namespace VotemUp
{
    partial class VotemUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pathOfPlayerBox = new System.Windows.Forms.TextBox();
            this.pathOfPlayerButton = new System.Windows.Forms.Button();
            this.addBox = new System.Windows.Forms.TextBox();
            this.pathofPlaylistButton = new System.Windows.Forms.Button();
            this.pathofplayListBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.playListBox = new System.Windows.Forms.ListBox();
            this.loadPlaylistButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.voteListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.startServerButton = new System.Windows.Forms.Button();
            this.addUserButton = new System.Windows.Forms.Button();
            this.userBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.masterPwBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.currentMasterBox = new System.Windows.Forms.TextBox();
            this.newMasterBox = new System.Windows.Forms.TextBox();
            this.changeMasterButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.userList = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.daemonButton = new System.Windows.Forms.Button();
            this.songTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path of Player:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "add Command:";
            // 
            // pathOfPlayerBox
            // 
            this.pathOfPlayerBox.Location = new System.Drawing.Point(94, 6);
            this.pathOfPlayerBox.Name = "pathOfPlayerBox";
            this.pathOfPlayerBox.Size = new System.Drawing.Size(379, 20);
            this.pathOfPlayerBox.TabIndex = 2;
            // 
            // pathOfPlayerButton
            // 
            this.pathOfPlayerButton.Location = new System.Drawing.Point(479, 4);
            this.pathOfPlayerButton.Name = "pathOfPlayerButton";
            this.pathOfPlayerButton.Size = new System.Drawing.Size(30, 23);
            this.pathOfPlayerButton.TabIndex = 3;
            this.pathOfPlayerButton.Text = "...";
            this.pathOfPlayerButton.UseVisualStyleBackColor = true;
            this.pathOfPlayerButton.Click += new System.EventHandler(this.pathOfPlayerButton_Click);
            // 
            // addBox
            // 
            this.addBox.Location = new System.Drawing.Point(94, 32);
            this.addBox.Name = "addBox";
            this.addBox.Size = new System.Drawing.Size(122, 20);
            this.addBox.TabIndex = 4;
            this.addBox.Text = "/add";
            // 
            // pathofPlaylistButton
            // 
            this.pathofPlaylistButton.Location = new System.Drawing.Point(479, 124);
            this.pathofPlaylistButton.Name = "pathofPlaylistButton";
            this.pathofPlaylistButton.Size = new System.Drawing.Size(30, 23);
            this.pathofPlaylistButton.TabIndex = 7;
            this.pathofPlaylistButton.Text = "...";
            this.pathofPlaylistButton.UseVisualStyleBackColor = true;
            this.pathofPlaylistButton.Click += new System.EventHandler(this.pathofPlaylistButton_Click);
            // 
            // pathofplayListBox
            // 
            this.pathofplayListBox.Location = new System.Drawing.Point(94, 126);
            this.pathofplayListBox.Name = "pathofplayListBox";
            this.pathofplayListBox.Size = new System.Drawing.Size(379, 20);
            this.pathofplayListBox.TabIndex = 6;
            this.pathofplayListBox.Text = "D:\\Music\\test.playlist";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Path of Playlist:";
            // 
            // playListBox
            // 
            this.playListBox.FormattingEnabled = true;
            this.playListBox.Location = new System.Drawing.Point(15, 259);
            this.playListBox.Name = "playListBox";
            this.playListBox.Size = new System.Drawing.Size(403, 368);
            this.playListBox.TabIndex = 8;
            this.playListBox.SelectedValueChanged += new System.EventHandler(this.playListBox_SelectedValueChanged);
            // 
            // loadPlaylistButton
            // 
            this.loadPlaylistButton.Location = new System.Drawing.Point(206, 153);
            this.loadPlaylistButton.Name = "loadPlaylistButton";
            this.loadPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this.loadPlaylistButton.TabIndex = 9;
            this.loadPlaylistButton.Text = "Load";
            this.loadPlaylistButton.UseVisualStyleBackColor = true;
            this.loadPlaylistButton.Click += new System.EventHandler(this.loadPlaylistButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Playlist:";
            // 
            // voteListBox
            // 
            this.voteListBox.FormattingEnabled = true;
            this.voteListBox.Location = new System.Drawing.Point(424, 259);
            this.voteListBox.Name = "voteListBox";
            this.voteListBox.Size = new System.Drawing.Size(93, 368);
            this.voteListBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(421, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Votes:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 646);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 649);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "UID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 669);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Votes:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(72, 669);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 20);
            this.textBox2.TabIndex = 16;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(424, 633);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(93, 23);
            this.refreshButton.TabIndex = 17;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // startServerButton
            // 
            this.startServerButton.Location = new System.Drawing.Point(94, 152);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(106, 23);
            this.startServerButton.TabIndex = 18;
            this.startServerButton.Text = "Start Server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.startServerButton_Click);
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(675, 84);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(75, 23);
            this.addUserButton.TabIndex = 19;
            this.addUserButton.Text = "Add User";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(650, 6);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(100, 20);
            this.userBox.TabIndex = 20;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(650, 32);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(581, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Username:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(581, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Password:";
            // 
            // masterPwBox
            // 
            this.masterPwBox.Location = new System.Drawing.Point(650, 58);
            this.masterPwBox.Name = "masterPwBox";
            this.masterPwBox.PasswordChar = '*';
            this.masterPwBox.Size = new System.Drawing.Size(100, 20);
            this.masterPwBox.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(581, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Master PW:";
            // 
            // currentMasterBox
            // 
            this.currentMasterBox.Location = new System.Drawing.Point(650, 129);
            this.currentMasterBox.Name = "currentMasterBox";
            this.currentMasterBox.PasswordChar = '*';
            this.currentMasterBox.Size = new System.Drawing.Size(100, 20);
            this.currentMasterBox.TabIndex = 26;
            // 
            // newMasterBox
            // 
            this.newMasterBox.Location = new System.Drawing.Point(650, 156);
            this.newMasterBox.Name = "newMasterBox";
            this.newMasterBox.PasswordChar = '*';
            this.newMasterBox.Size = new System.Drawing.Size(100, 20);
            this.newMasterBox.TabIndex = 27;
            // 
            // changeMasterButton
            // 
            this.changeMasterButton.Location = new System.Drawing.Point(675, 182);
            this.changeMasterButton.Name = "changeMasterButton";
            this.changeMasterButton.Size = new System.Drawing.Size(75, 23);
            this.changeMasterButton.TabIndex = 28;
            this.changeMasterButton.Text = "Change";
            this.changeMasterButton.UseVisualStyleBackColor = true;
            this.changeMasterButton.Click += new System.EventHandler(this.changeMasterButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(544, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Current Master PW:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(591, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "New PW:";
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(639, 259);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(108, 368);
            this.userList.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(639, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Users:";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(672, 669);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 33;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // daemonButton
            // 
            this.daemonButton.Location = new System.Drawing.Point(94, 182);
            this.daemonButton.Name = "daemonButton";
            this.daemonButton.Size = new System.Drawing.Size(106, 23);
            this.daemonButton.TabIndex = 34;
            this.daemonButton.Text = "Start Daemon";
            this.daemonButton.UseVisualStyleBackColor = true;
            this.daemonButton.Click += new System.EventHandler(this.daemonButton_Click);
            // 
            // songTimer
            // 
            this.songTimer.Interval = 1000;
            this.songTimer.Tick += new System.EventHandler(this.songTimer_Tick);
            // 
            // VotemUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 698);
            this.Controls.Add(this.daemonButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.changeMasterButton);
            this.Controls.Add(this.newMasterBox);
            this.Controls.Add(this.currentMasterBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.masterPwBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.startServerButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.voteListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loadPlaylistButton);
            this.Controls.Add(this.playListBox);
            this.Controls.Add(this.pathofPlaylistButton);
            this.Controls.Add(this.pathofplayListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addBox);
            this.Controls.Add(this.pathOfPlayerButton);
            this.Controls.Add(this.pathOfPlayerBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VotemUp";
            this.Text = "VotemUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pathOfPlayerBox;
        private System.Windows.Forms.Button pathOfPlayerButton;
        private System.Windows.Forms.TextBox addBox;
        private System.Windows.Forms.Button pathofPlaylistButton;
        private System.Windows.Forms.TextBox pathofplayListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox playListBox;
        private System.Windows.Forms.Button loadPlaylistButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox voteListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox masterPwBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox currentMasterBox;
        private System.Windows.Forms.TextBox newMasterBox;
        private System.Windows.Forms.Button changeMasterButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button daemonButton;
        private System.Windows.Forms.Timer songTimer;
    }
}

