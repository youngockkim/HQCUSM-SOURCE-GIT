namespace SOI.Solar
{
    partial class frmCUSViewLotListOfCustBarcodeMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCUSViewLotListOfCustBarcodeMaterial));
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtCustBarcode = new SOI.OIFrx.SOIControls.SOITextBox(this.components);
            this.soiLabel1 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.soiGroupBox3 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiTableLayoutPanel15 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.spdLotList = new BOI.OIFrx.BOIControls.BOISpread();
            this.spdLotList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnView = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.btnToExcel = new SOI.OIFrx.SOIControls.SOIButtonExportExcel(this.components);
            this.pnlTopMargin.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomMargin.SuspendLayout();
            this.pnlMiddleMargin.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottomClosePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox3)).BeginInit();
            this.soiGroupBox3.SuspendLayout();
            this.soiTableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList_Sheet1)).BeginInit();
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
            // pnlBottomMargin
            // 
            this.pnlBottomMargin.Controls.Add(this.btnToExcel);
            this.pnlBottomMargin.Controls.Add(this.btnView);
            this.pnlBottomMargin.Controls.SetChildIndex(this.pnlBottomClosePanel, 0);
            this.pnlBottomMargin.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottomMargin.Controls.SetChildIndex(this.btnToExcel, 0);
            // 
            // pnlMiddleMargin
            // 
            this.pnlMiddleMargin.Controls.Add(this.splitContainer1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtCustBarcode);
            this.splitContainer1.Panel1.Controls.Add(this.soiLabel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.soiGroupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 492);
            this.splitContainer1.SplitterDistance = 59;
            this.splitContainer1.TabIndex = 3;
            // 
            // txtCustBarcode
            // 
            this.txtCustBarcode._DecimalCount = 3;
            this.txtCustBarcode._UseOITheme = true;
            this.txtCustBarcode._UseOnlyNumeric = false;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance20.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            appearance20.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance20.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            appearance20.FontData.BoldAsString = "True";
            appearance20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance20.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtCustBarcode.Appearance = appearance20;
            this.txtCustBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtCustBarcode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCustBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustBarcode.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.txtCustBarcode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCustBarcode.Location = new System.Drawing.Point(199, 13);
            this.txtCustBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.txtCustBarcode.MaxLength = 100;
            this.txtCustBarcode.Name = "txtCustBarcode";
            this.txtCustBarcode.Size = new System.Drawing.Size(400, 40);
            this.txtCustBarcode.TabIndex = 49;
            this.txtCustBarcode.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtCustBarcode.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtCustBarcode.UseSOIContextMenu = true;
            this.txtCustBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustBarcode_KeyPress);
            // 
            // soiLabel1
            // 
            this.soiLabel1._UseConvertLanguage = true;
            this.soiLabel1._UseOITheme = true;
            this.soiLabel1._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            this.soiLabel1.Appearance = appearance8;
            this.soiLabel1.AutoSize = true;
            this.soiLabel1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.soiLabel1.Location = new System.Drawing.Point(19, 16);
            this.soiLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel1.Name = "soiLabel1";
            this.soiLabel1.Size = new System.Drawing.Size(164, 35);
            this.soiLabel1.TabIndex = 48;
            this.soiLabel1.Text = "Cust Barcode";
            this.soiLabel1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // soiGroupBox3
            // 
            this.soiGroupBox3._UseOITheme = true;
            this.soiGroupBox3._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance71.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox3.Appearance = appearance71;
            this.soiGroupBox3.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance72.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox3.ContentAreaAppearance = appearance72;
            this.soiGroupBox3.Controls.Add(this.soiTableLayoutPanel15);
            this.soiGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance73.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance73.FontData.BoldAsString = "True";
            appearance73.FontData.SizeInPoints = 14F;
            appearance73.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance73.TextHAlignAsString = "Right";
            this.soiGroupBox3.HeaderAppearance = appearance73;
            this.soiGroupBox3.Location = new System.Drawing.Point(0, 0);
            this.soiGroupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox3.Name = "soiGroupBox3";
            this.soiGroupBox3.Size = new System.Drawing.Size(1008, 429);
            this.soiGroupBox3.TabIndex = 3;
            this.soiGroupBox3.Text = "Lot List By ";
            this.soiGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // soiTableLayoutPanel15
            // 
            this.soiTableLayoutPanel15._UseOITheme = true;
            this.soiTableLayoutPanel15.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel15.ColumnCount = 1;
            this.soiTableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.soiTableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 354F));
            this.soiTableLayoutPanel15.Controls.Add(this.spdLotList, 0, 0);
            this.soiTableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel15.Location = new System.Drawing.Point(1, 32);
            this.soiTableLayoutPanel15.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel15.Name = "soiTableLayoutPanel15";
            this.soiTableLayoutPanel15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.soiTableLayoutPanel15.RowCount = 1;
            this.soiTableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.soiTableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.soiTableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.soiTableLayoutPanel15.Size = new System.Drawing.Size(1006, 396);
            this.soiTableLayoutPanel15.TabIndex = 6;
            // 
            // spdLotList
            // 
            this.spdLotList._UseAutoHeight = false;
            this.spdLotList._UseOITheme = true;
            this.spdLotList.AccessibleDescription = "spdWeightListByCar, Sheet1, Row 0, Column 0, ";
            this.spdLotList.AllowColumnMove = true;
            this.spdLotList.AllowUserZoom = false;
            this.spdLotList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdLotList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotList.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.spdLotList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotList.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdLotList.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdLotList.HorizontalScrollBar.TabIndex = 34;
            this.spdLotList.HorizontalScrollBarHeight = 25;
            this.spdLotList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLotList.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.spdLotList.Location = new System.Drawing.Point(0, 0);
            this.spdLotList.Margin = new System.Windows.Forms.Padding(0);
            this.spdLotList.Name = "spdLotList";
            this.spdLotList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdLotList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdLotList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotList_Sheet1});
            this.spdLotList.Size = new System.Drawing.Size(1006, 396);
            this.spdLotList.SOICellHeight = 50;
            this.spdLotList.SOIColumnHeight = 30;
            this.spdLotList.TabIndex = 0;
            this.spdLotList.TabStop = false;
            this.spdLotList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLotList.UseEnterKeyForMove = true;
            this.spdLotList.UseKeyPad = true;
            this.spdLotList.UseSOIContextMenu = true;
            this.spdLotList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotList.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdLotList.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdLotList.VerticalScrollBar.TabIndex = 35;
            this.spdLotList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLotList.VerticalScrollBarWidth = 25;
            this.spdLotList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList.SetActiveViewport(0, -1, -1);
            // 
            // spdLotList_Sheet1
            // 
            this.spdLotList_Sheet1.Reset();
            spdLotList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotList_Sheet1.ColumnCount = 6;
            spdLotList_Sheet1.RowCount = 0;
            this.spdLotList_Sheet1.ActiveColumnIndex = -1;
            this.spdLotList_Sheet1.ActiveRowIndex = -1;
            this.spdLotList_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdLotList_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Box ID";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "FG ID";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Oper";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Lot ID";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Cust Barcode";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mat ID";
            this.spdLotList_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotList_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.spdLotList_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotList_Sheet1.Columns.Get(0).Label = "Box ID";
            this.spdLotList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(0).Width = 90F;
            this.spdLotList_Sheet1.Columns.Get(1).Label = "FG ID";
            this.spdLotList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(1).Width = 90F;
            this.spdLotList_Sheet1.Columns.Get(2).Label = "Oper";
            this.spdLotList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(2).Width = 90F;
            this.spdLotList_Sheet1.Columns.Get(3).Label = "Lot ID";
            this.spdLotList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(3).Width = 90F;
            this.spdLotList_Sheet1.Columns.Get(4).Label = "Cust Barcode";
            this.spdLotList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(4).Width = 90F;
            this.spdLotList_Sheet1.Columns.Get(5).Label = "Mat ID";
            this.spdLotList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(5).Width = 90F;
            this.spdLotList_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdLotList_Sheet1.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdLotList_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdLotList_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdLotList_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdLotList_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdLotList_Sheet1.PrintInfo.ShowColor = true;
            this.spdLotList_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdLotList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotList_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.RowHeader.Columns.Get(0).Width = 52F;
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotList_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.spdLotList_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotList_Sheet1.Rows.Default.Height = 50F;
            this.spdLotList_Sheet1.Rows.Default.Resizable = true;
            this.spdLotList_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;
            this.spdLotList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdLotList_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdLotList_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdLotList_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdLotList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdLotList_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotList_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotList_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnView
            // 
            this.btnView._UseOITheme = true;
            this.btnView._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance59.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance59.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance59.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance59.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance59.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance59.FontData.BoldAsString = "True";
            appearance59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance59.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnView.Appearance = appearance59;
            this.btnView.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Font = new System.Drawing.Font("맑은 고딕", 18F);
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance66.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance66.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance66.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnView.HotTrackAppearance = appearance66;
            this.btnView.Location = new System.Drawing.Point(783, 0);
            this.btnView.Margin = new System.Windows.Forms.Padding(0);
            this.btnView.Name = "btnView";
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance67.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance67.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance67.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnView.PressedAppearance = appearance67;
            this.btnView.ShowFocusRect = false;
            this.btnView.ShowOutline = false;
            this.btnView.Size = new System.Drawing.Size(110, 75);
            this.btnView.TabIndex = 43;
            this.btnView.Text = "View";
            this.btnView.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnView.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnView.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnToExcel
            // 
            this.btnToExcel._UseOITheme = true;
            this.btnToExcel._UseStyle = SOI.OIFrx.SOIButtonExportExcelStyle.DefaultStyle;
            this.btnToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance92.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance92.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance92.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance92.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance92.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance92.FontData.BoldAsString = "True";
            appearance92.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance92.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            appearance92.TextHAlignAsString = "Left";
            appearance92.TextVAlignAsString = "Middle";
            this.btnToExcel.Appearance = appearance92;
            this.btnToExcel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnToExcel.Font = new System.Drawing.Font("맑은 고딕", 18F);
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance93.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance93.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance93.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance93.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnToExcel.HotTrackAppearance = appearance93;
            this.btnToExcel.ImageSize = new System.Drawing.Size(35, 35);
            this.btnToExcel.Location = new System.Drawing.Point(10, 0);
            this.btnToExcel.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnToExcel.Name = "btnToExcel";
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance94.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance94.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance94.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnToExcel.PressedAppearance = appearance94;
            this.btnToExcel.ShowFocusRect = false;
            this.btnToExcel.ShowOutline = false;
            this.btnToExcel.Size = new System.Drawing.Size(110, 75);
            this.btnToExcel.TabIndex = 44;
            this.btnToExcel.Text = "To Excel";
            this.btnToExcel.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnToExcel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnToExcel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // frmCUSViewLotListOfCustBarcodeMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 647);
            this.Name = "frmCUSViewLotListOfCustBarcodeMaterial";
            this.Text = "frmCUSViewLotListOfCustBarcodeMaterial";
            this.Load += new System.EventHandler(this.frmCUSViewLotListOfCustBarcodeMaterial_Load);
            this.pnlTopMargin.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomMargin.ResumeLayout(false);
            this.pnlMiddleMargin.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.pnlBottomClosePanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox3)).EndInit();
            this.soiGroupBox3.ResumeLayout(false);
            this.soiTableLayoutPanel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private OIFrx.SOIControls.SOITextBox txtCustBarcode;
        private OIFrx.SOIControls.SOILabel soiLabel1;
        private OIFrx.SOIControls.SOIGroupBox soiGroupBox3;
        private OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel15;
        private BOI.OIFrx.BOIControls.BOISpread spdLotList;
        private FarPoint.Win.Spread.SheetView spdLotList_Sheet1;
        private OIFrx.SOIControls.SOIButton btnView;
        private OIFrx.SOIControls.SOIButtonExportExcel btnToExcel;
    }
}