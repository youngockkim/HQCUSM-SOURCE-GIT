namespace SOI.ATP
{
    partial class frmATPRequestInventoryOutPrintPopup
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
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType3 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType4 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType5 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType6 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType7 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmATPRequestInventoryOutPrintPopup));
            this.btnPrint = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.soiTableLayoutPanel1 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.soiGroupBox2 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiPanel1 = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.spdDocument = new SOI.OIFrx.SOIControls.SOISpread();
            this.spdDocument_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            this.soiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox2)).BeginInit();
            this.soiGroupBox2.SuspendLayout();
            this.soiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDocument_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Size = new System.Drawing.Size(1196, 38);
            this.lblPopupTitle.Text = "Document";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlPopupTop.Size = new System.Drawing.Size(1216, 48);
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(2, 748);
            this.pnlPopupBottom.Size = new System.Drawing.Size(1216, 50);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1096, 0);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupMiddle.Size = new System.Drawing.Size(1216, 694);
            // 
            // pnlPopupTopMargin
            // 
            this.pnlPopupTopMargin.Size = new System.Drawing.Size(1196, 38);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Controls.Add(this.btnPrint);
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(1196, 40);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnPrint, 0);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.soiTableLayoutPanel1);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(1196, 684);
            // 
            // btnPrint
            // 
            this.btnPrint._UseOITheme = true;
            this.btnPrint._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance44.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance44.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.FontData.BoldAsString = "True";
            appearance44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance44.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnPrint.Appearance = appearance44;
            this.btnPrint.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance45.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance45.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance45.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnPrint.HotTrackAppearance = appearance45;
            this.btnPrint.Location = new System.Drawing.Point(986, 0);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnPrint.Name = "btnPrint";
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance46.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance46.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance46.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnPrint.PressedAppearance = appearance46;
            this.btnPrint.ShowFocusRect = false;
            this.btnPrint.ShowOutline = false;
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnPrint.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnPrint.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // soiTableLayoutPanel1
            // 
            this.soiTableLayoutPanel1._UseOITheme = true;
            this.soiTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel1.ColumnCount = 1;
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.Controls.Add(this.soiGroupBox2, 0, 0);
            this.soiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel1.Name = "soiTableLayoutPanel1";
            this.soiTableLayoutPanel1.RowCount = 1;
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 484F));
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 484F));
            this.soiTableLayoutPanel1.Size = new System.Drawing.Size(1196, 684);
            this.soiTableLayoutPanel1.TabIndex = 1;
            // 
            // soiGroupBox2
            // 
            this.soiGroupBox2._UseOITheme = true;
            this.soiGroupBox2._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox2.Appearance = appearance10;
            this.soiGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox2.ContentAreaAppearance = appearance11;
            this.soiGroupBox2.Controls.Add(this.soiPanel1);
            this.soiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance12.FontData.BoldAsString = "True";
            appearance12.FontData.SizeInPoints = 14F;
            appearance12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance12.TextHAlignAsString = "Right";
            this.soiGroupBox2.HeaderAppearance = appearance12;
            this.soiGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.soiGroupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox2.Name = "soiGroupBox2";
            this.soiGroupBox2.Size = new System.Drawing.Size(1196, 684);
            this.soiGroupBox2.TabIndex = 0;
            this.soiGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // soiPanel1
            // 
            this.soiPanel1._UseOITheme = true;
            this.soiPanel1._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.soiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soiPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiPanel1.Controls.Add(this.spdDocument);
            this.soiPanel1.Location = new System.Drawing.Point(11, 5);
            this.soiPanel1.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.soiPanel1.Name = "soiPanel1";
            this.soiPanel1.Size = new System.Drawing.Size(1174, 673);
            this.soiPanel1.TabIndex = 0;
            // 
            // spdDocument
            // 
            this.spdDocument._UseAutoHeight = false;
            this.spdDocument._UseOITheme = false;
            this.spdDocument.AccessibleDescription = "spdDocument, Sheet1, Row 0, Column 0, Request Inventory Out";
            this.spdDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDocument.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDocument.HorizontalScrollBar.Name = "";
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
            this.spdDocument.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdDocument.HorizontalScrollBar.TabIndex = 0;
            this.spdDocument.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdDocument.Location = new System.Drawing.Point(0, 0);
            this.spdDocument.Margin = new System.Windows.Forms.Padding(0);
            this.spdDocument.Name = "spdDocument";
            this.spdDocument.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdDocument.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdDocument.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDocument_Sheet1});
            this.spdDocument.Size = new System.Drawing.Size(1174, 673);
            this.spdDocument.SOICellHeight = 25;
            this.spdDocument.SOIColumnHeight = 30;
            this.spdDocument.TabIndex = 1;
            this.spdDocument.TabStop = false;
            this.spdDocument.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDocument.UseSOIContextMenu = true;
            this.spdDocument.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDocument.VerticalScrollBar.Name = "";
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
            this.spdDocument.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdDocument.VerticalScrollBar.TabIndex = 1;
            this.spdDocument.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdDocument.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdDocument_Sheet1
            // 
            this.spdDocument_Sheet1.Reset();
            spdDocument_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDocument_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDocument_Sheet1.ColumnCount = 9;
            spdDocument_Sheet1.RowCount = 6;
            this.spdDocument_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdDocument_Sheet1.Cells.Get(0, 0).ColumnSpan = 9;
            this.spdDocument_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(0, 0).Value = "Request Inventory Out";
            this.spdDocument_Sheet1.Cells.Get(1, 0).ColumnSpan = 9;
            this.spdDocument_Sheet1.Cells.Get(2, 0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(2, 0).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 0).Value = "Plan Date";
            this.spdDocument_Sheet1.Cells.Get(2, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 3).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 3).Value = "Line";
            this.spdDocument_Sheet1.Cells.Get(2, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 4).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(2, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 6).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(2, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 6).Value = "Publish Date";
            this.spdDocument_Sheet1.Cells.Get(2, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 7).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(2, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(3, 0).ColumnSpan = 9;
            this.spdDocument_Sheet1.Cells.Get(4, 0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 0).Value = "Seq";
            this.spdDocument_Sheet1.Cells.Get(4, 1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            generalCellType1.WordWrap = true;
            this.spdDocument_Sheet1.Cells.Get(4, 1).CellType = generalCellType1;
            this.spdDocument_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 1).Value = "Inventory Material ID";
            this.spdDocument_Sheet1.Cells.Get(4, 2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            generalCellType2.WordWrap = true;
            this.spdDocument_Sheet1.Cells.Get(4, 2).CellType = generalCellType2;
            this.spdDocument_Sheet1.Cells.Get(4, 2).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 2).Value = "Inventory Material Description";
            this.spdDocument_Sheet1.Cells.Get(4, 3).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(4, 4).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            generalCellType3.WordWrap = true;
            this.spdDocument_Sheet1.Cells.Get(4, 4).CellType = generalCellType3;
            this.spdDocument_Sheet1.Cells.Get(4, 4).Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(4, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 4).Value = "Production Requirement";
            this.spdDocument_Sheet1.Cells.Get(4, 5).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            generalCellType4.WordWrap = true;
            this.spdDocument_Sheet1.Cells.Get(4, 5).CellType = generalCellType4;
            this.spdDocument_Sheet1.Cells.Get(4, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 5).Value = "Safety Inventory";
            this.spdDocument_Sheet1.Cells.Get(4, 6).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            generalCellType5.WordWrap = true;
            this.spdDocument_Sheet1.Cells.Get(4, 6).CellType = generalCellType5;
            this.spdDocument_Sheet1.Cells.Get(4, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 6).Value = "Inventory Out";
            this.spdDocument_Sheet1.Cells.Get(4, 7).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            generalCellType6.WordWrap = true;
            this.spdDocument_Sheet1.Cells.Get(4, 7).CellType = generalCellType6;
            this.spdDocument_Sheet1.Cells.Get(4, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 7).Value = "Request ";
            this.spdDocument_Sheet1.Cells.Get(4, 8).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            generalCellType7.WordWrap = true;
            this.spdDocument_Sheet1.Cells.Get(4, 8).CellType = generalCellType7;
            this.spdDocument_Sheet1.Cells.Get(4, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 8).Value = "Inventory";
            this.spdDocument_Sheet1.Cells.Get(5, 0).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 1).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 2).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(5, 2).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(5, 3).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(5, 4).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(5, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDocument_Sheet1.Cells.Get(5, 5).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(5, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDocument_Sheet1.Cells.Get(5, 6).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(5, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDocument_Sheet1.Cells.Get(5, 7).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(5, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDocument_Sheet1.Cells.Get(5, 8).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(5, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDocument_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.spdDocument_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.ColumnHeader.Visible = false;
            this.spdDocument_Sheet1.Columns.Get(0).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(0).Width = 38F;
            this.spdDocument_Sheet1.Columns.Get(1).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(1).Width = 178F;
            this.spdDocument_Sheet1.Columns.Get(2).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(2).Width = 222F;
            this.spdDocument_Sheet1.Columns.Get(3).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(3).Width = 41F;
            this.spdDocument_Sheet1.Columns.Get(4).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(4).Width = 102F;
            this.spdDocument_Sheet1.Columns.Get(5).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(5).Width = 91F;
            this.spdDocument_Sheet1.Columns.Get(6).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(6).Width = 96F;
            this.spdDocument_Sheet1.Columns.Get(7).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(7).Width = 122F;
            this.spdDocument_Sheet1.Columns.Get(8).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(8).Width = 134F;
            this.spdDocument_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.spdDocument_Sheet1.DefaultStyle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdDocument_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdDocument_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.PrintInfo.ShowColor = true;
            this.spdDocument_Sheet1.PrintInfo.SmartPrintRules = ((FarPoint.Win.Spread.SmartPrintRulesCollection)(resources.GetObject("resource.SmartPrintRules")));
            this.spdDocument_Sheet1.PrintInfo.UseMax = false;
            this.spdDocument_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdDocument_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdDocument_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.RowHeader.Visible = false;
            this.spdDocument_Sheet1.Rows.Get(0).Font = new System.Drawing.Font("Malgun Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Rows.Get(0).Height = 70F;
            this.spdDocument_Sheet1.Rows.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Rows.Get(1).Height = 10F;
            this.spdDocument_Sheet1.Rows.Get(2).Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Rows.Get(2).Height = 50F;
            this.spdDocument_Sheet1.Rows.Get(3).Height = 10F;
            this.spdDocument_Sheet1.Rows.Get(4).Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Rows.Get(4).Height = 52F;
            this.spdDocument_Sheet1.Rows.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Rows.Get(5).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Rows.Get(5).Height = 25F;
            this.spdDocument_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdDocument_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdDocument_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdDocument_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.ZoomFactor = 1.1F;
            this.spdDocument_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmATPRequestInventoryOutPrintPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 800);
            this.Name = "frmATPRequestInventoryOutPrintPopup";
            this.Text = "frmATPRequestInventoryOutPrintPopup";
            this.Load += new System.EventHandler(this.frmTempSOIPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            this.soiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox2)).EndInit();
            this.soiGroupBox2.ResumeLayout(false);
            this.soiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDocument_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OIFrx.SOIControls.SOIButton btnPrint;
        private OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel1;
        private OIFrx.SOIControls.SOIGroupBox soiGroupBox2;
        private OIFrx.SOIControls.SOIPanel soiPanel1;
        private OIFrx.SOIControls.SOISpread spdDocument;
        private FarPoint.Win.Spread.SheetView spdDocument_Sheet1;
    }
}