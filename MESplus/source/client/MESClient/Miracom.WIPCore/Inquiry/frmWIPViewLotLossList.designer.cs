namespace Miracom.WIPCore
{
    partial class frmWIPViewLotLossList
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
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvLossCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkInculdeDelHist = new System.Windows.Forms.CheckBox();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cboQty = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLossCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 89);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.AutoSize = true;
            this.grpOption.Controls.Add(this.lblQty);
            this.grpOption.Controls.Add(this.cboQty);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.chkInculdeDelHist);
            this.grpOption.Controls.Add(this.label5);
            this.grpOption.Controls.Add(this.label4);
            this.grpOption.Controls.Add(this.label3);
            this.grpOption.Controls.Add(this.label2);
            this.grpOption.Controls.Add(this.label1);
            this.grpOption.Controls.Add(this.cdvLossCode);
            this.grpOption.Controls.Add(this.cdvOperation);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.cdvFlow);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Size = new System.Drawing.Size(742, 89);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.AutoSize = true;
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 89);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 424);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(70, 13);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(131, 20);
            this.txtLotID.TabIndex = 1;
            // 
            // cdvFlow
            // 
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = -1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(70, 38);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(131, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 3;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 131;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
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
            this.cdvMaterial.Location = new System.Drawing.Point(228, 13);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(220, 20);
            this.cdvMaterial.TabIndex = 6;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 70;
            this.cdvMaterial.WidthMaterialAndVersion = 150;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(70, 63);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(131, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 5;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 131;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(298, 38);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(150, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 8;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 150;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // cdvLossCode
            // 
            this.cdvLossCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLossCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLossCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLossCode.BtnToolTipText = "";
            this.cdvLossCode.DescText = "";
            this.cdvLossCode.DisplaySubItemIndex = -1;
            this.cdvLossCode.DisplayText = "";
            this.cdvLossCode.Focusing = null;
            this.cdvLossCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLossCode.Index = 0;
            this.cdvLossCode.IsViewBtnImage = false;
            this.cdvLossCode.Location = new System.Drawing.Point(298, 63);
            this.cdvLossCode.MaxLength = 20;
            this.cdvLossCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLossCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLossCode.Name = "cdvLossCode";
            this.cdvLossCode.ReadOnly = false;
            this.cdvLossCode.SearchSubItemIndex = 0;
            this.cdvLossCode.SelectedDescIndex = -1;
            this.cdvLossCode.SelectedSubItemIndex = -1;
            this.cdvLossCode.SelectionStart = 0;
            this.cdvLossCode.Size = new System.Drawing.Size(150, 20);
            this.cdvLossCode.SmallImageList = null;
            this.cdvLossCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLossCode.TabIndex = 10;
            this.cdvLossCode.TextBoxToolTipText = "";
            this.cdvLossCode.TextBoxWidth = 150;
            this.cdvLossCode.VisibleButton = true;
            this.cdvLossCode.VisibleColumnHeader = false;
            this.cdvLossCode.VisibleDescription = false;
            this.cdvLossCode.ButtonPress += new System.EventHandler(this.cdvLossCode_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lot ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Flow";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Resource";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(227, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Operation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(227, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Loss Code";
            // 
            // chkInculdeDelHist
            // 
            this.chkInculdeDelHist.AutoSize = true;
            this.chkInculdeDelHist.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInculdeDelHist.Location = new System.Drawing.Point(480, 64);
            this.chkInculdeDelHist.Name = "chkInculdeDelHist";
            this.chkInculdeDelHist.Size = new System.Drawing.Size(142, 18);
            this.chkInculdeDelHist.TabIndex = 14;
            this.chkInculdeDelHist.Text = "Include Deleted History";
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 12;
            this.spdList.Location = new System.Drawing.Point(0, 0);
            this.spdList.Name = "spdList";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer3;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer3;
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
            this.spdList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 424);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdList.TextTipAppearance = tipAppearance1;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 13;
            this.spdList.SetViewportLeftColumn(0, 0, 2);
            this.spdList.SetActiveViewport(0, 0, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 11;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Qty Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mat Ver";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Res ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Sum";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdList_Sheet1.Columns.Get(0).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 97F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 100F;
            this.spdList_Sheet1.Columns.Get(2).Label = "Hist Seq";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 120F;
            this.spdList_Sheet1.Columns.Get(3).Label = "Qty Flag";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Label = "Material";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 89F;
            this.spdList_Sheet1.Columns.Get(5).Label = "Mat Ver";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 105F;
            this.spdList_Sheet1.Columns.Get(6).Label = "Flow";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 77F;
            this.spdList_Sheet1.Columns.Get(7).Label = "Flow Seq";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 95F;
            this.spdList_Sheet1.Columns.Get(8).Label = "Oper";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Label = "Res ID";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spdList_Sheet1.Columns.Get(10).CellType = textCellType1;
            this.spdList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(10).Label = "Sum";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 70F;
            this.spdList_Sheet1.FrozenColumnCount = 2;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(480, 13);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 11;
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
            this.lblPeriod.Location = new System.Drawing.Point(-1, 3);
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
            // cboQty
            // 
            this.cboQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQty.FormattingEnabled = true;
            this.cboQty.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3"});
            this.cboQty.Location = new System.Drawing.Point(537, 38);
            this.cboQty.Name = "cboQty";
            this.cboQty.Size = new System.Drawing.Size(60, 21);
            this.cboQty.TabIndex = 13;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty.Location = new System.Drawing.Point(480, 42);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(46, 13);
            this.lblQty.TabIndex = 12;
            this.lblQty.Text = "Qty Flag";
            // 
            // frmWIPViewLotLossList
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewLotLossList";
            this.Text = "View Lot Loss List";
            this.Load += new System.EventHandler(this.frmWIPViewLotLoss_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.pnlViewTop.PerformLayout();
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlCenter.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLossCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLossCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkInculdeDelHist;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.ComboBox cboQty;
    }
}
