namespace SOI.OIFrx.SOIBaseForm
{
    partial class SOIBaseForm01
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SOIBaseForm01));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.pnlMiddle = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pnlMiddleMargin = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pnlBottom = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.spcBottom = new System.Windows.Forms.SplitContainer();
            this.pnlBottomMargin = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pnlBottomClosePanel = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.btnClose = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pb = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlTop = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pnlTopMargin = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.lblFormTitle = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.pnlMiddle.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcBottom)).BeginInit();
            this.spcBottom.Panel1.SuspendLayout();
            this.spcBottom.Panel2.SuspendLayout();
            this.spcBottom.SuspendLayout();
            this.pnlBottomMargin.SuspendLayout();
            this.pnlBottomClosePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTopMargin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMiddle
            // 
            this.pnlMiddle._UseOITheme = false;
            this.pnlMiddle._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlMiddle.BackColor = System.Drawing.Color.Transparent;
            this.pnlMiddle.Controls.Add(this.pnlMiddleMargin);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 60);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlMiddle.Size = new System.Drawing.Size(1240, 610);
            this.pnlMiddle.TabIndex = 3;
            // 
            // pnlMiddleMargin
            // 
            this.pnlMiddleMargin._UseOITheme = false;
            this.pnlMiddleMargin._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlMiddleMargin.AutoScroll = true;
            this.pnlMiddleMargin.BackColor = System.Drawing.Color.Transparent;
            this.pnlMiddleMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddleMargin.Location = new System.Drawing.Point(20, 5);
            this.pnlMiddleMargin.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlMiddleMargin.Name = "pnlMiddleMargin";
            this.pnlMiddleMargin.Size = new System.Drawing.Size(1200, 600);
            this.pnlMiddleMargin.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom._UseOITheme = false;
            this.pnlBottom._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.spcBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 670);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlBottom.Size = new System.Drawing.Size(1240, 90);
            this.pnlBottom.TabIndex = 2;
            // 
            // spcBottom
            // 
            this.spcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcBottom.Location = new System.Drawing.Point(20, 5);
            this.spcBottom.Name = "spcBottom";
            this.spcBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcBottom.Panel1
            // 
            this.spcBottom.Panel1.Controls.Add(this.pnlBottomMargin);
            // 
            // spcBottom.Panel2
            // 
            this.spcBottom.Panel2.Controls.Add(this.splitContainer1);
            this.spcBottom.Size = new System.Drawing.Size(1200, 80);
            this.spcBottom.SplitterDistance = 40;
            this.spcBottom.TabIndex = 3;
            // 
            // pnlBottomMargin
            // 
            this.pnlBottomMargin._UseOITheme = false;
            this.pnlBottomMargin._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlBottomMargin.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottomMargin.Controls.Add(this.pnlBottomClosePanel);
            this.pnlBottomMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomMargin.Location = new System.Drawing.Point(0, 0);
            this.pnlBottomMargin.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlBottomMargin.Name = "pnlBottomMargin";
            this.pnlBottomMargin.Size = new System.Drawing.Size(1200, 40);
            this.pnlBottomMargin.TabIndex = 2;
            // 
            // pnlBottomClosePanel
            // 
            this.pnlBottomClosePanel._UseOITheme = false;
            this.pnlBottomClosePanel._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlBottomClosePanel.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottomClosePanel.Controls.Add(this.btnClose);
            this.pnlBottomClosePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBottomClosePanel.Location = new System.Drawing.Point(1090, 0);
            this.pnlBottomClosePanel.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBottomClosePanel.Name = "pnlBottomClosePanel";
            this.pnlBottomClosePanel.Size = new System.Drawing.Size(110, 40);
            this.pnlBottomClosePanel.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose._UseOITheme = true;
            this.btnClose._UseStyle = SOI.OIFrx.SOIButtonStyle.CancelStyle;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance8.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance8.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance8.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance8.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnClose.Appearance = appearance8;
            this.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            appearance1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.btnClose.HotTrackAppearance = appearance1;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance9.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnClose.PressedAppearance = appearance9;
            this.btnClose.ShowFocusRect = false;
            this.btnClose.ShowOutline = false;
            this.btnClose.Size = new System.Drawing.Size(110, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnClose.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnClose.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.splitContainer1.Panel1.Controls.Add(this.pb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblMessage);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 36);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.TabIndex = 0;
            // 
            // pb
            // 
            this.pb._UseLotStatusStyle = SOI.OIFrx.SOIPictureBoxStyle.None;
            this.pb._UseOITheme = false;
            this.pb.BackColor = System.Drawing.Color.Transparent;
            this.pb.BorderShadowColor = System.Drawing.Color.Empty;
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Image = ((object)(resources.GetObject("pb.Image")));
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.LotStatus = false;
            this.pb.Margin = new System.Windows.Forms.Padding(0);
            this.pb.Name = "pb";
            this.pb.ScaleImage = Infragistics.Win.ScaleImage.Always;
            this.pb.Size = new System.Drawing.Size(38, 36);
            this.pb.TabIndex = 1;
            this.pb.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.pb.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMessage.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1158, 36);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTop
            // 
            this.pnlTop._UseOITheme = false;
            this.pnlTop._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.pnlTopMargin);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1240, 60);
            this.pnlTop.TabIndex = 1;
            // 
            // pnlTopMargin
            // 
            this.pnlTopMargin._UseOITheme = false;
            this.pnlTopMargin._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlTopMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopMargin.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopMargin.Controls.Add(this.lblFormTitle);
            this.pnlTopMargin.Location = new System.Drawing.Point(20, 5);
            this.pnlTopMargin.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlTopMargin.Name = "pnlTopMargin";
            this.pnlTopMargin.Size = new System.Drawing.Size(1200, 50);
            this.pnlTopMargin.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle._UseConvertLanguage = true;
            this.lblFormTitle._UseOITheme = false;
            this.lblFormTitle._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblFormTitle.Appearance = appearance5;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFormTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(1);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(1200, 50);
            this.lblFormTitle.TabIndex = 2;
            this.lblFormTitle.Text = "Title";
            this.lblFormTitle.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblFormTitle.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // SOIBaseForm01
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1240, 760);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SOIBaseForm01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SOIBaseForm01";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SOIBaseForm01_FormClosed);
            this.Load += new System.EventHandler(this.SOIBaseForm01_Load);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.spcBottom.Panel1.ResumeLayout(false);
            this.spcBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcBottom)).EndInit();
            this.spcBottom.ResumeLayout(false);
            this.pnlBottomMargin.ResumeLayout(false);
            this.pnlBottomClosePanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTopMargin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public SOIControls.SOILabel lblFormTitle;
        public SOIControls.SOIButton btnClose;
        public SOIControls.SOIPanel pnlTopMargin;
        public SOIControls.SOIPanel pnlTop;
        public SOIControls.SOIPanel pnlBottom;
        public SOIControls.SOIPanel pnlBottomMargin;
        public SOIControls.SOIPanel pnlMiddleMargin;
        public SOIControls.SOIPanel pnlMiddle;
        public SOIControls.SOIPanel pnlBottomClosePanel;
        private System.Windows.Forms.SplitContainer spcBottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label lblMessage;
        private SOIControls.SOIPictureBox pb;
    }
}