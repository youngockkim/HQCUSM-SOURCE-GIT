namespace Miracom.BASCore
{
    partial class frmBASSetupChecklistRelation
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
            this.tabRelation = new System.Windows.Forms.TabControl();
            this.tbpMFO = new System.Windows.Forms.TabPage();
            this.udcMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.tbpResource = new System.Windows.Forms.TabPage();
            this.udcResourceTreeList = new Miracom.MESCore.Controls.udcResourceTreeList();
            this.pnlCheckFill = new System.Windows.Forms.Panel();
            this.lisEventChecklist = new Miracom.UI.Controls.MCListView.MCListView();
            this.colChecklistID2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRequireCompleteFlag2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBAPoint2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApplyFromTo2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisTranChecklist = new Miracom.UI.Controls.MCListView.MCListView();
            this.colChecklistID1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInheritChildLotFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRequireCompleteFlag1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBAPoint1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApplyFromTo1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlCheckBottom = new System.Windows.Forms.Panel();
            this.pnlCheckBottomFill = new System.Windows.Forms.Panel();
            this.tabRelationInfo = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.pnlDetailInfo = new System.Windows.Forms.Panel();
            this.grpLotBaseRelation = new System.Windows.Forms.GroupBox();
            this.cboTransaction = new System.Windows.Forms.ComboBox();
            this.rdoTranBefore = new System.Windows.Forms.RadioButton();
            this.rdoTranAfter = new System.Windows.Forms.RadioButton();
            this.lblTransaction = new System.Windows.Forms.Label();
            this.chkInheritChild = new System.Windows.Forms.CheckBox();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.grpResourceBaseRelation = new System.Windows.Forms.GroupBox();
            this.rdoEventBefore = new System.Windows.Forms.RadioButton();
            this.cdvEvent = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rdoEventAfter = new System.Windows.Forms.RadioButton();
            this.lblEvent = new System.Windows.Forms.Label();
            this.pnlGeneralInfo = new System.Windows.Forms.Panel();
            this.lblApplyEndTime = new System.Windows.Forms.Label();
            this.lblApplyTime = new System.Windows.Forms.Label();
            this.cdvCompleteUser = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.dtpToTime = new System.Windows.Forms.DateTimePicker();
            this.lblCompleteUser = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.chkRequire = new System.Windows.Forms.CheckBox();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkFromTime = new System.Windows.Forms.CheckBox();
            this.chkToTime = new System.Windows.Forms.CheckBox();
            this.tabKeyValuePrompt = new System.Windows.Forms.TabPage();
            this.pnlCmfItemDef = new System.Windows.Forms.Panel();
            this.cdvChecklistKeyPrompt = new Miracom.BASCore.Controls.udcChecklistKeyPrompt();
            this.pnlCheckBottomTop = new System.Windows.Forms.Panel();
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.cdvChecklistID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblChecklistID = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabRelation.SuspendLayout();
            this.tbpMFO.SuspendLayout();
            this.tbpResource.SuspendLayout();
            this.pnlCheckFill.SuspendLayout();
            this.pnlCheckBottom.SuspendLayout();
            this.pnlCheckBottomFill.SuspendLayout();
            this.tabRelationInfo.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.pnlDetailInfo.SuspendLayout();
            this.grpLotBaseRelation.SuspendLayout();
            this.grpResourceBaseRelation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEvent)).BeginInit();
            this.pnlGeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCompleteUser)).BeginInit();
            this.tabKeyValuePrompt.SuspendLayout();
            this.pnlCmfItemDef.SuspendLayout();
            this.pnlCheckBottomTop.SuspendLayout();
            this.grbTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistID)).BeginInit();
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
            // splMain
            // 
            this.splMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlCheckFill);
            this.pnlRight.Controls.Add(this.pnlCheckBottom);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tabRelation);
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
            // tabRelation
            // 
            this.tabRelation.Controls.Add(this.tbpMFO);
            this.tabRelation.Controls.Add(this.tbpResource);
            this.tabRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRelation.Location = new System.Drawing.Point(0, 0);
            this.tabRelation.Name = "tabRelation";
            this.tabRelation.SelectedIndex = 0;
            this.tabRelation.Size = new System.Drawing.Size(232, 506);
            this.tabRelation.TabIndex = 0;
            this.tabRelation.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabRelation_Selected);
            // 
            // tbpMFO
            // 
            this.tbpMFO.Controls.Add(this.udcMFO);
            this.tbpMFO.Location = new System.Drawing.Point(4, 22);
            this.tbpMFO.Name = "tbpMFO";
            this.tbpMFO.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMFO.Size = new System.Drawing.Size(224, 480);
            this.tbpMFO.TabIndex = 0;
            this.tbpMFO.Text = "MFO";
            // 
            // udcMFO
            // 
            this.udcMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMFO.IncludeFlowSeqNum = false;
            this.udcMFO.ListCond_ExtFactory = "";
            this.udcMFO.ListCond_Step = '1';
            this.udcMFO.Location = new System.Drawing.Point(3, 3);
            this.udcMFO.MaterialType = "";
            this.udcMFO.Name = "udcMFO";
            this.udcMFO.Size = new System.Drawing.Size(218, 474);
            this.udcMFO.TabIndex = 0;
            this.udcMFO.VisibleLevel1MFO = true;
            this.udcMFO.VisibleLevel2FO = true;
            this.udcMFO.VisibleLevel3O = true;
            this.udcMFO.VisibleLevel4MO = true;
            this.udcMFO.VisibleLevel5MF = false;
            this.udcMFO.VisibleLevel6M = false;
            this.udcMFO.VisibleLevel7F = false;
            this.udcMFO.VisibleLevel8Factory = true;
            this.udcMFO.VisibleMaterialIncludeDeleteCheck = false;
            this.udcMFO.VisibleMaterialType = false;
            this.udcMFO.VisibleOnlySetData = true;
            this.udcMFO.VisibleViewType = true;
            this.udcMFO.AfterGetTree += new System.EventHandler(this.udcMFO_AfterGetTree);
            this.udcMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcMFO_LevelItemSelect);
            this.udcMFO.GetOnlySetData += new System.EventHandler(this.udcMFO_GetOnlySetData);
            this.udcMFO.SetDataSelectedIndexChanged += new System.EventHandler(this.udcMFO_SetDataSelectedIndexChanged);
            // 
            // tbpResource
            // 
            this.tbpResource.Controls.Add(this.udcResourceTreeList);
            this.tbpResource.Location = new System.Drawing.Point(4, 22);
            this.tbpResource.Name = "tbpResource";
            this.tbpResource.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResource.Size = new System.Drawing.Size(224, 480);
            this.tbpResource.TabIndex = 1;
            this.tbpResource.Text = "Resource";
            // 
            // udcResourceTreeList
            // 
            this.udcResourceTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcResourceTreeList.ListCond_ExtFactory = "";
            this.udcResourceTreeList.ListCond_Step = '1';
            this.udcResourceTreeList.Location = new System.Drawing.Point(3, 3);
            this.udcResourceTreeList.Name = "udcResourceTreeList";
            this.udcResourceTreeList.Size = new System.Drawing.Size(218, 474);
            this.udcResourceTreeList.TabIndex = 0;
            this.udcResourceTreeList.VisibleLevel1R = true;
            this.udcResourceTreeList.VisibleLevel2G = true;
            this.udcResourceTreeList.VisibleLevel3T = true;
            this.udcResourceTreeList.VisibleOnlySetData = true;
            this.udcResourceTreeList.VisibleResourceIncludeDeleteCheck = true;
            this.udcResourceTreeList.AfterGetTree += new System.EventHandler(this.udcResourceTreeList_AfterGetTree);
            this.udcResourceTreeList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcResourceTreeList_AfterSelect);
            this.udcResourceTreeList.GetOnlySetData += new System.EventHandler(this.udcResourceTreeList_GetOnlySetData);
            this.udcResourceTreeList.SetDataSelectedIndexChanged += new System.EventHandler(this.udcResourceTreeList_SetDataSelectedIndexChanged);
            // 
            // pnlCheckFill
            // 
            this.pnlCheckFill.Controls.Add(this.lisEventChecklist);
            this.pnlCheckFill.Controls.Add(this.lisTranChecklist);
            this.pnlCheckFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCheckFill.Location = new System.Drawing.Point(0, 0);
            this.pnlCheckFill.Name = "pnlCheckFill";
            this.pnlCheckFill.Size = new System.Drawing.Size(506, 144);
            this.pnlCheckFill.TabIndex = 0;
            // 
            // lisEventChecklist
            // 
            this.lisEventChecklist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChecklistID2,
            this.colRequireCompleteFlag2,
            this.colEventID,
            this.colBAPoint2,
            this.colApplyFromTo2});
            this.lisEventChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisEventChecklist.EnableSort = true;
            this.lisEventChecklist.EnableSortIcon = true;
            this.lisEventChecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisEventChecklist.FullRowSelect = true;
            this.lisEventChecklist.Location = new System.Drawing.Point(0, 0);
            this.lisEventChecklist.MultiSelect = false;
            this.lisEventChecklist.Name = "lisEventChecklist";
            this.lisEventChecklist.Size = new System.Drawing.Size(506, 144);
            this.lisEventChecklist.TabIndex = 0;
            this.lisEventChecklist.UseCompatibleStateImageBehavior = false;
            this.lisEventChecklist.View = System.Windows.Forms.View.Details;
            this.lisEventChecklist.SelectedIndexChanged += new System.EventHandler(this.lisEventChecklist_SelectedIndexChanged);
            // 
            // colChecklistID2
            // 
            this.colChecklistID2.Text = "Checklist ID";
            this.colChecklistID2.Width = 110;
            // 
            // colRequireCompleteFlag2
            // 
            this.colRequireCompleteFlag2.Text = "Require Complete Flag";
            this.colRequireCompleteFlag2.Width = 50;
            // 
            // colEventID
            // 
            this.colEventID.Text = "Event ID";
            this.colEventID.Width = 70;
            // 
            // colBAPoint2
            // 
            this.colBAPoint2.Text = "BAPoint";
            // 
            // colApplyFromTo2
            // 
            this.colApplyFromTo2.Text = "Apply From ~ To";
            this.colApplyFromTo2.Width = 200;
            // 
            // lisTranChecklist
            // 
            this.lisTranChecklist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChecklistID1,
            this.colLotID,
            this.colInheritChildLotFlag,
            this.colRequireCompleteFlag1,
            this.colTranCode,
            this.colBAPoint1,
            this.colApplyFromTo1});
            this.lisTranChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisTranChecklist.EnableSort = true;
            this.lisTranChecklist.EnableSortIcon = true;
            this.lisTranChecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisTranChecklist.FullRowSelect = true;
            this.lisTranChecklist.Location = new System.Drawing.Point(0, 0);
            this.lisTranChecklist.MultiSelect = false;
            this.lisTranChecklist.Name = "lisTranChecklist";
            this.lisTranChecklist.Size = new System.Drawing.Size(506, 144);
            this.lisTranChecklist.TabIndex = 3;
            this.lisTranChecklist.UseCompatibleStateImageBehavior = false;
            this.lisTranChecklist.View = System.Windows.Forms.View.Details;
            this.lisTranChecklist.SelectedIndexChanged += new System.EventHandler(this.lisTranChecklist_SelectedIndexChanged);
            // 
            // colChecklistID1
            // 
            this.colChecklistID1.Text = "Checklist ID";
            this.colChecklistID1.Width = 110;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 100;
            // 
            // colInheritChildLotFlag
            // 
            this.colInheritChildLotFlag.Text = "Inherit Child Lot Flag";
            this.colInheritChildLotFlag.Width = 50;
            // 
            // colRequireCompleteFlag1
            // 
            this.colRequireCompleteFlag1.Text = "Require Complete Flag";
            this.colRequireCompleteFlag1.Width = 50;
            // 
            // colTranCode
            // 
            this.colTranCode.Text = "Tran Code";
            this.colTranCode.Width = 70;
            // 
            // colBAPoint1
            // 
            this.colBAPoint1.Text = "BAPoint";
            // 
            // colApplyFromTo1
            // 
            this.colApplyFromTo1.Text = "Apply From ~ To";
            this.colApplyFromTo1.Width = 150;
            // 
            // pnlCheckBottom
            // 
            this.pnlCheckBottom.Controls.Add(this.pnlCheckBottomFill);
            this.pnlCheckBottom.Controls.Add(this.pnlCheckBottomTop);
            this.pnlCheckBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCheckBottom.Location = new System.Drawing.Point(0, 144);
            this.pnlCheckBottom.Name = "pnlCheckBottom";
            this.pnlCheckBottom.Size = new System.Drawing.Size(506, 362);
            this.pnlCheckBottom.TabIndex = 1;
            // 
            // pnlCheckBottomFill
            // 
            this.pnlCheckBottomFill.Controls.Add(this.tabRelationInfo);
            this.pnlCheckBottomFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCheckBottomFill.Location = new System.Drawing.Point(0, 65);
            this.pnlCheckBottomFill.Name = "pnlCheckBottomFill";
            this.pnlCheckBottomFill.Size = new System.Drawing.Size(506, 297);
            this.pnlCheckBottomFill.TabIndex = 1;
            // 
            // tabRelationInfo
            // 
            this.tabRelationInfo.Controls.Add(this.tabGeneral);
            this.tabRelationInfo.Controls.Add(this.tabKeyValuePrompt);
            this.tabRelationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRelationInfo.Location = new System.Drawing.Point(0, 0);
            this.tabRelationInfo.Name = "tabRelationInfo";
            this.tabRelationInfo.SelectedIndex = 0;
            this.tabRelationInfo.Size = new System.Drawing.Size(506, 297);
            this.tabRelationInfo.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.pnlDetailInfo);
            this.tabGeneral.Controls.Add(this.pnlGeneralInfo);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(498, 271);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // pnlDetailInfo
            // 
            this.pnlDetailInfo.Controls.Add(this.grpLotBaseRelation);
            this.pnlDetailInfo.Controls.Add(this.grpResourceBaseRelation);
            this.pnlDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailInfo.Location = new System.Drawing.Point(3, 92);
            this.pnlDetailInfo.Name = "pnlDetailInfo";
            this.pnlDetailInfo.Size = new System.Drawing.Size(492, 176);
            this.pnlDetailInfo.TabIndex = 1;
            // 
            // grpLotBaseRelation
            // 
            this.grpLotBaseRelation.Controls.Add(this.cboTransaction);
            this.grpLotBaseRelation.Controls.Add(this.rdoTranBefore);
            this.grpLotBaseRelation.Controls.Add(this.rdoTranAfter);
            this.grpLotBaseRelation.Controls.Add(this.lblTransaction);
            this.grpLotBaseRelation.Controls.Add(this.chkInheritChild);
            this.grpLotBaseRelation.Controls.Add(this.txtLotID);
            this.grpLotBaseRelation.Controls.Add(this.lblLotID);
            this.grpLotBaseRelation.Location = new System.Drawing.Point(6, 6);
            this.grpLotBaseRelation.Name = "grpLotBaseRelation";
            this.grpLotBaseRelation.Size = new System.Drawing.Size(481, 82);
            this.grpLotBaseRelation.TabIndex = 0;
            this.grpLotBaseRelation.TabStop = false;
            this.grpLotBaseRelation.Text = "Lot Base Relation";
            // 
            // cboTransaction
            // 
            this.cboTransaction.FormattingEnabled = true;
            this.cboTransaction.Location = new System.Drawing.Point(112, 46);
            this.cboTransaction.Name = "cboTransaction";
            this.cboTransaction.Size = new System.Drawing.Size(180, 21);
            this.cboTransaction.TabIndex = 4;
            this.cboTransaction.SelectedIndexChanged += new System.EventHandler(this.cboTransaction_SelectedIndexChanged);
            // 
            // rdoTranBefore
            // 
            this.rdoTranBefore.AutoSize = true;
            this.rdoTranBefore.Enabled = false;
            this.rdoTranBefore.Location = new System.Drawing.Point(315, 48);
            this.rdoTranBefore.Name = "rdoTranBefore";
            this.rdoTranBefore.Size = new System.Drawing.Size(56, 17);
            this.rdoTranBefore.TabIndex = 5;
            this.rdoTranBefore.TabStop = true;
            this.rdoTranBefore.Text = "Before";
            this.rdoTranBefore.UseVisualStyleBackColor = true;
            this.rdoTranBefore.CheckedChanged += new System.EventHandler(this.rdoTranBefore_CheckedChanged);
            // 
            // rdoTranAfter
            // 
            this.rdoTranAfter.AutoSize = true;
            this.rdoTranAfter.Enabled = false;
            this.rdoTranAfter.Location = new System.Drawing.Point(406, 50);
            this.rdoTranAfter.Name = "rdoTranAfter";
            this.rdoTranAfter.Size = new System.Drawing.Size(47, 17);
            this.rdoTranAfter.TabIndex = 6;
            this.rdoTranAfter.TabStop = true;
            this.rdoTranAfter.Text = "After";
            this.rdoTranAfter.UseVisualStyleBackColor = true;
            this.rdoTranAfter.CheckedChanged += new System.EventHandler(this.rdoTranAfter_CheckedChanged);
            // 
            // lblTransaction
            // 
            this.lblTransaction.AutoSize = true;
            this.lblTransaction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransaction.Location = new System.Drawing.Point(18, 50);
            this.lblTransaction.Name = "lblTransaction";
            this.lblTransaction.Size = new System.Drawing.Size(63, 13);
            this.lblTransaction.TabIndex = 3;
            this.lblTransaction.Text = "Transaction";
            this.lblTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkInheritChild
            // 
            this.chkInheritChild.AutoSize = true;
            this.chkInheritChild.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInheritChild.Enabled = false;
            this.chkInheritChild.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInheritChild.Location = new System.Drawing.Point(315, 20);
            this.chkInheritChild.Name = "chkInheritChild";
            this.chkInheritChild.Size = new System.Drawing.Size(105, 18);
            this.chkInheritChild.TabIndex = 2;
            this.chkInheritChild.Text = "Inherit Child Lot";
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(112, 19);
            this.txtLotID.MaxLength = 30;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(180, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Location = new System.Drawing.Point(18, 23);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // grpResourceBaseRelation
            // 
            this.grpResourceBaseRelation.Controls.Add(this.rdoEventBefore);
            this.grpResourceBaseRelation.Controls.Add(this.cdvEvent);
            this.grpResourceBaseRelation.Controls.Add(this.rdoEventAfter);
            this.grpResourceBaseRelation.Controls.Add(this.lblEvent);
            this.grpResourceBaseRelation.Location = new System.Drawing.Point(4, 93);
            this.grpResourceBaseRelation.Name = "grpResourceBaseRelation";
            this.grpResourceBaseRelation.Size = new System.Drawing.Size(487, 43);
            this.grpResourceBaseRelation.TabIndex = 1;
            this.grpResourceBaseRelation.TabStop = false;
            this.grpResourceBaseRelation.Text = "Resource Base Relation";
            // 
            // rdoEventBefore
            // 
            this.rdoEventBefore.AutoSize = true;
            this.rdoEventBefore.Enabled = false;
            this.rdoEventBefore.Location = new System.Drawing.Point(317, 18);
            this.rdoEventBefore.Name = "rdoEventBefore";
            this.rdoEventBefore.Size = new System.Drawing.Size(56, 17);
            this.rdoEventBefore.TabIndex = 2;
            this.rdoEventBefore.TabStop = true;
            this.rdoEventBefore.Text = "Before";
            this.rdoEventBefore.UseVisualStyleBackColor = true;
            this.rdoEventBefore.CheckedChanged += new System.EventHandler(this.rdoEventBefore_CheckedChanged);
            // 
            // cdvEvent
            // 
            this.cdvEvent.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEvent.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEvent.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEvent.BtnToolTipText = "";
            this.cdvEvent.DescText = "";
            this.cdvEvent.DisplaySubItemIndex = -1;
            this.cdvEvent.DisplayText = "";
            this.cdvEvent.Focusing = null;
            this.cdvEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEvent.Index = 0;
            this.cdvEvent.IsViewBtnImage = false;
            this.cdvEvent.Location = new System.Drawing.Point(114, 16);
            this.cdvEvent.MaxLength = 20;
            this.cdvEvent.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEvent.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEvent.Name = "cdvEvent";
            this.cdvEvent.ReadOnly = false;
            this.cdvEvent.SearchSubItemIndex = 0;
            this.cdvEvent.SelectedDescIndex = -1;
            this.cdvEvent.SelectedSubItemIndex = -1;
            this.cdvEvent.SelectionStart = 0;
            this.cdvEvent.Size = new System.Drawing.Size(180, 20);
            this.cdvEvent.SmallImageList = null;
            this.cdvEvent.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEvent.TabIndex = 1;
            this.cdvEvent.TextBoxToolTipText = "";
            this.cdvEvent.TextBoxWidth = 180;
            this.cdvEvent.VisibleButton = true;
            this.cdvEvent.VisibleColumnHeader = false;
            this.cdvEvent.VisibleDescription = false;
            this.cdvEvent.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvEvent_SelectedItemChanged);
            this.cdvEvent.ButtonPress += new System.EventHandler(this.cdvEvent_ButtonPress);
            // 
            // rdoEventAfter
            // 
            this.rdoEventAfter.AutoSize = true;
            this.rdoEventAfter.Enabled = false;
            this.rdoEventAfter.Location = new System.Drawing.Point(408, 18);
            this.rdoEventAfter.Name = "rdoEventAfter";
            this.rdoEventAfter.Size = new System.Drawing.Size(47, 17);
            this.rdoEventAfter.TabIndex = 3;
            this.rdoEventAfter.TabStop = true;
            this.rdoEventAfter.Text = "After";
            this.rdoEventAfter.UseVisualStyleBackColor = true;
            this.rdoEventAfter.CheckedChanged += new System.EventHandler(this.rdoEventAfter_CheckedChanged);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(18, 20);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(35, 13);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Event";
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlGeneralInfo
            // 
            this.pnlGeneralInfo.Controls.Add(this.lblApplyEndTime);
            this.pnlGeneralInfo.Controls.Add(this.lblApplyTime);
            this.pnlGeneralInfo.Controls.Add(this.cdvCompleteUser);
            this.pnlGeneralInfo.Controls.Add(this.dtpToTime);
            this.pnlGeneralInfo.Controls.Add(this.lblCompleteUser);
            this.pnlGeneralInfo.Controls.Add(this.dtpToDate);
            this.pnlGeneralInfo.Controls.Add(this.chkRequire);
            this.pnlGeneralInfo.Controls.Add(this.dtpFromTime);
            this.pnlGeneralInfo.Controls.Add(this.dtpFromDate);
            this.pnlGeneralInfo.Controls.Add(this.chkFromTime);
            this.pnlGeneralInfo.Controls.Add(this.chkToTime);
            this.pnlGeneralInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGeneralInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlGeneralInfo.Name = "pnlGeneralInfo";
            this.pnlGeneralInfo.Size = new System.Drawing.Size(492, 89);
            this.pnlGeneralInfo.TabIndex = 0;
            // 
            // lblApplyEndTime
            // 
            this.lblApplyEndTime.AutoSize = true;
            this.lblApplyEndTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApplyEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplyEndTime.Location = new System.Drawing.Point(7, 37);
            this.lblApplyEndTime.Name = "lblApplyEndTime";
            this.lblApplyEndTime.Size = new System.Drawing.Size(81, 13);
            this.lblApplyEndTime.TabIndex = 4;
            this.lblApplyEndTime.Text = "Apply End Time";
            this.lblApplyEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplyTime
            // 
            this.lblApplyTime.AutoSize = true;
            this.lblApplyTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApplyTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplyTime.Location = new System.Drawing.Point(7, 9);
            this.lblApplyTime.Name = "lblApplyTime";
            this.lblApplyTime.Size = new System.Drawing.Size(84, 13);
            this.lblApplyTime.TabIndex = 0;
            this.lblApplyTime.Text = "Apply Start Time";
            this.lblApplyTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCompleteUser
            // 
            this.cdvCompleteUser.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCompleteUser.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCompleteUser.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCompleteUser.BtnToolTipText = "";
            this.cdvCompleteUser.DescText = "";
            this.cdvCompleteUser.DisplaySubItemIndex = -1;
            this.cdvCompleteUser.DisplayText = "";
            this.cdvCompleteUser.Enabled = false;
            this.cdvCompleteUser.Focusing = null;
            this.cdvCompleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCompleteUser.Index = 0;
            this.cdvCompleteUser.IsViewBtnImage = false;
            this.cdvCompleteUser.Location = new System.Drawing.Point(299, 61);
            this.cdvCompleteUser.MaxLength = 20;
            this.cdvCompleteUser.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCompleteUser.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCompleteUser.Name = "cdvCompleteUser";
            this.cdvCompleteUser.ReadOnly = false;
            this.cdvCompleteUser.SearchSubItemIndex = 0;
            this.cdvCompleteUser.SelectedDescIndex = -1;
            this.cdvCompleteUser.SelectedSubItemIndex = -1;
            this.cdvCompleteUser.SelectionStart = 0;
            this.cdvCompleteUser.Size = new System.Drawing.Size(180, 20);
            this.cdvCompleteUser.SmallImageList = null;
            this.cdvCompleteUser.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCompleteUser.TabIndex = 10;
            this.cdvCompleteUser.TextBoxToolTipText = "";
            this.cdvCompleteUser.TextBoxWidth = 180;
            this.cdvCompleteUser.VisibleButton = true;
            this.cdvCompleteUser.VisibleColumnHeader = false;
            this.cdvCompleteUser.VisibleDescription = false;
            this.cdvCompleteUser.ButtonPress += new System.EventHandler(this.cdvCompleteUser_ButtonPress);
            // 
            // dtpToTime
            // 
            this.dtpToTime.Enabled = false;
            this.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpToTime.Location = new System.Drawing.Point(223, 33);
            this.dtpToTime.Name = "dtpToTime";
            this.dtpToTime.ShowUpDown = true;
            this.dtpToTime.Size = new System.Drawing.Size(97, 20);
            this.dtpToTime.TabIndex = 7;
            this.dtpToTime.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // lblCompleteUser
            // 
            this.lblCompleteUser.AutoSize = true;
            this.lblCompleteUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCompleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleteUser.Location = new System.Drawing.Point(205, 65);
            this.lblCompleteUser.Name = "lblCompleteUser";
            this.lblCompleteUser.Size = new System.Drawing.Size(76, 13);
            this.lblCompleteUser.TabIndex = 9;
            this.lblCompleteUser.Text = "Complete User";
            this.lblCompleteUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(129, 33);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(91, 20);
            this.dtpToDate.TabIndex = 6;
            this.dtpToDate.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // chkRequire
            // 
            this.chkRequire.AutoSize = true;
            this.chkRequire.Location = new System.Drawing.Point(6, 63);
            this.chkRequire.Name = "chkRequire";
            this.chkRequire.Size = new System.Drawing.Size(166, 17);
            this.chkRequire.TabIndex = 8;
            this.chkRequire.Text = "Require Complete Action Flag";
            this.chkRequire.UseVisualStyleBackColor = true;
            this.chkRequire.CheckedChanged += new System.EventHandler(this.chkRequire_CheckedChanged);
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Enabled = false;
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFromTime.Location = new System.Drawing.Point(223, 5);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(97, 20);
            this.dtpFromTime.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(129, 5);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(91, 20);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // chkFromTime
            // 
            this.chkFromTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkFromTime.Location = new System.Drawing.Point(112, 8);
            this.chkFromTime.Name = "chkFromTime";
            this.chkFromTime.Size = new System.Drawing.Size(14, 15);
            this.chkFromTime.TabIndex = 1;
            this.chkFromTime.CheckedChanged += new System.EventHandler(this.chkFromTime_CheckedChanged);
            // 
            // chkToTime
            // 
            this.chkToTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkToTime.Location = new System.Drawing.Point(112, 36);
            this.chkToTime.Name = "chkToTime";
            this.chkToTime.Size = new System.Drawing.Size(14, 15);
            this.chkToTime.TabIndex = 5;
            this.chkToTime.CheckedChanged += new System.EventHandler(this.chkToTime_CheckedChanged);
            // 
            // tabKeyValuePrompt
            // 
            this.tabKeyValuePrompt.Controls.Add(this.pnlCmfItemDef);
            this.tabKeyValuePrompt.Location = new System.Drawing.Point(4, 22);
            this.tabKeyValuePrompt.Name = "tabKeyValuePrompt";
            this.tabKeyValuePrompt.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeyValuePrompt.Size = new System.Drawing.Size(498, 271);
            this.tabKeyValuePrompt.TabIndex = 1;
            this.tabKeyValuePrompt.Text = "Key Value Prompt";
            // 
            // pnlCmfItemDef
            // 
            this.pnlCmfItemDef.Controls.Add(this.cdvChecklistKeyPrompt);
            this.pnlCmfItemDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCmfItemDef.Location = new System.Drawing.Point(3, 3);
            this.pnlCmfItemDef.Name = "pnlCmfItemDef";
            this.pnlCmfItemDef.Padding = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.pnlCmfItemDef.Size = new System.Drawing.Size(492, 265);
            this.pnlCmfItemDef.TabIndex = 4;
            // 
            // cdvChecklistKeyPrompt
            // 
            this.cdvChecklistKeyPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvChecklistKeyPrompt.Location = new System.Drawing.Point(5, 3);
            this.cdvChecklistKeyPrompt.LockColumn_Format = false;
            this.cdvChecklistKeyPrompt.LockColumn_Prompt = false;
            this.cdvChecklistKeyPrompt.LockColumn_Require = false;
            this.cdvChecklistKeyPrompt.LockColumn_TableItem = false;
            this.cdvChecklistKeyPrompt.Name = "cdvChecklistKeyPrompt";
            this.cdvChecklistKeyPrompt.Size = new System.Drawing.Size(484, 259);
            this.cdvChecklistKeyPrompt.TabIndex = 0;
            // 
            // pnlCheckBottomTop
            // 
            this.pnlCheckBottomTop.Controls.Add(this.grbTable);
            this.pnlCheckBottomTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCheckBottomTop.Location = new System.Drawing.Point(0, 0);
            this.pnlCheckBottomTop.Name = "pnlCheckBottomTop";
            this.pnlCheckBottomTop.Size = new System.Drawing.Size(506, 65);
            this.pnlCheckBottomTop.TabIndex = 0;
            // 
            // grbTable
            // 
            this.grbTable.Controls.Add(this.cdvChecklistID);
            this.grbTable.Controls.Add(this.txtDesc);
            this.grbTable.Controls.Add(this.Label6);
            this.grbTable.Controls.Add(this.lblChecklistID);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbTable.Location = new System.Drawing.Point(0, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(506, 65);
            this.grbTable.TabIndex = 0;
            this.grbTable.TabStop = false;
            // 
            // cdvChecklistID
            // 
            this.cdvChecklistID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChecklistID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChecklistID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChecklistID.BtnToolTipText = "";
            this.cdvChecklistID.DescText = "";
            this.cdvChecklistID.DisplaySubItemIndex = -1;
            this.cdvChecklistID.DisplayText = "";
            this.cdvChecklistID.Focusing = null;
            this.cdvChecklistID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChecklistID.Index = 0;
            this.cdvChecklistID.IsViewBtnImage = false;
            this.cdvChecklistID.Location = new System.Drawing.Point(119, 13);
            this.cdvChecklistID.MaxLength = 20;
            this.cdvChecklistID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistID.Name = "cdvChecklistID";
            this.cdvChecklistID.ReadOnly = false;
            this.cdvChecklistID.SearchSubItemIndex = 0;
            this.cdvChecklistID.SelectedDescIndex = -1;
            this.cdvChecklistID.SelectedSubItemIndex = -1;
            this.cdvChecklistID.SelectionStart = 0;
            this.cdvChecklistID.Size = new System.Drawing.Size(180, 20);
            this.cdvChecklistID.SmallImageList = null;
            this.cdvChecklistID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChecklistID.TabIndex = 1;
            this.cdvChecklistID.TextBoxToolTipText = "";
            this.cdvChecklistID.TextBoxWidth = 180;
            this.cdvChecklistID.VisibleButton = true;
            this.cdvChecklistID.VisibleColumnHeader = false;
            this.cdvChecklistID.VisibleDescription = false;
            this.cdvChecklistID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChecklistID_SelectedItemChanged);
            this.cdvChecklistID.ButtonPress += new System.EventHandler(this.cdvChecklistID_ButtonPress);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(119, 39);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(380, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(7, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 13);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Description";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChecklistID
            // 
            this.lblChecklistID.AutoSize = true;
            this.lblChecklistID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChecklistID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecklistID.Location = new System.Drawing.Point(7, 17);
            this.lblChecklistID.Name = "lblChecklistID";
            this.lblChecklistID.Size = new System.Drawing.Size(76, 13);
            this.lblChecklistID.TabIndex = 0;
            this.lblChecklistID.Text = "Checklist ID";
            this.lblChecklistID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBASSetupChecklistRelation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASSetupChecklistRelation";
            this.Text = "Checklist Relation Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupChecklistRelation_Activated);
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
            this.tabRelation.ResumeLayout(false);
            this.tbpMFO.ResumeLayout(false);
            this.tbpResource.ResumeLayout(false);
            this.pnlCheckFill.ResumeLayout(false);
            this.pnlCheckBottom.ResumeLayout(false);
            this.pnlCheckBottomFill.ResumeLayout(false);
            this.tabRelationInfo.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.pnlDetailInfo.ResumeLayout(false);
            this.grpLotBaseRelation.ResumeLayout(false);
            this.grpLotBaseRelation.PerformLayout();
            this.grpResourceBaseRelation.ResumeLayout(false);
            this.grpResourceBaseRelation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEvent)).EndInit();
            this.pnlGeneralInfo.ResumeLayout(false);
            this.pnlGeneralInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCompleteUser)).EndInit();
            this.tabKeyValuePrompt.ResumeLayout(false);
            this.pnlCmfItemDef.ResumeLayout(false);
            this.pnlCheckBottomTop.ResumeLayout(false);
            this.grbTable.ResumeLayout(false);
            this.grbTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCheckFill;
        private System.Windows.Forms.Panel pnlCheckBottom;
        private System.Windows.Forms.TabControl tabRelation;
        private System.Windows.Forms.TabPage tbpMFO;
        private System.Windows.Forms.TabPage tbpResource;
        private System.Windows.Forms.Panel pnlCheckBottomTop;
        private System.Windows.Forms.GroupBox grbTable;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label lblChecklistID;
        private System.Windows.Forms.Panel pnlCheckBottomFill;
        private System.Windows.Forms.TabControl tabRelationInfo;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabKeyValuePrompt;
        private UI.Controls.MCCodeView.MCCodeView cdvChecklistID;
        private MESCore.Controls.udcMFOTreeList udcMFO;
        private System.Windows.Forms.DateTimePicker dtpToTime;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromTime;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.CheckBox chkToTime;
        private System.Windows.Forms.CheckBox chkFromTime;
        private System.Windows.Forms.GroupBox grpLotBaseRelation;
        private System.Windows.Forms.CheckBox chkInheritChild;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private MESCore.Controls.udcResourceTreeList udcResourceTreeList;
        private System.Windows.Forms.Panel pnlCmfItemDef;
        private System.Windows.Forms.Label lblTransaction;
        private System.Windows.Forms.RadioButton rdoTranBefore;
        private System.Windows.Forms.RadioButton rdoTranAfter;
        private UI.Controls.MCListView.MCListView lisTranChecklist;
        private System.Windows.Forms.ColumnHeader colChecklistID1;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colInheritChildLotFlag;
        private System.Windows.Forms.ColumnHeader colTranCode;
        private System.Windows.Forms.ColumnHeader colRequireCompleteFlag1;
        private System.Windows.Forms.ColumnHeader colApplyFromTo1;
        private System.Windows.Forms.GroupBox grpResourceBaseRelation;
        private System.Windows.Forms.RadioButton rdoEventBefore;
        private UI.Controls.MCCodeView.MCCodeView cdvEvent;
        private System.Windows.Forms.RadioButton rdoEventAfter;
        private System.Windows.Forms.Label lblEvent;
        private UI.Controls.MCListView.MCListView lisEventChecklist;
        private System.Windows.Forms.ColumnHeader colChecklistID2;
        private System.Windows.Forms.ColumnHeader colEventID;
        private System.Windows.Forms.ColumnHeader colRequireCompleteFlag2;
        private System.Windows.Forms.ColumnHeader colApplyFromTo2;
        private System.Windows.Forms.Panel pnlGeneralInfo;
        private UI.Controls.MCCodeView.MCCodeView cdvCompleteUser;
        private System.Windows.Forms.Label lblCompleteUser;
        private System.Windows.Forms.CheckBox chkRequire;
        private System.Windows.Forms.Label lblApplyTime;
        private System.Windows.Forms.Label lblApplyEndTime;
        private System.Windows.Forms.Panel pnlDetailInfo;
        private System.Windows.Forms.ColumnHeader colBAPoint1;
        private Controls.udcChecklistKeyPrompt cdvChecklistKeyPrompt;
        private System.Windows.Forms.ColumnHeader colBAPoint2;
        private System.Windows.Forms.ComboBox cboTransaction;
    }
}