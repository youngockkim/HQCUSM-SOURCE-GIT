namespace Miracom.BASCore
{
    partial class frmBASSetupGCMDataByPrivilege
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASSetupGCMDataByPrivilege));
            this.grpTblGroup = new System.Windows.Forms.GroupBox();
            this.chkOnlyPrvTable = new System.Windows.Forms.CheckBox();
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lisTable = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDataListFill = new System.Windows.Forms.Panel();
            this.pnlSql = new System.Windows.Forms.Panel();
            this.spdQuery = new FarPoint.Win.Spread.FpSpread();
            this.spdQuery_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splSQL = new System.Windows.Forms.Splitter();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.pnlSQLTest = new System.Windows.Forms.Panel();
            this.btnSQLTest = new System.Windows.Forms.Button();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlDataListBottom = new System.Windows.Forms.Panel();
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.btnTblExcel = new System.Windows.Forms.Button();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlDataFilter = new System.Windows.Forms.Panel();
            this.txtFilterKey2 = new System.Windows.Forms.TextBox();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.txtFilterKey1 = new System.Windows.Forms.TextBox();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTblGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            this.pnlDataListFill.SuspendLayout();
            this.pnlSql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery_Sheet1)).BeginInit();
            this.pnlSQLTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.pnlDataListBottom.SuspendLayout();
            this.grbTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            this.pnlDataFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlDataListFill);
            this.pnlRight.Controls.Add(this.pnlDataFilter);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisTable);
            this.pnlLeft.Controls.Add(this.grpTblGroup);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnTblExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnTblExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // grpTblGroup
            // 
            this.grpTblGroup.Controls.Add(this.chkOnlyPrvTable);
            this.grpTblGroup.Controls.Add(this.cdvGroup);
            this.grpTblGroup.Controls.Add(this.lblGroup);
            this.grpTblGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTblGroup.Location = new System.Drawing.Point(3, 3);
            this.grpTblGroup.Name = "grpTblGroup";
            this.grpTblGroup.Size = new System.Drawing.Size(229, 60);
            this.grpTblGroup.TabIndex = 1;
            this.grpTblGroup.TabStop = false;
            // 
            // chkOnlyPrvTable
            // 
            this.chkOnlyPrvTable.AutoSize = true;
            this.chkOnlyPrvTable.Checked = true;
            this.chkOnlyPrvTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyPrvTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOnlyPrvTable.Location = new System.Drawing.Point(9, 36);
            this.chkOnlyPrvTable.Name = "chkOnlyPrvTable";
            this.chkOnlyPrvTable.Size = new System.Drawing.Size(147, 18);
            this.chkOnlyPrvTable.TabIndex = 11;
            this.chkOnlyPrvTable.Text = "Only for Privileged Table";
            this.chkOnlyPrvTable.UseVisualStyleBackColor = true;
            this.chkOnlyPrvTable.CheckedChanged += new System.EventHandler(this.chkOnlyPrvTable_CheckedChanged);
            // 
            // cdvGroup
            // 
            this.cdvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup.BtnToolTipText = "";
            this.cdvGroup.ButtonWidth = 20;
            this.cdvGroup.DescText = "";
            this.cdvGroup.DisplaySubItemIndex = -1;
            this.cdvGroup.DisplayText = "";
            this.cdvGroup.Focusing = null;
            this.cdvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup.Index = 0;
            this.cdvGroup.IsViewBtnImage = false;
            this.cdvGroup.Location = new System.Drawing.Point(83, 11);
            this.cdvGroup.MaxLength = 20;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = false;
            this.cdvGroup.SameWidthHeightOfButton = false;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedSubItemIndex = -1;
            this.cdvGroup.SelectionStart = 0;
            this.cdvGroup.Size = new System.Drawing.Size(142, 20);
            this.cdvGroup.SmallImageList = null;
            this.cdvGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup.TabIndex = 0;
            this.cdvGroup.TextBoxToolTipText = "";
            this.cdvGroup.TextBoxWidth = 142;
            this.cdvGroup.VisibleButton = true;
            this.cdvGroup.VisibleColumnHeader = false;
            this.cdvGroup.VisibleDescription = false;
            this.cdvGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGroup_SelectedItemChanged);
            this.cdvGroup.ButtonPress += new System.EventHandler(this.cdvGroup_ButtonPress);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup.Location = new System.Drawing.Point(6, 13);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(66, 13);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Table Group";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisTable
            // 
            this.lisTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisTable.EnableSort = true;
            this.lisTable.EnableSortIcon = true;
            this.lisTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisTable.FullRowSelect = true;
            this.lisTable.HideSelection = false;
            this.lisTable.Location = new System.Drawing.Point(3, 63);
            this.lisTable.MultiSelect = false;
            this.lisTable.Name = "lisTable";
            this.lisTable.Size = new System.Drawing.Size(229, 447);
            this.lisTable.TabIndex = 2;
            this.lisTable.UseCompatibleStateImageBehavior = false;
            this.lisTable.View = System.Windows.Forms.View.Details;
            this.lisTable.SelectedIndexChanged += new System.EventHandler(this.lisTable_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Table Name";
            this.ColumnHeader1.Width = 120;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 240;
            // 
            // pnlDataListFill
            // 
            this.pnlDataListFill.Controls.Add(this.pnlSql);
            this.pnlDataListFill.Controls.Add(this.spdData);
            this.pnlDataListFill.Controls.Add(this.pnlDataListBottom);
            this.pnlDataListFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataListFill.Location = new System.Drawing.Point(3, 29);
            this.pnlDataListFill.Name = "pnlDataListFill";
            this.pnlDataListFill.Size = new System.Drawing.Size(500, 481);
            this.pnlDataListFill.TabIndex = 1;
            // 
            // pnlSql
            // 
            this.pnlSql.Controls.Add(this.spdQuery);
            this.pnlSql.Controls.Add(this.splSQL);
            this.pnlSql.Controls.Add(this.txtQuery);
            this.pnlSql.Controls.Add(this.pnlSQLTest);
            this.pnlSql.Location = new System.Drawing.Point(147, 242);
            this.pnlSql.Name = "pnlSql";
            this.pnlSql.Size = new System.Drawing.Size(311, 194);
            this.pnlSql.TabIndex = 1;
            this.pnlSql.Visible = false;
            // 
            // spdQuery
            // 
            this.spdQuery.AccessibleDescription = "";
            this.spdQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdQuery.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdQuery.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQuery.HorizontalScrollBar.Name = "";
            this.spdQuery.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdQuery.HorizontalScrollBar.TabIndex = 2;
            this.spdQuery.Location = new System.Drawing.Point(0, 62);
            this.spdQuery.Name = "spdQuery";
            this.spdQuery.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdQuery.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdQuery.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdQuery_Sheet1});
            this.spdQuery.Size = new System.Drawing.Size(311, 98);
            this.spdQuery.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdQuery.TabIndex = 8;
            this.spdQuery.TextTipDelay = 200;
            this.spdQuery.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdQuery.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQuery.VerticalScrollBar.Name = "";
            this.spdQuery.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdQuery.VerticalScrollBar.TabIndex = 3;
            this.spdQuery.SetActiveViewport(0, -1, -1);
            // 
            // spdQuery_Sheet1
            // 
            this.spdQuery_Sheet1.Reset();
            spdQuery_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdQuery_Sheet1.ColumnCount = 0;
            spdQuery_Sheet1.RowCount = 0;
            this.spdQuery_Sheet1.ActiveColumnIndex = -1;
            this.spdQuery_Sheet1.ActiveRowIndex = -1;
            this.spdQuery_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdQuery_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdQuery_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdQuery_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdQuery_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdQuery_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splSQL
            // 
            this.splSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.splSQL.Location = new System.Drawing.Point(0, 59);
            this.splSQL.Name = "splSQL";
            this.splSQL.Size = new System.Drawing.Size(311, 3);
            this.splSQL.TabIndex = 7;
            this.splSQL.TabStop = false;
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(311, 59);
            this.txtQuery.TabIndex = 6;
            this.txtQuery.Text = "";
            // 
            // pnlSQLTest
            // 
            this.pnlSQLTest.Controls.Add(this.btnSQLTest);
            this.pnlSQLTest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSQLTest.Location = new System.Drawing.Point(0, 160);
            this.pnlSQLTest.Name = "pnlSQLTest";
            this.pnlSQLTest.Size = new System.Drawing.Size(311, 34);
            this.pnlSQLTest.TabIndex = 5;
            // 
            // btnSQLTest
            // 
            this.btnSQLTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSQLTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSQLTest.Location = new System.Drawing.Point(217, 4);
            this.btnSQLTest.Name = "btnSQLTest";
            this.btnSQLTest.Size = new System.Drawing.Size(88, 26);
            this.btnSQLTest.TabIndex = 1;
            this.btnSQLTest.Text = "SQL Test";
            this.btnSQLTest.Click += new System.EventHandler(this.btnSQLTest_Click);
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 0);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(500, 433);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData.ClipboardChanged += new System.EventHandler(this.spdData_ClipboardChanged);
            this.spdData.EditModeOff += new System.EventHandler(this.spdData_EditModeOff);
            this.spdData.ClipboardPasting += new FarPoint.Win.Spread.ClipboardPastingEventHandler(this.fpSpread_ClipboardPasting);
            this.spdData.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdData_EnterCell);
            this.spdData.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_ButtonClicked);
            this.spdData.ClipboardChanging += new System.EventHandler(this.spdData_ClipboardChanging);
            this.spdData.AutoFilteredColumn += new FarPoint.Win.Spread.AutoFilteredColumnEventHandler(this.spdData_AutoFilteredColumn);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 0;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.Columns.Get(0).Width = 40F;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlDataListBottom
            // 
            this.pnlDataListBottom.Controls.Add(this.grbTable);
            this.pnlDataListBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDataListBottom.Location = new System.Drawing.Point(0, 433);
            this.pnlDataListBottom.Name = "pnlDataListBottom";
            this.pnlDataListBottom.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlDataListBottom.Size = new System.Drawing.Size(500, 48);
            this.pnlDataListBottom.TabIndex = 2;
            // 
            // grbTable
            // 
            this.grbTable.Controls.Add(this.btnSelect);
            this.grbTable.Controls.Add(this.txtPwd);
            this.grbTable.Controls.Add(this.lblPwd);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Location = new System.Drawing.Point(0, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(497, 48);
            this.grbTable.TabIndex = 0;
            this.grbTable.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelect.Location = new System.Drawing.Point(10, 14);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 26);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select All Rows";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPwd.Location = new System.Drawing.Point(302, 16);
            this.txtPwd.MaxLength = 20;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(177, 20);
            this.txtPwd.TabIndex = 2;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPwd.Location = new System.Drawing.Point(190, 19);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 13);
            this.lblPwd.TabIndex = 1;
            this.lblPwd.Text = "Password";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTblExcel
            // 
            this.btnTblExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTblExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnTblExcel.Image")));
            this.btnTblExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTblExcel.Location = new System.Drawing.Point(249, 8);
            this.btnTblExcel.Name = "btnTblExcel";
            this.btnTblExcel.Size = new System.Drawing.Size(24, 24);
            this.btnTblExcel.TabIndex = 6;
            this.btnTblExcel.Click += new System.EventHandler(this.btnTblExcel_Click);
            // 
            // cdvDataList
            // 
            this.cdvDataList.BackColor = System.Drawing.SystemColors.Control;
            this.cdvDataList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDataList.Location = new System.Drawing.Point(0, 0);
            this.cdvDataList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Name = "MCSPCodeView";
            this.cdvDataList.Size = new System.Drawing.Size(20, 20);
            this.cdvDataList.SmallImageList = null;
            this.cdvDataList.TabIndex = 0;
            this.cdvDataList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDataList.VisibleColumnHeader = false;
            this.cdvDataList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvDataList_SelectedItemChanged);
            // 
            // pnlDataFilter
            // 
            this.pnlDataFilter.Controls.Add(this.txtFilterKey2);
            this.pnlDataFilter.Controls.Add(this.lblKey2);
            this.pnlDataFilter.Controls.Add(this.txtFilterKey1);
            this.pnlDataFilter.Controls.Add(this.lblKey1);
            this.pnlDataFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDataFilter.Location = new System.Drawing.Point(3, 3);
            this.pnlDataFilter.Name = "pnlDataFilter";
            this.pnlDataFilter.Size = new System.Drawing.Size(500, 26);
            this.pnlDataFilter.TabIndex = 2;
            this.pnlDataFilter.Visible = false;
            // 
            // txtFilterKey2
            // 
            this.txtFilterKey2.Location = new System.Drawing.Point(297, 2);
            this.txtFilterKey2.Name = "txtFilterKey2";
            this.txtFilterKey2.Size = new System.Drawing.Size(100, 20);
            this.txtFilterKey2.TabIndex = 3;
            this.txtFilterKey2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterKey_KeyPress);
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.Location = new System.Drawing.Point(207, 6);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(31, 13);
            this.lblKey2.TabIndex = 2;
            this.lblKey2.Text = "Key2";
            // 
            // txtFilterKey1
            // 
            this.txtFilterKey1.Location = new System.Drawing.Point(97, 2);
            this.txtFilterKey1.Name = "txtFilterKey1";
            this.txtFilterKey1.Size = new System.Drawing.Size(100, 20);
            this.txtFilterKey1.TabIndex = 1;
            this.txtFilterKey1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterKey_KeyPress);
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.Location = new System.Drawing.Point(7, 6);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(31, 13);
            this.lblKey1.TabIndex = 0;
            this.lblKey1.Text = "Key1";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(285, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmBASSetupGCMDataByPrivilege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASSetupGCMDataByPrivilege";
            this.Text = "General Code Data Setup By Privilege";
            this.Activated += new System.EventHandler(this.frmBASSetupGCMDataByPrivilege_Activated);
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
            this.grpTblGroup.ResumeLayout(false);
            this.grpTblGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            this.pnlDataListFill.ResumeLayout(false);
            this.pnlSql.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery_Sheet1)).EndInit();
            this.pnlSQLTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.pnlDataListBottom.ResumeLayout(false);
            this.grbTable.ResumeLayout(false);
            this.grbTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            this.pnlDataFilter.ResumeLayout(false);
            this.pnlDataFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTblGroup;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup;
        private System.Windows.Forms.Label lblGroup;
        private UI.Controls.MCListView.MCListView lisTable;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Panel pnlDataListFill;
        private System.Windows.Forms.Panel pnlSql;
        private FarPoint.Win.Spread.FpSpread spdQuery;
        private FarPoint.Win.Spread.SheetView spdQuery_Sheet1;
        private System.Windows.Forms.Splitter splSQL;
        private System.Windows.Forms.RichTextBox txtQuery;
        private System.Windows.Forms.Panel pnlSQLTest;
        private System.Windows.Forms.Button btnSQLTest;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.Panel pnlDataListBottom;
        private System.Windows.Forms.GroupBox grbTable;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblPwd;
        protected System.Windows.Forms.Button btnTblExcel;
        private System.Windows.Forms.CheckBox chkOnlyPrvTable;
        private UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        private System.Windows.Forms.Panel pnlDataFilter;
        private System.Windows.Forms.TextBox txtFilterKey2;
        private System.Windows.Forms.Label lblKey2;
        private System.Windows.Forms.TextBox txtFilterKey1;
        private System.Windows.Forms.Label lblKey1;
        private System.Windows.Forms.Button btnView;
    }
}