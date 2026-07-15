
namespace Miracom.WIPCore
{
	partial class frmWIPViewQAHistoryByLot : Miracom.MESCore.ViewForm01
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer7 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle13 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle14 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle15 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer4 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle16 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType4 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer8 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.tabDefect = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.spdDefect = new FarPoint.Win.Spread.FpSpread();
            this.spdDefect_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.spdSltDefect = new FarPoint.Win.Spread.FpSpread();
            this.spdSltDefect_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.tabDefect.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect_Sheet1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdSltDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSltDefect_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 68);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Controls.Add(this.chkIncludeDelHistory);
            this.grpOption.Size = new System.Drawing.Size(742, 68);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.panel2);
            this.pnlViewMid.Controls.Add(this.panel1);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 68);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 460);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 528);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 528);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Sub Lot History";
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(120, 43);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(162, 14);
            this.chkIncludeDelHistory.TabIndex = 6;
            this.chkIncludeDelHistory.Text = "Include Delete History";
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            // 
            // lblLotID
            // 
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(100, 14);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(475, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 25;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 27;
            // 
            // lblPeriod
            // 
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(50, 14);
            this.lblPeriod.TabIndex = 26;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(167, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 29;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 28;
            this.lblTo.Text = "~";
            // 
            // tabDefect
            // 
            this.tabDefect.Controls.Add(this.tabPage1);
            this.tabDefect.Controls.Add(this.tabPage2);
            this.tabDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDefect.Location = new System.Drawing.Point(0, 0);
            this.tabDefect.Name = "tabDefect";
            this.tabDefect.SelectedIndex = 0;
            this.tabDefect.Size = new System.Drawing.Size(742, 253);
            this.tabDefect.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.spdDefect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(734, 227);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lot Defect";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // spdDefect
            // 
            this.spdDefect.AccessibleDescription = "spdDefect, Sheet1, Row 0, Column 0, ";
            this.spdDefect.BackColor = System.Drawing.SystemColors.Control;
            this.spdDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDefect.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdDefect.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefect.HorizontalScrollBar.Name = "";
            this.spdDefect.HorizontalScrollBar.Renderer = defaultScrollBarRenderer7;
            this.spdDefect.HorizontalScrollBar.TabIndex = 20;
            this.spdDefect.Location = new System.Drawing.Point(3, 3);
            this.spdDefect.Name = "spdDefect";
            namedStyle13.BackColor = System.Drawing.SystemColors.Control;
            namedStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle13.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle13.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle13.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle14.BackColor = System.Drawing.SystemColors.Control;
            namedStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle14.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle14.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle14.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle15.BackColor = System.Drawing.SystemColors.Control;
            namedStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle15.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle15.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle15.Renderer = cornerRenderer4;
            namedStyle15.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle16.BackColor = System.Drawing.SystemColors.Window;
            namedStyle16.CellType = generalCellType4;
            namedStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle16.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle16.Renderer = generalCellType4;
            this.spdDefect.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle13,
            namedStyle14,
            namedStyle15,
            namedStyle16});
            this.spdDefect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdDefect.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdDefect.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdDefect.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDefect_Sheet1});
            this.spdDefect.Size = new System.Drawing.Size(728, 221);
            this.spdDefect.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdDefect.TabIndex = 4;
            this.spdDefect.TabStop = false;
            this.spdDefect.TextTipDelay = 200;
            this.spdDefect.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDefect.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefect.VerticalScrollBar.Name = "";
            this.spdDefect.VerticalScrollBar.Renderer = defaultScrollBarRenderer8;
            this.spdDefect.VerticalScrollBar.TabIndex = 21;
            this.spdDefect.SetViewportLeftColumn(0, 0, 3);
            this.spdDefect.SetActiveViewport(0, 0, -1);
            // 
            // spdDefect_Sheet1
            // 
            this.spdDefect_Sheet1.Reset();
            spdDefect_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDefect_Sheet1.ColumnCount = 35;
            spdDefect_Sheet1.RowCount = 5;
            spdDefect_Sheet1.RowHeader.ColumnCount = 0;
            this.spdDefect_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdDefect_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefect_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefect_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefect_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot_ID";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Hist_Seq";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "QA_Hist_Seq";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Trans_Time";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Factory";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Mat_ID";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Mat_Ver";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Flow";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Flow_Seq";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "QA_Oper";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Resource";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Carrier";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Qty1";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Qty2";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Qty3";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Defect_Seq";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Defect_Qty_Flag";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Defect_Code";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Defect_Qty";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Yield";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Hist_Del_Flag";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Hist_Del_Time";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Hist_Del_User";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Hist_Del_Comment";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Resv_Field1";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Resv_Field2";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Resv_Field3";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Resv_Field4";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Resv_Field5";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Resv_Field6";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Resv_Field7";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Resv_Field8";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Resv_Field9";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Resv_Field10";
            this.spdDefect_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefect_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefect_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdDefect_Sheet1.Columns.Get(0).Border = bevelBorder4;
            this.spdDefect_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefect_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdDefect_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdDefect_Sheet1.Columns.Get(0).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(0).Width = 44F;
            this.spdDefect_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(1).Label = "Lot_ID";
            this.spdDefect_Sheet1.Columns.Get(1).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(1).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(2).Label = "Hist_Seq";
            this.spdDefect_Sheet1.Columns.Get(2).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(2).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(3).Label = "QA_Hist_Seq";
            this.spdDefect_Sheet1.Columns.Get(3).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(3).Width = 76F;
            this.spdDefect_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(4).Label = "Trans_Time";
            this.spdDefect_Sheet1.Columns.Get(4).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(4).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(5).Label = "Factory";
            this.spdDefect_Sheet1.Columns.Get(5).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(6).Label = "Mat_ID";
            this.spdDefect_Sheet1.Columns.Get(6).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(6).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(7).Label = "Mat_Ver";
            this.spdDefect_Sheet1.Columns.Get(7).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(8).Label = "Flow";
            this.spdDefect_Sheet1.Columns.Get(8).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(8).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(9).Label = "Flow_Seq";
            this.spdDefect_Sheet1.Columns.Get(9).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(9).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(10).Label = "QA_Oper";
            this.spdDefect_Sheet1.Columns.Get(10).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(10).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(11).Label = "Resource";
            this.spdDefect_Sheet1.Columns.Get(11).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(11).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(12).Label = "Carrier";
            this.spdDefect_Sheet1.Columns.Get(12).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(13).Label = "Qty1";
            this.spdDefect_Sheet1.Columns.Get(13).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(14).Label = "Qty2";
            this.spdDefect_Sheet1.Columns.Get(14).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(15).Label = "Qty3";
            this.spdDefect_Sheet1.Columns.Get(15).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(16).Label = "Defect_Seq";
            this.spdDefect_Sheet1.Columns.Get(16).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(17).Label = "Defect_Qty_Flag";
            this.spdDefect_Sheet1.Columns.Get(17).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(18).Label = "Defect_Code";
            this.spdDefect_Sheet1.Columns.Get(18).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(19).Label = "Defect_Qty";
            this.spdDefect_Sheet1.Columns.Get(19).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(20).Label = "Yield";
            this.spdDefect_Sheet1.Columns.Get(20).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(21).Label = "Hist_Del_Flag";
            this.spdDefect_Sheet1.Columns.Get(21).Width = 80F;
            this.spdDefect_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(22).Label = "Hist_Del_Time";
            this.spdDefect_Sheet1.Columns.Get(22).Width = 80F;
            this.spdDefect_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(23).Label = "Hist_Del_User";
            this.spdDefect_Sheet1.Columns.Get(23).Width = 80F;
            this.spdDefect_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(24).Label = "Hist_Del_Comment";
            this.spdDefect_Sheet1.Columns.Get(24).Width = 103F;
            this.spdDefect_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(25).Label = "Resv_Field1";
            this.spdDefect_Sheet1.Columns.Get(25).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(26).Label = "Resv_Field2";
            this.spdDefect_Sheet1.Columns.Get(26).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(27).Label = "Resv_Field3";
            this.spdDefect_Sheet1.Columns.Get(27).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(28).Label = "Resv_Field4";
            this.spdDefect_Sheet1.Columns.Get(28).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(29).Label = "Resv_Field5";
            this.spdDefect_Sheet1.Columns.Get(29).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(30).Label = "Resv_Field6";
            this.spdDefect_Sheet1.Columns.Get(30).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(31).Label = "Resv_Field7";
            this.spdDefect_Sheet1.Columns.Get(31).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(32).Label = "Resv_Field8";
            this.spdDefect_Sheet1.Columns.Get(32).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(33).Label = "Resv_Field9";
            this.spdDefect_Sheet1.Columns.Get(33).Width = 70F;
            this.spdDefect_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(34).Label = "Resv_Field10";
            this.spdDefect_Sheet1.Columns.Get(34).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(34).Width = 72F;
            this.spdDefect_Sheet1.FrozenColumnCount = 3;
            this.spdDefect_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDefect_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdDefect_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdDefect_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdDefect_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefect_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDefect_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdDefect_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdDefect_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefect_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.spdSltDefect);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(734, 227);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sub Lot Defect";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // spdSltDefect
            // 
            this.spdSltDefect.AccessibleDescription = "spdSltDefect, Sheet1, Row 0, Column 0, ";
            this.spdSltDefect.BackColor = System.Drawing.SystemColors.Control;
            this.spdSltDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSltDefect.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdSltDefect.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSltDefect.HorizontalScrollBar.Name = "";
            this.spdSltDefect.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdSltDefect.HorizontalScrollBar.TabIndex = 16;
            this.spdSltDefect.Location = new System.Drawing.Point(3, 3);
            this.spdSltDefect.Name = "spdSltDefect";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = generalCellType1;
            this.spdSltDefect.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdSltDefect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdSltDefect.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdSltDefect.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdSltDefect.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSltDefect_Sheet1});
            this.spdSltDefect.Size = new System.Drawing.Size(728, 221);
            this.spdSltDefect.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSltDefect.TabIndex = 5;
            this.spdSltDefect.TabStop = false;
            this.spdSltDefect.TextTipDelay = 200;
            this.spdSltDefect.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdSltDefect.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSltDefect.VerticalScrollBar.Name = "";
            this.spdSltDefect.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdSltDefect.VerticalScrollBar.TabIndex = 17;
            this.spdSltDefect.SetViewportLeftColumn(0, 0, 3);
            this.spdSltDefect.SetActiveViewport(0, 0, -1);
            // 
            // spdSltDefect_Sheet1
            // 
            this.spdSltDefect_Sheet1.Reset();
            spdSltDefect_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSltDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSltDefect_Sheet1.ColumnCount = 43;
            spdSltDefect_Sheet1.RowCount = 5;
            spdSltDefect_Sheet1.RowHeader.ColumnCount = 0;
            this.spdSltDefect_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdSltDefect_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSltDefect_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSltDefect_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSltDefect_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Hist Seq";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Sub Lot ID";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Sub Lot Hist Seq";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Slot No";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "QA Hist Seq";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Tran Time";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Factory";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Mat ID";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Mat Ver";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Flow";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Flow Seq Num";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Operation";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "QA Operation";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Resource";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Carrier";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Qty2";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Qty3";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Defect Qty Flag";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Defect Code";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Defect Qty";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Yield";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Loc_X";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Loc_Y";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Loc_Z";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Cell_X";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Cell_Y";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Cell_Z";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Hist Del Flag";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Hist Del Time";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Hist Del User";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Hist Del Comment";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Resv Field1";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Resv Field2";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Resv Field3";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Resv Field4";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Resv Field5";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Resv Field6";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Resv Field7";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Resv Field8";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Resv Field9";
            this.spdSltDefect_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Resv Field10";
            this.spdSltDefect_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSltDefect_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSltDefect_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdSltDefect_Sheet1.Columns.Get(0).Border = bevelBorder5;
            this.spdSltDefect_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdSltDefect_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdSltDefect_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdSltDefect_Sheet1.Columns.Get(0).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(0).Width = 44F;
            this.spdSltDefect_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(1).Label = "Lot ID";
            this.spdSltDefect_Sheet1.Columns.Get(1).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(1).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(2).Label = "Hist Seq";
            this.spdSltDefect_Sheet1.Columns.Get(2).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(2).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(3).Label = "Sub Lot ID";
            this.spdSltDefect_Sheet1.Columns.Get(3).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(3).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(4).Label = "Sub Lot Hist Seq";
            this.spdSltDefect_Sheet1.Columns.Get(4).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(4).Width = 100F;
            this.spdSltDefect_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(5).Label = "Slot No";
            this.spdSltDefect_Sheet1.Columns.Get(5).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(5).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(6).Label = "QA Hist Seq";
            this.spdSltDefect_Sheet1.Columns.Get(6).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(6).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(7).Label = "Tran Time";
            this.spdSltDefect_Sheet1.Columns.Get(7).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(7).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(8).Label = "Factory";
            this.spdSltDefect_Sheet1.Columns.Get(8).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(8).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(9).Label = "Mat ID";
            this.spdSltDefect_Sheet1.Columns.Get(9).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(9).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(10).Label = "Mat Ver";
            this.spdSltDefect_Sheet1.Columns.Get(10).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(11).Label = "Flow";
            this.spdSltDefect_Sheet1.Columns.Get(11).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(12).Label = "Flow Seq Num";
            this.spdSltDefect_Sheet1.Columns.Get(12).Width = 86F;
            this.spdSltDefect_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(13).Label = "Operation";
            this.spdSltDefect_Sheet1.Columns.Get(13).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(14).Label = "QA Operation";
            this.spdSltDefect_Sheet1.Columns.Get(14).Width = 75F;
            this.spdSltDefect_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(15).Label = "Resource";
            this.spdSltDefect_Sheet1.Columns.Get(15).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(16).Label = "Carrier";
            this.spdSltDefect_Sheet1.Columns.Get(16).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(17).Label = "Qty2";
            this.spdSltDefect_Sheet1.Columns.Get(17).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(18).Label = "Qty3";
            this.spdSltDefect_Sheet1.Columns.Get(18).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(19).Label = "Defect Qty Flag";
            this.spdSltDefect_Sheet1.Columns.Get(19).Width = 88F;
            this.spdSltDefect_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(20).Label = "Defect Code";
            this.spdSltDefect_Sheet1.Columns.Get(20).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(21).Label = "Defect Qty";
            this.spdSltDefect_Sheet1.Columns.Get(21).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(22).Label = "Yield";
            this.spdSltDefect_Sheet1.Columns.Get(22).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(23).Label = "Loc_X";
            this.spdSltDefect_Sheet1.Columns.Get(23).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(24).Label = "Loc_Y";
            this.spdSltDefect_Sheet1.Columns.Get(24).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(25).Label = "Loc_Z";
            this.spdSltDefect_Sheet1.Columns.Get(25).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(26).Label = "Cell_X";
            this.spdSltDefect_Sheet1.Columns.Get(26).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(27).Label = "Cell_Y";
            this.spdSltDefect_Sheet1.Columns.Get(27).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(28).Label = "Cell_Z";
            this.spdSltDefect_Sheet1.Columns.Get(28).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(29).Label = "Hist Del Flag";
            this.spdSltDefect_Sheet1.Columns.Get(29).Width = 80F;
            this.spdSltDefect_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(30).Label = "Hist Del Time";
            this.spdSltDefect_Sheet1.Columns.Get(30).Width = 80F;
            this.spdSltDefect_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(31).Label = "Hist Del User";
            this.spdSltDefect_Sheet1.Columns.Get(31).Width = 80F;
            this.spdSltDefect_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(32).Label = "Hist Del Comment";
            this.spdSltDefect_Sheet1.Columns.Get(32).Width = 97F;
            this.spdSltDefect_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(33).Label = "Resv Field1";
            this.spdSltDefect_Sheet1.Columns.Get(33).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(34).Label = "Resv Field2";
            this.spdSltDefect_Sheet1.Columns.Get(34).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(35).Label = "Resv Field3";
            this.spdSltDefect_Sheet1.Columns.Get(35).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(36).Label = "Resv Field4";
            this.spdSltDefect_Sheet1.Columns.Get(36).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(37).Label = "Resv Field5";
            this.spdSltDefect_Sheet1.Columns.Get(37).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(38).Label = "Resv Field6";
            this.spdSltDefect_Sheet1.Columns.Get(38).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(39).Label = "Resv Field7";
            this.spdSltDefect_Sheet1.Columns.Get(39).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(40).Label = "Resv Field8";
            this.spdSltDefect_Sheet1.Columns.Get(40).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(41).Label = "Resv Field9";
            this.spdSltDefect_Sheet1.Columns.Get(41).Width = 71F;
            this.spdSltDefect_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(42).Label = "Resv Field10";
            this.spdSltDefect_Sheet1.Columns.Get(42).Locked = true;
            this.spdSltDefect_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSltDefect_Sheet1.Columns.Get(42).Width = 78F;
            this.spdSltDefect_Sheet1.FrozenColumnCount = 3;
            this.spdSltDefect_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdSltDefect_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdSltDefect_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdSltDefect_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSltDefect_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSltDefect_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSltDefect_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdSltDefect_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdSltDefect_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSltDefect_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSltDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdHistory.HorizontalScrollBar.TabIndex = 26;
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle7.BackColor = System.Drawing.SystemColors.Control;
            namedStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle7.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle7.Renderer = cornerRenderer2;
            namedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle8.BackColor = System.Drawing.SystemColors.Window;
            namedStyle8.CellType = generalCellType2;
            namedStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle8.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle8.Renderer = generalCellType2;
            this.spdHistory.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(742, 204);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 6;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdHistory.VerticalScrollBar.TabIndex = 27;
            this.spdHistory.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdHistory_CellClick);
            this.spdHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdHistory.SetActiveViewport(0, 0, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 56;
            spdHistory_Sheet1.RowCount = 5;
            spdHistory_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot_ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Hist_Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "QA_Hist_Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Trans_Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Mat_ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Mat_Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Flow_Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "QA_Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "RES_ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Carrier_ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Qty1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Qty2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Qty3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Sample_Rule";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Action_Rule";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Pass_Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Sample_Size1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Sample_Size2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Defect_Qty1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Defect_Qty2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Yield1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Yield2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Test_Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Inspector";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Shift";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "IRR_MRR";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Alarm_Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Hist_Del_Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Hist_Del_Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Hist_Del_User";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Hist_Del_Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Cmf1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Cmf2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Cmf3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Cmf4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Cmf5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Cmf6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Cmf7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Cmf8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Cmf9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Cmf10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Resv_Field1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Resv_Field2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Resv_Field3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Resv_Field4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Resv_Field5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Resv_Field6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Resv_Field7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Resv_Field8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Resv_Field9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Resv_Field10";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder6;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 44F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Lot_ID";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Hist_Seq";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "QA_Hist_Seq";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 77F;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Trans_Time";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Factory";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Mat_ID";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Mat_Ver";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Flow";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Flow_Seq";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Oper";
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "QA_Oper";
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "RES_ID";
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Carrier_ID";
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Qty1";
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Qty2";
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Qty3";
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Sample_Rule";
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Action_Rule";
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Pass_Flag";
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Sample_Size1";
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 78F;
            this.spdHistory_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Sample_Size2";
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 76F;
            this.spdHistory_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Defect_Qty1";
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Defect_Qty2";
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Yield1";
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Yield2";
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Test_Type";
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Inspector";
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Shift";
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "IRR_MRR";
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Comment";
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Alarm_Code";
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Hist_Del_Flag";
            this.spdHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Hist_Del_Time";
            this.spdHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Hist_Del_User";
            this.spdHistory_Sheet1.Columns.Get(34).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Hist_Del_Comment";
            this.spdHistory_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Width = 102F;
            this.spdHistory_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Cmf1";
            this.spdHistory_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "Cmf2";
            this.spdHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Cmf3";
            this.spdHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Cmf4";
            this.spdHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Cmf5";
            this.spdHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Cmf6";
            this.spdHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "Cmf7";
            this.spdHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(43).Label = "Cmf8";
            this.spdHistory_Sheet1.Columns.Get(43).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(44).Label = "Cmf9";
            this.spdHistory_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(44).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(45).Label = "Cmf10";
            this.spdHistory_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(45).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(46).Label = "Resv_Field1";
            this.spdHistory_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(46).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(47).Label = "Resv_Field2";
            this.spdHistory_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(47).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(48).Label = "Resv_Field3";
            this.spdHistory_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(48).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(49).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(49).Label = "Resv_Field4";
            this.spdHistory_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(49).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(50).Label = "Resv_Field5";
            this.spdHistory_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(50).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(51).Label = "Resv_Field6";
            this.spdHistory_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(51).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(52).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(52).Label = "Resv_Field7";
            this.spdHistory_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(52).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(53).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(53).Label = "Resv_Field8";
            this.spdHistory_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(53).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(54).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(54).Label = "Resv_Field9";
            this.spdHistory_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(54).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(55).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(55).Label = "Resv_Field10";
            this.spdHistory_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(55).Width = 72F;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.spdHistory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 204);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabDefect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 253);
            this.panel2.TabIndex = 8;
            // 
            // frmWIPViewQAHistoryByLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 568);
            this.Name = "frmWIPViewQAHistoryByLot";
            this.Text = "View QA History By Lot";
            this.Activated += new System.EventHandler(this.frmFPDViewQAHistoryByLot_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.tabDefect.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect_Sheet1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdSltDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSltDefect_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        #endregion

        private System.Windows.Forms.CheckBox chkIncludeDelHistory;
		private System.Windows.Forms.Panel pnlPeriod;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.Label lblPeriod;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.Label lblTo;
		private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TabControl tabDefect;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FarPoint.Win.Spread.FpSpread spdDefect;
        private FarPoint.Win.Spread.SheetView spdDefect_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdSltDefect;
        private FarPoint.Win.Spread.SheetView spdSltDefect_Sheet1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
	}
}