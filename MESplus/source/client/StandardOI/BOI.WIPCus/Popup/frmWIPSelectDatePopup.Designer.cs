namespace BOI.WIPCus.Popup
{
    partial class frmWIPSelectDatePopup
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
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer3 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer4 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            this.soiTableLayoutPanel1 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.soiGroupBox1 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.spdWorkOrder = new BOI.OIFrx.BOIControls.BOISpread();
            this.spdWorkOrder_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.soiGroupBox2 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.spdDateList = new BOI.OIFrx.BOIControls.BOISpread();
            this.spdDateList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnSelect = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.btnView = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            this.soiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).BeginInit();
            this.soiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox2)).BeginInit();
            this.soiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDateList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDateList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Text = "Select Date";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(2, 513);
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
            this.pnlPopupMiddle.Size = new System.Drawing.Size(796, 459);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Controls.Add(this.btnView);
            this.pnlPopupBottomMargin.Controls.Add(this.btnSelect);
            this.pnlPopupBottomMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(786, 75);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnSelect, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnView, 0);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.soiTableLayoutPanel1);
            this.pnlPopupMiddleMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlPopupMiddleMargin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(786, 449);
            // 
            // soiTableLayoutPanel1
            // 
            this.soiTableLayoutPanel1._UseOITheme = true;
            this.soiTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel1.ColumnCount = 1;
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.soiTableLayoutPanel1.Controls.Add(this.soiGroupBox1, 0, 0);
            this.soiTableLayoutPanel1.Controls.Add(this.soiGroupBox2, 0, 1);
            this.soiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel1.Name = "soiTableLayoutPanel1";
            this.soiTableLayoutPanel1.RowCount = 2;
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.soiTableLayoutPanel1.Size = new System.Drawing.Size(786, 449);
            this.soiTableLayoutPanel1.TabIndex = 0;
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
            this.soiGroupBox1.Controls.Add(this.spdWorkOrder);
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
            this.soiGroupBox1.Size = new System.Drawing.Size(786, 134);
            this.soiGroupBox1.TabIndex = 2;
            this.soiGroupBox1.Text = "Order Information";
            this.soiGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // spdWorkOrder
            // 
            this.spdWorkOrder._UseAutoHeight = false;
            this.spdWorkOrder._UseOITheme = true;
            this.spdWorkOrder.AccessibleDescription = "spdWorkOrder, Sheet1, Row 0, Column 0, ";
            this.spdWorkOrder.AllowUserZoom = false;
            this.spdWorkOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdWorkOrder.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.spdWorkOrder.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdWorkOrder.HorizontalScrollBar.Name = "";
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
            this.spdWorkOrder.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdWorkOrder.HorizontalScrollBar.TabIndex = 144;
            this.spdWorkOrder.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdWorkOrder.Location = new System.Drawing.Point(1, 32);
            this.spdWorkOrder.Margin = new System.Windows.Forms.Padding(0);
            this.spdWorkOrder.Name = "spdWorkOrder";
            this.spdWorkOrder.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdWorkOrder.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdWorkOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdWorkOrder_Sheet1});
            this.spdWorkOrder.Size = new System.Drawing.Size(784, 101);
            this.spdWorkOrder.SOICellHeight = 50;
            this.spdWorkOrder.SOIColumnHeight = 30;
            this.spdWorkOrder.TabIndex = 8;
            this.spdWorkOrder.TabStop = false;
            this.spdWorkOrder.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdWorkOrder.UseEnterKeyForMove = true;
            this.spdWorkOrder.UseKeyPad = true;
            this.spdWorkOrder.UseSOIContextMenu = true;
            this.spdWorkOrder.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdWorkOrder.VerticalScrollBar.Name = "";
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
            this.spdWorkOrder.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdWorkOrder.VerticalScrollBar.TabIndex = 145;
            this.spdWorkOrder.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdWorkOrder.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdWorkOrder_Sheet1
            // 
            this.spdWorkOrder_Sheet1.Reset();
            spdWorkOrder_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdWorkOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdWorkOrder_Sheet1.ColumnCount = 7;
            spdWorkOrder_Sheet1.RowCount = 3;
            spdWorkOrder_Sheet1.RowHeader.ColumnCount = 0;
            this.spdWorkOrder_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdWorkOrder_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdWorkOrder_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdWorkOrder_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Order Id";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Order Qty";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Mat ID";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Line";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Oper";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Resource";
            this.spdWorkOrder_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Box Qty";
            this.spdWorkOrder_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdWorkOrder_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdWorkOrder_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.ColumnHeader.Rows.Get(0).Height = 44F;
            this.spdWorkOrder_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdWorkOrder_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdWorkOrder_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(0).Label = "Order Id";
            this.spdWorkOrder_Sheet1.Columns.Get(0).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(0).Width = 120F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 10000000D;
            numberCellType1.MinimumValue = 0D;
            numberCellType1.WordWrap = true;
            this.spdWorkOrder_Sheet1.Columns.Get(1).CellType = numberCellType1;
            this.spdWorkOrder_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdWorkOrder_Sheet1.Columns.Get(1).Label = "Order Qty";
            this.spdWorkOrder_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(1).Width = 90F;
            numberCellType2.DecimalPlaces = 0;
            this.spdWorkOrder_Sheet1.Columns.Get(2).CellType = numberCellType2;
            this.spdWorkOrder_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(2).Label = "Mat ID";
            this.spdWorkOrder_Sheet1.Columns.Get(2).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(2).Width = 80F;
            this.spdWorkOrder_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdWorkOrder_Sheet1.Columns.Get(3).Label = "Line";
            this.spdWorkOrder_Sheet1.Columns.Get(3).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(3).Width = 80F;
            this.spdWorkOrder_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdWorkOrder_Sheet1.Columns.Get(4).Label = "Oper";
            this.spdWorkOrder_Sheet1.Columns.Get(4).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(4).Width = 80F;
            this.spdWorkOrder_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdWorkOrder_Sheet1.Columns.Get(5).Label = "Resource";
            this.spdWorkOrder_Sheet1.Columns.Get(5).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(5).Width = 100F;
            this.spdWorkOrder_Sheet1.Columns.Get(6).CellType = numberCellType3;
            this.spdWorkOrder_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdWorkOrder_Sheet1.Columns.Get(6).Label = "Box Qty";
            this.spdWorkOrder_Sheet1.Columns.Get(6).Locked = true;
            this.spdWorkOrder_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdWorkOrder_Sheet1.Columns.Get(6).Width = 120F;
            this.spdWorkOrder_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdWorkOrder_Sheet1.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdWorkOrder_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdWorkOrder_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdWorkOrder_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdWorkOrder_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdWorkOrder_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdWorkOrder_Sheet1.PrintInfo.ShowColor = true;
            this.spdWorkOrder_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdWorkOrder_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdWorkOrder_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdWorkOrder_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdWorkOrder_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.spdWorkOrder_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdWorkOrder_Sheet1.Rows.Default.Height = 50F;
            this.spdWorkOrder_Sheet1.Rows.Default.Resizable = true;
            this.spdWorkOrder_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;
            this.spdWorkOrder_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdWorkOrder_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdWorkOrder_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdWorkOrder_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdWorkOrder_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdWorkOrder_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdWorkOrder_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdWorkOrder_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdWorkOrder_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdWorkOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // soiGroupBox2
            // 
            this.soiGroupBox2._UseOITheme = true;
            this.soiGroupBox2._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox2.Appearance = appearance5;
            this.soiGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox2.ContentAreaAppearance = appearance6;
            this.soiGroupBox2.Controls.Add(this.spdDateList);
            this.soiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.SizeInPoints = 14F;
            appearance4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance4.TextHAlignAsString = "Right";
            this.soiGroupBox2.HeaderAppearance = appearance4;
            this.soiGroupBox2.Location = new System.Drawing.Point(0, 134);
            this.soiGroupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox2.Name = "soiGroupBox2";
            this.soiGroupBox2.Size = new System.Drawing.Size(786, 315);
            this.soiGroupBox2.TabIndex = 3;
            this.soiGroupBox2.Text = "Manufacturing Date/Shelf Life Information";
            this.soiGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // spdDateList
            // 
            this.spdDateList._UseAutoHeight = false;
            this.spdDateList._UseOITheme = true;
            this.spdDateList.AccessibleDescription = "spdWorkOrder, Sheet1, Row 0, Column 0, ";
            this.spdDateList.AllowUserZoom = false;
            this.spdDateList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDateList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdDateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDateList.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.spdDateList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDateList.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer3.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer3.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer3.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer3.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer3.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer3.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer3.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer3.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer3.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer3.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer3.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdDateList.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer3;
            this.spdDateList.HorizontalScrollBar.TabIndex = 140;
            this.spdDateList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdDateList.Location = new System.Drawing.Point(1, 32);
            this.spdDateList.Margin = new System.Windows.Forms.Padding(0);
            this.spdDateList.Name = "spdDateList";
            this.spdDateList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdDateList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdDateList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDateList_Sheet1});
            this.spdDateList.Size = new System.Drawing.Size(784, 282);
            this.spdDateList.SOICellHeight = 50;
            this.spdDateList.SOIColumnHeight = 30;
            this.spdDateList.TabIndex = 8;
            this.spdDateList.TabStop = false;
            this.spdDateList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDateList.UseEnterKeyForMove = true;
            this.spdDateList.UseKeyPad = true;
            this.spdDateList.UseSOIContextMenu = true;
            this.spdDateList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDateList.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer4.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer4.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer4.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer4.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer4.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer4.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer4.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer4.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer4.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer4.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer4.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdDateList.VerticalScrollBar.Renderer = enhancedScrollBarRenderer4;
            this.spdDateList.VerticalScrollBar.TabIndex = 141;
            this.spdDateList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdDateList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdDateList_Sheet1
            // 
            this.spdDateList_Sheet1.Reset();
            spdDateList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDateList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDateList_Sheet1.ColumnCount = 6;
            spdDateList_Sheet1.RowCount = 3;
            spdDateList_Sheet1.RowHeader.ColumnCount = 0;
            this.spdDateList_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdDateList_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdDateList_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdDateList_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdDateList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDateList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDateList_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdDateList_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdDateList_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdDateList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDateList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdDateList_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Select";
            this.spdDateList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Order Id";
            this.spdDateList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Order Date";
            this.spdDateList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat ID";
            this.spdDateList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Manufacturing Date";
            this.spdDateList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Shelf Life";
            this.spdDateList_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdDateList_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdDateList_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdDateList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDateList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDateList_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDateList_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.ColumnHeader.Rows.Get(0).Height = 44F;
            this.spdDateList_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDateList_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdDateList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(0).Label = "Select";
            this.spdDateList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.spdDateList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(1).Label = "Order Id";
            this.spdDateList_Sheet1.Columns.Get(1).Locked = true;
            this.spdDateList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(1).Width = 120F;
            this.spdDateList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(2).Label = "Order Date";
            this.spdDateList_Sheet1.Columns.Get(2).Locked = true;
            this.spdDateList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(2).Width = 120F;
            numberCellType4.DecimalPlaces = 0;
            this.spdDateList_Sheet1.Columns.Get(3).CellType = numberCellType4;
            this.spdDateList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(3).Label = "Mat ID";
            this.spdDateList_Sheet1.Columns.Get(3).Locked = true;
            this.spdDateList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(3).Width = 80F;
            this.spdDateList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDateList_Sheet1.Columns.Get(4).Label = "Manufacturing Date";
            this.spdDateList_Sheet1.Columns.Get(4).Locked = true;
            this.spdDateList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(4).Width = 150F;
            this.spdDateList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDateList_Sheet1.Columns.Get(5).Label = "Shelf Life";
            this.spdDateList_Sheet1.Columns.Get(5).Locked = true;
            this.spdDateList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDateList_Sheet1.Columns.Get(5).Width = 120F;
            this.spdDateList_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDateList_Sheet1.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdDateList_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdDateList_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDateList_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdDateList_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDateList_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDateList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdDateList_Sheet1.PrintInfo.ShowColor = true;
            this.spdDateList_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdDateList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdDateList_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdDateList_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdDateList_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdDateList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDateList_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDateList_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDateList_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.spdDateList_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDateList_Sheet1.Rows.Default.Height = 50F;
            this.spdDateList_Sheet1.Rows.Default.Resizable = true;
            this.spdDateList_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;
            this.spdDateList_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDateList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdDateList_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdDateList_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdDateList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDateList_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdDateList_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDateList_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDateList_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDateList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnSelect
            // 
            this.btnSelect._UseOITheme = true;
            this.btnSelect._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance7.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance7.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance7.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance7.FontData.BoldAsString = "True";
            appearance7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance7.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnSelect.Appearance = appearance7;
            this.btnSelect.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance8.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnSelect.HotTrackAppearance = appearance8;
            this.btnSelect.Location = new System.Drawing.Point(428, 0);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelect.Name = "btnSelect";
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance9.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnSelect.PressedAppearance = appearance9;
            this.btnSelect.ShowFocusRect = false;
            this.btnSelect.ShowOutline = false;
            this.btnSelect.Size = new System.Drawing.Size(110, 75);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnSelect.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSelect.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnView
            // 
            this.btnView._UseOITheme = true;
            this.btnView._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this.btnView.Appearance = appearance39;
            this.btnView.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance40.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance40.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance40.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnView.HotTrackAppearance = appearance40;
            this.btnView.Location = new System.Drawing.Point(552, 0);
            this.btnView.Margin = new System.Windows.Forms.Padding(0);
            this.btnView.Name = "btnView";
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance41.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance41.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance41.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnView.PressedAppearance = appearance41;
            this.btnView.ShowFocusRect = false;
            this.btnView.ShowOutline = false;
            this.btnView.Size = new System.Drawing.Size(110, 75);
            this.btnView.TabIndex = 11;
            this.btnView.Text = "View";
            this.btnView.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnView.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnView.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // frmWIPSelectDatePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "frmWIPSelectDatePopup";
            this.Text = "frmWIPSelectDatePopup";
            this.Load += new System.EventHandler(this.frmTempBOIPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            this.soiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).EndInit();
            this.soiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdWorkOrder_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox2)).EndInit();
            this.soiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDateList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDateList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel1;
        private SOI.OIFrx.SOIControls.SOIGroupBox soiGroupBox1;
        private SOI.OIFrx.SOIControls.SOIGroupBox soiGroupBox2;
        private OIFrx.BOIControls.BOISpread spdWorkOrder;
        private FarPoint.Win.Spread.SheetView spdWorkOrder_Sheet1;
        private OIFrx.BOIControls.BOISpread spdDateList;
        private FarPoint.Win.Spread.SheetView spdDateList_Sheet1;
        private SOI.OIFrx.SOIControls.SOIButton btnView;
        private SOI.OIFrx.SOIControls.SOIButton btnSelect;
    }
}