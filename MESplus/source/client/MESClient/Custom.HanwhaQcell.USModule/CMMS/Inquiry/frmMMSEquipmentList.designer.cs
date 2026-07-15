namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSEquipmentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMMSEquipmentList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbTop = new System.Windows.Forms.GroupBox();
            this.chkRemainDay = new System.Windows.Forms.CheckBox();
            this.dtpPlanToDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.chkCaliPlanDate = new System.Windows.Forms.CheckBox();
            this.dtpPlanFromDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cdvEquipType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUseDept = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label3 = new System.Windows.Forms.Label();
            this.cdvInstPalce = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cdvEquipCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.grbIdentiClass = new System.Windows.Forms.GroupBox();
            this.rdoInactive = new System.Windows.Forms.RadioButton();
            this.rdoTrouble = new System.Windows.Forms.RadioButton();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.rdoALL = new System.Windows.Forms.RadioButton();
            this.grpRemainDay = new System.Windows.Forms.GroupBox();
            this.chkoOneToMillion = new System.Windows.Forms.CheckBox();
            this.chkNothing = new System.Windows.Forms.CheckBox();
            this.chkToZero = new System.Windows.Forms.CheckBox();
            this.chkMillionTo = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbMain = new System.Windows.Forms.GroupBox();
            this.spdEquipList = new FarPoint.Win.Spread.FpSpread();
            this.spdEquipList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInstPalce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).BeginInit();
            this.grbIdentiClass.SuspendLayout();
            this.grpRemainDay.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdEquipList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEquipList_Sheet1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(742, 114);
            this.panel1.TabIndex = 0;
            // 
            // grbTop
            // 
            this.grbTop.Controls.Add(this.chkRemainDay);
            this.grbTop.Controls.Add(this.dtpPlanToDate);
            this.grbTop.Controls.Add(this.label7);
            this.grbTop.Controls.Add(this.chkCaliPlanDate);
            this.grbTop.Controls.Add(this.dtpPlanFromDate);
            this.grbTop.Controls.Add(this.label6);
            this.grbTop.Controls.Add(this.label1);
            this.grbTop.Controls.Add(this.label4);
            this.grbTop.Controls.Add(this.cdvEquipType);
            this.grbTop.Controls.Add(this.cdvUseDept);
            this.grbTop.Controls.Add(this.label3);
            this.grbTop.Controls.Add(this.cdvInstPalce);
            this.grbTop.Controls.Add(this.label2);
            this.grbTop.Controls.Add(this.label5);
            this.grbTop.Controls.Add(this.cdvEquipCode);
            this.grbTop.Controls.Add(this.grbIdentiClass);
            this.grbTop.Controls.Add(this.grpRemainDay);
            this.grbTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTop.Location = new System.Drawing.Point(0, 0);
            this.grbTop.Name = "grbTop";
            this.grbTop.Size = new System.Drawing.Size(742, 114);
            this.grbTop.TabIndex = 0;
            this.grbTop.TabStop = false;
            // 
            // chkRemainDay
            // 
            this.chkRemainDay.AutoSize = true;
            this.chkRemainDay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRemainDay.Location = new System.Drawing.Point(19, 86);
            this.chkRemainDay.Name = "chkRemainDay";
            this.chkRemainDay.Size = new System.Drawing.Size(93, 17);
            this.chkRemainDay.TabIndex = 165;
            this.chkRemainDay.Text = "Remain Day   ";
            this.chkRemainDay.UseVisualStyleBackColor = true;
            this.chkRemainDay.CheckedChanged += new System.EventHandler(this.chkRemainDay_CheckedChanged);
            // 
            // dtpPlanToDate
            // 
            this.dtpPlanToDate.Checked = false;
            this.dtpPlanToDate.CustomFormat = "";
            this.dtpPlanToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanToDate.Location = new System.Drawing.Point(238, 60);
            this.dtpPlanToDate.Name = "dtpPlanToDate";
            this.dtpPlanToDate.Size = new System.Drawing.Size(100, 20);
            this.dtpPlanToDate.TabIndex = 157;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(228, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 143;
            this.label7.Text = "~";
            // 
            // chkCaliPlanDate
            // 
            this.chkCaliPlanDate.AutoSize = true;
            this.chkCaliPlanDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCaliPlanDate.Location = new System.Drawing.Point(19, 62);
            this.chkCaliPlanDate.Name = "chkCaliPlanDate";
            this.chkCaliPlanDate.Size = new System.Drawing.Size(94, 17);
            this.chkCaliPlanDate.TabIndex = 158;
            this.chkCaliPlanDate.Text = "Next Cali Date";
            this.chkCaliPlanDate.UseVisualStyleBackColor = true;
            this.chkCaliPlanDate.CheckedChanged += new System.EventHandler(this.chkCaliPlanDate_CheckedChanged);
            // 
            // dtpPlanFromDate
            // 
            this.dtpPlanFromDate.Checked = false;
            this.dtpPlanFromDate.CustomFormat = "";
            this.dtpPlanFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanFromDate.Location = new System.Drawing.Point(126, 60);
            this.dtpPlanFromDate.Name = "dtpPlanFromDate";
            this.dtpPlanFromDate.Size = new System.Drawing.Size(100, 20);
            this.dtpPlanFromDate.TabIndex = 156;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(23, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 155;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(373, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 154;
            this.label1.Text = "Use Division";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(23, 17);
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
            this.cdvEquipType.Location = new System.Drawing.Point(126, 13);
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
            this.cdvUseDept.Location = new System.Drawing.Point(126, 36);
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
            this.cdvUseDept.Size = new System.Drawing.Size(210, 20);
            this.cdvUseDept.SmallImageList = null;
            this.cdvUseDept.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUseDept.TabIndex = 143;
            this.cdvUseDept.TextBoxToolTipText = "";
            this.cdvUseDept.TextBoxWidth = 85;
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
            this.label3.Location = new System.Drawing.Point(23, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 142;
            this.label3.Text = "Use Dept";
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
            this.cdvInstPalce.Location = new System.Drawing.Point(475, 36);
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
            this.cdvInstPalce.Size = new System.Drawing.Size(255, 20);
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
            this.label2.Location = new System.Drawing.Point(360, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 146;
            this.label2.Text = "Installation Place";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(360, 17);
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
            this.cdvEquipCode.Location = new System.Drawing.Point(475, 13);
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
            this.cdvEquipCode.Size = new System.Drawing.Size(255, 20);
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
            this.grbIdentiClass.Controls.Add(this.rdoInactive);
            this.grbIdentiClass.Controls.Add(this.rdoTrouble);
            this.grbIdentiClass.Controls.Add(this.rdoActive);
            this.grbIdentiClass.Controls.Add(this.rdoALL);
            this.grbIdentiClass.Location = new System.Drawing.Point(475, 55);
            this.grbIdentiClass.Name = "grbIdentiClass";
            this.grbIdentiClass.Size = new System.Drawing.Size(256, 30);
            this.grbIdentiClass.TabIndex = 150;
            this.grbIdentiClass.TabStop = false;
            // 
            // rdoInactive
            // 
            this.rdoInactive.AutoSize = true;
            this.rdoInactive.Location = new System.Drawing.Point(193, 9);
            this.rdoInactive.Name = "rdoInactive";
            this.rdoInactive.Size = new System.Drawing.Size(63, 17);
            this.rdoInactive.TabIndex = 3;
            this.rdoInactive.Text = "Inactive";
            this.rdoInactive.UseVisualStyleBackColor = true;
            // 
            // rdoTrouble
            // 
            this.rdoTrouble.AutoSize = true;
            this.rdoTrouble.Location = new System.Drawing.Point(123, 9);
            this.rdoTrouble.Name = "rdoTrouble";
            this.rdoTrouble.Size = new System.Drawing.Size(61, 17);
            this.rdoTrouble.TabIndex = 2;
            this.rdoTrouble.Text = "Trouble";
            this.rdoTrouble.UseVisualStyleBackColor = true;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Checked = true;
            this.rdoActive.Location = new System.Drawing.Point(59, 9);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(55, 17);
            this.rdoActive.TabIndex = 1;
            this.rdoActive.TabStop = true;
            this.rdoActive.Text = "Active";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // rdoALL
            // 
            this.rdoALL.AutoSize = true;
            this.rdoALL.Location = new System.Drawing.Point(6, 9);
            this.rdoALL.Name = "rdoALL";
            this.rdoALL.Size = new System.Drawing.Size(44, 17);
            this.rdoALL.TabIndex = 0;
            this.rdoALL.Text = "ALL";
            this.rdoALL.UseVisualStyleBackColor = true;
            // 
            // grpRemainDay
            // 
            this.grpRemainDay.Controls.Add(this.chkoOneToMillion);
            this.grpRemainDay.Controls.Add(this.chkNothing);
            this.grpRemainDay.Controls.Add(this.chkToZero);
            this.grpRemainDay.Controls.Add(this.chkMillionTo);
            this.grpRemainDay.Location = new System.Drawing.Point(126, 79);
            this.grpRemainDay.Name = "grpRemainDay";
            this.grpRemainDay.Size = new System.Drawing.Size(212, 30);
            this.grpRemainDay.TabIndex = 164;
            this.grpRemainDay.TabStop = false;
            // 
            // chkoOneToMillion
            // 
            this.chkoOneToMillion.AutoSize = true;
            this.chkoOneToMillion.BackColor = System.Drawing.Color.DarkTurquoise;
            this.chkoOneToMillion.Location = new System.Drawing.Point(51, 8);
            this.chkoOneToMillion.Name = "chkoOneToMillion";
            this.chkoOneToMillion.Size = new System.Drawing.Size(59, 17);
            this.chkoOneToMillion.TabIndex = 161;
            this.chkoOneToMillion.Text = "1 - 100";
            this.chkoOneToMillion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkoOneToMillion.UseVisualStyleBackColor = false;
            // 
            // chkNothing
            // 
            this.chkNothing.AutoSize = true;
            this.chkNothing.Location = new System.Drawing.Point(176, 8);
            this.chkNothing.Name = "chkNothing";
            this.chkNothing.Size = new System.Drawing.Size(34, 17);
            this.chkNothing.TabIndex = 163;
            this.chkNothing.Text = "¦¡";
            this.chkNothing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNothing.UseVisualStyleBackColor = true;
            // 
            // chkToZero
            // 
            this.chkToZero.AutoSize = true;
            this.chkToZero.BackColor = System.Drawing.Color.Crimson;
            this.chkToZero.Location = new System.Drawing.Point(5, 8);
            this.chkToZero.Name = "chkToZero";
            this.chkToZero.Size = new System.Drawing.Size(41, 17);
            this.chkToZero.TabIndex = 159;
            this.chkToZero.Text = "< 0";
            this.chkToZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkToZero.UseVisualStyleBackColor = false;
            // 
            // chkMillionTo
            // 
            this.chkMillionTo.AutoSize = true;
            this.chkMillionTo.BackColor = System.Drawing.Color.LightCyan;
            this.chkMillionTo.Location = new System.Drawing.Point(118, 8);
            this.chkMillionTo.Name = "chkMillionTo";
            this.chkMillionTo.Size = new System.Drawing.Size(53, 17);
            this.chkMillionTo.TabIndex = 162;
            this.chkMillionTo.Text = "100 <";
            this.chkMillionTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMillionTo.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grbMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 392);
            this.panel2.TabIndex = 1;
            // 
            // grbMain
            // 
            this.grbMain.Controls.Add(this.spdEquipList);
            this.grbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbMain.Location = new System.Drawing.Point(0, 0);
            this.grbMain.Name = "grbMain";
            this.grbMain.Size = new System.Drawing.Size(742, 392);
            this.grbMain.TabIndex = 0;
            this.grbMain.TabStop = false;
            this.grbMain.Text = "Measuring Equipment List";
            // 
            // spdEquipList
            // 
            this.spdEquipList.AccessibleDescription = "spdEquipList, Sheet1, Row 0, Column 0, ";
            this.spdEquipList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdEquipList.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdEquipList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEquipList.HorizontalScrollBar.Name = "";
            this.spdEquipList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdEquipList.HorizontalScrollBar.TabIndex = 74;
            this.spdEquipList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdEquipList.Location = new System.Drawing.Point(3, 16);
            this.spdEquipList.Name = "spdEquipList";
            namedStyle2.BackColor = System.Drawing.Color.Gainsboro;
            namedStyle2.CellType = generalCellType2;
            namedStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = generalCellType2;
            this.spdEquipList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle2});
            this.spdEquipList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdEquipList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdEquipList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdEquipList_Sheet1});
            this.spdEquipList.Size = new System.Drawing.Size(736, 373);
            this.spdEquipList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdEquipList.TabIndex = 52;
            this.spdEquipList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdEquipList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEquipList.VerticalScrollBar.Name = "";
            this.spdEquipList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdEquipList.VerticalScrollBar.TabIndex = 75;
            this.spdEquipList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdEquipList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdEquipList.SetViewportLeftColumn(0, 0, 4);
            // 
            // spdEquipList_Sheet1
            // 
            this.spdEquipList_Sheet1.Reset();
            spdEquipList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdEquipList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdEquipList_Sheet1.ColumnCount = 20;
            spdEquipList_Sheet1.RowCount = 1;
            this.spdEquipList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdEquipList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Measuring Equipment Type";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Measuring Equipment";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Measuring Equipment Name";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Use Department";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Installation Place";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 8).ColumnSpan = 2;
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Use Division";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Maker";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Model";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Serial No.";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Last Calibration Date";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Result";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Next Calibration Date";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Remain Days";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 17).ColumnSpan = 2;
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Calibration Institute";
            this.spdEquipList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Remark";
            this.spdEquipList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdEquipList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdEquipList_Sheet1.Columns.Get(1).Width = 116F;
            this.spdEquipList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(2).Label = "Measuring Equipment";
            this.spdEquipList_Sheet1.Columns.Get(2).Locked = true;
            this.spdEquipList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(2).Width = 80F;
            this.spdEquipList_Sheet1.Columns.Get(3).Label = "Measuring Equipment Name";
            this.spdEquipList_Sheet1.Columns.Get(3).Locked = true;
            this.spdEquipList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(3).Width = 180F;
            this.spdEquipList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(4).Label = "Use Department";
            this.spdEquipList_Sheet1.Columns.Get(4).Locked = true;
            this.spdEquipList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(4).Width = 50F;
            this.spdEquipList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(5).Width = 100F;
            this.spdEquipList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(6).Label = "Installation Place";
            this.spdEquipList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(6).Width = 50F;
            this.spdEquipList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(7).Width = 100F;
            this.spdEquipList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(8).Label = "Use Division";
            this.spdEquipList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(8).Width = 50F;
            this.spdEquipList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(9).Width = 80F;
            this.spdEquipList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdEquipList_Sheet1.Columns.Get(10).Label = "Maker";
            this.spdEquipList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(10).Width = 120F;
            this.spdEquipList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdEquipList_Sheet1.Columns.Get(11).Label = "Model";
            this.spdEquipList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(11).Width = 140F;
            this.spdEquipList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdEquipList_Sheet1.Columns.Get(12).Label = "Serial No.";
            this.spdEquipList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(12).Width = 120F;
            this.spdEquipList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(13).Label = "Last Calibration Date";
            this.spdEquipList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(13).Width = 115F;
            this.spdEquipList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(14).Label = "Result";
            this.spdEquipList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(15).Label = "Next Calibration Date";
            this.spdEquipList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(15).Width = 115F;
            this.spdEquipList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(16).Label = "Remain Days";
            this.spdEquipList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(16).Width = 80F;
            this.spdEquipList_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(17).Label = "Calibration Institute";
            this.spdEquipList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(18).Width = 150F;
            this.spdEquipList_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdEquipList_Sheet1.Columns.Get(19).Label = "Remark";
            this.spdEquipList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEquipList_Sheet1.Columns.Get(19).Width = 180F;
            this.spdEquipList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdEquipList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdEquipList_Sheet1.RowHeader.Columns.Get(0).Width = 25F;
            this.spdEquipList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdEquipList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEquipList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdEquipList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
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
            // frmMMSEquipmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSEquipmentList";
            this.Text = "Measuring Equipment List";
            this.Activated += new System.EventHandler(this.frmMMSEquipmentList_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grbTop.ResumeLayout(false);
            this.grbTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUseDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInstPalce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).EndInit();
            this.grbIdentiClass.ResumeLayout(false);
            this.grbIdentiClass.PerformLayout();
            this.grpRemainDay.ResumeLayout(false);
            this.grpRemainDay.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.grbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdEquipList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEquipList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvInstPalce;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEquipCode;
        private System.Windows.Forms.Label label5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUseDept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbTop;
        private System.Windows.Forms.GroupBox grbIdentiClass;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.GroupBox grbMain;
        private FarPoint.Win.Spread.FpSpread spdEquipList;
        private FarPoint.Win.Spread.SheetView spdEquipList_Sheet1;
        protected System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEquipType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpPlanToDate;
        private System.Windows.Forms.DateTimePicker dtpPlanFromDate;
        private System.Windows.Forms.CheckBox chkCaliPlanDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdoInactive;
        private System.Windows.Forms.RadioButton rdoTrouble;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.RadioButton rdoALL;
        private System.Windows.Forms.GroupBox grpRemainDay;
        private System.Windows.Forms.CheckBox chkoOneToMillion;
        private System.Windows.Forms.CheckBox chkNothing;
        private System.Windows.Forms.CheckBox chkToZero;
        private System.Windows.Forms.CheckBox chkMillionTo;
        private System.Windows.Forms.CheckBox chkRemainDay;

    }
}