namespace Miracom.RASCore
{
    partial class frmRASSetupResourceMFORelation
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
            this.tvMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.tabOption = new System.Windows.Forms.TabControl();
            this.tbpResourceGroup = new System.Windows.Forms.TabPage();
            this.pnlGrpMid = new System.Windows.Forms.Panel();
            this.pnlGrpMidRight = new System.Windows.Forms.Panel();
            this.lisGroupList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupList = new System.Windows.Forms.Label();
            this.pnlGrpMidMid = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlGrpMidLeft = new System.Windows.Forms.Panel();
            this.lisMFORel1 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroup = new System.Windows.Forms.Label();
            this.tbpResource = new System.Windows.Forms.TabPage();
            this.pnlResMid = new System.Windows.Forms.Panel();
            this.pnlResMidRight = new System.Windows.Forms.Panel();
            this.lisResourceList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResList = new System.Windows.Forms.Label();
            this.pnlResMidMid = new System.Windows.Forms.Panel();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.pnlResMidLeft = new System.Windows.Forms.Panel();
            this.lisMFORel2 = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblRes = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.tbpResourceGroup.SuspendLayout();
            this.pnlGrpMid.SuspendLayout();
            this.pnlGrpMidRight.SuspendLayout();
            this.pnlGrpMidMid.SuspendLayout();
            this.pnlGrpMidLeft.SuspendLayout();
            this.tbpResource.SuspendLayout();
            this.pnlResMid.SuspendLayout();
            this.pnlResMidRight.SuspendLayout();
            this.pnlResMidMid.SuspendLayout();
            this.pnlResMidLeft.SuspendLayout();
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
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tabOption);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvMFO);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
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
            // tabOption
            // 
            this.tabOption.Controls.Add(this.tbpResourceGroup);
            this.tabOption.Controls.Add(this.tbpResource);
            this.tabOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOption.Location = new System.Drawing.Point(0, 0);
            this.tabOption.Name = "tabOption";
            this.tabOption.SelectedIndex = 0;
            this.tabOption.Size = new System.Drawing.Size(506, 506);
            this.tabOption.TabIndex = 0;
            this.tabOption.SelectedIndexChanged += new System.EventHandler(this.tabOption_SelectedIndexChanged);
            // 
            // tbpResourceGroup
            // 
            this.tbpResourceGroup.BackColor = System.Drawing.SystemColors.Control;
            this.tbpResourceGroup.Controls.Add(this.pnlGrpMid);
            this.tbpResourceGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpResourceGroup.Name = "tbpResourceGroup";
            this.tbpResourceGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResourceGroup.Size = new System.Drawing.Size(498, 480);
            this.tbpResourceGroup.TabIndex = 0;
            this.tbpResourceGroup.Text = "Resource Group";
            // 
            // pnlGrpMid
            // 
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidRight);
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidMid);
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidLeft);
            this.pnlGrpMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrpMid.Location = new System.Drawing.Point(3, 3);
            this.pnlGrpMid.Name = "pnlGrpMid";
            this.pnlGrpMid.Size = new System.Drawing.Size(492, 474);
            this.pnlGrpMid.TabIndex = 2;
            this.pnlGrpMid.Resize += new System.EventHandler(this.pnlGrpMid_Resize);
            // 
            // pnlGrpMidRight
            // 
            this.pnlGrpMidRight.Controls.Add(this.lisGroupList);
            this.pnlGrpMidRight.Controls.Add(this.lblGroupList);
            this.pnlGrpMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGrpMidRight.Location = new System.Drawing.Point(266, 0);
            this.pnlGrpMidRight.Name = "pnlGrpMidRight";
            this.pnlGrpMidRight.Size = new System.Drawing.Size(226, 474);
            this.pnlGrpMidRight.TabIndex = 18;
            // 
            // lisGroupList
            // 
            this.lisGroupList.AllowDrop = true;
            this.lisGroupList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisGroupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisGroupList.EnableSort = true;
            this.lisGroupList.EnableSortIcon = true;
            this.lisGroupList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisGroupList.FullRowSelect = true;
            this.lisGroupList.Location = new System.Drawing.Point(0, 14);
            this.lisGroupList.Name = "lisGroupList";
            this.lisGroupList.Size = new System.Drawing.Size(226, 460);
            this.lisGroupList.TabIndex = 1;
            this.lisGroupList.UseCompatibleStateImageBehavior = false;
            this.lisGroupList.View = System.Windows.Forms.View.Details;
            this.lisGroupList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisGroupList_ItemDrag);
            this.lisGroupList.Click += new System.EventHandler(this.lisGroupList_Click);
            this.lisGroupList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisGroupList_DragDrop);
            this.lisGroupList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisGroupList_DragEnter);
            this.lisGroupList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisGroupList_MouseDown);
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "Resource Group";
            this.ColumnHeader15.Width = 100;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.Text = "Description";
            this.ColumnHeader16.Width = 150;
            // 
            // lblGroupList
            // 
            this.lblGroupList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroupList.Location = new System.Drawing.Point(0, 0);
            this.lblGroupList.Name = "lblGroupList";
            this.lblGroupList.Size = new System.Drawing.Size(226, 14);
            this.lblGroupList.TabIndex = 0;
            this.lblGroupList.Text = "All Resource Group List";
            // 
            // pnlGrpMidMid
            // 
            this.pnlGrpMidMid.Controls.Add(this.btnDel);
            this.pnlGrpMidMid.Controls.Add(this.btnAdd);
            this.pnlGrpMidMid.Location = new System.Drawing.Point(216, 36);
            this.pnlGrpMidMid.Name = "pnlGrpMidMid";
            this.pnlGrpMidMid.Size = new System.Drawing.Size(38, 108);
            this.pnlGrpMidMid.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(7, 57);
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
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(7, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlGrpMidLeft
            // 
            this.pnlGrpMidLeft.Controls.Add(this.lisMFORel1);
            this.pnlGrpMidLeft.Controls.Add(this.lblGroup);
            this.pnlGrpMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrpMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlGrpMidLeft.Name = "pnlGrpMidLeft";
            this.pnlGrpMidLeft.Size = new System.Drawing.Size(208, 474);
            this.pnlGrpMidLeft.TabIndex = 16;
            // 
            // lisMFORel1
            // 
            this.lisMFORel1.AllowDrop = true;
            this.lisMFORel1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader13,
            this.ColumnHeader14});
            this.lisMFORel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMFORel1.EnableSort = true;
            this.lisMFORel1.EnableSortIcon = true;
            this.lisMFORel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMFORel1.FullRowSelect = true;
            this.lisMFORel1.Location = new System.Drawing.Point(0, 14);
            this.lisMFORel1.Name = "lisMFORel1";
            this.lisMFORel1.Size = new System.Drawing.Size(208, 460);
            this.lisMFORel1.TabIndex = 1;
            this.lisMFORel1.UseCompatibleStateImageBehavior = false;
            this.lisMFORel1.View = System.Windows.Forms.View.Details;
            this.lisMFORel1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisMFORel1_ItemDrag);
            this.lisMFORel1.Click += new System.EventHandler(this.lisMFORel1_Click);
            this.lisMFORel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisMFORel1_DragDrop);
            this.lisMFORel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisMFORel1_DragEnter);
            this.lisMFORel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisMFORel1_MouseDown);
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Resource Group";
            this.ColumnHeader13.Width = 100;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Description";
            this.ColumnHeader14.Width = 150;
            // 
            // lblGroup
            // 
            this.lblGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup.Location = new System.Drawing.Point(0, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(208, 14);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "MFO - Resource Group Relation";
            // 
            // tbpResource
            // 
            this.tbpResource.BackColor = System.Drawing.SystemColors.Control;
            this.tbpResource.Controls.Add(this.pnlResMid);
            this.tbpResource.Location = new System.Drawing.Point(4, 22);
            this.tbpResource.Name = "tbpResource";
            this.tbpResource.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResource.Size = new System.Drawing.Size(498, 480);
            this.tbpResource.TabIndex = 1;
            this.tbpResource.Text = "Resource";
            // 
            // pnlResMid
            // 
            this.pnlResMid.Controls.Add(this.pnlResMidRight);
            this.pnlResMid.Controls.Add(this.pnlResMidMid);
            this.pnlResMid.Controls.Add(this.pnlResMidLeft);
            this.pnlResMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResMid.Location = new System.Drawing.Point(3, 3);
            this.pnlResMid.Name = "pnlResMid";
            this.pnlResMid.Size = new System.Drawing.Size(492, 474);
            this.pnlResMid.TabIndex = 2;
            this.pnlResMid.Resize += new System.EventHandler(this.pnlResMid_Resize);
            // 
            // pnlResMidRight
            // 
            this.pnlResMidRight.Controls.Add(this.lisResourceList);
            this.pnlResMidRight.Controls.Add(this.lblResList);
            this.pnlResMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlResMidRight.Location = new System.Drawing.Point(294, 0);
            this.pnlResMidRight.Name = "pnlResMidRight";
            this.pnlResMidRight.Size = new System.Drawing.Size(198, 474);
            this.pnlResMidRight.TabIndex = 18;
            // 
            // lisResourceList
            // 
            this.lisResourceList.AllowDrop = true;
            this.lisResourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader9,
            this.ColumnHeader10});
            this.lisResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResourceList.EnableSort = true;
            this.lisResourceList.EnableSortIcon = true;
            this.lisResourceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResourceList.FullRowSelect = true;
            this.lisResourceList.Location = new System.Drawing.Point(0, 14);
            this.lisResourceList.Name = "lisResourceList";
            this.lisResourceList.Size = new System.Drawing.Size(198, 460);
            this.lisResourceList.TabIndex = 16;
            this.lisResourceList.UseCompatibleStateImageBehavior = false;
            this.lisResourceList.View = System.Windows.Forms.View.Details;
            this.lisResourceList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisResourceList_ItemDrag);
            this.lisResourceList.Click += new System.EventHandler(this.lisResourceList_Click);
            this.lisResourceList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisResourceList_DragDrop);
            this.lisResourceList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisResourceList_DragEnter);
            this.lisResourceList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisResourceList_MouseDown);
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Resource";
            this.ColumnHeader9.Width = 100;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Description";
            this.ColumnHeader10.Width = 150;
            // 
            // lblResList
            // 
            this.lblResList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResList.Location = new System.Drawing.Point(0, 0);
            this.lblResList.Name = "lblResList";
            this.lblResList.Size = new System.Drawing.Size(198, 14);
            this.lblResList.TabIndex = 14;
            this.lblResList.Text = "All Resource List";
            // 
            // pnlResMidMid
            // 
            this.pnlResMidMid.Controls.Add(this.btnDetach);
            this.pnlResMidMid.Controls.Add(this.btnAttach);
            this.pnlResMidMid.Location = new System.Drawing.Point(240, 54);
            this.pnlResMidMid.Name = "pnlResMidMid";
            this.pnlResMidMid.Size = new System.Drawing.Size(34, 126);
            this.pnlResMidMid.TabIndex = 17;
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetach.Location = new System.Drawing.Point(5, 66);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 17;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(5, 37);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 16;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // pnlResMidLeft
            // 
            this.pnlResMidLeft.Controls.Add(this.lisMFORel2);
            this.pnlResMidLeft.Controls.Add(this.lblRes);
            this.pnlResMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlResMidLeft.Name = "pnlResMidLeft";
            this.pnlResMidLeft.Size = new System.Drawing.Size(220, 474);
            this.pnlResMidLeft.TabIndex = 16;
            // 
            // lisMFORel2
            // 
            this.lisMFORel2.AllowDrop = true;
            this.lisMFORel2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader11,
            this.ColumnHeader12});
            this.lisMFORel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMFORel2.EnableSort = true;
            this.lisMFORel2.EnableSortIcon = true;
            this.lisMFORel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMFORel2.FullRowSelect = true;
            this.lisMFORel2.Location = new System.Drawing.Point(0, 14);
            this.lisMFORel2.Name = "lisMFORel2";
            this.lisMFORel2.Size = new System.Drawing.Size(220, 460);
            this.lisMFORel2.TabIndex = 15;
            this.lisMFORel2.UseCompatibleStateImageBehavior = false;
            this.lisMFORel2.View = System.Windows.Forms.View.Details;
            this.lisMFORel2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisMFORel2_ItemDrag);
            this.lisMFORel2.Click += new System.EventHandler(this.lisMFORel2_Click);
            this.lisMFORel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisMFORel2_DragDrop);
            this.lisMFORel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisMFORel2_DragEnter);
            this.lisMFORel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisMFORel2_MouseDown);
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Resource";
            this.ColumnHeader11.Width = 100;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Description";
            this.ColumnHeader12.Width = 150;
            // 
            // lblRes
            // 
            this.lblRes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRes.Location = new System.Drawing.Point(0, 0);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(220, 14);
            this.lblRes.TabIndex = 13;
            this.lblRes.Text = "MFO - Resource Relation";
            // 
            // frmRASSetupResourceMFORelation
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupResourceMFORelation";
            this.Text = "Resource MFO Relation Setup";
            this.Load += new System.EventHandler(this.frmRASSetupResourceMFORelation_Load);
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
            this.tabOption.ResumeLayout(false);
            this.tbpResourceGroup.ResumeLayout(false);
            this.pnlGrpMid.ResumeLayout(false);
            this.pnlGrpMidRight.ResumeLayout(false);
            this.pnlGrpMidMid.ResumeLayout(false);
            this.pnlGrpMidLeft.ResumeLayout(false);
            this.tbpResource.ResumeLayout(false);
            this.pnlResMid.ResumeLayout(false);
            this.pnlResMidRight.ResumeLayout(false);
            this.pnlResMidMid.ResumeLayout(false);
            this.pnlResMidLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.MESCore.Controls.udcMFOTreeList tvMFO;
        private System.Windows.Forms.TabControl tabOption;
        private System.Windows.Forms.TabPage tbpResourceGroup;
        private System.Windows.Forms.TabPage tbpResource;
        private System.Windows.Forms.Panel pnlGrpMid;
        private System.Windows.Forms.Panel pnlGrpMidRight;
        private Miracom.UI.Controls.MCListView.MCListView lisGroupList;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.ColumnHeader ColumnHeader16;
        private System.Windows.Forms.Label lblGroupList;
        private System.Windows.Forms.Panel pnlGrpMidMid;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlGrpMidLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisMFORel1;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Panel pnlResMid;
        private System.Windows.Forms.Panel pnlResMidRight;
        private Miracom.UI.Controls.MCListView.MCListView lisResourceList;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.Label lblResList;
        private System.Windows.Forms.Panel pnlResMidMid;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Panel pnlResMidLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisMFORel2;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.Label lblRes;

    }
}
