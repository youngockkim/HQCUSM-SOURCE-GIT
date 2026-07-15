namespace Custom.HanwhaQcell.USModule
{
    partial class frmJobChangeItemSetup
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
            this.tabSampling = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.nudAlarmPeriod = new System.Windows.Forms.NumericUpDown();
            this.chkAlarmFlag = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudPlanEndDate = new System.Windows.Forms.NumericUpDown();
            this.nudPlanStartDate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoUseNg = new System.Windows.Forms.RadioButton();
            this.rdoUseYes = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSqlStatus = new System.Windows.Forms.CheckBox();
            this.btnSqlTest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.cdvAlarmCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvDeptCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.grbStandradEquip = new System.Windows.Forms.GroupBox();
            this.rdoAutoFlagNo = new System.Windows.Forms.RadioButton();
            this.rdoAutoFlagYes = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabSampling.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlanEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlanStartDate)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDeptCode)).BeginInit();
            this.grbStandradEquip.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.tabSampling);
            this.pnlRight.Controls.Add(this.grpMaterial);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisView);
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
            this.lisView.Location = new System.Drawing.Point(0, 0);
            this.lisView.Name = "lisView";
            this.lisView.Size = new System.Drawing.Size(232, 506);
            this.lisView.TabIndex = 7;
            this.lisView.UseCompatibleStateImageBehavior = false;
            this.lisView.View = System.Windows.Forms.View.Details;
            this.lisView.SelectedIndexChanged += new System.EventHandler(this.lisView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Code";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 130;
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
            this.tbpGeneral.Controls.Add(this.GroupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(498, 409);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label34);
            this.GroupBox1.Controls.Add(this.nudAlarmPeriod);
            this.GroupBox1.Controls.Add(this.chkAlarmFlag);
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.nudPlanEndDate);
            this.GroupBox1.Controls.Add(this.nudPlanStartDate);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.groupBox2);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.chkSqlStatus);
            this.GroupBox1.Controls.Add(this.btnSqlTest);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txtSql);
            this.GroupBox1.Controls.Add(this.cdvAlarmCode);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.cdvDeptCode);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.grbStandradEquip);
            this.GroupBox1.Controls.Add(this.label4);
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
            this.GroupBox1.Size = new System.Drawing.Size(492, 406);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label34.Location = new System.Drawing.Point(212, 297);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(156, 13);
            this.label34.TabIndex = 103;
            this.label34.Text = "Days before the order start date";
            // 
            // nudAlarmPeriod
            // 
            this.nudAlarmPeriod.Enabled = false;
            this.nudAlarmPeriod.Location = new System.Drawing.Point(104, 295);
            this.nudAlarmPeriod.Name = "nudAlarmPeriod";
            this.nudAlarmPeriod.Size = new System.Drawing.Size(100, 20);
            this.nudAlarmPeriod.TabIndex = 102;
            this.nudAlarmPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkAlarmFlag
            // 
            this.chkAlarmFlag.AutoSize = true;
            this.chkAlarmFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAlarmFlag.Location = new System.Drawing.Point(11, 298);
            this.chkAlarmFlag.Name = "chkAlarmFlag";
            this.chkAlarmFlag.Size = new System.Drawing.Size(88, 17);
            this.chkAlarmFlag.TabIndex = 101;
            this.chkAlarmFlag.Text = "Enable Alarm";
            this.chkAlarmFlag.UseVisualStyleBackColor = true;
            this.chkAlarmFlag.CheckedChanged += new System.EventHandler(this.chkAlarmFlag_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(190, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 99;
            this.label8.Text = "~";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(296, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 13);
            this.label7.TabIndex = 98;
            this.label7.Text = "Days before the order start date";
            // 
            // nudPlanEndDate
            // 
            this.nudPlanEndDate.Location = new System.Drawing.Point(213, 63);
            this.nudPlanEndDate.Name = "nudPlanEndDate";
            this.nudPlanEndDate.Size = new System.Drawing.Size(77, 20);
            this.nudPlanEndDate.TabIndex = 97;
            this.nudPlanEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudPlanStartDate
            // 
            this.nudPlanStartDate.Location = new System.Drawing.Point(102, 63);
            this.nudPlanStartDate.Name = "nudPlanStartDate";
            this.nudPlanStartDate.Size = new System.Drawing.Size(77, 20);
            this.nudPlanStartDate.TabIndex = 96;
            this.nudPlanStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(15, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 95;
            this.label6.Text = "Start/End Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoUseNg);
            this.groupBox2.Controls.Add(this.rdoUseYes);
            this.groupBox2.Location = new System.Drawing.Point(350, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 28);
            this.groupBox2.TabIndex = 94;
            this.groupBox2.TabStop = false;
            // 
            // rdoUseNg
            // 
            this.rdoUseNg.AutoSize = true;
            this.rdoUseNg.Location = new System.Drawing.Point(67, 8);
            this.rdoUseNg.Name = "rdoUseNg";
            this.rdoUseNg.Size = new System.Drawing.Size(39, 17);
            this.rdoUseNg.TabIndex = 10;
            this.rdoUseNg.TabStop = true;
            this.rdoUseNg.Text = "No";
            this.rdoUseNg.UseVisualStyleBackColor = true;
            // 
            // rdoUseYes
            // 
            this.rdoUseYes.AutoSize = true;
            this.rdoUseYes.Checked = true;
            this.rdoUseYes.Location = new System.Drawing.Point(4, 8);
            this.rdoUseYes.Name = "rdoUseYes";
            this.rdoUseYes.Size = new System.Drawing.Size(43, 17);
            this.rdoUseYes.TabIndex = 9;
            this.rdoUseYes.TabStop = true;
            this.rdoUseYes.Text = "Yes";
            this.rdoUseYes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(263, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Use Flag";
            // 
            // chkSqlStatus
            // 
            this.chkSqlStatus.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSqlStatus.Enabled = false;
            this.chkSqlStatus.Location = new System.Drawing.Point(12, 133);
            this.chkSqlStatus.Name = "chkSqlStatus";
            this.chkSqlStatus.Size = new System.Drawing.Size(84, 22);
            this.chkSqlStatus.TabIndex = 92;
            this.chkSqlStatus.Text = "Check Ok";
            this.chkSqlStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSqlStatus.UseVisualStyleBackColor = true;
            this.chkSqlStatus.Visible = false;
            // 
            // btnSqlTest
            // 
            this.btnSqlTest.Location = new System.Drawing.Point(12, 106);
            this.btnSqlTest.Name = "btnSqlTest";
            this.btnSqlTest.Size = new System.Drawing.Size(84, 21);
            this.btnSqlTest.TabIndex = 90;
            this.btnSqlTest.Text = "Sql Test";
            this.btnSqlTest.UseVisualStyleBackColor = true;
            this.btnSqlTest.Click += new System.EventHandler(this.btnSqlTest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "Sql Text";
            // 
            // txtSql
            // 
            this.txtSql.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSql.Location = new System.Drawing.Point(102, 88);
            this.txtSql.MaxLength = 4000;
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(378, 202);
            this.txtSql.TabIndex = 88;
            this.txtSql.TextChanged += new System.EventHandler(this.txtSql_TextChanged);
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
            this.cdvAlarmCode.Focusing = null;
            this.cdvAlarmCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCode.Index = 0;
            this.cdvAlarmCode.IsViewBtnImage = false;
            this.cdvAlarmCode.Location = new System.Drawing.Point(102, 318);
            this.cdvAlarmCode.MaxLength = 40;
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
            this.cdvAlarmCode.Size = new System.Drawing.Size(378, 21);
            this.cdvAlarmCode.SmallImageList = null;
            this.cdvAlarmCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCode.TabIndex = 86;
            this.cdvAlarmCode.TextBoxToolTipText = "";
            this.cdvAlarmCode.TextBoxWidth = 130;
            this.cdvAlarmCode.VisibleButton = true;
            this.cdvAlarmCode.VisibleColumnHeader = false;
            this.cdvAlarmCode.VisibleDescription = true;
            this.cdvAlarmCode.ButtonPress += new System.EventHandler(this.cdvAlarmCode_ButtonPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(15, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Alarm Code";
            // 
            // cdvDeptCode
            // 
            this.cdvDeptCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvDeptCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDeptCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDeptCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDeptCode.BtnToolTipText = "";
            this.cdvDeptCode.ButtonWidth = 20;
            this.cdvDeptCode.DescText = "";
            this.cdvDeptCode.DisplaySubItemIndex = 0;
            this.cdvDeptCode.DisplayText = "";
            this.cdvDeptCode.Focusing = null;
            this.cdvDeptCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDeptCode.Index = 0;
            this.cdvDeptCode.IsViewBtnImage = false;
            this.cdvDeptCode.Location = new System.Drawing.Point(102, 39);
            this.cdvDeptCode.MaxLength = 40;
            this.cdvDeptCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDeptCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDeptCode.MultiSelect = false;
            this.cdvDeptCode.Name = "cdvDeptCode";
            this.cdvDeptCode.ReadOnly = false;
            this.cdvDeptCode.SameWidthHeightOfButton = false;
            this.cdvDeptCode.SearchSubItemIndex = 0;
            this.cdvDeptCode.SelectedDescIndex = 1;
            this.cdvDeptCode.SelectedDescToQueryText = "";
            this.cdvDeptCode.SelectedSubItemIndex = 0;
            this.cdvDeptCode.SelectedValueToQueryText = "";
            this.cdvDeptCode.SelectionStart = 0;
            this.cdvDeptCode.Size = new System.Drawing.Size(378, 21);
            this.cdvDeptCode.SmallImageList = null;
            this.cdvDeptCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDeptCode.TabIndex = 84;
            this.cdvDeptCode.TextBoxToolTipText = "";
            this.cdvDeptCode.TextBoxWidth = 130;
            this.cdvDeptCode.VisibleButton = true;
            this.cdvDeptCode.VisibleColumnHeader = false;
            this.cdvDeptCode.VisibleDescription = true;
            this.cdvDeptCode.ButtonPress += new System.EventHandler(this.cdvDeptCode_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Dept Code";
            // 
            // grbStandradEquip
            // 
            this.grbStandradEquip.Controls.Add(this.rdoAutoFlagNo);
            this.grbStandradEquip.Controls.Add(this.rdoAutoFlagYes);
            this.grbStandradEquip.Location = new System.Drawing.Point(102, 8);
            this.grbStandradEquip.Name = "grbStandradEquip";
            this.grbStandradEquip.Size = new System.Drawing.Size(130, 28);
            this.grbStandradEquip.TabIndex = 83;
            this.grbStandradEquip.TabStop = false;
            // 
            // rdoAutoFlagNo
            // 
            this.rdoAutoFlagNo.AutoSize = true;
            this.rdoAutoFlagNo.Location = new System.Drawing.Point(67, 8);
            this.rdoAutoFlagNo.Name = "rdoAutoFlagNo";
            this.rdoAutoFlagNo.Size = new System.Drawing.Size(39, 17);
            this.rdoAutoFlagNo.TabIndex = 10;
            this.rdoAutoFlagNo.TabStop = true;
            this.rdoAutoFlagNo.Text = "No";
            this.rdoAutoFlagNo.UseVisualStyleBackColor = true;
            // 
            // rdoAutoFlagYes
            // 
            this.rdoAutoFlagYes.AutoSize = true;
            this.rdoAutoFlagYes.Checked = true;
            this.rdoAutoFlagYes.Location = new System.Drawing.Point(4, 8);
            this.rdoAutoFlagYes.Name = "rdoAutoFlagYes";
            this.rdoAutoFlagYes.Size = new System.Drawing.Size(43, 17);
            this.rdoAutoFlagYes.TabIndex = 9;
            this.rdoAutoFlagYes.TabStop = true;
            this.rdoAutoFlagYes.Text = "Yes";
            this.rdoAutoFlagYes.UseVisualStyleBackColor = true;
            this.rdoAutoFlagYes.CheckedChanged += new System.EventHandler(this.rdoAutoFlagYes_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(15, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Auto Flag";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(304, 372);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 23;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(304, 348);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 20;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(133, 372);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(168, 20);
            this.txtUpdateUser.TabIndex = 22;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(12, 374);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 21;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(133, 348);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(168, 20);
            this.txtCreateUser.TabIndex = 19;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(12, 350);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 18;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.txtItemCode);
            this.grpMaterial.Controls.Add(this.lblItemCode);
            this.grpMaterial.Controls.Add(this.txtItemName);
            this.grpMaterial.Controls.Add(this.lblItemDesc);
            this.grpMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterial.Location = new System.Drawing.Point(0, 0);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Size = new System.Drawing.Size(506, 71);
            this.grpMaterial.TabIndex = 4;
            this.grpMaterial.TabStop = false;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(109, 14);
            this.txtItemCode.MaxLength = 50;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(199, 20);
            this.txtItemCode.TabIndex = 6;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemCode.Location = new System.Drawing.Point(16, 18);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(64, 13);
            this.lblItemCode.TabIndex = 3;
            this.lblItemCode.Text = "Item Code";
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(109, 40);
            this.txtItemName.MaxLength = 100;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(387, 20);
            this.txtItemName.TabIndex = 7;
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDesc.Location = new System.Drawing.Point(16, 43);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(60, 13);
            this.lblItemDesc.TabIndex = 1;
            this.lblItemDesc.Text = "Description";
            this.lblItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmJobChangeItemSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmJobChangeItemSetup";
            this.Text = "Job Change Item Setup";
            this.Activated += new System.EventHandler(this.frmJobChangeItemSetup_Activated);
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
            this.tabSampling.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlanEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlanStartDate)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDeptCode)).EndInit();
            this.grbStandradEquip.ResumeLayout(false);
            this.grbStandradEquip.PerformLayout();
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lisView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabControl tabSampling;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.GroupBox grbStandradEquip;
        private System.Windows.Forms.RadioButton rdoAutoFlagNo;
        private System.Windows.Forms.RadioButton rdoAutoFlagYes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemDesc;
        private System.Windows.Forms.Label label3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAlarmCode;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDeptCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSqlTest;
        private System.Windows.Forms.CheckBox chkSqlStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoUseNg;
        private System.Windows.Forms.RadioButton rdoUseYes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPlanEndDate;
        private System.Windows.Forms.NumericUpDown nudPlanStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Label label34;
        protected System.Windows.Forms.NumericUpDown nudAlarmPeriod;
        private System.Windows.Forms.CheckBox chkAlarmFlag;
    }
}