namespace Miracom.RASCore
{
    partial class frmRASViewCheckResult
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASViewCheckResult));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.grpShtDatType = new System.Windows.Forms.GroupBox();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cdvGrpDataType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGrpDataType = new System.Windows.Forms.Label();
            this.lisSheetName = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpCondi = new System.Windows.Forms.GroupBox();
            this.lisSheetData = new System.Windows.Forms.ListView();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.spdSheetData = new FarPoint.Win.Spread.FpSpread();
            this.spdSheetData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.imlSPIcons = new System.Windows.Forms.ImageList(this.components);
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpShtDatType.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrpDataType)).BeginInit();
            this.grpCondi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdSheetData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSheetData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 6;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.spdSheetData);
            this.pnlRight.Controls.Add(this.grpCondi);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisSheetName);
            this.pnlLeft.Controls.Add(this.grpShtDatType);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 7);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 7);
            this.btnUpdate.Text = "View";
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExpand);
            this.pnlBottom.Controls.Add(this.btnCollapse);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCollapse, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExpand, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // grpShtDatType
            // 
            this.grpShtDatType.Controls.Add(this.pnlPeriod);
            this.grpShtDatType.Controls.Add(this.panel1);
            this.grpShtDatType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpShtDatType.Location = new System.Drawing.Point(0, 0);
            this.grpShtDatType.Name = "grpShtDatType";
            this.grpShtDatType.Size = new System.Drawing.Size(232, 94);
            this.grpShtDatType.TabIndex = 0;
            this.grpShtDatType.TabStop = false;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPeriod.Location = new System.Drawing.Point(3, 44);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(226, 47);
            this.pnlPeriod.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(9, 20);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(3, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(123, 20);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.Value = new System.DateTime(2012, 6, 7, 0, 0, 0, 0);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(105, 24);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cdvGrpDataType);
            this.panel1.Controls.Add(this.lblGrpDataType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 28);
            this.panel1.TabIndex = 0;
            // 
            // cdvGrpDataType
            // 
            this.cdvGrpDataType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrpDataType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrpDataType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrpDataType.BtnToolTipText = "";
            this.cdvGrpDataType.DescText = "";
            this.cdvGrpDataType.DisplaySubItemIndex = 0;
            this.cdvGrpDataType.DisplayText = "";
            this.cdvGrpDataType.Focusing = null;
            this.cdvGrpDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrpDataType.Index = 0;
            this.cdvGrpDataType.IsViewBtnImage = false;
            this.cdvGrpDataType.Location = new System.Drawing.Point(108, 5);
            this.cdvGrpDataType.MaxLength = 20;
            this.cdvGrpDataType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrpDataType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrpDataType.Name = "cdvGrpDataType";
            this.cdvGrpDataType.ReadOnly = false;
            this.cdvGrpDataType.SearchSubItemIndex = 0;
            this.cdvGrpDataType.SelectedDescIndex = -1;
            this.cdvGrpDataType.SelectedSubItemIndex = 0;
            this.cdvGrpDataType.SelectionStart = 0;
            this.cdvGrpDataType.Size = new System.Drawing.Size(113, 20);
            this.cdvGrpDataType.SmallImageList = null;
            this.cdvGrpDataType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrpDataType.TabIndex = 1;
            this.cdvGrpDataType.TextBoxToolTipText = "";
            this.cdvGrpDataType.TextBoxWidth = 113;
            this.cdvGrpDataType.VisibleButton = true;
            this.cdvGrpDataType.VisibleColumnHeader = false;
            this.cdvGrpDataType.VisibleDescription = false;
            this.cdvGrpDataType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGrpDataType_SelectedItemChanged);
            this.cdvGrpDataType.ButtonPress += new System.EventHandler(this.cdvGrpDataType_ButtonPress);
            // 
            // lblGrpDataType
            // 
            this.lblGrpDataType.AutoSize = true;
            this.lblGrpDataType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrpDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrpDataType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGrpDataType.Location = new System.Drawing.Point(3, 8);
            this.lblGrpDataType.Name = "lblGrpDataType";
            this.lblGrpDataType.Size = new System.Drawing.Size(106, 13);
            this.lblGrpDataType.TabIndex = 0;
            this.lblGrpDataType.Text = "Check Data Type";
            // 
            // lisSheetName
            // 
            this.lisSheetName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisSheetName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSheetName.EnableSort = true;
            this.lisSheetName.EnableSortIcon = true;
            this.lisSheetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSheetName.FullRowSelect = true;
            this.lisSheetName.HideSelection = false;
            this.lisSheetName.Location = new System.Drawing.Point(0, 94);
            this.lisSheetName.MultiSelect = false;
            this.lisSheetName.Name = "lisSheetName";
            this.lisSheetName.Size = new System.Drawing.Size(232, 419);
            this.lisSheetName.TabIndex = 1;
            this.lisSheetName.UseCompatibleStateImageBehavior = false;
            this.lisSheetName.View = System.Windows.Forms.View.Details;
            this.lisSheetName.SelectedIndexChanged += new System.EventHandler(this.lisSheetName_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Check List Name";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Data Type";
            this.ColumnHeader2.Width = 300;
            // 
            // grpCondi
            // 
            this.grpCondi.Controls.Add(this.lisSheetData);
            this.grpCondi.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCondi.Location = new System.Drawing.Point(0, 0);
            this.grpCondi.Name = "grpCondi";
            this.grpCondi.Size = new System.Drawing.Size(506, 147);
            this.grpCondi.TabIndex = 0;
            this.grpCondi.TabStop = false;
            // 
            // lisSheetData
            // 
            this.lisSheetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSheetData.Location = new System.Drawing.Point(3, 16);
            this.lisSheetData.MultiSelect = false;
            this.lisSheetData.Name = "lisSheetData";
            this.lisSheetData.Size = new System.Drawing.Size(500, 128);
            this.lisSheetData.TabIndex = 0;
            this.lisSheetData.UseCompatibleStateImageBehavior = false;
            this.lisSheetData.SelectedIndexChanged += new System.EventHandler(this.lisSheetData_SelectedIndexChanged);
            // 
            // btnExpand
            // 
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(270, 8);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 24);
            this.btnExpand.TabIndex = 5;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(238, 8);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnCollapse.TabIndex = 4;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // spdSheetData
            // 
            this.spdSheetData.AccessibleDescription = "spdSheetData, Sheet1";
            this.spdSheetData.BackColor = System.Drawing.SystemColors.Control;
            this.spdSheetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSheetData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSheetData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSheetData.HorizontalScrollBar.Name = "";
            this.spdSheetData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdSheetData.HorizontalScrollBar.TabIndex = 4;
            this.spdSheetData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdSheetData.Location = new System.Drawing.Point(0, 147);
            this.spdSheetData.Name = "spdSheetData";
            this.spdSheetData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdSheetData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdSheetData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSheetData_Sheet1});
            this.spdSheetData.Size = new System.Drawing.Size(506, 366);
            this.spdSheetData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSheetData.TabIndex = 1;
            this.spdSheetData.TabStop = false;
            this.spdSheetData.TextTipDelay = 200;
            this.spdSheetData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdSheetData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSheetData.VerticalScrollBar.Name = "";
            this.spdSheetData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdSheetData.VerticalScrollBar.TabIndex = 5;
            this.spdSheetData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdSheetData_CellClick);
            this.spdSheetData.SetViewportLeftColumn(0, 0, 3);
            this.spdSheetData.SetActiveViewport(0, -1, -1);
            // 
            // spdSheetData_Sheet1
            // 
            this.spdSheetData_Sheet1.Reset();
            spdSheetData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSheetData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSheetData_Sheet1.ColumnCount = 6;
            spdSheetData_Sheet1.RowCount = 0;
            spdSheetData_Sheet1.RowHeader.ColumnCount = 0;
            this.spdSheetData_Sheet1.ActiveColumnIndex = -1;
            this.spdSheetData_Sheet1.ActiveRowIndex = -1;
            this.spdSheetData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.White;
            this.spdSheetData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSheetData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "_";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "SEQ";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Check Data";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Result";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Comment";
            this.spdSheetData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSheetData_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdSheetData_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.Gainsboro;
            this.spdSheetData_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdSheetData_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdSheetData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSheetData_Sheet1.Columns.Get(0).Label = "_";
            this.spdSheetData_Sheet1.Columns.Get(0).Locked = true;
            this.spdSheetData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSheetData_Sheet1.Columns.Get(0).Width = 23F;
            this.spdSheetData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdSheetData_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdSheetData_Sheet1.Columns.Get(1).Locked = true;
            this.spdSheetData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSheetData_Sheet1.Columns.Get(1).Width = 114F;
            this.spdSheetData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdSheetData_Sheet1.Columns.Get(2).Label = "SEQ";
            this.spdSheetData_Sheet1.Columns.Get(2).Locked = true;
            this.spdSheetData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSheetData_Sheet1.Columns.Get(2).Width = 35F;
            this.spdSheetData_Sheet1.Columns.Get(3).CellType = textCellType1;
            this.spdSheetData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdSheetData_Sheet1.Columns.Get(3).Label = "Check Data";
            this.spdSheetData_Sheet1.Columns.Get(3).Locked = true;
            this.spdSheetData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSheetData_Sheet1.Columns.Get(3).Width = 302F;
            this.spdSheetData_Sheet1.Columns.Get(4).CellType = textCellType2;
            this.spdSheetData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSheetData_Sheet1.Columns.Get(4).Label = "Result";
            this.spdSheetData_Sheet1.Columns.Get(4).Locked = true;
            this.spdSheetData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSheetData_Sheet1.Columns.Get(5).CellType = textCellType3;
            this.spdSheetData_Sheet1.Columns.Get(5).Label = "Comment";
            this.spdSheetData_Sheet1.Columns.Get(5).Width = 232F;
            this.spdSheetData_Sheet1.FrozenColumnCount = 3;
            this.spdSheetData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdSheetData_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdSheetData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSheetData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSheetData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSheetData_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdSheetData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // imlSPIcons
            // 
            this.imlSPIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSPIcons.ImageStream")));
            this.imlSPIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSPIcons.Images.SetKeyName(0, "");
            this.imlSPIcons.Images.SetKeyName(1, "");
            this.imlSPIcons.Images.SetKeyName(2, "");
            this.imlSPIcons.Images.SetKeyName(3, "");
            // 
            // frmRASViewCheckResult
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASViewCheckResult";
            this.Text = "View Check Result";
            this.Activated += new System.EventHandler(this.frmRASViewSheetResult_Activated);
            this.Load += new System.EventHandler(this.frmRASViewSheetResult_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpShtDatType.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrpDataType)).EndInit();
            this.grpCondi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdSheetData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSheetData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpShtDatType;
        private Miracom.UI.Controls.MCListView.MCListView lisSheetName;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox grpCondi;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
        private FarPoint.Win.Spread.FpSpread spdSheetData;
        private FarPoint.Win.Spread.SheetView spdSheetData_Sheet1;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Panel panel1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrpDataType;
        private System.Windows.Forms.Label lblGrpDataType;
        private System.Windows.Forms.ListView lisSheetData;
        private System.Windows.Forms.ImageList imlSPIcons;
    }
}
