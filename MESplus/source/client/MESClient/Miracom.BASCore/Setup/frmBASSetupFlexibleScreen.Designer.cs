namespace Miracom.BASCore
{
    partial class frmBASSetupFlexibleScreen
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
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlListTop = new System.Windows.Forms.Panel();
            this.cdvFactory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFactory = new System.Windows.Forms.Label();
            this.cdvSGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSGrp = new System.Windows.Forms.Label();
            this.lisScreen = new Miracom.UI.Controls.MCListView.MCListView();
            this.colScreenID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpScreenName = new System.Windows.Forms.GroupBox();
            this.txtScreenID = new System.Windows.Forms.TextBox();
            this.txtScreenDesc = new System.Windows.Forms.TextBox();
            this.lblAttrDesc = new System.Windows.Forms.Label();
            this.cdvScreenGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblScreenGrp = new System.Windows.Forms.Label();
            this.lblScreenID = new System.Windows.Forms.Label();
            this.spdSpread = new FarPoint.Win.Spread.FpSpread();
            this.spdSpread_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tabScreen = new System.Windows.Forms.TabControl();
            this.tapGeneral = new System.Windows.Forms.TabPage();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblService = new System.Windows.Forms.Label();
            this.cdvService = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblModule = new System.Windows.Forms.Label();
            this.cdvModule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.tapScreen = new System.Windows.Forms.TabPage();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnFromExcel = new System.Windows.Forms.Button();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFactory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSGrp)).BeginInit();
            this.grpScreenName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvScreenGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread_Sheet1)).BeginInit();
            this.tabScreen.SuspendLayout();
            this.tapGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).BeginInit();
            this.tapScreen.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.tabScreen);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisScreen);
            this.pnlLeft.Controls.Add(this.pnlListTop);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnFromExcel);
            this.pnlBottom.Controls.Add(this.btnEdit);
            this.pnlBottom.Controls.SetChildIndex(this.btnEdit, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnFromExcel, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            // 
            // pnlListTop
            // 
            this.pnlListTop.Controls.Add(this.cdvFactory);
            this.pnlListTop.Controls.Add(this.lblFactory);
            this.pnlListTop.Controls.Add(this.cdvSGrp);
            this.pnlListTop.Controls.Add(this.lblSGrp);
            this.pnlListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListTop.Location = new System.Drawing.Point(0, 0);
            this.pnlListTop.Name = "pnlListTop";
            this.pnlListTop.Size = new System.Drawing.Size(232, 58);
            this.pnlListTop.TabIndex = 0;
            // 
            // cdvFactory
            // 
            this.cdvFactory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFactory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFactory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFactory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFactory.BtnToolTipText = "";
            this.cdvFactory.ButtonWidth = 20;
            this.cdvFactory.DescText = "";
            this.cdvFactory.DisplaySubItemIndex = 0;
            this.cdvFactory.DisplayText = "";
            this.cdvFactory.Focusing = null;
            this.cdvFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFactory.Index = 0;
            this.cdvFactory.IsViewBtnImage = false;
            this.cdvFactory.Location = new System.Drawing.Point(97, 5);
            this.cdvFactory.MaxLength = 10;
            this.cdvFactory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFactory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFactory.MultiSelect = false;
            this.cdvFactory.Name = "cdvFactory";
            this.cdvFactory.ReadOnly = false;
            this.cdvFactory.SameWidthHeightOfButton = false;
            this.cdvFactory.SearchSubItemIndex = 0;
            this.cdvFactory.SelectedDescIndex = -1;
            this.cdvFactory.SelectedDescToQueryText = "";
            this.cdvFactory.SelectedSubItemIndex = 0;
            this.cdvFactory.SelectedValueToQueryText = "";
            this.cdvFactory.SelectionStart = 0;
            this.cdvFactory.Size = new System.Drawing.Size(128, 20);
            this.cdvFactory.SmallImageList = null;
            this.cdvFactory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFactory.TabIndex = 1;
            this.cdvFactory.TextBoxToolTipText = "";
            this.cdvFactory.TextBoxWidth = 128;
            this.cdvFactory.VisibleButton = true;
            this.cdvFactory.VisibleColumnHeader = false;
            this.cdvFactory.VisibleDescription = false;
            this.cdvFactory.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFactory_SelectedItemChanged);
            this.cdvFactory.ButtonPress += new System.EventHandler(this.cdvFactory_ButtonPress);
            // 
            // lblFactory
            // 
            this.lblFactory.AutoSize = true;
            this.lblFactory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFactory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFactory.Location = new System.Drawing.Point(7, 8);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(42, 13);
            this.lblFactory.TabIndex = 0;
            this.lblFactory.Text = "Factory";
            // 
            // cdvSGrp
            // 
            this.cdvSGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvSGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSGrp.BtnToolTipText = "";
            this.cdvSGrp.ButtonWidth = 20;
            this.cdvSGrp.DescText = "";
            this.cdvSGrp.DisplaySubItemIndex = 0;
            this.cdvSGrp.DisplayText = "";
            this.cdvSGrp.Focusing = null;
            this.cdvSGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSGrp.Index = 0;
            this.cdvSGrp.IsViewBtnImage = false;
            this.cdvSGrp.Location = new System.Drawing.Point(97, 29);
            this.cdvSGrp.MaxLength = 10;
            this.cdvSGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSGrp.MultiSelect = false;
            this.cdvSGrp.Name = "cdvSGrp";
            this.cdvSGrp.ReadOnly = false;
            this.cdvSGrp.SameWidthHeightOfButton = false;
            this.cdvSGrp.SearchSubItemIndex = 0;
            this.cdvSGrp.SelectedDescIndex = -1;
            this.cdvSGrp.SelectedDescToQueryText = "";
            this.cdvSGrp.SelectedSubItemIndex = 0;
            this.cdvSGrp.SelectedValueToQueryText = "";
            this.cdvSGrp.SelectionStart = 0;
            this.cdvSGrp.Size = new System.Drawing.Size(128, 20);
            this.cdvSGrp.SmallImageList = null;
            this.cdvSGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSGrp.TabIndex = 1;
            this.cdvSGrp.TextBoxToolTipText = "";
            this.cdvSGrp.TextBoxWidth = 128;
            this.cdvSGrp.VisibleButton = true;
            this.cdvSGrp.VisibleColumnHeader = false;
            this.cdvSGrp.VisibleDescription = false;
            this.cdvSGrp.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSGrp_SelectedItemChanged);
            this.cdvSGrp.ButtonPress += new System.EventHandler(this.cdvSGrp_ButtonPress);
            // 
            // lblSGrp
            // 
            this.lblSGrp.AutoSize = true;
            this.lblSGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSGrp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSGrp.Location = new System.Drawing.Point(7, 32);
            this.lblSGrp.Name = "lblSGrp";
            this.lblSGrp.Size = new System.Drawing.Size(73, 13);
            this.lblSGrp.TabIndex = 0;
            this.lblSGrp.Text = "Screen Group";
            // 
            // lisScreen
            // 
            this.lisScreen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colScreenID,
            this.colDesc});
            this.lisScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisScreen.EnableSort = true;
            this.lisScreen.EnableSortIcon = true;
            this.lisScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisScreen.FullRowSelect = true;
            this.lisScreen.Location = new System.Drawing.Point(0, 58);
            this.lisScreen.MultiSelect = false;
            this.lisScreen.Name = "lisScreen";
            this.lisScreen.Size = new System.Drawing.Size(232, 448);
            this.lisScreen.TabIndex = 1;
            this.lisScreen.UseCompatibleStateImageBehavior = false;
            this.lisScreen.View = System.Windows.Forms.View.Details;
            this.lisScreen.SelectedIndexChanged += new System.EventHandler(this.lisScreen_SelectedIndexChanged);
            // 
            // colScreenID
            // 
            this.colScreenID.Text = "Screen ID";
            this.colScreenID.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 300;
            // 
            // grpScreenName
            // 
            this.grpScreenName.Controls.Add(this.txtScreenID);
            this.grpScreenName.Controls.Add(this.txtScreenDesc);
            this.grpScreenName.Controls.Add(this.lblAttrDesc);
            this.grpScreenName.Controls.Add(this.cdvScreenGrp);
            this.grpScreenName.Controls.Add(this.lblScreenGrp);
            this.grpScreenName.Controls.Add(this.lblScreenID);
            this.grpScreenName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpScreenName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpScreenName.Location = new System.Drawing.Point(3, 3);
            this.grpScreenName.Name = "grpScreenName";
            this.grpScreenName.Size = new System.Drawing.Size(492, 93);
            this.grpScreenName.TabIndex = 0;
            this.grpScreenName.TabStop = false;
            // 
            // txtScreenID
            // 
            this.txtScreenID.Location = new System.Drawing.Point(116, 13);
            this.txtScreenID.MaxLength = 30;
            this.txtScreenID.Name = "txtScreenID";
            this.txtScreenID.Size = new System.Drawing.Size(150, 20);
            this.txtScreenID.TabIndex = 1;
            // 
            // txtScreenDesc
            // 
            this.txtScreenDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScreenDesc.Location = new System.Drawing.Point(116, 59);
            this.txtScreenDesc.MaxLength = 200;
            this.txtScreenDesc.Name = "txtScreenDesc";
            this.txtScreenDesc.Size = new System.Drawing.Size(370, 20);
            this.txtScreenDesc.TabIndex = 5;
            // 
            // lblAttrDesc
            // 
            this.lblAttrDesc.AutoSize = true;
            this.lblAttrDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrDesc.Location = new System.Drawing.Point(16, 62);
            this.lblAttrDesc.Name = "lblAttrDesc";
            this.lblAttrDesc.Size = new System.Drawing.Size(60, 13);
            this.lblAttrDesc.TabIndex = 4;
            this.lblAttrDesc.Text = "Description";
            // 
            // cdvScreenGrp
            // 
            this.cdvScreenGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvScreenGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvScreenGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvScreenGrp.BtnToolTipText = "";
            this.cdvScreenGrp.ButtonWidth = 20;
            this.cdvScreenGrp.DescText = "";
            this.cdvScreenGrp.DisplaySubItemIndex = 0;
            this.cdvScreenGrp.DisplayText = "";
            this.cdvScreenGrp.Focusing = null;
            this.cdvScreenGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvScreenGrp.Index = 0;
            this.cdvScreenGrp.IsViewBtnImage = false;
            this.cdvScreenGrp.Location = new System.Drawing.Point(116, 36);
            this.cdvScreenGrp.MaxLength = 10;
            this.cdvScreenGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvScreenGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvScreenGrp.MultiSelect = false;
            this.cdvScreenGrp.Name = "cdvScreenGrp";
            this.cdvScreenGrp.ReadOnly = false;
            this.cdvScreenGrp.SameWidthHeightOfButton = false;
            this.cdvScreenGrp.SearchSubItemIndex = 0;
            this.cdvScreenGrp.SelectedDescIndex = -1;
            this.cdvScreenGrp.SelectedDescToQueryText = "";
            this.cdvScreenGrp.SelectedSubItemIndex = 0;
            this.cdvScreenGrp.SelectedValueToQueryText = "";
            this.cdvScreenGrp.SelectionStart = 0;
            this.cdvScreenGrp.Size = new System.Drawing.Size(150, 20);
            this.cdvScreenGrp.SmallImageList = null;
            this.cdvScreenGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvScreenGrp.TabIndex = 3;
            this.cdvScreenGrp.TextBoxToolTipText = "";
            this.cdvScreenGrp.TextBoxWidth = 150;
            this.cdvScreenGrp.VisibleButton = true;
            this.cdvScreenGrp.VisibleColumnHeader = false;
            this.cdvScreenGrp.VisibleDescription = false;
            this.cdvScreenGrp.ButtonPress += new System.EventHandler(this.cdvScreenGrp_ButtonPress);
            // 
            // lblScreenGrp
            // 
            this.lblScreenGrp.AutoSize = true;
            this.lblScreenGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblScreenGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreenGrp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblScreenGrp.Location = new System.Drawing.Point(16, 39);
            this.lblScreenGrp.Name = "lblScreenGrp";
            this.lblScreenGrp.Size = new System.Drawing.Size(85, 13);
            this.lblScreenGrp.TabIndex = 2;
            this.lblScreenGrp.Text = "Screen Group";
            // 
            // lblScreenID
            // 
            this.lblScreenID.AutoSize = true;
            this.lblScreenID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblScreenID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreenID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblScreenID.Location = new System.Drawing.Point(16, 19);
            this.lblScreenID.Name = "lblScreenID";
            this.lblScreenID.Size = new System.Drawing.Size(64, 13);
            this.lblScreenID.TabIndex = 0;
            this.lblScreenID.Text = "Screen ID";
            // 
            // spdSpread
            // 
            this.spdSpread.AccessibleDescription = "spdSpread, Sheet1, Row 0, Column 0, ";
            this.spdSpread.BackColor = System.Drawing.SystemColors.Control;
            this.spdSpread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSpread.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSpread.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSpread.HorizontalScrollBar.Name = "";
            this.spdSpread.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdSpread.HorizontalScrollBar.TabIndex = 4;
            this.spdSpread.Location = new System.Drawing.Point(3, 3);
            this.spdSpread.Name = "spdSpread";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer2;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer2;
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
            this.spdSpread.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdSpread.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdSpread.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSpread_Sheet1});
            this.spdSpread.Size = new System.Drawing.Size(492, 474);
            this.spdSpread.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSpread.TabIndex = 3;
            this.spdSpread.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSpread.VerticalScrollBar.Name = "";
            this.spdSpread.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdSpread.VerticalScrollBar.TabIndex = 5;
            this.spdSpread.SetActiveViewport(0, -1, -1);
            // 
            // spdSpread_Sheet1
            // 
            this.spdSpread_Sheet1.Reset();
            spdSpread_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSpread_Sheet1.ColumnCount = 0;
            spdSpread_Sheet1.RowCount = 0;
            this.spdSpread_Sheet1.ActiveColumnIndex = -1;
            this.spdSpread_Sheet1.ActiveRowIndex = -1;
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSpread_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSpread_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tabScreen
            // 
            this.tabScreen.Controls.Add(this.tapGeneral);
            this.tabScreen.Controls.Add(this.tapScreen);
            this.tabScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabScreen.Location = new System.Drawing.Point(0, 0);
            this.tabScreen.Name = "tabScreen";
            this.tabScreen.SelectedIndex = 0;
            this.tabScreen.Size = new System.Drawing.Size(506, 506);
            this.tabScreen.TabIndex = 0;
            this.tabScreen.SelectedIndexChanged += new System.EventHandler(this.tabScreen_SelectedIndexChanged);
            // 
            // tapGeneral
            // 
            this.tapGeneral.BackColor = System.Drawing.SystemColors.Control;
            this.tapGeneral.Controls.Add(this.lblUpdateUser);
            this.tapGeneral.Controls.Add(this.txtUpdateTime);
            this.tapGeneral.Controls.Add(this.lblUpdateTime);
            this.tapGeneral.Controls.Add(this.txtUpdateUser);
            this.tapGeneral.Controls.Add(this.lblCreateUser);
            this.tapGeneral.Controls.Add(this.txtCreateTime);
            this.tapGeneral.Controls.Add(this.lblCreateTime);
            this.tapGeneral.Controls.Add(this.txtCreateUser);
            this.tapGeneral.Controls.Add(this.lblService);
            this.tapGeneral.Controls.Add(this.cdvService);
            this.tapGeneral.Controls.Add(this.lblModule);
            this.tapGeneral.Controls.Add(this.cdvModule);
            this.tapGeneral.Controls.Add(this.grpScreenName);
            this.tapGeneral.Location = new System.Drawing.Point(4, 22);
            this.tapGeneral.Name = "tapGeneral";
            this.tapGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tapGeneral.Size = new System.Drawing.Size(498, 480);
            this.tapGeneral.TabIndex = 0;
            this.tapGeneral.Text = "General";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(19, 224);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 9;
            this.lblUpdateUser.Text = "Update User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(119, 247);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(150, 20);
            this.txtUpdateTime.TabIndex = 12;
            this.txtUpdateTime.TabStop = false;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(19, 250);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 11;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(119, 221);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(150, 20);
            this.txtUpdateUser.TabIndex = 10;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(19, 172);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 5;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(119, 195);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(150, 20);
            this.txtCreateTime.TabIndex = 8;
            this.txtCreateTime.TabStop = false;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(19, 198);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 7;
            this.lblCreateTime.Text = "Create Time";
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(119, 169);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(150, 20);
            this.txtCreateUser.TabIndex = 6;
            this.txtCreateUser.TabStop = false;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblService.Location = new System.Drawing.Point(19, 132);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(86, 13);
            this.lblService.TabIndex = 3;
            this.lblService.Text = "Service Name";
            // 
            // cdvService
            // 
            this.cdvService.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvService.BorderHotColor = System.Drawing.Color.Black;
            this.cdvService.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvService.BtnToolTipText = "";
            this.cdvService.ButtonWidth = 20;
            this.cdvService.DescText = "";
            this.cdvService.DisplaySubItemIndex = 0;
            this.cdvService.DisplayText = "";
            this.cdvService.Focusing = null;
            this.cdvService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvService.Index = 0;
            this.cdvService.IsViewBtnImage = false;
            this.cdvService.Location = new System.Drawing.Point(119, 129);
            this.cdvService.MaxLength = 100;
            this.cdvService.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvService.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvService.MultiSelect = false;
            this.cdvService.Name = "cdvService";
            this.cdvService.ReadOnly = false;
            this.cdvService.SameWidthHeightOfButton = false;
            this.cdvService.SearchSubItemIndex = 0;
            this.cdvService.SelectedDescIndex = -1;
            this.cdvService.SelectedDescToQueryText = "";
            this.cdvService.SelectedSubItemIndex = 0;
            this.cdvService.SelectedValueToQueryText = "";
            this.cdvService.SelectionStart = 0;
            this.cdvService.Size = new System.Drawing.Size(276, 20);
            this.cdvService.SmallImageList = null;
            this.cdvService.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvService.TabIndex = 4;
            this.cdvService.TextBoxToolTipText = "";
            this.cdvService.TextBoxWidth = 276;
            this.cdvService.VisibleButton = true;
            this.cdvService.VisibleColumnHeader = false;
            this.cdvService.VisibleDescription = false;
            this.cdvService.ButtonPress += new System.EventHandler(this.cdvService_ButtonPress);
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModule.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblModule.Location = new System.Drawing.Point(19, 109);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(84, 13);
            this.lblModule.TabIndex = 1;
            this.lblModule.Text = "Module Name";
            // 
            // cdvModule
            // 
            this.cdvModule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvModule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvModule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvModule.BtnToolTipText = "";
            this.cdvModule.ButtonWidth = 20;
            this.cdvModule.DescText = "";
            this.cdvModule.DisplaySubItemIndex = 0;
            this.cdvModule.DisplayText = "";
            this.cdvModule.Focusing = null;
            this.cdvModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvModule.Index = 0;
            this.cdvModule.IsViewBtnImage = false;
            this.cdvModule.Location = new System.Drawing.Point(119, 106);
            this.cdvModule.MaxLength = 20;
            this.cdvModule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvModule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvModule.MultiSelect = false;
            this.cdvModule.Name = "cdvModule";
            this.cdvModule.ReadOnly = false;
            this.cdvModule.SameWidthHeightOfButton = false;
            this.cdvModule.SearchSubItemIndex = 0;
            this.cdvModule.SelectedDescIndex = -1;
            this.cdvModule.SelectedDescToQueryText = "";
            this.cdvModule.SelectedSubItemIndex = 0;
            this.cdvModule.SelectedValueToQueryText = "";
            this.cdvModule.SelectionStart = 0;
            this.cdvModule.Size = new System.Drawing.Size(150, 20);
            this.cdvModule.SmallImageList = null;
            this.cdvModule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvModule.TabIndex = 2;
            this.cdvModule.TextBoxToolTipText = "";
            this.cdvModule.TextBoxWidth = 150;
            this.cdvModule.VisibleButton = true;
            this.cdvModule.VisibleColumnHeader = false;
            this.cdvModule.VisibleDescription = false;
            this.cdvModule.ButtonPress += new System.EventHandler(this.cdvModule_ButtonPress);
            // 
            // tapScreen
            // 
            this.tapScreen.BackColor = System.Drawing.SystemColors.Control;
            this.tapScreen.Controls.Add(this.spdSpread);
            this.tapScreen.Location = new System.Drawing.Point(4, 22);
            this.tapScreen.Name = "tapScreen";
            this.tapScreen.Padding = new System.Windows.Forms.Padding(3);
            this.tapScreen.Size = new System.Drawing.Size(498, 480);
            this.tapScreen.TabIndex = 1;
            this.tapScreen.Text = "Screen";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(285, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 26);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnFromExcel
            // 
            this.btnFromExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromExcel.Enabled = false;
            this.btnFromExcel.Location = new System.Drawing.Point(376, 7);
            this.btnFromExcel.Name = "btnFromExcel";
            this.btnFromExcel.Size = new System.Drawing.Size(88, 26);
            this.btnFromExcel.TabIndex = 6;
            this.btnFromExcel.Text = "Load Excel";
            this.btnFromExcel.UseVisualStyleBackColor = true;
            this.btnFromExcel.Click += new System.EventHandler(this.btnFromExcel_Click);
            // 
            // frmBASSetupFlexibleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASSetupFlexibleScreen";
            this.Text = "Flexible Screen Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupFlexibleScreen_Activated);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvFactory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSGrp)).EndInit();
            this.grpScreenName.ResumeLayout(false);
            this.grpScreenName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvScreenGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread_Sheet1)).EndInit();
            this.tabScreen.ResumeLayout(false);
            this.tapGeneral.ResumeLayout(false);
            this.tapGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).EndInit();
            this.tapScreen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListTop;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSGrp;
        private System.Windows.Forms.Label lblSGrp;
        private Miracom.UI.Controls.MCListView.MCListView lisScreen;
        private System.Windows.Forms.ColumnHeader colScreenID;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.GroupBox grpScreenName;
        private System.Windows.Forms.TextBox txtScreenID;
        private System.Windows.Forms.TextBox txtScreenDesc;
        private System.Windows.Forms.Label lblAttrDesc;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvScreenGrp;
        private System.Windows.Forms.Label lblScreenGrp;
        private System.Windows.Forms.Label lblScreenID;
        private FarPoint.Win.Spread.FpSpread spdSpread;
        private FarPoint.Win.Spread.SheetView spdSpread_Sheet1;
        private System.Windows.Forms.TabControl tabScreen;
        private System.Windows.Forms.TabPage tapGeneral;
        private System.Windows.Forms.TabPage tapScreen;
        private System.Windows.Forms.Label lblService;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvService;
        private System.Windows.Forms.Label lblModule;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvModule;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Button btnEdit;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFactory;
        private System.Windows.Forms.Label lblFactory;
        private System.Windows.Forms.Button btnFromExcel;
        private System.Windows.Forms.OpenFileDialog ofdFile;
    }
}