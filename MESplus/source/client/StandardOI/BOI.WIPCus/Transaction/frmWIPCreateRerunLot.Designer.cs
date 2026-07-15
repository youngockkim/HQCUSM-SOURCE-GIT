namespace BOI.WIPCus
{
    partial class frmWIPCreateRerunLot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPCreateRerunLot));
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("CodeViewButton");
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton("CodeViewButton");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.soiTableLayoutPanel1 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.boiOrderInfo = new BOI.WIPCus.Controls.BOIOrderInfo();
            this.soiGroupBox1 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiGroupBox2 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiTableLayoutPanel3 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.lblCode = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.cdvRerunCode = new BOI.OIFrx.BOIControls.BOICodeView(this.components);
            this.txtRerunQty = new BOI.OIFrx.BOIControls.BOITextBoxNumber(this.components);
            this.soiLabel1 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.cdvWorkUser = new BOI.OIFrx.BOIControls.BOICodeView(this.components);
            this.soiLabel4 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.txtColSetID = new SOI.OIFrx.SOIControls.SOITextBox(this.components);
            this.btnProcess = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlTopMargin.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomMargin.SuspendLayout();
            this.pnlMiddleMargin.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottomClosePanel.SuspendLayout();
            this.soiTableLayoutPanel1.SuspendLayout();
            this.boiOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox2)).BeginInit();
            this.soiGroupBox2.SuspendLayout();
            this.soiTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRerunCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRerunQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvWorkUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColSetID)).BeginInit();
            this.SuspendLayout();
            // 
            // pbHelp
            // 
            this.pbHelp.Image = ((object)(resources.GetObject("pbHelp.Image")));
            // 
            // pbStdOper
            // 
            this.pbStdOper.Image = ((object)(resources.GetObject("pbStdOper.Image")));
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Create Rerun Lot";
            // 
            // pnlBottomMargin
            // 
            this.pnlBottomMargin.Controls.Add(this.btnProcess);
            this.pnlBottomMargin.Controls.SetChildIndex(this.pnlBottomClosePanel, 0);
            this.pnlBottomMargin.Controls.SetChildIndex(this.btnProcess, 0);
            // 
            // pnlMiddleMargin
            // 
            this.pnlMiddleMargin.Controls.Add(this.soiTableLayoutPanel1);
            // 
            // soiTableLayoutPanel1
            // 
            this.soiTableLayoutPanel1._UseOITheme = true;
            this.soiTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel1.ColumnCount = 1;
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.Controls.Add(this.boiOrderInfo, 0, 0);
            this.soiTableLayoutPanel1.Controls.Add(this.soiGroupBox2, 0, 1);
            this.soiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel1.Name = "soiTableLayoutPanel1";
            this.soiTableLayoutPanel1.RowCount = 2;
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.Size = new System.Drawing.Size(1008, 492);
            this.soiTableLayoutPanel1.TabIndex = 1;
            // 
            // boiOrderInfo
            // 
            this.boiOrderInfo.Controls.Add(this.soiGroupBox1);
            this.boiOrderInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boiOrderInfo.InvisibleColums = null;
            this.boiOrderInfo.Location = new System.Drawing.Point(5, 9);
            this.boiOrderInfo.LotId = "";
            this.boiOrderInfo.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.boiOrderInfo.Name = "boiOrderInfo";
            this.boiOrderInfo.Oper = "A100";
            this.boiOrderInfo.Size = new System.Drawing.Size(998, 168);
            this.boiOrderInfo.TabIndex = 2;
            this.boiOrderInfo.VisibleColums = null;
            this.boiOrderInfo.WorkOrderLineDesc = null;
            this.boiOrderInfo.WorkOrderLineId = null;
            // 
            // soiGroupBox1
            // 
            this.soiGroupBox1._UseOITheme = true;
            this.soiGroupBox1._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox1.Appearance = appearance6;
            this.soiGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox1.ContentAreaAppearance = appearance8;
            this.soiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiGroupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance9.FontData.BoldAsString = "True";
            appearance9.FontData.SizeInPoints = 14F;
            appearance9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance9.TextHAlignAsString = "Right";
            this.soiGroupBox1.HeaderAppearance = appearance9;
            this.soiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.soiGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox1.Name = "soiGroupBox1";
            this.soiGroupBox1.Size = new System.Drawing.Size(998, 168);
            this.soiGroupBox1.TabIndex = 2;
            this.soiGroupBox1.Text = "Order Information";
            this.soiGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // soiGroupBox2
            // 
            this.soiGroupBox2._UseOITheme = true;
            this.soiGroupBox2._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox2.Appearance = appearance7;
            this.soiGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox2.ContentAreaAppearance = appearance12;
            this.soiGroupBox2.Controls.Add(this.soiTableLayoutPanel3);
            this.soiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance13.FontData.BoldAsString = "True";
            appearance13.FontData.SizeInPoints = 14F;
            appearance13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance13.TextHAlignAsString = "Right";
            this.soiGroupBox2.HeaderAppearance = appearance13;
            this.soiGroupBox2.Location = new System.Drawing.Point(0, 186);
            this.soiGroupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox2.Name = "soiGroupBox2";
            this.soiGroupBox2.Size = new System.Drawing.Size(1008, 306);
            this.soiGroupBox2.TabIndex = 1;
            this.soiGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
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
            this.soiTableLayoutPanel3.Controls.Add(this.lblCode, 0, 0);
            this.soiTableLayoutPanel3.Controls.Add(this.cdvRerunCode, 1, 0);
            this.soiTableLayoutPanel3.Controls.Add(this.txtRerunQty, 4, 0);
            this.soiTableLayoutPanel3.Controls.Add(this.soiLabel1, 3, 0);
            this.soiTableLayoutPanel3.Controls.Add(this.cdvWorkUser, 1, 1);
            this.soiTableLayoutPanel3.Controls.Add(this.soiLabel4, 0, 1);
            this.soiTableLayoutPanel3.Controls.Add(this.txtColSetID, 0, 2);
            this.soiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel3.Location = new System.Drawing.Point(1, 0);
            this.soiTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel3.Name = "soiTableLayoutPanel3";
            this.soiTableLayoutPanel3.RowCount = 4;
            this.soiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.soiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.soiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.soiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel3.Size = new System.Drawing.Size(1006, 305);
            this.soiTableLayoutPanel3.TabIndex = 0;
            // 
            // lblCode
            // 
            this.lblCode._UseConvertLanguage = true;
            this.lblCode._UseOITheme = true;
            this.lblCode._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lblCode.Appearance = appearance1;
            this.lblCode.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblCode.Location = new System.Drawing.Point(0, 0);
            this.lblCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(150, 50);
            this.lblCode.TabIndex = 22;
            this.lblCode.Tag = "H";
            this.lblCode.Text = "Re-Run";
            this.lblCode.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblCode.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // cdvRerunCode
            // 
            this.cdvRerunCode._UseOITheme = true;
            this.cdvRerunCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance38.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance38.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance38.FontData.BoldAsString = "True";
            appearance38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance38.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.cdvRerunCode.Appearance = appearance38;
            this.cdvRerunCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cdvRerunCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance33.Image = ((object)(resources.GetObject("appearance33.Image")));
            editorButton1.Appearance = appearance33;
            editorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            editorButton1.Key = "CodeViewButton";
            editorButton1.Width = 30;
            this.cdvRerunCode.ButtonsRight.Add(editorButton1);
            this.cdvRerunCode.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cdvRerunCode.Location = new System.Drawing.Point(150, 5);
            this.cdvRerunCode.Margin = new System.Windows.Forms.Padding(0);
            this.cdvRerunCode.Name = "cdvRerunCode";
            this.cdvRerunCode.ReadOnly = true;
            this.cdvRerunCode.SaveRegistry = true;
            this.cdvRerunCode.Size = new System.Drawing.Size(250, 40);
            this.cdvRerunCode.TabIndex = 29;
            this.cdvRerunCode.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cdvRerunCode.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cdvRerunCode.CodeViewButtonClick += new System.EventHandler(this.cdvRerunCode_CodeViewButtonClick);
            // 
            // txtRerunQty
            // 
            this.txtRerunQty._UseOITheme = true;
            this.txtRerunQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance36.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance36.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance36.FontData.BoldAsString = "True";
            appearance36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance36.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtRerunQty.Appearance = appearance36;
            this.txtRerunQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtRerunQty.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRerunQty.DefaultDoubleValue = 0D;
            this.txtRerunQty.DefaultIntegerValue = 0;
            this.txtRerunQty.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRerunQty.FormatString = "N2";
            this.txtRerunQty.isKeyDown = true;
            this.txtRerunQty.Location = new System.Drawing.Point(560, 5);
            this.txtRerunQty.Margin = new System.Windows.Forms.Padding(0);
            this.txtRerunQty.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtRerunQty.MaskInput = "{LOC}nnnnnnn.nn";
            this.txtRerunQty.Name = "txtRerunQty";
            this.txtRerunQty.Nullable = true;
            this.txtRerunQty.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtRerunQty.PromptChar = ' ';
            this.txtRerunQty.ShowKeyPadControl = true;
            this.txtRerunQty.Size = new System.Drawing.Size(250, 40);
            this.txtRerunQty.TabIndex = 36;
            this.txtRerunQty.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtRerunQty.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // soiLabel1
            // 
            this.soiLabel1._UseConvertLanguage = true;
            this.soiLabel1._UseOITheme = true;
            this.soiLabel1._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            this.soiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.soiLabel1.Appearance = appearance11;
            this.soiLabel1.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.soiLabel1.Location = new System.Drawing.Point(410, 0);
            this.soiLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel1.Name = "soiLabel1";
            this.soiLabel1.Size = new System.Drawing.Size(150, 50);
            this.soiLabel1.TabIndex = 35;
            this.soiLabel1.Tag = "H";
            this.soiLabel1.Text = "Re-Run Qty";
            this.soiLabel1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // cdvWorkUser
            // 
            this.cdvWorkUser._UseOITheme = true;
            this.cdvWorkUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance2.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance2.FontData.BoldAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance2.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.cdvWorkUser.Appearance = appearance2;
            this.cdvWorkUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cdvWorkUser.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            editorButton2.Appearance = appearance3;
            editorButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            editorButton2.Key = "CodeViewButton";
            editorButton2.Width = 30;
            this.cdvWorkUser.ButtonsRight.Add(editorButton2);
            this.cdvWorkUser.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cdvWorkUser.Location = new System.Drawing.Point(150, 55);
            this.cdvWorkUser.Margin = new System.Windows.Forms.Padding(0);
            this.cdvWorkUser.Name = "cdvWorkUser";
            this.cdvWorkUser.ReadOnly = true;
            this.cdvWorkUser.SaveRegistry = true;
            this.cdvWorkUser.Size = new System.Drawing.Size(250, 40);
            this.cdvWorkUser.TabIndex = 34;
            this.cdvWorkUser.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cdvWorkUser.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // soiLabel4
            // 
            this.soiLabel4._UseConvertLanguage = true;
            this.soiLabel4._UseOITheme = true;
            this.soiLabel4._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            this.soiLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance29.BackColor = System.Drawing.Color.Transparent;
            appearance29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance29.TextHAlignAsString = "Left";
            appearance29.TextVAlignAsString = "Middle";
            this.soiLabel4.Appearance = appearance29;
            this.soiLabel4.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.soiLabel4.Location = new System.Drawing.Point(0, 50);
            this.soiLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel4.Name = "soiLabel4";
            this.soiLabel4.Size = new System.Drawing.Size(150, 50);
            this.soiLabel4.TabIndex = 33;
            this.soiLabel4.Text = "Work User";
            this.soiLabel4.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtColSetID
            // 
            this.txtColSetID._UseOITheme = true;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance4.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance4.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtColSetID.Appearance = appearance4;
            this.txtColSetID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtColSetID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtColSetID.Location = new System.Drawing.Point(0, 100);
            this.txtColSetID.Margin = new System.Windows.Forms.Padding(0);
            this.txtColSetID.MaxLength = 100;
            this.txtColSetID.Name = "txtColSetID";
            this.txtColSetID.Size = new System.Drawing.Size(100, 29);
            this.txtColSetID.TabIndex = 38;
            this.txtColSetID.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtColSetID.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtColSetID.UseSOIContextMenu = true;
            this.txtColSetID.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess._UseOITheme = true;
            this.btnProcess._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance39.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance39.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance39.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance39.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance39.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance39.FontData.BoldAsString = "True";
            appearance39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance39.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnProcess.Appearance = appearance39;
            this.btnProcess.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcess.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance40.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance40.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance40.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnProcess.HotTrackAppearance = appearance40;
            this.btnProcess.Location = new System.Drawing.Point(773, 0);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(0);
            this.btnProcess.Name = "btnProcess";
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance5.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnProcess.PressedAppearance = appearance5;
            this.btnProcess.ShowFocusRect = false;
            this.btnProcess.ShowOutline = false;
            this.btnProcess.Size = new System.Drawing.Size(110, 75);
            this.btnProcess.TabIndex = 14;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnProcess.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnProcess.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // frmWIPCreateRerunLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 647);
            this.Name = "frmWIPCreateRerunLot";
            this.Text = "Create Rerun Lot";
            this.Load += new System.EventHandler(this.frmTempBOIBaseForm02_Load);
            this.Shown += new System.EventHandler(this.frmTempBOIBaseForm02_Shown);
            this.pnlTopMargin.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomMargin.ResumeLayout(false);
            this.pnlMiddleMargin.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.pnlBottomClosePanel.ResumeLayout(false);
            this.soiTableLayoutPanel1.ResumeLayout(false);
            this.boiOrderInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox2)).EndInit();
            this.soiGroupBox2.ResumeLayout(false);
            this.soiTableLayoutPanel3.ResumeLayout(false);
            this.soiTableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRerunCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRerunQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvWorkUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColSetID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel1;
        private SOI.OIFrx.SOIControls.SOIGroupBox soiGroupBox2;
        private SOI.OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel3;
        private SOI.OIFrx.SOIControls.SOILabel lblCode;
        private OIFrx.BOIControls.BOICodeView cdvRerunCode;
        private SOI.OIFrx.SOIControls.SOILabel soiLabel4;
        private OIFrx.BOIControls.BOICodeView cdvWorkUser;
        private SOI.OIFrx.SOIControls.SOILabel soiLabel1;
        private OIFrx.BOIControls.BOITextBoxNumber txtRerunQty;
        private SOI.OIFrx.SOIControls.SOIButton btnProcess;
        private SOI.OIFrx.SOIControls.SOITextBox txtColSetID;
        private Controls.BOIOrderInfo boiOrderInfo;
        private SOI.OIFrx.SOIControls.SOIGroupBox soiGroupBox1;
    }
}