namespace Custom.HanwhaQcell.USModule
{
    partial class frmMMSAttributesAnalysis
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
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.label1 = new System.Windows.Forms.Label();
            this.cdvEquipCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label5 = new System.Windows.Forms.Label();
            this.cdvMgtDept = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpPlanToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.spdAnalysisResultList = new FarPoint.Win.Spread.FpSpread();
            this.spdAnalysisResultList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvEquipType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMgtDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnalysisResultList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnalysisResultList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipType)).BeginInit();
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
            this.grpOption.Controls.Add(this.cdvEquipType);
            this.grpOption.Controls.Add(this.label1);
            this.grpOption.Controls.Add(this.cdvEquipCode);
            this.grpOption.Controls.Add(this.label5);
            this.grpOption.Controls.Add(this.cdvMgtDept);
            this.grpOption.Controls.Add(this.label3);
            this.grpOption.Controls.Add(this.dtpPlanToDate);
            this.grpOption.Controls.Add(this.dtpPlanFromDate);
            this.grpOption.Controls.Add(this.label4);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdAnalysisResultList);
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
            this.lblFormTitle.Text = "Gage R&R Variables Analysis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(258, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 140;
            this.label1.Text = "~";
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
            this.cdvEquipCode.Location = new System.Drawing.Point(142, 42);
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
            this.cdvEquipCode.TabIndex = 147;
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
            this.label5.Location = new System.Drawing.Point(33, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 146;
            this.label5.Text = "Measuring Equipment";
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
            this.cdvMgtDept.Location = new System.Drawing.Point(504, 42);
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
            this.cdvMgtDept.Size = new System.Drawing.Size(211, 20);
            this.cdvMgtDept.SmallImageList = null;
            this.cdvMgtDept.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMgtDept.TabIndex = 145;
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
            this.label3.Location = new System.Drawing.Point(413, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 144;
            this.label3.Text = "Mgt Dept";
            // 
            // dtpPlanToDate
            // 
            this.dtpPlanToDate.Checked = false;
            this.dtpPlanToDate.CustomFormat = "";
            this.dtpPlanToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanToDate.Location = new System.Drawing.Point(273, 16);
            this.dtpPlanToDate.Name = "dtpPlanToDate";
            this.dtpPlanToDate.Size = new System.Drawing.Size(110, 20);
            this.dtpPlanToDate.TabIndex = 143;
            // 
            // dtpPlanFromDate
            // 
            this.dtpPlanFromDate.Checked = false;
            this.dtpPlanFromDate.CustomFormat = "";
            this.dtpPlanFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanFromDate.Location = new System.Drawing.Point(142, 16);
            this.dtpPlanFromDate.Name = "dtpPlanFromDate";
            this.dtpPlanFromDate.Size = new System.Drawing.Size(110, 20);
            this.dtpPlanFromDate.TabIndex = 142;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(33, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 141;
            this.label4.Text = "Plan Date";
            // 
            // spdAnalysisResultList
            // 
            this.spdAnalysisResultList.AccessibleDescription = "spdAnalysisResultList, Sheet1, Row 0, Column 0, ";
            this.spdAnalysisResultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAnalysisResultList.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdAnalysisResultList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAnalysisResultList.HorizontalScrollBar.Name = "";
            this.spdAnalysisResultList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdAnalysisResultList.HorizontalScrollBar.TabIndex = 70;
            this.spdAnalysisResultList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAnalysisResultList.Location = new System.Drawing.Point(0, 0);
            this.spdAnalysisResultList.Name = "spdAnalysisResultList";
            this.spdAnalysisResultList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAnalysisResultList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAnalysisResultList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAnalysisResultList_Sheet1});
            this.spdAnalysisResultList.Size = new System.Drawing.Size(742, 435);
            this.spdAnalysisResultList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAnalysisResultList.TabIndex = 53;
            this.spdAnalysisResultList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAnalysisResultList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAnalysisResultList.VerticalScrollBar.Name = "";
            this.spdAnalysisResultList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdAnalysisResultList.VerticalScrollBar.TabIndex = 71;
            this.spdAnalysisResultList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAnalysisResultList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAnalysisResultList_ButtonClicked);
            this.spdAnalysisResultList.SetViewportLeftColumn(0, 0, 6);
            this.spdAnalysisResultList.SetActiveViewport(0, 0, -1);
            // 
            // spdAnalysisResultList_Sheet1
            // 
            this.spdAnalysisResultList_Sheet1.Reset();
            spdAnalysisResultList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAnalysisResultList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAnalysisResultList_Sheet1.ColumnCount = 21;
            spdAnalysisResultList_Sheet1.RowCount = 1;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "Detail";
            this.spdAnalysisResultList_Sheet1.Cells.Get(0, 0).CellType = buttonCellType3;
            this.spdAnalysisResultList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnalysisResultList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAnalysisResultList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnalysisResultList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Detail";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "ANA_ID";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Plan Date";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Measurement Date";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Judge Result";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Equip Code";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Equip Name";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Sample Name";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Inspector Count";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Sample Count";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Repeat Count";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Item Code";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Item Name";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "LSL";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "USL";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Unit";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Decimal Place";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Create Time";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Create User";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Update Time";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Update User";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnalysisResultList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAnalysisResultList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.Text = "Detail";
            this.spdAnalysisResultList_Sheet1.Columns.Get(0).CellType = buttonCellType4;
            this.spdAnalysisResultList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(0).Label = "Detail";
            this.spdAnalysisResultList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(0).Width = 65F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(1).Label = "ANA_ID";
            this.spdAnalysisResultList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(1).Visible = false;
            this.spdAnalysisResultList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(2).Label = "Plan Date";
            this.spdAnalysisResultList_Sheet1.Columns.Get(2).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(2).Width = 100F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(3).Label = "Measurement Date";
            this.spdAnalysisResultList_Sheet1.Columns.Get(3).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(3).Width = 100F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(4).Label = "Judge Result";
            this.spdAnalysisResultList_Sheet1.Columns.Get(4).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(4).Width = 100F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(5).Label = "Equip Code";
            this.spdAnalysisResultList_Sheet1.Columns.Get(5).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(5).Width = 100F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(6).Label = "Equip Name";
            this.spdAnalysisResultList_Sheet1.Columns.Get(6).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(6).Width = 120F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(7).Label = "Sample Name";
            this.spdAnalysisResultList_Sheet1.Columns.Get(7).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(7).Width = 80F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(8).Label = "Inspector Count";
            this.spdAnalysisResultList_Sheet1.Columns.Get(8).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(8).Width = 90F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(9).Label = "Sample Count";
            this.spdAnalysisResultList_Sheet1.Columns.Get(9).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(9).Width = 80F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(10).Label = "Repeat Count";
            this.spdAnalysisResultList_Sheet1.Columns.Get(10).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(10).Width = 80F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(11).Label = "Item Code";
            this.spdAnalysisResultList_Sheet1.Columns.Get(11).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(11).Width = 80F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(12).Label = "Item Name";
            this.spdAnalysisResultList_Sheet1.Columns.Get(12).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(12).Width = 167F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(13).Label = "LSL";
            this.spdAnalysisResultList_Sheet1.Columns.Get(13).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(13).Width = 88F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(14).Label = "USL";
            this.spdAnalysisResultList_Sheet1.Columns.Get(14).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(14).Width = 88F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(15).Label = "Unit";
            this.spdAnalysisResultList_Sheet1.Columns.Get(15).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(15).Width = 88F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(16).Label = "Decimal Place";
            this.spdAnalysisResultList_Sheet1.Columns.Get(16).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(16).Width = 88F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(17).Label = "Create Time";
            this.spdAnalysisResultList_Sheet1.Columns.Get(17).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(17).Width = 100F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(18).Label = "Create User";
            this.spdAnalysisResultList_Sheet1.Columns.Get(18).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(18).Width = 80F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(19).Label = "Update Time";
            this.spdAnalysisResultList_Sheet1.Columns.Get(19).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(19).Width = 100F;
            this.spdAnalysisResultList_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(20).Label = "Update User";
            this.spdAnalysisResultList_Sheet1.Columns.Get(20).Locked = true;
            this.spdAnalysisResultList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAnalysisResultList_Sheet1.Columns.Get(20).Width = 80F;
            this.spdAnalysisResultList_Sheet1.FrozenColumnCount = 6;
            this.spdAnalysisResultList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAnalysisResultList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAnalysisResultList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdAnalysisResultList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnalysisResultList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAnalysisResultList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAnalysisResultList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAnalysisResultList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(412, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 156;
            this.label2.Text = "Equip Type";
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
            this.cdvEquipType.Location = new System.Drawing.Point(504, 16);
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
            this.cdvEquipType.TabIndex = 157;
            this.cdvEquipType.TextBoxToolTipText = "";
            this.cdvEquipType.TextBoxWidth = 85;
            this.cdvEquipType.VisibleButton = true;
            this.cdvEquipType.VisibleColumnHeader = false;
            this.cdvEquipType.VisibleDescription = true;
            this.cdvEquipType.ButtonPress += new System.EventHandler(this.cdvEquipType_ButtonPress);
            // 
            // frmMMSAttributesAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmMMSAttributesAnalysis";
            this.Text = "Gage R&R Attributes Analysis";
            this.Activated += new System.EventHandler(this.frmMMSAttributesAnalysis_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMgtDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnalysisResultList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAnalysisResultList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEquipType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEquipCode;
        private System.Windows.Forms.Label label5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMgtDept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpPlanToDate;
        private System.Windows.Forms.DateTimePicker dtpPlanFromDate;
        private System.Windows.Forms.Label label4;
        private FarPoint.Win.Spread.FpSpread spdAnalysisResultList;
        private FarPoint.Win.Spread.SheetView spdAnalysisResultList_Sheet1;
        private System.Windows.Forms.Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEquipType;
    }
}