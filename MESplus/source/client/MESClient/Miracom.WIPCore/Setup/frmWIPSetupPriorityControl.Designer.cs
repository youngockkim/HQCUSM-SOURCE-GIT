namespace Miracom.WIPCore
{
    partial class frmWIPSetupPriorityControl
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer3 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.pnlPriType = new System.Windows.Forms.Panel();
            this.cdvPriorityType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPriorityType = new System.Windows.Forms.Label();
            this.lisPriority = new Miracom.UI.Controls.MCListView.MCListView();
            this.colPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriorityDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpPriority = new System.Windows.Forms.GroupBox();
            this.lblPriorityDesc = new System.Windows.Forms.Label();
            this.txtPriorityDesc = new System.Windows.Forms.TextBox();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.lblPriority = new System.Windows.Forms.Label();
            this.grpCheckFields = new System.Windows.Forms.GroupBox();
            this.pnlMFO = new System.Windows.Forms.Panel();
            this.chkResGroup = new System.Windows.Forms.CheckBox();
            this.chkResType = new System.Windows.Forms.CheckBox();
            this.chkOper = new System.Windows.Forms.CheckBox();
            this.chkMatVer = new System.Windows.Forms.CheckBox();
            this.chkResource = new System.Windows.Forms.CheckBox();
            this.chkFlow = new System.Windows.Forms.CheckBox();
            this.chkMatID = new System.Windows.Forms.CheckBox();
            this.grpCreateUpdate = new System.Windows.Forms.GroupBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.pnlCMF = new System.Windows.Forms.Panel();
            this.spdLotCMF = new FarPoint.Win.Spread.FpSpread();
            this.spdLotCMF_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdResGRP = new FarPoint.Win.Spread.FpSpread();
            this.spdResGRP_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdResCMF = new FarPoint.Win.Spread.FpSpread();
            this.spdResCMF_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPriType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPriorityType)).BeginInit();
            this.grpPriority.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            this.grpCheckFields.SuspendLayout();
            this.pnlMFO.SuspendLayout();
            this.grpCreateUpdate.SuspendLayout();
            this.pnlCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotCMF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotCMF_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResGRP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResGRP_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResCMF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResCMF_Sheet1)).BeginInit();
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
            // txtFind
            // 
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpCheckFields);
            this.pnlRight.Controls.Add(this.grpCreateUpdate);
            this.pnlRight.Controls.Add(this.grpPriority);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisPriority);
            this.pnlLeft.Controls.Add(this.pnlPriType);
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
            // pnlPriType
            // 
            this.pnlPriType.Controls.Add(this.cdvPriorityType);
            this.pnlPriType.Controls.Add(this.lblPriorityType);
            this.pnlPriType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPriType.Location = new System.Drawing.Point(0, 0);
            this.pnlPriType.Name = "pnlPriType";
            this.pnlPriType.Size = new System.Drawing.Size(232, 35);
            this.pnlPriType.TabIndex = 0;
            // 
            // cdvPriorityType
            // 
            this.cdvPriorityType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPriorityType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPriorityType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPriorityType.BtnToolTipText = "";
            this.cdvPriorityType.DescText = "";
            this.cdvPriorityType.DisplaySubItemIndex = -1;
            this.cdvPriorityType.DisplayText = "";
            this.cdvPriorityType.Focusing = null;
            this.cdvPriorityType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPriorityType.Index = 0;
            this.cdvPriorityType.IsViewBtnImage = false;
            this.cdvPriorityType.Location = new System.Drawing.Point(106, 8);
            this.cdvPriorityType.MaxLength = 20;
            this.cdvPriorityType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPriorityType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPriorityType.Name = "cdvPriorityType";
            this.cdvPriorityType.ReadOnly = false;
            this.cdvPriorityType.SearchSubItemIndex = 0;
            this.cdvPriorityType.SelectedDescIndex = -1;
            this.cdvPriorityType.SelectedSubItemIndex = -1;
            this.cdvPriorityType.SelectionStart = 0;
            this.cdvPriorityType.Size = new System.Drawing.Size(120, 20);
            this.cdvPriorityType.SmallImageList = null;
            this.cdvPriorityType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPriorityType.TabIndex = 1;
            this.cdvPriorityType.TextBoxToolTipText = "";
            this.cdvPriorityType.TextBoxWidth = 120;
            this.cdvPriorityType.VisibleButton = true;
            this.cdvPriorityType.VisibleColumnHeader = false;
            this.cdvPriorityType.VisibleDescription = false;
            this.cdvPriorityType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPriorityType_SelectedItemChanged);
            this.cdvPriorityType.ButtonPress += new System.EventHandler(this.cdvPriorityType_ButtonPress);
            // 
            // lblPriorityType
            // 
            this.lblPriorityType.AutoSize = true;
            this.lblPriorityType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriorityType.Location = new System.Drawing.Point(6, 12);
            this.lblPriorityType.Name = "lblPriorityType";
            this.lblPriorityType.Size = new System.Drawing.Size(78, 13);
            this.lblPriorityType.TabIndex = 0;
            this.lblPriorityType.Text = "Priority Type";
            // 
            // lisPriority
            // 
            this.lisPriority.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPriority,
            this.colPriorityDesc});
            this.lisPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisPriority.EnableSort = true;
            this.lisPriority.EnableSortIcon = true;
            this.lisPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisPriority.FullRowSelect = true;
            this.lisPriority.Location = new System.Drawing.Point(0, 35);
            this.lisPriority.MultiSelect = false;
            this.lisPriority.Name = "lisPriority";
            this.lisPriority.Size = new System.Drawing.Size(232, 471);
            this.lisPriority.TabIndex = 1;
            this.lisPriority.UseCompatibleStateImageBehavior = false;
            this.lisPriority.View = System.Windows.Forms.View.Details;
            this.lisPriority.SelectedIndexChanged += new System.EventHandler(this.lisPriority_SelectedIndexChanged);
            // 
            // colPriority
            // 
            this.colPriority.Text = "Priority";
            this.colPriority.Width = 55;
            // 
            // colPriorityDesc
            // 
            this.colPriorityDesc.Text = "Description";
            this.colPriorityDesc.Width = 160;
            // 
            // grpPriority
            // 
            this.grpPriority.Controls.Add(this.lblPriorityDesc);
            this.grpPriority.Controls.Add(this.txtPriorityDesc);
            this.grpPriority.Controls.Add(this.numPriority);
            this.grpPriority.Controls.Add(this.lblPriority);
            this.grpPriority.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPriority.Location = new System.Drawing.Point(0, 0);
            this.grpPriority.Name = "grpPriority";
            this.grpPriority.Size = new System.Drawing.Size(506, 70);
            this.grpPriority.TabIndex = 0;
            this.grpPriority.TabStop = false;
            this.grpPriority.Text = "Priority";
            // 
            // lblPriorityDesc
            // 
            this.lblPriorityDesc.AutoSize = true;
            this.lblPriorityDesc.Location = new System.Drawing.Point(8, 45);
            this.lblPriorityDesc.Name = "lblPriorityDesc";
            this.lblPriorityDesc.Size = new System.Drawing.Size(60, 13);
            this.lblPriorityDesc.TabIndex = 2;
            this.lblPriorityDesc.Text = "Description";
            // 
            // txtPriorityDesc
            // 
            this.txtPriorityDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPriorityDesc.Location = new System.Drawing.Point(110, 41);
            this.txtPriorityDesc.MaxLength = 200;
            this.txtPriorityDesc.Name = "txtPriorityDesc";
            this.txtPriorityDesc.Size = new System.Drawing.Size(390, 20);
            this.txtPriorityDesc.TabIndex = 3;
            // 
            // numPriority
            // 
            this.numPriority.Location = new System.Drawing.Point(110, 16);
            this.numPriority.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(70, 20);
            this.numPriority.TabIndex = 1;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(8, 20);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(46, 13);
            this.lblPriority.TabIndex = 0;
            this.lblPriority.Text = "Priority";
            // 
            // grpCheckFields
            // 
            this.grpCheckFields.Controls.Add(this.pnlCMF);
            this.grpCheckFields.Controls.Add(this.pnlMFO);
            this.grpCheckFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCheckFields.Location = new System.Drawing.Point(0, 70);
            this.grpCheckFields.Name = "grpCheckFields";
            this.grpCheckFields.Size = new System.Drawing.Size(506, 368);
            this.grpCheckFields.TabIndex = 1;
            this.grpCheckFields.TabStop = false;
            this.grpCheckFields.Text = "Check Fields";
            // 
            // pnlMFO
            // 
            this.pnlMFO.Controls.Add(this.chkResGroup);
            this.pnlMFO.Controls.Add(this.chkResType);
            this.pnlMFO.Controls.Add(this.chkOper);
            this.pnlMFO.Controls.Add(this.chkMatVer);
            this.pnlMFO.Controls.Add(this.chkResource);
            this.pnlMFO.Controls.Add(this.chkFlow);
            this.pnlMFO.Controls.Add(this.chkMatID);
            this.pnlMFO.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMFO.Location = new System.Drawing.Point(3, 16);
            this.pnlMFO.Name = "pnlMFO";
            this.pnlMFO.Size = new System.Drawing.Size(500, 101);
            this.pnlMFO.TabIndex = 0;
            // 
            // chkResGroup
            // 
            this.chkResGroup.AutoSize = true;
            this.chkResGroup.Location = new System.Drawing.Point(8, 72);
            this.chkResGroup.Name = "chkResGroup";
            this.chkResGroup.Size = new System.Drawing.Size(104, 17);
            this.chkResGroup.TabIndex = 6;
            this.chkResGroup.Text = "Resource Group";
            this.chkResGroup.UseVisualStyleBackColor = true;
            // 
            // chkResType
            // 
            this.chkResType.AutoSize = true;
            this.chkResType.Location = new System.Drawing.Point(262, 49);
            this.chkResType.Name = "chkResType";
            this.chkResType.Size = new System.Drawing.Size(99, 17);
            this.chkResType.TabIndex = 5;
            this.chkResType.Text = "Resource Type";
            this.chkResType.UseVisualStyleBackColor = true;
            // 
            // chkOper
            // 
            this.chkOper.AutoSize = true;
            this.chkOper.Location = new System.Drawing.Point(262, 26);
            this.chkOper.Name = "chkOper";
            this.chkOper.Size = new System.Drawing.Size(72, 17);
            this.chkOper.TabIndex = 3;
            this.chkOper.Text = "Operation";
            this.chkOper.UseVisualStyleBackColor = true;
            // 
            // chkMatVer
            // 
            this.chkMatVer.AutoSize = true;
            this.chkMatVer.Location = new System.Drawing.Point(262, 3);
            this.chkMatVer.Name = "chkMatVer";
            this.chkMatVer.Size = new System.Drawing.Size(101, 17);
            this.chkMatVer.TabIndex = 1;
            this.chkMatVer.Text = "Material Version";
            this.chkMatVer.UseVisualStyleBackColor = true;
            // 
            // chkResource
            // 
            this.chkResource.AutoSize = true;
            this.chkResource.Location = new System.Drawing.Point(8, 49);
            this.chkResource.Name = "chkResource";
            this.chkResource.Size = new System.Drawing.Size(72, 17);
            this.chkResource.TabIndex = 4;
            this.chkResource.Text = "Resource";
            this.chkResource.UseVisualStyleBackColor = true;
            // 
            // chkFlow
            // 
            this.chkFlow.AutoSize = true;
            this.chkFlow.Location = new System.Drawing.Point(8, 26);
            this.chkFlow.Name = "chkFlow";
            this.chkFlow.Size = new System.Drawing.Size(48, 17);
            this.chkFlow.TabIndex = 2;
            this.chkFlow.Text = "Flow";
            this.chkFlow.UseVisualStyleBackColor = true;
            // 
            // chkMatID
            // 
            this.chkMatID.AutoSize = true;
            this.chkMatID.Location = new System.Drawing.Point(8, 3);
            this.chkMatID.Name = "chkMatID";
            this.chkMatID.Size = new System.Drawing.Size(63, 17);
            this.chkMatID.TabIndex = 0;
            this.chkMatID.Text = "Material";
            this.chkMatID.UseVisualStyleBackColor = true;
            // 
            // grpCreateUpdate
            // 
            this.grpCreateUpdate.Controls.Add(this.txtUpdateUser);
            this.grpCreateUpdate.Controls.Add(this.lblCreate);
            this.grpCreateUpdate.Controls.Add(this.txtCreateUser);
            this.grpCreateUpdate.Controls.Add(this.lblUpdate);
            this.grpCreateUpdate.Controls.Add(this.txtCreateTime);
            this.grpCreateUpdate.Controls.Add(this.txtUpdateTime);
            this.grpCreateUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCreateUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateUpdate.Location = new System.Drawing.Point(0, 438);
            this.grpCreateUpdate.Name = "grpCreateUpdate";
            this.grpCreateUpdate.Size = new System.Drawing.Size(506, 68);
            this.grpCreateUpdate.TabIndex = 2;
            this.grpCreateUpdate.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(15, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(15, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(303, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(303, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // pnlCMF
            // 
            this.pnlCMF.Controls.Add(this.spdLotCMF);
            this.pnlCMF.Controls.Add(this.spdResCMF);
            this.pnlCMF.Controls.Add(this.spdResGRP);
            this.pnlCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCMF.Location = new System.Drawing.Point(3, 117);
            this.pnlCMF.Name = "pnlCMF";
            this.pnlCMF.Size = new System.Drawing.Size(500, 248);
            this.pnlCMF.TabIndex = 1;
            this.pnlCMF.Resize += new System.EventHandler(this.pnlCMF_Resize);
            // 
            // spdLotCMF
            // 
            this.spdLotCMF.AccessibleDescription = "spdLotCMF, Sheet1, Row 0, Column 0, ";
            this.spdLotCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotCMF.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLotCMF.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotCMF.HorizontalScrollBar.Name = "";
            this.spdLotCMF.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotCMF.HorizontalScrollBar.TabIndex = 6;
            this.spdLotCMF.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLotCMF.Location = new System.Drawing.Point(0, 0);
            this.spdLotCMF.Name = "spdLotCMF";
            this.spdLotCMF.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdLotCMF.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdLotCMF.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotCMF_Sheet1});
            this.spdLotCMF.Size = new System.Drawing.Size(166, 248);
            this.spdLotCMF.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLotCMF.TabIndex = 0;
            this.spdLotCMF.TextTipDelay = 200;
            this.spdLotCMF.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLotCMF.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotCMF.VerticalScrollBar.Name = "";
            this.spdLotCMF.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotCMF.VerticalScrollBar.TabIndex = 7;
            this.spdLotCMF.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdLotCMF_Sheet1
            // 
            this.spdLotCMF_Sheet1.Reset();
            spdLotCMF_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotCMF_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotCMF_Sheet1.ColumnCount = 2;
            spdLotCMF_Sheet1.RowCount = 20;
            this.spdLotCMF_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotCMF_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotCMF_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotCMF_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLotCMF_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.spdLotCMF_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot CMF";
            this.spdLotCMF_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotCMF_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotCMF_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdLotCMF_Sheet1.Columns.Get(0).Label = " ";
            this.spdLotCMF_Sheet1.Columns.Get(0).Resizable = false;
            this.spdLotCMF_Sheet1.Columns.Get(0).Width = 20F;
            this.spdLotCMF_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotCMF_Sheet1.Columns.Get(1).Label = "Lot CMF";
            this.spdLotCMF_Sheet1.Columns.Get(1).Width = 100F;
            this.spdLotCMF_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotCMF_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdLotCMF_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotCMF_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLotCMF_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotCMF_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdLotCMF_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotCMF_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLotCMF_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotCMF_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLotCMF_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdResGRP
            // 
            this.spdResGRP.AccessibleDescription = "spdResGRP, Sheet1, Row 0, Column 0, ";
            this.spdResGRP.Dock = System.Windows.Forms.DockStyle.Right;
            this.spdResGRP.FocusRenderer = defaultFocusIndicatorRenderer3;
            this.spdResGRP.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResGRP.HorizontalScrollBar.Name = "";
            this.spdResGRP.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdResGRP.HorizontalScrollBar.TabIndex = 8;
            this.spdResGRP.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResGRP.Location = new System.Drawing.Point(333, 0);
            this.spdResGRP.Name = "spdResGRP";
            this.spdResGRP.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdResGRP.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdResGRP.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResGRP_Sheet1});
            this.spdResGRP.Size = new System.Drawing.Size(167, 248);
            this.spdResGRP.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResGRP.TabIndex = 1;
            this.spdResGRP.TextTipDelay = 200;
            this.spdResGRP.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdResGRP.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResGRP.VerticalScrollBar.Name = "";
            this.spdResGRP.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdResGRP.VerticalScrollBar.TabIndex = 9;
            this.spdResGRP.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdResGRP_Sheet1
            // 
            this.spdResGRP_Sheet1.Reset();
            spdResGRP_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResGRP_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdResGRP_Sheet1.ColumnCount = 2;
            spdResGRP_Sheet1.RowCount = 10;
            this.spdResGRP_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResGRP_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdResGRP_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResGRP_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdResGRP_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.spdResGRP_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Resource Group";
            this.spdResGRP_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResGRP_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResGRP_Sheet1.Columns.Get(0).CellType = checkBoxCellType3;
            this.spdResGRP_Sheet1.Columns.Get(0).Label = " ";
            this.spdResGRP_Sheet1.Columns.Get(0).Resizable = false;
            this.spdResGRP_Sheet1.Columns.Get(0).Width = 20F;
            this.spdResGRP_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResGRP_Sheet1.Columns.Get(1).Label = "Resource Group";
            this.spdResGRP_Sheet1.Columns.Get(1).Width = 100F;
            this.spdResGRP_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResGRP_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdResGRP_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResGRP_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdResGRP_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdResGRP_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdResGRP_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResGRP_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResGRP_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResGRP_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResGRP_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdResCMF
            // 
            this.spdResCMF.AccessibleDescription = "spdResCMF, Sheet1, Row 0, Column 0, ";
            this.spdResCMF.Dock = System.Windows.Forms.DockStyle.Right;
            this.spdResCMF.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdResCMF.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResCMF.HorizontalScrollBar.Name = "";
            this.spdResCMF.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdResCMF.HorizontalScrollBar.TabIndex = 8;
            this.spdResCMF.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResCMF.Location = new System.Drawing.Point(166, 0);
            this.spdResCMF.Name = "spdResCMF";
            this.spdResCMF.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdResCMF.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdResCMF.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResCMF_Sheet1});
            this.spdResCMF.Size = new System.Drawing.Size(167, 248);
            this.spdResCMF.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResCMF.TabIndex = 2;
            this.spdResCMF.TextTipDelay = 200;
            this.spdResCMF.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdResCMF.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResCMF.VerticalScrollBar.Name = "";
            this.spdResCMF.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdResCMF.VerticalScrollBar.TabIndex = 9;
            this.spdResCMF.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdResCMF_Sheet1
            // 
            this.spdResCMF_Sheet1.Reset();
            spdResCMF_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResCMF_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdResCMF_Sheet1.ColumnCount = 2;
            spdResCMF_Sheet1.RowCount = 20;
            this.spdResCMF_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResCMF_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdResCMF_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResCMF_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdResCMF_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.spdResCMF_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Resource CMF";
            this.spdResCMF_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResCMF_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResCMF_Sheet1.Columns.Get(0).CellType = checkBoxCellType2;
            this.spdResCMF_Sheet1.Columns.Get(0).Label = " ";
            this.spdResCMF_Sheet1.Columns.Get(0).Resizable = false;
            this.spdResCMF_Sheet1.Columns.Get(0).Width = 20F;
            this.spdResCMF_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResCMF_Sheet1.Columns.Get(1).Label = "Resource CMF";
            this.spdResCMF_Sheet1.Columns.Get(1).Width = 100F;
            this.spdResCMF_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResCMF_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdResCMF_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResCMF_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdResCMF_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdResCMF_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdResCMF_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResCMF_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResCMF_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResCMF_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResCMF_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPSetupPriorityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupPriorityControl";
            this.Text = "Priority Control Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupPriorityControl_Activated);
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
            this.pnlPriType.ResumeLayout(false);
            this.pnlPriType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPriorityType)).EndInit();
            this.grpPriority.ResumeLayout(false);
            this.grpPriority.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            this.grpCheckFields.ResumeLayout(false);
            this.pnlMFO.ResumeLayout(false);
            this.pnlMFO.PerformLayout();
            this.grpCreateUpdate.ResumeLayout(false);
            this.grpCreateUpdate.PerformLayout();
            this.pnlCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotCMF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotCMF_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResGRP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResGRP_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResCMF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResCMF_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPriType;
        private UI.Controls.MCCodeView.MCCodeView cdvPriorityType;
        private System.Windows.Forms.Label lblPriorityType;
        private UI.Controls.MCListView.MCListView lisPriority;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.GroupBox grpPriority;
        private System.Windows.Forms.ColumnHeader colPriorityDesc;
        private System.Windows.Forms.GroupBox grpCheckFields;
        private System.Windows.Forms.Label lblPriorityDesc;
        private System.Windows.Forms.TextBox txtPriorityDesc;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.GroupBox grpCreateUpdate;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.Panel pnlMFO;
        private System.Windows.Forms.CheckBox chkResGroup;
        private System.Windows.Forms.CheckBox chkResType;
        private System.Windows.Forms.CheckBox chkOper;
        private System.Windows.Forms.CheckBox chkMatVer;
        private System.Windows.Forms.CheckBox chkResource;
        private System.Windows.Forms.CheckBox chkFlow;
        private System.Windows.Forms.CheckBox chkMatID;
        private System.Windows.Forms.Panel pnlCMF;
        private FarPoint.Win.Spread.FpSpread spdLotCMF;
        private FarPoint.Win.Spread.SheetView spdLotCMF_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdResCMF;
        private FarPoint.Win.Spread.SheetView spdResCMF_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdResGRP;
        private FarPoint.Win.Spread.SheetView spdResGRP_Sheet1;
    }
}