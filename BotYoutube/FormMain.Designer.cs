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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnConnectToServer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.managerUser1 = new BotYoutube.Manager.User.ManagerUser();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.managerBot1 = new BotYoutube.Manager.Bot.ManagerBot();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.managerLink1 = new BotYoutube.Manager.Link.ManagerLink();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.managerAccYoutube1 = new BotYoutube.Manager.AccYoutube.ManagerAccYoutube();
            this.pnMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.tabControl1);
            this.pnMain.Location = new System.Drawing.Point(2, 51);
            this.pnMain.Size = new System.Drawing.Size(1096, 648);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1096, 648);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1088, 607);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnConnectToServer);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtIPServer);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 356);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1082, 248);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(794, 141);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 68);
            this.button1.TabIndex = 11;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConnectToServer
            // 
            this.btnConnectToServer.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnConnectToServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectToServer.Font = new System.Drawing.Font("Meiryo UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectToServer.Location = new System.Drawing.Point(794, 32);
            this.btnConnectToServer.Name = "btnConnectToServer";
            this.btnConnectToServer.Size = new System.Drawing.Size(236, 100);
            this.btnConnectToServer.TabIndex = 8;
            this.btnConnectToServer.Text = "Connect To Server";
            this.btnConnectToServer.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "IP Server";
            // 
            // txtIPServer
            // 
            this.txtIPServer.Location = new System.Drawing.Point(24, 74);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(500, 33);
            this.txtIPServer.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtComment);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbkLinkLoop);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.numDelay);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.txtLocalLink);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtLocalProxy);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1082, 353);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local";
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1088, 607);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Admin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1082, 601);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.managerUser1);
            this.tabPage5.Location = new System.Drawing.Point(4, 37);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1074, 560);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "User";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // managerUser1
            // 
            this.managerUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerUser1.Location = new System.Drawing.Point(3, 3);
            this.managerUser1.Margin = new System.Windows.Forms.Padding(4);
            this.managerUser1.Name = "managerUser1";
            this.managerUser1.Size = new System.Drawing.Size(1068, 554);
            this.managerUser1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.managerBot1);
            this.tabPage6.Location = new System.Drawing.Point(4, 37);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1074, 560);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Bot";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // managerBot1
            // 
            this.managerBot1.Location = new System.Drawing.Point(19, 23);
            this.managerBot1.Margin = new System.Windows.Forms.Padding(4);
            this.managerBot1.Name = "managerBot1";
            this.managerBot1.Size = new System.Drawing.Size(1594, 761);
            this.managerBot1.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.managerLink1);
            this.tabPage7.Location = new System.Drawing.Point(4, 37);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1074, 560);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Link";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // managerLink1
            // 
            this.managerLink1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerLink1.Location = new System.Drawing.Point(3, 3);
            this.managerLink1.Margin = new System.Windows.Forms.Padding(4);
            this.managerLink1.Name = "managerLink1";
            this.managerLink1.Size = new System.Drawing.Size(1068, 554);
            this.managerLink1.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.managerAccYoutube1);
            this.tabPage8.Location = new System.Drawing.Point(4, 37);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1074, 560);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Acc Youtube";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 37);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(290, 207);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Proxy Free";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 37);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(290, 207);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // managerAccYoutube1
            // 
            this.managerAccYoutube1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerAccYoutube1.Location = new System.Drawing.Point(3, 3);
            this.managerAccYoutube1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.managerAccYoutube1.Name = "managerAccYoutube1";
            this.managerAccYoutube1.Size = new System.Drawing.Size(1068, 554);
            this.managerAccYoutube1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.MaximumSize = new System.Drawing.Size(1100, 700);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Text = "Bot Youtube";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalProxy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.CheckBox cbkLinkLoop;
        private System.Windows.Forms.Button btnConnectToServer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtIPServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbkTaskView;
        private System.Windows.Forms.CheckBox cbkTaskSub;
        private System.Windows.Forms.CheckBox cbkTaskLike;
        private System.Windows.Forms.CheckBox cbkTaskDisLike;
        private System.Windows.Forms.CheckBox cbkTaskComment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label5;
        private Manager.User.ManagerUser managerUser1;
        private Manager.Link.ManagerLink managerLink1;
        private Manager.Bot.ManagerBot managerBot1;
        private Manager.AccYoutube.ManagerAccYoutube managerAccYoutube1;
    }
}

