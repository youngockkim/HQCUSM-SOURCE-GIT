namespace Miracom.WIPCore
{
    partial class frmWIPSetupAttachQARule
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
            this.pnlGrpMid = new System.Windows.Forms.Panel();
            this.pnlGrpMidRight = new System.Windows.Forms.Panel();
            this.lisQARuleList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupList = new System.Windows.Forms.Label();
            this.pnlGrpMidMid = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlGrpMidLeft = new System.Windows.Forms.Panel();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.lisQARule = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroup = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrpMid.SuspendLayout();
            this.pnlGrpMidRight.SuspendLayout();
            this.pnlGrpMidMid.SuspendLayout();
            this.pnlGrpMidLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
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
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlGrpMid);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvMFO);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(558, 8);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
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
            this.tvMFO.Size = new System.Drawing.Size(232, 513);
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
            this.tvMFO.VisibleOnlySetData = false;
            this.tvMFO.VisibleViewType = true;
            this.tvMFO.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_AfterSelect);
            this.tvMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_LevelItemSelect);
            this.tvMFO.GetOnlySetData += new System.EventHandler(this.tvMFO_GetOnlySetData);
            this.tvMFO.SetDataSelectedIndexChanged += new System.EventHandler(this.tvMFO_SetDataSelectedIndexChanged);
            // 
            // pnlGrpMid
            // 
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidRight);
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidMid);
            this.pnlGrpMid.Controls.Add(this.pnlGrpMidLeft);
            this.pnlGrpMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrpMid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrpMid.Name = "pnlGrpMid";
            this.pnlGrpMid.Size = new System.Drawing.Size(506, 513);
            this.pnlGrpMid.TabIndex = 3;
            this.pnlGrpMid.Resize += new System.EventHandler(this.pnlGrpMid_Resize);
            // 
            // pnlGrpMidRight
            // 
            this.pnlGrpMidRight.Controls.Add(this.lisQARuleList);
            this.pnlGrpMidRight.Controls.Add(this.lblGroupList);
            this.pnlGrpMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGrpMidRight.Location = new System.Drawing.Point(280, 0);
            this.pnlGrpMidRight.Name = "pnlGrpMidRight";
            this.pnlGrpMidRight.Size = new System.Drawing.Size(226, 513);
            this.pnlGrpMidRight.TabIndex = 18;
            // 
            // lisQARuleList
            // 
            this.lisQARuleList.AllowDrop = true;
            this.lisQARuleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisQARuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisQARuleList.EnableSort = true;
            this.lisQARuleList.EnableSortIcon = true;
            this.lisQARuleList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisQARuleList.FullRowSelect = true;
            this.lisQARuleList.Location = new System.Drawing.Point(0, 14);
            this.lisQARuleList.Name = "lisQARuleList";
            this.lisQARuleList.Size = new System.Drawing.Size(226, 499);
            this.lisQARuleList.TabIndex = 1;
            this.lisQARuleList.UseCompatibleStateImageBehavior = false;
            this.lisQARuleList.View = System.Windows.Forms.View.Details;
            this.lisQARuleList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisQARuleList_ItemDrag);
            this.lisQARuleList.Click += new System.EventHandler(this.lisQARuleList_Click);
            this.lisQARuleList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisQARuleList_DragDrop);
            this.lisQARuleList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisQARuleList_DragEnter);
            this.lisQARuleList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisQARuleList_MouseDown);
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "QA Rule";
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
            this.lblGroupList.Text = "All QA Rule List";
            // 
            // pnlGrpMidMid
            // 
            this.pnlGrpMidMid.Controls.Add(this.btnDel);
            this.pnlGrpMidMid.Controls.Add(this.btnAdd);
            this.pnlGrpMidMid.Location = new System.Drawing.Point(231, 203);
            this.pnlGrpMidMid.Name = "pnlGrpMidMid";
            this.pnlGrpMidMid.Size = new System.Drawing.Size(38, 108);
            this.pnlGrpMidMid.TabIndex = 17;
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
            this.pnlGrpMidLeft.Controls.Add(this.cdvType);
            this.pnlGrpMidLeft.Controls.Add(this.lblType);
            this.pnlGrpMidLeft.Controls.Add(this.lisQARule);
            this.pnlGrpMidLeft.Controls.Add(this.lblGroup);
            this.pnlGrpMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrpMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlGrpMidLeft.Name = "pnlGrpMidLeft";
            this.pnlGrpMidLeft.Size = new System.Drawing.Size(208, 513);
            this.pnlGrpMidLeft.TabIndex = 16;
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(70, 14);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(132, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 3;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 132;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvType_SelectedItemChanged);
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Location = new System.Drawing.Point(6, 17);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(56, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Rule Type";
            // 
            // lisQARule
            // 
            this.lisQARule.AllowDrop = true;
            this.lisQARule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader13,
            this.ColumnHeader14});
            this.lisQARule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisQARule.EnableSort = true;
            this.lisQARule.EnableSortIcon = true;
            this.lisQARule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisQARule.FullRowSelect = true;
            this.lisQARule.Location = new System.Drawing.Point(0, 37);
            this.lisQARule.Name = "lisQARule";
            this.lisQARule.Size = new System.Drawing.Size(208, 476);
            this.lisQARule.TabIndex = 1;
            this.lisQARule.UseCompatibleStateImageBehavior = false;
            this.lisQARule.View = System.Windows.Forms.View.Details;
            this.lisQARule.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisQARule_ItemDrag);
            this.lisQARule.Click += new System.EventHandler(this.lisQARule_Click);
            this.lisQARule.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisQARule_DragDrop);
            this.lisQARule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisQARule_MouseDown);
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "QA Rule";
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
            this.lblGroup.Size = new System.Drawing.Size(208, 37);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "MFO - QA Rule Relation";
            // 
            // frmWIPSetupAttachQARule
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPSetupAttachQARule";
            this.Text = "Attach QA Rule to MFO";
            this.Load += new System.EventHandler(this.frmWIPSetupAttachQARule_Load);
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
            this.pnlGrpMidRight.ResumeLayout(false);
            this.pnlGrpMidMid.ResumeLayout(false);
            this.pnlGrpMidLeft.ResumeLayout(false);
            this.pnlGrpMidLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.MESCore.Controls.udcMFOTreeList tvMFO;
        private System.Windows.Forms.Panel pnlGrpMid;
        private System.Windows.Forms.Panel pnlGrpMidRight;
        private Miracom.UI.Controls.MCListView.MCListView lisQARuleList;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.ColumnHeader ColumnHeader16;
        private System.Windows.Forms.Label lblGroupList;
        private System.Windows.Forms.Panel pnlGrpMidMid;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlGrpMidLeft;
        private Miracom.UI.Controls.MCListView.MCListView lisQARule;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private System.Windows.Forms.Label lblGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Label lblType;

    }
}
