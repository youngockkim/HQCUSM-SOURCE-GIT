namespace Miracom.WEMCore
{
    partial class frmWEMSetupWorkProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWEMSetupWorkProcess));
            this.pnlProcType = new System.Windows.Forms.Panel();
            this.lblProcType = new System.Windows.Forms.Label();
            this.cdvProcType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lisProcessList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colProcess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpProcStep = new System.Windows.Forms.GroupBox();
            this.cdvIDRule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblIDRule = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtProcDesc = new System.Windows.Forms.TextBox();
            this.lblActionDesc = new System.Windows.Forms.Label();
            this.txtProcID = new System.Windows.Forms.TextBox();
            this.lblProcID = new System.Windows.Forms.Label();
            this.tabAssign = new System.Windows.Forms.TabControl();
            this.tbpStep = new System.Windows.Forms.TabPage();
            this.pnlStepLeft = new System.Windows.Forms.Panel();
            this.lisAssStepList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colAssStep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssStepGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssOptional = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssMinProcCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssArbitrary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssInputApprover = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssAlarmID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssStepDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpActionOption = new System.Windows.Forms.GroupBox();
            this.numMinProcCount = new System.Windows.Forms.NumericUpDown();
            this.lblMinProcCount = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.txtStepGroup = new System.Windows.Forms.TextBox();
            this.chkInputApprover = new System.Windows.Forms.CheckBox();
            this.lblAlarmID = new System.Windows.Forms.Label();
            this.cdvNotifyAlarmID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkArbitrary = new System.Windows.Forms.CheckBox();
            this.chkOptionalStep = new System.Windows.Forms.CheckBox();
            this.lblStepGroup = new System.Windows.Forms.Label();
            this.pnlStepMid = new System.Windows.Forms.Panel();
            this.btnStepDown = new System.Windows.Forms.Button();
            this.btnStepUp = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splAssignStep = new System.Windows.Forms.Splitter();
            this.pnlStepRight = new System.Windows.Forms.Panel();
            this.lisStepList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colStep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStepDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpAuth = new System.Windows.Forms.TabPage();
            this.pnlAuthMid = new System.Windows.Forms.Panel();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.pnlUserMid = new System.Windows.Forms.Panel();
            this.lisRecvList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserAssOption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlRecMid = new System.Windows.Forms.Panel();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.pnlUserRight = new System.Windows.Forms.Panel();
            this.lisPrvGrpList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colPriGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisUserList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSecGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSecGrpDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisSecGrpList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlUserType = new System.Windows.Forms.Panel();
            this.rbnPrvGroup = new System.Windows.Forms.RadioButton();
            this.rbnSecGroup = new System.Windows.Forms.RadioButton();
            this.rbnUser = new System.Windows.Forms.RadioButton();
            this.splAuth = new System.Windows.Forms.Splitter();
            this.pnlAuthTop = new System.Windows.Forms.Panel();
            this.grpAssignedStep = new System.Windows.Forms.GroupBox();
            this.lisAssStepList2 = new Miracom.UI.Controls.MCListView.MCListView();
            this.colAss2Step = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAss2Group = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAss2Optional = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAss2MinProcCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAss2Arbitrary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAss2InputApprover = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAss2AlarmID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAss2Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpAuthorityOption = new System.Windows.Forms.GroupBox();
            this.btnModify2 = new System.Windows.Forms.Button();
            this.chkAllowSkip = new System.Windows.Forms.CheckBox();
            this.rbtReadable = new System.Windows.Forms.RadioButton();
            this.rbtWritable = new System.Windows.Forms.RadioButton();
            this.chkAllowGoToAny = new System.Windows.Forms.CheckBox();
            this.chkApprover = new System.Windows.Forms.CheckBox();
            this.chkRecvNoti = new System.Windows.Forms.CheckBox();
            this.tbpCopyProcess = new System.Windows.Forms.TabPage();
            this.btnCopyProcess = new System.Windows.Forms.Button();
            this.txtToProcess = new System.Windows.Forms.TextBox();
            this.lblToProcess = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlProcType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).BeginInit();
            this.grpProcStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvIDRule)).BeginInit();
            this.tabAssign.SuspendLayout();
            this.tbpStep.SuspendLayout();
            this.pnlStepLeft.SuspendLayout();
            this.grpActionOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinProcCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNotifyAlarmID)).BeginInit();
            this.pnlStepMid.SuspendLayout();
            this.pnlStepRight.SuspendLayout();
            this.tbpAuth.SuspendLayout();
            this.pnlAuthMid.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.pnlUserMid.SuspendLayout();
            this.pnlRecMid.SuspendLayout();
            this.pnlUserRight.SuspendLayout();
            this.pnlUserType.SuspendLayout();
            this.pnlAuthTop.SuspendLayout();
            this.grpAssignedStep.SuspendLayout();
            this.grpAuthorityOption.SuspendLayout();
            this.tbpCopyProcess.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.tabAssign);
            this.pnlRight.Controls.Add(this.grpProcStep);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisProcessList);
            this.pnlLeft.Controls.Add(this.pnlProcType);
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
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // pnlProcType
            // 
            this.pnlProcType.Controls.Add(this.lblProcType);
            this.pnlProcType.Controls.Add(this.cdvProcType);
            this.pnlProcType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProcType.Location = new System.Drawing.Point(0, 0);
            this.pnlProcType.Name = "pnlProcType";
            this.pnlProcType.Size = new System.Drawing.Size(232, 50);
            this.pnlProcType.TabIndex = 1;
            // 
            // lblProcType
            // 
            this.lblProcType.AutoSize = true;
            this.lblProcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcType.Location = new System.Drawing.Point(6, 6);
            this.lblProcType.Name = "lblProcType";
            this.lblProcType.Size = new System.Drawing.Size(118, 13);
            this.lblProcType.TabIndex = 0;
            this.lblProcType.Text = "Work Process Type";
            // 
            // cdvProcType
            // 
            this.cdvProcType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvProcType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcType.BtnToolTipText = "";
            this.cdvProcType.DescText = "";
            this.cdvProcType.DisplaySubItemIndex = -1;
            this.cdvProcType.DisplayText = "";
            this.cdvProcType.Focusing = null;
            this.cdvProcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcType.Index = 0;
            this.cdvProcType.IsViewBtnImage = false;
            this.cdvProcType.Location = new System.Drawing.Point(10, 24);
            this.cdvProcType.MaxLength = 30;
            this.cdvProcType.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcType.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcType.Name = "cdvProcType";
            this.cdvProcType.ReadOnly = true;
            this.cdvProcType.SearchSubItemIndex = 0;
            this.cdvProcType.SelectedDescIndex = -1;
            this.cdvProcType.SelectedSubItemIndex = -1;
            this.cdvProcType.SelectionStart = 0;
            this.cdvProcType.Size = new System.Drawing.Size(214, 20);
            this.cdvProcType.SmallImageList = null;
            this.cdvProcType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcType.TabIndex = 1;
            this.cdvProcType.TextBoxToolTipText = "";
            this.cdvProcType.TextBoxWidth = 214;
            this.cdvProcType.VisibleButton = true;
            this.cdvProcType.VisibleColumnHeader = false;
            this.cdvProcType.VisibleDescription = false;
            this.cdvProcType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvProcType_SelectedItemChanged);
            this.cdvProcType.ButtonPress += new System.EventHandler(this.cdvProcType_ButtonPress);
            // 
            // lisProcessList
            // 
            this.lisProcessList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProcess,
            this.colDesc});
            this.lisProcessList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisProcessList.EnableSort = true;
            this.lisProcessList.EnableSortIcon = true;
            this.lisProcessList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisProcessList.FullRowSelect = true;
            this.lisProcessList.Location = new System.Drawing.Point(0, 50);
            this.lisProcessList.Name = "lisProcessList";
            this.lisProcessList.Size = new System.Drawing.Size(232, 456);
            this.lisProcessList.TabIndex = 2;
            this.lisProcessList.UseCompatibleStateImageBehavior = false;
            this.lisProcessList.View = System.Windows.Forms.View.Details;
            this.lisProcessList.SelectedIndexChanged += new System.EventHandler(this.lisProcessList_SelectedIndexChanged);
            // 
            // colProcess
            // 
            this.colProcess.Text = "Process ID";
            this.colProcess.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 150;
            // 
            // grpProcStep
            // 
            this.grpProcStep.Controls.Add(this.cdvIDRule);
            this.grpProcStep.Controls.Add(this.lblIDRule);
            this.grpProcStep.Controls.Add(this.txtTitle);
            this.grpProcStep.Controls.Add(this.lblTitle);
            this.grpProcStep.Controls.Add(this.txtProcDesc);
            this.grpProcStep.Controls.Add(this.lblActionDesc);
            this.grpProcStep.Controls.Add(this.txtProcID);
            this.grpProcStep.Controls.Add(this.lblProcID);
            this.grpProcStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpProcStep.Location = new System.Drawing.Point(0, 0);
            this.grpProcStep.Name = "grpProcStep";
            this.grpProcStep.Size = new System.Drawing.Size(506, 90);
            this.grpProcStep.TabIndex = 0;
            this.grpProcStep.TabStop = false;
            // 
            // cdvIDRule
            // 
            this.cdvIDRule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvIDRule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvIDRule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvIDRule.BtnToolTipText = "";
            this.cdvIDRule.DescText = "";
            this.cdvIDRule.DisplaySubItemIndex = -1;
            this.cdvIDRule.DisplayText = "";
            this.cdvIDRule.Focusing = null;
            this.cdvIDRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvIDRule.Index = 0;
            this.cdvIDRule.IsViewBtnImage = false;
            this.cdvIDRule.Location = new System.Drawing.Point(301, 39);
            this.cdvIDRule.MaxLength = 20;
            this.cdvIDRule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvIDRule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvIDRule.Name = "cdvIDRule";
            this.cdvIDRule.ReadOnly = true;
            this.cdvIDRule.SearchSubItemIndex = 0;
            this.cdvIDRule.SelectedDescIndex = -1;
            this.cdvIDRule.SelectedSubItemIndex = -1;
            this.cdvIDRule.SelectionStart = 0;
            this.cdvIDRule.Size = new System.Drawing.Size(199, 20);
            this.cdvIDRule.SmallImageList = null;
            this.cdvIDRule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvIDRule.TabIndex = 7;
            this.cdvIDRule.TextBoxToolTipText = "";
            this.cdvIDRule.TextBoxWidth = 199;
            this.cdvIDRule.VisibleButton = true;
            this.cdvIDRule.VisibleColumnHeader = false;
            this.cdvIDRule.VisibleDescription = false;
            this.cdvIDRule.ButtonPress += new System.EventHandler(this.cdvIDRule_ButtonPress);
            // 
            // lblIDRule
            // 
            this.lblIDRule.AutoSize = true;
            this.lblIDRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDRule.Location = new System.Drawing.Point(298, 19);
            this.lblIDRule.Name = "lblIDRule";
            this.lblIDRule.Size = new System.Drawing.Size(170, 13);
            this.lblIDRule.TabIndex = 6;
            this.lblIDRule.Text = "Process Event ID Generation Rule";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(100, 39);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(180, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(10, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            // 
            // txtProcDesc
            // 
            this.txtProcDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcDesc.Location = new System.Drawing.Point(100, 63);
            this.txtProcDesc.MaxLength = 200;
            this.txtProcDesc.Name = "txtProcDesc";
            this.txtProcDesc.Size = new System.Drawing.Size(400, 20);
            this.txtProcDesc.TabIndex = 5;
            // 
            // lblActionDesc
            // 
            this.lblActionDesc.AutoSize = true;
            this.lblActionDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionDesc.Location = new System.Drawing.Point(10, 67);
            this.lblActionDesc.Name = "lblActionDesc";
            this.lblActionDesc.Size = new System.Drawing.Size(60, 13);
            this.lblActionDesc.TabIndex = 4;
            this.lblActionDesc.Text = "Description";
            // 
            // txtProcID
            // 
            this.txtProcID.Location = new System.Drawing.Point(100, 15);
            this.txtProcID.MaxLength = 30;
            this.txtProcID.Name = "txtProcID";
            this.txtProcID.Size = new System.Drawing.Size(180, 20);
            this.txtProcID.TabIndex = 1;
            // 
            // lblProcID
            // 
            this.lblProcID.AutoSize = true;
            this.lblProcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcID.Location = new System.Drawing.Point(10, 19);
            this.lblProcID.Name = "lblProcID";
            this.lblProcID.Size = new System.Drawing.Size(69, 13);
            this.lblProcID.TabIndex = 0;
            this.lblProcID.Text = "Process ID";
            // 
            // tabAssign
            // 
            this.tabAssign.Controls.Add(this.tbpStep);
            this.tabAssign.Controls.Add(this.tbpAuth);
            this.tabAssign.Controls.Add(this.tbpCopyProcess);
            this.tabAssign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAssign.Location = new System.Drawing.Point(0, 90);
            this.tabAssign.Name = "tabAssign";
            this.tabAssign.SelectedIndex = 0;
            this.tabAssign.Size = new System.Drawing.Size(506, 416);
            this.tabAssign.TabIndex = 1;
            this.tabAssign.SelectedIndexChanged += new System.EventHandler(this.tabAssign_SelectedIndexChanged);
            // 
            // tbpStep
            // 
            this.tbpStep.Controls.Add(this.pnlStepLeft);
            this.tbpStep.Controls.Add(this.pnlStepMid);
            this.tbpStep.Controls.Add(this.splAssignStep);
            this.tbpStep.Controls.Add(this.pnlStepRight);
            this.tbpStep.Location = new System.Drawing.Point(4, 22);
            this.tbpStep.Name = "tbpStep";
            this.tbpStep.Padding = new System.Windows.Forms.Padding(3);
            this.tbpStep.Size = new System.Drawing.Size(498, 390);
            this.tbpStep.TabIndex = 0;
            this.tbpStep.Text = "Assign Step";
            // 
            // pnlStepLeft
            // 
            this.pnlStepLeft.Controls.Add(this.lisAssStepList);
            this.pnlStepLeft.Controls.Add(this.grpActionOption);
            this.pnlStepLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStepLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlStepLeft.Name = "pnlStepLeft";
            this.pnlStepLeft.Size = new System.Drawing.Size(272, 384);
            this.pnlStepLeft.TabIndex = 0;
            // 
            // lisAssStepList
            // 
            this.lisAssStepList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAssStep,
            this.colAssStepGroup,
            this.colAssOptional,
            this.colAssMinProcCount,
            this.colAssArbitrary,
            this.colAssInputApprover,
            this.colAssAlarmID,
            this.colAssStepDesc});
            this.lisAssStepList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAssStepList.EnableSort = true;
            this.lisAssStepList.EnableSortIcon = true;
            this.lisAssStepList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAssStepList.FullRowSelect = true;
            this.lisAssStepList.HideSelection = false;
            this.lisAssStepList.Location = new System.Drawing.Point(0, 146);
            this.lisAssStepList.Name = "lisAssStepList";
            this.lisAssStepList.Size = new System.Drawing.Size(272, 238);
            this.lisAssStepList.TabIndex = 1;
            this.lisAssStepList.UseCompatibleStateImageBehavior = false;
            this.lisAssStepList.View = System.Windows.Forms.View.Details;
            this.lisAssStepList.SelectedIndexChanged += new System.EventHandler(this.lisAssStepList_SelectedIndexChanged);
            // 
            // colAssStep
            // 
            this.colAssStep.Text = "Step";
            this.colAssStep.Width = 80;
            // 
            // colAssStepGroup
            // 
            this.colAssStepGroup.Text = "Group";
            this.colAssStepGroup.Width = 40;
            // 
            // colAssOptional
            // 
            this.colAssOptional.Text = "Optional";
            this.colAssOptional.Width = 30;
            // 
            // colAssMinProcCount
            // 
            this.colAssMinProcCount.Text = "Minimum Process Step Count";
            this.colAssMinProcCount.Width = 30;
            // 
            // colAssArbitrary
            // 
            this.colAssArbitrary.Text = "Arbitrary";
            this.colAssArbitrary.Width = 30;
            // 
            // colAssInputApprover
            // 
            this.colAssInputApprover.Text = "Input Approver";
            this.colAssInputApprover.Width = 30;
            // 
            // colAssAlarmID
            // 
            this.colAssAlarmID.Text = "Alarm ID";
            // 
            // colAssStepDesc
            // 
            this.colAssStepDesc.Text = "Description";
            this.colAssStepDesc.Width = 150;
            // 
            // grpActionOption
            // 
            this.grpActionOption.Controls.Add(this.numMinProcCount);
            this.grpActionOption.Controls.Add(this.lblMinProcCount);
            this.grpActionOption.Controls.Add(this.btnModify);
            this.grpActionOption.Controls.Add(this.txtStepGroup);
            this.grpActionOption.Controls.Add(this.chkInputApprover);
            this.grpActionOption.Controls.Add(this.lblAlarmID);
            this.grpActionOption.Controls.Add(this.cdvNotifyAlarmID);
            this.grpActionOption.Controls.Add(this.chkArbitrary);
            this.grpActionOption.Controls.Add(this.chkOptionalStep);
            this.grpActionOption.Controls.Add(this.lblStepGroup);
            this.grpActionOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActionOption.Location = new System.Drawing.Point(0, 0);
            this.grpActionOption.Name = "grpActionOption";
            this.grpActionOption.Size = new System.Drawing.Size(272, 146);
            this.grpActionOption.TabIndex = 0;
            this.grpActionOption.TabStop = false;
            this.grpActionOption.Text = "Assign Option";
            // 
            // numMinProcCount
            // 
            this.numMinProcCount.Enabled = false;
            this.numMinProcCount.Location = new System.Drawing.Point(216, 57);
            this.numMinProcCount.Name = "numMinProcCount";
            this.numMinProcCount.Size = new System.Drawing.Size(50, 20);
            this.numMinProcCount.TabIndex = 5;
            // 
            // lblMinProcCount
            // 
            this.lblMinProcCount.AutoSize = true;
            this.lblMinProcCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinProcCount.Location = new System.Drawing.Point(3, 59);
            this.lblMinProcCount.Name = "lblMinProcCount";
            this.lblMinProcCount.Size = new System.Drawing.Size(145, 13);
            this.lblMinProcCount.TabIndex = 4;
            this.lblMinProcCount.Text = "Minimum Process Step Count";
            // 
            // btnModify
            // 
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(178, 119);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(88, 24);
            this.btnModify.TabIndex = 9;
            this.btnModify.Text = "Modify";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // txtStepGroup
            // 
            this.txtStepGroup.Location = new System.Drawing.Point(124, 34);
            this.txtStepGroup.MaxLength = 50;
            this.txtStepGroup.Name = "txtStepGroup";
            this.txtStepGroup.Size = new System.Drawing.Size(142, 20);
            this.txtStepGroup.TabIndex = 3;
            // 
            // chkInputApprover
            // 
            this.chkInputApprover.AutoSize = true;
            this.chkInputApprover.Location = new System.Drawing.Point(6, 78);
            this.chkInputApprover.Name = "chkInputApprover";
            this.chkInputApprover.Size = new System.Drawing.Size(190, 17);
            this.chkInputApprover.TabIndex = 6;
            this.chkInputApprover.Text = "Manual input approver of next step";
            this.chkInputApprover.UseVisualStyleBackColor = true;
            // 
            // lblAlarmID
            // 
            this.lblAlarmID.AutoSize = true;
            this.lblAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmID.Location = new System.Drawing.Point(3, 101);
            this.lblAlarmID.Name = "lblAlarmID";
            this.lblAlarmID.Size = new System.Drawing.Size(77, 13);
            this.lblAlarmID.TabIndex = 7;
            this.lblAlarmID.Text = "Notify Alarm ID";
            // 
            // cdvNotifyAlarmID
            // 
            this.cdvNotifyAlarmID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvNotifyAlarmID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvNotifyAlarmID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvNotifyAlarmID.BtnToolTipText = "";
            this.cdvNotifyAlarmID.DescText = "";
            this.cdvNotifyAlarmID.DisplaySubItemIndex = -1;
            this.cdvNotifyAlarmID.DisplayText = "";
            this.cdvNotifyAlarmID.Focusing = null;
            this.cdvNotifyAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvNotifyAlarmID.Index = 0;
            this.cdvNotifyAlarmID.IsViewBtnImage = false;
            this.cdvNotifyAlarmID.Location = new System.Drawing.Point(124, 97);
            this.cdvNotifyAlarmID.MaxLength = 20;
            this.cdvNotifyAlarmID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvNotifyAlarmID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvNotifyAlarmID.Name = "cdvNotifyAlarmID";
            this.cdvNotifyAlarmID.ReadOnly = true;
            this.cdvNotifyAlarmID.SearchSubItemIndex = 0;
            this.cdvNotifyAlarmID.SelectedDescIndex = -1;
            this.cdvNotifyAlarmID.SelectedSubItemIndex = -1;
            this.cdvNotifyAlarmID.SelectionStart = 0;
            this.cdvNotifyAlarmID.Size = new System.Drawing.Size(142, 20);
            this.cdvNotifyAlarmID.SmallImageList = null;
            this.cdvNotifyAlarmID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvNotifyAlarmID.TabIndex = 8;
            this.cdvNotifyAlarmID.TextBoxToolTipText = "";
            this.cdvNotifyAlarmID.TextBoxWidth = 142;
            this.cdvNotifyAlarmID.VisibleButton = true;
            this.cdvNotifyAlarmID.VisibleColumnHeader = false;
            this.cdvNotifyAlarmID.VisibleDescription = false;
            this.cdvNotifyAlarmID.ButtonPress += new System.EventHandler(this.cdvNotifyAlarmID_ButtonPress);
            // 
            // chkArbitrary
            // 
            this.chkArbitrary.AutoSize = true;
            this.chkArbitrary.Location = new System.Drawing.Point(124, 16);
            this.chkArbitrary.Name = "chkArbitrary";
            this.chkArbitrary.Size = new System.Drawing.Size(108, 17);
            this.chkArbitrary.TabIndex = 1;
            this.chkArbitrary.Text = "Arbitrary Decision";
            this.chkArbitrary.UseVisualStyleBackColor = true;
            // 
            // chkOptionalStep
            // 
            this.chkOptionalStep.AutoSize = true;
            this.chkOptionalStep.Location = new System.Drawing.Point(6, 16);
            this.chkOptionalStep.Name = "chkOptionalStep";
            this.chkOptionalStep.Size = new System.Drawing.Size(90, 17);
            this.chkOptionalStep.TabIndex = 0;
            this.chkOptionalStep.Text = "Optional Step";
            this.chkOptionalStep.UseVisualStyleBackColor = true;
            // 
            // lblStepGroup
            // 
            this.lblStepGroup.AutoSize = true;
            this.lblStepGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepGroup.Location = new System.Drawing.Point(3, 38);
            this.lblStepGroup.Name = "lblStepGroup";
            this.lblStepGroup.Size = new System.Drawing.Size(61, 13);
            this.lblStepGroup.TabIndex = 2;
            this.lblStepGroup.Text = "Step Group";
            // 
            // pnlStepMid
            // 
            this.pnlStepMid.Controls.Add(this.btnStepDown);
            this.pnlStepMid.Controls.Add(this.btnStepUp);
            this.pnlStepMid.Controls.Add(this.btnDel);
            this.pnlStepMid.Controls.Add(this.btnAdd);
            this.pnlStepMid.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlStepMid.Location = new System.Drawing.Point(275, 3);
            this.pnlStepMid.Name = "pnlStepMid";
            this.pnlStepMid.Size = new System.Drawing.Size(37, 384);
            this.pnlStepMid.TabIndex = 0;
            // 
            // btnStepDown
            // 
            this.btnStepDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStepDown.Image = ((System.Drawing.Image)(resources.GetObject("btnStepDown.Image")));
            this.btnStepDown.Location = new System.Drawing.Point(2, 360);
            this.btnStepDown.Name = "btnStepDown";
            this.btnStepDown.Size = new System.Drawing.Size(22, 22);
            this.btnStepDown.TabIndex = 3;
            this.btnStepDown.UseVisualStyleBackColor = true;
            this.btnStepDown.Click += new System.EventHandler(this.btnStepDown_Click);
            // 
            // btnStepUp
            // 
            this.btnStepUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStepUp.Image = ((System.Drawing.Image)(resources.GetObject("btnStepUp.Image")));
            this.btnStepUp.Location = new System.Drawing.Point(2, 335);
            this.btnStepUp.Name = "btnStepUp";
            this.btnStepUp.Size = new System.Drawing.Size(22, 22);
            this.btnStepUp.TabIndex = 2;
            this.btnStepUp.UseVisualStyleBackColor = true;
            this.btnStepUp.Click += new System.EventHandler(this.btnStepUp_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Location = new System.Drawing.Point(6, 202);
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
            this.btnAdd.Location = new System.Drawing.Point(6, 175);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splAssignStep
            // 
            this.splAssignStep.Dock = System.Windows.Forms.DockStyle.Right;
            this.splAssignStep.Location = new System.Drawing.Point(312, 3);
            this.splAssignStep.Name = "splAssignStep";
            this.splAssignStep.Size = new System.Drawing.Size(3, 384);
            this.splAssignStep.TabIndex = 3;
            this.splAssignStep.TabStop = false;
            // 
            // pnlStepRight
            // 
            this.pnlStepRight.Controls.Add(this.lisStepList);
            this.pnlStepRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlStepRight.Location = new System.Drawing.Point(315, 3);
            this.pnlStepRight.Name = "pnlStepRight";
            this.pnlStepRight.Size = new System.Drawing.Size(180, 384);
            this.pnlStepRight.TabIndex = 2;
            // 
            // lisStepList
            // 
            this.lisStepList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStep,
            this.colStepDesc});
            this.lisStepList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisStepList.EnableSort = true;
            this.lisStepList.EnableSortIcon = true;
            this.lisStepList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisStepList.FullRowSelect = true;
            this.lisStepList.HideSelection = false;
            this.lisStepList.Location = new System.Drawing.Point(0, 0);
            this.lisStepList.Name = "lisStepList";
            this.lisStepList.Size = new System.Drawing.Size(180, 384);
            this.lisStepList.TabIndex = 0;
            this.lisStepList.UseCompatibleStateImageBehavior = false;
            this.lisStepList.View = System.Windows.Forms.View.Details;
            // 
            // colStep
            // 
            this.colStep.Text = "Step";
            this.colStep.Width = 100;
            // 
            // colStepDesc
            // 
            this.colStepDesc.Text = "Description";
            this.colStepDesc.Width = 150;
            // 
            // tbpAuth
            // 
            this.tbpAuth.Controls.Add(this.pnlAuthMid);
            this.tbpAuth.Controls.Add(this.splAuth);
            this.tbpAuth.Controls.Add(this.pnlAuthTop);
            this.tbpAuth.Location = new System.Drawing.Point(4, 22);
            this.tbpAuth.Name = "tbpAuth";
            this.tbpAuth.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAuth.Size = new System.Drawing.Size(498, 390);
            this.tbpAuth.TabIndex = 1;
            this.tbpAuth.Text = "Authority";
            // 
            // pnlAuthMid
            // 
            this.pnlAuthMid.Controls.Add(this.grpUser);
            this.pnlAuthMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAuthMid.Location = new System.Drawing.Point(3, 203);
            this.pnlAuthMid.Name = "pnlAuthMid";
            this.pnlAuthMid.Size = new System.Drawing.Size(492, 184);
            this.pnlAuthMid.TabIndex = 1;
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.pnlUserMid);
            this.grpUser.Controls.Add(this.pnlRecMid);
            this.grpUser.Controls.Add(this.pnlUserRight);
            this.grpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUser.Location = new System.Drawing.Point(0, 0);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(492, 184);
            this.grpUser.TabIndex = 0;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "User Information";
            // 
            // pnlUserMid
            // 
            this.pnlUserMid.Controls.Add(this.lisRecvList);
            this.pnlUserMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserMid.Location = new System.Drawing.Point(3, 16);
            this.pnlUserMid.Name = "pnlUserMid";
            this.pnlUserMid.Size = new System.Drawing.Size(187, 165);
            this.pnlUserMid.TabIndex = 0;
            // 
            // lisRecvList
            // 
            this.lisRecvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUser,
            this.colUserType,
            this.colUserAssOption});
            this.lisRecvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRecvList.EnableSort = true;
            this.lisRecvList.EnableSortIcon = true;
            this.lisRecvList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRecvList.FullRowSelect = true;
            this.lisRecvList.Location = new System.Drawing.Point(0, 0);
            this.lisRecvList.Name = "lisRecvList";
            this.lisRecvList.Size = new System.Drawing.Size(187, 165);
            this.lisRecvList.TabIndex = 0;
            this.lisRecvList.UseCompatibleStateImageBehavior = false;
            this.lisRecvList.View = System.Windows.Forms.View.Details;
            this.lisRecvList.SelectedIndexChanged += new System.EventHandler(this.lisRecvList_SelectedIndexChanged);
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            this.colUser.Width = 100;
            // 
            // colUserType
            // 
            this.colUserType.Text = "Type";
            this.colUserType.Width = 70;
            // 
            // colUserAssOption
            // 
            this.colUserAssOption.Text = "Option";
            // 
            // pnlRecMid
            // 
            this.pnlRecMid.Controls.Add(this.btnDetach);
            this.pnlRecMid.Controls.Add(this.btnAttach);
            this.pnlRecMid.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRecMid.Location = new System.Drawing.Point(190, 16);
            this.pnlRecMid.Name = "pnlRecMid";
            this.pnlRecMid.Size = new System.Drawing.Size(31, 165);
            this.pnlRecMid.TabIndex = 0;
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetach.Location = new System.Drawing.Point(3, 85);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 1;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(3, 56);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 0;
            this.btnAttach.Text = "< ";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // pnlUserRight
            // 
            this.pnlUserRight.Controls.Add(this.lisPrvGrpList);
            this.pnlUserRight.Controls.Add(this.lisUserList);
            this.pnlUserRight.Controls.Add(this.lisSecGrpList);
            this.pnlUserRight.Controls.Add(this.pnlUserType);
            this.pnlUserRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUserRight.Location = new System.Drawing.Point(221, 16);
            this.pnlUserRight.Name = "pnlUserRight";
            this.pnlUserRight.Size = new System.Drawing.Size(268, 165);
            this.pnlUserRight.TabIndex = 0;
            // 
            // lisPrvGrpList
            // 
            this.lisPrvGrpList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPriGroup,
            this.colPriDesc});
            this.lisPrvGrpList.EnableSort = true;
            this.lisPrvGrpList.EnableSortIcon = true;
            this.lisPrvGrpList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisPrvGrpList.FullRowSelect = true;
            this.lisPrvGrpList.Location = new System.Drawing.Point(96, 66);
            this.lisPrvGrpList.Name = "lisPrvGrpList";
            this.lisPrvGrpList.Size = new System.Drawing.Size(169, 96);
            this.lisPrvGrpList.TabIndex = 2;
            this.lisPrvGrpList.UseCompatibleStateImageBehavior = false;
            this.lisPrvGrpList.View = System.Windows.Forms.View.Details;
            // 
            // colPriGroup
            // 
            this.colPriGroup.Text = "Privilege Group";
            this.colPriGroup.Width = 100;
            // 
            // colPriDesc
            // 
            this.colPriDesc.Text = "Description";
            this.colPriDesc.Width = 150;
            // 
            // lisUserList
            // 
            this.lisUserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSecGroup,
            this.colSecGrpDesc});
            this.lisUserList.EnableSort = true;
            this.lisUserList.EnableSortIcon = true;
            this.lisUserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisUserList.FullRowSelect = true;
            this.lisUserList.Location = new System.Drawing.Point(0, 42);
            this.lisUserList.Name = "lisUserList";
            this.lisUserList.Size = new System.Drawing.Size(142, 109);
            this.lisUserList.TabIndex = 1;
            this.lisUserList.UseCompatibleStateImageBehavior = false;
            this.lisUserList.View = System.Windows.Forms.View.Details;
            // 
            // colSecGroup
            // 
            this.colSecGroup.Text = "Security Group";
            this.colSecGroup.Width = 100;
            // 
            // colSecGrpDesc
            // 
            this.colSecGrpDesc.Text = "Description";
            this.colSecGrpDesc.Width = 150;
            // 
            // lisSecGrpList
            // 
            this.lisSecGrpList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUserID,
            this.colUserDescription});
            this.lisSecGrpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSecGrpList.EnableSort = true;
            this.lisSecGrpList.EnableSortIcon = true;
            this.lisSecGrpList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSecGrpList.FullRowSelect = true;
            this.lisSecGrpList.Location = new System.Drawing.Point(0, 22);
            this.lisSecGrpList.Name = "lisSecGrpList";
            this.lisSecGrpList.Size = new System.Drawing.Size(268, 143);
            this.lisSecGrpList.TabIndex = 0;
            this.lisSecGrpList.UseCompatibleStateImageBehavior = false;
            this.lisSecGrpList.View = System.Windows.Forms.View.Details;
            // 
            // colUserID
            // 
            this.colUserID.Text = "User ID";
            this.colUserID.Width = 100;
            // 
            // colUserDescription
            // 
            this.colUserDescription.Text = "Description";
            this.colUserDescription.Width = 150;
            // 
            // pnlUserType
            // 
            this.pnlUserType.Controls.Add(this.rbnPrvGroup);
            this.pnlUserType.Controls.Add(this.rbnSecGroup);
            this.pnlUserType.Controls.Add(this.rbnUser);
            this.pnlUserType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserType.Location = new System.Drawing.Point(0, 0);
            this.pnlUserType.Name = "pnlUserType";
            this.pnlUserType.Size = new System.Drawing.Size(268, 22);
            this.pnlUserType.TabIndex = 0;
            // 
            // rbnPrvGroup
            // 
            this.rbnPrvGroup.AutoSize = true;
            this.rbnPrvGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnPrvGroup.Location = new System.Drawing.Point(162, 2);
            this.rbnPrvGroup.Name = "rbnPrvGroup";
            this.rbnPrvGroup.Size = new System.Drawing.Size(103, 18);
            this.rbnPrvGroup.TabIndex = 2;
            this.rbnPrvGroup.TabStop = true;
            this.rbnPrvGroup.Text = "Privilege Group";
            this.rbnPrvGroup.CheckedChanged += new System.EventHandler(this.rbnUserType_CheckedChanged);
            // 
            // rbnSecGroup
            // 
            this.rbnSecGroup.AutoSize = true;
            this.rbnSecGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnSecGroup.Location = new System.Drawing.Point(59, 2);
            this.rbnSecGroup.Name = "rbnSecGroup";
            this.rbnSecGroup.Size = new System.Drawing.Size(101, 18);
            this.rbnSecGroup.TabIndex = 1;
            this.rbnSecGroup.TabStop = true;
            this.rbnSecGroup.Text = "Security Group";
            this.rbnSecGroup.CheckedChanged += new System.EventHandler(this.rbnUserType_CheckedChanged);
            // 
            // rbnUser
            // 
            this.rbnUser.AutoSize = true;
            this.rbnUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnUser.Location = new System.Drawing.Point(4, 2);
            this.rbnUser.Name = "rbnUser";
            this.rbnUser.Size = new System.Drawing.Size(53, 18);
            this.rbnUser.TabIndex = 0;
            this.rbnUser.TabStop = true;
            this.rbnUser.Text = "User";
            this.rbnUser.CheckedChanged += new System.EventHandler(this.rbnUserType_CheckedChanged);
            // 
            // splAuth
            // 
            this.splAuth.Dock = System.Windows.Forms.DockStyle.Top;
            this.splAuth.Location = new System.Drawing.Point(3, 200);
            this.splAuth.Name = "splAuth";
            this.splAuth.Size = new System.Drawing.Size(492, 3);
            this.splAuth.TabIndex = 0;
            this.splAuth.TabStop = false;
            // 
            // pnlAuthTop
            // 
            this.pnlAuthTop.Controls.Add(this.grpAssignedStep);
            this.pnlAuthTop.Controls.Add(this.grpAuthorityOption);
            this.pnlAuthTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAuthTop.Location = new System.Drawing.Point(3, 3);
            this.pnlAuthTop.Name = "pnlAuthTop";
            this.pnlAuthTop.Size = new System.Drawing.Size(492, 197);
            this.pnlAuthTop.TabIndex = 0;
            // 
            // grpAssignedStep
            // 
            this.grpAssignedStep.Controls.Add(this.lisAssStepList2);
            this.grpAssignedStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAssignedStep.Location = new System.Drawing.Point(0, 0);
            this.grpAssignedStep.Name = "grpAssignedStep";
            this.grpAssignedStep.Size = new System.Drawing.Size(315, 197);
            this.grpAssignedStep.TabIndex = 0;
            this.grpAssignedStep.TabStop = false;
            this.grpAssignedStep.Text = "Assigned Step List";
            // 
            // lisAssStepList2
            // 
            this.lisAssStepList2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAss2Step,
            this.colAss2Group,
            this.colAss2Optional,
            this.colAss2MinProcCount,
            this.colAss2Arbitrary,
            this.colAss2InputApprover,
            this.colAss2AlarmID,
            this.colAss2Desc});
            this.lisAssStepList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAssStepList2.EnableSort = true;
            this.lisAssStepList2.EnableSortIcon = true;
            this.lisAssStepList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAssStepList2.FullRowSelect = true;
            this.lisAssStepList2.Location = new System.Drawing.Point(3, 16);
            this.lisAssStepList2.MultiSelect = false;
            this.lisAssStepList2.Name = "lisAssStepList2";
            this.lisAssStepList2.Size = new System.Drawing.Size(309, 178);
            this.lisAssStepList2.TabIndex = 2;
            this.lisAssStepList2.UseCompatibleStateImageBehavior = false;
            this.lisAssStepList2.View = System.Windows.Forms.View.Details;
            this.lisAssStepList2.SelectedIndexChanged += new System.EventHandler(this.lisAssStepList2_SelectedIndexChanged);
            // 
            // colAss2Step
            // 
            this.colAss2Step.Text = "Step";
            this.colAss2Step.Width = 80;
            // 
            // colAss2Group
            // 
            this.colAss2Group.Text = "Group";
            this.colAss2Group.Width = 40;
            // 
            // colAss2Optional
            // 
            this.colAss2Optional.Text = "Optional";
            this.colAss2Optional.Width = 30;
            // 
            // colAss2MinProcCount
            // 
            this.colAss2MinProcCount.Text = "Minimum Process Step Count";
            this.colAss2MinProcCount.Width = 30;
            // 
            // colAss2Arbitrary
            // 
            this.colAss2Arbitrary.Text = "Arbitrary";
            this.colAss2Arbitrary.Width = 30;
            // 
            // colAss2InputApprover
            // 
            this.colAss2InputApprover.Text = "Input Approver";
            this.colAss2InputApprover.Width = 30;
            // 
            // colAss2AlarmID
            // 
            this.colAss2AlarmID.Text = "Alarm ID";
            // 
            // colAss2Desc
            // 
            this.colAss2Desc.Text = "Description";
            this.colAss2Desc.Width = 150;
            // 
            // grpAuthorityOption
            // 
            this.grpAuthorityOption.Controls.Add(this.btnModify2);
            this.grpAuthorityOption.Controls.Add(this.chkAllowSkip);
            this.grpAuthorityOption.Controls.Add(this.rbtReadable);
            this.grpAuthorityOption.Controls.Add(this.rbtWritable);
            this.grpAuthorityOption.Controls.Add(this.chkAllowGoToAny);
            this.grpAuthorityOption.Controls.Add(this.chkApprover);
            this.grpAuthorityOption.Controls.Add(this.chkRecvNoti);
            this.grpAuthorityOption.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpAuthorityOption.Location = new System.Drawing.Point(315, 0);
            this.grpAuthorityOption.Name = "grpAuthorityOption";
            this.grpAuthorityOption.Size = new System.Drawing.Size(177, 197);
            this.grpAuthorityOption.TabIndex = 0;
            this.grpAuthorityOption.TabStop = false;
            this.grpAuthorityOption.Text = "Authority Option";
            // 
            // btnModify2
            // 
            this.btnModify2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnModify2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify2.Location = new System.Drawing.Point(3, 170);
            this.btnModify2.Name = "btnModify2";
            this.btnModify2.Size = new System.Drawing.Size(88, 24);
            this.btnModify2.TabIndex = 6;
            this.btnModify2.Text = "Modify";
            this.btnModify2.Click += new System.EventHandler(this.btnModify2_Click);
            // 
            // chkAllowSkip
            // 
            this.chkAllowSkip.AutoSize = true;
            this.chkAllowSkip.Location = new System.Drawing.Point(6, 101);
            this.chkAllowSkip.Name = "chkAllowSkip";
            this.chkAllowSkip.Size = new System.Drawing.Size(115, 17);
            this.chkAllowSkip.TabIndex = 3;
            this.chkAllowSkip.Text = "Allow skip this step";
            this.chkAllowSkip.UseVisualStyleBackColor = true;
            // 
            // rbtReadable
            // 
            this.rbtReadable.AutoSize = true;
            this.rbtReadable.Location = new System.Drawing.Point(6, 19);
            this.rbtReadable.Name = "rbtReadable";
            this.rbtReadable.Size = new System.Drawing.Size(71, 17);
            this.rbtReadable.TabIndex = 0;
            this.rbtReadable.TabStop = true;
            this.rbtReadable.Text = "Readable";
            this.rbtReadable.UseVisualStyleBackColor = true;
            // 
            // rbtWritable
            // 
            this.rbtWritable.AutoSize = true;
            this.rbtWritable.Location = new System.Drawing.Point(6, 42);
            this.rbtWritable.Name = "rbtWritable";
            this.rbtWritable.Size = new System.Drawing.Size(101, 17);
            this.rbtWritable.TabIndex = 1;
            this.rbtWritable.TabStop = true;
            this.rbtWritable.Text = "Read / Writable";
            this.rbtWritable.UseVisualStyleBackColor = true;
            // 
            // chkAllowGoToAny
            // 
            this.chkAllowGoToAny.AutoSize = true;
            this.chkAllowGoToAny.Location = new System.Drawing.Point(6, 147);
            this.chkAllowGoToAny.Name = "chkAllowGoToAny";
            this.chkAllowGoToAny.Size = new System.Drawing.Size(121, 17);
            this.chkAllowGoToAny.TabIndex = 5;
            this.chkAllowGoToAny.Text = "Allow go to any step";
            this.chkAllowGoToAny.UseVisualStyleBackColor = true;
            // 
            // chkApprover
            // 
            this.chkApprover.AutoSize = true;
            this.chkApprover.Location = new System.Drawing.Point(6, 124);
            this.chkApprover.Name = "chkApprover";
            this.chkApprover.Size = new System.Drawing.Size(69, 17);
            this.chkApprover.TabIndex = 4;
            this.chkApprover.Text = "Approver";
            this.chkApprover.UseVisualStyleBackColor = true;
            // 
            // chkRecvNoti
            // 
            this.chkRecvNoti.AutoSize = true;
            this.chkRecvNoti.Location = new System.Drawing.Point(6, 78);
            this.chkRecvNoti.Name = "chkRecvNoti";
            this.chkRecvNoti.Size = new System.Drawing.Size(120, 17);
            this.chkRecvNoti.TabIndex = 2;
            this.chkRecvNoti.Text = "Receive notification";
            this.chkRecvNoti.UseVisualStyleBackColor = true;
            // 
            // tbpCopyProcess
            // 
            this.tbpCopyProcess.Controls.Add(this.btnCopyProcess);
            this.tbpCopyProcess.Controls.Add(this.txtToProcess);
            this.tbpCopyProcess.Controls.Add(this.lblToProcess);
            this.tbpCopyProcess.Location = new System.Drawing.Point(4, 22);
            this.tbpCopyProcess.Name = "tbpCopyProcess";
            this.tbpCopyProcess.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCopyProcess.Size = new System.Drawing.Size(498, 390);
            this.tbpCopyProcess.TabIndex = 2;
            this.tbpCopyProcess.Text = "Copy Process";
            // 
            // btnCopyProcess
            // 
            this.btnCopyProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopyProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyProcess.Location = new System.Drawing.Point(282, 4);
            this.btnCopyProcess.Name = "btnCopyProcess";
            this.btnCopyProcess.Size = new System.Drawing.Size(88, 24);
            this.btnCopyProcess.TabIndex = 10;
            this.btnCopyProcess.Text = "Copy";
            this.btnCopyProcess.Click += new System.EventHandler(this.btnCopyProcess_Click);
            // 
            // txtToProcess
            // 
            this.txtToProcess.Location = new System.Drawing.Point(96, 6);
            this.txtToProcess.MaxLength = 30;
            this.txtToProcess.Name = "txtToProcess";
            this.txtToProcess.Size = new System.Drawing.Size(180, 20);
            this.txtToProcess.TabIndex = 3;
            // 
            // lblToProcess
            // 
            this.lblToProcess.AutoSize = true;
            this.lblToProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToProcess.Location = new System.Drawing.Point(6, 10);
            this.lblToProcess.Name = "lblToProcess";
            this.lblToProcess.Size = new System.Drawing.Size(61, 13);
            this.lblToProcess.TabIndex = 2;
            this.lblToProcess.Text = "To Process";
            // 
            // frmWEMSetupWorkProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWEMSetupWorkProcess";
            this.Text = "Work Process Setup";
            this.Activated += new System.EventHandler(this.frmWEMSetupWorkProcess_Activated);
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
            this.pnlProcType.ResumeLayout(false);
            this.pnlProcType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).EndInit();
            this.grpProcStep.ResumeLayout(false);
            this.grpProcStep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvIDRule)).EndInit();
            this.tabAssign.ResumeLayout(false);
            this.tbpStep.ResumeLayout(false);
            this.pnlStepLeft.ResumeLayout(false);
            this.grpActionOption.ResumeLayout(false);
            this.grpActionOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinProcCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNotifyAlarmID)).EndInit();
            this.pnlStepMid.ResumeLayout(false);
            this.pnlStepRight.ResumeLayout(false);
            this.tbpAuth.ResumeLayout(false);
            this.pnlAuthMid.ResumeLayout(false);
            this.grpUser.ResumeLayout(false);
            this.pnlUserMid.ResumeLayout(false);
            this.pnlRecMid.ResumeLayout(false);
            this.pnlUserRight.ResumeLayout(false);
            this.pnlUserType.ResumeLayout(false);
            this.pnlUserType.PerformLayout();
            this.pnlAuthTop.ResumeLayout(false);
            this.grpAssignedStep.ResumeLayout(false);
            this.grpAuthorityOption.ResumeLayout(false);
            this.grpAuthorityOption.PerformLayout();
            this.tbpCopyProcess.ResumeLayout(false);
            this.tbpCopyProcess.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProcType;
        private System.Windows.Forms.Label lblProcType;
        private UI.Controls.MCCodeView.MCCodeView cdvProcType;
        private UI.Controls.MCListView.MCListView lisProcessList;
        private System.Windows.Forms.ColumnHeader colProcess;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.GroupBox grpProcStep;
        private System.Windows.Forms.Label lblIDRule;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtProcDesc;
        private System.Windows.Forms.Label lblActionDesc;
        private System.Windows.Forms.TextBox txtProcID;
        private System.Windows.Forms.Label lblProcID;
        private System.Windows.Forms.TabControl tabAssign;
        private System.Windows.Forms.TabPage tbpStep;
        private System.Windows.Forms.TabPage tbpAuth;
        private UI.Controls.MCCodeView.MCCodeView cdvIDRule;
        private System.Windows.Forms.Panel pnlStepRight;
        private System.Windows.Forms.Panel pnlStepMid;
        private System.Windows.Forms.Panel pnlStepLeft;
        private System.Windows.Forms.Button btnStepDown;
        private System.Windows.Forms.Button btnStepUp;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpActionOption;
        private System.Windows.Forms.CheckBox chkArbitrary;
        private System.Windows.Forms.CheckBox chkOptionalStep;
        private System.Windows.Forms.Label lblStepGroup;
        private System.Windows.Forms.Label lblAlarmID;
        private UI.Controls.MCCodeView.MCCodeView cdvNotifyAlarmID;
        private UI.Controls.MCListView.MCListView lisAssStepList;
        private System.Windows.Forms.ColumnHeader colAssStep;
        private System.Windows.Forms.ColumnHeader colAssStepGroup;
        private System.Windows.Forms.ColumnHeader colAssOptional;
        private System.Windows.Forms.ColumnHeader colAssArbitrary;
        private System.Windows.Forms.ColumnHeader colAssAlarmID;
        private System.Windows.Forms.ColumnHeader colAssStepDesc;
        private UI.Controls.MCListView.MCListView lisStepList;
        private System.Windows.Forms.ColumnHeader colStep;
        private System.Windows.Forms.ColumnHeader colStepDesc;
        private System.Windows.Forms.CheckBox chkInputApprover;
        private System.Windows.Forms.Panel pnlAuthMid;
        private System.Windows.Forms.Splitter splAuth;
        private System.Windows.Forms.Panel pnlAuthTop;
        private System.Windows.Forms.GroupBox grpAssignedStep;
        private System.Windows.Forms.GroupBox grpAuthorityOption;
        private System.Windows.Forms.CheckBox chkAllowSkip;
        private System.Windows.Forms.RadioButton rbtReadable;
        private System.Windows.Forms.RadioButton rbtWritable;
        private System.Windows.Forms.CheckBox chkAllowGoToAny;
        private System.Windows.Forms.CheckBox chkApprover;
        private System.Windows.Forms.CheckBox chkRecvNoti;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.Panel pnlUserMid;
        private UI.Controls.MCListView.MCListView lisRecvList;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.ColumnHeader colUserType;
        private System.Windows.Forms.Panel pnlRecMid;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Panel pnlUserRight;
        private UI.Controls.MCListView.MCListView lisPrvGrpList;
        private System.Windows.Forms.ColumnHeader colPriGroup;
        private System.Windows.Forms.ColumnHeader colPriDesc;
        private UI.Controls.MCListView.MCListView lisUserList;
        private System.Windows.Forms.ColumnHeader colSecGroup;
        private System.Windows.Forms.ColumnHeader colSecGrpDesc;
        private UI.Controls.MCListView.MCListView lisSecGrpList;
        private System.Windows.Forms.ColumnHeader colUserID;
        private System.Windows.Forms.ColumnHeader colUserDescription;
        private System.Windows.Forms.Panel pnlUserType;
        private System.Windows.Forms.RadioButton rbnPrvGroup;
        private System.Windows.Forms.RadioButton rbnSecGroup;
        private System.Windows.Forms.RadioButton rbnUser;
        private System.Windows.Forms.TextBox txtStepGroup;
        private UI.Controls.MCListView.MCListView lisAssStepList2;
        private System.Windows.Forms.ColumnHeader colAss2Step;
        private System.Windows.Forms.ColumnHeader colAss2Group;
        private System.Windows.Forms.ColumnHeader colAss2Optional;
        private System.Windows.Forms.ColumnHeader colAss2Arbitrary;
        private System.Windows.Forms.ColumnHeader colAss2AlarmID;
        private System.Windows.Forms.ColumnHeader colAss2Desc;
        private System.Windows.Forms.ColumnHeader colAssInputApprover;
        private System.Windows.Forms.ColumnHeader colAss2InputApprover;
        private System.Windows.Forms.ColumnHeader colUserAssOption;
        private System.Windows.Forms.Splitter splAssignStep;
        private System.Windows.Forms.Button btnModify2;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ColumnHeader colAssMinProcCount;
        private System.Windows.Forms.NumericUpDown numMinProcCount;
        private System.Windows.Forms.Label lblMinProcCount;
        private System.Windows.Forms.ColumnHeader colAss2MinProcCount;
        private System.Windows.Forms.TabPage tbpCopyProcess;
        private System.Windows.Forms.Button btnCopyProcess;
        private System.Windows.Forms.TextBox txtToProcess;
        private System.Windows.Forms.Label lblToProcess;
    }
}