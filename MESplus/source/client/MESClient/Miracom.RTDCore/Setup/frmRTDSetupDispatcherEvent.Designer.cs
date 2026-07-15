namespace Miracom.RTDCore
{
    partial class frmRTDSetupDispatcherEvent
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.lisService = new Miracom.UI.Controls.MCListView.MCListView();
            this.colDspID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDspDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpDsp = new System.Windows.Forms.GroupBox();
            this.cdvModule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMod = new System.Windows.Forms.Label();
            this.cdvService = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSeq = new System.Windows.Forms.Label();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.tabGeneral = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlGroupFill = new System.Windows.Forms.Panel();
            this.grpCheck = new System.Windows.Forms.GroupBox();
            this.cdvChkMember = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChkTable = new System.Windows.Forms.Label();
            this.txtChkSts = new System.Windows.Forms.TextBox();
            this.cdvTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChkSts = new System.Windows.Forms.Label();
            this.cboChkFlag = new System.Windows.Forms.ComboBox();
            this.lblChkFlag = new System.Windows.Forms.Label();
            this.lblChkMember = new System.Windows.Forms.Label();
            this.grpRuleType = new System.Windows.Forms.GroupBox();
            this.cdvDepSeq = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboCombi = new System.Windows.Forms.ComboBox();
            this.lblDepCombi = new System.Windows.Forms.Label();
            this.lblDepSeq = new System.Windows.Forms.Label();
            this.tbpAction = new System.Windows.Forms.TabPage();
            this.chkUnselectCapableOnly = new System.Windows.Forms.CheckBox();
            this.cdvActArray2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvActArray1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvActMember3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvActMember4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvActMember2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvActMember1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblActMember4 = new System.Windows.Forms.Label();
            this.lblActMember3 = new System.Windows.Forms.Label();
            this.lblActMember2 = new System.Windows.Forms.Label();
            this.lblActFlag = new System.Windows.Forms.Label();
            this.lblActMember1 = new System.Windows.Forms.Label();
            this.cboActFlag = new System.Windows.Forms.ComboBox();
            this.lblActArray2 = new System.Windows.Forms.Label();
            this.lblActArray1 = new System.Windows.Forms.Label();
            this.tbpCreate = new System.Windows.Forms.TabPage();
            this.grpCreateInfo = new System.Windows.Forms.GroupBox();
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
            this.grpDsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).BeginInit();
            this.tabGeneral.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGroupFill.SuspendLayout();
            this.grpCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChkMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTable)).BeginInit();
            this.grpRuleType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDepSeq)).BeginInit();
            this.tbpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActArray2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActArray1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActMember3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActMember4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActMember2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActMember1)).BeginInit();
            this.tbpCreate.SuspendLayout();
            this.grpCreateInfo.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.tabGeneral);
            this.pnlRight.Controls.Add(this.grpDsp);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisService);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
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
            // lisService
            // 
            this.lisService.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDspID,
            this.colDspDesc});
            this.lisService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisService.EnableSort = true;
            this.lisService.EnableSortIcon = true;
            this.lisService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisService.FullRowSelect = true;
            this.lisService.HideSelection = false;
            this.lisService.Location = new System.Drawing.Point(3, 0);
            this.lisService.MultiSelect = false;
            this.lisService.Name = "lisService";
            this.lisService.Size = new System.Drawing.Size(226, 513);
            this.lisService.TabIndex = 0;
            this.lisService.UseCompatibleStateImageBehavior = false;
            this.lisService.View = System.Windows.Forms.View.Details;
            this.lisService.SelectedIndexChanged += new System.EventHandler(this.lisService_SelectedIndexChanged);
            // 
            // colDspID
            // 
            this.colDspID.Text = "Service";
            this.colDspID.Width = 150;
            // 
            // colDspDesc
            // 
            this.colDspDesc.Text = "Seq";
            this.colDspDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDspDesc.Width = 80;
            // 
            // grpDsp
            // 
            this.grpDsp.Controls.Add(this.cdvModule);
            this.grpDsp.Controls.Add(this.lblMod);
            this.grpDsp.Controls.Add(this.cdvService);
            this.grpDsp.Controls.Add(this.lblSeq);
            this.grpDsp.Controls.Add(this.txtSeq);
            this.grpDsp.Controls.Add(this.lblDesc);
            this.grpDsp.Controls.Add(this.lblService);
            this.grpDsp.Controls.Add(this.txtDesc);
            this.grpDsp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDsp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDsp.Location = new System.Drawing.Point(0, 3);
            this.grpDsp.Name = "grpDsp";
            this.grpDsp.Size = new System.Drawing.Size(503, 97);
            this.grpDsp.TabIndex = 0;
            this.grpDsp.TabStop = false;
            // 
            // cdvModule
            // 
            this.cdvModule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvModule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvModule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvModule.BtnToolTipText = "";
            this.cdvModule.DescText = "";
            this.cdvModule.DisplaySubItemIndex = -1;
            this.cdvModule.DisplayText = "";
            this.cdvModule.Focusing = null;
            this.cdvModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvModule.Index = 0;
            this.cdvModule.IsViewBtnImage = false;
            this.cdvModule.Location = new System.Drawing.Point(120, 16);
            this.cdvModule.MaxLength = 20;
            this.cdvModule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvModule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvModule.Name = "cdvModule";
            this.cdvModule.ReadOnly = false;
            this.cdvModule.SearchSubItemIndex = 0;
            this.cdvModule.SelectedDescIndex = -1;
            this.cdvModule.SelectedSubItemIndex = -1;
            this.cdvModule.SelectionStart = 0;
            this.cdvModule.Size = new System.Drawing.Size(200, 20);
            this.cdvModule.SmallImageList = null;
            this.cdvModule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvModule.TabIndex = 1;
            this.cdvModule.TextBoxToolTipText = "";
            this.cdvModule.TextBoxWidth = 200;
            this.cdvModule.VisibleButton = true;
            this.cdvModule.VisibleColumnHeader = false;
            this.cdvModule.VisibleDescription = false;
            this.cdvModule.ButtonPress += new System.EventHandler(this.cdvModule_ButtonPress);
            // 
            // lblMod
            // 
            this.lblMod.AutoSize = true;
            this.lblMod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMod.Location = new System.Drawing.Point(15, 19);
            this.lblMod.Name = "lblMod";
            this.lblMod.Size = new System.Drawing.Size(73, 13);
            this.lblMod.TabIndex = 0;
            this.lblMod.Text = "Module Name";
            this.lblMod.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvService
            // 
            this.cdvService.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvService.BorderHotColor = System.Drawing.Color.Black;
            this.cdvService.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvService.BtnToolTipText = "";
            this.cdvService.DescText = "";
            this.cdvService.DisplaySubItemIndex = -1;
            this.cdvService.DisplayText = "";
            this.cdvService.Focusing = null;
            this.cdvService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvService.Index = 0;
            this.cdvService.IsViewBtnImage = false;
            this.cdvService.Location = new System.Drawing.Point(120, 41);
            this.cdvService.MaxLength = 100;
            this.cdvService.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvService.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvService.Name = "cdvService";
            this.cdvService.ReadOnly = false;
            this.cdvService.SearchSubItemIndex = 0;
            this.cdvService.SelectedDescIndex = -1;
            this.cdvService.SelectedSubItemIndex = -1;
            this.cdvService.SelectionStart = 0;
            this.cdvService.Size = new System.Drawing.Size(200, 20);
            this.cdvService.SmallImageList = null;
            this.cdvService.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvService.TabIndex = 3;
            this.cdvService.TextBoxToolTipText = "";
            this.cdvService.TextBoxWidth = 200;
            this.cdvService.VisibleButton = true;
            this.cdvService.VisibleColumnHeader = false;
            this.cdvService.VisibleDescription = false;
            this.cdvService.ButtonPress += new System.EventHandler(this.cdvService_ButtonPress);
            // 
            // lblSeq
            // 
            this.lblSeq.AutoSize = true;
            this.lblSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeq.Location = new System.Drawing.Point(351, 44);
            this.lblSeq.Name = "lblSeq";
            this.lblSeq.Size = new System.Drawing.Size(76, 13);
            this.lblSeq.TabIndex = 4;
            this.lblSeq.Text = "Service Seq";
            this.lblSeq.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtSeq
            // 
            this.txtSeq.Location = new System.Drawing.Point(442, 41);
            this.txtSeq.MaxLength = 6;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(49, 20);
            this.txtSeq.TabIndex = 5;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 67);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(15, 44);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(86, 13);
            this.lblService.TabIndex = 2;
            this.lblService.Text = "Service Name";
            this.lblService.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 65);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(371, 20);
            this.txtDesc.TabIndex = 7;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tbpGeneral);
            this.tabGeneral.Controls.Add(this.tbpAction);
            this.tabGeneral.Controls.Add(this.tbpCreate);
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.ItemSize = new System.Drawing.Size(60, 18);
            this.tabGeneral.Location = new System.Drawing.Point(0, 100);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.Size = new System.Drawing.Size(503, 413);
            this.tabGeneral.TabIndex = 1;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGroupFill);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(495, 387);
            this.tbpGeneral.TabIndex = 3;
            this.tbpGeneral.Text = "General";
            // 
            // pnlGroupFill
            // 
            this.pnlGroupFill.Controls.Add(this.grpCheck);
            this.pnlGroupFill.Controls.Add(this.grpRuleType);
            this.pnlGroupFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroupFill.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupFill.Name = "pnlGroupFill";
            this.pnlGroupFill.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlGroupFill.Size = new System.Drawing.Size(495, 387);
            this.pnlGroupFill.TabIndex = 0;
            // 
            // grpCheck
            // 
            this.grpCheck.Controls.Add(this.cdvChkMember);
            this.grpCheck.Controls.Add(this.lblChkTable);
            this.grpCheck.Controls.Add(this.txtChkSts);
            this.grpCheck.Controls.Add(this.cdvTable);
            this.grpCheck.Controls.Add(this.lblChkSts);
            this.grpCheck.Controls.Add(this.cboChkFlag);
            this.grpCheck.Controls.Add(this.lblChkFlag);
            this.grpCheck.Controls.Add(this.lblChkMember);
            this.grpCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCheck.Location = new System.Drawing.Point(3, 82);
            this.grpCheck.Name = "grpCheck";
            this.grpCheck.Size = new System.Drawing.Size(489, 302);
            this.grpCheck.TabIndex = 1;
            this.grpCheck.TabStop = false;
            this.grpCheck.Text = "Check Status";
            // 
            // cdvChkMember
            // 
            this.cdvChkMember.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChkMember.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChkMember.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChkMember.BtnToolTipText = "";
            this.cdvChkMember.DescText = "";
            this.cdvChkMember.DisplaySubItemIndex = -1;
            this.cdvChkMember.DisplayText = "";
            this.cdvChkMember.Focusing = null;
            this.cdvChkMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChkMember.Index = 0;
            this.cdvChkMember.IsViewBtnImage = false;
            this.cdvChkMember.Location = new System.Drawing.Point(172, 19);
            this.cdvChkMember.MaxLength = 20;
            this.cdvChkMember.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChkMember.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChkMember.Name = "cdvChkMember";
            this.cdvChkMember.ReadOnly = false;
            this.cdvChkMember.SearchSubItemIndex = 0;
            this.cdvChkMember.SelectedDescIndex = -1;
            this.cdvChkMember.SelectedSubItemIndex = -1;
            this.cdvChkMember.SelectionStart = 0;
            this.cdvChkMember.Size = new System.Drawing.Size(200, 20);
            this.cdvChkMember.SmallImageList = null;
            this.cdvChkMember.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChkMember.TabIndex = 1;
            this.cdvChkMember.TextBoxToolTipText = "";
            this.cdvChkMember.TextBoxWidth = 200;
            this.cdvChkMember.VisibleButton = true;
            this.cdvChkMember.VisibleColumnHeader = false;
            this.cdvChkMember.VisibleDescription = false;
            this.cdvChkMember.ButtonPress += new System.EventHandler(this.cdvChkMember_ButtonPress);
            // 
            // lblChkTable
            // 
            this.lblChkTable.AutoSize = true;
            this.lblChkTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChkTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChkTable.Location = new System.Drawing.Point(15, 95);
            this.lblChkTable.Name = "lblChkTable";
            this.lblChkTable.Size = new System.Drawing.Size(68, 13);
            this.lblChkTable.TabIndex = 6;
            this.lblChkTable.Text = "Check Table";
            // 
            // txtChkSts
            // 
            this.txtChkSts.Location = new System.Drawing.Point(172, 68);
            this.txtChkSts.MaxLength = 30;
            this.txtChkSts.Name = "txtChkSts";
            this.txtChkSts.Size = new System.Drawing.Size(200, 20);
            this.txtChkSts.TabIndex = 5;
            // 
            // cdvTable
            // 
            this.cdvTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTable.BtnToolTipText = "";
            this.cdvTable.DescText = "";
            this.cdvTable.DisplaySubItemIndex = -1;
            this.cdvTable.DisplayText = "";
            this.cdvTable.Focusing = null;
            this.cdvTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTable.Index = 0;
            this.cdvTable.IsViewBtnImage = false;
            this.cdvTable.Location = new System.Drawing.Point(172, 92);
            this.cdvTable.MaxLength = 20;
            this.cdvTable.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTable.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTable.Name = "cdvTable";
            this.cdvTable.ReadOnly = false;
            this.cdvTable.SearchSubItemIndex = 0;
            this.cdvTable.SelectedDescIndex = -1;
            this.cdvTable.SelectedSubItemIndex = -1;
            this.cdvTable.SelectionStart = 0;
            this.cdvTable.Size = new System.Drawing.Size(200, 20);
            this.cdvTable.SmallImageList = null;
            this.cdvTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTable.TabIndex = 7;
            this.cdvTable.TextBoxToolTipText = "";
            this.cdvTable.TextBoxWidth = 200;
            this.cdvTable.VisibleButton = true;
            this.cdvTable.VisibleColumnHeader = false;
            this.cdvTable.VisibleDescription = false;
            this.cdvTable.ButtonPress += new System.EventHandler(this.cdvTable_ButtonPress);
            // 
            // lblChkSts
            // 
            this.lblChkSts.AutoSize = true;
            this.lblChkSts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChkSts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChkSts.Location = new System.Drawing.Point(15, 71);
            this.lblChkSts.Name = "lblChkSts";
            this.lblChkSts.Size = new System.Drawing.Size(71, 13);
            this.lblChkSts.TabIndex = 4;
            this.lblChkSts.Text = "Check Status";
            // 
            // cboChkFlag
            // 
            this.cboChkFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChkFlag.Items.AddRange(new object[] {
            "= (Allow)",
            "! (Reject)",
            "N (Not Check)",
            "> (Greater than)",
            "< (Less than)",
            "T (Table)"});
            this.cboChkFlag.Location = new System.Drawing.Point(172, 43);
            this.cboChkFlag.MaxLength = 1;
            this.cboChkFlag.Name = "cboChkFlag";
            this.cboChkFlag.Size = new System.Drawing.Size(108, 21);
            this.cboChkFlag.TabIndex = 3;
            this.cboChkFlag.SelectedIndexChanged += new System.EventHandler(this.cboChkFlag_SelectedIndexChanged);
            // 
            // lblChkFlag
            // 
            this.lblChkFlag.AutoSize = true;
            this.lblChkFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChkFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChkFlag.Location = new System.Drawing.Point(15, 46);
            this.lblChkFlag.Name = "lblChkFlag";
            this.lblChkFlag.Size = new System.Drawing.Size(61, 13);
            this.lblChkFlag.TabIndex = 2;
            this.lblChkFlag.Text = "Check Flag";
            // 
            // lblChkMember
            // 
            this.lblChkMember.AutoSize = true;
            this.lblChkMember.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChkMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChkMember.Location = new System.Drawing.Point(15, 22);
            this.lblChkMember.Name = "lblChkMember";
            this.lblChkMember.Size = new System.Drawing.Size(79, 13);
            this.lblChkMember.TabIndex = 0;
            this.lblChkMember.Text = "Check Member";
            // 
            // grpRuleType
            // 
            this.grpRuleType.Controls.Add(this.cdvDepSeq);
            this.grpRuleType.Controls.Add(this.cboCombi);
            this.grpRuleType.Controls.Add(this.lblDepCombi);
            this.grpRuleType.Controls.Add(this.lblDepSeq);
            this.grpRuleType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRuleType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRuleType.Location = new System.Drawing.Point(3, 5);
            this.grpRuleType.Name = "grpRuleType";
            this.grpRuleType.Size = new System.Drawing.Size(489, 77);
            this.grpRuleType.TabIndex = 0;
            this.grpRuleType.TabStop = false;
            this.grpRuleType.Text = "Dependent";
            // 
            // cdvDepSeq
            // 
            this.cdvDepSeq.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDepSeq.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDepSeq.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDepSeq.BtnToolTipText = "";
            this.cdvDepSeq.DescText = "";
            this.cdvDepSeq.DisplaySubItemIndex = -1;
            this.cdvDepSeq.DisplayText = "";
            this.cdvDepSeq.Focusing = null;
            this.cdvDepSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDepSeq.Index = 0;
            this.cdvDepSeq.IsViewBtnImage = false;
            this.cdvDepSeq.Location = new System.Drawing.Point(172, 19);
            this.cdvDepSeq.MaxLength = 6;
            this.cdvDepSeq.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDepSeq.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDepSeq.Name = "cdvDepSeq";
            this.cdvDepSeq.ReadOnly = false;
            this.cdvDepSeq.SearchSubItemIndex = 0;
            this.cdvDepSeq.SelectedDescIndex = -1;
            this.cdvDepSeq.SelectedSubItemIndex = -1;
            this.cdvDepSeq.SelectionStart = 0;
            this.cdvDepSeq.Size = new System.Drawing.Size(200, 20);
            this.cdvDepSeq.SmallImageList = null;
            this.cdvDepSeq.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDepSeq.TabIndex = 1;
            this.cdvDepSeq.TextBoxToolTipText = "";
            this.cdvDepSeq.TextBoxWidth = 200;
            this.cdvDepSeq.VisibleButton = true;
            this.cdvDepSeq.VisibleColumnHeader = false;
            this.cdvDepSeq.VisibleDescription = false;
            this.cdvDepSeq.ButtonPress += new System.EventHandler(this.cdvDepSeq_ButtonPress);
            this.cdvDepSeq.TextBoxTextChanged += new System.EventHandler(this.cdvDepSeq_TextChanged);
            // 
            // cboCombi
            // 
            this.cboCombi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCombi.Items.AddRange(new object[] {
            "AND",
            "OR",
            ""});
            this.cboCombi.Location = new System.Drawing.Point(172, 48);
            this.cboCombi.Name = "cboCombi";
            this.cboCombi.Size = new System.Drawing.Size(100, 21);
            this.cboCombi.TabIndex = 3;
            // 
            // lblDepCombi
            // 
            this.lblDepCombi.AutoSize = true;
            this.lblDepCombi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDepCombi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepCombi.Location = new System.Drawing.Point(15, 51);
            this.lblDepCombi.Name = "lblDepCombi";
            this.lblDepCombi.Size = new System.Drawing.Size(121, 13);
            this.lblDepCombi.TabIndex = 2;
            this.lblDepCombi.Text = "Dependent Combination";
            // 
            // lblDepSeq
            // 
            this.lblDepSeq.AutoSize = true;
            this.lblDepSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDepSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepSeq.Location = new System.Drawing.Point(15, 22);
            this.lblDepSeq.Name = "lblDepSeq";
            this.lblDepSeq.Size = new System.Drawing.Size(82, 13);
            this.lblDepSeq.TabIndex = 0;
            this.lblDepSeq.Text = "Dependent Seq";
            // 
            // tbpAction
            // 
            this.tbpAction.Controls.Add(this.chkUnselectCapableOnly);
            this.tbpAction.Controls.Add(this.cdvActArray2);
            this.tbpAction.Controls.Add(this.cdvActArray1);
            this.tbpAction.Controls.Add(this.cdvActMember3);
            this.tbpAction.Controls.Add(this.cdvActMember4);
            this.tbpAction.Controls.Add(this.cdvActMember2);
            this.tbpAction.Controls.Add(this.cdvActMember1);
            this.tbpAction.Controls.Add(this.lblActMember4);
            this.tbpAction.Controls.Add(this.lblActMember3);
            this.tbpAction.Controls.Add(this.lblActMember2);
            this.tbpAction.Controls.Add(this.lblActFlag);
            this.tbpAction.Controls.Add(this.lblActMember1);
            this.tbpAction.Controls.Add(this.cboActFlag);
            this.tbpAction.Controls.Add(this.lblActArray2);
            this.tbpAction.Controls.Add(this.lblActArray1);
            this.tbpAction.Location = new System.Drawing.Point(4, 22);
            this.tbpAction.Name = "tbpAction";
            this.tbpAction.Size = new System.Drawing.Size(495, 387);
            this.tbpAction.TabIndex = 5;
            this.tbpAction.Text = "Action";
            // 
            // chkUnselectCapableOnly
            // 
            this.chkUnselectCapableOnly.AutoSize = true;
            this.chkUnselectCapableOnly.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUnselectCapableOnly.Location = new System.Drawing.Point(18, 202);
            this.chkUnselectCapableOnly.Name = "chkUnselectCapableOnly";
            this.chkUnselectCapableOnly.Size = new System.Drawing.Size(140, 18);
            this.chkUnselectCapableOnly.TabIndex = 14;
            this.chkUnselectCapableOnly.Text = "Unselect-Capable Only";
            // 
            // cdvActArray2
            // 
            this.cdvActArray2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActArray2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActArray2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActArray2.BtnToolTipText = "";
            this.cdvActArray2.DescText = "";
            this.cdvActArray2.DisplaySubItemIndex = -1;
            this.cdvActArray2.DisplayText = "";
            this.cdvActArray2.Focusing = null;
            this.cdvActArray2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActArray2.Index = 0;
            this.cdvActArray2.IsViewBtnImage = false;
            this.cdvActArray2.Location = new System.Drawing.Point(172, 46);
            this.cdvActArray2.MaxLength = 20;
            this.cdvActArray2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActArray2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActArray2.Name = "cdvActArray2";
            this.cdvActArray2.ReadOnly = false;
            this.cdvActArray2.SearchSubItemIndex = 0;
            this.cdvActArray2.SelectedDescIndex = -1;
            this.cdvActArray2.SelectedSubItemIndex = -1;
            this.cdvActArray2.SelectionStart = 0;
            this.cdvActArray2.Size = new System.Drawing.Size(200, 20);
            this.cdvActArray2.SmallImageList = null;
            this.cdvActArray2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActArray2.TabIndex = 3;
            this.cdvActArray2.TextBoxToolTipText = "";
            this.cdvActArray2.TextBoxWidth = 200;
            this.cdvActArray2.VisibleButton = true;
            this.cdvActArray2.VisibleColumnHeader = false;
            this.cdvActArray2.VisibleDescription = false;
            this.cdvActArray2.ButtonPress += new System.EventHandler(this.cdvActArray2_ButtonPress);
            this.cdvActArray2.TextBoxTextChanged += new System.EventHandler(this.cdvActArray2_TextBoxTextChanged);
            // 
            // cdvActArray1
            // 
            this.cdvActArray1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActArray1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActArray1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActArray1.BtnToolTipText = "";
            this.cdvActArray1.DescText = "";
            this.cdvActArray1.DisplaySubItemIndex = -1;
            this.cdvActArray1.DisplayText = "";
            this.cdvActArray1.Focusing = null;
            this.cdvActArray1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActArray1.Index = 0;
            this.cdvActArray1.IsViewBtnImage = false;
            this.cdvActArray1.Location = new System.Drawing.Point(172, 22);
            this.cdvActArray1.MaxLength = 20;
            this.cdvActArray1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActArray1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActArray1.Name = "cdvActArray1";
            this.cdvActArray1.ReadOnly = false;
            this.cdvActArray1.SearchSubItemIndex = 0;
            this.cdvActArray1.SelectedDescIndex = -1;
            this.cdvActArray1.SelectedSubItemIndex = -1;
            this.cdvActArray1.SelectionStart = 0;
            this.cdvActArray1.Size = new System.Drawing.Size(200, 20);
            this.cdvActArray1.SmallImageList = null;
            this.cdvActArray1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActArray1.TabIndex = 1;
            this.cdvActArray1.TextBoxToolTipText = "";
            this.cdvActArray1.TextBoxWidth = 200;
            this.cdvActArray1.VisibleButton = true;
            this.cdvActArray1.VisibleColumnHeader = false;
            this.cdvActArray1.VisibleDescription = false;
            this.cdvActArray1.ButtonPress += new System.EventHandler(this.cdvActArray1_ButtonPress);
            this.cdvActArray1.TextBoxTextChanged += new System.EventHandler(this.cdvActArray1_TextBoxTextChanged);
            // 
            // cdvActMember3
            // 
            this.cdvActMember3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActMember3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActMember3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActMember3.BtnToolTipText = "";
            this.cdvActMember3.DescText = "";
            this.cdvActMember3.DisplaySubItemIndex = -1;
            this.cdvActMember3.DisplayText = "";
            this.cdvActMember3.Focusing = null;
            this.cdvActMember3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActMember3.Index = 0;
            this.cdvActMember3.IsViewBtnImage = false;
            this.cdvActMember3.Location = new System.Drawing.Point(172, 143);
            this.cdvActMember3.MaxLength = 20;
            this.cdvActMember3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActMember3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActMember3.Name = "cdvActMember3";
            this.cdvActMember3.ReadOnly = false;
            this.cdvActMember3.SearchSubItemIndex = 0;
            this.cdvActMember3.SelectedDescIndex = -1;
            this.cdvActMember3.SelectedSubItemIndex = -1;
            this.cdvActMember3.SelectionStart = 0;
            this.cdvActMember3.Size = new System.Drawing.Size(200, 20);
            this.cdvActMember3.SmallImageList = null;
            this.cdvActMember3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActMember3.TabIndex = 11;
            this.cdvActMember3.TextBoxToolTipText = "";
            this.cdvActMember3.TextBoxWidth = 200;
            this.cdvActMember3.VisibleButton = true;
            this.cdvActMember3.VisibleColumnHeader = false;
            this.cdvActMember3.VisibleDescription = false;
            this.cdvActMember3.ButtonPress += new System.EventHandler(this.cdvActMember1_ButtonPress);
            // 
            // cdvActMember4
            // 
            this.cdvActMember4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActMember4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActMember4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActMember4.BtnToolTipText = "";
            this.cdvActMember4.DescText = "";
            this.cdvActMember4.DisplaySubItemIndex = -1;
            this.cdvActMember4.DisplayText = "";
            this.cdvActMember4.Focusing = null;
            this.cdvActMember4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActMember4.Index = 0;
            this.cdvActMember4.IsViewBtnImage = false;
            this.cdvActMember4.Location = new System.Drawing.Point(172, 167);
            this.cdvActMember4.MaxLength = 20;
            this.cdvActMember4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActMember4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActMember4.Name = "cdvActMember4";
            this.cdvActMember4.ReadOnly = false;
            this.cdvActMember4.SearchSubItemIndex = 0;
            this.cdvActMember4.SelectedDescIndex = -1;
            this.cdvActMember4.SelectedSubItemIndex = -1;
            this.cdvActMember4.SelectionStart = 0;
            this.cdvActMember4.Size = new System.Drawing.Size(200, 20);
            this.cdvActMember4.SmallImageList = null;
            this.cdvActMember4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActMember4.TabIndex = 13;
            this.cdvActMember4.TextBoxToolTipText = "";
            this.cdvActMember4.TextBoxWidth = 200;
            this.cdvActMember4.VisibleButton = true;
            this.cdvActMember4.VisibleColumnHeader = false;
            this.cdvActMember4.VisibleDescription = false;
            this.cdvActMember4.ButtonPress += new System.EventHandler(this.cdvActMember1_ButtonPress);
            // 
            // cdvActMember2
            // 
            this.cdvActMember2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActMember2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActMember2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActMember2.BtnToolTipText = "";
            this.cdvActMember2.DescText = "";
            this.cdvActMember2.DisplaySubItemIndex = -1;
            this.cdvActMember2.DisplayText = "";
            this.cdvActMember2.Focusing = null;
            this.cdvActMember2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActMember2.Index = 0;
            this.cdvActMember2.IsViewBtnImage = false;
            this.cdvActMember2.Location = new System.Drawing.Point(172, 119);
            this.cdvActMember2.MaxLength = 20;
            this.cdvActMember2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActMember2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActMember2.Name = "cdvActMember2";
            this.cdvActMember2.ReadOnly = false;
            this.cdvActMember2.SearchSubItemIndex = 0;
            this.cdvActMember2.SelectedDescIndex = -1;
            this.cdvActMember2.SelectedSubItemIndex = -1;
            this.cdvActMember2.SelectionStart = 0;
            this.cdvActMember2.Size = new System.Drawing.Size(200, 20);
            this.cdvActMember2.SmallImageList = null;
            this.cdvActMember2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActMember2.TabIndex = 9;
            this.cdvActMember2.TextBoxToolTipText = "";
            this.cdvActMember2.TextBoxWidth = 200;
            this.cdvActMember2.VisibleButton = true;
            this.cdvActMember2.VisibleColumnHeader = false;
            this.cdvActMember2.VisibleDescription = false;
            this.cdvActMember2.ButtonPress += new System.EventHandler(this.cdvActMember1_ButtonPress);
            // 
            // cdvActMember1
            // 
            this.cdvActMember1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActMember1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActMember1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActMember1.BtnToolTipText = "";
            this.cdvActMember1.DescText = "";
            this.cdvActMember1.DisplaySubItemIndex = -1;
            this.cdvActMember1.DisplayText = "";
            this.cdvActMember1.Focusing = null;
            this.cdvActMember1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActMember1.Index = 0;
            this.cdvActMember1.IsViewBtnImage = false;
            this.cdvActMember1.Location = new System.Drawing.Point(172, 95);
            this.cdvActMember1.MaxLength = 20;
            this.cdvActMember1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActMember1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActMember1.Name = "cdvActMember1";
            this.cdvActMember1.ReadOnly = false;
            this.cdvActMember1.SearchSubItemIndex = 0;
            this.cdvActMember1.SelectedDescIndex = -1;
            this.cdvActMember1.SelectedSubItemIndex = -1;
            this.cdvActMember1.SelectionStart = 0;
            this.cdvActMember1.Size = new System.Drawing.Size(200, 20);
            this.cdvActMember1.SmallImageList = null;
            this.cdvActMember1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActMember1.TabIndex = 7;
            this.cdvActMember1.TextBoxToolTipText = "";
            this.cdvActMember1.TextBoxWidth = 200;
            this.cdvActMember1.VisibleButton = true;
            this.cdvActMember1.VisibleColumnHeader = false;
            this.cdvActMember1.VisibleDescription = false;
            this.cdvActMember1.ButtonPress += new System.EventHandler(this.cdvActMember1_ButtonPress);
            // 
            // lblActMember4
            // 
            this.lblActMember4.AutoSize = true;
            this.lblActMember4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActMember4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActMember4.Location = new System.Drawing.Point(18, 170);
            this.lblActMember4.Name = "lblActMember4";
            this.lblActMember4.Size = new System.Drawing.Size(87, 13);
            this.lblActMember4.TabIndex = 12;
            this.lblActMember4.Text = "Action Member 4";
            // 
            // lblActMember3
            // 
            this.lblActMember3.AutoSize = true;
            this.lblActMember3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActMember3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActMember3.Location = new System.Drawing.Point(18, 146);
            this.lblActMember3.Name = "lblActMember3";
            this.lblActMember3.Size = new System.Drawing.Size(87, 13);
            this.lblActMember3.TabIndex = 10;
            this.lblActMember3.Text = "Action Member 3";
            // 
            // lblActMember2
            // 
            this.lblActMember2.AutoSize = true;
            this.lblActMember2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActMember2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActMember2.Location = new System.Drawing.Point(18, 122);
            this.lblActMember2.Name = "lblActMember2";
            this.lblActMember2.Size = new System.Drawing.Size(87, 13);
            this.lblActMember2.TabIndex = 8;
            this.lblActMember2.Text = "Action Member 2";
            // 
            // lblActFlag
            // 
            this.lblActFlag.AutoSize = true;
            this.lblActFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActFlag.Location = new System.Drawing.Point(18, 73);
            this.lblActFlag.Name = "lblActFlag";
            this.lblActFlag.Size = new System.Drawing.Size(60, 13);
            this.lblActFlag.TabIndex = 4;
            this.lblActFlag.Text = "Action Flag";
            // 
            // lblActMember1
            // 
            this.lblActMember1.AutoSize = true;
            this.lblActMember1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActMember1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActMember1.Location = new System.Drawing.Point(18, 98);
            this.lblActMember1.Name = "lblActMember1";
            this.lblActMember1.Size = new System.Drawing.Size(87, 13);
            this.lblActMember1.TabIndex = 6;
            this.lblActMember1.Text = "Action Member 1";
            // 
            // cboActFlag
            // 
            this.cboActFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActFlag.Items.AddRange(new object[] {
            "Lot",
            "Resource",
            "Resource Group",
            "Material",
            "Flow",
            "Operation",
            "Batch",
            "Material-Flow-Operation",
            "Flow-Operation",
            "Material-Operation",
            "Dispatcher",
            "Dispatcher Rule",
            "All",
            "Child Lots",
            "Zero Qty Lot"});
            this.cboActFlag.Location = new System.Drawing.Point(172, 70);
            this.cboActFlag.Name = "cboActFlag";
            this.cboActFlag.Size = new System.Drawing.Size(200, 21);
            this.cboActFlag.TabIndex = 5;
            this.cboActFlag.SelectedIndexChanged += new System.EventHandler(this.cboActFlag_SelectedIndexChanged);
            // 
            // lblActArray2
            // 
            this.lblActArray2.AutoSize = true;
            this.lblActArray2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActArray2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActArray2.Location = new System.Drawing.Point(18, 49);
            this.lblActArray2.Name = "lblActArray2";
            this.lblActArray2.Size = new System.Drawing.Size(97, 13);
            this.lblActArray2.TabIndex = 2;
            this.lblActArray2.Text = "Action List Depth 2";
            // 
            // lblActArray1
            // 
            this.lblActArray1.AutoSize = true;
            this.lblActArray1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActArray1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActArray1.Location = new System.Drawing.Point(18, 25);
            this.lblActArray1.Name = "lblActArray1";
            this.lblActArray1.Size = new System.Drawing.Size(97, 13);
            this.lblActArray1.TabIndex = 0;
            this.lblActArray1.Text = "Action List Depth 1";
            // 
            // tbpCreate
            // 
            this.tbpCreate.Controls.Add(this.grpCreateInfo);
            this.tbpCreate.Location = new System.Drawing.Point(4, 22);
            this.tbpCreate.Name = "tbpCreate";
            this.tbpCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCreate.Size = new System.Drawing.Size(495, 387);
            this.tbpCreate.TabIndex = 4;
            this.tbpCreate.Text = "Create Info";
            // 
            // grpCreateInfo
            // 
            this.grpCreateInfo.Controls.Add(this.txtUpdateTime);
            this.grpCreateInfo.Controls.Add(this.txtCreateTime);
            this.grpCreateInfo.Controls.Add(this.txtUpdateUser);
            this.grpCreateInfo.Controls.Add(this.lblUpdate);
            this.grpCreateInfo.Controls.Add(this.txtCreateUser);
            this.grpCreateInfo.Controls.Add(this.lblCreate);
            this.grpCreateInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCreateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateInfo.Location = new System.Drawing.Point(3, 3);
            this.grpCreateInfo.Name = "grpCreateInfo";
            this.grpCreateInfo.Size = new System.Drawing.Size(489, 70);
            this.grpCreateInfo.TabIndex = 3;
            this.grpCreateInfo.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(306, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(306, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(126, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(10, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(126, 16);
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
            this.lblCreate.Location = new System.Drawing.Point(10, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRTDSetupDispatcherEvent
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRTDSetupDispatcherEvent";
            this.Text = "Dispatch Event Configuration Setup";
            this.Load += new System.EventHandler(this.frmRTDSetupDispatcherEvent_Load);
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
            this.grpDsp.ResumeLayout(false);
            this.grpDsp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).EndInit();
            this.tabGeneral.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlGroupFill.ResumeLayout(false);
            this.grpCheck.ResumeLayout(false);
            this.grpCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChkMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTable)).EndInit();
            this.grpRuleType.ResumeLayout(false);
            this.grpRuleType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDepSeq)).EndInit();
            this.tbpAction.ResumeLayout(false);
            this.tbpAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActArray2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActArray1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActMember3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActMember4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActMember2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActMember1)).EndInit();
            this.tbpCreate.ResumeLayout(false);
            this.grpCreateInfo.ResumeLayout(false);
            this.grpCreateInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.UI.Controls.MCListView.MCListView lisService;
        private System.Windows.Forms.ColumnHeader colDspID;
        private System.Windows.Forms.ColumnHeader colDspDesc;
        private System.Windows.Forms.GroupBox grpDsp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TabControl tabGeneral;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Panel pnlGroupFill;
        private System.Windows.Forms.GroupBox grpRuleType;
        private System.Windows.Forms.Label lblDepSeq;
        private System.Windows.Forms.TabPage tbpCreate;
        private System.Windows.Forms.GroupBox grpCreateInfo;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label lblDepCombi;
        private System.Windows.Forms.ComboBox cboCombi;
        private System.Windows.Forms.GroupBox grpCheck;
        private System.Windows.Forms.Label lblChkTable;
        private System.Windows.Forms.TextBox txtChkSts;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTable;
        private System.Windows.Forms.Label lblChkSts;
        private System.Windows.Forms.ComboBox cboChkFlag;
        private System.Windows.Forms.Label lblChkFlag;
        private System.Windows.Forms.Label lblChkMember;
        private System.Windows.Forms.TabPage tbpAction;
        private System.Windows.Forms.ComboBox cboActFlag;
        private System.Windows.Forms.Label lblActArray2;
        private System.Windows.Forms.Label lblActArray1;
        private System.Windows.Forms.Label lblActMember1;
        private System.Windows.Forms.Label lblActFlag;
        private System.Windows.Forms.Label lblSeq;
        private System.Windows.Forms.TextBox txtSeq;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDepSeq;
        private System.Windows.Forms.Label lblActMember4;
        private System.Windows.Forms.Label lblActMember3;
        private System.Windows.Forms.Label lblActMember2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvService;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChkMember;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvActMember3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvActMember4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvActMember2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvActMember1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvModule;
        private System.Windows.Forms.Label lblMod;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvActArray2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvActArray1;
        private System.Windows.Forms.CheckBox chkUnselectCapableOnly;
    }
}
