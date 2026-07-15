namespace Miracom.OUISample
{
    partial class frmOrderLotStartNEnd
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.splMiddle = new System.Windows.Forms.Splitter();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.pnlTotalCount = new System.Windows.Forms.Panel();
            this.lblOrderInQty = new System.Windows.Forms.Label();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.lblOrderCount = new System.Windows.Forms.Label();
            this.tabOrder = new System.Windows.Forms.TabControl();
            this.tbpOrder = new System.Windows.Forms.TabPage();
            this.spdOrder = new FarPoint.Win.Spread.FpSpread();
            this.spdOrder_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpMaterial = new System.Windows.Forms.TabPage();
            this.spdMatOrder = new FarPoint.Win.Spread.FpSpread();
            this.spdMatOrder_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlTransaction = new System.Windows.Forms.Panel();
            this.btnCreateLot = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnSplitLot = new System.Windows.Forms.Button();
            this.btnHoldLot = new System.Windows.Forms.Button();
            this.btnEndLot = new System.Windows.Forms.Button();
            this.btnStartLot = new System.Windows.Forms.Button();
            this.pnlLotList = new System.Windows.Forms.Panel();
            this.grpLotList = new System.Windows.Forms.GroupBox();
            this.spdLotList = new FarPoint.Win.Spread.FpSpread();
            this.spdLotList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splRight = new System.Windows.Forms.Splitter();
            this.pnlInValue = new System.Windows.Forms.Panel();
            this.grpInputValue = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblInValue01 = new System.Windows.Forms.Label();
            this.lblInValue05 = new System.Windows.Forms.Label();
            this.cdvInValue05 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInValue04 = new System.Windows.Forms.Label();
            this.cdvInValue04 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInValue03 = new System.Windows.Forms.Label();
            this.cdvInValue03 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInValue02 = new System.Windows.Forms.Label();
            this.cdvInValue02 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvInValue01 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterial)).BeginInit();
            this.pnlTotalCount.SuspendLayout();
            this.tabOrder.SuspendLayout();
            this.tbpOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder_Sheet1)).BeginInit();
            this.tbpMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatOrder_Sheet1)).BeginInit();
            this.pnlTransaction.SuspendLayout();
            this.pnlLotList.SuspendLayout();
            this.grpLotList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList_Sheet1)).BeginInit();
            this.pnlInValue.SuspendLayout();
            this.grpInputValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue01)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlLotList);
            this.pnlBottom.Controls.Add(this.pnlTransaction);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 312);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(6);
            this.pnlBottom.Size = new System.Drawing.Size(784, 250);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabOrder);
            this.pnlCenter.Controls.Add(this.pnlTotalCount);
            this.pnlCenter.Controls.Add(this.pnlFilter);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(6);
            this.pnlCenter.Size = new System.Drawing.Size(784, 307);
            // 
            // pnlTop
            // 
            this.pnlTop.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTop.Padding = new System.Windows.Forms.Padding(4);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(4, 4);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFormTitle.Size = new System.Drawing.Size(734, 0);
            this.lblFormTitle.Text = "BaseForm03";
            // 
            // splMiddle
            // 
            this.splMiddle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.splMiddle.Location = new System.Drawing.Point(0, 307);
            this.splMiddle.Margin = new System.Windows.Forms.Padding(6);
            this.splMiddle.Name = "splMiddle";
            this.splMiddle.Size = new System.Drawing.Size(784, 5);
            this.splMiddle.TabIndex = 0;
            this.splMiddle.TabStop = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(6);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(784, 56);
            this.pnlFilter.TabIndex = 0;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.cdvMaterial);
            this.grpFilter.Controls.Add(this.lblMaterial);
            this.grpFilter.Controls.Add(this.dtpWorkDate);
            this.grpFilter.Controls.Add(this.btnRefresh);
            this.grpFilter.Controls.Add(this.lblWorkDate);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.ForeColor = System.Drawing.Color.MediumBlue;
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(784, 56);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMaterial.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMaterial.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMaterial.BtnToolTipText = "";
            this.cdvMaterial.ButtonWidth = 31;
            this.cdvMaterial.DescText = "";
            this.cdvMaterial.DisplaySubItemIndex = -1;
            this.cdvMaterial.DisplayText = "";
            this.cdvMaterial.Focusing = null;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.Index = 0;
            this.cdvMaterial.IsViewBtnImage = false;
            this.cdvMaterial.Location = new System.Drawing.Point(430, 16);
            this.cdvMaterial.MaxLength = 30;
            this.cdvMaterial.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMaterial.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.ReadOnly = false;
            this.cdvMaterial.SameWidthHeightOfButton = true;
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = -1;
            this.cdvMaterial.SelectionStart = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(170, 31);
            this.cdvMaterial.SmallImageList = null;
            this.cdvMaterial.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMaterial.TabIndex = 3;
            this.cdvMaterial.TextBoxToolTipText = "";
            this.cdvMaterial.TextBoxWidth = 170;
            this.cdvMaterial.VisibleButton = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            this.cdvMaterial.ButtonPress += new System.EventHandler(this.cdvMaterial_ButtonPress);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaterial.Location = new System.Drawing.Point(331, 20);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(75, 24);
            this.lblMaterial.TabIndex = 2;
            this.lblMaterial.Text = "Material";
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(124, 18);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(153, 29);
            this.dtpWorkDate.TabIndex = 1;
            this.dtpWorkDate.ValueChanged += new System.EventHandler(this.dtpWorkDate_ValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnRefresh.Image = global::Miracom.OUISample.Properties.Resources._7_4_1_Reload;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(678, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWorkDate.Location = new System.Drawing.Point(12, 20);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(106, 24);
            this.lblWorkDate.TabIndex = 0;
            this.lblWorkDate.Text = "Work Date";
            // 
            // pnlTotalCount
            // 
            this.pnlTotalCount.Controls.Add(this.lblOrderInQty);
            this.pnlTotalCount.Controls.Add(this.lblOrderQty);
            this.pnlTotalCount.Controls.Add(this.lblOrderCount);
            this.pnlTotalCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotalCount.Location = new System.Drawing.Point(0, 285);
            this.pnlTotalCount.Name = "pnlTotalCount";
            this.pnlTotalCount.Size = new System.Drawing.Size(784, 22);
            this.pnlTotalCount.TabIndex = 2;
            // 
            // lblOrderInQty
            // 
            this.lblOrderInQty.AutoSize = true;
            this.lblOrderInQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderInQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrderInQty.Location = new System.Drawing.Point(427, 3);
            this.lblOrderInQty.Name = "lblOrderInQty";
            this.lblOrderInQty.Size = new System.Drawing.Size(106, 16);
            this.lblOrderInQty.TabIndex = 2;
            this.lblOrderInQty.Text = "Order In Quantity";
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.AutoSize = true;
            this.lblOrderQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrderQty.Location = new System.Drawing.Point(184, 3);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(93, 16);
            this.lblOrderQty.TabIndex = 1;
            this.lblOrderQty.Text = "Order Quantity";
            // 
            // lblOrderCount
            // 
            this.lblOrderCount.AutoSize = true;
            this.lblOrderCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrderCount.Location = new System.Drawing.Point(12, 3);
            this.lblOrderCount.Name = "lblOrderCount";
            this.lblOrderCount.Size = new System.Drawing.Size(79, 16);
            this.lblOrderCount.TabIndex = 0;
            this.lblOrderCount.Text = "Order Count";
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.tbpOrder);
            this.tabOrder.Controls.Add(this.tbpMaterial);
            this.tabOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOrder.ItemSize = new System.Drawing.Size(100, 24);
            this.tabOrder.Location = new System.Drawing.Point(0, 56);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.SelectedIndex = 0;
            this.tabOrder.Size = new System.Drawing.Size(784, 229);
            this.tabOrder.TabIndex = 1;
            // 
            // tbpOrder
            // 
            this.tbpOrder.Controls.Add(this.spdOrder);
            this.tbpOrder.Location = new System.Drawing.Point(4, 28);
            this.tbpOrder.Name = "tbpOrder";
            this.tbpOrder.Size = new System.Drawing.Size(776, 197);
            this.tbpOrder.TabIndex = 0;
            this.tbpOrder.Text = "Order";
            // 
            // spdOrder
            // 
            this.spdOrder.AccessibleDescription = "spdOrder, Sheet1, Row 0, Column 0, ";
            this.spdOrder.BackColor = System.Drawing.SystemColors.Control;
            this.spdOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOrder.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdOrder.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOrder.HorizontalScrollBar.Name = "";
            this.spdOrder.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdOrder.HorizontalScrollBar.TabIndex = 8;
            this.spdOrder.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOrder.Location = new System.Drawing.Point(0, 0);
            this.spdOrder.Name = "spdOrder";
            this.spdOrder.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOrder.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOrder_Sheet1});
            this.spdOrder.Size = new System.Drawing.Size(776, 197);
            this.spdOrder.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOrder.TabIndex = 0;
            this.spdOrder.TabStop = false;
            this.spdOrder.TextTipDelay = 200;
            this.spdOrder.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOrder.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOrder.VerticalScrollBar.Name = "";
            this.spdOrder.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdOrder.VerticalScrollBar.TabIndex = 9;
            this.spdOrder.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOrder.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdOrder_SelectionChanged);
            this.spdOrder.SetViewportLeftColumn(0, 0, 2);
            this.spdOrder.SetActiveViewport(0, 0, -1);
            // 
            // spdOrder_Sheet1
            // 
            this.spdOrder_Sheet1.Reset();
            spdOrder_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOrder_Sheet1.ColumnCount = 32;
            spdOrder_Sheet1.RowCount = 5;
            this.spdOrder_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdOrder_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOrder_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Work Date";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Order ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Order Desc";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Order Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Res ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Bom Set ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Bom Set Version";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Customer ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Customer Mat ID";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Plan Due Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Plan Start Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Plan End Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Lot Type";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Owner Code";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Create Code";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lot Priority";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Org Due Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Ord Status Flag";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Ord Ship Flag";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Ord Start Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Ord End Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Order In Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Order Out Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Order Loss Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Order Rwk Qty";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Create User";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Create Time";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Update User";
            this.spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Update Time";
            this.spdOrder_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOrder_Sheet1.ColumnHeader.Rows.Get(0).Height = 35F;
            this.spdOrder_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdOrder_Sheet1.Columns.Get(0).Label = "Work Date";
            this.spdOrder_Sheet1.Columns.Get(0).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdOrder_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(0).Width = 120F;
            this.spdOrder_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(1).Label = "Order ID";
            this.spdOrder_Sheet1.Columns.Get(1).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(1).Width = 106F;
            this.spdOrder_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(2).Label = "Order Desc";
            this.spdOrder_Sheet1.Columns.Get(2).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(2).Width = 150F;
            this.spdOrder_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(3).Label = "Mat ID";
            this.spdOrder_Sheet1.Columns.Get(3).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(3).Width = 120F;
            this.spdOrder_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(4).Label = "Flow";
            this.spdOrder_Sheet1.Columns.Get(4).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(4).Width = 101F;
            this.spdOrder_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(5).Label = "Order Qty";
            this.spdOrder_Sheet1.Columns.Get(5).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(5).Width = 120F;
            this.spdOrder_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(6).Label = "Res ID";
            this.spdOrder_Sheet1.Columns.Get(6).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(6).Width = 115F;
            this.spdOrder_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(7).Label = "Bom Set ID";
            this.spdOrder_Sheet1.Columns.Get(7).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(7).Width = 121F;
            this.spdOrder_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(8).Label = "Bom Set Version";
            this.spdOrder_Sheet1.Columns.Get(8).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(8).Width = 118F;
            this.spdOrder_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(9).Label = "Customer ID";
            this.spdOrder_Sheet1.Columns.Get(9).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(9).Width = 105F;
            this.spdOrder_Sheet1.Columns.Get(10).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(10).Label = "Customer Mat ID";
            this.spdOrder_Sheet1.Columns.Get(10).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(10).Width = 127F;
            this.spdOrder_Sheet1.Columns.Get(11).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(11).Label = "Plan Due Time";
            this.spdOrder_Sheet1.Columns.Get(11).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(11).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(12).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(12).Label = "Plan Start Time";
            this.spdOrder_Sheet1.Columns.Get(12).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(12).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(13).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(13).Label = "Plan End Time";
            this.spdOrder_Sheet1.Columns.Get(13).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(13).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(14).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(14).Label = "Qty";
            this.spdOrder_Sheet1.Columns.Get(14).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(14).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(15).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(15).Label = "Lot Type";
            this.spdOrder_Sheet1.Columns.Get(15).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(15).Width = 70F;
            this.spdOrder_Sheet1.Columns.Get(16).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(16).Label = "Owner Code";
            this.spdOrder_Sheet1.Columns.Get(16).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(16).Width = 92F;
            this.spdOrder_Sheet1.Columns.Get(17).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(17).Label = "Create Code";
            this.spdOrder_Sheet1.Columns.Get(17).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(17).Width = 86F;
            this.spdOrder_Sheet1.Columns.Get(18).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(18).Label = "Lot Priority";
            this.spdOrder_Sheet1.Columns.Get(18).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(18).Width = 82F;
            this.spdOrder_Sheet1.Columns.Get(19).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(19).Label = "Org Due Time";
            this.spdOrder_Sheet1.Columns.Get(19).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(19).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(20).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(20).Label = "Ord Status Flag";
            this.spdOrder_Sheet1.Columns.Get(20).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(20).Width = 97F;
            this.spdOrder_Sheet1.Columns.Get(21).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(21).Label = "Ord Ship Flag";
            this.spdOrder_Sheet1.Columns.Get(21).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(21).Width = 98F;
            this.spdOrder_Sheet1.Columns.Get(22).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(22).Label = "Ord Start Time";
            this.spdOrder_Sheet1.Columns.Get(22).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(22).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(23).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(23).Label = "Ord End Time";
            this.spdOrder_Sheet1.Columns.Get(23).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(23).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(24).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(24).Label = "Order In Qty";
            this.spdOrder_Sheet1.Columns.Get(24).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(24).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(25).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(25).Label = "Order Out Qty";
            this.spdOrder_Sheet1.Columns.Get(25).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(25).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(26).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(26).Label = "Order Loss Qty";
            this.spdOrder_Sheet1.Columns.Get(26).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(26).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(27).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOrder_Sheet1.Columns.Get(27).Label = "Order Rwk Qty";
            this.spdOrder_Sheet1.Columns.Get(27).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(27).Width = 100F;
            this.spdOrder_Sheet1.Columns.Get(28).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(28).Label = "Create User";
            this.spdOrder_Sheet1.Columns.Get(28).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(28).Width = 80F;
            this.spdOrder_Sheet1.Columns.Get(29).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(29).Label = "Create Time";
            this.spdOrder_Sheet1.Columns.Get(29).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(29).Width = 125F;
            this.spdOrder_Sheet1.Columns.Get(30).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(30).Label = "Update User";
            this.spdOrder_Sheet1.Columns.Get(30).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(30).Width = 80F;
            this.spdOrder_Sheet1.Columns.Get(31).AllowAutoSort = true;
            this.spdOrder_Sheet1.Columns.Get(31).Label = "Update Time";
            this.spdOrder_Sheet1.Columns.Get(31).Locked = true;
            this.spdOrder_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOrder_Sheet1.Columns.Get(31).Width = 125F;
            this.spdOrder_Sheet1.FrozenColumnCount = 2;
            this.spdOrder_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOrder_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdOrder_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdOrder_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOrder_Sheet1.Rows.Default.Height = 35F;
            this.spdOrder_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdOrder_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdOrder_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrder_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpMaterial
            // 
            this.tbpMaterial.Controls.Add(this.spdMatOrder);
            this.tbpMaterial.Location = new System.Drawing.Point(4, 28);
            this.tbpMaterial.Name = "tbpMaterial";
            this.tbpMaterial.Size = new System.Drawing.Size(734, 197);
            this.tbpMaterial.TabIndex = 1;
            this.tbpMaterial.Text = "Material";
            // 
            // spdMatOrder
            // 
            this.spdMatOrder.AccessibleDescription = "spdMatOrder, Sheet1, Row 0, Column 0, ";
            this.spdMatOrder.BackColor = System.Drawing.SystemColors.Control;
            this.spdMatOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMatOrder.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdMatOrder.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMatOrder.HorizontalScrollBar.Name = "";
            this.spdMatOrder.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdMatOrder.HorizontalScrollBar.TabIndex = 8;
            this.spdMatOrder.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMatOrder.Location = new System.Drawing.Point(0, 0);
            this.spdMatOrder.Name = "spdMatOrder";
            this.spdMatOrder.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMatOrder.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMatOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMatOrder_Sheet1});
            this.spdMatOrder.Size = new System.Drawing.Size(734, 197);
            this.spdMatOrder.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMatOrder.TabIndex = 1;
            this.spdMatOrder.TabStop = false;
            this.spdMatOrder.TextTipDelay = 200;
            this.spdMatOrder.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMatOrder.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMatOrder.VerticalScrollBar.Name = "";
            this.spdMatOrder.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdMatOrder.VerticalScrollBar.TabIndex = 9;
            this.spdMatOrder.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMatOrder.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdMatOrder_SelectionChanged);
            this.spdMatOrder.SetViewportLeftColumn(0, 0, 3);
            this.spdMatOrder.SetActiveViewport(0, 0, -1);
            // 
            // spdMatOrder_Sheet1
            // 
            this.spdMatOrder_Sheet1.Reset();
            spdMatOrder_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMatOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMatOrder_Sheet1.ColumnCount = 32;
            spdMatOrder_Sheet1.RowCount = 5;
            this.spdMatOrder_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdMatOrder_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMatOrder_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Mat ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Work Date";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Order ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Order Desc";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Order Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Res ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Bom Set ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Bom Set Version";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Customer ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Customer Mat ID";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Plan Due Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Plan Start Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Plan End Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Lot Type";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Owner Code";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Create Code";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lot Priority";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Org Due Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Ord Status Flag";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Ord Ship Flag";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Ord Start Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Ord End Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Order In Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Order Out Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Order Loss Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Order Rwk Qty";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Create User";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Create Time";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Update User";
            this.spdMatOrder_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Update Time";
            this.spdMatOrder_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMatOrder_Sheet1.ColumnHeader.Rows.Get(0).Height = 35F;
            this.spdMatOrder_Sheet1.Columns.Get(0).Label = "Mat ID";
            this.spdMatOrder_Sheet1.Columns.Get(0).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMatOrder_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(0).Width = 118F;
            this.spdMatOrder_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdMatOrder_Sheet1.Columns.Get(1).Label = "Work Date";
            this.spdMatOrder_Sheet1.Columns.Get(1).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdMatOrder_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(1).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(2).Label = "Order ID";
            this.spdMatOrder_Sheet1.Columns.Get(2).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(2).Width = 106F;
            this.spdMatOrder_Sheet1.Columns.Get(3).Label = "Order Desc";
            this.spdMatOrder_Sheet1.Columns.Get(3).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(3).Width = 110F;
            this.spdMatOrder_Sheet1.Columns.Get(4).Label = "Flow";
            this.spdMatOrder_Sheet1.Columns.Get(4).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(4).Width = 101F;
            this.spdMatOrder_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(5).Label = "Order Qty";
            this.spdMatOrder_Sheet1.Columns.Get(5).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(5).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(6).Label = "Res ID";
            this.spdMatOrder_Sheet1.Columns.Get(6).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(6).Width = 115F;
            this.spdMatOrder_Sheet1.Columns.Get(7).Label = "Bom Set ID";
            this.spdMatOrder_Sheet1.Columns.Get(7).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(7).Width = 121F;
            this.spdMatOrder_Sheet1.Columns.Get(8).Label = "Bom Set Version";
            this.spdMatOrder_Sheet1.Columns.Get(8).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(8).Width = 118F;
            this.spdMatOrder_Sheet1.Columns.Get(9).Label = "Customer ID";
            this.spdMatOrder_Sheet1.Columns.Get(9).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(9).Width = 105F;
            this.spdMatOrder_Sheet1.Columns.Get(10).Label = "Customer Mat ID";
            this.spdMatOrder_Sheet1.Columns.Get(10).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(10).Width = 127F;
            this.spdMatOrder_Sheet1.Columns.Get(11).Label = "Plan Due Time";
            this.spdMatOrder_Sheet1.Columns.Get(11).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(11).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(12).Label = "Plan Start Time";
            this.spdMatOrder_Sheet1.Columns.Get(12).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(12).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(13).Label = "Plan End Time";
            this.spdMatOrder_Sheet1.Columns.Get(13).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(13).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(14).Label = "Qty";
            this.spdMatOrder_Sheet1.Columns.Get(14).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(14).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(15).Label = "Lot Type";
            this.spdMatOrder_Sheet1.Columns.Get(15).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(15).Width = 70F;
            this.spdMatOrder_Sheet1.Columns.Get(16).Label = "Owner Code";
            this.spdMatOrder_Sheet1.Columns.Get(16).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(16).Width = 92F;
            this.spdMatOrder_Sheet1.Columns.Get(17).Label = "Create Code";
            this.spdMatOrder_Sheet1.Columns.Get(17).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(17).Width = 86F;
            this.spdMatOrder_Sheet1.Columns.Get(18).Label = "Lot Priority";
            this.spdMatOrder_Sheet1.Columns.Get(18).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(18).Width = 82F;
            this.spdMatOrder_Sheet1.Columns.Get(19).Label = "Org Due Time";
            this.spdMatOrder_Sheet1.Columns.Get(19).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(19).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(20).Label = "Ord Status Flag";
            this.spdMatOrder_Sheet1.Columns.Get(20).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(20).Width = 97F;
            this.spdMatOrder_Sheet1.Columns.Get(21).Label = "Ord Ship Flag";
            this.spdMatOrder_Sheet1.Columns.Get(21).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(21).Width = 98F;
            this.spdMatOrder_Sheet1.Columns.Get(22).Label = "Ord Start Time";
            this.spdMatOrder_Sheet1.Columns.Get(22).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(22).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(23).Label = "Ord End Time";
            this.spdMatOrder_Sheet1.Columns.Get(23).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(23).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(24).Label = "Order In Qty";
            this.spdMatOrder_Sheet1.Columns.Get(24).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(24).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(25).Label = "Order Out Qty";
            this.spdMatOrder_Sheet1.Columns.Get(25).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(25).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(26).Label = "Order Loss Qty";
            this.spdMatOrder_Sheet1.Columns.Get(26).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(26).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatOrder_Sheet1.Columns.Get(27).Label = "Order Rwk Qty";
            this.spdMatOrder_Sheet1.Columns.Get(27).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(27).Width = 100F;
            this.spdMatOrder_Sheet1.Columns.Get(28).Label = "Create User";
            this.spdMatOrder_Sheet1.Columns.Get(28).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(28).Width = 80F;
            this.spdMatOrder_Sheet1.Columns.Get(29).Label = "Create Time";
            this.spdMatOrder_Sheet1.Columns.Get(29).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(29).Width = 125F;
            this.spdMatOrder_Sheet1.Columns.Get(30).Label = "Update User";
            this.spdMatOrder_Sheet1.Columns.Get(30).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(30).Width = 80F;
            this.spdMatOrder_Sheet1.Columns.Get(31).Label = "Update Time";
            this.spdMatOrder_Sheet1.Columns.Get(31).Locked = true;
            this.spdMatOrder_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatOrder_Sheet1.Columns.Get(31).Width = 125F;
            this.spdMatOrder_Sheet1.FrozenColumnCount = 3;
            this.spdMatOrder_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMatOrder_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdMatOrder_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMatOrder_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMatOrder_Sheet1.Rows.Default.Height = 35F;
            this.spdMatOrder_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdMatOrder_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdMatOrder_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatOrder_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMatOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlTransaction
            // 
            this.pnlTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTransaction.Controls.Add(this.btnCreateLot);
            this.pnlTransaction.Controls.Add(this.btnProcess);
            this.pnlTransaction.Controls.Add(this.btnSplitLot);
            this.pnlTransaction.Controls.Add(this.btnHoldLot);
            this.pnlTransaction.Controls.Add(this.btnEndLot);
            this.pnlTransaction.Controls.Add(this.btnStartLot);
            this.pnlTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTransaction.Location = new System.Drawing.Point(0, 0);
            this.pnlTransaction.Name = "pnlTransaction";
            this.pnlTransaction.Size = new System.Drawing.Size(784, 50);
            this.pnlTransaction.TabIndex = 0;
            // 
            // btnCreateLot
            // 
            this.btnCreateLot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateLot.Image = global::Miracom.OUISample.Properties.Resources._8_Create_Lot;
            this.btnCreateLot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateLot.Location = new System.Drawing.Point(16, 4);
            this.btnCreateLot.Name = "btnCreateLot";
            this.btnCreateLot.Size = new System.Drawing.Size(105, 40);
            this.btnCreateLot.TabIndex = 0;
            this.btnCreateLot.Text = "Create";
            this.btnCreateLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateLot.UseVisualStyleBackColor = true;
            this.btnCreateLot.Click += new System.EventHandler(this.btnCreateLot_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnProcess.Image = global::Miracom.OUISample.Properties.Resources._2_8_3_ApprovalandReleaseRecipeVersion;
            this.btnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcess.Location = new System.Drawing.Point(657, 4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(120, 40);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Process";
            this.btnProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnSplitLot
            // 
            this.btnSplitLot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSplitLot.Image = global::Miracom.OUISample.Properties.Resources._15_Split_Lot;
            this.btnSplitLot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSplitLot.Location = new System.Drawing.Point(418, 4);
            this.btnSplitLot.Name = "btnSplitLot";
            this.btnSplitLot.Size = new System.Drawing.Size(91, 40);
            this.btnSplitLot.TabIndex = 4;
            this.btnSplitLot.Text = "Split";
            this.btnSplitLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSplitLot.UseVisualStyleBackColor = true;
            this.btnSplitLot.Click += new System.EventHandler(this.btnSplitLot_Click);
            // 
            // btnHoldLot
            // 
            this.btnHoldLot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHoldLot.Image = global::Miracom.OUISample.Properties.Resources._19_Hold_Lot;
            this.btnHoldLot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoldLot.Location = new System.Drawing.Point(321, 4);
            this.btnHoldLot.Name = "btnHoldLot";
            this.btnHoldLot.Size = new System.Drawing.Size(91, 40);
            this.btnHoldLot.TabIndex = 3;
            this.btnHoldLot.Text = "Hold";
            this.btnHoldLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHoldLot.UseVisualStyleBackColor = true;
            this.btnHoldLot.Click += new System.EventHandler(this.btnHoldLot_Click);
            // 
            // btnEndLot
            // 
            this.btnEndLot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEndLot.Image = global::Miracom.OUISample.Properties.Resources._11_End_Lot;
            this.btnEndLot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEndLot.Location = new System.Drawing.Point(224, 4);
            this.btnEndLot.Name = "btnEndLot";
            this.btnEndLot.Size = new System.Drawing.Size(91, 40);
            this.btnEndLot.TabIndex = 2;
            this.btnEndLot.Text = "End";
            this.btnEndLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEndLot.UseVisualStyleBackColor = true;
            this.btnEndLot.Click += new System.EventHandler(this.btnEndLot_Click);
            // 
            // btnStartLot
            // 
            this.btnStartLot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartLot.Image = global::Miracom.OUISample.Properties.Resources._9_Start_Lot;
            this.btnStartLot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartLot.Location = new System.Drawing.Point(127, 4);
            this.btnStartLot.Name = "btnStartLot";
            this.btnStartLot.Size = new System.Drawing.Size(91, 40);
            this.btnStartLot.TabIndex = 1;
            this.btnStartLot.Text = "Start";
            this.btnStartLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartLot.UseVisualStyleBackColor = true;
            this.btnStartLot.Click += new System.EventHandler(this.btnStartLot_Click);
            // 
            // pnlLotList
            // 
            this.pnlLotList.Controls.Add(this.grpLotList);
            this.pnlLotList.Controls.Add(this.splRight);
            this.pnlLotList.Controls.Add(this.pnlInValue);
            this.pnlLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotList.Location = new System.Drawing.Point(0, 50);
            this.pnlLotList.Name = "pnlLotList";
            this.pnlLotList.Size = new System.Drawing.Size(784, 200);
            this.pnlLotList.TabIndex = 2;
            // 
            // grpLotList
            // 
            this.grpLotList.Controls.Add(this.spdLotList);
            this.grpLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLotList.ForeColor = System.Drawing.Color.MediumBlue;
            this.grpLotList.Location = new System.Drawing.Point(0, 0);
            this.grpLotList.Name = "grpLotList";
            this.grpLotList.Size = new System.Drawing.Size(529, 200);
            this.grpLotList.TabIndex = 0;
            this.grpLotList.TabStop = false;
            this.grpLotList.Text = "Order Lot List";
            // 
            // spdLotList
            // 
            this.spdLotList.AccessibleDescription = "spdLotList, Sheet1, Row 0, Column 0, ";
            this.spdLotList.BackColor = System.Drawing.SystemColors.Control;
            this.spdLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdLotList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotList.HorizontalScrollBar.Name = "";
            this.spdLotList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotList.HorizontalScrollBar.TabIndex = 16;
            this.spdLotList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLotList.Location = new System.Drawing.Point(3, 18);
            this.spdLotList.Name = "spdLotList";
            this.spdLotList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdLotList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdLotList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotList_Sheet1});
            this.spdLotList.Size = new System.Drawing.Size(523, 179);
            this.spdLotList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLotList.TabIndex = 0;
            this.spdLotList.TabStop = false;
            this.spdLotList.TextTipDelay = 200;
            this.spdLotList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLotList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotList.VerticalScrollBar.Name = "";
            this.spdLotList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotList.VerticalScrollBar.TabIndex = 17;
            this.spdLotList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLotList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdLotList_SelectionChanged);
            this.spdLotList.SetViewportLeftColumn(0, 0, 1);
            this.spdLotList.SetActiveViewport(0, 0, -1);
            // 
            // spdLotList_Sheet1
            // 
            this.spdLotList_Sheet1.Reset();
            spdLotList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotList_Sheet1.ColumnCount = 14;
            spdLotList_Sheet1.RowCount = 5;
            this.spdLotList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "_";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Lot Desc";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat ID";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Oper";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "QTY";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Start Res ID";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Start Time";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Lot Type";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Owner Code";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Create Code";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Lot Priority";
            this.spdLotList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Due Time";
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotList_Sheet1.ColumnHeader.Rows.Get(0).Height = 35F;
            this.spdLotList_Sheet1.Columns.Get(0).Label = "_";
            this.spdLotList_Sheet1.Columns.Get(0).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(0).Width = 25F;
            this.spdLotList_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(1).Label = "Lot ID";
            this.spdLotList_Sheet1.Columns.Get(1).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(1).Width = 106F;
            this.spdLotList_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(2).Label = "Lot Desc";
            this.spdLotList_Sheet1.Columns.Get(2).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(2).Width = 150F;
            this.spdLotList_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(3).Label = "Mat ID";
            this.spdLotList_Sheet1.Columns.Get(3).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(3).Width = 120F;
            this.spdLotList_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(4).Label = "Flow";
            this.spdLotList_Sheet1.Columns.Get(4).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(4).Width = 99F;
            this.spdLotList_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(5).Label = "Oper";
            this.spdLotList_Sheet1.Columns.Get(5).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(5).Width = 80F;
            this.spdLotList_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotList_Sheet1.Columns.Get(6).Label = "QTY";
            this.spdLotList_Sheet1.Columns.Get(6).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(6).Width = 80F;
            this.spdLotList_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(7).Label = "Start Res ID";
            this.spdLotList_Sheet1.Columns.Get(7).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(7).Width = 130F;
            this.spdLotList_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(8).Label = "Start Time";
            this.spdLotList_Sheet1.Columns.Get(8).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(8).Width = 120F;
            this.spdLotList_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(9).Label = "Lot Type";
            this.spdLotList_Sheet1.Columns.Get(9).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(9).Width = 106F;
            this.spdLotList_Sheet1.Columns.Get(10).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(10).Label = "Owner Code";
            this.spdLotList_Sheet1.Columns.Get(10).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(10).Width = 148F;
            this.spdLotList_Sheet1.Columns.Get(11).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(11).Label = "Create Code";
            this.spdLotList_Sheet1.Columns.Get(11).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(11).Width = 157F;
            this.spdLotList_Sheet1.Columns.Get(12).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(12).Label = "Lot Priority";
            this.spdLotList_Sheet1.Columns.Get(12).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(12).Width = 142F;
            this.spdLotList_Sheet1.Columns.Get(13).AllowAutoSort = true;
            this.spdLotList_Sheet1.Columns.Get(13).Label = "Due Time";
            this.spdLotList_Sheet1.Columns.Get(13).Locked = true;
            this.spdLotList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.Columns.Get(13).Width = 150F;
            this.spdLotList_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdLotList_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotList_Sheet1.FrozenColumnCount = 1;
            this.spdLotList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLotList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdLotList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLotList_Sheet1.Rows.Default.Height = 35F;
            this.spdLotList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdLotList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdLotList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splRight
            // 
            this.splRight.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splRight.Location = new System.Drawing.Point(529, 0);
            this.splRight.Name = "splRight";
            this.splRight.Size = new System.Drawing.Size(5, 200);
            this.splRight.TabIndex = 1;
            this.splRight.TabStop = false;
            // 
            // pnlInValue
            // 
            this.pnlInValue.Controls.Add(this.grpInputValue);
            this.pnlInValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInValue.Location = new System.Drawing.Point(534, 0);
            this.pnlInValue.Name = "pnlInValue";
            this.pnlInValue.Size = new System.Drawing.Size(250, 200);
            this.pnlInValue.TabIndex = 0;
            // 
            // grpInputValue
            // 
            this.grpInputValue.Controls.Add(this.btnGenerate);
            this.grpInputValue.Controls.Add(this.lblInValue01);
            this.grpInputValue.Controls.Add(this.lblInValue05);
            this.grpInputValue.Controls.Add(this.cdvInValue05);
            this.grpInputValue.Controls.Add(this.lblInValue04);
            this.grpInputValue.Controls.Add(this.cdvInValue04);
            this.grpInputValue.Controls.Add(this.lblInValue03);
            this.grpInputValue.Controls.Add(this.cdvInValue03);
            this.grpInputValue.Controls.Add(this.lblInValue02);
            this.grpInputValue.Controls.Add(this.cdvInValue02);
            this.grpInputValue.Controls.Add(this.cdvInValue01);
            this.grpInputValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInputValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInputValue.ForeColor = System.Drawing.Color.MediumBlue;
            this.grpInputValue.Location = new System.Drawing.Point(0, 0);
            this.grpInputValue.Name = "grpInputValue";
            this.grpInputValue.Size = new System.Drawing.Size(250, 200);
            this.grpInputValue.TabIndex = 0;
            this.grpInputValue.TabStop = false;
            this.grpInputValue.Text = "Input Value";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Location = new System.Drawing.Point(179, 18);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(65, 32);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Gen ID";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblInValue01
            // 
            this.lblInValue01.AutoSize = true;
            this.lblInValue01.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue01.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue01.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue01.Location = new System.Drawing.Point(10, 21);
            this.lblInValue01.Name = "lblInValue01";
            this.lblInValue01.Size = new System.Drawing.Size(130, 24);
            this.lblInValue01.TabIndex = 0;
            this.lblInValue01.Text = "Input Value 01";
            this.lblInValue01.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // lblInValue05
            // 
            this.lblInValue05.AutoSize = true;
            this.lblInValue05.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue05.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue05.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue05.Location = new System.Drawing.Point(10, 165);
            this.lblInValue05.Name = "lblInValue05";
            this.lblInValue05.Size = new System.Drawing.Size(130, 24);
            this.lblInValue05.TabIndex = 9;
            this.lblInValue05.Text = "Input Value 05";
            this.lblInValue05.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // cdvInValue05
            // 
            this.cdvInValue05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue05.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue05.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue05.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue05.BtnToolTipText = "";
            this.cdvInValue05.ButtonWidth = 31;
            this.cdvInValue05.DescText = "";
            this.cdvInValue05.DisplaySubItemIndex = -1;
            this.cdvInValue05.DisplayText = "";
            this.cdvInValue05.Focusing = null;
            this.cdvInValue05.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue05.Index = 0;
            this.cdvInValue05.IsViewBtnImage = false;
            this.cdvInValue05.Location = new System.Drawing.Point(6, 162);
            this.cdvInValue05.MaxLength = 32767;
            this.cdvInValue05.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue05.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue05.Name = "cdvInValue05";
            this.cdvInValue05.ReadOnly = false;
            this.cdvInValue05.SameWidthHeightOfButton = true;
            this.cdvInValue05.SearchSubItemIndex = 0;
            this.cdvInValue05.SelectedDescIndex = -1;
            this.cdvInValue05.SelectedSubItemIndex = -1;
            this.cdvInValue05.SelectionStart = 0;
            this.cdvInValue05.Size = new System.Drawing.Size(238, 31);
            this.cdvInValue05.SmallImageList = null;
            this.cdvInValue05.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue05.TabIndex = 10;
            this.cdvInValue05.TextBoxToolTipText = "";
            this.cdvInValue05.TextBoxWidth = 238;
            this.cdvInValue05.VisibleButton = true;
            this.cdvInValue05.VisibleColumnHeader = false;
            this.cdvInValue05.VisibleDescription = false;
            this.cdvInValue05.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue05.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue05.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // lblInValue04
            // 
            this.lblInValue04.AutoSize = true;
            this.lblInValue04.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue04.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue04.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue04.Location = new System.Drawing.Point(10, 129);
            this.lblInValue04.Name = "lblInValue04";
            this.lblInValue04.Size = new System.Drawing.Size(130, 24);
            this.lblInValue04.TabIndex = 7;
            this.lblInValue04.Text = "Input Value 04";
            this.lblInValue04.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // cdvInValue04
            // 
            this.cdvInValue04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue04.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue04.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue04.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue04.BtnToolTipText = "";
            this.cdvInValue04.ButtonWidth = 31;
            this.cdvInValue04.DescText = "";
            this.cdvInValue04.DisplaySubItemIndex = -1;
            this.cdvInValue04.DisplayText = "";
            this.cdvInValue04.Focusing = null;
            this.cdvInValue04.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue04.Index = 0;
            this.cdvInValue04.IsViewBtnImage = false;
            this.cdvInValue04.Location = new System.Drawing.Point(6, 126);
            this.cdvInValue04.MaxLength = 32767;
            this.cdvInValue04.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue04.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue04.Name = "cdvInValue04";
            this.cdvInValue04.ReadOnly = false;
            this.cdvInValue04.SameWidthHeightOfButton = true;
            this.cdvInValue04.SearchSubItemIndex = 0;
            this.cdvInValue04.SelectedDescIndex = -1;
            this.cdvInValue04.SelectedSubItemIndex = -1;
            this.cdvInValue04.SelectionStart = 0;
            this.cdvInValue04.Size = new System.Drawing.Size(238, 31);
            this.cdvInValue04.SmallImageList = null;
            this.cdvInValue04.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue04.TabIndex = 8;
            this.cdvInValue04.TextBoxToolTipText = "";
            this.cdvInValue04.TextBoxWidth = 238;
            this.cdvInValue04.VisibleButton = true;
            this.cdvInValue04.VisibleColumnHeader = false;
            this.cdvInValue04.VisibleDescription = false;
            this.cdvInValue04.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue04.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue04.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // lblInValue03
            // 
            this.lblInValue03.AutoSize = true;
            this.lblInValue03.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue03.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue03.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue03.Location = new System.Drawing.Point(10, 93);
            this.lblInValue03.Name = "lblInValue03";
            this.lblInValue03.Size = new System.Drawing.Size(130, 24);
            this.lblInValue03.TabIndex = 5;
            this.lblInValue03.Text = "Input Value 03";
            this.lblInValue03.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // cdvInValue03
            // 
            this.cdvInValue03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue03.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue03.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue03.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue03.BtnToolTipText = "";
            this.cdvInValue03.ButtonWidth = 31;
            this.cdvInValue03.DescText = "";
            this.cdvInValue03.DisplaySubItemIndex = -1;
            this.cdvInValue03.DisplayText = "";
            this.cdvInValue03.Focusing = null;
            this.cdvInValue03.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue03.Index = 0;
            this.cdvInValue03.IsViewBtnImage = false;
            this.cdvInValue03.Location = new System.Drawing.Point(6, 90);
            this.cdvInValue03.MaxLength = 32767;
            this.cdvInValue03.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue03.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue03.Name = "cdvInValue03";
            this.cdvInValue03.ReadOnly = false;
            this.cdvInValue03.SameWidthHeightOfButton = true;
            this.cdvInValue03.SearchSubItemIndex = 0;
            this.cdvInValue03.SelectedDescIndex = -1;
            this.cdvInValue03.SelectedSubItemIndex = -1;
            this.cdvInValue03.SelectionStart = 0;
            this.cdvInValue03.Size = new System.Drawing.Size(238, 31);
            this.cdvInValue03.SmallImageList = null;
            this.cdvInValue03.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue03.TabIndex = 6;
            this.cdvInValue03.TextBoxToolTipText = "";
            this.cdvInValue03.TextBoxWidth = 238;
            this.cdvInValue03.VisibleButton = true;
            this.cdvInValue03.VisibleColumnHeader = false;
            this.cdvInValue03.VisibleDescription = false;
            this.cdvInValue03.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue03.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue03.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // lblInValue02
            // 
            this.lblInValue02.AutoSize = true;
            this.lblInValue02.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue02.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue02.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue02.Location = new System.Drawing.Point(10, 57);
            this.lblInValue02.Name = "lblInValue02";
            this.lblInValue02.Size = new System.Drawing.Size(130, 24);
            this.lblInValue02.TabIndex = 3;
            this.lblInValue02.Text = "Input Value 02";
            this.lblInValue02.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // cdvInValue02
            // 
            this.cdvInValue02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue02.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue02.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue02.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue02.BtnToolTipText = "";
            this.cdvInValue02.ButtonWidth = 31;
            this.cdvInValue02.DescText = "";
            this.cdvInValue02.DisplaySubItemIndex = -1;
            this.cdvInValue02.DisplayText = "";
            this.cdvInValue02.Focusing = null;
            this.cdvInValue02.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue02.Index = 0;
            this.cdvInValue02.IsViewBtnImage = false;
            this.cdvInValue02.Location = new System.Drawing.Point(6, 54);
            this.cdvInValue02.MaxLength = 32767;
            this.cdvInValue02.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue02.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue02.Name = "cdvInValue02";
            this.cdvInValue02.ReadOnly = false;
            this.cdvInValue02.SameWidthHeightOfButton = true;
            this.cdvInValue02.SearchSubItemIndex = 0;
            this.cdvInValue02.SelectedDescIndex = -1;
            this.cdvInValue02.SelectedSubItemIndex = -1;
            this.cdvInValue02.SelectionStart = 0;
            this.cdvInValue02.Size = new System.Drawing.Size(238, 31);
            this.cdvInValue02.SmallImageList = null;
            this.cdvInValue02.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue02.TabIndex = 4;
            this.cdvInValue02.TextBoxToolTipText = "";
            this.cdvInValue02.TextBoxWidth = 238;
            this.cdvInValue02.VisibleButton = true;
            this.cdvInValue02.VisibleColumnHeader = false;
            this.cdvInValue02.VisibleDescription = false;
            this.cdvInValue02.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue02.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue02.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // cdvInValue01
            // 
            this.cdvInValue01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue01.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue01.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue01.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue01.BtnToolTipText = "";
            this.cdvInValue01.ButtonWidth = 31;
            this.cdvInValue01.DescText = "";
            this.cdvInValue01.DisplaySubItemIndex = -1;
            this.cdvInValue01.DisplayText = "";
            this.cdvInValue01.Focusing = null;
            this.cdvInValue01.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue01.Index = 0;
            this.cdvInValue01.IsViewBtnImage = false;
            this.cdvInValue01.Location = new System.Drawing.Point(6, 18);
            this.cdvInValue01.MaxLength = 32767;
            this.cdvInValue01.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue01.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue01.Name = "cdvInValue01";
            this.cdvInValue01.ReadOnly = false;
            this.cdvInValue01.SameWidthHeightOfButton = true;
            this.cdvInValue01.SearchSubItemIndex = 0;
            this.cdvInValue01.SelectedDescIndex = -1;
            this.cdvInValue01.SelectedSubItemIndex = -1;
            this.cdvInValue01.SelectionStart = 0;
            this.cdvInValue01.Size = new System.Drawing.Size(170, 31);
            this.cdvInValue01.SmallImageList = null;
            this.cdvInValue01.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue01.TabIndex = 1;
            this.cdvInValue01.TextBoxToolTipText = "";
            this.cdvInValue01.TextBoxWidth = 170;
            this.cdvInValue01.VisibleButton = true;
            this.cdvInValue01.VisibleColumnHeader = false;
            this.cdvInValue01.VisibleDescription = false;
            this.cdvInValue01.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue01.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue01.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // frmOrderLotStartNEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splMiddle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmOrderLotStartNEnd";
            this.Text = "Order based Start and End Lot";
            this.Load += new System.EventHandler(this.frmOrderLotStartNEnd_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.splMiddle, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterial)).EndInit();
            this.pnlTotalCount.ResumeLayout(false);
            this.pnlTotalCount.PerformLayout();
            this.tabOrder.ResumeLayout(false);
            this.tbpOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder_Sheet1)).EndInit();
            this.tbpMaterial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdMatOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatOrder_Sheet1)).EndInit();
            this.pnlTransaction.ResumeLayout(false);
            this.pnlLotList.ResumeLayout(false);
            this.grpLotList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotList_Sheet1)).EndInit();
            this.pnlInValue.ResumeLayout(false);
            this.grpInputValue.ResumeLayout(false);
            this.grpInputValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splMiddle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.Panel pnlTotalCount;
        private System.Windows.Forms.Label lblOrderQty;
        private System.Windows.Forms.Label lblOrderCount;
        private System.Windows.Forms.TabControl tabOrder;
        private System.Windows.Forms.TabPage tbpOrder;
        private FarPoint.Win.Spread.FpSpread spdOrder;
        private FarPoint.Win.Spread.SheetView spdOrder_Sheet1;
        private System.Windows.Forms.TabPage tbpMaterial;
        private FarPoint.Win.Spread.FpSpread spdMatOrder;
        private FarPoint.Win.Spread.SheetView spdMatOrder_Sheet1;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private UI.Controls.MCCodeView.MCCodeView cdvMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblOrderInQty;
        private System.Windows.Forms.Panel pnlTransaction;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnSplitLot;
        private System.Windows.Forms.Button btnHoldLot;
        private System.Windows.Forms.Button btnEndLot;
        private System.Windows.Forms.Button btnStartLot;
        private System.Windows.Forms.Panel pnlLotList;
        private System.Windows.Forms.GroupBox grpLotList;
        private FarPoint.Win.Spread.FpSpread spdLotList;
        private FarPoint.Win.Spread.SheetView spdLotList_Sheet1;
        private System.Windows.Forms.Splitter splRight;
        private System.Windows.Forms.Panel pnlInValue;
        private System.Windows.Forms.GroupBox grpInputValue;
        private System.Windows.Forms.Label lblInValue01;
        private System.Windows.Forms.Label lblInValue05;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue05;
        private System.Windows.Forms.Label lblInValue04;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue04;
        private System.Windows.Forms.Label lblInValue03;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue03;
        private System.Windows.Forms.Label lblInValue02;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue02;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue01;
        private System.Windows.Forms.Button btnCreateLot;
        private System.Windows.Forms.Button btnGenerate;
    }
}