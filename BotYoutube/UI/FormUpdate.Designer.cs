namespace BotYoutube.UI
{
    partial class FormUpdate
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
            this.panEditer = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new BotYoutube.UI.Controls.BButton();
            this.pnMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.panEditer);
            this.pnMain.Controls.Add(this.panel3);
            this.pnMain.Size = new System.Drawing.Size(925, 630);
            // 
            // panEditer
            // 
            this.panEditer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panEditer.Location = new System.Drawing.Point(0, 0);
            this.panEditer.Margin = new System.Windows.Forms.Padding(0);
            this.panEditer.Name = "panEditer";
            this.panEditer.Size = new System.Drawing.Size(925, 550);
            this.panEditer.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 550);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(925, 80);
            this.panel3.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Meiryo UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnSave.Location = new System.Drawing.Point(740, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 60);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 682);
            this.HideButtuonClose = true;
            this.HideButtuonMin = true;
            this.Name = "FormUpdate";
            this.Text = "FormUpdate";
            this.Load += new System.EventHandler(this.FormUpdate_Load);
            this.pnMain.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private Controls.BButton btnSave;
        public System.Windows.Forms.Panel panEditer;
    }
}