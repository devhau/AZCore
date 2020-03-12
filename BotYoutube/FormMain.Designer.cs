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
            this.btnConnectToServer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.pnMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.tabControl1);
            this.pnMain.Size = new System.Drawing.Size(731, 424);
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
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(731, 424);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(723, 391);
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
            this.groupBox3.Location = new System.Drawing.Point(2, 242);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(719, 147);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Server";
            // 
            // btnConnectToServer
            // 
            this.btnConnectToServer.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnConnectToServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectToServer.Font = new System.Drawing.Font("Meiryo UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectToServer.Location = new System.Drawing.Point(529, 22);
            this.btnConnectToServer.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnectToServer.Name = "btnConnectToServer";
            this.btnConnectToServer.Size = new System.Drawing.Size(157, 68);
            this.btnConnectToServer.TabIndex = 8;
            this.btnConnectToServer.Text = "Connect To Server";
            this.btnConnectToServer.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "IP Server";
            // 
            // txtIPServer
            // 
            this.txtIPServer.Location = new System.Drawing.Point(16, 50);
            this.txtIPServer.Margin = new System.Windows.Forms.Padding(2);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(335, 24);
            this.txtIPServer.TabIndex = 10;
            // 
            // groupBox2
            // 
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
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(719, 240);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local";
            // 
            // cbkLinkLoop
            // 
            this.cbkLinkLoop.AutoSize = true;
            this.cbkLinkLoop.Location = new System.Drawing.Point(118, 138);
            this.cbkLinkLoop.Margin = new System.Windows.Forms.Padding(2);
            this.cbkLinkLoop.Name = "cbkLinkLoop";
            this.cbkLinkLoop.Size = new System.Drawing.Size(94, 22);
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
            this.groupBox1.Location = new System.Drawing.Point(21, 165);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(354, 68);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // cbkTaskView
            // 
            this.cbkTaskView.AutoSize = true;
            this.cbkTaskView.Checked = true;
            this.cbkTaskView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkTaskView.Location = new System.Drawing.Point(15, 29);
            this.cbkTaskView.Margin = new System.Windows.Forms.Padding(2);
            this.cbkTaskView.Name = "cbkTaskView";
            this.cbkTaskView.Size = new System.Drawing.Size(61, 22);
            this.cbkTaskView.TabIndex = 11;
            this.cbkTaskView.Text = "View";
            this.cbkTaskView.UseVisualStyleBackColor = true;
            // 
            // cbkTaskComment
            // 
            this.cbkTaskComment.AutoSize = true;
            this.cbkTaskComment.Location = new System.Drawing.Point(261, 29);
            this.cbkTaskComment.Margin = new System.Windows.Forms.Padding(2);
            this.cbkTaskComment.Name = "cbkTaskComment";
            this.cbkTaskComment.Size = new System.Drawing.Size(92, 22);
            this.cbkTaskComment.TabIndex = 15;
            this.cbkTaskComment.Text = "Comment";
            this.cbkTaskComment.UseVisualStyleBackColor = true;
            // 
            // cbkTaskSub
            // 
            this.cbkTaskSub.AutoSize = true;
            this.cbkTaskSub.Location = new System.Drawing.Point(76, 29);
            this.cbkTaskSub.Margin = new System.Windows.Forms.Padding(2);
            this.cbkTaskSub.Name = "cbkTaskSub";
            this.cbkTaskSub.Size = new System.Drawing.Size(54, 22);
            this.cbkTaskSub.TabIndex = 12;
            this.cbkTaskSub.Text = "Sub";
            this.cbkTaskSub.UseVisualStyleBackColor = true;
            // 
            // cbkTaskDisLike
            // 
            this.cbkTaskDisLike.AutoSize = true;
            this.cbkTaskDisLike.Location = new System.Drawing.Point(185, 29);
            this.cbkTaskDisLike.Margin = new System.Windows.Forms.Padding(2);
            this.cbkTaskDisLike.Name = "cbkTaskDisLike";
            this.cbkTaskDisLike.Size = new System.Drawing.Size(76, 22);
            this.cbkTaskDisLike.TabIndex = 14;
            this.cbkTaskDisLike.Text = "DisLike";
            this.cbkTaskDisLike.UseVisualStyleBackColor = true;
            // 
            // cbkTaskLike
            // 
            this.cbkTaskLike.AutoSize = true;
            this.cbkTaskLike.Location = new System.Drawing.Point(130, 29);
            this.cbkTaskLike.Margin = new System.Windows.Forms.Padding(2);
            this.cbkTaskLike.Name = "cbkTaskLike";
            this.cbkTaskLike.Size = new System.Drawing.Size(55, 22);
            this.cbkTaskLike.TabIndex = 13;
            this.cbkTaskLike.Text = "Like";
            this.cbkTaskLike.UseVisualStyleBackColor = true;
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(21, 138);
            this.numDelay.Margin = new System.Windows.Forms.Padding(2);
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(80, 24);
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
            this.label3.Location = new System.Drawing.Point(21, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Delay(s)";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.GreenYellow;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Meiryo UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(529, 165);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(157, 68);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // txtLocalLink
            // 
            this.txtLocalLink.Location = new System.Drawing.Point(16, 35);
            this.txtLocalLink.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocalLink.Multiline = true;
            this.txtLocalLink.Name = "txtLocalLink";
            this.txtLocalLink.Size = new System.Drawing.Size(335, 79);
            this.txtLocalLink.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Link";
            // 
            // txtLocalProxy
            // 
            this.txtLocalProxy.Location = new System.Drawing.Point(353, 35);
            this.txtLocalProxy.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocalProxy.Multiline = true;
            this.txtLocalProxy.Name = "txtLocalProxy";
            this.txtLocalProxy.Size = new System.Drawing.Size(335, 79);
            this.txtLocalProxy.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Proxy";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(290, 215);
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
            this.tabControl2.Location = new System.Drawing.Point(2, 2);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(286, 211);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage5.Size = new System.Drawing.Size(278, 178);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "User";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage6.Size = new System.Drawing.Size(711, 354);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Bot";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 29);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage7.Size = new System.Drawing.Size(711, 354);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Link";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 29);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage8.Size = new System.Drawing.Size(711, 354);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Acc Youtube";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(290, 215);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Proxy Free";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(290, 215);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(529, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 476);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Margin = new System.Windows.Forms.Padding(3);
            this.MaximumSize = new System.Drawing.Size(733, 476);
            this.MinimumSize = new System.Drawing.Size(733, 476);
            this.Name = "FormMain";
            this.Text = "Bot Youtube";
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
    }
}

