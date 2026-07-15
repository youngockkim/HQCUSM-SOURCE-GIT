namespace Miracom.BASCore
{
    partial class frmBASSetupBatchJobProcessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASSetupBatchJobProcessor));
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtBatPrc = new System.Windows.Forms.TextBox();
            this.lblBatPrc = new System.Windows.Forms.Label();
            this.pnlRightBottom = new System.Windows.Forms.Panel();
            this.grpDateTime = new System.Windows.Forms.GroupBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.grpInfoExt = new System.Windows.Forms.GroupBox();
            this.txtMesChannel = new System.Windows.Forms.TextBox();
            this.cdvService = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvModule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMesChannel = new System.Windows.Forms.Label();
            this.lblExecService = new System.Windows.Forms.Label();
            this.lblExecModSvc = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.chkApplyEnd = new System.Windows.Forms.CheckBox();
            this.chkApplyStart = new System.Windows.Forms.CheckBox();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.dtpApplyEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpApplyEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpApplyStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpApplyStartDate = new System.Windows.Forms.DateTimePicker();
            this.cboExecMethod = new System.Windows.Forms.ComboBox();
            this.lblExeMethod = new System.Windows.Forms.Label();
            this.chkActFlag = new System.Windows.Forms.CheckBox();
            this.txtExecCycleEx = new System.Windows.Forms.TextBox();
            this.txtExecCycle = new System.Windows.Forms.TextBox();
            this.lblExeCycle = new System.Windows.Forms.Label();
            this.cdvCompAlarm = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblApplyEndTime = new System.Windows.Forms.Label();
            this.lblApplyStartTime = new System.Windows.Forms.Label();
            this.lblCompleteAlarm = new System.Windows.Forms.Label();
            this.lisBatPrc = new Miracom.UI.Controls.MCListView.MCListView();
            this.colJobProc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExecute = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grbTable.SuspendLayout();
            this.pnlRightBottom.SuspendLayout();
            this.grpDateTime.SuspendLayout();
            this.grpInfoExt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).BeginInit();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCompAlarm)).BeginInit();
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
            this.pnlRight.Controls.Add(this.pnlRightBottom);
            this.pnlRight.Controls.Add(this.grbTable);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisBatPrc);
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
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExecute);
            this.pnlBottom.Controls.SetChildIndex(this.btnExecute, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // grbTable
            // 
            this.grbTable.Controls.Add(this.txtDesc);
            this.grbTable.Controls.Add(this.lblDesc);
            this.grbTable.Controls.Add(this.txtBatPrc);
            this.grbTable.Controls.Add(this.lblBatPrc);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbTable.Location = new System.Drawing.Point(0, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(506, 71);
            this.grbTable.TabIndex = 1;
            this.grbTable.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(140, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(359, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBatPrc
            // 
            this.txtBatPrc.Location = new System.Drawing.Point(140, 16);
            this.txtBatPrc.MaxLength = 30;
            this.txtBatPrc.Name = "txtBatPrc";
            this.txtBatPrc.Size = new System.Drawing.Size(200, 20);
            this.txtBatPrc.TabIndex = 1;
            // 
            // lblBatPrc
            // 
            this.lblBatPrc.AutoSize = true;
            this.lblBatPrc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatPrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatPrc.Location = new System.Drawing.Point(15, 19);
            this.lblBatPrc.Name = "lblBatPrc";
            this.lblBatPrc.Size = new System.Drawing.Size(87, 13);
            this.lblBatPrc.TabIndex = 0;
            this.lblBatPrc.Text = "Job Processor";
            this.lblBatPrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRightBottom
            // 
            this.pnlRightBottom.Controls.Add(this.grpDateTime);
            this.pnlRightBottom.Controls.Add(this.grpInfoExt);
            this.pnlRightBottom.Controls.Add(this.grpInfo);
            this.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightBottom.Location = new System.Drawing.Point(0, 71);
            this.pnlRightBottom.Name = "pnlRightBottom";
            this.pnlRightBottom.Size = new System.Drawing.Size(506, 435);
            this.pnlRightBottom.TabIndex = 2;
            // 
            // grpDateTime
            // 
            this.grpDateTime.Controls.Add(this.txtCreateUser);
            this.grpDateTime.Controls.Add(this.lblCreate);
            this.grpDateTime.Controls.Add(this.lblUpdate);
            this.grpDateTime.Controls.Add(this.txtUpdateUser);
            this.grpDateTime.Controls.Add(this.txtUpdateTime);
            this.grpDateTime.Controls.Add(this.txtCreateTime);
            this.grpDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDateTime.Location = new System.Drawing.Point(0, 370);
            this.grpDateTime.Name = "grpDateTime";
            this.grpDateTime.Size = new System.Drawing.Size(506, 65);
            this.grpDateTime.TabIndex = 2;
            this.grpDateTime.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(140, 15);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(14, 18);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(14, 42);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(140, 39);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(325, 39);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(325, 15);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // grpInfoExt
            // 
            this.grpInfoExt.Controls.Add(this.txtMesChannel);
            this.grpInfoExt.Controls.Add(this.cdvService);
            this.grpInfoExt.Controls.Add(this.cdvModule);
            this.grpInfoExt.Controls.Add(this.lblMesChannel);
            this.grpInfoExt.Controls.Add(this.lblExecService);
            this.grpInfoExt.Controls.Add(this.lblExecModSvc);
            this.grpInfoExt.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfoExt.Location = new System.Drawing.Point(0, 283);
            this.grpInfoExt.Name = "grpInfoExt";
            this.grpInfoExt.Size = new System.Drawing.Size(506, 87);
            this.grpInfoExt.TabIndex = 1;
            this.grpInfoExt.TabStop = false;
            // 
            // txtMesChannel
            // 
            this.txtMesChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMesChannel.Location = new System.Drawing.Point(140, 61);
            this.txtMesChannel.MaxLength = 1000;
            this.txtMesChannel.Name = "txtMesChannel";
            this.txtMesChannel.Size = new System.Drawing.Size(359, 20);
            this.txtMesChannel.TabIndex = 5;
            this.txtMesChannel.TabStop = false;
            // 
            // cdvService
            // 
            this.cdvService.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvService.BorderHotColor = System.Drawing.Color.Black;
            this.cdvService.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvService.BtnToolTipText = "";
            this.cdvService.ButtonWidth = 20;
            this.cdvService.DescText = "";
            this.cdvService.DisplaySubItemIndex = -1;
            this.cdvService.DisplayText = "";
            this.cdvService.Focusing = null;
            this.cdvService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvService.Index = 0;
            this.cdvService.IsViewBtnImage = false;
            this.cdvService.Location = new System.Drawing.Point(140, 37);
            this.cdvService.MaxLength = 100;
            this.cdvService.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvService.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvService.Name = "cdvService";
            this.cdvService.ReadOnly = true;
            this.cdvService.SameWidthHeightOfButton = false;
            this.cdvService.SearchSubItemIndex = 0;
            this.cdvService.SelectedDescIndex = -1;
            this.cdvService.SelectedSubItemIndex = -1;
            this.cdvService.SelectionStart = 0;
            this.cdvService.Size = new System.Drawing.Size(184, 20);
            this.cdvService.SmallImageList = null;
            this.cdvService.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvService.TabIndex = 3;
            this.cdvService.TextBoxToolTipText = "";
            this.cdvService.TextBoxWidth = 184;
            this.cdvService.VisibleButton = true;
            this.cdvService.VisibleColumnHeader = false;
            this.cdvService.VisibleDescription = false;
            this.cdvService.ButtonPress += new System.EventHandler(this.cdvService_ButtonPress);
            // 
            // cdvModule
            // 
            this.cdvModule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvModule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvModule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvModule.BtnToolTipText = "";
            this.cdvModule.ButtonWidth = 20;
            this.cdvModule.DescText = "";
            this.cdvModule.DisplaySubItemIndex = -1;
            this.cdvModule.DisplayText = "";
            this.cdvModule.Focusing = null;
            this.cdvModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvModule.Index = 0;
            this.cdvModule.IsViewBtnImage = false;
            this.cdvModule.Location = new System.Drawing.Point(140, 13);
            this.cdvModule.MaxLength = 30;
            this.cdvModule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvModule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvModule.Name = "cdvModule";
            this.cdvModule.ReadOnly = true;
            this.cdvModule.SameWidthHeightOfButton = false;
            this.cdvModule.SearchSubItemIndex = 0;
            this.cdvModule.SelectedDescIndex = -1;
            this.cdvModule.SelectedSubItemIndex = -1;
            this.cdvModule.SelectionStart = 0;
            this.cdvModule.Size = new System.Drawing.Size(184, 20);
            this.cdvModule.SmallImageList = null;
            this.cdvModule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvModule.TabIndex = 1;
            this.cdvModule.TextBoxToolTipText = "";
            this.cdvModule.TextBoxWidth = 184;
            this.cdvModule.VisibleButton = true;
            this.cdvModule.VisibleColumnHeader = false;
            this.cdvModule.VisibleDescription = false;
            this.cdvModule.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvModule_SelectedItemChanged);
            this.cdvModule.ButtonPress += new System.EventHandler(this.cdvModule_ButtonPress);
            // 
            // lblMesChannel
            // 
            this.lblMesChannel.AutoSize = true;
            this.lblMesChannel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMesChannel.Location = new System.Drawing.Point(14, 64);
            this.lblMesChannel.Name = "lblMesChannel";
            this.lblMesChannel.Size = new System.Drawing.Size(72, 13);
            this.lblMesChannel.TabIndex = 4;
            this.lblMesChannel.Text = "MES Channel";
            this.lblMesChannel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExecService
            // 
            this.lblExecService.AutoSize = true;
            this.lblExecService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExecService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExecService.Location = new System.Drawing.Point(13, 40);
            this.lblExecService.Name = "lblExecService";
            this.lblExecService.Size = new System.Drawing.Size(110, 13);
            this.lblExecService.TabIndex = 2;
            this.lblExecService.Text = "Execution Service";
            this.lblExecService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExecModSvc
            // 
            this.lblExecModSvc.AutoSize = true;
            this.lblExecModSvc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExecModSvc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExecModSvc.Location = new System.Drawing.Point(14, 16);
            this.lblExecModSvc.Name = "lblExecModSvc";
            this.lblExecModSvc.Size = new System.Drawing.Size(108, 13);
            this.lblExecModSvc.TabIndex = 0;
            this.lblExecModSvc.Text = "Execution Module";
            this.lblExecModSvc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.chkApplyEnd);
            this.grpInfo.Controls.Add(this.chkApplyStart);
            this.grpInfo.Controls.Add(this.numPriority);
            this.grpInfo.Controls.Add(this.dtpApplyEndTime);
            this.grpInfo.Controls.Add(this.dtpApplyEndDate);
            this.grpInfo.Controls.Add(this.dtpApplyStartTime);
            this.grpInfo.Controls.Add(this.dtpApplyStartDate);
            this.grpInfo.Controls.Add(this.cboExecMethod);
            this.grpInfo.Controls.Add(this.lblExeMethod);
            this.grpInfo.Controls.Add(this.chkActFlag);
            this.grpInfo.Controls.Add(this.txtExecCycleEx);
            this.grpInfo.Controls.Add(this.txtExecCycle);
            this.grpInfo.Controls.Add(this.lblExeCycle);
            this.grpInfo.Controls.Add(this.cdvCompAlarm);
            this.grpInfo.Controls.Add(this.lblPriority);
            this.grpInfo.Controls.Add(this.lblApplyEndTime);
            this.grpInfo.Controls.Add(this.lblApplyStartTime);
            this.grpInfo.Controls.Add(this.lblCompleteAlarm);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(506, 283);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            // 
            // chkApplyEnd
            // 
            this.chkApplyEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkApplyEnd.Location = new System.Drawing.Point(140, 257);
            this.chkApplyEnd.Name = "chkApplyEnd";
            this.chkApplyEnd.Size = new System.Drawing.Size(18, 18);
            this.chkApplyEnd.TabIndex = 14;
            this.chkApplyEnd.CheckedChanged += new System.EventHandler(this.chkApplyEnd_CheckedChanged);
            // 
            // chkApplyStart
            // 
            this.chkApplyStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkApplyStart.Location = new System.Drawing.Point(140, 233);
            this.chkApplyStart.Name = "chkApplyStart";
            this.chkApplyStart.Size = new System.Drawing.Size(18, 18);
            this.chkApplyStart.TabIndex = 10;
            this.chkApplyStart.CheckedChanged += new System.EventHandler(this.chkApplyStart_CheckedChanged);
            // 
            // numPriority
            // 
            this.numPriority.Location = new System.Drawing.Point(140, 184);
            this.numPriority.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(184, 20);
            this.numPriority.TabIndex = 6;
            // 
            // dtpApplyEndTime
            // 
            this.dtpApplyEndTime.Checked = false;
            this.dtpApplyEndTime.CustomFormat = "HH:mm:ss";
            this.dtpApplyEndTime.Enabled = false;
            this.dtpApplyEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyEndTime.Location = new System.Drawing.Point(253, 256);
            this.dtpApplyEndTime.Name = "dtpApplyEndTime";
            this.dtpApplyEndTime.ShowUpDown = true;
            this.dtpApplyEndTime.Size = new System.Drawing.Size(71, 20);
            this.dtpApplyEndTime.TabIndex = 16;
            this.dtpApplyEndTime.Value = new System.DateTime(2013, 8, 26, 0, 0, 0, 0);
            // 
            // dtpApplyEndDate
            // 
            this.dtpApplyEndDate.Checked = false;
            this.dtpApplyEndDate.CustomFormat = "";
            this.dtpApplyEndDate.Enabled = false;
            this.dtpApplyEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpApplyEndDate.Location = new System.Drawing.Point(158, 256);
            this.dtpApplyEndDate.Name = "dtpApplyEndDate";
            this.dtpApplyEndDate.Size = new System.Drawing.Size(92, 20);
            this.dtpApplyEndDate.TabIndex = 15;
            // 
            // dtpApplyStartTime
            // 
            this.dtpApplyStartTime.Checked = false;
            this.dtpApplyStartTime.CustomFormat = "HH:mm:ss";
            this.dtpApplyStartTime.Enabled = false;
            this.dtpApplyStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyStartTime.Location = new System.Drawing.Point(253, 232);
            this.dtpApplyStartTime.Name = "dtpApplyStartTime";
            this.dtpApplyStartTime.ShowUpDown = true;
            this.dtpApplyStartTime.Size = new System.Drawing.Size(71, 20);
            this.dtpApplyStartTime.TabIndex = 12;
            this.dtpApplyStartTime.Value = new System.DateTime(2013, 8, 26, 0, 0, 0, 0);
            // 
            // dtpApplyStartDate
            // 
            this.dtpApplyStartDate.Checked = false;
            this.dtpApplyStartDate.CustomFormat = "";
            this.dtpApplyStartDate.Enabled = false;
            this.dtpApplyStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpApplyStartDate.Location = new System.Drawing.Point(158, 232);
            this.dtpApplyStartDate.Name = "dtpApplyStartDate";
            this.dtpApplyStartDate.Size = new System.Drawing.Size(92, 20);
            this.dtpApplyStartDate.TabIndex = 11;
            // 
            // cboExecMethod
            // 
            this.cboExecMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExecMethod.Items.AddRange(new object[] {
            "S  : Single Process",
            "M : Multi Process"});
            this.cboExecMethod.Location = new System.Drawing.Point(140, 159);
            this.cboExecMethod.Name = "cboExecMethod";
            this.cboExecMethod.Size = new System.Drawing.Size(184, 21);
            this.cboExecMethod.TabIndex = 4;
            // 
            // lblExeMethod
            // 
            this.lblExeMethod.AutoSize = true;
            this.lblExeMethod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExeMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExeMethod.Location = new System.Drawing.Point(15, 162);
            this.lblExeMethod.Name = "lblExeMethod";
            this.lblExeMethod.Size = new System.Drawing.Size(109, 13);
            this.lblExeMethod.TabIndex = 3;
            this.lblExeMethod.Text = "Execution Method";
            this.lblExeMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkActFlag
            // 
            this.chkActFlag.AutoSize = true;
            this.chkActFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkActFlag.Location = new System.Drawing.Point(330, 257);
            this.chkActFlag.Name = "chkActFlag";
            this.chkActFlag.Size = new System.Drawing.Size(94, 18);
            this.chkActFlag.TabIndex = 17;
            this.chkActFlag.Text = "Activate Flag";
            // 
            // txtExecCycleEx
            // 
            this.txtExecCycleEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExecCycleEx.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExecCycleEx.Location = new System.Drawing.Point(53, 40);
            this.txtExecCycleEx.MaxLength = 2000;
            this.txtExecCycleEx.Multiline = true;
            this.txtExecCycleEx.Name = "txtExecCycleEx";
            this.txtExecCycleEx.ReadOnly = true;
            this.txtExecCycleEx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtExecCycleEx.Size = new System.Drawing.Size(446, 116);
            this.txtExecCycleEx.TabIndex = 2;
            this.txtExecCycleEx.TabStop = false;
            this.txtExecCycleEx.Text = resources.GetString("txtExecCycleEx.Text");
            // 
            // txtExecCycle
            // 
            this.txtExecCycle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExecCycle.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExecCycle.Location = new System.Drawing.Point(140, 13);
            this.txtExecCycle.MaxLength = 1000;
            this.txtExecCycle.Name = "txtExecCycle";
            this.txtExecCycle.Size = new System.Drawing.Size(359, 25);
            this.txtExecCycle.TabIndex = 1;
            this.txtExecCycle.TabStop = false;
            // 
            // lblExeCycle
            // 
            this.lblExeCycle.AutoSize = true;
            this.lblExeCycle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExeCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExeCycle.Location = new System.Drawing.Point(13, 16);
            this.lblExeCycle.Name = "lblExeCycle";
            this.lblExeCycle.Size = new System.Drawing.Size(98, 13);
            this.lblExeCycle.TabIndex = 0;
            this.lblExeCycle.Text = "Execution Cycle";
            this.lblExeCycle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCompAlarm
            // 
            this.cdvCompAlarm.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCompAlarm.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCompAlarm.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCompAlarm.BtnToolTipText = "";
            this.cdvCompAlarm.ButtonWidth = 20;
            this.cdvCompAlarm.DescText = "";
            this.cdvCompAlarm.DisplaySubItemIndex = -1;
            this.cdvCompAlarm.DisplayText = "";
            this.cdvCompAlarm.Focusing = null;
            this.cdvCompAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCompAlarm.Index = 0;
            this.cdvCompAlarm.IsViewBtnImage = false;
            this.cdvCompAlarm.Location = new System.Drawing.Point(140, 208);
            this.cdvCompAlarm.MaxLength = 20;
            this.cdvCompAlarm.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCompAlarm.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCompAlarm.Name = "cdvCompAlarm";
            this.cdvCompAlarm.ReadOnly = true;
            this.cdvCompAlarm.SameWidthHeightOfButton = false;
            this.cdvCompAlarm.SearchSubItemIndex = 0;
            this.cdvCompAlarm.SelectedDescIndex = -1;
            this.cdvCompAlarm.SelectedSubItemIndex = -1;
            this.cdvCompAlarm.SelectionStart = 0;
            this.cdvCompAlarm.Size = new System.Drawing.Size(184, 20);
            this.cdvCompAlarm.SmallImageList = null;
            this.cdvCompAlarm.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCompAlarm.TabIndex = 8;
            this.cdvCompAlarm.TextBoxToolTipText = "";
            this.cdvCompAlarm.TextBoxWidth = 184;
            this.cdvCompAlarm.VisibleButton = true;
            this.cdvCompAlarm.VisibleColumnHeader = false;
            this.cdvCompAlarm.VisibleDescription = false;
            this.cdvCompAlarm.ButtonPress += new System.EventHandler(this.cdvCompAlarm_ButtonPress);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(15, 186);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(46, 13);
            this.lblPriority.TabIndex = 5;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplyEndTime
            // 
            this.lblApplyEndTime.AutoSize = true;
            this.lblApplyEndTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApplyEndTime.Location = new System.Drawing.Point(15, 258);
            this.lblApplyEndTime.Name = "lblApplyEndTime";
            this.lblApplyEndTime.Size = new System.Drawing.Size(81, 13);
            this.lblApplyEndTime.TabIndex = 13;
            this.lblApplyEndTime.Text = "Apply End Time";
            this.lblApplyEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplyStartTime
            // 
            this.lblApplyStartTime.AutoSize = true;
            this.lblApplyStartTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApplyStartTime.Location = new System.Drawing.Point(15, 234);
            this.lblApplyStartTime.Name = "lblApplyStartTime";
            this.lblApplyStartTime.Size = new System.Drawing.Size(84, 13);
            this.lblApplyStartTime.TabIndex = 9;
            this.lblApplyStartTime.Text = "Apply Start Time";
            this.lblApplyStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompleteAlarm
            // 
            this.lblCompleteAlarm.AutoSize = true;
            this.lblCompleteAlarm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCompleteAlarm.Location = new System.Drawing.Point(15, 210);
            this.lblCompleteAlarm.Name = "lblCompleteAlarm";
            this.lblCompleteAlarm.Size = new System.Drawing.Size(80, 13);
            this.lblCompleteAlarm.TabIndex = 7;
            this.lblCompleteAlarm.Text = "Complete Alarm";
            this.lblCompleteAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisBatPrc
            // 
            this.lisBatPrc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobProc,
            this.colDesc});
            this.lisBatPrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisBatPrc.EnableSort = true;
            this.lisBatPrc.EnableSortIcon = true;
            this.lisBatPrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisBatPrc.FullRowSelect = true;
            this.lisBatPrc.HideSelection = false;
            this.lisBatPrc.Location = new System.Drawing.Point(0, 0);
            this.lisBatPrc.MultiSelect = false;
            this.lisBatPrc.Name = "lisBatPrc";
            this.lisBatPrc.Size = new System.Drawing.Size(232, 506);
            this.lisBatPrc.TabIndex = 1;
            this.lisBatPrc.UseCompatibleStateImageBehavior = false;
            this.lisBatPrc.View = System.Windows.Forms.View.Details;
            this.lisBatPrc.SelectedIndexChanged += new System.EventHandler(this.lisBatPrc_SelectedIndexChanged);
            // 
            // colJobProc
            // 
            this.colJobProc.Text = "Job Processor";
            this.colJobProc.Width = 120;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 240;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(284, 7);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(88, 26);
            this.btnExecute.TabIndex = 5;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // frmBASSetupBatchJobProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASSetupBatchJobProcessor";
            this.Text = "Batch Job Processor Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupBatchJobProcessor_Activated);
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
            this.grbTable.ResumeLayout(false);
            this.grbTable.PerformLayout();
            this.pnlRightBottom.ResumeLayout(false);
            this.grpDateTime.ResumeLayout(false);
            this.grpDateTime.PerformLayout();
            this.grpInfoExt.ResumeLayout(false);
            this.grpInfoExt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCompAlarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTable;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtBatPrc;
        private System.Windows.Forms.Label lblBatPrc;
        private System.Windows.Forms.Panel pnlRightBottom;
        private UI.Controls.MCListView.MCListView lisBatPrc;
        private System.Windows.Forms.ColumnHeader colJobProc;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.ComboBox cboExecMethod;
        private System.Windows.Forms.Label lblExeMethod;
        private System.Windows.Forms.CheckBox chkActFlag;
        private System.Windows.Forms.TextBox txtExecCycle;
        private System.Windows.Forms.Label lblExeCycle;
        private UI.Controls.MCCodeView.MCCodeView cdvCompAlarm;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblCompleteAlarm;
        private System.Windows.Forms.GroupBox grpDateTime;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.GroupBox grpInfoExt;
        private System.Windows.Forms.TextBox txtMesChannel;
        private UI.Controls.MCCodeView.MCCodeView cdvService;
        private UI.Controls.MCCodeView.MCCodeView cdvModule;
        private System.Windows.Forms.Label lblMesChannel;
        private System.Windows.Forms.Label lblExecModSvc;
        private System.Windows.Forms.DateTimePicker dtpApplyStartTime;
        private System.Windows.Forms.DateTimePicker dtpApplyStartDate;
        private System.Windows.Forms.DateTimePicker dtpApplyEndTime;
        private System.Windows.Forms.DateTimePicker dtpApplyEndDate;
        private System.Windows.Forms.Label lblApplyEndTime;
        private System.Windows.Forms.Label lblApplyStartTime;
        private System.Windows.Forms.Label lblExecService;
        private System.Windows.Forms.TextBox txtExecCycleEx;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.CheckBox chkApplyEnd;
        private System.Windows.Forms.CheckBox chkApplyStart;
        private System.Windows.Forms.Button btnExecute;
    }
}