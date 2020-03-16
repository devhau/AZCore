namespace BotYoutube.Manager.Campaign
{
    partial class UpdateCampaign
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bCheckBox1 = new BotYoutube.UI.Controls.BCheckBox();
            this.bDateTimePicker1 = new BotYoutube.UI.Controls.BDateTimePicker();
            this.bDateTimePicker2 = new BotYoutube.UI.Controls.BDateTimePicker();
            this.panEditer.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panEditer
            // 
            this.panEditer.Controls.Add(this.bDateTimePicker2);
            this.panEditer.Controls.Add(this.bDateTimePicker1);
            this.panEditer.Controls.Add(this.bCheckBox1);
            this.panEditer.Controls.Add(this.label2);
            this.panEditer.Controls.Add(this.label1);
            this.panEditer.Size = new System.Drawing.Size(519, 186);
            // 
            // pnMain
            // 
            this.pnMain.Size = new System.Drawing.Size(519, 266);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "End";
            // 
            // bCheckBox1
            // 
            this.bCheckBox1.AutoSize = true;
            this.bCheckBox1.Location = new System.Drawing.Point(106, 122);
            this.bCheckBox1.Name = "bCheckBox1";
            this.bCheckBox1.Size = new System.Drawing.Size(123, 29);
            this.bCheckBox1.TabIndex = 4;
            this.bCheckBox1.Tag = "IsActice";
            this.bCheckBox1.Text = "Is Active";
            this.bCheckBox1.UseVisualStyleBackColor = true;
            // 
            // bDateTimePicker1
            // 
            this.bDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.bDateTimePicker1.KeyCommand = System.Windows.Forms.Keys.None;
            this.bDateTimePicker1.Location = new System.Drawing.Point(106, 44);
            this.bDateTimePicker1.Name = "bDateTimePicker1";
            this.bDateTimePicker1.Size = new System.Drawing.Size(241, 33);
            this.bDateTimePicker1.TabIndex = 5;
            // 
            // bDateTimePicker2
            // 
            this.bDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.bDateTimePicker2.KeyCommand = System.Windows.Forms.Keys.None;
            this.bDateTimePicker2.Location = new System.Drawing.Point(106, 83);
            this.bDateTimePicker2.Name = "bDateTimePicker2";
            this.bDateTimePicker2.Size = new System.Drawing.Size(241, 33);
            this.bDateTimePicker2.TabIndex = 6;
            // 
            // UpdateCampaign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 318);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "UpdateCampaign";
            this.Text = "Campaign Info";
            this.panEditer.ResumeLayout(false);
            this.panEditer.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UI.Controls.BCheckBox bCheckBox1;
        private System.Windows.Forms.Label label2;
        private UI.Controls.BDateTimePicker bDateTimePicker1;
        private UI.Controls.BDateTimePicker bDateTimePicker2;
    }
}