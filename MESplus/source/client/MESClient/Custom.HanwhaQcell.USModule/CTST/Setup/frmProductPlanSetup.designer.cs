namespace Custom.HanwhaQcell.USModule
{
    partial class frmProductPlanSetup
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductPlanSetup));
            this.grpViewProductPlan = new System.Windows.Forms.GroupBox();
            this.spdPlan = new FarPoint.Win.Spread.FpSpread();
            this.spdPlan_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdXlsData = new FarPoint.Win.Spread.FpSpread();
            this.sheetView2 = new FarPoint.Win.Spread.SheetView();
            this.spdData1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.spdXlsData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdData2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblMatID = new System.Windows.Forms.Label();
            this.cdvMatID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnExcelOpen = new System.Windows.Forms.Button();
            this.dtpOptWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblOptWorkDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cdvLineID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpViewProductPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlan_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdXlsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData1_Sheet1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdXlsData_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData2_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLineID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(1208, 66);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.grpViewProductPlan);
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 66);
            this.pnlTranCenter.Size = new System.Drawing.Size(1208, 560);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.dtpOptWorkDate);
            this.grpTranTop.Controls.Add(this.lblOptWorkDate);
            this.grpTranTop.Controls.Add(this.btnExcelOpen);
            this.grpTranTop.Controls.Add(this.label1);
            this.grpTranTop.Controls.Add(this.lblMatID);
            this.grpTranTop.Controls.Add(this.cdvLineID);
            this.grpTranTop.Controls.Add(this.cdvMatID);
            this.grpTranTop.ForeColor = System.Drawing.Color.Black;
            this.grpTranTop.Size = new System.Drawing.Size(1202, 66);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(30208, 7);
            this.btnProcess.Text = "Order Close";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(30299, 7);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExport);
            this.pnlBottom.Controls.Add(this.btnClose2);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnCreate);
            this.pnlBottom.Controls.Add(this.btnDel);
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Location = new System.Drawing.Point(0, 626);
            this.pnlBottom.Size = new System.Drawing.Size(1208, 40);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose2, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExport, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(1208, 626);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(915, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Size = new System.Drawing.Size(911, 0);
            this.lblFormTitle.Text = "TranForm02";
            // 
            // grpViewProductPlan
            // 
            this.grpViewProductPlan.Controls.Add(this.spdPlan);
            this.grpViewProductPlan.Controls.Add(this.spdXlsData);
            this.grpViewProductPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpViewProductPlan.Location = new System.Drawing.Point(3, 3);
            this.grpViewProductPlan.Name = "grpViewProductPlan";
            this.grpViewProductPlan.Size = new System.Drawing.Size(1202, 557);
            this.grpViewProductPlan.TabIndex = 0;
            this.grpViewProductPlan.TabStop = false;
            // 
            // spdPlan
            // 
            this.spdPlan.AccessibleDescription = "fpSpread1, Sheet1";
            this.spdPlan.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.spdPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdPlan.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdPlan.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPlan.HorizontalScrollBar.Name = "";
            this.spdPlan.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdPlan.HorizontalScrollBar.TabIndex = 0;
            this.spdPlan.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdPlan.Location = new System.Drawing.Point(3, 19);
            this.spdPlan.Name = "spdPlan";
            this.spdPlan.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.spdPlan.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdPlan_Sheet1});
            this.spdPlan.Size = new System.Drawing.Size(1196, 535);
            this.spdPlan.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdPlan.TabIndex = 3;
            this.spdPlan.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPlan.VerticalScrollBar.Name = "";
            this.spdPlan.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdPlan.VerticalScrollBar.TabIndex = 1;
            this.spdPlan.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdPlan.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdPlan.EditModeOff += new System.EventHandler(this.spdPlan_EditModeOff);
            this.spdPlan.ClipboardPasted += new FarPoint.Win.Spread.ClipboardPastedEventHandler(this.spdPlan_ClipboardPasted);
            this.spdPlan.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdPlan_CellClick);
            this.spdPlan.SetActiveViewport(0, -1, -1);
            // 
            // spdPlan_Sheet1
            // 
            this.spdPlan_Sheet1.Reset();
            spdPlan_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdPlan_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdPlan_Sheet1.ColumnCount = 0;
            spdPlan_Sheet1.ColumnHeader.RowCount = 0;
            spdPlan_Sheet1.RowCount = 0;
            this.spdPlan_Sheet1.ActiveColumnIndex = -1;
            this.spdPlan_Sheet1.ActiveRowIndex = -1;
            this.spdPlan_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdPlan_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdPlan_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdPlan_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdPlan_Sheet1.Columns.Default.CanFocus = true;
            this.spdPlan_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdPlan_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdPlan_Sheet1.RowHeader.AutoTextIndex = 0;
            this.spdPlan_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdPlan_Sheet1.RowHeader.Columns.Get(0).Width = 34F;
            this.spdPlan_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdPlan_Sheet1.Rows.Default.CanFocus = true;
            this.spdPlan_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.spdPlan_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdPlan_Sheet1.ShowRowSelector = true;
            this.spdPlan_Sheet1.StartingColumnNumber = -1;
            this.spdPlan_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdXlsData
            // 
            this.spdXlsData.AccessibleDescription = "fpSpread1, Sheet1";
            this.spdXlsData.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.spdXlsData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdXlsData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdXlsData.HorizontalScrollBar.Name = "";
            this.spdXlsData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdXlsData.HorizontalScrollBar.TabIndex = 0;
            this.spdXlsData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdXlsData.Location = new System.Drawing.Point(576, 24);
            this.spdXlsData.Name = "spdXlsData";
            this.spdXlsData.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.spdXlsData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.sheetView2});
            this.spdXlsData.Size = new System.Drawing.Size(623, 194);
            this.spdXlsData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdXlsData.TabIndex = 4;
            this.spdXlsData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdXlsData.VerticalScrollBar.Name = "";
            this.spdXlsData.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdXlsData.VerticalScrollBar.TabIndex = 1;
            this.spdXlsData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdXlsData.Visible = false;
            this.spdXlsData.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdXlsData.SetActiveViewport(0, -1, -1);
            // 
            // sheetView2
            // 
            this.sheetView2.Reset();
            sheetView2.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetView2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            sheetView2.ColumnCount = 0;
            sheetView2.ColumnHeader.RowCount = 0;
            sheetView2.RowCount = 0;
            this.sheetView2.ActiveColumnIndex = -1;
            this.sheetView2.ActiveRowIndex = -1;
            this.sheetView2.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.sheetView2.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.sheetView2.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.sheetView2.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.sheetView2.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.sheetView2.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.sheetView2.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.sheetView2.Columns.Default.CanFocus = true;
            this.sheetView2.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.sheetView2.DefaultStyle.Parent = "DataAreaDefault";
            this.sheetView2.GrayAreaBackColor = System.Drawing.Color.White;
            this.sheetView2.RowHeader.AutoTextIndex = 0;
            this.sheetView2.RowHeader.Columns.Default.Resizable = false;
            this.sheetView2.RowHeader.Columns.Get(0).Width = 34F;
            this.sheetView2.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.sheetView2.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.sheetView2.Rows.Default.CanFocus = true;
            this.sheetView2.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.sheetView2.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.sheetView2.SheetCornerStyle.Parent = "CornerDefault";
            this.sheetView2.ShowRowSelector = true;
            this.sheetView2.StartingColumnNumber = -1;
            this.sheetView2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdData1_Sheet1
            // 
            this.spdData1_Sheet1.Reset();
            spdData1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData1_Sheet1.ColumnCount = 0;
            spdData1_Sheet1.RowCount = 0;
            this.spdData1_Sheet1.ActiveColumnIndex = -1;
            this.spdData1_Sheet1.ActiveRowIndex = -1;
            this.spdData1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelRow);
            this.panel2.Controls.Add(this.btnAddRow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1182, 41);
            this.panel2.TabIndex = 1;
            // 
            // btnDelRow
            // 
            this.btnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelRow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelRow.Location = new System.Drawing.Point(594, 7);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(88, 26);
            this.btnDelRow.TabIndex = 4;
            this.btnDelRow.Text = "행삭제";
            // 
            // btnAddRow
            // 
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddRow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddRow.Location = new System.Drawing.Point(500, 7);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(88, 26);
            this.btnAddRow.TabIndex = 3;
            this.btnAddRow.Text = "행추가";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(701, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 160);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // spdXlsData_Sheet1
            // 
            this.spdXlsData_Sheet1.Reset();
            spdXlsData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdXlsData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdXlsData_Sheet1.ColumnCount = 0;
            spdXlsData_Sheet1.RowCount = 0;
            this.spdXlsData_Sheet1.ActiveColumnIndex = -1;
            this.spdXlsData_Sheet1.ActiveRowIndex = -1;
            this.spdXlsData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdXlsData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdData2_Sheet1
            // 
            this.spdData2_Sheet1.Reset();
            spdData2_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData2_Sheet1.ColumnCount = 0;
            spdData2_Sheet1.RowCount = 0;
            this.spdData2_Sheet1.ActiveColumnIndex = -1;
            this.spdData2_Sheet1.ActiveRowIndex = -1;
            this.spdData2_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(931, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblMatID
            // 
            this.lblMatID.AutoSize = true;
            this.lblMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatID.Location = new System.Drawing.Point(631, 32);
            this.lblMatID.Name = "lblMatID";
            this.lblMatID.Size = new System.Drawing.Size(48, 17);
            this.lblMatID.TabIndex = 40;
            this.lblMatID.Text = "Mat ID";
            // 
            // cdvMatID
            // 
            this.cdvMatID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMatID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMatID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMatID.BtnToolTipText = "";
            this.cdvMatID.ButtonWidth = 20;
            this.cdvMatID.DescText = "";
            this.cdvMatID.DisplaySubItemIndex = 0;
            this.cdvMatID.DisplayText = "";
            this.cdvMatID.Focusing = null;
            this.cdvMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.Index = 0;
            this.cdvMatID.IsViewBtnImage = false;
            this.cdvMatID.Location = new System.Drawing.Point(689, 28);
            this.cdvMatID.MaxLength = 32767;
            this.cdvMatID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMatID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMatID.MultiSelect = false;
            this.cdvMatID.Name = "cdvMatID";
            this.cdvMatID.ReadOnly = false;
            this.cdvMatID.SameWidthHeightOfButton = false;
            this.cdvMatID.SearchSubItemIndex = 0;
            this.cdvMatID.SelectedDescIndex = 1;
            this.cdvMatID.SelectedDescToQueryText = "";
            this.cdvMatID.SelectedSubItemIndex = 0;
            this.cdvMatID.SelectedValueToQueryText = "";
            this.cdvMatID.SelectionStart = 0;
            this.cdvMatID.Size = new System.Drawing.Size(286, 20);
            this.cdvMatID.SmallImageList = null;
            this.cdvMatID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMatID.TabIndex = 41;
            this.cdvMatID.TextBoxToolTipText = "";
            this.cdvMatID.TextBoxWidth = 110;
            this.cdvMatID.VisibleButton = true;
            this.cdvMatID.VisibleColumnHeader = false;
            this.cdvMatID.VisibleDescription = true;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(744, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 19;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose2
            // 
            this.btnClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose2.Location = new System.Drawing.Point(1117, 7);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(88, 26);
            this.btnClose2.TabIndex = 20;
            this.btnClose2.Text = "Close";
            this.btnClose2.UseVisualStyleBackColor = true;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(838, 7);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(88, 26);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnExcelOpen
            // 
            this.btnExcelOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcelOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelOpen.Image")));
            this.btnExcelOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcelOpen.Location = new System.Drawing.Point(1010, 26);
            this.btnExcelOpen.Name = "btnExcelOpen";
            this.btnExcelOpen.Size = new System.Drawing.Size(99, 24);
            this.btnExcelOpen.TabIndex = 56;
            this.btnExcelOpen.Text = "Excel Upload";
            this.btnExcelOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelOpen.Click += new System.EventHandler(this.btnExcelOpen_Click);
            // 
            // dtpOptWorkDate
            // 
            this.dtpOptWorkDate.CustomFormat = "yyyyMM";
            this.dtpOptWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOptWorkDate.Location = new System.Drawing.Point(96, 28);
            this.dtpOptWorkDate.Name = "dtpOptWorkDate";
            this.dtpOptWorkDate.Size = new System.Drawing.Size(82, 23);
            this.dtpOptWorkDate.TabIndex = 58;
            // 
            // lblOptWorkDate
            // 
            this.lblOptWorkDate.AutoSize = true;
            this.lblOptWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOptWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptWorkDate.Location = new System.Drawing.Point(23, 30);
            this.lblOptWorkDate.Name = "lblOptWorkDate";
            this.lblOptWorkDate.Size = new System.Drawing.Size(84, 17);
            this.lblOptWorkDate.TabIndex = 57;
            this.lblOptWorkDate.Text = "Work Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(270, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "LINE ID";
            // 
            // cdvLineID
            // 
            this.cdvLineID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLineID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLineID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLineID.BtnToolTipText = "";
            this.cdvLineID.ButtonWidth = 20;
            this.cdvLineID.DescText = "";
            this.cdvLineID.DisplaySubItemIndex = 0;
            this.cdvLineID.DisplayText = "";
            this.cdvLineID.Focusing = null;
            this.cdvLineID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLineID.Index = 0;
            this.cdvLineID.IsViewBtnImage = false;
            this.cdvLineID.Location = new System.Drawing.Point(327, 28);
            this.cdvLineID.MaxLength = 32767;
            this.cdvLineID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLineID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLineID.MultiSelect = false;
            this.cdvLineID.Name = "cdvLineID";
            this.cdvLineID.ReadOnly = false;
            this.cdvLineID.SameWidthHeightOfButton = false;
            this.cdvLineID.SearchSubItemIndex = 0;
            this.cdvLineID.SelectedDescIndex = 1;
            this.cdvLineID.SelectedDescToQueryText = "";
            this.cdvLineID.SelectedSubItemIndex = 0;
            this.cdvLineID.SelectedValueToQueryText = "";
            this.cdvLineID.SelectionStart = 0;
            this.cdvLineID.Size = new System.Drawing.Size(214, 20);
            this.cdvLineID.SmallImageList = null;
            this.cdvLineID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLineID.TabIndex = 41;
            this.cdvLineID.TextBoxToolTipText = "";
            this.cdvLineID.TextBoxWidth = 110;
            this.cdvLineID.VisibleButton = true;
            this.cdvLineID.VisibleColumnHeader = false;
            this.cdvLineID.VisibleDescription = true;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(1024, 7);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(88, 26);
            this.btnDel.TabIndex = 18;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExport.Location = new System.Drawing.Point(29, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 24);
            this.btnExport.TabIndex = 57;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmProductPlanSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 666);
            this.MinimumSize = new System.Drawing.Size(1000, 580);
            this.Name = "frmProductPlanSetup";
            this.Text = "Product Plan Setup";
            this.Load += new System.EventHandler(this.frmProductPlanSetup_Load);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpViewProductPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlan_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdXlsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData1_Sheet1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdXlsData_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData2_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLineID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private udcFromToDate udcFromToDate1;
        private System.Windows.Forms.GroupBox grpViewProductPlan;
        private FarPoint.Win.Spread.FpSpread spdData1;
        private FarPoint.Win.Spread.SheetView spdData1_Sheet1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblMatID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMatID;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.Button btnView;
        //private udcFarpoint spdData2;
        private FarPoint.Win.Spread.SheetView spdData2_Sheet1;
        private System.Windows.Forms.Button btnCreate;
        protected System.Windows.Forms.Button btnExcelOpen;
        private System.Windows.Forms.Panel panel1;
        //private udcFarpoint spdXlsData;
        private FarPoint.Win.Spread.SheetView spdXlsData_Sheet1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnDelRow;
        public System.Windows.Forms.Button btnAddRow;
        private FarPoint.Win.Spread.FpSpread spdPlan;
        private FarPoint.Win.Spread.SheetView spdPlan_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdXlsData;
        private FarPoint.Win.Spread.SheetView sheetView2;
        private System.Windows.Forms.DateTimePicker dtpOptWorkDate;
        private System.Windows.Forms.Label lblOptWorkDate;
        private System.Windows.Forms.Label label1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLineID;
        private System.Windows.Forms.Button btnDel;
        protected System.Windows.Forms.Button btnExport;
    }
}