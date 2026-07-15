namespace BOI.OIFrx.Popup
{
    partial class frmCOMViewPrinterList
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.soiGroupBox2 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiTableLayoutPanel2 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.spdPrinterList = new BOI.OIFrx.BOIControls.BOISpread();
            this.spdPrinterList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnView = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox2)).BeginInit();
            this.soiGroupBox2.SuspendLayout();
            this.soiTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdPrinterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPrinterList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Text = "View Printer List";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Controls.Add(this.btnView);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnView, 0);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.soiGroupBox2);
            // 
            // soiGroupBox2
            // 
            this.soiGroupBox2._UseOITheme = true;
            this.soiGroupBox2._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox2.Appearance = appearance2;
            this.soiGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox2.ContentAreaAppearance = appearance3;
            this.soiGroupBox2.Controls.Add(this.soiTableLayoutPanel2);
            this.soiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.SizeInPoints = 14F;
            appearance4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance4.TextHAlignAsString = "Right";
            this.soiGroupBox2.HeaderAppearance = appearance4;
            this.soiGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.soiGroupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox2.Name = "soiGroupBox2";
            this.soiGroupBox2.Size = new System.Drawing.Size(776, 484);
            this.soiGroupBox2.TabIndex = 3;
            this.soiGroupBox2.Text = "Printer List";
            this.soiGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // soiTableLayoutPanel2
            // 
            this.soiTableLayoutPanel2._UseOITheme = true;
            this.soiTableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel2.ColumnCount = 1;
            this.soiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel2.Controls.Add(this.spdPrinterList, 0, 0);
            this.soiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel2.Location = new System.Drawing.Point(1, 32);
            this.soiTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel2.Name = "soiTableLayoutPanel2";
            this.soiTableLayoutPanel2.RowCount = 1;
            this.soiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.soiTableLayoutPanel2.Size = new System.Drawing.Size(774, 451);
            this.soiTableLayoutPanel2.TabIndex = 0;
            // 
            // spdPrinterList
            // 
            this.spdPrinterList._UseAutoHeight = false;
            this.spdPrinterList._UseOITheme = true;
            this.spdPrinterList.AccessibleDescription = "spdInvLot, Sheet1, Row 0, Column 0, ";
            this.spdPrinterList.AllowUserZoom = false;
            this.spdPrinterList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdPrinterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdPrinterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdPrinterList.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.spdPrinterList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPrinterList.HorizontalScrollBar.Name = "";
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
            this.spdPrinterList.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdPrinterList.HorizontalScrollBar.TabIndex = 152;
            this.spdPrinterList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdPrinterList.Location = new System.Drawing.Point(0, 0);
            this.spdPrinterList.Margin = new System.Windows.Forms.Padding(0);
            this.spdPrinterList.Name = "spdPrinterList";
            this.spdPrinterList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdPrinterList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdPrinterList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdPrinterList_Sheet1});
            this.spdPrinterList.Size = new System.Drawing.Size(774, 451);
            this.spdPrinterList.SOICellHeight = 50;
            this.spdPrinterList.SOIColumnHeight = 30;
            this.spdPrinterList.TabIndex = 7;
            this.spdPrinterList.TabStop = false;
            this.spdPrinterList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdPrinterList.UseEnterKeyForMove = true;
            this.spdPrinterList.UseKeyPad = true;
            this.spdPrinterList.UseSOIContextMenu = true;
            this.spdPrinterList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPrinterList.VerticalScrollBar.Name = "";
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
            this.spdPrinterList.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdPrinterList.VerticalScrollBar.TabIndex = 153;
            this.spdPrinterList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdPrinterList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdPrinterList_CellClick);
            // 
            // spdPrinterList_Sheet1
            // 
            this.spdPrinterList_Sheet1.Reset();
            spdPrinterList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdPrinterList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdPrinterList_Sheet1.ColumnCount = 1;
            spdPrinterList_Sheet1.RowCount = 3;
            this.spdPrinterList_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdPrinterList_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdPrinterList_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdPrinterList_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdPrinterList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrinterList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdPrinterList_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdPrinterList_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdPrinterList_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdPrinterList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrinterList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdPrinterList_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Printer";
            this.spdPrinterList_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdPrinterList_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdPrinterList_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdPrinterList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrinterList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdPrinterList_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdPrinterList_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.ColumnHeader.Rows.Get(0).Height = 65F;
            this.spdPrinterList_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdPrinterList_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdPrinterList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdPrinterList_Sheet1.Columns.Get(0).Label = "Printer";
            this.spdPrinterList_Sheet1.Columns.Get(0).Locked = true;
            this.spdPrinterList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPrinterList_Sheet1.Columns.Get(0).Width = 400F;
            this.spdPrinterList_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdPrinterList_Sheet1.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdPrinterList_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdPrinterList_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrinterList_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdPrinterList_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdPrinterList_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdPrinterList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdPrinterList_Sheet1.PrintInfo.ShowColor = true;
            this.spdPrinterList_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdPrinterList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdPrinterList_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdPrinterList_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdPrinterList_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdPrinterList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrinterList_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdPrinterList_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdPrinterList_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.spdPrinterList_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdPrinterList_Sheet1.Rows.Default.Height = 50F;
            this.spdPrinterList_Sheet1.Rows.Default.Resizable = true;
            this.spdPrinterList_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;
            this.spdPrinterList_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdPrinterList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdPrinterList_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdPrinterList_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdPrinterList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrinterList_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdPrinterList_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPrinterList_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdPrinterList_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdPrinterList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnView
            // 
            this.btnView._UseOITheme = true;
            this.btnView._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance6.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance6.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance6.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance6.FontData.BoldAsString = "True";
            appearance6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnView.Appearance = appearance6;
            this.btnView.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Font = new System.Drawing.Font("맑은 고딕", 12F);
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance7.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnView.HotTrackAppearance = appearance7;
            this.btnView.Location = new System.Drawing.Point(567, 0);
            this.btnView.Margin = new System.Windows.Forms.Padding(0);
            this.btnView.Name = "btnView";
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance8.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnView.PressedAppearance = appearance8;
            this.btnView.ShowFocusRect = false;
            this.btnView.ShowOutline = false;
            this.btnView.Size = new System.Drawing.Size(100, 40);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "View";
            this.btnView.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnView.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnView.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmCOMViewPrinterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "frmCOMViewPrinterList";
            this.Text = "frmCOMViewPrinterList";
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox2)).EndInit();
            this.soiGroupBox2.ResumeLayout(false);
            this.soiTableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdPrinterList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPrinterList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOIGroupBox soiGroupBox2;
        private SOI.OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel2;
        private OIFrx.BOIControls.BOISpread spdPrinterList;
        private FarPoint.Win.Spread.SheetView spdPrinterList_Sheet1;
        private SOI.OIFrx.SOIControls.SOIButton btnView;
    }
}