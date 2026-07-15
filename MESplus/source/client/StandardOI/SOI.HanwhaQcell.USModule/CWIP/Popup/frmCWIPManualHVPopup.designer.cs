namespace SOI.HanwhaQcell.USModule.CWIP.Popup
{
    partial class frmCWIPManualHVPopup
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            this.soiPanel1 = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.soiLabel1 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.btnVertical = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            this.soiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Size = new System.Drawing.Size(654, 50);
            this.lblPopupTitle.Text = "Cell Location";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlPopupTop.Location = new System.Drawing.Point(4, 5);
            this.pnlPopupTop.Padding = new System.Windows.Forms.Padding(12, 7, 12, 7);
            this.pnlPopupTop.Size = new System.Drawing.Size(678, 64);
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(4, 339);
            this.pnlPopupBottom.Padding = new System.Windows.Forms.Padding(12, 7, 12, 7);
            this.pnlPopupBottom.Size = new System.Drawing.Size(678, 70);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Malgun Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(329, 0);
            this.btnClose.Size = new System.Drawing.Size(325, 56);
            this.btnClose.Text = "Horizontal";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupMiddle.Location = new System.Drawing.Point(4, 73);
            this.pnlPopupMiddle.Padding = new System.Windows.Forms.Padding(12, 7, 12, 7);
            this.pnlPopupMiddle.Size = new System.Drawing.Size(678, 266);
            // 
            // pnlPopupTopMargin
            // 
            this.pnlPopupTopMargin.Location = new System.Drawing.Point(12, 7);
            this.pnlPopupTopMargin.Size = new System.Drawing.Size(654, 50);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Controls.Add(this.btnVertical);
            this.pnlPopupBottomMargin.Location = new System.Drawing.Point(12, 7);
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(654, 56);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnVertical, 0);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.soiPanel1);
            this.pnlPopupMiddleMargin.Location = new System.Drawing.Point(12, 7);
            this.pnlPopupMiddleMargin.Margin = new System.Windows.Forms.Padding(12, 7, 12, 7);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(654, 252);
            // 
            // soiPanel1
            // 
            this.soiPanel1._SetAutoScrollPanel = false;
            this.soiPanel1._UseOITheme = true;
            this.soiPanel1._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.soiPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiPanel1.Controls.Add(this.soiLabel1);
            this.soiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiPanel1.Location = new System.Drawing.Point(0, 0);
            this.soiPanel1.Margin = new System.Windows.Forms.Padding(12, 7, 12, 7);
            this.soiPanel1.Name = "soiPanel1";
            this.soiPanel1.Size = new System.Drawing.Size(654, 252);
            this.soiPanel1.TabIndex = 3;
            // 
            // soiLabel1
            // 
            this.soiLabel1._UseConvertLanguage = true;
            this.soiLabel1._UseOITheme = true;
            this.soiLabel1._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BorderColor = System.Drawing.Color.Black;
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.soiLabel1.Appearance = appearance1;
            this.soiLabel1.Font = new System.Drawing.Font("Malgun Gothic", 18F);
            appearance2.BorderColor = System.Drawing.Color.Black;
            this.soiLabel1.HotTrackAppearance = appearance2;
            this.soiLabel1.Location = new System.Drawing.Point(16, 30);
            this.soiLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel1.Name = "soiLabel1";
            this.soiLabel1.Size = new System.Drawing.Size(616, 195);
            this.soiLabel1.TabIndex = 0;
            this.soiLabel1.Text = "Press Vertical for Vertical Packing                                     OR       " +
                "                                            Press Horizontal for Horizontal Pack" +
                "ing";
            this.soiLabel1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnVertical
            // 
            this.btnVertical._UseOITheme = true;
            this.btnVertical._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnVertical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance17.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance17.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance17.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance17.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance17.FontData.BoldAsString = "True";
            appearance17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance17.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnVertical.Appearance = appearance17;
            this.btnVertical.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVertical.Font = new System.Drawing.Font("Malgun Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance18.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance18.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnVertical.HotTrackAppearance = appearance18;
            this.btnVertical.Location = new System.Drawing.Point(0, 0);
            this.btnVertical.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnVertical.Name = "btnVertical";
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnVertical.PressedAppearance = appearance19;
            this.btnVertical.ShowFocusRect = false;
            this.btnVertical.ShowOutline = false;
            this.btnVertical.Size = new System.Drawing.Size(325, 56);
            this.btnVertical.TabIndex = 4;
            this.btnVertical.Text = "Vertical";
            this.btnVertical.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnVertical.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnVertical.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnVertical.Click += new System.EventHandler(this.btnVertical_Click);
            // 
            // frmCWIPManualHVPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 414);
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Name = "frmCWIPManualHVPopup";
            this.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Text = "frmCellLocationPopup";
            this.Load += new System.EventHandler(this.frmCWIPManualHVPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            this.soiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OIFrx.SOIControls.SOIPanel soiPanel1;
        private OIFrx.SOIControls.SOIButton btnVertical;
        private OIFrx.SOIControls.SOILabel soiLabel1;

    }
}