namespace BotYoutube
{
    partial class FormSetup
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
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtConnectString = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new BotYoutube.UI.Controls.BButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPass = new BotYoutube.UI.Controls.BTextbox();
            this.pnMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.panel2);
            this.pnMain.Controls.Add(this.label5);
            this.pnMain.Controls.Add(this.txtConnectString);
            this.pnMain.Controls.Add(this.label4);
            this.pnMain.Controls.Add(this.txtDatabase);
            this.pnMain.Controls.Add(this.btnCreateDB);
            this.pnMain.Controls.Add(this.label3);
            this.pnMain.Controls.Add(this.label2);
            this.pnMain.Controls.Add(this.label1);
            this.pnMain.Controls.Add(this.txtPassword);
            this.pnMain.Controls.Add(this.txtUser);
            this.pnMain.Controls.Add(this.txtHost);
            this.pnMain.Controls.Add(this.btnConnectDB);
            this.pnMain.Size = new System.Drawing.Size(690, 414);
            this.pnMain.TabIndex = 0;
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.BackColor = System.Drawing.Color.Red;
            this.btnConnectDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectDB.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectDB.ForeColor = System.Drawing.Color.White;
            this.btnConnectDB.Location = new System.Drawing.Point(144, 304);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(211, 51);
            this.btnConnectDB.TabIndex = 4;
            this.btnConnectDB.Text = "Connect DB";
            this.btnConnectDB.UseVisualStyleBackColor = false;
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHost.Location = new System.Drawing.Point(184, 24);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(486, 41);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = "127.0.0.1";
            this.txtHost.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(184, 117);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(486, 41);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "root";
            this.txtUser.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(184, 164);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(486, 41);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password";
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.BackColor = System.Drawing.Color.Red;
            this.btnCreateDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDB.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDB.ForeColor = System.Drawing.Color.White;
            this.btnCreateDB.Location = new System.Drawing.Point(358, 304);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(179, 51);
            this.btnCreateDB.TabIndex = 5;
            this.btnCreateDB.Text = "Create DB";
            this.btnCreateDB.UseVisualStyleBackColor = false;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Database";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.Location = new System.Drawing.Point(184, 71);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(486, 41);
            this.txtDatabase.TabIndex = 1;
            this.txtDatabase.Text = "botyoutube";
            this.txtDatabase.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtConnectString
            // 
            this.txtConnectString.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectString.Location = new System.Drawing.Point(184, 211);
            this.txtConnectString.Name = "txtConnectString";
            this.txtConnectString.ReadOnly = true;
            this.txtConnectString.Size = new System.Drawing.Size(486, 41);
            this.txtConnectString.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "ConnectString";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtPass);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 414);
            this.panel2.TabIndex = 12;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Yellow;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnOK.Location = new System.Drawing.Point(278, 164);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 52);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Pass";
            // 
            // txtPass
            // 
            this.txtPass.KeyCommand = System.Windows.Forms.Keys.None;
            this.txtPass.Location = new System.Drawing.Point(197, 117);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(297, 33);
            this.txtPass.TabIndex = 0;
            // 
            // FormSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 466);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "FormSetup";
            this.Text = "Setup Database";
            this.Load += new System.EventHandler(this.FormSetup_Load);
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnectDB;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConnectString;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private UI.Controls.BTextbox txtPass;
        private UI.Controls.BButton btnOK;
    }
}