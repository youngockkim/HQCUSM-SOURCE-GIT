namespace Miracom.MESCore.Controls
{
    partial class udcMFOTreeList
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
            this.grpMaterialType = new System.Windows.Forms.GroupBox();
            this.pnlMaterialFilter = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlMaterialDeleteCondition = new System.Windows.Forms.Panel();
            this.chkIncludeDeactiveMaterial = new System.Windows.Forms.CheckBox();
            this.chkIncludeDeletedMaterial = new System.Windows.Forms.CheckBox();
            this.pnlMaterialType = new System.Windows.Forms.Panel();
            this.cdvMaterialType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMaterialType = new System.Windows.Forms.Label();
            this.grpLevel = new System.Windows.Forms.GroupBox();
            this.pnlSetData = new System.Windows.Forms.Panel();
            this.chkSetData = new System.Windows.Forms.CheckBox();
            this.pnlFactory = new System.Windows.Forms.Panel();
            this.rbtFactory = new System.Windows.Forms.RadioButton();
            this.pnlO = new System.Windows.Forms.Panel();
            this.rbtO = new System.Windows.Forms.RadioButton();
            this.pnlF = new System.Windows.Forms.Panel();
            this.rbtF = new System.Windows.Forms.RadioButton();
            this.pnlFO = new System.Windows.Forms.Panel();
            this.rbtFO = new System.Windows.Forms.RadioButton();
            this.pnlM = new System.Windows.Forms.Panel();
            this.rbtM = new System.Windows.Forms.RadioButton();
            this.pnlMF = new System.Windows.Forms.Panel();
            this.rbtMF = new System.Windows.Forms.RadioButton();
            this.pnlMO = new System.Windows.Forms.Panel();
            this.rbtMO = new System.Windows.Forms.RadioButton();
            this.pnlMFO = new System.Windows.Forms.Panel();
            this.rbtMFO = new System.Windows.Forms.RadioButton();
            this.pnlMainMid = new System.Windows.Forms.Panel();
            this.pnlMaterialList = new System.Windows.Forms.Panel();
            this.treMFOList = new System.Windows.Forms.TreeView();
            this.pnlMaterialViewType = new System.Windows.Forms.Panel();
            this.grpMaterialViewType = new System.Windows.Forms.GroupBox();
            this.rbtTree = new System.Windows.Forms.RadioButton();
            this.rbtLastActive = new System.Windows.Forms.RadioButton();
            this.lisList = new Miracom.UI.Controls.MCListView.MCListView();
            this.pnlMainTop.SuspendLayout();
            this.grpMaterialType.SuspendLayout();
            this.pnlMaterialFilter.SuspendLayout();
            this.pnlMaterialDeleteCondition.SuspendLayout();
            this.pnlMaterialType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterialType)).BeginInit();
            this.grpLevel.SuspendLayout();
            this.pnlSetData.SuspendLayout();
            this.pnlFactory.SuspendLayout();
            this.pnlO.SuspendLayout();
            this.pnlF.SuspendLayout();
            this.pnlFO.SuspendLayout();
            this.pnlM.SuspendLayout();
            this.pnlMF.SuspendLayout();
            this.pnlMO.SuspendLayout();
            this.pnlMFO.SuspendLayout();
            this.pnlMainMid.SuspendLayout();
            this.pnlMaterialList.SuspendLayout();
            this.pnlMaterialViewType.SuspendLayout();
            this.grpMaterialViewType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainTop
            // 
            this.pnlMainTop.Controls.Add(this.grpMaterialType);
            this.pnlMainTop.Controls.Add(this.grpLevel);
            this.pnlMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTop.Name = "pnlMainTop";
            this.pnlMainTop.Size = new System.Drawing.Size(232, 270);
            this.pnlMainTop.TabIndex = 1;
            // 
            // grpMaterialType
            // 
            this.grpMaterialType.Controls.Add(this.pnlMaterialFilter);
            this.grpMaterialType.Controls.Add(this.pnlMaterialDeleteCondition);
            this.grpMaterialType.Controls.Add(this.pnlMaterialType);
            this.grpMaterialType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterialType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterialType.Location = new System.Drawing.Point(0, 190);
            this.grpMaterialType.Name = "grpMaterialType";
            this.grpMaterialType.Size = new System.Drawing.Size(232, 80);
            this.grpMaterialType.TabIndex = 1;
            this.grpMaterialType.TabStop = false;
            // 
            // pnlMaterialFilter
            // 
            this.pnlMaterialFilter.Controls.Add(this.txtFilter);
            this.pnlMaterialFilter.Controls.Add(this.lblFilter);
            this.pnlMaterialFilter.Location = new System.Drawing.Point(3, 33);
            this.pnlMaterialFilter.Name = "pnlMaterialFilter";
            this.pnlMaterialFilter.Size = new System.Drawing.Size(225, 22);
            this.pnlMaterialFilter.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(93, 0);
            this.txtFilter.MaxLength = 30;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(128, 20);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFilter.Location = new System.Drawing.Point(12, 4);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            // 
            // pnlMaterialDeleteCondition
            // 
            this.pnlMaterialDeleteCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMaterialDeleteCondition.Controls.Add(this.chkIncludeDeactiveMaterial);
            this.pnlMaterialDeleteCondition.Controls.Add(this.chkIncludeDeletedMaterial);
            this.pnlMaterialDeleteCondition.Location = new System.Drawing.Point(3, 55);
            this.pnlMaterialDeleteCondition.Name = "pnlMaterialDeleteCondition";
            this.pnlMaterialDeleteCondition.Size = new System.Drawing.Size(226, 20);
            this.pnlMaterialDeleteCondition.TabIndex = 2;
            // 
            // chkIncludeDeactiveMaterial
            // 
            this.chkIncludeDeactiveMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDeactiveMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIncludeDeactiveMaterial.Location = new System.Drawing.Point(12, 35);
            this.chkIncludeDeactiveMaterial.Name = "chkIncludeDeactiveMaterial";
            this.chkIncludeDeactiveMaterial.Size = new System.Drawing.Size(209, 14);
            this.chkIncludeDeactiveMaterial.TabIndex = 1;
            this.chkIncludeDeactiveMaterial.Text = "Include Deactive Material";
            this.chkIncludeDeactiveMaterial.CheckedChanged += new System.EventHandler(this.chkIncludeMaterial_CheckedChanged);
            // 
            // chkIncludeDeletedMaterial
            // 
            this.chkIncludeDeletedMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDeletedMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIncludeDeletedMaterial.Location = new System.Drawing.Point(12, 1);
            this.chkIncludeDeletedMaterial.Name = "chkIncludeDeletedMaterial";
            this.chkIncludeDeletedMaterial.Size = new System.Drawing.Size(209, 16);
            this.chkIncludeDeletedMaterial.TabIndex = 0;
            this.chkIncludeDeletedMaterial.Text = "Include Deleted Material";
            this.chkIncludeDeletedMaterial.CheckedChanged += new System.EventHandler(this.chkIncludeMaterial_CheckedChanged);
            // 
            // pnlMaterialType
            // 
            this.pnlMaterialType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMaterialType.Controls.Add(this.cdvMaterialType);
            this.pnlMaterialType.Controls.Add(this.lblMaterialType);
            this.pnlMaterialType.Location = new System.Drawing.Point(3, 10);
            this.pnlMaterialType.Name = "pnlMaterialType";
            this.pnlMaterialType.Size = new System.Drawing.Size(226, 20);
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
            // grpLevel
            // 
            this.grpLevel.Controls.Add(this.pnlSetData);
            this.grpLevel.Controls.Add(this.pnlFactory);
            this.grpLevel.Controls.Add(this.pnlO);
            this.grpLevel.Controls.Add(this.pnlF);
            this.grpLevel.Controls.Add(this.pnlFO);
            this.grpLevel.Controls.Add(this.pnlM);
            this.grpLevel.Controls.Add(this.pnlMF);
            this.grpLevel.Controls.Add(this.pnlMO);
            this.grpLevel.Controls.Add(this.pnlMFO);
            this.grpLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLevel.Location = new System.Drawing.Point(0, 0);
            this.grpLevel.Name = "grpLevel";
            this.grpLevel.Size = new System.Drawing.Size(232, 190);
            this.grpLevel.TabIndex = 0;
            this.grpLevel.TabStop = false;
            this.grpLevel.Text = "Level Select";
            // 
            // pnlSetData
            // 
            this.pnlSetData.Controls.Add(this.chkSetData);
            this.pnlSetData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetData.Location = new System.Drawing.Point(3, 168);
            this.pnlSetData.Name = "pnlSetData";
            this.pnlSetData.Size = new System.Drawing.Size(226, 20);
            this.pnlSetData.TabIndex = 8;
            // 
            // chkSetData
            // 
            this.chkSetData.AutoSize = true;
            this.chkSetData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSetData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSetData.Location = new System.Drawing.Point(12, 1);
            this.chkSetData.Name = "chkSetData";
            this.chkSetData.Size = new System.Drawing.Size(98, 18);
            this.chkSetData.TabIndex = 0;
            this.chkSetData.Text = "Only Set Data";
            this.chkSetData.CheckedChanged += new System.EventHandler(this.chkSetData_CheckedChanged);
            // 
            // pnlFactory
            // 
            this.pnlFactory.Controls.Add(this.rbtFactory);
            this.pnlFactory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFactory.Location = new System.Drawing.Point(3, 149);
            this.pnlFactory.Name = "pnlFactory";
            this.pnlFactory.Size = new System.Drawing.Size(226, 19);
            this.pnlFactory.TabIndex = 7;
            // 
            // rbtFactory
            // 
            this.rbtFactory.AutoSize = true;
            this.rbtFactory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtFactory.Location = new System.Drawing.Point(12, 1);
            this.rbtFactory.Name = "rbtFactory";
            this.rbtFactory.Size = new System.Drawing.Size(66, 18);
            this.rbtFactory.TabIndex = 0;
            this.rbtFactory.TabStop = true;
            this.rbtFactory.Text = "Factory";
            this.rbtFactory.CheckedChanged += new System.EventHandler(this.MFO_Level_CheckedChanged);
            // 
            // pnlO
            // 
            this.pnlO.Controls.Add(this.rbtO);
            this.pnlO.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlO.Location = new System.Drawing.Point(3, 130);
            this.pnlO.Name = "pnlO";
            this.pnlO.Size = new System.Drawing.Size(226, 19);
            this.pnlO.TabIndex = 6;
            // 
            // rbtO
            // 
            this.rbtO.AutoSize = true;
            this.rbtO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtO.Location = new System.Drawing.Point(12, 1);
            this.rbtO.Name = "rbtO";
            this.rbtO.Size = new System.Drawing.Size(77, 18);
            this.rbtO.TabIndex = 0;
            this.rbtO.TabStop = true;
            this.rbtO.Text = "Operation";
            this.rbtO.CheckedChanged += new System.EventHandler(this.MFO_Level_CheckedChanged);
            // 
            // pnlF
            // 
            this.pnlF.Controls.Add(this.rbtF);
            this.pnlF.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlF.Location = new System.Drawing.Point(3, 111);
            this.pnlF.Name = "pnlF";
            this.pnlF.Size = new System.Drawing.Size(226, 19);
            this.pnlF.TabIndex = 5;
            // 
            // rbtF
            // 
            this.rbtF.AutoSize = true;
            this.rbtF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtF.Location = new System.Drawing.Point(12, 1);
            this.rbtF.Name = "rbtF";
            this.rbtF.Size = new System.Drawing.Size(53, 18);
            this.rbtF.TabIndex = 0;
            this.rbtF.TabStop = true;
            this.rbtF.Text = "Flow";
            this.rbtF.CheckedChanged += new System.EventHandler(this.MFO_Level_CheckedChanged);
            // 
            // pnlFO
            // 
            this.pnlFO.Controls.Add(this.rbtFO);
            this.pnlFO.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFO.Location = new System.Drawing.Point(3, 92);
            this.pnlFO.Name = "pnlFO";
            this.pnlFO.Size = new System.Drawing.Size(226, 19);
            this.pnlFO.TabIndex = 4;
            // 
            // rbtFO
            // 
            this.rbtFO.AutoSize = true;
            this.rbtFO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtFO.Location = new System.Drawing.Point(12, 1);
            this.rbtFO.Name = "rbtFO";
            this.rbtFO.Size = new System.Drawing.Size(108, 18);
            this.rbtFO.TabIndex = 0;
            this.rbtFO.TabStop = true;
            this.rbtFO.Text = "Flow - Operation";
            this.rbtFO.CheckedChanged += new System.EventHandler(this.MFO_Level_CheckedChanged);
            // 
            // pnlM
            // 
            this.pnlM.Controls.Add(this.rbtM);
            this.pnlM.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlM.Location = new System.Drawing.Point(3, 73);
            this.pnlM.Name = "pnlM";
            this.pnlM.Size = new System.Drawing.Size(226, 19);
            this.pnlM.TabIndex = 3;
            // 
            // rbtM
            // 
            this.rbtM.AutoSize = true;
            this.rbtM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtM.Location = new System.Drawing.Point(12, 1);
            this.rbtM.Name = "rbtM";
            this.rbtM.Size = new System.Drawing.Size(68, 18);
            this.rbtM.TabIndex = 0;
            this.rbtM.TabStop = true;
            this.rbtM.Text = "Material";
            this.rbtM.CheckedChanged += new System.EventHandler(this.MFO_Level_CheckedChanged);
            // 
            // pnlMF
            // 
            this.pnlMF.Controls.Add(this.rbtMF);
            this.pnlMF.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMF.Location = new System.Drawing.Point(3, 54);
            this.pnlMF.Name = "pnlMF";
            this.pnlMF.Size = new System.Drawing.Size(226, 19);
            this.pnlMF.TabIndex = 2;
            // 
            // rbtMF
            // 
            this.rbtMF.AutoSize = true;
            this.rbtMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtMF.Location = new System.Drawing.Point(12, 1);
            this.rbtMF.Name = "rbtMF";
            this.rbtMF.Size = new System.Drawing.Size(99, 18);
            this.rbtMF.TabIndex = 0;
            this.rbtMF.TabStop = true;
            this.rbtMF.Text = "Material - Flow";
            this.rbtMF.CheckedChanged += new System.EventHandler(this.MFO_Level_CheckedChanged);
            // 
            // pnlMO
            // 
            this.pnlMO.Controls.Add(this.rbtMO);
            this.pnlMO.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMO.Location = new System.Drawing.Point(3, 35);
            this.pnlMO.Name = "pnlMO";
            this.pnlMO.Size = new System.Drawing.Size(226, 19);
            this.pnlMO.TabIndex = 1;
            // 
            // rbtMO
            // 
            this.rbtMO.AutoSize = true;
            this.rbtMO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtMO.Location = new System.Drawing.Point(12, 1);
            this.rbtMO.Name = "rbtMO";
            this.rbtMO.Size = new System.Drawing.Size(123, 18);
            this.rbtMO.TabIndex = 0;
            this.rbtMO.TabStop = true;
            this.rbtMO.Text = "Material - Operation";
            this.rbtMO.CheckedChanged += new System.EventHandler(this.MFO_Level_CheckedChanged);
            // 
            // pnlMFO
            // 
            this.pnlMFO.Controls.Add(this.rbtMFO);
            this.pnlMFO.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMFO.Location = new System.Drawing.Point(3, 16);
            this.pnlMFO.Name = "pnlMFO";
            this.pnlMFO.Size = new System.Drawing.Size(226, 19);
            this.pnlMFO.TabIndex = 0;
            // 
            // rbtMFO
            // 
            this.rbtMFO.AutoSize = true;
            this.rbtMFO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtMFO.Location = new System.Drawing.Point(12, 1);
            this.rbtMFO.Name = "rbtMFO";
            this.rbtMFO.Size = new System.Drawing.Size(154, 18);
            this.rbtMFO.TabIndex = 0;
            this.rbtMFO.TabStop = true;
            this.rbtMFO.Text = "Material - Flow - Operation";
            this.rbtMFO.CheckedChanged += new System.EventHandler(this.MFO_Level_CheckedChanged);
            // 
            // pnlMainMid
            // 
            this.pnlMainMid.Controls.Add(this.pnlMaterialList);
            this.pnlMainMid.Controls.Add(this.pnlMaterialViewType);
            this.pnlMainMid.Controls.Add(this.lisList);
            this.pnlMainMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMid.Location = new System.Drawing.Point(0, 270);
            this.pnlMainMid.Name = "pnlMainMid";
            this.pnlMainMid.Size = new System.Drawing.Size(232, 210);
            this.pnlMainMid.TabIndex = 0;
            // 
            // pnlMaterialList
            // 
            this.pnlMaterialList.Controls.Add(this.treMFOList);
            this.pnlMaterialList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMaterialList.Location = new System.Drawing.Point(0, 47);
            this.pnlMaterialList.Name = "pnlMaterialList";
            this.pnlMaterialList.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlMaterialList.Size = new System.Drawing.Size(232, 163);
            this.pnlMaterialList.TabIndex = 0;
            // 
            // treMFOList
            // 
            this.treMFOList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treMFOList.Location = new System.Drawing.Point(0, 3);
            this.treMFOList.Name = "treMFOList";
            this.treMFOList.Size = new System.Drawing.Size(232, 160);
            this.treMFOList.TabIndex = 0;
            this.treMFOList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treMFOList_AfterSelect);
            // 
            // pnlMaterialViewType
            // 
            this.pnlMaterialViewType.Controls.Add(this.grpMaterialViewType);
            this.pnlMaterialViewType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMaterialViewType.Location = new System.Drawing.Point(0, 0);
            this.pnlMaterialViewType.Name = "pnlMaterialViewType";
            this.pnlMaterialViewType.Size = new System.Drawing.Size(232, 47);
            this.pnlMaterialViewType.TabIndex = 0;
            // 
            // grpMaterialViewType
            // 
            this.grpMaterialViewType.Controls.Add(this.rbtTree);
            this.grpMaterialViewType.Controls.Add(this.rbtLastActive);
            this.grpMaterialViewType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaterialViewType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterialViewType.Location = new System.Drawing.Point(0, 0);
            this.grpMaterialViewType.Name = "grpMaterialViewType";
            this.grpMaterialViewType.Size = new System.Drawing.Size(232, 47);
            this.grpMaterialViewType.TabIndex = 0;
            this.grpMaterialViewType.TabStop = false;
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
            this.lisList.Size = new System.Drawing.Size(232, 210);
            this.lisList.TabIndex = 1;
            this.lisList.UseCompatibleStateImageBehavior = false;
            this.lisList.View = System.Windows.Forms.View.Details;
            this.lisList.SelectedIndexChanged += new System.EventHandler(this.lisList_SelectedIndexChanged);
            // 
            // udcMFOTreeList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlMainMid);
            this.Controls.Add(this.pnlMainTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "udcMFOTreeList";
            this.Size = new System.Drawing.Size(232, 480);
            this.FontChanged += new System.EventHandler(this.udcMFOTreeList_FontChanged);
            this.pnlMainTop.ResumeLayout(false);
            this.grpMaterialType.ResumeLayout(false);
            this.pnlMaterialFilter.ResumeLayout(false);
            this.pnlMaterialFilter.PerformLayout();
            this.pnlMaterialDeleteCondition.ResumeLayout(false);
            this.pnlMaterialType.ResumeLayout(false);
            this.pnlMaterialType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterialType)).EndInit();
            this.grpLevel.ResumeLayout(false);
            this.pnlSetData.ResumeLayout(false);
            this.pnlSetData.PerformLayout();
            this.pnlFactory.ResumeLayout(false);
            this.pnlFactory.PerformLayout();
            this.pnlO.ResumeLayout(false);
            this.pnlO.PerformLayout();
            this.pnlF.ResumeLayout(false);
            this.pnlF.PerformLayout();
            this.pnlFO.ResumeLayout(false);
            this.pnlFO.PerformLayout();
            this.pnlM.ResumeLayout(false);
            this.pnlM.PerformLayout();
            this.pnlMF.ResumeLayout(false);
            this.pnlMF.PerformLayout();
            this.pnlMO.ResumeLayout(false);
            this.pnlMO.PerformLayout();
            this.pnlMFO.ResumeLayout(false);
            this.pnlMFO.PerformLayout();
            this.pnlMainMid.ResumeLayout(false);
            this.pnlMaterialList.ResumeLayout(false);
            this.pnlMaterialViewType.ResumeLayout(false);
            this.grpMaterialViewType.ResumeLayout(false);
            this.grpMaterialViewType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainTop;
        private System.Windows.Forms.Panel pnlMainMid;
        private System.Windows.Forms.GroupBox grpMaterialType;
        private System.Windows.Forms.Panel pnlMaterialList;
        private System.Windows.Forms.TreeView treMFOList;
        private System.Windows.Forms.Panel pnlMaterialViewType;
        private System.Windows.Forms.GroupBox grpMaterialViewType;
        private System.Windows.Forms.RadioButton rbtTree;
        private System.Windows.Forms.RadioButton rbtLastActive;
        private System.Windows.Forms.Panel pnlMaterialType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMaterialType;
        private System.Windows.Forms.Label lblMaterialType;
        private System.Windows.Forms.Panel pnlMaterialDeleteCondition;
        private System.Windows.Forms.CheckBox chkIncludeDeactiveMaterial;
        private System.Windows.Forms.CheckBox chkIncludeDeletedMaterial;
        private System.Windows.Forms.GroupBox grpLevel;
        private System.Windows.Forms.Panel pnlMFO;
        private System.Windows.Forms.RadioButton rbtMFO;
        private System.Windows.Forms.Panel pnlSetData;
        private System.Windows.Forms.Panel pnlF;
        private System.Windows.Forms.RadioButton rbtF;
        private System.Windows.Forms.Panel pnlM;
        private System.Windows.Forms.RadioButton rbtM;
        private System.Windows.Forms.Panel pnlMF;
        private System.Windows.Forms.RadioButton rbtMF;
        private System.Windows.Forms.Panel pnlMO;
        private System.Windows.Forms.RadioButton rbtMO;
        private System.Windows.Forms.Panel pnlO;
        private System.Windows.Forms.RadioButton rbtO;
        private System.Windows.Forms.Panel pnlFO;
        private System.Windows.Forms.RadioButton rbtFO;
        private System.Windows.Forms.CheckBox chkSetData;
        private Miracom.UI.Controls.MCListView.MCListView lisList;
        private System.Windows.Forms.Panel pnlFactory;
        private System.Windows.Forms.RadioButton rbtFactory;
        private System.Windows.Forms.Panel pnlMaterialFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;

    }
}
