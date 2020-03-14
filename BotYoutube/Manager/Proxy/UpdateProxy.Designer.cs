namespace BotYoutube.Manager.Proxy
{
    partial class UpdateProxy
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
            this.bNumericUpDown1 = new BotYoutube.UI.Controls.BNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.bCheckBox2 = new BotYoutube.UI.Controls.BCheckBox();
            this.panEditer.SuspendLayout();
            this.pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panEditer
            // 
            this.panEditer.Controls.Add(this.bCheckBox2);
            this.panEditer.Controls.Add(this.label2);
            this.panEditer.Controls.Add(this.bNumericUpDown1);
            this.panEditer.Controls.Add(this.bCheckBox1);
            this.panEditer.Controls.Add(this.label1);
            this.panEditer.Controls.Add(this.bTextbox1);
            this.panEditer.Size = new System.Drawing.Size(505, 197);
            // 
            // pnMain
            // 
            this.pnMain.Size = new System.Drawing.Size(505, 277);
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
            this.label1.Location = new System.Drawing.Point(60, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // bCheckBox1
            // 
            this.bCheckBox1.AutoSize = true;
            this.bCheckBox1.Location = new System.Drawing.Point(106, 120);
            this.bCheckBox1.Name = "bCheckBox1";
            this.bCheckBox1.Size = new System.Drawing.Size(123, 29);
            this.bCheckBox1.TabIndex = 2;
            this.bCheckBox1.Tag = "IsActice";
            this.bCheckBox1.Text = "Is Active";
            this.bCheckBox1.UseVisualStyleBackColor = true;
            // 
            // bNumericUpDown1
            // 
            this.bNumericUpDown1.Location = new System.Drawing.Point(106, 81);
            this.bNumericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.bNumericUpDown1.Name = "bNumericUpDown1";
            this.bNumericUpDown1.Size = new System.Drawing.Size(334, 33);
            this.bNumericUpDown1.TabIndex = 3;
            this.bNumericUpDown1.Tag = "port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // bCheckBox2
            // 
            this.bCheckBox2.AutoSize = true;
            this.bCheckBox2.Enabled = false;
            this.bCheckBox2.Location = new System.Drawing.Point(106, 155);
            this.bCheckBox2.Name = "bCheckBox2";
            this.bCheckBox2.Size = new System.Drawing.Size(100, 29);
            this.bCheckBox2.TabIndex = 5;
            this.bCheckBox2.Tag = "IsUse";
            this.bCheckBox2.Text = "Is Use";
            this.bCheckBox2.UseVisualStyleBackColor = true;
            // 
            // UpdateProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 329);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "UpdateProxy";
            this.Text = "Proxy Info";
            this.panEditer.ResumeLayout(false);
            this.panEditer.PerformLayout();
            this.pnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UI.Controls.BTextbox bTextbox1;
        private UI.Controls.BCheckBox bCheckBox1;
        private System.Windows.Forms.Label label2;
        private UI.Controls.BNumericUpDown bNumericUpDown1;
        private UI.Controls.BCheckBox bCheckBox2;
    }
}