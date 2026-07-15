namespace SOI.CINV.Popup
{
    partial class frmCINVViewResourceListPopup
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
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ko-KR", false);
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            this.spdCarResList = new BOI.OIFrx.BOIControls.BOISpread();
            this.spdCarResList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnSelect = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.soiTableLayoutPanel5 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.chkonInOutFlag = new SOI.OIFrx.SOIControls.SOICheckBoxOnOff(this.components);
            this.soiGroupBox1 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCarResList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCarResList_Sheet1)).BeginInit();
            this.soiTableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).BeginInit();
            this.soiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Size = new System.Drawing.Size(626, 38);
            this.lblPopupTitle.Text = "View Tank List";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlPopupTop.Size = new System.Drawing.Size(646, 48);
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(2, 612);
            this.pnlPopupBottom.Padding = new System.Windows.Forms.Padding(5);
            this.pnlPopupBottom.Size = new System.Drawing.Size(646, 85);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.btnClose.Location = new System.Drawing.Point(526, 0);
            this.btnClose.Size = new System.Drawing.Size(110, 75);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupMiddle.Padding = new System.Windows.Forms.Padding(5);
            this.pnlPopupMiddle.Size = new System.Drawing.Size(646, 558);
            // 
            // pnlPopupTopMargin
            // 
            this.pnlPopupTopMargin.Size = new System.Drawing.Size(626, 38);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Controls.Add(this.btnSelect);
            this.pnlPopupBottomMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(636, 75);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnSelect, 0);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.soiTableLayoutPanel5);
            this.pnlPopupMiddleMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlPopupMiddleMargin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(636, 548);
            // 
            // spdCarResList
            // 
            this.spdCarResList._UseAutoHeight = false;
            this.spdCarResList._UseOITheme = true;
            this.spdCarResList.AccessibleDescription = "spdCarResList, Sheet1, Row 0, Column 0, ";
            this.spdCarResList.AllowUserZoom = false;
            this.spdCarResList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdCarResList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdCarResList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCarResList.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.spdCarResList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCarResList.HorizontalScrollBar.Name = "";
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
            this.spdCarResList.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdCarResList.HorizontalScrollBar.TabIndex = 96;
            this.spdCarResList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCarResList.Location = new System.Drawing.Point(1, 32);
            this.spdCarResList.Margin = new System.Windows.Forms.Padding(0);
            this.spdCarResList.Name = "spdCarResList";
            this.spdCarResList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCarResList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCarResList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCarResList_Sheet1});
            this.spdCarResList.Size = new System.Drawing.Size(634, 422);
            this.spdCarResList.SOICellHeight = 50;
            this.spdCarResList.SOIColumnHeight = 30;
            this.spdCarResList.TabIndex = 6;
            this.spdCarResList.TabStop = false;
            this.spdCarResList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCarResList.UseEnterKeyForMove = true;
            this.spdCarResList.UseKeyPad = true;
            this.spdCarResList.UseSOIContextMenu = true;
            this.spdCarResList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCarResList.VerticalScrollBar.Name = "";
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
            this.spdCarResList.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdCarResList.VerticalScrollBar.TabIndex = 97;
            this.spdCarResList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCarResList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCarResList_CellClick);
            // 
            // spdCarResList_Sheet1
            // 
            this.spdCarResList_Sheet1.Reset();
            spdCarResList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCarResList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCarResList_Sheet1.ColumnCount = 4;
            spdCarResList_Sheet1.RowCount = 3;
            spdCarResList_Sheet1.RowHeader.ColumnCount = 0;
            this.spdCarResList_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdCarResList_Sheet1.Cells.Get(0, 1).Value = "Tank001";
            this.spdCarResList_Sheet1.Cells.Get(0, 2).Value = "원유 보관탱크 1";
            this.spdCarResList_Sheet1.Cells.Get(0, 3).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.spdCarResList_Sheet1.Cells.Get(0, 3).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.spdCarResList_Sheet1.Cells.Get(0, 3).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.spdCarResList_Sheet1.Cells.Get(0, 3).ParseFormatString = "n";
            this.spdCarResList_Sheet1.Cells.Get(0, 3).Value = 5000D;
            this.spdCarResList_Sheet1.Cells.Get(1, 1).Value = "Tank002";
            this.spdCarResList_Sheet1.Cells.Get(1, 2).Value = "원유 보관탱크 2";
            this.spdCarResList_Sheet1.Cells.Get(1, 3).ParseFormatInfo = ((System.Globalization.NumberFormatInfo)(cultureInfo.NumberFormat.Clone()));
            ((System.Globalization.NumberFormatInfo)(this.spdCarResList_Sheet1.Cells.Get(1, 3).ParseFormatInfo)).NumberDecimalDigits = 0;
            ((System.Globalization.NumberFormatInfo)(this.spdCarResList_Sheet1.Cells.Get(1, 3).ParseFormatInfo)).NumberGroupSizes = new int[] {
        0};
            this.spdCarResList_Sheet1.Cells.Get(1, 3).ParseFormatString = "n";
            this.spdCarResList_Sheet1.Cells.Get(1, 3).Value = 6000D;
            this.spdCarResList_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdCarResList_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdCarResList_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdCarResList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarResList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCarResList_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdCarResList_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdCarResList_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdCarResList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarResList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdCarResList_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Select";
            this.spdCarResList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tank ID";
            this.spdCarResList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tank Name";
            this.spdCarResList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Weight Tank";
            this.spdCarResList_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdCarResList_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdCarResList_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdCarResList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarResList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCarResList_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdCarResList_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.ColumnHeader.Rows.Get(0).Height = 60F;
            this.spdCarResList_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdCarResList_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdCarResList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCarResList_Sheet1.Columns.Get(0).Label = "Select";
            this.spdCarResList_Sheet1.Columns.Get(0).Locked = true;
            this.spdCarResList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCarResList_Sheet1.Columns.Get(0).VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdCarResList_Sheet1.Columns.Get(0).Width = 49F;
            this.spdCarResList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCarResList_Sheet1.Columns.Get(1).Label = "Tank ID";
            this.spdCarResList_Sheet1.Columns.Get(1).Locked = true;
            this.spdCarResList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCarResList_Sheet1.Columns.Get(1).Width = 180F;
            this.spdCarResList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCarResList_Sheet1.Columns.Get(2).Label = "Tank Name";
            this.spdCarResList_Sheet1.Columns.Get(2).Locked = true;
            this.spdCarResList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCarResList_Sheet1.Columns.Get(2).Width = 257F;
            numberCellType1.DecimalPlaces = 2;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.spdCarResList_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.spdCarResList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCarResList_Sheet1.Columns.Get(3).Label = "Weight Tank";
            this.spdCarResList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCarResList_Sheet1.Columns.Get(3).Width = 129F;
            this.spdCarResList_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdCarResList_Sheet1.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdCarResList_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdCarResList_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarResList_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdCarResList_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdCarResList_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdCarResList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdCarResList_Sheet1.PrintInfo.ShowColor = true;
            this.spdCarResList_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdCarResList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCarResList_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdCarResList_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdCarResList_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdCarResList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarResList_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCarResList_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdCarResList_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.spdCarResList_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdCarResList_Sheet1.RowHeader.Visible = false;
            this.spdCarResList_Sheet1.Rows.Default.Height = 50F;
            this.spdCarResList_Sheet1.Rows.Default.Resizable = true;
            this.spdCarResList_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;
            this.spdCarResList_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdCarResList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdCarResList_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdCarResList_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdCarResList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarResList_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdCarResList_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCarResList_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdCarResList_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdCarResList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnSelect
            // 
            this.btnSelect._UseOITheme = true;
            this.btnSelect._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance59.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance59.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance59.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance59.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance59.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance59.FontData.BoldAsString = "True";
            appearance59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance59.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnSelect.Appearance = appearance59;
            this.btnSelect.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Font = new System.Drawing.Font("맑은 고딕", 18F);
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance66.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance66.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance66.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnSelect.HotTrackAppearance = appearance66;
            this.btnSelect.Location = new System.Drawing.Point(409, 0);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelect.Name = "btnSelect";
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance67.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance67.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance67.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnSelect.PressedAppearance = appearance67;
            this.btnSelect.ShowFocusRect = false;
            this.btnSelect.ShowOutline = false;
            this.btnSelect.Size = new System.Drawing.Size(110, 75);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnSelect.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSelect.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // soiTableLayoutPanel5
            // 
            this.soiTableLayoutPanel5._UseOITheme = true;
            this.soiTableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel5.ColumnCount = 2;
            this.soiTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.soiTableLayoutPanel5.Controls.Add(this.chkonInOutFlag, 0, 2);
            this.soiTableLayoutPanel5.Controls.Add(this.soiGroupBox1, 0, 0);
            this.soiTableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel5.Name = "soiTableLayoutPanel5";
            this.soiTableLayoutPanel5.RowCount = 3;
            this.soiTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.soiTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.soiTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.soiTableLayoutPanel5.Size = new System.Drawing.Size(636, 548);
            this.soiTableLayoutPanel5.TabIndex = 7;
            // 
            // chkonInOutFlag
            // 
            this.chkonInOutFlag._UseConvertLanguage = true;
            this.chkonInOutFlag._UseOITheme = true;
            this.soiTableLayoutPanel5.SetColumnSpan(this.chkonInOutFlag, 2);
            this.chkonInOutFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkonInOutFlag.Location = new System.Drawing.Point(0, 483);
            this.chkonInOutFlag.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.chkonInOutFlag.Name = "chkonInOutFlag";
            this.chkonInOutFlag.OffStateKey = "O";
            this.chkonInOutFlag.OffStateText = "Out";
            this.chkonInOutFlag.OnOffState = SOI.OIFrx.SOICheckBoxOnOffState.OnState;
            this.chkonInOutFlag.OnStateKey = "I";
            this.chkonInOutFlag.OnStateText = "In";
            this.chkonInOutFlag.Size = new System.Drawing.Size(636, 45);
            this.chkonInOutFlag.TabIndex = 26;
            // 
            // soiGroupBox1
            // 
            this.soiGroupBox1._UseOITheme = true;
            this.soiGroupBox1._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance40.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox1.Appearance = appearance40;
            this.soiGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.soiTableLayoutPanel5.SetColumnSpan(this.soiGroupBox1, 2);
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance41.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox1.ContentAreaAppearance = appearance41;
            this.soiGroupBox1.Controls.Add(this.spdCarResList);
            this.soiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance42.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance42.FontData.BoldAsString = "True";
            appearance42.FontData.SizeInPoints = 14F;
            appearance42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance42.TextHAlignAsString = "Right";
            this.soiGroupBox1.HeaderAppearance = appearance42;
            this.soiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.soiGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox1.Name = "soiGroupBox1";
            this.soiGroupBox1.Size = new System.Drawing.Size(636, 455);
            this.soiGroupBox1.TabIndex = 29;
            this.soiGroupBox1.Text = "Tank List";
            this.soiGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // frmCINVViewResourceListPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 699);
            this.Name = "frmCINVViewResourceListPopup";
            this.Text = "frmCINVViewResourceListPopup";
            this.Load += new System.EventHandler(this.frmTempBOIPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCarResList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCarResList_Sheet1)).EndInit();
            this.soiTableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).EndInit();
            this.soiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BOI.OIFrx.BOIControls.BOISpread spdCarResList;
        private FarPoint.Win.Spread.SheetView spdCarResList_Sheet1;
        private OIFrx.SOIControls.SOIButton btnSelect;
        private OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel5;
        private OIFrx.SOIControls.SOICheckBoxOnOff chkonInOutFlag;
        private OIFrx.SOIControls.SOIGroupBox soiGroupBox1;
    }
}