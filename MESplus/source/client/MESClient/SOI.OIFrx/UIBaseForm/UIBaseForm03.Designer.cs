namespace SOI.OIFrx
{
    partial class UIBaseForm03
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
            this.pnlTopInfo = new System.Windows.Forms.Panel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlCLeft = new System.Windows.Forms.Panel();
            this.pnlCRight = new System.Windows.Forms.Panel();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.pnlBCenter = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlBLeftMsg = new System.Windows.Forms.Panel();
            this.pnlBRight = new System.Windows.Forms.Panel();
            this.pnlBLeftTitle = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.pnlBCenter.SuspendLayout();
            this.pnlBLeftTitle.SuspendLayout();
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 586);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1064, 52);
            this.pnlBottom.TabIndex = 3;
            // 
            // pnlTopInfo
            // 
            this.pnlTopInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopInfo.Name = "pnlTopInfo";
            this.pnlTopInfo.Size = new System.Drawing.Size(1064, 68);
            this.pnlTopInfo.TabIndex = 4;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlCLeft);
            this.pnlCenter.Controls.Add(this.pnlCRight);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 68);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1064, 518);
            this.pnlCenter.TabIndex = 5;
            // 
            // pnlCLeft
            // 
            this.pnlCLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlCLeft.Name = "pnlCLeft";
            this.pnlCLeft.Size = new System.Drawing.Size(592, 518);
            this.pnlCLeft.TabIndex = 5;
            // 
            // pnlCRight
            // 
            this.pnlCRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCRight.Location = new System.Drawing.Point(592, 0);
            this.pnlCRight.Name = "pnlCRight";
            this.pnlCRight.Size = new System.Drawing.Size(472, 518);
            this.pnlCRight.TabIndex = 6;
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.Transparent;
            this.pnlMessage.Controls.Add(this.pnlBCenter);
            this.pnlMessage.Controls.Add(this.pnlBLeftMsg);
            this.pnlMessage.Controls.Add(this.pnlBRight);
            this.pnlMessage.Controls.Add(this.pnlBLeftTitle);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(1064, 52);
            this.pnlMessage.TabIndex = 29;
            // 
            // pnlBCenter
            // 
            this.pnlBCenter.BackgroundImage = global::SOI.OIFrx.Properties.Resources.message_center_bg;
            this.pnlBCenter.Controls.Add(this.lblMessage);
            this.pnlBCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBCenter.Location = new System.Drawing.Point(175, 0);
            this.pnlBCenter.Name = "pnlBCenter";
            this.pnlBCenter.Padding = new System.Windows.Forms.Padding(5, 10, 5, 12);
            this.pnlBCenter.Size = new System.Drawing.Size(870, 52);
            this.pnlBCenter.TabIndex = 23;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.ForeColor = System.Drawing.Color.Yellow;
            this.lblMessage.Location = new System.Drawing.Point(5, 10);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(860, 30);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBLeftMsg
            // 
            this.pnlBLeftMsg.BackgroundImage = global::SOI.OIFrx.Properties.Resources.message;
            this.pnlBLeftMsg.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBLeftMsg.Location = new System.Drawing.Point(127, 0);
            this.pnlBLeftMsg.Name = "pnlBLeftMsg";
            this.pnlBLeftMsg.Size = new System.Drawing.Size(48, 52);
            this.pnlBLeftMsg.TabIndex = 25;
            // 
            // pnlBRight
            // 
            this.pnlBRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlBRight.BackgroundImage = global::SOI.OIFrx.Properties.Resources.message_right_bg;
            this.pnlBRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBRight.Location = new System.Drawing.Point(1045, 0);
            this.pnlBRight.Name = "pnlBRight";
            this.pnlBRight.Size = new System.Drawing.Size(19, 52);
            this.pnlBRight.TabIndex = 24;
            // 
            // pnlBLeftTitle
            // 
            this.pnlBLeftTitle.Controls.Add(this.lblMsg);
            this.pnlBLeftTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBLeftTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlBLeftTitle.Name = "pnlBLeftTitle";
            this.pnlBLeftTitle.Size = new System.Drawing.Size(127, 52);
            this.pnlBLeftTitle.TabIndex = 22;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Black;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMsg.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Silver;
            this.lblMsg.Location = new System.Drawing.Point(0, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(127, 52);
            this.lblMsg.TabIndex = 21;
            this.lblMsg.Text = "Message";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UIBaseForm03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1064, 638);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTopInfo);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(645, 38);
            this.Name = "UIBaseForm03";
            this.Text = "UIBaseForm03";
            this.Activated += new System.EventHandler(this.UIBaseForm03_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIBaseForm03_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIBaseForm03_FormClosed);
            this.Load += new System.EventHandler(this.UIBaseForm03_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTopInfo, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.pnlBCenter.ResumeLayout(false);
            this.pnlBLeftTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlBottom;
        protected System.Windows.Forms.Panel pnlTopInfo;
        protected System.Windows.Forms.Panel pnlCenter;
        protected System.Windows.Forms.Panel pnlCRight;
        protected System.Windows.Forms.Panel pnlCLeft;
        private System.Windows.Forms.Panel pnlMessage;
        protected System.Windows.Forms.Panel pnlBCenter;
        protected System.Windows.Forms.Label lblMessage;
        protected System.Windows.Forms.Panel pnlBLeftMsg;
        protected System.Windows.Forms.Panel pnlBRight;
        protected System.Windows.Forms.Panel pnlBLeftTitle;
        private System.Windows.Forms.Label lblMsg;




    }
}