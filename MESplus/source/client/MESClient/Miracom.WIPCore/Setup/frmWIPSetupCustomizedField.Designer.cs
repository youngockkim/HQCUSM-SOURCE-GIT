namespace Miracom.WIPCore
{
    partial class frmWIPSetupCustomizedField
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
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.ComplexBorder complexBorder2 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.ComplexBorder complexBorder3 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.lisCmfList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colCmfItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmfType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlCmfItem = new System.Windows.Forms.Panel();
            this.grpTableName = new System.Windows.Forms.GroupBox();
            this.txtCmfCount = new System.Windows.Forms.TextBox();
            this.lblCmfCount = new System.Windows.Forms.Label();
            this.txtCmfType = new System.Windows.Forms.TextBox();
            this.lblCmfType = new System.Windows.Forms.Label();
            this.txtCmfDesc = new System.Windows.Forms.TextBox();
            this.lblCmfDesc = new System.Windows.Forms.Label();
            this.txtCmfItem = new System.Windows.Forms.TextBox();
            this.lblCmfItem = new System.Windows.Forms.Label();
            this.pnlCmfItemDef = new System.Windows.Forms.Panel();
            this.spdCmfDef = new FarPoint.Win.Spread.FpSpread();
            this.spdCmfDef_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.ctxSpread = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlCmfItem.SuspendLayout();
            this.grpTableName.SuspendLayout();
            this.pnlCmfItemDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCmfDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCmfDef_Sheet1)).BeginInit();
            this.ctxSpread.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
            // 
            // lblDataCountBase
            // 
            this.lblDataCountBase.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 2;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlCmfItemDef);
            this.pnlRight.Controls.Add(this.pnlCmfItem);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisCmfList);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // lisCmfList
            // 
            this.lisCmfList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCmfItem,
            this.colDescription,
            this.colCmfType,
            this.colCount});
            this.lisCmfList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCmfList.EnableSort = true;
            this.lisCmfList.EnableSortIcon = true;
            this.lisCmfList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCmfList.FullRowSelect = true;
            this.lisCmfList.GridLines = true;
            this.lisCmfList.HideSelection = false;
            this.lisCmfList.Location = new System.Drawing.Point(0, 0);
            this.lisCmfList.MultiSelect = false;
            this.lisCmfList.Name = "lisCmfList";
            this.lisCmfList.Size = new System.Drawing.Size(232, 506);
            this.lisCmfList.TabIndex = 0;
            this.lisCmfList.UseCompatibleStateImageBehavior = false;
            this.lisCmfList.View = System.Windows.Forms.View.Details;
            this.lisCmfList.SelectedIndexChanged += new System.EventHandler(this.lisCmfList_SelectedIndexChanged);
            // 
            // colCmfItem
            // 
            this.colCmfItem.Text = "Custom Item";
            this.colCmfItem.Width = 160;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 0;
            // 
            // colCmfType
            // 
            this.colCmfType.Text = "Type";
            this.colCmfType.Width = 40;
            // 
            // colCount
            // 
            this.colCount.Text = "Count";
            this.colCount.Width = 40;
            // 
            // pnlCmfItem
            // 
            this.pnlCmfItem.Controls.Add(this.grpTableName);
            this.pnlCmfItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCmfItem.Location = new System.Drawing.Point(0, 0);
            this.pnlCmfItem.Name = "pnlCmfItem";
            this.pnlCmfItem.Padding = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.pnlCmfItem.Size = new System.Drawing.Size(506, 118);
            this.pnlCmfItem.TabIndex = 1;
            // 
            // grpTableName
            // 
            this.grpTableName.Controls.Add(this.txtCmfCount);
            this.grpTableName.Controls.Add(this.lblCmfCount);
            this.grpTableName.Controls.Add(this.txtCmfType);
            this.grpTableName.Controls.Add(this.lblCmfType);
            this.grpTableName.Controls.Add(this.txtCmfDesc);
            this.grpTableName.Controls.Add(this.lblCmfDesc);
            this.grpTableName.Controls.Add(this.txtCmfItem);
            this.grpTableName.Controls.Add(this.lblCmfItem);
            this.grpTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTableName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTableName.Location = new System.Drawing.Point(5, 0);
            this.grpTableName.Name = "grpTableName";
            this.grpTableName.Size = new System.Drawing.Size(498, 118);
            this.grpTableName.TabIndex = 0;
            this.grpTableName.TabStop = false;
            // 
            // txtCmfCount
            // 
            this.txtCmfCount.Location = new System.Drawing.Point(146, 88);
            this.txtCmfCount.MaxLength = 20;
            this.txtCmfCount.Name = "txtCmfCount";
            this.txtCmfCount.Size = new System.Drawing.Size(195, 20);
            this.txtCmfCount.TabIndex = 7;
            // 
            // lblCmfCount
            // 
            this.lblCmfCount.AutoSize = true;
            this.lblCmfCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCmfCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmfCount.Location = new System.Drawing.Point(17, 91);
            this.lblCmfCount.Name = "lblCmfCount";
            this.lblCmfCount.Size = new System.Drawing.Size(36, 13);
            this.lblCmfCount.TabIndex = 8;
            this.lblCmfCount.Text = "Count";
            // 
            // txtCmfType
            // 
            this.txtCmfType.Location = new System.Drawing.Point(146, 64);
            this.txtCmfType.MaxLength = 20;
            this.txtCmfType.Name = "txtCmfType";
            this.txtCmfType.Size = new System.Drawing.Size(195, 20);
            this.txtCmfType.TabIndex = 5;
            // 
            // lblCmfType
            // 
            this.lblCmfType.AutoSize = true;
            this.lblCmfType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCmfType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmfType.Location = new System.Drawing.Point(17, 67);
            this.lblCmfType.Name = "lblCmfType";
            this.lblCmfType.Size = new System.Drawing.Size(31, 13);
            this.lblCmfType.TabIndex = 6;
            this.lblCmfType.Text = "Type";
            // 
            // txtCmfDesc
            // 
            this.txtCmfDesc.Location = new System.Drawing.Point(146, 40);
            this.txtCmfDesc.MaxLength = 50;
            this.txtCmfDesc.Name = "txtCmfDesc";
            this.txtCmfDesc.Size = new System.Drawing.Size(339, 20);
            this.txtCmfDesc.TabIndex = 3;
            // 
            // lblCmfDesc
            // 
            this.lblCmfDesc.AutoSize = true;
            this.lblCmfDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCmfDesc.Location = new System.Drawing.Point(17, 43);
            this.lblCmfDesc.Name = "lblCmfDesc";
            this.lblCmfDesc.Size = new System.Drawing.Size(60, 13);
            this.lblCmfDesc.TabIndex = 4;
            this.lblCmfDesc.Text = "Description";
            // 
            // txtCmfItem
            // 
            this.txtCmfItem.Location = new System.Drawing.Point(146, 16);
            this.txtCmfItem.MaxLength = 20;
            this.txtCmfItem.Name = "txtCmfItem";
            this.txtCmfItem.Size = new System.Drawing.Size(195, 20);
            this.txtCmfItem.TabIndex = 1;
            // 
            // lblCmfItem
            // 
            this.lblCmfItem.AutoSize = true;
            this.lblCmfItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCmfItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCmfItem.Location = new System.Drawing.Point(18, 19);
            this.lblCmfItem.Name = "lblCmfItem";
            this.lblCmfItem.Size = new System.Drawing.Size(81, 13);
            this.lblCmfItem.TabIndex = 0;
            this.lblCmfItem.Text = "Custom Item";
            // 
            // pnlCmfItemDef
            // 
            this.pnlCmfItemDef.Controls.Add(this.spdCmfDef);
            this.pnlCmfItemDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCmfItemDef.Location = new System.Drawing.Point(0, 118);
            this.pnlCmfItemDef.Name = "pnlCmfItemDef";
            this.pnlCmfItemDef.Padding = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.pnlCmfItemDef.Size = new System.Drawing.Size(506, 388);
            this.pnlCmfItemDef.TabIndex = 2;
            // 
            // spdCmfDef
            // 
            this.spdCmfDef.AccessibleDescription = "";
            this.spdCmfDef.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdCmfDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCmfDef.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCmfDef.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCmfDef.HorizontalScrollBar.Name = "";
            this.spdCmfDef.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCmfDef.HorizontalScrollBar.TabIndex = 2;
            this.spdCmfDef.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCmfDef.Location = new System.Drawing.Point(5, 3);
            this.spdCmfDef.Name = "spdCmfDef";
            this.spdCmfDef.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdCmfDef.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdCmfDef.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCmfDef_Sheet1});
            this.spdCmfDef.Size = new System.Drawing.Size(498, 382);
            this.spdCmfDef.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCmfDef.TabIndex = 0;
            this.spdCmfDef.TabStop = false;
            this.spdCmfDef.TextTipDelay = 200;
            this.spdCmfDef.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCmfDef.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCmfDef.VerticalScrollBar.Name = "";
            this.spdCmfDef.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCmfDef.VerticalScrollBar.TabIndex = 3;
            this.spdCmfDef.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCmfDef.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.spdCmfDef_LeaveCell);
            this.spdCmfDef.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdCmfDef_EnterCell);
            this.spdCmfDef.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCmfDef_ButtonClicked);
            this.spdCmfDef.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spdCmfDef_MouseDown);
            // 
            // spdCmfDef_Sheet1
            // 
            this.spdCmfDef_Sheet1.Reset();
            spdCmfDef_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCmfDef_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCmfDef_Sheet1.ColumnCount = 5;
            spdCmfDef_Sheet1.RowCount = 5;
            this.spdCmfDef_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(1, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(1, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(1, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(1, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(2, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(2, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(2, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(2, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(3, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(3, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(3, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(3, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(4, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(4, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(4, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Cells.Get(4, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCmfDef_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCmfDef_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCmfDef_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCmfDef_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdCmfDef_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Require";
            this.spdCmfDef_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Format";
            this.spdCmfDef_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.spdCmfDef_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Table";
            this.spdCmfDef_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCmfDef_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCmfDef_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdCmfDef_Sheet1.Columns.Get(0).Border = complexBorder1;
            this.spdCmfDef_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdCmfDef_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCmfDef_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdCmfDef_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Columns.Get(0).Width = 140F;
            this.spdCmfDef_Sheet1.Columns.Get(1).Border = complexBorder2;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "Y",
        "N"};
            this.spdCmfDef_Sheet1.Columns.Get(1).CellType = comboBoxCellType1;
            this.spdCmfDef_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Columns.Get(1).Label = "Require";
            this.spdCmfDef_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Columns.Get(1).Width = 52F;
            this.spdCmfDef_Sheet1.Columns.Get(2).Border = complexBorder3;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "Ascii",
        "Number",
        "Float"};
            this.spdCmfDef_Sheet1.Columns.Get(2).CellType = comboBoxCellType2;
            this.spdCmfDef_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCmfDef_Sheet1.Columns.Get(2).Label = "Format";
            this.spdCmfDef_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Columns.Get(2).Width = 80F;
            this.spdCmfDef_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.spdCmfDef_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCmfDef_Sheet1.Columns.Get(3).Label = "Table";
            this.spdCmfDef_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Columns.Get(3).Width = 157F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdCmfDef_Sheet1.Columns.Get(4).CellType = buttonCellType1;
            this.spdCmfDef_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCmfDef_Sheet1.Columns.Get(4).Width = 22F;
            this.spdCmfDef_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCmfDef_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdCmfDef_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCmfDef_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCmfDef_Sheet1.Rows.Get(0).Height = 18F;
            this.spdCmfDef_Sheet1.Rows.Get(1).Height = 18F;
            this.spdCmfDef_Sheet1.Rows.Get(2).Height = 18F;
            this.spdCmfDef_Sheet1.Rows.Get(3).Height = 18F;
            this.spdCmfDef_Sheet1.Rows.Get(4).Height = 18F;
            this.spdCmfDef_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCmfDef_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCmfDef_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ctxSpread
            // 
            this.ctxSpread.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemove,
            this.mnuClear});
            this.ctxSpread.Name = "ctxSpread";
            this.ctxSpread.Size = new System.Drawing.Size(118, 48);
            // 
            // mnuRemove
            // 
            this.mnuRemove.Name = "mnuRemove";
            this.mnuRemove.Size = new System.Drawing.Size(117, 22);
            this.mnuRemove.Text = "Remove";
            this.mnuRemove.Click += new System.EventHandler(this.mnuRemove_Click);
            // 
            // mnuClear
            // 
            this.mnuClear.Name = "mnuClear";
            this.mnuClear.Size = new System.Drawing.Size(117, 22);
            this.mnuClear.Text = "Clear";
            this.mnuClear.Click += new System.EventHandler(this.mnuClear_Click);
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvTableList.Location = new System.Drawing.Point(180, 17);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "cdvTableList";
            this.cdvTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 0;
            this.cdvTableList.TabStop = false;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.Visible = false;
            this.cdvTableList.VisibleColumnHeader = false;
            this.cdvTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableList_SelectedItemChanged);
            // 
            // frmWIPSetupCustomizedField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupCustomizedField";
            this.Text = "Customized Field Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupCustomizedField_Activated);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
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
            this.pnlCmfItem.ResumeLayout(false);
            this.grpTableName.ResumeLayout(false);
            this.grpTableName.PerformLayout();
            this.pnlCmfItemDef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCmfDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCmfDef_Sheet1)).EndInit();
            this.ctxSpread.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.MCListView.MCListView lisCmfList;
        private System.Windows.Forms.ColumnHeader colCmfItem;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colCmfType;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.Panel pnlCmfItem;
        private System.Windows.Forms.GroupBox grpTableName;
        private System.Windows.Forms.TextBox txtCmfItem;
        private System.Windows.Forms.Label lblCmfItem;
        private System.Windows.Forms.Panel pnlCmfItemDef;
        private FarPoint.Win.Spread.FpSpread spdCmfDef;
        private FarPoint.Win.Spread.SheetView spdCmfDef_Sheet1;
        private System.Windows.Forms.TextBox txtCmfDesc;
        private System.Windows.Forms.Label lblCmfDesc;
        private System.Windows.Forms.TextBox txtCmfCount;
        private System.Windows.Forms.Label lblCmfCount;
        private System.Windows.Forms.TextBox txtCmfType;
        private System.Windows.Forms.Label lblCmfType;
        private System.Windows.Forms.ContextMenuStrip ctxSpread;
        private System.Windows.Forms.ToolStripMenuItem mnuRemove;
        private System.Windows.Forms.ToolStripMenuItem mnuClear;
        private UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
    }
}