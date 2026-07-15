namespace Custom.HanwhaQcell.USModule
{
    partial class frmProdMonitoringSetup
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
            this.colMainCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coldesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlListTop = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cdvViewCategory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblItemGroup = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabSampling = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.nudBaseDTTime = new System.Windows.Forms.NumericUpDown();
            this.txtPrinterMessage = new System.Windows.Forms.TextBox();
            this.txtPrinterStatus = new System.Windows.Forms.TextBox();
            this.pnlSOIStatus = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grbStandradEquip = new System.Windows.Forms.GroupBox();
            this.rdoPrinterCheckNo = new System.Windows.Forms.RadioButton();
            this.rdoPrinterCheckYes = new System.Windows.Forms.RadioButton();
            this.txtLoginUserID = new System.Windows.Forms.TextBox();
            this.txtClientVersion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cdvOption4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvOption5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label9 = new System.Windows.Forms.Label();
            this.cdvOption3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label8 = new System.Windows.Forms.Label();
            this.cdvOption2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label7 = new System.Windows.Forms.Label();
            this.cdvOption1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastTranTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cdvCategory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.txtSubCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMainCode = new System.Windows.Forms.TextBox();
            this.lblIMainCode = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlListTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewCategory)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabSampling.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseDTTime)).BeginInit();
            this.pnlSOIStatus.SuspendLayout();
            this.grbStandradEquip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCategory)).BeginInit();
            this.grpMaterial.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.panel1);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisView);
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
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // lisView
            // 
            this.lisView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMainCode,
            this.colSubCode,
            this.coldesc});
            this.lisView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisView.FullRowSelect = true;
            this.lisView.Location = new System.Drawing.Point(0, 48);
            this.lisView.Name = "lisView";
            this.lisView.Size = new System.Drawing.Size(232, 458);
            this.lisView.TabIndex = 4;
            this.lisView.UseCompatibleStateImageBehavior = false;
            this.lisView.View = System.Windows.Forms.View.Details;
            this.lisView.SelectedIndexChanged += new System.EventHandler(this.lisView_SelectedIndexChanged);
            // 
            // colMainCode
            // 
            this.colMainCode.Text = "Base Code";
            this.colMainCode.Width = 90;
            // 
            // colSubCode
            // 
            this.colSubCode.Text = "Sub Code";
            this.colSubCode.Width = 80;
            // 
            // coldesc
            // 
            this.coldesc.Text = "Description";
            this.coldesc.Width = 130;
            // 
            // pnlListTop
            // 
            this.pnlListTop.Controls.Add(this.groupBox2);
            this.pnlListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListTop.Location = new System.Drawing.Point(0, 0);
            this.pnlListTop.Name = "pnlListTop";
            this.pnlListTop.Size = new System.Drawing.Size(232, 48);
            this.pnlListTop.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cdvViewCategory);
            this.groupBox2.Controls.Add(this.lblItemGroup);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 48);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // cdvViewCategory
            // 
            this.cdvViewCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvViewCategory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvViewCategory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvViewCategory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvViewCategory.BtnToolTipText = "";
            this.cdvViewCategory.ButtonWidth = 20;
            this.cdvViewCategory.DescText = "";
            this.cdvViewCategory.DisplaySubItemIndex = 0;
            this.cdvViewCategory.DisplayText = "";
            this.cdvViewCategory.Focusing = null;
            this.cdvViewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvViewCategory.Index = 0;
            this.cdvViewCategory.IsViewBtnImage = false;
            this.cdvViewCategory.Location = new System.Drawing.Point(91, 17);
            this.cdvViewCategory.MaxLength = 20;
            this.cdvViewCategory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvViewCategory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvViewCategory.MultiSelect = false;
            this.cdvViewCategory.Name = "cdvViewCategory";
            this.cdvViewCategory.ReadOnly = false;
            this.cdvViewCategory.SameWidthHeightOfButton = false;
            this.cdvViewCategory.SearchSubItemIndex = 0;
            this.cdvViewCategory.SelectedDescIndex = -1;
            this.cdvViewCategory.SelectedDescToQueryText = "";
            this.cdvViewCategory.SelectedSubItemIndex = 0;
            this.cdvViewCategory.SelectedValueToQueryText = "";
            this.cdvViewCategory.SelectionStart = 0;
            this.cdvViewCategory.Size = new System.Drawing.Size(128, 20);
            this.cdvViewCategory.SmallImageList = null;
            this.cdvViewCategory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvViewCategory.TabIndex = 4;
            this.cdvViewCategory.TextBoxToolTipText = "";
            this.cdvViewCategory.TextBoxWidth = 128;
            this.cdvViewCategory.VisibleButton = true;
            this.cdvViewCategory.VisibleColumnHeader = false;
            this.cdvViewCategory.VisibleDescription = false;
            this.cdvViewCategory.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvViewCategory_SelectedItemChanged);
            this.cdvViewCategory.ButtonPress += new System.EventHandler(this.cdvViewCategory_ButtonPress);
            // 
            // lblItemGroup
            // 
            this.lblItemGroup.AutoSize = true;
            this.lblItemGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblItemGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemGroup.Location = new System.Drawing.Point(14, 20);
            this.lblItemGroup.Name = "lblItemGroup";
            this.lblItemGroup.Size = new System.Drawing.Size(57, 13);
            this.lblItemGroup.TabIndex = 3;
            this.lblItemGroup.Text = "Category";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabSampling);
            this.panel1.Controls.Add(this.grpMaterial);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 506);
            this.panel1.TabIndex = 0;
            // 
            // tabSampling
            // 
            this.tabSampling.Controls.Add(this.tbpGeneral);
            this.tabSampling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabSampling.ItemSize = new System.Drawing.Size(60, 18);
            this.tabSampling.Location = new System.Drawing.Point(0, 87);
            this.tabSampling.Name = "tabSampling";
            this.tabSampling.SelectedIndex = 0;
            this.tabSampling.Size = new System.Drawing.Size(506, 419);
            this.tabSampling.TabIndex = 3;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.GroupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(498, 393);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.nudBaseDTTime);
            this.GroupBox1.Controls.Add(this.txtPrinterMessage);
            this.GroupBox1.Controls.Add(this.txtPrinterStatus);
            this.GroupBox1.Controls.Add(this.pnlSOIStatus);
            this.GroupBox1.Controls.Add(this.label13);
            this.GroupBox1.Controls.Add(this.label10);
            this.GroupBox1.Controls.Add(this.cdvOption4);
            this.GroupBox1.Controls.Add(this.cdvOption5);
            this.GroupBox1.Controls.Add(this.label9);
            this.GroupBox1.Controls.Add(this.cdvOption3);
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.cdvOption2);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.cdvOption1);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.txtLastTranTime);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.cdvCategory);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.txtUpdateTime);
            this.GroupBox1.Controls.Add(this.txtCreateTime);
            this.GroupBox1.Controls.Add(this.txtUpdateUser);
            this.GroupBox1.Controls.Add(this.lblUpdate);
            this.GroupBox1.Controls.Add(this.txtCreateUser);
            this.GroupBox1.Controls.Add(this.lblCreate);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(3, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(492, 390);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // nudBaseDTTime
            // 
            this.nudBaseDTTime.Location = new System.Drawing.Point(128, 164);
            this.nudBaseDTTime.Name = "nudBaseDTTime";
            this.nudBaseDTTime.Size = new System.Drawing.Size(110, 20);
            this.nudBaseDTTime.TabIndex = 11;
            this.nudBaseDTTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPrinterMessage
            // 
            this.txtPrinterMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrinterMessage.Location = new System.Drawing.Point(230, 294);
            this.txtPrinterMessage.MaxLength = 11;
            this.txtPrinterMessage.Name = "txtPrinterMessage";
            this.txtPrinterMessage.ReadOnly = true;
            this.txtPrinterMessage.Size = new System.Drawing.Size(245, 20);
            this.txtPrinterMessage.TabIndex = 101;
            this.txtPrinterMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPrinterStatus
            // 
            this.txtPrinterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrinterStatus.Location = new System.Drawing.Point(128, 294);
            this.txtPrinterStatus.MaxLength = 11;
            this.txtPrinterStatus.Name = "txtPrinterStatus";
            this.txtPrinterStatus.ReadOnly = true;
            this.txtPrinterStatus.Size = new System.Drawing.Size(96, 20);
            this.txtPrinterStatus.TabIndex = 99;
            this.txtPrinterStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlSOIStatus
            // 
            this.pnlSOIStatus.Controls.Add(this.label4);
            this.pnlSOIStatus.Controls.Add(this.label11);
            this.pnlSOIStatus.Controls.Add(this.grbStandradEquip);
            this.pnlSOIStatus.Controls.Add(this.txtLoginUserID);
            this.pnlSOIStatus.Controls.Add(this.txtClientVersion);
            this.pnlSOIStatus.Controls.Add(this.label12);
            this.pnlSOIStatus.Location = new System.Drawing.Point(10, 184);
            this.pnlSOIStatus.Name = "pnlSOIStatus";
            this.pnlSOIStatus.Size = new System.Drawing.Size(478, 78);
            this.pnlSOIStatus.TabIndex = 101;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(5, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Printer Check";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(5, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 96;
            this.label11.Text = "Login User ID";
            // 
            // grbStandradEquip
            // 
            this.grbStandradEquip.Controls.Add(this.rdoPrinterCheckNo);
            this.grbStandradEquip.Controls.Add(this.rdoPrinterCheckYes);
            this.grbStandradEquip.Location = new System.Drawing.Point(118, 0);
            this.grbStandradEquip.Name = "grbStandradEquip";
            this.grbStandradEquip.Size = new System.Drawing.Size(110, 28);
            this.grbStandradEquip.TabIndex = 82;
            this.grbStandradEquip.TabStop = false;
            // 
            // rdoPrinterCheckNo
            // 
            this.rdoPrinterCheckNo.AutoSize = true;
            this.rdoPrinterCheckNo.Checked = true;
            this.rdoPrinterCheckNo.Location = new System.Drawing.Point(57, 8);
            this.rdoPrinterCheckNo.Name = "rdoPrinterCheckNo";
            this.rdoPrinterCheckNo.Size = new System.Drawing.Size(39, 17);
            this.rdoPrinterCheckNo.TabIndex = 13;
            this.rdoPrinterCheckNo.TabStop = true;
            this.rdoPrinterCheckNo.Text = "No";
            this.rdoPrinterCheckNo.UseVisualStyleBackColor = true;
            // 
            // rdoPrinterCheckYes
            // 
            this.rdoPrinterCheckYes.AutoSize = true;
            this.rdoPrinterCheckYes.Location = new System.Drawing.Point(4, 8);
            this.rdoPrinterCheckYes.Name = "rdoPrinterCheckYes";
            this.rdoPrinterCheckYes.Size = new System.Drawing.Size(43, 17);
            this.rdoPrinterCheckYes.TabIndex = 12;
            this.rdoPrinterCheckYes.Text = "Yes";
            this.rdoPrinterCheckYes.UseVisualStyleBackColor = true;
            // 
            // txtLoginUserID
            // 
            this.txtLoginUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginUserID.Location = new System.Drawing.Point(118, 31);
            this.txtLoginUserID.MaxLength = 11;
            this.txtLoginUserID.Name = "txtLoginUserID";
            this.txtLoginUserID.ReadOnly = true;
            this.txtLoginUserID.Size = new System.Drawing.Size(184, 20);
            this.txtLoginUserID.TabIndex = 95;
            this.txtLoginUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClientVersion
            // 
            this.txtClientVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientVersion.Location = new System.Drawing.Point(118, 55);
            this.txtClientVersion.MaxLength = 11;
            this.txtClientVersion.Name = "txtClientVersion";
            this.txtClientVersion.ReadOnly = true;
            this.txtClientVersion.Size = new System.Drawing.Size(184, 20);
            this.txtClientVersion.TabIndex = 97;
            this.txtClientVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(5, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 98;
            this.label12.Text = "Client Version";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(15, 298);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 13);
            this.label13.TabIndex = 100;
            this.label13.Text = "Printer Status/Message";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(15, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 94;
            this.label10.Text = "Category";
            // 
            // cdvOption4
            // 
            this.cdvOption4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvOption4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOption4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOption4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOption4.BtnToolTipText = "";
            this.cdvOption4.ButtonWidth = 20;
            this.cdvOption4.DescText = "";
            this.cdvOption4.DisplaySubItemIndex = 0;
            this.cdvOption4.DisplayText = "";
            this.cdvOption4.Focusing = null;
            this.cdvOption4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOption4.Index = 0;
            this.cdvOption4.IsViewBtnImage = false;
            this.cdvOption4.Location = new System.Drawing.Point(128, 115);
            this.cdvOption4.MaxLength = 40;
            this.cdvOption4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOption4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOption4.MultiSelect = false;
            this.cdvOption4.Name = "cdvOption4";
            this.cdvOption4.ReadOnly = false;
            this.cdvOption4.SameWidthHeightOfButton = false;
            this.cdvOption4.SearchSubItemIndex = 0;
            this.cdvOption4.SelectedDescIndex = 1;
            this.cdvOption4.SelectedDescToQueryText = "";
            this.cdvOption4.SelectedSubItemIndex = 0;
            this.cdvOption4.SelectedValueToQueryText = "";
            this.cdvOption4.SelectionStart = 0;
            this.cdvOption4.Size = new System.Drawing.Size(347, 21);
            this.cdvOption4.SmallImageList = null;
            this.cdvOption4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOption4.TabIndex = 93;
            this.cdvOption4.TextBoxToolTipText = "";
            this.cdvOption4.TextBoxWidth = 120;
            this.cdvOption4.VisibleButton = true;
            this.cdvOption4.VisibleColumnHeader = false;
            this.cdvOption4.VisibleDescription = true;
            this.cdvOption4.ButtonPress += new System.EventHandler(this.cdvOption_ButtonPress);
            // 
            // cdvOption5
            // 
            this.cdvOption5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvOption5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOption5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOption5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOption5.BtnToolTipText = "";
            this.cdvOption5.ButtonWidth = 20;
            this.cdvOption5.DescText = "";
            this.cdvOption5.DisplaySubItemIndex = 0;
            this.cdvOption5.DisplayText = "";
            this.cdvOption5.Focusing = null;
            this.cdvOption5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOption5.Index = 0;
            this.cdvOption5.IsViewBtnImage = false;
            this.cdvOption5.Location = new System.Drawing.Point(128, 139);
            this.cdvOption5.MaxLength = 40;
            this.cdvOption5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOption5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOption5.MultiSelect = false;
            this.cdvOption5.Name = "cdvOption5";
            this.cdvOption5.ReadOnly = false;
            this.cdvOption5.SameWidthHeightOfButton = false;
            this.cdvOption5.SearchSubItemIndex = 0;
            this.cdvOption5.SelectedDescIndex = 1;
            this.cdvOption5.SelectedDescToQueryText = "";
            this.cdvOption5.SelectedSubItemIndex = 0;
            this.cdvOption5.SelectedValueToQueryText = "";
            this.cdvOption5.SelectionStart = 0;
            this.cdvOption5.Size = new System.Drawing.Size(347, 21);
            this.cdvOption5.SmallImageList = null;
            this.cdvOption5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOption5.TabIndex = 91;
            this.cdvOption5.TextBoxToolTipText = "";
            this.cdvOption5.TextBoxWidth = 120;
            this.cdvOption5.VisibleButton = true;
            this.cdvOption5.VisibleColumnHeader = false;
            this.cdvOption5.VisibleDescription = true;
            this.cdvOption5.ButtonPress += new System.EventHandler(this.cdvOption_ButtonPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(15, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 92;
            this.label9.Text = "Option #5";
            // 
            // cdvOption3
            // 
            this.cdvOption3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvOption3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOption3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOption3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOption3.BtnToolTipText = "";
            this.cdvOption3.ButtonWidth = 20;
            this.cdvOption3.DescText = "";
            this.cdvOption3.DisplaySubItemIndex = 0;
            this.cdvOption3.DisplayText = "";
            this.cdvOption3.Focusing = null;
            this.cdvOption3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOption3.Index = 0;
            this.cdvOption3.IsViewBtnImage = false;
            this.cdvOption3.Location = new System.Drawing.Point(128, 91);
            this.cdvOption3.MaxLength = 40;
            this.cdvOption3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOption3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOption3.MultiSelect = false;
            this.cdvOption3.Name = "cdvOption3";
            this.cdvOption3.ReadOnly = false;
            this.cdvOption3.SameWidthHeightOfButton = false;
            this.cdvOption3.SearchSubItemIndex = 0;
            this.cdvOption3.SelectedDescIndex = 1;
            this.cdvOption3.SelectedDescToQueryText = "";
            this.cdvOption3.SelectedSubItemIndex = 0;
            this.cdvOption3.SelectedValueToQueryText = "";
            this.cdvOption3.SelectionStart = 0;
            this.cdvOption3.Size = new System.Drawing.Size(347, 21);
            this.cdvOption3.SmallImageList = null;
            this.cdvOption3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOption3.TabIndex = 89;
            this.cdvOption3.TextBoxToolTipText = "";
            this.cdvOption3.TextBoxWidth = 120;
            this.cdvOption3.VisibleButton = true;
            this.cdvOption3.VisibleColumnHeader = false;
            this.cdvOption3.VisibleDescription = true;
            this.cdvOption3.ButtonPress += new System.EventHandler(this.cdvOption_ButtonPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(15, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "Option #4";
            // 
            // cdvOption2
            // 
            this.cdvOption2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvOption2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOption2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOption2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOption2.BtnToolTipText = "";
            this.cdvOption2.ButtonWidth = 20;
            this.cdvOption2.DescText = "";
            this.cdvOption2.DisplaySubItemIndex = 0;
            this.cdvOption2.DisplayText = "";
            this.cdvOption2.Focusing = null;
            this.cdvOption2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOption2.Index = 0;
            this.cdvOption2.IsViewBtnImage = false;
            this.cdvOption2.Location = new System.Drawing.Point(128, 67);
            this.cdvOption2.MaxLength = 40;
            this.cdvOption2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOption2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOption2.MultiSelect = false;
            this.cdvOption2.Name = "cdvOption2";
            this.cdvOption2.ReadOnly = false;
            this.cdvOption2.SameWidthHeightOfButton = false;
            this.cdvOption2.SearchSubItemIndex = 0;
            this.cdvOption2.SelectedDescIndex = 1;
            this.cdvOption2.SelectedDescToQueryText = "";
            this.cdvOption2.SelectedSubItemIndex = 0;
            this.cdvOption2.SelectedValueToQueryText = "";
            this.cdvOption2.SelectionStart = 0;
            this.cdvOption2.Size = new System.Drawing.Size(347, 21);
            this.cdvOption2.SmallImageList = null;
            this.cdvOption2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOption2.TabIndex = 87;
            this.cdvOption2.TextBoxToolTipText = "";
            this.cdvOption2.TextBoxWidth = 120;
            this.cdvOption2.VisibleButton = true;
            this.cdvOption2.VisibleColumnHeader = false;
            this.cdvOption2.VisibleDescription = true;
            this.cdvOption2.ButtonPress += new System.EventHandler(this.cdvOption_ButtonPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(15, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Option #3";
            // 
            // cdvOption1
            // 
            this.cdvOption1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvOption1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOption1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOption1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOption1.BtnToolTipText = "";
            this.cdvOption1.ButtonWidth = 20;
            this.cdvOption1.DescText = "";
            this.cdvOption1.DisplaySubItemIndex = 0;
            this.cdvOption1.DisplayText = "";
            this.cdvOption1.Focusing = null;
            this.cdvOption1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOption1.Index = 0;
            this.cdvOption1.IsViewBtnImage = false;
            this.cdvOption1.Location = new System.Drawing.Point(128, 43);
            this.cdvOption1.MaxLength = 40;
            this.cdvOption1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOption1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOption1.MultiSelect = false;
            this.cdvOption1.Name = "cdvOption1";
            this.cdvOption1.ReadOnly = false;
            this.cdvOption1.SameWidthHeightOfButton = false;
            this.cdvOption1.SearchSubItemIndex = 0;
            this.cdvOption1.SelectedDescIndex = 1;
            this.cdvOption1.SelectedDescToQueryText = "";
            this.cdvOption1.SelectedSubItemIndex = 0;
            this.cdvOption1.SelectedValueToQueryText = "";
            this.cdvOption1.SelectionStart = 0;
            this.cdvOption1.Size = new System.Drawing.Size(347, 21);
            this.cdvOption1.SmallImageList = null;
            this.cdvOption1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOption1.TabIndex = 85;
            this.cdvOption1.TextBoxToolTipText = "";
            this.cdvOption1.TextBoxWidth = 120;
            this.cdvOption1.VisibleButton = true;
            this.cdvOption1.VisibleColumnHeader = false;
            this.cdvOption1.VisibleDescription = true;
            this.cdvOption1.ButtonPress += new System.EventHandler(this.cdvOption_ButtonPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Option #2";
            // 
            // txtLastTranTime
            // 
            this.txtLastTranTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastTranTime.Location = new System.Drawing.Point(128, 268);
            this.txtLastTranTime.MaxLength = 11;
            this.txtLastTranTime.Name = "txtLastTranTime";
            this.txtLastTranTime.ReadOnly = true;
            this.txtLastTranTime.Size = new System.Drawing.Size(184, 20);
            this.txtLastTranTime.TabIndex = 83;
            this.txtLastTranTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(15, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "Last Tran Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(15, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Base D/T Time(Min)";
            // 
            // cdvCategory
            // 
            this.cdvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCategory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCategory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCategory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCategory.BtnToolTipText = "";
            this.cdvCategory.ButtonWidth = 20;
            this.cdvCategory.DescText = "";
            this.cdvCategory.DisplaySubItemIndex = 0;
            this.cdvCategory.DisplayText = "";
            this.cdvCategory.Focusing = null;
            this.cdvCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCategory.Index = 0;
            this.cdvCategory.IsViewBtnImage = false;
            this.cdvCategory.Location = new System.Drawing.Point(128, 19);
            this.cdvCategory.MaxLength = 40;
            this.cdvCategory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCategory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCategory.MultiSelect = false;
            this.cdvCategory.Name = "cdvCategory";
            this.cdvCategory.ReadOnly = false;
            this.cdvCategory.SameWidthHeightOfButton = false;
            this.cdvCategory.SearchSubItemIndex = 0;
            this.cdvCategory.SelectedDescIndex = 1;
            this.cdvCategory.SelectedDescToQueryText = "";
            this.cdvCategory.SelectedSubItemIndex = 0;
            this.cdvCategory.SelectedValueToQueryText = "";
            this.cdvCategory.SelectionStart = 0;
            this.cdvCategory.Size = new System.Drawing.Size(347, 21);
            this.cdvCategory.SmallImageList = null;
            this.cdvCategory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCategory.TabIndex = 7;
            this.cdvCategory.TextBoxToolTipText = "";
            this.cdvCategory.TextBoxWidth = 120;
            this.cdvCategory.VisibleButton = true;
            this.cdvCategory.VisibleColumnHeader = false;
            this.cdvCategory.VisibleDescription = true;
            this.cdvCategory.ButtonPress += new System.EventHandler(this.cdvCategory_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Option #1";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(275, 362);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(200, 20);
            this.txtUpdateTime.TabIndex = 23;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(275, 338);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(200, 20);
            this.txtCreateTime.TabIndex = 20;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(128, 362);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(141, 20);
            this.txtUpdateUser.TabIndex = 22;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(12, 364);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 21;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(128, 338);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(141, 20);
            this.txtCreateUser.TabIndex = 19;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(12, 340);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 18;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.txtSubCode);
            this.grpMaterial.Controls.Add(this.label6);
            this.grpMaterial.Controls.Add(this.txtMainCode);
            this.grpMaterial.Controls.Add(this.lblIMainCode);
            this.grpMaterial.Controls.Add(this.txtDescription);
            this.grpMaterial.Controls.Add(this.lblItemDesc);
            this.grpMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterial.Location = new System.Drawing.Point(0, 0);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Size = new System.Drawing.Size(506, 87);
            this.grpMaterial.TabIndex = 2;
            this.grpMaterial.TabStop = false;
            // 
            // txtSubCode
            // 
            this.txtSubCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCode.Location = new System.Drawing.Point(135, 37);
            this.txtSubCode.MaxLength = 50;
            this.txtSubCode.Name = "txtSubCode";
            this.txtSubCode.Size = new System.Drawing.Size(141, 20);
            this.txtSubCode.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(16, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Sub Code";
            // 
            // txtMainCode
            // 
            this.txtMainCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMainCode.Location = new System.Drawing.Point(135, 14);
            this.txtMainCode.MaxLength = 50;
            this.txtMainCode.Name = "txtMainCode";
            this.txtMainCode.Size = new System.Drawing.Size(141, 20);
            this.txtMainCode.TabIndex = 5;
            // 
            // lblIMainCode
            // 
            this.lblIMainCode.AutoSize = true;
            this.lblIMainCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblIMainCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMainCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblIMainCode.Location = new System.Drawing.Point(16, 18);
            this.lblIMainCode.Name = "lblIMainCode";
            this.lblIMainCode.Size = new System.Drawing.Size(68, 13);
            this.lblIMainCode.TabIndex = 3;
            this.lblIMainCode.Text = "Base Code";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(135, 60);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(361, 20);
            this.txtDescription.TabIndex = 6;
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDesc.Location = new System.Drawing.Point(16, 64);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(60, 13);
            this.lblItemDesc.TabIndex = 1;
            this.lblItemDesc.Text = "Description";
            this.lblItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmProdMonitoringSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmProdMonitoringSetup";
            this.Text = "Product Site Monitoring Setup";
            this.Activated += new System.EventHandler(this.frmProdMonitoringSetup_Activated);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewCategory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabSampling.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaseDTTime)).EndInit();
            this.pnlSOIStatus.ResumeLayout(false);
            this.pnlSOIStatus.PerformLayout();
            this.grbStandradEquip.ResumeLayout(false);
            this.grbStandradEquip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOption1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCategory)).EndInit();
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lisView;
        private System.Windows.Forms.ColumnHeader colMainCode;
        private System.Windows.Forms.ColumnHeader coldesc;
        private System.Windows.Forms.Panel pnlListTop;
        private System.Windows.Forms.GroupBox groupBox2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvViewCategory;
        private System.Windows.Forms.Label lblItemGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.TextBox txtMainCode;
        private System.Windows.Forms.Label lblIMainCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblItemDesc;
        private System.Windows.Forms.TabControl tabSampling;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.GroupBox grbStandradEquip;
        private System.Windows.Forms.RadioButton rdoPrinterCheckNo;
        private System.Windows.Forms.RadioButton rdoPrinterCheckYes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.NumericUpDown nudBaseDTTime;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TextBox txtSubCode;
        private System.Windows.Forms.Label label6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOption5;
        private System.Windows.Forms.Label label9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOption3;
        private System.Windows.Forms.Label label8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOption2;
        private System.Windows.Forms.Label label7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOption1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastTranTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colSubCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOption4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlSOIStatus;
        private System.Windows.Forms.TextBox txtPrinterMessage;
        private System.Windows.Forms.TextBox txtPrinterStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLoginUserID;
        private System.Windows.Forms.TextBox txtClientVersion;
        private System.Windows.Forms.Label label12;


    }
}