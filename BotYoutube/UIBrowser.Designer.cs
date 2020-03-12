namespace BotYoutube
{
    partial class UIBrowser
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
            this.botBrowser1 = new BotYoutube.BotBrowser();
            this.btnHome = new System.Windows.Forms.Button();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.btnHome);
            this.pnMain.Controls.Add(this.botBrowser1);
            this.pnMain.Location = new System.Drawing.Point(2, 51);
            this.pnMain.Size = new System.Drawing.Size(509, 248);
            // 
            // botBrowser1
            // 
            this.botBrowser1.ConsoleMessageEventReceivesConsoleLogCalls = true;
            this.botBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.botBrowser1.FrameEventsPropagateToMainWindow = false;
            this.botBrowser1.Location = new System.Drawing.Point(0, 0);
            this.botBrowser1.Name = "botBrowser1";
            this.botBrowser1.Size = new System.Drawing.Size(509, 248);
            this.botBrowser1.TabIndex = 0;
            this.botBrowser1.UseHttpActivityObserver = false;
            // 
            // btnHome
            // 
            this.btnHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHome.Location = new System.Drawing.Point(4, 205);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(98, 38);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // UIBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 300);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "UIBrowser";
            this.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Text = "UIBrowser";
            this.Load += new System.EventHandler(this.UIBrowser_Load);
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BotBrowser botBrowser1;
        private System.Windows.Forms.Button btnHome;
    }
}