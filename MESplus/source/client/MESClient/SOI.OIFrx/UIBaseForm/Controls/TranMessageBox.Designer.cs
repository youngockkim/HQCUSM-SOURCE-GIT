namespace SOI.OIFrx
{
    partial class TranMessageBox
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
            this.StatusLabel = new System.Windows.Forms.Label();
            this.tmrWait = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusLabel.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StatusLabel.ForeColor = System.Drawing.Color.Black;
            this.StatusLabel.Location = new System.Drawing.Point(0, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(300, 69);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Status Message Box";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrWait
            // 
            this.tmrWait.Interval = 200;
            this.tmrWait.Tick += new System.EventHandler(this.tmrWait_Tick);
            // 
            // TranMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(300, 69);
            this.ControlBox = false;
            this.Controls.Add(this.StatusLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TranMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TranMessageBox";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TranMessageBox_FormClosing);
            this.Load += new System.EventHandler(this.TranMessageBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StatusLabel;
        public System.Windows.Forms.Timer tmrWait;
    }
}