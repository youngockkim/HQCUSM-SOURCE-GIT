namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSCalibrationResultPopup
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.txtCalibrationEquipCode = new System.Windows.Forms.TextBox();
            this.lblCalibrationInstituteCode = new System.Windows.Forms.Label();
            this.txtCalibrationEquipName = new System.Windows.Forms.TextBox();
            this.lblCalibrationEquipName = new System.Windows.Forms.Label();
            this.lblViewUseDept = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEquioNo = new System.Windows.Forms.TextBox();
            this.txtPlanDate = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbStandardEquipList = new System.Windows.Forms.GroupBox();
            this.spdStandardEquipList = new FarPoint.Win.Spread.FpSpread();
            this.spdStandardEquipList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnStandardEquipDelete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkStandardEquipAll = new System.Windows.Forms.CheckBox();
            this.btnStandardEquipAdd = new System.Windows.Forms.Button();
            this.grbCaliFileList = new System.Windows.Forms.GroupBox();
            this.spdCaliFileList = new FarPoint.Win.Spread.FpSpread();
            this.spdCaliFileList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnCaliFileDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkCaliFileAll = new System.Windows.Forms.CheckBox();
            this.btnCaliNewFile = new System.Windows.Forms.Button();
            this.grbCaliResult = new System.Windows.Forms.GroupBox();
            this.txtCaliRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudCaliAmount = new System.Windows.Forms.NumericUpDown();
            this.cboCaliResult = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvCaliUser = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.dtpCaliDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.cdvCaliDocument = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtCaliMethod = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cdvCaliInstitute = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtCaliId = new System.Windows.Forms.TextBox();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbStandardEquipList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdStandardEquipList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdStandardEquipList_Sheet1)).BeginInit();
            this.panel3.SuspendLayout();
            this.grbCaliFileList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCaliFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCaliFileList_Sheet1)).BeginInit();
            this.panel2.SuspendLayout();
            this.grbCaliResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaliAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliInstitute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.pnlMain);
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 585);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.txtCaliId);
            this.grpTranTop.Controls.Add(this.txtEquioNo);
            this.grpTranTop.Controls.Add(this.txtPlanDate);
            this.grpTranTop.Controls.Add(this.lblViewUseDept);
            this.grpTranTop.Controls.Add(this.label1);
            this.grpTranTop.Controls.Add(this.txtCalibrationEquipCode);
            this.grpTranTop.Controls.Add(this.lblCalibrationInstituteCode);
            this.grpTranTop.Controls.Add(this.txtCalibrationEquipName);
            this.grpTranTop.Controls.Add(this.lblCalibrationEquipName);
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 647);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 647);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Calibration Result Registration";
            // 
            // txtCalibrationEquipCode
            // 
            this.txtCalibrationEquipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalibrationEquipCode.Location = new System.Drawing.Point(165, 12);
            this.txtCalibrationEquipCode.MaxLength = 50;
            this.txtCalibrationEquipCode.Name = "txtCalibrationEquipCode";
            this.txtCalibrationEquipCode.ReadOnly = true;
            this.txtCalibrationEquipCode.Size = new System.Drawing.Size(164, 20);
            this.txtCalibrationEquipCode.TabIndex = 9;
            // 
            // lblCalibrationInstituteCode
            // 
            this.lblCalibrationInstituteCode.AutoSize = true;
            this.lblCalibrationInstituteCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationInstituteCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationInstituteCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCalibrationInstituteCode.Location = new System.Drawing.Point(27, 16);
            this.lblCalibrationInstituteCode.Name = "lblCalibrationInstituteCode";
            this.lblCalibrationInstituteCode.Size = new System.Drawing.Size(137, 13);
            this.lblCalibrationInstituteCode.TabIndex = 8;
            this.lblCalibrationInstituteCode.Text = "Measuring Equipment Code";
            // 
            // txtCalibrationEquipName
            // 
            this.txtCalibrationEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalibrationEquipName.Location = new System.Drawing.Point(165, 36);
            this.txtCalibrationEquipName.MaxLength = 100;
            this.txtCalibrationEquipName.Name = "txtCalibrationEquipName";
            this.txtCalibrationEquipName.ReadOnly = true;
            this.txtCalibrationEquipName.Size = new System.Drawing.Size(164, 20);
            this.txtCalibrationEquipName.TabIndex = 10;
            // 
            // lblCalibrationEquipName
            // 
            this.lblCalibrationEquipName.AutoSize = true;
            this.lblCalibrationEquipName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationEquipName.Location = new System.Drawing.Point(27, 40);
            this.lblCalibrationEquipName.Name = "lblCalibrationEquipName";
            this.lblCalibrationEquipName.Size = new System.Drawing.Size(140, 13);
            this.lblCalibrationEquipName.TabIndex = 7;
            this.lblCalibrationEquipName.Text = "Measuring Equipment Name";
            this.lblCalibrationEquipName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblViewUseDept
            // 
            this.lblViewUseDept.AutoSize = true;
            this.lblViewUseDept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblViewUseDept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblViewUseDept.Location = new System.Drawing.Point(376, 16);
            this.lblViewUseDept.Name = "lblViewUseDept";
            this.lblViewUseDept.Size = new System.Drawing.Size(129, 13);
            this.lblViewUseDept.TabIndex = 43;
            this.lblViewUseDept.Text = "Measuring Equipment No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(377, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Plan Date";
            // 
            // txtEquioNo
            // 
            this.txtEquioNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquioNo.Location = new System.Drawing.Point(511, 13);
            this.txtEquioNo.MaxLength = 50;
            this.txtEquioNo.Name = "txtEquioNo";
            this.txtEquioNo.ReadOnly = true;
            this.txtEquioNo.Size = new System.Drawing.Size(164, 20);
            this.txtEquioNo.TabIndex = 46;
            // 
            // txtPlanDate
            // 
            this.txtPlanDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlanDate.Location = new System.Drawing.Point(511, 37);
            this.txtPlanDate.MaxLength = 100;
            this.txtPlanDate.Name = "txtPlanDate";
            this.txtPlanDate.ReadOnly = true;
            this.txtPlanDate.Size = new System.Drawing.Size(164, 20);
            this.txtPlanDate.TabIndex = 47;
            this.txtPlanDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(736, 582);
            this.pnlMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbStandardEquipList);
            this.panel1.Controls.Add(this.grbCaliFileList);
            this.panel1.Controls.Add(this.grbCaliResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 582);
            this.panel1.TabIndex = 0;
            // 
            // grbStandardEquipList
            // 
            this.grbStandardEquipList.Controls.Add(this.spdStandardEquipList);
            this.grbStandardEquipList.Controls.Add(this.btnStandardEquipDelete);
            this.grbStandardEquipList.Controls.Add(this.panel3);
            this.grbStandardEquipList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbStandardEquipList.Location = new System.Drawing.Point(0, 0);
            this.grbStandardEquipList.Name = "grbStandardEquipList";
            this.grbStandardEquipList.Size = new System.Drawing.Size(736, 231);
            this.grbStandardEquipList.TabIndex = 2;
            this.grbStandardEquipList.TabStop = false;
            this.grbStandardEquipList.Text = "Standard Equipment List";
            // 
            // spdStandardEquipList
            // 
            this.spdStandardEquipList.AccessibleDescription = "spdStandardEquipList, Sheet1, Row 0, Column 0, ";
            this.spdStandardEquipList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdStandardEquipList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdStandardEquipList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdStandardEquipList.HorizontalScrollBar.Name = "";
            this.spdStandardEquipList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdStandardEquipList.HorizontalScrollBar.TabIndex = 0;
            this.spdStandardEquipList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdStandardEquipList.Location = new System.Drawing.Point(3, 43);
            this.spdStandardEquipList.Name = "spdStandardEquipList";
            this.spdStandardEquipList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdStandardEquipList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdStandardEquipList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdStandardEquipList_Sheet1});
            this.spdStandardEquipList.Size = new System.Drawing.Size(730, 185);
            this.spdStandardEquipList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdStandardEquipList.TabIndex = 45;
            this.spdStandardEquipList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdStandardEquipList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdStandardEquipList.VerticalScrollBar.Name = "";
            this.spdStandardEquipList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdStandardEquipList.VerticalScrollBar.TabIndex = 27;
            this.spdStandardEquipList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdStandardEquipList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdStandardEquipList_ButtonClicked);
            // 
            // spdStandardEquipList_Sheet1
            // 
            this.spdStandardEquipList_Sheet1.Reset();
            spdStandardEquipList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdStandardEquipList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdStandardEquipList_Sheet1.ColumnCount = 4;
            spdStandardEquipList_Sheet1.RowCount = 1;
            this.spdStandardEquipList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStandardEquipList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdStandardEquipList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStandardEquipList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdStandardEquipList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdStandardEquipList_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdStandardEquipList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Measuring Equipment Code";
            this.spdStandardEquipList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Measuring Equipment Name";
            this.spdStandardEquipList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStandardEquipList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdStandardEquipList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdStandardEquipList_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdStandardEquipList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdStandardEquipList_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdStandardEquipList_Sheet1.Columns.Get(0).Locked = false;
            this.spdStandardEquipList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdStandardEquipList_Sheet1.Columns.Get(0).Width = 47F;
            this.spdStandardEquipList_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdStandardEquipList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdStandardEquipList_Sheet1.Columns.Get(1).Label = "Measuring Equipment Code";
            this.spdStandardEquipList_Sheet1.Columns.Get(1).Locked = true;
            this.spdStandardEquipList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdStandardEquipList_Sheet1.Columns.Get(1).Width = 255F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdStandardEquipList_Sheet1.Columns.Get(2).CellType = buttonCellType1;
            this.spdStandardEquipList_Sheet1.Columns.Get(2).Width = 30F;
            this.spdStandardEquipList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdStandardEquipList_Sheet1.Columns.Get(3).Label = "Measuring Equipment Name";
            this.spdStandardEquipList_Sheet1.Columns.Get(3).Locked = true;
            this.spdStandardEquipList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdStandardEquipList_Sheet1.Columns.Get(3).Width = 355F;
            this.spdStandardEquipList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdStandardEquipList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdStandardEquipList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdStandardEquipList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStandardEquipList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdStandardEquipList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStandardEquipList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdStandardEquipList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnStandardEquipDelete
            // 
            this.btnStandardEquipDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStandardEquipDelete.Location = new System.Drawing.Point(651, 17);
            this.btnStandardEquipDelete.Name = "btnStandardEquipDelete";
            this.btnStandardEquipDelete.Size = new System.Drawing.Size(78, 25);
            this.btnStandardEquipDelete.TabIndex = 44;
            this.btnStandardEquipDelete.Text = "Delete";
            this.btnStandardEquipDelete.UseVisualStyleBackColor = true;
            this.btnStandardEquipDelete.Click += new System.EventHandler(this.btnStandardEquipDelete_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkStandardEquipAll);
            this.panel3.Controls.Add(this.btnStandardEquipAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(730, 27);
            this.panel3.TabIndex = 0;
            // 
            // chkStandardEquipAll
            // 
            this.chkStandardEquipAll.AutoSize = true;
            this.chkStandardEquipAll.Location = new System.Drawing.Point(44, 7);
            this.chkStandardEquipAll.Name = "chkStandardEquipAll";
            this.chkStandardEquipAll.Size = new System.Drawing.Size(71, 17);
            this.chkStandardEquipAll.TabIndex = 44;
            this.chkStandardEquipAll.Text = "Check All";
            this.chkStandardEquipAll.UseVisualStyleBackColor = true;
            this.chkStandardEquipAll.CheckedChanged += new System.EventHandler(this.chkStandardEquipAll_CheckedChanged);
            // 
            // btnStandardEquipAdd
            // 
            this.btnStandardEquipAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStandardEquipAdd.Location = new System.Drawing.Point(528, 0);
            this.btnStandardEquipAdd.Name = "btnStandardEquipAdd";
            this.btnStandardEquipAdd.Size = new System.Drawing.Size(78, 25);
            this.btnStandardEquipAdd.TabIndex = 43;
            this.btnStandardEquipAdd.Text = "Add";
            this.btnStandardEquipAdd.UseVisualStyleBackColor = true;
            this.btnStandardEquipAdd.Click += new System.EventHandler(this.btnStandardEquipAdd_Click);
            // 
            // grbCaliFileList
            // 
            this.grbCaliFileList.Controls.Add(this.spdCaliFileList);
            this.grbCaliFileList.Controls.Add(this.btnCaliFileDelete);
            this.grbCaliFileList.Controls.Add(this.panel2);
            this.grbCaliFileList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbCaliFileList.Location = new System.Drawing.Point(0, 231);
            this.grbCaliFileList.Name = "grbCaliFileList";
            this.grbCaliFileList.Size = new System.Drawing.Size(736, 203);
            this.grbCaliFileList.TabIndex = 1;
            this.grbCaliFileList.TabStop = false;
            this.grbCaliFileList.Text = "File List";
            // 
            // spdCaliFileList
            // 
            this.spdCaliFileList.AccessibleDescription = "spdCaliFileList, Sheet1, Row 0, Column 0, ";
            this.spdCaliFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCaliFileList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCaliFileList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCaliFileList.HorizontalScrollBar.Name = "";
            this.spdCaliFileList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdCaliFileList.HorizontalScrollBar.TabIndex = 0;
            this.spdCaliFileList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCaliFileList.Location = new System.Drawing.Point(3, 43);
            this.spdCaliFileList.Name = "spdCaliFileList";
            this.spdCaliFileList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCaliFileList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCaliFileList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCaliFileList_Sheet1});
            this.spdCaliFileList.Size = new System.Drawing.Size(730, 157);
            this.spdCaliFileList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCaliFileList.TabIndex = 45;
            this.spdCaliFileList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCaliFileList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCaliFileList.VerticalScrollBar.Name = "";
            this.spdCaliFileList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdCaliFileList.VerticalScrollBar.TabIndex = 25;
            this.spdCaliFileList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCaliFileList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCaliFileList_CellDoubleClick);
            // 
            // spdCaliFileList_Sheet1
            // 
            this.spdCaliFileList_Sheet1.Reset();
            spdCaliFileList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCaliFileList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCaliFileList_Sheet1.ColumnCount = 4;
            spdCaliFileList_Sheet1.RowCount = 1;
            this.spdCaliFileList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCaliFileList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCaliFileList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCaliFileList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCaliFileList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdCaliFileList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "File Name";
            this.spdCaliFileList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "File Path";
            this.spdCaliFileList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "File Order";
            this.spdCaliFileList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCaliFileList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCaliFileList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdCaliFileList_Sheet1.Columns.Get(0).CellType = checkBoxCellType2;
            this.spdCaliFileList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCaliFileList_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdCaliFileList_Sheet1.Columns.Get(0).Locked = false;
            this.spdCaliFileList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCaliFileList_Sheet1.Columns.Get(0).Width = 47F;
            this.spdCaliFileList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCaliFileList_Sheet1.Columns.Get(1).Label = "File Name";
            this.spdCaliFileList_Sheet1.Columns.Get(1).Locked = true;
            this.spdCaliFileList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCaliFileList_Sheet1.Columns.Get(1).Width = 285F;
            this.spdCaliFileList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCaliFileList_Sheet1.Columns.Get(2).Label = "File Path";
            this.spdCaliFileList_Sheet1.Columns.Get(2).Locked = true;
            this.spdCaliFileList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCaliFileList_Sheet1.Columns.Get(2).Width = 362F;
            this.spdCaliFileList_Sheet1.Columns.Get(3).Label = "File Order";
            this.spdCaliFileList_Sheet1.Columns.Get(3).Width = 0F;
            this.spdCaliFileList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCaliFileList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCaliFileList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdCaliFileList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCaliFileList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCaliFileList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCaliFileList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCaliFileList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnCaliFileDelete
            // 
            this.btnCaliFileDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaliFileDelete.Location = new System.Drawing.Point(651, 17);
            this.btnCaliFileDelete.Name = "btnCaliFileDelete";
            this.btnCaliFileDelete.Size = new System.Drawing.Size(78, 25);
            this.btnCaliFileDelete.TabIndex = 44;
            this.btnCaliFileDelete.Text = "Delete";
            this.btnCaliFileDelete.UseVisualStyleBackColor = true;
            this.btnCaliFileDelete.Click += new System.EventHandler(this.btnCaliFileDelete_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkCaliFileAll);
            this.panel2.Controls.Add(this.btnCaliNewFile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 27);
            this.panel2.TabIndex = 0;
            // 
            // chkCaliFileAll
            // 
            this.chkCaliFileAll.AutoSize = true;
            this.chkCaliFileAll.Location = new System.Drawing.Point(44, 7);
            this.chkCaliFileAll.Name = "chkCaliFileAll";
            this.chkCaliFileAll.Size = new System.Drawing.Size(71, 17);
            this.chkCaliFileAll.TabIndex = 44;
            this.chkCaliFileAll.Text = "Check All";
            this.chkCaliFileAll.UseVisualStyleBackColor = true;
            this.chkCaliFileAll.CheckedChanged += new System.EventHandler(this.chkCaliFileAll_CheckedChanged);
            // 
            // btnCaliNewFile
            // 
            this.btnCaliNewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaliNewFile.Location = new System.Drawing.Point(528, 0);
            this.btnCaliNewFile.Name = "btnCaliNewFile";
            this.btnCaliNewFile.Size = new System.Drawing.Size(78, 25);
            this.btnCaliNewFile.TabIndex = 43;
            this.btnCaliNewFile.Text = "New File";
            this.btnCaliNewFile.UseVisualStyleBackColor = true;
            this.btnCaliNewFile.Click += new System.EventHandler(this.btnCaliNewFile_Click);
            // 
            // grbCaliResult
            // 
            this.grbCaliResult.Controls.Add(this.txtCaliRemarks);
            this.grbCaliResult.Controls.Add(this.label5);
            this.grbCaliResult.Controls.Add(this.nudCaliAmount);
            this.grbCaliResult.Controls.Add(this.cboCaliResult);
            this.grbCaliResult.Controls.Add(this.label3);
            this.grbCaliResult.Controls.Add(this.label15);
            this.grbCaliResult.Controls.Add(this.label2);
            this.grbCaliResult.Controls.Add(this.cdvCaliUser);
            this.grbCaliResult.Controls.Add(this.dtpCaliDate);
            this.grbCaliResult.Controls.Add(this.label4);
            this.grbCaliResult.Controls.Add(this.btnFileOpen);
            this.grbCaliResult.Controls.Add(this.cdvCaliDocument);
            this.grbCaliResult.Controls.Add(this.lblFileName);
            this.grbCaliResult.Controls.Add(this.txtCaliMethod);
            this.grbCaliResult.Controls.Add(this.label30);
            this.grbCaliResult.Controls.Add(this.label29);
            this.grbCaliResult.Controls.Add(this.cdvCaliInstitute);
            this.grbCaliResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbCaliResult.Location = new System.Drawing.Point(0, 434);
            this.grbCaliResult.Name = "grbCaliResult";
            this.grbCaliResult.Size = new System.Drawing.Size(736, 148);
            this.grbCaliResult.TabIndex = 0;
            this.grbCaliResult.TabStop = false;
            this.grbCaliResult.Text = "Calibration Result";
            // 
            // txtCaliRemarks
            // 
            this.txtCaliRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaliRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaliRemarks.Location = new System.Drawing.Point(109, 100);
            this.txtCaliRemarks.MaxLength = 200;
            this.txtCaliRemarks.Multiline = true;
            this.txtCaliRemarks.Name = "txtCaliRemarks";
            this.txtCaliRemarks.Size = new System.Drawing.Size(616, 38);
            this.txtCaliRemarks.TabIndex = 128;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(14, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 129;
            this.label5.Text = "Remark";
            // 
            // nudCaliAmount
            // 
            this.nudCaliAmount.DecimalPlaces = 2;
            this.nudCaliAmount.Location = new System.Drawing.Point(319, 20);
            this.nudCaliAmount.Name = "nudCaliAmount";
            this.nudCaliAmount.Size = new System.Drawing.Size(84, 20);
            this.nudCaliAmount.TabIndex = 123;
            this.nudCaliAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboCaliResult
            // 
            this.cboCaliResult.FormattingEnabled = true;
            this.cboCaliResult.Items.AddRange(new object[] {
            "",
            "Pass",
            "Fail"});
            this.cboCaliResult.Location = new System.Drawing.Point(526, 72);
            this.cboCaliResult.Name = "cboCaliResult";
            this.cboCaliResult.Size = new System.Drawing.Size(84, 21);
            this.cboCaliResult.TabIndex = 127;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(226, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 126;
            this.label3.Text = "Calibration Cost";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label15.Location = new System.Drawing.Point(424, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 13);
            this.label15.TabIndex = 124;
            this.label15.Text = "Calibration Result";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(424, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 122;
            this.label2.Text = "Calibration User";
            // 
            // cdvCaliUser
            // 
            this.cdvCaliUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCaliUser.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCaliUser.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCaliUser.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCaliUser.BtnToolTipText = "";
            this.cdvCaliUser.ButtonWidth = 20;
            this.cdvCaliUser.DescText = "";
            this.cdvCaliUser.DisplaySubItemIndex = 0;
            this.cdvCaliUser.DisplayText = "";
            this.cdvCaliUser.Focusing = null;
            this.cdvCaliUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCaliUser.Index = 0;
            this.cdvCaliUser.IsViewBtnImage = false;
            this.cdvCaliUser.Location = new System.Drawing.Point(526, 47);
            this.cdvCaliUser.MaxLength = 20;
            this.cdvCaliUser.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCaliUser.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCaliUser.MultiSelect = false;
            this.cdvCaliUser.Name = "cdvCaliUser";
            this.cdvCaliUser.ReadOnly = false;
            this.cdvCaliUser.SameWidthHeightOfButton = false;
            this.cdvCaliUser.SearchSubItemIndex = 0;
            this.cdvCaliUser.SelectedDescIndex = 1;
            this.cdvCaliUser.SelectedDescToQueryText = "";
            this.cdvCaliUser.SelectedSubItemIndex = 0;
            this.cdvCaliUser.SelectedValueToQueryText = "";
            this.cdvCaliUser.SelectionStart = 0;
            this.cdvCaliUser.Size = new System.Drawing.Size(199, 21);
            this.cdvCaliUser.SmallImageList = null;
            this.cdvCaliUser.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCaliUser.TabIndex = 121;
            this.cdvCaliUser.TextBoxToolTipText = "";
            this.cdvCaliUser.TextBoxWidth = 75;
            this.cdvCaliUser.VisibleButton = true;
            this.cdvCaliUser.VisibleColumnHeader = false;
            this.cdvCaliUser.VisibleDescription = true;
            this.cdvCaliUser.ButtonPress += new System.EventHandler(this.cdvCaliUser_ButtonPress);
            // 
            // dtpCaliDate
            // 
            this.dtpCaliDate.CustomFormat = "";
            this.dtpCaliDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCaliDate.Location = new System.Drawing.Point(109, 20);
            this.dtpCaliDate.Name = "dtpCaliDate";
            this.dtpCaliDate.Size = new System.Drawing.Size(103, 20);
            this.dtpCaliDate.TabIndex = 120;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(14, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 119;
            this.label4.Text = "Calibration Date";
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Location = new System.Drawing.Point(360, 72);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(43, 21);
            this.btnFileOpen.TabIndex = 118;
            this.btnFileOpen.Text = "Open";
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // cdvCaliDocument
            // 
            this.cdvCaliDocument.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCaliDocument.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCaliDocument.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCaliDocument.BtnToolTipText = "";
            this.cdvCaliDocument.ButtonWidth = 50;
            this.cdvCaliDocument.DescText = "";
            this.cdvCaliDocument.DisplaySubItemIndex = -1;
            this.cdvCaliDocument.DisplayText = "";
            this.cdvCaliDocument.Focusing = null;
            this.cdvCaliDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCaliDocument.Index = 0;
            this.cdvCaliDocument.IsViewBtnImage = false;
            this.cdvCaliDocument.Location = new System.Drawing.Point(108, 72);
            this.cdvCaliDocument.MaxLength = 50;
            this.cdvCaliDocument.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCaliDocument.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCaliDocument.MultiSelect = false;
            this.cdvCaliDocument.Name = "cdvCaliDocument";
            this.cdvCaliDocument.ReadOnly = true;
            this.cdvCaliDocument.SameWidthHeightOfButton = false;
            this.cdvCaliDocument.SearchSubItemIndex = 0;
            this.cdvCaliDocument.SelectedDescIndex = -1;
            this.cdvCaliDocument.SelectedDescToQueryText = "";
            this.cdvCaliDocument.SelectedSubItemIndex = -1;
            this.cdvCaliDocument.SelectedValueToQueryText = "";
            this.cdvCaliDocument.SelectionStart = 0;
            this.cdvCaliDocument.Size = new System.Drawing.Size(252, 20);
            this.cdvCaliDocument.SmallImageList = null;
            this.cdvCaliDocument.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCaliDocument.TabIndex = 117;
            this.cdvCaliDocument.TextBoxToolTipText = "";
            this.cdvCaliDocument.TextBoxWidth = 252;
            this.cdvCaliDocument.VisibleButton = true;
            this.cdvCaliDocument.VisibleColumnHeader = false;
            this.cdvCaliDocument.VisibleDescription = false;
            this.cdvCaliDocument.ButtonPress += new System.EventHandler(this.cdvCaliPlanDoc_ButtonPress);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFileName.Location = new System.Drawing.Point(13, 76);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(82, 13);
            this.lblFileName.TabIndex = 116;
            this.lblFileName.Text = "Calibration Doc.";
            // 
            // txtCaliMethod
            // 
            this.txtCaliMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaliMethod.Location = new System.Drawing.Point(109, 47);
            this.txtCaliMethod.MaxLength = 100;
            this.txtCaliMethod.Name = "txtCaliMethod";
            this.txtCaliMethod.Size = new System.Drawing.Size(294, 20);
            this.txtCaliMethod.TabIndex = 114;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(14, 51);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(95, 13);
            this.label30.TabIndex = 115;
            this.label30.Text = "Calibration Method";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(424, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 13);
            this.label29.TabIndex = 113;
            this.label29.Text = "Calibration Institute";
            // 
            // cdvCaliInstitute
            // 
            this.cdvCaliInstitute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCaliInstitute.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCaliInstitute.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCaliInstitute.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCaliInstitute.BtnToolTipText = "";
            this.cdvCaliInstitute.ButtonWidth = 20;
            this.cdvCaliInstitute.DescText = "";
            this.cdvCaliInstitute.DisplaySubItemIndex = 0;
            this.cdvCaliInstitute.DisplayText = "";
            this.cdvCaliInstitute.Focusing = null;
            this.cdvCaliInstitute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCaliInstitute.Index = 0;
            this.cdvCaliInstitute.IsViewBtnImage = false;
            this.cdvCaliInstitute.Location = new System.Drawing.Point(526, 20);
            this.cdvCaliInstitute.MaxLength = 20;
            this.cdvCaliInstitute.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCaliInstitute.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCaliInstitute.MultiSelect = false;
            this.cdvCaliInstitute.Name = "cdvCaliInstitute";
            this.cdvCaliInstitute.ReadOnly = false;
            this.cdvCaliInstitute.SameWidthHeightOfButton = false;
            this.cdvCaliInstitute.SearchSubItemIndex = 0;
            this.cdvCaliInstitute.SelectedDescIndex = 1;
            this.cdvCaliInstitute.SelectedDescToQueryText = "";
            this.cdvCaliInstitute.SelectedSubItemIndex = 0;
            this.cdvCaliInstitute.SelectedValueToQueryText = "";
            this.cdvCaliInstitute.SelectionStart = 0;
            this.cdvCaliInstitute.Size = new System.Drawing.Size(199, 21);
            this.cdvCaliInstitute.SmallImageList = null;
            this.cdvCaliInstitute.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCaliInstitute.TabIndex = 112;
            this.cdvCaliInstitute.TextBoxToolTipText = "";
            this.cdvCaliInstitute.TextBoxWidth = 75;
            this.cdvCaliInstitute.VisibleButton = true;
            this.cdvCaliInstitute.VisibleColumnHeader = false;
            this.cdvCaliInstitute.VisibleDescription = true;
            this.cdvCaliInstitute.ButtonPress += new System.EventHandler(this.cdvCaliInstitute_ButtonPress);
            // 
            // txtCaliId
            // 
            this.txtCaliId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaliId.Location = new System.Drawing.Point(681, 13);
            this.txtCaliId.MaxLength = 100;
            this.txtCaliId.Name = "txtCaliId";
            this.txtCaliId.ReadOnly = true;
            this.txtCaliId.Size = new System.Drawing.Size(52, 20);
            this.txtCaliId.TabIndex = 48;
            this.txtCaliId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCaliId.Visible = false;
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
            // frmMMSCalibrationResultPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 687);
            this.Name = "frmMMSCalibrationResultPopup";
            this.Text = "Calibration Result Registration";
            this.Activated += new System.EventHandler(this.frmMMSCalibrationResultPopup_Activated);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grbStandardEquipList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdStandardEquipList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdStandardEquipList_Sheet1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grbCaliFileList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCaliFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCaliFileList_Sheet1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbCaliResult.ResumeLayout(false);
            this.grbCaliResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaliAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCaliInstitute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCalibrationEquipCode;
        private System.Windows.Forms.Label lblCalibrationInstituteCode;
        private System.Windows.Forms.TextBox txtCalibrationEquipName;
        private System.Windows.Forms.Label lblCalibrationEquipName;
        private System.Windows.Forms.Label lblViewUseDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtEquioNo;
        private System.Windows.Forms.TextBox txtPlanDate;
        private System.Windows.Forms.TextBox txtCaliId;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        private System.Windows.Forms.GroupBox grbStandardEquipList;
        private FarPoint.Win.Spread.FpSpread spdStandardEquipList;
        private FarPoint.Win.Spread.SheetView spdStandardEquipList_Sheet1;
        private System.Windows.Forms.Button btnStandardEquipDelete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkStandardEquipAll;
        private System.Windows.Forms.Button btnStandardEquipAdd;
        private System.Windows.Forms.GroupBox grbCaliFileList;
        private FarPoint.Win.Spread.FpSpread spdCaliFileList;
        private FarPoint.Win.Spread.SheetView spdCaliFileList_Sheet1;
        private System.Windows.Forms.Button btnCaliFileDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkCaliFileAll;
        private System.Windows.Forms.Button btnCaliNewFile;
        private System.Windows.Forms.GroupBox grbCaliResult;
        private System.Windows.Forms.TextBox txtCaliRemarks;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.NumericUpDown nudCaliAmount;
        private System.Windows.Forms.ComboBox cboCaliResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCaliUser;
        private System.Windows.Forms.DateTimePicker dtpCaliDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFileOpen;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCaliDocument;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtCaliMethod;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCaliInstitute;
    }
}