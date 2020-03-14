namespace BotYoutube.Manager.Proxy
{
    partial class UpdateProxy2
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
            this.txtProxy = new BotYoutube.UI.Controls.BTextbox();
            this.panEditer.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panEditer
            // 
            this.panEditer.Controls.Add(this.txtProxy);
            this.panEditer.Size = new System.Drawing.Size(798, 318);
            // 
            // pnMain
            // 
            this.pnMain.Size = new System.Drawing.Size(798, 398);
            // 
            // txtProxy
            // 
            this.txtProxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProxy.KeyCommand = System.Windows.Forms.Keys.None;
            this.txtProxy.Location = new System.Drawing.Point(0, 0);
            this.txtProxy.Multiline = true;
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.Size = new System.Drawing.Size(798, 318);
            this.txtProxy.TabIndex = 0;
            // 
            // UpdateProxy2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "UpdateProxy2";
            this.Text = "Proxy";
            this.panEditer.ResumeLayout(false);
            this.panEditer.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.BTextbox txtProxy;
    }
}