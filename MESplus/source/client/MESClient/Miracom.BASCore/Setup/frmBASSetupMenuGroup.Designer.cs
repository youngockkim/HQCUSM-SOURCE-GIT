namespace Miracom.BASCore
{
    partial class frmBASSetupMenuGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASSetupMenuGroup));
            this.lisMenuGrp = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpSecGrp = new System.Windows.Forms.GroupBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtMenuGrp = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblMenuGrp = new System.Windows.Forms.Label();
            this.pnlUserMid = new System.Windows.Forms.Panel();
            this.pnlUserMidRight = new System.Windows.Forms.Panel();
            this.lisAvailFunc = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.cdvFGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnMenuRefresh = new System.Windows.Forms.Button();
            this.lblMenuList = new System.Windows.Forms.Label();
            this.pnlUserMidMid = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlUserMidLeft = new System.Windows.Forms.Panel();
            this.lisAttachedMenu = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFuncName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRequired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlGroupLabel = new System.Windows.Forms.Panel();
            this.btnAttachedRefresh = new System.Windows.Forms.Button();
            this.lblAttachedMenu = new System.Windows.Forms.Label();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvTranCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.lblTranCode = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.chkRequired = new System.Windows.Forms.CheckBox();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.tbpCopy = new System.Windows.Forms.TabPage();
            this.grpCopy = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblToFlow = new System.Windows.Forms.Label();
            this.txtToMenuGrp = new System.Windows.Forms.TextBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpSecGrp.SuspendLayout();
            this.pnlUserMid.SuspendLayout();
            this.pnlUserMidRight.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFGroup)).BeginInit();
            this.pnlUserMidMid.SuspendLayout();
            this.pnlUserMidLeft.SuspendLayout();
            this.pnlGroupLabel.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTranCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            this.tabMenu.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.tbpCopy.SuspendLayout();
            this.grpCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
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
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tabMenu);
            this.pnlRight.Controls.Add(this.grpSecGrp);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisMenuGrp);
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
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // lisMenuGrp
            // 
            this.lisMenuGrp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.columnHeader3});
            this.lisMenuGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMenuGrp.EnableSort = true;
            this.lisMenuGrp.EnableSortIcon = true;
            this.lisMenuGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMenuGrp.FullRowSelect = true;
            this.lisMenuGrp.HideSelection = false;
            this.lisMenuGrp.Location = new System.Drawing.Point(0, 0);
            this.lisMenuGrp.MultiSelect = false;
            this.lisMenuGrp.Name = "lisMenuGrp";
            this.lisMenuGrp.Size = new System.Drawing.Size(232, 506);
            this.lisMenuGrp.TabIndex = 0;
            this.lisMenuGrp.UseCompatibleStateImageBehavior = false;
            this.lisMenuGrp.View = System.Windows.Forms.View.Details;
            this.lisMenuGrp.SelectedIndexChanged += new System.EventHandler(this.lisMenuGrp_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Menu Group";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Group Category";
            // 
            // grpSecGrp
            // 
            this.grpSecGrp.Controls.Add(this.cboCategory);
            this.grpSecGrp.Controls.Add(this.txtDesc);
            this.grpSecGrp.Controls.Add(this.lblDesc);
            this.grpSecGrp.Controls.Add(this.txtMenuGrp);
            this.grpSecGrp.Controls.Add(this.lblCategory);
            this.grpSecGrp.Controls.Add(this.lblMenuGrp);
            this.grpSecGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSecGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSecGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpSecGrp.Location = new System.Drawing.Point(0, 0);
            this.grpSecGrp.Name = "grpSecGrp";
            this.grpSecGrp.Size = new System.Drawing.Size(506, 93);
            this.grpSecGrp.TabIndex = 0;
            this.grpSecGrp.TabStop = false;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "Setup",
            "Transaction",
            "Inquiry"});
            this.cboCategory.Location = new System.Drawing.Point(132, 17);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 21);
            this.cboCategory.TabIndex = 3;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(132, 64);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(363, 20);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // lblDesc
            // 
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDesc.Location = new System.Drawing.Point(15, 67);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 14);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMenuGrp
            // 
            this.txtMenuGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenuGrp.Location = new System.Drawing.Point(132, 41);
            this.txtMenuGrp.MaxLength = 30;
            this.txtMenuGrp.Name = "txtMenuGrp";
            this.txtMenuGrp.Size = new System.Drawing.Size(200, 20);
            this.txtMenuGrp.TabIndex = 0;
            this.txtMenuGrp.TextChanged += new System.EventHandler(this.txtMenuGrp_TextChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCategory.Location = new System.Drawing.Point(15, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(100, 14);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Group Category";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMenuGrp
            // 
            this.lblMenuGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMenuGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMenuGrp.Location = new System.Drawing.Point(15, 44);
            this.lblMenuGrp.Name = "lblMenuGrp";
            this.lblMenuGrp.Size = new System.Drawing.Size(100, 14);
            this.lblMenuGrp.TabIndex = 0;
            this.lblMenuGrp.Text = "Menu Group";
            this.lblMenuGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUserMid
            // 
            this.pnlUserMid.Controls.Add(this.pnlUserMidRight);
            this.pnlUserMid.Controls.Add(this.pnlUserMidMid);
            this.pnlUserMid.Controls.Add(this.pnlUserMidLeft);
            this.pnlUserMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserMid.Location = new System.Drawing.Point(3, 3);
            this.pnlUserMid.Name = "pnlUserMid";
            this.pnlUserMid.Size = new System.Drawing.Size(492, 340);
            this.pnlUserMid.TabIndex = 2;
            this.pnlUserMid.Resize += new System.EventHandler(this.pnlUserMid_Resize);
            // 
            // pnlUserMidRight
            // 
            this.pnlUserMidRight.Controls.Add(this.lisAvailFunc);
            this.pnlUserMidRight.Controls.Add(this.pnlMenu);
            this.pnlUserMidRight.Location = new System.Drawing.Point(272, 0);
            this.pnlUserMidRight.Name = "pnlUserMidRight";
            this.pnlUserMidRight.Size = new System.Drawing.Size(220, 340);
            this.pnlUserMidRight.TabIndex = 2;
            // 
            // lisAvailFunc
            // 
            this.lisAvailFunc.AllowDrop = true;
            this.lisAvailFunc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisAvailFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAvailFunc.EnableSort = true;
            this.lisAvailFunc.EnableSortIcon = true;
            this.lisAvailFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAvailFunc.FullRowSelect = true;
            this.lisAvailFunc.HideSelection = false;
            this.lisAvailFunc.Location = new System.Drawing.Point(0, 24);
            this.lisAvailFunc.Name = "lisAvailFunc";
            this.lisAvailFunc.Size = new System.Drawing.Size(220, 316);
            this.lisAvailFunc.TabIndex = 0;
            this.lisAvailFunc.UseCompatibleStateImageBehavior = false;
            this.lisAvailFunc.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "Function Name";
            this.ColumnHeader15.Width = 100;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.Text = "Description";
            this.ColumnHeader16.Width = 150;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.cdvFGroup);
            this.pnlMenu.Controls.Add(this.btnMenuRefresh);
            this.pnlMenu.Controls.Add(this.lblMenuList);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 24);
            this.pnlMenu.TabIndex = 3;
            // 
            // cdvFGroup
            // 
            this.cdvFGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFGroup.BtnToolTipText = "";
            this.cdvFGroup.DescText = "";
            this.cdvFGroup.DisplaySubItemIndex = -1;
            this.cdvFGroup.DisplayText = "";
            this.cdvFGroup.Focusing = null;
            this.cdvFGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFGroup.Index = 0;
            this.cdvFGroup.IsViewBtnImage = false;
            this.cdvFGroup.Location = new System.Drawing.Point(76, 2);
            this.cdvFGroup.MaxLength = 20;
            this.cdvFGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFGroup.Name = "cdvFGroup";
            this.cdvFGroup.ReadOnly = true;
            this.cdvFGroup.SearchSubItemIndex = 0;
            this.cdvFGroup.SelectedDescIndex = -1;
            this.cdvFGroup.SelectedSubItemIndex = -1;
            this.cdvFGroup.SelectionStart = 0;
            this.cdvFGroup.Size = new System.Drawing.Size(108, 20);
            this.cdvFGroup.SmallImageList = null;
            this.cdvFGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFGroup.TabIndex = 0;
            this.cdvFGroup.TextBoxToolTipText = "";
            this.cdvFGroup.TextBoxWidth = 108;
            this.cdvFGroup.VisibleButton = true;
            this.cdvFGroup.VisibleColumnHeader = false;
            this.cdvFGroup.VisibleDescription = false;
            this.cdvFGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFGroup_SelectedItemChanged);
            this.cdvFGroup.ButtonPress += new System.EventHandler(this.cdvFGroup_ButtonPress);
            // 
            // btnMenuRefresh
            // 
            this.btnMenuRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMenuRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenuRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuRefresh.Image")));
            this.btnMenuRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMenuRefresh.Location = new System.Drawing.Point(196, 0);
            this.btnMenuRefresh.Name = "btnMenuRefresh";
            this.btnMenuRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnMenuRefresh.TabIndex = 1;
            this.btnMenuRefresh.Click += new System.EventHandler(this.btnMenuRefresh_Click);
            // 
            // lblMenuList
            // 
            this.lblMenuList.AutoSize = true;
            this.lblMenuList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMenuList.Location = new System.Drawing.Point(3, 6);
            this.lblMenuList.Name = "lblMenuList";
            this.lblMenuList.Size = new System.Drawing.Size(48, 13);
            this.lblMenuList.TabIndex = 1;
            this.lblMenuList.Text = "All Menu";
            this.lblMenuList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUserMidMid
            // 
            this.pnlUserMidMid.Controls.Add(this.btnDown);
            this.pnlUserMidMid.Controls.Add(this.btnUp);
            this.pnlUserMidMid.Controls.Add(this.btnDel);
            this.pnlUserMidMid.Controls.Add(this.btnAdd);
            this.pnlUserMidMid.Location = new System.Drawing.Point(237, 13);
            this.pnlUserMidMid.Name = "pnlUserMidMid";
            this.pnlUserMidMid.Size = new System.Drawing.Size(34, 335);
            this.pnlUserMidMid.TabIndex = 1;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(5, 292);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(5, 266);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(5, 118);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(5, 89);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlUserMidLeft
            // 
            this.pnlUserMidLeft.Controls.Add(this.lisAttachedMenu);
            this.pnlUserMidLeft.Controls.Add(this.pnlGroupLabel);
            this.pnlUserMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlUserMidLeft.Name = "pnlUserMidLeft";
            this.pnlUserMidLeft.Size = new System.Drawing.Size(235, 340);
            this.pnlUserMidLeft.TabIndex = 0;
            // 
            // lisAttachedMenu
            // 
            this.lisAttachedMenu.AllowDrop = true;
            this.lisAttachedMenu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colFuncName,
            this.colRequired,
            this.colPriority,
            this.colTranCode});
            this.lisAttachedMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachedMenu.EnableSort = true;
            this.lisAttachedMenu.EnableSortIcon = true;
            this.lisAttachedMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachedMenu.FullRowSelect = true;
            this.lisAttachedMenu.HideSelection = false;
            this.lisAttachedMenu.Location = new System.Drawing.Point(0, 24);
            this.lisAttachedMenu.Name = "lisAttachedMenu";
            this.lisAttachedMenu.Size = new System.Drawing.Size(235, 316);
            this.lisAttachedMenu.TabIndex = 0;
            this.lisAttachedMenu.UseCompatibleStateImageBehavior = false;
            this.lisAttachedMenu.View = System.Windows.Forms.View.Details;
            this.lisAttachedMenu.SelectedIndexChanged += new System.EventHandler(this.lisAttachedMenu_SelectedIndexChanged);
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 35;
            // 
            // colFuncName
            // 
            this.colFuncName.Text = "Function Name";
            this.colFuncName.Width = 100;
            // 
            // colRequired
            // 
            this.colRequired.Text = "Required";
            // 
            // colPriority
            // 
            this.colPriority.Text = "Priority";
            // 
            // colTranCode
            // 
            this.colTranCode.Text = "Tran Code";
            this.colTranCode.Width = 100;
            // 
            // pnlGroupLabel
            // 
            this.pnlGroupLabel.Controls.Add(this.btnAttachedRefresh);
            this.pnlGroupLabel.Controls.Add(this.lblAttachedMenu);
            this.pnlGroupLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroupLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupLabel.Name = "pnlGroupLabel";
            this.pnlGroupLabel.Size = new System.Drawing.Size(235, 24);
            this.pnlGroupLabel.TabIndex = 3;
            // 
            // btnAttachedRefresh
            // 
            this.btnAttachedRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAttachedRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAttachedRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnAttachedRefresh.Image")));
            this.btnAttachedRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAttachedRefresh.Location = new System.Drawing.Point(211, 0);
            this.btnAttachedRefresh.Name = "btnAttachedRefresh";
            this.btnAttachedRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnAttachedRefresh.TabIndex = 0;
            this.btnAttachedRefresh.Click += new System.EventHandler(this.btnAttachedRefresh_Click);
            // 
            // lblAttachedMenu
            // 
            this.lblAttachedMenu.AutoSize = true;
            this.lblAttachedMenu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachedMenu.Location = new System.Drawing.Point(3, 6);
            this.lblAttachedMenu.Name = "lblAttachedMenu";
            this.lblAttachedMenu.Size = new System.Drawing.Size(80, 13);
            this.lblAttachedMenu.TabIndex = 0;
            this.lblAttachedMenu.Text = "Attached Menu";
            this.lblAttachedMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvTranCode);
            this.grpOption.Controls.Add(this.numPriority);
            this.grpOption.Controls.Add(this.lblTranCode);
            this.grpOption.Controls.Add(this.lblPriority);
            this.grpOption.Controls.Add(this.chkRequired);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpOption.Location = new System.Drawing.Point(3, 343);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(492, 41);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Option";
            // 
            // cdvTranCode
            // 
            this.cdvTranCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTranCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTranCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTranCode.BtnToolTipText = "";
            this.cdvTranCode.DescText = "";
            this.cdvTranCode.DisplaySubItemIndex = -1;
            this.cdvTranCode.DisplayText = "";
            this.cdvTranCode.Focusing = null;
            this.cdvTranCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTranCode.Index = 0;
            this.cdvTranCode.IsViewBtnImage = false;
            this.cdvTranCode.Location = new System.Drawing.Point(355, 15);
            this.cdvTranCode.MaxLength = 12;
            this.cdvTranCode.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTranCode.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTranCode.Name = "cdvTranCode";
            this.cdvTranCode.ReadOnly = true;
            this.cdvTranCode.SearchSubItemIndex = 0;
            this.cdvTranCode.SelectedDescIndex = -1;
            this.cdvTranCode.SelectedSubItemIndex = -1;
            this.cdvTranCode.SelectionStart = 0;
            this.cdvTranCode.Size = new System.Drawing.Size(128, 20);
            this.cdvTranCode.SmallImageList = null;
            this.cdvTranCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTranCode.TabIndex = 2;
            this.cdvTranCode.TextBoxToolTipText = "";
            this.cdvTranCode.TextBoxWidth = 128;
            this.cdvTranCode.VisibleButton = true;
            this.cdvTranCode.VisibleColumnHeader = false;
            this.cdvTranCode.VisibleDescription = false;
            // 
            // numPriority
            // 
            this.numPriority.Location = new System.Drawing.Point(196, 15);
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(53, 20);
            this.numPriority.TabIndex = 1;
            // 
            // lblTranCode
            // 
            this.lblTranCode.AutoSize = true;
            this.lblTranCode.Location = new System.Drawing.Point(278, 18);
            this.lblTranCode.Name = "lblTranCode";
            this.lblTranCode.Size = new System.Drawing.Size(57, 13);
            this.lblTranCode.TabIndex = 2;
            this.lblTranCode.Text = "Tran Code";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(133, 18);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(38, 13);
            this.lblPriority.TabIndex = 1;
            this.lblPriority.Text = "Priority";
            // 
            // chkRequired
            // 
            this.chkRequired.AutoSize = true;
            this.chkRequired.Location = new System.Drawing.Point(15, 17);
            this.chkRequired.Name = "chkRequired";
            this.chkRequired.Size = new System.Drawing.Size(102, 16);
            this.chkRequired.TabIndex = 0;
            this.chkRequired.Text = "Required Flag";
            this.chkRequired.UseVisualStyleBackColor = true;
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.tbpGeneral);
            this.tabMenu.Controls.Add(this.tbpCopy);
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Location = new System.Drawing.Point(0, 93);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(506, 413);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.SelectedIndexChanged += new System.EventHandler(this.tabMenu_SelectedIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlUserMid);
            this.tbpGeneral.Controls.Add(this.grpOption);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(498, 387);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // tbpCopy
            // 
            this.tbpCopy.Controls.Add(this.grpCopy);
            this.tbpCopy.Location = new System.Drawing.Point(4, 22);
            this.tbpCopy.Name = "tbpCopy";
            this.tbpCopy.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCopy.Size = new System.Drawing.Size(498, 387);
            this.tbpCopy.TabIndex = 1;
            this.tbpCopy.Text = "Copy Menu Group";
            // 
            // grpCopy
            // 
            this.grpCopy.Controls.Add(this.btnCopy);
            this.grpCopy.Controls.Add(this.lblToFlow);
            this.grpCopy.Controls.Add(this.txtToMenuGrp);
            this.grpCopy.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopy.Location = new System.Drawing.Point(3, 3);
            this.grpCopy.Name = "grpCopy";
            this.grpCopy.Size = new System.Drawing.Size(492, 47);
            this.grpCopy.TabIndex = 1;
            this.grpCopy.TabStop = false;
            this.grpCopy.Text = "Copy Menu Group";
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(318, 15);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(80, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblToFlow
            // 
            this.lblToFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToFlow.Location = new System.Drawing.Point(20, 19);
            this.lblToFlow.Name = "lblToFlow";
            this.lblToFlow.Size = new System.Drawing.Size(88, 14);
            this.lblToFlow.TabIndex = 0;
            this.lblToFlow.Text = "To Menu Group";
            this.lblToFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToMenuGrp
            // 
            this.txtToMenuGrp.Location = new System.Drawing.Point(115, 16);
            this.txtToMenuGrp.MaxLength = 30;
            this.txtToMenuGrp.Name = "txtToMenuGrp";
            this.txtToMenuGrp.Size = new System.Drawing.Size(200, 20);
            this.txtToMenuGrp.TabIndex = 0;
            // 
            // frmBASSetupMenuGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASSetupMenuGroup";
            this.Text = "Menu Group Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupMenuGroup_Activated);
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
            this.grpSecGrp.ResumeLayout(false);
            this.grpSecGrp.PerformLayout();
            this.pnlUserMid.ResumeLayout(false);
            this.pnlUserMidRight.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFGroup)).EndInit();
            this.pnlUserMidMid.ResumeLayout(false);
            this.pnlUserMidLeft.ResumeLayout(false);
            this.pnlGroupLabel.ResumeLayout(false);
            this.pnlGroupLabel.PerformLayout();
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTranCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            this.tabMenu.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.tbpCopy.ResumeLayout(false);
            this.grpCopy.ResumeLayout(false);
            this.grpCopy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.MCListView.MCListView lisMenuGrp;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox grpSecGrp;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtMenuGrp;
        private System.Windows.Forms.Label lblMenuGrp;
        private System.Windows.Forms.Panel pnlUserMid;
        private System.Windows.Forms.Panel pnlUserMidRight;
        private UI.Controls.MCListView.MCListView lisAvailFunc;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.ColumnHeader ColumnHeader16;
        private System.Windows.Forms.Panel pnlMenu;
        protected System.Windows.Forms.Button btnMenuRefresh;
        private System.Windows.Forms.Label lblMenuList;
        private System.Windows.Forms.Panel pnlUserMidMid;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlUserMidLeft;
        private UI.Controls.MCListView.MCListView lisAttachedMenu;
        private System.Windows.Forms.ColumnHeader colFuncName;
        private System.Windows.Forms.ColumnHeader colRequired;
        private System.Windows.Forms.Panel pnlGroupLabel;
        protected System.Windows.Forms.Button btnAttachedRefresh;
        private System.Windows.Forms.Label lblAttachedMenu;
        private UI.Controls.MCCodeView.MCCodeView cdvFGroup;
        private System.Windows.Forms.GroupBox grpOption;
        private UI.Controls.MCCodeView.MCCodeView cdvTranCode;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.Label lblTranCode;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.CheckBox chkRequired;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.ColumnHeader colTranCode;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpCopy;
        private System.Windows.Forms.GroupBox grpCopy;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblToFlow;
        private System.Windows.Forms.TextBox txtToMenuGrp;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}