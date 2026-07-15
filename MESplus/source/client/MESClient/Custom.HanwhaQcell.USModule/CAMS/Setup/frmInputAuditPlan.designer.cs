namespace Custom.HanwhaQcell.USModule
{
    partial class frmInputAuditPlan
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPlanToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cdvManager = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label5 = new System.Windows.Forms.Label();
            this.cdvCustomer = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblViewUseDept = new System.Windows.Forms.Label();
            this.cdvStatus = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.spdAuditList = new FarPoint.Win.Spread.FpSpread();
            this.spdAuditList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvStatus)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAuditList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAuditList_Sheet1)).BeginInit();
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
            this.grpOption.Controls.Add(this.label2);
            this.grpOption.Controls.Add(this.dtpPlanToDate);
            this.grpOption.Controls.Add(this.dtpPlanFromDate);
            this.grpOption.Controls.Add(this.label4);
            this.grpOption.Controls.Add(this.cdvManager);
            this.grpOption.Controls.Add(this.label5);
            this.grpOption.Controls.Add(this.cdvCustomer);
            this.grpOption.Controls.Add(this.lblViewUseDept);
            this.grpOption.Controls.Add(this.cdvStatus);
            this.grpOption.Controls.Add(this.label1);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.panel2);
            this.pnlViewMid.Controls.Add(this.panel1);
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
            this.lblFormTitle.Text = "Input Audit Plan";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAddNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 33);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(644, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 26);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(535, 4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(88, 26);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(226, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 152;
            this.label2.Text = "~";
            // 
            // dtpPlanToDate
            // 
            this.dtpPlanToDate.Checked = false;
            this.dtpPlanToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPlanToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanToDate.Location = new System.Drawing.Point(242, 16);
            this.dtpPlanToDate.Name = "dtpPlanToDate";
            this.dtpPlanToDate.Size = new System.Drawing.Size(96, 20);
            this.dtpPlanToDate.TabIndex = 155;
            // 
            // dtpPlanFromDate
            // 
            this.dtpPlanFromDate.Checked = false;
            this.dtpPlanFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPlanFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanFromDate.Location = new System.Drawing.Point(119, 16);
            this.dtpPlanFromDate.Name = "dtpPlanFromDate";
            this.dtpPlanFromDate.Size = new System.Drawing.Size(96, 20);
            this.dtpPlanFromDate.TabIndex = 154;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(30, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 153;
            this.label4.Text = "Plan Date";
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
            this.cdvManager.Location = new System.Drawing.Point(119, 40);
            this.cdvManager.MaxLength = 20;
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
            this.cdvManager.Size = new System.Drawing.Size(220, 20);
            this.cdvManager.SmallImageList = null;
            this.cdvManager.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvManager.TabIndex = 151;
            this.cdvManager.TextBoxToolTipText = "";
            this.cdvManager.TextBoxWidth = 90;
            this.cdvManager.VisibleButton = true;
            this.cdvManager.VisibleColumnHeader = false;
            this.cdvManager.VisibleDescription = true;
            this.cdvManager.ButtonPress += new System.EventHandler(this.cdvManager_ButtonPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(30, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 150;
            this.label5.Text = "Manager";
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
            this.cdvCustomer.Location = new System.Drawing.Point(492, 16);
            this.cdvCustomer.MaxLength = 20;
            this.cdvCustomer.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCustomer.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCustomer.MultiSelect = false;
            this.cdvCustomer.Name = "cdvCustomer";
            this.cdvCustomer.ReadOnly = false;
            this.cdvCustomer.SameWidthHeightOfButton = false;
            this.cdvCustomer.SearchSubItemIndex = 0;
            this.cdvCustomer.SelectedDescIndex = 1;
            this.cdvCustomer.SelectedDescToQueryText = "";
            this.cdvCustomer.SelectedSubItemIndex = 0;
            this.cdvCustomer.SelectedValueToQueryText = "";
            this.cdvCustomer.SelectionStart = 0;
            this.cdvCustomer.Size = new System.Drawing.Size(220, 20);
            this.cdvCustomer.SmallImageList = null;
            this.cdvCustomer.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCustomer.TabIndex = 147;
            this.cdvCustomer.TextBoxToolTipText = "";
            this.cdvCustomer.TextBoxWidth = 90;
            this.cdvCustomer.VisibleButton = true;
            this.cdvCustomer.VisibleColumnHeader = false;
            this.cdvCustomer.VisibleDescription = true;
            this.cdvCustomer.ButtonPress += new System.EventHandler(this.cdvCustomer_ButtonPress);
            // 
            // lblViewUseDept
            // 
            this.lblViewUseDept.AutoSize = true;
            this.lblViewUseDept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblViewUseDept.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblViewUseDept.Location = new System.Drawing.Point(405, 20);
            this.lblViewUseDept.Name = "lblViewUseDept";
            this.lblViewUseDept.Size = new System.Drawing.Size(51, 13);
            this.lblViewUseDept.TabIndex = 146;
            this.lblViewUseDept.Text = "Customer";
            // 
            // cdvStatus
            // 
            this.cdvStatus.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvStatus.BorderHotColor = System.Drawing.Color.Black;
            this.cdvStatus.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvStatus.BtnToolTipText = "";
            this.cdvStatus.ButtonWidth = 20;
            this.cdvStatus.DescText = "";
            this.cdvStatus.DisplaySubItemIndex = 0;
            this.cdvStatus.DisplayText = "";
            this.cdvStatus.Focusing = null;
            this.cdvStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvStatus.Index = 0;
            this.cdvStatus.IsViewBtnImage = false;
            this.cdvStatus.Location = new System.Drawing.Point(492, 40);
            this.cdvStatus.MaxLength = 20;
            this.cdvStatus.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvStatus.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvStatus.MultiSelect = false;
            this.cdvStatus.Name = "cdvStatus";
            this.cdvStatus.ReadOnly = false;
            this.cdvStatus.SameWidthHeightOfButton = false;
            this.cdvStatus.SearchSubItemIndex = 0;
            this.cdvStatus.SelectedDescIndex = 1;
            this.cdvStatus.SelectedDescToQueryText = "";
            this.cdvStatus.SelectedSubItemIndex = 0;
            this.cdvStatus.SelectedValueToQueryText = "";
            this.cdvStatus.SelectionStart = 0;
            this.cdvStatus.Size = new System.Drawing.Size(220, 20);
            this.cdvStatus.SmallImageList = null;
            this.cdvStatus.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvStatus.TabIndex = 149;
            this.cdvStatus.TextBoxToolTipText = "";
            this.cdvStatus.TextBoxWidth = 90;
            this.cdvStatus.VisibleButton = true;
            this.cdvStatus.VisibleColumnHeader = false;
            this.cdvStatus.VisibleDescription = true;
            this.cdvStatus.ButtonPress += new System.EventHandler(this.cdvStatus_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(406, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 148;
            this.label1.Text = "Status";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.spdAuditList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 402);
            this.panel2.TabIndex = 1;
            // 
            // spdAuditList
            // 
            this.spdAuditList.AccessibleDescription = "spdAuditList, Sheet1, Row 0, Column 0, ";
            this.spdAuditList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAuditList.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdAuditList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAuditList.HorizontalScrollBar.Name = "";
            this.spdAuditList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdAuditList.HorizontalScrollBar.TabIndex = 40;
            this.spdAuditList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAuditList.Location = new System.Drawing.Point(0, 0);
            this.spdAuditList.Name = "spdAuditList";
            this.spdAuditList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAuditList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAuditList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAuditList_Sheet1});
            this.spdAuditList.Size = new System.Drawing.Size(742, 402);
            this.spdAuditList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAuditList.TabIndex = 11;
            this.spdAuditList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAuditList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAuditList.VerticalScrollBar.Name = "";
            this.spdAuditList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdAuditList.VerticalScrollBar.TabIndex = 41;
            this.spdAuditList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAuditList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAuditList_ButtonClicked);
            this.spdAuditList.SetViewportLeftColumn(0, 0, 4);
            this.spdAuditList.SetActiveViewport(0, 0, -1);
            // 
            // spdAuditList_Sheet1
            // 
            this.spdAuditList_Sheet1.Reset();
            spdAuditList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAuditList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAuditList_Sheet1.ColumnCount = 16;
            spdAuditList_Sheet1.RowCount = 2;
            this.spdAuditList_Sheet1.Cells.Get(0, 1).Value = 0;
            this.spdAuditList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAuditList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAuditList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAuditList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Detail";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Audit ID";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Audit Description";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Plan Date";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Customer Code";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Customer";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Auditor";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Manager ID";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Manager";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Status Code";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Status";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Create Time";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Create User";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Update Time";
            this.spdAuditList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Update User";
            this.spdAuditList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAuditList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAuditList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdAuditList_Sheet1.Columns.Get(0).CellType = checkBoxCellType2;
            this.spdAuditList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdAuditList_Sheet1.Columns.Get(0).Locked = false;
            this.spdAuditList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(0).Width = 29F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "Detail";
            this.spdAuditList_Sheet1.Columns.Get(1).CellType = buttonCellType2;
            this.spdAuditList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(1).Label = "Detail";
            this.spdAuditList_Sheet1.Columns.Get(1).Locked = false;
            this.spdAuditList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(2).Label = "Audit ID";
            this.spdAuditList_Sheet1.Columns.Get(2).Locked = true;
            this.spdAuditList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(2).Width = 80F;
            this.spdAuditList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAuditList_Sheet1.Columns.Get(3).Label = "Audit Description";
            this.spdAuditList_Sheet1.Columns.Get(3).Locked = true;
            this.spdAuditList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(3).Width = 150F;
            this.spdAuditList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(4).Label = "Plan Date";
            this.spdAuditList_Sheet1.Columns.Get(4).Locked = true;
            this.spdAuditList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(4).Width = 90F;
            this.spdAuditList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAuditList_Sheet1.Columns.Get(5).Label = "Customer Code";
            this.spdAuditList_Sheet1.Columns.Get(5).Locked = true;
            this.spdAuditList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(5).Visible = false;
            this.spdAuditList_Sheet1.Columns.Get(5).Width = 0F;
            this.spdAuditList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(6).Label = "Customer";
            this.spdAuditList_Sheet1.Columns.Get(6).Locked = true;
            this.spdAuditList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(6).Width = 120F;
            this.spdAuditList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(7).Label = "Auditor";
            this.spdAuditList_Sheet1.Columns.Get(7).Locked = true;
            this.spdAuditList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(7).Width = 140F;
            this.spdAuditList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(8).Label = "Manager ID";
            this.spdAuditList_Sheet1.Columns.Get(8).Locked = true;
            this.spdAuditList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(8).Visible = false;
            this.spdAuditList_Sheet1.Columns.Get(8).Width = 0F;
            this.spdAuditList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(9).Label = "Manager";
            this.spdAuditList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(9).Width = 100F;
            this.spdAuditList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(10).Label = "Status Code";
            this.spdAuditList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(10).Visible = false;
            this.spdAuditList_Sheet1.Columns.Get(10).Width = 0F;
            this.spdAuditList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(11).Label = "Status";
            this.spdAuditList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAuditList_Sheet1.Columns.Get(11).Width = 80F;
            this.spdAuditList_Sheet1.Columns.Get(12).Label = "Create Time";
            this.spdAuditList_Sheet1.Columns.Get(12).Width = 100F;
            this.spdAuditList_Sheet1.Columns.Get(13).Label = "Create User";
            this.spdAuditList_Sheet1.Columns.Get(13).Width = 80F;
            this.spdAuditList_Sheet1.Columns.Get(14).Label = "Update Time";
            this.spdAuditList_Sheet1.Columns.Get(14).Width = 100F;
            this.spdAuditList_Sheet1.Columns.Get(15).Label = "Update User";
            this.spdAuditList_Sheet1.Columns.Get(15).Width = 80F;
            this.spdAuditList_Sheet1.FrozenColumnCount = 4;
            this.spdAuditList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAuditList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAuditList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdAuditList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAuditList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAuditList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdAuditList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAuditList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAuditList_Sheet1.ShowRowSelector = true;
            this.spdAuditList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmInputAuditPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmInputAuditPlan";
            this.Text = "Input Audit Plan";
            this.Activated += new System.EventHandler(this.frmInputAuditPlan_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvStatus)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAuditList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAuditList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPlanToDate;
        private System.Windows.Forms.DateTimePicker dtpPlanFromDate;
        private System.Windows.Forms.Label label4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvManager;
        private System.Windows.Forms.Label label5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCustomer;
        private System.Windows.Forms.Label lblViewUseDept;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private FarPoint.Win.Spread.FpSpread spdAuditList;
        private FarPoint.Win.Spread.SheetView spdAuditList_Sheet1;

    }
}