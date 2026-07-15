namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSMeasuringResultRegistration
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.label1 = new System.Windows.Forms.Label();
            this.cdvAnaMethod = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvEquipCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label5 = new System.Windows.Forms.Label();
            this.cdvUseDept = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpPlanToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spdAnaPlanList = new FarPoint.Win.Spread.FpSpread();
            this.spdAnaPlanList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spdAnaPlanItemList = new FarPoint.Win.Spread.FpSpread();
            this.spdAnaPlanItemList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAnaMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanList_Sheet1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanItemList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.label1);
            this.grpOption.Controls.Add(this.cdvAnaMethod);
            this.grpOption.Controls.Add(this.label2);
            this.grpOption.Controls.Add(this.cdvEquipCode);
            this.grpOption.Controls.Add(this.label5);
            this.grpOption.Controls.Add(this.cdvUseDept);
            this.grpOption.Controls.Add(this.label3);
            this.grpOption.Controls.Add(this.dtpPlanToDate);
            this.grpOption.Controls.Add(this.dtpPlanFromDate);
            this.grpOption.Controls.Add(this.label4);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spcMain);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 435);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Measuring Result Registration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(250, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "~";
            // 
            // cdvAnaMethod
            // 
            this.cdvAnaMethod.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAnaMethod.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAnaMethod.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAnaMethod.BtnToolTipText = "";
            this.cdvAnaMethod.ButtonWidth = 20;
            this.cdvAnaMethod.DescText = "";
            this.cdvAnaMethod.DisplaySubItemIndex = 0;
            this.cdvAnaMethod.DisplayText = "";
            this.cdvAnaMethod.Focusing = null;
            this.cdvAnaMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAnaMethod.Index = 0;
            this.cdvAnaMethod.IsViewBtnImage = false;
            this.cdvAnaMethod.Location = new System.Drawing.Point(495, 40);
            this.cdvAnaMethod.MaxLength = 20;
            this.cdvAnaMethod.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAnaMethod.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAnaMethod.MultiSelect = false;
            this.cdvAnaMethod.Name = "cdvAnaMethod";
            this.cdvAnaMethod.ReadOnly = false;
            this.cdvAnaMethod.SameWidthHeightOfButton = false;
            this.cdvAnaMethod.SearchSubItemIndex = 0;
            this.cdvAnaMethod.SelectedDescIndex = 1;
            this.cdvAnaMethod.SelectedDescToQueryText = "";
            this.cdvAnaMethod.SelectedSubItemIndex = 0;
            this.cdvAnaMethod.SelectedValueToQueryText = "";
            this.cdvAnaMethod.SelectionStart = 0;
            this.cdvAnaMethod.Size = new System.Drawing.Size(200, 20);
            this.cdvAnaMethod.SmallImageList = null;
            this.cdvAnaMethod.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAnaMethod.TabIndex = 141;
            this.cdvAnaMethod.TextBoxToolTipText = "";
            this.cdvAnaMethod.TextBoxWidth = 80;
            this.cdvAnaMethod.VisibleButton = true;
            this.cdvAnaMethod.VisibleColumnHeader = false;
            this.cdvAnaMethod.VisibleDescription = true;
            this.cdvAnaMethod.ButtonPress += new System.EventHandler(this.cdvAnaMethod_ButtonPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(404, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 140;
            this.label2.Text = "Analysis Method";
            // 
            // cdvEquipCode
            // 
            this.cdvEquipCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEquipCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEquipCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEquipCode.BtnToolTipText = "";
            this.cdvEquipCode.ButtonWidth = 20;
            this.cdvEquipCode.DescText = "";
            this.cdvEquipCode.DisplaySubItemIndex = 0;
            this.cdvEquipCode.DisplayText = "";
            this.cdvEquipCode.Focusing = null;
            this.cdvEquipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEquipCode.Index = 0;
            this.cdvEquipCode.IsViewBtnImage = false;
            this.cdvEquipCode.Location = new System.Drawing.Point(134, 40);
            this.cdvEquipCode.MaxLength = 20;
            this.cdvEquipCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEquipCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEquipCode.MultiSelect = false;
            this.cdvEquipCode.Name = "cdvEquipCode";
            this.cdvEquipCode.ReadOnly = false;
            this.cdvEquipCode.SameWidthHeightOfButton = false;
            this.cdvEquipCode.SearchSubItemIndex = 0;
            this.cdvEquipCode.SelectedDescIndex = 1;
            this.cdvEquipCode.SelectedDescToQueryText = "";
            this.cdvEquipCode.SelectedSubItemIndex = 0;
            this.cdvEquipCode.SelectedValueToQueryText = "";
            this.cdvEquipCode.SelectionStart = 0;
            this.cdvEquipCode.Size = new System.Drawing.Size(241, 20);
            this.cdvEquipCode.SmallImageList = null;
            this.cdvEquipCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEquipCode.TabIndex = 139;
            this.cdvEquipCode.TextBoxToolTipText = "";
            this.cdvEquipCode.TextBoxWidth = 110;
            this.cdvEquipCode.VisibleButton = true;
            this.cdvEquipCode.VisibleColumnHeader = false;
            this.cdvEquipCode.VisibleDescription = true;
            this.cdvEquipCode.ButtonPress += new System.EventHandler(this.cdvEquipCode_ButtonPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(25, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 138;
            this.label5.Text = "Measuring Equipment";
            // 
            // cdvUseDept
            // 
            this.cdvUseDept.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUseDept.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUseDept.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUseDept.BtnToolTipText = "";
            this.cdvUseDept.ButtonWidth = 20;
            this.cdvUseDept.DescText = "";
            this.cdvUseDept.DisplaySubItemIndex = 0;
            this.cdvUseDept.DisplayText = "";
            this.cdvUseDept.Focusing = null;
            this.cdvUseDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUseDept.Index = 0;
            this.cdvUseDept.IsViewBtnImage = false;
            this.cdvUseDept.Location = new System.Drawing.Point(495, 14);
            this.cdvUseDept.MaxLength = 20;
            this.cdvUseDept.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUseDept.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUseDept.MultiSelect = false;
            this.cdvUseDept.Name = "cdvUseDept";
            this.cdvUseDept.ReadOnly = false;
            this.cdvUseDept.SameWidthHeightOfButton = false;
            this.cdvUseDept.SearchSubItemIndex = 0;
            this.cdvUseDept.SelectedDescIndex = 1;
            this.cdvUseDept.SelectedDescToQueryText = "";
            this.cdvUseDept.SelectedSubItemIndex = 0;
            this.cdvUseDept.SelectedValueToQueryText = "";
            this.cdvUseDept.SelectionStart = 0;
            this.cdvUseDept.Size = new System.Drawing.Size(200, 20);
            this.cdvUseDept.SmallImageList = null;
            this.cdvUseDept.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUseDept.TabIndex = 137;
            this.cdvUseDept.TextBoxToolTipText = "";
            this.cdvUseDept.TextBoxWidth = 80;
            this.cdvUseDept.VisibleButton = true;
            this.cdvUseDept.VisibleColumnHeader = false;
            this.cdvUseDept.VisibleDescription = true;
            this.cdvUseDept.ButtonPress += new System.EventHandler(this.cdvUseDept_ButtonPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(404, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 136;
            this.label3.Text = "Use Dept.";
            // 
            // dtpPlanToDate
            // 
            this.dtpPlanToDate.Checked = false;
            this.dtpPlanToDate.CustomFormat = "";
            this.dtpPlanToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanToDate.Location = new System.Drawing.Point(265, 14);
            this.dtpPlanToDate.Name = "dtpPlanToDate";
            this.dtpPlanToDate.Size = new System.Drawing.Size(110, 20);
            this.dtpPlanToDate.TabIndex = 135;
            // 
            // dtpPlanFromDate
            // 
            this.dtpPlanFromDate.Checked = false;
            this.dtpPlanFromDate.CustomFormat = "";
            this.dtpPlanFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanFromDate.Location = new System.Drawing.Point(134, 14);
            this.dtpPlanFromDate.Name = "dtpPlanFromDate";
            this.dtpPlanFromDate.Size = new System.Drawing.Size(110, 20);
            this.dtpPlanFromDate.TabIndex = 134;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(25, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 133;
            this.label4.Text = "Plan Date";
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.groupBox1);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.groupBox2);
            this.spcMain.Size = new System.Drawing.Size(742, 435);
            this.spcMain.SplitterDistance = 280;
            this.spcMain.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spdAnaPlanList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement Plan List";
            // 
            // spdAnaPlanList
            // 
            this.spdAnaPlanList.AccessibleDescription = "spdAnaPlanList, Sheet1, Row 0, Column 0, ";
            this.spdAnaPlanList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAnaPlanList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdAnaPlanList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAnaPlanList.HorizontalScrollBar.Name = "";
            this.spdAnaPlanList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdAnaPlanList.HorizontalScrollBar.TabIndex = 50;
            this.spdAnaPlanList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAnaPlanList.Location = new System.Drawing.Point(3, 16);
            this.spdAnaPlanList.Name = "spdAnaPlanList";
            this.spdAnaPlanList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAnaPlanList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAnaPlanList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAnaPlanList_Sheet1});
            this.spdAnaPlanList.Size = new System.Drawing.Size(736, 261);
            this.spdAnaPlanList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAnaPlanList.TabIndex = 51;
            this.spdAnaPlanList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAnaPlanList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAnaPlanList.VerticalScrollBar.Name = "";
            this.spdAnaPlanList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdAnaPlanList.VerticalScrollBar.TabIndex = 51;
            this.spdAnaPlanList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAnaPlanList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdAnaPlanList_SelectionChanged);
            // 
            // spdAnaPlanList_Sheet1
            // 
            this.spdAnaPlanList_Sheet1.Reset();
            spdAnaPlanList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAnaPlanList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAnaPlanList_Sheet1.ColumnCount = 14;
            spdAnaPlanList_Sheet1.RowCount = 1;
            this.spdAnaPlanList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAnaPlanList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Plan Date";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Measuring Equipment Code";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Measuring Equipment Name";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Analysis Method";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Measurement Date";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Sample Code";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Inspector Count";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Sample Count";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Repeat Count";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Create Time";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Create User";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Update Time";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Update User";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "ANA_ID";
            this.spdAnaPlanList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAnaPlanList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdAnaPlanList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnaPlanList_Sheet1.Columns.Get(0).Label = "Plan Date";
            this.spdAnaPlanList_Sheet1.Columns.Get(0).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnaPlanList_Sheet1.Columns.Get(0).Width = 87F;
            this.spdAnaPlanList_Sheet1.Columns.Get(1).Label = "Measuring Equipment Code";
            this.spdAnaPlanList_Sheet1.Columns.Get(1).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(1).Width = 92F;
            this.spdAnaPlanList_Sheet1.Columns.Get(2).Label = "Measuring Equipment Name";
            this.spdAnaPlanList_Sheet1.Columns.Get(2).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(2).Width = 153F;
            this.spdAnaPlanList_Sheet1.Columns.Get(3).Label = "Analysis Method";
            this.spdAnaPlanList_Sheet1.Columns.Get(3).Width = 117F;
            this.spdAnaPlanList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnaPlanList_Sheet1.Columns.Get(4).Label = "Measurement Date";
            this.spdAnaPlanList_Sheet1.Columns.Get(4).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(4).Width = 106F;
            this.spdAnaPlanList_Sheet1.Columns.Get(5).Label = "Sample Code";
            this.spdAnaPlanList_Sheet1.Columns.Get(5).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(5).Width = 105F;
            this.spdAnaPlanList_Sheet1.Columns.Get(6).Label = "Inspector Count";
            this.spdAnaPlanList_Sheet1.Columns.Get(6).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(6).Width = 84F;
            this.spdAnaPlanList_Sheet1.Columns.Get(7).Label = "Sample Count";
            this.spdAnaPlanList_Sheet1.Columns.Get(7).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(7).Width = 75F;
            this.spdAnaPlanList_Sheet1.Columns.Get(8).Label = "Repeat Count";
            this.spdAnaPlanList_Sheet1.Columns.Get(8).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(8).Width = 75F;
            this.spdAnaPlanList_Sheet1.Columns.Get(9).Label = "Create Time";
            this.spdAnaPlanList_Sheet1.Columns.Get(9).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(9).Width = 96F;
            this.spdAnaPlanList_Sheet1.Columns.Get(10).Label = "Create User";
            this.spdAnaPlanList_Sheet1.Columns.Get(10).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(10).Width = 96F;
            this.spdAnaPlanList_Sheet1.Columns.Get(11).Label = "Update Time";
            this.spdAnaPlanList_Sheet1.Columns.Get(11).Locked = true;
            this.spdAnaPlanList_Sheet1.Columns.Get(11).Width = 96F;
            this.spdAnaPlanList_Sheet1.Columns.Get(12).Label = "Update User";
            this.spdAnaPlanList_Sheet1.Columns.Get(12).Width = 84F;
            this.spdAnaPlanList_Sheet1.Columns.Get(13).Label = "ANA_ID";
            this.spdAnaPlanList_Sheet1.Columns.Get(13).Visible = false;
            this.spdAnaPlanList_Sheet1.Columns.Get(13).Width = 73F;
            this.spdAnaPlanList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAnaPlanList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAnaPlanList_Sheet1.RowHeader.Columns.Get(0).Width = 25F;
            this.spdAnaPlanList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAnaPlanList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAnaPlanList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spdAnaPlanItemList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 151);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Item List";
            // 
            // spdAnaPlanItemList
            // 
            this.spdAnaPlanItemList.AccessibleDescription = "spdAnaPlanItemList, Sheet1, Row 0, Column 0, ";
            this.spdAnaPlanItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAnaPlanItemList.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdAnaPlanItemList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAnaPlanItemList.HorizontalScrollBar.Name = "";
            this.spdAnaPlanItemList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdAnaPlanItemList.HorizontalScrollBar.TabIndex = 54;
            this.spdAnaPlanItemList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAnaPlanItemList.Location = new System.Drawing.Point(3, 16);
            this.spdAnaPlanItemList.Name = "spdAnaPlanItemList";
            this.spdAnaPlanItemList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAnaPlanItemList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAnaPlanItemList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAnaPlanItemList_Sheet1});
            this.spdAnaPlanItemList.Size = new System.Drawing.Size(736, 132);
            this.spdAnaPlanItemList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAnaPlanItemList.TabIndex = 52;
            this.spdAnaPlanItemList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAnaPlanItemList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAnaPlanItemList.VerticalScrollBar.Name = "";
            this.spdAnaPlanItemList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdAnaPlanItemList.VerticalScrollBar.TabIndex = 55;
            this.spdAnaPlanItemList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAnaPlanItemList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAnaPlanItemList_ButtonClicked);
            // 
            // spdAnaPlanItemList_Sheet1
            // 
            this.spdAnaPlanItemList_Sheet1.Reset();
            spdAnaPlanItemList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAnaPlanItemList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAnaPlanItemList_Sheet1.ColumnCount = 11;
            spdAnaPlanItemList_Sheet1.RowCount = 1;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "Detail";
            this.spdAnaPlanItemList_Sheet1.Cells.Get(0, 0).CellType = buttonCellType1;
            this.spdAnaPlanItemList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanItemList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAnaPlanItemList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanItemList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Detail";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Item Code";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Item Name";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Measurement Date";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "LSL";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "USL";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Unit";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Decimal Place";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "ANA_ID";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Equip Code";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Equip Name";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAnaPlanItemList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "Detail";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(0).CellType = buttonCellType2;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(0).Label = "Detail";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(0).Width = 69F;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(1).Label = "Item Code";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(1).Locked = true;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(1).Width = 102F;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(2).Label = "Item Name";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(2).Locked = true;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(2).Width = 167F;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(3).Label = "Measurement Date";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(3).Width = 100F;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(4).Label = "LSL";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(4).Locked = true;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(4).Width = 88F;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(5).Label = "USL";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(5).Locked = true;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(5).Width = 88F;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(6).Label = "Unit";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(6).Locked = true;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(6).Width = 88F;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(7).Label = "Decimal Place";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(7).Locked = true;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(7).Width = 88F;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(8).Label = "ANA_ID";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(8).Locked = true;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(8).Visible = false;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(9).Label = "Equip Code";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(9).Visible = false;
            this.spdAnaPlanItemList_Sheet1.Columns.Get(10).Label = "Equip Name";
            this.spdAnaPlanItemList_Sheet1.Columns.Get(10).Visible = false;
            this.spdAnaPlanItemList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAnaPlanItemList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAnaPlanItemList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdAnaPlanItemList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanItemList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAnaPlanItemList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnaPlanItemList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAnaPlanItemList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmMMSMeasuringResultRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSMeasuringResultRegistration";
            this.Text = "Measuring Result Registration";
            this.Activated += new System.EventHandler(this.frmMMSMeasuringResultRegistration_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvAnaMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseDept)).EndInit();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanList_Sheet1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnaPlanItemList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAnaMethod;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEquipCode;
        private System.Windows.Forms.Label label5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUseDept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpPlanToDate;
        private System.Windows.Forms.DateTimePicker dtpPlanFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private FarPoint.Win.Spread.FpSpread spdAnaPlanList;
        private FarPoint.Win.Spread.SheetView spdAnaPlanList_Sheet1;
        private System.Windows.Forms.GroupBox groupBox2;
        private FarPoint.Win.Spread.FpSpread spdAnaPlanItemList;
        private FarPoint.Win.Spread.SheetView spdAnaPlanItemList_Sheet1;


    }
}