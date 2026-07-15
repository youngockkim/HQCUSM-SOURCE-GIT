namespace Miracom.SVMCore
{
    partial class frmSVMSetupMember
    {
        /// <summary>
        /// ?�수 ?�자?�너 변?�입?�다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ?�용 중인 모든 리소?��? ?�리?�니??
        /// </summary>
        /// <param name="disposing">관리되??리소?��? ??��?�야 ?�면 true?�고, 그렇지 ?�으�?false?�니??</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form ?�자?�너?�서 ?�성??코드

        /// <summary>
        /// ?�자?�너 지?�에 ?�요??메서?�입?�다.
        /// ??메서?�의 ?�용??코드 ?�집기로 ?�정?��? 마십?�오.
        /// </summary>
        private void InitializeComponent()
        {
            this.lisMember = new Miracom.UI.Controls.MCListView.MCListView();
            this.colMember = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabMember = new System.Windows.Forms.TabPage();
            this.grbMemberDetail = new System.Windows.Forms.GroupBox();
            this.nudRangeMin = new System.Windows.Forms.NumericUpDown();
            this.nudRangeMax = new System.Windows.Forms.NumericUpDown();
            this.chkUseRange = new System.Windows.Forms.CheckBox();
            this.lblBetween = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.cbxArrayType = new System.Windows.Forms.ComboBox();
            this.lblArrayType = new System.Windows.Forms.Label();
            this.cbxMemberType = new System.Windows.Forms.ComboBox();
            this.lblMemberType = new System.Windows.Forms.Label();
            this.lblMemberSize = new System.Windows.Forms.Label();
            this.txtMemberSize = new System.Windows.Forms.TextBox();
            this.grbMemberInfo = new System.Windows.Forms.GroupBox();
            this.txtMemberUpdateTime = new System.Windows.Forms.TextBox();
            this.txtMemberUpdateUser = new System.Windows.Forms.TextBox();
            this.txtMemberCreateTime = new System.Windows.Forms.TextBox();
            this.lblMemberUpdateTime = new System.Windows.Forms.Label();
            this.txtMemberCreateUser = new System.Windows.Forms.TextBox();
            this.lblMemberUpdateUser = new System.Windows.Forms.Label();
            this.lblMemberCreateTime = new System.Windows.Forms.Label();
            this.lblMemberCreateUser = new System.Windows.Forms.Label();
            this.txtMemberDesc_3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMemberDesc_2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberDesc_1 = new System.Windows.Forms.TextBox();
            this.lblServiceDesc = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.grbExportCenter = new System.Windows.Forms.GroupBox();
            this.txtExport = new System.Windows.Forms.RichTextBox();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.rboMember = new System.Windows.Forms.RadioButton();
            this.rboAllTbl = new System.Windows.Forms.RadioButton();
            this.txtExpFile = new System.Windows.Forms.TextBox();
            this.btnExpFile = new System.Windows.Forms.Button();
            this.lblExpFile = new System.Windows.Forms.Label();
            this.btnExpCopy = new System.Windows.Forms.Button();
            this.txtExpMember = new System.Windows.Forms.TextBox();
            this.lblExpMember = new System.Windows.Forms.Label();
            this.btnExpStop = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabMember.SuspendLayout();
            this.grbMemberDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeMax)).BeginInit();
            this.grbMemberInfo.SuspendLayout();
            this.tabExport.SuspendLayout();
            this.grbExportCenter.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
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
            this.pnlRight.Controls.Add(this.tabCtrl);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisMember);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
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
            // lisMember
            // 
            this.lisMember.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMember,
            this.colType,
            this.colSize,
            this.colDesc});
            this.lisMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMember.EnableSort = true;
            this.lisMember.EnableSortIcon = true;
            this.lisMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMember.FullRowSelect = true;
            this.lisMember.HideSelection = false;
            this.lisMember.Location = new System.Drawing.Point(0, 0);
            this.lisMember.MultiSelect = false;
            this.lisMember.Name = "lisMember";
            this.lisMember.Size = new System.Drawing.Size(232, 506);
            this.lisMember.TabIndex = 0;
            this.lisMember.UseCompatibleStateImageBehavior = false;
            this.lisMember.View = System.Windows.Forms.View.Details;
            this.lisMember.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lisMember_ItemSelectionChanged);
            // 
            // colMember
            // 
            this.colMember.Text = "Member";
            this.colMember.Width = 120;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 55;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 55;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 150;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabMember);
            this.tabCtrl.Controls.Add(this.tabExport);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(506, 506);
            this.tabCtrl.TabIndex = 0;
            // 
            // tabMember
            // 
            this.tabMember.Controls.Add(this.grbMemberDetail);
            this.tabMember.Controls.Add(this.grbMemberInfo);
            this.tabMember.Location = new System.Drawing.Point(4, 22);
            this.tabMember.Name = "tabMember";
            this.tabMember.Padding = new System.Windows.Forms.Padding(3);
            this.tabMember.Size = new System.Drawing.Size(498, 480);
            this.tabMember.TabIndex = 0;
            this.tabMember.Text = "Member";
            // 
            // grbMemberDetail
            // 
            this.grbMemberDetail.BackColor = System.Drawing.SystemColors.Control;
            this.grbMemberDetail.Controls.Add(this.nudRangeMin);
            this.grbMemberDetail.Controls.Add(this.nudRangeMax);
            this.grbMemberDetail.Controls.Add(this.chkUseRange);
            this.grbMemberDetail.Controls.Add(this.lblBetween);
            this.grbMemberDetail.Controls.Add(this.lblRange);
            this.grbMemberDetail.Controls.Add(this.cbxArrayType);
            this.grbMemberDetail.Controls.Add(this.lblArrayType);
            this.grbMemberDetail.Controls.Add(this.cbxMemberType);
            this.grbMemberDetail.Controls.Add(this.lblMemberType);
            this.grbMemberDetail.Controls.Add(this.lblMemberSize);
            this.grbMemberDetail.Controls.Add(this.txtMemberSize);
            this.grbMemberDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbMemberDetail.Location = new System.Drawing.Point(3, 387);
            this.grbMemberDetail.Name = "grbMemberDetail";
            this.grbMemberDetail.Size = new System.Drawing.Size(492, 90);
            this.grbMemberDetail.TabIndex = 3;
            this.grbMemberDetail.TabStop = false;
            // 
            // nudRangeMin
            // 
            this.nudRangeMin.DecimalPlaces = 4;
            this.nudRangeMin.Location = new System.Drawing.Point(152, 62);
            this.nudRangeMin.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            262144});
            this.nudRangeMin.Minimum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            -2147221504});
            this.nudRangeMin.Name = "nudRangeMin";
            this.nudRangeMin.Size = new System.Drawing.Size(150, 20);
            this.nudRangeMin.TabIndex = 8;
            this.nudRangeMin.Visible = false;
            // 
            // nudRangeMax
            // 
            this.nudRangeMax.DecimalPlaces = 4;
            this.nudRangeMax.Location = new System.Drawing.Point(324, 62);
            this.nudRangeMax.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            262144});
            this.nudRangeMax.Minimum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            -2147221504});
            this.nudRangeMax.Name = "nudRangeMax";
            this.nudRangeMax.Size = new System.Drawing.Size(150, 20);
            this.nudRangeMax.TabIndex = 10;
            this.nudRangeMax.Visible = false;
            // 
            // chkUseRange
            // 
            this.chkUseRange.AutoSize = true;
            this.chkUseRange.Location = new System.Drawing.Point(101, 63);
            this.chkUseRange.Name = "chkUseRange";
            this.chkUseRange.Size = new System.Drawing.Size(46, 16);
            this.chkUseRange.TabIndex = 7;
            this.chkUseRange.Text = "Use";
            this.chkUseRange.UseVisualStyleBackColor = true;
            this.chkUseRange.Visible = false;
            this.chkUseRange.CheckedChanged += new System.EventHandler(this.chkUseRange_CheckedChanged);
            // 
            // lblBetween
            // 
            this.lblBetween.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBetween.Location = new System.Drawing.Point(308, 67);
            this.lblBetween.Name = "lblBetween";
            this.lblBetween.Size = new System.Drawing.Size(10, 15);
            this.lblBetween.TabIndex = 9;
            this.lblBetween.Text = "~";
            this.lblBetween.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBetween.Visible = false;
            // 
            // lblRange
            // 
            this.lblRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRange.Location = new System.Drawing.Point(15, 62);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(80, 16);
            this.lblRange.TabIndex = 6;
            this.lblRange.Text = "Range";
            this.lblRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRange.Visible = false;
            // 
            // cbxArrayType
            // 
            this.cbxArrayType.FormattingEnabled = true;
            this.cbxArrayType.Items.AddRange(new object[] {
            "String",
            "Char",
            "Int",
            "Short",
            "Long",
            "Float",
            "Double",
            "UInt",
            "UShort",
            "ULong",
            "UByte",
            "Binary",
            "Byte",
            "Boolean",
            "Datetime",
            "Blob"});
            this.cbxArrayType.Location = new System.Drawing.Point(357, 14);
            this.cbxArrayType.Name = "cbxArrayType";
            this.cbxArrayType.Size = new System.Drawing.Size(100, 21);
            this.cbxArrayType.TabIndex = 3;
            this.cbxArrayType.Visible = false;
            this.cbxArrayType.TextChanged += new System.EventHandler(this.cbxArrayType_TextChanged);
            // 
            // lblArrayType
            // 
            this.lblArrayType.AutoSize = true;
            this.lblArrayType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblArrayType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrayType.Location = new System.Drawing.Point(271, 16);
            this.lblArrayType.Name = "lblArrayType";
            this.lblArrayType.Size = new System.Drawing.Size(68, 13);
            this.lblArrayType.TabIndex = 2;
            this.lblArrayType.Text = "Array Type";
            this.lblArrayType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArrayType.Visible = false;
            // 
            // cbxMemberType
            // 
            this.cbxMemberType.FormattingEnabled = true;
            this.cbxMemberType.Items.AddRange(new object[] {
            "String",
            "Char",
            "Int",
            "Short",
            "Long",
            "Float",
            "Double",
            "UInt",
            "UShort",
            "ULong",
            "UByte",
            "Binary",
            "Byte",
            "Boolean",
            "Datetime",
            "Blob",
            "List",
            "Array"});
            this.cbxMemberType.Location = new System.Drawing.Point(101, 14);
            this.cbxMemberType.Name = "cbxMemberType";
            this.cbxMemberType.Size = new System.Drawing.Size(100, 21);
            this.cbxMemberType.TabIndex = 1;
            this.cbxMemberType.TextChanged += new System.EventHandler(this.cbxMemberType_TextChanged);
            this.cbxMemberType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxMemberType_KeyPress);
            // 
            // lblMemberType
            // 
            this.lblMemberType.AutoSize = true;
            this.lblMemberType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMemberType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberType.Location = new System.Drawing.Point(15, 16);
            this.lblMemberType.Name = "lblMemberType";
            this.lblMemberType.Size = new System.Drawing.Size(35, 13);
            this.lblMemberType.TabIndex = 0;
            this.lblMemberType.Text = "Type";
            this.lblMemberType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMemberSize
            // 
            this.lblMemberSize.AutoSize = true;
            this.lblMemberSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMemberSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberSize.Location = new System.Drawing.Point(15, 40);
            this.lblMemberSize.Name = "lblMemberSize";
            this.lblMemberSize.Size = new System.Drawing.Size(31, 13);
            this.lblMemberSize.TabIndex = 4;
            this.lblMemberSize.Text = "Size";
            this.lblMemberSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMemberSize.Visible = false;
            // 
            // txtMemberSize
            // 
            this.txtMemberSize.Location = new System.Drawing.Point(101, 38);
            this.txtMemberSize.MaxLength = 6;
            this.txtMemberSize.Name = "txtMemberSize";
            this.txtMemberSize.Size = new System.Drawing.Size(100, 20);
            this.txtMemberSize.TabIndex = 5;
            this.txtMemberSize.Visible = false;
            this.txtMemberSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMemberSize_KeyPress);
            // 
            // grbMemberInfo
            // 
            this.grbMemberInfo.BackColor = System.Drawing.SystemColors.Control;
            this.grbMemberInfo.Controls.Add(this.txtMemberUpdateTime);
            this.grbMemberInfo.Controls.Add(this.txtMemberUpdateUser);
            this.grbMemberInfo.Controls.Add(this.txtMemberCreateTime);
            this.grbMemberInfo.Controls.Add(this.lblMemberUpdateTime);
            this.grbMemberInfo.Controls.Add(this.txtMemberCreateUser);
            this.grbMemberInfo.Controls.Add(this.lblMemberUpdateUser);
            this.grbMemberInfo.Controls.Add(this.lblMemberCreateTime);
            this.grbMemberInfo.Controls.Add(this.lblMemberCreateUser);
            this.grbMemberInfo.Controls.Add(this.txtMemberDesc_3);
            this.grbMemberInfo.Controls.Add(this.label3);
            this.grbMemberInfo.Controls.Add(this.txtMemberDesc_2);
            this.grbMemberInfo.Controls.Add(this.label1);
            this.grbMemberInfo.Controls.Add(this.txtMemberDesc_1);
            this.grbMemberInfo.Controls.Add(this.lblServiceDesc);
            this.grbMemberInfo.Controls.Add(this.txtMemberName);
            this.grbMemberInfo.Controls.Add(this.lblMemberName);
            this.grbMemberInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbMemberInfo.Location = new System.Drawing.Point(3, 3);
            this.grbMemberInfo.Name = "grbMemberInfo";
            this.grbMemberInfo.Size = new System.Drawing.Size(492, 384);
            this.grbMemberInfo.TabIndex = 2;
            this.grbMemberInfo.TabStop = false;
            // 
            // txtMemberUpdateTime
            // 
            this.txtMemberUpdateTime.Location = new System.Drawing.Point(350, 358);
            this.txtMemberUpdateTime.MaxLength = 30;
            this.txtMemberUpdateTime.Name = "txtMemberUpdateTime";
            this.txtMemberUpdateTime.ReadOnly = true;
            this.txtMemberUpdateTime.Size = new System.Drawing.Size(130, 20);
            this.txtMemberUpdateTime.TabIndex = 15;
            // 
            // txtMemberUpdateUser
            // 
            this.txtMemberUpdateUser.Location = new System.Drawing.Point(101, 358);
            this.txtMemberUpdateUser.MaxLength = 20;
            this.txtMemberUpdateUser.Name = "txtMemberUpdateUser";
            this.txtMemberUpdateUser.ReadOnly = true;
            this.txtMemberUpdateUser.Size = new System.Drawing.Size(130, 20);
            this.txtMemberUpdateUser.TabIndex = 13;
            // 
            // txtMemberCreateTime
            // 
            this.txtMemberCreateTime.Location = new System.Drawing.Point(350, 335);
            this.txtMemberCreateTime.MaxLength = 30;
            this.txtMemberCreateTime.Name = "txtMemberCreateTime";
            this.txtMemberCreateTime.ReadOnly = true;
            this.txtMemberCreateTime.Size = new System.Drawing.Size(130, 20);
            this.txtMemberCreateTime.TabIndex = 11;
            // 
            // lblMemberUpdateTime
            // 
            this.lblMemberUpdateTime.AutoSize = true;
            this.lblMemberUpdateTime.Location = new System.Drawing.Point(271, 361);
            this.lblMemberUpdateTime.Name = "lblMemberUpdateTime";
            this.lblMemberUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblMemberUpdateTime.TabIndex = 14;
            this.lblMemberUpdateTime.Text = "Update Time";
            // 
            // txtMemberCreateUser
            // 
            this.txtMemberCreateUser.Location = new System.Drawing.Point(101, 335);
            this.txtMemberCreateUser.MaxLength = 20;
            this.txtMemberCreateUser.Name = "txtMemberCreateUser";
            this.txtMemberCreateUser.ReadOnly = true;
            this.txtMemberCreateUser.Size = new System.Drawing.Size(130, 20);
            this.txtMemberCreateUser.TabIndex = 9;
            // 
            // lblMemberUpdateUser
            // 
            this.lblMemberUpdateUser.AutoSize = true;
            this.lblMemberUpdateUser.Location = new System.Drawing.Point(15, 361);
            this.lblMemberUpdateUser.Name = "lblMemberUpdateUser";
            this.lblMemberUpdateUser.Size = new System.Drawing.Size(81, 13);
            this.lblMemberUpdateUser.TabIndex = 12;
            this.lblMemberUpdateUser.Text = "Update User ID";
            // 
            // lblMemberCreateTime
            // 
            this.lblMemberCreateTime.AutoSize = true;
            this.lblMemberCreateTime.Location = new System.Drawing.Point(271, 338);
            this.lblMemberCreateTime.Name = "lblMemberCreateTime";
            this.lblMemberCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblMemberCreateTime.TabIndex = 10;
            this.lblMemberCreateTime.Text = "Create Time";
            // 
            // lblMemberCreateUser
            // 
            this.lblMemberCreateUser.AutoSize = true;
            this.lblMemberCreateUser.Location = new System.Drawing.Point(15, 338);
            this.lblMemberCreateUser.Name = "lblMemberCreateUser";
            this.lblMemberCreateUser.Size = new System.Drawing.Size(77, 13);
            this.lblMemberCreateUser.TabIndex = 8;
            this.lblMemberCreateUser.Text = "Create User ID";
            // 
            // txtMemberDesc_3
            // 
            this.txtMemberDesc_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemberDesc_3.Location = new System.Drawing.Point(101, 234);
            this.txtMemberDesc_3.MaxLength = 1000;
            this.txtMemberDesc_3.Multiline = true;
            this.txtMemberDesc_3.Name = "txtMemberDesc_3";
            this.txtMemberDesc_3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMemberDesc_3.Size = new System.Drawing.Size(379, 94);
            this.txtMemberDesc_3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description\r\n(3rd Language)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMemberDesc_2
            // 
            this.txtMemberDesc_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemberDesc_2.Location = new System.Drawing.Point(101, 136);
            this.txtMemberDesc_2.MaxLength = 1000;
            this.txtMemberDesc_2.Multiline = true;
            this.txtMemberDesc_2.Name = "txtMemberDesc_2";
            this.txtMemberDesc_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMemberDesc_2.Size = new System.Drawing.Size(379, 94);
            this.txtMemberDesc_2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Description\r\n(2nd Language)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMemberDesc_1
            // 
            this.txtMemberDesc_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemberDesc_1.Location = new System.Drawing.Point(101, 38);
            this.txtMemberDesc_1.MaxLength = 1000;
            this.txtMemberDesc_1.Multiline = true;
            this.txtMemberDesc_1.Name = "txtMemberDesc_1";
            this.txtMemberDesc_1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMemberDesc_1.Size = new System.Drawing.Size(379, 94);
            this.txtMemberDesc_1.TabIndex = 3;
            // 
            // lblServiceDesc
            // 
            this.lblServiceDesc.AutoSize = true;
            this.lblServiceDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblServiceDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceDesc.Location = new System.Drawing.Point(15, 39);
            this.lblServiceDesc.Name = "lblServiceDesc";
            this.lblServiceDesc.Size = new System.Drawing.Size(71, 26);
            this.lblServiceDesc.TabIndex = 2;
            this.lblServiceDesc.Text = "Description\r\n(English)";
            this.lblServiceDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMemberName
            // 
            this.txtMemberName.Location = new System.Drawing.Point(101, 14);
            this.txtMemberName.MaxLength = 50;
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(379, 20);
            this.txtMemberName.TabIndex = 1;
            // 
            // lblMemberName
            // 
            this.lblMemberName.AutoSize = true;
            this.lblMemberName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberName.Location = new System.Drawing.Point(15, 16);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(39, 13);
            this.lblMemberName.TabIndex = 0;
            this.lblMemberName.Text = "Name";
            this.lblMemberName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabExport
            // 
            this.tabExport.BackColor = System.Drawing.SystemColors.Control;
            this.tabExport.Controls.Add(this.grbExportCenter);
            this.tabExport.Controls.Add(this.grpExport);
            this.tabExport.Location = new System.Drawing.Point(4, 22);
            this.tabExport.Name = "tabExport";
            this.tabExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExport.Size = new System.Drawing.Size(498, 480);
            this.tabExport.TabIndex = 1;
            this.tabExport.Text = "Export";
            // 
            // grbExportCenter
            // 
            this.grbExportCenter.Controls.Add(this.txtExport);
            this.grbExportCenter.Controls.Add(this.progressBarExport);
            this.grbExportCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbExportCenter.Location = new System.Drawing.Point(3, 103);
            this.grbExportCenter.Name = "grbExportCenter";
            this.grbExportCenter.Size = new System.Drawing.Size(492, 374);
            this.grbExportCenter.TabIndex = 7;
            this.grbExportCenter.TabStop = false;
            // 
            // txtExport
            // 
            this.txtExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExport.Location = new System.Drawing.Point(3, 17);
            this.txtExport.Name = "txtExport";
            this.txtExport.ReadOnly = true;
            this.txtExport.Size = new System.Drawing.Size(486, 331);
            this.txtExport.TabIndex = 10;
            this.txtExport.Text = "";
            this.txtExport.WordWrap = false;
            // 
            // progressBarExport
            // 
            this.progressBarExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarExport.Location = new System.Drawing.Point(3, 348);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(486, 23);
            this.progressBarExport.TabIndex = 11;
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.rboMember);
            this.grpExport.Controls.Add(this.rboAllTbl);
            this.grpExport.Controls.Add(this.txtExpFile);
            this.grpExport.Controls.Add(this.btnExpFile);
            this.grpExport.Controls.Add(this.lblExpFile);
            this.grpExport.Controls.Add(this.btnExpCopy);
            this.grpExport.Controls.Add(this.txtExpMember);
            this.grpExport.Controls.Add(this.lblExpMember);
            this.grpExport.Controls.Add(this.btnExpStop);
            this.grpExport.Controls.Add(this.btnExport);
            this.grpExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpExport.Location = new System.Drawing.Point(3, 3);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(492, 100);
            this.grpExport.TabIndex = 6;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "DB Insert Script Create";
            // 
            // rboMember
            // 
            this.rboMember.AutoSize = true;
            this.rboMember.Checked = true;
            this.rboMember.Location = new System.Drawing.Point(306, 18);
            this.rboMember.Name = "rboMember";
            this.rboMember.Size = new System.Drawing.Size(70, 16);
            this.rboMember.TabIndex = 2;
            this.rboMember.TabStop = true;
            this.rboMember.Text = "Member";
            this.rboMember.UseVisualStyleBackColor = true;
            // 
            // rboAllTbl
            // 
            this.rboAllTbl.AutoSize = true;
            this.rboAllTbl.Location = new System.Drawing.Point(396, 18);
            this.rboAllTbl.Name = "rboAllTbl";
            this.rboAllTbl.Size = new System.Drawing.Size(73, 16);
            this.rboAllTbl.TabIndex = 3;
            this.rboAllTbl.Text = "All Table";
            this.rboAllTbl.UseVisualStyleBackColor = true;
            // 
            // txtExpFile
            // 
            this.txtExpFile.Location = new System.Drawing.Point(113, 42);
            this.txtExpFile.MaxLength = 1000;
            this.txtExpFile.Name = "txtExpFile";
            this.txtExpFile.ReadOnly = true;
            this.txtExpFile.Size = new System.Drawing.Size(350, 20);
            this.txtExpFile.TabIndex = 5;
            // 
            // btnExpFile
            // 
            this.btnExpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpFile.Location = new System.Drawing.Point(465, 41);
            this.btnExpFile.Name = "btnExpFile";
            this.btnExpFile.Size = new System.Drawing.Size(21, 21);
            this.btnExpFile.TabIndex = 6;
            this.btnExpFile.Text = "...";
            this.btnExpFile.Click += new System.EventHandler(this.btnExpFile_Click);
            // 
            // lblExpFile
            // 
            this.lblExpFile.AutoSize = true;
            this.lblExpFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpFile.Location = new System.Drawing.Point(15, 46);
            this.lblExpFile.Name = "lblExpFile";
            this.lblExpFile.Size = new System.Drawing.Size(56, 13);
            this.lblExpFile.TabIndex = 4;
            this.lblExpFile.Text = "Export File";
            // 
            // btnExpCopy
            // 
            this.btnExpCopy.Location = new System.Drawing.Point(287, 69);
            this.btnExpCopy.Name = "btnExpCopy";
            this.btnExpCopy.Size = new System.Drawing.Size(75, 23);
            this.btnExpCopy.TabIndex = 9;
            this.btnExpCopy.Text = "Clip Copy";
            this.btnExpCopy.Click += new System.EventHandler(this.btnExpCopy_Click);
            // 
            // txtExpMember
            // 
            this.txtExpMember.Location = new System.Drawing.Point(113, 17);
            this.txtExpMember.MaxLength = 50;
            this.txtExpMember.Name = "txtExpMember";
            this.txtExpMember.Size = new System.Drawing.Size(162, 20);
            this.txtExpMember.TabIndex = 1;
            // 
            // lblExpMember
            // 
            this.lblExpMember.AutoSize = true;
            this.lblExpMember.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExpMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpMember.Location = new System.Drawing.Point(16, 21);
            this.lblExpMember.Name = "lblExpMember";
            this.lblExpMember.Size = new System.Drawing.Size(76, 13);
            this.lblExpMember.TabIndex = 0;
            this.lblExpMember.Text = "Member Name";
            // 
            // btnExpStop
            // 
            this.btnExpStop.Location = new System.Drawing.Point(200, 69);
            this.btnExpStop.Name = "btnExpStop";
            this.btnExpStop.Size = new System.Drawing.Size(75, 23);
            this.btnExpStop.TabIndex = 8;
            this.btnExpStop.Text = "Stop";
            this.btnExpStop.Click += new System.EventHandler(this.btnExpStop_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(113, 69);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmSVMSetupMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmSVMSetupMember";
            this.Text = "Member Setup";
            this.Activated += new System.EventHandler(this.frmSVMSetupMember_Activated);
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
            this.tabCtrl.ResumeLayout(false);
            this.tabMember.ResumeLayout(false);
            this.grbMemberDetail.ResumeLayout(false);
            this.grbMemberDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeMax)).EndInit();
            this.grbMemberInfo.ResumeLayout(false);
            this.grbMemberInfo.PerformLayout();
            this.tabExport.ResumeLayout(false);
            this.grbExportCenter.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.UI.Controls.MCListView.MCListView lisMember;
        private System.Windows.Forms.ColumnHeader colMember;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabMember;
        private System.Windows.Forms.TabPage tabExport;
        private System.Windows.Forms.GroupBox grbMemberInfo;
        private System.Windows.Forms.TextBox txtMemberUpdateTime;
        private System.Windows.Forms.TextBox txtMemberUpdateUser;
        private System.Windows.Forms.TextBox txtMemberCreateTime;
        private System.Windows.Forms.Label lblMemberUpdateTime;
        private System.Windows.Forms.TextBox txtMemberCreateUser;
        private System.Windows.Forms.Label lblMemberUpdateUser;
        private System.Windows.Forms.Label lblMemberCreateTime;
        private System.Windows.Forms.Label lblMemberCreateUser;
        private System.Windows.Forms.TextBox txtMemberDesc_3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMemberDesc_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMemberDesc_1;
        private System.Windows.Forms.Label lblServiceDesc;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.GroupBox grbMemberDetail;
        private System.Windows.Forms.NumericUpDown nudRangeMin;
        private System.Windows.Forms.NumericUpDown nudRangeMax;
        private System.Windows.Forms.CheckBox chkUseRange;
        private System.Windows.Forms.Label lblBetween;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.ComboBox cbxArrayType;
        private System.Windows.Forms.Label lblArrayType;
        private System.Windows.Forms.ComboBox cbxMemberType;
        private System.Windows.Forms.Label lblMemberType;
        private System.Windows.Forms.Label lblMemberSize;
        private System.Windows.Forms.TextBox txtMemberSize;
        private System.Windows.Forms.GroupBox grpExport;
        private System.Windows.Forms.RadioButton rboMember;
        private System.Windows.Forms.RadioButton rboAllTbl;
        private System.Windows.Forms.TextBox txtExpFile;
        private System.Windows.Forms.Button btnExpFile;
        private System.Windows.Forms.Label lblExpFile;
        private System.Windows.Forms.Button btnExpCopy;
        private System.Windows.Forms.TextBox txtExpMember;
        private System.Windows.Forms.Label lblExpMember;
        private System.Windows.Forms.Button btnExpStop;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox grbExportCenter;
        private System.Windows.Forms.RichTextBox txtExport;
        private System.Windows.Forms.ProgressBar progressBarExport;
        private System.Windows.Forms.SaveFileDialog sfdFile;

    }
}