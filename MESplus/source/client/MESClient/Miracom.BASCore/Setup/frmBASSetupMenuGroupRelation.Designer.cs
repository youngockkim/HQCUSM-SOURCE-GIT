namespace Miracom.BASCore
{
    partial class frmBASSetupMenuGroupRelation
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
            this.tvMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.cdvMenuGrpID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMenuGrpId = new System.Windows.Forms.Label();
            this.lisMenuGrp = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.cdvKey5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvKey4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey5 = new System.Windows.Forms.Label();
            this.lblKey4 = new System.Windows.Forms.Label();
            this.cdvKey3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvKey2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvKey1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey3 = new System.Windows.Forms.Label();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.lisAttachedMenu = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFuncName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRequired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMenuGrpID)).BeginInit();
            this.grpCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey1)).BeginInit();
            this.pnlGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
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
            this.pnlRight.Controls.Add(this.pnlGeneral);
            this.pnlRight.Controls.Add(this.lisMenuGrp);
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
            this.btnCreate.TabStop = false;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Create";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.tvMFO.VisibleLevel8Factory = true;
            this.tvMFO.VisibleMaterialIncludeDeleteCheck = false;
            this.tvMFO.VisibleMaterialType = false;
            this.tvMFO.VisibleOnlySetData = true;
            this.tvMFO.VisibleViewType = true;
            this.tvMFO.AfterGetTree += new System.EventHandler(this.tvMFO_AfterGetTree);
            this.tvMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_LevelItemSelect);
            this.tvMFO.GetOnlySetData += new System.EventHandler(this.tvMFO_GetOnlySetData);
            this.tvMFO.SetDataSelectedIndexChanged += new System.EventHandler(this.tvMFO_SetDataSelectedIndexChanged);
            this.tvMFO.SelectLevelChanged += new System.EventHandler(this.tvMFO_SelectLevelChanged);
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.txtDesc);
            this.grpGeneral.Controls.Add(this.lblDesc);
            this.grpGeneral.Controls.Add(this.cdvMenuGrpID);
            this.grpGeneral.Controls.Add(this.lblMenuGrpId);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGeneral.Location = new System.Drawing.Point(0, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(506, 67);
            this.grpGeneral.TabIndex = 2;
            this.grpGeneral.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(118, 38);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(377, 20);
            this.txtDesc.TabIndex = 14;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDesc.Location = new System.Drawing.Point(10, 41);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 13;
            this.lblDesc.Text = "Description";
            // 
            // cdvMenuGrpID
            // 
            this.cdvMenuGrpID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMenuGrpID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMenuGrpID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMenuGrpID.BtnToolTipText = "";
            this.cdvMenuGrpID.DescText = "";
            this.cdvMenuGrpID.DisplaySubItemIndex = 0;
            this.cdvMenuGrpID.DisplayText = "";
            this.cdvMenuGrpID.Focusing = null;
            this.cdvMenuGrpID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMenuGrpID.Index = 0;
            this.cdvMenuGrpID.IsViewBtnImage = false;
            this.cdvMenuGrpID.Location = new System.Drawing.Point(118, 14);
            this.cdvMenuGrpID.MaxLength = 30;
            this.cdvMenuGrpID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMenuGrpID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMenuGrpID.Name = "cdvMenuGrpID";
            this.cdvMenuGrpID.ReadOnly = false;
            this.cdvMenuGrpID.SearchSubItemIndex = 0;
            this.cdvMenuGrpID.SelectedDescIndex = -1;
            this.cdvMenuGrpID.SelectedSubItemIndex = 0;
            this.cdvMenuGrpID.SelectionStart = 0;
            this.cdvMenuGrpID.Size = new System.Drawing.Size(150, 20);
            this.cdvMenuGrpID.SmallImageList = null;
            this.cdvMenuGrpID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMenuGrpID.TabIndex = 0;
            this.cdvMenuGrpID.TextBoxToolTipText = "";
            this.cdvMenuGrpID.TextBoxWidth = 150;
            this.cdvMenuGrpID.VisibleButton = true;
            this.cdvMenuGrpID.VisibleColumnHeader = false;
            this.cdvMenuGrpID.VisibleDescription = false;
            this.cdvMenuGrpID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMenuGrpID_SelectedItemChanged);
            this.cdvMenuGrpID.ButtonPress += new System.EventHandler(this.cdvMenuGrpID_ButtonPress);
            // 
            // lblMenuGrpId
            // 
            this.lblMenuGrpId.AutoSize = true;
            this.lblMenuGrpId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMenuGrpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuGrpId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMenuGrpId.Location = new System.Drawing.Point(10, 17);
            this.lblMenuGrpId.Name = "lblMenuGrpId";
            this.lblMenuGrpId.Size = new System.Drawing.Size(76, 13);
            this.lblMenuGrpId.TabIndex = 11;
            this.lblMenuGrpId.Text = "Menu Group";
            // 
            // lisMenuGrp
            // 
            this.lisMenuGrp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.columnHeader3});
            this.lisMenuGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lisMenuGrp.EnableSort = true;
            this.lisMenuGrp.EnableSortIcon = true;
            this.lisMenuGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMenuGrp.FullRowSelect = true;
            this.lisMenuGrp.HideSelection = false;
            this.lisMenuGrp.Location = new System.Drawing.Point(0, 0);
            this.lisMenuGrp.MultiSelect = false;
            this.lisMenuGrp.Name = "lisMenuGrp";
            this.lisMenuGrp.Size = new System.Drawing.Size(506, 133);
            this.lisMenuGrp.TabIndex = 3;
            this.lisMenuGrp.TabStop = false;
            this.lisMenuGrp.UseCompatibleStateImageBehavior = false;
            this.lisMenuGrp.View = System.Windows.Forms.View.Details;
            this.lisMenuGrp.SelectedIndexChanged += new System.EventHandler(this.lisMenuGrp_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Menu Group";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Group Category";
            this.columnHeader3.Width = 100;
            // 
            // grpCondition
            // 
            this.grpCondition.Controls.Add(this.cdvKey5);
            this.grpCondition.Controls.Add(this.cdvKey4);
            this.grpCondition.Controls.Add(this.lblKey5);
            this.grpCondition.Controls.Add(this.lblKey4);
            this.grpCondition.Controls.Add(this.cdvKey3);
            this.grpCondition.Controls.Add(this.cdvKey2);
            this.grpCondition.Controls.Add(this.cdvKey1);
            this.grpCondition.Controls.Add(this.lblKey3);
            this.grpCondition.Controls.Add(this.lblKey2);
            this.grpCondition.Controls.Add(this.lblKey1);
            this.grpCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCondition.Location = new System.Drawing.Point(0, 67);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(506, 98);
            this.grpCondition.TabIndex = 4;
            this.grpCondition.TabStop = false;
            // 
            // cdvKey5
            // 
            this.cdvKey5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey5.BtnToolTipText = "";
            this.cdvKey5.DescText = "";
            this.cdvKey5.DisplaySubItemIndex = -1;
            this.cdvKey5.DisplayText = "";
            this.cdvKey5.Focusing = null;
            this.cdvKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey5.Index = 0;
            this.cdvKey5.IsViewBtnImage = false;
            this.cdvKey5.Location = new System.Drawing.Point(401, 44);
            this.cdvKey5.MaxLength = 30;
            this.cdvKey5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey5.Name = "cdvKey5";
            this.cdvKey5.ReadOnly = false;
            this.cdvKey5.SearchSubItemIndex = 0;
            this.cdvKey5.SelectedDescIndex = -1;
            this.cdvKey5.SelectedSubItemIndex = -1;
            this.cdvKey5.SelectionStart = 0;
            this.cdvKey5.Size = new System.Drawing.Size(165, 20);
            this.cdvKey5.SmallImageList = null;
            this.cdvKey5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey5.TabIndex = 4;
            this.cdvKey5.TextBoxToolTipText = "";
            this.cdvKey5.TextBoxWidth = 165;
            this.cdvKey5.VisibleButton = true;
            this.cdvKey5.VisibleColumnHeader = false;
            this.cdvKey5.VisibleDescription = false;
            this.cdvKey5.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // cdvKey4
            // 
            this.cdvKey4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey4.BtnToolTipText = "";
            this.cdvKey4.DescText = "";
            this.cdvKey4.DisplaySubItemIndex = -1;
            this.cdvKey4.DisplayText = "";
            this.cdvKey4.Focusing = null;
            this.cdvKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey4.Index = 0;
            this.cdvKey4.IsViewBtnImage = false;
            this.cdvKey4.Location = new System.Drawing.Point(401, 19);
            this.cdvKey4.MaxLength = 30;
            this.cdvKey4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey4.Name = "cdvKey4";
            this.cdvKey4.ReadOnly = false;
            this.cdvKey4.SearchSubItemIndex = 0;
            this.cdvKey4.SelectedDescIndex = -1;
            this.cdvKey4.SelectedSubItemIndex = -1;
            this.cdvKey4.SelectionStart = 0;
            this.cdvKey4.Size = new System.Drawing.Size(165, 20);
            this.cdvKey4.SmallImageList = null;
            this.cdvKey4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey4.TabIndex = 3;
            this.cdvKey4.TextBoxToolTipText = "";
            this.cdvKey4.TextBoxWidth = 165;
            this.cdvKey4.VisibleButton = true;
            this.cdvKey4.VisibleColumnHeader = false;
            this.cdvKey4.VisibleDescription = false;
            this.cdvKey4.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // lblKey5
            // 
            this.lblKey5.AutoSize = true;
            this.lblKey5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey5.Location = new System.Drawing.Point(293, 46);
            this.lblKey5.Name = "lblKey5";
            this.lblKey5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKey5.Size = new System.Drawing.Size(34, 13);
            this.lblKey5.TabIndex = 18;
            this.lblKey5.Text = "Key 5";
            this.lblKey5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey5.Visible = false;
            // 
            // lblKey4
            // 
            this.lblKey4.AutoSize = true;
            this.lblKey4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey4.Location = new System.Drawing.Point(293, 22);
            this.lblKey4.Name = "lblKey4";
            this.lblKey4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKey4.Size = new System.Drawing.Size(34, 13);
            this.lblKey4.TabIndex = 16;
            this.lblKey4.Text = "Key 4";
            this.lblKey4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey4.Visible = false;
            // 
            // cdvKey3
            // 
            this.cdvKey3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey3.BtnToolTipText = "";
            this.cdvKey3.DescText = "";
            this.cdvKey3.DisplaySubItemIndex = -1;
            this.cdvKey3.DisplayText = "";
            this.cdvKey3.Focusing = null;
            this.cdvKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey3.Index = 0;
            this.cdvKey3.IsViewBtnImage = false;
            this.cdvKey3.Location = new System.Drawing.Point(118, 67);
            this.cdvKey3.MaxLength = 30;
            this.cdvKey3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey3.Name = "cdvKey3";
            this.cdvKey3.ReadOnly = false;
            this.cdvKey3.SearchSubItemIndex = 0;
            this.cdvKey3.SelectedDescIndex = -1;
            this.cdvKey3.SelectedSubItemIndex = -1;
            this.cdvKey3.SelectionStart = 0;
            this.cdvKey3.Size = new System.Drawing.Size(150, 20);
            this.cdvKey3.SmallImageList = null;
            this.cdvKey3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey3.TabIndex = 2;
            this.cdvKey3.TextBoxToolTipText = "";
            this.cdvKey3.TextBoxWidth = 150;
            this.cdvKey3.VisibleButton = true;
            this.cdvKey3.VisibleColumnHeader = false;
            this.cdvKey3.VisibleDescription = false;
            this.cdvKey3.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // cdvKey2
            // 
            this.cdvKey2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey2.BtnToolTipText = "";
            this.cdvKey2.DescText = "";
            this.cdvKey2.DisplaySubItemIndex = -1;
            this.cdvKey2.DisplayText = "";
            this.cdvKey2.Focusing = null;
            this.cdvKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey2.Index = 0;
            this.cdvKey2.IsViewBtnImage = false;
            this.cdvKey2.Location = new System.Drawing.Point(118, 43);
            this.cdvKey2.MaxLength = 30;
            this.cdvKey2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey2.Name = "cdvKey2";
            this.cdvKey2.ReadOnly = false;
            this.cdvKey2.SearchSubItemIndex = 0;
            this.cdvKey2.SelectedDescIndex = -1;
            this.cdvKey2.SelectedSubItemIndex = -1;
            this.cdvKey2.SelectionStart = 0;
            this.cdvKey2.Size = new System.Drawing.Size(150, 20);
            this.cdvKey2.SmallImageList = null;
            this.cdvKey2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey2.TabIndex = 1;
            this.cdvKey2.TextBoxToolTipText = "";
            this.cdvKey2.TextBoxWidth = 150;
            this.cdvKey2.VisibleButton = true;
            this.cdvKey2.VisibleColumnHeader = false;
            this.cdvKey2.VisibleDescription = false;
            this.cdvKey2.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // cdvKey1
            // 
            this.cdvKey1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey1.BtnToolTipText = "";
            this.cdvKey1.DescText = "";
            this.cdvKey1.DisplaySubItemIndex = -1;
            this.cdvKey1.DisplayText = "";
            this.cdvKey1.Focusing = null;
            this.cdvKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey1.Index = 0;
            this.cdvKey1.IsViewBtnImage = false;
            this.cdvKey1.Location = new System.Drawing.Point(118, 19);
            this.cdvKey1.MaxLength = 30;
            this.cdvKey1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey1.Name = "cdvKey1";
            this.cdvKey1.ReadOnly = false;
            this.cdvKey1.SearchSubItemIndex = 0;
            this.cdvKey1.SelectedDescIndex = -1;
            this.cdvKey1.SelectedSubItemIndex = -1;
            this.cdvKey1.SelectionStart = 0;
            this.cdvKey1.Size = new System.Drawing.Size(150, 20);
            this.cdvKey1.SmallImageList = null;
            this.cdvKey1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey1.TabIndex = 0;
            this.cdvKey1.TextBoxToolTipText = "";
            this.cdvKey1.TextBoxWidth = 150;
            this.cdvKey1.VisibleButton = true;
            this.cdvKey1.VisibleColumnHeader = false;
            this.cdvKey1.VisibleDescription = false;
            this.cdvKey1.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            this.cdvKey1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvKey_TextBoxKeyPress);
            // 
            // lblKey3
            // 
            this.lblKey3.AutoSize = true;
            this.lblKey3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey3.Location = new System.Drawing.Point(10, 70);
            this.lblKey3.Name = "lblKey3";
            this.lblKey3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKey3.Size = new System.Drawing.Size(34, 13);
            this.lblKey3.TabIndex = 14;
            this.lblKey3.Text = "Key 3";
            this.lblKey3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey3.Visible = false;
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey2.Location = new System.Drawing.Point(10, 46);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKey2.Size = new System.Drawing.Size(34, 13);
            this.lblKey2.TabIndex = 12;
            this.lblKey2.Text = "Key 2";
            this.lblKey2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey2.Visible = false;
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey1.Location = new System.Drawing.Point(10, 22);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKey1.Size = new System.Drawing.Size(34, 13);
            this.lblKey1.TabIndex = 10;
            this.lblKey1.Text = "Key 1";
            this.lblKey1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey1.Visible = false;
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.lisAttachedMenu);
            this.pnlGeneral.Controls.Add(this.grpCondition);
            this.pnlGeneral.Controls.Add(this.grpGeneral);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 133);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(506, 373);
            this.pnlGeneral.TabIndex = 5;
            // 
            // lisAttachedMenu
            // 
            this.lisAttachedMenu.AllowDrop = true;
            this.lisAttachedMenu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colFuncName,
            this.colRequired,
            this.colPriority,
            this.colTranCode});
            this.lisAttachedMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachedMenu.EnableSort = true;
            this.lisAttachedMenu.EnableSortIcon = true;
            this.lisAttachedMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachedMenu.FullRowSelect = true;
            this.lisAttachedMenu.HideSelection = false;
            this.lisAttachedMenu.Location = new System.Drawing.Point(0, 165);
            this.lisAttachedMenu.Name = "lisAttachedMenu";
            this.lisAttachedMenu.Size = new System.Drawing.Size(506, 208);
            this.lisAttachedMenu.TabIndex = 5;
            this.lisAttachedMenu.TabStop = false;
            this.lisAttachedMenu.UseCompatibleStateImageBehavior = false;
            this.lisAttachedMenu.View = System.Windows.Forms.View.Details;
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 35;
            // 
            // colFuncName
            // 
            this.colFuncName.Text = "Function Name";
            this.colFuncName.Width = 100;
            // 
            // colRequired
            // 
            this.colRequired.Text = "Required";
            // 
            // colPriority
            // 
            this.colPriority.Text = "Priority";
            // 
            // colTranCode
            // 
            this.colTranCode.Text = "Tran Code";
            this.colTranCode.Width = 100;
            // 
            // frmBASSetupMenuGroupRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASSetupMenuGroupRelation";
            this.Text = "Menu Group MFO Relation Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupMenuGroupRelation_Activated);
            this.Load += new System.EventHandler(this.frmBASSetupMenuGroupRelation_Load);
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
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMenuGrpID)).EndInit();
            this.grpCondition.ResumeLayout(false);
            this.grpCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey1)).EndInit();
            this.pnlGeneral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MESCore.Controls.udcMFOTreeList tvMFO;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private UI.Controls.MCCodeView.MCCodeView cdvMenuGrpID;
        private System.Windows.Forms.Label lblMenuGrpId;
        private UI.Controls.MCListView.MCListView lisMenuGrp;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.GroupBox grpCondition;
        private UI.Controls.MCCodeView.MCCodeView cdvKey5;
        private UI.Controls.MCCodeView.MCCodeView cdvKey4;
        private System.Windows.Forms.Label lblKey5;
        private System.Windows.Forms.Label lblKey4;
        private UI.Controls.MCCodeView.MCCodeView cdvKey3;
        private UI.Controls.MCCodeView.MCCodeView cdvKey2;
        private UI.Controls.MCCodeView.MCCodeView cdvKey1;
        private System.Windows.Forms.Label lblKey3;
        private System.Windows.Forms.Label lblKey2;
        private System.Windows.Forms.Label lblKey1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private UI.Controls.MCListView.MCListView lisAttachedMenu;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colFuncName;
        private System.Windows.Forms.ColumnHeader colRequired;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.ColumnHeader colTranCode;
    }
}