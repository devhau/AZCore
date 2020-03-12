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
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
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
            this.pnMain.Size = new System.Drawing.Size(663, 329);
            this.pnMain.TabIndex = 0;
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.BackColor = System.Drawing.Color.Red;
            this.btnConnectDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectDB.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectDB.ForeColor = System.Drawing.Color.White;
            this.btnConnectDB.Location = new System.Drawing.Point(141, 233);
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
            this.txtHost.Location = new System.Drawing.Point(144, 24);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(486, 41);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = "127.0.0.1";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(144, 117);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(486, 41);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "root";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(144, 164);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(486, 41);
            this.txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 174);
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
            this.btnCreateDB.Location = new System.Drawing.Point(358, 233);
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
            this.label4.Location = new System.Drawing.Point(29, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Database";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.Location = new System.Drawing.Point(144, 71);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(486, 41);
            this.txtDatabase.TabIndex = 1;
            this.txtDatabase.Text = "botyoutube";
            // 
            // FormSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 381);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "FormSetup";
            this.Text = "Setup Database";
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
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
    }
}