namespace SOI.OIFrx.SOIPopup
{
    partial class frmPopupBase
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.pnlPopupBottom = new System.Windows.Forms.Panel();
            this.pnlPopupBottomMargin = new System.Windows.Forms.Panel();
            this.btnClose = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlPopupMiddle = new System.Windows.Forms.Panel();
            this.pnlPopupMiddleMargin = new System.Windows.Forms.Panel();
            this.pnlPopupTop = new System.Windows.Forms.Panel();
            this.pnlPopupTopMargin = new System.Windows.Forms.Panel();
            this.lblPopupTitle = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.pnlPopupTopUnderline = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlPopupBottom.Controls.Add(this.pnlPopupBottomMargin);
            this.pnlPopupBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPopupBottom.Location = new System.Drawing.Point(2, 548);
            this.pnlPopupBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupBottom.Name = "pnlPopupBottom";
            this.pnlPopupBottom.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlPopupBottom.Size = new System.Drawing.Size(796, 50);
            this.pnlPopupBottom.TabIndex = 3;
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.BackColor = System.Drawing.Color.Transparent;
            this.pnlPopupBottomMargin.Controls.Add(this.btnClose);
            this.pnlPopupBottomMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPopupBottomMargin.Location = new System.Drawing.Point(10, 5);
            this.pnlPopupBottomMargin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupBottomMargin.Name = "pnlPopupBottomMargin";
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(776, 40);
            this.pnlPopupBottomMargin.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose._UseOITheme = true;
            this.btnClose._UseStyle = SOI.OIFrx.SOIButtonStyle.CancelStyle;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance1.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance1.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance1.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnClose.Appearance = appearance1;
            this.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            appearance3.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(84)))));
            this.btnClose.HotTrackAppearance = appearance3;
            this.btnClose.Location = new System.Drawing.Point(676, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            appearance4.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnClose.PressedAppearance = appearance4;
            this.btnClose.ShowFocusRect = false;
            this.btnClose.ShowOutline = false;
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnClose.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnClose.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.Transparent;
            this.pnlPopupMiddle.Controls.Add(this.pnlPopupMiddleMargin);
            this.pnlPopupMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPopupMiddle.Location = new System.Drawing.Point(2, 54);
            this.pnlPopupMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupMiddle.Name = "pnlPopupMiddle";
            this.pnlPopupMiddle.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlPopupMiddle.Size = new System.Drawing.Size(796, 494);
            this.pnlPopupMiddle.TabIndex = 2;
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.BackColor = System.Drawing.Color.Transparent;
            this.pnlPopupMiddleMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPopupMiddleMargin.Location = new System.Drawing.Point(10, 5);
            this.pnlPopupMiddleMargin.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlPopupMiddleMargin.Name = "pnlPopupMiddleMargin";
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(776, 484);
            this.pnlPopupMiddleMargin.TabIndex = 3;
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlPopupTop.Controls.Add(this.pnlPopupTopMargin);
            this.pnlPopupTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPopupTop.Location = new System.Drawing.Point(2, 2);
            this.pnlPopupTop.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupTop.Name = "pnlPopupTop";
            this.pnlPopupTop.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlPopupTop.Size = new System.Drawing.Size(796, 48);
            this.pnlPopupTop.TabIndex = 1;
            // 
            // pnlPopupTopMargin
            // 
            this.pnlPopupTopMargin.BackColor = System.Drawing.Color.Transparent;
            this.pnlPopupTopMargin.Controls.Add(this.lblPopupTitle);
            this.pnlPopupTopMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPopupTopMargin.Location = new System.Drawing.Point(10, 5);
            this.pnlPopupTopMargin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupTopMargin.Name = "pnlPopupTopMargin";
            this.pnlPopupTopMargin.Size = new System.Drawing.Size(776, 38);
            this.pnlPopupTopMargin.TabIndex = 2;
            this.pnlPopupTopMargin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPopupTopMargin_MouseDown);
            this.pnlPopupTopMargin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPopupTopMargin_MouseMove);
            this.pnlPopupTopMargin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlPopupTopMargin_MouseUp);
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle._UseConvertLanguage = true;
            this.lblPopupTitle._UseOITheme = false;
            this.lblPopupTitle._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lblPopupTitle.Appearance = appearance2;
            this.lblPopupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPopupTitle.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPopupTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPopupTitle.Margin = new System.Windows.Forms.Padding(1);
            this.lblPopupTitle.Name = "lblPopupTitle";
            this.lblPopupTitle.Size = new System.Drawing.Size(776, 38);
            this.lblPopupTitle.TabIndex = 1;
            this.lblPopupTitle.Text = "Title";
            this.lblPopupTitle.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblPopupTitle.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.lblPopupTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPopupTopMargin_MouseDown);
            this.lblPopupTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPopupTopMargin_MouseMove);
            this.lblPopupTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlPopupTopMargin_MouseUp);
            // 
            // pnlPopupTopUnderline
            // 
            this.pnlPopupTopUnderline._UseOITheme = false;
            this.pnlPopupTopUnderline._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlPopupTopUnderline.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPopupTopUnderline.Location = new System.Drawing.Point(2, 50);
            this.pnlPopupTopUnderline.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupTopUnderline.Name = "pnlPopupTopUnderline";
            this.pnlPopupTopUnderline.Size = new System.Drawing.Size(796, 4);
            this.pnlPopupTopUnderline.TabIndex = 0;
            // 
            // frmPopupBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.pnlPopupMiddle);
            this.Controls.Add(this.pnlPopupBottom);
            this.Controls.Add(this.pnlPopupTopUnderline);
            this.Controls.Add(this.pnlPopupTop);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPopupBase";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPopupBase";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPopupBase_FormClosed);
            this.Load += new System.EventHandler(this.frmPopupBase_Load);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public SOIControls.SOILabel lblPopupTitle;
        public System.Windows.Forms.Panel pnlPopupTop;
        public System.Windows.Forms.Panel pnlPopupBottom;
        public SOIControls.SOIButton btnClose;
        public System.Windows.Forms.Panel pnlPopupMiddle;
        public System.Windows.Forms.Panel pnlPopupTopMargin;
        public System.Windows.Forms.Panel pnlPopupBottomMargin;
        public System.Windows.Forms.Panel pnlPopupMiddleMargin;
        private SOIControls.SOIPanel pnlPopupTopUnderline;

    }
}