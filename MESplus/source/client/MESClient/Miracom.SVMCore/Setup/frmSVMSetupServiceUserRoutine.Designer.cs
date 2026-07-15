namespace Miracom.SVMCore
{
    partial class frmSVMSetupServiceUserRoutine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSVMSetupServiceUserRoutine));
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.txtService = new System.Windows.Forms.TextBox();
            this.lblService = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cdvModule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblModule = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.txtLibVer = new System.Windows.Forms.TextBox();
            this.lblLibVer = new System.Windows.Forms.Label();
            this.txtLibName = new System.Windows.Forms.TextBox();
            this.lblLibrary = new System.Windows.Forms.Label();
            this.chkOverride = new System.Windows.Forms.CheckBox();
            this.chkAfter = new System.Windows.Forms.CheckBox();
            this.chkBefore = new System.Windows.Forms.CheckBox();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).BeginInit();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Text = "View";
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
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.spdList);
            this.pnlCenter.Controls.Add(this.grpData);
            this.pnlCenter.Controls.Add(this.grpFilter);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm01";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.txtService);
            this.grpFilter.Controls.Add(this.lblService);
            this.grpFilter.Controls.Add(this.cboCategory);
            this.grpFilter.Controls.Add(this.lblCategory);
            this.grpFilter.Controls.Add(this.cdvModule);
            this.grpFilter.Controls.Add(this.lblModule);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(742, 44);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // txtService
            // 
            this.txtService.Location = new System.Drawing.Point(450, 15);
            this.txtService.MaxLength = 100;
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(283, 20);
            this.txtService.TabIndex = 5;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblService.Location = new System.Drawing.Point(385, 19);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(43, 13);
            this.lblService.TabIndex = 4;
            this.lblService.Text = "Service";
            // 
            // cboCategory
            // 
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "Inquiry",
            "Setup",
            "Transaction"});
            this.cboCategory.Location = new System.Drawing.Point(252, 15);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(100, 21);
            this.cboCategory.TabIndex = 3;
            this.cboCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCategory_KeyPress);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCategory.Location = new System.Drawing.Point(193, 19);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvModule
            // 
            this.cdvModule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvModule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvModule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvModule.BtnToolTipText = "";
            this.cdvModule.DescText = "";
            this.cdvModule.DisplaySubItemIndex = -1;
            this.cdvModule.DisplayText = "";
            this.cdvModule.Focusing = null;
            this.cdvModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvModule.Index = 0;
            this.cdvModule.IsViewBtnImage = false;
            this.cdvModule.Location = new System.Drawing.Point(65, 15);
            this.cdvModule.MaxLength = 20;
            this.cdvModule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvModule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvModule.Name = "cdvModule";
            this.cdvModule.ReadOnly = false;
            this.cdvModule.SearchSubItemIndex = 0;
            this.cdvModule.SelectedDescIndex = -1;
            this.cdvModule.SelectedSubItemIndex = -1;
            this.cdvModule.SelectionStart = 0;
            this.cdvModule.Size = new System.Drawing.Size(100, 20);
            this.cdvModule.SmallImageList = null;
            this.cdvModule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvModule.TabIndex = 1;
            this.cdvModule.TextBoxToolTipText = "";
            this.cdvModule.TextBoxWidth = 100;
            this.cdvModule.VisibleButton = true;
            this.cdvModule.VisibleColumnHeader = false;
            this.cdvModule.VisibleDescription = false;
            this.cdvModule.ButtonPress += new System.EventHandler(this.cdvModule_ButtonPress);
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblModule.Location = new System.Drawing.Point(12, 19);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(42, 13);
            this.lblModule.TabIndex = 0;
            this.lblModule.Text = "Module";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtLibVer);
            this.grpData.Controls.Add(this.lblLibVer);
            this.grpData.Controls.Add(this.txtLibName);
            this.grpData.Controls.Add(this.lblLibrary);
            this.grpData.Controls.Add(this.chkOverride);
            this.grpData.Controls.Add(this.chkAfter);
            this.grpData.Controls.Add(this.chkBefore);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpData.Location = new System.Drawing.Point(0, 441);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(742, 72);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            this.grpData.Text = "Set Data";
            // 
            // txtLibVer
            // 
            this.txtLibVer.Location = new System.Drawing.Point(527, 43);
            this.txtLibVer.MaxLength = 30;
            this.txtLibVer.Name = "txtLibVer";
            this.txtLibVer.ReadOnly = true;
            this.txtLibVer.Size = new System.Drawing.Size(200, 20);
            this.txtLibVer.TabIndex = 6;
            // 
            // lblLibVer
            // 
            this.lblLibVer.AutoSize = true;
            this.lblLibVer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLibVer.Location = new System.Drawing.Point(435, 47);
            this.lblLibVer.Name = "lblLibVer";
            this.lblLibVer.Size = new System.Drawing.Size(76, 13);
            this.lblLibVer.TabIndex = 5;
            this.lblLibVer.Text = "Library Version";
            // 
            // txtLibName
            // 
            this.txtLibName.Location = new System.Drawing.Point(219, 43);
            this.txtLibName.MaxLength = 30;
            this.txtLibName.Name = "txtLibName";
            this.txtLibName.ReadOnly = true;
            this.txtLibName.Size = new System.Drawing.Size(200, 20);
            this.txtLibName.TabIndex = 4;
            // 
            // lblLibrary
            // 
            this.lblLibrary.AutoSize = true;
            this.lblLibrary.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLibrary.Location = new System.Drawing.Point(134, 47);
            this.lblLibrary.Name = "lblLibrary";
            this.lblLibrary.Size = new System.Drawing.Size(69, 13);
            this.lblLibrary.TabIndex = 3;
            this.lblLibrary.Text = "Library Name";
            // 
            // chkOverride
            // 
            this.chkOverride.AutoSize = true;
            this.chkOverride.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOverride.Location = new System.Drawing.Point(12, 44);
            this.chkOverride.Name = "chkOverride";
            this.chkOverride.Size = new System.Drawing.Size(106, 18);
            this.chkOverride.TabIndex = 2;
            this.chkOverride.Text = "Library Override";
            this.chkOverride.ThreeState = true;
            this.chkOverride.UseVisualStyleBackColor = false;
            this.chkOverride.CheckStateChanged += new System.EventHandler(this.chkOverride_CheckStateChanged);
            // 
            // chkAfter
            // 
            this.chkAfter.AutoSize = true;
            this.chkAfter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAfter.Location = new System.Drawing.Point(134, 18);
            this.chkAfter.Name = "chkAfter";
            this.chkAfter.Size = new System.Drawing.Size(93, 18);
            this.chkAfter.TabIndex = 1;
            this.chkAfter.Text = "Service After";
            this.chkAfter.ThreeState = true;
            this.chkAfter.UseVisualStyleBackColor = false;
            // 
            // chkBefore
            // 
            this.chkBefore.AutoSize = true;
            this.chkBefore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkBefore.Location = new System.Drawing.Point(12, 18);
            this.chkBefore.Name = "chkBefore";
            this.chkBefore.Size = new System.Drawing.Size(102, 18);
            this.chkBefore.TabIndex = 0;
            this.chkBefore.Text = "Service Before";
            this.chkBefore.ThreeState = true;
            this.chkBefore.UseVisualStyleBackColor = false;
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 2;
            this.spdList.Location = new System.Drawing.Point(0, 44);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 397);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 1;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 3;
            this.spdList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdList_SelectionChanged);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 13;
            spdList_Sheet1.RowCount = 3;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Module";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Cate";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Service";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Description";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Before";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "After";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Override";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Lib Name";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Lib Version";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Create User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Create Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Update User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Update Time";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Label = "Module";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 44F;
            this.spdList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Label = "Cate";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 31F;
            this.spdList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(2).Label = "Service";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 150F;
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(3).Label = "Description";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 200F;
            this.spdList_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Label = "Before";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 40F;
            this.spdList_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Label = "After";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 40F;
            this.spdList_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Label = "Override";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(7).Label = "Lib Name";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 100F;
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(8).Label = "Lib Version";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 70F;
            this.spdList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(9).Label = "Create User ID";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 90F;
            this.spdList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(10).Label = "Create Time";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 120F;
            this.spdList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(11).Label = "Update User ID";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 90F;
            this.spdList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(12).Label = "Update Time";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 120F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.spdList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmSVMSetupServiceUserRoutine
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmSVMSetupServiceUserRoutine";
            this.Text = "Service User Routine Setup";
            this.Activated += new System.EventHandler(this.frmSVMSetupServiceUserRoutine_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).EndInit();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.GroupBox grpFilter;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.Label lblModule;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvModule;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.CheckBox chkAfter;
        private System.Windows.Forms.CheckBox chkBefore;
        private System.Windows.Forms.TextBox txtLibVer;
        private System.Windows.Forms.Label lblLibVer;
        private System.Windows.Forms.TextBox txtLibName;
        private System.Windows.Forms.Label lblLibrary;
        private System.Windows.Forms.CheckBox chkOverride;
        private System.Windows.Forms.TextBox txtService;
        protected System.Windows.Forms.Button btnExcel;
    }
}
