namespace BotYoutube.Manager.User
{
    partial class UpdateUser
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
            this.txtUser = new BotYoutube.UI.Controls.BTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new BotYoutube.UI.Controls.BTextbox();
            this.cbkAdmin = new BotYoutube.UI.Controls.BCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panEditer.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panEditer
            // 
            this.panEditer.Controls.Add(this.label3);
            this.panEditer.Controls.Add(this.cbkAdmin);
            this.panEditer.Controls.Add(this.label2);
            this.panEditer.Controls.Add(this.txtPass);
            this.panEditer.Controls.Add(this.label1);
            this.panEditer.Controls.Add(this.txtUser);
            this.panEditer.Size = new System.Drawing.Size(533, 168);
            // 
            // pnMain
            // 
            this.pnMain.Size = new System.Drawing.Size(533, 248);
            // 
            // txtUser
            // 
            this.txtUser.KeyCommand = System.Windows.Forms.Keys.None;
            this.txtUser.Location = new System.Drawing.Point(149, 27);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(352, 33);
            this.txtUser.TabIndex = 0;
            this.txtUser.Tag = "username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.KeyCommand = System.Windows.Forms.Keys.None;
            this.txtPass.Location = new System.Drawing.Point(149, 66);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(352, 33);
            this.txtPass.TabIndex = 2;
            this.txtPass.Tag = "passsword";
            // 
            // cbkAdmin
            // 
            this.cbkAdmin.AutoSize = true;
            this.cbkAdmin.Location = new System.Drawing.Point(149, 110);
            this.cbkAdmin.Name = "cbkAdmin";
            this.cbkAdmin.Size = new System.Drawing.Size(22, 21);
            this.cbkAdmin.TabIndex = 4;
            this.cbkAdmin.Tag = "IsAdmin";
            this.cbkAdmin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Is Admin";
            // 
            // UpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 300);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "UpdateUser";
            this.Text = "User Info";
            this.panEditer.ResumeLayout(false);
            this.panEditer.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UI.Controls.BTextbox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UI.Controls.BTextbox txtPass;
        private UI.Controls.BCheckBox cbkAdmin;
        private System.Windows.Forms.Label label3;
    }
}