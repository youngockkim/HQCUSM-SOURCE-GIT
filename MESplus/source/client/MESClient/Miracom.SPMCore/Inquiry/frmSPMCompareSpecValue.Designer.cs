namespace Miracom.SPMCore
{
    partial class frmSPMCompareSpecValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPMCompareSpecValue));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
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
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlDark, 2);
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType5 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised, System.Drawing.SystemColors.ControlLightLight, System.Drawing.SystemColors.ControlDark, 2);
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType6 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.rbtBaseOnMat = new System.Windows.Forms.RadioButton();
            this.rbtBaseOnOper = new System.Windows.Forms.RadioButton();
            this.udcMatID1 = new Miracom.MESCore.Controls.udcMaterial();
            this.udcMatID2 = new Miracom.MESCore.Controls.udcMaterial();
            this.udcMatID3 = new Miracom.MESCore.Controls.udcMaterial();
            this.udcMatID4 = new Miracom.MESCore.Controls.udcMaterial();
            this.udcMatID5 = new Miracom.MESCore.Controls.udcMaterial();
            this.udcOper1 = new Miracom.MESCore.Controls.udcOperation();
            this.udcOper2 = new Miracom.MESCore.Controls.udcOperation();
            this.udcOper3 = new Miracom.MESCore.Controls.udcOperation();
            this.udcOper4 = new Miracom.MESCore.Controls.udcOperation();
            this.udcOper5 = new Miracom.MESCore.Controls.udcOperation();
            this.udcFlow = new Miracom.MESCore.Controls.udcFlow();
            this.lblCharID = new System.Windows.Forms.Label();
            this.cdvCharID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCharGrp1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboCharGrp1 = new System.Windows.Forms.ComboBox();
            this.lblCharGrp1 = new System.Windows.Forms.Label();
            this.cdvCharGrp2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboCharGrp2 = new System.Windows.Forms.ComboBox();
            this.lblCharGrp2 = new System.Windows.Forms.Label();
            this.cboRelVersion = new System.Windows.Forms.ComboBox();
            this.lblRelVersion = new System.Windows.Forms.Label();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.btnToPDF = new System.Windows.Forms.Button();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.sfdPDF = new System.Windows.Forms.SaveFileDialog();
            this.pnlSplitter = new System.Windows.Forms.Panel();
            this.spdSortCol = new FarPoint.Win.Spread.FpSpread();
            this.spdSortCol_Sheet1 = new FarPoint.Win.Spread.SheetView();
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
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 186);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.spdSortCol);
            this.grpOption.Controls.Add(this.pnlSplitter);
            this.grpOption.Controls.Add(this.btnExpand);
            this.grpOption.Controls.Add(this.btnCollapse);
            this.grpOption.Controls.Add(this.cboRelVersion);
            this.grpOption.Controls.Add(this.lblRelVersion);
            this.grpOption.Controls.Add(this.lblCharGrp2);
            this.grpOption.Controls.Add(this.cdvCharGrp2);
            this.grpOption.Controls.Add(this.cboCharGrp2);
            this.grpOption.Controls.Add(this.cdvCharGrp1);
            this.grpOption.Controls.Add(this.cboCharGrp1);
            this.grpOption.Controls.Add(this.lblCharGrp1);
            this.grpOption.Controls.Add(this.lblCharID);
            this.grpOption.Controls.Add(this.cdvCharID);
            this.grpOption.Controls.Add(this.udcFlow);
            this.grpOption.Controls.Add(this.udcOper5);
            this.grpOption.Controls.Add(this.udcOper4);
            this.grpOption.Controls.Add(this.udcOper3);
            this.grpOption.Controls.Add(this.udcOper2);
            this.grpOption.Controls.Add(this.udcOper1);
            this.grpOption.Controls.Add(this.udcMatID5);
            this.grpOption.Controls.Add(this.udcMatID4);
            this.grpOption.Controls.Add(this.udcMatID3);
            this.grpOption.Controls.Add(this.udcMatID2);
            this.grpOption.Controls.Add(this.udcMatID1);
            this.grpOption.Controls.Add(this.rbtBaseOnOper);
            this.grpOption.Controls.Add(this.rbtBaseOnMat);
            this.grpOption.Size = new System.Drawing.Size(742, 186);
            this.grpOption.Text = "Comparison Option";
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdData);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 186);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 327);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnToPDF);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnToPDF, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // rbtBaseOnMat
            // 
            this.rbtBaseOnMat.AutoSize = true;
            this.rbtBaseOnMat.Location = new System.Drawing.Point(12, 16);
            this.rbtBaseOnMat.Name = "rbtBaseOnMat";
            this.rbtBaseOnMat.Size = new System.Drawing.Size(104, 17);
            this.rbtBaseOnMat.TabIndex = 0;
            this.rbtBaseOnMat.Text = "Base on Material";
            this.rbtBaseOnMat.UseVisualStyleBackColor = true;
            this.rbtBaseOnMat.CheckedChanged += new System.EventHandler(this.rbtBaseOnMat_CheckedChanged);
            // 
            // rbtBaseOnOper
            // 
            this.rbtBaseOnOper.AutoSize = true;
            this.rbtBaseOnOper.Location = new System.Drawing.Point(269, 16);
            this.rbtBaseOnOper.Name = "rbtBaseOnOper";
            this.rbtBaseOnOper.Size = new System.Drawing.Size(113, 17);
            this.rbtBaseOnOper.TabIndex = 6;
            this.rbtBaseOnOper.Text = "Base on Operation";
            this.rbtBaseOnOper.UseVisualStyleBackColor = true;
            this.rbtBaseOnOper.CheckedChanged += new System.EventHandler(this.rbtBaseOnOper_CheckedChanged);
            // 
            // udcMatID1
            // 
            this.udcMatID1.AddEmptyRowToLast = false;
            this.udcMatID1.AddEmptyRowToTop = false;
            this.udcMatID1.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.udcMatID1.DisplaySubItemIndex = 0;
            this.udcMatID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID1.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcMatID1.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID1.LabelText = "Material ID 1";
            this.udcMatID1.ListCond_ExtFactory = "";
            this.udcMatID1.ListCond_StepMaterial = '1';
            this.udcMatID1.ListCond_StepVersion = '1';
            this.udcMatID1.Location = new System.Drawing.Point(12, 37);
            this.udcMatID1.MaterialEnabled = true;
            this.udcMatID1.MaterialReadOnly = false;
            this.udcMatID1.Name = "udcMatID1";
            this.udcMatID1.SearchSubItemIndex = 0;
            this.udcMatID1.SelectedDescIndex = -1;
            this.udcMatID1.SelectedSubItemIndex = 0;
            this.udcMatID1.Size = new System.Drawing.Size(230, 20);
            this.udcMatID1.TabIndex = 1;
            this.udcMatID1.VersionEnabled = true;
            this.udcMatID1.VersionReadOnly = false;
            this.udcMatID1.VisibleColumnHeader = false;
            this.udcMatID1.VisibleDescription = false;
            this.udcMatID1.VisibleMaterialButton = true;
            this.udcMatID1.VisibleVersionButton = true;
            this.udcMatID1.WidthButton = 20;
            this.udcMatID1.WidthLabel = 70;
            this.udcMatID1.WidthMaterialAndVersion = 160;
            this.udcMatID1.WidthVersion = 45;
            // 
            // udcMatID2
            // 
            this.udcMatID2.AddEmptyRowToLast = false;
            this.udcMatID2.AddEmptyRowToTop = false;
            this.udcMatID2.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.udcMatID2.DisplaySubItemIndex = 0;
            this.udcMatID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID2.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcMatID2.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID2.LabelText = "Material ID 2";
            this.udcMatID2.ListCond_ExtFactory = "";
            this.udcMatID2.ListCond_StepMaterial = '1';
            this.udcMatID2.ListCond_StepVersion = '1';
            this.udcMatID2.Location = new System.Drawing.Point(12, 61);
            this.udcMatID2.MaterialEnabled = true;
            this.udcMatID2.MaterialReadOnly = false;
            this.udcMatID2.Name = "udcMatID2";
            this.udcMatID2.SearchSubItemIndex = 0;
            this.udcMatID2.SelectedDescIndex = -1;
            this.udcMatID2.SelectedSubItemIndex = 0;
            this.udcMatID2.Size = new System.Drawing.Size(230, 20);
            this.udcMatID2.TabIndex = 2;
            this.udcMatID2.VersionEnabled = true;
            this.udcMatID2.VersionReadOnly = false;
            this.udcMatID2.VisibleColumnHeader = false;
            this.udcMatID2.VisibleDescription = false;
            this.udcMatID2.VisibleMaterialButton = true;
            this.udcMatID2.VisibleVersionButton = true;
            this.udcMatID2.WidthButton = 20;
            this.udcMatID2.WidthLabel = 70;
            this.udcMatID2.WidthMaterialAndVersion = 160;
            this.udcMatID2.WidthVersion = 45;
            // 
            // udcMatID3
            // 
            this.udcMatID3.AddEmptyRowToLast = false;
            this.udcMatID3.AddEmptyRowToTop = false;
            this.udcMatID3.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.udcMatID3.DisplaySubItemIndex = 0;
            this.udcMatID3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID3.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcMatID3.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID3.LabelText = "Material ID 3";
            this.udcMatID3.ListCond_ExtFactory = "";
            this.udcMatID3.ListCond_StepMaterial = '1';
            this.udcMatID3.ListCond_StepVersion = '1';
            this.udcMatID3.Location = new System.Drawing.Point(12, 85);
            this.udcMatID3.MaterialEnabled = true;
            this.udcMatID3.MaterialReadOnly = false;
            this.udcMatID3.Name = "udcMatID3";
            this.udcMatID3.SearchSubItemIndex = 0;
            this.udcMatID3.SelectedDescIndex = -1;
            this.udcMatID3.SelectedSubItemIndex = 0;
            this.udcMatID3.Size = new System.Drawing.Size(230, 20);
            this.udcMatID3.TabIndex = 3;
            this.udcMatID3.VersionEnabled = true;
            this.udcMatID3.VersionReadOnly = false;
            this.udcMatID3.VisibleColumnHeader = false;
            this.udcMatID3.VisibleDescription = false;
            this.udcMatID3.VisibleMaterialButton = true;
            this.udcMatID3.VisibleVersionButton = true;
            this.udcMatID3.WidthButton = 20;
            this.udcMatID3.WidthLabel = 70;
            this.udcMatID3.WidthMaterialAndVersion = 160;
            this.udcMatID3.WidthVersion = 45;
            // 
            // udcMatID4
            // 
            this.udcMatID4.AddEmptyRowToLast = false;
            this.udcMatID4.AddEmptyRowToTop = false;
            this.udcMatID4.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.udcMatID4.DisplaySubItemIndex = 0;
            this.udcMatID4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID4.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcMatID4.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID4.LabelText = "Material ID 4";
            this.udcMatID4.ListCond_ExtFactory = "";
            this.udcMatID4.ListCond_StepMaterial = '1';
            this.udcMatID4.ListCond_StepVersion = '1';
            this.udcMatID4.Location = new System.Drawing.Point(12, 109);
            this.udcMatID4.MaterialEnabled = true;
            this.udcMatID4.MaterialReadOnly = false;
            this.udcMatID4.Name = "udcMatID4";
            this.udcMatID4.SearchSubItemIndex = 0;
            this.udcMatID4.SelectedDescIndex = -1;
            this.udcMatID4.SelectedSubItemIndex = 0;
            this.udcMatID4.Size = new System.Drawing.Size(230, 20);
            this.udcMatID4.TabIndex = 4;
            this.udcMatID4.VersionEnabled = true;
            this.udcMatID4.VersionReadOnly = false;
            this.udcMatID4.VisibleColumnHeader = false;
            this.udcMatID4.VisibleDescription = false;
            this.udcMatID4.VisibleMaterialButton = true;
            this.udcMatID4.VisibleVersionButton = true;
            this.udcMatID4.WidthButton = 20;
            this.udcMatID4.WidthLabel = 70;
            this.udcMatID4.WidthMaterialAndVersion = 160;
            this.udcMatID4.WidthVersion = 45;
            // 
            // udcMatID5
            // 
            this.udcMatID5.AddEmptyRowToLast = false;
            this.udcMatID5.AddEmptyRowToTop = false;
            this.udcMatID5.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.udcMatID5.DisplaySubItemIndex = 0;
            this.udcMatID5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID5.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcMatID5.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcMatID5.LabelText = "Material ID 5";
            this.udcMatID5.ListCond_ExtFactory = "";
            this.udcMatID5.ListCond_StepMaterial = '1';
            this.udcMatID5.ListCond_StepVersion = '1';
            this.udcMatID5.Location = new System.Drawing.Point(12, 133);
            this.udcMatID5.MaterialEnabled = true;
            this.udcMatID5.MaterialReadOnly = false;
            this.udcMatID5.Name = "udcMatID5";
            this.udcMatID5.SearchSubItemIndex = 0;
            this.udcMatID5.SelectedDescIndex = -1;
            this.udcMatID5.SelectedSubItemIndex = 0;
            this.udcMatID5.Size = new System.Drawing.Size(230, 20);
            this.udcMatID5.TabIndex = 5;
            this.udcMatID5.VersionEnabled = true;
            this.udcMatID5.VersionReadOnly = false;
            this.udcMatID5.VisibleColumnHeader = false;
            this.udcMatID5.VisibleDescription = false;
            this.udcMatID5.VisibleMaterialButton = true;
            this.udcMatID5.VisibleVersionButton = true;
            this.udcMatID5.WidthButton = 20;
            this.udcMatID5.WidthLabel = 70;
            this.udcMatID5.WidthMaterialAndVersion = 160;
            this.udcMatID5.WidthVersion = 45;
            // 
            // udcOper1
            // 
            this.udcOper1.AddEmptyRowToLast = false;
            this.udcOper1.AddEmptyRowToTop = false;
            this.udcOper1.ButtonWidth = 21;
            this.udcOper1.DisplaySubItemIndex = 0;
            this.udcOper1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper1.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper1.LabelText = "Operation 1";
            this.udcOper1.LabelWidth = 70;
            this.udcOper1.ListCond_ExtFactory = "";
            this.udcOper1.ListCond_Step = '1';
            this.udcOper1.Location = new System.Drawing.Point(269, 37);
            this.udcOper1.Name = "udcOper1";
            this.udcOper1.ReadOnly = false;
            this.udcOper1.SearchSubItemIndex = 0;
            this.udcOper1.SelectedDescIndex = 1;
            this.udcOper1.SelectedSubItemIndex = 0;
            this.udcOper1.Size = new System.Drawing.Size(160, 20);
            this.udcOper1.TabIndex = 7;
            this.udcOper1.TextBoxWidth = 90;
            this.udcOper1.VisibleButton = true;
            this.udcOper1.VisibleColumnHeader = false;
            this.udcOper1.VisibleDescription = false;
            // 
            // udcOper2
            // 
            this.udcOper2.AddEmptyRowToLast = false;
            this.udcOper2.AddEmptyRowToTop = false;
            this.udcOper2.ButtonWidth = 21;
            this.udcOper2.DisplaySubItemIndex = 0;
            this.udcOper2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper2.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper2.LabelText = "Operation 2";
            this.udcOper2.LabelWidth = 70;
            this.udcOper2.ListCond_ExtFactory = "";
            this.udcOper2.ListCond_Step = '1';
            this.udcOper2.Location = new System.Drawing.Point(269, 61);
            this.udcOper2.Name = "udcOper2";
            this.udcOper2.ReadOnly = false;
            this.udcOper2.SearchSubItemIndex = 0;
            this.udcOper2.SelectedDescIndex = 1;
            this.udcOper2.SelectedSubItemIndex = 0;
            this.udcOper2.Size = new System.Drawing.Size(160, 20);
            this.udcOper2.TabIndex = 8;
            this.udcOper2.TextBoxWidth = 90;
            this.udcOper2.VisibleButton = true;
            this.udcOper2.VisibleColumnHeader = false;
            this.udcOper2.VisibleDescription = false;
            // 
            // udcOper3
            // 
            this.udcOper3.AddEmptyRowToLast = false;
            this.udcOper3.AddEmptyRowToTop = false;
            this.udcOper3.ButtonWidth = 21;
            this.udcOper3.DisplaySubItemIndex = 0;
            this.udcOper3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper3.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper3.LabelText = "Operation 3";
            this.udcOper3.LabelWidth = 70;
            this.udcOper3.ListCond_ExtFactory = "";
            this.udcOper3.ListCond_Step = '1';
            this.udcOper3.Location = new System.Drawing.Point(269, 85);
            this.udcOper3.Name = "udcOper3";
            this.udcOper3.ReadOnly = false;
            this.udcOper3.SearchSubItemIndex = 0;
            this.udcOper3.SelectedDescIndex = 1;
            this.udcOper3.SelectedSubItemIndex = 0;
            this.udcOper3.Size = new System.Drawing.Size(160, 20);
            this.udcOper3.TabIndex = 9;
            this.udcOper3.TextBoxWidth = 90;
            this.udcOper3.VisibleButton = true;
            this.udcOper3.VisibleColumnHeader = false;
            this.udcOper3.VisibleDescription = false;
            // 
            // udcOper4
            // 
            this.udcOper4.AddEmptyRowToLast = false;
            this.udcOper4.AddEmptyRowToTop = false;
            this.udcOper4.ButtonWidth = 21;
            this.udcOper4.DisplaySubItemIndex = 0;
            this.udcOper4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper4.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper4.LabelText = "Operation 4";
            this.udcOper4.LabelWidth = 70;
            this.udcOper4.ListCond_ExtFactory = "";
            this.udcOper4.ListCond_Step = '1';
            this.udcOper4.Location = new System.Drawing.Point(269, 109);
            this.udcOper4.Name = "udcOper4";
            this.udcOper4.ReadOnly = false;
            this.udcOper4.SearchSubItemIndex = 0;
            this.udcOper4.SelectedDescIndex = 1;
            this.udcOper4.SelectedSubItemIndex = 0;
            this.udcOper4.Size = new System.Drawing.Size(160, 20);
            this.udcOper4.TabIndex = 10;
            this.udcOper4.TextBoxWidth = 90;
            this.udcOper4.VisibleButton = true;
            this.udcOper4.VisibleColumnHeader = false;
            this.udcOper4.VisibleDescription = false;
            // 
            // udcOper5
            // 
            this.udcOper5.AddEmptyRowToLast = false;
            this.udcOper5.AddEmptyRowToTop = false;
            this.udcOper5.ButtonWidth = 21;
            this.udcOper5.DisplaySubItemIndex = 0;
            this.udcOper5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper5.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcOper5.LabelText = "Operation 5";
            this.udcOper5.LabelWidth = 70;
            this.udcOper5.ListCond_ExtFactory = "";
            this.udcOper5.ListCond_Step = '1';
            this.udcOper5.Location = new System.Drawing.Point(269, 133);
            this.udcOper5.Name = "udcOper5";
            this.udcOper5.ReadOnly = false;
            this.udcOper5.SearchSubItemIndex = 0;
            this.udcOper5.SelectedDescIndex = 1;
            this.udcOper5.SelectedSubItemIndex = 0;
            this.udcOper5.Size = new System.Drawing.Size(160, 20);
            this.udcOper5.TabIndex = 11;
            this.udcOper5.TextBoxWidth = 90;
            this.udcOper5.VisibleButton = true;
            this.udcOper5.VisibleColumnHeader = false;
            this.udcOper5.VisibleDescription = false;
            // 
            // udcFlow
            // 
            this.udcFlow.AddEmptyRowToLast = false;
            this.udcFlow.AddEmptyRowToTop = false;
            this.udcFlow.ButtonWidth = 21;
            this.udcFlow.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.udcFlow.DisplaySubItemIndex = 0;
            this.udcFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcFlow.LabelBackColor = System.Drawing.SystemColors.Control;
            this.udcFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udcFlow.LabelText = "Flow";
            this.udcFlow.LabelWidth = 100;
            this.udcFlow.ListCond_ExtFactory = "";
            this.udcFlow.ListCond_Step = '1';
            this.udcFlow.Location = new System.Drawing.Point(457, 37);
            this.udcFlow.Name = "udcFlow";
            this.udcFlow.ReadOnly = false;
            this.udcFlow.SearchSubItemIndex = 0;
            this.udcFlow.SelectedDescIndex = 1;
            this.udcFlow.SelectedSubItemIndex = 0;
            this.udcFlow.Size = new System.Drawing.Size(279, 20);
            this.udcFlow.TabIndex = 12;
            this.udcFlow.TextBoxWidth = 179;
            this.udcFlow.VisibleButton = true;
            this.udcFlow.VisibleColumnHeader = false;
            this.udcFlow.VisibleDescription = false;
            // 
            // lblCharID
            // 
            this.lblCharID.AutoSize = true;
            this.lblCharID.Location = new System.Drawing.Point(454, 65);
            this.lblCharID.Name = "lblCharID";
            this.lblCharID.Size = new System.Drawing.Size(67, 13);
            this.lblCharID.TabIndex = 13;
            this.lblCharID.Text = "Character ID";
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
            this.cdvCharID.Location = new System.Drawing.Point(557, 61);
            this.cdvCharID.MaxLength = 25;
            this.cdvCharID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharID.Name = "cdvCharID";
            this.cdvCharID.ReadOnly = false;
            this.cdvCharID.SearchSubItemIndex = 0;
            this.cdvCharID.SelectedDescIndex = -1;
            this.cdvCharID.SelectedSubItemIndex = -1;
            this.cdvCharID.SelectionStart = 0;
            this.cdvCharID.Size = new System.Drawing.Size(179, 20);
            this.cdvCharID.SmallImageList = null;
            this.cdvCharID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharID.TabIndex = 14;
            this.cdvCharID.TextBoxToolTipText = "";
            this.cdvCharID.TextBoxWidth = 179;
            this.cdvCharID.VisibleButton = true;
            this.cdvCharID.VisibleColumnHeader = false;
            this.cdvCharID.VisibleDescription = false;
            this.cdvCharID.ButtonPress += new System.EventHandler(this.cdvCharID_ButtonPress);
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
            this.cdvCharGrp1.Location = new System.Drawing.Point(665, 85);
            this.cdvCharGrp1.MaxLength = 30;
            this.cdvCharGrp1.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharGrp1.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharGrp1.Name = "cdvCharGrp1";
            this.cdvCharGrp1.ReadOnly = false;
            this.cdvCharGrp1.SearchSubItemIndex = 0;
            this.cdvCharGrp1.SelectedDescIndex = -1;
            this.cdvCharGrp1.SelectedSubItemIndex = -1;
            this.cdvCharGrp1.SelectionStart = 0;
            this.cdvCharGrp1.Size = new System.Drawing.Size(71, 20);
            this.cdvCharGrp1.SmallImageList = null;
            this.cdvCharGrp1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharGrp1.TabIndex = 17;
            this.cdvCharGrp1.TextBoxToolTipText = "";
            this.cdvCharGrp1.TextBoxWidth = 71;
            this.cdvCharGrp1.VisibleButton = true;
            this.cdvCharGrp1.VisibleColumnHeader = false;
            this.cdvCharGrp1.VisibleDescription = false;
            // 
            // cboCharGrp1
            // 
            this.cboCharGrp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharGrp1.FormattingEnabled = true;
            this.cboCharGrp1.Location = new System.Drawing.Point(557, 85);
            this.cboCharGrp1.Name = "cboCharGrp1";
            this.cboCharGrp1.Size = new System.Drawing.Size(105, 21);
            this.cboCharGrp1.TabIndex = 16;
            this.cboCharGrp1.SelectedIndexChanged += new System.EventHandler(this.cboCharGrp_SelectedIndexChanged);
            // 
            // lblCharGrp1
            // 
            this.lblCharGrp1.AutoSize = true;
            this.lblCharGrp1.Location = new System.Drawing.Point(454, 89);
            this.lblCharGrp1.Name = "lblCharGrp1";
            this.lblCharGrp1.Size = new System.Drawing.Size(91, 13);
            this.lblCharGrp1.TabIndex = 15;
            this.lblCharGrp1.Text = "Char GRP/CMF 1";
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
            this.cdvCharGrp2.Location = new System.Drawing.Point(665, 109);
            this.cdvCharGrp2.MaxLength = 30;
            this.cdvCharGrp2.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharGrp2.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharGrp2.Name = "cdvCharGrp2";
            this.cdvCharGrp2.ReadOnly = false;
            this.cdvCharGrp2.SearchSubItemIndex = 0;
            this.cdvCharGrp2.SelectedDescIndex = -1;
            this.cdvCharGrp2.SelectedSubItemIndex = -1;
            this.cdvCharGrp2.SelectionStart = 0;
            this.cdvCharGrp2.Size = new System.Drawing.Size(71, 20);
            this.cdvCharGrp2.SmallImageList = null;
            this.cdvCharGrp2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharGrp2.TabIndex = 20;
            this.cdvCharGrp2.TextBoxToolTipText = "";
            this.cdvCharGrp2.TextBoxWidth = 71;
            this.cdvCharGrp2.VisibleButton = true;
            this.cdvCharGrp2.VisibleColumnHeader = false;
            this.cdvCharGrp2.VisibleDescription = false;
            // 
            // cboCharGrp2
            // 
            this.cboCharGrp2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharGrp2.FormattingEnabled = true;
            this.cboCharGrp2.Location = new System.Drawing.Point(557, 109);
            this.cboCharGrp2.Name = "cboCharGrp2";
            this.cboCharGrp2.Size = new System.Drawing.Size(105, 21);
            this.cboCharGrp2.TabIndex = 19;
            this.cboCharGrp2.SelectedIndexChanged += new System.EventHandler(this.cboCharGrp_SelectedIndexChanged);
            // 
            // lblCharGrp2
            // 
            this.lblCharGrp2.AutoSize = true;
            this.lblCharGrp2.Location = new System.Drawing.Point(454, 113);
            this.lblCharGrp2.Name = "lblCharGrp2";
            this.lblCharGrp2.Size = new System.Drawing.Size(91, 13);
            this.lblCharGrp2.TabIndex = 18;
            this.lblCharGrp2.Text = "Char GRP/CMF 2";
            // 
            // cboRelVersion
            // 
            this.cboRelVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelVersion.FormattingEnabled = true;
            this.cboRelVersion.Items.AddRange(new object[] {
            "Last Release Version",
            "Last Version"});
            this.cboRelVersion.Location = new System.Drawing.Point(557, 133);
            this.cboRelVersion.Name = "cboRelVersion";
            this.cboRelVersion.Size = new System.Drawing.Size(179, 21);
            this.cboRelVersion.TabIndex = 22;
            // 
            // lblRelVersion
            // 
            this.lblRelVersion.AutoSize = true;
            this.lblRelVersion.Location = new System.Drawing.Point(453, 137);
            this.lblRelVersion.Name = "lblRelVersion";
            this.lblRelVersion.Size = new System.Drawing.Size(84, 13);
            this.lblRelVersion.TabIndex = 21;
            this.lblRelVersion.Text = "Relation Version";
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(712, 1);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 15);
            this.btnExpand.TabIndex = 24;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(685, 1);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 15);
            this.btnCollapse.TabIndex = 23;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnToPDF
            // 
            this.btnToPDF.Location = new System.Drawing.Point(12, 7);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(88, 26);
            this.btnToPDF.TabIndex = 0;
            this.btnToPDF.Text = "To PDF";
            this.btnToPDF.UseVisualStyleBackColor = true;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdData.HorizontalScrollBar.TabIndex = 16;
            this.spdData.Location = new System.Drawing.Point(0, 0);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(742, 327);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdData.VerticalScrollBar.TabIndex = 17;
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 1;
            spdData_Sheet1.RowCount = 3;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Object Value";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Label = "Object Value";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 74F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdData_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlSplitter
            // 
            this.pnlSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSplitter.BackColor = System.Drawing.Color.Black;
            this.pnlSplitter.Location = new System.Drawing.Point(12, 156);
            this.pnlSplitter.Name = "pnlSplitter";
            this.pnlSplitter.Size = new System.Drawing.Size(724, 1);
            this.pnlSplitter.TabIndex = 25;
            // 
            // spdSortCol
            // 
            this.spdSortCol.AccessibleDescription = "spdSortCol, Sheet1, Row 0, Column 0, MAT_ID";
            this.spdSortCol.AllowColumnMove = true;
            this.spdSortCol.AllowUserZoom = false;
            this.spdSortCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spdSortCol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spdSortCol.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSortCol.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSortCol.HorizontalScrollBar.Name = "";
            this.spdSortCol.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdSortCol.HorizontalScrollBar.TabIndex = 26;
            this.spdSortCol.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdSortCol.Location = new System.Drawing.Point(12, 161);
            this.spdSortCol.Name = "spdSortCol";
            this.spdSortCol.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSortCol_Sheet1});
            this.spdSortCol.Size = new System.Drawing.Size(719, 19);
            this.spdSortCol.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSortCol.TabIndex = 26;
            this.spdSortCol.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSortCol.VerticalScrollBar.Name = "";
            this.spdSortCol.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdSortCol.VerticalScrollBar.TabIndex = 27;
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
            spdSortCol_Sheet1.ColumnCount = 6;
            spdSortCol_Sheet1.RowCount = 1;
            this.spdSortCol_Sheet1.Cells.Get(0, 0).Value = "MAT_ID";
            this.spdSortCol_Sheet1.Cells.Get(0, 1).Value = "MAT_VER";
            this.spdSortCol_Sheet1.Cells.Get(0, 2).Value = "FLOW";
            this.spdSortCol_Sheet1.Cells.Get(0, 3).Value = "OPER";
            this.spdSortCol_Sheet1.Cells.Get(0, 4).Value = "CHAR_ID";
            this.spdSortCol_Sheet1.Cells.Get(0, 5).Value = "CHAR_DESC";
            this.spdSortCol_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSortCol_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 0).Border = bevelBorder1;
            checkBoxCellType1.Caption = "Material ID";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 0).CellType = checkBoxCellType1;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = true;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 1).Border = bevelBorder2;
            checkBoxCellType2.Caption = "Mat Ver";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 1).CellType = checkBoxCellType2;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = true;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 2).Border = bevelBorder3;
            checkBoxCellType3.Caption = "Flow";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 2).CellType = checkBoxCellType3;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = true;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 3).Border = bevelBorder4;
            checkBoxCellType4.Caption = "Operation";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 3).CellType = checkBoxCellType4;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "True";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 4).Border = bevelBorder5;
            checkBoxCellType5.Caption = "Character ID";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 4).CellType = checkBoxCellType5;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "True";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 5).Border = bevelBorder6;
            checkBoxCellType6.Caption = "Character Description";
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 5).CellType = checkBoxCellType6;
            this.spdSortCol_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "True";
            this.spdSortCol_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSortCol_Sheet1.Columns.Get(0).Label = "True";
            this.spdSortCol_Sheet1.Columns.Get(0).Width = 80F;
            this.spdSortCol_Sheet1.Columns.Get(1).Label = "True";
            this.spdSortCol_Sheet1.Columns.Get(1).Width = 70F;
            this.spdSortCol_Sheet1.Columns.Get(3).Label = "True";
            this.spdSortCol_Sheet1.Columns.Get(3).Width = 80F;
            this.spdSortCol_Sheet1.Columns.Get(4).Label = "True";
            this.spdSortCol_Sheet1.Columns.Get(4).Width = 100F;
            this.spdSortCol_Sheet1.Columns.Get(5).Label = "True";
            this.spdSortCol_Sheet1.Columns.Get(5).Width = 140F;
            this.spdSortCol_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSortCol_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSortCol_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSortCol_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSortCol_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmSPMCompareSpecValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmSPMCompareSpecValue";
            this.Text = "Compare Specification Value";
            this.Activated += new System.EventHandler(this.frmSPMCompareSpecValue_Activated);
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

        private System.Windows.Forms.RadioButton rbtBaseOnOper;
        private System.Windows.Forms.RadioButton rbtBaseOnMat;
        private MESCore.Controls.udcMaterial udcMatID1;
        private MESCore.Controls.udcMaterial udcMatID5;
        private MESCore.Controls.udcMaterial udcMatID4;
        private MESCore.Controls.udcMaterial udcMatID3;
        private MESCore.Controls.udcMaterial udcMatID2;
        private MESCore.Controls.udcOperation udcOper5;
        private MESCore.Controls.udcOperation udcOper4;
        private MESCore.Controls.udcOperation udcOper3;
        private MESCore.Controls.udcOperation udcOper2;
        private MESCore.Controls.udcOperation udcOper1;
        private MESCore.Controls.udcFlow udcFlow;
        private System.Windows.Forms.Label lblCharID;
        private UI.Controls.MCCodeView.MCCodeView cdvCharID;
        private System.Windows.Forms.Label lblCharGrp2;
        private UI.Controls.MCCodeView.MCCodeView cdvCharGrp2;
        private System.Windows.Forms.ComboBox cboCharGrp2;
        private UI.Controls.MCCodeView.MCCodeView cdvCharGrp1;
        private System.Windows.Forms.ComboBox cboCharGrp1;
        private System.Windows.Forms.Label lblCharGrp1;
        private System.Windows.Forms.ComboBox cboRelVersion;
        private System.Windows.Forms.Label lblRelVersion;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.Button btnToPDF;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.SaveFileDialog sfdPDF;
        private System.Windows.Forms.Panel pnlSplitter;
        private FarPoint.Win.Spread.FpSpread spdSortCol;
        private FarPoint.Win.Spread.SheetView spdSortCol_Sheet1;
    }
}