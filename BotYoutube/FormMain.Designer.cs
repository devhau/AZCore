namespace BotYoutube
{
    partial class FormMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.grbServer = new System.Windows.Forms.GroupBox();
            this.pnMainServer = new System.Windows.Forms.Panel();
            this.btnDisconnect = new BotYoutube.UI.Controls.BButton();
            this.pnInfo = new System.Windows.Forms.Panel();
            this.btnLogout = new BotYoutube.UI.Controls.BButton();
            this.btnStartWork = new BotYoutube.UI.Controls.BButton();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new BotYoutube.UI.Controls.BTextbox();
            this.txtUser = new BotYoutube.UI.Controls.BTextbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtConnect = new BotYoutube.UI.Controls.BTextbox();
            this.btnConnect = new BotYoutube.UI.Controls.BButton();
            this.grbLocal = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbkLinkLoop = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbkTaskView = new System.Windows.Forms.CheckBox();
            this.cbkTaskComment = new System.Windows.Forms.CheckBox();
            this.cbkTaskSub = new System.Windows.Forms.CheckBox();
            this.cbkTaskDisLike = new System.Windows.Forms.CheckBox();
            this.cbkTaskLike = new System.Windows.Forms.CheckBox();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtLocalLink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocalProxy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.managerUser1 = new BotYoutube.Manager.User.ManagerUser();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.managerBot1 = new BotYoutube.Manager.Bot.ManagerBot();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.managerLink1 = new BotYoutube.Manager.Link.ManagerLink();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.managerAccYoutube1 = new BotYoutube.Manager.AccYoutube.ManagerAccYoutube();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.managerProxy1 = new BotYoutube.Manager.Proxy.ManagerProxy();
            this.tabConnect = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodeBotConnect = new BotYoutube.UI.Controls.BTextbox();
            this.tabProxyFree = new System.Windows.Forms.TabPage();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.pnMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.grbServer.SuspendLayout();
            this.pnMainServer.SuspendLayout();
            this.pnInfo.SuspendLayout();
            this.pnLogin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbLocal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.tabAdmin.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.tabControl1);
            this.pnMain.Location = new System.Drawing.Point(2, 51);
            this.pnMain.Size = new System.Drawing.Size(1096, 748);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabHome);
            this.tabControl1.Controls.Add(this.tabAdmin);
            this.tabControl1.Controls.Add(this.tabProxyFree);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1096, 748);
            this.tabControl1.TabIndex = 0;
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.grbServer);
            this.tabHome.Controls.Add(this.grbLocal);
            this.tabHome.Location = new System.Drawing.Point(4, 37);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(1088, 707);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // grbServer
            // 
            this.grbServer.Controls.Add(this.pnMainServer);
            this.grbServer.Controls.Add(this.panel2);
            this.grbServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbServer.Location = new System.Drawing.Point(3, 356);
            this.grbServer.Name = "grbServer";
            this.grbServer.Size = new System.Drawing.Size(1082, 348);
            this.grbServer.TabIndex = 18;
            this.grbServer.TabStop = false;
            this.grbServer.Text = "Server";
            // 
            // pnMainServer
            // 
            this.pnMainServer.Controls.Add(this.btnDisconnect);
            this.pnMainServer.Controls.Add(this.pnInfo);
            this.pnMainServer.Controls.Add(this.pnLogin);
            this.pnMainServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMainServer.Location = new System.Drawing.Point(3, 29);
            this.pnMainServer.Name = "pnMainServer";
            this.pnMainServer.Size = new System.Drawing.Size(1076, 316);
            this.pnMainServer.TabIndex = 2;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Yellow;
            this.btnDisconnect.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnDisconnect.Location = new System.Drawing.Point(21, 19);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(197, 61);
            this.btnDisconnect.TabIndex = 12;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // pnInfo
            // 
            this.pnInfo.Controls.Add(this.btnLogout);
            this.pnInfo.Controls.Add(this.btnStartWork);
            this.pnInfo.Controls.Add(this.lblUserInfo);
            this.pnInfo.Location = new System.Drawing.Point(242, 3);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(561, 210);
            this.pnInfo.TabIndex = 11;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLogout.Font = new System.Drawing.Font("Meiryo UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnLogout.Location = new System.Drawing.Point(285, 122);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(235, 64);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnStartWork
            // 
            this.btnStartWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStartWork.Font = new System.Drawing.Font("Meiryo UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartWork.ForeColor = System.Drawing.Color.White;
            this.btnStartWork.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnStartWork.Location = new System.Drawing.Point(44, 122);
            this.btnStartWork.Name = "btnStartWork";
            this.btnStartWork.Size = new System.Drawing.Size(235, 64);
            this.btnStartWork.TabIndex = 1;
            this.btnStartWork.Text = "Start Bot";
            this.btnStartWork.UseVisualStyleBackColor = false;
            this.btnStartWork.Click += new System.EventHandler(this.btnStartWork_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Location = new System.Drawing.Point(39, 33);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(0, 25);
            this.lblUserInfo.TabIndex = 0;
            // 
            // pnLogin
            // 
            this.pnLogin.Controls.Add(this.label7);
            this.pnLogin.Controls.Add(this.label6);
            this.pnLogin.Controls.Add(this.btnLogin);
            this.pnLogin.Controls.Add(this.txtPassword);
            this.pnLogin.Controls.Add(this.txtUser);
            this.pnLogin.Location = new System.Drawing.Point(242, 3);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(561, 210);
            this.pnLogin.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Pass";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "User";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Meiryo UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(179, 116);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(216, 70);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.KeyCommand = System.Windows.Forms.Keys.None;
            this.txtPassword.Location = new System.Drawing.Point(134, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(316, 33);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.KeyCommand = System.Windows.Forms.Keys.None;
            this.txtUser.Location = new System.Drawing.Point(134, 25);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(316, 33);
            this.txtUser.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtConnect);
            this.panel2.Controls.Add(this.btnConnect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 316);
            this.panel2.TabIndex = 0;
            // 
            // txtConnect
            // 
            this.txtConnect.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnect.KeyCommand = System.Windows.Forms.Keys.None;
            this.txtConnect.Location = new System.Drawing.Point(222, 52);
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.Size = new System.Drawing.Size(632, 41);
            this.txtConnect.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnConnect.Location = new System.Drawing.Point(222, 100);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(632, 64);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grbLocal
            // 
            this.grbLocal.Controls.Add(this.txtComment);
            this.grbLocal.Controls.Add(this.label5);
            this.grbLocal.Controls.Add(this.cbkLinkLoop);
            this.grbLocal.Controls.Add(this.groupBox1);
            this.grbLocal.Controls.Add(this.numDelay);
            this.grbLocal.Controls.Add(this.label3);
            this.grbLocal.Controls.Add(this.btnStart);
            this.grbLocal.Controls.Add(this.txtLocalLink);
            this.grbLocal.Controls.Add(this.label1);
            this.grbLocal.Controls.Add(this.txtLocalProxy);
            this.grbLocal.Controls.Add(this.label2);
            this.grbLocal.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbLocal.Location = new System.Drawing.Point(3, 3);
            this.grbLocal.Name = "grbLocal";
            this.grbLocal.Size = new System.Drawing.Size(1082, 353);
            this.grbLocal.TabIndex = 17;
            this.grbLocal.TabStop = false;
            this.grbLocal.Text = "Local";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(730, 51);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(346, 114);
            this.txtComment.TabIndex = 17;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(730, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Comment";
            // 
            // cbkLinkLoop
            // 
            this.cbkLinkLoop.AutoSize = true;
            this.cbkLinkLoop.Location = new System.Drawing.Point(177, 203);
            this.cbkLinkLoop.Name = "cbkLinkLoop";
            this.cbkLinkLoop.Size = new System.Drawing.Size(131, 29);
            this.cbkLinkLoop.TabIndex = 6;
            this.cbkLinkLoop.Text = "Link Loop";
            this.cbkLinkLoop.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Controls.Add(this.cbkTaskView);
            this.groupBox1.Controls.Add(this.cbkTaskComment);
            this.groupBox1.Controls.Add(this.cbkTaskSub);
            this.groupBox1.Controls.Add(this.cbkTaskDisLike);
            this.groupBox1.Controls.Add(this.cbkTaskLike);
            this.groupBox1.Location = new System.Drawing.Point(32, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 100);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // cbkTaskView
            // 
            this.cbkTaskView.AutoSize = true;
            this.cbkTaskView.Checked = true;
            this.cbkTaskView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkTaskView.Location = new System.Drawing.Point(22, 43);
            this.cbkTaskView.Name = "cbkTaskView";
            this.cbkTaskView.Size = new System.Drawing.Size(86, 29);
            this.cbkTaskView.TabIndex = 11;
            this.cbkTaskView.Text = "View";
            this.cbkTaskView.UseVisualStyleBackColor = true;
            // 
            // cbkTaskComment
            // 
            this.cbkTaskComment.AutoSize = true;
            this.cbkTaskComment.Enabled = false;
            this.cbkTaskComment.Location = new System.Drawing.Point(392, 43);
            this.cbkTaskComment.Name = "cbkTaskComment";
            this.cbkTaskComment.Size = new System.Drawing.Size(133, 29);
            this.cbkTaskComment.TabIndex = 15;
            this.cbkTaskComment.Text = "Comment";
            this.cbkTaskComment.UseVisualStyleBackColor = true;
            // 
            // cbkTaskSub
            // 
            this.cbkTaskSub.AutoSize = true;
            this.cbkTaskSub.Location = new System.Drawing.Point(114, 43);
            this.cbkTaskSub.Name = "cbkTaskSub";
            this.cbkTaskSub.Size = new System.Drawing.Size(75, 29);
            this.cbkTaskSub.TabIndex = 12;
            this.cbkTaskSub.Text = "Sub";
            this.cbkTaskSub.UseVisualStyleBackColor = true;
            // 
            // cbkTaskDisLike
            // 
            this.cbkTaskDisLike.AutoSize = true;
            this.cbkTaskDisLike.Location = new System.Drawing.Point(278, 43);
            this.cbkTaskDisLike.Name = "cbkTaskDisLike";
            this.cbkTaskDisLike.Size = new System.Drawing.Size(107, 29);
            this.cbkTaskDisLike.TabIndex = 14;
            this.cbkTaskDisLike.Text = "DisLike";
            this.cbkTaskDisLike.UseVisualStyleBackColor = true;
            // 
            // cbkTaskLike
            // 
            this.cbkTaskLike.AutoSize = true;
            this.cbkTaskLike.Location = new System.Drawing.Point(195, 43);
            this.cbkTaskLike.Name = "cbkTaskLike";
            this.cbkTaskLike.Size = new System.Drawing.Size(77, 29);
            this.cbkTaskLike.TabIndex = 13;
            this.cbkTaskLike.Text = "Like";
            this.cbkTaskLike.UseVisualStyleBackColor = true;
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(32, 203);
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(120, 33);
            this.numDelay.TabIndex = 4;
            this.numDelay.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Delay(s)";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.GreenYellow;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Meiryo UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(794, 243);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(236, 100);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtLocalLink
            // 
            this.txtLocalLink.Location = new System.Drawing.Point(24, 51);
            this.txtLocalLink.Multiline = true;
            this.txtLocalLink.Name = "txtLocalLink";
            this.txtLocalLink.Size = new System.Drawing.Size(349, 114);
            this.txtLocalLink.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Link";
            // 
            // txtLocalProxy
            // 
            this.txtLocalProxy.Location = new System.Drawing.Point(379, 51);
            this.txtLocalProxy.Multiline = true;
            this.txtLocalProxy.Name = "txtLocalProxy";
            this.txtLocalProxy.Size = new System.Drawing.Size(345, 114);
            this.txtLocalProxy.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Proxy";
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabControl2);
            this.tabAdmin.Location = new System.Drawing.Point(4, 37);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Size = new System.Drawing.Size(290, 207);
            this.tabAdmin.TabIndex = 1;
            this.tabAdmin.Text = "Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabConnect);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(284, 201);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.managerUser1);
            this.tabPage5.Location = new System.Drawing.Point(4, 37);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(276, 160);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "User";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // managerUser1
            // 
            this.managerUser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.managerUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerUser1.Location = new System.Drawing.Point(3, 3);
            this.managerUser1.Margin = new System.Windows.Forms.Padding(4);
            this.managerUser1.Name = "managerUser1";
            this.managerUser1.Padding = new System.Windows.Forms.Padding(2);
            this.managerUser1.Size = new System.Drawing.Size(270, 154);
            this.managerUser1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.managerBot1);
            this.tabPage6.Location = new System.Drawing.Point(4, 37);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1074, 660);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Bot";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // managerBot1
            // 
            this.managerBot1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.managerBot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerBot1.Location = new System.Drawing.Point(3, 3);
            this.managerBot1.Margin = new System.Windows.Forms.Padding(4);
            this.managerBot1.Name = "managerBot1";
            this.managerBot1.Padding = new System.Windows.Forms.Padding(2);
            this.managerBot1.Size = new System.Drawing.Size(1068, 654);
            this.managerBot1.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.managerLink1);
            this.tabPage7.Location = new System.Drawing.Point(4, 37);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1074, 660);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Link";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // managerLink1
            // 
            this.managerLink1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.managerLink1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerLink1.Location = new System.Drawing.Point(3, 3);
            this.managerLink1.Margin = new System.Windows.Forms.Padding(4);
            this.managerLink1.Name = "managerLink1";
            this.managerLink1.Padding = new System.Windows.Forms.Padding(2);
            this.managerLink1.Size = new System.Drawing.Size(1068, 654);
            this.managerLink1.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.managerAccYoutube1);
            this.tabPage8.Location = new System.Drawing.Point(4, 37);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1074, 660);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Acc Youtube";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // managerAccYoutube1
            // 
            this.managerAccYoutube1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.managerAccYoutube1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerAccYoutube1.Location = new System.Drawing.Point(3, 3);
            this.managerAccYoutube1.Margin = new System.Windows.Forms.Padding(4);
            this.managerAccYoutube1.Name = "managerAccYoutube1";
            this.managerAccYoutube1.Padding = new System.Windows.Forms.Padding(2);
            this.managerAccYoutube1.Size = new System.Drawing.Size(1068, 654);
            this.managerAccYoutube1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.managerProxy1);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1074, 660);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Proxy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // managerProxy1
            // 
            this.managerProxy1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.managerProxy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerProxy1.Location = new System.Drawing.Point(3, 3);
            this.managerProxy1.Margin = new System.Windows.Forms.Padding(4);
            this.managerProxy1.Name = "managerProxy1";
            this.managerProxy1.Padding = new System.Windows.Forms.Padding(2);
            this.managerProxy1.Size = new System.Drawing.Size(1068, 654);
            this.managerProxy1.TabIndex = 0;
            // 
            // tabConnect
            // 
            this.tabConnect.Controls.Add(this.label4);
            this.tabConnect.Controls.Add(this.txtCodeBotConnect);
            this.tabConnect.Location = new System.Drawing.Point(4, 37);
            this.tabConnect.Name = "tabConnect";
            this.tabConnect.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnect.Size = new System.Drawing.Size(1074, 660);
            this.tabConnect.TabIndex = 4;
            this.tabConnect.Text = "Setting";
            this.tabConnect.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Code Bot";
            // 
            // txtCodeBotConnect
            // 
            this.txtCodeBotConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtCodeBotConnect.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeBotConnect.KeyCommand = System.Windows.Forms.Keys.None;
            this.txtCodeBotConnect.Location = new System.Drawing.Point(113, 6);
            this.txtCodeBotConnect.Name = "txtCodeBotConnect";
            this.txtCodeBotConnect.ReadOnly = true;
            this.txtCodeBotConnect.Size = new System.Drawing.Size(466, 41);
            this.txtCodeBotConnect.TabIndex = 0;
            // 
            // tabProxyFree
            // 
            this.tabProxyFree.Location = new System.Drawing.Point(4, 37);
            this.tabProxyFree.Name = "tabProxyFree";
            this.tabProxyFree.Padding = new System.Windows.Forms.Padding(3);
            this.tabProxyFree.Size = new System.Drawing.Size(290, 207);
            this.tabProxyFree.TabIndex = 2;
            this.tabProxyFree.Text = "Proxy Free";
            this.tabProxyFree.UseVisualStyleBackColor = true;
            // 
            // tabAbout
            // 
            this.tabAbout.Location = new System.Drawing.Point(4, 37);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(290, 207);
            this.tabAbout.TabIndex = 3;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.MaximumSize = new System.Drawing.Size(1100, 800);
            this.MinimumSize = new System.Drawing.Size(1100, 800);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Text = "Bot Youtube";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.grbServer.ResumeLayout(false);
            this.pnMainServer.ResumeLayout(false);
            this.pnInfo.ResumeLayout(false);
            this.pnInfo.PerformLayout();
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbLocal.ResumeLayout(false);
            this.grbLocal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.tabAdmin.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabConnect.ResumeLayout(false);
            this.tabConnect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.TabPage tabProxyFree;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalProxy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.CheckBox cbkLinkLoop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox cbkTaskView;
        private System.Windows.Forms.CheckBox cbkTaskSub;
        private System.Windows.Forms.CheckBox cbkTaskLike;
        private System.Windows.Forms.CheckBox cbkTaskDisLike;
        private System.Windows.Forms.CheckBox cbkTaskComment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grbServer;
        private System.Windows.Forms.GroupBox grbLocal;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label5;
        private Manager.User.ManagerUser managerUser1;
        private Manager.Link.ManagerLink managerLink1;
        private Manager.Bot.ManagerBot managerBot1;
        private Manager.AccYoutube.ManagerAccYoutube managerAccYoutube1;
        private System.Windows.Forms.Panel panel2;
        private UI.Controls.BButton btnConnect;
        private UI.Controls.BTextbox txtConnect;
        private System.Windows.Forms.TabPage tabConnect;
        private System.Windows.Forms.Label label4;
        private UI.Controls.BTextbox txtCodeBotConnect;
        private System.Windows.Forms.Panel pnMainServer;
        private System.Windows.Forms.Panel pnLogin;
        private UI.Controls.BTextbox txtUser;
        private System.Windows.Forms.Button btnLogin;
        private UI.Controls.BTextbox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnInfo;
        private System.Windows.Forms.Label lblUserInfo;
        private UI.Controls.BButton btnStartWork;
        private UI.Controls.BButton btnLogout;
        private UI.Controls.BButton btnDisconnect;
        private System.Windows.Forms.TabPage tabPage1;
        private Manager.Proxy.ManagerProxy managerProxy1;
    }
}

