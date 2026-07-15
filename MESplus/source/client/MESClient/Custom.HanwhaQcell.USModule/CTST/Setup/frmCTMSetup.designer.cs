namespace Custom.HanwhaQcell.USModule
{
    partial class frmCTMSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCTMSetup));
            this.grpViewProductPlan = new System.Windows.Forms.GroupBox();
            this.tabCTM = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.spdCTMView = new FarPoint.Win.Spread.FpSpread();
            this.spdCTMView_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpWorkDate = new Miracom.MESCore.Controls.udcFromToDate();
            this.label1 = new System.Windows.Forms.Label();
            this.cdvLineID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.spdCTM = new FarPoint.Win.Spread.FpSpread();
            this.spdCTM_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.lblOptWorkDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cdvLine2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvItem2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.spdData1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.spdXlsData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdData2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.sheetView1 = new FarPoint.Win.Spread.SheetView();
            this.sheetView3 = new FarPoint.Win.Spread.SheetView();
            this.sheetView4 = new FarPoint.Win.Spread.SheetView();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpViewProductPlan.SuspendLayout();
            this.tabCTM.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCTMView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCTMView_Sheet1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLineID)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCTM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCTM_Sheet1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData1_Sheet1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdXlsData_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData2_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(1208, 10);
            this.pnlTranTop.Visible = false;
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.grpViewProductPlan);
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 10);
            this.pnlTranCenter.Size = new System.Drawing.Size(1208, 496);
            // 
            // grpTranTop
            // 
            this.grpTranTop.ForeColor = System.Drawing.Color.Black;
            this.grpTranTop.Size = new System.Drawing.Size(1202, 10);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(32767, 7);
            this.btnProcess.Text = "Order Close";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(32767, 7);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExport);
            this.pnlBottom.Controls.Add(this.btnClose2);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnDel);
            this.pnlBottom.Size = new System.Drawing.Size(1208, 40);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnSave, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose2, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExport, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(1208, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm02";
            // 
            // grpViewProductPlan
            // 
            this.grpViewProductPlan.Controls.Add(this.tabCTM);
            this.grpViewProductPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpViewProductPlan.Location = new System.Drawing.Point(3, 3);
            this.grpViewProductPlan.Name = "grpViewProductPlan";
            this.grpViewProductPlan.Size = new System.Drawing.Size(1202, 493);
            this.grpViewProductPlan.TabIndex = 0;
            this.grpViewProductPlan.TabStop = false;
            // 
            // tabCTM
            // 
            this.tabCTM.Controls.Add(this.tabPage1);
            this.tabCTM.Controls.Add(this.tabPage2);
            this.tabCTM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCTM.Location = new System.Drawing.Point(3, 16);
            this.tabCTM.Name = "tabCTM";
            this.tabCTM.SelectedIndex = 0;
            this.tabCTM.Size = new System.Drawing.Size(1196, 474);
            this.tabCTM.TabIndex = 0;
            this.tabCTM.SelectedIndexChanged += new System.EventHandler(this.tabCTM_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1188, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View CTM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.spdCTMView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1182, 386);
            this.panel4.TabIndex = 61;
            // 
            // spdCTMView
            // 
            this.spdCTMView.AccessibleDescription = "fpSpread1, Sheet1";
            this.spdCTMView.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.spdCTMView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCTMView.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCTMView.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCTMView.HorizontalScrollBar.Name = "";
            this.spdCTMView.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCTMView.HorizontalScrollBar.TabIndex = 0;
            this.spdCTMView.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCTMView.Location = new System.Drawing.Point(0, 0);
            this.spdCTMView.Name = "spdCTMView";
            this.spdCTMView.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.spdCTMView.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCTMView_Sheet1});
            this.spdCTMView.Size = new System.Drawing.Size(1182, 386);
            this.spdCTMView.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCTMView.TabIndex = 3;
            this.spdCTMView.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCTMView.VerticalScrollBar.Name = "";
            this.spdCTMView.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCTMView.VerticalScrollBar.TabIndex = 1;
            this.spdCTMView.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCTMView.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCTMView.EditModeOff += new System.EventHandler(this.spdCTMView_EditModeOff);
            this.spdCTMView.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCTMView_CellClick);
            this.spdCTMView.SetActiveViewport(0, -1, -1);
            // 
            // spdCTMView_Sheet1
            // 
            this.spdCTMView_Sheet1.Reset();
            spdCTMView_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCTMView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCTMView_Sheet1.ColumnCount = 0;
            spdCTMView_Sheet1.ColumnHeader.RowCount = 0;
            spdCTMView_Sheet1.RowCount = 0;
            this.spdCTMView_Sheet1.ActiveColumnIndex = -1;
            this.spdCTMView_Sheet1.ActiveRowIndex = -1;
            this.spdCTMView_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTMView_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCTMView_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTMView_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCTMView_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdCTMView_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTMView_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCTMView_Sheet1.Columns.Default.CanFocus = true;
            this.spdCTMView_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTMView_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdCTMView_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCTMView_Sheet1.RowHeader.AutoTextIndex = 0;
            this.spdCTMView_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCTMView_Sheet1.RowHeader.Columns.Get(0).Width = 34F;
            this.spdCTMView_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTMView_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCTMView_Sheet1.Rows.Default.CanFocus = true;
            this.spdCTMView_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.spdCTMView_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTMView_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCTMView_Sheet1.ShowRowSelector = true;
            this.spdCTMView_Sheet1.StartingColumnNumber = -1;
            this.spdCTMView_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.dtpWorkDate);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cdvLineID);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1182, 56);
            this.panel3.TabIndex = 60;
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpWorkDate.CanlendarID = "";
            this.dtpWorkDate.ConditionText = "PERIOD";
            this.dtpWorkDate.ConditionType = Miracom.MESCore.Controls.udcFromToDate.DateConditionType.CurrentDay;
            this.dtpWorkDate.DurationType = Miracom.MESCore.Controls.udcFromToDate.DateType.기간;
            this.dtpWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpWorkDate.IsVertical = false;
            this.dtpWorkDate.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpWorkDate.LabelSize = new System.Drawing.Size(80, 20);
            this.dtpWorkDate.LanguageKey = "";
            this.dtpWorkDate.Location = new System.Drawing.Point(17, 20);
            this.dtpWorkDate.MandatoryFlag = false;
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(360, 22);
            this.dtpWorkDate.TabIndex = 64;
            this.dtpWorkDate.VerticalOrder = 0;
            this.dtpWorkDate.VisibleConditionText = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(469, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 60;
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
            this.cdvLineID.Location = new System.Drawing.Point(526, 20);
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
            this.cdvLineID.TabIndex = 62;
            this.cdvLineID.TextBoxToolTipText = "";
            this.cdvLineID.TextBoxWidth = 110;
            this.cdvLineID.VisibleButton = true;
            this.cdvLineID.VisibleColumnHeader = false;
            this.cdvLineID.VisibleDescription = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1188, 448);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create CTM";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.spdCTM);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 59);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1182, 386);
            this.panel6.TabIndex = 66;
            // 
            // spdCTM
            // 
            this.spdCTM.AccessibleDescription = "fpSpread1, Sheet1";
            this.spdCTM.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.spdCTM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCTM.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCTM.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCTM.HorizontalScrollBar.Name = "";
            this.spdCTM.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdCTM.HorizontalScrollBar.TabIndex = 0;
            this.spdCTM.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCTM.Location = new System.Drawing.Point(0, 0);
            this.spdCTM.Name = "spdCTM";
            this.spdCTM.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;
            this.spdCTM.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCTM_Sheet1});
            this.spdCTM.Size = new System.Drawing.Size(1182, 386);
            this.spdCTM.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCTM.TabIndex = 4;
            this.spdCTM.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCTM.VerticalScrollBar.Name = "";
            this.spdCTM.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdCTM.VerticalScrollBar.TabIndex = 1;
            this.spdCTM.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCTM.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCTM.EditModeOff += new System.EventHandler(this.spdCTM_EditModeOff);
            this.spdCTM.ClipboardPasted += new FarPoint.Win.Spread.ClipboardPastedEventHandler(this.spdCTM_ClipboardPasted);
            this.spdCTM.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCTM_CellClick);
            this.spdCTM.SetActiveViewport(0, -1, -1);
            // 
            // spdCTM_Sheet1
            // 
            this.spdCTM_Sheet1.Reset();
            spdCTM_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCTM_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCTM_Sheet1.ColumnCount = 0;
            spdCTM_Sheet1.ColumnHeader.RowCount = 0;
            spdCTM_Sheet1.RowCount = 0;
            this.spdCTM_Sheet1.ActiveColumnIndex = -1;
            this.spdCTM_Sheet1.ActiveRowIndex = -1;
            this.spdCTM_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTM_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCTM_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTM_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCTM_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdCTM_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTM_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCTM_Sheet1.Columns.Default.CanFocus = true;
            this.spdCTM_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTM_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdCTM_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCTM_Sheet1.RowHeader.AutoTextIndex = 0;
            this.spdCTM_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCTM_Sheet1.RowHeader.Columns.Get(0).Width = 34F;
            this.spdCTM_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTM_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCTM_Sheet1.Rows.Default.CanFocus = true;
            this.spdCTM_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.spdCTM_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCTM_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCTM_Sheet1.ShowRowSelector = true;
            this.spdCTM_Sheet1.StartingColumnNumber = -1;
            this.spdCTM_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.btnReset);
            this.panel5.Controls.Add(this.dtpMonth);
            this.panel5.Controls.Add(this.lblOptWorkDate);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.cdvLine2);
            this.panel5.Controls.Add(this.cdvItem2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1182, 56);
            this.panel5.TabIndex = 61;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(1031, 14);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 26);
            this.btnReset.TabIndex = 66;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "yyyyMM";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(93, 20);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(82, 20);
            this.dtpMonth.TabIndex = 65;
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);
            // 
            // lblOptWorkDate
            // 
            this.lblOptWorkDate.AutoSize = true;
            this.lblOptWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOptWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptWorkDate.Location = new System.Drawing.Point(19, 23);
            this.lblOptWorkDate.Name = "lblOptWorkDate";
            this.lblOptWorkDate.Size = new System.Drawing.Size(42, 13);
            this.lblOptWorkDate.TabIndex = 64;
            this.lblOptWorkDate.Text = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(264, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "LINE ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(621, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "ITEM";
            // 
            // cdvLine2
            // 
            this.cdvLine2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLine2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLine2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLine2.BtnToolTipText = "";
            this.cdvLine2.ButtonWidth = 20;
            this.cdvLine2.DescText = "";
            this.cdvLine2.DisplaySubItemIndex = 0;
            this.cdvLine2.DisplayText = "";
            this.cdvLine2.Focusing = null;
            this.cdvLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLine2.Index = 0;
            this.cdvLine2.IsViewBtnImage = false;
            this.cdvLine2.Location = new System.Drawing.Point(321, 20);
            this.cdvLine2.MaxLength = 32767;
            this.cdvLine2.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLine2.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLine2.MultiSelect = false;
            this.cdvLine2.Name = "cdvLine2";
            this.cdvLine2.ReadOnly = false;
            this.cdvLine2.SameWidthHeightOfButton = false;
            this.cdvLine2.SearchSubItemIndex = 0;
            this.cdvLine2.SelectedDescIndex = 1;
            this.cdvLine2.SelectedDescToQueryText = "";
            this.cdvLine2.SelectedSubItemIndex = 0;
            this.cdvLine2.SelectedValueToQueryText = "";
            this.cdvLine2.SelectionStart = 0;
            this.cdvLine2.Size = new System.Drawing.Size(214, 20);
            this.cdvLine2.SmallImageList = null;
            this.cdvLine2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLine2.TabIndex = 62;
            this.cdvLine2.TextBoxToolTipText = "";
            this.cdvLine2.TextBoxWidth = 110;
            this.cdvLine2.VisibleButton = true;
            this.cdvLine2.VisibleColumnHeader = false;
            this.cdvLine2.VisibleDescription = true;
            // 
            // cdvItem2
            // 
            this.cdvItem2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvItem2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvItem2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvItem2.BtnToolTipText = "";
            this.cdvItem2.ButtonWidth = 20;
            this.cdvItem2.DescText = "";
            this.cdvItem2.DisplaySubItemIndex = 0;
            this.cdvItem2.DisplayText = "";
            this.cdvItem2.Focusing = null;
            this.cdvItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvItem2.Index = 0;
            this.cdvItem2.IsViewBtnImage = false;
            this.cdvItem2.Location = new System.Drawing.Point(679, 20);
            this.cdvItem2.MaxLength = 32767;
            this.cdvItem2.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvItem2.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvItem2.MultiSelect = false;
            this.cdvItem2.Name = "cdvItem2";
            this.cdvItem2.ReadOnly = false;
            this.cdvItem2.SameWidthHeightOfButton = false;
            this.cdvItem2.SearchSubItemIndex = 0;
            this.cdvItem2.SelectedDescIndex = 1;
            this.cdvItem2.SelectedDescToQueryText = "";
            this.cdvItem2.SelectedSubItemIndex = 0;
            this.cdvItem2.SelectedValueToQueryText = "";
            this.cdvItem2.SelectionStart = 0;
            this.cdvItem2.Size = new System.Drawing.Size(286, 20);
            this.cdvItem2.SmallImageList = null;
            this.cdvItem2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvItem2.TabIndex = 63;
            this.cdvItem2.TextBoxToolTipText = "";
            this.cdvItem2.TextBoxWidth = 110;
            this.cdvItem2.VisibleButton = true;
            this.cdvItem2.VisibleColumnHeader = false;
            this.cdvItem2.VisibleDescription = true;
            this.cdvItem2.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvItem2_SelectedItemChanged);
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
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(836, 7);
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
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(930, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 26);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // sheetView1
            // 
            this.sheetView1.Reset();
            sheetView1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            sheetView1.ColumnCount = 0;
            sheetView1.RowCount = 0;
            this.sheetView1.ActiveColumnIndex = -1;
            this.sheetView1.ActiveRowIndex = -1;
            this.sheetView1.RowHeader.Columns.Default.Resizable = false;
            this.sheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // sheetView3
            // 
            this.sheetView3.Reset();
            sheetView3.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetView3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            sheetView3.ColumnCount = 0;
            sheetView3.RowCount = 0;
            this.sheetView3.ActiveColumnIndex = -1;
            this.sheetView3.ActiveRowIndex = -1;
            this.sheetView3.RowHeader.Columns.Default.Resizable = false;
            this.sheetView3.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // sheetView4
            // 
            this.sheetView4.Reset();
            sheetView4.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.sheetView4.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            sheetView4.ColumnCount = 0;
            sheetView4.RowCount = 0;
            this.sheetView4.ActiveColumnIndex = -1;
            this.sheetView4.ActiveRowIndex = -1;
            this.sheetView4.RowHeader.Columns.Default.Resizable = false;
            this.sheetView4.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmCTMSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 546);
            this.MinimumSize = new System.Drawing.Size(1000, 580);
            this.Name = "frmCTMSetup";
            this.Text = "CTM Setup";
            this.Load += new System.EventHandler(this.frmCTMSetup_Load);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpViewProductPlan.ResumeLayout(false);
            this.tabCTM.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCTMView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCTMView_Sheet1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLineID)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCTM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCTM_Sheet1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData1_Sheet1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdXlsData_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData2_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private udcFromToDate udcFromToDate1;
        private System.Windows.Forms.GroupBox grpViewProductPlan;
        private FarPoint.Win.Spread.FpSpread spdData1;
        private FarPoint.Win.Spread.SheetView spdData1_Sheet1;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.Button btnView;
        //private udcFarpoint spdData2;
        private FarPoint.Win.Spread.SheetView spdData2_Sheet1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        //private udcFarpoint spdXlsData;
        private FarPoint.Win.Spread.SheetView spdXlsData_Sheet1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnDelRow;
        public System.Windows.Forms.Button btnAddRow;
        private FarPoint.Win.Spread.FpSpread spdCTMView;
        private FarPoint.Win.Spread.SheetView spdCTMView_Sheet1;
        private System.Windows.Forms.Button btnDel;
        protected System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabControl tabCTM;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FarPoint.Win.Spread.FpSpread spdCTM;
        private FarPoint.Win.Spread.SheetView spdCTM_Sheet1;
        private FarPoint.Win.Spread.SheetView sheetView1;
        private FarPoint.Win.Spread.SheetView sheetView3;
        private FarPoint.Win.Spread.SheetView sheetView4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private Miracom.MESCore.Controls.udcFromToDate dtpWorkDate;
        private System.Windows.Forms.Label label1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLineID;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLine2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvItem2;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Label lblOptWorkDate;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnReset;
    }
}