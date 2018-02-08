using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Security.Cryptography;


namespace game_server
{
    public partial class Form1 : Form
    {
        /*control flags*/

        class Player
        {
            // Struct holds the connection Socket and connections username.
            public string username;
            public Socket s;
            public int score;

            public int secret_num;
            public int rounds_won;
            public int guessed;
            public int submissions;

            public Player opponent;
            /*
            public bool ingame;

            public void SetIngameTrue()
            {
                ingame = true;
            }
            public void SetIngameFalse()
            {
                ingame = false;
            }

            public bool GetIngame()
            {
                return ingame;
            }
            */

        };
        bool terminating = false;
        bool accept = true;

        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//create the server socket
        List<Player> playerList= new List<Player>();//each element of the list holds a user's username and his/her socket
        List<Player> playing = new List<Player>();


        bool UsernameCheck(string username)
        {
            /*returns true if the username is available, returns false if the user is already connected*/
            bool isExist = false;

            for (int i = 0; i < playerList.Count && !isExist; i++)
            {
                if (username == playerList[i].username)
                {
                    isExist = true;
                }
            }

            return !isExist;
        }

        void SendMessage(string message, Socket n)
        {
            /*sends a message to the client that has socket n*/
            byte[] buffer = Encoding.Default.GetBytes(message);
            
            n.Send(buffer);
        }

        bool isPlaying(string playername)
        {
            for (int i = 0; i < playing.Count; i++)
            {
                if (playername == playing[i].username)
                {
                    return true;
                }
            }

            return false;
        }

        string GetPlayers()
        {
            /*stores the list of the players in a string and returns it*/
            String players = "Player Name\tScore:\n";
            for (int g = 0; g < playerList.Count; g++)
            {
                players += playerList[g].username + "\t\t" + playerList[g].score + " \n";
            }

            return players;
        }

        private void Receive(Object arg)
        {
            bool connected = true;
            Array argArray = new object[1]; // Array is created to extract and cast the parameter variable to Player class.
            argArray = (Array)arg;
            Player p = (Player)argArray.GetValue(0); // Convert Object parameter to  array and extract the Player value.
            Socket n = p.s; // Socket of the player

            while (connected)
            {
                try
                {
                    /*receive a byte buffer and convert it to string. if the message is "request", send the playerlist to the client
                     Notify the user of each step
                     If a client is disconnected, remove it from the playerList.*/
                    Byte[] buffer = new byte[64];
                    int rec = n.Receive(buffer);

                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }

                    string newmessage = Encoding.Default.GetString(buffer);
                    newmessage = newmessage.Substring(0, newmessage.IndexOf("\0"));

                    if (newmessage == "request")
                    {
                        rtb_output.AppendText(p.username + " requested the player list.\n");
                        string players = GetPlayers(); 
                        SendMessage(players,n);
                        rtb_playerList.Text = players;
                        rtb_output.AppendText("Player list has been sent to " + p.username + "\n");
                    }

                    else if (newmessage.Substring(0, 4) == "Surr")
                    {
                        string winner = newmessage.Substring(5);
                        string loser = p.username;
                        rtb_output.AppendText(loser + " has surrendered." + winner + " won.\n");
                        p.opponent.score++;

                        for (int i = 0; i < playerList.Count; i++)
                        {
                            if (playerList[i].username == winner)
                            {
                                // Send invite to the invited player with the username of the sender of invitation.
                                string res = "Surr " + loser;
                                SendMessage(res, playerList[i].s);
                                playing.Remove(playerList[i]);
                                playing.Remove(p);
                            }
                        }
                    }

                    else if (newmessage.Substring(0, 6) == "Invite")
                    {
                        string in_player = newmessage.Substring(7, newmessage.Length - 7);

                        if (!UsernameCheck(in_player))
                        {
                            // If invited user is in playerlist, send invitation.

                            for (int i = 0; i < playerList.Count; i++)
                            {
                                if (playerList[i].username == in_player)
                                {
                                    // Send invite to the invited player with the username of the sender of invitation.
                                    string send_invite = "Invite " + p.username;
                                    if (!isPlaying(in_player) && !isPlaying(p.username) && in_player != p.username)
                                    {
                                        rtb_output.AppendText(p.username + " has sent invitation to " + in_player + "\n");
                                        SendMessage(send_invite, playerList[i].s);
                                        playing.Add(playerList[i]);
                                        playing.Add(p);
                                    }

                                    else
                                    {
                                        rtb_output.AppendText(in_player + " is currently playing with someone else / has a pending ivitation.\n Invitation can not be send.\n");
                                        SendMessage("Is in game " + in_player, n);
                                    }
                                }
                            }
                        }

                        else
                        {
                            rtb_output.AppendText("There is no user named " + in_player + ".\n Invitation cannot be sent.\n");
                            SendMessage("No user " + in_player,n);
                        }
                    }

                    else if (newmessage.Substring(0,8) == "InAccept")
                    {
                        string sender = newmessage.Substring(9);
                        string receiver = p.username;
                        rtb_output.AppendText(receiver + " accepted the invitation from " + sender + ".\n");
                        rtb_output.AppendText(receiver + " and " + sender + " are in a game now.\n");

                        for (int i = 0; i < playerList.Count; i++)
                        {
                            if (playerList[i].username == sender)
                            {
                                // Send invite to the invited player with the username of the sender of invitation.
                                string res_invite = "InAccept " + receiver;
                                SendMessage(res_invite, playerList[i].s);
                                p.rounds_won = 0;
                                p.opponent = playerList[i];
                                p.opponent.rounds_won = 0;
                                p.opponent.opponent = p;
                                Random rand = new Random();
                                p.secret_num = rand.Next(0,100);
                                p.opponent.secret_num = p.secret_num;
                            }
                        }
                    }

                    else if (newmessage.Substring(0, 8) == "Guessed ")
                    {
                        int gnum = Convert.ToInt32(newmessage.Substring(8));    // Retrieve number from client.
                        p.guessed = gnum;
                        rtb_output.AppendText(p.username + " guessed: " + p.guessed + ".\n");
                        p.submissions++; // Increment number of submissions.

                        if (p.opponent.submissions == 1)
                        {

                            int res1 = p.secret_num - p.guessed, res2 = p.opponent.secret_num - p.opponent.guessed;
                            rtb_output.AppendText("Secret number: " + p.secret_num + ".\n");
                            if (res1 < 0)
                            {
                                res1 *= -1;
                            }
                            if (res2 < 0)
                            {
                                res2 *= -1;
                            }

                            if (res1 < res2)
                            {
                                p.rounds_won++;
                                rtb_output.AppendText(p.username + " won the round against " + p.opponent.username + ".\n");
                            }
                            else if (res2 < res1)
                            {
                                p.opponent.rounds_won++;
                                rtb_output.AppendText(p.opponent.username + " won the round against " + p.username + ".\n");
                            }
                            else
                            {
                                rtb_output.AppendText("Round is tied.\n");
                            }
                            SendMessage("Round Status: " + p.username + " " + p.rounds_won + " , " + p.opponent.username + " " + p.opponent.rounds_won + ".", p.s);
                            SendMessage("Round Status: " + p.username + " " + p.rounds_won + " , " + p.opponent.username + " " + p.opponent.rounds_won + ".", p.opponent.s);
                            Random rand = new Random();
                            p.secret_num = rand.Next(0, 100);
                            p.opponent.secret_num = p.secret_num;
                            p.submissions = 0;
                            p.opponent.submissions = 0;
                        }
                        if (p.rounds_won == 2)
                        {
                            rtb_output.AppendText("Game Over\n" + p.username + " has won, " + p.opponent.username + " has lost.\n" );
                            SendMessage("Game Won" , p.s);
                            SendMessage("Game Lost" , p.opponent.s);
                            p.rounds_won = 0;
                            p.opponent.rounds_won = 0;
                            p.score++;
                            playing.Remove(p);
                            playing.Remove(p.opponent);
                        }
                        else if (p.opponent.rounds_won == 2)
                        {
                            rtb_output.AppendText("Game Over\n" + p.opponent.username + " has won, " + p.username + " has lost.\n");
                            SendMessage("Game Won", p.opponent.s);
                            SendMessage("Game Lost", p.s);
                            p.rounds_won = 0;
                            p.opponent.rounds_won = 0;
                            p.opponent.score++;
                            playing.Remove(p);
                            playing.Remove(p.opponent);
                        }
                    }

                    else if (newmessage.Substring(0, 8) == "InReject")
                    {
                        string sender = newmessage.Substring(9);
                        string receiver = p.username;
                        rtb_output.AppendText(receiver + " rejected the invitation from " + sender + ".\n");

                        for (int i = 0; i < playerList.Count; i++)
                        {
                            if (playerList[i].username == sender)
                            {
                                // Send invite to the invited player with the username of the sender of invitation.
                                string res_invite = "InReject " + receiver;
                                SendMessage(res_invite, playerList[i].s);

                                playing.Remove(playerList[i]);
                                playing.Remove(p);
                            }
                        }
                    }

                }
                catch
                {
                    rtb_output.AppendText("Client has disconnected...\n");
                    if (isPlaying(p.username))
                    {
                        rtb_output.AppendText("Game Over\n" + p.opponent.username + " has won, " + p.username + " has lost.\n");
                        SendMessage("Game Won", p.opponent.s);
                        p.opponent.secret_num = p.secret_num;
                        p.opponent.submissions = 0;
                        p.opponent.rounds_won = 0;
                        p.opponent.score++;
                        playing.Remove(p);
                        playing.Remove(p.opponent);
                    }
                    playerList.Remove(p);
                    n.Close();
                    rtb_playerList.Text = GetPlayers();
                    connected = false;
                }
            }

        }

        private void Accept()
        {
            /*accepts an incoming client, checks its username, reject the request if the user is already connected */
            while (accept)
            {
                try
                {
                    /*connect the client*/
                    Socket n = server.Accept();

                    Byte[] buffer = new byte[64];
                    int rec = n.Receive(buffer);

                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }

                    string username = Encoding.Default.GetString(buffer);
                    username = username.Substring(0, username.IndexOf("\0"));
                    
                    if (UsernameCheck(username))
                    {
                        /*If the username is applicable, notify the client that it is connected, add the client
                         to player list,  and start the receive thread for incoming requests.*/
                        SendMessage("connected", n);

                        rtb_output.AppendText(username + " is now connected.\n");

                        Player current = new Player();  // Create Player object to hold corresponding Socket and username
                        current.username = username;
                        current.s = n;
                        current.score = 0;
                        playerList.Add(current);    // Add the new connection to the list
                        Thread thrReceive;
                        Object arg = new object[1] {current};
                        thrReceive = new Thread(new ParameterizedThreadStart(Receive)); // This thread is created for each and every distinct client connection.
                        thrReceive.Start(arg);
                        rtb_playerList.Text = GetPlayers();
                    }

                    else
                    {
                        /*terminate the connection in case of username error*/
                        rtb_output.AppendText(username + " is already connected. New connection request rejected.\n");
                        SendMessage("Reject", n);
                        n.Close();
                    }
       
                }
                catch
                {
                    if (terminating)
                        accept = false;
                    else
                        rtb_output.AppendText("Listening socket has stopped working...\n");
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int serverPort; 
            Thread thrAccept;

            serverPort = Convert.ToInt32(tb_portNum.Text);

            try
            {
                server.Bind(new IPEndPoint(IPAddress.Any, serverPort)); //connect the server
                rtb_output.AppendText("The server started listening for player connections.\n");
                server.Listen(8); //8 is themaximum length of the pending connections queue
                thrAccept = new Thread(new ThreadStart(Accept));
                thrAccept.Start(); //start the accept thread for incoming connections
            }
            catch
            {
                rtb_output.AppendText("Cannot create a server with the specified port number\nCheck the port number and try again.\nterminating...\n");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            /*Notify all clients connected to the server that the server is being shut down, 
              then close the server and the gui when exit button is clicked*/

            for (int i = 0; i < playerList.Count; i++)
            {
                SendMessage("close", playerList[i].s);
            }            
            server.Close();
            Application.Exit();
        }
    }
}
