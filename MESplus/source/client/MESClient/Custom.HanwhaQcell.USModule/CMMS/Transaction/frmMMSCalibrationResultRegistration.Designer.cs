namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSCalibrationResultRegistration
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
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMMSCalibrationResultRegistration));
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cdvUseDept = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblViewUseDept = new System.Windows.Forms.Label();
            this.cdvMgtDept = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.grbCalibrationPlanList = new System.Windows.Forms.GroupBox();
            this.spdCalibrationPlanList = new FarPoint.Win.Spread.FpSpread();
            this.spdCalibrationPlanList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grbCalibrationHistory = new System.Windows.Forms.GroupBox();
            this.spdCalibrationHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdCalibrationHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtDetailEquipID = new System.Windows.Forms.TextBox();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvEquipCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPlanToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMgtDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.grbCalibrationPlanList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalibrationPlanList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalibrationPlanList_Sheet1)).BeginInit();
            this.grbCalibrationHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalibrationHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalibrationHistory_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.spcMain);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.label2);
            this.grpTranTop.Controls.Add(this.dtpPlanToDate);
            this.grpTranTop.Controls.Add(this.dtpPlanFromDate);
            this.grpTranTop.Controls.Add(this.label4);
            this.grpTranTop.Controls.Add(this.cdvEquipCode);
            this.grpTranTop.Controls.Add(this.label5);
            this.grpTranTop.Controls.Add(this.txtDetailEquipID);
            this.grpTranTop.Controls.Add(this.cdvUseDept);
            this.grpTranTop.Controls.Add(this.lblViewUseDept);
            this.grpTranTop.Controls.Add(this.cdvMgtDept);
            this.grpTranTop.Controls.Add(this.label1);
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSearch);
            this.pnlBottom.Controls.SetChildIndex(this.btnSearch, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Calibration Result Registration";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(435, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 25);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "View";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.cdvUseDept.Location = new System.Drawing.Point(483, 12);
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
            this.cdvUseDept.Size = new System.Drawing.Size(219, 20);
            this.cdvUseDept.SmallImageList = null;
            this.cdvUseDept.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUseDept.TabIndex = 44;
            this.cdvUseDept.TextBoxToolTipText = "";
            this.cdvUseDept.TextBoxWidth = 80;
            this.cdvUseDept.VisibleButton = true;
            this.cdvUseDept.VisibleColumnHeader = false;
            this.cdvUseDept.VisibleDescription = true;
            this.cdvUseDept.ButtonPress += new System.EventHandler(this.cdvUseDept_ButtonPress);
            // 
            // lblViewUseDept
            // 
            this.lblViewUseDept.AutoSize = true;
            this.lblViewUseDept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblViewUseDept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblViewUseDept.Location = new System.Drawing.Point(411, 16);
            this.lblViewUseDept.Name = "lblViewUseDept";
            this.lblViewUseDept.Size = new System.Drawing.Size(52, 13);
            this.lblViewUseDept.TabIndex = 43;
            this.lblViewUseDept.Text = "Use Dept";
            this.lblViewUseDept.Click += new System.EventHandler(this.lblViewUseDept_Click);
            // 
            // cdvMgtDept
            // 
            this.cdvMgtDept.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMgtDept.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMgtDept.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMgtDept.BtnToolTipText = "";
            this.cdvMgtDept.ButtonWidth = 20;
            this.cdvMgtDept.DescText = "";
            this.cdvMgtDept.DisplaySubItemIndex = 0;
            this.cdvMgtDept.DisplayText = "";
            this.cdvMgtDept.Focusing = null;
            this.cdvMgtDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMgtDept.Index = 0;
            this.cdvMgtDept.IsViewBtnImage = false;
            this.cdvMgtDept.Location = new System.Drawing.Point(483, 36);
            this.cdvMgtDept.MaxLength = 20;
            this.cdvMgtDept.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMgtDept.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMgtDept.MultiSelect = false;
            this.cdvMgtDept.Name = "cdvMgtDept";
            this.cdvMgtDept.ReadOnly = false;
            this.cdvMgtDept.SameWidthHeightOfButton = false;
            this.cdvMgtDept.SearchSubItemIndex = 0;
            this.cdvMgtDept.SelectedDescIndex = 1;
            this.cdvMgtDept.SelectedDescToQueryText = "";
            this.cdvMgtDept.SelectedSubItemIndex = 0;
            this.cdvMgtDept.SelectedValueToQueryText = "";
            this.cdvMgtDept.SelectionStart = 0;
            this.cdvMgtDept.Size = new System.Drawing.Size(219, 20);
            this.cdvMgtDept.SmallImageList = null;
            this.cdvMgtDept.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMgtDept.TabIndex = 46;
            this.cdvMgtDept.TextBoxToolTipText = "";
            this.cdvMgtDept.TextBoxWidth = 80;
            this.cdvMgtDept.VisibleButton = true;
            this.cdvMgtDept.VisibleColumnHeader = false;
            this.cdvMgtDept.VisibleDescription = true;
            this.cdvMgtDept.ButtonPress += new System.EventHandler(this.cdvMgtDept_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(412, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Mgt Dept";
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(3, 3);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.grbCalibrationPlanList);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.grbCalibrationHistory);
            this.spcMain.Size = new System.Drawing.Size(736, 441);
            this.spcMain.SplitterDistance = 245;
            this.spcMain.TabIndex = 0;
            // 
            // grbCalibrationPlanList
            // 
            this.grbCalibrationPlanList.Controls.Add(this.spdCalibrationPlanList);
            this.grbCalibrationPlanList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCalibrationPlanList.Location = new System.Drawing.Point(0, 0);
            this.grbCalibrationPlanList.Name = "grbCalibrationPlanList";
            this.grbCalibrationPlanList.Size = new System.Drawing.Size(736, 245);
            this.grbCalibrationPlanList.TabIndex = 0;
            this.grbCalibrationPlanList.TabStop = false;
            this.grbCalibrationPlanList.Text = "Calibration Plan List";
            // 
            // spdCalibrationPlanList
            // 
            this.spdCalibrationPlanList.AccessibleDescription = "spdCalibrationPlanList, Sheet1, Row 0, Column 0, ";
            this.spdCalibrationPlanList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCalibrationPlanList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCalibrationPlanList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCalibrationPlanList.HorizontalScrollBar.Name = "";
            this.spdCalibrationPlanList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCalibrationPlanList.HorizontalScrollBar.TabIndex = 40;
            this.spdCalibrationPlanList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCalibrationPlanList.Location = new System.Drawing.Point(3, 16);
            this.spdCalibrationPlanList.Name = "spdCalibrationPlanList";
            this.spdCalibrationPlanList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCalibrationPlanList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCalibrationPlanList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCalibrationPlanList_Sheet1});
            this.spdCalibrationPlanList.Size = new System.Drawing.Size(730, 226);
            this.spdCalibrationPlanList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCalibrationPlanList.TabIndex = 9;
            this.spdCalibrationPlanList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCalibrationPlanList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCalibrationPlanList.VerticalScrollBar.Name = "";
            this.spdCalibrationPlanList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCalibrationPlanList.VerticalScrollBar.TabIndex = 41;
            this.spdCalibrationPlanList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCalibrationPlanList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdCalibrationPlanList_SelectionChanged);
            this.spdCalibrationPlanList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCalibrationPlanList_ButtonClicked);
            this.spdCalibrationPlanList.ComboSelChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCalibrationPlanList_ComboSelChange);
            this.spdCalibrationPlanList.SetViewportLeftColumn(0, 0, 5);
            this.spdCalibrationPlanList.SetActiveViewport(0, 0, -1);
            // 
            // spdCalibrationPlanList_Sheet1
            // 
            this.spdCalibrationPlanList_Sheet1.Reset();
            spdCalibrationPlanList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCalibrationPlanList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCalibrationPlanList_Sheet1.ColumnCount = 22;
            spdCalibrationPlanList_Sheet1.RowCount = 2;
            this.spdCalibrationPlanList_Sheet1.Cells.Get(0, 1).Value = 0;
            this.spdCalibrationPlanList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationPlanList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCalibrationPlanList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationPlanList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Detail";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Measuring Equipment Code";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Measuring Equipment Name";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Measuring Equipment No.";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Spec";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Model";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Maker";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Serial No.";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Calibration Cycle(Month)";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Plan Date";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Last Calibration Date";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Last Calibration Result";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Calibration Date";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Calibration Result";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Calibration Method";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 16).ColumnSpan = 3;
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Calibration Institute";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 19).ColumnSpan = 3;
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Calibration User";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCalibrationPlanList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(0).Locked = false;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(0).Width = 29F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "Detail";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(1).CellType = buttonCellType1;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(1).Label = "Detail";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(1).Locked = false;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(2).Label = "Measuring Equipment Code";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(2).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(2).Width = 100F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(3).Label = "Measuring Equipment Name";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(3).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(3).Width = 100F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(4).Label = "Measuring Equipment No.";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(4).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(4).Width = 100F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(5).Label = "Spec";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(5).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(5).Width = 80F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(6).Label = "Model";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(6).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(6).Width = 80F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(7).Label = "Maker";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(7).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(7).Width = 80F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(8).Label = "Serial No.";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(8).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(8).Width = 80F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(9).Label = "Calibration Cycle(Month)";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(9).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(9).Width = 90F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(10).Label = "Plan Date";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(10).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(10).Width = 76F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(11).Label = "Last Calibration Date";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(11).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(11).Width = 92F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(12).Label = "Last Calibration Result";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(12).Locked = true;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(12).Width = 93F;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType1.DateDefault = new System.DateTime(2023, 6, 1, 13, 56, 44, 0);
            dateTimeCellType1.DropDownButton = true;
            dateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999");
            dateTimeCellType1.TimeDefault = new System.DateTime(2023, 6, 1, 13, 56, 44, 0);
            dateTimeCellType1.TwoDigitYearMax = 4382;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(13).CellType = dateTimeCellType1;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(13).Label = "Calibration Date";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(13).Width = 90F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(14).CellType = comboBoxCellType1;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(14).Label = "Calibration Result";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(14).Width = 76F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(15).Label = "Calibration Method";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(15).Width = 150F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(16).CellType = textCellType1;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(16).Label = "Calibration Institute";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(16).Width = 65F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(17).CellType = buttonCellType2;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(17).Width = 30F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(18).Width = 106F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(19).CellType = textCellType2;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(19).Label = "Calibration User";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(19).Width = 65F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdCalibrationPlanList_Sheet1.Columns.Get(20).CellType = buttonCellType3;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(20).Width = 28F;
            this.spdCalibrationPlanList_Sheet1.Columns.Get(21).Width = 92F;
            this.spdCalibrationPlanList_Sheet1.FrozenColumnCount = 5;
            this.spdCalibrationPlanList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCalibrationPlanList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCalibrationPlanList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdCalibrationPlanList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationPlanList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCalibrationPlanList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdCalibrationPlanList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationPlanList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCalibrationPlanList_Sheet1.ShowRowSelector = true;
            this.spdCalibrationPlanList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grbCalibrationHistory
            // 
            this.grbCalibrationHistory.Controls.Add(this.spdCalibrationHistory);
            this.grbCalibrationHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCalibrationHistory.Location = new System.Drawing.Point(0, 0);
            this.grbCalibrationHistory.Name = "grbCalibrationHistory";
            this.grbCalibrationHistory.Size = new System.Drawing.Size(736, 192);
            this.grbCalibrationHistory.TabIndex = 1;
            this.grbCalibrationHistory.TabStop = false;
            this.grbCalibrationHistory.Text = "Calibration History";
            // 
            // spdCalibrationHistory
            // 
            this.spdCalibrationHistory.AccessibleDescription = "spdCalibrationHistory, Sheet1, Row 0, Column 0, ";
            this.spdCalibrationHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCalibrationHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCalibrationHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCalibrationHistory.HorizontalScrollBar.Name = "";
            this.spdCalibrationHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdCalibrationHistory.HorizontalScrollBar.TabIndex = 16;
            this.spdCalibrationHistory.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCalibrationHistory.Location = new System.Drawing.Point(3, 16);
            this.spdCalibrationHistory.Name = "spdCalibrationHistory";
            this.spdCalibrationHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCalibrationHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCalibrationHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCalibrationHistory_Sheet1});
            this.spdCalibrationHistory.Size = new System.Drawing.Size(730, 173);
            this.spdCalibrationHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCalibrationHistory.TabIndex = 9;
            this.spdCalibrationHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCalibrationHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCalibrationHistory.VerticalScrollBar.Name = "";
            this.spdCalibrationHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdCalibrationHistory.VerticalScrollBar.TabIndex = 17;
            this.spdCalibrationHistory.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCalibrationHistory.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCalibrationHistory_ButtonClicked);
            // 
            // spdCalibrationHistory_Sheet1
            // 
            this.spdCalibrationHistory_Sheet1.Reset();
            spdCalibrationHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCalibrationHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCalibrationHistory_Sheet1.ColumnCount = 9;
            spdCalibrationHistory_Sheet1.RowCount = 1;
            this.spdCalibrationHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCalibrationHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Detail";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Cali_id";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Plan Date";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Calibration Date";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Calibration Institute";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Calibration Method";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Calibration Result";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Calibration Cost";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Remark";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCalibrationHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.Text = "Detail";
            this.spdCalibrationHistory_Sheet1.Columns.Get(0).CellType = buttonCellType4;
            this.spdCalibrationHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationHistory_Sheet1.Columns.Get(0).Label = "Detail";
            this.spdCalibrationHistory_Sheet1.Columns.Get(0).Locked = false;
            this.spdCalibrationHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationHistory_Sheet1.Columns.Get(0).VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdCalibrationHistory_Sheet1.Columns.Get(1).Label = "Cali_id";
            this.spdCalibrationHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdCalibrationHistory_Sheet1.Columns.Get(1).Resizable = false;
            this.spdCalibrationHistory_Sheet1.Columns.Get(1).Width = 0F;
            this.spdCalibrationHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationHistory_Sheet1.Columns.Get(2).Label = "Plan Date";
            this.spdCalibrationHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdCalibrationHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationHistory_Sheet1.Columns.Get(2).Width = 90F;
            this.spdCalibrationHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalibrationHistory_Sheet1.Columns.Get(3).Label = "Calibration Date";
            this.spdCalibrationHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdCalibrationHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationHistory_Sheet1.Columns.Get(3).Width = 90F;
            this.spdCalibrationHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalibrationHistory_Sheet1.Columns.Get(4).Label = "Calibration Institute";
            this.spdCalibrationHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdCalibrationHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationHistory_Sheet1.Columns.Get(4).Width = 97F;
            this.spdCalibrationHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalibrationHistory_Sheet1.Columns.Get(5).Label = "Calibration Method";
            this.spdCalibrationHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdCalibrationHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationHistory_Sheet1.Columns.Get(5).Width = 101F;
            this.spdCalibrationHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalibrationHistory_Sheet1.Columns.Get(6).Label = "Calibration Result";
            this.spdCalibrationHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdCalibrationHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalibrationHistory_Sheet1.Columns.Get(6).Width = 115F;
            numberCellType1.FractionDenominatorDigits = 2;
            this.spdCalibrationHistory_Sheet1.Columns.Get(7).CellType = numberCellType1;
            this.spdCalibrationHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCalibrationHistory_Sheet1.Columns.Get(7).Label = "Calibration Cost";
            this.spdCalibrationHistory_Sheet1.Columns.Get(7).Width = 102F;
            this.spdCalibrationHistory_Sheet1.Columns.Get(8).Label = "Remark";
            this.spdCalibrationHistory_Sheet1.Columns.Get(8).Width = 123F;
            this.spdCalibrationHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCalibrationHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCalibrationHistory_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdCalibrationHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCalibrationHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalibrationHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCalibrationHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtDetailEquipID
            // 
            this.txtDetailEquipID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetailEquipID.Location = new System.Drawing.Point(725, 19);
            this.txtDetailEquipID.MaxLength = 50;
            this.txtDetailEquipID.Name = "txtDetailEquipID";
            this.txtDetailEquipID.ReadOnly = true;
            this.txtDetailEquipID.Size = new System.Drawing.Size(14, 20);
            this.txtDetailEquipID.TabIndex = 10;
            this.txtDetailEquipID.Visible = false;
            // 
            // cdvDataList
            // 
            this.cdvDataList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvDataList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvDataList.Location = new System.Drawing.Point(349, 12);
            this.cdvDataList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Name = "cdvTableList";
            this.cdvDataList.Size = new System.Drawing.Size(20, 20);
            this.cdvDataList.SmallImageList = null;
            this.cdvDataList.TabIndex = 0;
            this.cdvDataList.TabStop = false;
            this.cdvDataList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDataList.Visible = false;
            this.cdvDataList.VisibleColumnHeader = false;
            this.cdvDataList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvDataList_SelectedItemChanged);
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
            this.cdvEquipCode.Location = new System.Drawing.Point(130, 36);
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
            this.cdvEquipCode.TabIndex = 141;
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
            this.label5.Location = new System.Drawing.Point(21, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 140;
            this.label5.Text = "Measuring Equipment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(246, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 142;
            this.label2.Text = "~";
            // 
            // dtpPlanToDate
            // 
            this.dtpPlanToDate.Checked = false;
            this.dtpPlanToDate.CustomFormat = "";
            this.dtpPlanToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanToDate.Location = new System.Drawing.Point(261, 12);
            this.dtpPlanToDate.Name = "dtpPlanToDate";
            this.dtpPlanToDate.Size = new System.Drawing.Size(110, 20);
            this.dtpPlanToDate.TabIndex = 145;
            // 
            // dtpPlanFromDate
            // 
            this.dtpPlanFromDate.Checked = false;
            this.dtpPlanFromDate.CustomFormat = "";
            this.dtpPlanFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanFromDate.Location = new System.Drawing.Point(130, 12);
            this.dtpPlanFromDate.Name = "dtpPlanFromDate";
            this.dtpPlanFromDate.Size = new System.Drawing.Size(110, 20);
            this.dtpPlanFromDate.TabIndex = 144;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(21, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 143;
            this.label4.Text = "Plan Date";
            // 
            // frmMMSCalibrationResultRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSCalibrationResultRegistration";
            this.Text = "Calibration Result Registration";
            this.Activated += new System.EventHandler(this.frmMMSCalibrationResultRegistration_Activated);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMgtDept)).EndInit();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.grbCalibrationPlanList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCalibrationPlanList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalibrationPlanList_Sheet1)).EndInit();
            this.grbCalibrationHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCalibrationHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalibrationHistory_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUseDept;
        private System.Windows.Forms.Label lblViewUseDept;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.GroupBox grbCalibrationPlanList;
        private System.Windows.Forms.GroupBox grbCalibrationHistory;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMgtDept;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Spread.FpSpread spdCalibrationPlanList;
        private FarPoint.Win.Spread.SheetView spdCalibrationPlanList_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdCalibrationHistory;
        private FarPoint.Win.Spread.SheetView spdCalibrationHistory_Sheet1;
        private System.Windows.Forms.TextBox txtDetailEquipID;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEquipCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPlanToDate;
        private System.Windows.Forms.DateTimePicker dtpPlanFromDate;
        private System.Windows.Forms.Label label4;
    }
}