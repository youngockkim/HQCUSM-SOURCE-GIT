namespace Miracom.BASCore
{
    partial class frmBASViewGeneralCodeDataHistory
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
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            this.cdvTableName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKey1 = new System.Windows.Forms.TextBox();
            this.txtKey2 = new System.Windows.Forms.TextBox();
            this.txtKey3 = new System.Windows.Forms.TextBox();
            this.txtKey4 = new System.Windows.Forms.TextBox();
            this.txtKey5 = new System.Windows.Forms.TextBox();
            this.txtKey6 = new System.Windows.Forms.TextBox();
            this.txtKey7 = new System.Windows.Forms.TextBox();
            this.txtKey8 = new System.Windows.Forms.TextBox();
            this.txtKey9 = new System.Windows.Forms.TextBox();
            this.txtKey10 = new System.Windows.Forms.TextBox();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableName)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
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
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 163);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtTableName);
            this.grpOption.Controls.Add(this.txtKey10);
            this.grpOption.Controls.Add(this.txtKey9);
            this.grpOption.Controls.Add(this.txtKey8);
            this.grpOption.Controls.Add(this.txtKey7);
            this.grpOption.Controls.Add(this.txtKey6);
            this.grpOption.Controls.Add(this.txtKey5);
            this.grpOption.Controls.Add(this.txtKey4);
            this.grpOption.Controls.Add(this.txtKey3);
            this.grpOption.Controls.Add(this.txtKey2);
            this.grpOption.Controls.Add(this.txtKey1);
            this.grpOption.Controls.Add(this.label10);
            this.grpOption.Controls.Add(this.label9);
            this.grpOption.Controls.Add(this.label8);
            this.grpOption.Controls.Add(this.label7);
            this.grpOption.Controls.Add(this.label6);
            this.grpOption.Controls.Add(this.label5);
            this.grpOption.Controls.Add(this.label4);
            this.grpOption.Controls.Add(this.label3);
            this.grpOption.Controls.Add(this.label2);
            this.grpOption.Controls.Add(this.label1);
            this.grpOption.Controls.Add(this.cdvTableName);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.lblTableName);
            this.grpOption.Size = new System.Drawing.Size(742, 163);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdHistory);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 163);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 343);
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
            this.lblFormTitle.Text = "View General Code Data History";
            // 
            // cdvTableName
            // 
            this.cdvTableName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTableName.BtnToolTipText = "";
            this.cdvTableName.ButtonWidth = 20;
            this.cdvTableName.DescText = "";
            this.cdvTableName.DisplaySubItemIndex = 0;
            this.cdvTableName.DisplayText = "";
            this.cdvTableName.Focusing = null;
            this.cdvTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableName.Index = 0;
            this.cdvTableName.IsViewBtnImage = false;
            this.cdvTableName.Location = new System.Drawing.Point(94, 13);
            this.cdvTableName.MaxLength = 20;
            this.cdvTableName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTableName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTableName.MultiSelect = false;
            this.cdvTableName.Name = "cdvTableName";
            this.cdvTableName.ReadOnly = false;
            this.cdvTableName.SameWidthHeightOfButton = false;
            this.cdvTableName.SearchSubItemIndex = 0;
            this.cdvTableName.SelectedDescIndex = -1;
            this.cdvTableName.SelectedDescToQueryText = "";
            this.cdvTableName.SelectedSubItemIndex = 0;
            this.cdvTableName.SelectedValueToQueryText = "";
            this.cdvTableName.SelectionStart = 0;
            this.cdvTableName.Size = new System.Drawing.Size(200, 20);
            this.cdvTableName.SmallImageList = null;
            this.cdvTableName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTableName.TabIndex = 8;
            this.cdvTableName.TextBoxToolTipText = "";
            this.cdvTableName.TextBoxWidth = 200;
            this.cdvTableName.Visible = false;
            this.cdvTableName.VisibleButton = true;
            this.cdvTableName.VisibleColumnHeader = false;
            this.cdvTableName.VisibleDescription = false;
            this.cdvTableName.ButtonPress += new System.EventHandler(this.cdvTableName_ButtonPress);
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(344, 13);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 9;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(167, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.Location = new System.Drawing.Point(12, 16);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(75, 13);
            this.lblTableName.TabIndex = 7;
            this.lblTableName.Text = "Table Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Key 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Key 3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Key 5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Key 7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Key 9";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Key 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(342, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Key 4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(342, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Key 6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(342, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Key 8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(342, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Key 10";
            // 
            // txtKey1
            // 
            this.txtKey1.Location = new System.Drawing.Point(94, 37);
            this.txtKey1.MaxLength = 100;
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.Size = new System.Drawing.Size(200, 20);
            this.txtKey1.TabIndex = 20;
            // 
            // txtKey2
            // 
            this.txtKey2.Location = new System.Drawing.Point(400, 37);
            this.txtKey2.MaxLength = 100;
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.Size = new System.Drawing.Size(201, 20);
            this.txtKey2.TabIndex = 21;
            // 
            // txtKey3
            // 
            this.txtKey3.Location = new System.Drawing.Point(94, 61);
            this.txtKey3.MaxLength = 100;
            this.txtKey3.Name = "txtKey3";
            this.txtKey3.Size = new System.Drawing.Size(200, 20);
            this.txtKey3.TabIndex = 22;
            // 
            // txtKey4
            // 
            this.txtKey4.Location = new System.Drawing.Point(400, 61);
            this.txtKey4.MaxLength = 100;
            this.txtKey4.Name = "txtKey4";
            this.txtKey4.Size = new System.Drawing.Size(201, 20);
            this.txtKey4.TabIndex = 23;
            // 
            // txtKey5
            // 
            this.txtKey5.Location = new System.Drawing.Point(94, 85);
            this.txtKey5.MaxLength = 100;
            this.txtKey5.Name = "txtKey5";
            this.txtKey5.Size = new System.Drawing.Size(200, 20);
            this.txtKey5.TabIndex = 24;
            // 
            // txtKey6
            // 
            this.txtKey6.Location = new System.Drawing.Point(400, 85);
            this.txtKey6.MaxLength = 100;
            this.txtKey6.Name = "txtKey6";
            this.txtKey6.Size = new System.Drawing.Size(201, 20);
            this.txtKey6.TabIndex = 25;
            // 
            // txtKey7
            // 
            this.txtKey7.Location = new System.Drawing.Point(94, 109);
            this.txtKey7.MaxLength = 100;
            this.txtKey7.Name = "txtKey7";
            this.txtKey7.Size = new System.Drawing.Size(200, 20);
            this.txtKey7.TabIndex = 26;
            // 
            // txtKey8
            // 
            this.txtKey8.Location = new System.Drawing.Point(400, 109);
            this.txtKey8.MaxLength = 100;
            this.txtKey8.Name = "txtKey8";
            this.txtKey8.Size = new System.Drawing.Size(201, 20);
            this.txtKey8.TabIndex = 27;
            // 
            // txtKey9
            // 
            this.txtKey9.Location = new System.Drawing.Point(94, 133);
            this.txtKey9.MaxLength = 100;
            this.txtKey9.Name = "txtKey9";
            this.txtKey9.Size = new System.Drawing.Size(200, 20);
            this.txtKey9.TabIndex = 28;
            // 
            // txtKey10
            // 
            this.txtKey10.Location = new System.Drawing.Point(400, 133);
            this.txtKey10.MaxLength = 100;
            this.txtKey10.Name = "txtKey10";
            this.txtKey10.Size = new System.Drawing.Size(201, 20);
            this.txtKey10.TabIndex = 29;
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdHistory.HorizontalScrollBar.TabIndex = 28;
            this.spdHistory.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = generalCellType1;
            this.spdHistory.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(742, 343);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 2;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistory.VerticalScrollBar.TabIndex = 29;
            this.spdHistory.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistory.SetViewportLeftColumn(0, 0, 2);
            this.spdHistory.SetActiveViewport(0, 0, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 38;
            spdHistory_Sheet1.RowCount = 5;
            spdHistory_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Key1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Key2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Key3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Key4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Key5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Key6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Key7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Key8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Key9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Key10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Data1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Data2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Data3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Data4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Data5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Data6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Data7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Data8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Data9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Data10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Old Data1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Old Data2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Old Data3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Old Data4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Old Data5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Old Data6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Old Data7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Old Data8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Old Data9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Old Data10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Create User";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Create Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Update User";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Update Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Tran User";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 50F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 150F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Key1";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Key2";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Key3";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Key4";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Key5";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Key6";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Key7";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Key8";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Key9";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Key10";
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Data1";
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Data2";
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Data3";
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Data4";
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Data5";
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Data6";
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Data7";
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Data8";
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Data9";
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Data10";
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Old Data1";
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Old Data2";
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Old Data3";
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Old Data4";
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Old Data5";
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Old Data6";
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Old Data7";
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Old Data8";
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Old Data9";
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Old Data10";
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(32).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Create User";
            this.spdHistory_Sheet1.Columns.Get(33).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Create Time";
            this.spdHistory_Sheet1.Columns.Get(34).Width = 150F;
            this.spdHistory_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Update User";
            this.spdHistory_Sheet1.Columns.Get(35).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Update Time";
            this.spdHistory_Sheet1.Columns.Get(36).Width = 150F;
            this.spdHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "Tran User";
            this.spdHistory_Sheet1.Columns.Get(37).Width = 100F;
            this.spdHistory_Sheet1.FrozenColumnCount = 2;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(1).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(2).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(3).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(4).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(94, 13);
            this.txtTableName.MaxLength = 20;
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(200, 20);
            this.txtTableName.TabIndex = 30;
            // 
            // frmBASViewGeneralCodeDataHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASViewGeneralCodeDataHistory";
            this.Text = "View General Code Data History";
            this.Activated += new System.EventHandler(this.frmBASViewGeneralCodeDataHistory_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableName)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.MCCodeView.MCCodeView cdvTableName;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txtKey10;
        private System.Windows.Forms.TextBox txtKey9;
        private System.Windows.Forms.TextBox txtKey8;
        private System.Windows.Forms.TextBox txtKey7;
        private System.Windows.Forms.TextBox txtKey6;
        private System.Windows.Forms.TextBox txtKey5;
        private System.Windows.Forms.TextBox txtKey4;
        private System.Windows.Forms.TextBox txtKey3;
        private System.Windows.Forms.TextBox txtKey2;
        private System.Windows.Forms.TextBox txtKey1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private System.Windows.Forms.TextBox txtTableName;
    }
}