namespace Custom.HanwhaQcell.USModule
{
    partial class frmInputActionResultPopup
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputActionResultPopup));
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType5 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType6 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtAgenda = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPlanDate = new System.Windows.Forms.TextBox();
            this.txtAuditDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAuditor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvCustomer = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvManager = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuditDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuditID = new System.Windows.Forms.TextBox();
            this.lblCalibrationInstituteCode = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.spdItemList = new FarPoint.Win.Spread.FpSpread();
            this.spdItemList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtActionRemark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpActionDate = new System.Windows.Forms.DateTimePicker();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFileName = new System.Windows.Forms.Button();
            this.cdvFileName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdItemList_Sheet1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFileName)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(729, 6);
            this.btnProcess.Text = "Save";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(823, 6);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 501);
            this.pnlBottom.Size = new System.Drawing.Size(834, 40);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.groupBox2);
            this.pnlCenter.Controls.Add(this.grpInfo);
            this.pnlCenter.Size = new System.Drawing.Size(834, 501);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Input Audit Plan";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtAgenda);
            this.grpInfo.Controls.Add(this.label6);
            this.grpInfo.Controls.Add(this.textBox2);
            this.grpInfo.Controls.Add(this.label8);
            this.grpInfo.Controls.Add(this.txtPlanDate);
            this.grpInfo.Controls.Add(this.txtAuditDate);
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.label5);
            this.grpInfo.Controls.Add(this.label7);
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
            this.grpInfo.Size = new System.Drawing.Size(834, 204);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Information Audit";
            // 
            // txtAgenda
            // 
            this.txtAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgenda.Location = new System.Drawing.Point(100, 121);
            this.txtAgenda.MaxLength = 500;
            this.txtAgenda.Multiline = true;
            this.txtAgenda.Name = "txtAgenda";
            this.txtAgenda.ReadOnly = true;
            this.txtAgenda.Size = new System.Drawing.Size(719, 73);
            this.txtAgenda.TabIndex = 135;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(21, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 136;
            this.label6.Text = "Agenda";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(466, 95);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(110, 20);
            this.textBox2.TabIndex = 134;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(390, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 133;
            this.label8.Text = "Audit Result";
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
            // txtAuditDate
            // 
            this.txtAuditDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAuditDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditDate.Location = new System.Drawing.Point(100, 94);
            this.txtAuditDate.MaxLength = 50;
            this.txtAuditDate.Name = "txtAuditDate";
            this.txtAuditDate.ReadOnly = true;
            this.txtAuditDate.Size = new System.Drawing.Size(96, 20);
            this.txtAuditDate.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(390, 72);
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
            this.label5.Location = new System.Drawing.Point(390, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 129;
            this.label5.Text = "Customer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(22, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 114;
            this.label7.Text = "Audit Date";
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
            this.label1.Location = new System.Drawing.Point(390, 22);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(834, 297);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action Result";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.spdItemList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(828, 220);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action Item";
            // 
            // spdItemList
            // 
            this.spdItemList.AccessibleDescription = "spdItemList, Sheet1, Row 0, Column 0, ";
            this.spdItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdItemList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdItemList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdItemList.HorizontalScrollBar.Name = "";
            this.spdItemList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdItemList.HorizontalScrollBar.TabIndex = 68;
            this.spdItemList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdItemList.Location = new System.Drawing.Point(3, 16);
            this.spdItemList.Name = "spdItemList";
            this.spdItemList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdItemList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdItemList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdItemList_Sheet1});
            this.spdItemList.Size = new System.Drawing.Size(822, 201);
            this.spdItemList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdItemList.TabIndex = 12;
            this.spdItemList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdItemList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdItemList.VerticalScrollBar.Name = "";
            this.spdItemList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdItemList.VerticalScrollBar.TabIndex = 69;
            this.spdItemList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdItemList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdItemList_CellDoubleClick);
            this.spdItemList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdItemList_ButtonClicked);
            this.spdItemList.ComboSelChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdItemList_ComboSelChange);
            this.spdItemList.SetViewportLeftColumn(0, 0, 6);
            this.spdItemList.SetActiveViewport(0, 0, -1);
            // 
            // spdItemList_Sheet1
            // 
            this.spdItemList_Sheet1.Reset();
            spdItemList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdItemList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdItemList_Sheet1.ColumnCount = 16;
            spdItemList_Sheet1.RowCount = 2;
            this.spdItemList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdItemList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sort Order";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Division";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Audit Div Code";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Item";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Detail";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Finding";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = " Image";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Limit Date";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Action Date";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 10).ColumnSpan = 2;
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Action Image";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 12).ColumnSpan = 2;
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Person In Charge";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Action User ID";
            this.spdItemList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Action Result";
            this.spdItemList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdItemList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdItemList_Sheet1.Columns.Get(0).CellType = checkBoxCellType3;
            this.spdItemList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdItemList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(0).Width = 28F;
            numberCellType3.DecimalPlaces = 0;
            this.spdItemList_Sheet1.Columns.Get(1).CellType = numberCellType3;
            this.spdItemList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(1).Label = "Sort Order";
            this.spdItemList_Sheet1.Columns.Get(1).Locked = true;
            this.spdItemList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(1).Visible = false;
            this.spdItemList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(2).Label = "Division";
            this.spdItemList_Sheet1.Columns.Get(2).Locked = true;
            this.spdItemList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdItemList_Sheet1.Columns.Get(3).Label = "Audit Div Code";
            this.spdItemList_Sheet1.Columns.Get(3).Locked = true;
            this.spdItemList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(3).Visible = false;
            this.spdItemList_Sheet1.Columns.Get(3).Width = 80F;
            this.spdItemList_Sheet1.Columns.Get(4).CellType = textCellType5;
            this.spdItemList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(4).Label = "Item";
            this.spdItemList_Sheet1.Columns.Get(4).Locked = true;
            this.spdItemList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(5).CellType = textCellType6;
            this.spdItemList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdItemList_Sheet1.Columns.Get(5).Label = "Detail";
            this.spdItemList_Sheet1.Columns.Get(5).Locked = true;
            this.spdItemList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(5).Width = 180F;
            this.spdItemList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(6).Label = "Finding";
            this.spdItemList_Sheet1.Columns.Get(6).Locked = true;
            this.spdItemList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(6).Width = 71F;
            this.spdItemList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(7).Label = " Image";
            this.spdItemList_Sheet1.Columns.Get(7).Locked = true;
            this.spdItemList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(7).Width = 70F;
            this.spdItemList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(8).Label = "Limit Date";
            this.spdItemList_Sheet1.Columns.Get(8).Locked = true;
            this.spdItemList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(8).Width = 93F;
            dateTimeCellType3.Calendar = ((System.Globalization.Calendar)(resources.GetObject("dateTimeCellType3.Calendar")));
            dateTimeCellType3.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType3.DateDefault = new System.DateTime(2023, 6, 15, 14, 46, 20, 0);
            dateTimeCellType3.DropDownButton = true;
            dateTimeCellType3.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999");
            dateTimeCellType3.TimeDefault = new System.DateTime(2023, 6, 15, 14, 46, 20, 0);
            this.spdItemList_Sheet1.Columns.Get(9).CellType = dateTimeCellType3;
            this.spdItemList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(9).Label = "Action Date";
            this.spdItemList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(9).Width = 102F;
            this.spdItemList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdItemList_Sheet1.Columns.Get(10).Label = "Action Image";
            this.spdItemList_Sheet1.Columns.Get(10).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(10).Width = 100F;
            buttonCellType5.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType5.Text = "...";
            this.spdItemList_Sheet1.Columns.Get(11).CellType = buttonCellType5;
            this.spdItemList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(11).Width = 25F;
            this.spdItemList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(12).Label = "Person In Charge";
            this.spdItemList_Sheet1.Columns.Get(12).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(12).Width = 100F;
            buttonCellType6.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType6.Text = "...";
            this.spdItemList_Sheet1.Columns.Get(13).CellType = buttonCellType6;
            this.spdItemList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(13).Width = 25F;
            this.spdItemList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(14).Label = "Action User ID";
            this.spdItemList_Sheet1.Columns.Get(14).Locked = false;
            this.spdItemList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(14).Visible = false;
            this.spdItemList_Sheet1.Columns.Get(14).Width = 80F;
            comboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdItemList_Sheet1.Columns.Get(15).CellType = comboBoxCellType3;
            this.spdItemList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(15).Label = "Action Result";
            this.spdItemList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemList_Sheet1.Columns.Get(15).Width = 77F;
            this.spdItemList_Sheet1.FrozenColumnCount = 6;
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
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnFileName);
            this.panel1.Controls.Add(this.cdvFileName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtActionRemark);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtpActionDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 58);
            this.panel1.TabIndex = 0;
            // 
            // txtActionRemark
            // 
            this.txtActionRemark.Location = new System.Drawing.Point(97, 32);
            this.txtActionRemark.MaxLength = 300;
            this.txtActionRemark.Name = "txtActionRemark";
            this.txtActionRemark.Size = new System.Drawing.Size(717, 20);
            this.txtActionRemark.TabIndex = 135;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(18, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 134;
            this.label10.Text = "Remark";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(19, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 115;
            this.label9.Text = "Action Date";
            // 
            // dtpActionDate
            // 
            this.dtpActionDate.Checked = false;
            this.dtpActionDate.CustomFormat = "";
            this.dtpActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActionDate.Location = new System.Drawing.Point(97, 8);
            this.dtpActionDate.Name = "dtpActionDate";
            this.dtpActionDate.Size = new System.Drawing.Size(96, 20);
            this.dtpActionDate.TabIndex = 113;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(340, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 136;
            this.label11.Text = "Document";
            // 
            // btnFileName
            // 
            this.btnFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileName.Location = new System.Drawing.Point(703, 8);
            this.btnFileName.Name = "btnFileName";
            this.btnFileName.Size = new System.Drawing.Size(43, 21);
            this.btnFileName.TabIndex = 138;
            this.btnFileName.Text = "Open";
            this.btnFileName.UseVisualStyleBackColor = true;
            this.btnFileName.Click += new System.EventHandler(this.btnFileName_Click);
            // 
            // cdvFileName
            // 
            this.cdvFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFileName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFileName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFileName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFileName.BtnToolTipText = "";
            this.cdvFileName.ButtonWidth = 20;
            this.cdvFileName.DescText = "";
            this.cdvFileName.DisplaySubItemIndex = -1;
            this.cdvFileName.DisplayText = "";
            this.cdvFileName.Focusing = null;
            this.cdvFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFileName.Index = 0;
            this.cdvFileName.IsViewBtnImage = false;
            this.cdvFileName.Location = new System.Drawing.Point(399, 8);
            this.cdvFileName.MaxLength = 32767;
            this.cdvFileName.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFileName.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFileName.MultiSelect = false;
            this.cdvFileName.Name = "cdvFileName";
            this.cdvFileName.ReadOnly = true;
            this.cdvFileName.SameWidthHeightOfButton = false;
            this.cdvFileName.SearchSubItemIndex = 0;
            this.cdvFileName.SelectedDescIndex = -1;
            this.cdvFileName.SelectedDescToQueryText = "";
            this.cdvFileName.SelectedSubItemIndex = -1;
            this.cdvFileName.SelectedValueToQueryText = "";
            this.cdvFileName.SelectionStart = 0;
            this.cdvFileName.Size = new System.Drawing.Size(298, 20);
            this.cdvFileName.SmallImageList = null;
            this.cdvFileName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFileName.TabIndex = 137;
            this.cdvFileName.TextBoxToolTipText = "";
            this.cdvFileName.TextBoxWidth = 298;
            this.cdvFileName.VisibleButton = true;
            this.cdvFileName.VisibleColumnHeader = false;
            this.cdvFileName.VisibleDescription = false;
            this.cdvFileName.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFileName_SelectedItemChanged);
            this.cdvFileName.ButtonPress += new System.EventHandler(this.cdvFileName_ButtonPress);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(752, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(62, 21);
            this.btnUpdate.TabIndex = 139;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmInputActionResultPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 541);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "frmInputActionResultPopup";
            this.Text = "Audit Result Action";
            this.Activated += new System.EventHandler(this.frmInputActionResultPopup_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdItemList_Sheet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFileName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtAuditDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuditID;
        private System.Windows.Forms.Label lblCalibrationInstituteCode;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.DateTimePicker dtpActionDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlanDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        private System.Windows.Forms.TextBox txtActionRemark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAuditDate;
        private System.Windows.Forms.TextBox txtAgenda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnFileName;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFileName;
        private System.Windows.Forms.Button btnUpdate;
    }
}