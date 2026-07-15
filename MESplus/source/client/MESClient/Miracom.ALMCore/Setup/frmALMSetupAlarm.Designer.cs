namespace Miracom.ALMCore
{
    partial class frmALMSetupAlarm
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
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlContition = new System.Windows.Forms.Panel();
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.lblAlarmType = new System.Windows.Forms.Label();
            this.cboAlarmType = new System.Windows.Forms.ComboBox();
            this.pnlAlarm = new System.Windows.Forms.Panel();
            this.grpAlarm = new System.Windows.Forms.GroupBox();
            this.chkResAlarmFlag = new System.Windows.Forms.CheckBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtAlarmID = new System.Windows.Forms.TextBox();
            this.lblAlarmID = new System.Windows.Forms.Label();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabAlarm = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlRelate = new System.Windows.Forms.Panel();
            this.grpLotAction = new System.Windows.Forms.GroupBox();
            this.lblReturnOption = new System.Windows.Forms.Label();
            this.cboReturnOption = new System.Windows.Forms.ComboBox();
            this.cdvReworkStopOper = new Miracom.MESCore.Controls.udcOperation();
            this.cboTran = new System.Windows.Forms.ComboBox();
            this.lblTranCode = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtHoldPassword = new System.Windows.Forms.TextBox();
            this.lblHoldPassword = new System.Windows.Forms.Label();
            this.cdvHoldCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblHoldCode = new System.Windows.Forms.Label();
            this.cdvReturnOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvReturnFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvReworkOper = new Miracom.MESCore.Controls.udcOperation();
            this.cdvReworkFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.grpAlarmAction = new System.Windows.Forms.GroupBox();
            this.chkMail = new System.Windows.Forms.CheckBox();
            this.chkMessage = new System.Windows.Forms.CheckBox();
            this.chkDisplay = new System.Windows.Forms.CheckBox();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.rbnWarning = new System.Windows.Forms.RadioButton();
            this.rbnError = new System.Windows.Forms.RadioButton();
            this.rbnInformation = new System.Windows.Forms.RadioButton();
            this.tbpRecvInfo = new System.Windows.Forms.TabPage();
            this.pnlRecvInfo = new System.Windows.Forms.Panel();
            this.grpReceive = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lisRecvList = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlRecMid = new System.Windows.Forms.Panel();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lisPrvGrpList = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisUserList = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisSecGrpList = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkShift4 = new System.Windows.Forms.CheckBox();
            this.chkShift3 = new System.Windows.Forms.CheckBox();
            this.chkShift2 = new System.Windows.Forms.CheckBox();
            this.chkShift1 = new System.Windows.Forms.CheckBox();
            this.rbnPrvGroup = new System.Windows.Forms.RadioButton();
            this.rbnSecGroup = new System.Windows.Forms.RadioButton();
            this.rbnUser = new System.Windows.Forms.RadioButton();
            this.grpLotAlarm = new System.Windows.Forms.GroupBox();
            this.chkSendToUser = new System.Windows.Forms.CheckBox();
            this.tbpMessage = new System.Windows.Forms.TabPage();
            this.grpMsgData = new System.Windows.Forms.GroupBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtMsg3 = new System.Windows.Forms.TextBox();
            this.txtMsg2 = new System.Windows.Forms.TextBox();
            this.txtMsg1 = new System.Windows.Forms.TextBox();
            this.lblMsg_3 = new System.Windows.Forms.Label();
            this.lblMsg_2 = new System.Windows.Forms.Label();
            this.lblMsg_1 = new System.Windows.Forms.Label();
            this.tbpComment = new System.Windows.Forms.TabPage();
            this.spdComment = new FarPoint.Win.Spread.FpSpread();
            this.spdComment_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpPDF = new System.Windows.Forms.TabPage();
            this.pnlPDF = new System.Windows.Forms.Panel();
            this.pnlPDFBottom = new System.Windows.Forms.Panel();
            this.btnPDFRemove = new System.Windows.Forms.Button();
            this.btnPDFOpen = new System.Windows.Forms.Button();
            this.tbpImage = new System.Windows.Forms.TabPage();
            this.grpImage = new System.Windows.Forms.GroupBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.pnlImgBottom = new System.Windows.Forms.Panel();
            this.btnImgRemove = new System.Windows.Forms.Button();
            this.btnImgOpen = new System.Windows.Forms.Button();
            this.tbpEvent = new System.Windows.Forms.TabPage();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.cdvChangeStatus10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChgStatus3 = new System.Windows.Forms.Label();
            this.lblChgStatus2 = new System.Windows.Forms.Label();
            this.lblChgStatus8 = new System.Windows.Forms.Label();
            this.lblChgStatus7 = new System.Windows.Forms.Label();
            this.lblChgStatus4 = new System.Windows.Forms.Label();
            this.lblChgStatus6 = new System.Windows.Forms.Label();
            this.lblChgStatus5 = new System.Windows.Forms.Label();
            this.lblChgStatus1 = new System.Windows.Forms.Label();
            this.lblChgStatus10 = new System.Windows.Forms.Label();
            this.lblChgStatus9 = new System.Windows.Forms.Label();
            this.grpResComment = new System.Windows.Forms.GroupBox();
            this.txtResComment = new System.Windows.Forms.TextBox();
            this.lblResComment = new System.Windows.Forms.Label();
            this.grpEvent = new System.Windows.Forms.GroupBox();
            this.cdvEvent = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.tbpClearEvent = new System.Windows.Forms.TabPage();
            this.grpClearChgStatus = new System.Windows.Forms.GroupBox();
            this.cdvClearChangeStatus10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvClearChangeStatus9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvClearChangeStatus8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvClearChangeStatus7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvClearChangeStatus6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvClearChangeStatus5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvClearChangeStatus4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvClearChangeStatus3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvClearChangeStatus2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvClearChangeStatus1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblClearChgStatus3 = new System.Windows.Forms.Label();
            this.lblClearChgStatus2 = new System.Windows.Forms.Label();
            this.lblClearChgStatus8 = new System.Windows.Forms.Label();
            this.lblClearChgStatus7 = new System.Windows.Forms.Label();
            this.lblClearChgStatus4 = new System.Windows.Forms.Label();
            this.lblClearChgStatus6 = new System.Windows.Forms.Label();
            this.lblClearChgStatus5 = new System.Windows.Forms.Label();
            this.lblClearChgStatus1 = new System.Windows.Forms.Label();
            this.lblClearChgStatus10 = new System.Windows.Forms.Label();
            this.lblClearChgStatus9 = new System.Windows.Forms.Label();
            this.grpClearResComment = new System.Windows.Forms.GroupBox();
            this.txtClearResComment = new System.Windows.Forms.TextBox();
            this.lblClearComment = new System.Windows.Forms.Label();
            this.grpClearEvent = new System.Windows.Forms.GroupBox();
            this.cdvClearEvent = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblClearEvent = new System.Windows.Forms.Label();
            this.tbpTranCMF = new System.Windows.Forms.TabPage();
            this.grpTranCMF = new System.Windows.Forms.GroupBox();
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
            this.tbpAlarmGroup = new System.Windows.Forms.TabPage();
            this.grpAlarmGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup10 = new System.Windows.Forms.Label();
            this.lblGroup9 = new System.Windows.Forms.Label();
            this.lblGroup8 = new System.Windows.Forms.Label();
            this.lblGroup7 = new System.Windows.Forms.Label();
            this.lblGroup6 = new System.Windows.Forms.Label();
            this.lblGroup5 = new System.Windows.Forms.Label();
            this.lblGroup4 = new System.Windows.Forms.Label();
            this.lblGroup3 = new System.Windows.Forms.Label();
            this.lblGroup2 = new System.Windows.Forms.Label();
            this.lblGroup1 = new System.Windows.Forms.Label();
            this.cdvGroup9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.tbpAlarmCMF = new System.Windows.Forms.TabPage();
            this.grpAlarmCMF = new System.Windows.Forms.GroupBox();
            this.cdvAlarmCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAlarmCMF20 = new System.Windows.Forms.Label();
            this.lblAlarmCMF19 = new System.Windows.Forms.Label();
            this.lblAlarmCMF18 = new System.Windows.Forms.Label();
            this.lblAlarmCMF17 = new System.Windows.Forms.Label();
            this.lblAlarmCMF16 = new System.Windows.Forms.Label();
            this.lblAlarmCMF15 = new System.Windows.Forms.Label();
            this.lblAlarmCMF14 = new System.Windows.Forms.Label();
            this.lblAlarmCMF13 = new System.Windows.Forms.Label();
            this.lblAlarmCMF12 = new System.Windows.Forms.Label();
            this.lblAlarmCMF11 = new System.Windows.Forms.Label();
            this.cdvAlarmCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAlarmCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAlarmCMF10 = new System.Windows.Forms.Label();
            this.lblAlarmCMF9 = new System.Windows.Forms.Label();
            this.lblAlarmCMF8 = new System.Windows.Forms.Label();
            this.lblAlarmCMF7 = new System.Windows.Forms.Label();
            this.lblAlarmCMF6 = new System.Windows.Forms.Label();
            this.lblAlarmCMF5 = new System.Windows.Forms.Label();
            this.lblAlarmCMF4 = new System.Windows.Forms.Label();
            this.lblAlarmCMF3 = new System.Windows.Forms.Label();
            this.lblAlarmCMF2 = new System.Windows.Forms.Label();
            this.lblAlarmCMF1 = new System.Windows.Forms.Label();
            this.lisAlarm = new Miracom.UI.Controls.MCListView.MCListView();
            this.colAlarm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlmDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlContition.SuspendLayout();
            this.grpCondition.SuspendLayout();
            this.pnlAlarm.SuspendLayout();
            this.grpAlarm.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabAlarm.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlRelate.SuspendLayout();
            this.grpLotAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).BeginInit();
            this.grpAlarmAction.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.tbpRecvInfo.SuspendLayout();
            this.pnlRecvInfo.SuspendLayout();
            this.grpReceive.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlRecMid.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpLotAlarm.SuspendLayout();
            this.tbpMessage.SuspendLayout();
            this.grpMsgData.SuspendLayout();
            this.tbpComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdComment_Sheet1)).BeginInit();
            this.tbpPDF.SuspendLayout();
            this.pnlPDFBottom.SuspendLayout();
            this.tbpImage.SuspendLayout();
            this.grpImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.pnlImgBottom.SuspendLayout();
            this.tbpEvent.SuspendLayout();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus1)).BeginInit();
            this.grpResComment.SuspendLayout();
            this.grpEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEvent)).BeginInit();
            this.tbpClearEvent.SuspendLayout();
            this.grpClearChgStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus1)).BeginInit();
            this.grpClearResComment.SuspendLayout();
            this.grpClearEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearEvent)).BeginInit();
            this.tbpTranCMF.SuspendLayout();
            this.grpTranCMF.SuspendLayout();
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
            this.tbpAlarmGroup.SuspendLayout();
            this.grpAlarmGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).BeginInit();
            this.tbpAlarmCMF.SuspendLayout();
            this.grpAlarmCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
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
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.pnlAlarm);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisAlarm);
            this.pnlLeft.Controls.Add(this.pnlContition);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            columnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer4.Name = "columnHeaderRenderer4";
            columnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer4.TextRotationAngle = 0D;
            rowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer4.Name = "rowHeaderRenderer4";
            rowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer4.TextRotationAngle = 0D;
            // 
            // pnlContition
            // 
            this.pnlContition.Controls.Add(this.grpCondition);
            this.pnlContition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContition.Location = new System.Drawing.Point(0, 0);
            this.pnlContition.Name = "pnlContition";
            this.pnlContition.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlContition.Size = new System.Drawing.Size(232, 42);
            this.pnlContition.TabIndex = 0;
            // 
            // grpCondition
            // 
            this.grpCondition.Controls.Add(this.lblAlarmType);
            this.grpCondition.Controls.Add(this.cboAlarmType);
            this.grpCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCondition.Location = new System.Drawing.Point(0, 0);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(232, 39);
            this.grpCondition.TabIndex = 0;
            this.grpCondition.TabStop = false;
            // 
            // lblAlarmType
            // 
            this.lblAlarmType.AutoSize = true;
            this.lblAlarmType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmType.Location = new System.Drawing.Point(6, 15);
            this.lblAlarmType.Name = "lblAlarmType";
            this.lblAlarmType.Size = new System.Drawing.Size(60, 13);
            this.lblAlarmType.TabIndex = 0;
            this.lblAlarmType.Text = "Alarm Type";
            this.lblAlarmType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboAlarmType
            // 
            this.cboAlarmType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAlarmType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboAlarmType.FormattingEnabled = true;
            this.cboAlarmType.Items.AddRange(new object[] {
            "ALL Alarm List",
            "Only Normal Alarm",
            "Only Resource Alarm",
            "Only Automatic Collected Alarm"});
            this.cboAlarmType.Location = new System.Drawing.Point(76, 12);
            this.cboAlarmType.Name = "cboAlarmType";
            this.cboAlarmType.Size = new System.Drawing.Size(149, 21);
            this.cboAlarmType.TabIndex = 0;
            this.cboAlarmType.SelectedIndexChanged += new System.EventHandler(this.cboAlarmType_SelectedIndexChanged);
            // 
            // pnlAlarm
            // 
            this.pnlAlarm.Controls.Add(this.grpAlarm);
            this.pnlAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlarm.Location = new System.Drawing.Point(0, 0);
            this.pnlAlarm.Name = "pnlAlarm";
            this.pnlAlarm.Size = new System.Drawing.Size(506, 64);
            this.pnlAlarm.TabIndex = 0;
            // 
            // grpAlarm
            // 
            this.grpAlarm.Controls.Add(this.chkResAlarmFlag);
            this.grpAlarm.Controls.Add(this.txtDesc);
            this.grpAlarm.Controls.Add(this.lblDesc);
            this.grpAlarm.Controls.Add(this.txtAlarmID);
            this.grpAlarm.Controls.Add(this.lblAlarmID);
            this.grpAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlarm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAlarm.Location = new System.Drawing.Point(0, 0);
            this.grpAlarm.Name = "grpAlarm";
            this.grpAlarm.Size = new System.Drawing.Size(506, 64);
            this.grpAlarm.TabIndex = 0;
            this.grpAlarm.TabStop = false;
            // 
            // chkResAlarmFlag
            // 
            this.chkResAlarmFlag.AutoSize = true;
            this.chkResAlarmFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkResAlarmFlag.Location = new System.Drawing.Point(346, 16);
            this.chkResAlarmFlag.Name = "chkResAlarmFlag";
            this.chkResAlarmFlag.Size = new System.Drawing.Size(130, 18);
            this.chkResAlarmFlag.TabIndex = 1;
            this.chkResAlarmFlag.Text = "Resource Alarm Flag";
            this.chkResAlarmFlag.CheckedChanged += new System.EventHandler(this.chkResAlarmFlag_CheckedChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(122, 38);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtDesc.Size = new System.Drawing.Size(372, 20);
            this.txtDesc.TabIndex = 2;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(14, 41);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Description";
            // 
            // txtAlarmID
            // 
            this.txtAlarmID.Location = new System.Drawing.Point(122, 14);
            this.txtAlarmID.MaxLength = 20;
            this.txtAlarmID.Name = "txtAlarmID";
            this.txtAlarmID.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtAlarmID.Size = new System.Drawing.Size(194, 20);
            this.txtAlarmID.TabIndex = 0;
            // 
            // lblAlarmID
            // 
            this.lblAlarmID.AutoSize = true;
            this.lblAlarmID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmID.Location = new System.Drawing.Point(14, 17);
            this.lblAlarmID.Name = "lblAlarmID";
            this.lblAlarmID.Size = new System.Drawing.Size(55, 13);
            this.lblAlarmID.TabIndex = 0;
            this.lblAlarmID.Text = "Alarm ID";
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabAlarm);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 64);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(506, 449);
            this.pnlTab.TabIndex = 1;
            // 
            // tabAlarm
            // 
            this.tabAlarm.Controls.Add(this.tbpGeneral);
            this.tabAlarm.Controls.Add(this.tbpRecvInfo);
            this.tabAlarm.Controls.Add(this.tbpMessage);
            this.tabAlarm.Controls.Add(this.tbpComment);
            this.tabAlarm.Controls.Add(this.tbpPDF);
            this.tabAlarm.Controls.Add(this.tbpImage);
            this.tabAlarm.Controls.Add(this.tbpEvent);
            this.tabAlarm.Controls.Add(this.tbpClearEvent);
            this.tabAlarm.Controls.Add(this.tbpTranCMF);
            this.tabAlarm.Controls.Add(this.tbpAlarmGroup);
            this.tabAlarm.Controls.Add(this.tbpAlarmCMF);
            this.tabAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAlarm.ItemSize = new System.Drawing.Size(60, 18);
            this.tabAlarm.Location = new System.Drawing.Point(0, 3);
            this.tabAlarm.Name = "tabAlarm";
            this.tabAlarm.SelectedIndex = 0;
            this.tabAlarm.Size = new System.Drawing.Size(506, 446);
            this.tabAlarm.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.BackColor = System.Drawing.SystemColors.Control;
            this.tbpGeneral.Controls.Add(this.pnlRelate);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(498, 420);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlRelate
            // 
            this.pnlRelate.Controls.Add(this.grpLotAction);
            this.pnlRelate.Controls.Add(this.grpAlarmAction);
            this.pnlRelate.Controls.Add(this.grpInfo);
            this.pnlRelate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRelate.Location = new System.Drawing.Point(0, 0);
            this.pnlRelate.Name = "pnlRelate";
            this.pnlRelate.Size = new System.Drawing.Size(498, 420);
            this.pnlRelate.TabIndex = 0;
            // 
            // grpLotAction
            // 
            this.grpLotAction.BackColor = System.Drawing.SystemColors.Control;
            this.grpLotAction.Controls.Add(this.lblReturnOption);
            this.grpLotAction.Controls.Add(this.cboReturnOption);
            this.grpLotAction.Controls.Add(this.cdvReworkStopOper);
            this.grpLotAction.Controls.Add(this.cboTran);
            this.grpLotAction.Controls.Add(this.lblTranCode);
            this.grpLotAction.Controls.Add(this.txtComment);
            this.grpLotAction.Controls.Add(this.lblComment);
            this.grpLotAction.Controls.Add(this.txtHoldPassword);
            this.grpLotAction.Controls.Add(this.lblHoldPassword);
            this.grpLotAction.Controls.Add(this.cdvHoldCode);
            this.grpLotAction.Controls.Add(this.lblHoldCode);
            this.grpLotAction.Controls.Add(this.cdvReturnOper);
            this.grpLotAction.Controls.Add(this.cdvReturnFlow);
            this.grpLotAction.Controls.Add(this.cdvReworkOper);
            this.grpLotAction.Controls.Add(this.cdvReworkFlow);
            this.grpLotAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotAction.Location = new System.Drawing.Point(0, 76);
            this.grpLotAction.Name = "grpLotAction";
            this.grpLotAction.Size = new System.Drawing.Size(498, 344);
            this.grpLotAction.TabIndex = 2;
            this.grpLotAction.TabStop = false;
            this.grpLotAction.Text = "Lot Action";
            // 
            // lblReturnOption
            // 
            this.lblReturnOption.AutoSize = true;
            this.lblReturnOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReturnOption.Location = new System.Drawing.Point(9, 143);
            this.lblReturnOption.Name = "lblReturnOption";
            this.lblReturnOption.Size = new System.Drawing.Size(73, 13);
            this.lblReturnOption.TabIndex = 11;
            this.lblReturnOption.Text = "Return Option";
            // 
            // cboReturnOption
            // 
            this.cboReturnOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReturnOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboReturnOption.FormattingEnabled = true;
            this.cboReturnOption.Items.AddRange(new object[] {
            "Keep Rework",
            "Clear Rework",
            "Clear Rework and Move to Next Operation",
            "Keep Rework and Move to Next Operation"});
            this.cboReturnOption.Location = new System.Drawing.Point(86, 139);
            this.cboReturnOption.Name = "cboReturnOption";
            this.cboReturnOption.Size = new System.Drawing.Size(299, 21);
            this.cboReturnOption.TabIndex = 12;
            // 
            // cdvReworkStopOper
            // 
            this.cdvReworkStopOper.AddEmptyRowToLast = false;
            this.cdvReworkStopOper.AddEmptyRowToTop = false;
            this.cdvReworkStopOper.ButtonWidth = 21;
            this.cdvReworkStopOper.DisplaySubItemIndex = 0;
            this.cdvReworkStopOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkStopOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkStopOper.LabelText = "Stop Operation";
            this.cdvReworkStopOper.LabelWidth = 106;
            this.cdvReworkStopOper.ListCond_ExtFactory = "";
            this.cdvReworkStopOper.ListCond_Step = '2';
            this.cdvReworkStopOper.Location = new System.Drawing.Point(278, 90);
            this.cdvReworkStopOper.Name = "cdvReworkStopOper";
            this.cdvReworkStopOper.ReadOnly = false;
            this.cdvReworkStopOper.SearchSubItemIndex = 0;
            this.cdvReworkStopOper.SelectedDescIndex = 1;
            this.cdvReworkStopOper.SelectedSubItemIndex = 0;
            this.cdvReworkStopOper.Size = new System.Drawing.Size(212, 20);
            this.cdvReworkStopOper.TabIndex = 8;
            this.cdvReworkStopOper.TextBoxWidth = 106;
            this.cdvReworkStopOper.VisibleButton = true;
            this.cdvReworkStopOper.VisibleColumnHeader = false;
            this.cdvReworkStopOper.VisibleDescription = false;
            this.cdvReworkStopOper.ButtonPress += new System.EventHandler(this.cdvReworkStopOper_ButtonPress);
            // 
            // cboTran
            // 
            this.cboTran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTran.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTran.FormattingEnabled = true;
            this.cboTran.Items.AddRange(new object[] {
            " ",
            "HOLD",
            "FUTURE HOLD",
            "REWORK",
            "PROCESS BLOCKING"});
            this.cboTran.Location = new System.Drawing.Point(86, 16);
            this.cboTran.Name = "cboTran";
            this.cboTran.Size = new System.Drawing.Size(181, 21);
            this.cboTran.TabIndex = 1;
            this.cboTran.SelectedIndexChanged += new System.EventHandler(this.cboTran_SelectedIndexChanged);
            // 
            // lblTranCode
            // 
            this.lblTranCode.AutoSize = true;
            this.lblTranCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTranCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranCode.Location = new System.Drawing.Point(9, 22);
            this.lblTranCode.Name = "lblTranCode";
            this.lblTranCode.Size = new System.Drawing.Size(57, 13);
            this.lblTranCode.TabIndex = 0;
            this.lblTranCode.Text = "Tran Code";
            this.lblTranCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(86, 315);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(404, 20);
            this.txtComment.TabIndex = 14;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(9, 318);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(69, 13);
            this.lblComment.TabIndex = 13;
            this.lblComment.Text = "Lot Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHoldPassword
            // 
            this.txtHoldPassword.Location = new System.Drawing.Point(384, 41);
            this.txtHoldPassword.MaxLength = 20;
            this.txtHoldPassword.Name = "txtHoldPassword";
            this.txtHoldPassword.Size = new System.Drawing.Size(106, 20);
            this.txtHoldPassword.TabIndex = 5;
            this.txtHoldPassword.UseSystemPasswordChar = true;
            // 
            // lblHoldPassword
            // 
            this.lblHoldPassword.AutoSize = true;
            this.lblHoldPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldPassword.Location = new System.Drawing.Point(278, 46);
            this.lblHoldPassword.Name = "lblHoldPassword";
            this.lblHoldPassword.Size = new System.Drawing.Size(78, 13);
            this.lblHoldPassword.TabIndex = 4;
            this.lblHoldPassword.Text = "Hold Password";
            this.lblHoldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvHoldCode
            // 
            this.cdvHoldCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvHoldCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvHoldCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvHoldCode.BtnToolTipText = "";
            this.cdvHoldCode.DescText = "";
            this.cdvHoldCode.DisplaySubItemIndex = -1;
            this.cdvHoldCode.DisplayText = "";
            this.cdvHoldCode.Focusing = null;
            this.cdvHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvHoldCode.Index = 0;
            this.cdvHoldCode.IsViewBtnImage = false;
            this.cdvHoldCode.Location = new System.Drawing.Point(86, 41);
            this.cdvHoldCode.MaxLength = 10;
            this.cdvHoldCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.Name = "cdvHoldCode";
            this.cdvHoldCode.ReadOnly = false;
            this.cdvHoldCode.SearchSubItemIndex = 0;
            this.cdvHoldCode.SelectedDescIndex = -1;
            this.cdvHoldCode.SelectedSubItemIndex = -1;
            this.cdvHoldCode.SelectionStart = 0;
            this.cdvHoldCode.Size = new System.Drawing.Size(131, 20);
            this.cdvHoldCode.SmallImageList = null;
            this.cdvHoldCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvHoldCode.TabIndex = 3;
            this.cdvHoldCode.TextBoxToolTipText = "";
            this.cdvHoldCode.TextBoxWidth = 131;
            this.cdvHoldCode.VisibleButton = true;
            this.cdvHoldCode.VisibleColumnHeader = false;
            this.cdvHoldCode.VisibleDescription = false;
            this.cdvHoldCode.ButtonPress += new System.EventHandler(this.cdvHoldCode_ButtonPress);
            // 
            // lblHoldCode
            // 
            this.lblHoldCode.AutoSize = true;
            this.lblHoldCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldCode.Location = new System.Drawing.Point(9, 46);
            this.lblHoldCode.Name = "lblHoldCode";
            this.lblHoldCode.Size = new System.Drawing.Size(57, 13);
            this.lblHoldCode.TabIndex = 2;
            this.lblHoldCode.Text = "Hold Code";
            this.lblHoldCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvReturnOper
            // 
            this.cdvReturnOper.AddEmptyRowToLast = false;
            this.cdvReturnOper.AddEmptyRowToTop = false;
            this.cdvReturnOper.ButtonWidth = 21;
            this.cdvReturnOper.DisplaySubItemIndex = 0;
            this.cdvReturnOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnOper.LabelText = "Return Operation";
            this.cdvReturnOper.LabelWidth = 106;
            this.cdvReturnOper.ListCond_ExtFactory = "";
            this.cdvReturnOper.ListCond_Step = '2';
            this.cdvReturnOper.Location = new System.Drawing.Point(278, 114);
            this.cdvReturnOper.Name = "cdvReturnOper";
            this.cdvReturnOper.ReadOnly = false;
            this.cdvReturnOper.SearchSubItemIndex = 0;
            this.cdvReturnOper.SelectedDescIndex = 1;
            this.cdvReturnOper.SelectedSubItemIndex = 0;
            this.cdvReturnOper.Size = new System.Drawing.Size(212, 20);
            this.cdvReturnOper.TabIndex = 10;
            this.cdvReturnOper.TextBoxWidth = 106;
            this.cdvReturnOper.VisibleButton = true;
            this.cdvReturnOper.VisibleColumnHeader = false;
            this.cdvReturnOper.VisibleDescription = false;
            this.cdvReturnOper.ButtonPress += new System.EventHandler(this.cdvReturnOper_ButtonPress);
            // 
            // cdvReturnFlow
            // 
            this.cdvReturnFlow.AddEmptyRowToLast = false;
            this.cdvReturnFlow.AddEmptyRowToTop = false;
            this.cdvReturnFlow.DisplaySubItemIndex = 0;
            this.cdvReturnFlow.FlowReadOnly = false;
            this.cdvReturnFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnFlow.LabelText = "Return Flow";
            this.cdvReturnFlow.LabelWidth = 77;
            this.cdvReturnFlow.ListCond_ExtFactory = "";
            this.cdvReturnFlow.ListCond_Step = '1';
            this.cdvReturnFlow.Location = new System.Drawing.Point(9, 114);
            this.cdvReturnFlow.Name = "cdvReturnFlow";
            this.cdvReturnFlow.SearchSubItemIndex = 0;
            this.cdvReturnFlow.SelectedDescIndex = -1;
            this.cdvReturnFlow.SelectedSubItemIndex = 0;
            this.cdvReturnFlow.SequenceReadOnly = false;
            this.cdvReturnFlow.Size = new System.Drawing.Size(258, 20);
            this.cdvReturnFlow.TabIndex = 9;
            this.cdvReturnFlow.VisibleColumnHeader = false;
            this.cdvReturnFlow.VisibleDescription = false;
            this.cdvReturnFlow.VisibleFlowButton = true;
            this.cdvReturnFlow.VisibleSequenceButton = true;
            this.cdvReturnFlow.WidthButton = 20;
            this.cdvReturnFlow.WidthFlowAndSequence = 181;
            this.cdvReturnFlow.WidthSequence = 50;
            this.cdvReturnFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvReturnFlow_FlowSelectedItemChanged);
            // 
            // cdvReworkOper
            // 
            this.cdvReworkOper.AddEmptyRowToLast = false;
            this.cdvReworkOper.AddEmptyRowToTop = false;
            this.cdvReworkOper.ButtonWidth = 21;
            this.cdvReworkOper.DisplaySubItemIndex = 0;
            this.cdvReworkOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkOper.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkOper.LabelText = "Rework Operation";
            this.cdvReworkOper.LabelWidth = 106;
            this.cdvReworkOper.ListCond_ExtFactory = "";
            this.cdvReworkOper.ListCond_Step = '2';
            this.cdvReworkOper.Location = new System.Drawing.Point(278, 66);
            this.cdvReworkOper.Name = "cdvReworkOper";
            this.cdvReworkOper.ReadOnly = false;
            this.cdvReworkOper.SearchSubItemIndex = 0;
            this.cdvReworkOper.SelectedDescIndex = 1;
            this.cdvReworkOper.SelectedSubItemIndex = 0;
            this.cdvReworkOper.Size = new System.Drawing.Size(212, 20);
            this.cdvReworkOper.TabIndex = 7;
            this.cdvReworkOper.TextBoxWidth = 106;
            this.cdvReworkOper.VisibleButton = true;
            this.cdvReworkOper.VisibleColumnHeader = false;
            this.cdvReworkOper.VisibleDescription = false;
            this.cdvReworkOper.ButtonPress += new System.EventHandler(this.cdvReworkOper_ButtonPress);
            // 
            // cdvReworkFlow
            // 
            this.cdvReworkFlow.AddEmptyRowToLast = false;
            this.cdvReworkFlow.AddEmptyRowToTop = false;
            this.cdvReworkFlow.DisplaySubItemIndex = 0;
            this.cdvReworkFlow.FlowReadOnly = false;
            this.cdvReworkFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkFlow.LabelText = "Rework Flow";
            this.cdvReworkFlow.LabelWidth = 77;
            this.cdvReworkFlow.ListCond_ExtFactory = "";
            this.cdvReworkFlow.ListCond_Step = '1';
            this.cdvReworkFlow.Location = new System.Drawing.Point(9, 66);
            this.cdvReworkFlow.Name = "cdvReworkFlow";
            this.cdvReworkFlow.SearchSubItemIndex = 0;
            this.cdvReworkFlow.SelectedDescIndex = -1;
            this.cdvReworkFlow.SelectedSubItemIndex = 0;
            this.cdvReworkFlow.SequenceReadOnly = false;
            this.cdvReworkFlow.Size = new System.Drawing.Size(258, 20);
            this.cdvReworkFlow.TabIndex = 6;
            this.cdvReworkFlow.VisibleColumnHeader = false;
            this.cdvReworkFlow.VisibleDescription = false;
            this.cdvReworkFlow.VisibleFlowButton = true;
            this.cdvReworkFlow.VisibleSequenceButton = true;
            this.cdvReworkFlow.WidthButton = 20;
            this.cdvReworkFlow.WidthFlowAndSequence = 181;
            this.cdvReworkFlow.WidthSequence = 50;
            this.cdvReworkFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvReworkFlow_FlowSelectedItemChanged);
            // 
            // grpAlarmAction
            // 
            this.grpAlarmAction.Controls.Add(this.chkMail);
            this.grpAlarmAction.Controls.Add(this.chkMessage);
            this.grpAlarmAction.Controls.Add(this.chkDisplay);
            this.grpAlarmAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAlarmAction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAlarmAction.Location = new System.Drawing.Point(0, 38);
            this.grpAlarmAction.Name = "grpAlarmAction";
            this.grpAlarmAction.Size = new System.Drawing.Size(498, 38);
            this.grpAlarmAction.TabIndex = 1;
            this.grpAlarmAction.TabStop = false;
            this.grpAlarmAction.Text = "Alarm Action";
            // 
            // chkMail
            // 
            this.chkMail.AutoSize = true;
            this.chkMail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMail.Location = new System.Drawing.Point(351, 16);
            this.chkMail.Name = "chkMail";
            this.chkMail.Size = new System.Drawing.Size(51, 18);
            this.chkMail.TabIndex = 2;
            this.chkMail.Text = "Mail";
            // 
            // chkMessage
            // 
            this.chkMessage.AutoSize = true;
            this.chkMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMessage.Location = new System.Drawing.Point(183, 16);
            this.chkMessage.Name = "chkMessage";
            this.chkMessage.Size = new System.Drawing.Size(75, 18);
            this.chkMessage.TabIndex = 1;
            this.chkMessage.Text = "Message";
            // 
            // chkDisplay
            // 
            this.chkDisplay.AutoSize = true;
            this.chkDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDisplay.Location = new System.Drawing.Point(15, 16);
            this.chkDisplay.Name = "chkDisplay";
            this.chkDisplay.Size = new System.Drawing.Size(66, 18);
            this.chkDisplay.TabIndex = 0;
            this.chkDisplay.Text = "Display";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.rbnWarning);
            this.grpInfo.Controls.Add(this.rbnError);
            this.grpInfo.Controls.Add(this.rbnInformation);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(498, 38);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Alarm Level";
            // 
            // rbnWarning
            // 
            this.rbnWarning.AutoSize = true;
            this.rbnWarning.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnWarning.Location = new System.Drawing.Point(183, 16);
            this.rbnWarning.Name = "rbnWarning";
            this.rbnWarning.Size = new System.Drawing.Size(71, 18);
            this.rbnWarning.TabIndex = 1;
            this.rbnWarning.TabStop = true;
            this.rbnWarning.Text = "Warning";
            // 
            // rbnError
            // 
            this.rbnError.AutoSize = true;
            this.rbnError.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnError.Location = new System.Drawing.Point(351, 16);
            this.rbnError.Name = "rbnError";
            this.rbnError.Size = new System.Drawing.Size(53, 18);
            this.rbnError.TabIndex = 2;
            this.rbnError.TabStop = true;
            this.rbnError.Text = "Error";
            // 
            // rbnInformation
            // 
            this.rbnInformation.AutoSize = true;
            this.rbnInformation.Checked = true;
            this.rbnInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnInformation.Location = new System.Drawing.Point(15, 16);
            this.rbnInformation.Name = "rbnInformation";
            this.rbnInformation.Size = new System.Drawing.Size(83, 18);
            this.rbnInformation.TabIndex = 0;
            this.rbnInformation.TabStop = true;
            this.rbnInformation.Text = "Information";
            // 
            // tbpRecvInfo
            // 
            this.tbpRecvInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tbpRecvInfo.Controls.Add(this.pnlRecvInfo);
            this.tbpRecvInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpRecvInfo.Name = "tbpRecvInfo";
            this.tbpRecvInfo.Size = new System.Drawing.Size(498, 420);
            this.tbpRecvInfo.TabIndex = 6;
            this.tbpRecvInfo.Text = "Receive Information";
            // 
            // pnlRecvInfo
            // 
            this.pnlRecvInfo.Controls.Add(this.grpReceive);
            this.pnlRecvInfo.Controls.Add(this.grpLotAlarm);
            this.pnlRecvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecvInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlRecvInfo.Name = "pnlRecvInfo";
            this.pnlRecvInfo.Size = new System.Drawing.Size(498, 420);
            this.pnlRecvInfo.TabIndex = 0;
            // 
            // grpReceive
            // 
            this.grpReceive.Controls.Add(this.panel1);
            this.grpReceive.Controls.Add(this.pnlRecMid);
            this.grpReceive.Controls.Add(this.panel3);
            this.grpReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReceive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpReceive.Location = new System.Drawing.Point(0, 40);
            this.grpReceive.Name = "grpReceive";
            this.grpReceive.Size = new System.Drawing.Size(498, 380);
            this.grpReceive.TabIndex = 6;
            this.grpReceive.TabStop = false;
            this.grpReceive.Text = "Receive Information";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lisRecvList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 361);
            this.panel1.TabIndex = 0;
            // 
            // lisRecvList
            // 
            this.lisRecvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lisRecvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRecvList.EnableSort = true;
            this.lisRecvList.EnableSortIcon = true;
            this.lisRecvList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRecvList.FullRowSelect = true;
            this.lisRecvList.Location = new System.Drawing.Point(0, 0);
            this.lisRecvList.Name = "lisRecvList";
            this.lisRecvList.Size = new System.Drawing.Size(193, 361);
            this.lisRecvList.TabIndex = 0;
            this.lisRecvList.UseCompatibleStateImageBehavior = false;
            this.lisRecvList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Receiver";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Shift";
            // 
            // pnlRecMid
            // 
            this.pnlRecMid.Controls.Add(this.btnDetach);
            this.pnlRecMid.Controls.Add(this.btnAttach);
            this.pnlRecMid.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRecMid.Location = new System.Drawing.Point(196, 16);
            this.pnlRecMid.Name = "pnlRecMid";
            this.pnlRecMid.Size = new System.Drawing.Size(31, 361);
            this.pnlRecMid.TabIndex = 0;
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetach.Location = new System.Drawing.Point(3, 183);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 1;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(3, 154);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 0;
            this.btnAttach.Text = "< ";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lisPrvGrpList);
            this.panel3.Controls.Add(this.lisUserList);
            this.panel3.Controls.Add(this.lisSecGrpList);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(227, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 361);
            this.panel3.TabIndex = 0;
            // 
            // lisPrvGrpList
            // 
            this.lisPrvGrpList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lisPrvGrpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisPrvGrpList.EnableSort = true;
            this.lisPrvGrpList.EnableSortIcon = true;
            this.lisPrvGrpList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisPrvGrpList.FullRowSelect = true;
            this.lisPrvGrpList.Location = new System.Drawing.Point(0, 42);
            this.lisPrvGrpList.Name = "lisPrvGrpList";
            this.lisPrvGrpList.Size = new System.Drawing.Size(268, 319);
            this.lisPrvGrpList.TabIndex = 1;
            this.lisPrvGrpList.UseCompatibleStateImageBehavior = false;
            this.lisPrvGrpList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Privilege Group";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            this.columnHeader5.Width = 150;
            // 
            // lisUserList
            // 
            this.lisUserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.lisUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisUserList.EnableSort = true;
            this.lisUserList.EnableSortIcon = true;
            this.lisUserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisUserList.FullRowSelect = true;
            this.lisUserList.Location = new System.Drawing.Point(0, 42);
            this.lisUserList.Name = "lisUserList";
            this.lisUserList.Size = new System.Drawing.Size(268, 319);
            this.lisUserList.TabIndex = 2;
            this.lisUserList.UseCompatibleStateImageBehavior = false;
            this.lisUserList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "User ID";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Description";
            this.columnHeader7.Width = 150;
            // 
            // lisSecGrpList
            // 
            this.lisSecGrpList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.lisSecGrpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSecGrpList.EnableSort = true;
            this.lisSecGrpList.EnableSortIcon = true;
            this.lisSecGrpList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSecGrpList.FullRowSelect = true;
            this.lisSecGrpList.Location = new System.Drawing.Point(0, 42);
            this.lisSecGrpList.Name = "lisSecGrpList";
            this.lisSecGrpList.Size = new System.Drawing.Size(268, 319);
            this.lisSecGrpList.TabIndex = 1;
            this.lisSecGrpList.UseCompatibleStateImageBehavior = false;
            this.lisSecGrpList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Security Group";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Description";
            this.columnHeader9.Width = 150;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkShift4);
            this.panel4.Controls.Add(this.chkShift3);
            this.panel4.Controls.Add(this.chkShift2);
            this.panel4.Controls.Add(this.chkShift1);
            this.panel4.Controls.Add(this.rbnPrvGroup);
            this.panel4.Controls.Add(this.rbnSecGroup);
            this.panel4.Controls.Add(this.rbnUser);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(268, 42);
            this.panel4.TabIndex = 0;
            // 
            // chkShift4
            // 
            this.chkShift4.AutoSize = true;
            this.chkShift4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShift4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShift4.Location = new System.Drawing.Point(217, 23);
            this.chkShift4.Name = "chkShift4";
            this.chkShift4.Size = new System.Drawing.Size(38, 18);
            this.chkShift4.TabIndex = 6;
            this.chkShift4.Text = "4";
            this.chkShift4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShift3
            // 
            this.chkShift3.AutoSize = true;
            this.chkShift3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShift3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShift3.Location = new System.Drawing.Point(177, 23);
            this.chkShift3.Name = "chkShift3";
            this.chkShift3.Size = new System.Drawing.Size(38, 18);
            this.chkShift3.TabIndex = 5;
            this.chkShift3.Text = "3";
            this.chkShift3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShift2
            // 
            this.chkShift2.AutoSize = true;
            this.chkShift2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShift2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShift2.Location = new System.Drawing.Point(134, 23);
            this.chkShift2.Name = "chkShift2";
            this.chkShift2.Size = new System.Drawing.Size(38, 18);
            this.chkShift2.TabIndex = 4;
            this.chkShift2.Text = "2";
            this.chkShift2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShift1
            // 
            this.chkShift1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShift1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShift1.Location = new System.Drawing.Point(7, 24);
            this.chkShift1.Name = "chkShift1";
            this.chkShift1.Size = new System.Drawing.Size(123, 16);
            this.chkShift1.TabIndex = 3;
            this.chkShift1.Text = "Occured Alarm Shift 1";
            this.chkShift1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbnPrvGroup
            // 
            this.rbnPrvGroup.AutoSize = true;
            this.rbnPrvGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnPrvGroup.Location = new System.Drawing.Point(162, 2);
            this.rbnPrvGroup.Name = "rbnPrvGroup";
            this.rbnPrvGroup.Size = new System.Drawing.Size(103, 18);
            this.rbnPrvGroup.TabIndex = 2;
            this.rbnPrvGroup.TabStop = true;
            this.rbnPrvGroup.Text = "Privilege Group";
            this.rbnPrvGroup.CheckedChanged += new System.EventHandler(this.rbnReceiver_CheckedChanged);
            // 
            // rbnSecGroup
            // 
            this.rbnSecGroup.AutoSize = true;
            this.rbnSecGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnSecGroup.Location = new System.Drawing.Point(59, 2);
            this.rbnSecGroup.Name = "rbnSecGroup";
            this.rbnSecGroup.Size = new System.Drawing.Size(101, 18);
            this.rbnSecGroup.TabIndex = 1;
            this.rbnSecGroup.TabStop = true;
            this.rbnSecGroup.Text = "Security Group";
            this.rbnSecGroup.CheckedChanged += new System.EventHandler(this.rbnReceiver_CheckedChanged);
            // 
            // rbnUser
            // 
            this.rbnUser.AutoSize = true;
            this.rbnUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnUser.Location = new System.Drawing.Point(4, 2);
            this.rbnUser.Name = "rbnUser";
            this.rbnUser.Size = new System.Drawing.Size(53, 18);
            this.rbnUser.TabIndex = 0;
            this.rbnUser.TabStop = true;
            this.rbnUser.Text = "User";
            this.rbnUser.CheckedChanged += new System.EventHandler(this.rbnReceiver_CheckedChanged);
            // 
            // grpLotAlarm
            // 
            this.grpLotAlarm.Controls.Add(this.chkSendToUser);
            this.grpLotAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotAlarm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotAlarm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpLotAlarm.Location = new System.Drawing.Point(0, 0);
            this.grpLotAlarm.Name = "grpLotAlarm";
            this.grpLotAlarm.Size = new System.Drawing.Size(498, 40);
            this.grpLotAlarm.TabIndex = 0;
            this.grpLotAlarm.TabStop = false;
            this.grpLotAlarm.Text = "Send Information";
            // 
            // chkSendToUser
            // 
            this.chkSendToUser.AutoSize = true;
            this.chkSendToUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSendToUser.Location = new System.Drawing.Point(15, 16);
            this.chkSendToUser.Name = "chkSendToUser";
            this.chkSendToUser.Size = new System.Drawing.Size(159, 18);
            this.chkSendToUser.TabIndex = 0;
            this.chkSendToUser.Text = "Send To Occur Alarm User";
            // 
            // tbpMessage
            // 
            this.tbpMessage.BackColor = System.Drawing.Color.Transparent;
            this.tbpMessage.Controls.Add(this.grpMsgData);
            this.tbpMessage.Location = new System.Drawing.Point(4, 22);
            this.tbpMessage.Name = "tbpMessage";
            this.tbpMessage.Size = new System.Drawing.Size(498, 420);
            this.tbpMessage.TabIndex = 3;
            this.tbpMessage.Text = "Message";
            this.tbpMessage.Visible = false;
            // 
            // grpMsgData
            // 
            this.grpMsgData.AutoSize = true;
            this.grpMsgData.Controls.Add(this.txtSubject);
            this.grpMsgData.Controls.Add(this.lblSubject);
            this.grpMsgData.Controls.Add(this.txtMsg3);
            this.grpMsgData.Controls.Add(this.txtMsg2);
            this.grpMsgData.Controls.Add(this.txtMsg1);
            this.grpMsgData.Controls.Add(this.lblMsg_3);
            this.grpMsgData.Controls.Add(this.lblMsg_2);
            this.grpMsgData.Controls.Add(this.lblMsg_1);
            this.grpMsgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMsgData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMsgData.Location = new System.Drawing.Point(0, 0);
            this.grpMsgData.Name = "grpMsgData";
            this.grpMsgData.Size = new System.Drawing.Size(498, 420);
            this.grpMsgData.TabIndex = 0;
            this.grpMsgData.TabStop = false;
            this.grpMsgData.Text = "Message Data";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(120, 15);
            this.txtSubject.MaxLength = 200;
            this.txtSubject.Multiline = true;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(364, 47);
            this.txtSubject.TabIndex = 1;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(15, 31);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 0;
            this.lblSubject.Text = "Subject";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMsg3
            // 
            this.txtMsg3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg3.Location = new System.Drawing.Point(120, 300);
            this.txtMsg3.MaxLength = 1000;
            this.txtMsg3.Multiline = true;
            this.txtMsg3.Name = "txtMsg3";
            this.txtMsg3.Size = new System.Drawing.Size(364, 110);
            this.txtMsg3.TabIndex = 7;
            // 
            // txtMsg2
            // 
            this.txtMsg2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg2.Location = new System.Drawing.Point(120, 184);
            this.txtMsg2.MaxLength = 1000;
            this.txtMsg2.Multiline = true;
            this.txtMsg2.Name = "txtMsg2";
            this.txtMsg2.Size = new System.Drawing.Size(364, 110);
            this.txtMsg2.TabIndex = 5;
            // 
            // txtMsg1
            // 
            this.txtMsg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg1.Location = new System.Drawing.Point(120, 68);
            this.txtMsg1.MaxLength = 1000;
            this.txtMsg1.Multiline = true;
            this.txtMsg1.Name = "txtMsg1";
            this.txtMsg1.Size = new System.Drawing.Size(364, 110);
            this.txtMsg1.TabIndex = 3;
            // 
            // lblMsg_3
            // 
            this.lblMsg_3.AutoSize = true;
            this.lblMsg_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsg_3.Location = new System.Drawing.Point(15, 348);
            this.lblMsg_3.Name = "lblMsg_3";
            this.lblMsg_3.Size = new System.Drawing.Size(59, 13);
            this.lblMsg_3.TabIndex = 6;
            this.lblMsg_3.Text = "Message 3";
            this.lblMsg_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMsg_2
            // 
            this.lblMsg_2.AutoSize = true;
            this.lblMsg_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsg_2.Location = new System.Drawing.Point(15, 232);
            this.lblMsg_2.Name = "lblMsg_2";
            this.lblMsg_2.Size = new System.Drawing.Size(59, 13);
            this.lblMsg_2.TabIndex = 4;
            this.lblMsg_2.Text = "Message 2";
            this.lblMsg_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMsg_1
            // 
            this.lblMsg_1.AutoSize = true;
            this.lblMsg_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsg_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg_1.Location = new System.Drawing.Point(15, 116);
            this.lblMsg_1.Name = "lblMsg_1";
            this.lblMsg_1.Size = new System.Drawing.Size(59, 13);
            this.lblMsg_1.TabIndex = 2;
            this.lblMsg_1.Text = "Message 1";
            this.lblMsg_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpComment
            // 
            this.tbpComment.BackColor = System.Drawing.SystemColors.Control;
            this.tbpComment.Controls.Add(this.spdComment);
            this.tbpComment.Location = new System.Drawing.Point(4, 22);
            this.tbpComment.Name = "tbpComment";
            this.tbpComment.Size = new System.Drawing.Size(498, 420);
            this.tbpComment.TabIndex = 7;
            this.tbpComment.Text = "Comment";
            this.tbpComment.Resize += new System.EventHandler(this.tbpComment_Resize);
            // 
            // spdComment
            // 
            this.spdComment.AccessibleDescription = "spdComment, Sheet1, Row 0, Column 0, ";
            this.spdComment.BackColor = System.Drawing.SystemColors.Control;
            this.spdComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdComment.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdComment.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdComment.HorizontalScrollBar.Name = "";
            this.spdComment.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdComment.HorizontalScrollBar.TabIndex = 62;
            this.spdComment.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdComment.Location = new System.Drawing.Point(0, 0);
            this.spdComment.Name = "spdComment";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer4;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer4;
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
            this.spdComment.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdComment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdComment.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdComment_Sheet1});
            this.spdComment.Size = new System.Drawing.Size(498, 420);
            this.spdComment.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdComment.TabIndex = 0;
            this.spdComment.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdComment.VerticalScrollBar.Name = "";
            this.spdComment.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdComment.VerticalScrollBar.TabIndex = 63;
            this.spdComment.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdComment_Sheet1
            // 
            this.spdComment_Sheet1.Reset();
            spdComment_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdComment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdComment_Sheet1.ColumnCount = 1;
            spdComment_Sheet1.RowCount = 5;
            this.spdComment_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdComment_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdComment_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdComment_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdComment_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Contents";
            this.spdComment_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdComment_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            textCellType1.MaxLength = 1000;
            textCellType1.Multiline = true;
            textCellType1.WordWrap = true;
            this.spdComment_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdComment_Sheet1.Columns.Get(0).Label = "Contents";
            this.spdComment_Sheet1.Columns.Get(0).Width = 414F;
            this.spdComment_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdComment_Sheet1.RowHeader.Cells.Get(0, 0).Value = "Comment 1";
            this.spdComment_Sheet1.RowHeader.Cells.Get(1, 0).Value = "Comment 2";
            this.spdComment_Sheet1.RowHeader.Cells.Get(2, 0).Value = "Comment 3";
            this.spdComment_Sheet1.RowHeader.Cells.Get(3, 0).Value = "Comment 4";
            this.spdComment_Sheet1.RowHeader.Cells.Get(4, 0).Value = "Comment 5";
            this.spdComment_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdComment_Sheet1.RowHeader.Columns.Get(0).Width = 80F;
            this.spdComment_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdComment_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdComment_Sheet1.Rows.Get(0).Height = 78F;
            this.spdComment_Sheet1.Rows.Get(0).Label = "Comment 1";
            this.spdComment_Sheet1.Rows.Get(1).Height = 78F;
            this.spdComment_Sheet1.Rows.Get(1).Label = "Comment 2";
            this.spdComment_Sheet1.Rows.Get(2).Height = 78F;
            this.spdComment_Sheet1.Rows.Get(2).Label = "Comment 3";
            this.spdComment_Sheet1.Rows.Get(3).Height = 78F;
            this.spdComment_Sheet1.Rows.Get(3).Label = "Comment 4";
            this.spdComment_Sheet1.Rows.Get(4).Height = 78F;
            this.spdComment_Sheet1.Rows.Get(4).Label = "Comment 5";
            this.spdComment_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdComment_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdComment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpPDF
            // 
            this.tbpPDF.BackColor = System.Drawing.SystemColors.Control;
            this.tbpPDF.Controls.Add(this.pnlPDF);
            this.tbpPDF.Controls.Add(this.pnlPDFBottom);
            this.tbpPDF.Location = new System.Drawing.Point(4, 22);
            this.tbpPDF.Name = "tbpPDF";
            this.tbpPDF.Size = new System.Drawing.Size(498, 420);
            this.tbpPDF.TabIndex = 8;
            this.tbpPDF.Text = "PDF";
            // 
            // pnlPDF
            // 
            this.pnlPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPDF.Location = new System.Drawing.Point(0, 0);
            this.pnlPDF.Name = "pnlPDF";
            this.pnlPDF.Size = new System.Drawing.Size(498, 390);
            this.pnlPDF.TabIndex = 0;
            // 
            // pnlPDFBottom
            // 
            this.pnlPDFBottom.Controls.Add(this.btnPDFRemove);
            this.pnlPDFBottom.Controls.Add(this.btnPDFOpen);
            this.pnlPDFBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPDFBottom.Location = new System.Drawing.Point(0, 390);
            this.pnlPDFBottom.Name = "pnlPDFBottom";
            this.pnlPDFBottom.Size = new System.Drawing.Size(498, 30);
            this.pnlPDFBottom.TabIndex = 1;
            // 
            // btnPDFRemove
            // 
            this.btnPDFRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPDFRemove.Location = new System.Drawing.Point(94, 2);
            this.btnPDFRemove.Name = "btnPDFRemove";
            this.btnPDFRemove.Size = new System.Drawing.Size(88, 26);
            this.btnPDFRemove.TabIndex = 1;
            this.btnPDFRemove.Text = "Remove";
            this.btnPDFRemove.UseVisualStyleBackColor = true;
            // 
            // btnPDFOpen
            // 
            this.btnPDFOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPDFOpen.Location = new System.Drawing.Point(3, 2);
            this.btnPDFOpen.Name = "btnPDFOpen";
            this.btnPDFOpen.Size = new System.Drawing.Size(88, 26);
            this.btnPDFOpen.TabIndex = 0;
            this.btnPDFOpen.Text = "File Open";
            this.btnPDFOpen.UseVisualStyleBackColor = true;
            // 
            // tbpImage
            // 
            this.tbpImage.BackColor = System.Drawing.SystemColors.Control;
            this.tbpImage.Controls.Add(this.grpImage);
            this.tbpImage.Controls.Add(this.pnlImgBottom);
            this.tbpImage.Location = new System.Drawing.Point(4, 22);
            this.tbpImage.Name = "tbpImage";
            this.tbpImage.Size = new System.Drawing.Size(498, 420);
            this.tbpImage.TabIndex = 9;
            this.tbpImage.Text = "Image";
            // 
            // grpImage
            // 
            this.grpImage.Controls.Add(this.picImage);
            this.grpImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpImage.Location = new System.Drawing.Point(0, 0);
            this.grpImage.Name = "grpImage";
            this.grpImage.Size = new System.Drawing.Size(498, 390);
            this.grpImage.TabIndex = 0;
            this.grpImage.TabStop = false;
            this.grpImage.Text = "Display Image";
            // 
            // picImage
            // 
            this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImage.Location = new System.Drawing.Point(3, 16);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(492, 371);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            // 
            // pnlImgBottom
            // 
            this.pnlImgBottom.Controls.Add(this.btnImgRemove);
            this.pnlImgBottom.Controls.Add(this.btnImgOpen);
            this.pnlImgBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlImgBottom.Location = new System.Drawing.Point(0, 390);
            this.pnlImgBottom.Name = "pnlImgBottom";
            this.pnlImgBottom.Size = new System.Drawing.Size(498, 30);
            this.pnlImgBottom.TabIndex = 1;
            // 
            // btnImgRemove
            // 
            this.btnImgRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImgRemove.Location = new System.Drawing.Point(94, 2);
            this.btnImgRemove.Name = "btnImgRemove";
            this.btnImgRemove.Size = new System.Drawing.Size(88, 26);
            this.btnImgRemove.TabIndex = 1;
            this.btnImgRemove.Text = "Remove";
            this.btnImgRemove.UseVisualStyleBackColor = true;
            this.btnImgRemove.Click += new System.EventHandler(this.btnImgRemove_Click);
            // 
            // btnImgOpen
            // 
            this.btnImgOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImgOpen.Location = new System.Drawing.Point(3, 2);
            this.btnImgOpen.Name = "btnImgOpen";
            this.btnImgOpen.Size = new System.Drawing.Size(88, 26);
            this.btnImgOpen.TabIndex = 0;
            this.btnImgOpen.Text = "File Open";
            this.btnImgOpen.UseVisualStyleBackColor = true;
            this.btnImgOpen.Click += new System.EventHandler(this.btnImgOpen_Click);
            // 
            // tbpEvent
            // 
            this.tbpEvent.BackColor = System.Drawing.SystemColors.Control;
            this.tbpEvent.Controls.Add(this.grpStatus);
            this.tbpEvent.Controls.Add(this.grpResComment);
            this.tbpEvent.Controls.Add(this.grpEvent);
            this.tbpEvent.Location = new System.Drawing.Point(4, 22);
            this.tbpEvent.Name = "tbpEvent";
            this.tbpEvent.Size = new System.Drawing.Size(498, 420);
            this.tbpEvent.TabIndex = 4;
            this.tbpEvent.Text = "Event";
            this.tbpEvent.Visible = false;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.cdvChangeStatus10);
            this.grpStatus.Controls.Add(this.cdvChangeStatus9);
            this.grpStatus.Controls.Add(this.cdvChangeStatus8);
            this.grpStatus.Controls.Add(this.cdvChangeStatus7);
            this.grpStatus.Controls.Add(this.cdvChangeStatus6);
            this.grpStatus.Controls.Add(this.cdvChangeStatus5);
            this.grpStatus.Controls.Add(this.cdvChangeStatus4);
            this.grpStatus.Controls.Add(this.cdvChangeStatus3);
            this.grpStatus.Controls.Add(this.cdvChangeStatus2);
            this.grpStatus.Controls.Add(this.cdvChangeStatus1);
            this.grpStatus.Controls.Add(this.lblChgStatus3);
            this.grpStatus.Controls.Add(this.lblChgStatus2);
            this.grpStatus.Controls.Add(this.lblChgStatus8);
            this.grpStatus.Controls.Add(this.lblChgStatus7);
            this.grpStatus.Controls.Add(this.lblChgStatus4);
            this.grpStatus.Controls.Add(this.lblChgStatus6);
            this.grpStatus.Controls.Add(this.lblChgStatus5);
            this.grpStatus.Controls.Add(this.lblChgStatus1);
            this.grpStatus.Controls.Add(this.lblChgStatus10);
            this.grpStatus.Controls.Add(this.lblChgStatus9);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpStatus.Location = new System.Drawing.Point(0, 48);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(498, 324);
            this.grpStatus.TabIndex = 1;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // cdvChangeStatus10
            // 
            this.cdvChangeStatus10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus10.BtnToolTipText = "";
            this.cdvChangeStatus10.DescText = "";
            this.cdvChangeStatus10.DisplaySubItemIndex = -1;
            this.cdvChangeStatus10.DisplayText = "";
            this.cdvChangeStatus10.Focusing = null;
            this.cdvChangeStatus10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus10.Index = 0;
            this.cdvChangeStatus10.IsViewBtnImage = false;
            this.cdvChangeStatus10.Location = new System.Drawing.Point(143, 232);
            this.cdvChangeStatus10.MaxLength = 32767;
            this.cdvChangeStatus10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus10.Name = "cdvChangeStatus10";
            this.cdvChangeStatus10.ReadOnly = false;
            this.cdvChangeStatus10.SearchSubItemIndex = 0;
            this.cdvChangeStatus10.SelectedDescIndex = -1;
            this.cdvChangeStatus10.SelectedSubItemIndex = -1;
            this.cdvChangeStatus10.SelectionStart = 0;
            this.cdvChangeStatus10.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus10.SmallImageList = null;
            this.cdvChangeStatus10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus10.TabIndex = 19;
            this.cdvChangeStatus10.TextBoxToolTipText = "";
            this.cdvChangeStatus10.TextBoxWidth = 176;
            this.cdvChangeStatus10.VisibleButton = true;
            this.cdvChangeStatus10.VisibleColumnHeader = false;
            this.cdvChangeStatus10.VisibleDescription = false;
            this.cdvChangeStatus10.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvChangeStatus9
            // 
            this.cdvChangeStatus9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus9.BtnToolTipText = "";
            this.cdvChangeStatus9.DescText = "";
            this.cdvChangeStatus9.DisplaySubItemIndex = -1;
            this.cdvChangeStatus9.DisplayText = "";
            this.cdvChangeStatus9.Focusing = null;
            this.cdvChangeStatus9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus9.Index = 0;
            this.cdvChangeStatus9.IsViewBtnImage = false;
            this.cdvChangeStatus9.Location = new System.Drawing.Point(143, 208);
            this.cdvChangeStatus9.MaxLength = 32767;
            this.cdvChangeStatus9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus9.Name = "cdvChangeStatus9";
            this.cdvChangeStatus9.ReadOnly = false;
            this.cdvChangeStatus9.SearchSubItemIndex = 0;
            this.cdvChangeStatus9.SelectedDescIndex = -1;
            this.cdvChangeStatus9.SelectedSubItemIndex = -1;
            this.cdvChangeStatus9.SelectionStart = 0;
            this.cdvChangeStatus9.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus9.SmallImageList = null;
            this.cdvChangeStatus9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus9.TabIndex = 17;
            this.cdvChangeStatus9.TextBoxToolTipText = "";
            this.cdvChangeStatus9.TextBoxWidth = 176;
            this.cdvChangeStatus9.VisibleButton = true;
            this.cdvChangeStatus9.VisibleColumnHeader = false;
            this.cdvChangeStatus9.VisibleDescription = false;
            this.cdvChangeStatus9.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvChangeStatus8
            // 
            this.cdvChangeStatus8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus8.BtnToolTipText = "";
            this.cdvChangeStatus8.DescText = "";
            this.cdvChangeStatus8.DisplaySubItemIndex = -1;
            this.cdvChangeStatus8.DisplayText = "";
            this.cdvChangeStatus8.Focusing = null;
            this.cdvChangeStatus8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus8.Index = 0;
            this.cdvChangeStatus8.IsViewBtnImage = false;
            this.cdvChangeStatus8.Location = new System.Drawing.Point(143, 184);
            this.cdvChangeStatus8.MaxLength = 32767;
            this.cdvChangeStatus8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus8.Name = "cdvChangeStatus8";
            this.cdvChangeStatus8.ReadOnly = false;
            this.cdvChangeStatus8.SearchSubItemIndex = 0;
            this.cdvChangeStatus8.SelectedDescIndex = -1;
            this.cdvChangeStatus8.SelectedSubItemIndex = -1;
            this.cdvChangeStatus8.SelectionStart = 0;
            this.cdvChangeStatus8.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus8.SmallImageList = null;
            this.cdvChangeStatus8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus8.TabIndex = 15;
            this.cdvChangeStatus8.TextBoxToolTipText = "";
            this.cdvChangeStatus8.TextBoxWidth = 176;
            this.cdvChangeStatus8.VisibleButton = true;
            this.cdvChangeStatus8.VisibleColumnHeader = false;
            this.cdvChangeStatus8.VisibleDescription = false;
            this.cdvChangeStatus8.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvChangeStatus7
            // 
            this.cdvChangeStatus7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus7.BtnToolTipText = "";
            this.cdvChangeStatus7.DescText = "";
            this.cdvChangeStatus7.DisplaySubItemIndex = -1;
            this.cdvChangeStatus7.DisplayText = "";
            this.cdvChangeStatus7.Focusing = null;
            this.cdvChangeStatus7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus7.Index = 0;
            this.cdvChangeStatus7.IsViewBtnImage = false;
            this.cdvChangeStatus7.Location = new System.Drawing.Point(143, 160);
            this.cdvChangeStatus7.MaxLength = 32767;
            this.cdvChangeStatus7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus7.Name = "cdvChangeStatus7";
            this.cdvChangeStatus7.ReadOnly = false;
            this.cdvChangeStatus7.SearchSubItemIndex = 0;
            this.cdvChangeStatus7.SelectedDescIndex = -1;
            this.cdvChangeStatus7.SelectedSubItemIndex = -1;
            this.cdvChangeStatus7.SelectionStart = 0;
            this.cdvChangeStatus7.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus7.SmallImageList = null;
            this.cdvChangeStatus7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus7.TabIndex = 13;
            this.cdvChangeStatus7.TextBoxToolTipText = "";
            this.cdvChangeStatus7.TextBoxWidth = 176;
            this.cdvChangeStatus7.VisibleButton = true;
            this.cdvChangeStatus7.VisibleColumnHeader = false;
            this.cdvChangeStatus7.VisibleDescription = false;
            this.cdvChangeStatus7.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvChangeStatus6
            // 
            this.cdvChangeStatus6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus6.BtnToolTipText = "";
            this.cdvChangeStatus6.DescText = "";
            this.cdvChangeStatus6.DisplaySubItemIndex = -1;
            this.cdvChangeStatus6.DisplayText = "";
            this.cdvChangeStatus6.Focusing = null;
            this.cdvChangeStatus6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus6.Index = 0;
            this.cdvChangeStatus6.IsViewBtnImage = false;
            this.cdvChangeStatus6.Location = new System.Drawing.Point(143, 136);
            this.cdvChangeStatus6.MaxLength = 32767;
            this.cdvChangeStatus6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus6.Name = "cdvChangeStatus6";
            this.cdvChangeStatus6.ReadOnly = false;
            this.cdvChangeStatus6.SearchSubItemIndex = 0;
            this.cdvChangeStatus6.SelectedDescIndex = -1;
            this.cdvChangeStatus6.SelectedSubItemIndex = -1;
            this.cdvChangeStatus6.SelectionStart = 0;
            this.cdvChangeStatus6.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus6.SmallImageList = null;
            this.cdvChangeStatus6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus6.TabIndex = 11;
            this.cdvChangeStatus6.TextBoxToolTipText = "";
            this.cdvChangeStatus6.TextBoxWidth = 176;
            this.cdvChangeStatus6.VisibleButton = true;
            this.cdvChangeStatus6.VisibleColumnHeader = false;
            this.cdvChangeStatus6.VisibleDescription = false;
            this.cdvChangeStatus6.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvChangeStatus5
            // 
            this.cdvChangeStatus5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus5.BtnToolTipText = "";
            this.cdvChangeStatus5.DescText = "";
            this.cdvChangeStatus5.DisplaySubItemIndex = -1;
            this.cdvChangeStatus5.DisplayText = "";
            this.cdvChangeStatus5.Focusing = null;
            this.cdvChangeStatus5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus5.Index = 0;
            this.cdvChangeStatus5.IsViewBtnImage = false;
            this.cdvChangeStatus5.Location = new System.Drawing.Point(143, 112);
            this.cdvChangeStatus5.MaxLength = 32767;
            this.cdvChangeStatus5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus5.Name = "cdvChangeStatus5";
            this.cdvChangeStatus5.ReadOnly = false;
            this.cdvChangeStatus5.SearchSubItemIndex = 0;
            this.cdvChangeStatus5.SelectedDescIndex = -1;
            this.cdvChangeStatus5.SelectedSubItemIndex = -1;
            this.cdvChangeStatus5.SelectionStart = 0;
            this.cdvChangeStatus5.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus5.SmallImageList = null;
            this.cdvChangeStatus5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus5.TabIndex = 9;
            this.cdvChangeStatus5.TextBoxToolTipText = "";
            this.cdvChangeStatus5.TextBoxWidth = 176;
            this.cdvChangeStatus5.VisibleButton = true;
            this.cdvChangeStatus5.VisibleColumnHeader = false;
            this.cdvChangeStatus5.VisibleDescription = false;
            this.cdvChangeStatus5.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvChangeStatus4
            // 
            this.cdvChangeStatus4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus4.BtnToolTipText = "";
            this.cdvChangeStatus4.DescText = "";
            this.cdvChangeStatus4.DisplaySubItemIndex = -1;
            this.cdvChangeStatus4.DisplayText = "";
            this.cdvChangeStatus4.Focusing = null;
            this.cdvChangeStatus4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus4.Index = 0;
            this.cdvChangeStatus4.IsViewBtnImage = false;
            this.cdvChangeStatus4.Location = new System.Drawing.Point(143, 88);
            this.cdvChangeStatus4.MaxLength = 32767;
            this.cdvChangeStatus4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus4.Name = "cdvChangeStatus4";
            this.cdvChangeStatus4.ReadOnly = false;
            this.cdvChangeStatus4.SearchSubItemIndex = 0;
            this.cdvChangeStatus4.SelectedDescIndex = -1;
            this.cdvChangeStatus4.SelectedSubItemIndex = -1;
            this.cdvChangeStatus4.SelectionStart = 0;
            this.cdvChangeStatus4.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus4.SmallImageList = null;
            this.cdvChangeStatus4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus4.TabIndex = 7;
            this.cdvChangeStatus4.TextBoxToolTipText = "";
            this.cdvChangeStatus4.TextBoxWidth = 176;
            this.cdvChangeStatus4.VisibleButton = true;
            this.cdvChangeStatus4.VisibleColumnHeader = false;
            this.cdvChangeStatus4.VisibleDescription = false;
            this.cdvChangeStatus4.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvChangeStatus3
            // 
            this.cdvChangeStatus3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus3.BtnToolTipText = "";
            this.cdvChangeStatus3.DescText = "";
            this.cdvChangeStatus3.DisplaySubItemIndex = -1;
            this.cdvChangeStatus3.DisplayText = "";
            this.cdvChangeStatus3.Focusing = null;
            this.cdvChangeStatus3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus3.Index = 0;
            this.cdvChangeStatus3.IsViewBtnImage = false;
            this.cdvChangeStatus3.Location = new System.Drawing.Point(143, 64);
            this.cdvChangeStatus3.MaxLength = 32767;
            this.cdvChangeStatus3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus3.Name = "cdvChangeStatus3";
            this.cdvChangeStatus3.ReadOnly = false;
            this.cdvChangeStatus3.SearchSubItemIndex = 0;
            this.cdvChangeStatus3.SelectedDescIndex = -1;
            this.cdvChangeStatus3.SelectedSubItemIndex = -1;
            this.cdvChangeStatus3.SelectionStart = 0;
            this.cdvChangeStatus3.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus3.SmallImageList = null;
            this.cdvChangeStatus3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus3.TabIndex = 5;
            this.cdvChangeStatus3.TextBoxToolTipText = "";
            this.cdvChangeStatus3.TextBoxWidth = 176;
            this.cdvChangeStatus3.VisibleButton = true;
            this.cdvChangeStatus3.VisibleColumnHeader = false;
            this.cdvChangeStatus3.VisibleDescription = false;
            this.cdvChangeStatus3.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvChangeStatus2
            // 
            this.cdvChangeStatus2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus2.BtnToolTipText = "";
            this.cdvChangeStatus2.DescText = "";
            this.cdvChangeStatus2.DisplaySubItemIndex = -1;
            this.cdvChangeStatus2.DisplayText = "";
            this.cdvChangeStatus2.Focusing = null;
            this.cdvChangeStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus2.Index = 0;
            this.cdvChangeStatus2.IsViewBtnImage = false;
            this.cdvChangeStatus2.Location = new System.Drawing.Point(143, 40);
            this.cdvChangeStatus2.MaxLength = 32767;
            this.cdvChangeStatus2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus2.Name = "cdvChangeStatus2";
            this.cdvChangeStatus2.ReadOnly = false;
            this.cdvChangeStatus2.SearchSubItemIndex = 0;
            this.cdvChangeStatus2.SelectedDescIndex = -1;
            this.cdvChangeStatus2.SelectedSubItemIndex = -1;
            this.cdvChangeStatus2.SelectionStart = 0;
            this.cdvChangeStatus2.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus2.SmallImageList = null;
            this.cdvChangeStatus2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus2.TabIndex = 3;
            this.cdvChangeStatus2.TextBoxToolTipText = "";
            this.cdvChangeStatus2.TextBoxWidth = 176;
            this.cdvChangeStatus2.VisibleButton = true;
            this.cdvChangeStatus2.VisibleColumnHeader = false;
            this.cdvChangeStatus2.VisibleDescription = false;
            this.cdvChangeStatus2.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvChangeStatus1
            // 
            this.cdvChangeStatus1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChangeStatus1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChangeStatus1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus1.BtnToolTipText = "";
            this.cdvChangeStatus1.DescText = "";
            this.cdvChangeStatus1.DisplaySubItemIndex = -1;
            this.cdvChangeStatus1.DisplayText = "";
            this.cdvChangeStatus1.Focusing = null;
            this.cdvChangeStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus1.Index = 0;
            this.cdvChangeStatus1.IsViewBtnImage = false;
            this.cdvChangeStatus1.Location = new System.Drawing.Point(143, 16);
            this.cdvChangeStatus1.MaxLength = 32767;
            this.cdvChangeStatus1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus1.Name = "cdvChangeStatus1";
            this.cdvChangeStatus1.ReadOnly = false;
            this.cdvChangeStatus1.SearchSubItemIndex = 0;
            this.cdvChangeStatus1.SelectedDescIndex = -1;
            this.cdvChangeStatus1.SelectedSubItemIndex = -1;
            this.cdvChangeStatus1.SelectionStart = 0;
            this.cdvChangeStatus1.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus1.SmallImageList = null;
            this.cdvChangeStatus1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus1.TabIndex = 1;
            this.cdvChangeStatus1.TextBoxToolTipText = "";
            this.cdvChangeStatus1.TextBoxWidth = 176;
            this.cdvChangeStatus1.VisibleButton = true;
            this.cdvChangeStatus1.VisibleColumnHeader = false;
            this.cdvChangeStatus1.VisibleDescription = false;
            this.cdvChangeStatus1.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // lblChgStatus3
            // 
            this.lblChgStatus3.AutoSize = true;
            this.lblChgStatus3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChgStatus3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus3.Location = new System.Drawing.Point(15, 67);
            this.lblChgStatus3.Name = "lblChgStatus3";
            this.lblChgStatus3.Size = new System.Drawing.Size(86, 13);
            this.lblChgStatus3.TabIndex = 4;
            this.lblChgStatus3.Text = "Change Status 3";
            // 
            // lblChgStatus2
            // 
            this.lblChgStatus2.AutoSize = true;
            this.lblChgStatus2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChgStatus2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus2.Location = new System.Drawing.Point(15, 43);
            this.lblChgStatus2.Name = "lblChgStatus2";
            this.lblChgStatus2.Size = new System.Drawing.Size(86, 13);
            this.lblChgStatus2.TabIndex = 2;
            this.lblChgStatus2.Text = "Change Status 2";
            // 
            // lblChgStatus8
            // 
            this.lblChgStatus8.AutoSize = true;
            this.lblChgStatus8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus8.Location = new System.Drawing.Point(15, 187);
            this.lblChgStatus8.Name = "lblChgStatus8";
            this.lblChgStatus8.Size = new System.Drawing.Size(86, 13);
            this.lblChgStatus8.TabIndex = 14;
            this.lblChgStatus8.Text = "Change Status 8";
            // 
            // lblChgStatus7
            // 
            this.lblChgStatus7.AutoSize = true;
            this.lblChgStatus7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus7.Location = new System.Drawing.Point(15, 163);
            this.lblChgStatus7.Name = "lblChgStatus7";
            this.lblChgStatus7.Size = new System.Drawing.Size(86, 13);
            this.lblChgStatus7.TabIndex = 12;
            this.lblChgStatus7.Text = "Change Status 7";
            // 
            // lblChgStatus4
            // 
            this.lblChgStatus4.AutoSize = true;
            this.lblChgStatus4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChgStatus4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus4.Location = new System.Drawing.Point(15, 91);
            this.lblChgStatus4.Name = "lblChgStatus4";
            this.lblChgStatus4.Size = new System.Drawing.Size(86, 13);
            this.lblChgStatus4.TabIndex = 6;
            this.lblChgStatus4.Text = "Change Status 4";
            // 
            // lblChgStatus6
            // 
            this.lblChgStatus6.AutoSize = true;
            this.lblChgStatus6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChgStatus6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus6.Location = new System.Drawing.Point(15, 139);
            this.lblChgStatus6.Name = "lblChgStatus6";
            this.lblChgStatus6.Size = new System.Drawing.Size(86, 13);
            this.lblChgStatus6.TabIndex = 10;
            this.lblChgStatus6.Text = "Change Status 6";
            // 
            // lblChgStatus5
            // 
            this.lblChgStatus5.AutoSize = true;
            this.lblChgStatus5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChgStatus5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus5.Location = new System.Drawing.Point(15, 115);
            this.lblChgStatus5.Name = "lblChgStatus5";
            this.lblChgStatus5.Size = new System.Drawing.Size(86, 13);
            this.lblChgStatus5.TabIndex = 8;
            this.lblChgStatus5.Text = "Change Status 5";
            // 
            // lblChgStatus1
            // 
            this.lblChgStatus1.AutoSize = true;
            this.lblChgStatus1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChgStatus1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus1.Location = new System.Drawing.Point(15, 19);
            this.lblChgStatus1.Name = "lblChgStatus1";
            this.lblChgStatus1.Size = new System.Drawing.Size(86, 13);
            this.lblChgStatus1.TabIndex = 0;
            this.lblChgStatus1.Text = "Change Status 1";
            // 
            // lblChgStatus10
            // 
            this.lblChgStatus10.AutoSize = true;
            this.lblChgStatus10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus10.Location = new System.Drawing.Point(15, 235);
            this.lblChgStatus10.Name = "lblChgStatus10";
            this.lblChgStatus10.Size = new System.Drawing.Size(92, 13);
            this.lblChgStatus10.TabIndex = 18;
            this.lblChgStatus10.Text = "Change Status 10";
            // 
            // lblChgStatus9
            // 
            this.lblChgStatus9.AutoSize = true;
            this.lblChgStatus9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChgStatus9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChgStatus9.Location = new System.Drawing.Point(15, 211);
            this.lblChgStatus9.Name = "lblChgStatus9";
            this.lblChgStatus9.Size = new System.Drawing.Size(86, 13);
            this.lblChgStatus9.TabIndex = 16;
            this.lblChgStatus9.Text = "Change Status 9";
            // 
            // grpResComment
            // 
            this.grpResComment.Controls.Add(this.txtResComment);
            this.grpResComment.Controls.Add(this.lblResComment);
            this.grpResComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpResComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResComment.Location = new System.Drawing.Point(0, 372);
            this.grpResComment.Name = "grpResComment";
            this.grpResComment.Size = new System.Drawing.Size(498, 48);
            this.grpResComment.TabIndex = 2;
            this.grpResComment.TabStop = false;
            // 
            // txtResComment
            // 
            this.txtResComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResComment.Location = new System.Drawing.Point(143, 17);
            this.txtResComment.MaxLength = 400;
            this.txtResComment.Name = "txtResComment";
            this.txtResComment.Size = new System.Drawing.Size(350, 20);
            this.txtResComment.TabIndex = 1;
            // 
            // lblResComment
            // 
            this.lblResComment.AutoSize = true;
            this.lblResComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResComment.Location = new System.Drawing.Point(15, 19);
            this.lblResComment.Name = "lblResComment";
            this.lblResComment.Size = new System.Drawing.Size(100, 13);
            this.lblResComment.TabIndex = 0;
            this.lblResComment.Text = "Resource Comment";
            this.lblResComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpEvent
            // 
            this.grpEvent.Controls.Add(this.cdvEvent);
            this.grpEvent.Controls.Add(this.lblEvent);
            this.grpEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEvent.Location = new System.Drawing.Point(0, 0);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Size = new System.Drawing.Size(498, 48);
            this.grpEvent.TabIndex = 0;
            this.grpEvent.TabStop = false;
            this.grpEvent.Text = "Event";
            // 
            // cdvEvent
            // 
            this.cdvEvent.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEvent.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEvent.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEvent.BtnToolTipText = "";
            this.cdvEvent.DescText = "";
            this.cdvEvent.DisplaySubItemIndex = -1;
            this.cdvEvent.DisplayText = "";
            this.cdvEvent.Focusing = null;
            this.cdvEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEvent.Index = 0;
            this.cdvEvent.IsViewBtnImage = false;
            this.cdvEvent.Location = new System.Drawing.Point(143, 15);
            this.cdvEvent.MaxLength = 20;
            this.cdvEvent.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEvent.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEvent.Name = "cdvEvent";
            this.cdvEvent.ReadOnly = false;
            this.cdvEvent.SearchSubItemIndex = 0;
            this.cdvEvent.SelectedDescIndex = -1;
            this.cdvEvent.SelectedSubItemIndex = -1;
            this.cdvEvent.SelectionStart = 0;
            this.cdvEvent.Size = new System.Drawing.Size(176, 20);
            this.cdvEvent.SmallImageList = null;
            this.cdvEvent.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEvent.TabIndex = 1;
            this.cdvEvent.TextBoxToolTipText = "";
            this.cdvEvent.TextBoxWidth = 176;
            this.cdvEvent.VisibleButton = true;
            this.cdvEvent.VisibleColumnHeader = false;
            this.cdvEvent.VisibleDescription = false;
            this.cdvEvent.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvEvent_SelectedItemChanged);
            this.cdvEvent.ButtonPress += new System.EventHandler(this.cdvEvent_ButtonPress);
            this.cdvEvent.TextBoxTextChanged += new System.EventHandler(this.cdvEvent_TextBoxTextChanged);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(15, 19);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(35, 13);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Event";
            // 
            // tbpClearEvent
            // 
            this.tbpClearEvent.Controls.Add(this.grpClearChgStatus);
            this.tbpClearEvent.Controls.Add(this.grpClearResComment);
            this.tbpClearEvent.Controls.Add(this.grpClearEvent);
            this.tbpClearEvent.Location = new System.Drawing.Point(4, 22);
            this.tbpClearEvent.Name = "tbpClearEvent";
            this.tbpClearEvent.Size = new System.Drawing.Size(498, 420);
            this.tbpClearEvent.TabIndex = 10;
            this.tbpClearEvent.Text = "Clear Event";
            // 
            // grpClearChgStatus
            // 
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus10);
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus9);
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus8);
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus7);
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus6);
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus5);
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus4);
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus3);
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus2);
            this.grpClearChgStatus.Controls.Add(this.cdvClearChangeStatus1);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus3);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus2);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus8);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus7);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus4);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus6);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus5);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus1);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus10);
            this.grpClearChgStatus.Controls.Add(this.lblClearChgStatus9);
            this.grpClearChgStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpClearChgStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpClearChgStatus.Location = new System.Drawing.Point(0, 48);
            this.grpClearChgStatus.Name = "grpClearChgStatus";
            this.grpClearChgStatus.Size = new System.Drawing.Size(498, 324);
            this.grpClearChgStatus.TabIndex = 4;
            this.grpClearChgStatus.TabStop = false;
            this.grpClearChgStatus.Text = "Clear Status";
            // 
            // cdvClearChangeStatus10
            // 
            this.cdvClearChangeStatus10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus10.BtnToolTipText = "";
            this.cdvClearChangeStatus10.DescText = "";
            this.cdvClearChangeStatus10.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus10.DisplayText = "";
            this.cdvClearChangeStatus10.Focusing = null;
            this.cdvClearChangeStatus10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus10.Index = 0;
            this.cdvClearChangeStatus10.IsViewBtnImage = false;
            this.cdvClearChangeStatus10.Location = new System.Drawing.Point(143, 232);
            this.cdvClearChangeStatus10.MaxLength = 32767;
            this.cdvClearChangeStatus10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus10.Name = "cdvClearChangeStatus10";
            this.cdvClearChangeStatus10.ReadOnly = false;
            this.cdvClearChangeStatus10.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus10.SelectedDescIndex = -1;
            this.cdvClearChangeStatus10.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus10.SelectionStart = 0;
            this.cdvClearChangeStatus10.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus10.SmallImageList = null;
            this.cdvClearChangeStatus10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus10.TabIndex = 19;
            this.cdvClearChangeStatus10.TextBoxToolTipText = "";
            this.cdvClearChangeStatus10.TextBoxWidth = 176;
            this.cdvClearChangeStatus10.VisibleButton = true;
            this.cdvClearChangeStatus10.VisibleColumnHeader = false;
            this.cdvClearChangeStatus10.VisibleDescription = false;
            this.cdvClearChangeStatus10.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvClearChangeStatus9
            // 
            this.cdvClearChangeStatus9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus9.BtnToolTipText = "";
            this.cdvClearChangeStatus9.DescText = "";
            this.cdvClearChangeStatus9.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus9.DisplayText = "";
            this.cdvClearChangeStatus9.Focusing = null;
            this.cdvClearChangeStatus9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus9.Index = 0;
            this.cdvClearChangeStatus9.IsViewBtnImage = false;
            this.cdvClearChangeStatus9.Location = new System.Drawing.Point(143, 208);
            this.cdvClearChangeStatus9.MaxLength = 32767;
            this.cdvClearChangeStatus9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus9.Name = "cdvClearChangeStatus9";
            this.cdvClearChangeStatus9.ReadOnly = false;
            this.cdvClearChangeStatus9.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus9.SelectedDescIndex = -1;
            this.cdvClearChangeStatus9.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus9.SelectionStart = 0;
            this.cdvClearChangeStatus9.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus9.SmallImageList = null;
            this.cdvClearChangeStatus9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus9.TabIndex = 17;
            this.cdvClearChangeStatus9.TextBoxToolTipText = "";
            this.cdvClearChangeStatus9.TextBoxWidth = 176;
            this.cdvClearChangeStatus9.VisibleButton = true;
            this.cdvClearChangeStatus9.VisibleColumnHeader = false;
            this.cdvClearChangeStatus9.VisibleDescription = false;
            this.cdvClearChangeStatus9.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvClearChangeStatus8
            // 
            this.cdvClearChangeStatus8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus8.BtnToolTipText = "";
            this.cdvClearChangeStatus8.DescText = "";
            this.cdvClearChangeStatus8.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus8.DisplayText = "";
            this.cdvClearChangeStatus8.Focusing = null;
            this.cdvClearChangeStatus8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus8.Index = 0;
            this.cdvClearChangeStatus8.IsViewBtnImage = false;
            this.cdvClearChangeStatus8.Location = new System.Drawing.Point(143, 184);
            this.cdvClearChangeStatus8.MaxLength = 32767;
            this.cdvClearChangeStatus8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus8.Name = "cdvClearChangeStatus8";
            this.cdvClearChangeStatus8.ReadOnly = false;
            this.cdvClearChangeStatus8.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus8.SelectedDescIndex = -1;
            this.cdvClearChangeStatus8.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus8.SelectionStart = 0;
            this.cdvClearChangeStatus8.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus8.SmallImageList = null;
            this.cdvClearChangeStatus8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus8.TabIndex = 15;
            this.cdvClearChangeStatus8.TextBoxToolTipText = "";
            this.cdvClearChangeStatus8.TextBoxWidth = 176;
            this.cdvClearChangeStatus8.VisibleButton = true;
            this.cdvClearChangeStatus8.VisibleColumnHeader = false;
            this.cdvClearChangeStatus8.VisibleDescription = false;
            this.cdvClearChangeStatus8.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvClearChangeStatus7
            // 
            this.cdvClearChangeStatus7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus7.BtnToolTipText = "";
            this.cdvClearChangeStatus7.DescText = "";
            this.cdvClearChangeStatus7.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus7.DisplayText = "";
            this.cdvClearChangeStatus7.Focusing = null;
            this.cdvClearChangeStatus7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus7.Index = 0;
            this.cdvClearChangeStatus7.IsViewBtnImage = false;
            this.cdvClearChangeStatus7.Location = new System.Drawing.Point(143, 160);
            this.cdvClearChangeStatus7.MaxLength = 32767;
            this.cdvClearChangeStatus7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus7.Name = "cdvClearChangeStatus7";
            this.cdvClearChangeStatus7.ReadOnly = false;
            this.cdvClearChangeStatus7.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus7.SelectedDescIndex = -1;
            this.cdvClearChangeStatus7.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus7.SelectionStart = 0;
            this.cdvClearChangeStatus7.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus7.SmallImageList = null;
            this.cdvClearChangeStatus7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus7.TabIndex = 13;
            this.cdvClearChangeStatus7.TextBoxToolTipText = "";
            this.cdvClearChangeStatus7.TextBoxWidth = 176;
            this.cdvClearChangeStatus7.VisibleButton = true;
            this.cdvClearChangeStatus7.VisibleColumnHeader = false;
            this.cdvClearChangeStatus7.VisibleDescription = false;
            this.cdvClearChangeStatus7.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvClearChangeStatus6
            // 
            this.cdvClearChangeStatus6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus6.BtnToolTipText = "";
            this.cdvClearChangeStatus6.DescText = "";
            this.cdvClearChangeStatus6.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus6.DisplayText = "";
            this.cdvClearChangeStatus6.Focusing = null;
            this.cdvClearChangeStatus6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus6.Index = 0;
            this.cdvClearChangeStatus6.IsViewBtnImage = false;
            this.cdvClearChangeStatus6.Location = new System.Drawing.Point(143, 136);
            this.cdvClearChangeStatus6.MaxLength = 32767;
            this.cdvClearChangeStatus6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus6.Name = "cdvClearChangeStatus6";
            this.cdvClearChangeStatus6.ReadOnly = false;
            this.cdvClearChangeStatus6.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus6.SelectedDescIndex = -1;
            this.cdvClearChangeStatus6.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus6.SelectionStart = 0;
            this.cdvClearChangeStatus6.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus6.SmallImageList = null;
            this.cdvClearChangeStatus6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus6.TabIndex = 11;
            this.cdvClearChangeStatus6.TextBoxToolTipText = "";
            this.cdvClearChangeStatus6.TextBoxWidth = 176;
            this.cdvClearChangeStatus6.VisibleButton = true;
            this.cdvClearChangeStatus6.VisibleColumnHeader = false;
            this.cdvClearChangeStatus6.VisibleDescription = false;
            this.cdvClearChangeStatus6.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvClearChangeStatus5
            // 
            this.cdvClearChangeStatus5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus5.BtnToolTipText = "";
            this.cdvClearChangeStatus5.DescText = "";
            this.cdvClearChangeStatus5.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus5.DisplayText = "";
            this.cdvClearChangeStatus5.Focusing = null;
            this.cdvClearChangeStatus5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus5.Index = 0;
            this.cdvClearChangeStatus5.IsViewBtnImage = false;
            this.cdvClearChangeStatus5.Location = new System.Drawing.Point(143, 112);
            this.cdvClearChangeStatus5.MaxLength = 32767;
            this.cdvClearChangeStatus5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus5.Name = "cdvClearChangeStatus5";
            this.cdvClearChangeStatus5.ReadOnly = false;
            this.cdvClearChangeStatus5.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus5.SelectedDescIndex = -1;
            this.cdvClearChangeStatus5.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus5.SelectionStart = 0;
            this.cdvClearChangeStatus5.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus5.SmallImageList = null;
            this.cdvClearChangeStatus5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus5.TabIndex = 9;
            this.cdvClearChangeStatus5.TextBoxToolTipText = "";
            this.cdvClearChangeStatus5.TextBoxWidth = 176;
            this.cdvClearChangeStatus5.VisibleButton = true;
            this.cdvClearChangeStatus5.VisibleColumnHeader = false;
            this.cdvClearChangeStatus5.VisibleDescription = false;
            this.cdvClearChangeStatus5.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvClearChangeStatus4
            // 
            this.cdvClearChangeStatus4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus4.BtnToolTipText = "";
            this.cdvClearChangeStatus4.DescText = "";
            this.cdvClearChangeStatus4.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus4.DisplayText = "";
            this.cdvClearChangeStatus4.Focusing = null;
            this.cdvClearChangeStatus4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus4.Index = 0;
            this.cdvClearChangeStatus4.IsViewBtnImage = false;
            this.cdvClearChangeStatus4.Location = new System.Drawing.Point(143, 88);
            this.cdvClearChangeStatus4.MaxLength = 32767;
            this.cdvClearChangeStatus4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus4.Name = "cdvClearChangeStatus4";
            this.cdvClearChangeStatus4.ReadOnly = false;
            this.cdvClearChangeStatus4.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus4.SelectedDescIndex = -1;
            this.cdvClearChangeStatus4.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus4.SelectionStart = 0;
            this.cdvClearChangeStatus4.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus4.SmallImageList = null;
            this.cdvClearChangeStatus4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus4.TabIndex = 7;
            this.cdvClearChangeStatus4.TextBoxToolTipText = "";
            this.cdvClearChangeStatus4.TextBoxWidth = 176;
            this.cdvClearChangeStatus4.VisibleButton = true;
            this.cdvClearChangeStatus4.VisibleColumnHeader = false;
            this.cdvClearChangeStatus4.VisibleDescription = false;
            this.cdvClearChangeStatus4.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvClearChangeStatus3
            // 
            this.cdvClearChangeStatus3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus3.BtnToolTipText = "";
            this.cdvClearChangeStatus3.DescText = "";
            this.cdvClearChangeStatus3.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus3.DisplayText = "";
            this.cdvClearChangeStatus3.Focusing = null;
            this.cdvClearChangeStatus3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus3.Index = 0;
            this.cdvClearChangeStatus3.IsViewBtnImage = false;
            this.cdvClearChangeStatus3.Location = new System.Drawing.Point(143, 64);
            this.cdvClearChangeStatus3.MaxLength = 32767;
            this.cdvClearChangeStatus3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus3.Name = "cdvClearChangeStatus3";
            this.cdvClearChangeStatus3.ReadOnly = false;
            this.cdvClearChangeStatus3.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus3.SelectedDescIndex = -1;
            this.cdvClearChangeStatus3.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus3.SelectionStart = 0;
            this.cdvClearChangeStatus3.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus3.SmallImageList = null;
            this.cdvClearChangeStatus3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus3.TabIndex = 5;
            this.cdvClearChangeStatus3.TextBoxToolTipText = "";
            this.cdvClearChangeStatus3.TextBoxWidth = 176;
            this.cdvClearChangeStatus3.VisibleButton = true;
            this.cdvClearChangeStatus3.VisibleColumnHeader = false;
            this.cdvClearChangeStatus3.VisibleDescription = false;
            this.cdvClearChangeStatus3.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvClearChangeStatus2
            // 
            this.cdvClearChangeStatus2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus2.BtnToolTipText = "";
            this.cdvClearChangeStatus2.DescText = "";
            this.cdvClearChangeStatus2.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus2.DisplayText = "";
            this.cdvClearChangeStatus2.Focusing = null;
            this.cdvClearChangeStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus2.Index = 0;
            this.cdvClearChangeStatus2.IsViewBtnImage = false;
            this.cdvClearChangeStatus2.Location = new System.Drawing.Point(143, 40);
            this.cdvClearChangeStatus2.MaxLength = 32767;
            this.cdvClearChangeStatus2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus2.Name = "cdvClearChangeStatus2";
            this.cdvClearChangeStatus2.ReadOnly = false;
            this.cdvClearChangeStatus2.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus2.SelectedDescIndex = -1;
            this.cdvClearChangeStatus2.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus2.SelectionStart = 0;
            this.cdvClearChangeStatus2.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus2.SmallImageList = null;
            this.cdvClearChangeStatus2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus2.TabIndex = 3;
            this.cdvClearChangeStatus2.TextBoxToolTipText = "";
            this.cdvClearChangeStatus2.TextBoxWidth = 176;
            this.cdvClearChangeStatus2.VisibleButton = true;
            this.cdvClearChangeStatus2.VisibleColumnHeader = false;
            this.cdvClearChangeStatus2.VisibleDescription = false;
            this.cdvClearChangeStatus2.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // cdvClearChangeStatus1
            // 
            this.cdvClearChangeStatus1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearChangeStatus1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearChangeStatus1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearChangeStatus1.BtnToolTipText = "";
            this.cdvClearChangeStatus1.DescText = "";
            this.cdvClearChangeStatus1.DisplaySubItemIndex = -1;
            this.cdvClearChangeStatus1.DisplayText = "";
            this.cdvClearChangeStatus1.Focusing = null;
            this.cdvClearChangeStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearChangeStatus1.Index = 0;
            this.cdvClearChangeStatus1.IsViewBtnImage = false;
            this.cdvClearChangeStatus1.Location = new System.Drawing.Point(143, 16);
            this.cdvClearChangeStatus1.MaxLength = 32767;
            this.cdvClearChangeStatus1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearChangeStatus1.Name = "cdvClearChangeStatus1";
            this.cdvClearChangeStatus1.ReadOnly = false;
            this.cdvClearChangeStatus1.SearchSubItemIndex = 0;
            this.cdvClearChangeStatus1.SelectedDescIndex = -1;
            this.cdvClearChangeStatus1.SelectedSubItemIndex = -1;
            this.cdvClearChangeStatus1.SelectionStart = 0;
            this.cdvClearChangeStatus1.Size = new System.Drawing.Size(176, 20);
            this.cdvClearChangeStatus1.SmallImageList = null;
            this.cdvClearChangeStatus1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearChangeStatus1.TabIndex = 1;
            this.cdvClearChangeStatus1.TextBoxToolTipText = "";
            this.cdvClearChangeStatus1.TextBoxWidth = 176;
            this.cdvClearChangeStatus1.VisibleButton = true;
            this.cdvClearChangeStatus1.VisibleColumnHeader = false;
            this.cdvClearChangeStatus1.VisibleDescription = false;
            this.cdvClearChangeStatus1.ButtonPress += new System.EventHandler(this.cdvChangeStatus_ButtonPress);
            // 
            // lblClearChgStatus3
            // 
            this.lblClearChgStatus3.AutoSize = true;
            this.lblClearChgStatus3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearChgStatus3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus3.Location = new System.Drawing.Point(15, 67);
            this.lblClearChgStatus3.Name = "lblClearChgStatus3";
            this.lblClearChgStatus3.Size = new System.Drawing.Size(86, 13);
            this.lblClearChgStatus3.TabIndex = 4;
            this.lblClearChgStatus3.Text = "Change Status 3";
            // 
            // lblClearChgStatus2
            // 
            this.lblClearChgStatus2.AutoSize = true;
            this.lblClearChgStatus2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearChgStatus2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus2.Location = new System.Drawing.Point(15, 43);
            this.lblClearChgStatus2.Name = "lblClearChgStatus2";
            this.lblClearChgStatus2.Size = new System.Drawing.Size(86, 13);
            this.lblClearChgStatus2.TabIndex = 2;
            this.lblClearChgStatus2.Text = "Change Status 2";
            // 
            // lblClearChgStatus8
            // 
            this.lblClearChgStatus8.AutoSize = true;
            this.lblClearChgStatus8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus8.Location = new System.Drawing.Point(15, 187);
            this.lblClearChgStatus8.Name = "lblClearChgStatus8";
            this.lblClearChgStatus8.Size = new System.Drawing.Size(86, 13);
            this.lblClearChgStatus8.TabIndex = 14;
            this.lblClearChgStatus8.Text = "Change Status 8";
            // 
            // lblClearChgStatus7
            // 
            this.lblClearChgStatus7.AutoSize = true;
            this.lblClearChgStatus7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus7.Location = new System.Drawing.Point(15, 163);
            this.lblClearChgStatus7.Name = "lblClearChgStatus7";
            this.lblClearChgStatus7.Size = new System.Drawing.Size(86, 13);
            this.lblClearChgStatus7.TabIndex = 12;
            this.lblClearChgStatus7.Text = "Change Status 7";
            // 
            // lblClearChgStatus4
            // 
            this.lblClearChgStatus4.AutoSize = true;
            this.lblClearChgStatus4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearChgStatus4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus4.Location = new System.Drawing.Point(15, 91);
            this.lblClearChgStatus4.Name = "lblClearChgStatus4";
            this.lblClearChgStatus4.Size = new System.Drawing.Size(86, 13);
            this.lblClearChgStatus4.TabIndex = 6;
            this.lblClearChgStatus4.Text = "Change Status 4";
            // 
            // lblClearChgStatus6
            // 
            this.lblClearChgStatus6.AutoSize = true;
            this.lblClearChgStatus6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearChgStatus6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus6.Location = new System.Drawing.Point(15, 139);
            this.lblClearChgStatus6.Name = "lblClearChgStatus6";
            this.lblClearChgStatus6.Size = new System.Drawing.Size(86, 13);
            this.lblClearChgStatus6.TabIndex = 10;
            this.lblClearChgStatus6.Text = "Change Status 6";
            // 
            // lblClearChgStatus5
            // 
            this.lblClearChgStatus5.AutoSize = true;
            this.lblClearChgStatus5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearChgStatus5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus5.Location = new System.Drawing.Point(15, 115);
            this.lblClearChgStatus5.Name = "lblClearChgStatus5";
            this.lblClearChgStatus5.Size = new System.Drawing.Size(86, 13);
            this.lblClearChgStatus5.TabIndex = 8;
            this.lblClearChgStatus5.Text = "Change Status 5";
            // 
            // lblClearChgStatus1
            // 
            this.lblClearChgStatus1.AutoSize = true;
            this.lblClearChgStatus1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearChgStatus1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus1.Location = new System.Drawing.Point(15, 19);
            this.lblClearChgStatus1.Name = "lblClearChgStatus1";
            this.lblClearChgStatus1.Size = new System.Drawing.Size(86, 13);
            this.lblClearChgStatus1.TabIndex = 0;
            this.lblClearChgStatus1.Text = "Change Status 1";
            // 
            // lblClearChgStatus10
            // 
            this.lblClearChgStatus10.AutoSize = true;
            this.lblClearChgStatus10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus10.Location = new System.Drawing.Point(15, 235);
            this.lblClearChgStatus10.Name = "lblClearChgStatus10";
            this.lblClearChgStatus10.Size = new System.Drawing.Size(92, 13);
            this.lblClearChgStatus10.TabIndex = 18;
            this.lblClearChgStatus10.Text = "Change Status 10";
            // 
            // lblClearChgStatus9
            // 
            this.lblClearChgStatus9.AutoSize = true;
            this.lblClearChgStatus9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearChgStatus9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClearChgStatus9.Location = new System.Drawing.Point(15, 211);
            this.lblClearChgStatus9.Name = "lblClearChgStatus9";
            this.lblClearChgStatus9.Size = new System.Drawing.Size(86, 13);
            this.lblClearChgStatus9.TabIndex = 16;
            this.lblClearChgStatus9.Text = "Change Status 9";
            // 
            // grpClearResComment
            // 
            this.grpClearResComment.Controls.Add(this.txtClearResComment);
            this.grpClearResComment.Controls.Add(this.lblClearComment);
            this.grpClearResComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpClearResComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpClearResComment.Location = new System.Drawing.Point(0, 372);
            this.grpClearResComment.Name = "grpClearResComment";
            this.grpClearResComment.Size = new System.Drawing.Size(498, 48);
            this.grpClearResComment.TabIndex = 3;
            this.grpClearResComment.TabStop = false;
            // 
            // txtClearResComment
            // 
            this.txtClearResComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClearResComment.Location = new System.Drawing.Point(143, 17);
            this.txtClearResComment.MaxLength = 400;
            this.txtClearResComment.Name = "txtClearResComment";
            this.txtClearResComment.Size = new System.Drawing.Size(350, 20);
            this.txtClearResComment.TabIndex = 1;
            // 
            // lblClearComment
            // 
            this.lblClearComment.AutoSize = true;
            this.lblClearComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearComment.Location = new System.Drawing.Point(15, 19);
            this.lblClearComment.Name = "lblClearComment";
            this.lblClearComment.Size = new System.Drawing.Size(78, 13);
            this.lblClearComment.TabIndex = 0;
            this.lblClearComment.Text = "Clear Comment";
            this.lblClearComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpClearEvent
            // 
            this.grpClearEvent.Controls.Add(this.cdvClearEvent);
            this.grpClearEvent.Controls.Add(this.lblClearEvent);
            this.grpClearEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpClearEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpClearEvent.Location = new System.Drawing.Point(0, 0);
            this.grpClearEvent.Name = "grpClearEvent";
            this.grpClearEvent.Size = new System.Drawing.Size(498, 48);
            this.grpClearEvent.TabIndex = 1;
            this.grpClearEvent.TabStop = false;
            this.grpClearEvent.Text = "Clear Event";
            // 
            // cdvClearEvent
            // 
            this.cdvClearEvent.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvClearEvent.BorderHotColor = System.Drawing.Color.Black;
            this.cdvClearEvent.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvClearEvent.BtnToolTipText = "";
            this.cdvClearEvent.DescText = "";
            this.cdvClearEvent.DisplaySubItemIndex = -1;
            this.cdvClearEvent.DisplayText = "";
            this.cdvClearEvent.Focusing = null;
            this.cdvClearEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvClearEvent.Index = 0;
            this.cdvClearEvent.IsViewBtnImage = false;
            this.cdvClearEvent.Location = new System.Drawing.Point(143, 15);
            this.cdvClearEvent.MaxLength = 20;
            this.cdvClearEvent.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvClearEvent.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvClearEvent.Name = "cdvClearEvent";
            this.cdvClearEvent.ReadOnly = false;
            this.cdvClearEvent.SearchSubItemIndex = 0;
            this.cdvClearEvent.SelectedDescIndex = -1;
            this.cdvClearEvent.SelectedSubItemIndex = -1;
            this.cdvClearEvent.SelectionStart = 0;
            this.cdvClearEvent.Size = new System.Drawing.Size(176, 20);
            this.cdvClearEvent.SmallImageList = null;
            this.cdvClearEvent.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvClearEvent.TabIndex = 1;
            this.cdvClearEvent.TextBoxToolTipText = "";
            this.cdvClearEvent.TextBoxWidth = 176;
            this.cdvClearEvent.VisibleButton = true;
            this.cdvClearEvent.VisibleColumnHeader = false;
            this.cdvClearEvent.VisibleDescription = false;
            this.cdvClearEvent.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvClearEvent_SelectedItemChanged);
            this.cdvClearEvent.ButtonPress += new System.EventHandler(this.cdvClearEvent_ButtonPress);
            this.cdvClearEvent.TextBoxTextChanged += new System.EventHandler(this.cdvClearEvent_TextBoxTextChanged);
            // 
            // lblClearEvent
            // 
            this.lblClearEvent.AutoSize = true;
            this.lblClearEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClearEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearEvent.Location = new System.Drawing.Point(15, 19);
            this.lblClearEvent.Name = "lblClearEvent";
            this.lblClearEvent.Size = new System.Drawing.Size(62, 13);
            this.lblClearEvent.TabIndex = 0;
            this.lblClearEvent.Text = "Clear Event";
            // 
            // tbpTranCMF
            // 
            this.tbpTranCMF.BackColor = System.Drawing.SystemColors.Control;
            this.tbpTranCMF.Controls.Add(this.grpTranCMF);
            this.tbpTranCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpTranCMF.Name = "tbpTranCMF";
            this.tbpTranCMF.Size = new System.Drawing.Size(498, 420);
            this.tbpTranCMF.TabIndex = 2;
            this.tbpTranCMF.Text = "Tran Customized Field";
            this.tbpTranCMF.Visible = false;
            // 
            // grpTranCMF
            // 
            this.grpTranCMF.BackColor = System.Drawing.SystemColors.Control;
            this.grpTranCMF.Controls.Add(this.cdvCMF19);
            this.grpTranCMF.Controls.Add(this.cdvCMF18);
            this.grpTranCMF.Controls.Add(this.cdvCMF17);
            this.grpTranCMF.Controls.Add(this.cdvCMF16);
            this.grpTranCMF.Controls.Add(this.cdvCMF15);
            this.grpTranCMF.Controls.Add(this.cdvCMF14);
            this.grpTranCMF.Controls.Add(this.cdvCMF13);
            this.grpTranCMF.Controls.Add(this.cdvCMF12);
            this.grpTranCMF.Controls.Add(this.cdvCMF20);
            this.grpTranCMF.Controls.Add(this.cdvCMF11);
            this.grpTranCMF.Controls.Add(this.lblCMF20);
            this.grpTranCMF.Controls.Add(this.lblCMF19);
            this.grpTranCMF.Controls.Add(this.lblCMF18);
            this.grpTranCMF.Controls.Add(this.lblCMF17);
            this.grpTranCMF.Controls.Add(this.lblCMF16);
            this.grpTranCMF.Controls.Add(this.lblCMF15);
            this.grpTranCMF.Controls.Add(this.lblCMF14);
            this.grpTranCMF.Controls.Add(this.lblCMF13);
            this.grpTranCMF.Controls.Add(this.lblCMF12);
            this.grpTranCMF.Controls.Add(this.lblCMF11);
            this.grpTranCMF.Controls.Add(this.cdvCMF9);
            this.grpTranCMF.Controls.Add(this.cdvCMF8);
            this.grpTranCMF.Controls.Add(this.cdvCMF7);
            this.grpTranCMF.Controls.Add(this.cdvCMF6);
            this.grpTranCMF.Controls.Add(this.cdvCMF5);
            this.grpTranCMF.Controls.Add(this.cdvCMF4);
            this.grpTranCMF.Controls.Add(this.cdvCMF3);
            this.grpTranCMF.Controls.Add(this.cdvCMF2);
            this.grpTranCMF.Controls.Add(this.cdvCMF10);
            this.grpTranCMF.Controls.Add(this.cdvCMF1);
            this.grpTranCMF.Controls.Add(this.lblCMF10);
            this.grpTranCMF.Controls.Add(this.lblCMF9);
            this.grpTranCMF.Controls.Add(this.lblCMF8);
            this.grpTranCMF.Controls.Add(this.lblCMF7);
            this.grpTranCMF.Controls.Add(this.lblCMF6);
            this.grpTranCMF.Controls.Add(this.lblCMF5);
            this.grpTranCMF.Controls.Add(this.lblCMF4);
            this.grpTranCMF.Controls.Add(this.lblCMF3);
            this.grpTranCMF.Controls.Add(this.lblCMF2);
            this.grpTranCMF.Controls.Add(this.lblCMF1);
            this.grpTranCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranCMF.Location = new System.Drawing.Point(0, 0);
            this.grpTranCMF.Name = "grpTranCMF";
            this.grpTranCMF.Size = new System.Drawing.Size(498, 420);
            this.grpTranCMF.TabIndex = 0;
            this.grpTranCMF.TabStop = false;
            this.grpTranCMF.Text = "Tran Customized Field (1~20)";
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
            this.cdvCMF19.Location = new System.Drawing.Point(347, 210);
            this.cdvCMF19.MaxLength = 30;
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.Name = "cdvCMF19";
            this.cdvCMF19.ReadOnly = false;
            this.cdvCMF19.SearchSubItemIndex = 0;
            this.cdvCMF19.SelectedDescIndex = -1;
            this.cdvCMF19.SelectedSubItemIndex = -1;
            this.cdvCMF19.SelectionStart = 0;
            this.cdvCMF19.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF19.SmallImageList = null;
            this.cdvCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF19.TabIndex = 37;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 130;
            this.cdvCMF19.VisibleButton = true;
            this.cdvCMF19.VisibleColumnHeader = false;
            this.cdvCMF19.VisibleDescription = false;
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
            this.cdvCMF18.Location = new System.Drawing.Point(347, 186);
            this.cdvCMF18.MaxLength = 30;
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.Name = "cdvCMF18";
            this.cdvCMF18.ReadOnly = false;
            this.cdvCMF18.SearchSubItemIndex = 0;
            this.cdvCMF18.SelectedDescIndex = -1;
            this.cdvCMF18.SelectedSubItemIndex = -1;
            this.cdvCMF18.SelectionStart = 0;
            this.cdvCMF18.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF18.SmallImageList = null;
            this.cdvCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF18.TabIndex = 35;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 130;
            this.cdvCMF18.VisibleButton = true;
            this.cdvCMF18.VisibleColumnHeader = false;
            this.cdvCMF18.VisibleDescription = false;
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
            this.cdvCMF17.Location = new System.Drawing.Point(347, 162);
            this.cdvCMF17.MaxLength = 30;
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.Name = "cdvCMF17";
            this.cdvCMF17.ReadOnly = false;
            this.cdvCMF17.SearchSubItemIndex = 0;
            this.cdvCMF17.SelectedDescIndex = -1;
            this.cdvCMF17.SelectedSubItemIndex = -1;
            this.cdvCMF17.SelectionStart = 0;
            this.cdvCMF17.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF17.SmallImageList = null;
            this.cdvCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF17.TabIndex = 33;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 130;
            this.cdvCMF17.VisibleButton = true;
            this.cdvCMF17.VisibleColumnHeader = false;
            this.cdvCMF17.VisibleDescription = false;
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
            this.cdvCMF16.Location = new System.Drawing.Point(347, 138);
            this.cdvCMF16.MaxLength = 30;
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.Name = "cdvCMF16";
            this.cdvCMF16.ReadOnly = false;
            this.cdvCMF16.SearchSubItemIndex = 0;
            this.cdvCMF16.SelectedDescIndex = -1;
            this.cdvCMF16.SelectedSubItemIndex = -1;
            this.cdvCMF16.SelectionStart = 0;
            this.cdvCMF16.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF16.SmallImageList = null;
            this.cdvCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF16.TabIndex = 31;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 130;
            this.cdvCMF16.VisibleButton = true;
            this.cdvCMF16.VisibleColumnHeader = false;
            this.cdvCMF16.VisibleDescription = false;
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
            this.cdvCMF15.Location = new System.Drawing.Point(347, 114);
            this.cdvCMF15.MaxLength = 30;
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.Name = "cdvCMF15";
            this.cdvCMF15.ReadOnly = false;
            this.cdvCMF15.SearchSubItemIndex = 0;
            this.cdvCMF15.SelectedDescIndex = -1;
            this.cdvCMF15.SelectedSubItemIndex = -1;
            this.cdvCMF15.SelectionStart = 0;
            this.cdvCMF15.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF15.SmallImageList = null;
            this.cdvCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF15.TabIndex = 29;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 130;
            this.cdvCMF15.VisibleButton = true;
            this.cdvCMF15.VisibleColumnHeader = false;
            this.cdvCMF15.VisibleDescription = false;
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
            this.cdvCMF14.Location = new System.Drawing.Point(347, 90);
            this.cdvCMF14.MaxLength = 30;
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.Name = "cdvCMF14";
            this.cdvCMF14.ReadOnly = false;
            this.cdvCMF14.SearchSubItemIndex = 0;
            this.cdvCMF14.SelectedDescIndex = -1;
            this.cdvCMF14.SelectedSubItemIndex = -1;
            this.cdvCMF14.SelectionStart = 0;
            this.cdvCMF14.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF14.SmallImageList = null;
            this.cdvCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF14.TabIndex = 27;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 130;
            this.cdvCMF14.VisibleButton = true;
            this.cdvCMF14.VisibleColumnHeader = false;
            this.cdvCMF14.VisibleDescription = false;
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
            this.cdvCMF13.Location = new System.Drawing.Point(347, 66);
            this.cdvCMF13.MaxLength = 30;
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.Name = "cdvCMF13";
            this.cdvCMF13.ReadOnly = false;
            this.cdvCMF13.SearchSubItemIndex = 0;
            this.cdvCMF13.SelectedDescIndex = -1;
            this.cdvCMF13.SelectedSubItemIndex = -1;
            this.cdvCMF13.SelectionStart = 0;
            this.cdvCMF13.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF13.SmallImageList = null;
            this.cdvCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF13.TabIndex = 25;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 130;
            this.cdvCMF13.VisibleButton = true;
            this.cdvCMF13.VisibleColumnHeader = false;
            this.cdvCMF13.VisibleDescription = false;
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
            this.cdvCMF12.Location = new System.Drawing.Point(347, 42);
            this.cdvCMF12.MaxLength = 30;
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.Name = "cdvCMF12";
            this.cdvCMF12.ReadOnly = false;
            this.cdvCMF12.SearchSubItemIndex = 0;
            this.cdvCMF12.SelectedDescIndex = -1;
            this.cdvCMF12.SelectedSubItemIndex = -1;
            this.cdvCMF12.SelectionStart = 0;
            this.cdvCMF12.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF12.SmallImageList = null;
            this.cdvCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF12.TabIndex = 23;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 130;
            this.cdvCMF12.VisibleButton = true;
            this.cdvCMF12.VisibleColumnHeader = false;
            this.cdvCMF12.VisibleDescription = false;
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
            this.cdvCMF20.Location = new System.Drawing.Point(347, 234);
            this.cdvCMF20.MaxLength = 30;
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.Name = "cdvCMF20";
            this.cdvCMF20.ReadOnly = false;
            this.cdvCMF20.SearchSubItemIndex = 0;
            this.cdvCMF20.SelectedDescIndex = -1;
            this.cdvCMF20.SelectedSubItemIndex = -1;
            this.cdvCMF20.SelectionStart = 0;
            this.cdvCMF20.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF20.SmallImageList = null;
            this.cdvCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF20.TabIndex = 39;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 130;
            this.cdvCMF20.VisibleButton = true;
            this.cdvCMF20.VisibleColumnHeader = false;
            this.cdvCMF20.VisibleDescription = false;
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
            this.cdvCMF11.Location = new System.Drawing.Point(347, 18);
            this.cdvCMF11.MaxLength = 30;
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.Name = "cdvCMF11";
            this.cdvCMF11.ReadOnly = false;
            this.cdvCMF11.SearchSubItemIndex = 0;
            this.cdvCMF11.SelectedDescIndex = -1;
            this.cdvCMF11.SelectedSubItemIndex = -1;
            this.cdvCMF11.SelectionStart = 0;
            this.cdvCMF11.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF11.SmallImageList = null;
            this.cdvCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF11.TabIndex = 21;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 130;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(251, 238);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(90, 14);
            this.lblCMF20.TabIndex = 38;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(251, 214);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(90, 14);
            this.lblCMF19.TabIndex = 36;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(251, 190);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(90, 14);
            this.lblCMF18.TabIndex = 34;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(251, 166);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(90, 14);
            this.lblCMF17.TabIndex = 32;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(251, 142);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(90, 14);
            this.lblCMF16.TabIndex = 30;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(251, 118);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(90, 14);
            this.lblCMF15.TabIndex = 28;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(251, 94);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(90, 14);
            this.lblCMF14.TabIndex = 26;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(251, 70);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(90, 14);
            this.lblCMF13.TabIndex = 24;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(251, 46);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(90, 14);
            this.lblCMF12.TabIndex = 22;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(251, 22);
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
            this.cdvCMF9.Location = new System.Drawing.Point(104, 210);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 130;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
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
            this.cdvCMF8.Location = new System.Drawing.Point(104, 186);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 130;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
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
            this.cdvCMF7.Location = new System.Drawing.Point(104, 162);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 130;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
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
            this.cdvCMF6.Location = new System.Drawing.Point(104, 138);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 130;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
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
            this.cdvCMF5.Location = new System.Drawing.Point(104, 114);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 130;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
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
            this.cdvCMF4.Location = new System.Drawing.Point(104, 90);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 130;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
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
            this.cdvCMF3.Location = new System.Drawing.Point(104, 66);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 130;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
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
            this.cdvCMF2.Location = new System.Drawing.Point(104, 42);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 130;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
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
            this.cdvCMF10.Location = new System.Drawing.Point(104, 234);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 130;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
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
            this.cdvCMF1.Location = new System.Drawing.Point(104, 18);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 130;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(8, 238);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(90, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(8, 214);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(90, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(8, 190);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(90, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(8, 166);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(90, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(8, 142);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(90, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(8, 118);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(90, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(8, 94);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(90, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(8, 70);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(90, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(8, 46);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(90, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(8, 22);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(90, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpAlarmGroup
            // 
            this.tbpAlarmGroup.Controls.Add(this.grpAlarmGroup);
            this.tbpAlarmGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpAlarmGroup.Name = "tbpAlarmGroup";
            this.tbpAlarmGroup.Size = new System.Drawing.Size(498, 420);
            this.tbpAlarmGroup.TabIndex = 11;
            this.tbpAlarmGroup.Text = "Alarm Group Field";
            // 
            // grpAlarmGroup
            // 
            this.grpAlarmGroup.Controls.Add(this.cdvGroup10);
            this.grpAlarmGroup.Controls.Add(this.cdvGroup8);
            this.grpAlarmGroup.Controls.Add(this.cdvGroup7);
            this.grpAlarmGroup.Controls.Add(this.cdvGroup6);
            this.grpAlarmGroup.Controls.Add(this.cdvGroup5);
            this.grpAlarmGroup.Controls.Add(this.cdvGroup4);
            this.grpAlarmGroup.Controls.Add(this.cdvGroup3);
            this.grpAlarmGroup.Controls.Add(this.cdvGroup2);
            this.grpAlarmGroup.Controls.Add(this.cdvGroup1);
            this.grpAlarmGroup.Controls.Add(this.lblGroup10);
            this.grpAlarmGroup.Controls.Add(this.lblGroup9);
            this.grpAlarmGroup.Controls.Add(this.lblGroup8);
            this.grpAlarmGroup.Controls.Add(this.lblGroup7);
            this.grpAlarmGroup.Controls.Add(this.lblGroup6);
            this.grpAlarmGroup.Controls.Add(this.lblGroup5);
            this.grpAlarmGroup.Controls.Add(this.lblGroup4);
            this.grpAlarmGroup.Controls.Add(this.lblGroup3);
            this.grpAlarmGroup.Controls.Add(this.lblGroup2);
            this.grpAlarmGroup.Controls.Add(this.lblGroup1);
            this.grpAlarmGroup.Controls.Add(this.cdvGroup9);
            this.grpAlarmGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlarmGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAlarmGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpAlarmGroup.Location = new System.Drawing.Point(0, 0);
            this.grpAlarmGroup.Name = "grpAlarmGroup";
            this.grpAlarmGroup.Size = new System.Drawing.Size(498, 420);
            this.grpAlarmGroup.TabIndex = 1;
            this.grpAlarmGroup.TabStop = false;
            this.grpAlarmGroup.Text = "Alarm Group Field (1~10)";
            // 
            // cdvGroup10
            // 
            this.cdvGroup10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup10.BtnToolTipText = "";
            this.cdvGroup10.DescText = "";
            this.cdvGroup10.DisplaySubItemIndex = -1;
            this.cdvGroup10.DisplayText = "";
            this.cdvGroup10.Focusing = null;
            this.cdvGroup10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup10.Index = 0;
            this.cdvGroup10.IsViewBtnImage = false;
            this.cdvGroup10.Location = new System.Drawing.Point(172, 232);
            this.cdvGroup10.MaxLength = 30;
            this.cdvGroup10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.Name = "cdvGroup10";
            this.cdvGroup10.ReadOnly = false;
            this.cdvGroup10.SearchSubItemIndex = 0;
            this.cdvGroup10.SelectedDescIndex = -1;
            this.cdvGroup10.SelectedSubItemIndex = -1;
            this.cdvGroup10.SelectionStart = 0;
            this.cdvGroup10.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup10.SmallImageList = null;
            this.cdvGroup10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup10.TabIndex = 19;
            this.cdvGroup10.TextBoxToolTipText = "";
            this.cdvGroup10.TextBoxWidth = 200;
            this.cdvGroup10.VisibleButton = true;
            this.cdvGroup10.VisibleColumnHeader = false;
            this.cdvGroup10.VisibleDescription = false;
            this.cdvGroup10.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvGroup8
            // 
            this.cdvGroup8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup8.BtnToolTipText = "";
            this.cdvGroup8.DescText = "";
            this.cdvGroup8.DisplaySubItemIndex = -1;
            this.cdvGroup8.DisplayText = "";
            this.cdvGroup8.Focusing = null;
            this.cdvGroup8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup8.Index = 0;
            this.cdvGroup8.IsViewBtnImage = false;
            this.cdvGroup8.Location = new System.Drawing.Point(172, 184);
            this.cdvGroup8.MaxLength = 30;
            this.cdvGroup8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.Name = "cdvGroup8";
            this.cdvGroup8.ReadOnly = false;
            this.cdvGroup8.SearchSubItemIndex = 0;
            this.cdvGroup8.SelectedDescIndex = -1;
            this.cdvGroup8.SelectedSubItemIndex = -1;
            this.cdvGroup8.SelectionStart = 0;
            this.cdvGroup8.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup8.SmallImageList = null;
            this.cdvGroup8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup8.TabIndex = 15;
            this.cdvGroup8.TextBoxToolTipText = "";
            this.cdvGroup8.TextBoxWidth = 200;
            this.cdvGroup8.VisibleButton = true;
            this.cdvGroup8.VisibleColumnHeader = false;
            this.cdvGroup8.VisibleDescription = false;
            this.cdvGroup8.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvGroup7
            // 
            this.cdvGroup7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup7.BtnToolTipText = "";
            this.cdvGroup7.DescText = "";
            this.cdvGroup7.DisplaySubItemIndex = -1;
            this.cdvGroup7.DisplayText = "";
            this.cdvGroup7.Focusing = null;
            this.cdvGroup7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup7.Index = 0;
            this.cdvGroup7.IsViewBtnImage = false;
            this.cdvGroup7.Location = new System.Drawing.Point(172, 160);
            this.cdvGroup7.MaxLength = 30;
            this.cdvGroup7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.Name = "cdvGroup7";
            this.cdvGroup7.ReadOnly = false;
            this.cdvGroup7.SearchSubItemIndex = 0;
            this.cdvGroup7.SelectedDescIndex = -1;
            this.cdvGroup7.SelectedSubItemIndex = -1;
            this.cdvGroup7.SelectionStart = 0;
            this.cdvGroup7.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup7.SmallImageList = null;
            this.cdvGroup7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup7.TabIndex = 13;
            this.cdvGroup7.TextBoxToolTipText = "";
            this.cdvGroup7.TextBoxWidth = 200;
            this.cdvGroup7.VisibleButton = true;
            this.cdvGroup7.VisibleColumnHeader = false;
            this.cdvGroup7.VisibleDescription = false;
            this.cdvGroup7.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvGroup6
            // 
            this.cdvGroup6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup6.BtnToolTipText = "";
            this.cdvGroup6.DescText = "";
            this.cdvGroup6.DisplaySubItemIndex = -1;
            this.cdvGroup6.DisplayText = "";
            this.cdvGroup6.Focusing = null;
            this.cdvGroup6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup6.Index = 0;
            this.cdvGroup6.IsViewBtnImage = false;
            this.cdvGroup6.Location = new System.Drawing.Point(172, 136);
            this.cdvGroup6.MaxLength = 30;
            this.cdvGroup6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.Name = "cdvGroup6";
            this.cdvGroup6.ReadOnly = false;
            this.cdvGroup6.SearchSubItemIndex = 0;
            this.cdvGroup6.SelectedDescIndex = -1;
            this.cdvGroup6.SelectedSubItemIndex = -1;
            this.cdvGroup6.SelectionStart = 0;
            this.cdvGroup6.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup6.SmallImageList = null;
            this.cdvGroup6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup6.TabIndex = 11;
            this.cdvGroup6.TextBoxToolTipText = "";
            this.cdvGroup6.TextBoxWidth = 200;
            this.cdvGroup6.VisibleButton = true;
            this.cdvGroup6.VisibleColumnHeader = false;
            this.cdvGroup6.VisibleDescription = false;
            this.cdvGroup6.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvGroup5
            // 
            this.cdvGroup5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup5.BtnToolTipText = "";
            this.cdvGroup5.DescText = "";
            this.cdvGroup5.DisplaySubItemIndex = -1;
            this.cdvGroup5.DisplayText = "";
            this.cdvGroup5.Focusing = null;
            this.cdvGroup5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup5.Index = 0;
            this.cdvGroup5.IsViewBtnImage = false;
            this.cdvGroup5.Location = new System.Drawing.Point(172, 112);
            this.cdvGroup5.MaxLength = 30;
            this.cdvGroup5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.Name = "cdvGroup5";
            this.cdvGroup5.ReadOnly = false;
            this.cdvGroup5.SearchSubItemIndex = 0;
            this.cdvGroup5.SelectedDescIndex = -1;
            this.cdvGroup5.SelectedSubItemIndex = -1;
            this.cdvGroup5.SelectionStart = 0;
            this.cdvGroup5.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup5.SmallImageList = null;
            this.cdvGroup5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup5.TabIndex = 9;
            this.cdvGroup5.TextBoxToolTipText = "";
            this.cdvGroup5.TextBoxWidth = 200;
            this.cdvGroup5.VisibleButton = true;
            this.cdvGroup5.VisibleColumnHeader = false;
            this.cdvGroup5.VisibleDescription = false;
            this.cdvGroup5.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvGroup4
            // 
            this.cdvGroup4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup4.BtnToolTipText = "";
            this.cdvGroup4.DescText = "";
            this.cdvGroup4.DisplaySubItemIndex = -1;
            this.cdvGroup4.DisplayText = "";
            this.cdvGroup4.Focusing = null;
            this.cdvGroup4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup4.Index = 0;
            this.cdvGroup4.IsViewBtnImage = false;
            this.cdvGroup4.Location = new System.Drawing.Point(172, 88);
            this.cdvGroup4.MaxLength = 30;
            this.cdvGroup4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.Name = "cdvGroup4";
            this.cdvGroup4.ReadOnly = false;
            this.cdvGroup4.SearchSubItemIndex = 0;
            this.cdvGroup4.SelectedDescIndex = -1;
            this.cdvGroup4.SelectedSubItemIndex = -1;
            this.cdvGroup4.SelectionStart = 0;
            this.cdvGroup4.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup4.SmallImageList = null;
            this.cdvGroup4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup4.TabIndex = 7;
            this.cdvGroup4.TextBoxToolTipText = "";
            this.cdvGroup4.TextBoxWidth = 200;
            this.cdvGroup4.VisibleButton = true;
            this.cdvGroup4.VisibleColumnHeader = false;
            this.cdvGroup4.VisibleDescription = false;
            this.cdvGroup4.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvGroup3
            // 
            this.cdvGroup3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup3.BtnToolTipText = "";
            this.cdvGroup3.DescText = "";
            this.cdvGroup3.DisplaySubItemIndex = -1;
            this.cdvGroup3.DisplayText = "";
            this.cdvGroup3.Focusing = null;
            this.cdvGroup3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup3.Index = 0;
            this.cdvGroup3.IsViewBtnImage = false;
            this.cdvGroup3.Location = new System.Drawing.Point(172, 64);
            this.cdvGroup3.MaxLength = 30;
            this.cdvGroup3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.Name = "cdvGroup3";
            this.cdvGroup3.ReadOnly = false;
            this.cdvGroup3.SearchSubItemIndex = 0;
            this.cdvGroup3.SelectedDescIndex = -1;
            this.cdvGroup3.SelectedSubItemIndex = -1;
            this.cdvGroup3.SelectionStart = 0;
            this.cdvGroup3.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup3.SmallImageList = null;
            this.cdvGroup3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup3.TabIndex = 5;
            this.cdvGroup3.TextBoxToolTipText = "";
            this.cdvGroup3.TextBoxWidth = 200;
            this.cdvGroup3.VisibleButton = true;
            this.cdvGroup3.VisibleColumnHeader = false;
            this.cdvGroup3.VisibleDescription = false;
            this.cdvGroup3.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvGroup2
            // 
            this.cdvGroup2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup2.BtnToolTipText = "";
            this.cdvGroup2.DescText = "";
            this.cdvGroup2.DisplaySubItemIndex = -1;
            this.cdvGroup2.DisplayText = "";
            this.cdvGroup2.Focusing = null;
            this.cdvGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup2.Index = 0;
            this.cdvGroup2.IsViewBtnImage = false;
            this.cdvGroup2.Location = new System.Drawing.Point(172, 40);
            this.cdvGroup2.MaxLength = 30;
            this.cdvGroup2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.Name = "cdvGroup2";
            this.cdvGroup2.ReadOnly = false;
            this.cdvGroup2.SearchSubItemIndex = 0;
            this.cdvGroup2.SelectedDescIndex = -1;
            this.cdvGroup2.SelectedSubItemIndex = -1;
            this.cdvGroup2.SelectionStart = 0;
            this.cdvGroup2.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup2.SmallImageList = null;
            this.cdvGroup2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup2.TabIndex = 3;
            this.cdvGroup2.TextBoxToolTipText = "";
            this.cdvGroup2.TextBoxWidth = 200;
            this.cdvGroup2.VisibleButton = true;
            this.cdvGroup2.VisibleColumnHeader = false;
            this.cdvGroup2.VisibleDescription = false;
            this.cdvGroup2.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvGroup1
            // 
            this.cdvGroup1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup1.BtnToolTipText = "";
            this.cdvGroup1.DescText = "";
            this.cdvGroup1.DisplaySubItemIndex = -1;
            this.cdvGroup1.DisplayText = "";
            this.cdvGroup1.Focusing = null;
            this.cdvGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup1.Index = 0;
            this.cdvGroup1.IsViewBtnImage = false;
            this.cdvGroup1.Location = new System.Drawing.Point(172, 16);
            this.cdvGroup1.MaxLength = 30;
            this.cdvGroup1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = false;
            this.cdvGroup1.SearchSubItemIndex = 0;
            this.cdvGroup1.SelectedDescIndex = -1;
            this.cdvGroup1.SelectedSubItemIndex = -1;
            this.cdvGroup1.SelectionStart = 0;
            this.cdvGroup1.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup1.SmallImageList = null;
            this.cdvGroup1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup1.TabIndex = 1;
            this.cdvGroup1.TextBoxToolTipText = "";
            this.cdvGroup1.TextBoxWidth = 200;
            this.cdvGroup1.VisibleButton = true;
            this.cdvGroup1.VisibleColumnHeader = false;
            this.cdvGroup1.VisibleDescription = false;
            this.cdvGroup1.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblGroup10
            // 
            this.lblGroup10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup10.Location = new System.Drawing.Point(15, 235);
            this.lblGroup10.Name = "lblGroup10";
            this.lblGroup10.Size = new System.Drawing.Size(150, 14);
            this.lblGroup10.TabIndex = 18;
            // 
            // lblGroup9
            // 
            this.lblGroup9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup9.Location = new System.Drawing.Point(15, 211);
            this.lblGroup9.Name = "lblGroup9";
            this.lblGroup9.Size = new System.Drawing.Size(150, 14);
            this.lblGroup9.TabIndex = 16;
            // 
            // lblGroup8
            // 
            this.lblGroup8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup8.Location = new System.Drawing.Point(15, 187);
            this.lblGroup8.Name = "lblGroup8";
            this.lblGroup8.Size = new System.Drawing.Size(150, 14);
            this.lblGroup8.TabIndex = 14;
            // 
            // lblGroup7
            // 
            this.lblGroup7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup7.Location = new System.Drawing.Point(15, 163);
            this.lblGroup7.Name = "lblGroup7";
            this.lblGroup7.Size = new System.Drawing.Size(150, 14);
            this.lblGroup7.TabIndex = 12;
            // 
            // lblGroup6
            // 
            this.lblGroup6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup6.Location = new System.Drawing.Point(15, 139);
            this.lblGroup6.Name = "lblGroup6";
            this.lblGroup6.Size = new System.Drawing.Size(150, 14);
            this.lblGroup6.TabIndex = 10;
            // 
            // lblGroup5
            // 
            this.lblGroup5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup5.Location = new System.Drawing.Point(15, 115);
            this.lblGroup5.Name = "lblGroup5";
            this.lblGroup5.Size = new System.Drawing.Size(150, 14);
            this.lblGroup5.TabIndex = 8;
            // 
            // lblGroup4
            // 
            this.lblGroup4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup4.Location = new System.Drawing.Point(15, 91);
            this.lblGroup4.Name = "lblGroup4";
            this.lblGroup4.Size = new System.Drawing.Size(150, 14);
            this.lblGroup4.TabIndex = 6;
            // 
            // lblGroup3
            // 
            this.lblGroup3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup3.Location = new System.Drawing.Point(15, 67);
            this.lblGroup3.Name = "lblGroup3";
            this.lblGroup3.Size = new System.Drawing.Size(150, 14);
            this.lblGroup3.TabIndex = 4;
            // 
            // lblGroup2
            // 
            this.lblGroup2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup2.Location = new System.Drawing.Point(15, 43);
            this.lblGroup2.Name = "lblGroup2";
            this.lblGroup2.Size = new System.Drawing.Size(150, 14);
            this.lblGroup2.TabIndex = 2;
            // 
            // lblGroup1
            // 
            this.lblGroup1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup1.Location = new System.Drawing.Point(15, 19);
            this.lblGroup1.Name = "lblGroup1";
            this.lblGroup1.Size = new System.Drawing.Size(150, 14);
            this.lblGroup1.TabIndex = 0;
            // 
            // cdvGroup9
            // 
            this.cdvGroup9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup9.BtnToolTipText = "";
            this.cdvGroup9.DescText = "";
            this.cdvGroup9.DisplaySubItemIndex = -1;
            this.cdvGroup9.DisplayText = "";
            this.cdvGroup9.Focusing = null;
            this.cdvGroup9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup9.Index = 0;
            this.cdvGroup9.IsViewBtnImage = false;
            this.cdvGroup9.Location = new System.Drawing.Point(172, 208);
            this.cdvGroup9.MaxLength = 30;
            this.cdvGroup9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.Name = "cdvGroup9";
            this.cdvGroup9.ReadOnly = false;
            this.cdvGroup9.SearchSubItemIndex = 0;
            this.cdvGroup9.SelectedDescIndex = -1;
            this.cdvGroup9.SelectedSubItemIndex = -1;
            this.cdvGroup9.SelectionStart = 0;
            this.cdvGroup9.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup9.SmallImageList = null;
            this.cdvGroup9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup9.TabIndex = 17;
            this.cdvGroup9.TextBoxToolTipText = "";
            this.cdvGroup9.TextBoxWidth = 200;
            this.cdvGroup9.VisibleButton = true;
            this.cdvGroup9.VisibleColumnHeader = false;
            this.cdvGroup9.VisibleDescription = false;
            this.cdvGroup9.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvGroup9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // tbpAlarmCMF
            // 
            this.tbpAlarmCMF.Controls.Add(this.grpAlarmCMF);
            this.tbpAlarmCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpAlarmCMF.Name = "tbpAlarmCMF";
            this.tbpAlarmCMF.Size = new System.Drawing.Size(498, 420);
            this.tbpAlarmCMF.TabIndex = 12;
            this.tbpAlarmCMF.Text = "Alarm Customized Field";
            // 
            // grpAlarmCMF
            // 
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF19);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF18);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF17);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF16);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF15);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF14);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF13);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF12);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF20);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF11);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF20);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF19);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF18);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF17);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF16);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF15);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF14);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF13);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF12);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF11);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF9);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF8);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF7);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF6);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF5);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF4);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF3);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF2);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF10);
            this.grpAlarmCMF.Controls.Add(this.cdvAlarmCMF1);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF10);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF9);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF8);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF7);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF6);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF5);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF4);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF3);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF2);
            this.grpAlarmCMF.Controls.Add(this.lblAlarmCMF1);
            this.grpAlarmCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlarmCMF.Location = new System.Drawing.Point(0, 0);
            this.grpAlarmCMF.Name = "grpAlarmCMF";
            this.grpAlarmCMF.Size = new System.Drawing.Size(498, 420);
            this.grpAlarmCMF.TabIndex = 1;
            this.grpAlarmCMF.TabStop = false;
            this.grpAlarmCMF.Text = "Alarm Customized Field (1~20)";
            // 
            // cdvAlarmCMF19
            // 
            this.cdvAlarmCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF19.BtnToolTipText = "";
            this.cdvAlarmCMF19.DescText = "";
            this.cdvAlarmCMF19.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF19.DisplayText = "";
            this.cdvAlarmCMF19.Focusing = null;
            this.cdvAlarmCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF19.Index = 0;
            this.cdvAlarmCMF19.IsViewBtnImage = false;
            this.cdvAlarmCMF19.Location = new System.Drawing.Point(352, 210);
            this.cdvAlarmCMF19.MaxLength = 30;
            this.cdvAlarmCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF19.Name = "cdvAlarmCMF19";
            this.cdvAlarmCMF19.ReadOnly = false;
            this.cdvAlarmCMF19.SearchSubItemIndex = 0;
            this.cdvAlarmCMF19.SelectedDescIndex = -1;
            this.cdvAlarmCMF19.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF19.SelectionStart = 0;
            this.cdvAlarmCMF19.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF19.SmallImageList = null;
            this.cdvAlarmCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF19.TabIndex = 37;
            this.cdvAlarmCMF19.TextBoxToolTipText = "";
            this.cdvAlarmCMF19.TextBoxWidth = 125;
            this.cdvAlarmCMF19.VisibleButton = true;
            this.cdvAlarmCMF19.VisibleColumnHeader = false;
            this.cdvAlarmCMF19.VisibleDescription = false;
            this.cdvAlarmCMF19.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF18
            // 
            this.cdvAlarmCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF18.BtnToolTipText = "";
            this.cdvAlarmCMF18.DescText = "";
            this.cdvAlarmCMF18.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF18.DisplayText = "";
            this.cdvAlarmCMF18.Focusing = null;
            this.cdvAlarmCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF18.Index = 0;
            this.cdvAlarmCMF18.IsViewBtnImage = false;
            this.cdvAlarmCMF18.Location = new System.Drawing.Point(352, 186);
            this.cdvAlarmCMF18.MaxLength = 30;
            this.cdvAlarmCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF18.Name = "cdvAlarmCMF18";
            this.cdvAlarmCMF18.ReadOnly = false;
            this.cdvAlarmCMF18.SearchSubItemIndex = 0;
            this.cdvAlarmCMF18.SelectedDescIndex = -1;
            this.cdvAlarmCMF18.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF18.SelectionStart = 0;
            this.cdvAlarmCMF18.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF18.SmallImageList = null;
            this.cdvAlarmCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF18.TabIndex = 35;
            this.cdvAlarmCMF18.TextBoxToolTipText = "";
            this.cdvAlarmCMF18.TextBoxWidth = 125;
            this.cdvAlarmCMF18.VisibleButton = true;
            this.cdvAlarmCMF18.VisibleColumnHeader = false;
            this.cdvAlarmCMF18.VisibleDescription = false;
            this.cdvAlarmCMF18.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF17
            // 
            this.cdvAlarmCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF17.BtnToolTipText = "";
            this.cdvAlarmCMF17.DescText = "";
            this.cdvAlarmCMF17.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF17.DisplayText = "";
            this.cdvAlarmCMF17.Focusing = null;
            this.cdvAlarmCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF17.Index = 0;
            this.cdvAlarmCMF17.IsViewBtnImage = false;
            this.cdvAlarmCMF17.Location = new System.Drawing.Point(352, 162);
            this.cdvAlarmCMF17.MaxLength = 30;
            this.cdvAlarmCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF17.Name = "cdvAlarmCMF17";
            this.cdvAlarmCMF17.ReadOnly = false;
            this.cdvAlarmCMF17.SearchSubItemIndex = 0;
            this.cdvAlarmCMF17.SelectedDescIndex = -1;
            this.cdvAlarmCMF17.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF17.SelectionStart = 0;
            this.cdvAlarmCMF17.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF17.SmallImageList = null;
            this.cdvAlarmCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF17.TabIndex = 33;
            this.cdvAlarmCMF17.TextBoxToolTipText = "";
            this.cdvAlarmCMF17.TextBoxWidth = 125;
            this.cdvAlarmCMF17.VisibleButton = true;
            this.cdvAlarmCMF17.VisibleColumnHeader = false;
            this.cdvAlarmCMF17.VisibleDescription = false;
            this.cdvAlarmCMF17.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF16
            // 
            this.cdvAlarmCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF16.BtnToolTipText = "";
            this.cdvAlarmCMF16.DescText = "";
            this.cdvAlarmCMF16.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF16.DisplayText = "";
            this.cdvAlarmCMF16.Focusing = null;
            this.cdvAlarmCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF16.Index = 0;
            this.cdvAlarmCMF16.IsViewBtnImage = false;
            this.cdvAlarmCMF16.Location = new System.Drawing.Point(352, 138);
            this.cdvAlarmCMF16.MaxLength = 30;
            this.cdvAlarmCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF16.Name = "cdvAlarmCMF16";
            this.cdvAlarmCMF16.ReadOnly = false;
            this.cdvAlarmCMF16.SearchSubItemIndex = 0;
            this.cdvAlarmCMF16.SelectedDescIndex = -1;
            this.cdvAlarmCMF16.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF16.SelectionStart = 0;
            this.cdvAlarmCMF16.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF16.SmallImageList = null;
            this.cdvAlarmCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF16.TabIndex = 31;
            this.cdvAlarmCMF16.TextBoxToolTipText = "";
            this.cdvAlarmCMF16.TextBoxWidth = 125;
            this.cdvAlarmCMF16.VisibleButton = true;
            this.cdvAlarmCMF16.VisibleColumnHeader = false;
            this.cdvAlarmCMF16.VisibleDescription = false;
            this.cdvAlarmCMF16.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF15
            // 
            this.cdvAlarmCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF15.BtnToolTipText = "";
            this.cdvAlarmCMF15.DescText = "";
            this.cdvAlarmCMF15.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF15.DisplayText = "";
            this.cdvAlarmCMF15.Focusing = null;
            this.cdvAlarmCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF15.Index = 0;
            this.cdvAlarmCMF15.IsViewBtnImage = false;
            this.cdvAlarmCMF15.Location = new System.Drawing.Point(352, 114);
            this.cdvAlarmCMF15.MaxLength = 30;
            this.cdvAlarmCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF15.Name = "cdvAlarmCMF15";
            this.cdvAlarmCMF15.ReadOnly = false;
            this.cdvAlarmCMF15.SearchSubItemIndex = 0;
            this.cdvAlarmCMF15.SelectedDescIndex = -1;
            this.cdvAlarmCMF15.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF15.SelectionStart = 0;
            this.cdvAlarmCMF15.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF15.SmallImageList = null;
            this.cdvAlarmCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF15.TabIndex = 29;
            this.cdvAlarmCMF15.TextBoxToolTipText = "";
            this.cdvAlarmCMF15.TextBoxWidth = 125;
            this.cdvAlarmCMF15.VisibleButton = true;
            this.cdvAlarmCMF15.VisibleColumnHeader = false;
            this.cdvAlarmCMF15.VisibleDescription = false;
            this.cdvAlarmCMF15.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF14
            // 
            this.cdvAlarmCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF14.BtnToolTipText = "";
            this.cdvAlarmCMF14.DescText = "";
            this.cdvAlarmCMF14.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF14.DisplayText = "";
            this.cdvAlarmCMF14.Focusing = null;
            this.cdvAlarmCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF14.Index = 0;
            this.cdvAlarmCMF14.IsViewBtnImage = false;
            this.cdvAlarmCMF14.Location = new System.Drawing.Point(352, 90);
            this.cdvAlarmCMF14.MaxLength = 30;
            this.cdvAlarmCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF14.Name = "cdvAlarmCMF14";
            this.cdvAlarmCMF14.ReadOnly = false;
            this.cdvAlarmCMF14.SearchSubItemIndex = 0;
            this.cdvAlarmCMF14.SelectedDescIndex = -1;
            this.cdvAlarmCMF14.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF14.SelectionStart = 0;
            this.cdvAlarmCMF14.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF14.SmallImageList = null;
            this.cdvAlarmCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF14.TabIndex = 27;
            this.cdvAlarmCMF14.TextBoxToolTipText = "";
            this.cdvAlarmCMF14.TextBoxWidth = 125;
            this.cdvAlarmCMF14.VisibleButton = true;
            this.cdvAlarmCMF14.VisibleColumnHeader = false;
            this.cdvAlarmCMF14.VisibleDescription = false;
            this.cdvAlarmCMF14.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF13
            // 
            this.cdvAlarmCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF13.BtnToolTipText = "";
            this.cdvAlarmCMF13.DescText = "";
            this.cdvAlarmCMF13.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF13.DisplayText = "";
            this.cdvAlarmCMF13.Focusing = null;
            this.cdvAlarmCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF13.Index = 0;
            this.cdvAlarmCMF13.IsViewBtnImage = false;
            this.cdvAlarmCMF13.Location = new System.Drawing.Point(352, 66);
            this.cdvAlarmCMF13.MaxLength = 30;
            this.cdvAlarmCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF13.Name = "cdvAlarmCMF13";
            this.cdvAlarmCMF13.ReadOnly = false;
            this.cdvAlarmCMF13.SearchSubItemIndex = 0;
            this.cdvAlarmCMF13.SelectedDescIndex = -1;
            this.cdvAlarmCMF13.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF13.SelectionStart = 0;
            this.cdvAlarmCMF13.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF13.SmallImageList = null;
            this.cdvAlarmCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF13.TabIndex = 25;
            this.cdvAlarmCMF13.TextBoxToolTipText = "";
            this.cdvAlarmCMF13.TextBoxWidth = 125;
            this.cdvAlarmCMF13.VisibleButton = true;
            this.cdvAlarmCMF13.VisibleColumnHeader = false;
            this.cdvAlarmCMF13.VisibleDescription = false;
            this.cdvAlarmCMF13.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF12
            // 
            this.cdvAlarmCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF12.BtnToolTipText = "";
            this.cdvAlarmCMF12.DescText = "";
            this.cdvAlarmCMF12.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF12.DisplayText = "";
            this.cdvAlarmCMF12.Focusing = null;
            this.cdvAlarmCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF12.Index = 0;
            this.cdvAlarmCMF12.IsViewBtnImage = false;
            this.cdvAlarmCMF12.Location = new System.Drawing.Point(352, 42);
            this.cdvAlarmCMF12.MaxLength = 30;
            this.cdvAlarmCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF12.Name = "cdvAlarmCMF12";
            this.cdvAlarmCMF12.ReadOnly = false;
            this.cdvAlarmCMF12.SearchSubItemIndex = 0;
            this.cdvAlarmCMF12.SelectedDescIndex = -1;
            this.cdvAlarmCMF12.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF12.SelectionStart = 0;
            this.cdvAlarmCMF12.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF12.SmallImageList = null;
            this.cdvAlarmCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF12.TabIndex = 23;
            this.cdvAlarmCMF12.TextBoxToolTipText = "";
            this.cdvAlarmCMF12.TextBoxWidth = 125;
            this.cdvAlarmCMF12.VisibleButton = true;
            this.cdvAlarmCMF12.VisibleColumnHeader = false;
            this.cdvAlarmCMF12.VisibleDescription = false;
            this.cdvAlarmCMF12.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF20
            // 
            this.cdvAlarmCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF20.BtnToolTipText = "";
            this.cdvAlarmCMF20.DescText = "";
            this.cdvAlarmCMF20.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF20.DisplayText = "";
            this.cdvAlarmCMF20.Focusing = null;
            this.cdvAlarmCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF20.Index = 0;
            this.cdvAlarmCMF20.IsViewBtnImage = false;
            this.cdvAlarmCMF20.Location = new System.Drawing.Point(352, 234);
            this.cdvAlarmCMF20.MaxLength = 30;
            this.cdvAlarmCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF20.Name = "cdvAlarmCMF20";
            this.cdvAlarmCMF20.ReadOnly = false;
            this.cdvAlarmCMF20.SearchSubItemIndex = 0;
            this.cdvAlarmCMF20.SelectedDescIndex = -1;
            this.cdvAlarmCMF20.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF20.SelectionStart = 0;
            this.cdvAlarmCMF20.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF20.SmallImageList = null;
            this.cdvAlarmCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF20.TabIndex = 39;
            this.cdvAlarmCMF20.TextBoxToolTipText = "";
            this.cdvAlarmCMF20.TextBoxWidth = 125;
            this.cdvAlarmCMF20.VisibleButton = true;
            this.cdvAlarmCMF20.VisibleColumnHeader = false;
            this.cdvAlarmCMF20.VisibleDescription = false;
            this.cdvAlarmCMF20.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF11
            // 
            this.cdvAlarmCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF11.BtnToolTipText = "";
            this.cdvAlarmCMF11.DescText = "";
            this.cdvAlarmCMF11.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF11.DisplayText = "";
            this.cdvAlarmCMF11.Focusing = null;
            this.cdvAlarmCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF11.Index = 0;
            this.cdvAlarmCMF11.IsViewBtnImage = false;
            this.cdvAlarmCMF11.Location = new System.Drawing.Point(352, 18);
            this.cdvAlarmCMF11.MaxLength = 30;
            this.cdvAlarmCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF11.Name = "cdvAlarmCMF11";
            this.cdvAlarmCMF11.ReadOnly = false;
            this.cdvAlarmCMF11.SearchSubItemIndex = 0;
            this.cdvAlarmCMF11.SelectedDescIndex = -1;
            this.cdvAlarmCMF11.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF11.SelectionStart = 0;
            this.cdvAlarmCMF11.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF11.SmallImageList = null;
            this.cdvAlarmCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF11.TabIndex = 21;
            this.cdvAlarmCMF11.TextBoxToolTipText = "";
            this.cdvAlarmCMF11.TextBoxWidth = 125;
            this.cdvAlarmCMF11.VisibleButton = true;
            this.cdvAlarmCMF11.VisibleColumnHeader = false;
            this.cdvAlarmCMF11.VisibleDescription = false;
            this.cdvAlarmCMF11.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblAlarmCMF20
            // 
            this.lblAlarmCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF20.Location = new System.Drawing.Point(251, 238);
            this.lblAlarmCMF20.Name = "lblAlarmCMF20";
            this.lblAlarmCMF20.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF20.TabIndex = 38;
            this.lblAlarmCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF19
            // 
            this.lblAlarmCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF19.Location = new System.Drawing.Point(251, 214);
            this.lblAlarmCMF19.Name = "lblAlarmCMF19";
            this.lblAlarmCMF19.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF19.TabIndex = 36;
            this.lblAlarmCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF18
            // 
            this.lblAlarmCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF18.Location = new System.Drawing.Point(251, 190);
            this.lblAlarmCMF18.Name = "lblAlarmCMF18";
            this.lblAlarmCMF18.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF18.TabIndex = 34;
            this.lblAlarmCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF17
            // 
            this.lblAlarmCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF17.Location = new System.Drawing.Point(251, 166);
            this.lblAlarmCMF17.Name = "lblAlarmCMF17";
            this.lblAlarmCMF17.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF17.TabIndex = 32;
            this.lblAlarmCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF16
            // 
            this.lblAlarmCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF16.Location = new System.Drawing.Point(251, 142);
            this.lblAlarmCMF16.Name = "lblAlarmCMF16";
            this.lblAlarmCMF16.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF16.TabIndex = 30;
            this.lblAlarmCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF15
            // 
            this.lblAlarmCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF15.Location = new System.Drawing.Point(251, 118);
            this.lblAlarmCMF15.Name = "lblAlarmCMF15";
            this.lblAlarmCMF15.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF15.TabIndex = 28;
            this.lblAlarmCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF14
            // 
            this.lblAlarmCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF14.Location = new System.Drawing.Point(251, 94);
            this.lblAlarmCMF14.Name = "lblAlarmCMF14";
            this.lblAlarmCMF14.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF14.TabIndex = 26;
            this.lblAlarmCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF13
            // 
            this.lblAlarmCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF13.Location = new System.Drawing.Point(251, 70);
            this.lblAlarmCMF13.Name = "lblAlarmCMF13";
            this.lblAlarmCMF13.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF13.TabIndex = 24;
            this.lblAlarmCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF12
            // 
            this.lblAlarmCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF12.Location = new System.Drawing.Point(251, 46);
            this.lblAlarmCMF12.Name = "lblAlarmCMF12";
            this.lblAlarmCMF12.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF12.TabIndex = 22;
            this.lblAlarmCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF11
            // 
            this.lblAlarmCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF11.Location = new System.Drawing.Point(251, 22);
            this.lblAlarmCMF11.Name = "lblAlarmCMF11";
            this.lblAlarmCMF11.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF11.TabIndex = 20;
            this.lblAlarmCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvAlarmCMF9
            // 
            this.cdvAlarmCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF9.BtnToolTipText = "";
            this.cdvAlarmCMF9.DescText = "";
            this.cdvAlarmCMF9.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF9.DisplayText = "";
            this.cdvAlarmCMF9.Focusing = null;
            this.cdvAlarmCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF9.Index = 0;
            this.cdvAlarmCMF9.IsViewBtnImage = false;
            this.cdvAlarmCMF9.Location = new System.Drawing.Point(109, 210);
            this.cdvAlarmCMF9.MaxLength = 30;
            this.cdvAlarmCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF9.Name = "cdvAlarmCMF9";
            this.cdvAlarmCMF9.ReadOnly = false;
            this.cdvAlarmCMF9.SearchSubItemIndex = 0;
            this.cdvAlarmCMF9.SelectedDescIndex = -1;
            this.cdvAlarmCMF9.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF9.SelectionStart = 0;
            this.cdvAlarmCMF9.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF9.SmallImageList = null;
            this.cdvAlarmCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF9.TabIndex = 17;
            this.cdvAlarmCMF9.TextBoxToolTipText = "";
            this.cdvAlarmCMF9.TextBoxWidth = 125;
            this.cdvAlarmCMF9.VisibleButton = true;
            this.cdvAlarmCMF9.VisibleColumnHeader = false;
            this.cdvAlarmCMF9.VisibleDescription = false;
            this.cdvAlarmCMF9.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF8
            // 
            this.cdvAlarmCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF8.BtnToolTipText = "";
            this.cdvAlarmCMF8.DescText = "";
            this.cdvAlarmCMF8.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF8.DisplayText = "";
            this.cdvAlarmCMF8.Focusing = null;
            this.cdvAlarmCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF8.Index = 0;
            this.cdvAlarmCMF8.IsViewBtnImage = false;
            this.cdvAlarmCMF8.Location = new System.Drawing.Point(109, 186);
            this.cdvAlarmCMF8.MaxLength = 30;
            this.cdvAlarmCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF8.Name = "cdvAlarmCMF8";
            this.cdvAlarmCMF8.ReadOnly = false;
            this.cdvAlarmCMF8.SearchSubItemIndex = 0;
            this.cdvAlarmCMF8.SelectedDescIndex = -1;
            this.cdvAlarmCMF8.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF8.SelectionStart = 0;
            this.cdvAlarmCMF8.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF8.SmallImageList = null;
            this.cdvAlarmCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF8.TabIndex = 15;
            this.cdvAlarmCMF8.TextBoxToolTipText = "";
            this.cdvAlarmCMF8.TextBoxWidth = 125;
            this.cdvAlarmCMF8.VisibleButton = true;
            this.cdvAlarmCMF8.VisibleColumnHeader = false;
            this.cdvAlarmCMF8.VisibleDescription = false;
            this.cdvAlarmCMF8.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF7
            // 
            this.cdvAlarmCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF7.BtnToolTipText = "";
            this.cdvAlarmCMF7.DescText = "";
            this.cdvAlarmCMF7.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF7.DisplayText = "";
            this.cdvAlarmCMF7.Focusing = null;
            this.cdvAlarmCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF7.Index = 0;
            this.cdvAlarmCMF7.IsViewBtnImage = false;
            this.cdvAlarmCMF7.Location = new System.Drawing.Point(109, 162);
            this.cdvAlarmCMF7.MaxLength = 30;
            this.cdvAlarmCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF7.Name = "cdvAlarmCMF7";
            this.cdvAlarmCMF7.ReadOnly = false;
            this.cdvAlarmCMF7.SearchSubItemIndex = 0;
            this.cdvAlarmCMF7.SelectedDescIndex = -1;
            this.cdvAlarmCMF7.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF7.SelectionStart = 0;
            this.cdvAlarmCMF7.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF7.SmallImageList = null;
            this.cdvAlarmCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF7.TabIndex = 13;
            this.cdvAlarmCMF7.TextBoxToolTipText = "";
            this.cdvAlarmCMF7.TextBoxWidth = 125;
            this.cdvAlarmCMF7.VisibleButton = true;
            this.cdvAlarmCMF7.VisibleColumnHeader = false;
            this.cdvAlarmCMF7.VisibleDescription = false;
            this.cdvAlarmCMF7.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF6
            // 
            this.cdvAlarmCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF6.BtnToolTipText = "";
            this.cdvAlarmCMF6.DescText = "";
            this.cdvAlarmCMF6.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF6.DisplayText = "";
            this.cdvAlarmCMF6.Focusing = null;
            this.cdvAlarmCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF6.Index = 0;
            this.cdvAlarmCMF6.IsViewBtnImage = false;
            this.cdvAlarmCMF6.Location = new System.Drawing.Point(109, 138);
            this.cdvAlarmCMF6.MaxLength = 30;
            this.cdvAlarmCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF6.Name = "cdvAlarmCMF6";
            this.cdvAlarmCMF6.ReadOnly = false;
            this.cdvAlarmCMF6.SearchSubItemIndex = 0;
            this.cdvAlarmCMF6.SelectedDescIndex = -1;
            this.cdvAlarmCMF6.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF6.SelectionStart = 0;
            this.cdvAlarmCMF6.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF6.SmallImageList = null;
            this.cdvAlarmCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF6.TabIndex = 11;
            this.cdvAlarmCMF6.TextBoxToolTipText = "";
            this.cdvAlarmCMF6.TextBoxWidth = 125;
            this.cdvAlarmCMF6.VisibleButton = true;
            this.cdvAlarmCMF6.VisibleColumnHeader = false;
            this.cdvAlarmCMF6.VisibleDescription = false;
            this.cdvAlarmCMF6.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF5
            // 
            this.cdvAlarmCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF5.BtnToolTipText = "";
            this.cdvAlarmCMF5.DescText = "";
            this.cdvAlarmCMF5.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF5.DisplayText = "";
            this.cdvAlarmCMF5.Focusing = null;
            this.cdvAlarmCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF5.Index = 0;
            this.cdvAlarmCMF5.IsViewBtnImage = false;
            this.cdvAlarmCMF5.Location = new System.Drawing.Point(109, 114);
            this.cdvAlarmCMF5.MaxLength = 30;
            this.cdvAlarmCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF5.Name = "cdvAlarmCMF5";
            this.cdvAlarmCMF5.ReadOnly = false;
            this.cdvAlarmCMF5.SearchSubItemIndex = 0;
            this.cdvAlarmCMF5.SelectedDescIndex = -1;
            this.cdvAlarmCMF5.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF5.SelectionStart = 0;
            this.cdvAlarmCMF5.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF5.SmallImageList = null;
            this.cdvAlarmCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF5.TabIndex = 9;
            this.cdvAlarmCMF5.TextBoxToolTipText = "";
            this.cdvAlarmCMF5.TextBoxWidth = 125;
            this.cdvAlarmCMF5.VisibleButton = true;
            this.cdvAlarmCMF5.VisibleColumnHeader = false;
            this.cdvAlarmCMF5.VisibleDescription = false;
            this.cdvAlarmCMF5.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF4
            // 
            this.cdvAlarmCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF4.BtnToolTipText = "";
            this.cdvAlarmCMF4.DescText = "";
            this.cdvAlarmCMF4.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF4.DisplayText = "";
            this.cdvAlarmCMF4.Focusing = null;
            this.cdvAlarmCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF4.Index = 0;
            this.cdvAlarmCMF4.IsViewBtnImage = false;
            this.cdvAlarmCMF4.Location = new System.Drawing.Point(109, 90);
            this.cdvAlarmCMF4.MaxLength = 30;
            this.cdvAlarmCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF4.Name = "cdvAlarmCMF4";
            this.cdvAlarmCMF4.ReadOnly = false;
            this.cdvAlarmCMF4.SearchSubItemIndex = 0;
            this.cdvAlarmCMF4.SelectedDescIndex = -1;
            this.cdvAlarmCMF4.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF4.SelectionStart = 0;
            this.cdvAlarmCMF4.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF4.SmallImageList = null;
            this.cdvAlarmCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF4.TabIndex = 7;
            this.cdvAlarmCMF4.TextBoxToolTipText = "";
            this.cdvAlarmCMF4.TextBoxWidth = 125;
            this.cdvAlarmCMF4.VisibleButton = true;
            this.cdvAlarmCMF4.VisibleColumnHeader = false;
            this.cdvAlarmCMF4.VisibleDescription = false;
            this.cdvAlarmCMF4.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF3
            // 
            this.cdvAlarmCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF3.BtnToolTipText = "";
            this.cdvAlarmCMF3.DescText = "";
            this.cdvAlarmCMF3.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF3.DisplayText = "";
            this.cdvAlarmCMF3.Focusing = null;
            this.cdvAlarmCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF3.Index = 0;
            this.cdvAlarmCMF3.IsViewBtnImage = false;
            this.cdvAlarmCMF3.Location = new System.Drawing.Point(109, 66);
            this.cdvAlarmCMF3.MaxLength = 30;
            this.cdvAlarmCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF3.Name = "cdvAlarmCMF3";
            this.cdvAlarmCMF3.ReadOnly = false;
            this.cdvAlarmCMF3.SearchSubItemIndex = 0;
            this.cdvAlarmCMF3.SelectedDescIndex = -1;
            this.cdvAlarmCMF3.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF3.SelectionStart = 0;
            this.cdvAlarmCMF3.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF3.SmallImageList = null;
            this.cdvAlarmCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF3.TabIndex = 5;
            this.cdvAlarmCMF3.TextBoxToolTipText = "";
            this.cdvAlarmCMF3.TextBoxWidth = 125;
            this.cdvAlarmCMF3.VisibleButton = true;
            this.cdvAlarmCMF3.VisibleColumnHeader = false;
            this.cdvAlarmCMF3.VisibleDescription = false;
            this.cdvAlarmCMF3.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF2
            // 
            this.cdvAlarmCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF2.BtnToolTipText = "";
            this.cdvAlarmCMF2.DescText = "";
            this.cdvAlarmCMF2.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF2.DisplayText = "";
            this.cdvAlarmCMF2.Focusing = null;
            this.cdvAlarmCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF2.Index = 0;
            this.cdvAlarmCMF2.IsViewBtnImage = false;
            this.cdvAlarmCMF2.Location = new System.Drawing.Point(109, 42);
            this.cdvAlarmCMF2.MaxLength = 30;
            this.cdvAlarmCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF2.Name = "cdvAlarmCMF2";
            this.cdvAlarmCMF2.ReadOnly = false;
            this.cdvAlarmCMF2.SearchSubItemIndex = 0;
            this.cdvAlarmCMF2.SelectedDescIndex = -1;
            this.cdvAlarmCMF2.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF2.SelectionStart = 0;
            this.cdvAlarmCMF2.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF2.SmallImageList = null;
            this.cdvAlarmCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF2.TabIndex = 3;
            this.cdvAlarmCMF2.TextBoxToolTipText = "";
            this.cdvAlarmCMF2.TextBoxWidth = 125;
            this.cdvAlarmCMF2.VisibleButton = true;
            this.cdvAlarmCMF2.VisibleColumnHeader = false;
            this.cdvAlarmCMF2.VisibleDescription = false;
            this.cdvAlarmCMF2.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF10
            // 
            this.cdvAlarmCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF10.BtnToolTipText = "";
            this.cdvAlarmCMF10.DescText = "";
            this.cdvAlarmCMF10.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF10.DisplayText = "";
            this.cdvAlarmCMF10.Focusing = null;
            this.cdvAlarmCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF10.Index = 0;
            this.cdvAlarmCMF10.IsViewBtnImage = false;
            this.cdvAlarmCMF10.Location = new System.Drawing.Point(109, 234);
            this.cdvAlarmCMF10.MaxLength = 30;
            this.cdvAlarmCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF10.Name = "cdvAlarmCMF10";
            this.cdvAlarmCMF10.ReadOnly = false;
            this.cdvAlarmCMF10.SearchSubItemIndex = 0;
            this.cdvAlarmCMF10.SelectedDescIndex = -1;
            this.cdvAlarmCMF10.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF10.SelectionStart = 0;
            this.cdvAlarmCMF10.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF10.SmallImageList = null;
            this.cdvAlarmCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF10.TabIndex = 19;
            this.cdvAlarmCMF10.TextBoxToolTipText = "";
            this.cdvAlarmCMF10.TextBoxWidth = 125;
            this.cdvAlarmCMF10.VisibleButton = true;
            this.cdvAlarmCMF10.VisibleColumnHeader = false;
            this.cdvAlarmCMF10.VisibleDescription = false;
            this.cdvAlarmCMF10.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvAlarmCMF1
            // 
            this.cdvAlarmCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAlarmCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAlarmCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAlarmCMF1.BtnToolTipText = "";
            this.cdvAlarmCMF1.DescText = "";
            this.cdvAlarmCMF1.DisplaySubItemIndex = -1;
            this.cdvAlarmCMF1.DisplayText = "";
            this.cdvAlarmCMF1.Focusing = null;
            this.cdvAlarmCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAlarmCMF1.Index = 0;
            this.cdvAlarmCMF1.IsViewBtnImage = false;
            this.cdvAlarmCMF1.Location = new System.Drawing.Point(109, 18);
            this.cdvAlarmCMF1.MaxLength = 30;
            this.cdvAlarmCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAlarmCMF1.Name = "cdvAlarmCMF1";
            this.cdvAlarmCMF1.ReadOnly = false;
            this.cdvAlarmCMF1.SearchSubItemIndex = 0;
            this.cdvAlarmCMF1.SelectedDescIndex = -1;
            this.cdvAlarmCMF1.SelectedSubItemIndex = -1;
            this.cdvAlarmCMF1.SelectionStart = 0;
            this.cdvAlarmCMF1.Size = new System.Drawing.Size(125, 20);
            this.cdvAlarmCMF1.SmallImageList = null;
            this.cdvAlarmCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAlarmCMF1.TabIndex = 1;
            this.cdvAlarmCMF1.TextBoxToolTipText = "";
            this.cdvAlarmCMF1.TextBoxWidth = 125;
            this.cdvAlarmCMF1.VisibleButton = true;
            this.cdvAlarmCMF1.VisibleColumnHeader = false;
            this.cdvAlarmCMF1.VisibleDescription = false;
            this.cdvAlarmCMF1.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvAlarmCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblAlarmCMF10
            // 
            this.lblAlarmCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF10.Location = new System.Drawing.Point(8, 238);
            this.lblAlarmCMF10.Name = "lblAlarmCMF10";
            this.lblAlarmCMF10.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF10.TabIndex = 18;
            this.lblAlarmCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF9
            // 
            this.lblAlarmCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF9.Location = new System.Drawing.Point(8, 214);
            this.lblAlarmCMF9.Name = "lblAlarmCMF9";
            this.lblAlarmCMF9.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF9.TabIndex = 16;
            this.lblAlarmCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF8
            // 
            this.lblAlarmCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF8.Location = new System.Drawing.Point(8, 190);
            this.lblAlarmCMF8.Name = "lblAlarmCMF8";
            this.lblAlarmCMF8.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF8.TabIndex = 14;
            this.lblAlarmCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF7
            // 
            this.lblAlarmCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF7.Location = new System.Drawing.Point(8, 166);
            this.lblAlarmCMF7.Name = "lblAlarmCMF7";
            this.lblAlarmCMF7.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF7.TabIndex = 12;
            this.lblAlarmCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF6
            // 
            this.lblAlarmCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF6.Location = new System.Drawing.Point(8, 142);
            this.lblAlarmCMF6.Name = "lblAlarmCMF6";
            this.lblAlarmCMF6.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF6.TabIndex = 10;
            this.lblAlarmCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF5
            // 
            this.lblAlarmCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF5.Location = new System.Drawing.Point(8, 118);
            this.lblAlarmCMF5.Name = "lblAlarmCMF5";
            this.lblAlarmCMF5.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF5.TabIndex = 8;
            this.lblAlarmCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF4
            // 
            this.lblAlarmCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF4.Location = new System.Drawing.Point(8, 94);
            this.lblAlarmCMF4.Name = "lblAlarmCMF4";
            this.lblAlarmCMF4.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF4.TabIndex = 6;
            this.lblAlarmCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF3
            // 
            this.lblAlarmCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF3.Location = new System.Drawing.Point(8, 70);
            this.lblAlarmCMF3.Name = "lblAlarmCMF3";
            this.lblAlarmCMF3.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF3.TabIndex = 4;
            this.lblAlarmCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF2
            // 
            this.lblAlarmCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF2.Location = new System.Drawing.Point(8, 46);
            this.lblAlarmCMF2.Name = "lblAlarmCMF2";
            this.lblAlarmCMF2.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF2.TabIndex = 2;
            this.lblAlarmCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAlarmCMF1
            // 
            this.lblAlarmCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmCMF1.Location = new System.Drawing.Point(8, 22);
            this.lblAlarmCMF1.Name = "lblAlarmCMF1";
            this.lblAlarmCMF1.Size = new System.Drawing.Size(98, 14);
            this.lblAlarmCMF1.TabIndex = 0;
            this.lblAlarmCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisAlarm
            // 
            this.lisAlarm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAlarm,
            this.colAlmDesc});
            this.lisAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAlarm.EnableSort = true;
            this.lisAlarm.EnableSortIcon = true;
            this.lisAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAlarm.FullRowSelect = true;
            this.lisAlarm.Location = new System.Drawing.Point(0, 42);
            this.lisAlarm.MultiSelect = false;
            this.lisAlarm.Name = "lisAlarm";
            this.lisAlarm.Size = new System.Drawing.Size(232, 471);
            this.lisAlarm.TabIndex = 0;
            this.lisAlarm.UseCompatibleStateImageBehavior = false;
            this.lisAlarm.View = System.Windows.Forms.View.Details;
            this.lisAlarm.SelectedIndexChanged += new System.EventHandler(this.lisAlarm_SelectedIndexChanged);
            // 
            // colAlarm
            // 
            this.colAlarm.Text = "Alarm";
            this.colAlarm.Width = 150;
            // 
            // colAlmDesc
            // 
            this.colAlmDesc.Text = "Description";
            this.colAlmDesc.Width = 150;
            // 
            // frmALMSetupAlarm
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmALMSetupAlarm";
            this.Text = "Alarm Setup";
            this.Activated += new System.EventHandler(this.frmALMSetupAlarm_Activated);
            this.Load += new System.EventHandler(this.frmALMSetupAlarm_Load);
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
            this.pnlContition.ResumeLayout(false);
            this.grpCondition.ResumeLayout(false);
            this.grpCondition.PerformLayout();
            this.pnlAlarm.ResumeLayout(false);
            this.grpAlarm.ResumeLayout(false);
            this.grpAlarm.PerformLayout();
            this.pnlTab.ResumeLayout(false);
            this.tabAlarm.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlRelate.ResumeLayout(false);
            this.grpLotAction.ResumeLayout(false);
            this.grpLotAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).EndInit();
            this.grpAlarmAction.ResumeLayout(false);
            this.grpAlarmAction.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.tbpRecvInfo.ResumeLayout(false);
            this.pnlRecvInfo.ResumeLayout(false);
            this.grpReceive.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlRecMid.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.grpLotAlarm.ResumeLayout(false);
            this.grpLotAlarm.PerformLayout();
            this.tbpMessage.ResumeLayout(false);
            this.tbpMessage.PerformLayout();
            this.grpMsgData.ResumeLayout(false);
            this.grpMsgData.PerformLayout();
            this.tbpComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdComment_Sheet1)).EndInit();
            this.tbpPDF.ResumeLayout(false);
            this.pnlPDFBottom.ResumeLayout(false);
            this.tbpImage.ResumeLayout(false);
            this.grpImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.pnlImgBottom.ResumeLayout(false);
            this.tbpEvent.ResumeLayout(false);
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus1)).EndInit();
            this.grpResComment.ResumeLayout(false);
            this.grpResComment.PerformLayout();
            this.grpEvent.ResumeLayout(false);
            this.grpEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEvent)).EndInit();
            this.tbpClearEvent.ResumeLayout(false);
            this.grpClearChgStatus.ResumeLayout(false);
            this.grpClearChgStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearChangeStatus1)).EndInit();
            this.grpClearResComment.ResumeLayout(false);
            this.grpClearResComment.PerformLayout();
            this.grpClearEvent.ResumeLayout(false);
            this.grpClearEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvClearEvent)).EndInit();
            this.tbpTranCMF.ResumeLayout(false);
            this.grpTranCMF.ResumeLayout(false);
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
            this.tbpAlarmGroup.ResumeLayout(false);
            this.grpAlarmGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).EndInit();
            this.tbpAlarmCMF.ResumeLayout(false);
            this.grpAlarmCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAlarmCMF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContition;
        private Miracom.UI.Controls.MCListView.MCListView lisAlarm;
        private System.Windows.Forms.ColumnHeader colAlarm;
        private System.Windows.Forms.GroupBox grpCondition;
        private System.Windows.Forms.ComboBox cboAlarmType;
        private System.Windows.Forms.Panel pnlAlarm;
        private System.Windows.Forms.Label lblAlarmType;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.TabControl tabAlarm;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Panel pnlRelate;
        private System.Windows.Forms.GroupBox grpAlarmAction;
        private System.Windows.Forms.CheckBox chkMail;
        private System.Windows.Forms.CheckBox chkMessage;
        private System.Windows.Forms.CheckBox chkDisplay;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.RadioButton rbnWarning;
        private System.Windows.Forms.RadioButton rbnError;
        private System.Windows.Forms.RadioButton rbnInformation;
        private System.Windows.Forms.TabPage tbpMessage;
        private System.Windows.Forms.GroupBox grpMsgData;
        private System.Windows.Forms.TextBox txtMsg3;
        private System.Windows.Forms.TextBox txtMsg2;
        private System.Windows.Forms.TextBox txtMsg1;
        private System.Windows.Forms.Label lblMsg_3;
        private System.Windows.Forms.Label lblMsg_2;
        private System.Windows.Forms.Label lblMsg_1;
        private System.Windows.Forms.TabPage tbpEvent;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblChgStatus3;
        private System.Windows.Forms.Label lblChgStatus2;
        private System.Windows.Forms.Label lblChgStatus8;
        private System.Windows.Forms.Label lblChgStatus7;
        private System.Windows.Forms.Label lblChgStatus4;
        private System.Windows.Forms.Label lblChgStatus6;
        private System.Windows.Forms.Label lblChgStatus5;
        private System.Windows.Forms.Label lblChgStatus1;
        private System.Windows.Forms.Label lblChgStatus10;
        private System.Windows.Forms.Label lblChgStatus9;
        private System.Windows.Forms.GroupBox grpResComment;
        private System.Windows.Forms.TextBox txtResComment;
        private System.Windows.Forms.Label lblResComment;
        private System.Windows.Forms.GroupBox grpEvent;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEvent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TabPage tbpTranCMF;
        private System.Windows.Forms.ColumnHeader colAlmDesc;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.GroupBox grpAlarm;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtAlarmID;
        private System.Windows.Forms.Label lblAlarmID;
        private System.Windows.Forms.CheckBox chkResAlarmFlag;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus1;
        private System.Windows.Forms.GroupBox grpTranCMF;
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
        private System.Windows.Forms.GroupBox grpLotAction;
        private Miracom.MESCore.Controls.udcOperation cdvReworkOper;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvReworkFlow;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvReturnFlow;
        private Miracom.MESCore.Controls.udcOperation cdvReturnOper;
        private System.Windows.Forms.TextBox txtHoldPassword;
        private System.Windows.Forms.Label lblHoldPassword;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvHoldCode;
        private System.Windows.Forms.Label lblHoldCode;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblTranCode;
        private System.Windows.Forms.ComboBox cboTran;
        private System.Windows.Forms.TabPage tbpRecvInfo;
        private System.Windows.Forms.Panel pnlRecvInfo;
        private System.Windows.Forms.GroupBox grpReceive;
        private System.Windows.Forms.Panel panel1;
        private Miracom.UI.Controls.MCListView.MCListView lisRecvList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel pnlRecMid;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Panel panel3;
        private Miracom.UI.Controls.MCListView.MCListView lisPrvGrpList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private Miracom.UI.Controls.MCListView.MCListView lisUserList;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private Miracom.UI.Controls.MCListView.MCListView lisSecGrpList;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkShift4;
        private System.Windows.Forms.CheckBox chkShift3;
        private System.Windows.Forms.CheckBox chkShift2;
        private System.Windows.Forms.CheckBox chkShift1;
        private System.Windows.Forms.RadioButton rbnPrvGroup;
        private System.Windows.Forms.RadioButton rbnSecGroup;
        private System.Windows.Forms.RadioButton rbnUser;
        private System.Windows.Forms.GroupBox grpLotAlarm;
        private System.Windows.Forms.CheckBox chkSendToUser;
        private Miracom.MESCore.Controls.udcOperation cdvReworkStopOper;
        private System.Windows.Forms.ComboBox cboReturnOption;
        private System.Windows.Forms.Label lblReturnOption;
        private System.Windows.Forms.TabPage tbpComment;
        private System.Windows.Forms.TabPage tbpPDF;
        private System.Windows.Forms.TabPage tbpImage;
        private System.Windows.Forms.Panel pnlPDF;
        private System.Windows.Forms.Button btnPDFOpen;
        private System.Windows.Forms.Panel pnlPDFBottom;
        private FarPoint.Win.Spread.FpSpread spdComment;
        private FarPoint.Win.Spread.SheetView spdComment_Sheet1;
        private System.Windows.Forms.Panel pnlImgBottom;
        private System.Windows.Forms.Button btnImgOpen;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.GroupBox grpImage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnPDFRemove;
        private System.Windows.Forms.Button btnImgRemove;
        private System.Windows.Forms.TabPage tbpClearEvent;
        private System.Windows.Forms.GroupBox grpClearChgStatus;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus10;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus9;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus8;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus7;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus6;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus5;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus4;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus3;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus2;
        private UI.Controls.MCCodeView.MCCodeView cdvClearChangeStatus1;
        private System.Windows.Forms.Label lblClearChgStatus3;
        private System.Windows.Forms.Label lblClearChgStatus2;
        private System.Windows.Forms.Label lblClearChgStatus8;
        private System.Windows.Forms.Label lblClearChgStatus7;
        private System.Windows.Forms.Label lblClearChgStatus4;
        private System.Windows.Forms.Label lblClearChgStatus6;
        private System.Windows.Forms.Label lblClearChgStatus5;
        private System.Windows.Forms.Label lblClearChgStatus1;
        private System.Windows.Forms.Label lblClearChgStatus10;
        private System.Windows.Forms.Label lblClearChgStatus9;
        private System.Windows.Forms.GroupBox grpClearResComment;
        private System.Windows.Forms.TextBox txtClearResComment;
        private System.Windows.Forms.Label lblClearComment;
        private System.Windows.Forms.GroupBox grpClearEvent;
        private UI.Controls.MCCodeView.MCCodeView cdvClearEvent;
        private System.Windows.Forms.Label lblClearEvent;
        private System.Windows.Forms.TabPage tbpAlarmGroup;
        private System.Windows.Forms.TabPage tbpAlarmCMF;
        private System.Windows.Forms.GroupBox grpAlarmGroup;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup10;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup8;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup7;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup6;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup5;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup4;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup3;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup2;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup1;
        private System.Windows.Forms.Label lblGroup10;
        private System.Windows.Forms.Label lblGroup9;
        private System.Windows.Forms.Label lblGroup8;
        private System.Windows.Forms.Label lblGroup7;
        private System.Windows.Forms.Label lblGroup6;
        private System.Windows.Forms.Label lblGroup5;
        private System.Windows.Forms.Label lblGroup4;
        private System.Windows.Forms.Label lblGroup3;
        private System.Windows.Forms.Label lblGroup2;
        private System.Windows.Forms.Label lblGroup1;
        private UI.Controls.MCCodeView.MCCodeView cdvGroup9;
        private System.Windows.Forms.GroupBox grpAlarmCMF;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF19;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF18;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF17;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF16;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF15;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF14;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF13;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF12;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF20;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF11;
        protected System.Windows.Forms.Label lblAlarmCMF20;
        protected System.Windows.Forms.Label lblAlarmCMF19;
        protected System.Windows.Forms.Label lblAlarmCMF18;
        protected System.Windows.Forms.Label lblAlarmCMF17;
        protected System.Windows.Forms.Label lblAlarmCMF16;
        protected System.Windows.Forms.Label lblAlarmCMF15;
        protected System.Windows.Forms.Label lblAlarmCMF14;
        protected System.Windows.Forms.Label lblAlarmCMF13;
        protected System.Windows.Forms.Label lblAlarmCMF12;
        protected System.Windows.Forms.Label lblAlarmCMF11;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF9;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF8;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF7;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF6;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF5;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF4;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF3;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF2;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF10;
        protected UI.Controls.MCCodeView.MCCodeView cdvAlarmCMF1;
        protected System.Windows.Forms.Label lblAlarmCMF10;
        protected System.Windows.Forms.Label lblAlarmCMF9;
        protected System.Windows.Forms.Label lblAlarmCMF8;
        protected System.Windows.Forms.Label lblAlarmCMF7;
        protected System.Windows.Forms.Label lblAlarmCMF6;
        protected System.Windows.Forms.Label lblAlarmCMF5;
        protected System.Windows.Forms.Label lblAlarmCMF4;
        protected System.Windows.Forms.Label lblAlarmCMF3;
        protected System.Windows.Forms.Label lblAlarmCMF2;
        protected System.Windows.Forms.Label lblAlarmCMF1;
    }
}
