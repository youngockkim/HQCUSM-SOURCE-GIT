namespace Miracom.RASCore
{
    partial class frmRASSetupCarrierGroupRelation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASSetupCarrierGroupRelation));
            this.tabRelation = new System.Windows.Forms.TabControl();
            this.tbpMFO = new System.Windows.Forms.TabPage();
            this.pnlMFODetail = new System.Windows.Forms.Panel();
            this.pnlMFORelation = new System.Windows.Forms.Panel();
            this.pnlMFORelRight = new System.Windows.Forms.Panel();
            this.lisGroupList1 = new Miracom.UI.Controls.MCListView.MCListView();
            this.colGroup1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupList1 = new System.Windows.Forms.Label();
            this.pnlMFORelMid = new System.Windows.Forms.Panel();
            this.btnMFORelExcel = new System.Windows.Forms.Button();
            this.btnMFOUp = new System.Windows.Forms.Button();
            this.btnMFODown = new System.Windows.Forms.Button();
            this.btnMFODel = new System.Windows.Forms.Button();
            this.btnMFOAdd = new System.Windows.Forms.Button();
            this.pnlMFORelLeft = new System.Windows.Forms.Panel();
            this.lisMFORel = new Miracom.UI.Controls.MCListView.MCListView();
            this.colMFOSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMFOGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMFODesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMFOAttach = new System.Windows.Forms.Label();
            this.pnlChange = new System.Windows.Forms.Panel();
            this.grpChange = new System.Windows.Forms.GroupBox();
            this.lblC4 = new System.Windows.Forms.Label();
            this.lblC3 = new System.Windows.Forms.Label();
            this.lblC2 = new System.Windows.Forms.Label();
            this.lblC1 = new System.Windows.Forms.Label();
            this.cdvCModeEnd = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvToTypeEnd = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFromTypeEnd = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCModeStart = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvToTypeStart = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFromTypeStart = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCModeAdhoc = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvToTypeAdhoc = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFromTypeAdhoc = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.chkAdHoc = new System.Windows.Forms.CheckBox();
            this.lblA3 = new System.Windows.Forms.Label();
            this.lblA2 = new System.Windows.Forms.Label();
            this.lblA1 = new System.Windows.Forms.Label();
            this.lblBackGroup = new System.Windows.Forms.Label();
            this.spl1 = new System.Windows.Forms.Splitter();
            this.pnlMFOCond = new System.Windows.Forms.Panel();
            this.udcMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.tbpResource = new System.Windows.Forms.TabPage();
            this.pnlResDetail = new System.Windows.Forms.Panel();
            this.pnlResRelation = new System.Windows.Forms.Panel();
            this.pnlResRelRight = new System.Windows.Forms.Panel();
            this.lisGroupList2 = new Miracom.UI.Controls.MCListView.MCListView();
            this.colGroup2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupList2 = new System.Windows.Forms.Label();
            this.pnlResRelMid = new System.Windows.Forms.Panel();
            this.btnResCrrGrp = new System.Windows.Forms.Button();
            this.btnResUp = new System.Windows.Forms.Button();
            this.btnResDown = new System.Windows.Forms.Button();
            this.btnResDel = new System.Windows.Forms.Button();
            this.btnResAdd = new System.Windows.Forms.Button();
            this.pnlResRelLeft = new System.Windows.Forms.Panel();
            this.lisResRel = new Miracom.UI.Controls.MCListView.MCListView();
            this.colResSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResAttach = new System.Windows.Forms.Label();
            this.spl2 = new System.Windows.Forms.Splitter();
            this.pnlResCond = new System.Windows.Forms.Panel();
            this.pnlResCondMid = new System.Windows.Forms.Panel();
            this.tvResList = new System.Windows.Forms.TreeView();
            this.lisResList = new System.Windows.Forms.ListView();
            this.colResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPortID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlResCondTop = new System.Windows.Forms.Panel();
            this.chkOnlySettingData = new System.Windows.Forms.CheckBox();
            this.cdvResGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResGroup = new System.Windows.Forms.Label();
            this.cdvResType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResType = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabRelation.SuspendLayout();
            this.tbpMFO.SuspendLayout();
            this.pnlMFODetail.SuspendLayout();
            this.pnlMFORelation.SuspendLayout();
            this.pnlMFORelRight.SuspendLayout();
            this.pnlMFORelMid.SuspendLayout();
            this.pnlMFORelLeft.SuspendLayout();
            this.pnlChange.SuspendLayout();
            this.grpChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCModeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToTypeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromTypeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCModeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToTypeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromTypeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCModeAdhoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToTypeAdhoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromTypeAdhoc)).BeginInit();
            this.pnlMFOCond.SuspendLayout();
            this.tbpResource.SuspendLayout();
            this.pnlResDetail.SuspendLayout();
            this.pnlResRelation.SuspendLayout();
            this.pnlResRelRight.SuspendLayout();
            this.pnlResRelMid.SuspendLayout();
            this.pnlResRelLeft.SuspendLayout();
            this.pnlResCond.SuspendLayout();
            this.pnlResCondMid.SuspendLayout();
            this.pnlResCondTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 7);
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 7);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabRelation);
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
            this.tabRelation.Size = new System.Drawing.Size(742, 506);
            this.tabRelation.TabIndex = 0;
            this.tabRelation.SelectedIndexChanged += new System.EventHandler(this.tabRelation_SelectedIndexChanged);
            // 
            // tbpMFO
            // 
            this.tbpMFO.BackColor = System.Drawing.SystemColors.Control;
            this.tbpMFO.Controls.Add(this.pnlMFODetail);
            this.tbpMFO.Controls.Add(this.spl1);
            this.tbpMFO.Controls.Add(this.pnlMFOCond);
            this.tbpMFO.Location = new System.Drawing.Point(4, 22);
            this.tbpMFO.Name = "tbpMFO";
            this.tbpMFO.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMFO.Size = new System.Drawing.Size(734, 480);
            this.tbpMFO.TabIndex = 0;
            this.tbpMFO.Text = "M-F-O";
            // 
            // pnlMFODetail
            // 
            this.pnlMFODetail.Controls.Add(this.pnlMFORelation);
            this.pnlMFODetail.Controls.Add(this.pnlChange);
            this.pnlMFODetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMFODetail.Location = new System.Drawing.Point(239, 3);
            this.pnlMFODetail.Name = "pnlMFODetail";
            this.pnlMFODetail.Size = new System.Drawing.Size(492, 474);
            this.pnlMFODetail.TabIndex = 1;
            // 
            // pnlMFORelation
            // 
            this.pnlMFORelation.Controls.Add(this.pnlMFORelRight);
            this.pnlMFORelation.Controls.Add(this.pnlMFORelMid);
            this.pnlMFORelation.Controls.Add(this.pnlMFORelLeft);
            this.pnlMFORelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMFORelation.Location = new System.Drawing.Point(0, 0);
            this.pnlMFORelation.Name = "pnlMFORelation";
            this.pnlMFORelation.Size = new System.Drawing.Size(492, 360);
            this.pnlMFORelation.TabIndex = 0;
            this.pnlMFORelation.Resize += new System.EventHandler(this.pnlMFORelation_Resize);
            // 
            // pnlMFORelRight
            // 
            this.pnlMFORelRight.Controls.Add(this.lisGroupList1);
            this.pnlMFORelRight.Controls.Add(this.lblGroupList1);
            this.pnlMFORelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMFORelRight.Location = new System.Drawing.Point(266, 0);
            this.pnlMFORelRight.Name = "pnlMFORelRight";
            this.pnlMFORelRight.Size = new System.Drawing.Size(226, 360);
            this.pnlMFORelRight.TabIndex = 0;
            // 
            // lisGroupList1
            // 
            this.lisGroupList1.AllowDrop = true;
            this.lisGroupList1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGroup1,
            this.colDesc1});
            this.lisGroupList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisGroupList1.EnableSort = true;
            this.lisGroupList1.EnableSortIcon = true;
            this.lisGroupList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisGroupList1.FullRowSelect = true;
            this.lisGroupList1.Location = new System.Drawing.Point(0, 14);
            this.lisGroupList1.Name = "lisGroupList1";
            this.lisGroupList1.Size = new System.Drawing.Size(226, 346);
            this.lisGroupList1.TabIndex = 1;
            this.lisGroupList1.UseCompatibleStateImageBehavior = false;
            this.lisGroupList1.View = System.Windows.Forms.View.Details;
            // 
            // colGroup1
            // 
            this.colGroup1.Text = "Carrier Group";
            this.colGroup1.Width = 120;
            // 
            // colDesc1
            // 
            this.colDesc1.Text = "Description";
            this.colDesc1.Width = 200;
            // 
            // lblGroupList1
            // 
            this.lblGroupList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupList1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroupList1.Location = new System.Drawing.Point(0, 0);
            this.lblGroupList1.Name = "lblGroupList1";
            this.lblGroupList1.Size = new System.Drawing.Size(226, 14);
            this.lblGroupList1.TabIndex = 0;
            this.lblGroupList1.Text = "All Carrier Group List";
            // 
            // pnlMFORelMid
            // 
            this.pnlMFORelMid.Controls.Add(this.btnMFORelExcel);
            this.pnlMFORelMid.Controls.Add(this.btnMFOUp);
            this.pnlMFORelMid.Controls.Add(this.btnMFODown);
            this.pnlMFORelMid.Controls.Add(this.btnMFODel);
            this.pnlMFORelMid.Controls.Add(this.btnMFOAdd);
            this.pnlMFORelMid.Location = new System.Drawing.Point(214, 28);
            this.pnlMFORelMid.Name = "pnlMFORelMid";
            this.pnlMFORelMid.Size = new System.Drawing.Size(38, 279);
            this.pnlMFORelMid.TabIndex = 0;
            // 
            // btnMFORelExcel
            // 
            this.btnMFORelExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMFORelExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMFORelExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnMFORelExcel.Image")));
            this.btnMFORelExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMFORelExcel.Location = new System.Drawing.Point(2, 252);
            this.btnMFORelExcel.Name = "btnMFORelExcel";
            this.btnMFORelExcel.Size = new System.Drawing.Size(24, 24);
            this.btnMFORelExcel.TabIndex = 20;
            this.btnMFORelExcel.Click += new System.EventHandler(this.btnMFORelExcel_Click);
            // 
            // btnMFOUp
            // 
            this.btnMFOUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMFOUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMFOUp.Image")));
            this.btnMFOUp.Location = new System.Drawing.Point(2, 201);
            this.btnMFOUp.Name = "btnMFOUp";
            this.btnMFOUp.Size = new System.Drawing.Size(24, 24);
            this.btnMFOUp.TabIndex = 2;
            this.btnMFOUp.Click += new System.EventHandler(this.btnMFOUp_Click);
            // 
            // btnMFODown
            // 
            this.btnMFODown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMFODown.Image = ((System.Drawing.Image)(resources.GetObject("btnMFODown.Image")));
            this.btnMFODown.Location = new System.Drawing.Point(2, 226);
            this.btnMFODown.Name = "btnMFODown";
            this.btnMFODown.Size = new System.Drawing.Size(24, 24);
            this.btnMFODown.TabIndex = 3;
            this.btnMFODown.Click += new System.EventHandler(this.btnMFODown_Click);
            // 
            // btnMFODel
            // 
            this.btnMFODel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMFODel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMFODel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMFODel.Location = new System.Drawing.Point(7, 142);
            this.btnMFODel.Name = "btnMFODel";
            this.btnMFODel.Size = new System.Drawing.Size(24, 24);
            this.btnMFODel.TabIndex = 1;
            this.btnMFODel.Text = ">";
            this.btnMFODel.Click += new System.EventHandler(this.btnMFODel_Click);
            // 
            // btnMFOAdd
            // 
            this.btnMFOAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMFOAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMFOAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMFOAdd.Location = new System.Drawing.Point(7, 113);
            this.btnMFOAdd.Name = "btnMFOAdd";
            this.btnMFOAdd.Size = new System.Drawing.Size(24, 24);
            this.btnMFOAdd.TabIndex = 0;
            this.btnMFOAdd.Text = "<";
            this.btnMFOAdd.Click += new System.EventHandler(this.btnMFOAdd_Click);
            // 
            // pnlMFORelLeft
            // 
            this.pnlMFORelLeft.Controls.Add(this.lisMFORel);
            this.pnlMFORelLeft.Controls.Add(this.lblMFOAttach);
            this.pnlMFORelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMFORelLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlMFORelLeft.Name = "pnlMFORelLeft";
            this.pnlMFORelLeft.Size = new System.Drawing.Size(208, 360);
            this.pnlMFORelLeft.TabIndex = 0;
            // 
            // lisMFORel
            // 
            this.lisMFORel.AllowDrop = true;
            this.lisMFORel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMFOSeq,
            this.colMFOGroup,
            this.colMFODesc});
            this.lisMFORel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMFORel.EnableSort = true;
            this.lisMFORel.EnableSortIcon = true;
            this.lisMFORel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMFORel.FullRowSelect = true;
            this.lisMFORel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lisMFORel.Location = new System.Drawing.Point(0, 14);
            this.lisMFORel.Name = "lisMFORel";
            this.lisMFORel.Size = new System.Drawing.Size(208, 346);
            this.lisMFORel.TabIndex = 1;
            this.lisMFORel.UseCompatibleStateImageBehavior = false;
            this.lisMFORel.View = System.Windows.Forms.View.Details;
            // 
            // colMFOSeq
            // 
            this.colMFOSeq.Text = "Seq";
            this.colMFOSeq.Width = 50;
            // 
            // colMFOGroup
            // 
            this.colMFOGroup.Text = "Carrier Group";
            this.colMFOGroup.Width = 120;
            // 
            // colMFODesc
            // 
            this.colMFODesc.Text = "Description";
            this.colMFODesc.Width = 200;
            // 
            // lblMFOAttach
            // 
            this.lblMFOAttach.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMFOAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMFOAttach.Location = new System.Drawing.Point(0, 0);
            this.lblMFOAttach.Name = "lblMFOAttach";
            this.lblMFOAttach.Size = new System.Drawing.Size(208, 14);
            this.lblMFOAttach.TabIndex = 0;
            this.lblMFOAttach.Text = "Attached Carrier Group";
            // 
            // pnlChange
            // 
            this.pnlChange.Controls.Add(this.grpChange);
            this.pnlChange.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChange.Location = new System.Drawing.Point(0, 360);
            this.pnlChange.Name = "pnlChange";
            this.pnlChange.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlChange.Size = new System.Drawing.Size(492, 114);
            this.pnlChange.TabIndex = 0;
            // 
            // grpChange
            // 
            this.grpChange.Controls.Add(this.lblC4);
            this.grpChange.Controls.Add(this.lblC3);
            this.grpChange.Controls.Add(this.lblC2);
            this.grpChange.Controls.Add(this.lblC1);
            this.grpChange.Controls.Add(this.cdvCModeEnd);
            this.grpChange.Controls.Add(this.cdvToTypeEnd);
            this.grpChange.Controls.Add(this.cdvFromTypeEnd);
            this.grpChange.Controls.Add(this.cdvCModeStart);
            this.grpChange.Controls.Add(this.cdvToTypeStart);
            this.grpChange.Controls.Add(this.cdvFromTypeStart);
            this.grpChange.Controls.Add(this.cdvCModeAdhoc);
            this.grpChange.Controls.Add(this.cdvToTypeAdhoc);
            this.grpChange.Controls.Add(this.cdvFromTypeAdhoc);
            this.grpChange.Controls.Add(this.chkEnd);
            this.grpChange.Controls.Add(this.chkStart);
            this.grpChange.Controls.Add(this.chkAdHoc);
            this.grpChange.Controls.Add(this.lblA3);
            this.grpChange.Controls.Add(this.lblA2);
            this.grpChange.Controls.Add(this.lblA1);
            this.grpChange.Controls.Add(this.lblBackGroup);
            this.grpChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChange.Location = new System.Drawing.Point(0, 3);
            this.grpChange.Name = "grpChange";
            this.grpChange.Size = new System.Drawing.Size(492, 111);
            this.grpChange.TabIndex = 0;
            this.grpChange.TabStop = false;
            this.grpChange.Text = "Carrier Change Information";
            // 
            // lblC4
            // 
            this.lblC4.AutoSize = true;
            this.lblC4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblC4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblC4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblC4.Location = new System.Drawing.Point(360, 17);
            this.lblC4.Name = "lblC4";
            this.lblC4.Size = new System.Drawing.Size(95, 13);
            this.lblC4.TabIndex = 4;
            this.lblC4.Text = "Slot Change Mode";
            // 
            // lblC3
            // 
            this.lblC3.AutoSize = true;
            this.lblC3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblC3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblC3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblC3.Location = new System.Drawing.Point(234, 17);
            this.lblC3.Name = "lblC3";
            this.lblC3.Size = new System.Drawing.Size(47, 13);
            this.lblC3.TabIndex = 3;
            this.lblC3.Text = "To Type";
            // 
            // lblC2
            // 
            this.lblC2.AutoSize = true;
            this.lblC2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblC2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblC2.Location = new System.Drawing.Point(94, 17);
            this.lblC2.Name = "lblC2";
            this.lblC2.Size = new System.Drawing.Size(57, 13);
            this.lblC2.TabIndex = 2;
            this.lblC2.Text = "From Type";
            // 
            // lblC1
            // 
            this.lblC1.AutoSize = true;
            this.lblC1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblC1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblC1.Location = new System.Drawing.Point(12, 17);
            this.lblC1.Name = "lblC1";
            this.lblC1.Size = new System.Drawing.Size(71, 13);
            this.lblC1.TabIndex = 1;
            this.lblC1.Text = "Change Point";
            // 
            // cdvCModeEnd
            // 
            this.cdvCModeEnd.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCModeEnd.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCModeEnd.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCModeEnd.BtnToolTipText = "";
            this.cdvCModeEnd.DescText = "";
            this.cdvCModeEnd.DisplaySubItemIndex = -1;
            this.cdvCModeEnd.DisplayText = "";
            this.cdvCModeEnd.Enabled = false;
            this.cdvCModeEnd.Focusing = null;
            this.cdvCModeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCModeEnd.Index = 0;
            this.cdvCModeEnd.IsViewBtnImage = false;
            this.cdvCModeEnd.Location = new System.Drawing.Point(360, 84);
            this.cdvCModeEnd.MaxLength = 32767;
            this.cdvCModeEnd.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCModeEnd.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCModeEnd.Name = "cdvCModeEnd";
            this.cdvCModeEnd.ReadOnly = true;
            this.cdvCModeEnd.SearchSubItemIndex = 0;
            this.cdvCModeEnd.SelectedDescIndex = -1;
            this.cdvCModeEnd.SelectedSubItemIndex = -1;
            this.cdvCModeEnd.SelectionStart = 0;
            this.cdvCModeEnd.Size = new System.Drawing.Size(120, 20);
            this.cdvCModeEnd.SmallImageList = null;
            this.cdvCModeEnd.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCModeEnd.TabIndex = 19;
            this.cdvCModeEnd.TextBoxToolTipText = "";
            this.cdvCModeEnd.TextBoxWidth = 120;
            this.cdvCModeEnd.VisibleButton = true;
            this.cdvCModeEnd.VisibleColumnHeader = false;
            this.cdvCModeEnd.VisibleDescription = false;
            this.cdvCModeEnd.ButtonPress += new System.EventHandler(this.cdvCMode_ButtonPress);
            // 
            // cdvToTypeEnd
            // 
            this.cdvToTypeEnd.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToTypeEnd.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToTypeEnd.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToTypeEnd.BtnToolTipText = "";
            this.cdvToTypeEnd.DescText = "";
            this.cdvToTypeEnd.DisplaySubItemIndex = -1;
            this.cdvToTypeEnd.DisplayText = "";
            this.cdvToTypeEnd.Enabled = false;
            this.cdvToTypeEnd.Focusing = null;
            this.cdvToTypeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToTypeEnd.Index = 0;
            this.cdvToTypeEnd.IsViewBtnImage = false;
            this.cdvToTypeEnd.Location = new System.Drawing.Point(234, 84);
            this.cdvToTypeEnd.MaxLength = 32767;
            this.cdvToTypeEnd.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToTypeEnd.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToTypeEnd.Name = "cdvToTypeEnd";
            this.cdvToTypeEnd.ReadOnly = true;
            this.cdvToTypeEnd.SearchSubItemIndex = 0;
            this.cdvToTypeEnd.SelectedDescIndex = -1;
            this.cdvToTypeEnd.SelectedSubItemIndex = -1;
            this.cdvToTypeEnd.SelectionStart = 0;
            this.cdvToTypeEnd.Size = new System.Drawing.Size(120, 20);
            this.cdvToTypeEnd.SmallImageList = null;
            this.cdvToTypeEnd.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToTypeEnd.TabIndex = 18;
            this.cdvToTypeEnd.TextBoxToolTipText = "";
            this.cdvToTypeEnd.TextBoxWidth = 120;
            this.cdvToTypeEnd.VisibleButton = true;
            this.cdvToTypeEnd.VisibleColumnHeader = false;
            this.cdvToTypeEnd.VisibleDescription = false;
            this.cdvToTypeEnd.ButtonPress += new System.EventHandler(this.cdvToType_ButtonPress);
            // 
            // cdvFromTypeEnd
            // 
            this.cdvFromTypeEnd.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFromTypeEnd.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFromTypeEnd.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFromTypeEnd.BtnToolTipText = "";
            this.cdvFromTypeEnd.DescText = "";
            this.cdvFromTypeEnd.DisplaySubItemIndex = -1;
            this.cdvFromTypeEnd.DisplayText = "";
            this.cdvFromTypeEnd.Enabled = false;
            this.cdvFromTypeEnd.Focusing = null;
            this.cdvFromTypeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFromTypeEnd.Index = 0;
            this.cdvFromTypeEnd.IsViewBtnImage = false;
            this.cdvFromTypeEnd.Location = new System.Drawing.Point(94, 84);
            this.cdvFromTypeEnd.MaxLength = 32767;
            this.cdvFromTypeEnd.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFromTypeEnd.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFromTypeEnd.Name = "cdvFromTypeEnd";
            this.cdvFromTypeEnd.ReadOnly = true;
            this.cdvFromTypeEnd.SearchSubItemIndex = 0;
            this.cdvFromTypeEnd.SelectedDescIndex = -1;
            this.cdvFromTypeEnd.SelectedSubItemIndex = -1;
            this.cdvFromTypeEnd.SelectionStart = 0;
            this.cdvFromTypeEnd.Size = new System.Drawing.Size(120, 20);
            this.cdvFromTypeEnd.SmallImageList = null;
            this.cdvFromTypeEnd.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFromTypeEnd.TabIndex = 16;
            this.cdvFromTypeEnd.TextBoxToolTipText = "";
            this.cdvFromTypeEnd.TextBoxWidth = 120;
            this.cdvFromTypeEnd.VisibleButton = true;
            this.cdvFromTypeEnd.VisibleColumnHeader = false;
            this.cdvFromTypeEnd.VisibleDescription = false;
            this.cdvFromTypeEnd.ButtonPress += new System.EventHandler(this.cdvFromType_ButtonPress);
            // 
            // cdvCModeStart
            // 
            this.cdvCModeStart.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCModeStart.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCModeStart.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCModeStart.BtnToolTipText = "";
            this.cdvCModeStart.DescText = "";
            this.cdvCModeStart.DisplaySubItemIndex = -1;
            this.cdvCModeStart.DisplayText = "";
            this.cdvCModeStart.Enabled = false;
            this.cdvCModeStart.Focusing = null;
            this.cdvCModeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCModeStart.Index = 0;
            this.cdvCModeStart.IsViewBtnImage = false;
            this.cdvCModeStart.Location = new System.Drawing.Point(360, 60);
            this.cdvCModeStart.MaxLength = 32767;
            this.cdvCModeStart.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCModeStart.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCModeStart.Name = "cdvCModeStart";
            this.cdvCModeStart.ReadOnly = true;
            this.cdvCModeStart.SearchSubItemIndex = 0;
            this.cdvCModeStart.SelectedDescIndex = -1;
            this.cdvCModeStart.SelectedSubItemIndex = -1;
            this.cdvCModeStart.SelectionStart = 0;
            this.cdvCModeStart.Size = new System.Drawing.Size(120, 20);
            this.cdvCModeStart.SmallImageList = null;
            this.cdvCModeStart.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCModeStart.TabIndex = 14;
            this.cdvCModeStart.TextBoxToolTipText = "";
            this.cdvCModeStart.TextBoxWidth = 120;
            this.cdvCModeStart.VisibleButton = true;
            this.cdvCModeStart.VisibleColumnHeader = false;
            this.cdvCModeStart.VisibleDescription = false;
            this.cdvCModeStart.ButtonPress += new System.EventHandler(this.cdvCMode_ButtonPress);
            // 
            // cdvToTypeStart
            // 
            this.cdvToTypeStart.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToTypeStart.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToTypeStart.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToTypeStart.BtnToolTipText = "";
            this.cdvToTypeStart.DescText = "";
            this.cdvToTypeStart.DisplaySubItemIndex = -1;
            this.cdvToTypeStart.DisplayText = "";
            this.cdvToTypeStart.Enabled = false;
            this.cdvToTypeStart.Focusing = null;
            this.cdvToTypeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToTypeStart.Index = 0;
            this.cdvToTypeStart.IsViewBtnImage = false;
            this.cdvToTypeStart.Location = new System.Drawing.Point(234, 60);
            this.cdvToTypeStart.MaxLength = 32767;
            this.cdvToTypeStart.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToTypeStart.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToTypeStart.Name = "cdvToTypeStart";
            this.cdvToTypeStart.ReadOnly = true;
            this.cdvToTypeStart.SearchSubItemIndex = 0;
            this.cdvToTypeStart.SelectedDescIndex = -1;
            this.cdvToTypeStart.SelectedSubItemIndex = -1;
            this.cdvToTypeStart.SelectionStart = 0;
            this.cdvToTypeStart.Size = new System.Drawing.Size(120, 20);
            this.cdvToTypeStart.SmallImageList = null;
            this.cdvToTypeStart.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToTypeStart.TabIndex = 13;
            this.cdvToTypeStart.TextBoxToolTipText = "";
            this.cdvToTypeStart.TextBoxWidth = 120;
            this.cdvToTypeStart.VisibleButton = true;
            this.cdvToTypeStart.VisibleColumnHeader = false;
            this.cdvToTypeStart.VisibleDescription = false;
            this.cdvToTypeStart.ButtonPress += new System.EventHandler(this.cdvToType_ButtonPress);
            // 
            // cdvFromTypeStart
            // 
            this.cdvFromTypeStart.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFromTypeStart.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFromTypeStart.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFromTypeStart.BtnToolTipText = "";
            this.cdvFromTypeStart.DescText = "";
            this.cdvFromTypeStart.DisplaySubItemIndex = -1;
            this.cdvFromTypeStart.DisplayText = "";
            this.cdvFromTypeStart.Enabled = false;
            this.cdvFromTypeStart.Focusing = null;
            this.cdvFromTypeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFromTypeStart.Index = 0;
            this.cdvFromTypeStart.IsViewBtnImage = false;
            this.cdvFromTypeStart.Location = new System.Drawing.Point(94, 60);
            this.cdvFromTypeStart.MaxLength = 32767;
            this.cdvFromTypeStart.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFromTypeStart.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFromTypeStart.Name = "cdvFromTypeStart";
            this.cdvFromTypeStart.ReadOnly = true;
            this.cdvFromTypeStart.SearchSubItemIndex = 0;
            this.cdvFromTypeStart.SelectedDescIndex = -1;
            this.cdvFromTypeStart.SelectedSubItemIndex = -1;
            this.cdvFromTypeStart.SelectionStart = 0;
            this.cdvFromTypeStart.Size = new System.Drawing.Size(120, 20);
            this.cdvFromTypeStart.SmallImageList = null;
            this.cdvFromTypeStart.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFromTypeStart.TabIndex = 11;
            this.cdvFromTypeStart.TextBoxToolTipText = "";
            this.cdvFromTypeStart.TextBoxWidth = 120;
            this.cdvFromTypeStart.VisibleButton = true;
            this.cdvFromTypeStart.VisibleColumnHeader = false;
            this.cdvFromTypeStart.VisibleDescription = false;
            this.cdvFromTypeStart.ButtonPress += new System.EventHandler(this.cdvFromType_ButtonPress);
            // 
            // cdvCModeAdhoc
            // 
            this.cdvCModeAdhoc.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCModeAdhoc.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCModeAdhoc.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCModeAdhoc.BtnToolTipText = "";
            this.cdvCModeAdhoc.DescText = "";
            this.cdvCModeAdhoc.DisplaySubItemIndex = -1;
            this.cdvCModeAdhoc.DisplayText = "";
            this.cdvCModeAdhoc.Enabled = false;
            this.cdvCModeAdhoc.Focusing = null;
            this.cdvCModeAdhoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCModeAdhoc.Index = 0;
            this.cdvCModeAdhoc.IsViewBtnImage = false;
            this.cdvCModeAdhoc.Location = new System.Drawing.Point(360, 36);
            this.cdvCModeAdhoc.MaxLength = 32767;
            this.cdvCModeAdhoc.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCModeAdhoc.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCModeAdhoc.Name = "cdvCModeAdhoc";
            this.cdvCModeAdhoc.ReadOnly = true;
            this.cdvCModeAdhoc.SearchSubItemIndex = 0;
            this.cdvCModeAdhoc.SelectedDescIndex = -1;
            this.cdvCModeAdhoc.SelectedSubItemIndex = -1;
            this.cdvCModeAdhoc.SelectionStart = 0;
            this.cdvCModeAdhoc.Size = new System.Drawing.Size(120, 20);
            this.cdvCModeAdhoc.SmallImageList = null;
            this.cdvCModeAdhoc.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCModeAdhoc.TabIndex = 9;
            this.cdvCModeAdhoc.TextBoxToolTipText = "";
            this.cdvCModeAdhoc.TextBoxWidth = 120;
            this.cdvCModeAdhoc.VisibleButton = true;
            this.cdvCModeAdhoc.VisibleColumnHeader = false;
            this.cdvCModeAdhoc.VisibleDescription = false;
            this.cdvCModeAdhoc.ButtonPress += new System.EventHandler(this.cdvCMode_ButtonPress);
            // 
            // cdvToTypeAdhoc
            // 
            this.cdvToTypeAdhoc.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToTypeAdhoc.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToTypeAdhoc.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToTypeAdhoc.BtnToolTipText = "";
            this.cdvToTypeAdhoc.DescText = "";
            this.cdvToTypeAdhoc.DisplaySubItemIndex = -1;
            this.cdvToTypeAdhoc.DisplayText = "";
            this.cdvToTypeAdhoc.Enabled = false;
            this.cdvToTypeAdhoc.Focusing = null;
            this.cdvToTypeAdhoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToTypeAdhoc.Index = 0;
            this.cdvToTypeAdhoc.IsViewBtnImage = false;
            this.cdvToTypeAdhoc.Location = new System.Drawing.Point(234, 36);
            this.cdvToTypeAdhoc.MaxLength = 32767;
            this.cdvToTypeAdhoc.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToTypeAdhoc.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToTypeAdhoc.Name = "cdvToTypeAdhoc";
            this.cdvToTypeAdhoc.ReadOnly = true;
            this.cdvToTypeAdhoc.SearchSubItemIndex = 0;
            this.cdvToTypeAdhoc.SelectedDescIndex = -1;
            this.cdvToTypeAdhoc.SelectedSubItemIndex = -1;
            this.cdvToTypeAdhoc.SelectionStart = 0;
            this.cdvToTypeAdhoc.Size = new System.Drawing.Size(120, 20);
            this.cdvToTypeAdhoc.SmallImageList = null;
            this.cdvToTypeAdhoc.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToTypeAdhoc.TabIndex = 8;
            this.cdvToTypeAdhoc.TextBoxToolTipText = "";
            this.cdvToTypeAdhoc.TextBoxWidth = 120;
            this.cdvToTypeAdhoc.VisibleButton = true;
            this.cdvToTypeAdhoc.VisibleColumnHeader = false;
            this.cdvToTypeAdhoc.VisibleDescription = false;
            this.cdvToTypeAdhoc.ButtonPress += new System.EventHandler(this.cdvToType_ButtonPress);
            // 
            // cdvFromTypeAdhoc
            // 
            this.cdvFromTypeAdhoc.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFromTypeAdhoc.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFromTypeAdhoc.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFromTypeAdhoc.BtnToolTipText = "";
            this.cdvFromTypeAdhoc.DescText = "";
            this.cdvFromTypeAdhoc.DisplaySubItemIndex = -1;
            this.cdvFromTypeAdhoc.DisplayText = "";
            this.cdvFromTypeAdhoc.Enabled = false;
            this.cdvFromTypeAdhoc.Focusing = null;
            this.cdvFromTypeAdhoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFromTypeAdhoc.Index = 0;
            this.cdvFromTypeAdhoc.IsViewBtnImage = false;
            this.cdvFromTypeAdhoc.Location = new System.Drawing.Point(94, 36);
            this.cdvFromTypeAdhoc.MaxLength = 32767;
            this.cdvFromTypeAdhoc.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFromTypeAdhoc.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFromTypeAdhoc.Name = "cdvFromTypeAdhoc";
            this.cdvFromTypeAdhoc.ReadOnly = true;
            this.cdvFromTypeAdhoc.SearchSubItemIndex = 0;
            this.cdvFromTypeAdhoc.SelectedDescIndex = -1;
            this.cdvFromTypeAdhoc.SelectedSubItemIndex = -1;
            this.cdvFromTypeAdhoc.SelectionStart = 0;
            this.cdvFromTypeAdhoc.Size = new System.Drawing.Size(120, 20);
            this.cdvFromTypeAdhoc.SmallImageList = null;
            this.cdvFromTypeAdhoc.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFromTypeAdhoc.TabIndex = 6;
            this.cdvFromTypeAdhoc.TextBoxToolTipText = "";
            this.cdvFromTypeAdhoc.TextBoxWidth = 120;
            this.cdvFromTypeAdhoc.VisibleButton = true;
            this.cdvFromTypeAdhoc.VisibleColumnHeader = false;
            this.cdvFromTypeAdhoc.VisibleDescription = false;
            this.cdvFromTypeAdhoc.ButtonPress += new System.EventHandler(this.cdvFromType_ButtonPress);
            // 
            // chkEnd
            // 
            this.chkEnd.AutoSize = true;
            this.chkEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEnd.Location = new System.Drawing.Point(12, 84);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(52, 17);
            this.chkEnd.TabIndex = 15;
            this.chkEnd.Text = "End";
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkEnd_CheckedChanged);
            // 
            // chkStart
            // 
            this.chkStart.AutoSize = true;
            this.chkStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStart.Location = new System.Drawing.Point(12, 60);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(55, 17);
            this.chkStart.TabIndex = 10;
            this.chkStart.Text = "Start";
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // chkAdHoc
            // 
            this.chkAdHoc.AutoSize = true;
            this.chkAdHoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAdHoc.Location = new System.Drawing.Point(12, 36);
            this.chkAdHoc.Name = "chkAdHoc";
            this.chkAdHoc.Size = new System.Drawing.Size(71, 17);
            this.chkAdHoc.TabIndex = 5;
            this.chkAdHoc.Text = "Ad Hoc";
            this.chkAdHoc.CheckedChanged += new System.EventHandler(this.chkAdHoc_CheckedChanged);
            // 
            // lblA3
            // 
            this.lblA3.AutoSize = true;
            this.lblA3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblA3.Location = new System.Drawing.Point(220, 87);
            this.lblA3.Name = "lblA3";
            this.lblA3.Size = new System.Drawing.Size(16, 13);
            this.lblA3.TabIndex = 17;
            this.lblA3.Text = "->";
            // 
            // lblA2
            // 
            this.lblA2.AutoSize = true;
            this.lblA2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblA2.Location = new System.Drawing.Point(220, 64);
            this.lblA2.Name = "lblA2";
            this.lblA2.Size = new System.Drawing.Size(16, 13);
            this.lblA2.TabIndex = 12;
            this.lblA2.Text = "->";
            // 
            // lblA1
            // 
            this.lblA1.AutoSize = true;
            this.lblA1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblA1.Location = new System.Drawing.Point(220, 40);
            this.lblA1.Name = "lblA1";
            this.lblA1.Size = new System.Drawing.Size(16, 13);
            this.lblA1.TabIndex = 7;
            this.lblA1.Text = "->";
            // 
            // lblBackGroup
            // 
            this.lblBackGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBackGroup.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblBackGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBackGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBackGroup.Location = new System.Drawing.Point(6, 15);
            this.lblBackGroup.Name = "lblBackGroup";
            this.lblBackGroup.Size = new System.Drawing.Size(480, 17);
            this.lblBackGroup.TabIndex = 0;
            // 
            // spl1
            // 
            this.spl1.Location = new System.Drawing.Point(235, 3);
            this.spl1.Name = "spl1";
            this.spl1.Size = new System.Drawing.Size(4, 474);
            this.spl1.TabIndex = 0;
            this.spl1.TabStop = false;
            // 
            // pnlMFOCond
            // 
            this.pnlMFOCond.Controls.Add(this.udcMFO);
            this.pnlMFOCond.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMFOCond.Location = new System.Drawing.Point(3, 3);
            this.pnlMFOCond.Name = "pnlMFOCond";
            this.pnlMFOCond.Size = new System.Drawing.Size(232, 474);
            this.pnlMFOCond.TabIndex = 0;
            // 
            // udcMFO
            // 
            this.udcMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMFO.IncludeFlowSeqNum = false;
            this.udcMFO.ListCond_ExtFactory = "";
            this.udcMFO.ListCond_Step = '1';
            this.udcMFO.Location = new System.Drawing.Point(0, 0);
            this.udcMFO.MaterialType = "";
            this.udcMFO.Name = "udcMFO";
            this.udcMFO.Size = new System.Drawing.Size(232, 474);
            this.udcMFO.TabIndex = 0;
            this.udcMFO.VisibleLevel1MFO = true;
            this.udcMFO.VisibleLevel2FO = true;
            this.udcMFO.VisibleLevel3O = true;
            this.udcMFO.VisibleLevel4MO = true;
            this.udcMFO.VisibleLevel5MF = false;
            this.udcMFO.VisibleLevel6M = false;
            this.udcMFO.VisibleLevel7F = false;
            this.udcMFO.VisibleLevel8Factory = false;
            this.udcMFO.VisibleMaterialIncludeDeleteCheck = false;
            this.udcMFO.VisibleMaterialType = false;
            this.udcMFO.VisibleOnlySetData = true;
            this.udcMFO.VisibleViewType = true;
            this.udcMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.udcMFO_LevelItemSelect);
            this.udcMFO.GetOnlySetData += new System.EventHandler(this.udcMFO_GetOnlySetData);
            this.udcMFO.SetDataSelectedIndexChanged += new System.EventHandler(this.udcMFO_SetDataSelectedIndexChanged);
            // 
            // tbpResource
            // 
            this.tbpResource.BackColor = System.Drawing.SystemColors.Control;
            this.tbpResource.Controls.Add(this.pnlResDetail);
            this.tbpResource.Controls.Add(this.spl2);
            this.tbpResource.Controls.Add(this.pnlResCond);
            this.tbpResource.Location = new System.Drawing.Point(4, 22);
            this.tbpResource.Name = "tbpResource";
            this.tbpResource.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResource.Size = new System.Drawing.Size(734, 480);
            this.tbpResource.TabIndex = 1;
            this.tbpResource.Text = "Resource";
            // 
            // pnlResDetail
            // 
            this.pnlResDetail.Controls.Add(this.pnlResRelation);
            this.pnlResDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResDetail.Location = new System.Drawing.Point(239, 3);
            this.pnlResDetail.Name = "pnlResDetail";
            this.pnlResDetail.Size = new System.Drawing.Size(492, 474);
            this.pnlResDetail.TabIndex = 1;
            // 
            // pnlResRelation
            // 
            this.pnlResRelation.Controls.Add(this.pnlResRelRight);
            this.pnlResRelation.Controls.Add(this.pnlResRelMid);
            this.pnlResRelation.Controls.Add(this.pnlResRelLeft);
            this.pnlResRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResRelation.Location = new System.Drawing.Point(0, 0);
            this.pnlResRelation.Name = "pnlResRelation";
            this.pnlResRelation.Size = new System.Drawing.Size(492, 474);
            this.pnlResRelation.TabIndex = 1;
            this.pnlResRelation.Resize += new System.EventHandler(this.pnlResRelation_Resize);
            // 
            // pnlResRelRight
            // 
            this.pnlResRelRight.Controls.Add(this.lisGroupList2);
            this.pnlResRelRight.Controls.Add(this.lblGroupList2);
            this.pnlResRelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlResRelRight.Location = new System.Drawing.Point(266, 0);
            this.pnlResRelRight.Name = "pnlResRelRight";
            this.pnlResRelRight.Size = new System.Drawing.Size(226, 474);
            this.pnlResRelRight.TabIndex = 0;
            // 
            // lisGroupList2
            // 
            this.lisGroupList2.AllowDrop = true;
            this.lisGroupList2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGroup2,
            this.colDesc2});
            this.lisGroupList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisGroupList2.EnableSort = true;
            this.lisGroupList2.EnableSortIcon = true;
            this.lisGroupList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisGroupList2.FullRowSelect = true;
            this.lisGroupList2.Location = new System.Drawing.Point(0, 14);
            this.lisGroupList2.Name = "lisGroupList2";
            this.lisGroupList2.Size = new System.Drawing.Size(226, 460);
            this.lisGroupList2.TabIndex = 1;
            this.lisGroupList2.UseCompatibleStateImageBehavior = false;
            this.lisGroupList2.View = System.Windows.Forms.View.Details;
            // 
            // colGroup2
            // 
            this.colGroup2.Text = "Carrier Group";
            this.colGroup2.Width = 120;
            // 
            // colDesc2
            // 
            this.colDesc2.Text = "Description";
            this.colDesc2.Width = 200;
            // 
            // lblGroupList2
            // 
            this.lblGroupList2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupList2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroupList2.Location = new System.Drawing.Point(0, 0);
            this.lblGroupList2.Name = "lblGroupList2";
            this.lblGroupList2.Size = new System.Drawing.Size(226, 14);
            this.lblGroupList2.TabIndex = 0;
            this.lblGroupList2.Text = "All Carrier Group List";
            // 
            // pnlResRelMid
            // 
            this.pnlResRelMid.Controls.Add(this.btnResCrrGrp);
            this.pnlResRelMid.Controls.Add(this.btnResUp);
            this.pnlResRelMid.Controls.Add(this.btnResDown);
            this.pnlResRelMid.Controls.Add(this.btnResDel);
            this.pnlResRelMid.Controls.Add(this.btnResAdd);
            this.pnlResRelMid.Location = new System.Drawing.Point(214, 28);
            this.pnlResRelMid.Name = "pnlResRelMid";
            this.pnlResRelMid.Size = new System.Drawing.Size(38, 292);
            this.pnlResRelMid.TabIndex = 0;
            // 
            // btnResCrrGrp
            // 
            this.btnResCrrGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResCrrGrp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResCrrGrp.Image = ((System.Drawing.Image)(resources.GetObject("btnResCrrGrp.Image")));
            this.btnResCrrGrp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResCrrGrp.Location = new System.Drawing.Point(3, 265);
            this.btnResCrrGrp.Name = "btnResCrrGrp";
            this.btnResCrrGrp.Size = new System.Drawing.Size(24, 24);
            this.btnResCrrGrp.TabIndex = 21;
            this.btnResCrrGrp.Click += new System.EventHandler(this.btnResCrrGrp_Click);
            // 
            // btnResUp
            // 
            this.btnResUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResUp.Image = ((System.Drawing.Image)(resources.GetObject("btnResUp.Image")));
            this.btnResUp.Location = new System.Drawing.Point(3, 214);
            this.btnResUp.Name = "btnResUp";
            this.btnResUp.Size = new System.Drawing.Size(24, 24);
            this.btnResUp.TabIndex = 2;
            this.btnResUp.Click += new System.EventHandler(this.btnResUp_Click);
            // 
            // btnResDown
            // 
            this.btnResDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResDown.Image = ((System.Drawing.Image)(resources.GetObject("btnResDown.Image")));
            this.btnResDown.Location = new System.Drawing.Point(3, 239);
            this.btnResDown.Name = "btnResDown";
            this.btnResDown.Size = new System.Drawing.Size(24, 24);
            this.btnResDown.TabIndex = 3;
            this.btnResDown.Click += new System.EventHandler(this.btnResDown_Click);
            // 
            // btnResDel
            // 
            this.btnResDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnResDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResDel.Location = new System.Drawing.Point(7, 149);
            this.btnResDel.Name = "btnResDel";
            this.btnResDel.Size = new System.Drawing.Size(24, 24);
            this.btnResDel.TabIndex = 1;
            this.btnResDel.Text = ">";
            this.btnResDel.Click += new System.EventHandler(this.btnResDel_Click);
            // 
            // btnResAdd
            // 
            this.btnResAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnResAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResAdd.Location = new System.Drawing.Point(7, 120);
            this.btnResAdd.Name = "btnResAdd";
            this.btnResAdd.Size = new System.Drawing.Size(24, 24);
            this.btnResAdd.TabIndex = 0;
            this.btnResAdd.Text = "<";
            this.btnResAdd.Click += new System.EventHandler(this.btnResAdd_Click);
            // 
            // pnlResRelLeft
            // 
            this.pnlResRelLeft.Controls.Add(this.lisResRel);
            this.pnlResRelLeft.Controls.Add(this.lblResAttach);
            this.pnlResRelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResRelLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlResRelLeft.Name = "pnlResRelLeft";
            this.pnlResRelLeft.Size = new System.Drawing.Size(208, 474);
            this.pnlResRelLeft.TabIndex = 0;
            // 
            // lisResRel
            // 
            this.lisResRel.AllowDrop = true;
            this.lisResRel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colResSeq,
            this.colResGroup,
            this.colResDesc});
            this.lisResRel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResRel.EnableSort = true;
            this.lisResRel.EnableSortIcon = true;
            this.lisResRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResRel.FullRowSelect = true;
            this.lisResRel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lisResRel.Location = new System.Drawing.Point(0, 14);
            this.lisResRel.Name = "lisResRel";
            this.lisResRel.Size = new System.Drawing.Size(208, 460);
            this.lisResRel.TabIndex = 1;
            this.lisResRel.UseCompatibleStateImageBehavior = false;
            this.lisResRel.View = System.Windows.Forms.View.Details;
            // 
            // colResSeq
            // 
            this.colResSeq.Text = "Seq";
            this.colResSeq.Width = 50;
            // 
            // colResGroup
            // 
            this.colResGroup.Text = "Carrier Group";
            this.colResGroup.Width = 120;
            // 
            // colResDesc
            // 
            this.colResDesc.Text = "Description";
            this.colResDesc.Width = 200;
            // 
            // lblResAttach
            // 
            this.lblResAttach.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResAttach.Location = new System.Drawing.Point(0, 0);
            this.lblResAttach.Name = "lblResAttach";
            this.lblResAttach.Size = new System.Drawing.Size(208, 14);
            this.lblResAttach.TabIndex = 0;
            this.lblResAttach.Text = "Attached Carrier Group";
            // 
            // spl2
            // 
            this.spl2.Location = new System.Drawing.Point(235, 3);
            this.spl2.Name = "spl2";
            this.spl2.Size = new System.Drawing.Size(4, 474);
            this.spl2.TabIndex = 1;
            this.spl2.TabStop = false;
            // 
            // pnlResCond
            // 
            this.pnlResCond.Controls.Add(this.pnlResCondMid);
            this.pnlResCond.Controls.Add(this.pnlResCondTop);
            this.pnlResCond.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResCond.Location = new System.Drawing.Point(3, 3);
            this.pnlResCond.Name = "pnlResCond";
            this.pnlResCond.Size = new System.Drawing.Size(232, 474);
            this.pnlResCond.TabIndex = 0;
            // 
            // pnlResCondMid
            // 
            this.pnlResCondMid.Controls.Add(this.tvResList);
            this.pnlResCondMid.Controls.Add(this.lisResList);
            this.pnlResCondMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResCondMid.Location = new System.Drawing.Point(0, 77);
            this.pnlResCondMid.Name = "pnlResCondMid";
            this.pnlResCondMid.Size = new System.Drawing.Size(232, 397);
            this.pnlResCondMid.TabIndex = 1;
            // 
            // tvResList
            // 
            this.tvResList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvResList.Location = new System.Drawing.Point(0, 0);
            this.tvResList.Name = "tvResList";
            this.tvResList.Size = new System.Drawing.Size(232, 397);
            this.tvResList.TabIndex = 0;
            this.tvResList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvResList_AfterSelect);
            // 
            // lisResList
            // 
            this.lisResList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colResID,
            this.colPortID});
            this.lisResList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResList.Location = new System.Drawing.Point(0, 0);
            this.lisResList.MultiSelect = false;
            this.lisResList.Name = "lisResList";
            this.lisResList.Size = new System.Drawing.Size(232, 397);
            this.lisResList.TabIndex = 1;
            this.lisResList.UseCompatibleStateImageBehavior = false;
            this.lisResList.View = System.Windows.Forms.View.Details;
            this.lisResList.SelectedIndexChanged += new System.EventHandler(this.lisResList_SelectedIndexChanged);
            // 
            // colResID
            // 
            this.colResID.Text = "Res ID";
            this.colResID.Width = 120;
            // 
            // colPortID
            // 
            this.colPortID.Text = "Port ID";
            this.colPortID.Width = 90;
            // 
            // pnlResCondTop
            // 
            this.pnlResCondTop.Controls.Add(this.chkOnlySettingData);
            this.pnlResCondTop.Controls.Add(this.cdvResGroup);
            this.pnlResCondTop.Controls.Add(this.lblResGroup);
            this.pnlResCondTop.Controls.Add(this.cdvResType);
            this.pnlResCondTop.Controls.Add(this.lblResType);
            this.pnlResCondTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResCondTop.Location = new System.Drawing.Point(0, 0);
            this.pnlResCondTop.Name = "pnlResCondTop";
            this.pnlResCondTop.Size = new System.Drawing.Size(232, 77);
            this.pnlResCondTop.TabIndex = 0;
            // 
            // chkOnlySettingData
            // 
            this.chkOnlySettingData.AutoSize = true;
            this.chkOnlySettingData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOnlySettingData.Location = new System.Drawing.Point(11, 54);
            this.chkOnlySettingData.Name = "chkOnlySettingData";
            this.chkOnlySettingData.Size = new System.Drawing.Size(115, 18);
            this.chkOnlySettingData.TabIndex = 4;
            this.chkOnlySettingData.Text = "Only Setting Data";
            this.chkOnlySettingData.CheckedChanged += new System.EventHandler(this.chkOnlySettingData_CheckedChanged);
            // 
            // cdvResGroup
            // 
            this.cdvResGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGroup.BtnToolTipText = "";
            this.cdvResGroup.DescText = "";
            this.cdvResGroup.DisplaySubItemIndex = -1;
            this.cdvResGroup.DisplayText = "";
            this.cdvResGroup.Focusing = null;
            this.cdvResGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGroup.Index = 0;
            this.cdvResGroup.IsViewBtnImage = false;
            this.cdvResGroup.Location = new System.Drawing.Point(107, 30);
            this.cdvResGroup.MaxLength = 20;
            this.cdvResGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGroup.Name = "cdvResGroup";
            this.cdvResGroup.ReadOnly = true;
            this.cdvResGroup.SearchSubItemIndex = 0;
            this.cdvResGroup.SelectedDescIndex = -1;
            this.cdvResGroup.SelectedSubItemIndex = -1;
            this.cdvResGroup.SelectionStart = 0;
            this.cdvResGroup.Size = new System.Drawing.Size(120, 20);
            this.cdvResGroup.SmallImageList = null;
            this.cdvResGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGroup.TabIndex = 3;
            this.cdvResGroup.TextBoxToolTipText = "";
            this.cdvResGroup.TextBoxWidth = 120;
            this.cdvResGroup.VisibleButton = true;
            this.cdvResGroup.VisibleColumnHeader = false;
            this.cdvResGroup.VisibleDescription = false;
            this.cdvResGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResGroup_SelectedItemChanged);
            this.cdvResGroup.ButtonPress += new System.EventHandler(this.cdvResGroup_ButtonPress);
            // 
            // lblResGroup
            // 
            this.lblResGroup.AutoSize = true;
            this.lblResGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGroup.Location = new System.Drawing.Point(11, 34);
            this.lblResGroup.Name = "lblResGroup";
            this.lblResGroup.Size = new System.Drawing.Size(85, 13);
            this.lblResGroup.TabIndex = 2;
            this.lblResGroup.Text = "Resource Group";
            // 
            // cdvResType
            // 
            this.cdvResType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResType.BtnToolTipText = "";
            this.cdvResType.DescText = "";
            this.cdvResType.DisplaySubItemIndex = -1;
            this.cdvResType.DisplayText = "";
            this.cdvResType.Focusing = null;
            this.cdvResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResType.Index = 0;
            this.cdvResType.IsViewBtnImage = false;
            this.cdvResType.Location = new System.Drawing.Point(107, 6);
            this.cdvResType.MaxLength = 20;
            this.cdvResType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResType.Name = "cdvResType";
            this.cdvResType.ReadOnly = true;
            this.cdvResType.SearchSubItemIndex = 0;
            this.cdvResType.SelectedDescIndex = -1;
            this.cdvResType.SelectedSubItemIndex = -1;
            this.cdvResType.SelectionStart = 0;
            this.cdvResType.Size = new System.Drawing.Size(120, 20);
            this.cdvResType.SmallImageList = null;
            this.cdvResType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResType.TabIndex = 1;
            this.cdvResType.TextBoxToolTipText = "";
            this.cdvResType.TextBoxWidth = 120;
            this.cdvResType.VisibleButton = true;
            this.cdvResType.VisibleColumnHeader = false;
            this.cdvResType.VisibleDescription = false;
            this.cdvResType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResType_SelectedItemChanged);
            this.cdvResType.ButtonPress += new System.EventHandler(this.cdvResType_ButtonPress);
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.Location = new System.Drawing.Point(11, 10);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(80, 13);
            this.lblResType.TabIndex = 0;
            this.lblResType.Text = "Resource Type";
            // 
            // frmRASSetupCarrierGroupRelation
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupCarrierGroupRelation";
            this.Text = "Carrier Group Relation Setup";
            this.Load += new System.EventHandler(this.frmRASSetupCarrierGroupRelation_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabRelation.ResumeLayout(false);
            this.tbpMFO.ResumeLayout(false);
            this.pnlMFODetail.ResumeLayout(false);
            this.pnlMFORelation.ResumeLayout(false);
            this.pnlMFORelRight.ResumeLayout(false);
            this.pnlMFORelMid.ResumeLayout(false);
            this.pnlMFORelLeft.ResumeLayout(false);
            this.pnlChange.ResumeLayout(false);
            this.grpChange.ResumeLayout(false);
            this.grpChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCModeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToTypeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromTypeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCModeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToTypeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromTypeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCModeAdhoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToTypeAdhoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromTypeAdhoc)).EndInit();
            this.pnlMFOCond.ResumeLayout(false);
            this.tbpResource.ResumeLayout(false);
            this.pnlResDetail.ResumeLayout(false);
            this.pnlResRelation.ResumeLayout(false);
            this.pnlResRelRight.ResumeLayout(false);
            this.pnlResRelMid.ResumeLayout(false);
            this.pnlResRelLeft.ResumeLayout(false);
            this.pnlResCond.ResumeLayout(false);
            this.pnlResCondMid.ResumeLayout(false);
            this.pnlResCondTop.ResumeLayout(false);
            this.pnlResCondTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRelation;
        private System.Windows.Forms.TabPage tbpMFO;
        private System.Windows.Forms.TabPage tbpResource;
        private System.Windows.Forms.Splitter spl2;
        private System.Windows.Forms.Panel pnlResCond;
        private System.Windows.Forms.Panel pnlResDetail;
        private System.Windows.Forms.Panel pnlMFODetail;
        private System.Windows.Forms.Splitter spl1;
        private System.Windows.Forms.Panel pnlMFOCond;
        private System.Windows.Forms.Panel pnlMFORelation;
        private System.Windows.Forms.Panel pnlChange;
        private Miracom.MESCore.Controls.udcMFOTreeList udcMFO;
        private System.Windows.Forms.GroupBox grpChange;
        private System.Windows.Forms.Panel pnlMFORelRight;
        private Miracom.UI.Controls.MCListView.MCListView lisGroupList1;
        private System.Windows.Forms.ColumnHeader colGroup1;
        private System.Windows.Forms.ColumnHeader colDesc1;
        private System.Windows.Forms.Label lblGroupList1;
        private System.Windows.Forms.Panel pnlMFORelMid;
        private System.Windows.Forms.Button btnMFODel;
        private System.Windows.Forms.Button btnMFOAdd;
        private System.Windows.Forms.Panel pnlMFORelLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisMFORel;
        private System.Windows.Forms.ColumnHeader colMFOSeq;
        private System.Windows.Forms.ColumnHeader colMFOGroup;
        private System.Windows.Forms.Label lblMFOAttach;
        private System.Windows.Forms.ColumnHeader colMFODesc;
        private System.Windows.Forms.Button btnMFOUp;
        private System.Windows.Forms.Button btnMFODown;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFromTypeAdhoc;
        private System.Windows.Forms.CheckBox chkEnd;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.CheckBox chkAdHoc;
        private System.Windows.Forms.Label lblA3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCModeEnd;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToTypeEnd;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFromTypeEnd;
        private System.Windows.Forms.Label lblA2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCModeStart;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToTypeStart;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFromTypeStart;
        private System.Windows.Forms.Label lblA1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCModeAdhoc;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToTypeAdhoc;
        private System.Windows.Forms.Label lblC4;
        private System.Windows.Forms.Label lblC3;
        private System.Windows.Forms.Label lblC2;
        private System.Windows.Forms.Label lblC1;
        private System.Windows.Forms.Label lblBackGroup;
        private System.Windows.Forms.Panel pnlResRelation;
        private System.Windows.Forms.Panel pnlResRelRight;
        private Miracom.UI.Controls.MCListView.MCListView lisGroupList2;
        private System.Windows.Forms.ColumnHeader colGroup2;
        private System.Windows.Forms.ColumnHeader colDesc2;
        private System.Windows.Forms.Label lblGroupList2;
        private System.Windows.Forms.Panel pnlResRelMid;
        private System.Windows.Forms.Button btnResUp;
        private System.Windows.Forms.Button btnResDown;
        private System.Windows.Forms.Button btnResDel;
        private System.Windows.Forms.Button btnResAdd;
        private System.Windows.Forms.Panel pnlResRelLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisResRel;
        private System.Windows.Forms.ColumnHeader colResSeq;
        private System.Windows.Forms.ColumnHeader colResGroup;
        private System.Windows.Forms.ColumnHeader colResDesc;
        private System.Windows.Forms.Label lblResAttach;
        private System.Windows.Forms.Panel pnlResCondMid;
        private System.Windows.Forms.Panel pnlResCondTop;
        private System.Windows.Forms.TreeView tvResList;
        private System.Windows.Forms.CheckBox chkOnlySettingData;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGroup;
        private System.Windows.Forms.Label lblResGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResType;
        private System.Windows.Forms.Label lblResType;
        private System.Windows.Forms.ListView lisResList;
        private System.Windows.Forms.ColumnHeader colResID;
        private System.Windows.Forms.ColumnHeader colPortID;
        protected System.Windows.Forms.Button btnMFORelExcel;
        protected System.Windows.Forms.Button btnResCrrGrp;
    }
}
