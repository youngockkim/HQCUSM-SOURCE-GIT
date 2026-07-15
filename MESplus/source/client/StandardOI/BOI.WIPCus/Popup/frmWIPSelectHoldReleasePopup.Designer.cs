namespace BOI.WIPCus.Popup
{
    partial class frmWIPSelectHoldReleasePopup
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("CodeViewButton");
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSelectHoldReleasePopup));
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            this.soiGroupBox1 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiTableLayoutPanel3 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.soiLabel3 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.lblCode = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.cdvCode = new BOI.OIFrx.BOIControls.BOICodeView(this.components);
            this.txtComment = new SOI.OIFrx.SOIControls.SOITextBox(this.components);
            this.btnSelect = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).BeginInit();
            this.soiGroupBox1.SuspendLayout();
            this.soiTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Text = "Hold/Release";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(2, 163);
            this.pnlPopupBottom.Padding = new System.Windows.Forms.Padding(5);
            this.pnlPopupBottom.Size = new System.Drawing.Size(796, 85);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.btnClose.Size = new System.Drawing.Size(110, 75);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupMiddle.Padding = new System.Windows.Forms.Padding(5);
            this.pnlPopupMiddle.Size = new System.Drawing.Size(796, 109);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Controls.Add(this.btnSelect);
            this.pnlPopupBottomMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(786, 75);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnSelect, 0);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.soiGroupBox1);
            this.pnlPopupMiddleMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlPopupMiddleMargin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(786, 99);
            // 
            // soiGroupBox1
            // 
            this.soiGroupBox1._UseOITheme = true;
            this.soiGroupBox1._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox1.Appearance = appearance2;
            this.soiGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox1.ContentAreaAppearance = appearance3;
            this.soiGroupBox1.Controls.Add(this.soiTableLayoutPanel3);
            this.soiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.SizeInPoints = 14F;
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance1.TextHAlignAsString = "Right";
            this.soiGroupBox1.HeaderAppearance = appearance1;
            this.soiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.soiGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox1.Name = "soiGroupBox1";
            this.soiGroupBox1.Size = new System.Drawing.Size(786, 99);
            this.soiGroupBox1.TabIndex = 0;
            this.soiGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // soiTableLayoutPanel3
            // 
            this.soiTableLayoutPanel3._UseOITheme = true;
            this.soiTableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel3.ColumnCount = 7;
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel3.Controls.Add(this.soiLabel3, 0, 1);
            this.soiTableLayoutPanel3.Controls.Add(this.lblCode, 0, 0);
            this.soiTableLayoutPanel3.Controls.Add(this.cdvCode, 1, 0);
            this.soiTableLayoutPanel3.Controls.Add(this.txtComment, 1, 1);
            this.soiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel3.Location = new System.Drawing.Point(1, 0);
            this.soiTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel3.Name = "soiTableLayoutPanel3";
            this.soiTableLayoutPanel3.RowCount = 2;
            this.soiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.soiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.soiTableLayoutPanel3.Size = new System.Drawing.Size(784, 98);
            this.soiTableLayoutPanel3.TabIndex = 1;
            // 
            // soiLabel3
            // 
            this.soiLabel3._UseConvertLanguage = true;
            this.soiLabel3._UseOITheme = true;
            this.soiLabel3._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            this.soiLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance26.BackColor = System.Drawing.Color.Transparent;
            appearance26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.soiLabel3.Appearance = appearance26;
            this.soiLabel3.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.soiLabel3.Location = new System.Drawing.Point(0, 50);
            this.soiLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel3.Name = "soiLabel3";
            this.soiLabel3.Size = new System.Drawing.Size(150, 50);
            this.soiLabel3.TabIndex = 30;
            this.soiLabel3.Text = "Comment";
            this.soiLabel3.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblCode
            // 
            this.lblCode._UseConvertLanguage = true;
            this.lblCode._UseOITheme = true;
            this.lblCode._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.lblCode.Appearance = appearance11;
            this.lblCode.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblCode.Location = new System.Drawing.Point(0, 0);
            this.lblCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(150, 50);
            this.lblCode.TabIndex = 22;
            this.lblCode.Tag = "H";
            this.lblCode.Text = "Hold Code";
            this.lblCode.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblCode.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // cdvCode
            // 
            this.cdvCode._UseOITheme = true;
            this.cdvCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance38.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance38.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance38.FontData.BoldAsString = "True";
            appearance38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance38.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.cdvCode.Appearance = appearance38;
            this.cdvCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cdvCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance33.Image = ((object)(resources.GetObject("appearance33.Image")));
            editorButton1.Appearance = appearance33;
            editorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            editorButton1.Key = "CodeViewButton";
            editorButton1.Width = 30;
            this.cdvCode.ButtonsRight.Add(editorButton1);
            this.cdvCode.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cdvCode.Location = new System.Drawing.Point(150, 5);
            this.cdvCode.Margin = new System.Windows.Forms.Padding(0);
            this.cdvCode.Name = "cdvCode";
            this.cdvCode.ReadOnly = true;
            this.cdvCode.SaveRegistry = true;
            this.cdvCode.Size = new System.Drawing.Size(250, 40);
            this.cdvCode.TabIndex = 29;
            this.cdvCode.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cdvCode.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cdvCode.CodeViewButtonClick += new System.EventHandler(this.cdvCode_CodeViewButtonClick);
            // 
            // txtComment
            // 
            this.txtComment._UseOITheme = true;
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance32.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance32.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance32.FontData.BoldAsString = "True";
            appearance32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance32.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtComment.Appearance = appearance32;
            this.txtComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtComment.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.soiTableLayoutPanel3.SetColumnSpan(this.txtComment, 6);
            this.txtComment.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtComment.Location = new System.Drawing.Point(150, 55);
            this.txtComment.Margin = new System.Windows.Forms.Padding(0);
            this.txtComment.MaxLength = 100;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(634, 40);
            this.txtComment.TabIndex = 32;
            this.txtComment.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtComment.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtComment.UseSOIContextMenu = true;
            // 
            // btnSelect
            // 
            this.btnSelect._UseOITheme = true;
            this.btnSelect._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance19.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance19.FontData.BoldAsString = "True";
            appearance19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance19.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnSelect.Appearance = appearance19;
            this.btnSelect.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance20.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance20.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnSelect.HotTrackAppearance = appearance20;
            this.btnSelect.Location = new System.Drawing.Point(552, 0);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelect.Name = "btnSelect";
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance21.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance21.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance21.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnSelect.PressedAppearance = appearance21;
            this.btnSelect.ShowFocusRect = false;
            this.btnSelect.ShowOutline = false;
            this.btnSelect.Size = new System.Drawing.Size(110, 75);
            this.btnSelect.TabIndex = 26;
            this.btnSelect.Tag = "H";
            this.btnSelect.Text = "Select";
            this.btnSelect.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnSelect.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSelect.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmWIPSelectHoldReleasePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 250);
            this.Name = "frmWIPSelectHoldReleasePopup";
            this.Text = "frmWIPSelectHoldReleasePopup";
            this.Load += new System.EventHandler(this.frmTempBOIPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).EndInit();
            this.soiGroupBox1.ResumeLayout(false);
            this.soiTableLayoutPanel3.ResumeLayout(false);
            this.soiTableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOIGroupBox soiGroupBox1;
        private SOI.OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel3;
        private SOI.OIFrx.SOIControls.SOILabel soiLabel3;
        private SOI.OIFrx.SOIControls.SOILabel lblCode;
        private OIFrx.BOIControls.BOICodeView cdvCode;
        private SOI.OIFrx.SOIControls.SOITextBox txtComment;
        private SOI.OIFrx.SOIControls.SOIButton btnSelect;
    }
}