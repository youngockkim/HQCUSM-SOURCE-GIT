namespace Miracom.BASCore
{
    partial class frmBASSetupGCMCodeAttribute
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.pnlListTop = new System.Windows.Forms.Panel();
            this.chkCentralFactory = new System.Windows.Forms.CheckBox();
            this.cdvTableGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTableGroup = new System.Windows.Forms.Label();
            this.cdvGCMTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGCMTable = new System.Windows.Forms.Label();
            this.lisCodeList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpAttributeName = new System.Windows.Forms.GroupBox();
            this.txtDesc2 = new System.Windows.Forms.TextBox();
            this.lblCodeDesc2 = new System.Windows.Forms.Label();
            this.txtDesc1 = new System.Windows.Forms.TextBox();
            this.lblCodeDesc1 = new System.Windows.Forms.Label();
            this.cdvCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCode = new System.Windows.Forms.Label();
            this.pnlAttrInfo = new System.Windows.Forms.Panel();
            this.grpAttributeInfo = new System.Windows.Forms.GroupBox();
            this.spdAttrValue = new FarPoint.Win.Spread.FpSpread();
            this.spdAttrValue_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grbUpdate = new System.Windows.Forms.GroupBox();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.cdvTableData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGCMTable)).BeginInit();
            this.grpAttributeName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCode)).BeginInit();
            this.pnlAttrInfo.SuspendLayout();
            this.grpAttributeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue_Sheet1)).BeginInit();
            this.grbUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 5;
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
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlAttrInfo);
            this.pnlRight.Controls.Add(this.grpAttributeName);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisCodeList);
            this.pnlLeft.Controls.Add(this.pnlListTop);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 7);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDelRow);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelRow, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // pnlListTop
            // 
            this.pnlListTop.Controls.Add(this.chkCentralFactory);
            this.pnlListTop.Controls.Add(this.cdvTableGroup);
            this.pnlListTop.Controls.Add(this.lblTableGroup);
            this.pnlListTop.Controls.Add(this.cdvGCMTable);
            this.pnlListTop.Controls.Add(this.lblGCMTable);
            this.pnlListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListTop.Location = new System.Drawing.Point(0, 0);
            this.pnlListTop.Name = "pnlListTop";
            this.pnlListTop.Size = new System.Drawing.Size(232, 76);
            this.pnlListTop.TabIndex = 0;
            // 
            // chkCentralFactory
            // 
            this.chkCentralFactory.AutoSize = true;
            this.chkCentralFactory.Location = new System.Drawing.Point(11, 5);
            this.chkCentralFactory.Name = "chkCentralFactory";
            this.chkCentralFactory.Size = new System.Drawing.Size(149, 17);
            this.chkCentralFactory.TabIndex = 0;
            this.chkCentralFactory.Text = "Use Central Factory Table";
            this.chkCentralFactory.UseVisualStyleBackColor = true;
            // 
            // cdvTableGroup
            // 
            this.cdvTableGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvTableGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTableGroup.BtnToolTipText = "";
            this.cdvTableGroup.DescText = "";
            this.cdvTableGroup.DisplaySubItemIndex = 0;
            this.cdvTableGroup.DisplayText = "";
            this.cdvTableGroup.Focusing = null;
            this.cdvTableGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableGroup.Index = 0;
            this.cdvTableGroup.IsViewBtnImage = false;
            this.cdvTableGroup.Location = new System.Drawing.Point(97, 26);
            this.cdvTableGroup.MaxLength = 20;
            this.cdvTableGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTableGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTableGroup.Name = "cdvTableGroup";
            this.cdvTableGroup.ReadOnly = false;
            this.cdvTableGroup.SearchSubItemIndex = 0;
            this.cdvTableGroup.SelectedDescIndex = -1;
            this.cdvTableGroup.SelectedSubItemIndex = 0;
            this.cdvTableGroup.SelectionStart = 0;
            this.cdvTableGroup.Size = new System.Drawing.Size(128, 20);
            this.cdvTableGroup.SmallImageList = null;
            this.cdvTableGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTableGroup.TabIndex = 2;
            this.cdvTableGroup.TextBoxToolTipText = "";
            this.cdvTableGroup.TextBoxWidth = 128;
            this.cdvTableGroup.VisibleButton = true;
            this.cdvTableGroup.VisibleColumnHeader = false;
            this.cdvTableGroup.VisibleDescription = false;
            this.cdvTableGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvTableGroup_SelectedItemChanged);
            this.cdvTableGroup.ButtonPress += new System.EventHandler(this.cdvTableGroup_ButtonPress);
            // 
            // lblTableGroup
            // 
            this.lblTableGroup.AutoSize = true;
            this.lblTableGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTableGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTableGroup.Location = new System.Drawing.Point(8, 30);
            this.lblTableGroup.Name = "lblTableGroup";
            this.lblTableGroup.Size = new System.Drawing.Size(66, 13);
            this.lblTableGroup.TabIndex = 1;
            this.lblTableGroup.Text = "Table Group";
            // 
            // cdvGCMTable
            // 
            this.cdvGCMTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvGCMTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGCMTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGCMTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGCMTable.BtnToolTipText = "";
            this.cdvGCMTable.DescText = "";
            this.cdvGCMTable.DisplaySubItemIndex = 0;
            this.cdvGCMTable.DisplayText = "";
            this.cdvGCMTable.Focusing = null;
            this.cdvGCMTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGCMTable.Index = 0;
            this.cdvGCMTable.IsViewBtnImage = false;
            this.cdvGCMTable.Location = new System.Drawing.Point(97, 50);
            this.cdvGCMTable.MaxLength = 20;
            this.cdvGCMTable.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGCMTable.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGCMTable.Name = "cdvGCMTable";
            this.cdvGCMTable.ReadOnly = false;
            this.cdvGCMTable.SearchSubItemIndex = 0;
            this.cdvGCMTable.SelectedDescIndex = -1;
            this.cdvGCMTable.SelectedSubItemIndex = 0;
            this.cdvGCMTable.SelectionStart = 0;
            this.cdvGCMTable.Size = new System.Drawing.Size(128, 20);
            this.cdvGCMTable.SmallImageList = null;
            this.cdvGCMTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGCMTable.TabIndex = 4;
            this.cdvGCMTable.TextBoxToolTipText = "";
            this.cdvGCMTable.TextBoxWidth = 128;
            this.cdvGCMTable.VisibleButton = true;
            this.cdvGCMTable.VisibleColumnHeader = false;
            this.cdvGCMTable.VisibleDescription = false;
            this.cdvGCMTable.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGCMTable_SelectedItemChanged);
            this.cdvGCMTable.ButtonPress += new System.EventHandler(this.cdvGCMTable_ButtonPress);
            // 
            // lblGCMTable
            // 
            this.lblGCMTable.AutoSize = true;
            this.lblGCMTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGCMTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGCMTable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGCMTable.Location = new System.Drawing.Point(8, 54);
            this.lblGCMTable.Name = "lblGCMTable";
            this.lblGCMTable.Size = new System.Drawing.Size(70, 13);
            this.lblGCMTable.TabIndex = 3;
            this.lblGCMTable.Text = "GCM Table";
            // 
            // lisCodeList
            // 
            this.lisCodeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colDesc});
            this.lisCodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCodeList.EnableSort = true;
            this.lisCodeList.EnableSortIcon = true;
            this.lisCodeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCodeList.FullRowSelect = true;
            this.lisCodeList.Location = new System.Drawing.Point(0, 76);
            this.lisCodeList.MultiSelect = false;
            this.lisCodeList.Name = "lisCodeList";
            this.lisCodeList.Size = new System.Drawing.Size(232, 430);
            this.lisCodeList.TabIndex = 1;
            this.lisCodeList.UseCompatibleStateImageBehavior = false;
            this.lisCodeList.View = System.Windows.Forms.View.Details;
            this.lisCodeList.SelectedIndexChanged += new System.EventHandler(this.lisCodeList_SelectedIndexChanged);
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 120;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 120;
            // 
            // grpAttributeName
            // 
            this.grpAttributeName.Controls.Add(this.txtDesc2);
            this.grpAttributeName.Controls.Add(this.lblCodeDesc2);
            this.grpAttributeName.Controls.Add(this.txtDesc1);
            this.grpAttributeName.Controls.Add(this.lblCodeDesc1);
            this.grpAttributeName.Controls.Add(this.cdvCode);
            this.grpAttributeName.Controls.Add(this.lblCode);
            this.grpAttributeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAttributeName.Location = new System.Drawing.Point(0, 0);
            this.grpAttributeName.Name = "grpAttributeName";
            this.grpAttributeName.Size = new System.Drawing.Size(506, 92);
            this.grpAttributeName.TabIndex = 0;
            this.grpAttributeName.TabStop = false;
            // 
            // txtDesc2
            // 
            this.txtDesc2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc2.Location = new System.Drawing.Point(182, 64);
            this.txtDesc2.MaxLength = 200;
            this.txtDesc2.Name = "txtDesc2";
            this.txtDesc2.Size = new System.Drawing.Size(318, 20);
            this.txtDesc2.TabIndex = 5;
            // 
            // lblCodeDesc2
            // 
            this.lblCodeDesc2.AutoSize = true;
            this.lblCodeDesc2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCodeDesc2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCodeDesc2.Location = new System.Drawing.Point(16, 68);
            this.lblCodeDesc2.Name = "lblCodeDesc2";
            this.lblCodeDesc2.Size = new System.Drawing.Size(66, 13);
            this.lblCodeDesc2.TabIndex = 4;
            this.lblCodeDesc2.Text = "Description2";
            // 
            // txtDesc1
            // 
            this.txtDesc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc1.Location = new System.Drawing.Point(182, 40);
            this.txtDesc1.MaxLength = 200;
            this.txtDesc1.Name = "txtDesc1";
            this.txtDesc1.Size = new System.Drawing.Size(318, 20);
            this.txtDesc1.TabIndex = 3;
            // 
            // lblCodeDesc1
            // 
            this.lblCodeDesc1.AutoSize = true;
            this.lblCodeDesc1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCodeDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeDesc1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCodeDesc1.Location = new System.Drawing.Point(16, 44);
            this.lblCodeDesc1.Name = "lblCodeDesc1";
            this.lblCodeDesc1.Size = new System.Drawing.Size(66, 13);
            this.lblCodeDesc1.TabIndex = 2;
            this.lblCodeDesc1.Text = "Description1";
            // 
            // cdvCode
            // 
            this.cdvCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCode.BtnToolTipText = "";
            this.cdvCode.DescText = "";
            this.cdvCode.DisplaySubItemIndex = 0;
            this.cdvCode.DisplayText = "";
            this.cdvCode.Focusing = null;
            this.cdvCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCode.Index = 0;
            this.cdvCode.IsViewBtnImage = false;
            this.cdvCode.Location = new System.Drawing.Point(182, 16);
            this.cdvCode.MaxLength = 20;
            this.cdvCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCode.Name = "cdvCode";
            this.cdvCode.ReadOnly = false;
            this.cdvCode.SearchSubItemIndex = 0;
            this.cdvCode.SelectedDescIndex = -1;
            this.cdvCode.SelectedSubItemIndex = 0;
            this.cdvCode.SelectionStart = 0;
            this.cdvCode.Size = new System.Drawing.Size(178, 20);
            this.cdvCode.SmallImageList = null;
            this.cdvCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCode.TabIndex = 1;
            this.cdvCode.TextBoxToolTipText = "";
            this.cdvCode.TextBoxWidth = 178;
            this.cdvCode.VisibleButton = false;
            this.cdvCode.VisibleColumnHeader = false;
            this.cdvCode.VisibleDescription = false;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCode.Location = new System.Drawing.Point(16, 20);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(36, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // pnlAttrInfo
            // 
            this.pnlAttrInfo.Controls.Add(this.grpAttributeInfo);
            this.pnlAttrInfo.Controls.Add(this.grbUpdate);
            this.pnlAttrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttrInfo.Location = new System.Drawing.Point(0, 92);
            this.pnlAttrInfo.Name = "pnlAttrInfo";
            this.pnlAttrInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlAttrInfo.Size = new System.Drawing.Size(506, 414);
            this.pnlAttrInfo.TabIndex = 1;
            // 
            // grpAttributeInfo
            // 
            this.grpAttributeInfo.Controls.Add(this.spdAttrValue);
            this.grpAttributeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttributeInfo.Location = new System.Drawing.Point(0, 5);
            this.grpAttributeInfo.Name = "grpAttributeInfo";
            this.grpAttributeInfo.Size = new System.Drawing.Size(506, 341);
            this.grpAttributeInfo.TabIndex = 0;
            this.grpAttributeInfo.TabStop = false;
            this.grpAttributeInfo.Text = "Code Attribute Information";
            // 
            // spdAttrValue
            // 
            this.spdAttrValue.AccessibleDescription = "spdAttrValue, Sheet1, Row 0, Column 0, ";
            this.spdAttrValue.BackColor = System.Drawing.SystemColors.Control;
            this.spdAttrValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAttrValue.EditModeReplace = true;
            this.spdAttrValue.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdAttrValue.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttrValue.HorizontalScrollBar.Name = "";
            this.spdAttrValue.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdAttrValue.HorizontalScrollBar.TabIndex = 18;
            this.spdAttrValue.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttrValue.Location = new System.Drawing.Point(3, 16);
            this.spdAttrValue.Name = "spdAttrValue";
            this.spdAttrValue.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAttrValue.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAttrValue.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAttrValue_Sheet1});
            this.spdAttrValue.Size = new System.Drawing.Size(500, 322);
            this.spdAttrValue.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAttrValue.TabIndex = 0;
            this.spdAttrValue.TextTipDelay = 200;
            this.spdAttrValue.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAttrValue.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttrValue.VerticalScrollBar.Name = "";
            this.spdAttrValue.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdAttrValue.VerticalScrollBar.TabIndex = 19;
            this.spdAttrValue.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttrValue.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdAttrValue_EnterCell);
            this.spdAttrValue.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdAttrValue_CellDoubleClick);
            this.spdAttrValue.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttrValue_ButtonClicked);
            this.spdAttrValue.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttrValue_EditChange);
            // 
            // spdAttrValue_Sheet1
            // 
            this.spdAttrValue_Sheet1.Reset();
            spdAttrValue_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAttrValue_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAttrValue_Sheet1.ColumnCount = 14;
            spdAttrValue_Sheet1.RowCount = 3;
            this.spdAttrValue_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttrValue_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Name";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Current Value";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "New Value";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Null";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Array Type";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Array Separator";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Value Format";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Value Size";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Valid Table";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Table Type";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Allow Blank";
            this.spdAttrValue_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttrValue_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            checkBoxCellType1.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdAttrValue_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdAttrValue_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdAttrValue_Sheet1.Columns.Get(0).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(0).Width = 25F;
            this.spdAttrValue_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(1).Label = "Name";
            this.spdAttrValue_Sheet1.Columns.Get(1).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdAttrValue_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(1).Width = 120F;
            this.spdAttrValue_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(2).Label = "Description";
            this.spdAttrValue_Sheet1.Columns.Get(2).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdAttrValue_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(2).Width = 120F;
            this.spdAttrValue_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType1.MaxLength = 110;
            textCellType1.WordWrap = true;
            this.spdAttrValue_Sheet1.Columns.Get(3).CellType = textCellType1;
            this.spdAttrValue_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(3).Label = "Current Value";
            this.spdAttrValue_Sheet1.Columns.Get(3).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(3).Width = 100F;
            this.spdAttrValue_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(4).Label = "New Value";
            this.spdAttrValue_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(4).Width = 100F;
            this.spdAttrValue_Sheet1.Columns.Get(5).Resizable = false;
            this.spdAttrValue_Sheet1.Columns.Get(5).Width = 20F;
            this.spdAttrValue_Sheet1.Columns.Get(6).CellType = checkBoxCellType2;
            this.spdAttrValue_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(6).Label = "Null";
            this.spdAttrValue_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(6).Width = 30F;
            this.spdAttrValue_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAttrValue_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAttrValue_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAttrValue_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAttrValue_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grbUpdate
            // 
            this.grbUpdate.Controls.Add(this.lblUpdateUser);
            this.grbUpdate.Controls.Add(this.txtUpdateTime);
            this.grbUpdate.Controls.Add(this.lblUpdateTime);
            this.grbUpdate.Controls.Add(this.txtUpdateUser);
            this.grbUpdate.Controls.Add(this.lblCreateUser);
            this.grbUpdate.Controls.Add(this.txtCreateTime);
            this.grbUpdate.Controls.Add(this.lblCreateTime);
            this.grbUpdate.Controls.Add(this.txtCreateUser);
            this.grbUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbUpdate.Location = new System.Drawing.Point(0, 346);
            this.grbUpdate.Name = "grbUpdate";
            this.grbUpdate.Size = new System.Drawing.Size(506, 68);
            this.grbUpdate.TabIndex = 1;
            this.grbUpdate.TabStop = false;
            this.grbUpdate.Text = "Update Information";
            this.grbUpdate.Visible = false;
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(266, 20);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 2;
            this.lblUpdateUser.Text = "Update User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(345, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(155, 20);
            this.txtUpdateTime.TabIndex = 7;
            this.txtUpdateTime.TabStop = false;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(266, 44);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 6;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(345, 16);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(155, 20);
            this.txtUpdateUser.TabIndex = 3;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(16, 20);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 0;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(95, 40);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(155, 20);
            this.txtCreateTime.TabIndex = 5;
            this.txtCreateTime.TabStop = false;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(16, 44);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 4;
            this.lblCreateTime.Text = "Create Time";
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(95, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(155, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // cdvTableData
            // 
            this.cdvTableData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableData.Location = new System.Drawing.Point(189, 17);
            this.cdvTableData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Name = "cdvTableData";
            this.cdvTableData.Size = new System.Drawing.Size(20, 20);
            this.cdvTableData.SmallImageList = null;
            this.cdvTableData.TabIndex = 0;
            this.cdvTableData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableData.VisibleColumnHeader = false;
            this.cdvTableData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableData_SelectedItemChanged);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Enabled = false;
            this.btnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelRow.Location = new System.Drawing.Point(236, 7);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(88, 26);
            this.btnDelRow.TabIndex = 4;
            this.btnDelRow.Text = "Delete Row";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // frmBASSetupGCMCodeAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASSetupGCMCodeAttribute";
            this.Text = "General Code Attribute Value Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupGCMCodeAttribute_Activated);
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
            this.pnlListTop.ResumeLayout(false);
            this.pnlListTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGCMTable)).EndInit();
            this.grpAttributeName.ResumeLayout(false);
            this.grpAttributeName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCode)).EndInit();
            this.pnlAttrInfo.ResumeLayout(false);
            this.grpAttributeInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue_Sheet1)).EndInit();
            this.grbUpdate.ResumeLayout(false);
            this.grbUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListTop;
        private UI.Controls.MCCodeView.MCCodeView cdvGCMTable;
        private System.Windows.Forms.Label lblGCMTable;
        private UI.Controls.MCListView.MCListView lisCodeList;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.GroupBox grpAttributeName;
        private System.Windows.Forms.TextBox txtDesc2;
        private System.Windows.Forms.Label lblCodeDesc2;
        private System.Windows.Forms.TextBox txtDesc1;
        private System.Windows.Forms.Label lblCodeDesc1;
        private UI.Controls.MCCodeView.MCCodeView cdvCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Panel pnlAttrInfo;
        private System.Windows.Forms.GroupBox grpAttributeInfo;
        private FarPoint.Win.Spread.FpSpread spdAttrValue;
        private FarPoint.Win.Spread.SheetView spdAttrValue_Sheet1;
        private UI.Controls.MCCodeView.MCSPCodeView cdvTableData;
        private UI.Controls.MCCodeView.MCCodeView cdvTableGroup;
        private System.Windows.Forms.Label lblTableGroup;
        private System.Windows.Forms.CheckBox chkCentralFactory;
        private System.Windows.Forms.Button btnDelRow;
        private System.Windows.Forms.GroupBox grbUpdate;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.TextBox txtCreateUser;
    }
}