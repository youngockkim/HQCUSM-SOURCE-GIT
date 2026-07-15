namespace BOI.WIPCus
{
    partial class frmWIPInputEndQty
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
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            this.soiTableLayoutPanel1 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.soiLabel5 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.numEndQty = new BOI.OIFrx.BOIControls.BOITextBoxNumber(this.components);
            this.soiLabel2 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.btnProcess = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            this.soiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndQty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Size = new System.Drawing.Size(370, 38);
            this.lblPopupTitle.Text = "End Qty";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlPopupTop.Size = new System.Drawing.Size(390, 48);
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(2, 271);
            this.pnlPopupBottom.Padding = new System.Windows.Forms.Padding(5);
            this.pnlPopupBottom.Size = new System.Drawing.Size(390, 85);
            this.pnlPopupBottom.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.btnClose.Location = new System.Drawing.Point(270, 0);
            this.btnClose.Size = new System.Drawing.Size(110, 75);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupMiddle.Padding = new System.Windows.Forms.Padding(5);
            this.pnlPopupMiddle.Size = new System.Drawing.Size(390, 217);
            // 
            // pnlPopupTopMargin
            // 
            this.pnlPopupTopMargin.Size = new System.Drawing.Size(370, 38);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Controls.Add(this.btnProcess);
            this.pnlPopupBottomMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(380, 75);
            this.pnlPopupBottomMargin.TabIndex = 0;
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnProcess, 0);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.soiTableLayoutPanel1);
            this.pnlPopupMiddleMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlPopupMiddleMargin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(380, 207);
            // 
            // soiTableLayoutPanel1
            // 
            this.soiTableLayoutPanel1._UseOITheme = true;
            this.soiTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel1.ColumnCount = 5;
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.soiTableLayoutPanel1.Controls.Add(this.soiLabel5, 3, 0);
            this.soiTableLayoutPanel1.Controls.Add(this.numEndQty, 2, 0);
            this.soiTableLayoutPanel1.Controls.Add(this.soiLabel2, 1, 0);
            this.soiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel1.Name = "soiTableLayoutPanel1";
            this.soiTableLayoutPanel1.RowCount = 1;
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.Size = new System.Drawing.Size(380, 207);
            this.soiTableLayoutPanel1.TabIndex = 1;
            // 
            // soiLabel5
            // 
            this.soiLabel5._UseConvertLanguage = true;
            this.soiLabel5._UseOITheme = true;
            this.soiLabel5._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            this.soiLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance24.BackColor = System.Drawing.Color.Transparent;
            appearance24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance24.TextHAlignAsString = "Left";
            appearance24.TextVAlignAsString = "Middle";
            this.soiLabel5.Appearance = appearance24;
            this.soiLabel5.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.soiLabel5.Location = new System.Drawing.Point(328, 80);
            this.soiLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel5.Name = "soiLabel5";
            this.soiLabel5.Size = new System.Drawing.Size(43, 46);
            this.soiLabel5.TabIndex = 30;
            this.soiLabel5.Text = "Kg";
            this.soiLabel5.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel5.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // numEndQty
            // 
            this.numEndQty._UseOITheme = false;
            this.numEndQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance40.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance40.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance40.ForeColor = System.Drawing.Color.Red;
            appearance40.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.numEndQty.Appearance = appearance40;
            this.numEndQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.numEndQty.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.numEndQty.DefaultDoubleValue = 0D;
            this.numEndQty.DefaultIntegerValue = 0;
            this.numEndQty.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.numEndQty.FormatString = "N2";
            this.numEndQty.Location = new System.Drawing.Point(134, 83);
            this.numEndQty.Margin = new System.Windows.Forms.Padding(0);
            this.numEndQty.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.numEndQty.MaskInput = "{LOC}nnnnnnn.nn";
            this.numEndQty.Name = "numEndQty";
            this.numEndQty.Nullable = true;
            this.numEndQty.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.numEndQty.PromptChar = ' ';
            this.numEndQty.ShowKeyPadControl = true;
            this.numEndQty.Size = new System.Drawing.Size(194, 40);
            this.numEndQty.TabIndex = 0;
            this.numEndQty.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.numEndQty.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // soiLabel2
            // 
            this.soiLabel2._UseConvertLanguage = true;
            this.soiLabel2._UseOITheme = true;
            this.soiLabel2._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            this.soiLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.soiLabel2.Appearance = appearance1;
            this.soiLabel2.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.soiLabel2.Location = new System.Drawing.Point(9, 88);
            this.soiLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel2.Name = "soiLabel2";
            this.soiLabel2.Size = new System.Drawing.Size(125, 31);
            this.soiLabel2.TabIndex = 28;
            this.soiLabel2.Text = "End Qty";
            this.soiLabel2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnProcess
            // 
            this.btnProcess._UseOITheme = true;
            this.btnProcess._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance29.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance29.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance29.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance29.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance29.FontData.BoldAsString = "True";
            appearance29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance29.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnProcess.Appearance = appearance29;
            this.btnProcess.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcess.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance30.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance30.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance30.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnProcess.HotTrackAppearance = appearance30;
            this.btnProcess.Location = new System.Drawing.Point(155, 0);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(0);
            this.btnProcess.Name = "btnProcess";
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance31.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance31.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance31.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnProcess.PressedAppearance = appearance31;
            this.btnProcess.ShowFocusRect = false;
            this.btnProcess.ShowOutline = false;
            this.btnProcess.Size = new System.Drawing.Size(110, 75);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnProcess.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnProcess.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // frmWIPInputEndQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 358);
            this.Name = "frmWIPInputEndQty";
            this.Text = "frmWIPInputEndQty";
            this.Activated += new System.EventHandler(this.frmWIPInputEndQty_Activated);
            this.Load += new System.EventHandler(this.frmTempBOIPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            this.soiTableLayoutPanel1.ResumeLayout(false);
            this.soiTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel1;
        private SOI.OIFrx.SOIControls.SOILabel soiLabel5;
        private OIFrx.BOIControls.BOITextBoxNumber numEndQty;
        private SOI.OIFrx.SOIControls.SOILabel soiLabel2;
        private SOI.OIFrx.SOIControls.SOIButton btnProcess;
    }
}