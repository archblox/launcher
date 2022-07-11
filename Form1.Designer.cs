namespace ARCHBLOXLauncher1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AnimationHandler_SlideOutJoinBox = new System.Windows.Forms.Timer(this.components);
            this.JoinBox = new System.Windows.Forms.GroupBox();
            this.serverip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverport = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userid = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.HostBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.HostBTN = new System.Windows.Forms.Button();
            this.JoinBTN = new System.Windows.Forms.Button();
            this.UpdateBTN = new System.Windows.Forms.Button();
            this.AnimationHandler_SlideOutButtons = new System.Windows.Forms.Timer(this.components);
            this.AnimationHandler_SlideInButtons = new System.Windows.Forms.Timer(this.components);
            this.AnimationHandler_SlideInJoinBox = new System.Windows.Forms.Timer(this.components);
            this.BackBTN_Join = new System.Windows.Forms.Button();
            this.AnimationHandler_SlideInBackBTNJoin = new System.Windows.Forms.Timer(this.components);
            this.AnimationHandler_SlideOutBackBTNJoin = new System.Windows.Forms.Timer(this.components);
            this.BackBTN_Host = new System.Windows.Forms.Button();
            this.AnimationHandler_SlideOutBackBTNHost = new System.Windows.Forms.Timer(this.components);
            this.AnimationHandler_SlideInBackBTNHost = new System.Windows.Forms.Timer(this.components);
            this.AnimationHandler_SlideOutHostBox = new System.Windows.Forms.Timer(this.components);
            this.AnimationHandler_SlideInHostBox = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.JoinBox.SuspendLayout();
            this.HostBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::ARCHBLOXLauncher1.Properties.Resources.unknown;
            this.pictureBox1.Location = new System.Drawing.Point(54, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AnimationHandler_SlideOutJoinBox
            // 
            this.AnimationHandler_SlideOutJoinBox.Interval = 1;
            // 
            // JoinBox
            // 
            this.JoinBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(107)))), ((int)(((byte)(223)))));
            this.JoinBox.Controls.Add(this.serverip);
            this.JoinBox.Controls.Add(this.label4);
            this.JoinBox.Controls.Add(this.serverport);
            this.JoinBox.Controls.Add(this.label7);
            this.JoinBox.Controls.Add(this.label5);
            this.JoinBox.Controls.Add(this.userid);
            this.JoinBox.Controls.Add(this.username);
            this.JoinBox.Controls.Add(this.button2);
            this.JoinBox.Controls.Add(this.label6);
            this.JoinBox.Location = new System.Drawing.Point(400, 49);
            this.JoinBox.Name = "JoinBox";
            this.JoinBox.Size = new System.Drawing.Size(286, 192);
            this.JoinBox.TabIndex = 26;
            this.JoinBox.TabStop = false;
            // 
            // serverip
            // 
            this.serverip.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.serverip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.serverip.Location = new System.Drawing.Point(6, 40);
            this.serverip.MaxLength = 15;
            this.serverip.Name = "serverip";
            this.serverip.PlaceholderText = "IP";
            this.serverip.Size = new System.Drawing.Size(276, 23);
            this.serverip.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Server IP (Use localhost if joining your own server)";
            // 
            // serverport
            // 
            this.serverport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.serverport.Location = new System.Drawing.Point(6, 84);
            this.serverport.MaxLength = 5;
            this.serverport.Name = "serverport";
            this.serverport.PlaceholderText = "PORT";
            this.serverport.Size = new System.Drawing.Size(274, 23);
            this.serverport.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(6, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "Server Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(6, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Username";
            // 
            // userid
            // 
            this.userid.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userid.Location = new System.Drawing.Point(200, 131);
            this.userid.MaxLength = 8;
            this.userid.Name = "userid";
            this.userid.PlaceholderText = "UserID";
            this.userid.Size = new System.Drawing.Size(80, 23);
            this.userid.TabIndex = 22;
            this.userid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // username
            // 
            this.username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.username.Location = new System.Drawing.Point(6, 131);
            this.username.MaxLength = 20;
            this.username.Name = "username";
            this.username.PlaceholderText = "Username";
            this.username.Size = new System.Drawing.Size(188, 23);
            this.username.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.BackgroundImage = global::ARCHBLOXLauncher1.Properties.Resources.buttongreen;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(6, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(274, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Join";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(241, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "UserID";
            // 
            // HostBox
            // 
            this.HostBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(107)))), ((int)(((byte)(223)))));
            this.HostBox.Controls.Add(this.label2);
            this.HostBox.Controls.Add(this.textBox1);
            this.HostBox.Controls.Add(this.label3);
            this.HostBox.Controls.Add(this.button3);
            this.HostBox.Controls.Add(this.textBox2);
            this.HostBox.Controls.Add(this.button1);
            this.HostBox.Location = new System.Drawing.Point(400, 49);
            this.HostBox.Name = "HostBox";
            this.HostBox.Size = new System.Drawing.Size(288, 140);
            this.HostBox.TabIndex = 27;
            this.HostBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Port (53640 is recommended)";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(6, 37);
            this.textBox1.MaxLength = 5;
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "PORT";
            this.textBox1.Size = new System.Drawing.Size(274, 23);
            this.textBox1.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(4, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Filename (use temp.rbxl if unsure)";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::ARCHBLOXLauncher1.Properties.Resources.buttonblue;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(207, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Browse...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox2.Location = new System.Drawing.Point(6, 81);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Filename";
            this.textBox2.Size = new System.Drawing.Size(195, 23);
            this.textBox2.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.BackgroundImage = global::ARCHBLOXLauncher1.Properties.Resources.buttongreen;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(6, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(274, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Host";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HostBTN
            // 
            this.HostBTN.BackgroundImage = global::ARCHBLOXLauncher1.Properties.Resources.buttonblue;
            this.HostBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HostBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HostBTN.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HostBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HostBTN.Location = new System.Drawing.Point(-278, 130);
            this.HostBTN.Name = "HostBTN";
            this.HostBTN.Size = new System.Drawing.Size(276, 52);
            this.HostBTN.TabIndex = 28;
            this.HostBTN.Text = "Host a Game";
            this.HostBTN.UseVisualStyleBackColor = true;
            this.HostBTN.Click += new System.EventHandler(this.HostBTN_Click);
            // 
            // JoinBTN
            // 
            this.JoinBTN.BackgroundImage = global::ARCHBLOXLauncher1.Properties.Resources.buttonblue;
            this.JoinBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.JoinBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.JoinBTN.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.JoinBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.JoinBTN.Location = new System.Drawing.Point(-278, 188);
            this.JoinBTN.Name = "JoinBTN";
            this.JoinBTN.Size = new System.Drawing.Size(276, 52);
            this.JoinBTN.TabIndex = 29;
            this.JoinBTN.Text = "Join a Game";
            this.JoinBTN.UseVisualStyleBackColor = true;
            this.JoinBTN.Click += new System.EventHandler(this.JoinBTN_Click);
            // 
            // UpdateBTN
            // 
            this.UpdateBTN.BackgroundImage = global::ARCHBLOXLauncher1.Properties.Resources.buttonblue;
            this.UpdateBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpdateBTN.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UpdateBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UpdateBTN.Location = new System.Drawing.Point(-278, 74);
            this.UpdateBTN.Name = "UpdateBTN";
            this.UpdateBTN.Size = new System.Drawing.Size(276, 52);
            this.UpdateBTN.TabIndex = 30;
            this.UpdateBTN.Text = "Re-Install ARCHBLOX";
            this.UpdateBTN.UseVisualStyleBackColor = true;
            this.UpdateBTN.Click += new System.EventHandler(this.UpdateBTN_Click);
            // 
            // AnimationHandler_SlideOutButtons
            // 
            this.AnimationHandler_SlideOutButtons.Interval = 1;
            // 
            // AnimationHandler_SlideInButtons
            // 
            this.AnimationHandler_SlideInButtons.Interval = 1;
            // 
            // AnimationHandler_SlideInJoinBox
            // 
            this.AnimationHandler_SlideInJoinBox.Interval = 1;
            // 
            // BackBTN_Join
            // 
            this.BackBTN_Join.BackgroundImage = global::ARCHBLOXLauncher1.Properties.Resources.buttonblue;
            this.BackBTN_Join.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackBTN_Join.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackBTN_Join.Location = new System.Drawing.Point(258, -24);
            this.BackBTN_Join.Name = "BackBTN_Join";
            this.BackBTN_Join.Size = new System.Drawing.Size(42, 23);
            this.BackBTN_Join.TabIndex = 31;
            this.BackBTN_Join.Text = "Back";
            this.BackBTN_Join.UseVisualStyleBackColor = true;
            this.BackBTN_Join.Click += new System.EventHandler(this.BackBTN_Join_Click);
            // 
            // AnimationHandler_SlideInBackBTNJoin
            // 
            this.AnimationHandler_SlideInBackBTNJoin.Interval = 1;
            // 
            // AnimationHandler_SlideOutBackBTNJoin
            // 
            this.AnimationHandler_SlideOutBackBTNJoin.Interval = 1;
            // 
            // BackBTN_Host
            // 
            this.BackBTN_Host.BackgroundImage = global::ARCHBLOXLauncher1.Properties.Resources.buttonblue;
            this.BackBTN_Host.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackBTN_Host.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackBTN_Host.Location = new System.Drawing.Point(258, -24);
            this.BackBTN_Host.Name = "BackBTN_Host";
            this.BackBTN_Host.Size = new System.Drawing.Size(42, 23);
            this.BackBTN_Host.TabIndex = 32;
            this.BackBTN_Host.Text = "Back";
            this.BackBTN_Host.UseVisualStyleBackColor = true;
            this.BackBTN_Host.Click += new System.EventHandler(this.BackBTN_Host_Click);
            // 
            // AnimationHandler_SlideOutBackBTNHost
            // 
            this.AnimationHandler_SlideOutBackBTNHost.Interval = 1;
            // 
            // AnimationHandler_SlideInBackBTNHost
            // 
            this.AnimationHandler_SlideInBackBTNHost.Interval = 1;
            // 
            // AnimationHandler_SlideOutHostBox
            // 
            this.AnimationHandler_SlideOutHostBox.Interval = 1;
            // 
            // AnimationHandler_SlideInHostBox
            // 
            this.AnimationHandler_SlideInHostBox.Interval = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(107)))), ((int)(((byte)(223)))));
            this.BackgroundImage = global::ARCHBLOXLauncher1.Properties.Resources.animated;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(308, 259);
            this.Controls.Add(this.BackBTN_Host);
            this.Controls.Add(this.BackBTN_Join);
            this.Controls.Add(this.UpdateBTN);
            this.Controls.Add(this.JoinBTN);
            this.Controls.Add(this.HostBTN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.JoinBox);
            this.Controls.Add(this.HostBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ARCHBLOX Launcher";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.JoinBox.ResumeLayout(false);
            this.JoinBox.PerformLayout();
            this.HostBox.ResumeLayout(false);
            this.HostBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer AnimationHandler_SlideOutJoinBox;
        private System.Windows.Forms.GroupBox JoinBox;
        private System.Windows.Forms.TextBox serverip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userid;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox HostBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button HostBTN;
        private System.Windows.Forms.Button JoinBTN;
        private System.Windows.Forms.Button UpdateBTN;
        private System.Windows.Forms.Timer AnimationHandler_SlideOutButtons;
        private System.Windows.Forms.Timer AnimationHandler_SlideInButtons;
        private System.Windows.Forms.Timer AnimationHandler_SlideInJoinBox;
        private System.Windows.Forms.Button BackBTN_Join;
        private System.Windows.Forms.Timer AnimationHandler_SlideInBackBTNJoin;
        private System.Windows.Forms.Timer AnimationHandler_SlideOutBackBTNJoin;
        private System.Windows.Forms.Button BackBTN_Host;
        private System.Windows.Forms.Timer AnimationHandler_SlideOutBackBTNHost;
        private System.Windows.Forms.Timer AnimationHandler_SlideInBackBTNHost;
        private System.Windows.Forms.Timer AnimationHandler_SlideOutHostBox;
        private System.Windows.Forms.Timer AnimationHandler_SlideInHostBox;
    }
}
