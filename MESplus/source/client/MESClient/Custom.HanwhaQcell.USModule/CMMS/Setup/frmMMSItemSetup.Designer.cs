namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSItemSetup
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
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.pnlListTop = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cdvViewItemGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblItemGroup = new System.Windows.Forms.Label();
            this.lisView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabSampling = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.grbStandradEquip = new System.Windows.Forms.GroupBox();
            this.rdoUseFlagNo = new System.Windows.Forms.RadioButton();
            this.rdoUseFlagYes = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudDecimalPlace = new System.Windows.Forms.NumericUpDown();
            this.cdvUnit = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUSL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvItemGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLSL = new System.Windows.Forms.TextBox();
            this.lblLSL = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpMaterial.SuspendLayout();
            this.pnlListTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewItemGroup)).BeginInit();
            this.tabSampling.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.grbStandradEquip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecimalPlace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvItemGroup)).BeginInit();
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
            this.grpMaterial.TabIndex = 1;
            this.grpMaterial.TabStop = false;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(135, 14);
            this.txtItemCode.MaxLength = 50;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(173, 20);
            this.txtItemCode.TabIndex = 5;
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
            this.txtItemName.Location = new System.Drawing.Point(135, 40);
            this.txtItemName.MaxLength = 100;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(361, 20);
            this.txtItemName.TabIndex = 6;
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
            // pnlListTop
            // 
            this.pnlListTop.Controls.Add(this.groupBox2);
            this.pnlListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListTop.Location = new System.Drawing.Point(0, 0);
            this.pnlListTop.Name = "pnlListTop";
            this.pnlListTop.Size = new System.Drawing.Size(232, 48);
            this.pnlListTop.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cdvViewItemGroup);
            this.groupBox2.Controls.Add(this.lblItemGroup);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 48);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // cdvViewItemGroup
            // 
            this.cdvViewItemGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvViewItemGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvViewItemGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvViewItemGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvViewItemGroup.BtnToolTipText = "";
            this.cdvViewItemGroup.ButtonWidth = 20;
            this.cdvViewItemGroup.DescText = "";
            this.cdvViewItemGroup.DisplaySubItemIndex = 0;
            this.cdvViewItemGroup.DisplayText = "";
            this.cdvViewItemGroup.Focusing = null;
            this.cdvViewItemGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvViewItemGroup.Index = 0;
            this.cdvViewItemGroup.IsViewBtnImage = false;
            this.cdvViewItemGroup.Location = new System.Drawing.Point(91, 17);
            this.cdvViewItemGroup.MaxLength = 20;
            this.cdvViewItemGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvViewItemGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvViewItemGroup.MultiSelect = false;
            this.cdvViewItemGroup.Name = "cdvViewItemGroup";
            this.cdvViewItemGroup.ReadOnly = false;
            this.cdvViewItemGroup.SameWidthHeightOfButton = false;
            this.cdvViewItemGroup.SearchSubItemIndex = 0;
            this.cdvViewItemGroup.SelectedDescIndex = -1;
            this.cdvViewItemGroup.SelectedDescToQueryText = "";
            this.cdvViewItemGroup.SelectedSubItemIndex = 0;
            this.cdvViewItemGroup.SelectedValueToQueryText = "";
            this.cdvViewItemGroup.SelectionStart = 0;
            this.cdvViewItemGroup.Size = new System.Drawing.Size(128, 20);
            this.cdvViewItemGroup.SmallImageList = null;
            this.cdvViewItemGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvViewItemGroup.TabIndex = 4;
            this.cdvViewItemGroup.TextBoxToolTipText = "";
            this.cdvViewItemGroup.TextBoxWidth = 128;
            this.cdvViewItemGroup.VisibleButton = true;
            this.cdvViewItemGroup.VisibleColumnHeader = false;
            this.cdvViewItemGroup.VisibleDescription = false;
            this.cdvViewItemGroup.ButtonPress += new System.EventHandler(this.cdvViewItemGroup_ButtonPress);
            this.cdvViewItemGroup.TextBoxTextChanged += new System.EventHandler(this.cdvViewItemGroup_TextBoxTextChanged);
            // 
            // lblItemGroup
            // 
            this.lblItemGroup.AutoSize = true;
            this.lblItemGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblItemGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItemGroup.Location = new System.Drawing.Point(14, 20);
            this.lblItemGroup.Name = "lblItemGroup";
            this.lblItemGroup.Size = new System.Drawing.Size(59, 13);
            this.lblItemGroup.TabIndex = 3;
            this.lblItemGroup.Text = "Item Group";
            // 
            // lisView
            // 
            this.lisView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lisView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisView.FullRowSelect = true;
            this.lisView.Location = new System.Drawing.Point(0, 48);
            this.lisView.Name = "lisView";
            this.lisView.Size = new System.Drawing.Size(232, 458);
            this.lisView.TabIndex = 2;
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
            this.tabSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabSampling.ItemSize = new System.Drawing.Size(60, 18);
            this.tabSampling.Location = new System.Drawing.Point(0, 71);
            this.tabSampling.Name = "tabSampling";
            this.tabSampling.SelectedIndex = 0;
            this.tabSampling.Size = new System.Drawing.Size(506, 435);
            this.tabSampling.TabIndex = 2;
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
            this.GroupBox1.Controls.Add(this.grbStandradEquip);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.nudDecimalPlace);
            this.GroupBox1.Controls.Add(this.cdvUnit);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txtUSL);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.cdvItemGroup);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.txtLSL);
            this.GroupBox1.Controls.Add(this.lblLSL);
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
            // grbStandradEquip
            // 
            this.grbStandradEquip.Controls.Add(this.rdoUseFlagNo);
            this.grbStandradEquip.Controls.Add(this.rdoUseFlagYes);
            this.grbStandradEquip.Location = new System.Drawing.Point(133, 156);
            this.grbStandradEquip.Name = "grbStandradEquip";
            this.grbStandradEquip.Size = new System.Drawing.Size(110, 28);
            this.grbStandradEquip.TabIndex = 82;
            this.grbStandradEquip.TabStop = false;
            // 
            // rdoUseFlagNo
            // 
            this.rdoUseFlagNo.AutoSize = true;
            this.rdoUseFlagNo.Location = new System.Drawing.Point(57, 8);
            this.rdoUseFlagNo.Name = "rdoUseFlagNo";
            this.rdoUseFlagNo.Size = new System.Drawing.Size(39, 17);
            this.rdoUseFlagNo.TabIndex = 13;
            this.rdoUseFlagNo.TabStop = true;
            this.rdoUseFlagNo.Text = "No";
            this.rdoUseFlagNo.UseVisualStyleBackColor = true;
            // 
            // rdoUseFlagYes
            // 
            this.rdoUseFlagYes.AutoSize = true;
            this.rdoUseFlagYes.Checked = true;
            this.rdoUseFlagYes.Location = new System.Drawing.Point(4, 8);
            this.rdoUseFlagYes.Name = "rdoUseFlagYes";
            this.rdoUseFlagYes.Size = new System.Drawing.Size(43, 17);
            this.rdoUseFlagYes.TabIndex = 12;
            this.rdoUseFlagYes.TabStop = true;
            this.rdoUseFlagYes.Text = "Yes";
            this.rdoUseFlagYes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(15, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Decimal Place";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(15, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Use Flag";
            // 
            // nudDecimalPlace
            // 
            this.nudDecimalPlace.Location = new System.Drawing.Point(133, 133);
            this.nudDecimalPlace.Name = "nudDecimalPlace";
            this.nudDecimalPlace.Size = new System.Drawing.Size(110, 20);
            this.nudDecimalPlace.TabIndex = 11;
            this.nudDecimalPlace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cdvUnit
            // 
            this.cdvUnit.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit.BtnToolTipText = "";
            this.cdvUnit.ButtonWidth = 20;
            this.cdvUnit.DescText = "";
            this.cdvUnit.DisplaySubItemIndex = -1;
            this.cdvUnit.DisplayText = "";
            this.cdvUnit.Focusing = null;
            this.cdvUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit.Index = 0;
            this.cdvUnit.IsViewBtnImage = false;
            this.cdvUnit.Location = new System.Drawing.Point(133, 104);
            this.cdvUnit.MaxLength = 20;
            this.cdvUnit.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit.MultiSelect = false;
            this.cdvUnit.Name = "cdvUnit";
            this.cdvUnit.ReadOnly = false;
            this.cdvUnit.SameWidthHeightOfButton = false;
            this.cdvUnit.SearchSubItemIndex = 0;
            this.cdvUnit.SelectedDescIndex = -1;
            this.cdvUnit.SelectedDescToQueryText = "";
            this.cdvUnit.SelectedSubItemIndex = -1;
            this.cdvUnit.SelectedValueToQueryText = "";
            this.cdvUnit.SelectionStart = 0;
            this.cdvUnit.Size = new System.Drawing.Size(110, 21);
            this.cdvUnit.SmallImageList = null;
            this.cdvUnit.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit.TabIndex = 10;
            this.cdvUnit.TextBoxToolTipText = "";
            this.cdvUnit.TextBoxWidth = 110;
            this.cdvUnit.VisibleButton = true;
            this.cdvUnit.VisibleColumnHeader = false;
            this.cdvUnit.VisibleDescription = false;
            this.cdvUnit.ButtonPress += new System.EventHandler(this.cdvUnit_ButtonPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(15, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Unit";
            // 
            // txtUSL
            // 
            this.txtUSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUSL.Location = new System.Drawing.Point(133, 76);
            this.txtUSL.MaxLength = 11;
            this.txtUSL.Name = "txtUSL";
            this.txtUSL.Size = new System.Drawing.Size(110, 20);
            this.txtUSL.TabIndex = 9;
            this.txtUSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUSL.TextChanged += new System.EventHandler(this.txtUSL_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Upper Standard Limit";
            // 
            // cdvItemGroup
            // 
            this.cdvItemGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvItemGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvItemGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvItemGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvItemGroup.BtnToolTipText = "";
            this.cdvItemGroup.ButtonWidth = 20;
            this.cdvItemGroup.DescText = "";
            this.cdvItemGroup.DisplaySubItemIndex = 0;
            this.cdvItemGroup.DisplayText = "";
            this.cdvItemGroup.Focusing = null;
            this.cdvItemGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvItemGroup.Index = 0;
            this.cdvItemGroup.IsViewBtnImage = false;
            this.cdvItemGroup.Location = new System.Drawing.Point(133, 19);
            this.cdvItemGroup.MaxLength = 40;
            this.cdvItemGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvItemGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvItemGroup.MultiSelect = false;
            this.cdvItemGroup.Name = "cdvItemGroup";
            this.cdvItemGroup.ReadOnly = false;
            this.cdvItemGroup.SameWidthHeightOfButton = false;
            this.cdvItemGroup.SearchSubItemIndex = 0;
            this.cdvItemGroup.SelectedDescIndex = 1;
            this.cdvItemGroup.SelectedDescToQueryText = "";
            this.cdvItemGroup.SelectedSubItemIndex = 0;
            this.cdvItemGroup.SelectedValueToQueryText = "";
            this.cdvItemGroup.SelectionStart = 0;
            this.cdvItemGroup.Size = new System.Drawing.Size(280, 21);
            this.cdvItemGroup.SmallImageList = null;
            this.cdvItemGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvItemGroup.TabIndex = 7;
            this.cdvItemGroup.TextBoxToolTipText = "";
            this.cdvItemGroup.TextBoxWidth = 110;
            this.cdvItemGroup.VisibleButton = true;
            this.cdvItemGroup.VisibleColumnHeader = false;
            this.cdvItemGroup.VisibleDescription = true;
            this.cdvItemGroup.ButtonPress += new System.EventHandler(this.cdvItemGroup_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Item Group";
            // 
            // txtLSL
            // 
            this.txtLSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLSL.Location = new System.Drawing.Point(133, 48);
            this.txtLSL.MaxLength = 11;
            this.txtLSL.Name = "txtLSL";
            this.txtLSL.Size = new System.Drawing.Size(110, 20);
            this.txtLSL.TabIndex = 8;
            this.txtLSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLSL.TextChanged += new System.EventHandler(this.txtLSL_TextChanged);
            // 
            // lblLSL
            // 
            this.lblLSL.AutoSize = true;
            this.lblLSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLSL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblLSL.Location = new System.Drawing.Point(15, 55);
            this.lblLSL.Name = "lblLSL";
            this.lblLSL.Size = new System.Drawing.Size(106, 13);
            this.lblLSL.TabIndex = 30;
            this.lblLSL.Text = "Lower Standard Limit";
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
            // frmMMSItemSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSItemSetup";
            this.Text = "Item Setup";
            this.Activated += new System.EventHandler(this.frmMMSItemSetup_Activated);
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
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            this.pnlListTop.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewItemGroup)).EndInit();
            this.tabSampling.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.grbStandradEquip.ResumeLayout(false);
            this.grbStandradEquip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDecimalPlace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvItemGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemDesc;
        private System.Windows.Forms.Panel pnlListTop;
        private System.Windows.Forms.ListView lisView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabControl tabSampling;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox GroupBox1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUSL;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvItemGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLSL;
        private System.Windows.Forms.Label lblLSL;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.NumericUpDown nudDecimalPlace;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvViewItemGroup;
        private System.Windows.Forms.Label lblItemGroup;
        private System.Windows.Forms.GroupBox grbStandradEquip;
        private System.Windows.Forms.RadioButton rdoUseFlagNo;
        private System.Windows.Forms.RadioButton rdoUseFlagYes;
    }
}