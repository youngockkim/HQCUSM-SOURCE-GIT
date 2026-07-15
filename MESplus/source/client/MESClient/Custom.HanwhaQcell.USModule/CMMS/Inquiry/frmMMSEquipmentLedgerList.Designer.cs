namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSEquipmentLedgerList
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("DataAreaGrayscale");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType7 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType8 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType9 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType10 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType11 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType12 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMMSEquipmentLedgerList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbTop = new System.Windows.Forms.GroupBox();
            this.chkIdentiClass = new System.Windows.Forms.CheckBox();
            this.cdvMgtDept = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cdvInstPalce = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label2 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cdvEquipCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.grbIdentiClass = new System.Windows.Forms.GroupBox();
            this.chkStandardEquip = new System.Windows.Forms.CheckBox();
            this.chkIdleEquip = new System.Windows.Forms.CheckBox();
            this.chkCheck = new System.Windows.Forms.CheckBox();
            this.chkCalibration = new System.Windows.Forms.CheckBox();
            this.chkSPC = new System.Windows.Forms.CheckBox();
            this.chkMSA = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbMain = new System.Windows.Forms.GroupBox();
            this.spdEquipLedgerList = new FarPoint.Win.Spread.FpSpread();
            this.spdEquipLedgerList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cdvEquipType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMgtDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInstPalce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).BeginInit();
            this.grbIdentiClass.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdEquipLedgerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEquipLedgerList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.panel2);
            this.pnlCenter.Controls.Add(this.panel1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Equipment Ledger List";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 108);
            this.panel1.TabIndex = 0;
            // 
            // grbTop
            // 
            this.grbTop.Controls.Add(this.label4);
            this.grbTop.Controls.Add(this.cdvEquipType);
            this.grbTop.Controls.Add(this.chkIdentiClass);
            this.grbTop.Controls.Add(this.cdvMgtDept);
            this.grbTop.Controls.Add(this.label3);
            this.grbTop.Controls.Add(this.label1);
            this.grbTop.Controls.Add(this.cdvInstPalce);
            this.grbTop.Controls.Add(this.label2);
            this.grbTop.Controls.Add(this.cboYear);
            this.grbTop.Controls.Add(this.label5);
            this.grbTop.Controls.Add(this.cdvEquipCode);
            this.grbTop.Controls.Add(this.grbIdentiClass);
            this.grbTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTop.Location = new System.Drawing.Point(0, 0);
            this.grbTop.Name = "grbTop";
            this.grbTop.Size = new System.Drawing.Size(742, 108);
            this.grbTop.TabIndex = 0;
            this.grbTop.TabStop = false;
            // 
            // chkIdentiClass
            // 
            this.chkIdentiClass.AutoSize = true;
            this.chkIdentiClass.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIdentiClass.Location = new System.Drawing.Point(19, 83);
            this.chkIdentiClass.Name = "chkIdentiClass";
            this.chkIdentiClass.Size = new System.Drawing.Size(95, 17);
            this.chkIdentiClass.TabIndex = 151;
            this.chkIdentiClass.Text = "Identity Criteria";
            this.chkIdentiClass.UseVisualStyleBackColor = true;
            this.chkIdentiClass.CheckedChanged += new System.EventHandler(this.chkIdentiClass_CheckedChanged);
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
            this.cdvMgtDept.Location = new System.Drawing.Point(126, 56);
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
            this.cdvMgtDept.Size = new System.Drawing.Size(210, 20);
            this.cdvMgtDept.SmallImageList = null;
            this.cdvMgtDept.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMgtDept.TabIndex = 143;
            this.cdvMgtDept.TextBoxToolTipText = "";
            this.cdvMgtDept.TextBoxWidth = 85;
            this.cdvMgtDept.VisibleButton = true;
            this.cdvMgtDept.VisibleColumnHeader = false;
            this.cdvMgtDept.VisibleDescription = true;
            this.cdvMgtDept.ButtonPress += new System.EventHandler(this.cdvMgtDept_ButtonPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(23, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 142;
            this.label3.Text = "Mgt Dept";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 148;
            this.label1.Text = "Year";
            // 
            // cdvInstPalce
            // 
            this.cdvInstPalce.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInstPalce.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInstPalce.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInstPalce.BtnToolTipText = "";
            this.cdvInstPalce.ButtonWidth = 20;
            this.cdvInstPalce.DescText = "";
            this.cdvInstPalce.DisplaySubItemIndex = 0;
            this.cdvInstPalce.DisplayText = "";
            this.cdvInstPalce.Focusing = null;
            this.cdvInstPalce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInstPalce.Index = 0;
            this.cdvInstPalce.IsViewBtnImage = false;
            this.cdvInstPalce.Location = new System.Drawing.Point(475, 56);
            this.cdvInstPalce.MaxLength = 20;
            this.cdvInstPalce.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInstPalce.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInstPalce.MultiSelect = false;
            this.cdvInstPalce.Name = "cdvInstPalce";
            this.cdvInstPalce.ReadOnly = false;
            this.cdvInstPalce.SameWidthHeightOfButton = false;
            this.cdvInstPalce.SearchSubItemIndex = 0;
            this.cdvInstPalce.SelectedDescIndex = 1;
            this.cdvInstPalce.SelectedDescToQueryText = "";
            this.cdvInstPalce.SelectedSubItemIndex = 0;
            this.cdvInstPalce.SelectedValueToQueryText = "";
            this.cdvInstPalce.SelectionStart = 0;
            this.cdvInstPalce.Size = new System.Drawing.Size(241, 20);
            this.cdvInstPalce.SmallImageList = null;
            this.cdvInstPalce.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInstPalce.TabIndex = 147;
            this.cdvInstPalce.TextBoxToolTipText = "";
            this.cdvInstPalce.TextBoxWidth = 100;
            this.cdvInstPalce.VisibleButton = true;
            this.cdvInstPalce.VisibleColumnHeader = false;
            this.cdvInstPalce.VisibleDescription = true;
            this.cdvInstPalce.ButtonPress += new System.EventHandler(this.cdvInstPalce_ButtonPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(360, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 146;
            this.label2.Text = "Installation Place";
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(126, 10);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(82, 21);
            this.cboYear.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(360, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 144;
            this.label5.Text = "Measuring Equipment";
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
            this.cdvEquipCode.Location = new System.Drawing.Point(475, 33);
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
            this.cdvEquipCode.TabIndex = 145;
            this.cdvEquipCode.TextBoxToolTipText = "";
            this.cdvEquipCode.TextBoxWidth = 100;
            this.cdvEquipCode.VisibleButton = true;
            this.cdvEquipCode.VisibleColumnHeader = false;
            this.cdvEquipCode.VisibleDescription = true;
            this.cdvEquipCode.ButtonPress += new System.EventHandler(this.cdvEquipCode_ButtonPress);
            // 
            // grbIdentiClass
            // 
            this.grbIdentiClass.Controls.Add(this.chkStandardEquip);
            this.grbIdentiClass.Controls.Add(this.chkIdleEquip);
            this.grbIdentiClass.Controls.Add(this.chkCheck);
            this.grbIdentiClass.Controls.Add(this.chkCalibration);
            this.grbIdentiClass.Controls.Add(this.chkSPC);
            this.grbIdentiClass.Controls.Add(this.chkMSA);
            this.grbIdentiClass.Enabled = false;
            this.grbIdentiClass.Location = new System.Drawing.Point(125, 74);
            this.grbIdentiClass.Name = "grbIdentiClass";
            this.grbIdentiClass.Size = new System.Drawing.Size(591, 30);
            this.grbIdentiClass.TabIndex = 150;
            this.grbIdentiClass.TabStop = false;
            // 
            // chkStandardEquip
            // 
            this.chkStandardEquip.AutoSize = true;
            this.chkStandardEquip.Location = new System.Drawing.Point(464, 9);
            this.chkStandardEquip.Name = "chkStandardEquip";
            this.chkStandardEquip.Size = new System.Drawing.Size(115, 17);
            this.chkStandardEquip.TabIndex = 5;
            this.chkStandardEquip.Text = "(S)Standard Equip.";
            this.chkStandardEquip.UseVisualStyleBackColor = true;
            // 
            // chkIdleEquip
            // 
            this.chkIdleEquip.AutoSize = true;
            this.chkIdleEquip.Location = new System.Drawing.Point(341, 9);
            this.chkIdleEquip.Name = "chkIdleEquip";
            this.chkIdleEquip.Size = new System.Drawing.Size(109, 17);
            this.chkIdleEquip.TabIndex = 4;
            this.chkIdleEquip.Text = "(E)Idle Equipment";
            this.chkIdleEquip.UseVisualStyleBackColor = true;
            // 
            // chkCheck
            // 
            this.chkCheck.AutoSize = true;
            this.chkCheck.Location = new System.Drawing.Point(258, 9);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Size = new System.Drawing.Size(71, 17);
            this.chkCheck.TabIndex = 3;
            this.chkCheck.Text = "(D)Check";
            this.chkCheck.UseVisualStyleBackColor = true;
            // 
            // chkCalibration
            // 
            this.chkCalibration.AutoSize = true;
            this.chkCalibration.Location = new System.Drawing.Point(156, 9);
            this.chkCalibration.Name = "chkCalibration";
            this.chkCalibration.Size = new System.Drawing.Size(88, 17);
            this.chkCalibration.TabIndex = 2;
            this.chkCalibration.Text = "(C)Calibration";
            this.chkCalibration.UseVisualStyleBackColor = true;
            // 
            // chkSPC
            // 
            this.chkSPC.AutoSize = true;
            this.chkSPC.Location = new System.Drawing.Point(82, 9);
            this.chkSPC.Name = "chkSPC";
            this.chkSPC.Size = new System.Drawing.Size(60, 17);
            this.chkSPC.TabIndex = 1;
            this.chkSPC.Text = "(B)SPC";
            this.chkSPC.UseVisualStyleBackColor = true;
            // 
            // chkMSA
            // 
            this.chkMSA.AutoSize = true;
            this.chkMSA.Location = new System.Drawing.Point(6, 9);
            this.chkMSA.Name = "chkMSA";
            this.chkMSA.Size = new System.Drawing.Size(62, 17);
            this.chkMSA.TabIndex = 0;
            this.chkMSA.Text = "(A)MSA";
            this.chkMSA.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grbMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 398);
            this.panel2.TabIndex = 1;
            // 
            // grbMain
            // 
            this.grbMain.Controls.Add(this.spdEquipLedgerList);
            this.grbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbMain.Location = new System.Drawing.Point(0, 0);
            this.grbMain.Name = "grbMain";
            this.grbMain.Size = new System.Drawing.Size(742, 398);
            this.grbMain.TabIndex = 0;
            this.grbMain.TabStop = false;
            this.grbMain.Text = "Measuring Equipment List";
            // 
            // spdEquipLedgerList
            // 
            this.spdEquipLedgerList.AccessibleDescription = "spdEquipLedgerList, Sheet1, Row 0, Column 0, ";
            this.spdEquipLedgerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdEquipLedgerList.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdEquipLedgerList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEquipLedgerList.HorizontalScrollBar.Name = "";
            this.spdEquipLedgerList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdEquipLedgerList.HorizontalScrollBar.TabIndex = 58;
            this.spdEquipLedgerList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdEquipLedgerList.Location = new System.Drawing.Point(3, 16);
            this.spdEquipLedgerList.Name = "spdEquipLedgerList";
            namedStyle2.BackColor = System.Drawing.Color.Gainsboro;
            namedStyle2.CellType = generalCellType2;
            namedStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = generalCellType2;
            this.spdEquipLedgerList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle2});
            this.spdEquipLedgerList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdEquipLedgerList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdEquipLedgerList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdEquipLedgerList_Sheet1});
            this.spdEquipLedgerList.Size = new System.Drawing.Size(736, 379);
            this.spdEquipLedgerList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdEquipLedgerList.TabIndex = 52;
            this.spdEquipLedgerList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdEquipLedgerList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEquipLedgerList.VerticalScrollBar.Name = "";
            this.spdEquipLedgerList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdEquipLedgerList.VerticalScrollBar.TabIndex = 59;
            this.spdEquipLedgerList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdEquipLedgerList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdEquipLedgerList_Sheet1
            // 
            this.spdEquipLedgerList_Sheet1.Reset();
            spdEquipLedgerList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdEquipLedgerList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdEquipLedgerList_Sheet1.ColumnCount = 33;
            spdEquipLedgerList_Sheet1.ColumnHeader.RowCount = 4;
            spdEquipLedgerList_Sheet1.RowCount = 1;
            this.spdEquipLedgerList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipLedgerList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdEquipLedgerList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipLedgerList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 4;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Measuring Equipment Code";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 4;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Measuring Equipment Name";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 4;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Installation Place";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 4;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Identity Code";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 6;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Identity Criteria";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Analysis Method";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Measurement Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Sample Code";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 10).ColumnSpan = 7;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Measuring Equipment Calibration";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Sample Count";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Repeat Count";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Create Time";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Create User";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Update Time";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Update User";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 17).ColumnSpan = 16;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Measuring System Analysis(MSA)";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 4).RowSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 4).Value = "(A)MSA";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 5).RowSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 5).Value = "(B)SPC";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 6).RowSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 6).Value = "(C)Calibration";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 7).RowSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 7).Value = "(D)Check";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 8).RowSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 8).Value = "(E)Idle Equipment";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 9).RowSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 9).Value = "(S)Standard Equipment";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 10).RowSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 10).Value = "Management Cycle";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 11).RowSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 11).Value = "Calibration Institute";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 12).ColumnSpan = 2;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 12).Value = "Result of 2022";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 14).ColumnSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 14).Value = "Result of 2023";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 17).RowSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 17).Value = "Management Cycle";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 18).ColumnSpan = 6;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 18).Value = "Result of 2022";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 24).ColumnSpan = 9;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(1, 24).Value = "Result of 2023";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 2).Value = "Installation Place";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 12).RowSpan = 2;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 12).Value = "Calibration Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 13).RowSpan = 2;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 13).Value = "Result";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 14).RowSpan = 2;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 14).Value = "Plan Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 15).RowSpan = 2;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 15).Value = "Calibration Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 16).RowSpan = 2;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 16).Value = "Result";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 18).ColumnSpan = 2;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 18).Value = "Reputability and Reproducibility";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 20).ColumnSpan = 2;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 20).Value = "%linearity";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 22).ColumnSpan = 2;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 22).Value = "bias";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 24).ColumnSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 24).Value = "Reputability and Reproducibility";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 27).ColumnSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 27).Value = "%linearity";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 30).ColumnSpan = 3;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(2, 30).Value = "bias";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 18).Value = "Impl Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 19).Value = "%GRR(<10%)";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 20).Value = "Impl Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 21).Value = "¡Â 5%";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 22).Value = "Impl Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 23).Value = "t statistic < 2.145";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 24).Value = "Plan Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 25).Value = "Impl Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 26).Value = "%GRR(<10%)";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 27).Value = "Plan Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 28).Value = "Impl Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 29).Value = "¡Â 5%";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 30).Value = "Plan Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 31).Value = "Impl Date";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Cells.Get(3, 32).Value = "t statistic < 2.145";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipLedgerList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdEquipLedgerList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(0).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(0).Width = 92F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(1).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(1).Width = 153F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(2).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(2).Width = 113F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(3).Locked = true;
            checkBoxCellType7.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdEquipLedgerList_Sheet1.Columns.Get(4).CellType = checkBoxCellType7;
            this.spdEquipLedgerList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipLedgerList_Sheet1.Columns.Get(4).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(4).Width = 50F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(5).CellType = checkBoxCellType8;
            this.spdEquipLedgerList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipLedgerList_Sheet1.Columns.Get(5).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(5).Width = 50F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(6).CellType = checkBoxCellType9;
            this.spdEquipLedgerList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipLedgerList_Sheet1.Columns.Get(6).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(7).CellType = checkBoxCellType10;
            this.spdEquipLedgerList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipLedgerList_Sheet1.Columns.Get(7).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(8).CellType = checkBoxCellType11;
            this.spdEquipLedgerList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipLedgerList_Sheet1.Columns.Get(8).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(9).CellType = checkBoxCellType12;
            this.spdEquipLedgerList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipLedgerList_Sheet1.Columns.Get(9).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(9).Width = 65F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(10).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(10).Width = 75F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(11).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(11).Width = 75F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(12).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(12).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(13).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(13).Width = 80F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(14).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(14).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(15).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(15).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(16).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(16).Width = 80F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(17).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(17).Width = 80F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(18).Label = "Impl Date";
            this.spdEquipLedgerList_Sheet1.Columns.Get(18).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(18).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(19).Label = "%GRR(<10%)";
            this.spdEquipLedgerList_Sheet1.Columns.Get(19).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(19).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(20).Label = "Impl Date";
            this.spdEquipLedgerList_Sheet1.Columns.Get(20).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(20).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(21).Label = "¡Â 5%";
            this.spdEquipLedgerList_Sheet1.Columns.Get(21).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(21).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(22).Label = "Impl Date";
            this.spdEquipLedgerList_Sheet1.Columns.Get(22).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(22).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(23).Label = "t statistic < 2.145";
            this.spdEquipLedgerList_Sheet1.Columns.Get(23).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(23).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(24).Label = "Plan Date";
            this.spdEquipLedgerList_Sheet1.Columns.Get(24).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(24).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(25).Label = "Impl Date";
            this.spdEquipLedgerList_Sheet1.Columns.Get(25).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(25).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(26).Label = "%GRR(<10%)";
            this.spdEquipLedgerList_Sheet1.Columns.Get(26).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(26).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(27).Label = "Plan Date";
            this.spdEquipLedgerList_Sheet1.Columns.Get(27).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(27).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(28).Label = "Impl Date";
            this.spdEquipLedgerList_Sheet1.Columns.Get(28).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(29).Label = "¡Â 5%";
            this.spdEquipLedgerList_Sheet1.Columns.Get(29).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(30).Label = "Plan Date";
            this.spdEquipLedgerList_Sheet1.Columns.Get(30).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(30).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(31).Label = "Impl Date";
            this.spdEquipLedgerList_Sheet1.Columns.Get(31).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(31).Width = 90F;
            this.spdEquipLedgerList_Sheet1.Columns.Get(32).Label = "t statistic < 2.145";
            this.spdEquipLedgerList_Sheet1.Columns.Get(32).Locked = true;
            this.spdEquipLedgerList_Sheet1.Columns.Get(32).Width = 90F;
            this.spdEquipLedgerList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdEquipLedgerList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdEquipLedgerList_Sheet1.RowHeader.Columns.Get(0).Width = 25F;
            this.spdEquipLedgerList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipLedgerList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdEquipLedgerList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipLedgerList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdEquipLedgerList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(540, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(19, 7);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(23, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 152;
            this.label4.Text = "Equip Type";
            // 
            // cdvEquipType
            // 
            this.cdvEquipType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEquipType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEquipType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEquipType.BtnToolTipText = "";
            this.cdvEquipType.ButtonWidth = 20;
            this.cdvEquipType.DescText = "";
            this.cdvEquipType.DisplaySubItemIndex = 0;
            this.cdvEquipType.DisplayText = "";
            this.cdvEquipType.Focusing = null;
            this.cdvEquipType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEquipType.Index = 0;
            this.cdvEquipType.IsViewBtnImage = false;
            this.cdvEquipType.Location = new System.Drawing.Point(126, 33);
            this.cdvEquipType.MaxLength = 20;
            this.cdvEquipType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEquipType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEquipType.MultiSelect = false;
            this.cdvEquipType.Name = "cdvEquipType";
            this.cdvEquipType.ReadOnly = false;
            this.cdvEquipType.SameWidthHeightOfButton = false;
            this.cdvEquipType.SearchSubItemIndex = 0;
            this.cdvEquipType.SelectedDescIndex = 1;
            this.cdvEquipType.SelectedDescToQueryText = "";
            this.cdvEquipType.SelectedSubItemIndex = 0;
            this.cdvEquipType.SelectedValueToQueryText = "";
            this.cdvEquipType.SelectionStart = 0;
            this.cdvEquipType.Size = new System.Drawing.Size(211, 20);
            this.cdvEquipType.SmallImageList = null;
            this.cdvEquipType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEquipType.TabIndex = 153;
            this.cdvEquipType.TextBoxToolTipText = "";
            this.cdvEquipType.TextBoxWidth = 85;
            this.cdvEquipType.VisibleButton = true;
            this.cdvEquipType.VisibleColumnHeader = false;
            this.cdvEquipType.VisibleDescription = true;
            this.cdvEquipType.ButtonPress += new System.EventHandler(this.cdvEquipType_ButtonPress);
            // 
            // frmMMSEquipmentLedgerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSEquipmentLedgerList";
            this.Text = "Measuring Equipment Management Ledger";
            this.Activated += new System.EventHandler(this.frmMMSEquipmentLedgerList_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grbTop.ResumeLayout(false);
            this.grbTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMgtDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInstPalce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).EndInit();
            this.grbIdentiClass.ResumeLayout(false);
            this.grbIdentiClass.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.grbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdEquipLedgerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEquipLedgerList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboYear;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvInstPalce;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEquipCode;
        private System.Windows.Forms.Label label5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMgtDept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbIdentiClass;
        private System.Windows.Forms.CheckBox chkStandardEquip;
        private System.Windows.Forms.CheckBox chkIdleEquip;
        private System.Windows.Forms.CheckBox chkCheck;
        private System.Windows.Forms.CheckBox chkCalibration;
        private System.Windows.Forms.CheckBox chkSPC;
        private System.Windows.Forms.CheckBox chkMSA;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.GroupBox grbMain;
        private FarPoint.Win.Spread.FpSpread spdEquipLedgerList;
        private FarPoint.Win.Spread.SheetView spdEquipLedgerList_Sheet1;
        private System.Windows.Forms.CheckBox chkIdentiClass;
        protected System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEquipType;

    }
}