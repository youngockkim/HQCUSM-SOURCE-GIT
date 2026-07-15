namespace Miracom.MESCore.Controls
{
    partial class udcMaterialList
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
            this.pnlMaterialTop = new System.Windows.Forms.Panel();
            this.grpMaterialTop = new System.Windows.Forms.GroupBox();
            this.pnlMaterialFilter = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlMaterialDeleteCondition = new System.Windows.Forms.Panel();
            this.chkIncludeDeactiveMaterial = new System.Windows.Forms.CheckBox();
            this.chkIncludeDeletedMaterial = new System.Windows.Forms.CheckBox();
            this.pnlMaterialType = new System.Windows.Forms.Panel();
            this.cdvMaterialType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMaterialType = new System.Windows.Forms.Label();
            this.pnlMaterialMid = new System.Windows.Forms.Panel();
            this.pnlMaterialList = new System.Windows.Forms.Panel();
            this.lisMaterialList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colMaterialID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterialVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterialDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treMaterialList = new System.Windows.Forms.TreeView();
            this.pnlMaterialViewType = new System.Windows.Forms.Panel();
            this.grpMaterialViewType = new System.Windows.Forms.GroupBox();
            this.rbtAllVersion = new System.Windows.Forms.RadioButton();
            this.rbtTree = new System.Windows.Forms.RadioButton();
            this.rbtLastActive = new System.Windows.Forms.RadioButton();
            this.pnlMaterialTop.SuspendLayout();
            this.grpMaterialTop.SuspendLayout();
            this.pnlMaterialFilter.SuspendLayout();
            this.pnlMaterialDeleteCondition.SuspendLayout();
            this.pnlMaterialType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterialType)).BeginInit();
            this.pnlMaterialMid.SuspendLayout();
            this.pnlMaterialList.SuspendLayout();
            this.pnlMaterialViewType.SuspendLayout();
            this.grpMaterialViewType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMaterialTop
            // 
            this.pnlMaterialTop.Controls.Add(this.grpMaterialTop);
            this.pnlMaterialTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMaterialTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMaterialTop.Name = "pnlMaterialTop";
            this.pnlMaterialTop.Size = new System.Drawing.Size(232, 95);
            this.pnlMaterialTop.TabIndex = 0;
            // 
            // grpMaterialTop
            // 
            this.grpMaterialTop.Controls.Add(this.pnlMaterialFilter);
            this.grpMaterialTop.Controls.Add(this.pnlMaterialDeleteCondition);
            this.grpMaterialTop.Controls.Add(this.pnlMaterialType);
            this.grpMaterialTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaterialTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterialTop.Location = new System.Drawing.Point(0, 0);
            this.grpMaterialTop.Name = "grpMaterialTop";
            this.grpMaterialTop.Size = new System.Drawing.Size(232, 95);
            this.grpMaterialTop.TabIndex = 0;
            this.grpMaterialTop.TabStop = false;
            // 
            // pnlMaterialFilter
            // 
            this.pnlMaterialFilter.Controls.Add(this.txtFilter);
            this.pnlMaterialFilter.Controls.Add(this.lblFilter);
            this.pnlMaterialFilter.Location = new System.Drawing.Point(3, 33);
            this.pnlMaterialFilter.Name = "pnlMaterialFilter";
            this.pnlMaterialFilter.Size = new System.Drawing.Size(225, 22);
            this.pnlMaterialFilter.TabIndex = 2;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(93, 0);
            this.txtFilter.MaxLength = 30;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(128, 20);
            this.txtFilter.TabIndex = 5;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFilter.Location = new System.Drawing.Point(12, 4);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(35, 13);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "Filter";
            // 
            // pnlMaterialDeleteCondition
            // 
            this.pnlMaterialDeleteCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMaterialDeleteCondition.Controls.Add(this.chkIncludeDeactiveMaterial);
            this.pnlMaterialDeleteCondition.Controls.Add(this.chkIncludeDeletedMaterial);
            this.pnlMaterialDeleteCondition.Location = new System.Drawing.Point(3, 56);
            this.pnlMaterialDeleteCondition.Name = "pnlMaterialDeleteCondition";
            this.pnlMaterialDeleteCondition.Size = new System.Drawing.Size(226, 35);
            this.pnlMaterialDeleteCondition.TabIndex = 1;
            // 
            // chkIncludeDeactiveMaterial
            // 
            this.chkIncludeDeactiveMaterial.AutoSize = true;
            this.chkIncludeDeactiveMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDeactiveMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIncludeDeactiveMaterial.Location = new System.Drawing.Point(12, 18);
            this.chkIncludeDeactiveMaterial.Name = "chkIncludeDeactiveMaterial";
            this.chkIncludeDeactiveMaterial.Size = new System.Drawing.Size(153, 18);
            this.chkIncludeDeactiveMaterial.TabIndex = 1;
            this.chkIncludeDeactiveMaterial.Text = "Include Deactive Material";
            this.chkIncludeDeactiveMaterial.CheckedChanged += new System.EventHandler(this.chkIncludeMaterial_CheckedChanged);
            // 
            // chkIncludeDeletedMaterial
            // 
            this.chkIncludeDeletedMaterial.AutoSize = true;
            this.chkIncludeDeletedMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDeletedMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIncludeDeletedMaterial.Location = new System.Drawing.Point(12, 1);
            this.chkIncludeDeletedMaterial.Name = "chkIncludeDeletedMaterial";
            this.chkIncludeDeletedMaterial.Size = new System.Drawing.Size(147, 18);
            this.chkIncludeDeletedMaterial.TabIndex = 0;
            this.chkIncludeDeletedMaterial.Text = "Include Deleted Material";
            this.chkIncludeDeletedMaterial.CheckedChanged += new System.EventHandler(this.chkIncludeMaterial_CheckedChanged);
            // 
            // pnlMaterialType
            // 
            this.pnlMaterialType.Controls.Add(this.cdvMaterialType);
            this.pnlMaterialType.Controls.Add(this.lblMaterialType);
            this.pnlMaterialType.Location = new System.Drawing.Point(3, 10);
            this.pnlMaterialType.Name = "pnlMaterialType";
            this.pnlMaterialType.Size = new System.Drawing.Size(225, 22);
            this.pnlMaterialType.TabIndex = 0;
            // 
            // cdvMaterialType
            // 
            this.cdvMaterialType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMaterialType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMaterialType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMaterialType.BtnToolTipText = "";
            this.cdvMaterialType.DescText = "";
            this.cdvMaterialType.DisplaySubItemIndex = 0;
            this.cdvMaterialType.DisplayText = "";
            this.cdvMaterialType.Focusing = null;
            this.cdvMaterialType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterialType.Index = 0;
            this.cdvMaterialType.IsViewBtnImage = false;
            this.cdvMaterialType.Location = new System.Drawing.Point(93, 0);
            this.cdvMaterialType.MaxLength = 20;
            this.cdvMaterialType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMaterialType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMaterialType.Name = "cdvMaterialType";
            this.cdvMaterialType.ReadOnly = false;
            this.cdvMaterialType.SearchSubItemIndex = 0;
            this.cdvMaterialType.SelectedDescIndex = -1;
            this.cdvMaterialType.SelectedSubItemIndex = 0;
            this.cdvMaterialType.SelectionStart = 0;
            this.cdvMaterialType.Size = new System.Drawing.Size(128, 20);
            this.cdvMaterialType.SmallImageList = null;
            this.cdvMaterialType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMaterialType.TabIndex = 1;
            this.cdvMaterialType.TextBoxToolTipText = "";
            this.cdvMaterialType.TextBoxWidth = 128;
            this.cdvMaterialType.VisibleButton = true;
            this.cdvMaterialType.VisibleColumnHeader = false;
            this.cdvMaterialType.VisibleDescription = false;
            this.cdvMaterialType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterialType_SelectedItemChanged);
            this.cdvMaterialType.ButtonPress += new System.EventHandler(this.cdvMaterialType_ButtonPress);
            // 
            // lblMaterialType
            // 
            this.lblMaterialType.AutoSize = true;
            this.lblMaterialType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaterialType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaterialType.Location = new System.Drawing.Point(12, 3);
            this.lblMaterialType.Name = "lblMaterialType";
            this.lblMaterialType.Size = new System.Drawing.Size(71, 13);
            this.lblMaterialType.TabIndex = 0;
            this.lblMaterialType.Text = "Material Type";
            // 
            // pnlMaterialMid
            // 
            this.pnlMaterialMid.Controls.Add(this.pnlMaterialList);
            this.pnlMaterialMid.Controls.Add(this.pnlMaterialViewType);
            this.pnlMaterialMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMaterialMid.Location = new System.Drawing.Point(0, 95);
            this.pnlMaterialMid.Name = "pnlMaterialMid";
            this.pnlMaterialMid.Size = new System.Drawing.Size(232, 385);
            this.pnlMaterialMid.TabIndex = 0;
            // 
            // pnlMaterialList
            // 
            this.pnlMaterialList.Controls.Add(this.lisMaterialList);
            this.pnlMaterialList.Controls.Add(this.treMaterialList);
            this.pnlMaterialList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMaterialList.Location = new System.Drawing.Point(0, 63);
            this.pnlMaterialList.Name = "pnlMaterialList";
            this.pnlMaterialList.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlMaterialList.Size = new System.Drawing.Size(232, 322);
            this.pnlMaterialList.TabIndex = 1;
            // 
            // lisMaterialList
            // 
            this.lisMaterialList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaterialID,
            this.colMaterialVersion,
            this.colMaterialDesc});
            this.lisMaterialList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMaterialList.EnableSort = true;
            this.lisMaterialList.EnableSortIcon = true;
            this.lisMaterialList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMaterialList.FullRowSelect = true;
            this.lisMaterialList.Location = new System.Drawing.Point(0, 3);
            this.lisMaterialList.MultiSelect = false;
            this.lisMaterialList.Name = "lisMaterialList";
            this.lisMaterialList.Size = new System.Drawing.Size(232, 319);
            this.lisMaterialList.TabIndex = 0;
            this.lisMaterialList.UseCompatibleStateImageBehavior = false;
            this.lisMaterialList.View = System.Windows.Forms.View.Details;
            this.lisMaterialList.SelectedIndexChanged += new System.EventHandler(this.lisList_SelectedIndexChanged);
            // 
            // colMaterialID
            // 
            this.colMaterialID.Text = "Material";
            this.colMaterialID.Width = 120;
            // 
            // colMaterialVersion
            // 
            this.colMaterialVersion.Text = "Version";
            this.colMaterialVersion.Width = 45;
            // 
            // colMaterialDesc
            // 
            this.colMaterialDesc.Text = "Description";
            this.colMaterialDesc.Width = 200;
            // 
            // treMaterialList
            // 
            this.treMaterialList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treMaterialList.Location = new System.Drawing.Point(0, 3);
            this.treMaterialList.Name = "treMaterialList";
            this.treMaterialList.Size = new System.Drawing.Size(232, 319);
            this.treMaterialList.TabIndex = 1;
            this.treMaterialList.Visible = false;
            this.treMaterialList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treList_AfterSelect);
            // 
            // pnlMaterialViewType
            // 
            this.pnlMaterialViewType.Controls.Add(this.grpMaterialViewType);
            this.pnlMaterialViewType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMaterialViewType.Location = new System.Drawing.Point(0, 0);
            this.pnlMaterialViewType.Name = "pnlMaterialViewType";
            this.pnlMaterialViewType.Size = new System.Drawing.Size(232, 63);
            this.pnlMaterialViewType.TabIndex = 0;
            // 
            // grpMaterialViewType
            // 
            this.grpMaterialViewType.Controls.Add(this.rbtAllVersion);
            this.grpMaterialViewType.Controls.Add(this.rbtTree);
            this.grpMaterialViewType.Controls.Add(this.rbtLastActive);
            this.grpMaterialViewType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaterialViewType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterialViewType.Location = new System.Drawing.Point(0, 0);
            this.grpMaterialViewType.Name = "grpMaterialViewType";
            this.grpMaterialViewType.Size = new System.Drawing.Size(232, 63);
            this.grpMaterialViewType.TabIndex = 0;
            this.grpMaterialViewType.TabStop = false;
            // 
            // rbtAllVersion
            // 
            this.rbtAllVersion.AutoSize = true;
            this.rbtAllVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtAllVersion.Location = new System.Drawing.Point(12, 43);
            this.rbtAllVersion.Name = "rbtAllVersion";
            this.rbtAllVersion.Size = new System.Drawing.Size(79, 18);
            this.rbtAllVersion.TabIndex = 2;
            this.rbtAllVersion.TabStop = true;
            this.rbtAllVersion.Text = "All version";
            this.rbtAllVersion.CheckedChanged += new System.EventHandler(this.rbtViewType_CheckedChanged);
            // 
            // rbtTree
            // 
            this.rbtTree.AutoSize = true;
            this.rbtTree.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtTree.Location = new System.Drawing.Point(12, 26);
            this.rbtTree.Name = "rbtTree";
            this.rbtTree.Size = new System.Drawing.Size(146, 18);
            this.rbtTree.TabIndex = 1;
            this.rbtTree.TabStop = true;
            this.rbtTree.Text = "Version to tree structure ";
            this.rbtTree.CheckedChanged += new System.EventHandler(this.rbtViewType_CheckedChanged);
            // 
            // rbtLastActive
            // 
            this.rbtLastActive.AutoSize = true;
            this.rbtLastActive.Checked = true;
            this.rbtLastActive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtLastActive.Location = new System.Drawing.Point(12, 9);
            this.rbtLastActive.Name = "rbtLastActive";
            this.rbtLastActive.Size = new System.Drawing.Size(120, 18);
            this.rbtLastActive.TabIndex = 0;
            this.rbtLastActive.TabStop = true;
            this.rbtLastActive.Text = "Last active version";
            this.rbtLastActive.CheckedChanged += new System.EventHandler(this.rbtViewType_CheckedChanged);
            // 
            // udcMaterialList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlMaterialMid);
            this.Controls.Add(this.pnlMaterialTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "udcMaterialList";
            this.Size = new System.Drawing.Size(232, 480);
            this.FontChanged += new System.EventHandler(this.udcOperation_FontChanged);
            this.pnlMaterialTop.ResumeLayout(false);
            this.grpMaterialTop.ResumeLayout(false);
            this.pnlMaterialFilter.ResumeLayout(false);
            this.pnlMaterialFilter.PerformLayout();
            this.pnlMaterialDeleteCondition.ResumeLayout(false);
            this.pnlMaterialDeleteCondition.PerformLayout();
            this.pnlMaterialType.ResumeLayout(false);
            this.pnlMaterialType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterialType)).EndInit();
            this.pnlMaterialMid.ResumeLayout(false);
            this.pnlMaterialList.ResumeLayout(false);
            this.pnlMaterialViewType.ResumeLayout(false);
            this.grpMaterialViewType.ResumeLayout(false);
            this.grpMaterialViewType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMaterialTop;
        private System.Windows.Forms.Panel pnlMaterialMid;
        private System.Windows.Forms.GroupBox grpMaterialTop;
        private System.Windows.Forms.Panel pnlMaterialList;
        private Miracom.UI.Controls.MCListView.MCListView lisMaterialList;
        private System.Windows.Forms.ColumnHeader colMaterialID;
        private System.Windows.Forms.ColumnHeader colMaterialVersion;
        private System.Windows.Forms.ColumnHeader colMaterialDesc;
        private System.Windows.Forms.TreeView treMaterialList;
        private System.Windows.Forms.Panel pnlMaterialViewType;
        private System.Windows.Forms.GroupBox grpMaterialViewType;
        private System.Windows.Forms.RadioButton rbtAllVersion;
        private System.Windows.Forms.RadioButton rbtTree;
        private System.Windows.Forms.RadioButton rbtLastActive;
        private System.Windows.Forms.Panel pnlMaterialType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMaterialType;
        private System.Windows.Forms.Label lblMaterialType;
        private System.Windows.Forms.Panel pnlMaterialDeleteCondition;
        private System.Windows.Forms.CheckBox chkIncludeDeactiveMaterial;
        private System.Windows.Forms.CheckBox chkIncludeDeletedMaterial;
        private System.Windows.Forms.Panel pnlMaterialFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;

    }
}
