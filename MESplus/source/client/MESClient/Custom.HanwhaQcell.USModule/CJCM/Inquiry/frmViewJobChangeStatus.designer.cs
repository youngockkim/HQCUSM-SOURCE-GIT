namespace Custom.HanwhaQcell.USModule
{
    partial class frmViewJobChangeStatus
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
            this.lbl2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.spdJobChangeList = new FarPoint.Win.Spread.FpSpread();
            this.spdJobChangeList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvLine = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblFail = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdJobChangeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdJobChangeList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLine)).BeginInit();
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
            this.grpOption.Controls.Add(this.label1);
            this.grpOption.Controls.Add(this.lblStart);
            this.grpOption.Controls.Add(this.lblEnd);
            this.grpOption.Controls.Add(this.lblFail);
            this.grpOption.Controls.Add(this.cdvLine);
            this.grpOption.Controls.Add(this.lblLine);
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.txtOrderNumber);
            this.grpOption.Controls.Add(this.lblOrderNo);
            this.grpOption.Controls.Add(this.lbl2);
            this.grpOption.Controls.Add(this.dtpToDate);
            this.grpOption.Controls.Add(this.dtpFromDate);
            this.grpOption.Controls.Add(this.lblDate);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.panel6);
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
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbl2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl2.Location = new System.Drawing.Point(226, 22);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(14, 13);
            this.lbl2.TabIndex = 152;
            this.lbl2.Text = "~";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Checked = false;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(242, 16);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(96, 20);
            this.dtpToDate.TabIndex = 155;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Checked = false;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(119, 16);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(96, 20);
            this.dtpFromDate.TabIndex = 154;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDate.Location = new System.Drawing.Point(30, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(84, 13);
            this.lblDate.TabIndex = 153;
            this.lblDate.Text = "Order Start Date";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.spdJobChangeList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(742, 435);
            this.panel6.TabIndex = 1;
            // 
            // spdJobChangeList
            // 
            this.spdJobChangeList.AccessibleDescription = "spdJobChangeList, Sheet1, Row 0, Column 0, ";
            this.spdJobChangeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdJobChangeList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdJobChangeList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdJobChangeList.HorizontalScrollBar.Name = "";
            this.spdJobChangeList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdJobChangeList.HorizontalScrollBar.TabIndex = 80;
            this.spdJobChangeList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdJobChangeList.Location = new System.Drawing.Point(0, 0);
            this.spdJobChangeList.Name = "spdJobChangeList";
            this.spdJobChangeList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdJobChangeList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdJobChangeList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdJobChangeList_Sheet1});
            this.spdJobChangeList.Size = new System.Drawing.Size(742, 435);
            this.spdJobChangeList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdJobChangeList.TabIndex = 11;
            this.spdJobChangeList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdJobChangeList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdJobChangeList.VerticalScrollBar.Name = "";
            this.spdJobChangeList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdJobChangeList.VerticalScrollBar.TabIndex = 81;
            this.spdJobChangeList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdJobChangeList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdJobChangeList.SetViewportLeftColumn(0, 0, 3);
            this.spdJobChangeList.SetActiveViewport(0, 0, -1);
            // 
            // spdJobChangeList_Sheet1
            // 
            this.spdJobChangeList_Sheet1.Reset();
            spdJobChangeList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdJobChangeList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdJobChangeList_Sheet1.ColumnCount = 18;
            spdJobChangeList_Sheet1.ColumnHeader.RowCount = 2;
            spdJobChangeList_Sheet1.RowCount = 2;
            this.spdJobChangeList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdJobChangeList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Order ID";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Material";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Line";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Customer Name";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Start Date";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Status";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 11;
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Job Change Item";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Job Change Item";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Create User";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Item Name";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Detial";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 1).Value = "Code";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 2).Value = "Description";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 7).Value = "Item Code";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 8).Value = "Item Name";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 9).Value = "Auto Flag";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 10).Value = "Responsibility";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 11).Value = "Plan Start Date";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 12).Value = "Plan End Date";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 13).Value = "Start Time";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 14).Value = "End Time";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 15).Value = "Work Time";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 16).Value = "Check Flag";
            this.spdJobChangeList_Sheet1.ColumnHeader.Cells.Get(1, 17).Value = "Error";
            this.spdJobChangeList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdJobChangeList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdJobChangeList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(0).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(0).Width = 100F;
            this.spdJobChangeList_Sheet1.Columns.Get(1).Label = "Code";
            this.spdJobChangeList_Sheet1.Columns.Get(1).Width = 106F;
            this.spdJobChangeList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdJobChangeList_Sheet1.Columns.Get(2).Label = "Description";
            this.spdJobChangeList_Sheet1.Columns.Get(2).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(2).Width = 223F;
            this.spdJobChangeList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(3).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdJobChangeList_Sheet1.Columns.Get(4).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(4).Width = 145F;
            this.spdJobChangeList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(5).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(5).Width = 80F;
            this.spdJobChangeList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(6).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(6).Width = 80F;
            this.spdJobChangeList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdJobChangeList_Sheet1.Columns.Get(7).Label = "Item Code";
            this.spdJobChangeList_Sheet1.Columns.Get(7).Width = 120F;
            this.spdJobChangeList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdJobChangeList_Sheet1.Columns.Get(8).Label = "Item Name";
            this.spdJobChangeList_Sheet1.Columns.Get(8).Width = 250F;
            this.spdJobChangeList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(9).Label = "Auto Flag";
            this.spdJobChangeList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(10).Label = "Responsibility";
            this.spdJobChangeList_Sheet1.Columns.Get(10).Width = 118F;
            this.spdJobChangeList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(11).Label = "Plan Start Date";
            this.spdJobChangeList_Sheet1.Columns.Get(11).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(11).Width = 90F;
            this.spdJobChangeList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(12).Label = "Plan End Date";
            this.spdJobChangeList_Sheet1.Columns.Get(12).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(12).Width = 90F;
            this.spdJobChangeList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(13).Label = "Start Time";
            this.spdJobChangeList_Sheet1.Columns.Get(13).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(13).Width = 130F;
            this.spdJobChangeList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(14).Label = "End Time";
            this.spdJobChangeList_Sheet1.Columns.Get(14).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(14).Width = 130F;
            this.spdJobChangeList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(15).Label = "Work Time";
            this.spdJobChangeList_Sheet1.Columns.Get(15).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(15).Width = 80F;
            this.spdJobChangeList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(16).Label = "Check Flag";
            this.spdJobChangeList_Sheet1.Columns.Get(16).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(16).Width = 70F;
            this.spdJobChangeList_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdJobChangeList_Sheet1.Columns.Get(17).Label = "Error";
            this.spdJobChangeList_Sheet1.Columns.Get(17).Locked = true;
            this.spdJobChangeList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.Columns.Get(17).Width = 0F;
            this.spdJobChangeList_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeList_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdJobChangeList_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdJobChangeList_Sheet1.FrozenColumnCount = 3;
            this.spdJobChangeList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdJobChangeList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdJobChangeList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdJobChangeList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdJobChangeList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdJobChangeList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdJobChangeList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdJobChangeList_Sheet1.ShowRowSelector = true;
            this.spdJobChangeList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNumber.Location = new System.Drawing.Point(119, 40);
            this.txtOrderNumber.MaxLength = 100;
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(219, 20);
            this.txtOrderNumber.TabIndex = 157;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.Location = new System.Drawing.Point(30, 43);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(47, 13);
            this.lblOrderNo.TabIndex = 156;
            this.lblOrderNo.Text = "Order ID";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvMaterial.Location = new System.Drawing.Point(393, 40);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(337, 20);
            this.cdvMaterial.TabIndex = 158;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 74;
            this.cdvMaterial.WidthMaterialAndVersion = 131;
            this.cdvMaterial.WidthVersion = 30;
            // 
            // cdvLine
            // 
            this.cdvLine.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLine.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLine.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLine.BtnToolTipText = "";
            this.cdvLine.ButtonWidth = 20;
            this.cdvLine.DescText = "";
            this.cdvLine.DisplaySubItemIndex = 0;
            this.cdvLine.DisplayText = "";
            this.cdvLine.Focusing = null;
            this.cdvLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLine.Index = 0;
            this.cdvLine.IsViewBtnImage = false;
            this.cdvLine.Location = new System.Drawing.Point(467, 16);
            this.cdvLine.MaxLength = 40;
            this.cdvLine.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLine.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLine.MultiSelect = false;
            this.cdvLine.Name = "cdvLine";
            this.cdvLine.ReadOnly = false;
            this.cdvLine.SameWidthHeightOfButton = false;
            this.cdvLine.SearchSubItemIndex = 0;
            this.cdvLine.SelectedDescIndex = 1;
            this.cdvLine.SelectedDescToQueryText = "";
            this.cdvLine.SelectedSubItemIndex = 0;
            this.cdvLine.SelectedValueToQueryText = "";
            this.cdvLine.SelectionStart = 0;
            this.cdvLine.Size = new System.Drawing.Size(263, 21);
            this.cdvLine.SmallImageList = null;
            this.cdvLine.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLine.TabIndex = 159;
            this.cdvLine.TextBoxToolTipText = "";
            this.cdvLine.TextBoxWidth = 100;
            this.cdvLine.VisibleButton = true;
            this.cdvLine.VisibleColumnHeader = false;
            this.cdvLine.VisibleDescription = true;
            this.cdvLine.ButtonPress += new System.EventHandler(this.cdvLine_ButtonPress);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLine.Location = new System.Drawing.Point(393, 20);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(47, 13);
            this.lblLine.TabIndex = 160;
            this.lblLine.Text = "Line No.";
            // 
            // lblFail
            // 
            this.lblFail.BackColor = System.Drawing.Color.Crimson;
            this.lblFail.Location = new System.Drawing.Point(788, 41);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(55, 15);
            this.lblFail.TabIndex = 166;
            this.lblFail.Text = "Fail";
            this.lblFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnd
            // 
            this.lblEnd.BackColor = System.Drawing.Color.DarkTurquoise;
            this.lblEnd.Location = new System.Drawing.Point(846, 22);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(55, 15);
            this.lblEnd.TabIndex = 167;
            this.lblEnd.Text = "Ended";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStart
            // 
            this.lblStart.BackColor = System.Drawing.Color.LightCyan;
            this.lblStart.Location = new System.Drawing.Point(786, 22);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(55, 15);
            this.lblStart.TabIndex = 168;
            this.lblStart.Text = "Started";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(846, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 169;
            this.label1.Text = "Delayed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmViewJobChangeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmViewJobChangeStatus";
            this.Text = "View Job Change Status";
            this.Activated += new System.EventHandler(this.frmViewJobChangeStatus_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdJobChangeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdJobChangeList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel6;
        private FarPoint.Win.Spread.FpSpread spdJobChangeList;
        private FarPoint.Win.Spread.SheetView spdJobChangeList_Sheet1;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label lblOrderNo;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLine;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblFail;
        private System.Windows.Forms.Label label1;

    }
}