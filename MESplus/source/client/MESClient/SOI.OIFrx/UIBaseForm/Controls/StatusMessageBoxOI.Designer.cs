namespace SOI.OIFrx
{
    partial class StatusMessageBoxOI
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
            this.components = new System.ComponentModel.Container();
            this.tmrWait = new System.Windows.Forms.Timer(this.components);
            this.pnlPic = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.pnlPic.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrWait
            // 
            this.tmrWait.Tick += new System.EventHandler(this.tmrWait_Tick);
            // 
            // pnlPic
            // 
            this.pnlPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(36)))), ((int)(((byte)(37)))));
            this.pnlPic.BackgroundImage = global::SOI.OIFrx.Properties.Resources.Alarm_1920x300_red;
            this.pnlPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlPic.Controls.Add(this.panel2);
            this.pnlPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPic.Location = new System.Drawing.Point(0, 0);
            this.pnlPic.Name = "pnlPic";
            this.pnlPic.Size = new System.Drawing.Size(1500, 500);
            this.pnlPic.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.StatusLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1500, 500);
            this.panel2.TabIndex = 4;
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusLabel.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(232, 0);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(3);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Padding = new System.Windows.Forms.Padding(3);
            this.StatusLabel.Size = new System.Drawing.Size(1268, 500);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Status Message Box";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusMessageBoxOI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1500, 500);
            this.ControlBox = false;
            this.Controls.Add(this.pnlPic);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "StatusMessageBoxOI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatusMessageBoxOI";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatusMessageBoxOI_FormClosing);
            this.Load += new System.EventHandler(this.StatusMessageBoxOI_Load);
            this.pnlPic.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StatusLabel;
        public System.Windows.Forms.Timer tmrWait;
        private System.Windows.Forms.Panel pnlPic;
        private System.Windows.Forms.Panel panel2;
    }
}