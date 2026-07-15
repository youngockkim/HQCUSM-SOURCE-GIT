namespace Custom.HanwhaQcell.USModule
{
    partial class frmInputAuditResultPopup
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
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputAuditResultPopup));
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtPlanDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAuditor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvCustomer = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvManager = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuditDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuditID = new System.Windows.Forms.TextBox();
            this.lblCalibrationInstituteCode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAgenda = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.spdItemList = new FarPoint.Win.Spread.FpSpread();
            this.spdItemList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dtpAuditDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdItemList_Sheet1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(813, 6);
            this.btnProcess.Text = "Save";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(915, 6);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 471);
            this.pnlBottom.Size = new System.Drawing.Size(834, 40);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.groupBox2);
            this.pnlCenter.Controls.Add(this.groupBox1);
            this.pnlCenter.Controls.Add(this.grpInfo);
            this.pnlCenter.Size = new System.Drawing.Size(834, 471);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Input Audit Plan";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtPlanDate);
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.label5);
            this.grpInfo.Controls.Add(this.txtAuditor);
            this.grpInfo.Controls.Add(this.label2);
            this.grpInfo.Controls.Add(this.cdvCustomer);
            this.grpInfo.Controls.Add(this.cdvManager);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Controls.Add(this.txtAuditDesc);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Controls.Add(this.txtAuditID);
            this.grpInfo.Controls.Add(this.lblCalibrationInstituteCode);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(834, 96);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Information Audit";
            // 
            // txtPlanDate
            // 
            this.txtPlanDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPlanDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlanDate.Location = new System.Drawing.Point(100, 44);
            this.txtPlanDate.MaxLength = 50;
            this.txtPlanDate.Name = "txtPlanDate";
            this.txtPlanDate.ReadOnly = true;
            this.txtPlanDate.Size = new System.Drawing.Size(96, 20);
            this.txtPlanDate.TabIndex = 131;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(409, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 130;
            this.label3.Text = "Manager";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(409, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 129;
            this.label5.Text = "Customer";
            // 
            // txtAuditor
            // 
            this.txtAuditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAuditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditor.Location = new System.Drawing.Point(100, 69);
            this.txtAuditor.MaxLength = 50;
            this.txtAuditor.Name = "txtAuditor";
            this.txtAuditor.ReadOnly = true;
            this.txtAuditor.Size = new System.Drawing.Size(254, 20);
            this.txtAuditor.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(22, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Auditor";
            // 
            // cdvCustomer
            // 
            this.cdvCustomer.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCustomer.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCustomer.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCustomer.BtnToolTipText = "";
            this.cdvCustomer.ButtonWidth = 20;
            this.cdvCustomer.DescText = "";
            this.cdvCustomer.DisplaySubItemIndex = 0;
            this.cdvCustomer.DisplayText = "";
            this.cdvCustomer.Focusing = null;
            this.cdvCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCustomer.Index = 0;
            this.cdvCustomer.IsViewBtnImage = false;
            this.cdvCustomer.Location = new System.Drawing.Point(466, 42);
            this.cdvCustomer.MaxLength = 20;
            this.cdvCustomer.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCustomer.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCustomer.MultiSelect = false;
            this.cdvCustomer.Name = "cdvCustomer";
            this.cdvCustomer.ReadOnly = true;
            this.cdvCustomer.SameWidthHeightOfButton = false;
            this.cdvCustomer.SearchSubItemIndex = 0;
            this.cdvCustomer.SelectedDescIndex = 1;
            this.cdvCustomer.SelectedDescToQueryText = "";
            this.cdvCustomer.SelectedSubItemIndex = 0;
            this.cdvCustomer.SelectedValueToQueryText = "";
            this.cdvCustomer.SelectionStart = 0;
            this.cdvCustomer.Size = new System.Drawing.Size(353, 21);
            this.cdvCustomer.SmallImageList = null;
            this.cdvCustomer.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCustomer.TabIndex = 4;
            this.cdvCustomer.TextBoxToolTipText = "";
            this.cdvCustomer.TextBoxWidth = 110;
            this.cdvCustomer.VisibleButton = false;
            this.cdvCustomer.VisibleColumnHeader = false;
            this.cdvCustomer.VisibleDescription = true;
            this.cdvCustomer.ButtonPress += new System.EventHandler(this.cdvCustomer_ButtonPress);
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
            this.cdvManager.Location = new System.Drawing.Point(466, 68);
            this.cdvManager.MaxLength = 20;
            this.cdvManager.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvManager.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvManager.MultiSelect = false;
            this.cdvManager.Name = "cdvManager";
            this.cdvManager.ReadOnly = true;
            this.cdvManager.SameWidthHeightOfButton = false;
            this.cdvManager.SearchSubItemIndex = 0;
            this.cdvManager.SelectedDescIndex = 1;
            this.cdvManager.SelectedDescToQueryText = "";
            this.cdvManager.SelectedSubItemIndex = 0;
            this.cdvManager.SelectedValueToQueryText = "";
            this.cdvManager.SelectionStart = 0;
            this.cdvManager.Size = new System.Drawing.Size(353, 21);
            this.cdvManager.SmallImageList = null;
            this.cdvManager.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvManager.TabIndex = 6;
            this.cdvManager.TextBoxToolTipText = "";
            this.cdvManager.TextBoxWidth = 110;
            this.cdvManager.VisibleButton = false;
            this.cdvManager.VisibleColumnHeader = false;
            this.cdvManager.VisibleDescription = true;
            this.cdvManager.ButtonPress += new System.EventHandler(this.cdvManager_ButtonPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(22, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Plan Date";
            // 
            // txtAuditDesc
            // 
            this.txtAuditDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAuditDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditDesc.Location = new System.Drawing.Point(466, 18);
            this.txtAuditDesc.MaxLength = 50;
            this.txtAuditDesc.Name = "txtAuditDesc";
            this.txtAuditDesc.ReadOnly = true;
            this.txtAuditDesc.Size = new System.Drawing.Size(353, 20);
            this.txtAuditDesc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(399, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Description";
            // 
            // txtAuditID
            // 
            this.txtAuditID.BackColor = System.Drawing.Color.Silver;
            this.txtAuditID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditID.Location = new System.Drawing.Point(100, 17);
            this.txtAuditID.MaxLength = 20;
            this.txtAuditID.Name = "txtAuditID";
            this.txtAuditID.ReadOnly = true;
            this.txtAuditID.Size = new System.Drawing.Size(96, 20);
            this.txtAuditID.TabIndex = 1;
            // 
            // lblCalibrationInstituteCode
            // 
            this.lblCalibrationInstituteCode.AutoSize = true;
            this.lblCalibrationInstituteCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationInstituteCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationInstituteCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCalibrationInstituteCode.Location = new System.Drawing.Point(22, 21);
            this.lblCalibrationInstituteCode.Name = "lblCalibrationInstituteCode";
            this.lblCalibrationInstituteCode.Size = new System.Drawing.Size(45, 13);
            this.lblCalibrationInstituteCode.TabIndex = 10;
            this.lblCalibrationInstituteCode.Text = "Audit ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAgenda);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 119);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audit Contents";
            // 
            // txtAgenda
            // 
            this.txtAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgenda.Location = new System.Drawing.Point(12, 40);
            this.txtAgenda.MaxLength = 500;
            this.txtAgenda.Multiline = true;
            this.txtAgenda.Name = "txtAgenda";
            this.txtAgenda.ReadOnly = true;
            this.txtAgenda.Size = new System.Drawing.Size(807, 73);
            this.txtAgenda.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(16, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Agenda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(834, 256);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audit Result";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.spdItemList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(828, 201);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Audit Item";
            // 
            // spdItemList
            // 
            this.spdItemList.AccessibleDescription = "spdItemList, Sheet1, Row 0, Column 0, ";
            this.spdItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdItemList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdItemList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdItemList.HorizontalScrollBar.Name = "";
            this.spdItemList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdItemList.HorizontalScrollBar.TabIndex = 58;
            this.spdItemList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdItemList.Location = new System.Drawing.Point(3, 16);
            this.spdItemList.Name = "spdItemList";
            this.spdItemList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdItemList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdItemList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdItemList_Sheet1});
            this.spdItemList.Size = new System.Drawing.Size(822, 182);
            this.spdItemList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdItemList.TabIndex = 12;
            this.spdItemList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdItemList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdItemList.VerticalScrollBar.Name = "";
            this.spdItemList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdItemList.VerticalScrollBar.TabIndex = 59;
            this.spdItemList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdItemList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdItemList_CellDoubleClick);
            this.spdItemList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdItemList_ButtonClicked);
            this.spdItemList.SetViewportLeftColumn(0, 0, 2);
            this.spdItemList.SetActiveViewport(0, 0, -1);
            // 
            // spdItemList_Sheet1
            // 
            this.spdItemList_Sheet1.Reset();
            spdItemList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdItemList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdItemList_Sheet1.ColumnCount = 13;
            spdItemList_Sheet1.RowCount = 2;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdItemList_Sheet1.Cells.Get(0, 2).CellType = buttonCellType1;
            dateTimeCellType1.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType1.Calendar")));
            dateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType1.DateDefault = new System.DateTime(2023, 5, 26, 14, 2, 57, 0);
            dateTimeCellType1.DropDownButton = true;
            dateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999");
            dateTimeCellType1.TimeDefault = new System.DateTime(2023, 5, 26, 14, 2, 57, 0);
            this.spdItemList_Sheet1.Cells.Get(0, 12).CellType = dateTimeCellType1;
            this.spdItemList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdItemList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Division";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Audit Div Code";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Item";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Detail";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Finding";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 2;
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Image";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 9).ColumnSpan = 2;
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Person In Charge";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Resolve User ID";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Action Limit Date";
            this.spdItemList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdItemList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdItemList_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdItemList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdItemList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(0).Width = 28F;
            this.spdItemList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(1).Label = "Division";
            this.spdItemList_Sheet1.Columns.Get(1).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdItemList_Sheet1.Columns.Get(2).CellType = buttonCellType2;
            this.spdItemList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(2).Width = 24F;
            this.spdItemList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdItemList_Sheet1.Columns.Get(3).Label = "Audit Div Code";
            this.spdItemList_Sheet1.Columns.Get(3).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(3).Visible = false;
            this.spdItemList_Sheet1.Columns.Get(3).Width = 80F;
            this.spdItemList_Sheet1.Columns.Get(4).CellType = textCellType1;
            this.spdItemList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(4).Label = "Item";
            this.spdItemList_Sheet1.Columns.Get(4).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(5).CellType = textCellType2;
            this.spdItemList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdItemList_Sheet1.Columns.Get(5).Label = "Detail";
            this.spdItemList_Sheet1.Columns.Get(5).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(5).Width = 180F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdItemList_Sheet1.Columns.Get(6).CellType = comboBoxCellType1;
            this.spdItemList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(6).Label = "Finding";
            this.spdItemList_Sheet1.Columns.Get(6).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(6).Width = 70F;
            this.spdItemList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(7).Label = "Image";
            this.spdItemList_Sheet1.Columns.Get(7).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(7).Width = 100F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdItemList_Sheet1.Columns.Get(8).CellType = buttonCellType3;
            this.spdItemList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(8).Width = 25F;
            this.spdItemList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(9).Label = "Person In Charge";
            this.spdItemList_Sheet1.Columns.Get(9).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(9).Width = 100F;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.Text = "...";
            this.spdItemList_Sheet1.Columns.Get(10).CellType = buttonCellType4;
            this.spdItemList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(10).Width = 25F;
            this.spdItemList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(11).Label = "Resolve User ID";
            this.spdItemList_Sheet1.Columns.Get(11).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(11).Visible = false;
            this.spdItemList_Sheet1.Columns.Get(11).Width = 80F;
            dateTimeCellType2.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType2.Calendar")));
            dateTimeCellType2.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType2.DateDefault = new System.DateTime(2023, 6, 8, 13, 27, 55, 0);
            dateTimeCellType2.DropDownButton = true;
            dateTimeCellType2.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999");
            dateTimeCellType2.TimeDefault = new System.DateTime(2023, 6, 8, 13, 27, 55, 0);
            this.spdItemList_Sheet1.Columns.Get(12).CellType = dateTimeCellType2;
            this.spdItemList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(12).Label = "Action Limit Date";
            this.spdItemList_Sheet1.Columns.Get(12).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(12).Width = 110F;
            this.spdItemList_Sheet1.FrozenColumnCount = 2;
            this.spdItemList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdItemList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdItemList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdItemList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdItemList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdItemList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdItemList_Sheet1.ShowRowSelector = true;
            this.spdItemList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.dtpAuditDate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnAddNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 36);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(731, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 26);
            this.btnDelete.TabIndex = 115;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dtpAuditDate
            // 
            this.dtpAuditDate.Checked = false;
            this.dtpAuditDate.CustomFormat = "";
            this.dtpAuditDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuditDate.Location = new System.Drawing.Point(88, 9);
            this.dtpAuditDate.Name = "dtpAuditDate";
            this.dtpAuditDate.Size = new System.Drawing.Size(96, 20);
            this.dtpAuditDate.TabIndex = 113;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(10, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 114;
            this.label7.Text = "Audit Date";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(625, 6);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(88, 26);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
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
            // frmInputAuditResultPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 511);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "frmInputAuditResultPopup";
            this.Text = "Input Audit Result";
            this.Activated += new System.EventHandler(this.frmInputAuditResultPopup_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdItemList_Sheet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtAuditDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuditID;
        private System.Windows.Forms.Label lblCalibrationInstituteCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAgenda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAuditor;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCustomer;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvManager;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private FarPoint.Win.Spread.FpSpread spdItemList;
        private FarPoint.Win.Spread.SheetView spdItemList_Sheet1;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DateTimePicker dtpAuditDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlanDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDelete;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
    }
}