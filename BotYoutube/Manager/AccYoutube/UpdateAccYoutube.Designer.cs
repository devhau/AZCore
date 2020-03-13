namespace BotYoutube.Manager.AccYoutube
{
    partial class UpdateAccYoutube
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
            this.bTextbox1 = new BotYoutube.UI.Controls.BTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bTextbox2 = new BotYoutube.UI.Controls.BTextbox();
            this.bCheckBox1 = new BotYoutube.UI.Controls.BCheckBox();
            this.panEditer.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panEditer
            // 
            this.panEditer.Controls.Add(this.bCheckBox1);
            this.panEditer.Controls.Add(this.label2);
            this.panEditer.Controls.Add(this.bTextbox2);
            this.panEditer.Controls.Add(this.label1);
            this.panEditer.Controls.Add(this.bTextbox1);
            this.panEditer.Size = new System.Drawing.Size(478, 191);
            // 
            // pnMain
            // 
            this.pnMain.Size = new System.Drawing.Size(478, 271);
            // 
            // bTextbox1
            // 
            this.bTextbox1.KeyCommand = System.Windows.Forms.Keys.None;
            this.bTextbox1.Location = new System.Drawing.Point(106, 41);
            this.bTextbox1.Name = "bTextbox1";
            this.bTextbox1.Size = new System.Drawing.Size(334, 33);
            this.bTextbox1.TabIndex = 0;
            this.bTextbox1.Tag = "email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pass";
            // 
            // bTextbox2
            // 
            this.bTextbox2.KeyCommand = System.Windows.Forms.Keys.None;
            this.bTextbox2.Location = new System.Drawing.Point(106, 80);
            this.bTextbox2.Name = "bTextbox2";
            this.bTextbox2.PasswordChar = '*';
            this.bTextbox2.Size = new System.Drawing.Size(334, 33);
            this.bTextbox2.TabIndex = 2;
            this.bTextbox2.Tag = "pass";
            // 
            // bCheckBox1
            // 
            this.bCheckBox1.AutoSize = true;
            this.bCheckBox1.Location = new System.Drawing.Point(106, 120);
            this.bCheckBox1.Name = "bCheckBox1";
            this.bCheckBox1.Size = new System.Drawing.Size(123, 29);
            this.bCheckBox1.TabIndex = 4;
            this.bCheckBox1.Tag = "IsActice";
            this.bCheckBox1.Text = "Is Active";
            this.bCheckBox1.UseVisualStyleBackColor = true;
            // 
            // UpdateAccYoutube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 323);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "UpdateAccYoutube";
            this.Text = "AccYoutube Info";
            this.panEditer.ResumeLayout(false);
            this.panEditer.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UI.Controls.BTextbox bTextbox1;
        private UI.Controls.BCheckBox bCheckBox1;
        private System.Windows.Forms.Label label2;
        private UI.Controls.BTextbox bTextbox2;
    }
}