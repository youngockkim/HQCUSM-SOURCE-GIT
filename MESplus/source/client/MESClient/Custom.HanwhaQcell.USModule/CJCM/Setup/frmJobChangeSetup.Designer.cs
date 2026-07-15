namespace Custom.HanwhaQcell.USModule
{
    partial class frmJobChangeSetup
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
            FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer enhancedColumnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.EnhancedColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced");
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle9 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle10 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle11 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.SpreadSkin spreadSkin3 = new FarPoint.Win.Spread.SpreadSkin();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer7 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer8 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("ColumnHeaderEnhanced");
            FarPoint.Win.Spread.SpreadSkin spreadSkin2 = new FarPoint.Win.Spread.SpreadSkin();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJobChangeSetup));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType4 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.cdvViewMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvViewLine = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpViewOrderDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpViewOrderDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtViewOrderNumber = new System.Windows.Forms.TextBox();
            this.lblCalibrationInstituteName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbCalibrationPlanList = new System.Windows.Forms.GroupBox();
            this.spdOrderList = new FarPoint.Win.Spread.FpSpread();
            this.spdOrderList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpJobInfo = new System.Windows.Forms.GroupBox();
            this.chkNewOrder = new System.Windows.Forms.CheckBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cdvLineCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvDepeCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.dtpOrdStartDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cdvAlarmCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cdvManager = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label5 = new System.Windows.Forms.Label();
            this.cdvOrderNumber = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpPlanDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spdJobChangeItem = new FarPoint.Win.Spread.FpSpread();
            this.spdJobChangeItem_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnCopyTo = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewLine)).BeginInit();
            this.panel1.SuspendLayout();
            this.grbCalibrationPlanList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrderList_Sheet1)).BeginInit();
            this.grpJobInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLineCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDepeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrderNumber)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdJobChangeItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdJobChangeItem_Sheet1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(1710, 7);
            this.btnCreate.Text = "View";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1910, 7);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1810, 7);
            this.btnUpdate.Text = "Save";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(2010, 7);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 671);
            this.pnlBottom.Size = new System.Drawing.Size(1084, 40);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.groupBox2);
            this.pnlCenter.Controls.Add(this.grpJobInfo);
            this.pnlCenter.Controls.Add(this.panel1);
            this.pnlCenter.Controls.Add(this.grpMaterial);
            this.pnlCenter.Size = new System.Drawing.Size(1084, 671);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Job Change Setup";
            enhancedColumnHeaderRenderer1.Name = "enhancedColumnHeaderRenderer1";
            enhancedColumnHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.TextRotationAngle = 0D;
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.cdvViewMaterial);
            this.grpMaterial.Controls.Add(this.cdvViewLine);
            this.grpMaterial.Controls.Add(this.label2);
            this.grpMaterial.Controls.Add(this.label1);
            this.grpMaterial.Controls.Add(this.dtpViewOrderDateTo);
            this.grpMaterial.Controls.Add(this.dtpViewOrderDateFrom);
            this.grpMaterial.Controls.Add(this.label4);
            this.grpMaterial.Controls.Add(this.txtViewOrderNumber);
            this.grpMaterial.Controls.Add(this.lblCalibrationInstituteName);
            this.grpMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterial.Location = new System.Drawing.Point(0, 0);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Size = new System.Drawing.Size(1084, 65);
            this.grpMaterial.TabIndex = 3;
            this.grpMaterial.TabStop = false;
            // 
            // cdvViewMaterial
            // 
            this.cdvViewMaterial.AddEmptyRowToLast = false;
            this.cdvViewMaterial.AddEmptyRowToTop = false;
            this.cdvViewMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvViewMaterial.DisplaySubItemIndex = 0;
            this.cdvViewMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvViewMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvViewMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvViewMaterial.LabelText = "Material";
            this.cdvViewMaterial.ListCond_ExtFactory = "";
            this.cdvViewMaterial.ListCond_StepMaterial = '1';
            this.cdvViewMaterial.ListCond_StepVersion = '1';
            this.cdvViewMaterial.Location = new System.Drawing.Point(393, 39);
            this.cdvViewMaterial.MaterialEnabled = true;
            this.cdvViewMaterial.MaterialReadOnly = false;
            this.cdvViewMaterial.Name = "cdvViewMaterial";
            this.cdvViewMaterial.SearchSubItemIndex = 0;
            this.cdvViewMaterial.SelectedDescIndex = -1;
            this.cdvViewMaterial.SelectedSubItemIndex = 0;
            this.cdvViewMaterial.Size = new System.Drawing.Size(337, 20);
            this.cdvViewMaterial.TabIndex = 117;
            this.cdvViewMaterial.VersionEnabled = true;
            this.cdvViewMaterial.VersionReadOnly = false;
            this.cdvViewMaterial.VisibleColumnHeader = false;
            this.cdvViewMaterial.VisibleDescription = true;
            this.cdvViewMaterial.VisibleMaterialButton = true;
            this.cdvViewMaterial.VisibleVersionButton = false;
            this.cdvViewMaterial.WidthButton = 20;
            this.cdvViewMaterial.WidthLabel = 74;
            this.cdvViewMaterial.WidthMaterialAndVersion = 100;
            this.cdvViewMaterial.WidthVersion = 0;
            // 
            // cdvViewLine
            // 
            this.cdvViewLine.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvViewLine.BorderHotColor = System.Drawing.Color.Black;
            this.cdvViewLine.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvViewLine.BtnToolTipText = "";
            this.cdvViewLine.ButtonWidth = 20;
            this.cdvViewLine.DescText = "";
            this.cdvViewLine.DisplaySubItemIndex = 0;
            this.cdvViewLine.DisplayText = "";
            this.cdvViewLine.Focusing = null;
            this.cdvViewLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvViewLine.Index = 0;
            this.cdvViewLine.IsViewBtnImage = false;
            this.cdvViewLine.Location = new System.Drawing.Point(467, 12);
            this.cdvViewLine.MaxLength = 40;
            this.cdvViewLine.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvViewLine.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvViewLine.MultiSelect = false;
            this.cdvViewLine.Name = "cdvViewLine";
            this.cdvViewLine.ReadOnly = false;
            this.cdvViewLine.SameWidthHeightOfButton = false;
            this.cdvViewLine.SearchSubItemIndex = 0;
            this.cdvViewLine.SelectedDescIndex = 1;
            this.cdvViewLine.SelectedDescToQueryText = "";
            this.cdvViewLine.SelectedSubItemIndex = 0;
            this.cdvViewLine.SelectedValueToQueryText = "";
            this.cdvViewLine.SelectionStart = 0;
            this.cdvViewLine.Size = new System.Drawing.Size(263, 21);
            this.cdvViewLine.SmallImageList = null;
            this.cdvViewLine.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvViewLine.TabIndex = 115;
            this.cdvViewLine.TextBoxToolTipText = "";
            this.cdvViewLine.TextBoxWidth = 100;
            this.cdvViewLine.VisibleButton = true;
            this.cdvViewLine.VisibleColumnHeader = false;
            this.cdvViewLine.VisibleDescription = true;
            this.cdvViewLine.ButtonPress += new System.EventHandler(this.cdvLine_ButtonPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(393, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "Work Line";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(243, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "~";
            // 
            // dtpViewOrderDateTo
            // 
            this.dtpViewOrderDateTo.Checked = false;
            this.dtpViewOrderDateTo.CustomFormat = "";
            this.dtpViewOrderDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpViewOrderDateTo.Location = new System.Drawing.Point(257, 12);
            this.dtpViewOrderDateTo.Name = "dtpViewOrderDateTo";
            this.dtpViewOrderDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpViewOrderDateTo.TabIndex = 113;
            // 
            // dtpViewOrderDateFrom
            // 
            this.dtpViewOrderDateFrom.Checked = false;
            this.dtpViewOrderDateFrom.CustomFormat = "";
            this.dtpViewOrderDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpViewOrderDateFrom.Location = new System.Drawing.Point(135, 12);
            this.dtpViewOrderDateFrom.Name = "dtpViewOrderDateFrom";
            this.dtpViewOrderDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpViewOrderDateFrom.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(33, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Order Start Date";
            // 
            // txtViewOrderNumber
            // 
            this.txtViewOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtViewOrderNumber.Location = new System.Drawing.Point(135, 37);
            this.txtViewOrderNumber.MaxLength = 100;
            this.txtViewOrderNumber.Name = "txtViewOrderNumber";
            this.txtViewOrderNumber.Size = new System.Drawing.Size(222, 20);
            this.txtViewOrderNumber.TabIndex = 6;
            // 
            // lblCalibrationInstituteName
            // 
            this.lblCalibrationInstituteName.AutoSize = true;
            this.lblCalibrationInstituteName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationInstituteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationInstituteName.Location = new System.Drawing.Point(33, 41);
            this.lblCalibrationInstituteName.Name = "lblCalibrationInstituteName";
            this.lblCalibrationInstituteName.Size = new System.Drawing.Size(62, 13);
            this.lblCalibrationInstituteName.TabIndex = 1;
            this.lblCalibrationInstituteName.Text = "Work Order";
            this.lblCalibrationInstituteName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbCalibrationPlanList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 155);
            this.panel1.TabIndex = 4;
            // 
            // grbCalibrationPlanList
            // 
            this.grbCalibrationPlanList.Controls.Add(this.spdOrderList);
            this.grbCalibrationPlanList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbCalibrationPlanList.Location = new System.Drawing.Point(0, 0);
            this.grbCalibrationPlanList.Name = "grbCalibrationPlanList";
            this.grbCalibrationPlanList.Size = new System.Drawing.Size(1084, 155);
            this.grbCalibrationPlanList.TabIndex = 1;
            this.grbCalibrationPlanList.TabStop = false;
            this.grbCalibrationPlanList.Text = "Order List";
            // 
            // spdOrderList
            // 
            this.spdOrderList.AccessibleDescription = "spdCalibrationPlanList, Sheet1, Row 0, Column 0, ";
            this.spdOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOrderList.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdOrderList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOrderList.HorizontalScrollBar.Name = "";
            this.spdOrderList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdOrderList.HorizontalScrollBar.TabIndex = 46;
            this.spdOrderList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOrderList.Location = new System.Drawing.Point(3, 16);
            this.spdOrderList.Name = "spdOrderList";
            namedStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            namedStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle7.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle7.Renderer = enhancedColumnHeaderRenderer1;
            namedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle8.BackColor = System.Drawing.SystemColors.Control;
            namedStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle8.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle8.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle8.Renderer = columnHeaderRenderer1;
            namedStyle8.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle9.BackColor = System.Drawing.SystemColors.Control;
            namedStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle9.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle9.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle9.Renderer = rowHeaderRenderer1;
            namedStyle9.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle10.BackColor = System.Drawing.SystemColors.Control;
            namedStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle10.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle10.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle10.Renderer = cornerRenderer2;
            namedStyle10.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle11.BackColor = System.Drawing.SystemColors.Window;
            namedStyle11.CellType = generalCellType2;
            namedStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle11.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle11.Renderer = generalCellType2;
            this.spdOrderList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle7,
            namedStyle8,
            namedStyle9,
            namedStyle10,
            namedStyle11});
            this.spdOrderList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOrderList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOrderList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOrderList_Sheet1});
            this.spdOrderList.Size = new System.Drawing.Size(1078, 136);
            spreadSkin3.ColumnFooterDefaultStyle = namedStyle8;
            spreadSkin3.ColumnHeaderDefaultStyle = namedStyle7;
            spreadSkin3.CornerDefaultStyle = namedStyle10;
            spreadSkin3.DefaultStyle = namedStyle11;
            spreadSkin3.FocusRenderer = defaultFocusIndicatorRenderer2;
            spreadSkin3.Name = "CustomSkin1";
            spreadSkin3.RowHeaderDefaultStyle = namedStyle9;
            spreadSkin3.ScrollBarRenderer = defaultScrollBarRenderer7;
            spreadSkin3.SelectionRenderer = new FarPoint.Win.Spread.DefaultSelectionRenderer();
            this.spdOrderList.Skin = spreadSkin3;
            this.spdOrderList.TabIndex = 9;
            this.spdOrderList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOrderList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOrderList.VerticalScrollBar.Name = "";
            this.spdOrderList.VerticalScrollBar.Renderer = defaultScrollBarRenderer8;
            this.spdOrderList.VerticalScrollBar.TabIndex = 47;
            this.spdOrderList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOrderList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdOrderList_SelectionChanged);
            this.spdOrderList.SetViewportLeftColumn(0, 0, 5);
            this.spdOrderList.SetActiveViewport(0, 0, -1);
            // 
            // spdOrderList_Sheet1
            // 
            this.spdOrderList_Sheet1.Reset();
            spdOrderList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOrderList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOrderList_Sheet1.ColumnCount = 10;
            spdOrderList_Sheet1.ColumnHeader.RowCount = 2;
            spdOrderList_Sheet1.RowCount = 2;
            this.spdOrderList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrderList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOrderList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrderList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Order ID";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Material\r\n";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Line";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Model";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Start Date";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 4;
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Job Change";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(1, 1).Value = "Code";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(1, 2).Value = "Description";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(1, 3).Value = "Code";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(1, 4).Value = "Description";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(1, 6).Value = "Plan Start Date";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(1, 7).Value = "Plan End Date";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(1, 8).Value = "Manager";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(1, 9).Value = "Status";
            this.spdOrderList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdOrderList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(0).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(0).Width = 100F;
            this.spdOrderList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOrderList_Sheet1.Columns.Get(1).Label = "Code";
            this.spdOrderList_Sheet1.Columns.Get(1).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(1).Width = 100F;
            this.spdOrderList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOrderList_Sheet1.Columns.Get(2).Label = "Description";
            this.spdOrderList_Sheet1.Columns.Get(2).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(2).Width = 200F;
            this.spdOrderList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOrderList_Sheet1.Columns.Get(3).Label = "Code";
            this.spdOrderList_Sheet1.Columns.Get(3).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(3).Width = 80F;
            this.spdOrderList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdOrderList_Sheet1.Columns.Get(4).Label = "Description";
            this.spdOrderList_Sheet1.Columns.Get(4).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(4).Width = 120F;
            this.spdOrderList_Sheet1.Columns.Get(5).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(5).Width = 80F;
            this.spdOrderList_Sheet1.Columns.Get(6).CellType = textCellType4;
            this.spdOrderList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(6).Label = "Plan Start Date";
            this.spdOrderList_Sheet1.Columns.Get(6).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(6).Width = 80F;
            this.spdOrderList_Sheet1.Columns.Get(7).Label = "Plan End Date";
            this.spdOrderList_Sheet1.Columns.Get(7).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(7).Width = 79F;
            this.spdOrderList_Sheet1.Columns.Get(8).CellType = textCellType5;
            this.spdOrderList_Sheet1.Columns.Get(8).Label = "Manager";
            this.spdOrderList_Sheet1.Columns.Get(8).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrderList_Sheet1.Columns.Get(8).Width = 100F;
            this.spdOrderList_Sheet1.Columns.Get(9).Label = "Status";
            this.spdOrderList_Sheet1.Columns.Get(9).Locked = true;
            this.spdOrderList_Sheet1.Columns.Get(9).Width = 80F;
            this.spdOrderList_Sheet1.FrozenColumnCount = 5;
            this.spdOrderList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOrderList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdOrderList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdOrderList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrderList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOrderList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdOrderList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrderList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOrderList_Sheet1.ShowRowSelector = true;
            this.spdOrderList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpJobInfo
            // 
            this.grpJobInfo.Controls.Add(this.btnCopyTo);
            this.grpJobInfo.Controls.Add(this.chkNewOrder);
            this.grpJobInfo.Controls.Add(this.cdvMaterial);
            this.grpJobInfo.Controls.Add(this.label12);
            this.grpJobInfo.Controls.Add(this.label11);
            this.grpJobInfo.Controls.Add(this.cdvLineCode);
            this.grpJobInfo.Controls.Add(this.cdvDepeCode);
            this.grpJobInfo.Controls.Add(this.dtpOrdStartDate);
            this.grpJobInfo.Controls.Add(this.label10);
            this.grpJobInfo.Controls.Add(this.cdvAlarmCode);
            this.grpJobInfo.Controls.Add(this.label3);
            this.grpJobInfo.Controls.Add(this.label6);
            this.grpJobInfo.Controls.Add(this.cdvManager);
            this.grpJobInfo.Controls.Add(this.label5);
            this.grpJobInfo.Controls.Add(this.cdvOrderNumber);
            this.grpJobInfo.Controls.Add(this.label7);
            this.grpJobInfo.Controls.Add(this.dtpPlanDateTo);
            this.grpJobInfo.Controls.Add(this.dtpPlanDateFrom);
            this.grpJobInfo.Controls.Add(this.label8);
            this.grpJobInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpJobInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpJobInfo.Location = new System.Drawing.Point(0, 220);
            this.grpJobInfo.Name = "grpJobInfo";
            this.grpJobInfo.Size = new System.Drawing.Size(1084, 83);
            this.grpJobInfo.TabIndex = 5;
            this.grpJobInfo.TabStop = false;
            // 
            // chkNewOrder
            // 
            this.chkNewOrder.AutoSize = true;
            this.chkNewOrder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNewOrder.Location = new System.Drawing.Point(292, 13);
            this.chkNewOrder.Name = "chkNewOrder";
            this.chkNewOrder.Size = new System.Drawing.Size(111, 17);
            this.chkNewOrder.TabIndex = 132;
            this.chkNewOrder.Text = "New Create Order";
            this.chkNewOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNewOrder.UseVisualStyleBackColor = true;
            this.chkNewOrder.CheckedChanged += new System.EventHandler(this.chkNewOrder_CheckedChanged);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(682, 11);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(390, 20);
            this.cdvMaterial.TabIndex = 129;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 74;
            this.cdvMaterial.WidthMaterialAndVersion = 130;
            this.cdvMaterial.WidthVersion = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(447, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 131;
            this.label12.Text = "Work Line";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(35, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 130;
            this.label11.Text = "Order Start Date";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvLineCode
            // 
            this.cdvLineCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLineCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLineCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLineCode.BtnToolTipText = "";
            this.cdvLineCode.ButtonWidth = 20;
            this.cdvLineCode.DescText = "";
            this.cdvLineCode.DisplaySubItemIndex = 0;
            this.cdvLineCode.DisplayText = "";
            this.cdvLineCode.Focusing = null;
            this.cdvLineCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLineCode.Index = 0;
            this.cdvLineCode.IsViewBtnImage = false;
            this.cdvLineCode.Location = new System.Drawing.Point(525, 11);
            this.cdvLineCode.MaxLength = 40;
            this.cdvLineCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLineCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLineCode.MultiSelect = false;
            this.cdvLineCode.Name = "cdvLineCode";
            this.cdvLineCode.ReadOnly = false;
            this.cdvLineCode.SameWidthHeightOfButton = false;
            this.cdvLineCode.SearchSubItemIndex = 0;
            this.cdvLineCode.SelectedDescIndex = 1;
            this.cdvLineCode.SelectedDescToQueryText = "";
            this.cdvLineCode.SelectedSubItemIndex = 0;
            this.cdvLineCode.SelectedValueToQueryText = "";
            this.cdvLineCode.SelectionStart = 0;
            this.cdvLineCode.Size = new System.Drawing.Size(100, 21);
            this.cdvLineCode.SmallImageList = null;
            this.cdvLineCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLineCode.TabIndex = 129;
            this.cdvLineCode.TextBoxToolTipText = "";
            this.cdvLineCode.TextBoxWidth = 100;
            this.cdvLineCode.VisibleButton = true;
            this.cdvLineCode.VisibleColumnHeader = false;
            this.cdvLineCode.VisibleDescription = false;
            this.cdvLineCode.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvLineCode_SelectedItemChanged);
            this.cdvLineCode.ButtonPress += new System.EventHandler(this.cdvLineCode_ButtonPress);
            // 
            // cdvDepeCode
            // 
            this.cdvDepeCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDepeCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDepeCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDepeCode.BtnToolTipText = "";
            this.cdvDepeCode.ButtonWidth = 20;
            this.cdvDepeCode.DescText = "";
            this.cdvDepeCode.DisplaySubItemIndex = 0;
            this.cdvDepeCode.DisplayText = "";
            this.cdvDepeCode.Focusing = null;
            this.cdvDepeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDepeCode.Index = 0;
            this.cdvDepeCode.IsViewBtnImage = false;
            this.cdvDepeCode.Location = new System.Drawing.Point(525, 34);
            this.cdvDepeCode.MaxLength = 40;
            this.cdvDepeCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDepeCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDepeCode.MultiSelect = false;
            this.cdvDepeCode.Name = "cdvDepeCode";
            this.cdvDepeCode.ReadOnly = false;
            this.cdvDepeCode.SameWidthHeightOfButton = false;
            this.cdvDepeCode.SearchSubItemIndex = 0;
            this.cdvDepeCode.SelectedDescIndex = 1;
            this.cdvDepeCode.SelectedDescToQueryText = "";
            this.cdvDepeCode.SelectedSubItemIndex = 0;
            this.cdvDepeCode.SelectedValueToQueryText = "";
            this.cdvDepeCode.SelectionStart = 0;
            this.cdvDepeCode.Size = new System.Drawing.Size(100, 21);
            this.cdvDepeCode.SmallImageList = null;
            this.cdvDepeCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDepeCode.TabIndex = 128;
            this.cdvDepeCode.TextBoxToolTipText = "";
            this.cdvDepeCode.TextBoxWidth = 100;
            this.cdvDepeCode.VisibleButton = true;
            this.cdvDepeCode.VisibleColumnHeader = false;
            this.cdvDepeCode.VisibleDescription = false;
            this.cdvDepeCode.ButtonPress += new System.EventHandler(this.cdvDepeCode_ButtonPress);
            // 
            // dtpOrdStartDate
            // 
            this.dtpOrdStartDate.Checked = false;
            this.dtpOrdStartDate.CustomFormat = "";
            this.dtpOrdStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrdStartDate.Location = new System.Drawing.Point(128, 34);
            this.dtpOrdStartDate.Name = "dtpOrdStartDate";
            this.dtpOrdStartDate.Size = new System.Drawing.Size(100, 20);
            this.dtpOrdStartDate.TabIndex = 125;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(447, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 127;
            this.label10.Text = "Dept Code";
            // 
            // cdvAlarmCode
            // 
            this.cdvAlarmCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCode.BtnToolTipText = "";
            this.cdvAlarmCode.ButtonWidth = 20;
            this.cdvAlarmCode.DescText = "";
            this.cdvAlarmCode.DisplaySubItemIndex = 0;
            this.cdvAlarmCode.DisplayText = "";
            this.cdvAlarmCode.Focusing = null;
            this.cdvAlarmCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCode.Index = 0;
            this.cdvAlarmCode.IsViewBtnImage = false;
            this.cdvAlarmCode.Location = new System.Drawing.Point(757, 58);
            this.cdvAlarmCode.MaxLength = 40;
            this.cdvAlarmCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode.MultiSelect = false;
            this.cdvAlarmCode.Name = "cdvAlarmCode";
            this.cdvAlarmCode.ReadOnly = false;
            this.cdvAlarmCode.SameWidthHeightOfButton = false;
            this.cdvAlarmCode.SearchSubItemIndex = 0;
            this.cdvAlarmCode.SelectedDescIndex = 1;
            this.cdvAlarmCode.SelectedDescToQueryText = "";
            this.cdvAlarmCode.SelectedSubItemIndex = 0;
            this.cdvAlarmCode.SelectedValueToQueryText = "";
            this.cdvAlarmCode.SelectionStart = 0;
            this.cdvAlarmCode.Size = new System.Drawing.Size(213, 21);
            this.cdvAlarmCode.SmallImageList = null;
            this.cdvAlarmCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCode.TabIndex = 126;
            this.cdvAlarmCode.TextBoxToolTipText = "";
            this.cdvAlarmCode.TextBoxWidth = 213;
            this.cdvAlarmCode.VisibleButton = true;
            this.cdvAlarmCode.VisibleColumnHeader = false;
            this.cdvAlarmCode.VisibleDescription = false;
            this.cdvAlarmCode.ButtonPress += new System.EventHandler(this.cdvAlarmCode_ButtonPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(681, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 123;
            this.label3.Text = "Alarm Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Work Order";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvManager
            // 
            this.cdvManager.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvManager.BorderHotColor = System.Drawing.Color.Black;
            this.cdvManager.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvManager.BtnToolTipText = "";
            this.cdvManager.ButtonWidth = 20;
            this.cdvManager.DescText = "";
            this.cdvManager.DisplaySubItemIndex = 0;
            this.cdvManager.DisplayText = "";
            this.cdvManager.Focusing = null;
            this.cdvManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvManager.Index = 0;
            this.cdvManager.IsViewBtnImage = false;
            this.cdvManager.Location = new System.Drawing.Point(757, 34);
            this.cdvManager.MaxLength = 40;
            this.cdvManager.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvManager.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvManager.MultiSelect = false;
            this.cdvManager.Name = "cdvManager";
            this.cdvManager.ReadOnly = false;
            this.cdvManager.SameWidthHeightOfButton = false;
            this.cdvManager.SearchSubItemIndex = 0;
            this.cdvManager.SelectedDescIndex = 1;
            this.cdvManager.SelectedDescToQueryText = "";
            this.cdvManager.SelectedSubItemIndex = 0;
            this.cdvManager.SelectedValueToQueryText = "";
            this.cdvManager.SelectionStart = 0;
            this.cdvManager.Size = new System.Drawing.Size(315, 21);
            this.cdvManager.SmallImageList = null;
            this.cdvManager.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvManager.TabIndex = 117;
            this.cdvManager.TextBoxToolTipText = "";
            this.cdvManager.TextBoxWidth = 130;
            this.cdvManager.VisibleButton = true;
            this.cdvManager.VisibleColumnHeader = false;
            this.cdvManager.VisibleDescription = true;
            this.cdvManager.ButtonPress += new System.EventHandler(this.cdvManager_ButtonPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(682, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 118;
            this.label5.Text = "Manager";
            // 
            // cdvOrderNumber
            // 
            this.cdvOrderNumber.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOrderNumber.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOrderNumber.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOrderNumber.BtnToolTipText = "";
            this.cdvOrderNumber.ButtonWidth = 20;
            this.cdvOrderNumber.DescText = "";
            this.cdvOrderNumber.DisplaySubItemIndex = 0;
            this.cdvOrderNumber.DisplayText = "";
            this.cdvOrderNumber.Focusing = null;
            this.cdvOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOrderNumber.Index = 0;
            this.cdvOrderNumber.IsViewBtnImage = false;
            this.cdvOrderNumber.Location = new System.Drawing.Point(128, 11);
            this.cdvOrderNumber.MaxLength = 40;
            this.cdvOrderNumber.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOrderNumber.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOrderNumber.MultiSelect = false;
            this.cdvOrderNumber.Name = "cdvOrderNumber";
            this.cdvOrderNumber.ReadOnly = false;
            this.cdvOrderNumber.SameWidthHeightOfButton = false;
            this.cdvOrderNumber.SearchSubItemIndex = 0;
            this.cdvOrderNumber.SelectedDescIndex = 1;
            this.cdvOrderNumber.SelectedDescToQueryText = "";
            this.cdvOrderNumber.SelectedSubItemIndex = 0;
            this.cdvOrderNumber.SelectedValueToQueryText = "";
            this.cdvOrderNumber.SelectionStart = 0;
            this.cdvOrderNumber.Size = new System.Drawing.Size(148, 21);
            this.cdvOrderNumber.SmallImageList = null;
            this.cdvOrderNumber.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOrderNumber.TabIndex = 115;
            this.cdvOrderNumber.TextBoxToolTipText = "";
            this.cdvOrderNumber.TextBoxWidth = 148;
            this.cdvOrderNumber.VisibleButton = true;
            this.cdvOrderNumber.VisibleColumnHeader = false;
            this.cdvOrderNumber.VisibleDescription = false;
            this.cdvOrderNumber.ButtonPress += new System.EventHandler(this.cdvOrderNumber_ButtonPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(236, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 114;
            this.label7.Text = "~";
            // 
            // dtpPlanDateTo
            // 
            this.dtpPlanDateTo.Checked = false;
            this.dtpPlanDateTo.CustomFormat = "";
            this.dtpPlanDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanDateTo.Location = new System.Drawing.Point(250, 58);
            this.dtpPlanDateTo.Name = "dtpPlanDateTo";
            this.dtpPlanDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPlanDateTo.TabIndex = 113;
            // 
            // dtpPlanDateFrom
            // 
            this.dtpPlanDateFrom.Checked = false;
            this.dtpPlanDateFrom.CustomFormat = "";
            this.dtpPlanDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanDateFrom.Location = new System.Drawing.Point(128, 58);
            this.dtpPlanDateFrom.Name = "dtpPlanDateFrom";
            this.dtpPlanDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPlanDateFrom.TabIndex = 111;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(35, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "Plan Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spdJobChangeItem);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 303);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1084, 368);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Job Change Item List";
            // 
            // spdJobChangeItem
            // 
            this.spdJobChangeItem.AccessibleDescription = "spdJobChangeItem, Sheet1, Row 0, Column 0, ";
            this.spdJobChangeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdJobChangeItem.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdJobChangeItem.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdJobChangeItem.HorizontalScrollBar.Name = "";
            this.spdJobChangeItem.HorizontalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdJobChangeItem.HorizontalScrollBar.TabIndex = 50;
            this.spdJobChangeItem.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdJobChangeItem.Location = new System.Drawing.Point(3, 42);
            this.spdJobChangeItem.Name = "spdJobChangeItem";
            namedStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = enhancedColumnHeaderRenderer1;
            namedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle6,
            namedStyle8,
            namedStyle9,
            namedStyle10,
            namedStyle11});
            this.spdJobChangeItem.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdJobChangeItem.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdJobChangeItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdJobChangeItem_Sheet1});
            this.spdJobChangeItem.Size = new System.Drawing.Size(1078, 323);
            spreadSkin2.ColumnFooterDefaultStyle = namedStyle8;
            spreadSkin2.ColumnHeaderDefaultStyle = namedStyle6;
            spreadSkin2.CornerDefaultStyle = namedStyle10;
            spreadSkin2.DefaultStyle = namedStyle11;
            spreadSkin2.FocusRenderer = defaultFocusIndicatorRenderer2;
            spreadSkin2.Name = "CustomSkin1";
            spreadSkin2.RowHeaderDefaultStyle = namedStyle9;
            spreadSkin2.ScrollBarRenderer = defaultScrollBarRenderer7;
            spreadSkin2.SelectionRenderer = new FarPoint.Win.Spread.DefaultSelectionRenderer();
            this.spdJobChangeItem.Skin = spreadSkin2;
            this.spdJobChangeItem.TabIndex = 11;
            this.spdJobChangeItem.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdJobChangeItem.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdJobChangeItem.VerticalScrollBar.Name = "";
            this.spdJobChangeItem.VerticalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdJobChangeItem.VerticalScrollBar.TabIndex = 51;
            this.spdJobChangeItem.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdJobChangeItem.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdJobChangeItem_ButtonClicked);
            this.spdJobChangeItem.SubEditorClosed += new FarPoint.Win.Spread.SubEditorClosedEventHandler(this.spdJobChangeItem_SubEditorClosed);
            this.spdJobChangeItem.SetViewportLeftColumn(0, 0, 5);
            this.spdJobChangeItem.SetActiveViewport(0, 0, -1);
            // 
            // spdJobChangeItem_Sheet1
            // 
            this.spdJobChangeItem_Sheet1.Reset();
            spdJobChangeItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdJobChangeItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdJobChangeItem_Sheet1.ColumnCount = 11;
            spdJobChangeItem_Sheet1.RowCount = 2;
            this.spdJobChangeItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdJobChangeItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 3;
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Item";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Item Name";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Auto Flag";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 2;
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Responsibility";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Plan Start Date";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Plan End Date";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Dept Code";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Alarm Code";
            this.spdJobChangeItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdJobChangeItem_Sheet1.Columns.Get(0).CellType = checkBoxCellType3;
            this.spdJobChangeItem_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdJobChangeItem_Sheet1.Columns.Get(0).Locked = false;
            this.spdJobChangeItem_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(0).Width = 29F;
            this.spdJobChangeItem_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(1).Label = "Item";
            this.spdJobChangeItem_Sheet1.Columns.Get(1).Locked = true;
            this.spdJobChangeItem_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(1).Width = 101F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdJobChangeItem_Sheet1.Columns.Get(2).CellType = buttonCellType3;
            this.spdJobChangeItem_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(2).Width = 30F;
            this.spdJobChangeItem_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdJobChangeItem_Sheet1.Columns.Get(3).Label = "Item Name";
            this.spdJobChangeItem_Sheet1.Columns.Get(3).Locked = true;
            this.spdJobChangeItem_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(3).Width = 164F;
            this.spdJobChangeItem_Sheet1.Columns.Get(4).CellType = checkBoxCellType4;
            this.spdJobChangeItem_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(4).Label = "Auto Flag";
            this.spdJobChangeItem_Sheet1.Columns.Get(4).Locked = true;
            this.spdJobChangeItem_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(5).Label = "Responsibility";
            this.spdJobChangeItem_Sheet1.Columns.Get(5).Locked = true;
            this.spdJobChangeItem_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(5).Width = 120F;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.Text = "...";
            this.spdJobChangeItem_Sheet1.Columns.Get(6).CellType = buttonCellType4;
            this.spdJobChangeItem_Sheet1.Columns.Get(6).Width = 35F;
            dateTimeCellType3.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType3.Calendar")));
            dateTimeCellType3.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType3.DateDefault = new System.DateTime(2023, 7, 27, 13, 19, 5, 0);
            dateTimeCellType3.DropDownButton = true;
            dateTimeCellType3.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999");
            dateTimeCellType3.TimeDefault = new System.DateTime(2023, 7, 27, 13, 19, 5, 0);
            this.spdJobChangeItem_Sheet1.Columns.Get(7).CellType = dateTimeCellType3;
            this.spdJobChangeItem_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdJobChangeItem_Sheet1.Columns.Get(7).Label = "Plan Start Date";
            this.spdJobChangeItem_Sheet1.Columns.Get(7).Locked = false;
            this.spdJobChangeItem_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(7).Width = 100F;
            dateTimeCellType4.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType4.Calendar")));
            dateTimeCellType4.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType4.DateDefault = new System.DateTime(2023, 7, 27, 13, 19, 5, 0);
            dateTimeCellType4.DropDownButton = true;
            dateTimeCellType4.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999");
            dateTimeCellType4.TimeDefault = new System.DateTime(2023, 7, 27, 13, 19, 5, 0);
            this.spdJobChangeItem_Sheet1.Columns.Get(8).CellType = dateTimeCellType4;
            this.spdJobChangeItem_Sheet1.Columns.Get(8).Label = "Plan End Date";
            this.spdJobChangeItem_Sheet1.Columns.Get(8).Locked = false;
            this.spdJobChangeItem_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(8).Width = 100F;
            this.spdJobChangeItem_Sheet1.Columns.Get(9).Label = "Dept Code";
            this.spdJobChangeItem_Sheet1.Columns.Get(9).Locked = true;
            this.spdJobChangeItem_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(9).Width = 70F;
            this.spdJobChangeItem_Sheet1.Columns.Get(10).CellType = textCellType6;
            this.spdJobChangeItem_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(10).Label = "Alarm Code";
            this.spdJobChangeItem_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeItem_Sheet1.Columns.Get(10).Width = 80F;
            this.spdJobChangeItem_Sheet1.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeItem_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeItem_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdJobChangeItem_Sheet1.FrozenColumnCount = 5;
            this.spdJobChangeItem_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdJobChangeItem_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdJobChangeItem_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdJobChangeItem_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeItem_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdJobChangeItem_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdJobChangeItem_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeItem_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdJobChangeItem_Sheet1.ShowRowSelector = true;
            this.spdJobChangeItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelItem);
            this.panel2.Controls.Add(this.btnAddItem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1078, 26);
            this.panel2.TabIndex = 10;
            // 
            // btnDelItem
            // 
            this.btnDelItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelItem.Location = new System.Drawing.Point(991, 1);
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.Size = new System.Drawing.Size(78, 25);
            this.btnDelItem.TabIndex = 44;
            this.btnDelItem.Text = "Delete";
            this.btnDelItem.UseVisualStyleBackColor = true;
            this.btnDelItem.Click += new System.EventHandler(this.btnDelItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Location = new System.Drawing.Point(897, 1);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(78, 25);
            this.btnAddItem.TabIndex = 43;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
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
            this.cdvDataList.Size = new System.Drawing.Size(200, 20);
            this.cdvDataList.SmallImageList = null;
            this.cdvDataList.TabIndex = 0;
            this.cdvDataList.TabStop = false;
            this.cdvDataList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDataList.Visible = false;
            this.cdvDataList.VisibleColumnHeader = false;
            this.cdvDataList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvDataList_SelectedItemChanged);
            // 
            // btnCopyTo
            // 
            this.btnCopyTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyTo.Location = new System.Drawing.Point(292, 30);
            this.btnCopyTo.Name = "btnCopyTo";
            this.btnCopyTo.Size = new System.Drawing.Size(111, 25);
            this.btnCopyTo.TabIndex = 133;
            this.btnCopyTo.Text = "Copy To";
            this.btnCopyTo.UseVisualStyleBackColor = true;
            this.btnCopyTo.Click += new System.EventHandler(this.btnCopyTo_Click);
            // 
            // frmJobChangeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 711);
            this.Name = "frmJobChangeSetup";
            this.Text = "Job Change Setup";
            this.Activated += new System.EventHandler(this.frmJobChangeSetup_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvViewLine)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grbCalibrationPlanList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrderList_Sheet1)).EndInit();
            this.grpJobInfo.ResumeLayout(false);
            this.grpJobInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLineCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDepeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrderNumber)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdJobChangeItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdJobChangeItem_Sheet1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.TextBox txtViewOrderNumber;
        private System.Windows.Forms.Label lblCalibrationInstituteName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpViewOrderDateTo;
        private System.Windows.Forms.DateTimePicker dtpViewOrderDateFrom;
        private System.Windows.Forms.Label label4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvViewLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private FarPoint.Win.Spread.FpSpread spdJobChangeItem;
        private FarPoint.Win.Spread.SheetView spdJobChangeItem_Sheet1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpJobInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvManager;
        private System.Windows.Forms.Label label5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOrderNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpPlanDateTo;
        private System.Windows.Forms.DateTimePicker dtpPlanDateFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbCalibrationPlanList;
        private FarPoint.Win.Spread.FpSpread spdOrderList;
        private FarPoint.Win.Spread.SheetView spdOrderList_Sheet1;
        private System.Windows.Forms.Button btnDelItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label label6;
        private Miracom.MESCore.Controls.udcMaterial cdvViewMaterial;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        private System.Windows.Forms.DateTimePicker dtpOrdStartDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAlarmCode;
        private System.Windows.Forms.Label label3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDepeCode;
        private System.Windows.Forms.Label label10;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLineCode;
        private System.Windows.Forms.CheckBox chkNewOrder;
        private System.Windows.Forms.Button btnCopyTo;
    }
}