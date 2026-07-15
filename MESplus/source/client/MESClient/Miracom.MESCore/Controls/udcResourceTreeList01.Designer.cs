namespace Miracom.MESCore.Controls
{
    partial class udcResourceTreeList01
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMainTop = new System.Windows.Forms.Panel();
            this.grpRsourceIncludeDelete = new System.Windows.Forms.GroupBox();
            this.pnlResourceDeleteCondition = new System.Windows.Forms.Panel();
            this.chkIncludeDeletedResource = new System.Windows.Forms.CheckBox();
            this.grpLevel = new System.Windows.Forms.GroupBox();
            this.pnlSetData = new System.Windows.Forms.Panel();
            this.chkSetData = new System.Windows.Forms.CheckBox();
            this.pnlResType = new System.Windows.Forms.Panel();
            this.rbtResType = new System.Windows.Forms.RadioButton();
            this.pnlResGrp = new System.Windows.Forms.Panel();
            this.rbtResGrp = new System.Windows.Forms.RadioButton();
            this.pnlRes = new System.Windows.Forms.Panel();
            this.rbtRes = new System.Windows.Forms.RadioButton();
            this.pnlMainMid = new System.Windows.Forms.Panel();
            this.pnlResourceList = new System.Windows.Forms.Panel();
            this.treResourceList = new System.Windows.Forms.TreeView();
            this.lisResList = new System.Windows.Forms.ListView();
            this.colFactory = new System.Windows.Forms.ColumnHeader();
            this.colResType = new System.Windows.Forms.ColumnHeader();
            this.colResGroup = new System.Windows.Forms.ColumnHeader();
            this.colResID = new System.Windows.Forms.ColumnHeader();
            this.lisList = new Miracom.UI.Controls.MCListView.MCListView();
            this.pnlMainTop.SuspendLayout();
            this.grpRsourceIncludeDelete.SuspendLayout();
            this.pnlResourceDeleteCondition.SuspendLayout();
            this.grpLevel.SuspendLayout();
            this.pnlSetData.SuspendLayout();
            this.pnlResType.SuspendLayout();
            this.pnlResGrp.SuspendLayout();
            this.pnlRes.SuspendLayout();
            this.pnlMainMid.SuspendLayout();
            this.pnlResourceList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainTop
            // 
            this.pnlMainTop.Controls.Add(this.grpRsourceIncludeDelete);
            this.pnlMainTop.Controls.Add(this.grpLevel);
            this.pnlMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTop.Name = "pnlMainTop";
            this.pnlMainTop.Size = new System.Drawing.Size(232, 132);
            this.pnlMainTop.TabIndex = 0;
            // 
            // grpRsourceIncludeDelete
            // 
            this.grpRsourceIncludeDelete.Controls.Add(this.pnlResourceDeleteCondition);
            this.grpRsourceIncludeDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRsourceIncludeDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRsourceIncludeDelete.Location = new System.Drawing.Point(0, 96);
            this.grpRsourceIncludeDelete.Name = "grpRsourceIncludeDelete";
            this.grpRsourceIncludeDelete.Size = new System.Drawing.Size(232, 36);
            this.grpRsourceIncludeDelete.TabIndex = 1;
            this.grpRsourceIncludeDelete.TabStop = false;
            // 
            // pnlResourceDeleteCondition
            // 
            this.pnlResourceDeleteCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResourceDeleteCondition.Controls.Add(this.chkIncludeDeletedResource);
            this.pnlResourceDeleteCondition.Location = new System.Drawing.Point(3, 10);
            this.pnlResourceDeleteCondition.Name = "pnlResourceDeleteCondition";
            this.pnlResourceDeleteCondition.Size = new System.Drawing.Size(226, 20);
            this.pnlResourceDeleteCondition.TabIndex = 0;
            // 
            // chkIncludeDeletedResource
            // 
            this.chkIncludeDeletedResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDeletedResource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIncludeDeletedResource.Location = new System.Drawing.Point(12, 1);
            this.chkIncludeDeletedResource.Name = "chkIncludeDeletedResource";
            this.chkIncludeDeletedResource.Size = new System.Drawing.Size(209, 16);
            this.chkIncludeDeletedResource.TabIndex = 0;
            this.chkIncludeDeletedResource.Text = "Include Deleted Resource";
            this.chkIncludeDeletedResource.CheckedChanged += new System.EventHandler(this.chkIncludeResource_CheckedChanged);
            // 
            // grpLevel
            // 
            this.grpLevel.Controls.Add(this.pnlSetData);
            this.grpLevel.Controls.Add(this.pnlResType);
            this.grpLevel.Controls.Add(this.pnlResGrp);
            this.grpLevel.Controls.Add(this.pnlRes);
            this.grpLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLevel.Location = new System.Drawing.Point(0, 0);
            this.grpLevel.Name = "grpLevel";
            this.grpLevel.Size = new System.Drawing.Size(232, 96);
            this.grpLevel.TabIndex = 0;
            this.grpLevel.TabStop = false;
            this.grpLevel.Text = "Level Select";
            // 
            // pnlSetData
            // 
            this.pnlSetData.Controls.Add(this.chkSetData);
            this.pnlSetData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetData.Location = new System.Drawing.Point(3, 74);
            this.pnlSetData.Name = "pnlSetData";
            this.pnlSetData.Size = new System.Drawing.Size(226, 20);
            this.pnlSetData.TabIndex = 3;
            // 
            // chkSetData
            // 
            this.chkSetData.AutoSize = true;
            this.chkSetData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSetData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSetData.Location = new System.Drawing.Point(12, 1);
            this.chkSetData.Name = "chkSetData";
            this.chkSetData.Size = new System.Drawing.Size(107, 17);
            this.chkSetData.TabIndex = 0;
            this.chkSetData.Text = "Only Set Data";
            this.chkSetData.CheckedChanged += new System.EventHandler(this.chkSetData_CheckedChanged);
            // 
            // pnlResType
            // 
            this.pnlResType.Controls.Add(this.rbtResType);
            this.pnlResType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResType.Location = new System.Drawing.Point(3, 55);
            this.pnlResType.Name = "pnlResType";
            this.pnlResType.Size = new System.Drawing.Size(226, 19);
            this.pnlResType.TabIndex = 2;
            // 
            // rbtResType
            // 
            this.rbtResType.AutoSize = true;
            this.rbtResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtResType.Location = new System.Drawing.Point(12, 1);
            this.rbtResType.Name = "rbtResType";
            this.rbtResType.Size = new System.Drawing.Size(116, 17);
            this.rbtResType.TabIndex = 0;
            this.rbtResType.Text = "Resource Type";
            this.rbtResType.CheckedChanged += new System.EventHandler(this.Resource_Level_CheckedChanged);
            // 
            // pnlResGrp
            // 
            this.pnlResGrp.Controls.Add(this.rbtResGrp);
            this.pnlResGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResGrp.Location = new System.Drawing.Point(3, 36);
            this.pnlResGrp.Name = "pnlResGrp";
            this.pnlResGrp.Size = new System.Drawing.Size(226, 19);
            this.pnlResGrp.TabIndex = 1;
            // 
            // rbtResGrp
            // 
            this.rbtResGrp.AutoSize = true;
            this.rbtResGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtResGrp.Location = new System.Drawing.Point(12, 1);
            this.rbtResGrp.Name = "rbtResGrp";
            this.rbtResGrp.Size = new System.Drawing.Size(121, 17);
            this.rbtResGrp.TabIndex = 0;
            this.rbtResGrp.Text = "Resource Group";
            this.rbtResGrp.CheckedChanged += new System.EventHandler(this.Resource_Level_CheckedChanged);
            // 
            // pnlRes
            // 
            this.pnlRes.Controls.Add(this.rbtRes);
            this.pnlRes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRes.Location = new System.Drawing.Point(3, 17);
            this.pnlRes.Name = "pnlRes";
            this.pnlRes.Size = new System.Drawing.Size(226, 19);
            this.pnlRes.TabIndex = 0;
            // 
            // rbtRes
            // 
            this.rbtRes.AutoSize = true;
            this.rbtRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtRes.Location = new System.Drawing.Point(12, 1);
            this.rbtRes.Name = "rbtRes";
            this.rbtRes.Size = new System.Drawing.Size(83, 17);
            this.rbtRes.TabIndex = 0;
            this.rbtRes.Text = "Resource";
            this.rbtRes.CheckedChanged += new System.EventHandler(this.Resource_Level_CheckedChanged);
            // 
            // pnlMainMid
            // 
            this.pnlMainMid.Controls.Add(this.pnlResourceList);
            this.pnlMainMid.Controls.Add(this.lisList);
            this.pnlMainMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMid.Location = new System.Drawing.Point(0, 132);
            this.pnlMainMid.Name = "pnlMainMid";
            this.pnlMainMid.Size = new System.Drawing.Size(232, 348);
            this.pnlMainMid.TabIndex = 2;
            // 
            // pnlResourceList
            // 
            this.pnlResourceList.Controls.Add(this.treResourceList);
            this.pnlResourceList.Controls.Add(this.lisResList);
            this.pnlResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResourceList.Location = new System.Drawing.Point(0, 0);
            this.pnlResourceList.Name = "pnlResourceList";
            this.pnlResourceList.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlResourceList.Size = new System.Drawing.Size(232, 348);
            this.pnlResourceList.TabIndex = 0;
            // 
            // treResourceList
            // 
            this.treResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treResourceList.Location = new System.Drawing.Point(0, 3);
            this.treResourceList.Name = "treResourceList";
            this.treResourceList.Size = new System.Drawing.Size(232, 345);
            this.treResourceList.TabIndex = 0;
            this.treResourceList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treResourceList_AfterSelect);
            this.treResourceList.FontChanged += new System.EventHandler(this.treResourceList_FontChanged);
            // 
            // lisResList
            // 
            this.lisResList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFactory,
            this.colResType,
            this.colResGroup,
            this.colResID});
            this.lisResList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResList.Location = new System.Drawing.Point(0, 3);
            this.lisResList.MultiSelect = false;
            this.lisResList.Name = "lisResList";
            this.lisResList.Size = new System.Drawing.Size(232, 345);
            this.lisResList.TabIndex = 2;
            this.lisResList.UseCompatibleStateImageBehavior = false;
            this.lisResList.View = System.Windows.Forms.View.Details;
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
            // lisList
            // 
            this.lisList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisList.EnableSort = true;
            this.lisList.EnableSortIcon = true;
            this.lisList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisList.FullRowSelect = true;
            this.lisList.Location = new System.Drawing.Point(0, 0);
            this.lisList.MultiSelect = false;
            this.lisList.Name = "lisList";
            this.lisList.Size = new System.Drawing.Size(232, 348);
            this.lisList.TabIndex = 1;
            this.lisList.UseCompatibleStateImageBehavior = false;
            this.lisList.View = System.Windows.Forms.View.Details;
            this.lisList.SelectedIndexChanged += new System.EventHandler(this.lisList_SelectedIndexChanged);
            // 
            // udcResourceTreeList01
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlMainMid);
            this.Controls.Add(this.pnlMainTop);
            this.Name = "udcResourceTreeList01";
            this.Size = new System.Drawing.Size(232, 480);
            this.pnlMainTop.ResumeLayout(false);
            this.grpRsourceIncludeDelete.ResumeLayout(false);
            this.pnlResourceDeleteCondition.ResumeLayout(false);
            this.grpLevel.ResumeLayout(false);
            this.pnlSetData.ResumeLayout(false);
            this.pnlSetData.PerformLayout();
            this.pnlResType.ResumeLayout(false);
            this.pnlResType.PerformLayout();
            this.pnlResGrp.ResumeLayout(false);
            this.pnlResGrp.PerformLayout();
            this.pnlRes.ResumeLayout(false);
            this.pnlRes.PerformLayout();
            this.pnlMainMid.ResumeLayout(false);
            this.pnlResourceList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainTop;
        private System.Windows.Forms.GroupBox grpRsourceIncludeDelete;
        private System.Windows.Forms.Panel pnlResourceDeleteCondition;
        private System.Windows.Forms.CheckBox chkIncludeDeletedResource;
        private System.Windows.Forms.GroupBox grpLevel;
        private System.Windows.Forms.Panel pnlResType;
        private System.Windows.Forms.Panel pnlResGrp;
        private System.Windows.Forms.Panel pnlRes;
        private System.Windows.Forms.Panel pnlMainMid;
        private System.Windows.Forms.Panel pnlResourceList;
        private System.Windows.Forms.TreeView treResourceList;
        private Miracom.UI.Controls.MCListView.MCListView lisList;
        private System.Windows.Forms.RadioButton rbtRes;
        private System.Windows.Forms.RadioButton rbtResType;
        private System.Windows.Forms.RadioButton rbtResGrp;
        private System.Windows.Forms.Panel pnlSetData;
        private System.Windows.Forms.CheckBox chkSetData;
        private System.Windows.Forms.ListView lisResList;
        private System.Windows.Forms.ColumnHeader colFactory;
        private System.Windows.Forms.ColumnHeader colResType;
        private System.Windows.Forms.ColumnHeader colResGroup;
        private System.Windows.Forms.ColumnHeader colResID;

    }
}
