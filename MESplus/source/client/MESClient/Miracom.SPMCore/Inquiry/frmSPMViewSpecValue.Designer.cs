namespace Miracom.SPMCore
{
    partial class frmSPMViewSpecValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPMViewSpecValue));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlDark, 2);
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlDark, 2);
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlDark, 2);
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlDark, 2);
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.udcMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.udcOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvCharID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCharID = new System.Windows.Forms.Label();
            this.lblCharGrp = new System.Windows.Forms.Label();
            this.cboCharGrp1 = new System.Windows.Forms.ComboBox();
            this.cdvCharGrp1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboRelVersion = new System.Windows.Forms.ComboBox();
            this.lblRelVersion = new System.Windows.Forms.Label();
            this.chkSpecValueOnly = new System.Windows.Forms.CheckBox();
            this.pnlSplitter = new System.Windows.Forms.Panel();
            this.cdvCharGrp2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboCharGrp2 = new System.Windows.Forms.ComboBox();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnToPDF = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.spdSortCol = new FarPoint.Win.Spread.FpSpread();
            this.spdSortCol_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.sfdPDF = new System.Windows.Forms.SaveFileDialog();
            this.lblLot = new System.Windows.Forms.Label();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharGrp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharGrp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSortCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSortCol_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 145);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtLot);
            this.grpOption.Controls.Add(this.lblLot);
            this.grpOption.Controls.Add(this.spdSortCol);
            this.grpOption.Controls.Add(this.btnExpand);
            this.grpOption.Controls.Add(this.btnCollapse);
            this.grpOption.Controls.Add(this.cdvCharGrp2);
            this.grpOption.Controls.Add(this.cboCharGrp2);
            this.grpOption.Controls.Add(this.pnlSplitter);
            this.grpOption.Controls.Add(this.chkSpecValueOnly);
            this.grpOption.Controls.Add(this.cboRelVersion);
            this.grpOption.Controls.Add(this.lblRelVersion);
            this.grpOption.Controls.Add(this.cdvCharGrp1);
            this.grpOption.Controls.Add(this.cboCharGrp1);
            this.grpOption.Controls.Add(this.lblCharGrp);
            this.grpOption.Controls.Add(this.lblCharID);
            this.grpOption.Controls.Add(this.cdvCharID);
            this.grpOption.Controls.Add(this.udcOper);
            this.grpOption.Controls.Add(this.udcMatID);
            this.grpOption.Size = new System.Drawing.Size(742, 145);
            this.grpOption.Text = "Filter and Sort Order";
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdData);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 145);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 368);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnToPDF);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnToPDF, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // udcMatID
            // 
            this.udcMatID.AddEmptyRowToLast = false;
            this.udcMatID.AddEmptyRowToTop = false;
            this.udcMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.udcMatID.DisplaySubItemIndex = 0;
            this.udcMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID.LabelText = "Material ID";
            this.udcMatID.ListCond_ExtFactory = "";
            this.udcMatID.ListCond_StepMaterial = '1';
            this.udcMatID.ListCond_StepVersion = '1';
            this.udcMatID.Location = new System.Drawing.Point(12, 39);
            this.udcMatID.MaterialEnabled = true;
            this.udcMatID.MaterialReadOnly = false;
            this.udcMatID.Name = "udcMatID";
            this.udcMatID.SearchSubItemIndex = 0;
            this.udcMatID.SelectedDescIndex = -1;
            this.udcMatID.SelectedSubItemIndex = 0;
            this.udcMatID.Size = new System.Drawing.Size(260, 20);
            this.udcMatID.TabIndex = 0;
            this.udcMatID.VersionEnabled = true;
            this.udcMatID.VersionReadOnly = false;
            this.udcMatID.VisibleColumnHeader = false;
            this.udcMatID.VisibleDescription = false;
            this.udcMatID.VisibleMaterialButton = true;
            this.udcMatID.VisibleVersionButton = true;
            this.udcMatID.WidthButton = 20;
            this.udcMatID.WidthLabel = 100;
            this.udcMatID.WidthMaterialAndVersion = 160;
            this.udcMatID.WidthVersion = 45;
            // 
            // udcOper
            // 
            this.udcOper.AddEmptyRowToLast = false;
            this.udcOper.AddEmptyRowToTop = false;
            this.udcOper.ButtonWidth = 21;
            this.udcOper.DisplaySubItemIndex = 0;
            this.udcOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper.LabelText = "Operation";
            this.udcOper.LabelWidth = 100;
            this.udcOper.ListCond_ExtFactory = "";
            this.udcOper.ListCond_Step = '1';
            this.udcOper.Location = new System.Drawing.Point(346, 39);
            this.udcOper.Name = "udcOper";
            this.udcOper.ReadOnly = false;
            this.udcOper.SearchSubItemIndex = 0;
            this.udcOper.SelectedDescIndex = 1;
            this.udcOper.SelectedSubItemIndex = 0;
            this.udcOper.Size = new System.Drawing.Size(261, 20);
            this.udcOper.TabIndex = 1;
            this.udcOper.TextBoxWidth = 161;
            this.udcOper.VisibleButton = true;
            this.udcOper.VisibleColumnHeader = false;
            this.udcOper.VisibleDescription = false;
            // 
            // cdvCharID
            // 
            this.cdvCharID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCharID.BtnToolTipText = "";
            this.cdvCharID.DescText = "";
            this.cdvCharID.DisplaySubItemIndex = -1;
            this.cdvCharID.DisplayText = "";
            this.cdvCharID.Focusing = null;
            this.cdvCharID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCharID.Index = 0;
            this.cdvCharID.IsViewBtnImage = false;
            this.cdvCharID.Location = new System.Drawing.Point(112, 63);
            this.cdvCharID.MaxLength = 25;
            this.cdvCharID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharID.Name = "cdvCharID";
            this.cdvCharID.ReadOnly = false;
            this.cdvCharID.SearchSubItemIndex = 0;
            this.cdvCharID.SelectedDescIndex = -1;
            this.cdvCharID.SelectedSubItemIndex = -1;
            this.cdvCharID.SelectionStart = 0;
            this.cdvCharID.Size = new System.Drawing.Size(160, 20);
            this.cdvCharID.SmallImageList = null;
            this.cdvCharID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharID.TabIndex = 3;
            this.cdvCharID.TextBoxToolTipText = "";
            this.cdvCharID.TextBoxWidth = 160;
            this.cdvCharID.VisibleButton = true;
            this.cdvCharID.VisibleColumnHeader = false;
            this.cdvCharID.VisibleDescription = false;
            this.cdvCharID.ButtonPress += new System.EventHandler(this.cdvCharID_ButtonPress);
            // 
            // lblCharID
            // 
            this.lblCharID.AutoSize = true;
            this.lblCharID.Location = new System.Drawing.Point(9, 67);
            this.lblCharID.Name = "lblCharID";
            this.lblCharID.Size = new System.Drawing.Size(67, 13);
            this.lblCharID.TabIndex = 2;
            this.lblCharID.Text = "Character ID";
            // 
            // lblCharGrp
            // 
            this.lblCharGrp.AutoSize = true;
            this.lblCharGrp.Location = new System.Drawing.Point(9, 91);
            this.lblCharGrp.Name = "lblCharGrp";
            this.lblCharGrp.Size = new System.Drawing.Size(82, 13);
            this.lblCharGrp.TabIndex = 7;
            this.lblCharGrp.Text = "Char GRP/CMF";
            // 
            // cboCharGrp1
            // 
            this.cboCharGrp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharGrp1.FormattingEnabled = true;
            this.cboCharGrp1.Location = new System.Drawing.Point(112, 87);
            this.cboCharGrp1.Name = "cboCharGrp1";
            this.cboCharGrp1.Size = new System.Drawing.Size(160, 21);
            this.cboCharGrp1.TabIndex = 8;
            this.cboCharGrp1.SelectedIndexChanged += new System.EventHandler(this.cboCharGrp_SelectedIndexChanged);
            // 
            // cdvCharGrp1
            // 
            this.cdvCharGrp1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharGrp1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharGrp1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCharGrp1.BtnToolTipText = "";
            this.cdvCharGrp1.DescText = "";
            this.cdvCharGrp1.DisplaySubItemIndex = -1;
            this.cdvCharGrp1.DisplayText = "";
            this.cdvCharGrp1.Focusing = null;
            this.cdvCharGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCharGrp1.Index = 0;
            this.cdvCharGrp1.IsViewBtnImage = false;
            this.cdvCharGrp1.Location = new System.Drawing.Point(275, 88);
            this.cdvCharGrp1.MaxLength = 30;
            this.cdvCharGrp1.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharGrp1.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharGrp1.Name = "cdvCharGrp1";
            this.cdvCharGrp1.ReadOnly = false;
            this.cdvCharGrp1.SearchSubItemIndex = 0;
            this.cdvCharGrp1.SelectedDescIndex = -1;
            this.cdvCharGrp1.SelectedSubItemIndex = -1;
            this.cdvCharGrp1.SelectionStart = 0;
            this.cdvCharGrp1.Size = new System.Drawing.Size(109, 20);
            this.cdvCharGrp1.SmallImageList = null;
            this.cdvCharGrp1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharGrp1.TabIndex = 9;
            this.cdvCharGrp1.TextBoxToolTipText = "";
            this.cdvCharGrp1.TextBoxWidth = 109;
            this.cdvCharGrp1.VisibleButton = true;
            this.cdvCharGrp1.VisibleColumnHeader = false;
            this.cdvCharGrp1.VisibleDescription = false;
            // 
            // cboRelVersion
            // 
            this.cboRelVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelVersion.FormattingEnabled = true;
            this.cboRelVersion.Items.AddRange(new object[] {
            "Last Release Version",
            "Last Version"});
            this.cboRelVersion.Location = new System.Drawing.Point(447, 63);
            this.cboRelVersion.Name = "cboRelVersion";
            this.cboRelVersion.Size = new System.Drawing.Size(160, 21);
            this.cboRelVersion.TabIndex = 5;
            // 
            // lblRelVersion
            // 
            this.lblRelVersion.AutoSize = true;
            this.lblRelVersion.Location = new System.Drawing.Point(343, 67);
            this.lblRelVersion.Name = "lblRelVersion";
            this.lblRelVersion.Size = new System.Drawing.Size(84, 13);
            this.lblRelVersion.TabIndex = 4;
            this.lblRelVersion.Text = "Relation Version";
            // 
            // chkSpecValueOnly
            // 
            this.chkSpecValueOnly.AutoSize = true;
            this.chkSpecValueOnly.Location = new System.Drawing.Point(614, 65);
            this.chkSpecValueOnly.Name = "chkSpecValueOnly";
            this.chkSpecValueOnly.Size = new System.Drawing.Size(108, 17);
            this.chkSpecValueOnly.TabIndex = 6;
            this.chkSpecValueOnly.Text = "Spec. Value Only";
            this.chkSpecValueOnly.UseVisualStyleBackColor = true;
            // 
            // pnlSplitter
            // 
            this.pnlSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSplitter.BackColor = System.Drawing.Color.Black;
            this.pnlSplitter.Location = new System.Drawing.Point(12, 112);
            this.pnlSplitter.Name = "pnlSplitter";
            this.pnlSplitter.Size = new System.Drawing.Size(719, 1);
            this.pnlSplitter.TabIndex = 12;
            // 
            // cdvCharGrp2
            // 
            this.cdvCharGrp2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharGrp2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharGrp2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCharGrp2.BtnToolTipText = "";
            this.cdvCharGrp2.DescText = "";
            this.cdvCharGrp2.DisplaySubItemIndex = -1;
            this.cdvCharGrp2.DisplayText = "";
            this.cdvCharGrp2.Focusing = null;
            this.cdvCharGrp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCharGrp2.Index = 0;
            this.cdvCharGrp2.IsViewBtnImage = false;
            this.cdvCharGrp2.Location = new System.Drawing.Point(610, 88);
            this.cdvCharGrp2.MaxLength = 30;
            this.cdvCharGrp2.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharGrp2.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharGrp2.Name = "cdvCharGrp2";
            this.cdvCharGrp2.ReadOnly = false;
            this.cdvCharGrp2.SearchSubItemIndex = 0;
            this.cdvCharGrp2.SelectedDescIndex = -1;
            this.cdvCharGrp2.SelectedSubItemIndex = -1;
            this.cdvCharGrp2.SelectionStart = 0;
            this.cdvCharGrp2.Size = new System.Drawing.Size(114, 20);
            this.cdvCharGrp2.SmallImageList = null;
            this.cdvCharGrp2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharGrp2.TabIndex = 11;
            this.cdvCharGrp2.TextBoxToolTipText = "";
            this.cdvCharGrp2.TextBoxWidth = 114;
            this.cdvCharGrp2.VisibleButton = true;
            this.cdvCharGrp2.VisibleColumnHeader = false;
            this.cdvCharGrp2.VisibleDescription = false;
            // 
            // cboCharGrp2
            // 
            this.cboCharGrp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharGrp2.FormattingEnabled = true;
            this.cboCharGrp2.Location = new System.Drawing.Point(447, 87);
            this.cboCharGrp2.Name = "cboCharGrp2";
            this.cboCharGrp2.Size = new System.Drawing.Size(160, 21);
            this.cboCharGrp2.TabIndex = 10;
            this.cboCharGrp2.SelectedIndexChanged += new System.EventHandler(this.cboCharGrp_SelectedIndexChanged);
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdData.HorizontalScrollBar.TabIndex = 20;
            this.spdData.Location = new System.Drawing.Point(0, 0);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(742, 368);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdData.VerticalScrollBar.TabIndex = 21;
            this.spdData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdData_CellClick);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 21;
            spdData_Sheet1.RowCount = 3;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Doc 1";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Doc 2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Doc 3";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Doc 4";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Doc 5";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Img 1";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Img 2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Img 3";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Img 4";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Img 5";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Ref Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "OOS Alarm";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "OOW Alarm";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Rel Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Rel User";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Rel Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Apr Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Apr User";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Apr Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Apply Time";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Label = "Value";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Label = "Doc 1";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Label = "Doc 2";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Label = "Doc 3";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Label = "Doc 4";
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Label = "Doc 5";
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Label = "Img 1";
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Label = "Img 2";
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Label = "Img 3";
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Label = "Img 4";
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Label = "Img 5";
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Label = "Ref Type";
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Label = "OOS Alarm";
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Label = "OOW Alarm";
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 79F;
            this.spdData_Sheet1.Columns.Get(14).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Label = "Rel Flag";
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Label = "Rel User";
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Label = "Rel Time";
            this.spdData_Sheet1.Columns.Get(16).Locked = true;
            this.spdData_Sheet1.Columns.Get(16).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).Label = "Apr Flag";
            this.spdData_Sheet1.Columns.Get(17).Locked = true;
            this.spdData_Sheet1.Columns.Get(17).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdData_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).Label = "Apr User";
            this.spdData_Sheet1.Columns.Get(18).Locked = true;
            this.spdData_Sheet1.Columns.Get(18).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).Label = "Apr Time";
            this.spdData_Sheet1.Columns.Get(19).Locked = true;
            this.spdData_Sheet1.Columns.Get(19).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).Label = "Apply Time";
            this.spdData_Sheet1.Columns.Get(20).Locked = true;
            this.spdData_Sheet1.Columns.Get(20).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnToPDF
            // 
            this.btnToPDF.Location = new System.Drawing.Point(12, 7);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(88, 26);
            this.btnToPDF.TabIndex = 2;
            this.btnToPDF.Text = "To PDF";
            this.btnToPDF.UseVisualStyleBackColor = true;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(707, 1);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 15);
            this.btnExpand.TabIndex = 26;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(680, 1);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 15);
            this.btnCollapse.TabIndex = 25;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // spdSortCol
            // 
            this.spdSortCol.AccessibleDescription = "spdSortCol, Sheet1, Row 0, Column 0, OPER";
            this.spdSortCol.AllowColumnMove = true;
            this.spdSortCol.AllowUserZoom = false;
            this.spdSortCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spdSortCol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spdSortCol.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSortCol.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSortCol.HorizontalScrollBar.Name = "";
            this.spdSortCol.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdSortCol.HorizontalScrollBar.TabIndex = 22;
            this.spdSortCol.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdSortCol.Location = new System.Drawing.Point(12, 117);
            this.spdSortCol.Name = "spdSortCol";
            this.spdSortCol.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSortCol_Sheet1});
            this.spdSortCol.Size = new System.Drawing.Size(719, 19);
            this.spdSortCol.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSortCol.TabIndex = 12;
            this.spdSortCol.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSortCol.VerticalScrollBar.Name = "";
            this.spdSortCol.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdSortCol.VerticalScrollBar.TabIndex = 23;
            this.spdSortCol.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdSortCol.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdSortCol_CellClick);
            this.spdSortCol.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spdSortCol_MouseUp);
            // 
            // spdSortCol_Sheet1
            // 
            this.spdSortCol_Sheet1.Reset();
            spdSortCol_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSortCol_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSortCol_Sheet1.ColumnCount = 4;
            spdSortCol_Sheet1.RowCount = 1;
            this.spdSortCol_Sheet1.Cells.Get(0, 0).Value = "OPER";
            this.spdSortCol_Sheet1.Cells.Get(0, 1).Value = "CHAR_ID";
            this.spdSortCol_Sheet1.Cells.Get(0, 2).Value = "CHAR_DESC";
            this.spdSortCol_Sheet1.Cells.Get(0, 3).Value = "FLOW";
            this.spdSortCol_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSortCol_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 0).Border = bevelBorder1;
            checkBoxCellType1.Caption = "Operation";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 0).CellType = checkBoxCellType1;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "True";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 1).Border = bevelBorder2;
            checkBoxCellType2.Caption = "Character ID";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 1).CellType = checkBoxCellType2;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "True";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 2).Border = bevelBorder3;
            checkBoxCellType3.Caption = "Character Description";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 2).CellType = checkBoxCellType3;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "True";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 3).Border = bevelBorder4;
            checkBoxCellType4.Caption = "Flow";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 3).CellType = checkBoxCellType4;
            this.spdSortCol_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSortCol_Sheet1.Columns.Get(0).Label = "True";
            this.spdSortCol_Sheet1.Columns.Get(0).Width = 80F;
            this.spdSortCol_Sheet1.Columns.Get(1).Label = "True";
            this.spdSortCol_Sheet1.Columns.Get(1).Width = 100F;
            this.spdSortCol_Sheet1.Columns.Get(2).Label = "True";
            this.spdSortCol_Sheet1.Columns.Get(2).Width = 140F;
            this.spdSortCol_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSortCol_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSortCol_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSortCol_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.Location = new System.Drawing.Point(9, 19);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(42, 13);
            this.lblLot.TabIndex = 27;
            this.lblLot.Text = "Lot ID";
            // 
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(112, 16);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(160, 20);
            this.txtLot.TabIndex = 28;
            // 
            // frmSPMViewSpecValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmSPMViewSpecValue";
            this.Text = "View Specification Value";
            this.Activated += new System.EventHandler(this.frmSPMViewSpecValue_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharGrp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharGrp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSortCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSortCol_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.MCCodeView.MCCodeView cdvCharGrp2;
        private System.Windows.Forms.ComboBox cboCharGrp2;
        private System.Windows.Forms.Panel pnlSplitter;
        private System.Windows.Forms.CheckBox chkSpecValueOnly;
        private System.Windows.Forms.ComboBox cboRelVersion;
        private System.Windows.Forms.Label lblRelVersion;
        private UI.Controls.MCCodeView.MCCodeView cdvCharGrp1;
        private System.Windows.Forms.ComboBox cboCharGrp1;
        private System.Windows.Forms.Label lblCharGrp;
        private System.Windows.Forms.Label lblCharID;
        private UI.Controls.MCCodeView.MCCodeView cdvCharID;
        private MESCore.Controls.udcOperation udcOper;
        private MESCore.Controls.udcMaterial udcMatID;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.Button btnToPDF;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
        private FarPoint.Win.Spread.FpSpread spdSortCol;
        private FarPoint.Win.Spread.SheetView spdSortCol_Sheet1;
        private System.Windows.Forms.SaveFileDialog sfdPDF;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.Label lblLot;
    }
}