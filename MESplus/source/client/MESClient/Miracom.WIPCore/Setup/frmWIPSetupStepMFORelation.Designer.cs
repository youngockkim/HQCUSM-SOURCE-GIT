namespace Miracom.WIPCore
{
    partial class frmWIPSetupStepMFORelation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupStepMFORelation));
            this.tvMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.pnlGrpMid = new System.Windows.Forms.Panel();
            this.pnlGrpTop = new System.Windows.Forms.Panel();
            this.pnlGrpMidMid = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlGrpMidLeft = new System.Windows.Forms.Panel();
            this.GrpMFOStepRelation = new System.Windows.Forms.GroupBox();
            this.lisMFORel = new Miracom.UI.Controls.MCListView.MCListView();
            this.colMFOStep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAutoStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAutoEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartReq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndReq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerialProc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRSVF1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRSVF2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRSVF3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRSVF4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRSVF5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMFOStepDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlGrpMidRight = new System.Windows.Forms.Panel();
            this.GrpStepList = new System.Windows.Forms.GroupBox();
            this.lisStepList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colStep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStepDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlGrpBottom = new System.Windows.Forms.Panel();
            this.GrpOption = new System.Windows.Forms.GroupBox();
            this.lblStepResvField5 = new System.Windows.Forms.Label();
            this.lblStepResvField4 = new System.Windows.Forms.Label();
            this.lblStepResvField3 = new System.Windows.Forms.Label();
            this.lblStepResvField2 = new System.Windows.Forms.Label();
            this.lblStepResvField1 = new System.Windows.Forms.Label();
            this.txtResvField5 = new System.Windows.Forms.TextBox();
            this.txtResvField4 = new System.Windows.Forms.TextBox();
            this.txtResvField3 = new System.Windows.Forms.TextBox();
            this.txtResvField2 = new System.Windows.Forms.TextBox();
            this.txtResvField1 = new System.Windows.Forms.TextBox();
            this.chkSerialProcFlag = new System.Windows.Forms.CheckBox();
            this.chkEndReqFlag = new System.Windows.Forms.CheckBox();
            this.chkStartReqFlag = new System.Windows.Forms.CheckBox();
            this.chkAutoEndFlag = new System.Windows.Forms.CheckBox();
            this.chkAutoStartFlag = new System.Windows.Forms.CheckBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrpMid.SuspendLayout();
            this.pnlGrpTop.SuspendLayout();
            this.pnlGrpMidMid.SuspendLayout();
            this.pnlGrpMidLeft.SuspendLayout();
            this.GrpMFOStepRelation.SuspendLayout();
            this.pnlGrpMidRight.SuspendLayout();
            this.GrpStepList.SuspendLayout();
            this.pnlGrpBottom.SuspendLayout();
            this.GrpOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 6;
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
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlGrpMid);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvMFO);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(379, 7);
            this.btnCreate.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(469, 7);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(559, 7);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 5;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // tvMFO
            // 
            this.tvMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMFO.IncludeFlowSeqNum = false;
            this.tvMFO.ListCond_ExtFactory = "";
            this.tvMFO.ListCond_Step = '1';
            this.tvMFO.Location = new System.Drawing.Point(0, 0);
            this.tvMFO.MaterialType = "";
            this.tvMFO.Name = "tvMFO";
            this.tvMFO.Size = new System.Drawing.Size(232, 506);
            this.tvMFO.TabIndex = 0;
            this.tvMFO.VisibleLevel1MFO = true;
            this.tvMFO.VisibleLevel2FO = true;
            this.tvMFO.VisibleLevel3O = true;
            this.tvMFO.VisibleLevel4MO = true;
            this.tvMFO.VisibleLevel5MF = false;
            this.tvMFO.VisibleLevel6M = false;
            this.tvMFO.VisibleLevel7F = false;
            this.tvMFO.VisibleLevel8Factory = false;
            this.tvMFO.VisibleMaterialIncludeDeleteCheck = false;
            this.tvMFO.VisibleMaterialType = false;
            this.tvMFO.VisibleOnlySetData = true;
            this.tvMFO.VisibleViewType = true;
            this.tvMFO.AfterGetTree += new System.EventHandler(this.tvMFO_AfterGetTree);
            this.tvMFO.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_AfterSelect);
            this.tvMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_LevelItemSelect);
            this.tvMFO.GetOnlySetData += new System.EventHandler(this.tvMFO_GetOnlySetData);
            this.tvMFO.SetDataSelectedIndexChanged += new System.EventHandler(this.tvMFO_SetDataSelectedIndexChanged);
            // 
            // pnlGrpMid
            // 
            this.pnlGrpMid.Controls.Add(this.pnlGrpTop);
            this.pnlGrpMid.Controls.Add(this.pnlGrpBottom);
            this.pnlGrpMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrpMid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrpMid.Name = "pnlGrpMid";
            this.pnlGrpMid.Size = new System.Drawing.Size(506, 506);
            this.pnlGrpMid.TabIndex = 3;
            this.pnlGrpMid.Resize += new System.EventHandler(this.pnlGrpMid_Resize);
            // 
            // pnlGrpTop
            // 
            this.pnlGrpTop.Controls.Add(this.pnlGrpMidMid);
            this.pnlGrpTop.Controls.Add(this.pnlGrpMidLeft);
            this.pnlGrpTop.Controls.Add(this.pnlGrpMidRight);
            this.pnlGrpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrpTop.Location = new System.Drawing.Point(0, 0);
            this.pnlGrpTop.Name = "pnlGrpTop";
            this.pnlGrpTop.Size = new System.Drawing.Size(506, 316);
            this.pnlGrpTop.TabIndex = 21;
            // 
            // pnlGrpMidMid
            // 
            this.pnlGrpMidMid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrpMidMid.Controls.Add(this.btnDown);
            this.pnlGrpMidMid.Controls.Add(this.btnDel);
            this.pnlGrpMidMid.Controls.Add(this.btnUp);
            this.pnlGrpMidMid.Controls.Add(this.btnAdd);
            this.pnlGrpMidMid.Location = new System.Drawing.Point(214, 12);
            this.pnlGrpMidMid.Name = "pnlGrpMidMid";
            this.pnlGrpMidMid.Size = new System.Drawing.Size(57, 298);
            this.pnlGrpMidMid.TabIndex = 19;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(3, 262);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 9;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(16, 104);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(3, 236);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 8;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(16, 75);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // pnlGrpMidLeft
            // 
            this.pnlGrpMidLeft.Controls.Add(this.GrpMFOStepRelation);
            this.pnlGrpMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrpMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlGrpMidLeft.Name = "pnlGrpMidLeft";
            this.pnlGrpMidLeft.Size = new System.Drawing.Size(208, 316);
            this.pnlGrpMidLeft.TabIndex = 16;
            // 
            // GrpMFOStepRelation
            // 
            this.GrpMFOStepRelation.Controls.Add(this.lisMFORel);
            this.GrpMFOStepRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpMFOStepRelation.Location = new System.Drawing.Point(0, 0);
            this.GrpMFOStepRelation.Name = "GrpMFOStepRelation";
            this.GrpMFOStepRelation.Size = new System.Drawing.Size(208, 316);
            this.GrpMFOStepRelation.TabIndex = 2;
            this.GrpMFOStepRelation.TabStop = false;
            this.GrpMFOStepRelation.Text = "MFO-Step Relation";
            // 
            // lisMFORel
            // 
            this.lisMFORel.AllowDrop = true;
            this.lisMFORel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMFOStep,
            this.colAutoStart,
            this.colAutoEnd,
            this.colStartReq,
            this.colEndReq,
            this.colSerialProc,
            this.colRSVF1,
            this.colRSVF2,
            this.colRSVF3,
            this.colRSVF4,
            this.colRSVF5,
            this.colMFOStepDesc});
            this.lisMFORel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMFORel.EnableSort = true;
            this.lisMFORel.EnableSortIcon = true;
            this.lisMFORel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMFORel.FullRowSelect = true;
            this.lisMFORel.Location = new System.Drawing.Point(3, 16);
            this.lisMFORel.Name = "lisMFORel";
            this.lisMFORel.Size = new System.Drawing.Size(202, 297);
            this.lisMFORel.TabIndex = 1;
            this.lisMFORel.UseCompatibleStateImageBehavior = false;
            this.lisMFORel.View = System.Windows.Forms.View.Details;
            this.lisMFORel.SelectedIndexChanged += new System.EventHandler(this.lisMFORel_SelectedIndexChanged);
            // 
            // colMFOStep
            // 
            this.colMFOStep.Text = "Step";
            this.colMFOStep.Width = 100;
            // 
            // colAutoStart
            // 
            this.colAutoStart.Text = "Auto Start";
            this.colAutoStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAutoStart.Width = 70;
            // 
            // colAutoEnd
            // 
            this.colAutoEnd.Text = "Auto End";
            this.colAutoEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAutoEnd.Width = 70;
            // 
            // colStartReq
            // 
            this.colStartReq.Text = "Start Req";
            this.colStartReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStartReq.Width = 70;
            // 
            // colEndReq
            // 
            this.colEndReq.Text = "End Req";
            this.colEndReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colEndReq.Width = 70;
            // 
            // colSerialProc
            // 
            this.colSerialProc.Text = "Serial Proc";
            this.colSerialProc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSerialProc.Width = 70;
            // 
            // colRSVF1
            // 
            this.colRSVF1.Text = "Step Reserve Field 1";
            this.colRSVF1.Width = 100;
            // 
            // colRSVF2
            // 
            this.colRSVF2.Text = "Step Reserve Field 2";
            this.colRSVF2.Width = 100;
            // 
            // colRSVF3
            // 
            this.colRSVF3.Text = "Step Reserve Field 3";
            this.colRSVF3.Width = 100;
            // 
            // colRSVF4
            // 
            this.colRSVF4.Text = "Step Reserve Field 4";
            this.colRSVF4.Width = 100;
            // 
            // colRSVF5
            // 
            this.colRSVF5.Text = "Step Reserve Field 5";
            this.colRSVF5.Width = 100;
            // 
            // colMFOStepDesc
            // 
            this.colMFOStepDesc.Text = "Description";
            this.colMFOStepDesc.Width = 150;
            // 
            // pnlGrpMidRight
            // 
            this.pnlGrpMidRight.Controls.Add(this.GrpStepList);
            this.pnlGrpMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGrpMidRight.Location = new System.Drawing.Point(280, 0);
            this.pnlGrpMidRight.Name = "pnlGrpMidRight";
            this.pnlGrpMidRight.Size = new System.Drawing.Size(226, 316);
            this.pnlGrpMidRight.TabIndex = 18;
            // 
            // GrpStepList
            // 
            this.GrpStepList.Controls.Add(this.lisStepList);
            this.GrpStepList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpStepList.Location = new System.Drawing.Point(0, 0);
            this.GrpStepList.Name = "GrpStepList";
            this.GrpStepList.Size = new System.Drawing.Size(226, 316);
            this.GrpStepList.TabIndex = 3;
            this.GrpStepList.TabStop = false;
            this.GrpStepList.Text = "All Step List";
            // 
            // lisStepList
            // 
            this.lisStepList.AllowDrop = true;
            this.lisStepList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStep,
            this.colStepDesc});
            this.lisStepList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisStepList.EnableSort = true;
            this.lisStepList.EnableSortIcon = true;
            this.lisStepList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisStepList.FullRowSelect = true;
            this.lisStepList.Location = new System.Drawing.Point(3, 16);
            this.lisStepList.Name = "lisStepList";
            this.lisStepList.Size = new System.Drawing.Size(220, 297);
            this.lisStepList.TabIndex = 1;
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
            // pnlGrpBottom
            // 
            this.pnlGrpBottom.Controls.Add(this.GrpOption);
            this.pnlGrpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGrpBottom.Location = new System.Drawing.Point(0, 316);
            this.pnlGrpBottom.Name = "pnlGrpBottom";
            this.pnlGrpBottom.Size = new System.Drawing.Size(506, 190);
            this.pnlGrpBottom.TabIndex = 22;
            // 
            // GrpOption
            // 
            this.GrpOption.Controls.Add(this.lblStepResvField5);
            this.GrpOption.Controls.Add(this.lblStepResvField4);
            this.GrpOption.Controls.Add(this.lblStepResvField3);
            this.GrpOption.Controls.Add(this.lblStepResvField2);
            this.GrpOption.Controls.Add(this.lblStepResvField1);
            this.GrpOption.Controls.Add(this.txtResvField5);
            this.GrpOption.Controls.Add(this.txtResvField4);
            this.GrpOption.Controls.Add(this.txtResvField3);
            this.GrpOption.Controls.Add(this.txtResvField2);
            this.GrpOption.Controls.Add(this.txtResvField1);
            this.GrpOption.Controls.Add(this.chkSerialProcFlag);
            this.GrpOption.Controls.Add(this.chkEndReqFlag);
            this.GrpOption.Controls.Add(this.chkStartReqFlag);
            this.GrpOption.Controls.Add(this.chkAutoEndFlag);
            this.GrpOption.Controls.Add(this.chkAutoStartFlag);
            this.GrpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpOption.Location = new System.Drawing.Point(0, 0);
            this.GrpOption.Name = "GrpOption";
            this.GrpOption.Size = new System.Drawing.Size(506, 190);
            this.GrpOption.TabIndex = 0;
            this.GrpOption.TabStop = false;
            this.GrpOption.Text = "Option";
            // 
            // lblStepResvField5
            // 
            this.lblStepResvField5.AutoSize = true;
            this.lblStepResvField5.Location = new System.Drawing.Point(14, 164);
            this.lblStepResvField5.Name = "lblStepResvField5";
            this.lblStepResvField5.Size = new System.Drawing.Size(106, 13);
            this.lblStepResvField5.TabIndex = 14;
            this.lblStepResvField5.Text = "Step Reserve Field 5";
            // 
            // lblStepResvField4
            // 
            this.lblStepResvField4.AutoSize = true;
            this.lblStepResvField4.Location = new System.Drawing.Point(14, 140);
            this.lblStepResvField4.Name = "lblStepResvField4";
            this.lblStepResvField4.Size = new System.Drawing.Size(106, 13);
            this.lblStepResvField4.TabIndex = 13;
            this.lblStepResvField4.Text = "Step Reserve Field 4";
            // 
            // lblStepResvField3
            // 
            this.lblStepResvField3.AutoSize = true;
            this.lblStepResvField3.Location = new System.Drawing.Point(14, 116);
            this.lblStepResvField3.Name = "lblStepResvField3";
            this.lblStepResvField3.Size = new System.Drawing.Size(106, 13);
            this.lblStepResvField3.TabIndex = 12;
            this.lblStepResvField3.Text = "Step Reserve Field 3";
            // 
            // lblStepResvField2
            // 
            this.lblStepResvField2.AutoSize = true;
            this.lblStepResvField2.Location = new System.Drawing.Point(14, 92);
            this.lblStepResvField2.Name = "lblStepResvField2";
            this.lblStepResvField2.Size = new System.Drawing.Size(106, 13);
            this.lblStepResvField2.TabIndex = 11;
            this.lblStepResvField2.Text = "Step Reserve Field 2";
            // 
            // lblStepResvField1
            // 
            this.lblStepResvField1.AutoSize = true;
            this.lblStepResvField1.Location = new System.Drawing.Point(14, 68);
            this.lblStepResvField1.Name = "lblStepResvField1";
            this.lblStepResvField1.Size = new System.Drawing.Size(106, 13);
            this.lblStepResvField1.TabIndex = 10;
            this.lblStepResvField1.Text = "Step Reserve Field 1";
            // 
            // txtResvField5
            // 
            this.txtResvField5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResvField5.Location = new System.Drawing.Point(131, 161);
            this.txtResvField5.MaxLength = 50;
            this.txtResvField5.Name = "txtResvField5";
            this.txtResvField5.Size = new System.Drawing.Size(361, 20);
            this.txtResvField5.TabIndex = 9;
            // 
            // txtResvField4
            // 
            this.txtResvField4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResvField4.Location = new System.Drawing.Point(131, 137);
            this.txtResvField4.MaxLength = 50;
            this.txtResvField4.Name = "txtResvField4";
            this.txtResvField4.Size = new System.Drawing.Size(361, 20);
            this.txtResvField4.TabIndex = 8;
            // 
            // txtResvField3
            // 
            this.txtResvField3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResvField3.Location = new System.Drawing.Point(131, 113);
            this.txtResvField3.MaxLength = 50;
            this.txtResvField3.Name = "txtResvField3";
            this.txtResvField3.Size = new System.Drawing.Size(361, 20);
            this.txtResvField3.TabIndex = 7;
            // 
            // txtResvField2
            // 
            this.txtResvField2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResvField2.Location = new System.Drawing.Point(131, 89);
            this.txtResvField2.MaxLength = 50;
            this.txtResvField2.Name = "txtResvField2";
            this.txtResvField2.Size = new System.Drawing.Size(361, 20);
            this.txtResvField2.TabIndex = 6;
            // 
            // txtResvField1
            // 
            this.txtResvField1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResvField1.Location = new System.Drawing.Point(131, 65);
            this.txtResvField1.MaxLength = 50;
            this.txtResvField1.Name = "txtResvField1";
            this.txtResvField1.Size = new System.Drawing.Size(361, 20);
            this.txtResvField1.TabIndex = 5;
            // 
            // chkSerialProcFlag
            // 
            this.chkSerialProcFlag.AutoSize = true;
            this.chkSerialProcFlag.Location = new System.Drawing.Point(376, 23);
            this.chkSerialProcFlag.Name = "chkSerialProcFlag";
            this.chkSerialProcFlag.Size = new System.Drawing.Size(114, 16);
            this.chkSerialProcFlag.TabIndex = 2;
            this.chkSerialProcFlag.Text = "Serial Proc Flag";
            this.chkSerialProcFlag.UseVisualStyleBackColor = true;
            // 
            // chkEndReqFlag
            // 
            this.chkEndReqFlag.AutoSize = true;
            this.chkEndReqFlag.Location = new System.Drawing.Point(198, 42);
            this.chkEndReqFlag.Name = "chkEndReqFlag";
            this.chkEndReqFlag.Size = new System.Drawing.Size(129, 16);
            this.chkEndReqFlag.TabIndex = 4;
            this.chkEndReqFlag.Text = "Step End Required";
            this.chkEndReqFlag.UseVisualStyleBackColor = true;
            // 
            // chkStartReqFlag
            // 
            this.chkStartReqFlag.AutoSize = true;
            this.chkStartReqFlag.Location = new System.Drawing.Point(14, 42);
            this.chkStartReqFlag.Name = "chkStartReqFlag";
            this.chkStartReqFlag.Size = new System.Drawing.Size(132, 16);
            this.chkStartReqFlag.TabIndex = 3;
            this.chkStartReqFlag.Text = "Step Start Required";
            this.chkStartReqFlag.UseVisualStyleBackColor = true;
            // 
            // chkAutoEndFlag
            // 
            this.chkAutoEndFlag.AutoSize = true;
            this.chkAutoEndFlag.Location = new System.Drawing.Point(198, 23);
            this.chkAutoEndFlag.Name = "chkAutoEndFlag";
            this.chkAutoEndFlag.Size = new System.Drawing.Size(178, 16);
            this.chkAutoEndFlag.TabIndex = 1;
            this.chkAutoEndFlag.Text = "Auto End By Operation End";
            this.chkAutoEndFlag.UseVisualStyleBackColor = true;
            // 
            // chkAutoStartFlag
            // 
            this.chkAutoStartFlag.AutoSize = true;
            this.chkAutoStartFlag.Location = new System.Drawing.Point(14, 23);
            this.chkAutoStartFlag.Name = "chkAutoStartFlag";
            this.chkAutoStartFlag.Size = new System.Drawing.Size(184, 16);
            this.chkAutoStartFlag.TabIndex = 0;
            this.chkAutoStartFlag.Text = "Auto Start By Operation Start";
            this.chkAutoStartFlag.UseVisualStyleBackColor = true;
            // 
            // frmWIPSetupStepMFORelation
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupStepMFORelation";
            this.Text = "Step MFO Relation Setup";
            this.Load += new System.EventHandler(this.frmWIPSetupStepMFORelation_Load);
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
            this.pnlGrpMid.ResumeLayout(false);
            this.pnlGrpTop.ResumeLayout(false);
            this.pnlGrpMidMid.ResumeLayout(false);
            this.pnlGrpMidLeft.ResumeLayout(false);
            this.GrpMFOStepRelation.ResumeLayout(false);
            this.pnlGrpMidRight.ResumeLayout(false);
            this.GrpStepList.ResumeLayout(false);
            this.pnlGrpBottom.ResumeLayout(false);
            this.GrpOption.ResumeLayout(false);
            this.GrpOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.MESCore.Controls.udcMFOTreeList tvMFO;
        private System.Windows.Forms.Panel pnlGrpMid;
        private System.Windows.Forms.Panel pnlGrpMidRight;
        private Miracom.UI.Controls.MCListView.MCListView lisStepList;
        private System.Windows.Forms.ColumnHeader colStep;
        private System.Windows.Forms.ColumnHeader colStepDesc;
        private System.Windows.Forms.Panel pnlGrpMidLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisMFORel;
        private System.Windows.Forms.ColumnHeader colMFOStep;
        private System.Windows.Forms.ColumnHeader colMFOStepDesc;
        private System.Windows.Forms.GroupBox GrpStepList;
        private System.Windows.Forms.Panel pnlGrpMidMid;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox GrpMFOStepRelation;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ColumnHeader colAutoStart;
        private System.Windows.Forms.ColumnHeader colAutoEnd;
        private System.Windows.Forms.ColumnHeader colStartReq;
        private System.Windows.Forms.ColumnHeader colEndReq;
        private System.Windows.Forms.ColumnHeader colSerialProc;
        private System.Windows.Forms.Panel pnlGrpBottom;
        private System.Windows.Forms.GroupBox GrpOption;
        private System.Windows.Forms.CheckBox chkSerialProcFlag;
        private System.Windows.Forms.CheckBox chkEndReqFlag;
        private System.Windows.Forms.CheckBox chkStartReqFlag;
        private System.Windows.Forms.CheckBox chkAutoEndFlag;
        private System.Windows.Forms.CheckBox chkAutoStartFlag;
        private System.Windows.Forms.Panel pnlGrpTop;
        private System.Windows.Forms.TextBox txtResvField5;
        private System.Windows.Forms.TextBox txtResvField4;
        private System.Windows.Forms.TextBox txtResvField3;
        private System.Windows.Forms.TextBox txtResvField2;
        private System.Windows.Forms.TextBox txtResvField1;
        private System.Windows.Forms.Label lblStepResvField1;
        private System.Windows.Forms.Label lblStepResvField5;
        private System.Windows.Forms.Label lblStepResvField4;
        private System.Windows.Forms.Label lblStepResvField3;
        private System.Windows.Forms.Label lblStepResvField2;
        private System.Windows.Forms.ColumnHeader colRSVF1;
        private System.Windows.Forms.ColumnHeader colRSVF2;
        private System.Windows.Forms.ColumnHeader colRSVF3;
        private System.Windows.Forms.ColumnHeader colRSVF4;
        private System.Windows.Forms.ColumnHeader colRSVF5;

    }
}
