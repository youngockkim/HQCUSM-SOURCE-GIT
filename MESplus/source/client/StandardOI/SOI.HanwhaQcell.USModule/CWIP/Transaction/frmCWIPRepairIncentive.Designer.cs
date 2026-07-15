namespace SOI.HanwhaQcell.USModule
{
    partial class frmCWIPRepairIncentive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCWIPRepairIncentive));
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            this.soiGroupBox12 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiPanel8 = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.soiTableLayoutPanel7 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.cdvLocation = new SOI.OIFrx.SOIControls.SOICodeViewDescription();
            this.lblLocation = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.lblStartTime = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.txtStartTime = new SOI.OIFrx.SOIControls.SOITextBox(this.components);
            this.soiLabel1 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.txtEndTime = new SOI.OIFrx.SOIControls.SOITextBox(this.components);
            this.soiLabel2 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.cdvWorker = new SOI.OIFrx.SOIControls.SOICodeViewDescription();
            this.btnClear = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.btnRestart = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.btnSearch = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlTopMargin.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomMargin.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottomClosePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox12)).BeginInit();
            this.soiGroupBox12.SuspendLayout();
            this.soiPanel8.SuspendLayout();
            this.soiTableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(510, 0);
            this.btnProcess.Size = new System.Drawing.Size(160, 51);
            this.btnProcess.Text = "End";
            this.btnProcess.Click += new System.EventHandler(this.btnSave_Click);
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
            this.lblFormTitle.Text = "Management String Repair";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(675, 0);
            this.btnClose.Size = new System.Drawing.Size(160, 51);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 658);
            this.pnlBottom.Size = new System.Drawing.Size(1274, 61);
            // 
            // pnlBottomMargin
            // 
            this.pnlBottomMargin.Size = new System.Drawing.Size(1234, 51);
            // 
            // pnlMiddleMargin
            // 
            this.pnlMiddleMargin.Size = new System.Drawing.Size(1234, 588);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.AutoSize = true;
            this.pnlMiddle.Controls.Add(this.soiGroupBox12);
            this.pnlMiddle.Size = new System.Drawing.Size(1274, 598);
            this.pnlMiddle.Controls.SetChildIndex(this.pnlMiddleMargin, 0);
            this.pnlMiddle.Controls.SetChildIndex(this.soiGroupBox12, 0);
            // 
            // pnlBottomClosePanel
            // 
            this.pnlBottomClosePanel.Controls.Add(this.btnSearch);
            this.pnlBottomClosePanel.Controls.Add(this.btnRestart);
            this.pnlBottomClosePanel.Controls.Add(this.btnClear);
            this.pnlBottomClosePanel.Location = new System.Drawing.Point(396, 0);
            this.pnlBottomClosePanel.Size = new System.Drawing.Size(838, 51);
            this.pnlBottomClosePanel.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottomClosePanel.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottomClosePanel.Controls.SetChildIndex(this.btnClear, 0);
            this.pnlBottomClosePanel.Controls.SetChildIndex(this.btnRestart, 0);
            this.pnlBottomClosePanel.Controls.SetChildIndex(this.btnSearch, 0);
            // 
            // soiGroupBox12
            // 
            this.soiGroupBox12._UseOITheme = true;
            this.soiGroupBox12._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance61.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox12.Appearance = appearance61;
            this.soiGroupBox12.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance62.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox12.ContentAreaAppearance = appearance62;
            this.soiGroupBox12.Controls.Add(this.soiPanel8);
            this.soiGroupBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance63.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance63.FontData.BoldAsString = "True";
            appearance63.FontData.SizeInPoints = 14F;
            appearance63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance63.TextHAlignAsString = "Right";
            this.soiGroupBox12.HeaderAppearance = appearance63;
            this.soiGroupBox12.Location = new System.Drawing.Point(20, 5);
            this.soiGroupBox12.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox12.Name = "soiGroupBox12";
            this.soiGroupBox12.Size = new System.Drawing.Size(1234, 588);
            this.soiGroupBox12.TabIndex = 2;
            this.soiGroupBox12.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // soiPanel8
            // 
            this.soiPanel8._SetAutoScrollPanel = false;
            this.soiPanel8._UseOITheme = true;
            this.soiPanel8._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.soiPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soiPanel8.BackColor = System.Drawing.Color.Transparent;
            this.soiPanel8.Controls.Add(this.soiTableLayoutPanel7);
            this.soiPanel8.Location = new System.Drawing.Point(11, 5);
            this.soiPanel8.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.soiPanel8.Name = "soiPanel8";
            this.soiPanel8.Size = new System.Drawing.Size(1213, 577);
            this.soiPanel8.TabIndex = 0;
            // 
            // soiTableLayoutPanel7
            // 
            this.soiTableLayoutPanel7._UseOITheme = true;
            this.soiTableLayoutPanel7.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel7.ColumnCount = 5;
            this.soiTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.soiTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.soiTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.soiTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.soiTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.soiTableLayoutPanel7.Controls.Add(this.cdvLocation, 1, 2);
            this.soiTableLayoutPanel7.Controls.Add(this.lblLocation, 0, 2);
            this.soiTableLayoutPanel7.Controls.Add(this.lblStartTime, 0, 3);
            this.soiTableLayoutPanel7.Controls.Add(this.txtStartTime, 1, 3);
            this.soiTableLayoutPanel7.Controls.Add(this.soiLabel1, 0, 4);
            this.soiTableLayoutPanel7.Controls.Add(this.txtEndTime, 1, 4);
            this.soiTableLayoutPanel7.Controls.Add(this.soiLabel2, 0, 0);
            this.soiTableLayoutPanel7.Controls.Add(this.cdvWorker, 1, 0);
            this.soiTableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel7.Name = "soiTableLayoutPanel7";
            this.soiTableLayoutPanel7.RowCount = 5;
            this.soiTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.soiTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.soiTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.soiTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.soiTableLayoutPanel7.Size = new System.Drawing.Size(1213, 577);
            this.soiTableLayoutPanel7.TabIndex = 1;
            // 
            // cdvLocation
            // 
            this.cdvLocation._UseConvertLanguageCode = false;
            this.cdvLocation._UseConvertLanguageDesc = false;
            this.cdvLocation._UseOITheme = true;
            this.cdvLocation.Code = "";
            this.cdvLocation.CodeWidth = 200;
            this.cdvLocation.Description = "";
            this.cdvLocation.DescriptionVisible = true;
            this.cdvLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvLocation.Font = new System.Drawing.Font("맑은 고딕", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cdvLocation.Location = new System.Drawing.Point(242, 185);
            this.cdvLocation.Margin = new System.Windows.Forms.Padding(0);
            this.cdvLocation.Name = "cdvLocation";
            this.cdvLocation.Size = new System.Drawing.Size(970, 142);
            this.cdvLocation.TabIndex = 23;
            this.cdvLocation.CodeViewButtonClick += new System.EventHandler(this.cdvLocation_CodeViewButtonClick);
            this.cdvLocation.ValueChanged += new System.EventHandler(this.cdvLocation_ValueChanged);
            // 
            // lblLocation
            // 
            this.lblLocation._UseConvertLanguage = true;
            this.lblLocation._UseOITheme = true;
            this.lblLocation._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.lblLocation.Appearance = appearance10;
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLocation.Font = new System.Drawing.Font("맑은 고딕", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocation.Location = new System.Drawing.Point(0, 185);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(242, 93);
            this.lblLocation.TabIndex = 16;
            this.lblLocation.Text = "Location";
            this.lblLocation.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblLocation.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblStartTime
            // 
            this.lblStartTime._UseConvertLanguage = true;
            this.lblStartTime._UseOITheme = true;
            this.lblStartTime._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.lblStartTime.Appearance = appearance7;
            this.lblStartTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStartTime.Font = new System.Drawing.Font("맑은 고딕", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStartTime.Location = new System.Drawing.Point(0, 327);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(242, 49);
            this.lblStartTime.TabIndex = 19;
            this.lblStartTime.Text = "Start Time";
            this.lblStartTime.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblStartTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtStartTime
            // 
            this.txtStartTime._DecimalCount = 3;
            this.txtStartTime._UseOITheme = true;
            this.txtStartTime._UseOnlyNumeric = false;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            appearance9.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance9.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            appearance9.FontData.BoldAsString = "True";
            appearance9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance9.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtStartTime.Appearance = appearance9;
            this.txtStartTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtStartTime.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtStartTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtStartTime.Enabled = false;
            this.txtStartTime.Font = new System.Drawing.Font("맑은 고딕", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtStartTime.Location = new System.Drawing.Point(242, 327);
            this.txtStartTime.Margin = new System.Windows.Forms.Padding(0);
            this.txtStartTime.MaxLength = 100;
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(970, 54);
            this.txtStartTime.TabIndex = 20;
            this.txtStartTime.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtStartTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtStartTime.UseSOIContextMenu = true;
            // 
            // soiLabel1
            // 
            this.soiLabel1._UseConvertLanguage = true;
            this.soiLabel1._UseOITheme = true;
            this.soiLabel1._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.soiLabel1.Appearance = appearance3;
            this.soiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.soiLabel1.Font = new System.Drawing.Font("맑은 고딕", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.soiLabel1.Location = new System.Drawing.Point(0, 454);
            this.soiLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel1.Name = "soiLabel1";
            this.soiLabel1.Size = new System.Drawing.Size(242, 49);
            this.soiLabel1.TabIndex = 21;
            this.soiLabel1.Text = "End Time";
            this.soiLabel1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtEndTime
            // 
            this.txtEndTime._DecimalCount = 3;
            this.txtEndTime._UseOITheme = true;
            this.txtEndTime._UseOnlyNumeric = false;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            appearance11.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance11.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            appearance11.FontData.BoldAsString = "True";
            appearance11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance11.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtEndTime.Appearance = appearance11;
            this.txtEndTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtEndTime.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtEndTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEndTime.Enabled = false;
            this.txtEndTime.Font = new System.Drawing.Font("맑은 고딕", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtEndTime.Location = new System.Drawing.Point(242, 454);
            this.txtEndTime.Margin = new System.Windows.Forms.Padding(0);
            this.txtEndTime.MaxLength = 100;
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(970, 54);
            this.txtEndTime.TabIndex = 22;
            this.txtEndTime.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtEndTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtEndTime.UseSOIContextMenu = true;
            // 
            // soiLabel2
            // 
            this.soiLabel2._UseConvertLanguage = true;
            this.soiLabel2._UseOITheme = true;
            this.soiLabel2._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.soiLabel2.Appearance = appearance1;
            this.soiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiLabel2.Font = new System.Drawing.Font("맑은 고딕", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.soiLabel2.Location = new System.Drawing.Point(0, 0);
            this.soiLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel2.Name = "soiLabel2";
            this.soiLabel2.Size = new System.Drawing.Size(242, 180);
            this.soiLabel2.TabIndex = 8;
            this.soiLabel2.Text = "Worker";
            this.soiLabel2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // cdvWorker
            // 
            this.cdvWorker._UseConvertLanguageCode = false;
            this.cdvWorker._UseConvertLanguageDesc = false;
            this.cdvWorker._UseOITheme = true;
            this.cdvWorker.Code = "";
            this.cdvWorker.CodeWidth = 400;
            this.cdvWorker.Description = "";
            this.cdvWorker.DescriptionVisible = true;
            this.cdvWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvWorker.Font = new System.Drawing.Font("맑은 고딕", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cdvWorker.Location = new System.Drawing.Point(242, 0);
            this.cdvWorker.Margin = new System.Windows.Forms.Padding(0);
            this.cdvWorker.Name = "cdvWorker";
            this.cdvWorker.Size = new System.Drawing.Size(970, 180);
            this.cdvWorker.TabIndex = 9;
            this.cdvWorker.CodeViewButtonClick += new System.EventHandler(this.cdvWorker_CodeViewButtonClick);
            this.cdvWorker.ValueChanged += new System.EventHandler(this.cdvWorker_ValueChanged);
            // 
            // btnClear
            // 
            this.btnClear._UseOITheme = true;
            this.btnClear._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance2.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance2.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance2.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance2.FontData.BoldAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance2.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnClear.Appearance = appearance2;
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance12.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnClear.HotTrackAppearance = appearance12;
            this.btnClear.Location = new System.Drawing.Point(9, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.Name = "btnClear";
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance13.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnClear.PressedAppearance = appearance13;
            this.btnClear.ShowFocusRect = false;
            this.btnClear.ShowOutline = false;
            this.btnClear.Size = new System.Drawing.Size(160, 51);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRestart
            // 
            this.btnRestart._UseOITheme = true;
            this.btnRestart._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance4.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance4.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance4.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance4.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnRestart.Appearance = appearance4;
            this.btnRestart.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.Enabled = false;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance5.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnRestart.HotTrackAppearance = appearance5;
            this.btnRestart.Location = new System.Drawing.Point(343, 0);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(0);
            this.btnRestart.Name = "btnRestart";
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance6.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnRestart.PressedAppearance = appearance6;
            this.btnRestart.ShowFocusRect = false;
            this.btnRestart.ShowOutline = false;
            this.btnRestart.Size = new System.Drawing.Size(160, 51);
            this.btnRestart.TabIndex = 28;
            this.btnRestart.Text = "Start";
            this.btnRestart.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnRestart.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnRestart.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnSearch
            // 
            this.btnSearch._UseOITheme = true;
            this.btnSearch._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance14.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance14.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance14.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance14.FontData.BoldAsString = "True";
            appearance14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance14.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnSearch.Appearance = appearance14;
            this.btnSearch.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance15.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnSearch.HotTrackAppearance = appearance15;
            this.btnSearch.Location = new System.Drawing.Point(176, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance16.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance16.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnSearch.PressedAppearance = appearance16;
            this.btnSearch.ShowFocusRect = false;
            this.btnSearch.ShowOutline = false;
            this.btnSearch.Size = new System.Drawing.Size(160, 51);
            this.btnSearch.TabIndex = 29;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSearch.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmCWIPRepairIncentive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 719);
            this.Name = "frmCWIPRepairIncentive";
            this.Text = "MESOI_Item_BaseForm02_Template1";
            this.pnlTopMargin.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomMargin.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlBottomClosePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox12)).EndInit();
            this.soiGroupBox12.ResumeLayout(false);
            this.soiPanel8.ResumeLayout(false);
            this.soiTableLayoutPanel7.ResumeLayout(false);
            this.soiTableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OIFrx.SOIControls.SOIGroupBox soiGroupBox12;
        private OIFrx.SOIControls.SOIPanel soiPanel8;
        private OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel7;
        private OIFrx.SOIControls.SOILabel soiLabel2;
        private OIFrx.SOIControls.SOICodeViewDescription cdvWorker;
        private OIFrx.SOIControls.SOILabel lblLocation;
        private OIFrx.SOIControls.SOILabel lblStartTime;
        private OIFrx.SOIControls.SOITextBox txtStartTime;
        private OIFrx.SOIControls.SOILabel soiLabel1;
        private OIFrx.SOIControls.SOITextBox txtEndTime;
        private OIFrx.SOIControls.SOIButton btnClear;
        private OIFrx.SOIControls.SOIButton btnRestart;
        private OIFrx.SOIControls.SOICodeViewDescription cdvLocation;
        private OIFrx.SOIControls.SOIButton btnSearch;


    }
}