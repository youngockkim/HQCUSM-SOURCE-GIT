namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSCalibrationPlanSetup
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
            this.lblMeasuringEquipmentCode = new System.Windows.Forms.Label();
            this.txtEquipName = new System.Windows.Forms.TextBox();
            this.lblMeasuringEquipmentName = new System.Windows.Forms.Label();
            this.tabSampling = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grbMain = new System.Windows.Forms.GroupBox();
            this.txtLastCaliDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpCaliPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.cdvCaliPlanDoc = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtCaliMethod = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cdvCaliInstitute = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.nudAlarmPeriod = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            this.cdvAlarmCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkAlarmFlag = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cdvMgtDept = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label16 = new System.Windows.Forms.Label();
            this.nudCalibrationCycle = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEquipMaker = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEquipSpec = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEquipModel = new System.Windows.Forms.TextBox();
            this.txtEquipNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
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
            this.tabSampling.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grbMain.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliPlanDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliInstitute)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMgtDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibrationCycle)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.tabSampling);
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
            this.lisView.Location = new System.Drawing.Point(0, 90);
            this.lisView.Name = "lisView";
            this.lisView.Size = new System.Drawing.Size(232, 416);
            this.lisView.TabIndex = 6;
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
            this.groupBox2.Size = new System.Drawing.Size(232, 90);
            this.groupBox2.TabIndex = 5;
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
            this.cdvViewEquipType.Location = new System.Drawing.Point(91, 15);
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
            this.label32.Location = new System.Drawing.Point(14, 19);
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
            this.cdvViewMgtDept.Location = new System.Drawing.Point(91, 63);
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
            this.cdvViewMgtDept.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvViewControl_SelectedItemChanged);
            this.cdvViewMgtDept.ButtonPress += new System.EventHandler(this.cdvViewMgtDept_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(14, 67);
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
            this.cdvViewUseDept.Location = new System.Drawing.Point(91, 39);
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
            this.cdvViewUseDept.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvViewControl_SelectedItemChanged);
            this.cdvViewUseDept.ButtonPress += new System.EventHandler(this.cdvViewUseDept_ButtonPress);
            // 
            // lblViewUseDept
            // 
            this.lblViewUseDept.AutoSize = true;
            this.lblViewUseDept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblViewUseDept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblViewUseDept.Location = new System.Drawing.Point(14, 43);
            this.lblViewUseDept.Name = "lblViewUseDept";
            this.lblViewUseDept.Size = new System.Drawing.Size(52, 13);
            this.lblViewUseDept.TabIndex = 3;
            this.lblViewUseDept.Text = "Use Dept";
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.txtEquipCode);
            this.grpMaterial.Controls.Add(this.lblMeasuringEquipmentCode);
            this.grpMaterial.Controls.Add(this.txtEquipName);
            this.grpMaterial.Controls.Add(this.lblMeasuringEquipmentName);
            this.grpMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterial.Location = new System.Drawing.Point(0, 0);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Size = new System.Drawing.Size(506, 71);
            this.grpMaterial.TabIndex = 4;
            this.grpMaterial.TabStop = false;
            // 
            // txtEquipCode
            // 
            this.txtEquipCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEquipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipCode.Location = new System.Drawing.Point(82, 14);
            this.txtEquipCode.MaxLength = 50;
            this.txtEquipCode.Name = "txtEquipCode";
            this.txtEquipCode.Size = new System.Drawing.Size(160, 20);
            this.txtEquipCode.TabIndex = 1;
            // 
            // lblMeasuringEquipmentCode
            // 
            this.lblMeasuringEquipmentCode.AutoSize = true;
            this.lblMeasuringEquipmentCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMeasuringEquipmentCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeasuringEquipmentCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMeasuringEquipmentCode.Location = new System.Drawing.Point(16, 18);
            this.lblMeasuringEquipmentCode.Name = "lblMeasuringEquipmentCode";
            this.lblMeasuringEquipmentCode.Size = new System.Drawing.Size(72, 13);
            this.lblMeasuringEquipmentCode.TabIndex = 3;
            this.lblMeasuringEquipmentCode.Text = "Equip Code";
            // 
            // txtEquipName
            // 
            this.txtEquipName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipName.Location = new System.Drawing.Point(82, 40);
            this.txtEquipName.MaxLength = 100;
            this.txtEquipName.Name = "txtEquipName";
            this.txtEquipName.Size = new System.Drawing.Size(405, 20);
            this.txtEquipName.TabIndex = 2;
            // 
            // lblMeasuringEquipmentName
            // 
            this.lblMeasuringEquipmentName.AutoSize = true;
            this.lblMeasuringEquipmentName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMeasuringEquipmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeasuringEquipmentName.Location = new System.Drawing.Point(16, 43);
            this.lblMeasuringEquipmentName.Name = "lblMeasuringEquipmentName";
            this.lblMeasuringEquipmentName.Size = new System.Drawing.Size(65, 13);
            this.lblMeasuringEquipmentName.TabIndex = 1;
            this.lblMeasuringEquipmentName.Text = "Equip Name";
            this.lblMeasuringEquipmentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabSampling
            // 
            this.tabSampling.Controls.Add(this.tbpGeneral);
            this.tabSampling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabSampling.ItemSize = new System.Drawing.Size(60, 18);
            this.tabSampling.Location = new System.Drawing.Point(0, 71);
            this.tabSampling.Name = "tabSampling";
            this.tabSampling.SelectedIndex = 0;
            this.tabSampling.Size = new System.Drawing.Size(506, 435);
            this.tabSampling.TabIndex = 5;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grbMain);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(498, 409);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grbMain
            // 
            this.grbMain.Controls.Add(this.txtLastCaliDate);
            this.grbMain.Controls.Add(this.label2);
            this.grbMain.Controls.Add(this.groupBox4);
            this.grbMain.Controls.Add(this.groupBox3);
            this.grbMain.Controls.Add(this.label18);
            this.grbMain.Controls.Add(this.cdvMgtDept);
            this.grbMain.Controls.Add(this.label16);
            this.grbMain.Controls.Add(this.nudCalibrationCycle);
            this.grbMain.Controls.Add(this.label3);
            this.grbMain.Controls.Add(this.txtEquipMaker);
            this.grbMain.Controls.Add(this.label14);
            this.grbMain.Controls.Add(this.txtEquipSpec);
            this.grbMain.Controls.Add(this.label13);
            this.grbMain.Controls.Add(this.txtEquipModel);
            this.grbMain.Controls.Add(this.txtEquipNo);
            this.grbMain.Controls.Add(this.label7);
            this.grbMain.Controls.Add(this.panel1);
            this.grbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbMain.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbMain.Location = new System.Drawing.Point(3, 0);
            this.grbMain.Name = "grbMain";
            this.grbMain.Size = new System.Drawing.Size(492, 406);
            this.grbMain.TabIndex = 0;
            this.grbMain.TabStop = false;
            // 
            // txtLastCaliDate
            // 
            this.txtLastCaliDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastCaliDate.Location = new System.Drawing.Point(115, 94);
            this.txtLastCaliDate.MaxLength = 40;
            this.txtLastCaliDate.Name = "txtLastCaliDate";
            this.txtLastCaliDate.ReadOnly = true;
            this.txtLastCaliDate.Size = new System.Drawing.Size(120, 20);
            this.txtLastCaliDate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(13, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 108;
            this.label2.Text = "Last Calibration Date";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpCaliPlanDate);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btnFileOpen);
            this.groupBox4.Controls.Add(this.cdvCaliPlanDoc);
            this.groupBox4.Controls.Add(this.lblFileName);
            this.groupBox4.Controls.Add(this.txtCaliMethod);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.cdvCaliInstitute);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 137);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(486, 123);
            this.groupBox4.TabIndex = 106;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Plan";
            // 
            // dtpCaliPlanDate
            // 
            this.dtpCaliPlanDate.Checked = false;
            this.dtpCaliPlanDate.CustomFormat = "";
            this.dtpCaliPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaliPlanDate.Location = new System.Drawing.Point(131, 19);
            this.dtpCaliPlanDate.Name = "dtpCaliPlanDate";
            this.dtpCaliPlanDate.ShowCheckBox = true;
            this.dtpCaliPlanDate.Size = new System.Drawing.Size(116, 20);
            this.dtpCaliPlanDate.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(29, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "Plan Date";
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileOpen.Location = new System.Drawing.Point(434, 95);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(43, 21);
            this.btnFileOpen.TabIndex = 14;
            this.btnFileOpen.Text = "Open";
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // cdvCaliPlanDoc
            // 
            this.cdvCaliPlanDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCaliPlanDoc.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCaliPlanDoc.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCaliPlanDoc.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCaliPlanDoc.BtnToolTipText = "";
            this.cdvCaliPlanDoc.ButtonWidth = 50;
            this.cdvCaliPlanDoc.DescText = "";
            this.cdvCaliPlanDoc.DisplaySubItemIndex = -1;
            this.cdvCaliPlanDoc.DisplayText = "";
            this.cdvCaliPlanDoc.Focusing = null;
            this.cdvCaliPlanDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCaliPlanDoc.Index = 0;
            this.cdvCaliPlanDoc.IsViewBtnImage = false;
            this.cdvCaliPlanDoc.Location = new System.Drawing.Point(131, 95);
            this.cdvCaliPlanDoc.MaxLength = 50;
            this.cdvCaliPlanDoc.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCaliPlanDoc.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCaliPlanDoc.MultiSelect = false;
            this.cdvCaliPlanDoc.Name = "cdvCaliPlanDoc";
            this.cdvCaliPlanDoc.ReadOnly = true;
            this.cdvCaliPlanDoc.SameWidthHeightOfButton = false;
            this.cdvCaliPlanDoc.SearchSubItemIndex = 0;
            this.cdvCaliPlanDoc.SelectedDescIndex = -1;
            this.cdvCaliPlanDoc.SelectedDescToQueryText = "";
            this.cdvCaliPlanDoc.SelectedSubItemIndex = -1;
            this.cdvCaliPlanDoc.SelectedValueToQueryText = "";
            this.cdvCaliPlanDoc.SelectionStart = 0;
            this.cdvCaliPlanDoc.Size = new System.Drawing.Size(298, 20);
            this.cdvCaliPlanDoc.SmallImageList = null;
            this.cdvCaliPlanDoc.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCaliPlanDoc.TabIndex = 13;
            this.cdvCaliPlanDoc.TextBoxToolTipText = "";
            this.cdvCaliPlanDoc.TextBoxWidth = 298;
            this.cdvCaliPlanDoc.VisibleButton = true;
            this.cdvCaliPlanDoc.VisibleColumnHeader = false;
            this.cdvCaliPlanDoc.VisibleDescription = false;
            this.cdvCaliPlanDoc.ButtonPress += new System.EventHandler(this.cdvCaliPlanDoc_ButtonPress);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(26, 99);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(106, 13);
            this.lblFileName.TabIndex = 100;
            this.lblFileName.Text = "Calibration Plan Doc.";
            // 
            // txtCaliMethod
            // 
            this.txtCaliMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaliMethod.Location = new System.Drawing.Point(131, 70);
            this.txtCaliMethod.MaxLength = 40;
            this.txtCaliMethod.Name = "txtCaliMethod";
            this.txtCaliMethod.Size = new System.Drawing.Size(298, 20);
            this.txtCaliMethod.TabIndex = 12;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(29, 74);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(95, 13);
            this.label30.TabIndex = 99;
            this.label30.Text = "Calibration Method";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(29, 48);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 13);
            this.label29.TabIndex = 97;
            this.label29.Text = "Calibration Institute";
            // 
            // cdvCaliInstitute
            // 
            this.cdvCaliInstitute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCaliInstitute.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCaliInstitute.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCaliInstitute.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCaliInstitute.BtnToolTipText = "";
            this.cdvCaliInstitute.ButtonWidth = 20;
            this.cdvCaliInstitute.DescText = "";
            this.cdvCaliInstitute.DisplaySubItemIndex = 0;
            this.cdvCaliInstitute.DisplayText = "";
            this.cdvCaliInstitute.Focusing = null;
            this.cdvCaliInstitute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCaliInstitute.Index = 0;
            this.cdvCaliInstitute.IsViewBtnImage = false;
            this.cdvCaliInstitute.Location = new System.Drawing.Point(131, 44);
            this.cdvCaliInstitute.MaxLength = 20;
            this.cdvCaliInstitute.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCaliInstitute.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCaliInstitute.MultiSelect = false;
            this.cdvCaliInstitute.Name = "cdvCaliInstitute";
            this.cdvCaliInstitute.ReadOnly = false;
            this.cdvCaliInstitute.SameWidthHeightOfButton = false;
            this.cdvCaliInstitute.SearchSubItemIndex = 0;
            this.cdvCaliInstitute.SelectedDescIndex = 1;
            this.cdvCaliInstitute.SelectedDescToQueryText = "";
            this.cdvCaliInstitute.SelectedSubItemIndex = 0;
            this.cdvCaliInstitute.SelectedValueToQueryText = "";
            this.cdvCaliInstitute.SelectionStart = 0;
            this.cdvCaliInstitute.Size = new System.Drawing.Size(298, 21);
            this.cdvCaliInstitute.SmallImageList = null;
            this.cdvCaliInstitute.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCaliInstitute.TabIndex = 11;
            this.cdvCaliInstitute.TextBoxToolTipText = "";
            this.cdvCaliInstitute.TextBoxWidth = 100;
            this.cdvCaliInstitute.VisibleButton = true;
            this.cdvCaliInstitute.VisibleColumnHeader = false;
            this.cdvCaliInstitute.VisibleDescription = true;
            this.cdvCaliInstitute.ButtonPress += new System.EventHandler(this.cdvCaliInstitute_ButtonPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Controls.Add(this.nudAlarmPeriod);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.cdvAlarmCode);
            this.groupBox3.Controls.Add(this.chkAlarmFlag);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 75);
            this.groupBox3.TabIndex = 105;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alarm";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label34.Location = new System.Drawing.Point(241, 22);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(65, 13);
            this.label34.TabIndex = 100;
            this.label34.Text = "Days Before";
            // 
            // nudAlarmPeriod
            // 
            this.nudAlarmPeriod.Enabled = false;
            this.nudAlarmPeriod.Location = new System.Drawing.Point(131, 19);
            this.nudAlarmPeriod.Name = "nudAlarmPeriod";
            this.nudAlarmPeriod.Size = new System.Drawing.Size(100, 20);
            this.nudAlarmPeriod.TabIndex = 16;
            this.nudAlarmPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(32, 46);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(61, 13);
            this.label33.TabIndex = 98;
            this.label33.Text = "Alarm Code";
            // 
            // cdvAlarmCode
            // 
            this.cdvAlarmCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvAlarmCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCode.BtnToolTipText = "";
            this.cdvAlarmCode.ButtonWidth = 20;
            this.cdvAlarmCode.DescText = "";
            this.cdvAlarmCode.DisplaySubItemIndex = 0;
            this.cdvAlarmCode.DisplayText = "";
            this.cdvAlarmCode.Enabled = false;
            this.cdvAlarmCode.Focusing = null;
            this.cdvAlarmCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCode.Index = 0;
            this.cdvAlarmCode.IsViewBtnImage = false;
            this.cdvAlarmCode.Location = new System.Drawing.Point(131, 42);
            this.cdvAlarmCode.MaxLength = 20;
            this.cdvAlarmCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode.MultiSelect = false;
            this.cdvAlarmCode.Name = "cdvAlarmCode";
            this.cdvAlarmCode.ReadOnly = false;
            this.cdvAlarmCode.SameWidthHeightOfButton = false;
            this.cdvAlarmCode.SearchSubItemIndex = 0;
            this.cdvAlarmCode.SelectedDescIndex = 1;
            this.cdvAlarmCode.SelectedDescToQueryText = "";
            this.cdvAlarmCode.SelectedSubItemIndex = 0;
            this.cdvAlarmCode.SelectedValueToQueryText = "";
            this.cdvAlarmCode.SelectionStart = 0;
            this.cdvAlarmCode.Size = new System.Drawing.Size(298, 21);
            this.cdvAlarmCode.SmallImageList = null;
            this.cdvAlarmCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCode.TabIndex = 17;
            this.cdvAlarmCode.TextBoxToolTipText = "";
            this.cdvAlarmCode.TextBoxWidth = 100;
            this.cdvAlarmCode.VisibleButton = true;
            this.cdvAlarmCode.VisibleColumnHeader = false;
            this.cdvAlarmCode.VisibleDescription = true;
            this.cdvAlarmCode.ButtonPress += new System.EventHandler(this.cdvAlarmCode_ButtonPress);
            // 
            // chkAlarmFlag
            // 
            this.chkAlarmFlag.AutoSize = true;
            this.chkAlarmFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAlarmFlag.Location = new System.Drawing.Point(29, 23);
            this.chkAlarmFlag.Name = "chkAlarmFlag";
            this.chkAlarmFlag.Size = new System.Drawing.Size(88, 17);
            this.chkAlarmFlag.TabIndex = 15;
            this.chkAlarmFlag.Text = "Enable Alarm";
            this.chkAlarmFlag.UseVisualStyleBackColor = true;
            this.chkAlarmFlag.CheckedChanged += new System.EventHandler(this.chkAlarmFlag_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(261, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 84;
            this.label18.Text = "Mgt Dept";
            // 
            // cdvMgtDept
            // 
            this.cdvMgtDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvMgtDept.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMgtDept.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMgtDept.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMgtDept.BtnToolTipText = "";
            this.cdvMgtDept.ButtonWidth = 20;
            this.cdvMgtDept.DescText = "";
            this.cdvMgtDept.DisplaySubItemIndex = 0;
            this.cdvMgtDept.DisplayText = "";
            this.cdvMgtDept.Focusing = null;
            this.cdvMgtDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMgtDept.Index = 0;
            this.cdvMgtDept.IsViewBtnImage = false;
            this.cdvMgtDept.Location = new System.Drawing.Point(363, 69);
            this.cdvMgtDept.MaxLength = 20;
            this.cdvMgtDept.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMgtDept.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMgtDept.MultiSelect = false;
            this.cdvMgtDept.Name = "cdvMgtDept";
            this.cdvMgtDept.ReadOnly = true;
            this.cdvMgtDept.SameWidthHeightOfButton = false;
            this.cdvMgtDept.SearchSubItemIndex = 0;
            this.cdvMgtDept.SelectedDescIndex = 1;
            this.cdvMgtDept.SelectedDescToQueryText = "";
            this.cdvMgtDept.SelectedSubItemIndex = 0;
            this.cdvMgtDept.SelectedValueToQueryText = "";
            this.cdvMgtDept.SelectionStart = 0;
            this.cdvMgtDept.Size = new System.Drawing.Size(120, 21);
            this.cdvMgtDept.SmallImageList = null;
            this.cdvMgtDept.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMgtDept.TabIndex = 8;
            this.cdvMgtDept.TextBoxToolTipText = "";
            this.cdvMgtDept.TextBoxWidth = 50;
            this.cdvMgtDept.VisibleButton = false;
            this.cdvMgtDept.VisibleColumnHeader = false;
            this.cdvMgtDept.VisibleDescription = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label16.Location = new System.Drawing.Point(13, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 13);
            this.label16.TabIndex = 83;
            this.label16.Text = "Calibration Cycle";
            // 
            // nudCalibrationCycle
            // 
            this.nudCalibrationCycle.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCalibrationCycle.InterceptArrowKeys = false;
            this.nudCalibrationCycle.Location = new System.Drawing.Point(115, 69);
            this.nudCalibrationCycle.Name = "nudCalibrationCycle";
            this.nudCalibrationCycle.ReadOnly = true;
            this.nudCalibrationCycle.Size = new System.Drawing.Size(120, 20);
            this.nudCalibrationCycle.TabIndex = 7;
            this.nudCalibrationCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(261, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Maker";
            // 
            // txtEquipMaker
            // 
            this.txtEquipMaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipMaker.Location = new System.Drawing.Point(363, 44);
            this.txtEquipMaker.MaxLength = 40;
            this.txtEquipMaker.Name = "txtEquipMaker";
            this.txtEquipMaker.ReadOnly = true;
            this.txtEquipMaker.Size = new System.Drawing.Size(120, 20);
            this.txtEquipMaker.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(261, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 80;
            this.label14.Text = "Equip Spec";
            // 
            // txtEquipSpec
            // 
            this.txtEquipSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipSpec.Location = new System.Drawing.Point(363, 19);
            this.txtEquipSpec.MaxLength = 40;
            this.txtEquipSpec.Name = "txtEquipSpec";
            this.txtEquipSpec.ReadOnly = true;
            this.txtEquipSpec.Size = new System.Drawing.Size(120, 20);
            this.txtEquipSpec.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(13, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 79;
            this.label13.Text = "Equip Model";
            // 
            // txtEquipModel
            // 
            this.txtEquipModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipModel.Location = new System.Drawing.Point(115, 44);
            this.txtEquipModel.MaxLength = 40;
            this.txtEquipModel.Name = "txtEquipModel";
            this.txtEquipModel.ReadOnly = true;
            this.txtEquipModel.Size = new System.Drawing.Size(120, 20);
            this.txtEquipModel.TabIndex = 5;
            // 
            // txtEquipNo
            // 
            this.txtEquipNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipNo.Location = new System.Drawing.Point(115, 19);
            this.txtEquipNo.MaxLength = 40;
            this.txtEquipNo.Name = "txtEquipNo";
            this.txtEquipNo.ReadOnly = true;
            this.txtEquipNo.Size = new System.Drawing.Size(120, 20);
            this.txtEquipNo.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(13, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 78;
            this.label7.Text = "Equip Number";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCreateUser);
            this.panel1.Controls.Add(this.txtUpdateTime);
            this.panel1.Controls.Add(this.lblCreate);
            this.panel1.Controls.Add(this.txtCreateTime);
            this.panel1.Controls.Add(this.lblUpdate);
            this.panel1.Controls.Add(this.txtUpdateUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 68);
            this.panel1.TabIndex = 24;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(130, 13);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(168, 20);
            this.txtCreateUser.TabIndex = 19;
            this.txtCreateUser.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(301, 37);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 23;
            this.txtUpdateTime.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(9, 15);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 18;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(301, 13);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 20;
            this.txtCreateTime.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(9, 39);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 21;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(130, 37);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(168, 20);
            this.txtUpdateUser.TabIndex = 22;
            this.txtUpdateUser.TabStop = false;
            // 
            // frmMMSCalibrationPlanSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSCalibrationPlanSetup";
            this.Text = "Calibration Plan Setup";
            this.Activated += new System.EventHandler(this.frmMMSCalibrationPlanSetup_Activated);
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
            this.tabSampling.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grbMain.ResumeLayout(false);
            this.grbMain.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliPlanDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliInstitute)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMgtDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalibrationCycle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label lblMeasuringEquipmentCode;
        private System.Windows.Forms.TextBox txtEquipName;
        private System.Windows.Forms.Label lblMeasuringEquipmentName;
        private System.Windows.Forms.TabControl tabSampling;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grbMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label label18;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMgtDept;
        private System.Windows.Forms.Label label16;
        protected System.Windows.Forms.NumericUpDown nudCalibrationCycle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEquipMaker;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEquipSpec;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEquipModel;
        private System.Windows.Forms.TextBox txtEquipNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLastCaliDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFileOpen;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCaliPlanDoc;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtCaliMethod;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCaliInstitute;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label34;
        protected System.Windows.Forms.NumericUpDown nudAlarmPeriod;
        private System.Windows.Forms.Label label33;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAlarmCode;
        private System.Windows.Forms.CheckBox chkAlarmFlag;
        private System.Windows.Forms.DateTimePicker dtpCaliPlanDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvViewEquipType;
        private System.Windows.Forms.Label label32;
    }
}