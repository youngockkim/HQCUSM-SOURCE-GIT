namespace SOI.OIFrx
{
    partial class UIBaseForm04
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pnlTopInfo = new System.Windows.Forms.Panel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlCLeft = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm02";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlMessage);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 544);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1064, 48);
            this.pnlBottom.TabIndex = 3;
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Controls.Add(this.lblMsg);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(1064, 48);
            this.pnlMessage.TabIndex = 28;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Black;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.ForeColor = System.Drawing.Color.Yellow;
            this.lblMessage.Location = new System.Drawing.Point(129, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(935, 48);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Black;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMsg.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Silver;
            this.lblMsg.Location = new System.Drawing.Point(0, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(129, 48);
            this.lblMsg.TabIndex = 21;
            this.lblMsg.Text = "Message";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTopInfo
            // 
            this.pnlTopInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopInfo.Name = "pnlTopInfo";
            this.pnlTopInfo.Size = new System.Drawing.Size(1064, 63);
            this.pnlTopInfo.TabIndex = 4;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlCLeft);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 63);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1064, 481);
            this.pnlCenter.TabIndex = 5;
            // 
            // pnlCLeft
            // 
            this.pnlCLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlCLeft.Name = "pnlCLeft";
            this.pnlCLeft.Size = new System.Drawing.Size(1064, 481);
            this.pnlCLeft.TabIndex = 5;
            // 
            // UIBaseForm04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 592);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTopInfo);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new System.Drawing.Size(645, 38);
            this.Name = "UIBaseForm04";
            this.Text = "UIBaseForm04";
            this.Activated += new System.EventHandler(this.UIBaseForm04_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIBaseForm04_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIBaseForm04_FormClosed);
            this.Load += new System.EventHandler(this.UIBaseForm04_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTopInfo, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label lblMsg;
        protected System.Windows.Forms.Panel pnlTopInfo;
        protected System.Windows.Forms.Panel pnlCenter;
        protected System.Windows.Forms.Label lblMessage;
        protected System.Windows.Forms.Panel pnlCLeft;




    }
}