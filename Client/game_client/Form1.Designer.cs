namespace game_client
{
    partial class Client
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.tb_portNum = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_request_pl = new System.Windows.Forms.Button();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_invite = new System.Windows.Forms.Button();
            this.tb_invite = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_inAccept = new System.Windows.Forms.Button();
            this.btn_inReject = new System.Windows.Forms.Button();
            this.lb_inAsk = new System.Windows.Forms.Label();
            this.tb_inSender = new System.Windows.Forms.TextBox();
            this.btn_surr = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_inGame = new System.Windows.Forms.TextBox();
            this.cmb_guess = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port Number:";
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(123, 54);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(100, 20);
            this.tb_IP.TabIndex = 2;
            // 
            // tb_portNum
            // 
            this.tb_portNum.Location = new System.Drawing.Point(123, 80);
            this.tb_portNum.Name = "tb_portNum";
            this.tb_portNum.Size = new System.Drawing.Size(100, 20);
            this.tb_portNum.TabIndex = 3;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(254, 33);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(109, 61);
            this.btn_connect.TabIndex = 4;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // rtb_output
            // 
            this.rtb_output.Location = new System.Drawing.Point(36, 164);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.ReadOnly = true;
            this.rtb_output.Size = new System.Drawing.Size(686, 307);
            this.rtb_output.TabIndex = 5;
            this.rtb_output.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Activities:";
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Enabled = false;
            this.btn_disconnect.Location = new System.Drawing.Point(378, 33);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(112, 61);
            this.btn_disconnect.TabIndex = 7;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_request_pl
            // 
            this.btn_request_pl.Enabled = false;
            this.btn_request_pl.Location = new System.Drawing.Point(498, 514);
            this.btn_request_pl.Name = "btn_request_pl";
            this.btn_request_pl.Size = new System.Drawing.Size(224, 31);
            this.btn_request_pl.TabIndex = 8;
            this.btn_request_pl.Text = "Request Player List";
            this.btn_request_pl.UseVisualStyleBackColor = true;
            this.btn_request_pl.Click += new System.EventHandler(this.btn_request_pl_Click);
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(123, 28);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(100, 20);
            this.tb_username.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Username:";
            // 
            // btn_invite
            // 
            this.btn_invite.Enabled = false;
            this.btn_invite.Location = new System.Drawing.Point(36, 514);
            this.btn_invite.Name = "btn_invite";
            this.btn_invite.Size = new System.Drawing.Size(224, 31);
            this.btn_invite.TabIndex = 11;
            this.btn_invite.Text = "Send Invitation";
            this.btn_invite.UseVisualStyleBackColor = true;
            this.btn_invite.Click += new System.EventHandler(this.btn_invite_Click);
            // 
            // tb_invite
            // 
            this.tb_invite.Enabled = false;
            this.tb_invite.Location = new System.Drawing.Point(132, 488);
            this.tb_invite.Name = "tb_invite";
            this.tb_invite.Size = new System.Drawing.Size(128, 20);
            this.tb_invite.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 491);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "User to be invited:";
            // 
            // btn_inAccept
            // 
            this.btn_inAccept.Enabled = false;
            this.btn_inAccept.Location = new System.Drawing.Point(302, 514);
            this.btn_inAccept.Name = "btn_inAccept";
            this.btn_inAccept.Size = new System.Drawing.Size(75, 31);
            this.btn_inAccept.TabIndex = 15;
            this.btn_inAccept.Text = "Accept";
            this.btn_inAccept.UseVisualStyleBackColor = true;
            this.btn_inAccept.Click += new System.EventHandler(this.btn_inAccept_Click);
            // 
            // btn_inReject
            // 
            this.btn_inReject.Enabled = false;
            this.btn_inReject.Location = new System.Drawing.Point(383, 514);
            this.btn_inReject.Name = "btn_inReject";
            this.btn_inReject.Size = new System.Drawing.Size(75, 31);
            this.btn_inReject.TabIndex = 16;
            this.btn_inReject.Text = "Reject";
            this.btn_inReject.UseVisualStyleBackColor = true;
            this.btn_inReject.Click += new System.EventHandler(this.btn_inReject_Click);
            // 
            // lb_inAsk
            // 
            this.lb_inAsk.AutoSize = true;
            this.lb_inAsk.Location = new System.Drawing.Point(299, 488);
            this.lb_inAsk.Name = "lb_inAsk";
            this.lb_inAsk.Size = new System.Drawing.Size(82, 13);
            this.lb_inAsk.TabIndex = 17;
            this.lb_inAsk.Text = "Invitation From: ";
            // 
            // tb_inSender
            // 
            this.tb_inSender.Enabled = false;
            this.tb_inSender.Location = new System.Drawing.Point(383, 484);
            this.tb_inSender.Name = "tb_inSender";
            this.tb_inSender.ReadOnly = true;
            this.tb_inSender.Size = new System.Drawing.Size(75, 20);
            this.tb_inSender.TabIndex = 18;
            // 
            // btn_surr
            // 
            this.btn_surr.Enabled = false;
            this.btn_surr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_surr.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_surr.Location = new System.Drawing.Point(545, 112);
            this.btn_surr.Name = "btn_surr";
            this.btn_surr.Size = new System.Drawing.Size(192, 29);
            this.btn_surr.TabIndex = 19;
            this.btn_surr.Text = "SURRENDER";
            this.btn_surr.UseVisualStyleBackColor = true;
            this.btn_surr.Click += new System.EventHandler(this.btn_surr_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(542, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "In Game With:";
            // 
            // tb_inGame
            // 
            this.tb_inGame.Enabled = false;
            this.tb_inGame.Location = new System.Drawing.Point(638, 6);
            this.tb_inGame.Name = "tb_inGame";
            this.tb_inGame.ReadOnly = true;
            this.tb_inGame.Size = new System.Drawing.Size(99, 20);
            this.tb_inGame.TabIndex = 21;
            // 
            // cmb_guess
            // 
            this.cmb_guess.AllowDrop = true;
            this.cmb_guess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_guess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_guess.Enabled = false;
            this.cmb_guess.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100"});
            this.cmb_guess.Location = new System.Drawing.Point(638, 44);
            this.cmb_guess.Name = "cmb_guess";
            this.cmb_guess.Size = new System.Drawing.Size(99, 21);
            this.cmb_guess.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(542, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Guess a number: \r\n";
            // 
            // btn_submit
            // 
            this.btn_submit.Enabled = false;
            this.btn_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_submit.Location = new System.Drawing.Point(545, 77);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(192, 29);
            this.btn_submit.TabIndex = 24;
            this.btn_submit.Text = "SUBMIT";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(791, 568);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_guess);
            this.Controls.Add(this.tb_inGame);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_surr);
            this.Controls.Add(this.tb_inSender);
            this.Controls.Add(this.lb_inAsk);
            this.Controls.Add(this.btn_inReject);
            this.Controls.Add(this.btn_inAccept);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_invite);
            this.Controls.Add(this.btn_invite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.btn_request_pl);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtb_output);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.tb_portNum);
            this.Controls.Add(this.tb_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.TextBox tb_portNum;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.RichTextBox rtb_output;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_request_pl;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_invite;
        private System.Windows.Forms.TextBox tb_invite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_inAccept;
        private System.Windows.Forms.Button btn_inReject;
        private System.Windows.Forms.Label lb_inAsk;
        private System.Windows.Forms.TextBox tb_inSender;
        private System.Windows.Forms.Button btn_surr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_inGame;
        private System.Windows.Forms.ComboBox cmb_guess;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_submit;
    }
}

