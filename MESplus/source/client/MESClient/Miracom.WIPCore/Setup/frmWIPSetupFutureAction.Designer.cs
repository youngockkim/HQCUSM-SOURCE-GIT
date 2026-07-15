namespace Miracom.WIPCore
{
    partial class frmWIPSetupFutureAction
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType5 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType6 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupFutureAction));
            this.tvMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.tabAction = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.pnlActionValue = new System.Windows.Forms.Panel();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.cdvDependentAction = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDependent = new System.Windows.Forms.Label();
            this.chkSkipService = new System.Windows.Forms.CheckBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.cboTransaction = new System.Windows.Forms.ComboBox();
            this.lblTransaction = new System.Windows.Forms.Label();
            this.pnlPoint = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lisServices = new Miracom.UI.Controls.MCListView.MCListView();
            this.colCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServices = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpBA = new System.Windows.Forms.GroupBox();
            this.rbtAfter = new System.Windows.Forms.RadioButton();
            this.rbtBefore = new System.Windows.Forms.RadioButton();
            this.grpPoint = new System.Windows.Forms.GroupBox();
            this.rbtOperOut = new System.Windows.Forms.RadioButton();
            this.rbtOperAt = new System.Windows.Forms.RadioButton();
            this.rbtOperIn = new System.Windows.Forms.RadioButton();
            this.tbpCondition = new System.Windows.Forms.TabPage();
            this.grpConditionList = new System.Windows.Forms.GroupBox();
            this.spdCond = new FarPoint.Win.Spread.FpSpread();
            this.spdCond_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtRelation = new System.Windows.Forms.TextBox();
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtFVUsage = new System.Windows.Forms.TextBox();
            this.cboValueType = new System.Windows.Forms.ComboBox();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.txtCond3 = new System.Windows.Forms.TextBox();
            this.txtCond2 = new System.Windows.Forms.RichTextBox();
            this.txtCond1 = new System.Windows.Forms.TextBox();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.cdvValue2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.cdvValue1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.lblValueType = new System.Windows.Forms.Label();
            this.cdvField = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblField = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblCondition = new System.Windows.Forms.Label();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF20 = new System.Windows.Forms.Label();
            this.lblCMF19 = new System.Windows.Forms.Label();
            this.lblCMF18 = new System.Windows.Forms.Label();
            this.lblCMF17 = new System.Windows.Forms.Label();
            this.lblCMF16 = new System.Windows.Forms.Label();
            this.lblCMF15 = new System.Windows.Forms.Label();
            this.lblCMF14 = new System.Windows.Forms.Label();
            this.lblCMF13 = new System.Windows.Forms.Label();
            this.lblCMF12 = new System.Windows.Forms.Label();
            this.lblCMF11 = new System.Windows.Forms.Label();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.splAction = new System.Windows.Forms.Splitter();
            this.tvAction = new System.Windows.Forms.TreeView();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlSetting.SuspendLayout();
            this.tabAction.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.grpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDependentAction)).BeginInit();
            this.pnlPoint.SuspendLayout();
            this.grpBA.SuspendLayout();
            this.grpPoint.SuspendLayout();
            this.tbpCondition.SuspendLayout();
            this.grpConditionList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCond_Sheet1)).BeginInit();
            this.grpCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvField)).BeginInit();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // splMain
            // 
            this.splMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnExpand);
            this.pnlRight.Controls.Add(this.btnCollapse);
            this.pnlRight.Controls.Add(this.pnlSetting);
            this.pnlRight.Controls.Add(this.splAction);
            this.pnlRight.Controls.Add(this.tvAction);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvMFO);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(371, 9);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(554, 8);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(463, 9);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(647, 9);
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
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
            // 
            // tvMFO
            // 
            this.tvMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMFO.IncludeFlowSeqNum = false;
            this.tvMFO.ListCond_ExtFactory = "";
            this.tvMFO.ListCond_Step = '1';
            this.tvMFO.Location = new System.Drawing.Point(0, 0);
            this.tvMFO.MaterialType = "";
            this.tvMFO.Name = "tvMFO";
            this.tvMFO.Size = new System.Drawing.Size(232, 506);
            this.tvMFO.TabIndex = 0;
            this.tvMFO.VisibleLevel1MFO = true;
            this.tvMFO.VisibleLevel2FO = true;
            this.tvMFO.VisibleLevel3O = true;
            this.tvMFO.VisibleLevel4MO = true;
            this.tvMFO.VisibleLevel5MF = false;
            this.tvMFO.VisibleLevel6M = false;
            this.tvMFO.VisibleLevel7F = false;
            this.tvMFO.VisibleLevel8Factory = false;
            this.tvMFO.VisibleMaterialIncludeDeleteCheck = false;
            this.tvMFO.VisibleMaterialType = false;
            this.tvMFO.VisibleOnlySetData = true;
            this.tvMFO.VisibleViewType = true;
            this.tvMFO.AfterGetTree += new System.EventHandler(this.tvMFO_AfterGetTree);
            this.tvMFO.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_AfterSelect);
            this.tvMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_LevelItemSelect);
            this.tvMFO.GetOnlySetData += new System.EventHandler(this.tvMFO_GetOnlySetData);
            this.tvMFO.SetDataSelectedIndexChanged += new System.EventHandler(this.tvMFO_SetDataSelectedIndexChanged);
            this.tvMFO.SelectLevelChanged += new System.EventHandler(this.tvMFO_SelectLevelChanged);
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.tabAction);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSetting.Location = new System.Drawing.Point(0, 164);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlSetting.Size = new System.Drawing.Size(506, 342);
            this.pnlSetting.TabIndex = 4;
            // 
            // tabAction
            // 
            this.tabAction.Controls.Add(this.tbpGeneral);
            this.tabAction.Controls.Add(this.tbpCondition);
            this.tabAction.Controls.Add(this.tbpCMF);
            this.tabAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAction.Location = new System.Drawing.Point(0, 3);
            this.tabAction.Name = "tabAction";
            this.tabAction.SelectedIndex = 0;
            this.tabAction.Size = new System.Drawing.Size(506, 339);
            this.tabAction.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.BackColor = System.Drawing.Color.Transparent;
            this.tbpGeneral.Controls.Add(this.pnlAction);
            this.tbpGeneral.Controls.Add(this.pnlPoint);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(498, 313);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.pnlActionValue);
            this.pnlAction.Controls.Add(this.grpAction);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAction.Location = new System.Drawing.Point(187, 3);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlAction.Size = new System.Drawing.Size(308, 307);
            this.pnlAction.TabIndex = 1;
            // 
            // pnlActionValue
            // 
            this.pnlActionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActionValue.Location = new System.Drawing.Point(3, 84);
            this.pnlActionValue.Name = "pnlActionValue";
            this.pnlActionValue.Size = new System.Drawing.Size(305, 223);
            this.pnlActionValue.TabIndex = 1;
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.cdvDependentAction);
            this.grpAction.Controls.Add(this.lblDependent);
            this.grpAction.Controls.Add(this.chkSkipService);
            this.grpAction.Controls.Add(this.txtComment);
            this.grpAction.Controls.Add(this.lblComment);
            this.grpAction.Controls.Add(this.cboTransaction);
            this.grpAction.Controls.Add(this.lblTransaction);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAction.Location = new System.Drawing.Point(3, 0);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(305, 84);
            this.grpAction.TabIndex = 0;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Action";
            // 
            // cdvDependentAction
            // 
            this.cdvDependentAction.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDependentAction.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDependentAction.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDependentAction.BtnToolTipText = "";
            this.cdvDependentAction.DescText = "";
            this.cdvDependentAction.DisplaySubItemIndex = -1;
            this.cdvDependentAction.DisplayText = "";
            this.cdvDependentAction.Focusing = null;
            this.cdvDependentAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDependentAction.Index = 0;
            this.cdvDependentAction.IsViewBtnImage = false;
            this.cdvDependentAction.Location = new System.Drawing.Point(94, 59);
            this.cdvDependentAction.MaxLength = 32767;
            this.cdvDependentAction.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDependentAction.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDependentAction.Name = "cdvDependentAction";
            this.cdvDependentAction.ReadOnly = true;
            this.cdvDependentAction.SearchSubItemIndex = 0;
            this.cdvDependentAction.SelectedDescIndex = -1;
            this.cdvDependentAction.SelectedSubItemIndex = -1;
            this.cdvDependentAction.SelectionStart = 0;
            this.cdvDependentAction.Size = new System.Drawing.Size(432, 20);
            this.cdvDependentAction.SmallImageList = null;
            this.cdvDependentAction.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDependentAction.TabIndex = 6;
            this.cdvDependentAction.TextBoxToolTipText = "";
            this.cdvDependentAction.TextBoxWidth = 150;
            this.cdvDependentAction.VisibleButton = true;
            this.cdvDependentAction.VisibleColumnHeader = false;
            this.cdvDependentAction.VisibleDescription = true;
            this.cdvDependentAction.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvDependentAction_SelectedItemChanged);
            this.cdvDependentAction.ButtonPress += new System.EventHandler(this.cdvDependentAction_ButtonPress);
            this.cdvDependentAction.TextBoxTextChanged += new System.EventHandler(this.cdvDependentAction_TextBoxTextChanged);
            // 
            // lblDependent
            // 
            this.lblDependent.AutoSize = true;
            this.lblDependent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependent.Location = new System.Drawing.Point(8, 63);
            this.lblDependent.Name = "lblDependent";
            this.lblDependent.Size = new System.Drawing.Size(60, 13);
            this.lblDependent.TabIndex = 5;
            this.lblDependent.Text = "Dependent";
            this.lblDependent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSkipService
            // 
            this.chkSkipService.AutoSize = true;
            this.chkSkipService.BackColor = System.Drawing.SystemColors.Control;
            this.chkSkipService.Enabled = false;
            this.chkSkipService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSkipService.Location = new System.Drawing.Point(270, 13);
            this.chkSkipService.Name = "chkSkipService";
            this.chkSkipService.Size = new System.Drawing.Size(179, 17);
            this.chkSkipService.TabIndex = 2;
            this.chkSkipService.Text = "Skip the originated service";
            this.chkSkipService.UseVisualStyleBackColor = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(94, 36);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(206, 20);
            this.txtComment.TabIndex = 4;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(8, 40);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 3;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTransaction
            // 
            this.cboTransaction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTransaction.FormattingEnabled = true;
            this.cboTransaction.Items.AddRange(new object[] {
            "HOLD",
            "END",
            "MOVE",
            "SKIP",
            "TERMINATE",
            "REWORK",
            "ADAPT",
            "STORE",
            "RAISE ALARM",
            "INPUT ATTRIBUTE",
            "ERROR ACTION",
            "CUSTOM ACTION"});
            this.cboTransaction.Location = new System.Drawing.Point(94, 12);
            this.cboTransaction.Name = "cboTransaction";
            this.cboTransaction.Size = new System.Drawing.Size(150, 21);
            this.cboTransaction.TabIndex = 1;
            this.cboTransaction.SelectedIndexChanged += new System.EventHandler(this.cboTransaction_SelectedIndexChanged);
            this.cboTransaction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // lblTransaction
            // 
            this.lblTransaction.AutoSize = true;
            this.lblTransaction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransaction.Location = new System.Drawing.Point(8, 16);
            this.lblTransaction.Name = "lblTransaction";
            this.lblTransaction.Size = new System.Drawing.Size(63, 13);
            this.lblTransaction.TabIndex = 0;
            this.lblTransaction.Text = "Transaction";
            this.lblTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPoint
            // 
            this.pnlPoint.Controls.Add(this.chkAll);
            this.pnlPoint.Controls.Add(this.lisServices);
            this.pnlPoint.Controls.Add(this.grpBA);
            this.pnlPoint.Controls.Add(this.grpPoint);
            this.pnlPoint.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPoint.Location = new System.Drawing.Point(3, 3);
            this.pnlPoint.Name = "pnlPoint";
            this.pnlPoint.Size = new System.Drawing.Size(184, 307);
            this.pnlPoint.TabIndex = 0;
            // 
            // chkAll
            // 
            this.chkAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAll.Location = new System.Drawing.Point(7, 77);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 15);
            this.chkAll.TabIndex = 3;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lisServices
            // 
            this.lisServices.CheckBoxes = true;
            this.lisServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCheck,
            this.colServices});
            this.lisServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisServices.EnableSort = true;
            this.lisServices.EnableSortIcon = true;
            this.lisServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisServices.FullRowSelect = true;
            this.lisServices.Location = new System.Drawing.Point(0, 72);
            this.lisServices.Name = "lisServices";
            this.lisServices.Size = new System.Drawing.Size(184, 235);
            this.lisServices.TabIndex = 2;
            this.lisServices.UseCompatibleStateImageBehavior = false;
            this.lisServices.View = System.Windows.Forms.View.Details;
            // 
            // colCheck
            // 
            this.colCheck.Text = "";
            this.colCheck.Width = 24;
            // 
            // colServices
            // 
            this.colServices.Text = "Originated Services";
            this.colServices.Width = 138;
            // 
            // grpBA
            // 
            this.grpBA.Controls.Add(this.rbtAfter);
            this.grpBA.Controls.Add(this.rbtBefore);
            this.grpBA.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBA.Location = new System.Drawing.Point(0, 36);
            this.grpBA.Name = "grpBA";
            this.grpBA.Size = new System.Drawing.Size(184, 36);
            this.grpBA.TabIndex = 1;
            this.grpBA.TabStop = false;
            this.grpBA.Text = "Before / After Section of Service";
            // 
            // rbtAfter
            // 
            this.rbtAfter.AutoSize = true;
            this.rbtAfter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtAfter.Location = new System.Drawing.Point(113, 15);
            this.rbtAfter.Name = "rbtAfter";
            this.rbtAfter.Size = new System.Drawing.Size(54, 17);
            this.rbtAfter.TabIndex = 1;
            this.rbtAfter.TabStop = true;
            this.rbtAfter.Text = "After";
            this.rbtAfter.UseVisualStyleBackColor = true;
            this.rbtAfter.CheckedChanged += new System.EventHandler(this.rbtBA_CheckedChanged);
            // 
            // rbtBefore
            // 
            this.rbtBefore.AutoSize = true;
            this.rbtBefore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtBefore.Location = new System.Drawing.Point(20, 15);
            this.rbtBefore.Name = "rbtBefore";
            this.rbtBefore.Size = new System.Drawing.Size(65, 17);
            this.rbtBefore.TabIndex = 0;
            this.rbtBefore.TabStop = true;
            this.rbtBefore.Text = "Before";
            this.rbtBefore.UseVisualStyleBackColor = true;
            this.rbtBefore.CheckedChanged += new System.EventHandler(this.rbtBA_CheckedChanged);
            // 
            // grpPoint
            // 
            this.grpPoint.Controls.Add(this.rbtOperOut);
            this.grpPoint.Controls.Add(this.rbtOperAt);
            this.grpPoint.Controls.Add(this.rbtOperIn);
            this.grpPoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPoint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPoint.Location = new System.Drawing.Point(0, 0);
            this.grpPoint.Name = "grpPoint";
            this.grpPoint.Size = new System.Drawing.Size(184, 36);
            this.grpPoint.TabIndex = 0;
            this.grpPoint.TabStop = false;
            this.grpPoint.Text = "Operation Point";
            // 
            // rbtOperOut
            // 
            this.rbtOperOut.AutoSize = true;
            this.rbtOperOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtOperOut.Location = new System.Drawing.Point(113, 15);
            this.rbtOperOut.Name = "rbtOperOut";
            this.rbtOperOut.Size = new System.Drawing.Size(48, 17);
            this.rbtOperOut.TabIndex = 2;
            this.rbtOperOut.TabStop = true;
            this.rbtOperOut.Text = "Out";
            this.rbtOperOut.UseVisualStyleBackColor = true;
            this.rbtOperOut.CheckedChanged += new System.EventHandler(this.rbtOperPoint_CheckedChanged);
            // 
            // rbtOperAt
            // 
            this.rbtOperAt.AutoSize = true;
            this.rbtOperAt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtOperAt.Location = new System.Drawing.Point(66, 15);
            this.rbtOperAt.Name = "rbtOperAt";
            this.rbtOperAt.Size = new System.Drawing.Size(40, 17);
            this.rbtOperAt.TabIndex = 1;
            this.rbtOperAt.TabStop = true;
            this.rbtOperAt.Text = "At";
            this.rbtOperAt.UseVisualStyleBackColor = true;
            this.rbtOperAt.CheckedChanged += new System.EventHandler(this.rbtOperPoint_CheckedChanged);
            // 
            // rbtOperIn
            // 
            this.rbtOperIn.AutoSize = true;
            this.rbtOperIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtOperIn.Location = new System.Drawing.Point(20, 15);
            this.rbtOperIn.Name = "rbtOperIn";
            this.rbtOperIn.Size = new System.Drawing.Size(39, 17);
            this.rbtOperIn.TabIndex = 0;
            this.rbtOperIn.TabStop = true;
            this.rbtOperIn.Text = "In";
            this.rbtOperIn.UseVisualStyleBackColor = true;
            this.rbtOperIn.CheckedChanged += new System.EventHandler(this.rbtOperPoint_CheckedChanged);
            // 
            // tbpCondition
            // 
            this.tbpCondition.BackColor = System.Drawing.Color.Transparent;
            this.tbpCondition.Controls.Add(this.grpConditionList);
            this.tbpCondition.Controls.Add(this.grpCondition);
            this.tbpCondition.Location = new System.Drawing.Point(4, 22);
            this.tbpCondition.Name = "tbpCondition";
            this.tbpCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCondition.Size = new System.Drawing.Size(498, 313);
            this.tbpCondition.TabIndex = 2;
            this.tbpCondition.Text = "Conditions";
            // 
            // grpConditionList
            // 
            this.grpConditionList.Controls.Add(this.spdCond);
            this.grpConditionList.Controls.Add(this.txtRelation);
            this.grpConditionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConditionList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpConditionList.Location = new System.Drawing.Point(3, 240);
            this.grpConditionList.Name = "grpConditionList";
            this.grpConditionList.Size = new System.Drawing.Size(492, 70);
            this.grpConditionList.TabIndex = 1;
            this.grpConditionList.TabStop = false;
            this.grpConditionList.Text = "Condition lists with logical relationship";
            // 
            // spdCond
            // 
            this.spdCond.AccessibleDescription = "spdCond, Sheet1, Row 0, Column 0, ";
            this.spdCond.BackColor = System.Drawing.SystemColors.Control;
            this.spdCond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCond.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdCond.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCond.HorizontalScrollBar.Name = "";
            this.spdCond.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdCond.HorizontalScrollBar.TabIndex = 6;
            this.spdCond.Location = new System.Drawing.Point(3, 17);
            this.spdCond.Name = "spdCond";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.Renderer = columnHeaderRenderer2;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = rowHeaderRenderer2;
            namedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle7.BackColor = System.Drawing.SystemColors.Control;
            namedStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle7.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle7.Renderer = cornerRenderer2;
            namedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle8.BackColor = System.Drawing.SystemColors.Window;
            namedStyle8.CellType = generalCellType2;
            namedStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle8.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle8.Renderer = generalCellType2;
            this.spdCond.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdCond.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdCond.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCond.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCond.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCond_Sheet1});
            this.spdCond.Size = new System.Drawing.Size(486, 37);
            this.spdCond.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCond.TabIndex = 0;
            this.spdCond.TabStop = false;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdCond.TextTipAppearance = tipAppearance2;
            this.spdCond.TextTipDelay = 200;
            this.spdCond.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCond.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCond.VerticalScrollBar.Name = "";
            this.spdCond.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdCond.VerticalScrollBar.TabIndex = 7;
            this.spdCond.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCond_CellClick);
            this.spdCond.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCond_ComboCloseUp);
            this.spdCond.SetViewportLeftColumn(0, 0, 1);
            this.spdCond.SetActiveViewport(0, 0, -1);
            // 
            // spdCond_Sheet1
            // 
            this.spdCond_Sheet1.Reset();
            spdCond_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCond_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCond_Sheet1.ColumnCount = 9;
            spdCond_Sheet1.RowCount = 3;
            this.spdCond_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdCond_Sheet1.Cells.Get(0, 2).Locked = true;
            this.spdCond_Sheet1.Cells.Get(0, 3).Locked = true;
            this.spdCond_Sheet1.Cells.Get(0, 4).Locked = true;
            this.spdCond_Sheet1.Cells.Get(0, 5).Locked = true;
            this.spdCond_Sheet1.Cells.Get(0, 6).Locked = true;
            this.spdCond_Sheet1.Cells.Get(0, 7).Locked = true;
            this.spdCond_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCond_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCond_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCond_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCond_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "AND/OR";
            this.spdCond_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Left \"(\"";
            this.spdCond_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Condition";
            this.spdCond_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Field";
            this.spdCond_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Operator";
            this.spdCond_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Value Type";
            this.spdCond_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Value 1";
            this.spdCond_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Value 2";
            this.spdCond_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Right \")\"";
            this.spdCond_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCond_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCond_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            comboBoxCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType4.Items = new string[] {
        "AND",
        "OR"};
            this.spdCond_Sheet1.Columns.Get(0).CellType = comboBoxCellType4;
            this.spdCond_Sheet1.Columns.Get(0).Label = "AND/OR";
            this.spdCond_Sheet1.Columns.Get(0).Width = 51F;
            comboBoxCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType5.Items = new string[] {
        "(",
        "((",
        "(((",
        "((((",
        "(((((",
        ""};
            this.spdCond_Sheet1.Columns.Get(1).CellType = comboBoxCellType5;
            this.spdCond_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCond_Sheet1.Columns.Get(1).Label = "Left \"(\"";
            this.spdCond_Sheet1.Columns.Get(1).Width = 50F;
            this.spdCond_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.spdCond_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCond_Sheet1.Columns.Get(2).Label = "Condition";
            this.spdCond_Sheet1.Columns.Get(2).Locked = true;
            this.spdCond_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCond_Sheet1.Columns.Get(2).Width = 90F;
            this.spdCond_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCond_Sheet1.Columns.Get(3).Label = "Field";
            this.spdCond_Sheet1.Columns.Get(3).Locked = true;
            this.spdCond_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCond_Sheet1.Columns.Get(3).Width = 95F;
            this.spdCond_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCond_Sheet1.Columns.Get(4).Label = "Operator";
            this.spdCond_Sheet1.Columns.Get(4).Locked = true;
            this.spdCond_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCond_Sheet1.Columns.Get(4).Width = 50F;
            this.spdCond_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCond_Sheet1.Columns.Get(5).Label = "Value Type";
            this.spdCond_Sheet1.Columns.Get(5).Locked = true;
            this.spdCond_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCond_Sheet1.Columns.Get(5).Width = 90F;
            this.spdCond_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCond_Sheet1.Columns.Get(6).Label = "Value 1";
            this.spdCond_Sheet1.Columns.Get(6).Locked = true;
            this.spdCond_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCond_Sheet1.Columns.Get(6).Width = 90F;
            this.spdCond_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCond_Sheet1.Columns.Get(7).Label = "Value 2";
            this.spdCond_Sheet1.Columns.Get(7).Locked = true;
            this.spdCond_Sheet1.Columns.Get(7).Width = 90F;
            comboBoxCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType6.Items = new string[] {
        ")",
        "))",
        ")))",
        "))))",
        ")))))",
        ""};
            this.spdCond_Sheet1.Columns.Get(8).CellType = comboBoxCellType6;
            this.spdCond_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCond_Sheet1.Columns.Get(8).Label = "Right \")\"";
            this.spdCond_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCond_Sheet1.Columns.Get(8).Width = 50F;
            this.spdCond_Sheet1.FrozenColumnCount = 1;
            this.spdCond_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCond_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCond_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCond_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCond_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCond_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCond_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtRelation
            // 
            this.txtRelation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRelation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtRelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelation.Location = new System.Drawing.Point(3, 54);
            this.txtRelation.Name = "txtRelation";
            this.txtRelation.ReadOnly = true;
            this.txtRelation.Size = new System.Drawing.Size(486, 13);
            this.txtRelation.TabIndex = 1;
            this.txtRelation.Text = "((1 AND 2) OR (3 AND 4)) AND 5";
            // 
            // grpCondition
            // 
            this.grpCondition.Controls.Add(this.btnAdd);
            this.grpCondition.Controls.Add(this.txtFVUsage);
            this.grpCondition.Controls.Add(this.cboValueType);
            this.grpCondition.Controls.Add(this.cboCondition);
            this.grpCondition.Controls.Add(this.txtCond3);
            this.grpCondition.Controls.Add(this.txtCond2);
            this.grpCondition.Controls.Add(this.txtCond1);
            this.grpCondition.Controls.Add(this.cboOperator);
            this.grpCondition.Controls.Add(this.btnRemove);
            this.grpCondition.Controls.Add(this.btnModify);
            this.grpCondition.Controls.Add(this.cdvValue2);
            this.grpCondition.Controls.Add(this.lblValue2);
            this.grpCondition.Controls.Add(this.cdvValue1);
            this.grpCondition.Controls.Add(this.lblValue1);
            this.grpCondition.Controls.Add(this.lblValueType);
            this.grpCondition.Controls.Add(this.cdvField);
            this.grpCondition.Controls.Add(this.lblField);
            this.grpCondition.Controls.Add(this.lblOperator);
            this.grpCondition.Controls.Add(this.lblCondition);
            this.grpCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCondition.Location = new System.Drawing.Point(3, 3);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(492, 237);
            this.grpCondition.TabIndex = 0;
            this.grpCondition.TabStop = false;
            this.grpCondition.Text = "Conditions";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(276, 208);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 24);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtFVUsage
            // 
            this.txtFVUsage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFVUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFVUsage.Location = new System.Drawing.Point(624, 41);
            this.txtFVUsage.Multiline = true;
            this.txtFVUsage.Name = "txtFVUsage";
            this.txtFVUsage.ReadOnly = true;
            this.txtFVUsage.Size = new System.Drawing.Size(135, 35);
            this.txtFVUsage.TabIndex = 17;
            this.txtFVUsage.Text = "Wild card\r\n  %, _, $BLANK, $NULL";
            this.txtFVUsage.Visible = false;
            // 
            // cboValueType
            // 
            this.cboValueType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboValueType.FormattingEnabled = true;
            this.cboValueType.Items.AddRange(new object[] {
            "Fixed Value",
            "GCM Table",
            "User SQL"});
            this.cboValueType.Location = new System.Drawing.Point(419, 12);
            this.cboValueType.Name = "cboValueType";
            this.cboValueType.Size = new System.Drawing.Size(200, 21);
            this.cboValueType.TabIndex = 7;
            this.cboValueType.SelectedIndexChanged += new System.EventHandler(this.cboValueType_SelectedIndexChanged);
            this.cboValueType.TextChanged += new System.EventHandler(this.cboValueType_TextChanged);
            this.cboValueType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // cboCondition
            // 
            this.cboCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Items.AddRange(new object[] {
            "Lot Status",
            "Lot Attribute",
            "Sublot Status",
            "Sublot Attribute",
            "Custom Condition"});
            this.cboCondition.Location = new System.Drawing.Point(90, 12);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(180, 21);
            this.cboCondition.TabIndex = 1;
            this.cboCondition.SelectedIndexChanged += new System.EventHandler(this.cboCondition_SelectedIndexChanged);
            this.cboCondition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // txtCond3
            // 
            this.txtCond3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCond3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCond3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCond3.Location = new System.Drawing.Point(6, 206);
            this.txtCond3.Multiline = true;
            this.txtCond3.Name = "txtCond3";
            this.txtCond3.ReadOnly = true;
            this.txtCond3.Size = new System.Drawing.Size(262, 28);
            this.txtCond3.TabIndex = 14;
            this.txtCond3.Text = ")  // Can be use all columns of lot status to WHERE statement\r\n       ($FACTORY, " +
                "$LOT_ID, $MAT_ID, $QTY_1, ...)";
            // 
            // txtCond2
            // 
            this.txtCond2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCond2.Location = new System.Drawing.Point(6, 122);
            this.txtCond2.MaxLength = 7998;
            this.txtCond2.Name = "txtCond2";
            this.txtCond2.Size = new System.Drawing.Size(480, 81);
            this.txtCond2.TabIndex = 13;
            this.txtCond2.Text = "";
            this.txtCond2.Leave += new System.EventHandler(this.txtCond2_Leave);
            // 
            // txtCond1
            // 
            this.txtCond1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCond1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCond1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCond1.Location = new System.Drawing.Point(6, 91);
            this.txtCond1.Multiline = true;
            this.txtCond1.Name = "txtCond1";
            this.txtCond1.ReadOnly = true;
            this.txtCond1.Size = new System.Drawing.Size(480, 27);
            this.txtCond1.TabIndex = 12;
            this.txtCond1.Text = "select count(*) from MATRNAMSTS where factory = $FACTORY and attr_type = \'LOT\' an" +
                "d attr_key = $LOT_ID and attr_name = \"ADMASSDFSDFSDFSDFSDFSDFSDFSDFSDF\" and attr" +
                "_value = (";
            // 
            // cboOperator
            // 
            this.cboOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Items.AddRange(new object[] {
            "=",
            "!=",
            ">",
            ">=",
            "<",
            "<=",
            "IN",
            "NOT IN",
            "LIKE",
            "NOT LIKE",
            "IS",
            "IS NOT"});
            this.cboOperator.Location = new System.Drawing.Point(90, 61);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(180, 21);
            this.cboOperator.TabIndex = 5;
            this.cboOperator.SelectedIndexChanged += new System.EventHandler(this.cboOperator_SelectedIndexChanged);
            this.cboOperator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(418, 208);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(68, 24);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(347, 208);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(68, 24);
            this.btnModify.TabIndex = 16;
            this.btnModify.Text = "Modify";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // cdvValue2
            // 
            this.cdvValue2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue2.BtnToolTipText = "";
            this.cdvValue2.DescText = "";
            this.cdvValue2.DisplaySubItemIndex = -1;
            this.cdvValue2.DisplayText = "";
            this.cdvValue2.Focusing = null;
            this.cdvValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue2.Index = 0;
            this.cdvValue2.IsViewBtnImage = false;
            this.cdvValue2.Location = new System.Drawing.Point(419, 61);
            this.cdvValue2.MaxLength = 255;
            this.cdvValue2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue2.Name = "cdvValue2";
            this.cdvValue2.ReadOnly = true;
            this.cdvValue2.SearchSubItemIndex = 0;
            this.cdvValue2.SelectedDescIndex = -1;
            this.cdvValue2.SelectedSubItemIndex = -1;
            this.cdvValue2.SelectionStart = 0;
            this.cdvValue2.Size = new System.Drawing.Size(200, 20);
            this.cdvValue2.SmallImageList = null;
            this.cdvValue2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue2.TabIndex = 11;
            this.cdvValue2.TextBoxToolTipText = "";
            this.cdvValue2.TextBoxWidth = 200;
            this.cdvValue2.Visible = false;
            this.cdvValue2.VisibleButton = true;
            this.cdvValue2.VisibleColumnHeader = false;
            this.cdvValue2.VisibleDescription = false;
            this.cdvValue2.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvValue2_SelectedItemChanged);
            this.cdvValue2.ButtonPress += new System.EventHandler(this.cdvValue2_ButtonPress);
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue2.Location = new System.Drawing.Point(318, 64);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(73, 13);
            this.lblValue2.TabIndex = 10;
            this.lblValue2.Text = "Column Name";
            this.lblValue2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValue2.Visible = false;
            // 
            // cdvValue1
            // 
            this.cdvValue1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue1.BtnToolTipText = "";
            this.cdvValue1.DescText = "";
            this.cdvValue1.DisplaySubItemIndex = -1;
            this.cdvValue1.DisplayText = "";
            this.cdvValue1.Focusing = null;
            this.cdvValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue1.Index = 0;
            this.cdvValue1.IsViewBtnImage = false;
            this.cdvValue1.Location = new System.Drawing.Point(419, 37);
            this.cdvValue1.MaxLength = 255;
            this.cdvValue1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue1.Name = "cdvValue1";
            this.cdvValue1.ReadOnly = true;
            this.cdvValue1.SearchSubItemIndex = 0;
            this.cdvValue1.SelectedDescIndex = -1;
            this.cdvValue1.SelectedSubItemIndex = -1;
            this.cdvValue1.SelectionStart = 0;
            this.cdvValue1.Size = new System.Drawing.Size(200, 20);
            this.cdvValue1.SmallImageList = null;
            this.cdvValue1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue1.TabIndex = 9;
            this.cdvValue1.TextBoxToolTipText = "";
            this.cdvValue1.TextBoxWidth = 200;
            this.cdvValue1.Visible = false;
            this.cdvValue1.VisibleButton = true;
            this.cdvValue1.VisibleColumnHeader = false;
            this.cdvValue1.VisibleDescription = false;
            this.cdvValue1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvValue1_SelectedItemChanged);
            this.cdvValue1.ButtonPress += new System.EventHandler(this.cdvValue1_ButtonPress);
            this.cdvValue1.TextBoxTextChanged += new System.EventHandler(this.cdvValue1_TextBoxTextChanged);
            // 
            // lblValue1
            // 
            this.lblValue1.AutoSize = true;
            this.lblValue1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue1.Location = new System.Drawing.Point(318, 40);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(65, 13);
            this.lblValue1.TabIndex = 8;
            this.lblValue1.Text = "Table Name";
            this.lblValue1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValue1.Visible = false;
            // 
            // lblValueType
            // 
            this.lblValueType.AutoSize = true;
            this.lblValueType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValueType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueType.Location = new System.Drawing.Point(318, 15);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(61, 13);
            this.lblValueType.TabIndex = 6;
            this.lblValueType.Text = "Value Type";
            this.lblValueType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvField
            // 
            this.cdvField.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvField.BorderHotColor = System.Drawing.Color.Black;
            this.cdvField.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvField.BtnToolTipText = "";
            this.cdvField.DescText = "";
            this.cdvField.DisplaySubItemIndex = -1;
            this.cdvField.DisplayText = "";
            this.cdvField.Focusing = null;
            this.cdvField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvField.Index = 0;
            this.cdvField.IsViewBtnImage = false;
            this.cdvField.Location = new System.Drawing.Point(90, 37);
            this.cdvField.MaxLength = 100;
            this.cdvField.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvField.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvField.Name = "cdvField";
            this.cdvField.ReadOnly = true;
            this.cdvField.SearchSubItemIndex = 0;
            this.cdvField.SelectedDescIndex = -1;
            this.cdvField.SelectedSubItemIndex = -1;
            this.cdvField.SelectionStart = 0;
            this.cdvField.Size = new System.Drawing.Size(180, 20);
            this.cdvField.SmallImageList = null;
            this.cdvField.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvField.TabIndex = 3;
            this.cdvField.TextBoxToolTipText = "";
            this.cdvField.TextBoxWidth = 180;
            this.cdvField.VisibleButton = true;
            this.cdvField.VisibleColumnHeader = false;
            this.cdvField.VisibleDescription = false;
            this.cdvField.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvField_SelectedItemChanged);
            this.cdvField.ButtonPress += new System.EventHandler(this.cdvField_ButtonPress);
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblField.Location = new System.Drawing.Point(10, 40);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(29, 13);
            this.lblField.TabIndex = 2;
            this.lblField.Text = "Field";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.Location = new System.Drawing.Point(10, 64);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(48, 13);
            this.lblOperator.TabIndex = 4;
            this.lblOperator.Text = "Operator";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondition.Location = new System.Drawing.Point(10, 15);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(51, 13);
            this.lblCondition.TabIndex = 0;
            this.lblCondition.Text = "Condition";
            this.lblCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCMF
            // 
            this.tbpCMF.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCMF.Size = new System.Drawing.Size(498, 313);
            this.tbpCMF.TabIndex = 1;
            this.tbpCMF.Text = "Customized Field";
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF19);
            this.grpCMF.Controls.Add(this.cdvCMF18);
            this.grpCMF.Controls.Add(this.cdvCMF17);
            this.grpCMF.Controls.Add(this.cdvCMF16);
            this.grpCMF.Controls.Add(this.cdvCMF15);
            this.grpCMF.Controls.Add(this.cdvCMF14);
            this.grpCMF.Controls.Add(this.cdvCMF13);
            this.grpCMF.Controls.Add(this.cdvCMF12);
            this.grpCMF.Controls.Add(this.cdvCMF20);
            this.grpCMF.Controls.Add(this.cdvCMF11);
            this.grpCMF.Controls.Add(this.lblCMF20);
            this.grpCMF.Controls.Add(this.lblCMF19);
            this.grpCMF.Controls.Add(this.lblCMF18);
            this.grpCMF.Controls.Add(this.lblCMF17);
            this.grpCMF.Controls.Add(this.lblCMF16);
            this.grpCMF.Controls.Add(this.lblCMF15);
            this.grpCMF.Controls.Add(this.lblCMF14);
            this.grpCMF.Controls.Add(this.lblCMF13);
            this.grpCMF.Controls.Add(this.lblCMF12);
            this.grpCMF.Controls.Add(this.lblCMF11);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.Location = new System.Drawing.Point(3, 3);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(492, 307);
            this.grpCMF.TabIndex = 1;
            this.grpCMF.TabStop = false;
            this.grpCMF.Text = "Customized Field (1~20)";
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF19.BtnToolTipText = "";
            this.cdvCMF19.DescText = "";
            this.cdvCMF19.DisplaySubItemIndex = -1;
            this.cdvCMF19.DisplayText = "";
            this.cdvCMF19.Focusing = null;
            this.cdvCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF19.Index = 0;
            this.cdvCMF19.IsViewBtnImage = false;
            this.cdvCMF19.Location = new System.Drawing.Point(351, 210);
            this.cdvCMF19.MaxLength = 30;
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.Name = "cdvCMF19";
            this.cdvCMF19.ReadOnly = false;
            this.cdvCMF19.SearchSubItemIndex = 0;
            this.cdvCMF19.SelectedDescIndex = -1;
            this.cdvCMF19.SelectedSubItemIndex = -1;
            this.cdvCMF19.SelectionStart = 0;
            this.cdvCMF19.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF19.SmallImageList = null;
            this.cdvCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF19.TabIndex = 37;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 135;
            this.cdvCMF19.VisibleButton = true;
            this.cdvCMF19.VisibleColumnHeader = false;
            this.cdvCMF19.VisibleDescription = false;
            this.cdvCMF19.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF18.BtnToolTipText = "";
            this.cdvCMF18.DescText = "";
            this.cdvCMF18.DisplaySubItemIndex = -1;
            this.cdvCMF18.DisplayText = "";
            this.cdvCMF18.Focusing = null;
            this.cdvCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF18.Index = 0;
            this.cdvCMF18.IsViewBtnImage = false;
            this.cdvCMF18.Location = new System.Drawing.Point(351, 186);
            this.cdvCMF18.MaxLength = 30;
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.Name = "cdvCMF18";
            this.cdvCMF18.ReadOnly = false;
            this.cdvCMF18.SearchSubItemIndex = 0;
            this.cdvCMF18.SelectedDescIndex = -1;
            this.cdvCMF18.SelectedSubItemIndex = -1;
            this.cdvCMF18.SelectionStart = 0;
            this.cdvCMF18.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF18.SmallImageList = null;
            this.cdvCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF18.TabIndex = 35;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 135;
            this.cdvCMF18.VisibleButton = true;
            this.cdvCMF18.VisibleColumnHeader = false;
            this.cdvCMF18.VisibleDescription = false;
            this.cdvCMF18.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF17.BtnToolTipText = "";
            this.cdvCMF17.DescText = "";
            this.cdvCMF17.DisplaySubItemIndex = -1;
            this.cdvCMF17.DisplayText = "";
            this.cdvCMF17.Focusing = null;
            this.cdvCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF17.Index = 0;
            this.cdvCMF17.IsViewBtnImage = false;
            this.cdvCMF17.Location = new System.Drawing.Point(351, 162);
            this.cdvCMF17.MaxLength = 30;
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.Name = "cdvCMF17";
            this.cdvCMF17.ReadOnly = false;
            this.cdvCMF17.SearchSubItemIndex = 0;
            this.cdvCMF17.SelectedDescIndex = -1;
            this.cdvCMF17.SelectedSubItemIndex = -1;
            this.cdvCMF17.SelectionStart = 0;
            this.cdvCMF17.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF17.SmallImageList = null;
            this.cdvCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF17.TabIndex = 33;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 135;
            this.cdvCMF17.VisibleButton = true;
            this.cdvCMF17.VisibleColumnHeader = false;
            this.cdvCMF17.VisibleDescription = false;
            this.cdvCMF17.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF16.BtnToolTipText = "";
            this.cdvCMF16.DescText = "";
            this.cdvCMF16.DisplaySubItemIndex = -1;
            this.cdvCMF16.DisplayText = "";
            this.cdvCMF16.Focusing = null;
            this.cdvCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF16.Index = 0;
            this.cdvCMF16.IsViewBtnImage = false;
            this.cdvCMF16.Location = new System.Drawing.Point(351, 138);
            this.cdvCMF16.MaxLength = 30;
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.Name = "cdvCMF16";
            this.cdvCMF16.ReadOnly = false;
            this.cdvCMF16.SearchSubItemIndex = 0;
            this.cdvCMF16.SelectedDescIndex = -1;
            this.cdvCMF16.SelectedSubItemIndex = -1;
            this.cdvCMF16.SelectionStart = 0;
            this.cdvCMF16.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF16.SmallImageList = null;
            this.cdvCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF16.TabIndex = 31;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 135;
            this.cdvCMF16.VisibleButton = true;
            this.cdvCMF16.VisibleColumnHeader = false;
            this.cdvCMF16.VisibleDescription = false;
            this.cdvCMF16.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF15.BtnToolTipText = "";
            this.cdvCMF15.DescText = "";
            this.cdvCMF15.DisplaySubItemIndex = -1;
            this.cdvCMF15.DisplayText = "";
            this.cdvCMF15.Focusing = null;
            this.cdvCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF15.Index = 0;
            this.cdvCMF15.IsViewBtnImage = false;
            this.cdvCMF15.Location = new System.Drawing.Point(351, 114);
            this.cdvCMF15.MaxLength = 30;
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.Name = "cdvCMF15";
            this.cdvCMF15.ReadOnly = false;
            this.cdvCMF15.SearchSubItemIndex = 0;
            this.cdvCMF15.SelectedDescIndex = -1;
            this.cdvCMF15.SelectedSubItemIndex = -1;
            this.cdvCMF15.SelectionStart = 0;
            this.cdvCMF15.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF15.SmallImageList = null;
            this.cdvCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF15.TabIndex = 29;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 135;
            this.cdvCMF15.VisibleButton = true;
            this.cdvCMF15.VisibleColumnHeader = false;
            this.cdvCMF15.VisibleDescription = false;
            this.cdvCMF15.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF14.BtnToolTipText = "";
            this.cdvCMF14.DescText = "";
            this.cdvCMF14.DisplaySubItemIndex = -1;
            this.cdvCMF14.DisplayText = "";
            this.cdvCMF14.Focusing = null;
            this.cdvCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF14.Index = 0;
            this.cdvCMF14.IsViewBtnImage = false;
            this.cdvCMF14.Location = new System.Drawing.Point(351, 90);
            this.cdvCMF14.MaxLength = 30;
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.Name = "cdvCMF14";
            this.cdvCMF14.ReadOnly = false;
            this.cdvCMF14.SearchSubItemIndex = 0;
            this.cdvCMF14.SelectedDescIndex = -1;
            this.cdvCMF14.SelectedSubItemIndex = -1;
            this.cdvCMF14.SelectionStart = 0;
            this.cdvCMF14.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF14.SmallImageList = null;
            this.cdvCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF14.TabIndex = 27;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 135;
            this.cdvCMF14.VisibleButton = true;
            this.cdvCMF14.VisibleColumnHeader = false;
            this.cdvCMF14.VisibleDescription = false;
            this.cdvCMF14.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF13.BtnToolTipText = "";
            this.cdvCMF13.DescText = "";
            this.cdvCMF13.DisplaySubItemIndex = -1;
            this.cdvCMF13.DisplayText = "";
            this.cdvCMF13.Focusing = null;
            this.cdvCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF13.Index = 0;
            this.cdvCMF13.IsViewBtnImage = false;
            this.cdvCMF13.Location = new System.Drawing.Point(351, 66);
            this.cdvCMF13.MaxLength = 30;
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.Name = "cdvCMF13";
            this.cdvCMF13.ReadOnly = false;
            this.cdvCMF13.SearchSubItemIndex = 0;
            this.cdvCMF13.SelectedDescIndex = -1;
            this.cdvCMF13.SelectedSubItemIndex = -1;
            this.cdvCMF13.SelectionStart = 0;
            this.cdvCMF13.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF13.SmallImageList = null;
            this.cdvCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF13.TabIndex = 25;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 135;
            this.cdvCMF13.VisibleButton = true;
            this.cdvCMF13.VisibleColumnHeader = false;
            this.cdvCMF13.VisibleDescription = false;
            this.cdvCMF13.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF12.BtnToolTipText = "";
            this.cdvCMF12.DescText = "";
            this.cdvCMF12.DisplaySubItemIndex = -1;
            this.cdvCMF12.DisplayText = "";
            this.cdvCMF12.Focusing = null;
            this.cdvCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF12.Index = 0;
            this.cdvCMF12.IsViewBtnImage = false;
            this.cdvCMF12.Location = new System.Drawing.Point(351, 42);
            this.cdvCMF12.MaxLength = 30;
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.Name = "cdvCMF12";
            this.cdvCMF12.ReadOnly = false;
            this.cdvCMF12.SearchSubItemIndex = 0;
            this.cdvCMF12.SelectedDescIndex = -1;
            this.cdvCMF12.SelectedSubItemIndex = -1;
            this.cdvCMF12.SelectionStart = 0;
            this.cdvCMF12.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF12.SmallImageList = null;
            this.cdvCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF12.TabIndex = 23;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 135;
            this.cdvCMF12.VisibleButton = true;
            this.cdvCMF12.VisibleColumnHeader = false;
            this.cdvCMF12.VisibleDescription = false;
            this.cdvCMF12.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF20.BtnToolTipText = "";
            this.cdvCMF20.DescText = "";
            this.cdvCMF20.DisplaySubItemIndex = -1;
            this.cdvCMF20.DisplayText = "";
            this.cdvCMF20.Focusing = null;
            this.cdvCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF20.Index = 0;
            this.cdvCMF20.IsViewBtnImage = false;
            this.cdvCMF20.Location = new System.Drawing.Point(351, 234);
            this.cdvCMF20.MaxLength = 30;
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.Name = "cdvCMF20";
            this.cdvCMF20.ReadOnly = false;
            this.cdvCMF20.SearchSubItemIndex = 0;
            this.cdvCMF20.SelectedDescIndex = -1;
            this.cdvCMF20.SelectedSubItemIndex = -1;
            this.cdvCMF20.SelectionStart = 0;
            this.cdvCMF20.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF20.SmallImageList = null;
            this.cdvCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF20.TabIndex = 39;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 135;
            this.cdvCMF20.VisibleButton = true;
            this.cdvCMF20.VisibleColumnHeader = false;
            this.cdvCMF20.VisibleDescription = false;
            this.cdvCMF20.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF11.BtnToolTipText = "";
            this.cdvCMF11.DescText = "";
            this.cdvCMF11.DisplaySubItemIndex = -1;
            this.cdvCMF11.DisplayText = "";
            this.cdvCMF11.Focusing = null;
            this.cdvCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF11.Index = 0;
            this.cdvCMF11.IsViewBtnImage = false;
            this.cdvCMF11.Location = new System.Drawing.Point(351, 18);
            this.cdvCMF11.MaxLength = 30;
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.Name = "cdvCMF11";
            this.cdvCMF11.ReadOnly = false;
            this.cdvCMF11.SearchSubItemIndex = 0;
            this.cdvCMF11.SelectedDescIndex = -1;
            this.cdvCMF11.SelectedSubItemIndex = -1;
            this.cdvCMF11.SelectionStart = 0;
            this.cdvCMF11.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF11.SmallImageList = null;
            this.cdvCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF11.TabIndex = 21;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 135;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            this.cdvCMF11.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(257, 238);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(90, 14);
            this.lblCMF20.TabIndex = 38;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(257, 214);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(90, 14);
            this.lblCMF19.TabIndex = 36;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(257, 190);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(90, 14);
            this.lblCMF18.TabIndex = 34;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(257, 166);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(90, 14);
            this.lblCMF17.TabIndex = 32;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(257, 142);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(90, 14);
            this.lblCMF16.TabIndex = 30;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(257, 118);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(90, 14);
            this.lblCMF15.TabIndex = 28;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(257, 94);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(90, 14);
            this.lblCMF14.TabIndex = 26;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(257, 70);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(90, 14);
            this.lblCMF13.TabIndex = 24;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(257, 46);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(90, 14);
            this.lblCMF12.TabIndex = 22;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(257, 22);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(90, 14);
            this.lblCMF11.TabIndex = 20;
            this.lblCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(105, 210);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 135;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(105, 186);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 135;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(105, 162);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 135;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(105, 138);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 135;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(105, 114);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 135;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(105, 90);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 135;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(105, 66);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 135;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(105, 42);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 135;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(105, 234);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 135;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(105, 18);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(135, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 135;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(10, 238);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(90, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(10, 214);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(90, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(10, 190);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(90, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(10, 166);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(90, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(10, 142);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(90, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(10, 118);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(90, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(10, 94);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(90, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(10, 70);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(90, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(10, 46);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(90, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(10, 22);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(90, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splAction
            // 
            this.splAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.splAction.Location = new System.Drawing.Point(0, 160);
            this.splAction.Name = "splAction";
            this.splAction.Size = new System.Drawing.Size(506, 4);
            this.splAction.TabIndex = 1;
            this.splAction.TabStop = false;
            // 
            // tvAction
            // 
            this.tvAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvAction.Location = new System.Drawing.Point(0, 0);
            this.tvAction.Name = "tvAction";
            this.tvAction.Size = new System.Drawing.Size(506, 160);
            this.tvAction.TabIndex = 0;
            this.tvAction.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAction_AfterSelect);
            this.tvAction.Resize += new System.EventHandler(this.tvAction_Resize);
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(592, 111);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 20);
            this.btnExpand.TabIndex = 3;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(565, 111);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 20);
            this.btnCollapse.TabIndex = 2;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // frmWIPSetupFutureAction
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.MinimumSize = new System.Drawing.Size(758, 584);
            this.Name = "frmWIPSetupFutureAction";
            this.Text = "Future Action Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupFutureAction_Activated);
            this.Load += new System.EventHandler(this.frmWIPSetupFutureAction_Load);
            this.Resize += new System.EventHandler(this.frmWIPSetupFutureAction_Resize);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlSetting.ResumeLayout(false);
            this.tabAction.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlAction.ResumeLayout(false);
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDependentAction)).EndInit();
            this.pnlPoint.ResumeLayout(false);
            this.grpBA.ResumeLayout(false);
            this.grpBA.PerformLayout();
            this.grpPoint.ResumeLayout(false);
            this.grpPoint.PerformLayout();
            this.tbpCondition.ResumeLayout(false);
            this.grpConditionList.ResumeLayout(false);
            this.grpConditionList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCond_Sheet1)).EndInit();
            this.grpCondition.ResumeLayout(false);
            this.grpCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvField)).EndInit();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.MESCore.Controls.udcMFOTreeList tvMFO;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.TabControl tabAction;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.GroupBox grpCMF;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF19;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF18;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF17;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF16;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF15;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF14;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF13;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF12;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF20;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF11;
        private System.Windows.Forms.Label lblCMF20;
        private System.Windows.Forms.Label lblCMF19;
        private System.Windows.Forms.Label lblCMF18;
        private System.Windows.Forms.Label lblCMF17;
        private System.Windows.Forms.Label lblCMF16;
        private System.Windows.Forms.Label lblCMF15;
        private System.Windows.Forms.Label lblCMF14;
        private System.Windows.Forms.Label lblCMF13;
        private System.Windows.Forms.Label lblCMF12;
        private System.Windows.Forms.Label lblCMF11;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        private System.Windows.Forms.Label lblCMF10;
        private System.Windows.Forms.Label lblCMF9;
        private System.Windows.Forms.Label lblCMF8;
        private System.Windows.Forms.Label lblCMF7;
        private System.Windows.Forms.Label lblCMF6;
        private System.Windows.Forms.Label lblCMF5;
        private System.Windows.Forms.Label lblCMF4;
        private System.Windows.Forms.Label lblCMF3;
        private System.Windows.Forms.Label lblCMF2;
        private System.Windows.Forms.Label lblCMF1;
        private System.Windows.Forms.TabPage tbpCondition;
        private System.Windows.Forms.GroupBox grpCondition;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvField;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.Label lblValueType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue2;
        private System.Windows.Forms.Label lblValue2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue1;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.GroupBox grpConditionList;
        private FarPoint.Win.Spread.FpSpread spdCond;
        private FarPoint.Win.Spread.SheetView spdCond_Sheet1;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Splitter splAction;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Panel pnlPoint;
        private System.Windows.Forms.GroupBox grpBA;
        private System.Windows.Forms.GroupBox grpPoint;
        private System.Windows.Forms.RadioButton rbtOperAt;
        private System.Windows.Forms.RadioButton rbtOperIn;
        private System.Windows.Forms.RadioButton rbtAfter;
        private System.Windows.Forms.RadioButton rbtBefore;
        private System.Windows.Forms.RadioButton rbtOperOut;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Label lblTransaction;
        private System.Windows.Forms.ComboBox cboTransaction;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtCond1;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.RichTextBox txtCond2;
        private System.Windows.Forms.TextBox txtCond3;
        private System.Windows.Forms.TextBox txtRelation;
        private System.Windows.Forms.Panel pnlActionValue;
        private Miracom.UI.Controls.MCListView.MCListView lisServices;
        private System.Windows.Forms.ColumnHeader colCheck;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ColumnHeader colServices;
        private System.Windows.Forms.ComboBox cboCondition;
        private System.Windows.Forms.ComboBox cboValueType;
        private System.Windows.Forms.TextBox txtFVUsage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkSkipService;
        private UI.Controls.MCCodeView.MCCodeView cdvDependentAction;
        private System.Windows.Forms.Label lblDependent;
        private System.Windows.Forms.TreeView tvAction;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
    }
}
