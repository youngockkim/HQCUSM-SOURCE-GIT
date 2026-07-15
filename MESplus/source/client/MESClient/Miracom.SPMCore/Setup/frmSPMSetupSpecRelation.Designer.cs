namespace Miracom.SPMCore
{
    partial class frmSPMSetupSpecRelation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPMSetupSpecRelation));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.tvMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.tabSpec = new System.Windows.Forms.TabControl();
            this.tbpVersion = new System.Windows.Forms.TabPage();
            this.pnlSpecVersion2 = new System.Windows.Forms.Panel();
            this.pnlSpecVerTab = new System.Windows.Forms.Panel();
            this.tabVersion = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlUpdateInfo = new System.Windows.Forms.Panel();
            this.grpUpdateInfo = new System.Windows.Forms.GroupBox();
            this.txtSpecVerUpdateTime = new System.Windows.Forms.TextBox();
            this.lblSpecVerUpdateTime = new System.Windows.Forms.Label();
            this.txtSpecVerUpdateUser = new System.Windows.Forms.TextBox();
            this.lblSpecVerUpdateUser = new System.Windows.Forms.Label();
            this.txtSpecVerCreateTime = new System.Windows.Forms.TextBox();
            this.lblSpecVerCreateTime = new System.Windows.Forms.Label();
            this.txtSpecVerCreateUser = new System.Windows.Forms.TextBox();
            this.lblSpecVerCreateUser = new System.Windows.Forms.Label();
            this.grpApplyTime = new System.Windows.Forms.GroupBox();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.lblFromTo = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.tbpAppNRel = new System.Windows.Forms.TabPage();
            this.pnlReleaseInfo = new System.Windows.Forms.Panel();
            this.grpRelease = new System.Windows.Forms.GroupBox();
            this.chkReleaseFlag = new System.Windows.Forms.CheckBox();
            this.txtReleaseTime = new System.Windows.Forms.TextBox();
            this.lblReleaseTime = new System.Windows.Forms.Label();
            this.txtReleaseUser = new System.Windows.Forms.TextBox();
            this.lblReleaseUser = new System.Windows.Forms.Label();
            this.grpApproval = new System.Windows.Forms.GroupBox();
            this.chkApprovalFlag = new System.Windows.Forms.CheckBox();
            this.txtApprovalTime = new System.Windows.Forms.TextBox();
            this.lblApprovalTime = new System.Windows.Forms.Label();
            this.txtApprovalUser = new System.Windows.Forms.TextBox();
            this.lblApprovalUser = new System.Windows.Forms.Label();
            this.pnlVersionBottom = new System.Windows.Forms.Panel();
            this.btnApproval = new System.Windows.Forms.Button();
            this.btnCancelApproval = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.tbpCopyVer = new System.Windows.Forms.TabPage();
            this.grpCopyTable = new System.Windows.Forms.GroupBox();
            this.btnCopyVersion = new System.Windows.Forms.Button();
            this.lblToVersion = new System.Windows.Forms.Label();
            this.txtToVersion = new System.Windows.Forms.TextBox();
            this.pnlSpecVersion = new System.Windows.Forms.Panel();
            this.grpCoSetVersion = new System.Windows.Forms.GroupBox();
            this.txtSpecVersion = new System.Windows.Forms.TextBox();
            this.lblSpecVersion = new System.Windows.Forms.Label();
            this.lisSpecVersion = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSpecVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpCharacter = new System.Windows.Forms.TabPage();
            this.pnlCharMid = new System.Windows.Forms.Panel();
            this.pnlCharMidRight = new System.Windows.Forms.Panel();
            this.lisAllChar = new Miracom.UI.Controls.MCListView.MCListView();
            this.colChar2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCharDesc2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlAllCharFilter = new System.Windows.Forms.Panel();
            this.txtAllCharFilter = new System.Windows.Forms.TextBox();
            this.lblAllCharFilter = new System.Windows.Forms.Label();
            this.pnlCharRightBottom = new System.Windows.Forms.Panel();
            this.txtAllCharCount = new System.Windows.Forms.TextBox();
            this.lblAllCharCount = new System.Windows.Forms.Label();
            this.pnlChar2 = new System.Windows.Forms.Panel();
            this.btnCharRefresh2 = new System.Windows.Forms.Button();
            this.lblChar2 = new System.Windows.Forms.Label();
            this.pnlCharMidMid = new System.Windows.Forms.Panel();
            this.btnAttachAll = new System.Windows.Forms.Button();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.pnlCharMidLeft = new System.Windows.Forms.Panel();
            this.lisAssignedChar = new Miracom.UI.Controls.MCListView.MCListView();
            this.colChar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCharDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlChar = new System.Windows.Forms.Panel();
            this.btnCharRefresh = new System.Windows.Forms.Button();
            this.lblChar = new System.Windows.Forms.Label();
            this.pnlCharLeftBottom = new System.Windows.Forms.Panel();
            this.txtAssignedCharCount = new System.Windows.Forms.TextBox();
            this.lblAssignedCharCount = new System.Windows.Forms.Label();
            this.tbpLimit = new System.Windows.Forms.TabPage();
            this.pnlLimitRight = new System.Windows.Forms.Panel();
            this.tabLimit = new System.Windows.Forms.TabControl();
            this.tbpManSpec = new System.Windows.Forms.TabPage();
            this.spdLimit = new FarPoint.Win.Spread.FpSpread();
            this.spdLimit_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpSpecLimit = new System.Windows.Forms.GroupBox();
            this.cdvTargetValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValidTable = new System.Windows.Forms.Label();
            this.cdvValidTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkManSpec = new System.Windows.Forms.CheckBox();
            this.lblAlarmCode2 = new System.Windows.Forms.Label();
            this.lblAlarmCode1 = new System.Windows.Forms.Label();
            this.cdvAlarmCode2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCode1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboSpecType = new System.Windows.Forms.ComboBox();
            this.lblSpecType = new System.Windows.Forms.Label();
            this.lblSpecOutCount = new System.Windows.Forms.Label();
            this.txtSpecOutCount = new System.Windows.Forms.TextBox();
            this.lblLowerWarnLimit = new System.Windows.Forms.Label();
            this.txtLowerWarnLimit = new System.Windows.Forms.TextBox();
            this.lblUpperWarnLimit = new System.Windows.Forms.Label();
            this.txtUpperWarnLimit = new System.Windows.Forms.TextBox();
            this.lblLowerSpecLimit = new System.Windows.Forms.Label();
            this.txtLowerSpecLimit = new System.Windows.Forms.TextBox();
            this.lblUpperSpecLimit = new System.Windows.Forms.Label();
            this.txtUpperSpecLimit = new System.Windows.Forms.TextBox();
            this.lblTargetValue = new System.Windows.Forms.Label();
            this.tbpCusSpec = new System.Windows.Forms.TabPage();
            this.spdCusLimit = new FarPoint.Win.Spread.FpSpread();
            this.spdCusLimit_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpCusSpecLimit = new System.Windows.Forms.GroupBox();
            this.cdvCusTargetValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCusValidTable = new System.Windows.Forms.Label();
            this.cdvCusValidTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkCusSpec = new System.Windows.Forms.CheckBox();
            this.lblCusAlarmCode2 = new System.Windows.Forms.Label();
            this.lblCusAlarmCode1 = new System.Windows.Forms.Label();
            this.cdvCusAlarmCode2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCusAlarmCode1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboCusSpecType = new System.Windows.Forms.ComboBox();
            this.lblCusSpecType = new System.Windows.Forms.Label();
            this.lblCusSpecOutCount = new System.Windows.Forms.Label();
            this.txtCusSpecOutCount = new System.Windows.Forms.TextBox();
            this.lblCusLowerWarnLimit = new System.Windows.Forms.Label();
            this.txtCusLowerWarnLimit = new System.Windows.Forms.TextBox();
            this.lblCusUpperWarnLimit = new System.Windows.Forms.Label();
            this.txtCusUpperWarnLimit = new System.Windows.Forms.TextBox();
            this.lblCusLowerSpecLimit = new System.Windows.Forms.Label();
            this.txtCusLowerSpecLimit = new System.Windows.Forms.TextBox();
            this.lblCusUpperSpecLimit = new System.Windows.Forms.Label();
            this.txtCusUpperSpecLimit = new System.Windows.Forms.TextBox();
            this.lblCusTargetValue = new System.Windows.Forms.Label();
            this.splLimit = new System.Windows.Forms.Splitter();
            this.pnlLimitLeft = new System.Windows.Forms.Panel();
            this.pnlCharMidLeft3 = new System.Windows.Forms.Panel();
            this.lisAssignedChar3 = new Miracom.UI.Controls.MCListView.MCListView();
            this.colChar3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCharDesc3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCharType3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlChar3 = new System.Windows.Forms.Panel();
            this.btnCharRefresh3 = new System.Windows.Forms.Button();
            this.lblChar3 = new System.Windows.Forms.Label();
            this.tbpAttr = new System.Windows.Forms.TabPage();
            this.pnlAttrRight = new System.Windows.Forms.Panel();
            this.grpAttr = new System.Windows.Forms.GroupBox();
            this.spdAttr = new FarPoint.Win.Spread.FpSpread();
            this.spdAttr_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splAttr = new System.Windows.Forms.Splitter();
            this.pnlAttrLeft = new System.Windows.Forms.Panel();
            this.pnlCharMidLeft4 = new System.Windows.Forms.Panel();
            this.lisAssignedChar4 = new Miracom.UI.Controls.MCListView.MCListView();
            this.colChar4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCharDesc4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlChar4 = new System.Windows.Forms.Panel();
            this.btnCharRefresh4 = new System.Windows.Forms.Button();
            this.lblChar4 = new System.Windows.Forms.Label();
            this.tbpDoc = new System.Windows.Forms.TabPage();
            this.pnlDocRight = new System.Windows.Forms.Panel();
            this.grpImg = new System.Windows.Forms.GroupBox();
            this.tlpImg = new System.Windows.Forms.TableLayoutPanel();
            this.pnlImgBottom3 = new System.Windows.Forms.Panel();
            this.picImg3 = new System.Windows.Forms.PictureBox();
            this.pnlImgBottom2 = new System.Windows.Forms.Panel();
            this.picImg2 = new System.Windows.Forms.PictureBox();
            this.pnlImgBottom1 = new System.Windows.Forms.Panel();
            this.picImg1 = new System.Windows.Forms.PictureBox();
            this.pnlImgTop3 = new System.Windows.Forms.Panel();
            this.chkKeep8 = new System.Windows.Forms.CheckBox();
            this.cdvImg3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblImg3 = new System.Windows.Forms.Label();
            this.pnlImgTop2 = new System.Windows.Forms.Panel();
            this.chkKeep7 = new System.Windows.Forms.CheckBox();
            this.cdvImg2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblImg2 = new System.Windows.Forms.Label();
            this.pnlImgTop1 = new System.Windows.Forms.Panel();
            this.chkKeep6 = new System.Windows.Forms.CheckBox();
            this.cdvImg1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblImg1 = new System.Windows.Forms.Label();
            this.grpDoc = new System.Windows.Forms.GroupBox();
            this.chkKeep5 = new System.Windows.Forms.CheckBox();
            this.chkKeep4 = new System.Windows.Forms.CheckBox();
            this.chkKeep3 = new System.Windows.Forms.CheckBox();
            this.chkKeep2 = new System.Windows.Forms.CheckBox();
            this.chkKeep1 = new System.Windows.Forms.CheckBox();
            this.btnDoc5 = new System.Windows.Forms.Button();
            this.cdvDoc5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDoc5 = new System.Windows.Forms.Label();
            this.btnDoc4 = new System.Windows.Forms.Button();
            this.cdvDoc4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDoc4 = new System.Windows.Forms.Label();
            this.btnDoc3 = new System.Windows.Forms.Button();
            this.cdvDoc3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDoc3 = new System.Windows.Forms.Label();
            this.btnDoc2 = new System.Windows.Forms.Button();
            this.cdvDoc2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDoc2 = new System.Windows.Forms.Label();
            this.btnDoc1 = new System.Windows.Forms.Button();
            this.cdvDoc1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDoc1 = new System.Windows.Forms.Label();
            this.grpAttachOption = new System.Windows.Forms.GroupBox();
            this.btnViewSpecFile = new System.Windows.Forms.Button();
            this.lblFileExt = new System.Windows.Forms.Label();
            this.txtFileExt = new System.Windows.Forms.TextBox();
            this.chkUseTargetToFile = new System.Windows.Forms.CheckBox();
            this.chkUseLatestFileVersion = new System.Windows.Forms.CheckBox();
            this.chkUseTargetToDir = new System.Windows.Forms.CheckBox();
            this.chkUseCharDir = new System.Windows.Forms.CheckBox();
            this.splDoc = new System.Windows.Forms.Splitter();
            this.pnlDocLeft = new System.Windows.Forms.Panel();
            this.pnlCharMidLeft5 = new System.Windows.Forms.Panel();
            this.lisAssignedChar5 = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlChar5 = new System.Windows.Forms.Panel();
            this.btnCharRefresh5 = new System.Windows.Forms.Button();
            this.lblChar5 = new System.Windows.Forms.Label();
            this.tbpCopy = new System.Windows.Forms.TabPage();
            this.grpCopy = new System.Windows.Forms.GroupBox();
            this.btnCopySpec = new System.Windows.Forms.Button();
            this.cdvToVer = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToVer = new System.Windows.Forms.Label();
            this.cdvToOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvToFlow = new Miracom.MESCore.Controls.udcFlow();
            this.cdvToMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabSpec.SuspendLayout();
            this.tbpVersion.SuspendLayout();
            this.pnlSpecVersion2.SuspendLayout();
            this.pnlSpecVerTab.SuspendLayout();
            this.tabVersion.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlUpdateInfo.SuspendLayout();
            this.grpUpdateInfo.SuspendLayout();
            this.grpApplyTime.SuspendLayout();
            this.tbpAppNRel.SuspendLayout();
            this.pnlReleaseInfo.SuspendLayout();
            this.grpRelease.SuspendLayout();
            this.grpApproval.SuspendLayout();
            this.pnlVersionBottom.SuspendLayout();
            this.tbpCopyVer.SuspendLayout();
            this.grpCopyTable.SuspendLayout();
            this.pnlSpecVersion.SuspendLayout();
            this.grpCoSetVersion.SuspendLayout();
            this.tbpCharacter.SuspendLayout();
            this.pnlCharMid.SuspendLayout();
            this.pnlCharMidRight.SuspendLayout();
            this.pnlAllCharFilter.SuspendLayout();
            this.pnlCharRightBottom.SuspendLayout();
            this.pnlChar2.SuspendLayout();
            this.pnlCharMidMid.SuspendLayout();
            this.pnlCharMidLeft.SuspendLayout();
            this.pnlChar.SuspendLayout();
            this.pnlCharLeftBottom.SuspendLayout();
            this.tbpLimit.SuspendLayout();
            this.pnlLimitRight.SuspendLayout();
            this.tabLimit.SuspendLayout();
            this.tbpManSpec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLimit_Sheet1)).BeginInit();
            this.grpSpecLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValidTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode1)).BeginInit();
            this.tbpCusSpec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCusLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCusLimit_Sheet1)).BeginInit();
            this.grpCusSpecLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCusTargetValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCusValidTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCusAlarmCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCusAlarmCode1)).BeginInit();
            this.pnlLimitLeft.SuspendLayout();
            this.pnlCharMidLeft3.SuspendLayout();
            this.pnlChar3.SuspendLayout();
            this.tbpAttr.SuspendLayout();
            this.pnlAttrRight.SuspendLayout();
            this.grpAttr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttr_Sheet1)).BeginInit();
            this.pnlAttrLeft.SuspendLayout();
            this.pnlCharMidLeft4.SuspendLayout();
            this.pnlChar4.SuspendLayout();
            this.tbpDoc.SuspendLayout();
            this.pnlDocRight.SuspendLayout();
            this.grpImg.SuspendLayout();
            this.tlpImg.SuspendLayout();
            this.pnlImgBottom3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg3)).BeginInit();
            this.pnlImgBottom2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg2)).BeginInit();
            this.pnlImgBottom1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg1)).BeginInit();
            this.pnlImgTop3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvImg3)).BeginInit();
            this.pnlImgTop2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvImg2)).BeginInit();
            this.pnlImgTop1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvImg1)).BeginInit();
            this.grpDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc1)).BeginInit();
            this.grpAttachOption.SuspendLayout();
            this.pnlDocLeft.SuspendLayout();
            this.pnlCharMidLeft5.SuspendLayout();
            this.pnlChar5.SuspendLayout();
            this.tbpCopy.SuspendLayout();
            this.grpCopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.Enabled = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tabSpec);
            this.pnlRight.Size = new System.Drawing.Size(498, 506);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvMFO);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(368, 7);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(550, 7);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(459, 7);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(641, 7);
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Size = new System.Drawing.Size(734, 40);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(734, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
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
            this.tvMFO.VisibleLevel6M = true;
            this.tvMFO.VisibleLevel7F = false;
            this.tvMFO.VisibleLevel8Factory = true;
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
            // tabSpec
            // 
            this.tabSpec.Controls.Add(this.tbpVersion);
            this.tabSpec.Controls.Add(this.tbpCharacter);
            this.tabSpec.Controls.Add(this.tbpLimit);
            this.tabSpec.Controls.Add(this.tbpAttr);
            this.tabSpec.Controls.Add(this.tbpDoc);
            this.tabSpec.Controls.Add(this.tbpCopy);
            this.tabSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSpec.Location = new System.Drawing.Point(0, 0);
            this.tabSpec.Name = "tabSpec";
            this.tabSpec.SelectedIndex = 0;
            this.tabSpec.Size = new System.Drawing.Size(498, 506);
            this.tabSpec.TabIndex = 0;
            this.tabSpec.SelectedIndexChanged += new System.EventHandler(this.tabSpec_SelectedIndexChanged);
            // 
            // tbpVersion
            // 
            this.tbpVersion.BackColor = System.Drawing.SystemColors.Control;
            this.tbpVersion.Controls.Add(this.pnlSpecVersion2);
            this.tbpVersion.Controls.Add(this.pnlSpecVersion);
            this.tbpVersion.Controls.Add(this.lisSpecVersion);
            this.tbpVersion.Location = new System.Drawing.Point(4, 22);
            this.tbpVersion.Name = "tbpVersion";
            this.tbpVersion.Padding = new System.Windows.Forms.Padding(3);
            this.tbpVersion.Size = new System.Drawing.Size(490, 480);
            this.tbpVersion.TabIndex = 0;
            this.tbpVersion.Text = "Spec. Rel Version";
            // 
            // pnlSpecVersion2
            // 
            this.pnlSpecVersion2.Controls.Add(this.pnlSpecVerTab);
            this.pnlSpecVersion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSpecVersion2.Location = new System.Drawing.Point(144, 50);
            this.pnlSpecVersion2.Name = "pnlSpecVersion2";
            this.pnlSpecVersion2.Size = new System.Drawing.Size(343, 427);
            this.pnlSpecVersion2.TabIndex = 4;
            // 
            // pnlSpecVerTab
            // 
            this.pnlSpecVerTab.Controls.Add(this.tabVersion);
            this.pnlSpecVerTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSpecVerTab.Location = new System.Drawing.Point(0, 0);
            this.pnlSpecVerTab.Name = "pnlSpecVerTab";
            this.pnlSpecVerTab.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlSpecVerTab.Size = new System.Drawing.Size(343, 427);
            this.pnlSpecVerTab.TabIndex = 2;
            // 
            // tabVersion
            // 
            this.tabVersion.Controls.Add(this.tbpGeneral);
            this.tabVersion.Controls.Add(this.tbpAppNRel);
            this.tabVersion.Controls.Add(this.tbpCopyVer);
            this.tabVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVersion.Location = new System.Drawing.Point(3, 0);
            this.tabVersion.Name = "tabVersion";
            this.tabVersion.SelectedIndex = 0;
            this.tabVersion.Size = new System.Drawing.Size(337, 427);
            this.tabVersion.TabIndex = 4;
            this.tabVersion.SelectedIndexChanged += new System.EventHandler(this.tabSpec_SelectedIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlUpdateInfo);
            this.tbpGeneral.Controls.Add(this.grpApplyTime);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(329, 401);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlUpdateInfo
            // 
            this.pnlUpdateInfo.Controls.Add(this.grpUpdateInfo);
            this.pnlUpdateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpdateInfo.Location = new System.Drawing.Point(3, 76);
            this.pnlUpdateInfo.Name = "pnlUpdateInfo";
            this.pnlUpdateInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlUpdateInfo.Size = new System.Drawing.Size(323, 322);
            this.pnlUpdateInfo.TabIndex = 3;
            // 
            // grpUpdateInfo
            // 
            this.grpUpdateInfo.Controls.Add(this.txtSpecVerUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.lblSpecVerUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.txtSpecVerUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.lblSpecVerUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.txtSpecVerCreateTime);
            this.grpUpdateInfo.Controls.Add(this.lblSpecVerCreateTime);
            this.grpUpdateInfo.Controls.Add(this.txtSpecVerCreateUser);
            this.grpUpdateInfo.Controls.Add(this.lblSpecVerCreateUser);
            this.grpUpdateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUpdateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUpdateInfo.Location = new System.Drawing.Point(0, 5);
            this.grpUpdateInfo.Name = "grpUpdateInfo";
            this.grpUpdateInfo.Size = new System.Drawing.Size(323, 317);
            this.grpUpdateInfo.TabIndex = 2;
            this.grpUpdateInfo.TabStop = false;
            this.grpUpdateInfo.Text = "Update Information";
            // 
            // txtSpecVerUpdateTime
            // 
            this.txtSpecVerUpdateTime.Location = new System.Drawing.Point(104, 88);
            this.txtSpecVerUpdateTime.MaxLength = 20;
            this.txtSpecVerUpdateTime.Name = "txtSpecVerUpdateTime";
            this.txtSpecVerUpdateTime.ReadOnly = true;
            this.txtSpecVerUpdateTime.Size = new System.Drawing.Size(168, 20);
            this.txtSpecVerUpdateTime.TabIndex = 7;
            this.txtSpecVerUpdateTime.TabStop = false;
            // 
            // lblSpecVerUpdateTime
            // 
            this.lblSpecVerUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecVerUpdateTime.Location = new System.Drawing.Point(8, 91);
            this.lblSpecVerUpdateTime.Name = "lblSpecVerUpdateTime";
            this.lblSpecVerUpdateTime.Size = new System.Drawing.Size(92, 14);
            this.lblSpecVerUpdateTime.TabIndex = 6;
            this.lblSpecVerUpdateTime.Text = "Update Time";
            this.lblSpecVerUpdateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSpecVerUpdateUser
            // 
            this.txtSpecVerUpdateUser.Location = new System.Drawing.Point(104, 64);
            this.txtSpecVerUpdateUser.MaxLength = 20;
            this.txtSpecVerUpdateUser.Name = "txtSpecVerUpdateUser";
            this.txtSpecVerUpdateUser.ReadOnly = true;
            this.txtSpecVerUpdateUser.Size = new System.Drawing.Size(168, 20);
            this.txtSpecVerUpdateUser.TabIndex = 5;
            this.txtSpecVerUpdateUser.TabStop = false;
            // 
            // lblSpecVerUpdateUser
            // 
            this.lblSpecVerUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecVerUpdateUser.Location = new System.Drawing.Point(8, 67);
            this.lblSpecVerUpdateUser.Name = "lblSpecVerUpdateUser";
            this.lblSpecVerUpdateUser.Size = new System.Drawing.Size(92, 14);
            this.lblSpecVerUpdateUser.TabIndex = 4;
            this.lblSpecVerUpdateUser.Text = "Update User";
            this.lblSpecVerUpdateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSpecVerCreateTime
            // 
            this.txtSpecVerCreateTime.Location = new System.Drawing.Point(104, 40);
            this.txtSpecVerCreateTime.MaxLength = 20;
            this.txtSpecVerCreateTime.Name = "txtSpecVerCreateTime";
            this.txtSpecVerCreateTime.ReadOnly = true;
            this.txtSpecVerCreateTime.Size = new System.Drawing.Size(168, 20);
            this.txtSpecVerCreateTime.TabIndex = 3;
            this.txtSpecVerCreateTime.TabStop = false;
            // 
            // lblSpecVerCreateTime
            // 
            this.lblSpecVerCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecVerCreateTime.Location = new System.Drawing.Point(8, 43);
            this.lblSpecVerCreateTime.Name = "lblSpecVerCreateTime";
            this.lblSpecVerCreateTime.Size = new System.Drawing.Size(92, 14);
            this.lblSpecVerCreateTime.TabIndex = 2;
            this.lblSpecVerCreateTime.Text = "Create Time";
            this.lblSpecVerCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSpecVerCreateUser
            // 
            this.txtSpecVerCreateUser.Location = new System.Drawing.Point(104, 16);
            this.txtSpecVerCreateUser.MaxLength = 20;
            this.txtSpecVerCreateUser.Name = "txtSpecVerCreateUser";
            this.txtSpecVerCreateUser.ReadOnly = true;
            this.txtSpecVerCreateUser.Size = new System.Drawing.Size(168, 20);
            this.txtSpecVerCreateUser.TabIndex = 1;
            this.txtSpecVerCreateUser.TabStop = false;
            // 
            // lblSpecVerCreateUser
            // 
            this.lblSpecVerCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecVerCreateUser.Location = new System.Drawing.Point(8, 19);
            this.lblSpecVerCreateUser.Name = "lblSpecVerCreateUser";
            this.lblSpecVerCreateUser.Size = new System.Drawing.Size(92, 14);
            this.lblSpecVerCreateUser.TabIndex = 0;
            this.lblSpecVerCreateUser.Text = "Create User";
            this.lblSpecVerCreateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpApplyTime
            // 
            this.grpApplyTime.Controls.Add(this.chkEnd);
            this.grpApplyTime.Controls.Add(this.chkStart);
            this.grpApplyTime.Controls.Add(this.lblFromTo);
            this.grpApplyTime.Controls.Add(this.dtpEndTime);
            this.grpApplyTime.Controls.Add(this.dtpEndDate);
            this.grpApplyTime.Controls.Add(this.dtpStartTime);
            this.grpApplyTime.Controls.Add(this.dtpStartDate);
            this.grpApplyTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpApplyTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpApplyTime.Location = new System.Drawing.Point(3, 5);
            this.grpApplyTime.Name = "grpApplyTime";
            this.grpApplyTime.Size = new System.Drawing.Size(323, 71);
            this.grpApplyTime.TabIndex = 0;
            this.grpApplyTime.TabStop = false;
            this.grpApplyTime.Text = "Apply Time";
            // 
            // chkEnd
            // 
            this.chkEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEnd.Location = new System.Drawing.Point(34, 42);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(12, 16);
            this.chkEnd.TabIndex = 3;
            this.chkEnd.Text = "CheckBox1";
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkEnd_CheckedChanged);
            // 
            // chkStart
            // 
            this.chkStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStart.Location = new System.Drawing.Point(34, 18);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(12, 16);
            this.chkStart.TabIndex = 0;
            this.chkStart.Text = "CheckBox1";
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // lblFromTo
            // 
            this.lblFromTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromTo.Location = new System.Drawing.Point(233, 22);
            this.lblFromTo.Name = "lblFromTo";
            this.lblFromTo.Size = new System.Drawing.Size(11, 10);
            this.lblFromTo.TabIndex = 2;
            this.lblFromTo.Text = "~";
            this.lblFromTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(148, 40);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(80, 20);
            this.dtpEndTime.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(56, 40);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(90, 20);
            this.dtpEndDate.TabIndex = 2;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(148, 16);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(80, 20);
            this.dtpStartTime.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(56, 16);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(90, 20);
            this.dtpStartDate.TabIndex = 0;
            // 
            // tbpAppNRel
            // 
            this.tbpAppNRel.Controls.Add(this.pnlReleaseInfo);
            this.tbpAppNRel.Controls.Add(this.grpApproval);
            this.tbpAppNRel.Controls.Add(this.pnlVersionBottom);
            this.tbpAppNRel.Location = new System.Drawing.Point(4, 22);
            this.tbpAppNRel.Name = "tbpAppNRel";
            this.tbpAppNRel.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.tbpAppNRel.Size = new System.Drawing.Size(329, 401);
            this.tbpAppNRel.TabIndex = 2;
            this.tbpAppNRel.Text = "Approval and Release";
            this.tbpAppNRel.Visible = false;
            // 
            // pnlReleaseInfo
            // 
            this.pnlReleaseInfo.Controls.Add(this.grpRelease);
            this.pnlReleaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReleaseInfo.Location = new System.Drawing.Point(3, 98);
            this.pnlReleaseInfo.Name = "pnlReleaseInfo";
            this.pnlReleaseInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlReleaseInfo.Size = new System.Drawing.Size(323, 271);
            this.pnlReleaseInfo.TabIndex = 1;
            // 
            // grpRelease
            // 
            this.grpRelease.Controls.Add(this.chkReleaseFlag);
            this.grpRelease.Controls.Add(this.txtReleaseTime);
            this.grpRelease.Controls.Add(this.lblReleaseTime);
            this.grpRelease.Controls.Add(this.txtReleaseUser);
            this.grpRelease.Controls.Add(this.lblReleaseUser);
            this.grpRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRelease.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRelease.Location = new System.Drawing.Point(0, 5);
            this.grpRelease.Name = "grpRelease";
            this.grpRelease.Size = new System.Drawing.Size(323, 266);
            this.grpRelease.TabIndex = 2;
            this.grpRelease.TabStop = false;
            this.grpRelease.Text = "Release Information";
            // 
            // chkReleaseFlag
            // 
            this.chkReleaseFlag.Enabled = false;
            this.chkReleaseFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkReleaseFlag.Location = new System.Drawing.Point(9, 18);
            this.chkReleaseFlag.Name = "chkReleaseFlag";
            this.chkReleaseFlag.Size = new System.Drawing.Size(148, 14);
            this.chkReleaseFlag.TabIndex = 0;
            this.chkReleaseFlag.Text = "Release Flag";
            // 
            // txtReleaseTime
            // 
            this.txtReleaseTime.Location = new System.Drawing.Point(106, 62);
            this.txtReleaseTime.MaxLength = 20;
            this.txtReleaseTime.Name = "txtReleaseTime";
            this.txtReleaseTime.ReadOnly = true;
            this.txtReleaseTime.Size = new System.Drawing.Size(168, 20);
            this.txtReleaseTime.TabIndex = 4;
            this.txtReleaseTime.TabStop = false;
            // 
            // lblReleaseTime
            // 
            this.lblReleaseTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReleaseTime.Location = new System.Drawing.Point(9, 65);
            this.lblReleaseTime.Name = "lblReleaseTime";
            this.lblReleaseTime.Size = new System.Drawing.Size(92, 14);
            this.lblReleaseTime.TabIndex = 3;
            this.lblReleaseTime.Text = "Release Time";
            this.lblReleaseTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReleaseUser
            // 
            this.txtReleaseUser.Location = new System.Drawing.Point(106, 38);
            this.txtReleaseUser.MaxLength = 20;
            this.txtReleaseUser.Name = "txtReleaseUser";
            this.txtReleaseUser.ReadOnly = true;
            this.txtReleaseUser.Size = new System.Drawing.Size(168, 20);
            this.txtReleaseUser.TabIndex = 2;
            this.txtReleaseUser.TabStop = false;
            // 
            // lblReleaseUser
            // 
            this.lblReleaseUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReleaseUser.Location = new System.Drawing.Point(9, 41);
            this.lblReleaseUser.Name = "lblReleaseUser";
            this.lblReleaseUser.Size = new System.Drawing.Size(92, 14);
            this.lblReleaseUser.TabIndex = 1;
            this.lblReleaseUser.Text = "Release User";
            this.lblReleaseUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpApproval
            // 
            this.grpApproval.Controls.Add(this.chkApprovalFlag);
            this.grpApproval.Controls.Add(this.txtApprovalTime);
            this.grpApproval.Controls.Add(this.lblApprovalTime);
            this.grpApproval.Controls.Add(this.txtApprovalUser);
            this.grpApproval.Controls.Add(this.lblApprovalUser);
            this.grpApproval.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpApproval.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpApproval.Location = new System.Drawing.Point(3, 5);
            this.grpApproval.Name = "grpApproval";
            this.grpApproval.Size = new System.Drawing.Size(323, 93);
            this.grpApproval.TabIndex = 0;
            this.grpApproval.TabStop = false;
            this.grpApproval.Text = "Approval Information";
            // 
            // chkApprovalFlag
            // 
            this.chkApprovalFlag.Enabled = false;
            this.chkApprovalFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkApprovalFlag.Location = new System.Drawing.Point(9, 18);
            this.chkApprovalFlag.Name = "chkApprovalFlag";
            this.chkApprovalFlag.Size = new System.Drawing.Size(148, 14);
            this.chkApprovalFlag.TabIndex = 0;
            this.chkApprovalFlag.Text = "Approval Flag";
            // 
            // txtApprovalTime
            // 
            this.txtApprovalTime.Location = new System.Drawing.Point(106, 62);
            this.txtApprovalTime.MaxLength = 20;
            this.txtApprovalTime.Name = "txtApprovalTime";
            this.txtApprovalTime.ReadOnly = true;
            this.txtApprovalTime.Size = new System.Drawing.Size(168, 20);
            this.txtApprovalTime.TabIndex = 4;
            this.txtApprovalTime.TabStop = false;
            // 
            // lblApprovalTime
            // 
            this.lblApprovalTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApprovalTime.Location = new System.Drawing.Point(9, 65);
            this.lblApprovalTime.Name = "lblApprovalTime";
            this.lblApprovalTime.Size = new System.Drawing.Size(92, 14);
            this.lblApprovalTime.TabIndex = 3;
            this.lblApprovalTime.Text = "Approval Time";
            this.lblApprovalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtApprovalUser
            // 
            this.txtApprovalUser.Location = new System.Drawing.Point(106, 38);
            this.txtApprovalUser.MaxLength = 20;
            this.txtApprovalUser.Name = "txtApprovalUser";
            this.txtApprovalUser.ReadOnly = true;
            this.txtApprovalUser.Size = new System.Drawing.Size(168, 20);
            this.txtApprovalUser.TabIndex = 2;
            this.txtApprovalUser.TabStop = false;
            // 
            // lblApprovalUser
            // 
            this.lblApprovalUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApprovalUser.Location = new System.Drawing.Point(9, 41);
            this.lblApprovalUser.Name = "lblApprovalUser";
            this.lblApprovalUser.Size = new System.Drawing.Size(92, 14);
            this.lblApprovalUser.TabIndex = 1;
            this.lblApprovalUser.Text = "Approval User";
            this.lblApprovalUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlVersionBottom
            // 
            this.pnlVersionBottom.Controls.Add(this.btnApproval);
            this.pnlVersionBottom.Controls.Add(this.btnCancelApproval);
            this.pnlVersionBottom.Controls.Add(this.btnRelease);
            this.pnlVersionBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlVersionBottom.Location = new System.Drawing.Point(3, 369);
            this.pnlVersionBottom.Name = "pnlVersionBottom";
            this.pnlVersionBottom.Size = new System.Drawing.Size(323, 32);
            this.pnlVersionBottom.TabIndex = 6;
            // 
            // btnApproval
            // 
            this.btnApproval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproval.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApproval.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApproval.Location = new System.Drawing.Point(3, 3);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(105, 26);
            this.btnApproval.TabIndex = 8;
            this.btnApproval.Text = "Approval";
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnCancelApproval
            // 
            this.btnCancelApproval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelApproval.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancelApproval.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelApproval.Location = new System.Drawing.Point(215, 3);
            this.btnCancelApproval.Name = "btnCancelApproval";
            this.btnCancelApproval.Size = new System.Drawing.Size(105, 26);
            this.btnCancelApproval.TabIndex = 10;
            this.btnCancelApproval.Text = "Cancel Approval";
            this.btnCancelApproval.Click += new System.EventHandler(this.btnCancelApproval_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRelease.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRelease.Location = new System.Drawing.Point(109, 3);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(105, 26);
            this.btnRelease.TabIndex = 9;
            this.btnRelease.Text = "Release";
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // tbpCopyVer
            // 
            this.tbpCopyVer.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCopyVer.Controls.Add(this.grpCopyTable);
            this.tbpCopyVer.Location = new System.Drawing.Point(4, 22);
            this.tbpCopyVer.Name = "tbpCopyVer";
            this.tbpCopyVer.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCopyVer.Size = new System.Drawing.Size(329, 401);
            this.tbpCopyVer.TabIndex = 3;
            this.tbpCopyVer.Text = "Copy Version";
            // 
            // grpCopyTable
            // 
            this.grpCopyTable.Controls.Add(this.btnCopyVersion);
            this.grpCopyTable.Controls.Add(this.lblToVersion);
            this.grpCopyTable.Controls.Add(this.txtToVersion);
            this.grpCopyTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyTable.Location = new System.Drawing.Point(3, 3);
            this.grpCopyTable.Name = "grpCopyTable";
            this.grpCopyTable.Size = new System.Drawing.Size(323, 49);
            this.grpCopyTable.TabIndex = 1;
            this.grpCopyTable.TabStop = false;
            // 
            // btnCopyVersion
            // 
            this.btnCopyVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopyVersion.Location = new System.Drawing.Point(208, 15);
            this.btnCopyVersion.Name = "btnCopyVersion";
            this.btnCopyVersion.Size = new System.Drawing.Size(84, 23);
            this.btnCopyVersion.TabIndex = 1;
            this.btnCopyVersion.Text = "Copy";
            this.btnCopyVersion.Click += new System.EventHandler(this.btnCopyVersion_Click);
            // 
            // lblToVersion
            // 
            this.lblToVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToVersion.Location = new System.Drawing.Point(8, 19);
            this.lblToVersion.Name = "lblToVersion";
            this.lblToVersion.Size = new System.Drawing.Size(70, 14);
            this.lblToVersion.TabIndex = 0;
            this.lblToVersion.Text = "To Version";
            this.lblToVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToVersion
            // 
            this.txtToVersion.Location = new System.Drawing.Point(83, 16);
            this.txtToVersion.MaxLength = 3;
            this.txtToVersion.Name = "txtToVersion";
            this.txtToVersion.Size = new System.Drawing.Size(123, 20);
            this.txtToVersion.TabIndex = 0;
            // 
            // pnlSpecVersion
            // 
            this.pnlSpecVersion.Controls.Add(this.grpCoSetVersion);
            this.pnlSpecVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpecVersion.Location = new System.Drawing.Point(144, 3);
            this.pnlSpecVersion.Name = "pnlSpecVersion";
            this.pnlSpecVersion.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlSpecVersion.Size = new System.Drawing.Size(343, 47);
            this.pnlSpecVersion.TabIndex = 2;
            // 
            // grpCoSetVersion
            // 
            this.grpCoSetVersion.Controls.Add(this.txtSpecVersion);
            this.grpCoSetVersion.Controls.Add(this.lblSpecVersion);
            this.grpCoSetVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCoSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCoSetVersion.Location = new System.Drawing.Point(3, 0);
            this.grpCoSetVersion.Name = "grpCoSetVersion";
            this.grpCoSetVersion.Size = new System.Drawing.Size(337, 47);
            this.grpCoSetVersion.TabIndex = 0;
            this.grpCoSetVersion.TabStop = false;
            // 
            // txtSpecVersion
            // 
            this.txtSpecVersion.Location = new System.Drawing.Point(163, 16);
            this.txtSpecVersion.MaxLength = 3;
            this.txtSpecVersion.Name = "txtSpecVersion";
            this.txtSpecVersion.Size = new System.Drawing.Size(125, 20);
            this.txtSpecVersion.TabIndex = 1;
            this.txtSpecVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpecVersion_KeyPress);
            // 
            // lblSpecVersion
            // 
            this.lblSpecVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecVersion.Location = new System.Drawing.Point(8, 19);
            this.lblSpecVersion.Name = "lblSpecVersion";
            this.lblSpecVersion.Size = new System.Drawing.Size(152, 14);
            this.lblSpecVersion.TabIndex = 0;
            this.lblSpecVersion.Text = "Spec. Rel Version";
            this.lblSpecVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisSpecVersion
            // 
            this.lisSpecVersion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSpecVersion});
            this.lisSpecVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisSpecVersion.EnableSort = true;
            this.lisSpecVersion.EnableSortIcon = true;
            this.lisSpecVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSpecVersion.FullRowSelect = true;
            this.lisSpecVersion.Location = new System.Drawing.Point(3, 3);
            this.lisSpecVersion.MultiSelect = false;
            this.lisSpecVersion.Name = "lisSpecVersion";
            this.lisSpecVersion.Size = new System.Drawing.Size(141, 474);
            this.lisSpecVersion.TabIndex = 1;
            this.lisSpecVersion.UseCompatibleStateImageBehavior = false;
            this.lisSpecVersion.View = System.Windows.Forms.View.Details;
            this.lisSpecVersion.SelectedIndexChanged += new System.EventHandler(this.lisSpecVersion_SelectedIndexChanged);
            this.lisSpecVersion.Click += new System.EventHandler(this.lisSpecVersion_Click);
            // 
            // colSpecVersion
            // 
            this.colSpecVersion.Text = "Spec. Rel Version";
            this.colSpecVersion.Width = 118;
            // 
            // tbpCharacter
            // 
            this.tbpCharacter.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCharacter.Controls.Add(this.pnlCharMid);
            this.tbpCharacter.Location = new System.Drawing.Point(4, 22);
            this.tbpCharacter.Name = "tbpCharacter";
            this.tbpCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCharacter.Size = new System.Drawing.Size(490, 480);
            this.tbpCharacter.TabIndex = 1;
            this.tbpCharacter.Text = "Assign Character";
            // 
            // pnlCharMid
            // 
            this.pnlCharMid.Controls.Add(this.pnlCharMidRight);
            this.pnlCharMid.Controls.Add(this.pnlCharMidMid);
            this.pnlCharMid.Controls.Add(this.pnlCharMidLeft);
            this.pnlCharMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharMid.Location = new System.Drawing.Point(3, 3);
            this.pnlCharMid.Name = "pnlCharMid";
            this.pnlCharMid.Size = new System.Drawing.Size(484, 474);
            this.pnlCharMid.TabIndex = 2;
            this.pnlCharMid.Resize += new System.EventHandler(this.pnlCharMid_Resize);
            // 
            // pnlCharMidRight
            // 
            this.pnlCharMidRight.Controls.Add(this.lisAllChar);
            this.pnlCharMidRight.Controls.Add(this.pnlAllCharFilter);
            this.pnlCharMidRight.Controls.Add(this.pnlCharRightBottom);
            this.pnlCharMidRight.Controls.Add(this.pnlChar2);
            this.pnlCharMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCharMidRight.Location = new System.Drawing.Point(264, 0);
            this.pnlCharMidRight.Name = "pnlCharMidRight";
            this.pnlCharMidRight.Size = new System.Drawing.Size(220, 474);
            this.pnlCharMidRight.TabIndex = 2;
            // 
            // lisAllChar
            // 
            this.lisAllChar.AllowDrop = true;
            this.lisAllChar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChar2,
            this.colCharDesc2});
            this.lisAllChar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAllChar.EnableSort = true;
            this.lisAllChar.EnableSortIcon = true;
            this.lisAllChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAllChar.FullRowSelect = true;
            this.lisAllChar.Location = new System.Drawing.Point(0, 51);
            this.lisAllChar.Name = "lisAllChar";
            this.lisAllChar.Size = new System.Drawing.Size(220, 396);
            this.lisAllChar.TabIndex = 2;
            this.lisAllChar.UseCompatibleStateImageBehavior = false;
            this.lisAllChar.View = System.Windows.Forms.View.Details;
            this.lisAllChar.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisAllChar_ItemDrag);
            this.lisAllChar.Click += new System.EventHandler(this.lisAllChar_Click);
            this.lisAllChar.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisAllChar_DragDrop);
            this.lisAllChar.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisAllChar_DragEnter);
            this.lisAllChar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisAllChar_MouseDown);
            // 
            // colChar2
            // 
            this.colChar2.Text = "Character ID";
            this.colChar2.Width = 100;
            // 
            // colCharDesc2
            // 
            this.colCharDesc2.Text = "Description";
            this.colCharDesc2.Width = 150;
            // 
            // pnlAllCharFilter
            // 
            this.pnlAllCharFilter.Controls.Add(this.txtAllCharFilter);
            this.pnlAllCharFilter.Controls.Add(this.lblAllCharFilter);
            this.pnlAllCharFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAllCharFilter.Location = new System.Drawing.Point(0, 24);
            this.pnlAllCharFilter.Name = "pnlAllCharFilter";
            this.pnlAllCharFilter.Size = new System.Drawing.Size(220, 27);
            this.pnlAllCharFilter.TabIndex = 1;
            // 
            // txtAllCharFilter
            // 
            this.txtAllCharFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAllCharFilter.Location = new System.Drawing.Point(87, 3);
            this.txtAllCharFilter.MaxLength = 30;
            this.txtAllCharFilter.Name = "txtAllCharFilter";
            this.txtAllCharFilter.Size = new System.Drawing.Size(131, 20);
            this.txtAllCharFilter.TabIndex = 1;
            this.txtAllCharFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAllCharFilter_KeyPress);
            // 
            // lblAllCharFilter
            // 
            this.lblAllCharFilter.AutoSize = true;
            this.lblAllCharFilter.Location = new System.Drawing.Point(7, 6);
            this.lblAllCharFilter.Name = "lblAllCharFilter";
            this.lblAllCharFilter.Size = new System.Drawing.Size(29, 13);
            this.lblAllCharFilter.TabIndex = 0;
            this.lblAllCharFilter.Text = "Filter";
            // 
            // pnlCharRightBottom
            // 
            this.pnlCharRightBottom.Controls.Add(this.txtAllCharCount);
            this.pnlCharRightBottom.Controls.Add(this.lblAllCharCount);
            this.pnlCharRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCharRightBottom.Location = new System.Drawing.Point(0, 447);
            this.pnlCharRightBottom.Name = "pnlCharRightBottom";
            this.pnlCharRightBottom.Size = new System.Drawing.Size(220, 27);
            this.pnlCharRightBottom.TabIndex = 3;
            // 
            // txtAllCharCount
            // 
            this.txtAllCharCount.Location = new System.Drawing.Point(87, 3);
            this.txtAllCharCount.MaxLength = 30;
            this.txtAllCharCount.Name = "txtAllCharCount";
            this.txtAllCharCount.ReadOnly = true;
            this.txtAllCharCount.Size = new System.Drawing.Size(126, 20);
            this.txtAllCharCount.TabIndex = 1;
            this.txtAllCharCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAllCharCount
            // 
            this.lblAllCharCount.AutoSize = true;
            this.lblAllCharCount.Location = new System.Drawing.Point(7, 6);
            this.lblAllCharCount.Name = "lblAllCharCount";
            this.lblAllCharCount.Size = new System.Drawing.Size(35, 13);
            this.lblAllCharCount.TabIndex = 0;
            this.lblAllCharCount.Text = "Count";
            // 
            // pnlChar2
            // 
            this.pnlChar2.Controls.Add(this.btnCharRefresh2);
            this.pnlChar2.Controls.Add(this.lblChar2);
            this.pnlChar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChar2.Location = new System.Drawing.Point(0, 0);
            this.pnlChar2.Name = "pnlChar2";
            this.pnlChar2.Size = new System.Drawing.Size(220, 24);
            this.pnlChar2.TabIndex = 0;
            // 
            // btnCharRefresh2
            // 
            this.btnCharRefresh2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCharRefresh2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCharRefresh2.Image = ((System.Drawing.Image)(resources.GetObject("btnCharRefresh2.Image")));
            this.btnCharRefresh2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCharRefresh2.Location = new System.Drawing.Point(196, 0);
            this.btnCharRefresh2.Name = "btnCharRefresh2";
            this.btnCharRefresh2.Size = new System.Drawing.Size(24, 24);
            this.btnCharRefresh2.TabIndex = 20;
            this.btnCharRefresh2.Click += new System.EventHandler(this.btnCharRefresh2_Click);
            // 
            // lblChar2
            // 
            this.lblChar2.AutoSize = true;
            this.lblChar2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChar2.Location = new System.Drawing.Point(3, 6);
            this.lblChar2.Name = "lblChar2";
            this.lblChar2.Size = new System.Drawing.Size(91, 13);
            this.lblChar2.TabIndex = 1;
            this.lblChar2.Text = "All Characters List";
            this.lblChar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCharMidMid
            // 
            this.pnlCharMidMid.Controls.Add(this.btnAttachAll);
            this.pnlCharMidMid.Controls.Add(this.btnDetach);
            this.pnlCharMidMid.Controls.Add(this.btnAttach);
            this.pnlCharMidMid.Location = new System.Drawing.Point(226, 54);
            this.pnlCharMidMid.Name = "pnlCharMidMid";
            this.pnlCharMidMid.Size = new System.Drawing.Size(34, 276);
            this.pnlCharMidMid.TabIndex = 0;
            // 
            // btnAttachAll
            // 
            this.btnAttachAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttachAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttachAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachAll.Location = new System.Drawing.Point(5, 136);
            this.btnAttachAll.Name = "btnAttachAll";
            this.btnAttachAll.Size = new System.Drawing.Size(24, 24);
            this.btnAttachAll.TabIndex = 0;
            this.btnAttachAll.Text = "<<";
            this.btnAttachAll.Click += new System.EventHandler(this.btnAttachAll_Click);
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetach.Location = new System.Drawing.Point(5, 36);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 2;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(5, 7);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 1;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // pnlCharMidLeft
            // 
            this.pnlCharMidLeft.Controls.Add(this.lisAssignedChar);
            this.pnlCharMidLeft.Controls.Add(this.pnlChar);
            this.pnlCharMidLeft.Controls.Add(this.pnlCharLeftBottom);
            this.pnlCharMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCharMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlCharMidLeft.Name = "pnlCharMidLeft";
            this.pnlCharMidLeft.Size = new System.Drawing.Size(220, 474);
            this.pnlCharMidLeft.TabIndex = 0;
            // 
            // lisAssignedChar
            // 
            this.lisAssignedChar.AllowDrop = true;
            this.lisAssignedChar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChar,
            this.colCharDesc});
            this.lisAssignedChar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAssignedChar.EnableSort = true;
            this.lisAssignedChar.EnableSortIcon = true;
            this.lisAssignedChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAssignedChar.FullRowSelect = true;
            this.lisAssignedChar.Location = new System.Drawing.Point(0, 24);
            this.lisAssignedChar.Name = "lisAssignedChar";
            this.lisAssignedChar.Size = new System.Drawing.Size(220, 423);
            this.lisAssignedChar.TabIndex = 1;
            this.lisAssignedChar.UseCompatibleStateImageBehavior = false;
            this.lisAssignedChar.View = System.Windows.Forms.View.Details;
            this.lisAssignedChar.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lisAssignedChar_ItemDrag);
            this.lisAssignedChar.Click += new System.EventHandler(this.lisAssignedChar_Click);
            this.lisAssignedChar.DragDrop += new System.Windows.Forms.DragEventHandler(this.lisAssignedChar_DragDrop);
            this.lisAssignedChar.DragEnter += new System.Windows.Forms.DragEventHandler(this.lisAssignedChar_DragEnter);
            this.lisAssignedChar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisAssignedChar_MouseDown);
            // 
            // colChar
            // 
            this.colChar.Text = "Character ID";
            this.colChar.Width = 100;
            // 
            // colCharDesc
            // 
            this.colCharDesc.Text = "Description";
            this.colCharDesc.Width = 150;
            // 
            // pnlChar
            // 
            this.pnlChar.Controls.Add(this.btnCharRefresh);
            this.pnlChar.Controls.Add(this.lblChar);
            this.pnlChar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChar.Location = new System.Drawing.Point(0, 0);
            this.pnlChar.Name = "pnlChar";
            this.pnlChar.Size = new System.Drawing.Size(220, 24);
            this.pnlChar.TabIndex = 0;
            // 
            // btnCharRefresh
            // 
            this.btnCharRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCharRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCharRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnCharRefresh.Image")));
            this.btnCharRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCharRefresh.Location = new System.Drawing.Point(196, 0);
            this.btnCharRefresh.Name = "btnCharRefresh";
            this.btnCharRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnCharRefresh.TabIndex = 19;
            this.btnCharRefresh.Click += new System.EventHandler(this.btnCharRefresh_Click);
            // 
            // lblChar
            // 
            this.lblChar.AutoSize = true;
            this.lblChar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChar.Location = new System.Drawing.Point(3, 6);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(123, 13);
            this.lblChar.TabIndex = 0;
            this.lblChar.Text = "Assigned Characters List";
            this.lblChar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCharLeftBottom
            // 
            this.pnlCharLeftBottom.Controls.Add(this.txtAssignedCharCount);
            this.pnlCharLeftBottom.Controls.Add(this.lblAssignedCharCount);
            this.pnlCharLeftBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCharLeftBottom.Location = new System.Drawing.Point(0, 447);
            this.pnlCharLeftBottom.Name = "pnlCharLeftBottom";
            this.pnlCharLeftBottom.Size = new System.Drawing.Size(220, 27);
            this.pnlCharLeftBottom.TabIndex = 2;
            // 
            // txtAssignedCharCount
            // 
            this.txtAssignedCharCount.Location = new System.Drawing.Point(87, 3);
            this.txtAssignedCharCount.MaxLength = 30;
            this.txtAssignedCharCount.Name = "txtAssignedCharCount";
            this.txtAssignedCharCount.ReadOnly = true;
            this.txtAssignedCharCount.Size = new System.Drawing.Size(126, 20);
            this.txtAssignedCharCount.TabIndex = 1;
            this.txtAssignedCharCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAssignedCharCount
            // 
            this.lblAssignedCharCount.AutoSize = true;
            this.lblAssignedCharCount.Location = new System.Drawing.Point(7, 6);
            this.lblAssignedCharCount.Name = "lblAssignedCharCount";
            this.lblAssignedCharCount.Size = new System.Drawing.Size(35, 13);
            this.lblAssignedCharCount.TabIndex = 0;
            this.lblAssignedCharCount.Text = "Count";
            // 
            // tbpLimit
            // 
            this.tbpLimit.BackColor = System.Drawing.SystemColors.Control;
            this.tbpLimit.Controls.Add(this.pnlLimitRight);
            this.tbpLimit.Controls.Add(this.splLimit);
            this.tbpLimit.Controls.Add(this.pnlLimitLeft);
            this.tbpLimit.Location = new System.Drawing.Point(4, 22);
            this.tbpLimit.Name = "tbpLimit";
            this.tbpLimit.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLimit.Size = new System.Drawing.Size(490, 480);
            this.tbpLimit.TabIndex = 2;
            this.tbpLimit.Text = "Limit Information";
            // 
            // pnlLimitRight
            // 
            this.pnlLimitRight.Controls.Add(this.tabLimit);
            this.pnlLimitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLimitRight.Location = new System.Drawing.Point(166, 3);
            this.pnlLimitRight.Name = "pnlLimitRight";
            this.pnlLimitRight.Size = new System.Drawing.Size(321, 474);
            this.pnlLimitRight.TabIndex = 0;
            // 
            // tabLimit
            // 
            this.tabLimit.Controls.Add(this.tbpManSpec);
            this.tabLimit.Controls.Add(this.tbpCusSpec);
            this.tabLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLimit.Location = new System.Drawing.Point(0, 0);
            this.tabLimit.Name = "tabLimit";
            this.tabLimit.SelectedIndex = 0;
            this.tabLimit.Size = new System.Drawing.Size(321, 474);
            this.tabLimit.TabIndex = 0;
            // 
            // tbpManSpec
            // 
            this.tbpManSpec.BackColor = System.Drawing.SystemColors.Control;
            this.tbpManSpec.Controls.Add(this.spdLimit);
            this.tbpManSpec.Controls.Add(this.grpSpecLimit);
            this.tbpManSpec.Location = new System.Drawing.Point(4, 22);
            this.tbpManSpec.Name = "tbpManSpec";
            this.tbpManSpec.Padding = new System.Windows.Forms.Padding(3);
            this.tbpManSpec.Size = new System.Drawing.Size(313, 448);
            this.tbpManSpec.TabIndex = 0;
            this.tbpManSpec.Text = "Manufacturing Specification";
            // 
            // spdLimit
            // 
            this.spdLimit.AccessibleDescription = "spdLimit, Sheet1, Row 0, Column 0, ";
            this.spdLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLimit.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLimit.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLimit.HorizontalScrollBar.Name = "";
            this.spdLimit.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLimit.HorizontalScrollBar.TabIndex = 4;
            this.spdLimit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLimit.Location = new System.Drawing.Point(3, 363);
            this.spdLimit.Name = "spdLimit";
            this.spdLimit.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdLimit.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdLimit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLimit_Sheet1});
            this.spdLimit.Size = new System.Drawing.Size(307, 82);
            this.spdLimit.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLimit.TabIndex = 1;
            this.spdLimit.TextTipDelay = 200;
            this.spdLimit.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLimit.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLimit.VerticalScrollBar.Name = "";
            this.spdLimit.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLimit.VerticalScrollBar.TabIndex = 5;
            this.spdLimit.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLimit.Visible = false;
            // 
            // spdLimit_Sheet1
            // 
            this.spdLimit_Sheet1.Reset();
            spdLimit_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLimit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLimit_Sheet1.ColumnCount = 3;
            spdLimit_Sheet1.RowCount = 1;
            this.spdLimit_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLimit_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLimit_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLimit_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLimit_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Key Prompt";
            this.spdLimit_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Data Prompt";
            this.spdLimit_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Limit";
            this.spdLimit_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLimit_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLimit_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLimit_Sheet1.Columns.Get(0).Label = "Key Prompt";
            this.spdLimit_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLimit_Sheet1.Columns.Get(0).Width = 80F;
            this.spdLimit_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLimit_Sheet1.Columns.Get(1).Label = "Data Prompt";
            this.spdLimit_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLimit_Sheet1.Columns.Get(1).Width = 80F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "",
        "Target",
        "Warn. Out",
        "Spec. Out"};
            this.spdLimit_Sheet1.Columns.Get(2).CellType = comboBoxCellType1;
            this.spdLimit_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLimit_Sheet1.Columns.Get(2).Label = "Limit";
            this.spdLimit_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLimit_Sheet1.Columns.Get(2).Width = 100F;
            this.spdLimit_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLimit_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLimit_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLimit_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLimit_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLimit_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLimit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpSpecLimit
            // 
            this.grpSpecLimit.Controls.Add(this.cdvTargetValue);
            this.grpSpecLimit.Controls.Add(this.lblValidTable);
            this.grpSpecLimit.Controls.Add(this.cdvValidTable);
            this.grpSpecLimit.Controls.Add(this.chkManSpec);
            this.grpSpecLimit.Controls.Add(this.lblAlarmCode2);
            this.grpSpecLimit.Controls.Add(this.lblAlarmCode1);
            this.grpSpecLimit.Controls.Add(this.cdvAlarmCode2);
            this.grpSpecLimit.Controls.Add(this.cdvAlarmCode1);
            this.grpSpecLimit.Controls.Add(this.cboSpecType);
            this.grpSpecLimit.Controls.Add(this.lblSpecType);
            this.grpSpecLimit.Controls.Add(this.lblSpecOutCount);
            this.grpSpecLimit.Controls.Add(this.txtSpecOutCount);
            this.grpSpecLimit.Controls.Add(this.lblLowerWarnLimit);
            this.grpSpecLimit.Controls.Add(this.txtLowerWarnLimit);
            this.grpSpecLimit.Controls.Add(this.lblUpperWarnLimit);
            this.grpSpecLimit.Controls.Add(this.txtUpperWarnLimit);
            this.grpSpecLimit.Controls.Add(this.lblLowerSpecLimit);
            this.grpSpecLimit.Controls.Add(this.txtLowerSpecLimit);
            this.grpSpecLimit.Controls.Add(this.lblUpperSpecLimit);
            this.grpSpecLimit.Controls.Add(this.txtUpperSpecLimit);
            this.grpSpecLimit.Controls.Add(this.lblTargetValue);
            this.grpSpecLimit.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSpecLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSpecLimit.Location = new System.Drawing.Point(3, 3);
            this.grpSpecLimit.Name = "grpSpecLimit";
            this.grpSpecLimit.Size = new System.Drawing.Size(307, 360);
            this.grpSpecLimit.TabIndex = 0;
            this.grpSpecLimit.TabStop = false;
            // 
            // cdvTargetValue
            // 
            this.cdvTargetValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvTargetValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTargetValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTargetValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTargetValue.BtnToolTipText = "";
            this.cdvTargetValue.ButtonWidth = 20;
            this.cdvTargetValue.DescText = "";
            this.cdvTargetValue.DisplaySubItemIndex = -1;
            this.cdvTargetValue.DisplayText = "";
            this.cdvTargetValue.Focusing = null;
            this.cdvTargetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTargetValue.Index = 0;
            this.cdvTargetValue.IsViewBtnImage = false;
            this.cdvTargetValue.Location = new System.Drawing.Point(120, 219);
            this.cdvTargetValue.MaxLength = 400;
            this.cdvTargetValue.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTargetValue.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTargetValue.Name = "cdvTargetValue";
            this.cdvTargetValue.ReadOnly = false;
            this.cdvTargetValue.SameWidthHeightOfButton = false;
            this.cdvTargetValue.SearchSubItemIndex = 0;
            this.cdvTargetValue.SelectedDescIndex = -1;
            this.cdvTargetValue.SelectedSubItemIndex = -1;
            this.cdvTargetValue.SelectionStart = 0;
            this.cdvTargetValue.Size = new System.Drawing.Size(180, 82);
            this.cdvTargetValue.SmallImageList = null;
            this.cdvTargetValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTargetValue.TabIndex = 16;
            this.cdvTargetValue.TextBoxToolTipText = "";
            this.cdvTargetValue.TextBoxWidth = 180;
            this.cdvTargetValue.VisibleButton = false;
            this.cdvTargetValue.VisibleColumnHeader = false;
            this.cdvTargetValue.VisibleDescription = false;
            this.cdvTargetValue.ButtonPress += new System.EventHandler(this.cdvTargetValue_ButtonPress);
            this.cdvTargetValue.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharValue_TextBoxKeyPress);
            // 
            // lblValidTable
            // 
            this.lblValidTable.AutoSize = true;
            this.lblValidTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValidTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidTable.Location = new System.Drawing.Point(14, 100);
            this.lblValidTable.Name = "lblValidTable";
            this.lblValidTable.Size = new System.Drawing.Size(60, 13);
            this.lblValidTable.TabIndex = 5;
            this.lblValidTable.Text = "Valid Table";
            this.lblValidTable.Visible = false;
            // 
            // cdvValidTable
            // 
            this.cdvValidTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValidTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValidTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValidTable.BtnToolTipText = "";
            this.cdvValidTable.ButtonWidth = 20;
            this.cdvValidTable.DescText = "";
            this.cdvValidTable.DisplaySubItemIndex = -1;
            this.cdvValidTable.DisplayText = "";
            this.cdvValidTable.Focusing = null;
            this.cdvValidTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValidTable.Index = 0;
            this.cdvValidTable.IsViewBtnImage = false;
            this.cdvValidTable.Location = new System.Drawing.Point(120, 96);
            this.cdvValidTable.MaxLength = 20;
            this.cdvValidTable.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValidTable.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValidTable.Name = "cdvValidTable";
            this.cdvValidTable.ReadOnly = false;
            this.cdvValidTable.SameWidthHeightOfButton = false;
            this.cdvValidTable.SearchSubItemIndex = 0;
            this.cdvValidTable.SelectedDescIndex = -1;
            this.cdvValidTable.SelectedSubItemIndex = -1;
            this.cdvValidTable.SelectionStart = 0;
            this.cdvValidTable.Size = new System.Drawing.Size(180, 20);
            this.cdvValidTable.SmallImageList = null;
            this.cdvValidTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValidTable.TabIndex = 6;
            this.cdvValidTable.TextBoxToolTipText = "";
            this.cdvValidTable.TextBoxWidth = 180;
            this.cdvValidTable.Visible = false;
            this.cdvValidTable.VisibleButton = true;
            this.cdvValidTable.VisibleColumnHeader = false;
            this.cdvValidTable.VisibleDescription = false;
            this.cdvValidTable.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvValidTable_SelectedItemChanged);
            this.cdvValidTable.ButtonPress += new System.EventHandler(this.cdvValidTable_ButtonPress);
            // 
            // chkManSpec
            // 
            this.chkManSpec.AutoSize = true;
            this.chkManSpec.Checked = true;
            this.chkManSpec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManSpec.Location = new System.Drawing.Point(14, 16);
            this.chkManSpec.Name = "chkManSpec";
            this.chkManSpec.Size = new System.Drawing.Size(206, 16);
            this.chkManSpec.TabIndex = 0;
            this.chkManSpec.Text = "Use Manufacturing Specification";
            this.chkManSpec.UseVisualStyleBackColor = true;
            this.chkManSpec.CheckedChanged += new System.EventHandler(this.chkManSpec_CheckedChanged);
            // 
            // lblAlarmCode2
            // 
            this.lblAlarmCode2.AutoSize = true;
            this.lblAlarmCode2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmCode2.Location = new System.Drawing.Point(14, 150);
            this.lblAlarmCode2.Name = "lblAlarmCode2";
            this.lblAlarmCode2.Size = new System.Drawing.Size(85, 13);
            this.lblAlarmCode2.TabIndex = 9;
            this.lblAlarmCode2.Text = "Warn. Out Alarm";
            // 
            // lblAlarmCode1
            // 
            this.lblAlarmCode1.AutoSize = true;
            this.lblAlarmCode1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmCode1.Location = new System.Drawing.Point(14, 125);
            this.lblAlarmCode1.Name = "lblAlarmCode1";
            this.lblAlarmCode1.Size = new System.Drawing.Size(84, 13);
            this.lblAlarmCode1.TabIndex = 7;
            this.lblAlarmCode1.Text = "Spec. Out Alarm";
            // 
            // cdvAlarmCode2
            // 
            this.cdvAlarmCode2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCode2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCode2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCode2.BtnToolTipText = "";
            this.cdvAlarmCode2.ButtonWidth = 20;
            this.cdvAlarmCode2.DescText = "";
            this.cdvAlarmCode2.DisplaySubItemIndex = -1;
            this.cdvAlarmCode2.DisplayText = "";
            this.cdvAlarmCode2.Focusing = null;
            this.cdvAlarmCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCode2.Index = 0;
            this.cdvAlarmCode2.IsViewBtnImage = false;
            this.cdvAlarmCode2.Location = new System.Drawing.Point(120, 146);
            this.cdvAlarmCode2.MaxLength = 20;
            this.cdvAlarmCode2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode2.Name = "cdvAlarmCode2";
            this.cdvAlarmCode2.ReadOnly = false;
            this.cdvAlarmCode2.SameWidthHeightOfButton = false;
            this.cdvAlarmCode2.SearchSubItemIndex = 0;
            this.cdvAlarmCode2.SelectedDescIndex = -1;
            this.cdvAlarmCode2.SelectedSubItemIndex = -1;
            this.cdvAlarmCode2.SelectionStart = 0;
            this.cdvAlarmCode2.Size = new System.Drawing.Size(180, 20);
            this.cdvAlarmCode2.SmallImageList = null;
            this.cdvAlarmCode2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCode2.TabIndex = 10;
            this.cdvAlarmCode2.TextBoxToolTipText = "";
            this.cdvAlarmCode2.TextBoxWidth = 180;
            this.cdvAlarmCode2.VisibleButton = true;
            this.cdvAlarmCode2.VisibleColumnHeader = false;
            this.cdvAlarmCode2.VisibleDescription = false;
            this.cdvAlarmCode2.ButtonPress += new System.EventHandler(this.cdvAlarmCode_ButtonPress);
            // 
            // cdvAlarmCode1
            // 
            this.cdvAlarmCode1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCode1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCode1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCode1.BtnToolTipText = "";
            this.cdvAlarmCode1.ButtonWidth = 20;
            this.cdvAlarmCode1.DescText = "";
            this.cdvAlarmCode1.DisplaySubItemIndex = -1;
            this.cdvAlarmCode1.DisplayText = "";
            this.cdvAlarmCode1.Focusing = null;
            this.cdvAlarmCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCode1.Index = 0;
            this.cdvAlarmCode1.IsViewBtnImage = false;
            this.cdvAlarmCode1.Location = new System.Drawing.Point(120, 121);
            this.cdvAlarmCode1.MaxLength = 20;
            this.cdvAlarmCode1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCode1.Name = "cdvAlarmCode1";
            this.cdvAlarmCode1.ReadOnly = false;
            this.cdvAlarmCode1.SameWidthHeightOfButton = false;
            this.cdvAlarmCode1.SearchSubItemIndex = 0;
            this.cdvAlarmCode1.SelectedDescIndex = -1;
            this.cdvAlarmCode1.SelectedSubItemIndex = -1;
            this.cdvAlarmCode1.SelectionStart = 0;
            this.cdvAlarmCode1.Size = new System.Drawing.Size(180, 20);
            this.cdvAlarmCode1.SmallImageList = null;
            this.cdvAlarmCode1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCode1.TabIndex = 8;
            this.cdvAlarmCode1.TextBoxToolTipText = "";
            this.cdvAlarmCode1.TextBoxWidth = 180;
            this.cdvAlarmCode1.VisibleButton = true;
            this.cdvAlarmCode1.VisibleColumnHeader = false;
            this.cdvAlarmCode1.VisibleDescription = false;
            this.cdvAlarmCode1.ButtonPress += new System.EventHandler(this.cdvAlarmCode_ButtonPress);
            // 
            // cboSpecType
            // 
            this.cboSpecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpecType.FormattingEnabled = true;
            this.cboSpecType.Location = new System.Drawing.Point(120, 47);
            this.cboSpecType.Name = "cboSpecType";
            this.cboSpecType.Size = new System.Drawing.Size(180, 21);
            this.cboSpecType.TabIndex = 2;
            this.cboSpecType.SelectedIndexChanged += new System.EventHandler(this.cboSpecType_SelectedIndexChanged);
            // 
            // lblSpecType
            // 
            this.lblSpecType.AutoSize = true;
            this.lblSpecType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecType.Location = new System.Drawing.Point(14, 50);
            this.lblSpecType.Name = "lblSpecType";
            this.lblSpecType.Size = new System.Drawing.Size(59, 13);
            this.lblSpecType.TabIndex = 1;
            this.lblSpecType.Text = "Spec Type";
            // 
            // lblSpecOutCount
            // 
            this.lblSpecOutCount.AutoSize = true;
            this.lblSpecOutCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpecOutCount.Location = new System.Drawing.Point(14, 75);
            this.lblSpecOutCount.Name = "lblSpecOutCount";
            this.lblSpecOutCount.Size = new System.Drawing.Size(83, 13);
            this.lblSpecOutCount.TabIndex = 3;
            this.lblSpecOutCount.Text = "Spec Out Count";
            // 
            // txtSpecOutCount
            // 
            this.txtSpecOutCount.Location = new System.Drawing.Point(120, 72);
            this.txtSpecOutCount.MaxLength = 3;
            this.txtSpecOutCount.Name = "txtSpecOutCount";
            this.txtSpecOutCount.Size = new System.Drawing.Size(180, 20);
            this.txtSpecOutCount.TabIndex = 4;
            this.txtSpecOutCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckInteger_TextBoxKeyPress);
            // 
            // lblLowerWarnLimit
            // 
            this.lblLowerWarnLimit.AutoSize = true;
            this.lblLowerWarnLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLowerWarnLimit.Location = new System.Drawing.Point(14, 313);
            this.lblLowerWarnLimit.Name = "lblLowerWarnLimit";
            this.lblLowerWarnLimit.Size = new System.Drawing.Size(92, 13);
            this.lblLowerWarnLimit.TabIndex = 17;
            this.lblLowerWarnLimit.Text = "Lower Warn. Limit";
            // 
            // txtLowerWarnLimit
            // 
            this.txtLowerWarnLimit.Location = new System.Drawing.Point(120, 310);
            this.txtLowerWarnLimit.MaxLength = 25;
            this.txtLowerWarnLimit.Name = "txtLowerWarnLimit";
            this.txtLowerWarnLimit.ReadOnly = true;
            this.txtLowerWarnLimit.Size = new System.Drawing.Size(180, 20);
            this.txtLowerWarnLimit.TabIndex = 18;
            // 
            // lblUpperWarnLimit
            // 
            this.lblUpperWarnLimit.AutoSize = true;
            this.lblUpperWarnLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpperWarnLimit.Location = new System.Drawing.Point(14, 198);
            this.lblUpperWarnLimit.Name = "lblUpperWarnLimit";
            this.lblUpperWarnLimit.Size = new System.Drawing.Size(92, 13);
            this.lblUpperWarnLimit.TabIndex = 13;
            this.lblUpperWarnLimit.Text = "Upper Warn. Limit";
            // 
            // txtUpperWarnLimit
            // 
            this.txtUpperWarnLimit.Location = new System.Drawing.Point(120, 195);
            this.txtUpperWarnLimit.MaxLength = 25;
            this.txtUpperWarnLimit.Name = "txtUpperWarnLimit";
            this.txtUpperWarnLimit.ReadOnly = true;
            this.txtUpperWarnLimit.Size = new System.Drawing.Size(180, 20);
            this.txtUpperWarnLimit.TabIndex = 14;
            // 
            // lblLowerSpecLimit
            // 
            this.lblLowerSpecLimit.AutoSize = true;
            this.lblLowerSpecLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLowerSpecLimit.Location = new System.Drawing.Point(14, 337);
            this.lblLowerSpecLimit.Name = "lblLowerSpecLimit";
            this.lblLowerSpecLimit.Size = new System.Drawing.Size(91, 13);
            this.lblLowerSpecLimit.TabIndex = 19;
            this.lblLowerSpecLimit.Text = "Lower Spec. Limit";
            // 
            // txtLowerSpecLimit
            // 
            this.txtLowerSpecLimit.Location = new System.Drawing.Point(120, 334);
            this.txtLowerSpecLimit.MaxLength = 25;
            this.txtLowerSpecLimit.Name = "txtLowerSpecLimit";
            this.txtLowerSpecLimit.ReadOnly = true;
            this.txtLowerSpecLimit.Size = new System.Drawing.Size(180, 20);
            this.txtLowerSpecLimit.TabIndex = 20;
            // 
            // lblUpperSpecLimit
            // 
            this.lblUpperSpecLimit.AutoSize = true;
            this.lblUpperSpecLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpperSpecLimit.Location = new System.Drawing.Point(14, 174);
            this.lblUpperSpecLimit.Name = "lblUpperSpecLimit";
            this.lblUpperSpecLimit.Size = new System.Drawing.Size(91, 13);
            this.lblUpperSpecLimit.TabIndex = 11;
            this.lblUpperSpecLimit.Text = "Upper Spec. Limit";
            // 
            // txtUpperSpecLimit
            // 
            this.txtUpperSpecLimit.Location = new System.Drawing.Point(120, 171);
            this.txtUpperSpecLimit.MaxLength = 25;
            this.txtUpperSpecLimit.Name = "txtUpperSpecLimit";
            this.txtUpperSpecLimit.ReadOnly = true;
            this.txtUpperSpecLimit.Size = new System.Drawing.Size(180, 20);
            this.txtUpperSpecLimit.TabIndex = 12;
            // 
            // lblTargetValue
            // 
            this.lblTargetValue.AutoSize = true;
            this.lblTargetValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetValue.Location = new System.Drawing.Point(14, 222);
            this.lblTargetValue.Name = "lblTargetValue";
            this.lblTargetValue.Size = new System.Drawing.Size(68, 13);
            this.lblTargetValue.TabIndex = 15;
            this.lblTargetValue.Text = "Target Value";
            // 
            // tbpCusSpec
            // 
            this.tbpCusSpec.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCusSpec.Controls.Add(this.spdCusLimit);
            this.tbpCusSpec.Controls.Add(this.grpCusSpecLimit);
            this.tbpCusSpec.Location = new System.Drawing.Point(4, 22);
            this.tbpCusSpec.Name = "tbpCusSpec";
            this.tbpCusSpec.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCusSpec.Size = new System.Drawing.Size(313, 448);
            this.tbpCusSpec.TabIndex = 1;
            this.tbpCusSpec.Text = "Customer Specification";
            // 
            // spdCusLimit
            // 
            this.spdCusLimit.AccessibleDescription = "spdCusLimit, Sheet1, Row 0, Column 0, ";
            this.spdCusLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCusLimit.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCusLimit.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCusLimit.HorizontalScrollBar.Name = "";
            this.spdCusLimit.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdCusLimit.HorizontalScrollBar.TabIndex = 4;
            this.spdCusLimit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCusLimit.Location = new System.Drawing.Point(3, 363);
            this.spdCusLimit.Name = "spdCusLimit";
            this.spdCusLimit.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCusLimit.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCusLimit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCusLimit_Sheet1});
            this.spdCusLimit.Size = new System.Drawing.Size(307, 82);
            this.spdCusLimit.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCusLimit.TabIndex = 1;
            this.spdCusLimit.TextTipDelay = 200;
            this.spdCusLimit.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCusLimit.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCusLimit.VerticalScrollBar.Name = "";
            this.spdCusLimit.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdCusLimit.VerticalScrollBar.TabIndex = 5;
            this.spdCusLimit.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCusLimit.Visible = false;
            // 
            // spdCusLimit_Sheet1
            // 
            this.spdCusLimit_Sheet1.Reset();
            spdCusLimit_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCusLimit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCusLimit_Sheet1.ColumnCount = 3;
            spdCusLimit_Sheet1.RowCount = 1;
            this.spdCusLimit_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCusLimit_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCusLimit_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCusLimit_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCusLimit_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Key Prompt";
            this.spdCusLimit_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Data Prompt";
            this.spdCusLimit_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Limit";
            this.spdCusLimit_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCusLimit_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCusLimit_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCusLimit_Sheet1.Columns.Get(0).Label = "Key Prompt";
            this.spdCusLimit_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCusLimit_Sheet1.Columns.Get(0).Width = 80F;
            this.spdCusLimit_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCusLimit_Sheet1.Columns.Get(1).Label = "Data Prompt";
            this.spdCusLimit_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCusLimit_Sheet1.Columns.Get(1).Width = 80F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "",
        "Target",
        "Warn. Out",
        "Spec. Out"};
            this.spdCusLimit_Sheet1.Columns.Get(2).CellType = comboBoxCellType2;
            this.spdCusLimit_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCusLimit_Sheet1.Columns.Get(2).Label = "Limit";
            this.spdCusLimit_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCusLimit_Sheet1.Columns.Get(2).Width = 100F;
            this.spdCusLimit_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCusLimit_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCusLimit_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCusLimit_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCusLimit_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCusLimit_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCusLimit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpCusSpecLimit
            // 
            this.grpCusSpecLimit.Controls.Add(this.cdvCusTargetValue);
            this.grpCusSpecLimit.Controls.Add(this.lblCusValidTable);
            this.grpCusSpecLimit.Controls.Add(this.cdvCusValidTable);
            this.grpCusSpecLimit.Controls.Add(this.chkCusSpec);
            this.grpCusSpecLimit.Controls.Add(this.lblCusAlarmCode2);
            this.grpCusSpecLimit.Controls.Add(this.lblCusAlarmCode1);
            this.grpCusSpecLimit.Controls.Add(this.cdvCusAlarmCode2);
            this.grpCusSpecLimit.Controls.Add(this.cdvCusAlarmCode1);
            this.grpCusSpecLimit.Controls.Add(this.cboCusSpecType);
            this.grpCusSpecLimit.Controls.Add(this.lblCusSpecType);
            this.grpCusSpecLimit.Controls.Add(this.lblCusSpecOutCount);
            this.grpCusSpecLimit.Controls.Add(this.txtCusSpecOutCount);
            this.grpCusSpecLimit.Controls.Add(this.lblCusLowerWarnLimit);
            this.grpCusSpecLimit.Controls.Add(this.txtCusLowerWarnLimit);
            this.grpCusSpecLimit.Controls.Add(this.lblCusUpperWarnLimit);
            this.grpCusSpecLimit.Controls.Add(this.txtCusUpperWarnLimit);
            this.grpCusSpecLimit.Controls.Add(this.lblCusLowerSpecLimit);
            this.grpCusSpecLimit.Controls.Add(this.txtCusLowerSpecLimit);
            this.grpCusSpecLimit.Controls.Add(this.lblCusUpperSpecLimit);
            this.grpCusSpecLimit.Controls.Add(this.txtCusUpperSpecLimit);
            this.grpCusSpecLimit.Controls.Add(this.lblCusTargetValue);
            this.grpCusSpecLimit.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCusSpecLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCusSpecLimit.Location = new System.Drawing.Point(3, 3);
            this.grpCusSpecLimit.Name = "grpCusSpecLimit";
            this.grpCusSpecLimit.Size = new System.Drawing.Size(307, 360);
            this.grpCusSpecLimit.TabIndex = 0;
            this.grpCusSpecLimit.TabStop = false;
            // 
            // cdvCusTargetValue
            // 
            this.cdvCusTargetValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCusTargetValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCusTargetValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCusTargetValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCusTargetValue.BtnToolTipText = "";
            this.cdvCusTargetValue.ButtonWidth = 20;
            this.cdvCusTargetValue.DescText = "";
            this.cdvCusTargetValue.DisplaySubItemIndex = -1;
            this.cdvCusTargetValue.DisplayText = "";
            this.cdvCusTargetValue.Focusing = null;
            this.cdvCusTargetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCusTargetValue.Index = 0;
            this.cdvCusTargetValue.IsViewBtnImage = false;
            this.cdvCusTargetValue.Location = new System.Drawing.Point(120, 219);
            this.cdvCusTargetValue.MaxLength = 400;
            this.cdvCusTargetValue.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCusTargetValue.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCusTargetValue.Name = "cdvCusTargetValue";
            this.cdvCusTargetValue.ReadOnly = false;
            this.cdvCusTargetValue.SameWidthHeightOfButton = false;
            this.cdvCusTargetValue.SearchSubItemIndex = 0;
            this.cdvCusTargetValue.SelectedDescIndex = -1;
            this.cdvCusTargetValue.SelectedSubItemIndex = -1;
            this.cdvCusTargetValue.SelectionStart = 0;
            this.cdvCusTargetValue.Size = new System.Drawing.Size(180, 82);
            this.cdvCusTargetValue.SmallImageList = null;
            this.cdvCusTargetValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCusTargetValue.TabIndex = 16;
            this.cdvCusTargetValue.TextBoxToolTipText = "";
            this.cdvCusTargetValue.TextBoxWidth = 180;
            this.cdvCusTargetValue.VisibleButton = false;
            this.cdvCusTargetValue.VisibleColumnHeader = false;
            this.cdvCusTargetValue.VisibleDescription = false;
            this.cdvCusTargetValue.ButtonPress += new System.EventHandler(this.cdvCusTargetValue_ButtonPress);
            this.cdvCusTargetValue.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharValue_TextBoxKeyPress);
            // 
            // lblCusValidTable
            // 
            this.lblCusValidTable.AutoSize = true;
            this.lblCusValidTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusValidTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusValidTable.Location = new System.Drawing.Point(14, 100);
            this.lblCusValidTable.Name = "lblCusValidTable";
            this.lblCusValidTable.Size = new System.Drawing.Size(60, 13);
            this.lblCusValidTable.TabIndex = 5;
            this.lblCusValidTable.Text = "Valid Table";
            this.lblCusValidTable.Visible = false;
            // 
            // cdvCusValidTable
            // 
            this.cdvCusValidTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCusValidTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCusValidTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCusValidTable.BtnToolTipText = "";
            this.cdvCusValidTable.ButtonWidth = 20;
            this.cdvCusValidTable.DescText = "";
            this.cdvCusValidTable.DisplaySubItemIndex = -1;
            this.cdvCusValidTable.DisplayText = "";
            this.cdvCusValidTable.Focusing = null;
            this.cdvCusValidTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCusValidTable.Index = 0;
            this.cdvCusValidTable.IsViewBtnImage = false;
            this.cdvCusValidTable.Location = new System.Drawing.Point(120, 96);
            this.cdvCusValidTable.MaxLength = 20;
            this.cdvCusValidTable.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCusValidTable.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCusValidTable.Name = "cdvCusValidTable";
            this.cdvCusValidTable.ReadOnly = false;
            this.cdvCusValidTable.SameWidthHeightOfButton = false;
            this.cdvCusValidTable.SearchSubItemIndex = 0;
            this.cdvCusValidTable.SelectedDescIndex = -1;
            this.cdvCusValidTable.SelectedSubItemIndex = -1;
            this.cdvCusValidTable.SelectionStart = 0;
            this.cdvCusValidTable.Size = new System.Drawing.Size(180, 20);
            this.cdvCusValidTable.SmallImageList = null;
            this.cdvCusValidTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCusValidTable.TabIndex = 6;
            this.cdvCusValidTable.TextBoxToolTipText = "";
            this.cdvCusValidTable.TextBoxWidth = 180;
            this.cdvCusValidTable.Visible = false;
            this.cdvCusValidTable.VisibleButton = true;
            this.cdvCusValidTable.VisibleColumnHeader = false;
            this.cdvCusValidTable.VisibleDescription = false;
            this.cdvCusValidTable.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCusValidTable_SelectedItemChanged);
            this.cdvCusValidTable.ButtonPress += new System.EventHandler(this.cdvValidTable_ButtonPress);
            // 
            // chkCusSpec
            // 
            this.chkCusSpec.AutoSize = true;
            this.chkCusSpec.Location = new System.Drawing.Point(14, 16);
            this.chkCusSpec.Name = "chkCusSpec";
            this.chkCusSpec.Size = new System.Drawing.Size(181, 16);
            this.chkCusSpec.TabIndex = 0;
            this.chkCusSpec.Text = "Use Customer Specification";
            this.chkCusSpec.UseVisualStyleBackColor = true;
            this.chkCusSpec.CheckedChanged += new System.EventHandler(this.chkCusSpec_CheckedChanged);
            // 
            // lblCusAlarmCode2
            // 
            this.lblCusAlarmCode2.AutoSize = true;
            this.lblCusAlarmCode2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusAlarmCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusAlarmCode2.Location = new System.Drawing.Point(14, 150);
            this.lblCusAlarmCode2.Name = "lblCusAlarmCode2";
            this.lblCusAlarmCode2.Size = new System.Drawing.Size(85, 13);
            this.lblCusAlarmCode2.TabIndex = 9;
            this.lblCusAlarmCode2.Text = "Warn. Out Alarm";
            // 
            // lblCusAlarmCode1
            // 
            this.lblCusAlarmCode1.AutoSize = true;
            this.lblCusAlarmCode1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusAlarmCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusAlarmCode1.Location = new System.Drawing.Point(14, 125);
            this.lblCusAlarmCode1.Name = "lblCusAlarmCode1";
            this.lblCusAlarmCode1.Size = new System.Drawing.Size(84, 13);
            this.lblCusAlarmCode1.TabIndex = 7;
            this.lblCusAlarmCode1.Text = "Spec. Out Alarm";
            // 
            // cdvCusAlarmCode2
            // 
            this.cdvCusAlarmCode2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCusAlarmCode2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCusAlarmCode2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCusAlarmCode2.BtnToolTipText = "";
            this.cdvCusAlarmCode2.ButtonWidth = 20;
            this.cdvCusAlarmCode2.DescText = "";
            this.cdvCusAlarmCode2.DisplaySubItemIndex = -1;
            this.cdvCusAlarmCode2.DisplayText = "";
            this.cdvCusAlarmCode2.Focusing = null;
            this.cdvCusAlarmCode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCusAlarmCode2.Index = 0;
            this.cdvCusAlarmCode2.IsViewBtnImage = false;
            this.cdvCusAlarmCode2.Location = new System.Drawing.Point(120, 146);
            this.cdvCusAlarmCode2.MaxLength = 20;
            this.cdvCusAlarmCode2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCusAlarmCode2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCusAlarmCode2.Name = "cdvCusAlarmCode2";
            this.cdvCusAlarmCode2.ReadOnly = false;
            this.cdvCusAlarmCode2.SameWidthHeightOfButton = false;
            this.cdvCusAlarmCode2.SearchSubItemIndex = 0;
            this.cdvCusAlarmCode2.SelectedDescIndex = -1;
            this.cdvCusAlarmCode2.SelectedSubItemIndex = -1;
            this.cdvCusAlarmCode2.SelectionStart = 0;
            this.cdvCusAlarmCode2.Size = new System.Drawing.Size(180, 20);
            this.cdvCusAlarmCode2.SmallImageList = null;
            this.cdvCusAlarmCode2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCusAlarmCode2.TabIndex = 10;
            this.cdvCusAlarmCode2.TextBoxToolTipText = "";
            this.cdvCusAlarmCode2.TextBoxWidth = 180;
            this.cdvCusAlarmCode2.VisibleButton = true;
            this.cdvCusAlarmCode2.VisibleColumnHeader = false;
            this.cdvCusAlarmCode2.VisibleDescription = false;
            this.cdvCusAlarmCode2.ButtonPress += new System.EventHandler(this.cdvAlarmCode_ButtonPress);
            // 
            // cdvCusAlarmCode1
            // 
            this.cdvCusAlarmCode1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCusAlarmCode1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCusAlarmCode1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCusAlarmCode1.BtnToolTipText = "";
            this.cdvCusAlarmCode1.ButtonWidth = 20;
            this.cdvCusAlarmCode1.DescText = "";
            this.cdvCusAlarmCode1.DisplaySubItemIndex = -1;
            this.cdvCusAlarmCode1.DisplayText = "";
            this.cdvCusAlarmCode1.Focusing = null;
            this.cdvCusAlarmCode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCusAlarmCode1.Index = 0;
            this.cdvCusAlarmCode1.IsViewBtnImage = false;
            this.cdvCusAlarmCode1.Location = new System.Drawing.Point(120, 121);
            this.cdvCusAlarmCode1.MaxLength = 20;
            this.cdvCusAlarmCode1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCusAlarmCode1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCusAlarmCode1.Name = "cdvCusAlarmCode1";
            this.cdvCusAlarmCode1.ReadOnly = false;
            this.cdvCusAlarmCode1.SameWidthHeightOfButton = false;
            this.cdvCusAlarmCode1.SearchSubItemIndex = 0;
            this.cdvCusAlarmCode1.SelectedDescIndex = -1;
            this.cdvCusAlarmCode1.SelectedSubItemIndex = -1;
            this.cdvCusAlarmCode1.SelectionStart = 0;
            this.cdvCusAlarmCode1.Size = new System.Drawing.Size(180, 20);
            this.cdvCusAlarmCode1.SmallImageList = null;
            this.cdvCusAlarmCode1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCusAlarmCode1.TabIndex = 8;
            this.cdvCusAlarmCode1.TextBoxToolTipText = "";
            this.cdvCusAlarmCode1.TextBoxWidth = 180;
            this.cdvCusAlarmCode1.VisibleButton = true;
            this.cdvCusAlarmCode1.VisibleColumnHeader = false;
            this.cdvCusAlarmCode1.VisibleDescription = false;
            this.cdvCusAlarmCode1.ButtonPress += new System.EventHandler(this.cdvAlarmCode_ButtonPress);
            // 
            // cboCusSpecType
            // 
            this.cboCusSpecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCusSpecType.FormattingEnabled = true;
            this.cboCusSpecType.Location = new System.Drawing.Point(120, 47);
            this.cboCusSpecType.Name = "cboCusSpecType";
            this.cboCusSpecType.Size = new System.Drawing.Size(180, 21);
            this.cboCusSpecType.TabIndex = 2;
            this.cboCusSpecType.SelectionChangeCommitted += new System.EventHandler(this.cboCusSpecType_SelectedIndexChanged);
            // 
            // lblCusSpecType
            // 
            this.lblCusSpecType.AutoSize = true;
            this.lblCusSpecType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusSpecType.Location = new System.Drawing.Point(14, 50);
            this.lblCusSpecType.Name = "lblCusSpecType";
            this.lblCusSpecType.Size = new System.Drawing.Size(59, 13);
            this.lblCusSpecType.TabIndex = 1;
            this.lblCusSpecType.Text = "Spec Type";
            // 
            // lblCusSpecOutCount
            // 
            this.lblCusSpecOutCount.AutoSize = true;
            this.lblCusSpecOutCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusSpecOutCount.Location = new System.Drawing.Point(14, 75);
            this.lblCusSpecOutCount.Name = "lblCusSpecOutCount";
            this.lblCusSpecOutCount.Size = new System.Drawing.Size(83, 13);
            this.lblCusSpecOutCount.TabIndex = 3;
            this.lblCusSpecOutCount.Text = "Spec Out Count";
            // 
            // txtCusSpecOutCount
            // 
            this.txtCusSpecOutCount.Location = new System.Drawing.Point(120, 72);
            this.txtCusSpecOutCount.MaxLength = 3;
            this.txtCusSpecOutCount.Name = "txtCusSpecOutCount";
            this.txtCusSpecOutCount.Size = new System.Drawing.Size(180, 20);
            this.txtCusSpecOutCount.TabIndex = 4;
            // 
            // lblCusLowerWarnLimit
            // 
            this.lblCusLowerWarnLimit.AutoSize = true;
            this.lblCusLowerWarnLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusLowerWarnLimit.Location = new System.Drawing.Point(14, 313);
            this.lblCusLowerWarnLimit.Name = "lblCusLowerWarnLimit";
            this.lblCusLowerWarnLimit.Size = new System.Drawing.Size(92, 13);
            this.lblCusLowerWarnLimit.TabIndex = 17;
            this.lblCusLowerWarnLimit.Text = "Lower Warn. Limit";
            // 
            // txtCusLowerWarnLimit
            // 
            this.txtCusLowerWarnLimit.Location = new System.Drawing.Point(120, 310);
            this.txtCusLowerWarnLimit.MaxLength = 25;
            this.txtCusLowerWarnLimit.Name = "txtCusLowerWarnLimit";
            this.txtCusLowerWarnLimit.ReadOnly = true;
            this.txtCusLowerWarnLimit.Size = new System.Drawing.Size(180, 20);
            this.txtCusLowerWarnLimit.TabIndex = 18;
            // 
            // lblCusUpperWarnLimit
            // 
            this.lblCusUpperWarnLimit.AutoSize = true;
            this.lblCusUpperWarnLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusUpperWarnLimit.Location = new System.Drawing.Point(14, 198);
            this.lblCusUpperWarnLimit.Name = "lblCusUpperWarnLimit";
            this.lblCusUpperWarnLimit.Size = new System.Drawing.Size(92, 13);
            this.lblCusUpperWarnLimit.TabIndex = 13;
            this.lblCusUpperWarnLimit.Text = "Upper Warn. Limit";
            // 
            // txtCusUpperWarnLimit
            // 
            this.txtCusUpperWarnLimit.Location = new System.Drawing.Point(120, 195);
            this.txtCusUpperWarnLimit.MaxLength = 25;
            this.txtCusUpperWarnLimit.Name = "txtCusUpperWarnLimit";
            this.txtCusUpperWarnLimit.ReadOnly = true;
            this.txtCusUpperWarnLimit.Size = new System.Drawing.Size(180, 20);
            this.txtCusUpperWarnLimit.TabIndex = 14;
            // 
            // lblCusLowerSpecLimit
            // 
            this.lblCusLowerSpecLimit.AutoSize = true;
            this.lblCusLowerSpecLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusLowerSpecLimit.Location = new System.Drawing.Point(14, 337);
            this.lblCusLowerSpecLimit.Name = "lblCusLowerSpecLimit";
            this.lblCusLowerSpecLimit.Size = new System.Drawing.Size(91, 13);
            this.lblCusLowerSpecLimit.TabIndex = 19;
            this.lblCusLowerSpecLimit.Text = "Lower Spec. Limit";
            // 
            // txtCusLowerSpecLimit
            // 
            this.txtCusLowerSpecLimit.Location = new System.Drawing.Point(120, 334);
            this.txtCusLowerSpecLimit.MaxLength = 25;
            this.txtCusLowerSpecLimit.Name = "txtCusLowerSpecLimit";
            this.txtCusLowerSpecLimit.ReadOnly = true;
            this.txtCusLowerSpecLimit.Size = new System.Drawing.Size(180, 20);
            this.txtCusLowerSpecLimit.TabIndex = 20;
            // 
            // lblCusUpperSpecLimit
            // 
            this.lblCusUpperSpecLimit.AutoSize = true;
            this.lblCusUpperSpecLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusUpperSpecLimit.Location = new System.Drawing.Point(14, 174);
            this.lblCusUpperSpecLimit.Name = "lblCusUpperSpecLimit";
            this.lblCusUpperSpecLimit.Size = new System.Drawing.Size(91, 13);
            this.lblCusUpperSpecLimit.TabIndex = 11;
            this.lblCusUpperSpecLimit.Text = "Upper Spec. Limit";
            // 
            // txtCusUpperSpecLimit
            // 
            this.txtCusUpperSpecLimit.Location = new System.Drawing.Point(120, 171);
            this.txtCusUpperSpecLimit.MaxLength = 25;
            this.txtCusUpperSpecLimit.Name = "txtCusUpperSpecLimit";
            this.txtCusUpperSpecLimit.ReadOnly = true;
            this.txtCusUpperSpecLimit.Size = new System.Drawing.Size(180, 20);
            this.txtCusUpperSpecLimit.TabIndex = 12;
            // 
            // lblCusTargetValue
            // 
            this.lblCusTargetValue.AutoSize = true;
            this.lblCusTargetValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCusTargetValue.Location = new System.Drawing.Point(14, 222);
            this.lblCusTargetValue.Name = "lblCusTargetValue";
            this.lblCusTargetValue.Size = new System.Drawing.Size(68, 13);
            this.lblCusTargetValue.TabIndex = 15;
            this.lblCusTargetValue.Text = "Target Value";
            // 
            // splLimit
            // 
            this.splLimit.Location = new System.Drawing.Point(163, 3);
            this.splLimit.Name = "splLimit";
            this.splLimit.Size = new System.Drawing.Size(3, 474);
            this.splLimit.TabIndex = 1;
            this.splLimit.TabStop = false;
            // 
            // pnlLimitLeft
            // 
            this.pnlLimitLeft.Controls.Add(this.pnlCharMidLeft3);
            this.pnlLimitLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLimitLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLimitLeft.Name = "pnlLimitLeft";
            this.pnlLimitLeft.Size = new System.Drawing.Size(160, 474);
            this.pnlLimitLeft.TabIndex = 0;
            // 
            // pnlCharMidLeft3
            // 
            this.pnlCharMidLeft3.Controls.Add(this.lisAssignedChar3);
            this.pnlCharMidLeft3.Controls.Add(this.pnlChar3);
            this.pnlCharMidLeft3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharMidLeft3.Location = new System.Drawing.Point(0, 0);
            this.pnlCharMidLeft3.Name = "pnlCharMidLeft3";
            this.pnlCharMidLeft3.Size = new System.Drawing.Size(160, 474);
            this.pnlCharMidLeft3.TabIndex = 0;
            // 
            // lisAssignedChar3
            // 
            this.lisAssignedChar3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChar3,
            this.colCharDesc3,
            this.colCharType3});
            this.lisAssignedChar3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAssignedChar3.EnableSort = true;
            this.lisAssignedChar3.EnableSortIcon = true;
            this.lisAssignedChar3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAssignedChar3.FullRowSelect = true;
            this.lisAssignedChar3.Location = new System.Drawing.Point(0, 24);
            this.lisAssignedChar3.MultiSelect = false;
            this.lisAssignedChar3.Name = "lisAssignedChar3";
            this.lisAssignedChar3.Size = new System.Drawing.Size(160, 450);
            this.lisAssignedChar3.TabIndex = 0;
            this.lisAssignedChar3.UseCompatibleStateImageBehavior = false;
            this.lisAssignedChar3.View = System.Windows.Forms.View.Details;
            this.lisAssignedChar3.SelectedIndexChanged += new System.EventHandler(this.lisAssignedChar3_SelectedIndexChanged);
            // 
            // colChar3
            // 
            this.colChar3.Text = "Character ID";
            this.colChar3.Width = 100;
            // 
            // colCharDesc3
            // 
            this.colCharDesc3.Text = "Description";
            this.colCharDesc3.Width = 150;
            // 
            // colCharType3
            // 
            this.colCharType3.Text = "Type";
            this.colCharType3.Width = 0;
            // 
            // pnlChar3
            // 
            this.pnlChar3.Controls.Add(this.btnCharRefresh3);
            this.pnlChar3.Controls.Add(this.lblChar3);
            this.pnlChar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChar3.Location = new System.Drawing.Point(0, 0);
            this.pnlChar3.Name = "pnlChar3";
            this.pnlChar3.Size = new System.Drawing.Size(160, 24);
            this.pnlChar3.TabIndex = 0;
            // 
            // btnCharRefresh3
            // 
            this.btnCharRefresh3.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCharRefresh3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCharRefresh3.Image = ((System.Drawing.Image)(resources.GetObject("btnCharRefresh3.Image")));
            this.btnCharRefresh3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCharRefresh3.Location = new System.Drawing.Point(136, 0);
            this.btnCharRefresh3.Name = "btnCharRefresh3";
            this.btnCharRefresh3.Size = new System.Drawing.Size(24, 24);
            this.btnCharRefresh3.TabIndex = 0;
            this.btnCharRefresh3.Click += new System.EventHandler(this.btnCharRefresh3_Click);
            // 
            // lblChar3
            // 
            this.lblChar3.AutoSize = true;
            this.lblChar3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChar3.Location = new System.Drawing.Point(3, 6);
            this.lblChar3.Name = "lblChar3";
            this.lblChar3.Size = new System.Drawing.Size(123, 13);
            this.lblChar3.TabIndex = 0;
            this.lblChar3.Text = "Assigned Characters List";
            this.lblChar3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpAttr
            // 
            this.tbpAttr.BackColor = System.Drawing.SystemColors.Control;
            this.tbpAttr.Controls.Add(this.pnlAttrRight);
            this.tbpAttr.Controls.Add(this.splAttr);
            this.tbpAttr.Controls.Add(this.pnlAttrLeft);
            this.tbpAttr.Location = new System.Drawing.Point(4, 22);
            this.tbpAttr.Name = "tbpAttr";
            this.tbpAttr.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAttr.Size = new System.Drawing.Size(490, 480);
            this.tbpAttr.TabIndex = 3;
            this.tbpAttr.Text = "Spec Attribute";
            // 
            // pnlAttrRight
            // 
            this.pnlAttrRight.Controls.Add(this.grpAttr);
            this.pnlAttrRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttrRight.Location = new System.Drawing.Point(166, 3);
            this.pnlAttrRight.Name = "pnlAttrRight";
            this.pnlAttrRight.Size = new System.Drawing.Size(321, 474);
            this.pnlAttrRight.TabIndex = 0;
            // 
            // grpAttr
            // 
            this.grpAttr.Controls.Add(this.spdAttr);
            this.grpAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttr.Location = new System.Drawing.Point(0, 0);
            this.grpAttr.Name = "grpAttr";
            this.grpAttr.Size = new System.Drawing.Size(321, 474);
            this.grpAttr.TabIndex = 0;
            this.grpAttr.TabStop = false;
            this.grpAttr.Text = "Specification Attribute";
            this.grpAttr.Resize += new System.EventHandler(this.grpAttr_Resize);
            // 
            // spdAttr
            // 
            this.spdAttr.AccessibleDescription = "spdAttrValue, Sheet1";
            this.spdAttr.BackColor = System.Drawing.SystemColors.Control;
            this.spdAttr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAttr.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdAttr.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttr.HorizontalScrollBar.Name = "";
            this.spdAttr.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdAttr.HorizontalScrollBar.TabIndex = 34;
            this.spdAttr.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttr.Location = new System.Drawing.Point(3, 16);
            this.spdAttr.Name = "spdAttr";
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
            this.spdAttr.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdAttr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdAttr.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAttr.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAttr.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAttr_Sheet1});
            this.spdAttr.Size = new System.Drawing.Size(315, 455);
            this.spdAttr.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAttr.TabIndex = 0;
            this.spdAttr.TextTipDelay = 200;
            this.spdAttr.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAttr.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttr.VerticalScrollBar.Name = "";
            this.spdAttr.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdAttr.VerticalScrollBar.TabIndex = 35;
            this.spdAttr.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttr.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdAttr_EnterCell);
            this.spdAttr.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttr_ButtonClicked);
            this.spdAttr.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttr_EditChange);
            this.spdAttr.SetActiveViewport(0, -1, -1);
            // 
            // spdAttr_Sheet1
            // 
            this.spdAttr_Sheet1.Reset();
            spdAttr_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAttr_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAttr_Sheet1.ColumnCount = 7;
            spdAttr_Sheet1.RowCount = 0;
            this.spdAttr_Sheet1.ActiveColumnIndex = -1;
            this.spdAttr_Sheet1.ActiveRowIndex = -1;
            this.spdAttr_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttr_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttr_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttr_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAttr_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdAttr_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Name";
            this.spdAttr_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdAttr_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Current Value";
            this.spdAttr_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdAttr_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "New Value";
            this.spdAttr_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Null";
            this.spdAttr_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttr_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttr_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttr_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdAttr_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttr_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdAttr_Sheet1.Columns.Get(0).Locked = true;
            this.spdAttr_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttr_Sheet1.Columns.Get(0).Visible = false;
            this.spdAttr_Sheet1.Columns.Get(0).Width = 42F;
            this.spdAttr_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType1.MaxLength = 100;
            textCellType1.Multiline = true;
            this.spdAttr_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdAttr_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttr_Sheet1.Columns.Get(1).Label = "Name";
            this.spdAttr_Sheet1.Columns.Get(1).Locked = true;
            this.spdAttr_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttr_Sheet1.Columns.Get(1).Width = 100F;
            this.spdAttr_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType2.MaxLength = 100;
            textCellType2.Multiline = true;
            this.spdAttr_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.spdAttr_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttr_Sheet1.Columns.Get(2).Label = "Description";
            this.spdAttr_Sheet1.Columns.Get(2).Locked = true;
            this.spdAttr_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttr_Sheet1.Columns.Get(2).Width = 140F;
            this.spdAttr_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType3.MaxLength = 110;
            textCellType3.Multiline = true;
            this.spdAttr_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.spdAttr_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttr_Sheet1.Columns.Get(3).Label = "Current Value";
            this.spdAttr_Sheet1.Columns.Get(3).Locked = true;
            this.spdAttr_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttr_Sheet1.Columns.Get(3).Width = 80F;
            this.spdAttr_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.White;
            this.spdAttr_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.spdAttr_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttr_Sheet1.Columns.Get(4).Label = "New Value";
            this.spdAttr_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttr_Sheet1.Columns.Get(4).Width = 80F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdAttr_Sheet1.Columns.Get(5).CellType = buttonCellType1;
            this.spdAttr_Sheet1.Columns.Get(5).Width = 20F;
            this.spdAttr_Sheet1.Columns.Get(6).CellType = checkBoxCellType2;
            this.spdAttr_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttr_Sheet1.Columns.Get(6).Label = "Null";
            this.spdAttr_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttr_Sheet1.Columns.Get(6).Width = 40F;
            this.spdAttr_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAttr_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdAttr_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAttr_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttr_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAttr_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttr_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAttr_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splAttr
            // 
            this.splAttr.Location = new System.Drawing.Point(163, 3);
            this.splAttr.Name = "splAttr";
            this.splAttr.Size = new System.Drawing.Size(3, 474);
            this.splAttr.TabIndex = 5;
            this.splAttr.TabStop = false;
            // 
            // pnlAttrLeft
            // 
            this.pnlAttrLeft.Controls.Add(this.pnlCharMidLeft4);
            this.pnlAttrLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAttrLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlAttrLeft.Name = "pnlAttrLeft";
            this.pnlAttrLeft.Size = new System.Drawing.Size(160, 474);
            this.pnlAttrLeft.TabIndex = 0;
            // 
            // pnlCharMidLeft4
            // 
            this.pnlCharMidLeft4.Controls.Add(this.lisAssignedChar4);
            this.pnlCharMidLeft4.Controls.Add(this.pnlChar4);
            this.pnlCharMidLeft4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharMidLeft4.Location = new System.Drawing.Point(0, 0);
            this.pnlCharMidLeft4.Name = "pnlCharMidLeft4";
            this.pnlCharMidLeft4.Size = new System.Drawing.Size(160, 474);
            this.pnlCharMidLeft4.TabIndex = 0;
            // 
            // lisAssignedChar4
            // 
            this.lisAssignedChar4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChar4,
            this.colCharDesc4});
            this.lisAssignedChar4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAssignedChar4.EnableSort = true;
            this.lisAssignedChar4.EnableSortIcon = true;
            this.lisAssignedChar4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAssignedChar4.FullRowSelect = true;
            this.lisAssignedChar4.Location = new System.Drawing.Point(0, 24);
            this.lisAssignedChar4.MultiSelect = false;
            this.lisAssignedChar4.Name = "lisAssignedChar4";
            this.lisAssignedChar4.Size = new System.Drawing.Size(160, 450);
            this.lisAssignedChar4.TabIndex = 0;
            this.lisAssignedChar4.UseCompatibleStateImageBehavior = false;
            this.lisAssignedChar4.View = System.Windows.Forms.View.Details;
            this.lisAssignedChar4.SelectedIndexChanged += new System.EventHandler(this.lisAssignedChar4_SelectedIndexChanged);
            // 
            // colChar4
            // 
            this.colChar4.Text = "Character ID";
            this.colChar4.Width = 100;
            // 
            // colCharDesc4
            // 
            this.colCharDesc4.Text = "Description";
            this.colCharDesc4.Width = 150;
            // 
            // pnlChar4
            // 
            this.pnlChar4.Controls.Add(this.btnCharRefresh4);
            this.pnlChar4.Controls.Add(this.lblChar4);
            this.pnlChar4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChar4.Location = new System.Drawing.Point(0, 0);
            this.pnlChar4.Name = "pnlChar4";
            this.pnlChar4.Size = new System.Drawing.Size(160, 24);
            this.pnlChar4.TabIndex = 0;
            // 
            // btnCharRefresh4
            // 
            this.btnCharRefresh4.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCharRefresh4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCharRefresh4.Image = ((System.Drawing.Image)(resources.GetObject("btnCharRefresh4.Image")));
            this.btnCharRefresh4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCharRefresh4.Location = new System.Drawing.Point(136, 0);
            this.btnCharRefresh4.Name = "btnCharRefresh4";
            this.btnCharRefresh4.Size = new System.Drawing.Size(24, 24);
            this.btnCharRefresh4.TabIndex = 19;
            this.btnCharRefresh4.Click += new System.EventHandler(this.btnCharRefresh4_Click);
            // 
            // lblChar4
            // 
            this.lblChar4.AutoSize = true;
            this.lblChar4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChar4.Location = new System.Drawing.Point(3, 6);
            this.lblChar4.Name = "lblChar4";
            this.lblChar4.Size = new System.Drawing.Size(123, 13);
            this.lblChar4.TabIndex = 0;
            this.lblChar4.Text = "Assigned Characters List";
            this.lblChar4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpDoc
            // 
            this.tbpDoc.BackColor = System.Drawing.SystemColors.Control;
            this.tbpDoc.Controls.Add(this.pnlDocRight);
            this.tbpDoc.Controls.Add(this.splDoc);
            this.tbpDoc.Controls.Add(this.pnlDocLeft);
            this.tbpDoc.Location = new System.Drawing.Point(4, 22);
            this.tbpDoc.Name = "tbpDoc";
            this.tbpDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDoc.Size = new System.Drawing.Size(490, 480);
            this.tbpDoc.TabIndex = 4;
            this.tbpDoc.Text = "Document and Image";
            // 
            // pnlDocRight
            // 
            this.pnlDocRight.Controls.Add(this.grpImg);
            this.pnlDocRight.Controls.Add(this.grpDoc);
            this.pnlDocRight.Controls.Add(this.grpAttachOption);
            this.pnlDocRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDocRight.Location = new System.Drawing.Point(166, 3);
            this.pnlDocRight.Name = "pnlDocRight";
            this.pnlDocRight.Size = new System.Drawing.Size(321, 474);
            this.pnlDocRight.TabIndex = 4;
            // 
            // grpImg
            // 
            this.grpImg.Controls.Add(this.tlpImg);
            this.grpImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImg.Location = new System.Drawing.Point(0, 252);
            this.grpImg.Margin = new System.Windows.Forms.Padding(0);
            this.grpImg.Name = "grpImg";
            this.grpImg.Padding = new System.Windows.Forms.Padding(0);
            this.grpImg.Size = new System.Drawing.Size(321, 222);
            this.grpImg.TabIndex = 2;
            this.grpImg.TabStop = false;
            this.grpImg.Text = "Images";
            // 
            // tlpImg
            // 
            this.tlpImg.ColumnCount = 3;
            this.tlpImg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpImg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpImg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpImg.Controls.Add(this.pnlImgBottom3, 2, 1);
            this.tlpImg.Controls.Add(this.pnlImgBottom2, 1, 1);
            this.tlpImg.Controls.Add(this.pnlImgBottom1, 0, 1);
            this.tlpImg.Controls.Add(this.pnlImgTop3, 2, 0);
            this.tlpImg.Controls.Add(this.pnlImgTop2, 1, 0);
            this.tlpImg.Controls.Add(this.pnlImgTop1, 0, 0);
            this.tlpImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImg.Location = new System.Drawing.Point(0, 13);
            this.tlpImg.Margin = new System.Windows.Forms.Padding(0);
            this.tlpImg.Name = "tlpImg";
            this.tlpImg.RowCount = 2;
            this.tlpImg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpImg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpImg.Size = new System.Drawing.Size(321, 209);
            this.tlpImg.TabIndex = 0;
            // 
            // pnlImgBottom3
            // 
            this.pnlImgBottom3.Controls.Add(this.picImg3);
            this.pnlImgBottom3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImgBottom3.Location = new System.Drawing.Point(214, 54);
            this.pnlImgBottom3.Margin = new System.Windows.Forms.Padding(0);
            this.pnlImgBottom3.Name = "pnlImgBottom3";
            this.pnlImgBottom3.Size = new System.Drawing.Size(107, 155);
            this.pnlImgBottom3.TabIndex = 5;
            // 
            // picImg3
            // 
            this.picImg3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImg3.Location = new System.Drawing.Point(0, 0);
            this.picImg3.Name = "picImg3";
            this.picImg3.Size = new System.Drawing.Size(107, 155);
            this.picImg3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImg3.TabIndex = 0;
            this.picImg3.TabStop = false;
            // 
            // pnlImgBottom2
            // 
            this.pnlImgBottom2.Controls.Add(this.picImg2);
            this.pnlImgBottom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImgBottom2.Location = new System.Drawing.Point(107, 54);
            this.pnlImgBottom2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlImgBottom2.Name = "pnlImgBottom2";
            this.pnlImgBottom2.Size = new System.Drawing.Size(107, 155);
            this.pnlImgBottom2.TabIndex = 3;
            // 
            // picImg2
            // 
            this.picImg2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImg2.Location = new System.Drawing.Point(0, 0);
            this.picImg2.Name = "picImg2";
            this.picImg2.Size = new System.Drawing.Size(107, 155);
            this.picImg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImg2.TabIndex = 0;
            this.picImg2.TabStop = false;
            // 
            // pnlImgBottom1
            // 
            this.pnlImgBottom1.Controls.Add(this.picImg1);
            this.pnlImgBottom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImgBottom1.Location = new System.Drawing.Point(0, 54);
            this.pnlImgBottom1.Margin = new System.Windows.Forms.Padding(0);
            this.pnlImgBottom1.Name = "pnlImgBottom1";
            this.pnlImgBottom1.Size = new System.Drawing.Size(107, 155);
            this.pnlImgBottom1.TabIndex = 1;
            // 
            // picImg1
            // 
            this.picImg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImg1.Location = new System.Drawing.Point(0, 0);
            this.picImg1.Name = "picImg1";
            this.picImg1.Size = new System.Drawing.Size(107, 155);
            this.picImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImg1.TabIndex = 0;
            this.picImg1.TabStop = false;
            // 
            // pnlImgTop3
            // 
            this.pnlImgTop3.Controls.Add(this.chkKeep8);
            this.pnlImgTop3.Controls.Add(this.cdvImg3);
            this.pnlImgTop3.Controls.Add(this.lblImg3);
            this.pnlImgTop3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImgTop3.Location = new System.Drawing.Point(217, 3);
            this.pnlImgTop3.Name = "pnlImgTop3";
            this.pnlImgTop3.Size = new System.Drawing.Size(101, 48);
            this.pnlImgTop3.TabIndex = 4;
            // 
            // chkKeep8
            // 
            this.chkKeep8.AutoSize = true;
            this.chkKeep8.Location = new System.Drawing.Point(77, 3);
            this.chkKeep8.Name = "chkKeep8";
            this.chkKeep8.Size = new System.Drawing.Size(15, 14);
            this.chkKeep8.TabIndex = 34;
            this.toolTip.SetToolTip(this.chkKeep8, "Keep Old File");
            this.chkKeep8.UseVisualStyleBackColor = true;
            // 
            // cdvImg3
            // 
            this.cdvImg3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvImg3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvImg3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvImg3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvImg3.BtnToolTipText = "";
            this.cdvImg3.ButtonWidth = 20;
            this.cdvImg3.DescText = "";
            this.cdvImg3.DisplaySubItemIndex = -1;
            this.cdvImg3.DisplayText = "";
            this.cdvImg3.Focusing = null;
            this.cdvImg3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvImg3.Index = 0;
            this.cdvImg3.IsViewBtnImage = false;
            this.cdvImg3.Location = new System.Drawing.Point(6, 24);
            this.cdvImg3.MaxLength = 32767;
            this.cdvImg3.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvImg3.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvImg3.Name = "cdvImg3";
            this.cdvImg3.ReadOnly = true;
            this.cdvImg3.SameWidthHeightOfButton = false;
            this.cdvImg3.SearchSubItemIndex = 0;
            this.cdvImg3.SelectedDescIndex = -1;
            this.cdvImg3.SelectedSubItemIndex = -1;
            this.cdvImg3.SelectionStart = 0;
            this.cdvImg3.Size = new System.Drawing.Size(95, 20);
            this.cdvImg3.SmallImageList = null;
            this.cdvImg3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvImg3.TabIndex = 3;
            this.cdvImg3.TextBoxToolTipText = "";
            this.cdvImg3.TextBoxWidth = 95;
            this.cdvImg3.VisibleButton = true;
            this.cdvImg3.VisibleColumnHeader = false;
            this.cdvImg3.VisibleDescription = false;
            this.cdvImg3.ButtonPress += new System.EventHandler(this.cdvImg_ButtonPress);
            this.cdvImg3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvFile_TextBoxKeyPress);
            this.cdvImg3.TextBoxTextChanged += new System.EventHandler(this.cdvFile_TextBoxTextChanged);
            // 
            // lblImg3
            // 
            this.lblImg3.AutoSize = true;
            this.lblImg3.Location = new System.Drawing.Point(3, 4);
            this.lblImg3.Name = "lblImg3";
            this.lblImg3.Size = new System.Drawing.Size(45, 13);
            this.lblImg3.TabIndex = 1;
            this.lblImg3.Text = "Image 3";
            // 
            // pnlImgTop2
            // 
            this.pnlImgTop2.Controls.Add(this.chkKeep7);
            this.pnlImgTop2.Controls.Add(this.cdvImg2);
            this.pnlImgTop2.Controls.Add(this.lblImg2);
            this.pnlImgTop2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImgTop2.Location = new System.Drawing.Point(110, 3);
            this.pnlImgTop2.Name = "pnlImgTop2";
            this.pnlImgTop2.Size = new System.Drawing.Size(101, 48);
            this.pnlImgTop2.TabIndex = 2;
            // 
            // chkKeep7
            // 
            this.chkKeep7.AutoSize = true;
            this.chkKeep7.Location = new System.Drawing.Point(77, 3);
            this.chkKeep7.Name = "chkKeep7";
            this.chkKeep7.Size = new System.Drawing.Size(15, 14);
            this.chkKeep7.TabIndex = 34;
            this.toolTip.SetToolTip(this.chkKeep7, "Keep Old File");
            this.chkKeep7.UseVisualStyleBackColor = true;
            // 
            // cdvImg2
            // 
            this.cdvImg2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvImg2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvImg2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvImg2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvImg2.BtnToolTipText = "";
            this.cdvImg2.ButtonWidth = 20;
            this.cdvImg2.DescText = "";
            this.cdvImg2.DisplaySubItemIndex = -1;
            this.cdvImg2.DisplayText = "";
            this.cdvImg2.Focusing = null;
            this.cdvImg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvImg2.Index = 0;
            this.cdvImg2.IsViewBtnImage = false;
            this.cdvImg2.Location = new System.Drawing.Point(6, 24);
            this.cdvImg2.MaxLength = 32767;
            this.cdvImg2.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvImg2.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvImg2.Name = "cdvImg2";
            this.cdvImg2.ReadOnly = true;
            this.cdvImg2.SameWidthHeightOfButton = false;
            this.cdvImg2.SearchSubItemIndex = 0;
            this.cdvImg2.SelectedDescIndex = -1;
            this.cdvImg2.SelectedSubItemIndex = -1;
            this.cdvImg2.SelectionStart = 0;
            this.cdvImg2.Size = new System.Drawing.Size(95, 20);
            this.cdvImg2.SmallImageList = null;
            this.cdvImg2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvImg2.TabIndex = 3;
            this.cdvImg2.TextBoxToolTipText = "";
            this.cdvImg2.TextBoxWidth = 95;
            this.cdvImg2.VisibleButton = true;
            this.cdvImg2.VisibleColumnHeader = false;
            this.cdvImg2.VisibleDescription = false;
            this.cdvImg2.ButtonPress += new System.EventHandler(this.cdvImg_ButtonPress);
            this.cdvImg2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvFile_TextBoxKeyPress);
            this.cdvImg2.TextBoxTextChanged += new System.EventHandler(this.cdvFile_TextBoxTextChanged);
            // 
            // lblImg2
            // 
            this.lblImg2.AutoSize = true;
            this.lblImg2.Location = new System.Drawing.Point(3, 4);
            this.lblImg2.Name = "lblImg2";
            this.lblImg2.Size = new System.Drawing.Size(45, 13);
            this.lblImg2.TabIndex = 1;
            this.lblImg2.Text = "Image 2";
            // 
            // pnlImgTop1
            // 
            this.pnlImgTop1.Controls.Add(this.chkKeep6);
            this.pnlImgTop1.Controls.Add(this.cdvImg1);
            this.pnlImgTop1.Controls.Add(this.lblImg1);
            this.pnlImgTop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImgTop1.Location = new System.Drawing.Point(3, 3);
            this.pnlImgTop1.Name = "pnlImgTop1";
            this.pnlImgTop1.Size = new System.Drawing.Size(101, 48);
            this.pnlImgTop1.TabIndex = 0;
            // 
            // chkKeep6
            // 
            this.chkKeep6.AutoSize = true;
            this.chkKeep6.Location = new System.Drawing.Point(76, 3);
            this.chkKeep6.Name = "chkKeep6";
            this.chkKeep6.Size = new System.Drawing.Size(15, 14);
            this.chkKeep6.TabIndex = 33;
            this.toolTip.SetToolTip(this.chkKeep6, "Keep Old File");
            this.chkKeep6.UseVisualStyleBackColor = true;
            // 
            // cdvImg1
            // 
            this.cdvImg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvImg1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvImg1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvImg1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvImg1.BtnToolTipText = "";
            this.cdvImg1.ButtonWidth = 20;
            this.cdvImg1.DescText = "";
            this.cdvImg1.DisplaySubItemIndex = -1;
            this.cdvImg1.DisplayText = "";
            this.cdvImg1.Focusing = null;
            this.cdvImg1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvImg1.Index = 0;
            this.cdvImg1.IsViewBtnImage = false;
            this.cdvImg1.Location = new System.Drawing.Point(6, 24);
            this.cdvImg1.MaxLength = 32767;
            this.cdvImg1.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvImg1.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvImg1.Name = "cdvImg1";
            this.cdvImg1.ReadOnly = true;
            this.cdvImg1.SameWidthHeightOfButton = false;
            this.cdvImg1.SearchSubItemIndex = 0;
            this.cdvImg1.SelectedDescIndex = -1;
            this.cdvImg1.SelectedSubItemIndex = -1;
            this.cdvImg1.SelectionStart = 0;
            this.cdvImg1.Size = new System.Drawing.Size(95, 20);
            this.cdvImg1.SmallImageList = null;
            this.cdvImg1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvImg1.TabIndex = 3;
            this.cdvImg1.TextBoxToolTipText = "";
            this.cdvImg1.TextBoxWidth = 95;
            this.cdvImg1.VisibleButton = true;
            this.cdvImg1.VisibleColumnHeader = false;
            this.cdvImg1.VisibleDescription = false;
            this.cdvImg1.ButtonPress += new System.EventHandler(this.cdvImg_ButtonPress);
            this.cdvImg1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvFile_TextBoxKeyPress);
            this.cdvImg1.TextBoxTextChanged += new System.EventHandler(this.cdvFile_TextBoxTextChanged);
            // 
            // lblImg1
            // 
            this.lblImg1.AutoSize = true;
            this.lblImg1.Location = new System.Drawing.Point(3, 4);
            this.lblImg1.Name = "lblImg1";
            this.lblImg1.Size = new System.Drawing.Size(45, 13);
            this.lblImg1.TabIndex = 1;
            this.lblImg1.Text = "Image 1";
            // 
            // grpDoc
            // 
            this.grpDoc.Controls.Add(this.chkKeep5);
            this.grpDoc.Controls.Add(this.chkKeep4);
            this.grpDoc.Controls.Add(this.chkKeep3);
            this.grpDoc.Controls.Add(this.chkKeep2);
            this.grpDoc.Controls.Add(this.chkKeep1);
            this.grpDoc.Controls.Add(this.btnDoc5);
            this.grpDoc.Controls.Add(this.cdvDoc5);
            this.grpDoc.Controls.Add(this.lblDoc5);
            this.grpDoc.Controls.Add(this.btnDoc4);
            this.grpDoc.Controls.Add(this.cdvDoc4);
            this.grpDoc.Controls.Add(this.lblDoc4);
            this.grpDoc.Controls.Add(this.btnDoc3);
            this.grpDoc.Controls.Add(this.cdvDoc3);
            this.grpDoc.Controls.Add(this.lblDoc3);
            this.grpDoc.Controls.Add(this.btnDoc2);
            this.grpDoc.Controls.Add(this.cdvDoc2);
            this.grpDoc.Controls.Add(this.lblDoc2);
            this.grpDoc.Controls.Add(this.btnDoc1);
            this.grpDoc.Controls.Add(this.cdvDoc1);
            this.grpDoc.Controls.Add(this.lblDoc1);
            this.grpDoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDoc.Location = new System.Drawing.Point(0, 106);
            this.grpDoc.Name = "grpDoc";
            this.grpDoc.Size = new System.Drawing.Size(321, 146);
            this.grpDoc.TabIndex = 1;
            this.grpDoc.TabStop = false;
            this.grpDoc.Text = "Documents";
            // 
            // chkKeep5
            // 
            this.chkKeep5.AutoSize = true;
            this.chkKeep5.Location = new System.Drawing.Point(6, 119);
            this.chkKeep5.Name = "chkKeep5";
            this.chkKeep5.Size = new System.Drawing.Size(15, 14);
            this.chkKeep5.TabIndex = 16;
            this.toolTip.SetToolTip(this.chkKeep5, "Keep Old File");
            this.chkKeep5.UseVisualStyleBackColor = true;
            // 
            // chkKeep4
            // 
            this.chkKeep4.AutoSize = true;
            this.chkKeep4.Location = new System.Drawing.Point(6, 94);
            this.chkKeep4.Name = "chkKeep4";
            this.chkKeep4.Size = new System.Drawing.Size(15, 14);
            this.chkKeep4.TabIndex = 12;
            this.toolTip.SetToolTip(this.chkKeep4, "Keep Old File");
            this.chkKeep4.UseVisualStyleBackColor = true;
            // 
            // chkKeep3
            // 
            this.chkKeep3.AutoSize = true;
            this.chkKeep3.Location = new System.Drawing.Point(6, 69);
            this.chkKeep3.Name = "chkKeep3";
            this.chkKeep3.Size = new System.Drawing.Size(15, 14);
            this.chkKeep3.TabIndex = 8;
            this.toolTip.SetToolTip(this.chkKeep3, "Keep Old File");
            this.chkKeep3.UseVisualStyleBackColor = true;
            // 
            // chkKeep2
            // 
            this.chkKeep2.AutoSize = true;
            this.chkKeep2.Location = new System.Drawing.Point(6, 44);
            this.chkKeep2.Name = "chkKeep2";
            this.chkKeep2.Size = new System.Drawing.Size(15, 14);
            this.chkKeep2.TabIndex = 4;
            this.toolTip.SetToolTip(this.chkKeep2, "Keep Old File");
            this.chkKeep2.UseVisualStyleBackColor = true;
            // 
            // chkKeep1
            // 
            this.chkKeep1.AutoSize = true;
            this.chkKeep1.Location = new System.Drawing.Point(6, 19);
            this.chkKeep1.Name = "chkKeep1";
            this.chkKeep1.Size = new System.Drawing.Size(15, 14);
            this.chkKeep1.TabIndex = 0;
            this.toolTip.SetToolTip(this.chkKeep1, "Keep Old File");
            this.chkKeep1.UseVisualStyleBackColor = true;
            // 
            // btnDoc5
            // 
            this.btnDoc5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoc5.Location = new System.Drawing.Point(270, 116);
            this.btnDoc5.Name = "btnDoc5";
            this.btnDoc5.Size = new System.Drawing.Size(43, 21);
            this.btnDoc5.TabIndex = 19;
            this.btnDoc5.Text = "Open";
            this.btnDoc5.UseVisualStyleBackColor = true;
            this.btnDoc5.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // cdvDoc5
            // 
            this.cdvDoc5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvDoc5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDoc5.BtnToolTipText = "";
            this.cdvDoc5.ButtonWidth = 20;
            this.cdvDoc5.DescText = "";
            this.cdvDoc5.DisplaySubItemIndex = -1;
            this.cdvDoc5.DisplayText = "";
            this.cdvDoc5.Focusing = null;
            this.cdvDoc5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDoc5.Index = 0;
            this.cdvDoc5.IsViewBtnImage = false;
            this.cdvDoc5.Location = new System.Drawing.Point(97, 117);
            this.cdvDoc5.MaxLength = 32767;
            this.cdvDoc5.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc5.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc5.Name = "cdvDoc5";
            this.cdvDoc5.ReadOnly = true;
            this.cdvDoc5.SameWidthHeightOfButton = false;
            this.cdvDoc5.SearchSubItemIndex = 0;
            this.cdvDoc5.SelectedDescIndex = -1;
            this.cdvDoc5.SelectedSubItemIndex = -1;
            this.cdvDoc5.SelectionStart = 0;
            this.cdvDoc5.Size = new System.Drawing.Size(170, 20);
            this.cdvDoc5.SmallImageList = null;
            this.cdvDoc5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDoc5.TabIndex = 18;
            this.cdvDoc5.TextBoxToolTipText = "";
            this.cdvDoc5.TextBoxWidth = 170;
            this.cdvDoc5.VisibleButton = true;
            this.cdvDoc5.VisibleColumnHeader = false;
            this.cdvDoc5.VisibleDescription = false;
            this.cdvDoc5.ButtonPress += new System.EventHandler(this.cdvFile_ButtonPress);
            this.cdvDoc5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvFile_TextBoxKeyPress);
            this.cdvDoc5.TextBoxTextChanged += new System.EventHandler(this.cdvFile_TextBoxTextChanged);
            // 
            // lblDoc5
            // 
            this.lblDoc5.AutoSize = true;
            this.lblDoc5.Location = new System.Drawing.Point(21, 120);
            this.lblDoc5.Name = "lblDoc5";
            this.lblDoc5.Size = new System.Drawing.Size(65, 13);
            this.lblDoc5.TabIndex = 17;
            this.lblDoc5.Text = "Document 5";
            // 
            // btnDoc4
            // 
            this.btnDoc4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoc4.Location = new System.Drawing.Point(270, 91);
            this.btnDoc4.Name = "btnDoc4";
            this.btnDoc4.Size = new System.Drawing.Size(43, 21);
            this.btnDoc4.TabIndex = 15;
            this.btnDoc4.Text = "Open";
            this.btnDoc4.UseVisualStyleBackColor = true;
            this.btnDoc4.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // cdvDoc4
            // 
            this.cdvDoc4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvDoc4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDoc4.BtnToolTipText = "";
            this.cdvDoc4.ButtonWidth = 20;
            this.cdvDoc4.DescText = "";
            this.cdvDoc4.DisplaySubItemIndex = -1;
            this.cdvDoc4.DisplayText = "";
            this.cdvDoc4.Focusing = null;
            this.cdvDoc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDoc4.Index = 0;
            this.cdvDoc4.IsViewBtnImage = false;
            this.cdvDoc4.Location = new System.Drawing.Point(97, 92);
            this.cdvDoc4.MaxLength = 32767;
            this.cdvDoc4.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc4.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc4.Name = "cdvDoc4";
            this.cdvDoc4.ReadOnly = true;
            this.cdvDoc4.SameWidthHeightOfButton = false;
            this.cdvDoc4.SearchSubItemIndex = 0;
            this.cdvDoc4.SelectedDescIndex = -1;
            this.cdvDoc4.SelectedSubItemIndex = -1;
            this.cdvDoc4.SelectionStart = 0;
            this.cdvDoc4.Size = new System.Drawing.Size(170, 20);
            this.cdvDoc4.SmallImageList = null;
            this.cdvDoc4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDoc4.TabIndex = 14;
            this.cdvDoc4.TextBoxToolTipText = "";
            this.cdvDoc4.TextBoxWidth = 170;
            this.cdvDoc4.VisibleButton = true;
            this.cdvDoc4.VisibleColumnHeader = false;
            this.cdvDoc4.VisibleDescription = false;
            this.cdvDoc4.ButtonPress += new System.EventHandler(this.cdvFile_ButtonPress);
            this.cdvDoc4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvFile_TextBoxKeyPress);
            this.cdvDoc4.TextBoxTextChanged += new System.EventHandler(this.cdvFile_TextBoxTextChanged);
            // 
            // lblDoc4
            // 
            this.lblDoc4.AutoSize = true;
            this.lblDoc4.Location = new System.Drawing.Point(21, 95);
            this.lblDoc4.Name = "lblDoc4";
            this.lblDoc4.Size = new System.Drawing.Size(65, 13);
            this.lblDoc4.TabIndex = 13;
            this.lblDoc4.Text = "Document 4";
            // 
            // btnDoc3
            // 
            this.btnDoc3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoc3.Location = new System.Drawing.Point(270, 66);
            this.btnDoc3.Name = "btnDoc3";
            this.btnDoc3.Size = new System.Drawing.Size(43, 21);
            this.btnDoc3.TabIndex = 11;
            this.btnDoc3.Text = "Open";
            this.btnDoc3.UseVisualStyleBackColor = true;
            this.btnDoc3.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // cdvDoc3
            // 
            this.cdvDoc3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvDoc3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDoc3.BtnToolTipText = "";
            this.cdvDoc3.ButtonWidth = 20;
            this.cdvDoc3.DescText = "";
            this.cdvDoc3.DisplaySubItemIndex = -1;
            this.cdvDoc3.DisplayText = "";
            this.cdvDoc3.Focusing = null;
            this.cdvDoc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDoc3.Index = 0;
            this.cdvDoc3.IsViewBtnImage = false;
            this.cdvDoc3.Location = new System.Drawing.Point(97, 67);
            this.cdvDoc3.MaxLength = 32767;
            this.cdvDoc3.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc3.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc3.Name = "cdvDoc3";
            this.cdvDoc3.ReadOnly = true;
            this.cdvDoc3.SameWidthHeightOfButton = false;
            this.cdvDoc3.SearchSubItemIndex = 0;
            this.cdvDoc3.SelectedDescIndex = -1;
            this.cdvDoc3.SelectedSubItemIndex = -1;
            this.cdvDoc3.SelectionStart = 0;
            this.cdvDoc3.Size = new System.Drawing.Size(170, 20);
            this.cdvDoc3.SmallImageList = null;
            this.cdvDoc3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDoc3.TabIndex = 10;
            this.cdvDoc3.TextBoxToolTipText = "";
            this.cdvDoc3.TextBoxWidth = 170;
            this.cdvDoc3.VisibleButton = true;
            this.cdvDoc3.VisibleColumnHeader = false;
            this.cdvDoc3.VisibleDescription = false;
            this.cdvDoc3.ButtonPress += new System.EventHandler(this.cdvFile_ButtonPress);
            this.cdvDoc3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvFile_TextBoxKeyPress);
            this.cdvDoc3.TextBoxTextChanged += new System.EventHandler(this.cdvFile_TextBoxTextChanged);
            // 
            // lblDoc3
            // 
            this.lblDoc3.AutoSize = true;
            this.lblDoc3.Location = new System.Drawing.Point(21, 70);
            this.lblDoc3.Name = "lblDoc3";
            this.lblDoc3.Size = new System.Drawing.Size(65, 13);
            this.lblDoc3.TabIndex = 9;
            this.lblDoc3.Text = "Document 3";
            // 
            // btnDoc2
            // 
            this.btnDoc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoc2.Location = new System.Drawing.Point(270, 41);
            this.btnDoc2.Name = "btnDoc2";
            this.btnDoc2.Size = new System.Drawing.Size(43, 21);
            this.btnDoc2.TabIndex = 7;
            this.btnDoc2.Text = "Open";
            this.btnDoc2.UseVisualStyleBackColor = true;
            this.btnDoc2.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // cdvDoc2
            // 
            this.cdvDoc2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvDoc2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDoc2.BtnToolTipText = "";
            this.cdvDoc2.ButtonWidth = 20;
            this.cdvDoc2.DescText = "";
            this.cdvDoc2.DisplaySubItemIndex = -1;
            this.cdvDoc2.DisplayText = "";
            this.cdvDoc2.Focusing = null;
            this.cdvDoc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDoc2.Index = 0;
            this.cdvDoc2.IsViewBtnImage = false;
            this.cdvDoc2.Location = new System.Drawing.Point(97, 42);
            this.cdvDoc2.MaxLength = 32767;
            this.cdvDoc2.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc2.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc2.Name = "cdvDoc2";
            this.cdvDoc2.ReadOnly = true;
            this.cdvDoc2.SameWidthHeightOfButton = false;
            this.cdvDoc2.SearchSubItemIndex = 0;
            this.cdvDoc2.SelectedDescIndex = -1;
            this.cdvDoc2.SelectedSubItemIndex = -1;
            this.cdvDoc2.SelectionStart = 0;
            this.cdvDoc2.Size = new System.Drawing.Size(170, 20);
            this.cdvDoc2.SmallImageList = null;
            this.cdvDoc2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDoc2.TabIndex = 6;
            this.cdvDoc2.TextBoxToolTipText = "";
            this.cdvDoc2.TextBoxWidth = 170;
            this.cdvDoc2.VisibleButton = true;
            this.cdvDoc2.VisibleColumnHeader = false;
            this.cdvDoc2.VisibleDescription = false;
            this.cdvDoc2.ButtonPress += new System.EventHandler(this.cdvFile_ButtonPress);
            this.cdvDoc2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvFile_TextBoxKeyPress);
            this.cdvDoc2.TextBoxTextChanged += new System.EventHandler(this.cdvFile_TextBoxTextChanged);
            // 
            // lblDoc2
            // 
            this.lblDoc2.AutoSize = true;
            this.lblDoc2.Location = new System.Drawing.Point(21, 45);
            this.lblDoc2.Name = "lblDoc2";
            this.lblDoc2.Size = new System.Drawing.Size(65, 13);
            this.lblDoc2.TabIndex = 5;
            this.lblDoc2.Text = "Document 2";
            // 
            // btnDoc1
            // 
            this.btnDoc1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoc1.Location = new System.Drawing.Point(270, 16);
            this.btnDoc1.Name = "btnDoc1";
            this.btnDoc1.Size = new System.Drawing.Size(43, 21);
            this.btnDoc1.TabIndex = 3;
            this.btnDoc1.Text = "Open";
            this.btnDoc1.UseVisualStyleBackColor = true;
            this.btnDoc1.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // cdvDoc1
            // 
            this.cdvDoc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvDoc1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDoc1.BtnToolTipText = "";
            this.cdvDoc1.ButtonWidth = 20;
            this.cdvDoc1.DescText = "";
            this.cdvDoc1.DisplaySubItemIndex = -1;
            this.cdvDoc1.DisplayText = "";
            this.cdvDoc1.Focusing = null;
            this.cdvDoc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDoc1.Index = 0;
            this.cdvDoc1.IsViewBtnImage = false;
            this.cdvDoc1.Location = new System.Drawing.Point(97, 17);
            this.cdvDoc1.MaxLength = 32767;
            this.cdvDoc1.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDoc1.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDoc1.Name = "cdvDoc1";
            this.cdvDoc1.ReadOnly = true;
            this.cdvDoc1.SameWidthHeightOfButton = false;
            this.cdvDoc1.SearchSubItemIndex = 0;
            this.cdvDoc1.SelectedDescIndex = -1;
            this.cdvDoc1.SelectedSubItemIndex = -1;
            this.cdvDoc1.SelectionStart = 0;
            this.cdvDoc1.Size = new System.Drawing.Size(170, 20);
            this.cdvDoc1.SmallImageList = null;
            this.cdvDoc1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDoc1.TabIndex = 2;
            this.cdvDoc1.TextBoxToolTipText = "";
            this.cdvDoc1.TextBoxWidth = 170;
            this.cdvDoc1.VisibleButton = true;
            this.cdvDoc1.VisibleColumnHeader = false;
            this.cdvDoc1.VisibleDescription = false;
            this.cdvDoc1.ButtonPress += new System.EventHandler(this.cdvFile_ButtonPress);
            this.cdvDoc1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvFile_TextBoxKeyPress);
            this.cdvDoc1.TextBoxTextChanged += new System.EventHandler(this.cdvFile_TextBoxTextChanged);
            // 
            // lblDoc1
            // 
            this.lblDoc1.AutoSize = true;
            this.lblDoc1.Location = new System.Drawing.Point(21, 20);
            this.lblDoc1.Name = "lblDoc1";
            this.lblDoc1.Size = new System.Drawing.Size(65, 13);
            this.lblDoc1.TabIndex = 1;
            this.lblDoc1.Text = "Document 1";
            // 
            // grpAttachOption
            // 
            this.grpAttachOption.Controls.Add(this.btnViewSpecFile);
            this.grpAttachOption.Controls.Add(this.lblFileExt);
            this.grpAttachOption.Controls.Add(this.txtFileExt);
            this.grpAttachOption.Controls.Add(this.chkUseTargetToFile);
            this.grpAttachOption.Controls.Add(this.chkUseLatestFileVersion);
            this.grpAttachOption.Controls.Add(this.chkUseTargetToDir);
            this.grpAttachOption.Controls.Add(this.chkUseCharDir);
            this.grpAttachOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAttachOption.Location = new System.Drawing.Point(0, 0);
            this.grpAttachOption.Name = "grpAttachOption";
            this.grpAttachOption.Size = new System.Drawing.Size(321, 106);
            this.grpAttachOption.TabIndex = 0;
            this.grpAttachOption.TabStop = false;
            this.grpAttachOption.Text = "Attach Option";
            // 
            // btnViewSpecFile
            // 
            this.btnViewSpecFile.Location = new System.Drawing.Point(206, 80);
            this.btnViewSpecFile.Name = "btnViewSpecFile";
            this.btnViewSpecFile.Size = new System.Drawing.Size(109, 21);
            this.btnViewSpecFile.TabIndex = 6;
            this.btnViewSpecFile.Text = "View Spec File";
            this.btnViewSpecFile.UseVisualStyleBackColor = true;
            this.btnViewSpecFile.Click += new System.EventHandler(this.btnViewSpecFile_Click);
            // 
            // lblFileExt
            // 
            this.lblFileExt.AutoSize = true;
            this.lblFileExt.Location = new System.Drawing.Point(203, 62);
            this.lblFileExt.Name = "lblFileExt";
            this.lblFileExt.Size = new System.Drawing.Size(41, 13);
            this.lblFileExt.TabIndex = 3;
            this.lblFileExt.Text = "File Ext";
            // 
            // txtFileExt
            // 
            this.txtFileExt.Location = new System.Drawing.Point(262, 58);
            this.txtFileExt.MaxLength = 10;
            this.txtFileExt.Name = "txtFileExt";
            this.txtFileExt.ReadOnly = true;
            this.txtFileExt.Size = new System.Drawing.Size(53, 20);
            this.txtFileExt.TabIndex = 4;
            // 
            // chkUseTargetToFile
            // 
            this.chkUseTargetToFile.AutoSize = true;
            this.chkUseTargetToFile.Location = new System.Drawing.Point(15, 61);
            this.chkUseTargetToFile.Name = "chkUseTargetToFile";
            this.chkUseTargetToFile.Size = new System.Drawing.Size(196, 16);
            this.chkUseTargetToFile.TabIndex = 2;
            this.chkUseTargetToFile.Text = "Use Target value to File Name";
            this.chkUseTargetToFile.UseVisualStyleBackColor = true;
            this.chkUseTargetToFile.CheckedChanged += new System.EventHandler(this.chkUseTargetToFile_CheckedChanged);
            // 
            // chkUseLatestFileVersion
            // 
            this.chkUseLatestFileVersion.AutoSize = true;
            this.chkUseLatestFileVersion.Enabled = false;
            this.chkUseLatestFileVersion.Location = new System.Drawing.Point(15, 82);
            this.chkUseLatestFileVersion.Name = "chkUseLatestFileVersion";
            this.chkUseLatestFileVersion.Size = new System.Drawing.Size(145, 16);
            this.chkUseLatestFileVersion.TabIndex = 5;
            this.chkUseLatestFileVersion.Text = "Use latest file version";
            this.chkUseLatestFileVersion.UseVisualStyleBackColor = true;
            // 
            // chkUseTargetToDir
            // 
            this.chkUseTargetToDir.AutoSize = true;
            this.chkUseTargetToDir.Location = new System.Drawing.Point(15, 40);
            this.chkUseTargetToDir.Name = "chkUseTargetToDir";
            this.chkUseTargetToDir.Size = new System.Drawing.Size(226, 16);
            this.chkUseTargetToDir.TabIndex = 1;
            this.chkUseTargetToDir.Text = "Use Target value to Directory Name";
            this.chkUseTargetToDir.UseVisualStyleBackColor = true;
            // 
            // chkUseCharDir
            // 
            this.chkUseCharDir.AutoSize = true;
            this.chkUseCharDir.Location = new System.Drawing.Point(15, 19);
            this.chkUseCharDir.Name = "chkUseCharDir";
            this.chkUseCharDir.Size = new System.Drawing.Size(265, 16);
            this.chkUseCharDir.TabIndex = 0;
            this.chkUseCharDir.Text = "Use Directory of defined at character setup";
            this.chkUseCharDir.UseVisualStyleBackColor = true;
            // 
            // splDoc
            // 
            this.splDoc.Location = new System.Drawing.Point(163, 3);
            this.splDoc.Name = "splDoc";
            this.splDoc.Size = new System.Drawing.Size(3, 474);
            this.splDoc.TabIndex = 5;
            this.splDoc.TabStop = false;
            // 
            // pnlDocLeft
            // 
            this.pnlDocLeft.Controls.Add(this.pnlCharMidLeft5);
            this.pnlDocLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDocLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlDocLeft.Name = "pnlDocLeft";
            this.pnlDocLeft.Size = new System.Drawing.Size(160, 474);
            this.pnlDocLeft.TabIndex = 3;
            // 
            // pnlCharMidLeft5
            // 
            this.pnlCharMidLeft5.Controls.Add(this.lisAssignedChar5);
            this.pnlCharMidLeft5.Controls.Add(this.pnlChar5);
            this.pnlCharMidLeft5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharMidLeft5.Location = new System.Drawing.Point(0, 0);
            this.pnlCharMidLeft5.Name = "pnlCharMidLeft5";
            this.pnlCharMidLeft5.Size = new System.Drawing.Size(160, 474);
            this.pnlCharMidLeft5.TabIndex = 0;
            // 
            // lisAssignedChar5
            // 
            this.lisAssignedChar5.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lisAssignedChar5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAssignedChar5.EnableSort = true;
            this.lisAssignedChar5.EnableSortIcon = true;
            this.lisAssignedChar5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAssignedChar5.FullRowSelect = true;
            this.lisAssignedChar5.Location = new System.Drawing.Point(0, 24);
            this.lisAssignedChar5.MultiSelect = false;
            this.lisAssignedChar5.Name = "lisAssignedChar5";
            this.lisAssignedChar5.Size = new System.Drawing.Size(160, 450);
            this.lisAssignedChar5.TabIndex = 0;
            this.lisAssignedChar5.UseCompatibleStateImageBehavior = false;
            this.lisAssignedChar5.View = System.Windows.Forms.View.Details;
            this.lisAssignedChar5.SelectedIndexChanged += new System.EventHandler(this.lisAssignedChar5_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Character ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 150;
            // 
            // pnlChar5
            // 
            this.pnlChar5.Controls.Add(this.btnCharRefresh5);
            this.pnlChar5.Controls.Add(this.lblChar5);
            this.pnlChar5.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChar5.Location = new System.Drawing.Point(0, 0);
            this.pnlChar5.Name = "pnlChar5";
            this.pnlChar5.Size = new System.Drawing.Size(160, 24);
            this.pnlChar5.TabIndex = 0;
            // 
            // btnCharRefresh5
            // 
            this.btnCharRefresh5.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCharRefresh5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCharRefresh5.Image = ((System.Drawing.Image)(resources.GetObject("btnCharRefresh5.Image")));
            this.btnCharRefresh5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCharRefresh5.Location = new System.Drawing.Point(136, 0);
            this.btnCharRefresh5.Name = "btnCharRefresh5";
            this.btnCharRefresh5.Size = new System.Drawing.Size(24, 24);
            this.btnCharRefresh5.TabIndex = 19;
            this.btnCharRefresh5.Click += new System.EventHandler(this.btnCharRefresh5_Click);
            // 
            // lblChar5
            // 
            this.lblChar5.AutoSize = true;
            this.lblChar5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChar5.Location = new System.Drawing.Point(3, 6);
            this.lblChar5.Name = "lblChar5";
            this.lblChar5.Size = new System.Drawing.Size(123, 13);
            this.lblChar5.TabIndex = 0;
            this.lblChar5.Text = "Assigned Characters List";
            this.lblChar5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCopy
            // 
            this.tbpCopy.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCopy.Controls.Add(this.grpCopy);
            this.tbpCopy.Location = new System.Drawing.Point(4, 22);
            this.tbpCopy.Name = "tbpCopy";
            this.tbpCopy.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCopy.Size = new System.Drawing.Size(490, 480);
            this.tbpCopy.TabIndex = 5;
            this.tbpCopy.Text = "Copy Specification";
            // 
            // grpCopy
            // 
            this.grpCopy.Controls.Add(this.btnCopySpec);
            this.grpCopy.Controls.Add(this.cdvToVer);
            this.grpCopy.Controls.Add(this.lblToVer);
            this.grpCopy.Controls.Add(this.cdvToOper);
            this.grpCopy.Controls.Add(this.cdvToFlow);
            this.grpCopy.Controls.Add(this.cdvToMaterial);
            this.grpCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCopy.Location = new System.Drawing.Point(3, 3);
            this.grpCopy.Name = "grpCopy";
            this.grpCopy.Size = new System.Drawing.Size(484, 474);
            this.grpCopy.TabIndex = 0;
            this.grpCopy.TabStop = false;
            // 
            // btnCopySpec
            // 
            this.btnCopySpec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopySpec.Location = new System.Drawing.Point(394, 97);
            this.btnCopySpec.Name = "btnCopySpec";
            this.btnCopySpec.Size = new System.Drawing.Size(84, 23);
            this.btnCopySpec.TabIndex = 5;
            this.btnCopySpec.Text = "Copy";
            this.btnCopySpec.Click += new System.EventHandler(this.btnCopySpec_Click);
            // 
            // cdvToVer
            // 
            this.cdvToVer.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToVer.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToVer.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToVer.BtnToolTipText = "";
            this.cdvToVer.ButtonWidth = 20;
            this.cdvToVer.DescText = "";
            this.cdvToVer.DisplaySubItemIndex = -1;
            this.cdvToVer.DisplayText = "";
            this.cdvToVer.Focusing = null;
            this.cdvToVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToVer.Index = 0;
            this.cdvToVer.IsViewBtnImage = false;
            this.cdvToVer.Location = new System.Drawing.Point(115, 98);
            this.cdvToVer.MaxLength = 32767;
            this.cdvToVer.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToVer.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToVer.Name = "cdvToVer";
            this.cdvToVer.ReadOnly = false;
            this.cdvToVer.SameWidthHeightOfButton = false;
            this.cdvToVer.SearchSubItemIndex = 0;
            this.cdvToVer.SelectedDescIndex = -1;
            this.cdvToVer.SelectedSubItemIndex = -1;
            this.cdvToVer.SelectionStart = 0;
            this.cdvToVer.Size = new System.Drawing.Size(160, 20);
            this.cdvToVer.SmallImageList = null;
            this.cdvToVer.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToVer.TabIndex = 4;
            this.cdvToVer.TextBoxToolTipText = "";
            this.cdvToVer.TextBoxWidth = 160;
            this.cdvToVer.VisibleButton = true;
            this.cdvToVer.VisibleColumnHeader = false;
            this.cdvToVer.VisibleDescription = false;
            this.cdvToVer.ButtonPress += new System.EventHandler(this.cdvToVer_ButtonPress);
            // 
            // lblToVer
            // 
            this.lblToVer.AutoSize = true;
            this.lblToVer.Location = new System.Drawing.Point(13, 101);
            this.lblToVer.Name = "lblToVer";
            this.lblToVer.Size = new System.Drawing.Size(58, 13);
            this.lblToVer.TabIndex = 3;
            this.lblToVer.Text = "To Version";
            // 
            // cdvToOper
            // 
            this.cdvToOper.AddEmptyRowToLast = false;
            this.cdvToOper.AddEmptyRowToTop = false;
            this.cdvToOper.ButtonWidth = 21;
            this.cdvToOper.DisplaySubItemIndex = 0;
            this.cdvToOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOper.LabelText = "To Operation";
            this.cdvToOper.LabelWidth = 100;
            this.cdvToOper.ListCond_ExtFactory = "";
            this.cdvToOper.ListCond_Step = '1';
            this.cdvToOper.Location = new System.Drawing.Point(15, 71);
            this.cdvToOper.Name = "cdvToOper";
            this.cdvToOper.ReadOnly = false;
            this.cdvToOper.SearchSubItemIndex = 0;
            this.cdvToOper.SelectedDescIndex = 1;
            this.cdvToOper.SelectedSubItemIndex = 0;
            this.cdvToOper.Size = new System.Drawing.Size(260, 20);
            this.cdvToOper.TabIndex = 2;
            this.cdvToOper.TextBoxWidth = 160;
            this.cdvToOper.VisibleButton = true;
            this.cdvToOper.VisibleColumnHeader = false;
            this.cdvToOper.VisibleDescription = false;
            this.cdvToOper.ButtonPress += new System.EventHandler(this.cdvToOper_ButtonPress);
            // 
            // cdvToFlow
            // 
            this.cdvToFlow.AddEmptyRowToLast = false;
            this.cdvToFlow.AddEmptyRowToTop = false;
            this.cdvToFlow.ButtonWidth = 21;
            this.cdvToFlow.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvToFlow.DisplaySubItemIndex = 0;
            this.cdvToFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvToFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelText = "To Flow";
            this.cdvToFlow.LabelWidth = 100;
            this.cdvToFlow.ListCond_ExtFactory = "";
            this.cdvToFlow.ListCond_Step = '1';
            this.cdvToFlow.Location = new System.Drawing.Point(15, 45);
            this.cdvToFlow.Name = "cdvToFlow";
            this.cdvToFlow.ReadOnly = false;
            this.cdvToFlow.SearchSubItemIndex = 0;
            this.cdvToFlow.SelectedDescIndex = 1;
            this.cdvToFlow.SelectedSubItemIndex = 0;
            this.cdvToFlow.Size = new System.Drawing.Size(260, 20);
            this.cdvToFlow.TabIndex = 1;
            this.cdvToFlow.TextBoxWidth = 160;
            this.cdvToFlow.VisibleButton = true;
            this.cdvToFlow.VisibleColumnHeader = false;
            this.cdvToFlow.VisibleDescription = false;
            this.cdvToFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToFlow_SelectedItemChanged);
            this.cdvToFlow.ButtonPress += new System.EventHandler(this.cdvToFlow_ButtonPress);
            // 
            // cdvToMaterial
            // 
            this.cdvToMaterial.AddEmptyRowToLast = false;
            this.cdvToMaterial.AddEmptyRowToTop = false;
            this.cdvToMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvToMaterial.DisplaySubItemIndex = 0;
            this.cdvToMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvToMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMaterial.LabelText = "To Material";
            this.cdvToMaterial.ListCond_ExtFactory = "";
            this.cdvToMaterial.ListCond_StepMaterial = '1';
            this.cdvToMaterial.ListCond_StepVersion = '1';
            this.cdvToMaterial.Location = new System.Drawing.Point(15, 19);
            this.cdvToMaterial.MaterialEnabled = true;
            this.cdvToMaterial.MaterialReadOnly = false;
            this.cdvToMaterial.Name = "cdvToMaterial";
            this.cdvToMaterial.SearchSubItemIndex = 0;
            this.cdvToMaterial.SelectedDescIndex = -1;
            this.cdvToMaterial.SelectedSubItemIndex = 0;
            this.cdvToMaterial.Size = new System.Drawing.Size(310, 20);
            this.cdvToMaterial.TabIndex = 0;
            this.cdvToMaterial.VersionEnabled = true;
            this.cdvToMaterial.VersionReadOnly = false;
            this.cdvToMaterial.VisibleColumnHeader = false;
            this.cdvToMaterial.VisibleDescription = false;
            this.cdvToMaterial.VisibleMaterialButton = true;
            this.cdvToMaterial.VisibleVersionButton = true;
            this.cdvToMaterial.WidthButton = 20;
            this.cdvToMaterial.WidthLabel = 100;
            this.cdvToMaterial.WidthMaterialAndVersion = 210;
            this.cdvToMaterial.WidthVersion = 50;
            this.cdvToMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToMaterial_SelectedItemChanged);
            this.cdvToMaterial.MaterialButtonPress += new System.EventHandler(this.cdvToMaterial_MaterialButtonPress);
            // 
            // cdvData
            // 
            this.cdvData.BackColor = System.Drawing.SystemColors.Control;
            this.cdvData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvData.Location = new System.Drawing.Point(0, 0);
            this.cdvData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvData.Name = "MCSPCodeView";
            this.cdvData.Size = new System.Drawing.Size(20, 20);
            this.cdvData.SmallImageList = null;
            this.cdvData.TabIndex = 0;
            this.cdvData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvData.VisibleColumnHeader = false;
            this.cdvData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvData_SelectedItemChanged);
            // 
            // frmSPMSetupSpecRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 546);
            this.Name = "frmSPMSetupSpecRelation";
            this.Text = "Specification Setup";
            this.Activated += new System.EventHandler(this.frmSPMSetupSpecRelation_Activated);
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
            this.tabSpec.ResumeLayout(false);
            this.tbpVersion.ResumeLayout(false);
            this.pnlSpecVersion2.ResumeLayout(false);
            this.pnlSpecVerTab.ResumeLayout(false);
            this.tabVersion.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.PerformLayout();
            this.grpApplyTime.ResumeLayout(false);
            this.tbpAppNRel.ResumeLayout(false);
            this.pnlReleaseInfo.ResumeLayout(false);
            this.grpRelease.ResumeLayout(false);
            this.grpRelease.PerformLayout();
            this.grpApproval.ResumeLayout(false);
            this.grpApproval.PerformLayout();
            this.pnlVersionBottom.ResumeLayout(false);
            this.tbpCopyVer.ResumeLayout(false);
            this.grpCopyTable.ResumeLayout(false);
            this.grpCopyTable.PerformLayout();
            this.pnlSpecVersion.ResumeLayout(false);
            this.grpCoSetVersion.ResumeLayout(false);
            this.grpCoSetVersion.PerformLayout();
            this.tbpCharacter.ResumeLayout(false);
            this.pnlCharMid.ResumeLayout(false);
            this.pnlCharMidRight.ResumeLayout(false);
            this.pnlAllCharFilter.ResumeLayout(false);
            this.pnlAllCharFilter.PerformLayout();
            this.pnlCharRightBottom.ResumeLayout(false);
            this.pnlCharRightBottom.PerformLayout();
            this.pnlChar2.ResumeLayout(false);
            this.pnlChar2.PerformLayout();
            this.pnlCharMidMid.ResumeLayout(false);
            this.pnlCharMidLeft.ResumeLayout(false);
            this.pnlChar.ResumeLayout(false);
            this.pnlChar.PerformLayout();
            this.pnlCharLeftBottom.ResumeLayout(false);
            this.pnlCharLeftBottom.PerformLayout();
            this.tbpLimit.ResumeLayout(false);
            this.pnlLimitRight.ResumeLayout(false);
            this.tabLimit.ResumeLayout(false);
            this.tbpManSpec.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLimit_Sheet1)).EndInit();
            this.grpSpecLimit.ResumeLayout(false);
            this.grpSpecLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValidTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCode1)).EndInit();
            this.tbpCusSpec.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCusLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCusLimit_Sheet1)).EndInit();
            this.grpCusSpecLimit.ResumeLayout(false);
            this.grpCusSpecLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCusTargetValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCusValidTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCusAlarmCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCusAlarmCode1)).EndInit();
            this.pnlLimitLeft.ResumeLayout(false);
            this.pnlCharMidLeft3.ResumeLayout(false);
            this.pnlChar3.ResumeLayout(false);
            this.pnlChar3.PerformLayout();
            this.tbpAttr.ResumeLayout(false);
            this.pnlAttrRight.ResumeLayout(false);
            this.grpAttr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAttr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttr_Sheet1)).EndInit();
            this.pnlAttrLeft.ResumeLayout(false);
            this.pnlCharMidLeft4.ResumeLayout(false);
            this.pnlChar4.ResumeLayout(false);
            this.pnlChar4.PerformLayout();
            this.tbpDoc.ResumeLayout(false);
            this.pnlDocRight.ResumeLayout(false);
            this.grpImg.ResumeLayout(false);
            this.tlpImg.ResumeLayout(false);
            this.pnlImgBottom3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImg3)).EndInit();
            this.pnlImgBottom2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImg2)).EndInit();
            this.pnlImgBottom1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImg1)).EndInit();
            this.pnlImgTop3.ResumeLayout(false);
            this.pnlImgTop3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvImg3)).EndInit();
            this.pnlImgTop2.ResumeLayout(false);
            this.pnlImgTop2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvImg2)).EndInit();
            this.pnlImgTop1.ResumeLayout(false);
            this.pnlImgTop1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvImg1)).EndInit();
            this.grpDoc.ResumeLayout(false);
            this.grpDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDoc1)).EndInit();
            this.grpAttachOption.ResumeLayout(false);
            this.grpAttachOption.PerformLayout();
            this.pnlDocLeft.ResumeLayout(false);
            this.pnlCharMidLeft5.ResumeLayout(false);
            this.pnlChar5.ResumeLayout(false);
            this.pnlChar5.PerformLayout();
            this.tbpCopy.ResumeLayout(false);
            this.grpCopy.ResumeLayout(false);
            this.grpCopy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MESCore.Controls.udcMFOTreeList tvMFO;
        private System.Windows.Forms.TabControl tabSpec;
        private System.Windows.Forms.TabPage tbpVersion;
        private System.Windows.Forms.TabPage tbpCharacter;
        private System.Windows.Forms.TabPage tbpLimit;
        private System.Windows.Forms.TabPage tbpAttr;
        private System.Windows.Forms.TabPage tbpDoc;
        private System.Windows.Forms.TabPage tbpCopy;
        private UI.Controls.MCListView.MCListView lisSpecVersion;
        private System.Windows.Forms.ColumnHeader colSpecVersion;
        private System.Windows.Forms.Panel pnlSpecVersion;
        private System.Windows.Forms.GroupBox grpCoSetVersion;
        private System.Windows.Forms.TextBox txtSpecVersion;
        private System.Windows.Forms.Label lblSpecVersion;
        private System.Windows.Forms.Panel pnlSpecVersion2;
        private System.Windows.Forms.Panel pnlSpecVerTab;
        private System.Windows.Forms.TabControl tabVersion;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Panel pnlUpdateInfo;
        private System.Windows.Forms.GroupBox grpUpdateInfo;
        private System.Windows.Forms.TextBox txtSpecVerUpdateTime;
        private System.Windows.Forms.Label lblSpecVerUpdateTime;
        private System.Windows.Forms.TextBox txtSpecVerUpdateUser;
        private System.Windows.Forms.Label lblSpecVerUpdateUser;
        private System.Windows.Forms.TextBox txtSpecVerCreateTime;
        private System.Windows.Forms.Label lblSpecVerCreateTime;
        private System.Windows.Forms.TextBox txtSpecVerCreateUser;
        private System.Windows.Forms.Label lblSpecVerCreateUser;
        private System.Windows.Forms.GroupBox grpApplyTime;
        private System.Windows.Forms.CheckBox chkEnd;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.Label lblFromTo;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TabPage tbpAppNRel;
        private System.Windows.Forms.Panel pnlReleaseInfo;
        private System.Windows.Forms.GroupBox grpRelease;
        private System.Windows.Forms.CheckBox chkReleaseFlag;
        private System.Windows.Forms.TextBox txtReleaseTime;
        private System.Windows.Forms.Label lblReleaseTime;
        private System.Windows.Forms.TextBox txtReleaseUser;
        private System.Windows.Forms.Label lblReleaseUser;
        private System.Windows.Forms.GroupBox grpApproval;
        private System.Windows.Forms.CheckBox chkApprovalFlag;
        private System.Windows.Forms.TextBox txtApprovalTime;
        private System.Windows.Forms.Label lblApprovalTime;
        private System.Windows.Forms.TextBox txtApprovalUser;
        private System.Windows.Forms.Label lblApprovalUser;
        private System.Windows.Forms.Panel pnlCharMid;
        private System.Windows.Forms.Panel pnlCharMidRight;
        private UI.Controls.MCListView.MCListView lisAllChar;
        private System.Windows.Forms.ColumnHeader colChar2;
        private System.Windows.Forms.ColumnHeader colCharDesc2;
        private System.Windows.Forms.Panel pnlChar2;
        protected System.Windows.Forms.Button btnCharRefresh2;
        private System.Windows.Forms.Label lblChar2;
        private System.Windows.Forms.Panel pnlCharMidMid;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Panel pnlCharMidLeft;
        private UI.Controls.MCListView.MCListView lisAssignedChar;
        private System.Windows.Forms.ColumnHeader colChar;
        private System.Windows.Forms.ColumnHeader colCharDesc;
        private System.Windows.Forms.Panel pnlChar;
        protected System.Windows.Forms.Button btnCharRefresh;
        private System.Windows.Forms.Label lblChar;
        private UI.Controls.MCCodeView.MCSPCodeView cdvData;
        private System.Windows.Forms.GroupBox grpCopy;
        private UI.Controls.MCCodeView.MCCodeView cdvToVer;
        private System.Windows.Forms.Label lblToVer;
        private MESCore.Controls.udcOperation cdvToOper;
        private MESCore.Controls.udcFlow cdvToFlow;
        private MESCore.Controls.udcMaterial cdvToMaterial;
        private System.Windows.Forms.Button btnCopySpec;
        private System.Windows.Forms.TabPage tbpCopyVer;
        private System.Windows.Forms.GroupBox grpCopyTable;
        private System.Windows.Forms.Button btnCopyVersion;
        private System.Windows.Forms.Label lblToVersion;
        private System.Windows.Forms.TextBox txtToVersion;
        private System.Windows.Forms.Panel pnlVersionBottom;
        public System.Windows.Forms.Button btnApproval;
        public System.Windows.Forms.Button btnCancelApproval;
        public System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Panel pnlCharRightBottom;
        private System.Windows.Forms.Panel pnlCharLeftBottom;
        private System.Windows.Forms.TextBox txtAllCharCount;
        private System.Windows.Forms.Label lblAllCharCount;
        private System.Windows.Forms.TextBox txtAssignedCharCount;
        private System.Windows.Forms.Label lblAssignedCharCount;
        private System.Windows.Forms.Panel pnlAllCharFilter;
        private System.Windows.Forms.TextBox txtAllCharFilter;
        private System.Windows.Forms.Label lblAllCharFilter;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Panel pnlLimitRight;
        private System.Windows.Forms.TabControl tabLimit;
        private System.Windows.Forms.TabPage tbpManSpec;
        private FarPoint.Win.Spread.FpSpread spdLimit;
        private FarPoint.Win.Spread.SheetView spdLimit_Sheet1;
        private System.Windows.Forms.GroupBox grpSpecLimit;
        private UI.Controls.MCCodeView.MCCodeView cdvTargetValue;
        private System.Windows.Forms.Label lblValidTable;
        private UI.Controls.MCCodeView.MCCodeView cdvValidTable;
        private System.Windows.Forms.CheckBox chkManSpec;
        private System.Windows.Forms.Label lblAlarmCode2;
        private System.Windows.Forms.Label lblAlarmCode1;
        private UI.Controls.MCCodeView.MCCodeView cdvAlarmCode2;
        private UI.Controls.MCCodeView.MCCodeView cdvAlarmCode1;
        private System.Windows.Forms.ComboBox cboSpecType;
        private System.Windows.Forms.Label lblSpecType;
        private System.Windows.Forms.Label lblSpecOutCount;
        private System.Windows.Forms.TextBox txtSpecOutCount;
        private System.Windows.Forms.Label lblLowerWarnLimit;
        private System.Windows.Forms.TextBox txtLowerWarnLimit;
        private System.Windows.Forms.Label lblUpperWarnLimit;
        private System.Windows.Forms.TextBox txtUpperWarnLimit;
        private System.Windows.Forms.Label lblLowerSpecLimit;
        private System.Windows.Forms.TextBox txtLowerSpecLimit;
        private System.Windows.Forms.Label lblUpperSpecLimit;
        private System.Windows.Forms.TextBox txtUpperSpecLimit;
        private System.Windows.Forms.Label lblTargetValue;
        private System.Windows.Forms.TabPage tbpCusSpec;
        private FarPoint.Win.Spread.FpSpread spdCusLimit;
        private FarPoint.Win.Spread.SheetView spdCusLimit_Sheet1;
        private System.Windows.Forms.GroupBox grpCusSpecLimit;
        private UI.Controls.MCCodeView.MCCodeView cdvCusTargetValue;
        private System.Windows.Forms.Label lblCusValidTable;
        private UI.Controls.MCCodeView.MCCodeView cdvCusValidTable;
        private System.Windows.Forms.CheckBox chkCusSpec;
        private System.Windows.Forms.Label lblCusAlarmCode2;
        private System.Windows.Forms.Label lblCusAlarmCode1;
        private UI.Controls.MCCodeView.MCCodeView cdvCusAlarmCode2;
        private UI.Controls.MCCodeView.MCCodeView cdvCusAlarmCode1;
        private System.Windows.Forms.ComboBox cboCusSpecType;
        private System.Windows.Forms.Label lblCusSpecType;
        private System.Windows.Forms.Label lblCusSpecOutCount;
        private System.Windows.Forms.TextBox txtCusSpecOutCount;
        private System.Windows.Forms.Label lblCusLowerWarnLimit;
        private System.Windows.Forms.TextBox txtCusLowerWarnLimit;
        private System.Windows.Forms.Label lblCusUpperWarnLimit;
        private System.Windows.Forms.TextBox txtCusUpperWarnLimit;
        private System.Windows.Forms.Label lblCusLowerSpecLimit;
        private System.Windows.Forms.TextBox txtCusLowerSpecLimit;
        private System.Windows.Forms.Label lblCusUpperSpecLimit;
        private System.Windows.Forms.TextBox txtCusUpperSpecLimit;
        private System.Windows.Forms.Label lblCusTargetValue;
        private System.Windows.Forms.Splitter splLimit;
        private System.Windows.Forms.Panel pnlLimitLeft;
        private System.Windows.Forms.Panel pnlCharMidLeft3;
        private UI.Controls.MCListView.MCListView lisAssignedChar3;
        private System.Windows.Forms.ColumnHeader colChar3;
        private System.Windows.Forms.ColumnHeader colCharDesc3;
        private System.Windows.Forms.ColumnHeader colCharType3;
        private System.Windows.Forms.Panel pnlChar3;
        protected System.Windows.Forms.Button btnCharRefresh3;
        private System.Windows.Forms.Label lblChar3;
        private System.Windows.Forms.Panel pnlAttrRight;
        private System.Windows.Forms.GroupBox grpAttr;
        private FarPoint.Win.Spread.FpSpread spdAttr;
        private FarPoint.Win.Spread.SheetView spdAttr_Sheet1;
        private System.Windows.Forms.Splitter splAttr;
        private System.Windows.Forms.Panel pnlAttrLeft;
        private System.Windows.Forms.Panel pnlCharMidLeft4;
        private UI.Controls.MCListView.MCListView lisAssignedChar4;
        private System.Windows.Forms.ColumnHeader colChar4;
        private System.Windows.Forms.ColumnHeader colCharDesc4;
        private System.Windows.Forms.Panel pnlChar4;
        protected System.Windows.Forms.Button btnCharRefresh4;
        private System.Windows.Forms.Label lblChar4;
        private System.Windows.Forms.Button btnAttachAll;
        private System.Windows.Forms.Panel pnlDocRight;
        private System.Windows.Forms.GroupBox grpImg;
        private System.Windows.Forms.TableLayoutPanel tlpImg;
        private System.Windows.Forms.Panel pnlImgBottom3;
        private System.Windows.Forms.PictureBox picImg3;
        private System.Windows.Forms.Panel pnlImgBottom2;
        private System.Windows.Forms.PictureBox picImg2;
        private System.Windows.Forms.Panel pnlImgBottom1;
        private System.Windows.Forms.PictureBox picImg1;
        private System.Windows.Forms.Panel pnlImgTop3;
        private UI.Controls.MCCodeView.MCCodeView cdvImg3;
        private System.Windows.Forms.Label lblImg3;
        private System.Windows.Forms.Panel pnlImgTop2;
        private UI.Controls.MCCodeView.MCCodeView cdvImg2;
        private System.Windows.Forms.Label lblImg2;
        private System.Windows.Forms.Panel pnlImgTop1;
        private UI.Controls.MCCodeView.MCCodeView cdvImg1;
        private System.Windows.Forms.Label lblImg1;
        private System.Windows.Forms.GroupBox grpDoc;
        private System.Windows.Forms.Button btnDoc5;
        private UI.Controls.MCCodeView.MCCodeView cdvDoc5;
        private System.Windows.Forms.Label lblDoc5;
        private System.Windows.Forms.Button btnDoc4;
        private UI.Controls.MCCodeView.MCCodeView cdvDoc4;
        private System.Windows.Forms.Label lblDoc4;
        private System.Windows.Forms.Button btnDoc3;
        private UI.Controls.MCCodeView.MCCodeView cdvDoc3;
        private System.Windows.Forms.Label lblDoc3;
        private System.Windows.Forms.Button btnDoc2;
        private UI.Controls.MCCodeView.MCCodeView cdvDoc2;
        private System.Windows.Forms.Label lblDoc2;
        private System.Windows.Forms.Button btnDoc1;
        private UI.Controls.MCCodeView.MCCodeView cdvDoc1;
        private System.Windows.Forms.Label lblDoc1;
        private System.Windows.Forms.GroupBox grpAttachOption;
        private System.Windows.Forms.CheckBox chkUseLatestFileVersion;
        private System.Windows.Forms.CheckBox chkUseTargetToDir;
        private System.Windows.Forms.CheckBox chkUseCharDir;
        private System.Windows.Forms.Splitter splDoc;
        private System.Windows.Forms.Panel pnlDocLeft;
        private System.Windows.Forms.Panel pnlCharMidLeft5;
        private UI.Controls.MCListView.MCListView lisAssignedChar5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel pnlChar5;
        protected System.Windows.Forms.Button btnCharRefresh5;
        private System.Windows.Forms.Label lblChar5;
        private System.Windows.Forms.CheckBox chkKeep8;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkKeep7;
        private System.Windows.Forms.CheckBox chkKeep6;
        private System.Windows.Forms.CheckBox chkKeep5;
        private System.Windows.Forms.CheckBox chkKeep4;
        private System.Windows.Forms.CheckBox chkKeep3;
        private System.Windows.Forms.CheckBox chkKeep2;
        private System.Windows.Forms.CheckBox chkKeep1;
        private System.Windows.Forms.Label lblFileExt;
        private System.Windows.Forms.TextBox txtFileExt;
        private System.Windows.Forms.CheckBox chkUseTargetToFile;
        private System.Windows.Forms.Button btnViewSpecFile;
    }
}