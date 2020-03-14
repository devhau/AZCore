namespace BotYoutube.Manager.Proxy
{
    partial class ManagerProxy
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddProxy = new BotYoutube.UI.Controls.BButton();
            this.SuspendLayout();
            // 
            // btnAddProxy
            // 
            this.btnAddProxy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddProxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProxy.ForeColor = System.Drawing.Color.White;
            this.btnAddProxy.KeyCommand = System.Windows.Forms.Keys.None;
            this.btnAddProxy.Location = new System.Drawing.Point(497, 12);
            this.btnAddProxy.Name = "btnAddProxy";
            this.btnAddProxy.Size = new System.Drawing.Size(218, 54);
            this.btnAddProxy.TabIndex = 2;
            this.btnAddProxy.Text = "Add Proxy Text";
            this.btnAddProxy.UseVisualStyleBackColor = false;
            this.btnAddProxy.Click += new System.EventHandler(this.btnAddProxy_Click);
            // 
            // ManagerProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddProxy);
            this.Name = "ManagerProxy";
            this.Controls.SetChildIndex(this.btnAddProxy, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.BButton btnAddProxy;
    }
}
