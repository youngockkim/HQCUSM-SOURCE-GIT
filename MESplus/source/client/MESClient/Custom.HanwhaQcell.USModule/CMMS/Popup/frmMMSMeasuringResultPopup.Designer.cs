namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSMeasuringResultPopup
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
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("DataAreaGrayscale");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.pnlTop1 = new System.Windows.Forms.Panel();
            this.grbTop = new System.Windows.Forms.GroupBox();
            this.pnlMinMax = new System.Windows.Forms.Panel();
            this.txtUSL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLSL = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cdvSampleCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRepeatCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSampleCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvItemCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.dtpMeasurementDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlanDate = new System.Windows.Forms.TextBox();
            this.txtEquipCode = new System.Windows.Forms.TextBox();
            this.lblCalibrationInstituteCode = new System.Windows.Forms.Label();
            this.txtEquipName = new System.Windows.Forms.TextBox();
            this.lblCalibrationEquipName = new System.Windows.Forms.Label();
            this.pnlInputType = new System.Windows.Forms.Panel();
            this.rdoNumberType = new System.Windows.Forms.RadioButton();
            this.rdoCharType = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spdMeasuringResultList = new FarPoint.Win.Spread.FpSpread();
            this.spdMeasuringResultList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnDownloadExcel = new System.Windows.Forms.Button();
            this.btnUploadExcel = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTop1.SuspendLayout();
            this.grbTop.SuspendLayout();
            this.pnlMinMax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSampleCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvItemCode)).BeginInit();
            this.pnlInputType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdMeasuringResultList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMeasuringResultList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnUploadExcel);
            this.pnlBottom.Controls.Add(this.btnDownloadExcel);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDownloadExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUploadExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.panel1);
            this.pnlCenter.Controls.Add(this.pnlTop1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Measuring Result Registration";
            // 
            // pnlTop1
            // 
            this.pnlTop1.Controls.Add(this.grbTop);
            this.pnlTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop1.Location = new System.Drawing.Point(0, 0);
            this.pnlTop1.Name = "pnlTop1";
            this.pnlTop1.Size = new System.Drawing.Size(742, 134);
            this.pnlTop1.TabIndex = 0;
            // 
            // grbTop
            // 
            this.grbTop.Controls.Add(this.pnlMinMax);
            this.grbTop.Controls.Add(this.label9);
            this.grbTop.Controls.Add(this.label8);
            this.grbTop.Controls.Add(this.cdvSampleCode);
            this.grbTop.Controls.Add(this.label7);
            this.grbTop.Controls.Add(this.txtUserCount);
            this.grbTop.Controls.Add(this.label6);
            this.grbTop.Controls.Add(this.label5);
            this.grbTop.Controls.Add(this.txtRepeatCount);
            this.grbTop.Controls.Add(this.label3);
            this.grbTop.Controls.Add(this.txtSampleCount);
            this.grbTop.Controls.Add(this.label2);
            this.grbTop.Controls.Add(this.cdvItemCode);
            this.grbTop.Controls.Add(this.dtpMeasurementDate);
            this.grbTop.Controls.Add(this.label4);
            this.grbTop.Controls.Add(this.txtPlanDate);
            this.grbTop.Controls.Add(this.txtEquipCode);
            this.grbTop.Controls.Add(this.lblCalibrationInstituteCode);
            this.grbTop.Controls.Add(this.txtEquipName);
            this.grbTop.Controls.Add(this.lblCalibrationEquipName);
            this.grbTop.Controls.Add(this.pnlInputType);
            this.grbTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTop.Location = new System.Drawing.Point(0, 0);
            this.grbTop.Name = "grbTop";
            this.grbTop.Size = new System.Drawing.Size(742, 134);
            this.grbTop.TabIndex = 0;
            this.grbTop.TabStop = false;
            // 
            // pnlMinMax
            // 
            this.pnlMinMax.Controls.Add(this.txtUSL);
            this.pnlMinMax.Controls.Add(this.label10);
            this.pnlMinMax.Controls.Add(this.label11);
            this.pnlMinMax.Controls.Add(this.txtLSL);
            this.pnlMinMax.Location = new System.Drawing.Point(277, 104);
            this.pnlMinMax.Name = "pnlMinMax";
            this.pnlMinMax.Size = new System.Drawing.Size(460, 23);
            this.pnlMinMax.TabIndex = 159;
            // 
            // txtUSL
            // 
            this.txtUSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUSL.Location = new System.Drawing.Point(344, 0);
            this.txtUSL.MaxLength = 100;
            this.txtUSL.Name = "txtUSL";
            this.txtUSL.ReadOnly = true;
            this.txtUSL.Size = new System.Drawing.Size(110, 20);
            this.txtUSL.TabIndex = 13;
            this.txtUSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(230, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 158;
            this.label10.Text = "USL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(13, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 156;
            this.label11.Text = "LSL";
            // 
            // txtLSL
            // 
            this.txtLSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLSL.Location = new System.Drawing.Point(102, 0);
            this.txtLSL.MaxLength = 100;
            this.txtLSL.Name = "txtLSL";
            this.txtLSL.ReadOnly = true;
            this.txtLSL.Size = new System.Drawing.Size(110, 20);
            this.txtLSL.TabIndex = 12;
            this.txtLSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(506, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 154;
            this.label9.Text = "Sample Count";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(289, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 153;
            this.label8.Text = "Sample Code";
            // 
            // cdvSampleCode
            // 
            this.cdvSampleCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvSampleCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSampleCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSampleCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSampleCode.BtnToolTipText = "";
            this.cdvSampleCode.ButtonWidth = 20;
            this.cdvSampleCode.DescText = "";
            this.cdvSampleCode.DisplaySubItemIndex = 0;
            this.cdvSampleCode.DisplayText = "";
            this.cdvSampleCode.Focusing = null;
            this.cdvSampleCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSampleCode.Index = 0;
            this.cdvSampleCode.IsViewBtnImage = false;
            this.cdvSampleCode.Location = new System.Drawing.Point(378, 37);
            this.cdvSampleCode.MaxLength = 20;
            this.cdvSampleCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSampleCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSampleCode.MultiSelect = false;
            this.cdvSampleCode.Name = "cdvSampleCode";
            this.cdvSampleCode.ReadOnly = true;
            this.cdvSampleCode.SameWidthHeightOfButton = false;
            this.cdvSampleCode.SearchSubItemIndex = 0;
            this.cdvSampleCode.SelectedDescIndex = -1;
            this.cdvSampleCode.SelectedDescToQueryText = "";
            this.cdvSampleCode.SelectedSubItemIndex = 0;
            this.cdvSampleCode.SelectedValueToQueryText = "";
            this.cdvSampleCode.SelectionStart = 0;
            this.cdvSampleCode.Size = new System.Drawing.Size(352, 20);
            this.cdvSampleCode.SmallImageList = null;
            this.cdvSampleCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSampleCode.TabIndex = 3;
            this.cdvSampleCode.TextBoxToolTipText = "";
            this.cdvSampleCode.TextBoxWidth = 110;
            this.cdvSampleCode.VisibleButton = false;
            this.cdvSampleCode.VisibleColumnHeader = false;
            this.cdvSampleCode.VisibleDescription = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(289, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 151;
            this.label7.Text = "Item Code";
            // 
            // txtUserCount
            // 
            this.txtUserCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserCount.Location = new System.Drawing.Point(378, 60);
            this.txtUserCount.MaxLength = 100;
            this.txtUserCount.Name = "txtUserCount";
            this.txtUserCount.ReadOnly = true;
            this.txtUserCount.Size = new System.Drawing.Size(110, 20);
            this.txtUserCount.TabIndex = 5;
            this.txtUserCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(289, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 149;
            this.label6.Text = "Inspector Count";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(19, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 147;
            this.label5.Text = "Plan Date";
            // 
            // txtRepeatCount
            // 
            this.txtRepeatCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepeatCount.Location = new System.Drawing.Point(153, 60);
            this.txtRepeatCount.MaxLength = 100;
            this.txtRepeatCount.Name = "txtRepeatCount";
            this.txtRepeatCount.ReadOnly = true;
            this.txtRepeatCount.Size = new System.Drawing.Size(110, 20);
            this.txtRepeatCount.TabIndex = 4;
            this.txtRepeatCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(19, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 145;
            this.label3.Text = "Repeat Count";
            // 
            // txtSampleCount
            // 
            this.txtSampleCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSampleCount.Location = new System.Drawing.Point(620, 60);
            this.txtSampleCount.MaxLength = 100;
            this.txtSampleCount.Name = "txtSampleCount";
            this.txtSampleCount.ReadOnly = true;
            this.txtSampleCount.Size = new System.Drawing.Size(110, 20);
            this.txtSampleCount.TabIndex = 6;
            this.txtSampleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(289, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 143;
            // 
            // cdvItemCode
            // 
            this.cdvItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvItemCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvItemCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvItemCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvItemCode.BtnToolTipText = "";
            this.cdvItemCode.ButtonWidth = 20;
            this.cdvItemCode.DescText = "";
            this.cdvItemCode.DisplaySubItemIndex = 0;
            this.cdvItemCode.DisplayText = "";
            this.cdvItemCode.Focusing = null;
            this.cdvItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvItemCode.Index = 0;
            this.cdvItemCode.IsViewBtnImage = false;
            this.cdvItemCode.Location = new System.Drawing.Point(378, 82);
            this.cdvItemCode.MaxLength = 20;
            this.cdvItemCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvItemCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvItemCode.MultiSelect = false;
            this.cdvItemCode.Name = "cdvItemCode";
            this.cdvItemCode.ReadOnly = true;
            this.cdvItemCode.SameWidthHeightOfButton = false;
            this.cdvItemCode.SearchSubItemIndex = 0;
            this.cdvItemCode.SelectedDescIndex = -1;
            this.cdvItemCode.SelectedDescToQueryText = "";
            this.cdvItemCode.SelectedSubItemIndex = 0;
            this.cdvItemCode.SelectedValueToQueryText = "";
            this.cdvItemCode.SelectionStart = 0;
            this.cdvItemCode.Size = new System.Drawing.Size(352, 20);
            this.cdvItemCode.SmallImageList = null;
            this.cdvItemCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvItemCode.TabIndex = 8;
            this.cdvItemCode.TextBoxToolTipText = "";
            this.cdvItemCode.TextBoxWidth = 110;
            this.cdvItemCode.VisibleButton = false;
            this.cdvItemCode.VisibleColumnHeader = false;
            this.cdvItemCode.VisibleDescription = true;
            // 
            // dtpMeasurementDate
            // 
            this.dtpMeasurementDate.Checked = false;
            this.dtpMeasurementDate.CustomFormat = "";
            this.dtpMeasurementDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMeasurementDate.Location = new System.Drawing.Point(153, 105);
            this.dtpMeasurementDate.Name = "dtpMeasurementDate";
            this.dtpMeasurementDate.Size = new System.Drawing.Size(110, 20);
            this.dtpMeasurementDate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(19, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 140;
            this.label4.Text = "Measurement Date";
            // 
            // txtPlanDate
            // 
            this.txtPlanDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlanDate.Location = new System.Drawing.Point(153, 82);
            this.txtPlanDate.MaxLength = 100;
            this.txtPlanDate.Name = "txtPlanDate";
            this.txtPlanDate.ReadOnly = true;
            this.txtPlanDate.Size = new System.Drawing.Size(110, 20);
            this.txtPlanDate.TabIndex = 7;
            this.txtPlanDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEquipCode
            // 
            this.txtEquipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipCode.Location = new System.Drawing.Point(153, 15);
            this.txtEquipCode.MaxLength = 50;
            this.txtEquipCode.Name = "txtEquipCode";
            this.txtEquipCode.ReadOnly = true;
            this.txtEquipCode.Size = new System.Drawing.Size(110, 20);
            this.txtEquipCode.TabIndex = 1;
            // 
            // lblCalibrationInstituteCode
            // 
            this.lblCalibrationInstituteCode.AutoSize = true;
            this.lblCalibrationInstituteCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationInstituteCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationInstituteCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCalibrationInstituteCode.Location = new System.Drawing.Point(19, 19);
            this.lblCalibrationInstituteCode.Name = "lblCalibrationInstituteCode";
            this.lblCalibrationInstituteCode.Size = new System.Drawing.Size(137, 13);
            this.lblCalibrationInstituteCode.TabIndex = 12;
            this.lblCalibrationInstituteCode.Text = "Measuring Equipment Code";
            // 
            // txtEquipName
            // 
            this.txtEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipName.Location = new System.Drawing.Point(378, 15);
            this.txtEquipName.MaxLength = 100;
            this.txtEquipName.Name = "txtEquipName";
            this.txtEquipName.ReadOnly = true;
            this.txtEquipName.Size = new System.Drawing.Size(352, 20);
            this.txtEquipName.TabIndex = 2;
            // 
            // lblCalibrationEquipName
            // 
            this.lblCalibrationEquipName.AutoSize = true;
            this.lblCalibrationEquipName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationEquipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationEquipName.Location = new System.Drawing.Point(289, 19);
            this.lblCalibrationEquipName.Name = "lblCalibrationEquipName";
            this.lblCalibrationEquipName.Size = new System.Drawing.Size(60, 13);
            this.lblCalibrationEquipName.TabIndex = 11;
            this.lblCalibrationEquipName.Text = "Description";
            this.lblCalibrationEquipName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInputType
            // 
            this.pnlInputType.Controls.Add(this.rdoNumberType);
            this.pnlInputType.Controls.Add(this.rdoCharType);
            this.pnlInputType.Controls.Add(this.label12);
            this.pnlInputType.Location = new System.Drawing.Point(276, 104);
            this.pnlInputType.Name = "pnlInputType";
            this.pnlInputType.Size = new System.Drawing.Size(460, 23);
            this.pnlInputType.TabIndex = 160;
            this.pnlInputType.Visible = false;
            // 
            // rdoNumberType
            // 
            this.rdoNumberType.AutoSize = true;
            this.rdoNumberType.Location = new System.Drawing.Point(264, 5);
            this.rdoNumberType.Name = "rdoNumberType";
            this.rdoNumberType.Size = new System.Drawing.Size(159, 17);
            this.rdoNumberType.TabIndex = 11;
            this.rdoNumberType.TabStop = true;
            this.rdoNumberType.Text = "Number Type ( 1:OK, 0:NG )";
            this.rdoNumberType.UseVisualStyleBackColor = true;
            this.rdoNumberType.CheckedChanged += new System.EventHandler(this.rdoNumberType_CheckedChanged);
            // 
            // rdoCharType
            // 
            this.rdoCharType.AutoSize = true;
            this.rdoCharType.Location = new System.Drawing.Point(106, 4);
            this.rdoCharType.Name = "rdoCharType";
            this.rdoCharType.Size = new System.Drawing.Size(74, 17);
            this.rdoCharType.TabIndex = 10;
            this.rdoCharType.TabStop = true;
            this.rdoCharType.Text = "Char Type";
            this.rdoCharType.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(13, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 156;
            this.label12.Text = "Input Type";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 372);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spdMeasuringResultList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 372);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement Value";
            // 
            // spdMeasuringResultList
            // 
            this.spdMeasuringResultList.AccessibleDescription = "spdEquipLedgerList, Sheet1, Row 0, Column 0, ";
            this.spdMeasuringResultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMeasuringResultList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdMeasuringResultList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMeasuringResultList.HorizontalScrollBar.Name = "";
            this.spdMeasuringResultList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdMeasuringResultList.HorizontalScrollBar.TabIndex = 66;
            this.spdMeasuringResultList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMeasuringResultList.Location = new System.Drawing.Point(3, 16);
            this.spdMeasuringResultList.Name = "spdMeasuringResultList";
            namedStyle1.BackColor = System.Drawing.Color.Gainsboro;
            namedStyle1.CellType = generalCellType1;
            namedStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = generalCellType1;
            this.spdMeasuringResultList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1});
            this.spdMeasuringResultList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMeasuringResultList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMeasuringResultList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMeasuringResultList_Sheet1});
            this.spdMeasuringResultList.Size = new System.Drawing.Size(736, 353);
            this.spdMeasuringResultList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMeasuringResultList.TabIndex = 53;
            this.spdMeasuringResultList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMeasuringResultList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMeasuringResultList.VerticalScrollBar.Name = "";
            this.spdMeasuringResultList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdMeasuringResultList.VerticalScrollBar.TabIndex = 67;
            this.spdMeasuringResultList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMeasuringResultList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdMeasuringResultList_Sheet1
            // 
            this.spdMeasuringResultList_Sheet1.Reset();
            spdMeasuringResultList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMeasuringResultList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMeasuringResultList_Sheet1.ColumnCount = 1;
            spdMeasuringResultList_Sheet1.ColumnHeader.RowCount = 2;
            spdMeasuringResultList_Sheet1.RowCount = 1;
            this.spdMeasuringResultList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMeasuringResultList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMeasuringResultList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMeasuringResultList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMeasuringResultList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMeasuringResultList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMeasuringResultList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            numberCellType1.DecimalPlaces = 3;
            this.spdMeasuringResultList_Sheet1.Columns.Get(0).CellType = numberCellType1;
            this.spdMeasuringResultList_Sheet1.Columns.Get(0).Locked = true;
            this.spdMeasuringResultList_Sheet1.Columns.Get(0).Width = 70F;
            this.spdMeasuringResultList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMeasuringResultList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMeasuringResultList_Sheet1.RowHeader.Columns.Get(0).Width = 25F;
            this.spdMeasuringResultList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMeasuringResultList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMeasuringResultList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMeasuringResultList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMeasuringResultList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnDownloadExcel
            // 
            this.btnDownloadExcel.Location = new System.Drawing.Point(22, 9);
            this.btnDownloadExcel.Name = "btnDownloadExcel";
            this.btnDownloadExcel.Size = new System.Drawing.Size(100, 24);
            this.btnDownloadExcel.TabIndex = 14;
            this.btnDownloadExcel.Text = "Download Excel";
            this.btnDownloadExcel.UseVisualStyleBackColor = true;
            this.btnDownloadExcel.Click += new System.EventHandler(this.btnDownloadExcel_Click);
            // 
            // btnUploadExcel
            // 
            this.btnUploadExcel.Location = new System.Drawing.Point(128, 9);
            this.btnUploadExcel.Name = "btnUploadExcel";
            this.btnUploadExcel.Size = new System.Drawing.Size(100, 24);
            this.btnUploadExcel.TabIndex = 15;
            this.btnUploadExcel.Text = "Import Excel";
            this.btnUploadExcel.UseVisualStyleBackColor = true;
            this.btnUploadExcel.Click += new System.EventHandler(this.btnUploadExcel_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // frmMMSMeasuringResultPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSMeasuringResultPopup";
            this.Text = "Measuring Result Registration";
            this.Activated += new System.EventHandler(this.frmMMSMeasuringResultPopup_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop1.ResumeLayout(false);
            this.grbTop.ResumeLayout(false);
            this.grbTop.PerformLayout();
            this.pnlMinMax.ResumeLayout(false);
            this.pnlMinMax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSampleCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvItemCode)).EndInit();
            this.pnlInputType.ResumeLayout(false);
            this.pnlInputType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdMeasuringResultList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMeasuringResultList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop1;
        private System.Windows.Forms.GroupBox grbTop;
        private System.Windows.Forms.TextBox txtEquipCode;
        private System.Windows.Forms.Label lblCalibrationInstituteCode;
        private System.Windows.Forms.TextBox txtEquipName;
        private System.Windows.Forms.Label lblCalibrationEquipName;
        private System.Windows.Forms.TextBox txtPlanDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvItemCode;
        private System.Windows.Forms.DateTimePicker dtpMeasurementDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRepeatCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSampleCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSampleCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlMinMax;
        private System.Windows.Forms.TextBox txtUSL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLSL;
        private FarPoint.Win.Spread.FpSpread spdMeasuringResultList;
        private FarPoint.Win.Spread.SheetView spdMeasuringResultList_Sheet1;
        private System.Windows.Forms.Button btnDownloadExcel;
        private System.Windows.Forms.Panel pnlInputType;
        private System.Windows.Forms.RadioButton rdoNumberType;
        private System.Windows.Forms.RadioButton rdoCharType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnUploadExcel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}