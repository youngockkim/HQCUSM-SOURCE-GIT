namespace Miracom.WIPCore
{
    partial class frmWIPSetupBatchCreationRuleRelation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupBatchCreationRuleRelation));
            this.tabRule = new System.Windows.Forms.TabControl();
            this.tbpResource = new System.Windows.Forms.TabPage();
            this.grpTran = new System.Windows.Forms.GroupBox();
            this.cdvCreateRule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRule = new System.Windows.Forms.Label();
            this.lisRule = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spLeft = new System.Windows.Forms.Splitter();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.tvResList = new System.Windows.Forms.TreeView();
            this.lisResList = new System.Windows.Forms.ListView();
            this.colFactory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlLevel = new System.Windows.Forms.Panel();
            this.grpResSelLevel = new System.Windows.Forms.GroupBox();
            this.chkOnlySettingData = new System.Windows.Forms.CheckBox();
            this.rbtResGroup = new System.Windows.Forms.RadioButton();
            this.rbtResType = new System.Windows.Forms.RadioButton();
            this.tbpRule = new System.Windows.Forms.TabPage();
            this.pnlGrpMid = new System.Windows.Forms.Panel();
            this.pnlGrpMidRight = new System.Windows.Forms.Panel();
            this.lisRuleResource = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupList = new System.Windows.Forms.Label();
            this.pnlGrpMidMid = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlGrpMidLeft = new System.Windows.Forms.Panel();
            this.lisRuleRelation = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroup = new System.Windows.Forms.Label();
            this.pnlRuleLevel = new System.Windows.Forms.Panel();
            this.grpRuleLevel = new System.Windows.Forms.GroupBox();
            this.rbtRuleResource = new System.Windows.Forms.RadioButton();
            this.rbtRuleResGroup = new System.Windows.Forms.RadioButton();
            this.rbtRuleResType = new System.Windows.Forms.RadioButton();
            this.spRuleLeft = new System.Windows.Forms.Splitter();
            this.pnlRuleLeft = new System.Windows.Forms.Panel();
            this.lisBatchRule = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnResExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabRule.SuspendLayout();
            this.tbpResource.SuspendLayout();
            this.grpTran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateRule)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlLevel.SuspendLayout();
            this.grpResSelLevel.SuspendLayout();
            this.tbpRule.SuspendLayout();
            this.pnlGrpMid.SuspendLayout();
            this.pnlGrpMidRight.SuspendLayout();
            this.pnlGrpMidMid.SuspendLayout();
            this.pnlGrpMidLeft.SuspendLayout();
            this.pnlRuleLevel.SuspendLayout();
            this.grpRuleLevel.SuspendLayout();
            this.pnlRuleLeft.SuspendLayout();
            this.SuspendLayout();
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
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabRule);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // tabRule
            // 
            this.tabRule.Controls.Add(this.tbpResource);
            this.tabRule.Controls.Add(this.tbpRule);
            this.tabRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRule.Location = new System.Drawing.Point(3, 3);
            this.tabRule.Name = "tabRule";
            this.tabRule.SelectedIndex = 0;
            this.tabRule.Size = new System.Drawing.Size(736, 503);
            this.tabRule.TabIndex = 0;
            // 
            // tbpResource
            // 
            this.tbpResource.Controls.Add(this.grpTran);
            this.tbpResource.Controls.Add(this.lisRule);
            this.tbpResource.Controls.Add(this.spLeft);
            this.tbpResource.Controls.Add(this.pnlLeft);
            this.tbpResource.Location = new System.Drawing.Point(4, 22);
            this.tbpResource.Name = "tbpResource";
            this.tbpResource.Padding = new System.Windows.Forms.Padding(3);
            this.tbpResource.Size = new System.Drawing.Size(728, 477);
            this.tbpResource.TabIndex = 0;
            this.tbpResource.Text = "Resource";
            // 
            // grpTran
            // 
            this.grpTran.Controls.Add(this.cdvCreateRule);
            this.grpTran.Controls.Add(this.lblRule);
            this.grpTran.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTran.Location = new System.Drawing.Point(226, 106);
            this.grpTran.Name = "grpTran";
            this.grpTran.Size = new System.Drawing.Size(499, 175);
            this.grpTran.TabIndex = 7;
            this.grpTran.TabStop = false;
            // 
            // cdvCreateRule
            // 
            this.cdvCreateRule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateRule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateRule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateRule.BtnToolTipText = "";
            this.cdvCreateRule.DescText = "";
            this.cdvCreateRule.DisplaySubItemIndex = -1;
            this.cdvCreateRule.DisplayText = "";
            this.cdvCreateRule.Focusing = null;
            this.cdvCreateRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateRule.Index = 0;
            this.cdvCreateRule.IsViewBtnImage = false;
            this.cdvCreateRule.Location = new System.Drawing.Point(116, 20);
            this.cdvCreateRule.MaxLength = 20;
            this.cdvCreateRule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateRule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateRule.Name = "cdvCreateRule";
            this.cdvCreateRule.ReadOnly = false;
            this.cdvCreateRule.SearchSubItemIndex = 0;
            this.cdvCreateRule.SelectedDescIndex = -1;
            this.cdvCreateRule.SelectedSubItemIndex = -1;
            this.cdvCreateRule.SelectionStart = 0;
            this.cdvCreateRule.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateRule.SmallImageList = null;
            this.cdvCreateRule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateRule.TabIndex = 9;
            this.cdvCreateRule.TextBoxToolTipText = "";
            this.cdvCreateRule.TextBoxWidth = 180;
            this.cdvCreateRule.VisibleButton = true;
            this.cdvCreateRule.VisibleColumnHeader = false;
            this.cdvCreateRule.VisibleDescription = false;
            this.cdvCreateRule.ButtonPress += new System.EventHandler(this.cdvCreateRule_ButtonPress);
            // 
            // lblRule
            // 
            this.lblRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRule.Location = new System.Drawing.Point(13, 23);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new System.Drawing.Size(99, 14);
            this.lblRule.TabIndex = 8;
            this.lblRule.Text = "Creation Rule ID";
            this.lblRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisRule
            // 
            this.lisRule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader4});
            this.lisRule.Dock = System.Windows.Forms.DockStyle.Top;
            this.lisRule.EnableSort = true;
            this.lisRule.EnableSortIcon = true;
            this.lisRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRule.FullRowSelect = true;
            this.lisRule.Location = new System.Drawing.Point(226, 3);
            this.lisRule.MultiSelect = false;
            this.lisRule.Name = "lisRule";
            this.lisRule.Size = new System.Drawing.Size(499, 103);
            this.lisRule.TabIndex = 6;
            this.lisRule.UseCompatibleStateImageBehavior = false;
            this.lisRule.View = System.Windows.Forms.View.Details;
            this.lisRule.SelectedIndexChanged += new System.EventHandler(this.lisRule_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Creation Rule ID";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 200;
            // 
            // spLeft
            // 
            this.spLeft.Location = new System.Drawing.Point(222, 3);
            this.spLeft.Name = "spLeft";
            this.spLeft.Size = new System.Drawing.Size(4, 471);
            this.spLeft.TabIndex = 1;
            this.spLeft.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvResList);
            this.pnlLeft.Controls.Add(this.lisResList);
            this.pnlLeft.Controls.Add(this.pnlLevel);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(219, 471);
            this.pnlLeft.TabIndex = 0;
            // 
            // tvResList
            // 
            this.tvResList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvResList.Location = new System.Drawing.Point(0, 99);
            this.tvResList.Name = "tvResList";
            this.tvResList.Size = new System.Drawing.Size(219, 372);
            this.tvResList.TabIndex = 14;
            this.tvResList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvResList_AfterSelect);
            // 
            // lisResList
            // 
            this.lisResList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFactory,
            this.colResType,
            this.colResGroup,
            this.colResID});
            this.lisResList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResList.Location = new System.Drawing.Point(0, 99);
            this.lisResList.MultiSelect = false;
            this.lisResList.Name = "lisResList";
            this.lisResList.Size = new System.Drawing.Size(219, 372);
            this.lisResList.TabIndex = 13;
            this.lisResList.UseCompatibleStateImageBehavior = false;
            this.lisResList.View = System.Windows.Forms.View.Details;
            this.lisResList.SelectedIndexChanged += new System.EventHandler(this.lisResList_SelectedIndexChanged);
            // 
            // colFactory
            // 
            this.colFactory.Text = "Factory";
            // 
            // colResType
            // 
            this.colResType.Text = "Res Type";
            // 
            // colResGroup
            // 
            this.colResGroup.Text = "Res Group";
            // 
            // colResID
            // 
            this.colResID.Text = "Res ID";
            // 
            // pnlLevel
            // 
            this.pnlLevel.Controls.Add(this.grpResSelLevel);
            this.pnlLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLevel.Location = new System.Drawing.Point(0, 0);
            this.pnlLevel.Name = "pnlLevel";
            this.pnlLevel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.pnlLevel.Size = new System.Drawing.Size(219, 99);
            this.pnlLevel.TabIndex = 0;
            // 
            // grpResSelLevel
            // 
            this.grpResSelLevel.Controls.Add(this.chkOnlySettingData);
            this.grpResSelLevel.Controls.Add(this.rbtResGroup);
            this.grpResSelLevel.Controls.Add(this.rbtResType);
            this.grpResSelLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResSelLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResSelLevel.Location = new System.Drawing.Point(3, 0);
            this.grpResSelLevel.Name = "grpResSelLevel";
            this.grpResSelLevel.Size = new System.Drawing.Size(216, 96);
            this.grpResSelLevel.TabIndex = 11;
            this.grpResSelLevel.TabStop = false;
            this.grpResSelLevel.Text = "Level Select";
            // 
            // chkOnlySettingData
            // 
            this.chkOnlySettingData.AutoSize = true;
            this.chkOnlySettingData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOnlySettingData.Location = new System.Drawing.Point(15, 58);
            this.chkOnlySettingData.Name = "chkOnlySettingData";
            this.chkOnlySettingData.Size = new System.Drawing.Size(115, 18);
            this.chkOnlySettingData.TabIndex = 6;
            this.chkOnlySettingData.Text = "Only Setting Data";
            this.chkOnlySettingData.CheckedChanged += new System.EventHandler(this.chkOnlySettingData_CheckedChanged);
            // 
            // rbtResGroup
            // 
            this.rbtResGroup.AutoSize = true;
            this.rbtResGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtResGroup.Location = new System.Drawing.Point(15, 40);
            this.rbtResGroup.Name = "rbtResGroup";
            this.rbtResGroup.Size = new System.Drawing.Size(137, 18);
            this.rbtResGroup.TabIndex = 5;
            this.rbtResGroup.Text = "Res Group - Resource";
            this.rbtResGroup.CheckedChanged += new System.EventHandler(this.rbtResSelLevel_CheckedChanged);
            // 
            // rbtResType
            // 
            this.rbtResType.AutoSize = true;
            this.rbtResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtResType.Location = new System.Drawing.Point(15, 21);
            this.rbtResType.Name = "rbtResType";
            this.rbtResType.Size = new System.Drawing.Size(132, 18);
            this.rbtResType.TabIndex = 3;
            this.rbtResType.Text = "Res Type - Resource";
            this.rbtResType.CheckedChanged += new System.EventHandler(this.rbtResSelLevel_CheckedChanged);
            // 
            // tbpRule
            // 
            this.tbpRule.Controls.Add(this.pnlGrpMid);
            this.tbpRule.Controls.Add(this.pnlRuleLevel);
            this.tbpRule.Controls.Add(this.spRuleLeft);
            this.tbpRule.Controls.Add(this.pnlRuleLeft);
            this.tbpRule.Location = new System.Drawing.Point(4, 22);
            this.tbpRule.Name = "tbpRule";
            this.tbpRule.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRule.Size = new System.Drawing.Size(728, 477);
            this.tbpRule.TabIndex = 1;
            this.tbpRule.Text = "Rule";
            // 
            // pnlGrpMid
            // 
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidRight);
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidMid);
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidLeft);
            this.pnlGrpMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrpMid.Location = new System.Drawing.Point(229, 102);
            this.pnlGrpMid.Name = "pnlGrpMid";
            this.pnlGrpMid.Size = new System.Drawing.Size(496, 372);
            this.pnlGrpMid.TabIndex = 4;
            this.pnlGrpMid.Resize += new System.EventHandler(this.pnlGrpMid_Resize);
            // 
            // pnlGrpMidRight
            // 
            this.pnlGrpMidRight.Controls.Add(this.lisRuleResource);
            this.pnlGrpMidRight.Controls.Add(this.lblGroupList);
            this.pnlGrpMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGrpMidRight.Location = new System.Drawing.Point(270, 0);
            this.pnlGrpMidRight.Name = "pnlGrpMidRight";
            this.pnlGrpMidRight.Size = new System.Drawing.Size(226, 372);
            this.pnlGrpMidRight.TabIndex = 18;
            // 
            // lisRuleResource
            // 
            this.lisRuleResource.AllowDrop = true;
            this.lisRuleResource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisRuleResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRuleResource.EnableSort = true;
            this.lisRuleResource.EnableSortIcon = true;
            this.lisRuleResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRuleResource.FullRowSelect = true;
            this.lisRuleResource.Location = new System.Drawing.Point(0, 14);
            this.lisRuleResource.Name = "lisRuleResource";
            this.lisRuleResource.Size = new System.Drawing.Size(226, 358);
            this.lisRuleResource.TabIndex = 1;
            this.lisRuleResource.UseCompatibleStateImageBehavior = false;
            this.lisRuleResource.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "Resource";
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
            this.lblGroupList.Text = "All Resource List";
            // 
            // pnlGrpMidMid
            // 
            this.pnlGrpMidMid.Controls.Add(this.btnResExcel);
            this.pnlGrpMidMid.Controls.Add(this.btnDel);
            this.pnlGrpMidMid.Controls.Add(this.btnAdd);
            this.pnlGrpMidMid.Location = new System.Drawing.Point(220, 125);
            this.pnlGrpMidMid.Name = "pnlGrpMidMid";
            this.pnlGrpMidMid.Size = new System.Drawing.Size(38, 168);
            this.pnlGrpMidMid.TabIndex = 16;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(7, 87);
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
            this.btnAdd.Location = new System.Drawing.Point(7, 58);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlGrpMidLeft
            // 
            this.pnlGrpMidLeft.Controls.Add(this.lisRuleRelation);
            this.pnlGrpMidLeft.Controls.Add(this.lblGroup);
            this.pnlGrpMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrpMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlGrpMidLeft.Name = "pnlGrpMidLeft";
            this.pnlGrpMidLeft.Size = new System.Drawing.Size(208, 372);
            this.pnlGrpMidLeft.TabIndex = 15;
            // 
            // lisRuleRelation
            // 
            this.lisRuleRelation.AllowDrop = true;
            this.lisRuleRelation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader13,
            this.ColumnHeader14});
            this.lisRuleRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRuleRelation.EnableSort = true;
            this.lisRuleRelation.EnableSortIcon = true;
            this.lisRuleRelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRuleRelation.FullRowSelect = true;
            this.lisRuleRelation.Location = new System.Drawing.Point(0, 14);
            this.lisRuleRelation.Name = "lisRuleRelation";
            this.lisRuleRelation.Size = new System.Drawing.Size(208, 358);
            this.lisRuleRelation.TabIndex = 1;
            this.lisRuleRelation.UseCompatibleStateImageBehavior = false;
            this.lisRuleRelation.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Resource";
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
            this.lblGroup.Text = "Batch Creation Rule Relation";
            // 
            // pnlRuleLevel
            // 
            this.pnlRuleLevel.Controls.Add(this.grpRuleLevel);
            this.pnlRuleLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRuleLevel.Location = new System.Drawing.Point(229, 3);
            this.pnlRuleLevel.Name = "pnlRuleLevel";
            this.pnlRuleLevel.Padding = new System.Windows.Forms.Padding(3);
            this.pnlRuleLevel.Size = new System.Drawing.Size(496, 99);
            this.pnlRuleLevel.TabIndex = 3;
            // 
            // grpRuleLevel
            // 
            this.grpRuleLevel.Controls.Add(this.rbtRuleResource);
            this.grpRuleLevel.Controls.Add(this.rbtRuleResGroup);
            this.grpRuleLevel.Controls.Add(this.rbtRuleResType);
            this.grpRuleLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRuleLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRuleLevel.Location = new System.Drawing.Point(3, 3);
            this.grpRuleLevel.Name = "grpRuleLevel";
            this.grpRuleLevel.Size = new System.Drawing.Size(490, 93);
            this.grpRuleLevel.TabIndex = 12;
            this.grpRuleLevel.TabStop = false;
            this.grpRuleLevel.Text = "Level Select";
            // 
            // rbtRuleResource
            // 
            this.rbtRuleResource.AutoSize = true;
            this.rbtRuleResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtRuleResource.Location = new System.Drawing.Point(16, 21);
            this.rbtRuleResource.Name = "rbtRuleResource";
            this.rbtRuleResource.Size = new System.Drawing.Size(77, 18);
            this.rbtRuleResource.TabIndex = 1;
            this.rbtRuleResource.Text = "Resource";
            this.rbtRuleResource.CheckedChanged += new System.EventHandler(this.rbtRuleResource_CheckedChanged);
            // 
            // rbtRuleResGroup
            // 
            this.rbtRuleResGroup.AutoSize = true;
            this.rbtRuleResGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtRuleResGroup.Location = new System.Drawing.Point(16, 69);
            this.rbtRuleResGroup.Name = "rbtRuleResGroup";
            this.rbtRuleResGroup.Size = new System.Drawing.Size(112, 18);
            this.rbtRuleResGroup.TabIndex = 3;
            this.rbtRuleResGroup.Text = "Resource Group ";
            this.rbtRuleResGroup.CheckedChanged += new System.EventHandler(this.rbtRuleResGroup_CheckedChanged);
            // 
            // rbtRuleResType
            // 
            this.rbtRuleResType.AutoSize = true;
            this.rbtRuleResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtRuleResType.Location = new System.Drawing.Point(16, 45);
            this.rbtRuleResType.Name = "rbtRuleResType";
            this.rbtRuleResType.Size = new System.Drawing.Size(104, 18);
            this.rbtRuleResType.TabIndex = 2;
            this.rbtRuleResType.Text = "Resource Type";
            this.rbtRuleResType.CheckedChanged += new System.EventHandler(this.rbtRuleResType_CheckedChanged);
            // 
            // spRuleLeft
            // 
            this.spRuleLeft.Location = new System.Drawing.Point(225, 3);
            this.spRuleLeft.Name = "spRuleLeft";
            this.spRuleLeft.Size = new System.Drawing.Size(4, 471);
            this.spRuleLeft.TabIndex = 2;
            this.spRuleLeft.TabStop = false;
            // 
            // pnlRuleLeft
            // 
            this.pnlRuleLeft.Controls.Add(this.lisBatchRule);
            this.pnlRuleLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRuleLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlRuleLeft.Name = "pnlRuleLeft";
            this.pnlRuleLeft.Size = new System.Drawing.Size(222, 471);
            this.pnlRuleLeft.TabIndex = 0;
            // 
            // lisBatchRule
            // 
            this.lisBatchRule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader37,
            this.columnHeader38});
            this.lisBatchRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisBatchRule.EnableSort = true;
            this.lisBatchRule.EnableSortIcon = true;
            this.lisBatchRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisBatchRule.FullRowSelect = true;
            this.lisBatchRule.Location = new System.Drawing.Point(0, 0);
            this.lisBatchRule.MultiSelect = false;
            this.lisBatchRule.Name = "lisBatchRule";
            this.lisBatchRule.Size = new System.Drawing.Size(222, 471);
            this.lisBatchRule.TabIndex = 3;
            this.lisBatchRule.UseCompatibleStateImageBehavior = false;
            this.lisBatchRule.View = System.Windows.Forms.View.Details;
            this.lisBatchRule.SelectedIndexChanged += new System.EventHandler(this.lisBatchRule_SelectedIndexChanged);
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Creation Rule ID";
            this.columnHeader37.Width = 100;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Description";
            this.columnHeader38.Width = 120;
            // 
            // btnResExcel
            // 
            this.btnResExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnResExcel.Image")));
            this.btnResExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResExcel.Location = new System.Drawing.Point(0, 144);
            this.btnResExcel.Name = "btnResExcel";
            this.btnResExcel.Size = new System.Drawing.Size(24, 24);
            this.btnResExcel.TabIndex = 18;
            this.btnResExcel.Click += new System.EventHandler(this.btnResExcel_Click);
            // 
            // frmWIPSetupBatchCreationRuleRelation
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupBatchCreationRuleRelation";
            this.Text = "Batch Creation Rule Relation Setup";
            this.Load += new System.EventHandler(this.frmWIPSetupBatchCreationRuleRelation_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabRule.ResumeLayout(false);
            this.tbpResource.ResumeLayout(false);
            this.grpTran.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateRule)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLevel.ResumeLayout(false);
            this.grpResSelLevel.ResumeLayout(false);
            this.grpResSelLevel.PerformLayout();
            this.tbpRule.ResumeLayout(false);
            this.pnlGrpMid.ResumeLayout(false);
            this.pnlGrpMidRight.ResumeLayout(false);
            this.pnlGrpMidMid.ResumeLayout(false);
            this.pnlGrpMidLeft.ResumeLayout(false);
            this.pnlRuleLevel.ResumeLayout(false);
            this.grpRuleLevel.ResumeLayout(false);
            this.grpRuleLevel.PerformLayout();
            this.pnlRuleLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRule;
        private System.Windows.Forms.TabPage tbpResource;
        private System.Windows.Forms.TabPage tbpRule;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlLevel;
        private System.Windows.Forms.GroupBox grpResSelLevel;
        private System.Windows.Forms.CheckBox chkOnlySettingData;
        private System.Windows.Forms.RadioButton rbtResGroup;
        private System.Windows.Forms.RadioButton rbtResType;
        private System.Windows.Forms.ListView lisResList;
        private System.Windows.Forms.ColumnHeader colFactory;
        private System.Windows.Forms.ColumnHeader colResType;
        private System.Windows.Forms.ColumnHeader colResGroup;
        private System.Windows.Forms.ColumnHeader colResID;
        private System.Windows.Forms.TreeView tvResList;
        private System.Windows.Forms.Splitter spLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisRule;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox grpTran;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateRule;
        private System.Windows.Forms.Label lblRule;
        private System.Windows.Forms.Panel pnlRuleLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisBatchRule;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.Splitter spRuleLeft;
        private System.Windows.Forms.Panel pnlRuleLevel;
        private System.Windows.Forms.GroupBox grpRuleLevel;
        private System.Windows.Forms.RadioButton rbtRuleResource;
        private System.Windows.Forms.RadioButton rbtRuleResGroup;
        private System.Windows.Forms.RadioButton rbtRuleResType;
        private System.Windows.Forms.Panel pnlGrpMid;
        private System.Windows.Forms.Panel pnlGrpMidRight;
        private Miracom.UI.Controls.MCListView.MCListView lisRuleResource;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.ColumnHeader ColumnHeader16;
        private System.Windows.Forms.Label lblGroupList;
        private System.Windows.Forms.Panel pnlGrpMidMid;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlGrpMidLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisRuleRelation;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private System.Windows.Forms.Label lblGroup;
        protected System.Windows.Forms.Button btnResExcel;



    }
}
