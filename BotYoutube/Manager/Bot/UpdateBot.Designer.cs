namespace BotYoutube.Manager.Bot
{
    partial class UpdateBot
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
            this.bCheckBox1 = new BotYoutube.UI.Controls.BCheckBox();
            this.panEditer.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panEditer
            // 
            this.panEditer.Controls.Add(this.bCheckBox1);
            this.panEditer.Controls.Add(this.label1);
            this.panEditer.Controls.Add(this.bTextbox1);
            this.panEditer.Size = new System.Drawing.Size(505, 148);
            // 
            // pnMain
            // 
            this.pnMain.Size = new System.Drawing.Size(505, 228);
            // 
            // bTextbox1
            // 
            this.bTextbox1.KeyCommand = System.Windows.Forms.Keys.None;
            this.bTextbox1.Location = new System.Drawing.Point(106, 41);
            this.bTextbox1.Name = "bTextbox1";
            this.bTextbox1.Size = new System.Drawing.Size(334, 33);
            this.bTextbox1.TabIndex = 0;
            this.bTextbox1.Tag = "ip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // bCheckBox1
            // 
            this.bCheckBox1.AutoSize = true;
            this.bCheckBox1.Location = new System.Drawing.Point(106, 81);
            this.bCheckBox1.Name = "bCheckBox1";
            this.bCheckBox1.Size = new System.Drawing.Size(123, 29);
            this.bCheckBox1.TabIndex = 2;
            this.bCheckBox1.Tag = "IsActice";
            this.bCheckBox1.Text = "Is Active";
            this.bCheckBox1.UseVisualStyleBackColor = true;
            // 
            // UpdateBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 280);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "UpdateBot";
            this.Text = "Bot Info";
            this.panEditer.ResumeLayout(false);
            this.panEditer.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UI.Controls.BTextbox bTextbox1;
        private UI.Controls.BCheckBox bCheckBox1;
    }
}