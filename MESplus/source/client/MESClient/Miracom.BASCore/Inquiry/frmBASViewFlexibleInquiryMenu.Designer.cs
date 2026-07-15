namespace Miracom.BASCore
{
    partial class frmBASViewFlexibleInquiryMenu
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle9 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle10 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle11 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer3 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle12 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType3 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.spdInquiryCondition2 = new FarPoint.Win.Spread.FpSpread();
            this.spdInquiryCondition2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdInquiryCondition1 = new FarPoint.Win.Spread.FpSpread();
            this.spdInquiryCondition1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdInqQueryResult = new FarPoint.Win.Spread.FpSpread();
            this.spdInqQueryResult_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.sfdExcel = new System.Windows.Forms.SaveFileDialog();
            this.pnlLoopCount = new System.Windows.Forms.Panel();
            this.numLoopCount = new System.Windows.Forms.NumericUpDown();
            this.lblLoopCount = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInquiryCondition2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInquiryCondition2_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInquiryCondition1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInquiryCondition1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInqQueryResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInqQueryResult_Sheet1)).BeginInit();
            this.pnlLoopCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoopCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(637, 7);
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(821, 135);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.spdInquiryCondition2);
            this.grpOption.Controls.Add(this.spdInquiryCondition1);
            this.grpOption.Size = new System.Drawing.Size(821, 135);
            this.grpOption.Text = "Inquiry Condition";
            this.grpOption.Resize += new System.EventHandler(this.grpOption_Resize);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdInqQueryResult);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 135);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(821, 394);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(728, 7);
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlLoopCount);
            this.pnlBottom.Location = new System.Drawing.Point(0, 529);
            this.pnlBottom.Size = new System.Drawing.Size(821, 40);
            this.pnlBottom.DoubleClick += new System.EventHandler(this.pnlBottom_DoubleClick);
            this.pnlBottom.Controls.SetChildIndex(this.pnlLoopCount, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(821, 529);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvTableList.Location = new System.Drawing.Point(180, 17);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "cdvTableList";
            this.cdvTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 0;
            this.cdvTableList.TabStop = false;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.Visible = false;
            this.cdvTableList.VisibleColumnHeader = false;
            this.cdvTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableList_SelectedItemChanged);
            // 
            // spdInquiryCondition2
            // 
            this.spdInquiryCondition2.AccessibleDescription = "spdInquiryCondition2, Sheet1, Row 0, Column 0, ";
            this.spdInquiryCondition2.BackColor = System.Drawing.SystemColors.Control;
            this.spdInquiryCondition2.Dock = System.Windows.Forms.DockStyle.Right;
            this.spdInquiryCondition2.EditModeReplace = true;
            this.spdInquiryCondition2.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdInquiryCondition2.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInquiryCondition2.HorizontalScrollBar.Name = "";
            this.spdInquiryCondition2.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdInquiryCondition2.HorizontalScrollBar.TabIndex = 34;
            this.spdInquiryCondition2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdInquiryCondition2.Location = new System.Drawing.Point(426, 16);
            this.spdInquiryCondition2.Name = "spdInquiryCondition2";
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
            this.spdInquiryCondition2.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdInquiryCondition2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdInquiryCondition2.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdInquiryCondition2.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdInquiryCondition2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdInquiryCondition2_Sheet1});
            this.spdInquiryCondition2.Size = new System.Drawing.Size(392, 116);
            this.spdInquiryCondition2.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdInquiryCondition2.TabIndex = 1;
            this.spdInquiryCondition2.TextTipDelay = 200;
            this.spdInquiryCondition2.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdInquiryCondition2.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInquiryCondition2.VerticalScrollBar.Name = "";
            this.spdInquiryCondition2.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdInquiryCondition2.VerticalScrollBar.TabIndex = 35;
            this.spdInquiryCondition2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdInquiryCondition2.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdInquiryCondition2_ButtonClicked);
            this.spdInquiryCondition2.SetActiveViewport(0, -1, -1);
            // 
            // spdInquiryCondition2_Sheet1
            // 
            this.spdInquiryCondition2_Sheet1.Reset();
            spdInquiryCondition2_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdInquiryCondition2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdInquiryCondition2_Sheet1.ColumnCount = 8;
            spdInquiryCondition2_Sheet1.RowCount = 0;
            this.spdInquiryCondition2_Sheet1.ActiveColumnIndex = -1;
            this.spdInquiryCondition2_Sheet1.ActiveRowIndex = -1;
            this.spdInquiryCondition2_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition2_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdInquiryCondition2_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition2_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdInquiryCondition2_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdInquiryCondition2_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdInquiryCondition2_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Value";
            this.spdInquiryCondition2_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "ValueType";
            this.spdInquiryCondition2_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "displayType";
            this.spdInquiryCondition2_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Tool Event";
            this.spdInquiryCondition2_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Saved";
            this.spdInquiryCondition2_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Input Value Type";
            this.spdInquiryCondition2_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition2_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdInquiryCondition2_Sheet1.ColumnHeader.Visible = false;
            this.spdInquiryCondition2_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdInquiryCondition2_Sheet1.Columns.Get(0).Locked = true;
            this.spdInquiryCondition2_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInquiryCondition2_Sheet1.Columns.Get(0).Width = 143F;
            this.spdInquiryCondition2_Sheet1.Columns.Get(1).Label = "Value";
            this.spdInquiryCondition2_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInquiryCondition2_Sheet1.Columns.Get(1).Width = 150F;
            this.spdInquiryCondition2_Sheet1.Columns.Get(2).Width = 25F;
            this.spdInquiryCondition2_Sheet1.Columns.Get(3).Label = "ValueType";
            this.spdInquiryCondition2_Sheet1.Columns.Get(3).Visible = false;
            this.spdInquiryCondition2_Sheet1.Columns.Get(4).Label = "displayType";
            this.spdInquiryCondition2_Sheet1.Columns.Get(4).Visible = false;
            this.spdInquiryCondition2_Sheet1.Columns.Get(4).Width = 69F;
            this.spdInquiryCondition2_Sheet1.Columns.Get(5).Label = "Tool Event";
            this.spdInquiryCondition2_Sheet1.Columns.Get(5).Visible = false;
            this.spdInquiryCondition2_Sheet1.Columns.Get(6).Label = "Saved";
            this.spdInquiryCondition2_Sheet1.Columns.Get(6).Visible = false;
            this.spdInquiryCondition2_Sheet1.Columns.Get(7).Label = "Input Value Type";
            this.spdInquiryCondition2_Sheet1.Columns.Get(7).Visible = false;
            this.spdInquiryCondition2_Sheet1.Columns.Get(7).Width = 100F;
            this.spdInquiryCondition2_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdInquiryCondition2_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdInquiryCondition2_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition2_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdInquiryCondition2_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition2_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdInquiryCondition2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdInquiryCondition1
            // 
            this.spdInquiryCondition1.AccessibleDescription = "spdInquiryCondition1, Sheet1, Row 0, Column 0, ";
            this.spdInquiryCondition1.BackColor = System.Drawing.SystemColors.Control;
            this.spdInquiryCondition1.Dock = System.Windows.Forms.DockStyle.Left;
            this.spdInquiryCondition1.EditModeReplace = true;
            this.spdInquiryCondition1.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdInquiryCondition1.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInquiryCondition1.HorizontalScrollBar.Name = "";
            this.spdInquiryCondition1.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdInquiryCondition1.HorizontalScrollBar.TabIndex = 56;
            this.spdInquiryCondition1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdInquiryCondition1.Location = new System.Drawing.Point(3, 16);
            this.spdInquiryCondition1.Name = "spdInquiryCondition1";
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
            this.spdInquiryCondition1.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdInquiryCondition1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdInquiryCondition1.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdInquiryCondition1.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdInquiryCondition1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdInquiryCondition1_Sheet1});
            this.spdInquiryCondition1.Size = new System.Drawing.Size(358, 116);
            this.spdInquiryCondition1.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdInquiryCondition1.TabIndex = 0;
            this.spdInquiryCondition1.TextTipDelay = 200;
            this.spdInquiryCondition1.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdInquiryCondition1.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInquiryCondition1.VerticalScrollBar.Name = "";
            this.spdInquiryCondition1.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdInquiryCondition1.VerticalScrollBar.TabIndex = 57;
            this.spdInquiryCondition1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdInquiryCondition1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdInquiryCondition1_ButtonClicked);
            this.spdInquiryCondition1.SetActiveViewport(0, -1, -1);
            // 
            // spdInquiryCondition1_Sheet1
            // 
            this.spdInquiryCondition1_Sheet1.Reset();
            spdInquiryCondition1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdInquiryCondition1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdInquiryCondition1_Sheet1.ColumnCount = 8;
            spdInquiryCondition1_Sheet1.RowCount = 0;
            this.spdInquiryCondition1_Sheet1.ActiveColumnIndex = -1;
            this.spdInquiryCondition1_Sheet1.ActiveRowIndex = -1;
            this.spdInquiryCondition1_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition1_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdInquiryCondition1_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition1_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdInquiryCondition1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdInquiryCondition1_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdInquiryCondition1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Value";
            this.spdInquiryCondition1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "ValueType";
            this.spdInquiryCondition1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "displayType";
            this.spdInquiryCondition1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Tool Event";
            this.spdInquiryCondition1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Saved";
            this.spdInquiryCondition1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Input Value Type";
            this.spdInquiryCondition1_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdInquiryCondition1_Sheet1.ColumnHeader.Visible = false;
            this.spdInquiryCondition1_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdInquiryCondition1_Sheet1.Columns.Get(0).Locked = true;
            this.spdInquiryCondition1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInquiryCondition1_Sheet1.Columns.Get(0).Width = 143F;
            this.spdInquiryCondition1_Sheet1.Columns.Get(1).Label = "Value";
            this.spdInquiryCondition1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInquiryCondition1_Sheet1.Columns.Get(1).Width = 150F;
            this.spdInquiryCondition1_Sheet1.Columns.Get(2).Width = 25F;
            this.spdInquiryCondition1_Sheet1.Columns.Get(3).Label = "ValueType";
            this.spdInquiryCondition1_Sheet1.Columns.Get(3).Visible = false;
            this.spdInquiryCondition1_Sheet1.Columns.Get(3).Width = 0F;
            this.spdInquiryCondition1_Sheet1.Columns.Get(4).Label = "displayType";
            this.spdInquiryCondition1_Sheet1.Columns.Get(4).Visible = false;
            this.spdInquiryCondition1_Sheet1.Columns.Get(4).Width = 0F;
            this.spdInquiryCondition1_Sheet1.Columns.Get(5).Label = "Tool Event";
            this.spdInquiryCondition1_Sheet1.Columns.Get(5).Visible = false;
            this.spdInquiryCondition1_Sheet1.Columns.Get(5).Width = 0F;
            this.spdInquiryCondition1_Sheet1.Columns.Get(6).Label = "Saved";
            this.spdInquiryCondition1_Sheet1.Columns.Get(6).Visible = false;
            this.spdInquiryCondition1_Sheet1.Columns.Get(6).Width = 0F;
            this.spdInquiryCondition1_Sheet1.Columns.Get(7).Label = "Input Value Type";
            this.spdInquiryCondition1_Sheet1.Columns.Get(7).Visible = false;
            this.spdInquiryCondition1_Sheet1.Columns.Get(7).Width = 0F;
            this.spdInquiryCondition1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdInquiryCondition1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdInquiryCondition1_Sheet1.RowHeader.Columns.Get(0).Width = 31F;
            this.spdInquiryCondition1_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdInquiryCondition1_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInquiryCondition1_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdInquiryCondition1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdInqQueryResult
            // 
            this.spdInqQueryResult.AccessibleDescription = "spdInqQueryResult, Sheet1, Row 0, Column 0, ";
            this.spdInqQueryResult.AllowColumnMove = true;
            this.spdInqQueryResult.AllowColumnMoveMultiple = true;
            this.spdInqQueryResult.BackColor = System.Drawing.SystemColors.Control;
            this.spdInqQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdInqQueryResult.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdInqQueryResult.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInqQueryResult.HorizontalScrollBar.Name = "";
            this.spdInqQueryResult.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdInqQueryResult.HorizontalScrollBar.TabIndex = 0;
            this.spdInqQueryResult.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdInqQueryResult.Location = new System.Drawing.Point(3, 3);
            this.spdInqQueryResult.Name = "spdInqQueryResult";
            namedStyle9.BackColor = System.Drawing.SystemColors.Control;
            namedStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle9.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle9.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle9.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle10.BackColor = System.Drawing.SystemColors.Control;
            namedStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle10.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle10.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle10.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle11.BackColor = System.Drawing.SystemColors.Control;
            namedStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle11.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle11.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle11.Renderer = cornerRenderer3;
            namedStyle11.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle12.BackColor = System.Drawing.SystemColors.Window;
            namedStyle12.CellType = generalCellType3;
            namedStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle12.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle12.Renderer = generalCellType3;
            this.spdInqQueryResult.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle9,
            namedStyle10,
            namedStyle11,
            namedStyle12});
            this.spdInqQueryResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdInqQueryResult.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdInqQueryResult.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdInqQueryResult.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdInqQueryResult_Sheet1});
            this.spdInqQueryResult.Size = new System.Drawing.Size(815, 391);
            this.spdInqQueryResult.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdInqQueryResult.TabIndex = 0;
            this.spdInqQueryResult.TabStop = false;
            this.spdInqQueryResult.TextTipDelay = 200;
            this.spdInqQueryResult.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdInqQueryResult.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInqQueryResult.VerticalScrollBar.Name = "";
            this.spdInqQueryResult.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdInqQueryResult.VerticalScrollBar.TabIndex = 11;
            this.spdInqQueryResult.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdInqQueryResult.SetActiveViewport(0, -1, -1);
            // 
            // spdInqQueryResult_Sheet1
            // 
            this.spdInqQueryResult_Sheet1.Reset();
            spdInqQueryResult_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdInqQueryResult_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdInqQueryResult_Sheet1.ColumnCount = 0;
            spdInqQueryResult_Sheet1.RowCount = 0;
            this.spdInqQueryResult_Sheet1.ActiveColumnIndex = -1;
            this.spdInqQueryResult_Sheet1.ActiveRowIndex = -1;
            this.spdInqQueryResult_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInqQueryResult_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInqQueryResult_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdInqQueryResult_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInqQueryResult_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdInqQueryResult_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInqQueryResult_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdInqQueryResult_Sheet1.ColumnHeader.Rows.Get(0).Height = 21F;
            this.spdInqQueryResult_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdInqQueryResult_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdInqQueryResult_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInqQueryResult_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdInqQueryResult_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInqQueryResult_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdInqQueryResult_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // sfdExcel
            // 
            this.sfdExcel.DefaultExt = "xls";
            this.sfdExcel.Filter = "Excel files|*.xls";
            // 
            // pnlLoopCount
            // 
            this.pnlLoopCount.Controls.Add(this.numLoopCount);
            this.pnlLoopCount.Controls.Add(this.lblLoopCount);
            this.pnlLoopCount.Location = new System.Drawing.Point(42, 3);
            this.pnlLoopCount.Name = "pnlLoopCount";
            this.pnlLoopCount.Size = new System.Drawing.Size(239, 33);
            this.pnlLoopCount.TabIndex = 0;
            this.pnlLoopCount.Visible = false;
            // 
            // numLoopCount
            // 
            this.numLoopCount.Location = new System.Drawing.Point(176, 6);
            this.numLoopCount.Name = "numLoopCount";
            this.numLoopCount.Size = new System.Drawing.Size(60, 20);
            this.numLoopCount.TabIndex = 1;
            // 
            // lblLoopCount
            // 
            this.lblLoopCount.AutoSize = true;
            this.lblLoopCount.Location = new System.Drawing.Point(3, 10);
            this.lblLoopCount.Name = "lblLoopCount";
            this.lblLoopCount.Size = new System.Drawing.Size(143, 13);
            this.lblLoopCount.TabIndex = 0;
            this.lblLoopCount.Text = "Maximum Inquiry Loop Count";
            // 
            // frmBASViewFlexibleInquiryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 569);
            this.Name = "frmBASViewFlexibleInquiryMenu";
            this.Text = "Flexible Inquiry Menu";
            this.Activated += new System.EventHandler(this.frmBASViewFlexibleInquiryMenu_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInquiryCondition2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInquiryCondition2_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInquiryCondition1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInquiryCondition1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInqQueryResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInqQueryResult_Sheet1)).EndInit();
            this.pnlLoopCount.ResumeLayout(false);
            this.pnlLoopCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLoopCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
        private FarPoint.Win.Spread.FpSpread spdInquiryCondition2;
        private FarPoint.Win.Spread.SheetView spdInquiryCondition2_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdInquiryCondition1;
        private FarPoint.Win.Spread.SheetView spdInquiryCondition1_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdInqQueryResult;
        private FarPoint.Win.Spread.SheetView spdInqQueryResult_Sheet1;
        private System.Windows.Forms.SaveFileDialog sfdExcel;
        private System.Windows.Forms.Panel pnlLoopCount;
        private System.Windows.Forms.NumericUpDown numLoopCount;
        private System.Windows.Forms.Label lblLoopCount;
    }
}