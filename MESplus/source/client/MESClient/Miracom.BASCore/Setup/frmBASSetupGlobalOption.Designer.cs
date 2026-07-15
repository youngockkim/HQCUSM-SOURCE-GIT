namespace Miracom.BASCore
{
    partial class frmBASSetupGlobalOption
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
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASSetupGlobalOption));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.lblDataCountBase = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.tbpOption = new System.Windows.Forms.TabPage();
            this.pnlOption = new System.Windows.Forms.Panel();
            this.lisGOption = new Miracom.UI.Controls.MCListView.MCListView();
            this.colOptionName2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOptionDesc2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpOptionDefinition = new System.Windows.Forms.GroupBox();
            this.chkMESplusOption = new System.Windows.Forms.CheckBox();
            this.cdvOptionName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtOptionDescDefinition = new System.Windows.Forms.TextBox();
            this.lblDEFDesc = new System.Windows.Forms.Label();
            this.lblDEFName = new System.Windows.Forms.Label();
            this.txtDEFUpdateTime = new System.Windows.Forms.TextBox();
            this.txtDEFCreateTime = new System.Windows.Forms.TextBox();
            this.txtDEFUpdateUser = new System.Windows.Forms.TextBox();
            this.lblDEFUpdate = new System.Windows.Forms.Label();
            this.txtDEFCreateUser = new System.Windows.Forms.TextBox();
            this.lblDEFCreate = new System.Windows.Forms.Label();
            this.grpValueDefinition = new System.Windows.Forms.GroupBox();
            this.cdvValue5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvValue4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValue5 = new System.Windows.Forms.Label();
            this.lblValue4 = new System.Windows.Forms.Label();
            this.cdvValue3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvValue2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvValue1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValue3 = new System.Windows.Forms.Label();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.tbpPrompt = new System.Windows.Forms.TabPage();
            this.pnlPrompt = new System.Windows.Forms.Panel();
            this.grbValuePrompt = new System.Windows.Forms.GroupBox();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grbGeneral = new System.Windows.Forms.GroupBox();
            this.chkMESplusPmtFlag = new System.Windows.Forms.CheckBox();
            this.txtOptionDescPrompt = new System.Windows.Forms.TextBox();
            this.lblPMTDesc = new System.Windows.Forms.Label();
            this.txtOptionName = new System.Windows.Forms.TextBox();
            this.lblPMTName = new System.Windows.Forms.Label();
            this.txtPMTUpdateTime = new System.Windows.Forms.TextBox();
            this.txtPMTCreateTime = new System.Windows.Forms.TextBox();
            this.txtPMTUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtPMTCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lisOption = new Miracom.UI.Controls.MCListView.MCListView();
            this.colOptionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOptionDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabOption = new System.Windows.Forms.TabControl();
            this.cdvGCMTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlFind.SuspendLayout();
            this.tbpOption.SuspendLayout();
            this.pnlOption.SuspendLayout();
            this.grpOptionDefinition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionName)).BeginInit();
            this.grpValueDefinition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue1)).BeginInit();
            this.tbpPrompt.SuspendLayout();
            this.pnlPrompt.SuspendLayout();
            this.grbValuePrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.grbGeneral.SuspendLayout();
            this.tabOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGCMTableList)).BeginInit();
            this.SuspendLayout();
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
            this.pnlBottom.Controls.Add(this.pnlFind);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabOption);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm01";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            // 
            // pnlFind
            // 
            this.pnlFind.Controls.Add(this.lblDataCount);
            this.pnlFind.Controls.Add(this.lblDataCountBase);
            this.pnlFind.Controls.Add(this.btnExcel);
            this.pnlFind.Controls.Add(this.btnRefresh);
            this.pnlFind.Controls.Add(this.btnNext);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFind.Location = new System.Drawing.Point(0, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(228, 40);
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCount.Location = new System.Drawing.Point(5, 13);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(40, 12);
            this.lblDataCount.TabIndex = 1;
            this.lblDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataCountBase
            // 
            this.lblDataCountBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDataCountBase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCountBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCountBase.Location = new System.Drawing.Point(4, 9);
            this.lblDataCountBase.Name = "lblDataCountBase";
            this.lblDataCountBase.Size = new System.Drawing.Size(42, 21);
            this.lblDataCountBase.TabIndex = 0;
            this.lblDataCountBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(200, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(174, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(148, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 3;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(48, 9);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(96, 20);
            this.txtFind.TabIndex = 2;
            // 
            // tbpOption
            // 
            this.tbpOption.BackColor = System.Drawing.SystemColors.Control;
            this.tbpOption.Controls.Add(this.pnlOption);
            this.tbpOption.Location = new System.Drawing.Point(4, 22);
            this.tbpOption.Name = "tbpOption";
            this.tbpOption.Size = new System.Drawing.Size(734, 480);
            this.tbpOption.TabIndex = 1;
            this.tbpOption.Text = "Option Setup";
            this.tbpOption.Visible = false;
            // 
            // pnlOption
            // 
            this.pnlOption.Controls.Add(this.lisGOption);
            this.pnlOption.Controls.Add(this.grpOptionDefinition);
            this.pnlOption.Controls.Add(this.grpValueDefinition);
            this.pnlOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOption.Location = new System.Drawing.Point(0, 0);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlOption.Size = new System.Drawing.Size(734, 480);
            this.pnlOption.TabIndex = 0;
            // 
            // lisGOption
            // 
            this.lisGOption.BackColor = System.Drawing.SystemColors.Window;
            this.lisGOption.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOptionName2,
            this.colOptionDesc2,
            this.colValue1,
            this.colValue2,
            this.colValue3,
            this.colValue4,
            this.colValue5});
            this.lisGOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisGOption.EnableSort = true;
            this.lisGOption.EnableSortIcon = true;
            this.lisGOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisGOption.FullRowSelect = true;
            this.lisGOption.HideSelection = false;
            this.lisGOption.Location = new System.Drawing.Point(3, 0);
            this.lisGOption.MultiSelect = false;
            this.lisGOption.Name = "lisGOption";
            this.lisGOption.Size = new System.Drawing.Size(728, 272);
            this.lisGOption.TabIndex = 0;
            this.lisGOption.UseCompatibleStateImageBehavior = false;
            this.lisGOption.View = System.Windows.Forms.View.Details;
            this.lisGOption.SelectedIndexChanged += new System.EventHandler(this.lisGOption_SelectedIndexChanged);
            // 
            // colOptionName2
            // 
            this.colOptionName2.Text = "Option Name";
            this.colOptionName2.Width = 150;
            // 
            // colOptionDesc2
            // 
            this.colOptionDesc2.Text = "Description";
            this.colOptionDesc2.Width = 210;
            // 
            // colValue1
            // 
            this.colValue1.Text = "Value 1";
            this.colValue1.Width = 70;
            // 
            // colValue2
            // 
            this.colValue2.Text = "Value 2";
            this.colValue2.Width = 70;
            // 
            // colValue3
            // 
            this.colValue3.Text = "Value 3";
            this.colValue3.Width = 70;
            // 
            // colValue4
            // 
            this.colValue4.Text = "Value 4";
            this.colValue4.Width = 70;
            // 
            // colValue5
            // 
            this.colValue5.Text = "Value 5";
            this.colValue5.Width = 70;
            // 
            // grpOptionDefinition
            // 
            this.grpOptionDefinition.Controls.Add(this.chkMESplusOption);
            this.grpOptionDefinition.Controls.Add(this.cdvOptionName);
            this.grpOptionDefinition.Controls.Add(this.txtOptionDescDefinition);
            this.grpOptionDefinition.Controls.Add(this.lblDEFDesc);
            this.grpOptionDefinition.Controls.Add(this.lblDEFName);
            this.grpOptionDefinition.Controls.Add(this.txtDEFUpdateTime);
            this.grpOptionDefinition.Controls.Add(this.txtDEFCreateTime);
            this.grpOptionDefinition.Controls.Add(this.txtDEFUpdateUser);
            this.grpOptionDefinition.Controls.Add(this.lblDEFUpdate);
            this.grpOptionDefinition.Controls.Add(this.txtDEFCreateUser);
            this.grpOptionDefinition.Controls.Add(this.lblDEFCreate);
            this.grpOptionDefinition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpOptionDefinition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOptionDefinition.Location = new System.Drawing.Point(3, 272);
            this.grpOptionDefinition.Name = "grpOptionDefinition";
            this.grpOptionDefinition.Size = new System.Drawing.Size(728, 114);
            this.grpOptionDefinition.TabIndex = 1;
            this.grpOptionDefinition.TabStop = false;
            // 
            // chkMESplusOption
            // 
            this.chkMESplusOption.AutoSize = true;
            this.chkMESplusOption.Enabled = false;
            this.chkMESplusOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMESplusOption.Location = new System.Drawing.Point(486, 15);
            this.chkMESplusOption.Name = "chkMESplusOption";
            this.chkMESplusOption.Size = new System.Drawing.Size(121, 17);
            this.chkMESplusOption.TabIndex = 12;
            this.chkMESplusOption.Text = "MESplus Option";
            // 
            // cdvOptionName
            // 
            this.cdvOptionName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOptionName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOptionName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOptionName.BtnToolTipText = "";
            this.cdvOptionName.DescText = "";
            this.cdvOptionName.DisplaySubItemIndex = -1;
            this.cdvOptionName.DisplayText = "";
            this.cdvOptionName.Focusing = null;
            this.cdvOptionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOptionName.Index = 0;
            this.cdvOptionName.IsViewBtnImage = false;
            this.cdvOptionName.Location = new System.Drawing.Point(116, 13);
            this.cdvOptionName.MaxLength = 30;
            this.cdvOptionName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOptionName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOptionName.Name = "cdvOptionName";
            this.cdvOptionName.ReadOnly = false;
            this.cdvOptionName.SearchSubItemIndex = 0;
            this.cdvOptionName.SelectedDescIndex = -1;
            this.cdvOptionName.SelectedSubItemIndex = -1;
            this.cdvOptionName.SelectionStart = 0;
            this.cdvOptionName.Size = new System.Drawing.Size(364, 20);
            this.cdvOptionName.SmallImageList = null;
            this.cdvOptionName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOptionName.TabIndex = 1;
            this.cdvOptionName.TextBoxToolTipText = "";
            this.cdvOptionName.TextBoxWidth = 364;
            this.cdvOptionName.VisibleButton = true;
            this.cdvOptionName.VisibleColumnHeader = false;
            this.cdvOptionName.VisibleDescription = false;
            this.cdvOptionName.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOptionName_SelectedItemChanged);
            this.cdvOptionName.ButtonPress += new System.EventHandler(this.cdvOptionName_ButtonPress);
            this.cdvOptionName.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvOptionName_TextBoxKeyPress);
            // 
            // txtOptionDescDefinition
            // 
            this.txtOptionDescDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOptionDescDefinition.Location = new System.Drawing.Point(116, 37);
            this.txtOptionDescDefinition.MaxLength = 200;
            this.txtOptionDescDefinition.Name = "txtOptionDescDefinition";
            this.txtOptionDescDefinition.Size = new System.Drawing.Size(606, 20);
            this.txtOptionDescDefinition.TabIndex = 5;
            // 
            // lblDEFDesc
            // 
            this.lblDEFDesc.AutoSize = true;
            this.lblDEFDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDEFDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEFDesc.Location = new System.Drawing.Point(15, 40);
            this.lblDEFDesc.Name = "lblDEFDesc";
            this.lblDEFDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDEFDesc.TabIndex = 4;
            this.lblDEFDesc.Text = "Description";
            this.lblDEFDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDEFName
            // 
            this.lblDEFName.AutoSize = true;
            this.lblDEFName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDEFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDEFName.Location = new System.Drawing.Point(15, 16);
            this.lblDEFName.Name = "lblDEFName";
            this.lblDEFName.Size = new System.Drawing.Size(80, 13);
            this.lblDEFName.TabIndex = 0;
            this.lblDEFName.Text = "Option Name";
            this.lblDEFName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDEFUpdateTime
            // 
            this.txtDEFUpdateTime.Location = new System.Drawing.Point(300, 87);
            this.txtDEFUpdateTime.MaxLength = 30;
            this.txtDEFUpdateTime.Name = "txtDEFUpdateTime";
            this.txtDEFUpdateTime.ReadOnly = true;
            this.txtDEFUpdateTime.Size = new System.Drawing.Size(180, 20);
            this.txtDEFUpdateTime.TabIndex = 11;
            this.txtDEFUpdateTime.TabStop = false;
            // 
            // txtDEFCreateTime
            // 
            this.txtDEFCreateTime.Location = new System.Drawing.Point(300, 62);
            this.txtDEFCreateTime.MaxLength = 30;
            this.txtDEFCreateTime.Name = "txtDEFCreateTime";
            this.txtDEFCreateTime.ReadOnly = true;
            this.txtDEFCreateTime.Size = new System.Drawing.Size(180, 20);
            this.txtDEFCreateTime.TabIndex = 8;
            this.txtDEFCreateTime.TabStop = false;
            // 
            // txtDEFUpdateUser
            // 
            this.txtDEFUpdateUser.Location = new System.Drawing.Point(116, 87);
            this.txtDEFUpdateUser.MaxLength = 20;
            this.txtDEFUpdateUser.Name = "txtDEFUpdateUser";
            this.txtDEFUpdateUser.ReadOnly = true;
            this.txtDEFUpdateUser.Size = new System.Drawing.Size(180, 20);
            this.txtDEFUpdateUser.TabIndex = 10;
            this.txtDEFUpdateUser.TabStop = false;
            // 
            // lblDEFUpdate
            // 
            this.lblDEFUpdate.AutoSize = true;
            this.lblDEFUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDEFUpdate.Location = new System.Drawing.Point(15, 90);
            this.lblDEFUpdate.Name = "lblDEFUpdate";
            this.lblDEFUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblDEFUpdate.TabIndex = 9;
            this.lblDEFUpdate.Text = "Update User/Time";
            this.lblDEFUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDEFCreateUser
            // 
            this.txtDEFCreateUser.Location = new System.Drawing.Point(116, 62);
            this.txtDEFCreateUser.MaxLength = 20;
            this.txtDEFCreateUser.Name = "txtDEFCreateUser";
            this.txtDEFCreateUser.ReadOnly = true;
            this.txtDEFCreateUser.Size = new System.Drawing.Size(180, 20);
            this.txtDEFCreateUser.TabIndex = 7;
            this.txtDEFCreateUser.TabStop = false;
            // 
            // lblDEFCreate
            // 
            this.lblDEFCreate.AutoSize = true;
            this.lblDEFCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDEFCreate.Location = new System.Drawing.Point(15, 65);
            this.lblDEFCreate.Name = "lblDEFCreate";
            this.lblDEFCreate.Size = new System.Drawing.Size(91, 13);
            this.lblDEFCreate.TabIndex = 6;
            this.lblDEFCreate.Text = "Create User/Time";
            this.lblDEFCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpValueDefinition
            // 
            this.grpValueDefinition.Controls.Add(this.cdvValue5);
            this.grpValueDefinition.Controls.Add(this.cdvValue4);
            this.grpValueDefinition.Controls.Add(this.lblValue5);
            this.grpValueDefinition.Controls.Add(this.lblValue4);
            this.grpValueDefinition.Controls.Add(this.cdvValue3);
            this.grpValueDefinition.Controls.Add(this.cdvValue2);
            this.grpValueDefinition.Controls.Add(this.cdvValue1);
            this.grpValueDefinition.Controls.Add(this.lblValue3);
            this.grpValueDefinition.Controls.Add(this.lblValue2);
            this.grpValueDefinition.Controls.Add(this.lblValue1);
            this.grpValueDefinition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpValueDefinition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpValueDefinition.Location = new System.Drawing.Point(3, 386);
            this.grpValueDefinition.Name = "grpValueDefinition";
            this.grpValueDefinition.Size = new System.Drawing.Size(728, 94);
            this.grpValueDefinition.TabIndex = 2;
            this.grpValueDefinition.TabStop = false;
            // 
            // cdvValue5
            // 
            this.cdvValue5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue5.BtnToolTipText = "";
            this.cdvValue5.DescText = "";
            this.cdvValue5.DisplaySubItemIndex = -1;
            this.cdvValue5.DisplayText = "";
            this.cdvValue5.Focusing = null;
            this.cdvValue5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue5.Index = 0;
            this.cdvValue5.IsViewBtnImage = false;
            this.cdvValue5.Location = new System.Drawing.Point(548, 41);
            this.cdvValue5.MaxLength = 30;
            this.cdvValue5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue5.Name = "cdvValue5";
            this.cdvValue5.ReadOnly = false;
            this.cdvValue5.SearchSubItemIndex = 0;
            this.cdvValue5.SelectedDescIndex = -1;
            this.cdvValue5.SelectedSubItemIndex = -1;
            this.cdvValue5.SelectionStart = 0;
            this.cdvValue5.Size = new System.Drawing.Size(165, 20);
            this.cdvValue5.SmallImageList = null;
            this.cdvValue5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue5.TabIndex = 9;
            this.cdvValue5.TextBoxToolTipText = "";
            this.cdvValue5.TextBoxWidth = 165;
            this.cdvValue5.VisibleButton = true;
            this.cdvValue5.VisibleColumnHeader = false;
            this.cdvValue5.VisibleDescription = false;
            this.cdvValue5.ButtonPress += new System.EventHandler(this.cdvValue_ButtonPress);
            this.cdvValue5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvValue_TextBoxKeyPress);
            // 
            // cdvValue4
            // 
            this.cdvValue4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue4.BtnToolTipText = "";
            this.cdvValue4.DescText = "";
            this.cdvValue4.DisplaySubItemIndex = -1;
            this.cdvValue4.DisplayText = "";
            this.cdvValue4.Focusing = null;
            this.cdvValue4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue4.Index = 0;
            this.cdvValue4.IsViewBtnImage = false;
            this.cdvValue4.Location = new System.Drawing.Point(548, 16);
            this.cdvValue4.MaxLength = 30;
            this.cdvValue4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue4.Name = "cdvValue4";
            this.cdvValue4.ReadOnly = false;
            this.cdvValue4.SearchSubItemIndex = 0;
            this.cdvValue4.SelectedDescIndex = -1;
            this.cdvValue4.SelectedSubItemIndex = -1;
            this.cdvValue4.SelectionStart = 0;
            this.cdvValue4.Size = new System.Drawing.Size(165, 20);
            this.cdvValue4.SmallImageList = null;
            this.cdvValue4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue4.TabIndex = 7;
            this.cdvValue4.TextBoxToolTipText = "";
            this.cdvValue4.TextBoxWidth = 165;
            this.cdvValue4.VisibleButton = true;
            this.cdvValue4.VisibleColumnHeader = false;
            this.cdvValue4.VisibleDescription = false;
            this.cdvValue4.ButtonPress += new System.EventHandler(this.cdvValue_ButtonPress);
            this.cdvValue4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvValue_TextBoxKeyPress);
            // 
            // lblValue5
            // 
            this.lblValue5.AutoSize = true;
            this.lblValue5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue5.Location = new System.Drawing.Point(376, 44);
            this.lblValue5.Name = "lblValue5";
            this.lblValue5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValue5.Size = new System.Drawing.Size(43, 13);
            this.lblValue5.TabIndex = 8;
            this.lblValue5.Text = "Value 5";
            this.lblValue5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValue5.Visible = false;
            // 
            // lblValue4
            // 
            this.lblValue4.AutoSize = true;
            this.lblValue4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue4.Location = new System.Drawing.Point(376, 19);
            this.lblValue4.Name = "lblValue4";
            this.lblValue4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValue4.Size = new System.Drawing.Size(43, 13);
            this.lblValue4.TabIndex = 6;
            this.lblValue4.Text = "Value 4";
            this.lblValue4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValue4.Visible = false;
            // 
            // cdvValue3
            // 
            this.cdvValue3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue3.BtnToolTipText = "";
            this.cdvValue3.DescText = "";
            this.cdvValue3.DisplaySubItemIndex = -1;
            this.cdvValue3.DisplayText = "";
            this.cdvValue3.Focusing = null;
            this.cdvValue3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue3.Index = 0;
            this.cdvValue3.IsViewBtnImage = false;
            this.cdvValue3.Location = new System.Drawing.Point(187, 66);
            this.cdvValue3.MaxLength = 30;
            this.cdvValue3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue3.Name = "cdvValue3";
            this.cdvValue3.ReadOnly = false;
            this.cdvValue3.SearchSubItemIndex = 0;
            this.cdvValue3.SelectedDescIndex = -1;
            this.cdvValue3.SelectedSubItemIndex = -1;
            this.cdvValue3.SelectionStart = 0;
            this.cdvValue3.Size = new System.Drawing.Size(165, 20);
            this.cdvValue3.SmallImageList = null;
            this.cdvValue3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue3.TabIndex = 5;
            this.cdvValue3.TextBoxToolTipText = "";
            this.cdvValue3.TextBoxWidth = 165;
            this.cdvValue3.VisibleButton = true;
            this.cdvValue3.VisibleColumnHeader = false;
            this.cdvValue3.VisibleDescription = false;
            this.cdvValue3.ButtonPress += new System.EventHandler(this.cdvValue_ButtonPress);
            this.cdvValue3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvValue_TextBoxKeyPress);
            // 
            // cdvValue2
            // 
            this.cdvValue2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue2.BtnToolTipText = "";
            this.cdvValue2.DescText = "";
            this.cdvValue2.DisplaySubItemIndex = -1;
            this.cdvValue2.DisplayText = "";
            this.cdvValue2.Focusing = null;
            this.cdvValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue2.Index = 0;
            this.cdvValue2.IsViewBtnImage = false;
            this.cdvValue2.Location = new System.Drawing.Point(187, 41);
            this.cdvValue2.MaxLength = 30;
            this.cdvValue2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue2.Name = "cdvValue2";
            this.cdvValue2.ReadOnly = false;
            this.cdvValue2.SearchSubItemIndex = 0;
            this.cdvValue2.SelectedDescIndex = -1;
            this.cdvValue2.SelectedSubItemIndex = -1;
            this.cdvValue2.SelectionStart = 0;
            this.cdvValue2.Size = new System.Drawing.Size(165, 20);
            this.cdvValue2.SmallImageList = null;
            this.cdvValue2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue2.TabIndex = 3;
            this.cdvValue2.TextBoxToolTipText = "";
            this.cdvValue2.TextBoxWidth = 165;
            this.cdvValue2.VisibleButton = true;
            this.cdvValue2.VisibleColumnHeader = false;
            this.cdvValue2.VisibleDescription = false;
            this.cdvValue2.ButtonPress += new System.EventHandler(this.cdvValue_ButtonPress);
            this.cdvValue2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvValue_TextBoxKeyPress);
            // 
            // cdvValue1
            // 
            this.cdvValue1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue1.BtnToolTipText = "";
            this.cdvValue1.DescText = "";
            this.cdvValue1.DisplaySubItemIndex = -1;
            this.cdvValue1.DisplayText = "";
            this.cdvValue1.Focusing = null;
            this.cdvValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue1.Index = 0;
            this.cdvValue1.IsViewBtnImage = false;
            this.cdvValue1.Location = new System.Drawing.Point(187, 16);
            this.cdvValue1.MaxLength = 30;
            this.cdvValue1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue1.Name = "cdvValue1";
            this.cdvValue1.ReadOnly = false;
            this.cdvValue1.SearchSubItemIndex = 0;
            this.cdvValue1.SelectedDescIndex = -1;
            this.cdvValue1.SelectedSubItemIndex = -1;
            this.cdvValue1.SelectionStart = 0;
            this.cdvValue1.Size = new System.Drawing.Size(165, 20);
            this.cdvValue1.SmallImageList = null;
            this.cdvValue1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue1.TabIndex = 1;
            this.cdvValue1.TextBoxToolTipText = "";
            this.cdvValue1.TextBoxWidth = 165;
            this.cdvValue1.VisibleButton = true;
            this.cdvValue1.VisibleColumnHeader = false;
            this.cdvValue1.VisibleDescription = false;
            this.cdvValue1.ButtonPress += new System.EventHandler(this.cdvValue_ButtonPress);
            this.cdvValue1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvValue_TextBoxKeyPress);
            // 
            // lblValue3
            // 
            this.lblValue3.AutoSize = true;
            this.lblValue3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue3.Location = new System.Drawing.Point(15, 69);
            this.lblValue3.Name = "lblValue3";
            this.lblValue3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValue3.Size = new System.Drawing.Size(43, 13);
            this.lblValue3.TabIndex = 4;
            this.lblValue3.Text = "Value 3";
            this.lblValue3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValue3.Visible = false;
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue2.Location = new System.Drawing.Point(15, 44);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValue2.Size = new System.Drawing.Size(43, 13);
            this.lblValue2.TabIndex = 2;
            this.lblValue2.Text = "Value 2";
            this.lblValue2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValue2.Visible = false;
            // 
            // lblValue1
            // 
            this.lblValue1.AutoSize = true;
            this.lblValue1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue1.Location = new System.Drawing.Point(15, 19);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValue1.Size = new System.Drawing.Size(43, 13);
            this.lblValue1.TabIndex = 0;
            this.lblValue1.Text = "Value 1";
            this.lblValue1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValue1.Visible = false;
            // 
            // tbpPrompt
            // 
            this.tbpPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.tbpPrompt.Controls.Add(this.pnlPrompt);
            this.tbpPrompt.Controls.Add(this.splitter1);
            this.tbpPrompt.Controls.Add(this.lisOption);
            this.tbpPrompt.Location = new System.Drawing.Point(4, 22);
            this.tbpPrompt.Name = "tbpPrompt";
            this.tbpPrompt.Size = new System.Drawing.Size(734, 480);
            this.tbpPrompt.TabIndex = 0;
            this.tbpPrompt.Text = "Option Prompt";
            // 
            // pnlPrompt
            // 
            this.pnlPrompt.Controls.Add(this.grbValuePrompt);
            this.pnlPrompt.Controls.Add(this.grbGeneral);
            this.pnlPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrompt.Location = new System.Drawing.Point(227, 0);
            this.pnlPrompt.Name = "pnlPrompt";
            this.pnlPrompt.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlPrompt.Size = new System.Drawing.Size(507, 480);
            this.pnlPrompt.TabIndex = 0;
            // 
            // grbValuePrompt
            // 
            this.grbValuePrompt.Controls.Add(this.spdData);
            this.grbValuePrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbValuePrompt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbValuePrompt.Location = new System.Drawing.Point(3, 140);
            this.grbValuePrompt.Name = "grbValuePrompt";
            this.grbValuePrompt.Size = new System.Drawing.Size(501, 340);
            this.grbValuePrompt.TabIndex = 1;
            this.grbValuePrompt.TabStop = false;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.EditModePermanent = true;
            this.spdData.EditModeReplace = true;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 10;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(3, 16);
            this.spdData.Name = "spdData";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer3;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer3;
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
            this.spdData.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(495, 321);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 11;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.spdData_LeaveCell);
            this.spdData.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_ButtonClicked);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 4;
            spdData_Sheet1.RowCount = 5;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Format";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Table";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            textCellType1.MaxLength = 20;
            this.spdData_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 190F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "Ascii",
        "Number",
        "Float"};
            comboBoxCellType1.MaxDrop = 3;
            comboBoxCellType1.MaxLength = 6;
            this.spdData_Sheet1.Columns.Get(1).CellType = comboBoxCellType1;
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(1).Label = "Format";
            this.spdData_Sheet1.Columns.Get(1).Locked = false;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType2.MaxLength = 20;
            this.spdData_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(2).Label = "Table";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).Width = 170F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdData_Sheet1.Columns.Get(3).CellType = buttonCellType1;
            this.spdData_Sheet1.Columns.Get(3).Width = 20F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Cells.Get(0, 0).Value = "Value 1";
            this.spdData_Sheet1.RowHeader.Cells.Get(1, 0).Value = "Value 2";
            this.spdData_Sheet1.RowHeader.Cells.Get(2, 0).Value = "Value 3";
            this.spdData_Sheet1.RowHeader.Cells.Get(3, 0).Value = "Value 4";
            this.spdData_Sheet1.RowHeader.Cells.Get(4, 0).Value = "Value 5";
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.Columns.Get(0).Width = 50F;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Get(0).Height = 18F;
            this.spdData_Sheet1.Rows.Get(0).Label = "Value 1";
            this.spdData_Sheet1.Rows.Get(1).Height = 18F;
            this.spdData_Sheet1.Rows.Get(1).Label = "Value 2";
            this.spdData_Sheet1.Rows.Get(2).Height = 18F;
            this.spdData_Sheet1.Rows.Get(2).Label = "Value 3";
            this.spdData_Sheet1.Rows.Get(3).Height = 18F;
            this.spdData_Sheet1.Rows.Get(3).Label = "Value 4";
            this.spdData_Sheet1.Rows.Get(4).Height = 18F;
            this.spdData_Sheet1.Rows.Get(4).Label = "Value 5";
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grbGeneral
            // 
            this.grbGeneral.Controls.Add(this.chkMESplusPmtFlag);
            this.grbGeneral.Controls.Add(this.txtOptionDescPrompt);
            this.grbGeneral.Controls.Add(this.lblPMTDesc);
            this.grbGeneral.Controls.Add(this.txtOptionName);
            this.grbGeneral.Controls.Add(this.lblPMTName);
            this.grbGeneral.Controls.Add(this.txtPMTUpdateTime);
            this.grbGeneral.Controls.Add(this.txtPMTCreateTime);
            this.grbGeneral.Controls.Add(this.txtPMTUpdateUser);
            this.grbGeneral.Controls.Add(this.lblUpdate);
            this.grbGeneral.Controls.Add(this.txtPMTCreateUser);
            this.grbGeneral.Controls.Add(this.lblCreate);
            this.grbGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbGeneral.Location = new System.Drawing.Point(3, 0);
            this.grbGeneral.Name = "grbGeneral";
            this.grbGeneral.Size = new System.Drawing.Size(501, 140);
            this.grbGeneral.TabIndex = 0;
            this.grbGeneral.TabStop = false;
            // 
            // chkMESplusPmtFlag
            // 
            this.chkMESplusPmtFlag.AutoSize = true;
            this.chkMESplusPmtFlag.Enabled = false;
            this.chkMESplusPmtFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMESplusPmtFlag.Location = new System.Drawing.Point(116, 62);
            this.chkMESplusPmtFlag.Name = "chkMESplusPmtFlag";
            this.chkMESplusPmtFlag.Size = new System.Drawing.Size(189, 17);
            this.chkMESplusPmtFlag.TabIndex = 4;
            this.chkMESplusPmtFlag.Text = "MESplus Predefined Prompt";
            // 
            // txtOptionDescPrompt
            // 
            this.txtOptionDescPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOptionDescPrompt.Location = new System.Drawing.Point(116, 37);
            this.txtOptionDescPrompt.MaxLength = 200;
            this.txtOptionDescPrompt.Name = "txtOptionDescPrompt";
            this.txtOptionDescPrompt.Size = new System.Drawing.Size(379, 20);
            this.txtOptionDescPrompt.TabIndex = 3;
            // 
            // lblPMTDesc
            // 
            this.lblPMTDesc.AutoSize = true;
            this.lblPMTDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPMTDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTDesc.Location = new System.Drawing.Point(15, 40);
            this.lblPMTDesc.Name = "lblPMTDesc";
            this.lblPMTDesc.Size = new System.Drawing.Size(60, 13);
            this.lblPMTDesc.TabIndex = 2;
            this.lblPMTDesc.Text = "Description";
            this.lblPMTDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOptionName
            // 
            this.txtOptionName.Location = new System.Drawing.Point(116, 13);
            this.txtOptionName.MaxLength = 30;
            this.txtOptionName.Name = "txtOptionName";
            this.txtOptionName.Size = new System.Drawing.Size(379, 20);
            this.txtOptionName.TabIndex = 1;
            this.txtOptionName.Leave += new System.EventHandler(this.txtOptionName_Leave);
            // 
            // lblPMTName
            // 
            this.lblPMTName.AutoSize = true;
            this.lblPMTName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPMTName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTName.Location = new System.Drawing.Point(15, 16);
            this.lblPMTName.Name = "lblPMTName";
            this.lblPMTName.Size = new System.Drawing.Size(80, 13);
            this.lblPMTName.TabIndex = 0;
            this.lblPMTName.Text = "Option Name";
            this.lblPMTName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMTUpdateTime
            // 
            this.txtPMTUpdateTime.Location = new System.Drawing.Point(300, 109);
            this.txtPMTUpdateTime.MaxLength = 30;
            this.txtPMTUpdateTime.Name = "txtPMTUpdateTime";
            this.txtPMTUpdateTime.ReadOnly = true;
            this.txtPMTUpdateTime.Size = new System.Drawing.Size(180, 20);
            this.txtPMTUpdateTime.TabIndex = 10;
            this.txtPMTUpdateTime.TabStop = false;
            // 
            // txtPMTCreateTime
            // 
            this.txtPMTCreateTime.Location = new System.Drawing.Point(300, 84);
            this.txtPMTCreateTime.MaxLength = 30;
            this.txtPMTCreateTime.Name = "txtPMTCreateTime";
            this.txtPMTCreateTime.ReadOnly = true;
            this.txtPMTCreateTime.Size = new System.Drawing.Size(180, 20);
            this.txtPMTCreateTime.TabIndex = 7;
            this.txtPMTCreateTime.TabStop = false;
            // 
            // txtPMTUpdateUser
            // 
            this.txtPMTUpdateUser.Location = new System.Drawing.Point(116, 109);
            this.txtPMTUpdateUser.MaxLength = 20;
            this.txtPMTUpdateUser.Name = "txtPMTUpdateUser";
            this.txtPMTUpdateUser.ReadOnly = true;
            this.txtPMTUpdateUser.Size = new System.Drawing.Size(180, 20);
            this.txtPMTUpdateUser.TabIndex = 9;
            this.txtPMTUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(15, 112);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 8;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPMTCreateUser
            // 
            this.txtPMTCreateUser.Location = new System.Drawing.Point(116, 84);
            this.txtPMTCreateUser.MaxLength = 20;
            this.txtPMTCreateUser.Name = "txtPMTCreateUser";
            this.txtPMTCreateUser.ReadOnly = true;
            this.txtPMTCreateUser.Size = new System.Drawing.Size(180, 20);
            this.txtPMTCreateUser.TabIndex = 6;
            this.txtPMTCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(15, 87);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 5;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(224, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 480);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // lisOption
            // 
            this.lisOption.BackColor = System.Drawing.SystemColors.Window;
            this.lisOption.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOptionName,
            this.colOptionDesc});
            this.lisOption.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisOption.EnableSort = true;
            this.lisOption.EnableSortIcon = true;
            this.lisOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisOption.FullRowSelect = true;
            this.lisOption.HideSelection = false;
            this.lisOption.Location = new System.Drawing.Point(0, 0);
            this.lisOption.MultiSelect = false;
            this.lisOption.Name = "lisOption";
            this.lisOption.Size = new System.Drawing.Size(224, 480);
            this.lisOption.TabIndex = 0;
            this.lisOption.UseCompatibleStateImageBehavior = false;
            this.lisOption.View = System.Windows.Forms.View.Details;
            this.lisOption.SelectedIndexChanged += new System.EventHandler(this.lisOption_SelectedIndexChanged);
            // 
            // colOptionName
            // 
            this.colOptionName.Text = "Option Name";
            this.colOptionName.Width = 120;
            // 
            // colOptionDesc
            // 
            this.colOptionDesc.Text = "Description";
            this.colOptionDesc.Width = 200;
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.tbpPrompt);
            this.tabOption.Controls.Add(this.tbpOption);
            this.tabOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOption.Location = new System.Drawing.Point(0, 0);
            this.tabOption.Name = "tabOption";
            this.tabOption.SelectedIndex = 0;
            this.tabOption.Size = new System.Drawing.Size(742, 506);
            this.tabOption.TabIndex = 0;
            this.tabOption.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabOption_Selected);
            // 
            // cdvGCMTableList
            // 
            this.cdvGCMTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvGCMTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGCMTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGCMTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGCMTableList.Location = new System.Drawing.Point(0, 0);
            this.cdvGCMTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGCMTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGCMTableList.Name = "MCSPCodeView";
            this.cdvGCMTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvGCMTableList.SmallImageList = null;
            this.cdvGCMTableList.TabIndex = 0;
            this.cdvGCMTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvGCMTableList.VisibleColumnHeader = false;
            this.cdvGCMTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvGCMTableList_SelectedItemChanged);
            // 
            // frmBASSetupGlobalOption
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASSetupGlobalOption";
            this.Text = "Global Option Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupGlobalOption_Activated);
            this.Load += new System.EventHandler(this.frmBASSetupGlobalOption_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.tbpOption.ResumeLayout(false);
            this.pnlOption.ResumeLayout(false);
            this.grpOptionDefinition.ResumeLayout(false);
            this.grpOptionDefinition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionName)).EndInit();
            this.grpValueDefinition.ResumeLayout(false);
            this.grpValueDefinition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue1)).EndInit();
            this.tbpPrompt.ResumeLayout(false);
            this.pnlPrompt.ResumeLayout(false);
            this.grbValuePrompt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.grbGeneral.ResumeLayout(false);
            this.grbGeneral.PerformLayout();
            this.tabOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGCMTableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDataCountBase;
        private System.Windows.Forms.TabControl tabOption;
        private System.Windows.Forms.TabPage tbpPrompt;
        private Miracom.UI.Controls.MCListView.MCListView lisOption;
        private System.Windows.Forms.ColumnHeader colOptionName;
        private System.Windows.Forms.ColumnHeader colOptionDesc;
        private System.Windows.Forms.TabPage tbpOption;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvGCMTableList;
        private System.Windows.Forms.Panel pnlPrompt;
        private System.Windows.Forms.GroupBox grbGeneral;
        private System.Windows.Forms.TextBox txtOptionDescPrompt;
        private System.Windows.Forms.Label lblPMTDesc;
        private System.Windows.Forms.TextBox txtOptionName;
        private System.Windows.Forms.Label lblPMTName;
        private System.Windows.Forms.TextBox txtPMTUpdateTime;
        private System.Windows.Forms.TextBox txtPMTCreateTime;
        private System.Windows.Forms.TextBox txtPMTUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtPMTCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.GroupBox grbValuePrompt;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.GroupBox grpOptionDefinition;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOptionName;
        private System.Windows.Forms.TextBox txtOptionDescDefinition;
        private System.Windows.Forms.Label lblDEFDesc;
        private System.Windows.Forms.Label lblDEFName;
        private System.Windows.Forms.TextBox txtDEFUpdateTime;
        private System.Windows.Forms.TextBox txtDEFCreateTime;
        private System.Windows.Forms.TextBox txtDEFUpdateUser;
        private System.Windows.Forms.Label lblDEFUpdate;
        private System.Windows.Forms.TextBox txtDEFCreateUser;
        private System.Windows.Forms.Label lblDEFCreate;
        private System.Windows.Forms.GroupBox grpValueDefinition;
        private System.Windows.Forms.Label lblValue5;
        private System.Windows.Forms.Label lblValue4;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.Label lblValue1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue1;
        private System.Windows.Forms.Panel pnlFind;
        private System.Windows.Forms.Label lblDataCount;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.CheckBox chkMESplusPmtFlag;
        private Miracom.UI.Controls.MCListView.MCListView lisGOption;
        private System.Windows.Forms.ColumnHeader colOptionName2;
        private System.Windows.Forms.ColumnHeader colOptionDesc2;
        private System.Windows.Forms.ColumnHeader colValue1;
        private System.Windows.Forms.ColumnHeader colValue2;
        private System.Windows.Forms.ColumnHeader colValue3;
        private System.Windows.Forms.ColumnHeader colValue4;
        private System.Windows.Forms.ColumnHeader colValue5;
        private System.Windows.Forms.CheckBox chkMESplusOption;
    }
}
