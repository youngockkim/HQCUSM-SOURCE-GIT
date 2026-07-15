namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSMeasuringPlanSetup
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
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.lisView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cdvViewEquipType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label32 = new System.Windows.Forms.Label();
            this.cdvViewMgtDept = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.cdvViewUseDept = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblViewUseDept = new System.Windows.Forms.Label();
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.txtEquipCode = new System.Windows.Forms.TextBox();
            this.txtEquipName = new System.Windows.Forms.TextBox();
            this.lblCalibrationInstituteCode = new System.Windows.Forms.Label();
            this.lblCalibrationEquipName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAnaPlanAll = new System.Windows.Forms.CheckBox();
            this.btnAnaPlanDelete = new System.Windows.Forms.Button();
            this.btnAnaPlanAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.spdAnaPlanList = new FarPoint.Win.Spread.FpSpread();
            this.spdAnaPlanList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewEquipType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewMgtDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewUseDept)).BeginInit();
            this.grpMaterial.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanList_Sheet1)).BeginInit();
            this.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.panel2);
            this.pnlRight.Controls.Add(this.panel1);
            this.pnlRight.Controls.Add(this.grpMaterial);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisView);
            this.pnlLeft.Controls.Add(this.groupBox2);
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
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // lisView
            // 
            this.lisView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lisView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisView.FullRowSelect = true;
            this.lisView.Location = new System.Drawing.Point(0, 81);
            this.lisView.Name = "lisView";
            this.lisView.Size = new System.Drawing.Size(232, 425);
            this.lisView.TabIndex = 8;
            this.lisView.UseCompatibleStateImageBehavior = false;
            this.lisView.View = System.Windows.Forms.View.Details;
            this.lisView.SelectedIndexChanged += new System.EventHandler(this.lisView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Equip Code";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Equip Name";
            this.columnHeader2.Width = 130;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cdvViewEquipType);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.cdvViewMgtDept);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cdvViewUseDept);
            this.groupBox2.Controls.Add(this.lblViewUseDept);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 81);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // cdvViewEquipType
            // 
            this.cdvViewEquipType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvViewEquipType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvViewEquipType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvViewEquipType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvViewEquipType.BtnToolTipText = "";
            this.cdvViewEquipType.ButtonWidth = 20;
            this.cdvViewEquipType.DescText = "";
            this.cdvViewEquipType.DisplaySubItemIndex = 0;
            this.cdvViewEquipType.DisplayText = "";
            this.cdvViewEquipType.Focusing = null;
            this.cdvViewEquipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvViewEquipType.Index = 0;
            this.cdvViewEquipType.IsViewBtnImage = false;
            this.cdvViewEquipType.Location = new System.Drawing.Point(85, 12);
            this.cdvViewEquipType.MaxLength = 20;
            this.cdvViewEquipType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvViewEquipType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvViewEquipType.MultiSelect = false;
            this.cdvViewEquipType.Name = "cdvViewEquipType";
            this.cdvViewEquipType.ReadOnly = false;
            this.cdvViewEquipType.SameWidthHeightOfButton = false;
            this.cdvViewEquipType.SearchSubItemIndex = 0;
            this.cdvViewEquipType.SelectedDescIndex = -1;
            this.cdvViewEquipType.SelectedDescToQueryText = "";
            this.cdvViewEquipType.SelectedSubItemIndex = 0;
            this.cdvViewEquipType.SelectedValueToQueryText = "";
            this.cdvViewEquipType.SelectionStart = 0;
            this.cdvViewEquipType.Size = new System.Drawing.Size(128, 20);
            this.cdvViewEquipType.SmallImageList = null;
            this.cdvViewEquipType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvViewEquipType.TabIndex = 8;
            this.cdvViewEquipType.TextBoxToolTipText = "";
            this.cdvViewEquipType.TextBoxWidth = 128;
            this.cdvViewEquipType.VisibleButton = true;
            this.cdvViewEquipType.VisibleColumnHeader = false;
            this.cdvViewEquipType.VisibleDescription = false;
            this.cdvViewEquipType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvViewEquipType_SelectedItemChanged);
            this.cdvViewEquipType.ButtonPress += new System.EventHandler(this.cdvViewEquipType_ButtonPress);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(8, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(61, 13);
            this.label32.TabIndex = 7;
            this.label32.Text = "Equip Type";
            // 
            // cdvViewMgtDept
            // 
            this.cdvViewMgtDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvViewMgtDept.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvViewMgtDept.BorderHotColor = System.Drawing.Color.Black;
            this.cdvViewMgtDept.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvViewMgtDept.BtnToolTipText = "";
            this.cdvViewMgtDept.ButtonWidth = 20;
            this.cdvViewMgtDept.DescText = "";
            this.cdvViewMgtDept.DisplaySubItemIndex = 0;
            this.cdvViewMgtDept.DisplayText = "";
            this.cdvViewMgtDept.Focusing = null;
            this.cdvViewMgtDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvViewMgtDept.Index = 0;
            this.cdvViewMgtDept.IsViewBtnImage = false;
            this.cdvViewMgtDept.Location = new System.Drawing.Point(85, 56);
            this.cdvViewMgtDept.MaxLength = 20;
            this.cdvViewMgtDept.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvViewMgtDept.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvViewMgtDept.MultiSelect = false;
            this.cdvViewMgtDept.Name = "cdvViewMgtDept";
            this.cdvViewMgtDept.ReadOnly = false;
            this.cdvViewMgtDept.SameWidthHeightOfButton = false;
            this.cdvViewMgtDept.SearchSubItemIndex = 0;
            this.cdvViewMgtDept.SelectedDescIndex = -1;
            this.cdvViewMgtDept.SelectedDescToQueryText = "";
            this.cdvViewMgtDept.SelectedSubItemIndex = 0;
            this.cdvViewMgtDept.SelectedValueToQueryText = "";
            this.cdvViewMgtDept.SelectionStart = 0;
            this.cdvViewMgtDept.Size = new System.Drawing.Size(128, 20);
            this.cdvViewMgtDept.SmallImageList = null;
            this.cdvViewMgtDept.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvViewMgtDept.TabIndex = 6;
            this.cdvViewMgtDept.TextBoxToolTipText = "";
            this.cdvViewMgtDept.TextBoxWidth = 128;
            this.cdvViewMgtDept.VisibleButton = true;
            this.cdvViewMgtDept.VisibleColumnHeader = false;
            this.cdvViewMgtDept.VisibleDescription = false;
            this.cdvViewMgtDept.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvViewMgtDept_SelectedItemChanged);
            this.cdvViewMgtDept.ButtonPress += new System.EventHandler(this.cdvViewMgtDept_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(8, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mgt Dept";
            // 
            // cdvViewUseDept
            // 
            this.cdvViewUseDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvViewUseDept.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvViewUseDept.BorderHotColor = System.Drawing.Color.Black;
            this.cdvViewUseDept.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvViewUseDept.BtnToolTipText = "";
            this.cdvViewUseDept.ButtonWidth = 20;
            this.cdvViewUseDept.DescText = "";
            this.cdvViewUseDept.DisplaySubItemIndex = 0;
            this.cdvViewUseDept.DisplayText = "";
            this.cdvViewUseDept.Focusing = null;
            this.cdvViewUseDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvViewUseDept.Index = 0;
            this.cdvViewUseDept.IsViewBtnImage = false;
            this.cdvViewUseDept.Location = new System.Drawing.Point(85, 34);
            this.cdvViewUseDept.MaxLength = 20;
            this.cdvViewUseDept.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvViewUseDept.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvViewUseDept.MultiSelect = false;
            this.cdvViewUseDept.Name = "cdvViewUseDept";
            this.cdvViewUseDept.ReadOnly = false;
            this.cdvViewUseDept.SameWidthHeightOfButton = false;
            this.cdvViewUseDept.SearchSubItemIndex = 0;
            this.cdvViewUseDept.SelectedDescIndex = -1;
            this.cdvViewUseDept.SelectedDescToQueryText = "";
            this.cdvViewUseDept.SelectedSubItemIndex = 0;
            this.cdvViewUseDept.SelectedValueToQueryText = "";
            this.cdvViewUseDept.SelectionStart = 0;
            this.cdvViewUseDept.Size = new System.Drawing.Size(128, 20);
            this.cdvViewUseDept.SmallImageList = null;
            this.cdvViewUseDept.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvViewUseDept.TabIndex = 4;
            this.cdvViewUseDept.TextBoxToolTipText = "";
            this.cdvViewUseDept.TextBoxWidth = 128;
            this.cdvViewUseDept.VisibleButton = true;
            this.cdvViewUseDept.VisibleColumnHeader = false;
            this.cdvViewUseDept.VisibleDescription = false;
            this.cdvViewUseDept.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvViewUseDept_SelectedItemChanged);
            this.cdvViewUseDept.ButtonPress += new System.EventHandler(this.cdvViewUseDept_ButtonPress);
            // 
            // lblViewUseDept
            // 
            this.lblViewUseDept.AutoSize = true;
            this.lblViewUseDept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblViewUseDept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblViewUseDept.Location = new System.Drawing.Point(8, 38);
            this.lblViewUseDept.Name = "lblViewUseDept";
            this.lblViewUseDept.Size = new System.Drawing.Size(52, 13);
            this.lblViewUseDept.TabIndex = 3;
            this.lblViewUseDept.Text = "Use Dept";
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.txtEquipCode);
            this.grpMaterial.Controls.Add(this.txtEquipName);
            this.grpMaterial.Controls.Add(this.lblCalibrationInstituteCode);
            this.grpMaterial.Controls.Add(this.lblCalibrationEquipName);
            this.grpMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterial.Location = new System.Drawing.Point(0, 0);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Size = new System.Drawing.Size(506, 68);
            this.grpMaterial.TabIndex = 5;
            this.grpMaterial.TabStop = false;
            // 
            // txtEquipCode
            // 
            this.txtEquipCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEquipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipCode.Location = new System.Drawing.Point(152, 15);
            this.txtEquipCode.MaxLength = 50;
            this.txtEquipCode.Name = "txtEquipCode";
            this.txtEquipCode.ReadOnly = true;
            this.txtEquipCode.Size = new System.Drawing.Size(152, 20);
            this.txtEquipCode.TabIndex = 1;
            // 
            // txtEquipName
            // 
            this.txtEquipName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipName.Location = new System.Drawing.Point(152, 38);
            this.txtEquipName.MaxLength = 100;
            this.txtEquipName.Name = "txtEquipName";
            this.txtEquipName.ReadOnly = true;
            this.txtEquipName.Size = new System.Drawing.Size(335, 20);
            this.txtEquipName.TabIndex = 2;
            // 
            // lblCalibrationInstituteCode
            // 
            this.lblCalibrationInstituteCode.AutoSize = true;
            this.lblCalibrationInstituteCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationInstituteCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationInstituteCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCalibrationInstituteCode.Location = new System.Drawing.Point(9, 19);
            this.lblCalibrationInstituteCode.Name = "lblCalibrationInstituteCode";
            this.lblCalibrationInstituteCode.Size = new System.Drawing.Size(137, 13);
            this.lblCalibrationInstituteCode.TabIndex = 50;
            this.lblCalibrationInstituteCode.Text = "Measuring Equipment Code";
            // 
            // lblCalibrationEquipName
            // 
            this.lblCalibrationEquipName.AutoSize = true;
            this.lblCalibrationEquipName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationEquipName.Location = new System.Drawing.Point(9, 42);
            this.lblCalibrationEquipName.Name = "lblCalibrationEquipName";
            this.lblCalibrationEquipName.Size = new System.Drawing.Size(140, 13);
            this.lblCalibrationEquipName.TabIndex = 49;
            this.lblCalibrationEquipName.Text = "Measuring Equipment Name";
            this.lblCalibrationEquipName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAnaPlanAll);
            this.panel1.Controls.Add(this.btnAnaPlanDelete);
            this.panel1.Controls.Add(this.btnAnaPlanAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 31);
            this.panel1.TabIndex = 6;
            // 
            // chkAnaPlanAll
            // 
            this.chkAnaPlanAll.AutoSize = true;
            this.chkAnaPlanAll.Location = new System.Drawing.Point(41, 8);
            this.chkAnaPlanAll.Name = "chkAnaPlanAll";
            this.chkAnaPlanAll.Size = new System.Drawing.Size(71, 17);
            this.chkAnaPlanAll.TabIndex = 47;
            this.chkAnaPlanAll.Text = "Check All";
            this.chkAnaPlanAll.UseVisualStyleBackColor = true;
            this.chkAnaPlanAll.CheckedChanged += new System.EventHandler(this.chkAnaPlanAll_CheckedChanged);
            // 
            // btnAnaPlanDelete
            // 
            this.btnAnaPlanDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnaPlanDelete.Location = new System.Drawing.Point(425, 3);
            this.btnAnaPlanDelete.Name = "btnAnaPlanDelete";
            this.btnAnaPlanDelete.Size = new System.Drawing.Size(78, 25);
            this.btnAnaPlanDelete.TabIndex = 46;
            this.btnAnaPlanDelete.Text = "Delete";
            this.btnAnaPlanDelete.UseVisualStyleBackColor = true;
            this.btnAnaPlanDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAnaPlanAdd
            // 
            this.btnAnaPlanAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnaPlanAdd.Location = new System.Drawing.Point(332, 3);
            this.btnAnaPlanAdd.Name = "btnAnaPlanAdd";
            this.btnAnaPlanAdd.Size = new System.Drawing.Size(78, 25);
            this.btnAnaPlanAdd.TabIndex = 45;
            this.btnAnaPlanAdd.Text = "Add New";
            this.btnAnaPlanAdd.UseVisualStyleBackColor = true;
            this.btnAnaPlanAdd.Click += new System.EventHandler(this.btnAnaPlanAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.spdAnaPlanList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 407);
            this.panel2.TabIndex = 7;
            // 
            // spdAnaPlanList
            // 
            this.spdAnaPlanList.AccessibleDescription = "spdAnaPlanList, Sheet1, Row 0, Column 0, ";
            this.spdAnaPlanList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAnaPlanList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdAnaPlanList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAnaPlanList.HorizontalScrollBar.Name = "";
            this.spdAnaPlanList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdAnaPlanList.HorizontalScrollBar.TabIndex = 46;
            this.spdAnaPlanList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAnaPlanList.Location = new System.Drawing.Point(0, 0);
            this.spdAnaPlanList.Name = "spdAnaPlanList";
            this.spdAnaPlanList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAnaPlanList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAnaPlanList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAnaPlanList_Sheet1});
            this.spdAnaPlanList.Size = new System.Drawing.Size(506, 407);
            this.spdAnaPlanList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAnaPlanList.TabIndex = 50;
            this.spdAnaPlanList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAnaPlanList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAnaPlanList.VerticalScrollBar.Name = "";
            this.spdAnaPlanList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdAnaPlanList.VerticalScrollBar.TabIndex = 47;
            this.spdAnaPlanList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAnaPlanList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAnaPlanList_ButtonClicked);
            // 
            // spdAnaPlanList_Sheet1
            // 
            this.spdAnaPlanList_Sheet1.Reset();
            spdAnaPlanList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAnaPlanList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAnaPlanList_Sheet1.ColumnCount = 7;
            spdAnaPlanList_Sheet1.RowCount = 1;
            this.spdAnaPlanList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAnaPlanList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Detail";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Analysis ID";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Plan Date";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Status";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Analysis Method";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Sample Code";
            this.spdAnaPlanList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdAnaPlanList_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdAnaPlanList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnaPlanList_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdAnaPlanList_Sheet1.Columns.Get(0).Locked = false;
            this.spdAnaPlanList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnaPlanList_Sheet1.Columns.Get(0).Width = 40F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "Detail";
            this.spdAnaPlanList_Sheet1.Columns.Get(1).CellType = buttonCellType1;
            this.spdAnaPlanList_Sheet1.Columns.Get(1).Label = "Detail";
            this.spdAnaPlanList_Sheet1.Columns.Get(2).Label = "Analysis ID";
            this.spdAnaPlanList_Sheet1.Columns.Get(2).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(2).Visible = false;
            this.spdAnaPlanList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnaPlanList_Sheet1.Columns.Get(3).Label = "Plan Date";
            this.spdAnaPlanList_Sheet1.Columns.Get(3).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnaPlanList_Sheet1.Columns.Get(3).Width = 100F;
            this.spdAnaPlanList_Sheet1.Columns.Get(4).Label = "Status";
            this.spdAnaPlanList_Sheet1.Columns.Get(4).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(4).Width = 100F;
            this.spdAnaPlanList_Sheet1.Columns.Get(5).Label = "Analysis Method";
            this.spdAnaPlanList_Sheet1.Columns.Get(5).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(5).Width = 140F;
            this.spdAnaPlanList_Sheet1.Columns.Get(6).Label = "Sample Code";
            this.spdAnaPlanList_Sheet1.Columns.Get(6).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(6).Width = 100F;
            this.spdAnaPlanList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAnaPlanList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAnaPlanList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdAnaPlanList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAnaPlanList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAnaPlanList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmMMSMeasuringPlanSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSMeasuringPlanSetup";
            this.Text = "Measuring Plan Setup";
            this.Activated += new System.EventHandler(this.frmMMSMeasuringPlanSetup_Activated);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewEquipType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewMgtDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewUseDept)).EndInit();
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lisView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvViewMgtDept;
        private System.Windows.Forms.Label label1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvViewUseDept;
        private System.Windows.Forms.Label lblViewUseDept;
        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.TextBox txtEquipCode;
        private System.Windows.Forms.TextBox txtEquipName;
        private System.Windows.Forms.Panel panel2;
        private FarPoint.Win.Spread.FpSpread spdAnaPlanList;
        private FarPoint.Win.Spread.SheetView spdAnaPlanList_Sheet1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCalibrationInstituteCode;
        private System.Windows.Forms.Label lblCalibrationEquipName;
        private System.Windows.Forms.Button btnAnaPlanDelete;
        private System.Windows.Forms.Button btnAnaPlanAdd;
        private System.Windows.Forms.CheckBox chkAnaPlanAll;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvViewEquipType;
        private System.Windows.Forms.Label label32;
    }
}