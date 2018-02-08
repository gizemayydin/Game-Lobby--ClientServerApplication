using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace game_client
{
    public partial class Client : Form
    {
        bool terminating = false; 
        private Socket client; //socket of the client
        string username; //username of the client
        int flag = 1;

        public Client()
        {
            InitializeComponent();
        }

        void Receive()
        {
            /*This function receives a byte buffer from the server, handling all the commands
              and notifications coming from the server and takes actions accordingly.*/

            while (!terminating)
            {
                try
                {
                    byte[] buffer = new byte[64];

                    int rec = client.Receive(buffer);

                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }

                    string newmessage = Encoding.Default.GetString(buffer);
                    newmessage = newmessage.Substring(0, newmessage.IndexOf("\0")); //delete the zeros

                    if (newmessage == "connected")
                    {
                        /*if the username is not used, the answer will be "connected", the user will be notified*/
                        btn_disconnect.Enabled = true;
                        btn_request_pl.Enabled = true;
                        tb_invite.Enabled = true;
                        btn_invite.Enabled = true;
                        btn_connect.Enabled = false;
                        rtb_output.AppendText(username + " is now connected\n");
                    }

                    else if (newmessage == "Reject")
                    {
                        /*if the username is already taken, the connection will be terminated and the user will be notified*/
                        rtb_output.AppendText(username + " is already connected.\nNew connection request rejected.\n");
                        rtb_output.AppendText("\nDisconnecting...\n");
                        btn_connect.Enabled = true;
                        btn_disconnect.Enabled = false;
                        btn_request_pl.Enabled = false;
                        tb_invite.Enabled = false;
                        btn_invite.Enabled = false;
                        terminating = true;
                    }


                    else if (newmessage == "close")
                    {
                        /*disconnects the client*/
                        rtb_output.AppendText("\nServer is shut down.\nDisconnecting...\n");
                        btn_connect.Enabled = true;
                        btn_disconnect.Enabled = false;
                        btn_request_pl.Enabled = false;
                        tb_invite.Enabled = false;
                        btn_invite.Enabled = false;
                        client.Close();
                    }

                    else if (newmessage.Substring(0, 4) == "Surr")
                    {
                        string opponent = newmessage.Substring(5);
                        rtb_output.AppendText(opponent + " has surrendered.\n\n*** YOU WON! ***\n\n");
                        btn_submit.Enabled = false;
                        cmb_guess.Enabled = false;
                        btn_surr.Enabled = false;
                        btn_invite.Enabled = true;
                        tb_inGame.Text = "";
                    }

                    else if (newmessage.Substring(0, 6) == "Invite")
                    {
                        string in_player = newmessage.Substring(7);
                        rtb_output.AppendText(in_player + " has send invitation to you!\n");
                        tb_inSender.Text = in_player;
                        btn_inAccept.Enabled = true;
                        btn_inReject.Enabled = true;
                    }

                    else if (newmessage.Substring(0, 7) == "No user")
                    {
                        /*if the username is already taken, the connection will be terminated and the user will be notified*/
                        string in_player = newmessage.Substring(8);
                        rtb_output.AppendText(in_player + " cannot be found.\nInvitation cannot be sent.\n");
                    }

                    else if (newmessage.Substring(0, 8) == "InAccept")
                    {
                        string receiver = newmessage.Substring(9);
                        rtb_output.AppendText(receiver + " accepted your invitation.\n\nGame has started!\n\n");
                        tb_inGame.Text = receiver;
                        btn_surr.Enabled = true;
                        btn_invite.Enabled = false;
                        btn_submit.Enabled = true;
                        cmb_guess.Enabled = true;
                        // Start game
                    }

                    else if (newmessage.Substring(0, 8) == "Game Won")
                    {
                        rtb_output.AppendText("Game is over.\n\n*** YOU WON! ***\n\n");
                        btn_surr.Enabled = false;
                        btn_invite.Enabled = true;
                        btn_submit.Enabled = false;
                        cmb_guess.Enabled = false;
                        tb_inGame.Text = "";

                        // Start game
                    }

                    else if (newmessage.Substring(0, 9) == "Game Lost")
                    {
                        rtb_output.AppendText("\n*** You lose! ***\n\n");
                        btn_surr.Enabled = false;
                        btn_invite.Enabled = true;
                        btn_submit.Enabled = false;
                        cmb_guess.Enabled = false;
                        tb_inGame.Text = "";
                        // Start game
                    }

                    else if (newmessage.Substring(0, 8) == "InReject")
                    {
                        string receiver = newmessage.Substring(9);
                        rtb_output.AppendText(receiver + " rejected your invitation!\n");
                    }

                    else if (newmessage.Substring(0, 10) == "Is in game")
                    {
                        /*if the username is already taken, the connection will be terminated and the user will be notified*/
                        string in_player = newmessage.Substring(11);
                        rtb_output.AppendText(in_player + " is currently playing with someone else / has a pending invitation.\nInvitation cannot be send.\n");
                    }

                    else if(newmessage.Substring(0, 11) == "Player Name")
                    {
                        rtb_output.AppendText(newmessage);
                    }
                    else if (newmessage.Substring(0, 12) == "Round Status")
                    {
                        rtb_output.AppendText(newmessage + "\n");
                        btn_submit.Enabled = true;
                        cmb_guess.Enabled = true;
                    }
                }
                catch
                {
                    terminating = true;
                    rtb_output.AppendText("\nDisconnected.\n");
                }
            }

            
        }

        void SendMessage(string message)
        {
            /*sends a message taken from the parameter to the server*/
            byte[] buffer = Encoding.Default.GetBytes(message);
            client.Send(buffer);
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                terminating = false;
                string serverIP; //IP of the server
                int serverPort; //port number to connect
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //create client's socet

                /*get the username and serverIP from the ricktextbox*/
                username = tb_username.Text;
                serverIP = tb_IP.Text;

                /*initial connection to the server*/
                serverPort = Convert.ToInt32(tb_portNum.Text);
                client.Connect(serverIP, serverPort);

                SendMessage(username); //send the username to the server for checking
                Thread thrServer = new Thread(new ThreadStart(Receive));
                thrServer.Start(); //start the accept thread for incoming connections
            }
            catch
            {
                rtb_output.AppendText("Can not connect to the specified server.\nTerminating...\n");
            }

        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            /*disconnects the client*/
            rtb_output.AppendText("\nDisconnecting...\n");
            btn_connect.Enabled = true;
            btn_disconnect.Enabled = false;
            btn_request_pl.Enabled = false;
            tb_invite.Enabled = false;
            btn_invite.Enabled = false;
            terminating = true;
            client.Close();
        }

        private void btn_request_pl_Click(object sender, EventArgs e)
        {
            /*the client sends a request message to the server for the current game lobby*/
            rtb_output.AppendText("Player list is requested from server.\n\n");
            try
            {
                SendMessage("request");
            }
            catch
            {
                rtb_output.AppendText("Server does not respond.\nConnection lost.\n");
            }
        }

        private void btn_invite_Click(object sender, EventArgs e)
        {
            string in_user = "Invite " + tb_invite.Text;
            try
            {
                rtb_output.AppendText("You have sent invitation request to " + in_user + ".\n");
                SendMessage(in_user);
                tb_invite.Text = "";
            }
            catch
            {
                rtb_output.AppendText("Server does not respond.\nConnection lost.\n");
            }
        }

        private void btn_inAccept_Click(object sender, EventArgs e)
        {
            string response = "InAccept " + tb_inSender.Text;
            try
            {
                rtb_output.AppendText("You accepted the invitation from " + tb_inSender.Text + ".\n\n");
                rtb_output.AppendText("Game has started!\n\n");
                SendMessage(response);
                btn_inAccept.Enabled = false;
                btn_inReject.Enabled = false;
                tb_inGame.Text = tb_inSender.Text;
                btn_invite.Enabled = false;
                btn_surr.Enabled = true;
                tb_inSender.Text = "";
                btn_submit.Enabled = true;
                cmb_guess.Enabled = true;
            }
            catch
            {
                rtb_output.AppendText("Server does not respond.\nConnection lost.\n");
            }
        }

        private void btn_inReject_Click(object sender, EventArgs e)
        {
            string response = "InReject " + tb_inSender.Text;
            try
            {
                rtb_output.AppendText("You rejected the invitation from " + tb_inSender.Text + ".\n");
                SendMessage(response);
                tb_inSender.Text = "";
                btn_inAccept.Enabled = false;
                btn_inReject.Enabled = false;
            }
            catch
            {
                rtb_output.AppendText("Server does not respond.\nConnection lost.\n");
            }
        }

        private void btn_surr_Click(object sender, EventArgs e)
        {
            string msg = "Surr " + tb_inGame.Text;
            try
            {
                rtb_output.AppendText("\n*** You lose! ***\n\n");
                SendMessage(msg);
                btn_surr.Enabled = false;
                tb_inGame.Text = "";
                btn_invite.Enabled = true;
                btn_submit.Enabled = false;
                cmb_guess.Enabled = false;

            }
            catch
            {
                rtb_output.AppendText("Server does not respond.\nConnection lost.\n");
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string msg = "Guessed " + cmb_guess.Text;
            try
            {
                rtb_output.AppendText("\nSubmitted the number.\n");
                SendMessage(msg);
                btn_submit.Enabled = false;
                cmb_guess.Enabled = false;
            }
            catch
            {
                rtb_output.AppendText("Server does not respond.\nConnection lost.\n");
            }
        }
    }
}
