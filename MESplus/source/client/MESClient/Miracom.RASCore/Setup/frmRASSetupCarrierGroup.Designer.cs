namespace Miracom.RASCore
{
    partial class frmRASSetupCarrierGroup
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
            this.lisList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colCarrierGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroupDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpCarrierGroup = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtCarrierGroup = new System.Windows.Forms.TextBox();
            this.lblCarrierGroup = new System.Windows.Forms.Label();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblCleanLimitAlarm = new System.Windows.Forms.Label();
            this.cdvCleanLimitAlarm = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUsageLimitAlarm = new System.Windows.Forms.Label();
            this.cdvUsageLimitAlarm = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.numCleanLimitCount = new System.Windows.Forms.NumericUpDown();
            this.numUsageLimitTime = new System.Windows.Forms.NumericUpDown();
            this.numUsageLimitCount = new System.Windows.Forms.NumericUpDown();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.dtpPlanTermTime = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanTermDate = new System.Windows.Forms.DateTimePicker();
            this.lblPlanTermTime = new System.Windows.Forms.Label();
            this.lblCleanLimitCount = new System.Windows.Forms.Label();
            this.lblUsageLimitTimeUnit = new System.Windows.Forms.Label();
            this.lblUsageLimitTime = new System.Windows.Forms.Label();
            this.lblUsageLimitCount = new System.Windows.Forms.Label();
            this.chkPlanTerminate = new System.Windows.Forms.CheckBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpCarrierGroup.SuspendLayout();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCleanLimitAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUsageLimitAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCleanLimitCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitCount)).BeginInit();
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
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpDetail);
            this.pnlRight.Controls.Add(this.grpCarrierGroup);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisList);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // lisList
            // 
            this.lisList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCarrierGroup,
            this.colGroupDesc});
            this.lisList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisList.EnableSort = true;
            this.lisList.EnableSortIcon = true;
            this.lisList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisList.FullRowSelect = true;
            this.lisList.Location = new System.Drawing.Point(0, 0);
            this.lisList.MultiSelect = false;
            this.lisList.Name = "lisList";
            this.lisList.Size = new System.Drawing.Size(232, 513);
            this.lisList.TabIndex = 0;
            this.lisList.UseCompatibleStateImageBehavior = false;
            this.lisList.View = System.Windows.Forms.View.Details;
            this.lisList.SelectedIndexChanged += new System.EventHandler(this.lisList_SelectedIndexChanged);
            // 
            // colCarrierGroup
            // 
            this.colCarrierGroup.Text = "Carrier Group";
            this.colCarrierGroup.Width = 100;
            // 
            // colGroupDesc
            // 
            this.colGroupDesc.Text = "Description";
            this.colGroupDesc.Width = 100;
            // 
            // grpCarrierGroup
            // 
            this.grpCarrierGroup.Controls.Add(this.txtDesc);
            this.grpCarrierGroup.Controls.Add(this.lblDesc);
            this.grpCarrierGroup.Controls.Add(this.txtCarrierGroup);
            this.grpCarrierGroup.Controls.Add(this.lblCarrierGroup);
            this.grpCarrierGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCarrierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCarrierGroup.Location = new System.Drawing.Point(0, 0);
            this.grpCarrierGroup.Name = "grpCarrierGroup";
            this.grpCarrierGroup.Size = new System.Drawing.Size(506, 70);
            this.grpCarrierGroup.TabIndex = 0;
            this.grpCarrierGroup.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(136, 41);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(358, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(14, 45);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // txtCarrierGroup
            // 
            this.txtCarrierGroup.Location = new System.Drawing.Point(136, 16);
            this.txtCarrierGroup.MaxLength = 20;
            this.txtCarrierGroup.Name = "txtCarrierGroup";
            this.txtCarrierGroup.Size = new System.Drawing.Size(208, 20);
            this.txtCarrierGroup.TabIndex = 1;
            // 
            // lblCarrierGroup
            // 
            this.lblCarrierGroup.AutoSize = true;
            this.lblCarrierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCarrierGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrierGroup.Location = new System.Drawing.Point(14, 20);
            this.lblCarrierGroup.Name = "lblCarrierGroup";
            this.lblCarrierGroup.Size = new System.Drawing.Size(82, 13);
            this.lblCarrierGroup.TabIndex = 0;
            this.lblCarrierGroup.Text = "Carrier Group";
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.lblCleanLimitAlarm);
            this.grpDetail.Controls.Add(this.cdvCleanLimitAlarm);
            this.grpDetail.Controls.Add(this.lblUsageLimitAlarm);
            this.grpDetail.Controls.Add(this.cdvUsageLimitAlarm);
            this.grpDetail.Controls.Add(this.numCleanLimitCount);
            this.grpDetail.Controls.Add(this.numUsageLimitTime);
            this.grpDetail.Controls.Add(this.numUsageLimitCount);
            this.grpDetail.Controls.Add(this.txtUpdateTime);
            this.grpDetail.Controls.Add(this.txtCreateTime);
            this.grpDetail.Controls.Add(this.txtUpdateUser);
            this.grpDetail.Controls.Add(this.lblUpdate);
            this.grpDetail.Controls.Add(this.txtCreateUser);
            this.grpDetail.Controls.Add(this.lblCreate);
            this.grpDetail.Controls.Add(this.dtpPlanTermTime);
            this.grpDetail.Controls.Add(this.dtpPlanTermDate);
            this.grpDetail.Controls.Add(this.lblPlanTermTime);
            this.grpDetail.Controls.Add(this.lblCleanLimitCount);
            this.grpDetail.Controls.Add(this.lblUsageLimitTimeUnit);
            this.grpDetail.Controls.Add(this.lblUsageLimitTime);
            this.grpDetail.Controls.Add(this.lblUsageLimitCount);
            this.grpDetail.Controls.Add(this.chkPlanTerminate);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDetail.Location = new System.Drawing.Point(0, 70);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(506, 443);
            this.grpDetail.TabIndex = 1;
            this.grpDetail.TabStop = false;
            // 
            // lblCleanLimitAlarm
            // 
            this.lblCleanLimitAlarm.AutoSize = true;
            this.lblCleanLimitAlarm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCleanLimitAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCleanLimitAlarm.Location = new System.Drawing.Point(14, 123);
            this.lblCleanLimitAlarm.Name = "lblCleanLimitAlarm";
            this.lblCleanLimitAlarm.Size = new System.Drawing.Size(87, 13);
            this.lblCleanLimitAlarm.TabIndex = 20;
            this.lblCleanLimitAlarm.Text = "Clean Limit Alarm";
            // 
            // cdvCleanLimitAlarm
            // 
            this.cdvCleanLimitAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCleanLimitAlarm.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCleanLimitAlarm.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCleanLimitAlarm.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCleanLimitAlarm.BtnToolTipText = "";
            this.cdvCleanLimitAlarm.DescText = "";
            this.cdvCleanLimitAlarm.DisplaySubItemIndex = 0;
            this.cdvCleanLimitAlarm.DisplayText = "";
            this.cdvCleanLimitAlarm.Focusing = null;
            this.cdvCleanLimitAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCleanLimitAlarm.Index = 0;
            this.cdvCleanLimitAlarm.IsViewBtnImage = false;
            this.cdvCleanLimitAlarm.Location = new System.Drawing.Point(136, 119);
            this.cdvCleanLimitAlarm.MaxLength = 32767;
            this.cdvCleanLimitAlarm.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCleanLimitAlarm.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCleanLimitAlarm.Name = "cdvCleanLimitAlarm";
            this.cdvCleanLimitAlarm.ReadOnly = false;
            this.cdvCleanLimitAlarm.SearchSubItemIndex = 0;
            this.cdvCleanLimitAlarm.SelectedDescIndex = 1;
            this.cdvCleanLimitAlarm.SelectedSubItemIndex = 0;
            this.cdvCleanLimitAlarm.SelectionStart = 0;
            this.cdvCleanLimitAlarm.Size = new System.Drawing.Size(358, 20);
            this.cdvCleanLimitAlarm.SmallImageList = null;
            this.cdvCleanLimitAlarm.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCleanLimitAlarm.TabIndex = 19;
            this.cdvCleanLimitAlarm.TextBoxToolTipText = "";
            this.cdvCleanLimitAlarm.TextBoxWidth = 208;
            this.cdvCleanLimitAlarm.VisibleButton = true;
            this.cdvCleanLimitAlarm.VisibleColumnHeader = false;
            this.cdvCleanLimitAlarm.VisibleDescription = true;
            this.cdvCleanLimitAlarm.ButtonPress += new System.EventHandler(this.cdvCleanLimitAlarm_ButtonPress);
            // 
            // lblUsageLimitAlarm
            // 
            this.lblUsageLimitAlarm.AutoSize = true;
            this.lblUsageLimitAlarm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsageLimitAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageLimitAlarm.Location = new System.Drawing.Point(14, 71);
            this.lblUsageLimitAlarm.Name = "lblUsageLimitAlarm";
            this.lblUsageLimitAlarm.Size = new System.Drawing.Size(91, 13);
            this.lblUsageLimitAlarm.TabIndex = 18;
            this.lblUsageLimitAlarm.Text = "Usage Limit Alarm";
            // 
            // cdvUsageLimitAlarm
            // 
            this.cdvUsageLimitAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvUsageLimitAlarm.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUsageLimitAlarm.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUsageLimitAlarm.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUsageLimitAlarm.BtnToolTipText = "";
            this.cdvUsageLimitAlarm.DescText = "";
            this.cdvUsageLimitAlarm.DisplaySubItemIndex = 0;
            this.cdvUsageLimitAlarm.DisplayText = "";
            this.cdvUsageLimitAlarm.Focusing = null;
            this.cdvUsageLimitAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUsageLimitAlarm.Index = 0;
            this.cdvUsageLimitAlarm.IsViewBtnImage = false;
            this.cdvUsageLimitAlarm.Location = new System.Drawing.Point(136, 67);
            this.cdvUsageLimitAlarm.MaxLength = 32767;
            this.cdvUsageLimitAlarm.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUsageLimitAlarm.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUsageLimitAlarm.Name = "cdvUsageLimitAlarm";
            this.cdvUsageLimitAlarm.ReadOnly = false;
            this.cdvUsageLimitAlarm.SearchSubItemIndex = 0;
            this.cdvUsageLimitAlarm.SelectedDescIndex = 1;
            this.cdvUsageLimitAlarm.SelectedSubItemIndex = 0;
            this.cdvUsageLimitAlarm.SelectionStart = 0;
            this.cdvUsageLimitAlarm.Size = new System.Drawing.Size(358, 20);
            this.cdvUsageLimitAlarm.SmallImageList = null;
            this.cdvUsageLimitAlarm.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUsageLimitAlarm.TabIndex = 17;
            this.cdvUsageLimitAlarm.TextBoxToolTipText = "";
            this.cdvUsageLimitAlarm.TextBoxWidth = 208;
            this.cdvUsageLimitAlarm.VisibleButton = true;
            this.cdvUsageLimitAlarm.VisibleColumnHeader = false;
            this.cdvUsageLimitAlarm.VisibleDescription = true;
            this.cdvUsageLimitAlarm.ButtonPress += new System.EventHandler(this.cdvUsageLimitAlarm_ButtonPress);
            // 
            // numCleanLimitCount
            // 
            this.numCleanLimitCount.Location = new System.Drawing.Point(136, 93);
            this.numCleanLimitCount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numCleanLimitCount.Name = "numCleanLimitCount";
            this.numCleanLimitCount.Size = new System.Drawing.Size(208, 20);
            this.numCleanLimitCount.TabIndex = 6;
            this.numCleanLimitCount.ThousandsSeparator = true;
            // 
            // numUsageLimitTime
            // 
            this.numUsageLimitTime.Location = new System.Drawing.Point(136, 41);
            this.numUsageLimitTime.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUsageLimitTime.Name = "numUsageLimitTime";
            this.numUsageLimitTime.Size = new System.Drawing.Size(208, 20);
            this.numUsageLimitTime.TabIndex = 3;
            this.numUsageLimitTime.ThousandsSeparator = true;
            // 
            // numUsageLimitCount
            // 
            this.numUsageLimitCount.Location = new System.Drawing.Point(136, 16);
            this.numUsageLimitCount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUsageLimitCount.Name = "numUsageLimitCount";
            this.numUsageLimitCount.Size = new System.Drawing.Size(208, 20);
            this.numUsageLimitCount.TabIndex = 1;
            this.numUsageLimitCount.ThousandsSeparator = true;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(320, 406);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 16;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(320, 382);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 13;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(136, 406);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 15;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(14, 409);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 14;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(136, 382);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 12;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(14, 385);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 11;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpPlanTermTime
            // 
            this.dtpPlanTermTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpPlanTermTime.Location = new System.Drawing.Point(244, 145);
            this.dtpPlanTermTime.Name = "dtpPlanTermTime";
            this.dtpPlanTermTime.ShowUpDown = true;
            this.dtpPlanTermTime.Size = new System.Drawing.Size(100, 20);
            this.dtpPlanTermTime.TabIndex = 10;
            this.dtpPlanTermTime.Visible = false;
            // 
            // dtpPlanTermDate
            // 
            this.dtpPlanTermDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanTermDate.Location = new System.Drawing.Point(152, 145);
            this.dtpPlanTermDate.Name = "dtpPlanTermDate";
            this.dtpPlanTermDate.Size = new System.Drawing.Size(90, 20);
            this.dtpPlanTermDate.TabIndex = 9;
            this.dtpPlanTermDate.Visible = false;
            // 
            // lblPlanTermTime
            // 
            this.lblPlanTermTime.AutoSize = true;
            this.lblPlanTermTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanTermTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanTermTime.Location = new System.Drawing.Point(14, 149);
            this.lblPlanTermTime.Name = "lblPlanTermTime";
            this.lblPlanTermTime.Size = new System.Drawing.Size(104, 13);
            this.lblPlanTermTime.TabIndex = 7;
            this.lblPlanTermTime.Text = "Plan Terminate Time";
            // 
            // lblCleanLimitCount
            // 
            this.lblCleanLimitCount.AutoSize = true;
            this.lblCleanLimitCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCleanLimitCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCleanLimitCount.Location = new System.Drawing.Point(14, 97);
            this.lblCleanLimitCount.Name = "lblCleanLimitCount";
            this.lblCleanLimitCount.Size = new System.Drawing.Size(89, 13);
            this.lblCleanLimitCount.TabIndex = 5;
            this.lblCleanLimitCount.Text = "Clean Limit Count";
            // 
            // lblUsageLimitTimeUnit
            // 
            this.lblUsageLimitTimeUnit.AutoSize = true;
            this.lblUsageLimitTimeUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageLimitTimeUnit.Location = new System.Drawing.Point(353, 45);
            this.lblUsageLimitTimeUnit.Name = "lblUsageLimitTimeUnit";
            this.lblUsageLimitTimeUnit.Size = new System.Drawing.Size(30, 13);
            this.lblUsageLimitTimeUnit.TabIndex = 4;
            this.lblUsageLimitTimeUnit.Text = "Hour";
            // 
            // lblUsageLimitTime
            // 
            this.lblUsageLimitTime.AutoSize = true;
            this.lblUsageLimitTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsageLimitTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageLimitTime.Location = new System.Drawing.Point(14, 45);
            this.lblUsageLimitTime.Name = "lblUsageLimitTime";
            this.lblUsageLimitTime.Size = new System.Drawing.Size(88, 13);
            this.lblUsageLimitTime.TabIndex = 2;
            this.lblUsageLimitTime.Text = "Usage Limit Time";
            // 
            // lblUsageLimitCount
            // 
            this.lblUsageLimitCount.AutoSize = true;
            this.lblUsageLimitCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsageLimitCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageLimitCount.Location = new System.Drawing.Point(14, 20);
            this.lblUsageLimitCount.Name = "lblUsageLimitCount";
            this.lblUsageLimitCount.Size = new System.Drawing.Size(93, 13);
            this.lblUsageLimitCount.TabIndex = 0;
            this.lblUsageLimitCount.Text = "Usage Limit Count";
            // 
            // chkPlanTerminate
            // 
            this.chkPlanTerminate.Location = new System.Drawing.Point(136, 145);
            this.chkPlanTerminate.Name = "chkPlanTerminate";
            this.chkPlanTerminate.Size = new System.Drawing.Size(16, 20);
            this.chkPlanTerminate.TabIndex = 8;
            this.chkPlanTerminate.CheckedChanged += new System.EventHandler(this.chkPlanTerminate_CheckedChanged);
            // 
            // frmRASSetupCarrierGroup
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASSetupCarrierGroup";
            this.Text = "Carrier Group Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupCarrierGroup_Activated);
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
            this.grpCarrierGroup.ResumeLayout(false);
            this.grpCarrierGroup.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCleanLimitAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUsageLimitAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCleanLimitCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.UI.Controls.MCListView.MCListView lisList;
        private System.Windows.Forms.ColumnHeader colCarrierGroup;
        private System.Windows.Forms.ColumnHeader colGroupDesc;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.GroupBox grpCarrierGroup;
        private System.Windows.Forms.Label lblCarrierGroup;
        private System.Windows.Forms.TextBox txtCarrierGroup;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblUsageLimitCount;
        private System.Windows.Forms.Label lblPlanTermTime;
        private System.Windows.Forms.Label lblCleanLimitCount;
        private System.Windows.Forms.Label lblUsageLimitTimeUnit;
        private System.Windows.Forms.Label lblUsageLimitTime;
        private System.Windows.Forms.DateTimePicker dtpPlanTermTime;
        private System.Windows.Forms.DateTimePicker dtpPlanTermDate;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.CheckBox chkPlanTerminate;
        private System.Windows.Forms.NumericUpDown numCleanLimitCount;
        private System.Windows.Forms.NumericUpDown numUsageLimitTime;
        private System.Windows.Forms.NumericUpDown numUsageLimitCount;
        private UI.Controls.MCCodeView.MCCodeView cdvUsageLimitAlarm;
        private System.Windows.Forms.Label lblUsageLimitAlarm;
        private System.Windows.Forms.Label lblCleanLimitAlarm;
        private UI.Controls.MCCodeView.MCCodeView cdvCleanLimitAlarm;
    }
}
