namespace SOI.OIFrx
{
    partial class UIBaseForm09
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIBaseForm09));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.pnlBCenter = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlBLeftMsg = new System.Windows.Forms.Panel();
            this.pnlBRight = new System.Windows.Forms.Panel();
            this.pnlBLeftTitle = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pnlTopInfo = new System.Windows.Forms.Panel();
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.imlSmallIcon = new System.Windows.Forms.ImageList(this.components);
            this.pnlTopTitle = new System.Windows.Forms.Panel();
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.pnlLine1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.pnlBCenter.SuspendLayout();
            this.pnlBLeftTitle.SuspendLayout();
            this.pnlTopTitle.SuspendLayout();
            this.pnlLine1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm02";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.pnlMessage);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 586);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1064, 52);
            this.pnlBottom.TabIndex = 3;
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
            this.pnlMessage.TabIndex = 28;
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
            // pnlTopInfo
            // 
            this.pnlTopInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopInfo.Location = new System.Drawing.Point(0, 60);
            this.pnlTopInfo.Name = "pnlTopInfo";
            this.pnlTopInfo.Size = new System.Drawing.Size(1064, 458);
            this.pnlTopInfo.TabIndex = 4;
            // 
            // pnlCommand
            // 
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommand.Location = new System.Drawing.Point(0, 518);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(1064, 68);
            this.pnlCommand.TabIndex = 6;
            // 
            // imlSmallIcon
            // 
            this.imlSmallIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmallIcon.ImageStream")));
            this.imlSmallIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmallIcon.Images.SetKeyName(0, "");
            this.imlSmallIcon.Images.SetKeyName(1, "");
            this.imlSmallIcon.Images.SetKeyName(2, "");
            this.imlSmallIcon.Images.SetKeyName(3, "");
            this.imlSmallIcon.Images.SetKeyName(4, "");
            this.imlSmallIcon.Images.SetKeyName(5, "");
            this.imlSmallIcon.Images.SetKeyName(6, "");
            this.imlSmallIcon.Images.SetKeyName(7, "");
            this.imlSmallIcon.Images.SetKeyName(8, "");
            this.imlSmallIcon.Images.SetKeyName(9, "");
            this.imlSmallIcon.Images.SetKeyName(10, "");
            this.imlSmallIcon.Images.SetKeyName(11, "");
            this.imlSmallIcon.Images.SetKeyName(12, "");
            this.imlSmallIcon.Images.SetKeyName(13, "");
            this.imlSmallIcon.Images.SetKeyName(14, "");
            this.imlSmallIcon.Images.SetKeyName(15, "");
            this.imlSmallIcon.Images.SetKeyName(16, "");
            this.imlSmallIcon.Images.SetKeyName(17, "");
            this.imlSmallIcon.Images.SetKeyName(18, "");
            this.imlSmallIcon.Images.SetKeyName(19, "");
            this.imlSmallIcon.Images.SetKeyName(20, "");
            this.imlSmallIcon.Images.SetKeyName(21, "");
            this.imlSmallIcon.Images.SetKeyName(22, "");
            this.imlSmallIcon.Images.SetKeyName(23, "");
            this.imlSmallIcon.Images.SetKeyName(24, "");
            this.imlSmallIcon.Images.SetKeyName(25, "");
            this.imlSmallIcon.Images.SetKeyName(26, "");
            this.imlSmallIcon.Images.SetKeyName(27, "");
            this.imlSmallIcon.Images.SetKeyName(28, "");
            this.imlSmallIcon.Images.SetKeyName(29, "");
            this.imlSmallIcon.Images.SetKeyName(30, "");
            this.imlSmallIcon.Images.SetKeyName(31, "");
            this.imlSmallIcon.Images.SetKeyName(32, "");
            this.imlSmallIcon.Images.SetKeyName(33, "");
            this.imlSmallIcon.Images.SetKeyName(34, "");
            this.imlSmallIcon.Images.SetKeyName(35, "");
            this.imlSmallIcon.Images.SetKeyName(36, "");
            this.imlSmallIcon.Images.SetKeyName(37, "");
            this.imlSmallIcon.Images.SetKeyName(38, "");
            this.imlSmallIcon.Images.SetKeyName(39, "");
            this.imlSmallIcon.Images.SetKeyName(40, "");
            this.imlSmallIcon.Images.SetKeyName(41, "");
            this.imlSmallIcon.Images.SetKeyName(42, "");
            this.imlSmallIcon.Images.SetKeyName(43, "");
            this.imlSmallIcon.Images.SetKeyName(44, "");
            this.imlSmallIcon.Images.SetKeyName(45, "");
            this.imlSmallIcon.Images.SetKeyName(46, "");
            this.imlSmallIcon.Images.SetKeyName(47, "");
            this.imlSmallIcon.Images.SetKeyName(48, "");
            this.imlSmallIcon.Images.SetKeyName(49, "");
            this.imlSmallIcon.Images.SetKeyName(50, "");
            this.imlSmallIcon.Images.SetKeyName(51, "");
            this.imlSmallIcon.Images.SetKeyName(52, "");
            this.imlSmallIcon.Images.SetKeyName(53, "");
            this.imlSmallIcon.Images.SetKeyName(54, "");
            this.imlSmallIcon.Images.SetKeyName(55, "");
            this.imlSmallIcon.Images.SetKeyName(56, "");
            this.imlSmallIcon.Images.SetKeyName(57, "");
            this.imlSmallIcon.Images.SetKeyName(58, "");
            this.imlSmallIcon.Images.SetKeyName(59, "");
            this.imlSmallIcon.Images.SetKeyName(60, "");
            this.imlSmallIcon.Images.SetKeyName(61, "");
            this.imlSmallIcon.Images.SetKeyName(62, "");
            this.imlSmallIcon.Images.SetKeyName(63, "");
            this.imlSmallIcon.Images.SetKeyName(64, "");
            this.imlSmallIcon.Images.SetKeyName(65, "");
            this.imlSmallIcon.Images.SetKeyName(66, "");
            this.imlSmallIcon.Images.SetKeyName(67, "");
            this.imlSmallIcon.Images.SetKeyName(68, "");
            this.imlSmallIcon.Images.SetKeyName(69, "");
            this.imlSmallIcon.Images.SetKeyName(70, "");
            this.imlSmallIcon.Images.SetKeyName(71, "");
            this.imlSmallIcon.Images.SetKeyName(72, "");
            this.imlSmallIcon.Images.SetKeyName(73, "");
            this.imlSmallIcon.Images.SetKeyName(74, "");
            this.imlSmallIcon.Images.SetKeyName(75, "");
            this.imlSmallIcon.Images.SetKeyName(76, "");
            this.imlSmallIcon.Images.SetKeyName(77, "");
            this.imlSmallIcon.Images.SetKeyName(78, "");
            this.imlSmallIcon.Images.SetKeyName(79, "");
            this.imlSmallIcon.Images.SetKeyName(80, "");
            this.imlSmallIcon.Images.SetKeyName(81, "");
            this.imlSmallIcon.Images.SetKeyName(82, "");
            this.imlSmallIcon.Images.SetKeyName(83, "");
            this.imlSmallIcon.Images.SetKeyName(84, "");
            this.imlSmallIcon.Images.SetKeyName(85, "");
            this.imlSmallIcon.Images.SetKeyName(86, "");
            this.imlSmallIcon.Images.SetKeyName(87, "");
            this.imlSmallIcon.Images.SetKeyName(88, "");
            this.imlSmallIcon.Images.SetKeyName(89, "");
            this.imlSmallIcon.Images.SetKeyName(90, "");
            this.imlSmallIcon.Images.SetKeyName(91, "");
            this.imlSmallIcon.Images.SetKeyName(92, "");
            this.imlSmallIcon.Images.SetKeyName(93, "");
            this.imlSmallIcon.Images.SetKeyName(94, "");
            this.imlSmallIcon.Images.SetKeyName(95, "");
            this.imlSmallIcon.Images.SetKeyName(96, "");
            this.imlSmallIcon.Images.SetKeyName(97, "");
            this.imlSmallIcon.Images.SetKeyName(98, "");
            this.imlSmallIcon.Images.SetKeyName(99, "");
            this.imlSmallIcon.Images.SetKeyName(100, "");
            this.imlSmallIcon.Images.SetKeyName(101, "");
            this.imlSmallIcon.Images.SetKeyName(102, "");
            this.imlSmallIcon.Images.SetKeyName(103, "");
            this.imlSmallIcon.Images.SetKeyName(104, "White Image");
            this.imlSmallIcon.Images.SetKeyName(105, "");
            this.imlSmallIcon.Images.SetKeyName(106, "Subequip9.ico");
            this.imlSmallIcon.Images.SetKeyName(107, "Port_down.ico");
            // 
            // pnlTopTitle
            // 
            this.pnlTopTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopTitle.Controls.Add(this.lblTopTitle);
            this.pnlTopTitle.Controls.Add(this.lblIcon);
            this.pnlTopTitle.Controls.Add(this.lblUserId);
            this.pnlTopTitle.Controls.Add(this.pnlLine1);
            this.pnlTopTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTopTitle.Name = "pnlTopTitle";
            this.pnlTopTitle.Size = new System.Drawing.Size(1064, 60);
            this.pnlTopTitle.TabIndex = 7;
            // 
            // lblTopTitle
            // 
            this.lblTopTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTopTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTopTitle.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.lblTopTitle.ForeColor = System.Drawing.Color.Yellow;
            this.lblTopTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTopTitle.ImageIndex = 103;
            this.lblTopTitle.Location = new System.Drawing.Point(27, 0);
            this.lblTopTitle.Name = "lblTopTitle";
            this.lblTopTitle.Size = new System.Drawing.Size(858, 50);
            this.lblTopTitle.TabIndex = 157;
            this.lblTopTitle.Text = "UIBaseForm09";
            this.lblTopTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIcon
            // 
            this.lblIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblIcon.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
            this.lblIcon.ForeColor = System.Drawing.Color.Yellow;
            this.lblIcon.ImageIndex = 103;
            this.lblIcon.ImageList = this.imlSmallIcon;
            this.lblIcon.Location = new System.Drawing.Point(0, 0);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(27, 50);
            this.lblIcon.TabIndex = 159;
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserId
            // 
            this.lblUserId.BackColor = System.Drawing.Color.Transparent;
            this.lblUserId.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUserId.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblUserId.ForeColor = System.Drawing.Color.LightGray;
            this.lblUserId.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserId.ImageIndex = 103;
            this.lblUserId.Location = new System.Drawing.Point(885, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblUserId.Size = new System.Drawing.Size(179, 50);
            this.lblUserId.TabIndex = 160;
            this.lblUserId.Text = "userid";
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pnlLine1
            // 
            this.pnlLine1.BackColor = System.Drawing.Color.Transparent;
            this.pnlLine1.Controls.Add(this.panel5);
            this.pnlLine1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLine1.Location = new System.Drawing.Point(0, 50);
            this.pnlLine1.Name = "pnlLine1";
            this.pnlLine1.Padding = new System.Windows.Forms.Padding(5, 3, 10, 3);
            this.pnlLine1.Size = new System.Drawing.Size(1064, 10);
            this.pnlLine1.TabIndex = 158;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1049, 4);
            this.panel5.TabIndex = 1;
            // 
            // UIBaseForm09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1064, 638);
            this.Controls.Add(this.pnlTopInfo);
            this.Controls.Add(this.pnlTopTitle);
            this.Controls.Add(this.pnlCommand);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(645, 38);
            this.Name = "UIBaseForm09";
            this.Text = "UIBaseForm09";
            this.Activated += new System.EventHandler(this.UIBaseForm09_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIBaseForm09_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIBaseForm09_FormClosed);
            this.Load += new System.EventHandler(this.UIBaseForm09_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlCommand, 0);
            this.Controls.SetChildIndex(this.pnlTopTitle, 0);
            this.Controls.SetChildIndex(this.pnlTopInfo, 0);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.pnlBCenter.ResumeLayout(false);
            this.pnlBLeftTitle.ResumeLayout(false);
            this.pnlTopTitle.ResumeLayout(false);
            this.pnlLine1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label lblMsg;
        protected System.Windows.Forms.Panel pnlTopInfo;
        protected System.Windows.Forms.Label lblMessage;
        protected System.Windows.Forms.Panel pnlCommand;
        protected System.Windows.Forms.Panel pnlBCenter;
        protected System.Windows.Forms.Panel pnlBRight;
        protected System.Windows.Forms.Panel pnlBLeftTitle;
        protected System.Windows.Forms.Panel pnlBLeftMsg;
        protected System.Windows.Forms.ImageList imlSmallIcon;
        private System.Windows.Forms.Panel pnlTopTitle;
        private System.Windows.Forms.Label lblTopTitle;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Panel pnlLine1;
        private System.Windows.Forms.Panel panel5;




    }
}