namespace Miracom.WIPCore
{
    partial class frmWIPTranMultiQaGate
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
            this.pnlConditionInfo = new System.Windows.Forms.Panel();
            this.grpConditionInfo = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranDateTime = new System.Windows.Forms.CheckBox();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.pnlCheck = new System.Windows.Forms.Panel();
            this.grpCheck = new System.Windows.Forms.GroupBox();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.pnlLotList = new System.Windows.Forms.Panel();
            this.grpLotList = new System.Windows.Forms.GroupBox();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOwnerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHoldFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHoldCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperInQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperInQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperInQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTransitFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnitExistFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkRetFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkRetOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkEndFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkEndOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkRetClearFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNstdFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNstdRetFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNstdRetOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNstdTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRepFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRepOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStrRetFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStrRetFlowSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStrRetOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSampleFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSampleWaitFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSampleResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSplitFromLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShipCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShipTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrgDueTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSchDueTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFactoryInTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowInTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperInTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResvResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBatchID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBatchSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddOrder1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddOrder2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddOrder3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotCmf20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBomSetID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBomSetVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBomActiveSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBomHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotDelFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotDelTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotDelReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastTranCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastTranTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastActiveHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnView = new System.Windows.Forms.Button();
            this.grpLoss = new System.Windows.Forms.GroupBox();
            this.txtActionDesc = new System.Windows.Forms.TextBox();
            this.txtPassFail = new System.Windows.Forms.TextBox();
            this.lblResultType = new System.Windows.Forms.Label();
            this.chkSMPUnit2Flag = new System.Windows.Forms.CheckBox();
            this.chkSMPUnit1Flag = new System.Windows.Forms.CheckBox();
            this.grpSMPUnit2 = new System.Windows.Forms.GroupBox();
            this.txtUnit2SMPSelType = new System.Windows.Forms.TextBox();
            this.lblUnit2SMPSelType = new System.Windows.Forms.Label();
            this.txtUnit2SMPSize = new System.Windows.Forms.TextBox();
            this.lblUnit2SMPSize = new System.Windows.Forms.Label();
            this.txtUnit2SMPSizeType = new System.Windows.Forms.TextBox();
            this.lblUnit2SMPSizeType = new System.Windows.Forms.Label();
            this.grpSMPUnit1 = new System.Windows.Forms.GroupBox();
            this.txtUnit1SMPSelType = new System.Windows.Forms.TextBox();
            this.lblUnit1SMPSelType = new System.Windows.Forms.Label();
            this.txtUnit1SMPSize = new System.Windows.Forms.TextBox();
            this.lblUnit1SMPSize = new System.Windows.Forms.Label();
            this.txtUnit1SMPSizeType = new System.Windows.Forms.TextBox();
            this.lblUnit1SMPSizeType = new System.Windows.Forms.Label();
            this.txtSMPDesc = new System.Windows.Forms.TextBox();
            this.txtSMPRule = new System.Windows.Forms.TextBox();
            this.lblSMPRule = new System.Windows.Forms.Label();
            this.txtQAOper = new System.Windows.Forms.TextBox();
            this.lblQAGateOper = new System.Windows.Forms.Label();
            this.txtSMPType = new System.Windows.Forms.TextBox();
            this.lblSMPType = new System.Windows.Forms.Label();
            this.txtTestCount = new System.Windows.Forms.TextBox();
            this.lblTestCount = new System.Windows.Forms.Label();
            this.txtIRRMRR = new System.Windows.Forms.TextBox();
            this.txtInspector = new System.Windows.Forms.TextBox();
            this.lblInspector = new System.Windows.Forms.Label();
            this.cdvShift = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAction = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblIRRMRR = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblPassFlag = new System.Windows.Forms.Label();
            this.txtSMPSize2 = new System.Windows.Forms.TextBox();
            this.txtSMPSize1 = new System.Windows.Forms.TextBox();
            this.lblSMPSize1 = new System.Windows.Forms.Label();
            this.lblSMPSize2 = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
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
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlConditionInfo.SuspendLayout();
            this.grpConditionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            this.panel11.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            this.pnlCheck.SuspendLayout();
            this.grpCheck.SuspendLayout();
            this.pnlLotList.SuspendLayout();
            this.grpLotList.SuspendLayout();
            this.grpLoss.SuspendLayout();
            this.grpSMPUnit2.SuspendLayout();
            this.grpSMPUnit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.SuspendLayout();
            // 
            // tabTran
            // 
            this.tabTran.Size = new System.Drawing.Size(736, 521);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 495);
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.pnlLotList);
            this.pnlTranInfo.Controls.Add(this.pnlCheck);
            this.pnlTranInfo.Controls.Add(this.pnlConditionInfo);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 229);
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.splitter1);
            this.pnlComment.Controls.Add(this.grpLoss);
            this.pnlComment.Location = new System.Drawing.Point(0, 229);
            this.pnlComment.Size = new System.Drawing.Size(728, 263);
            this.pnlComment.TabIndex = 3;
            this.pnlComment.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlComment_Paint);
            this.pnlComment.Controls.SetChildIndex(this.grpComment, 0);
            this.pnlComment.Controls.SetChildIndex(this.grpLoss, 0);
            this.pnlComment.Controls.SetChildIndex(this.splitter1, 0);
            // 
            // grpComment
            // 
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpComment.Location = new System.Drawing.Point(3, 231);
            this.grpComment.Size = new System.Drawing.Size(722, 32);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(13, 13);
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 1;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(118, 10);
            this.txtComment.Size = new System.Drawing.Size(598, 20);
            this.txtComment.TabIndex = 2;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 511);
            // 
            // grpCMF
            // 
            this.grpCMF.Size = new System.Drawing.Size(722, 467);
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(558, 4);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(649, 4);
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 524);
            this.pnlBottom.Size = new System.Drawing.Size(742, 34);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 524);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Multi End Lot";
            // 
            // pnlConditionInfo
            // 
            this.pnlConditionInfo.Controls.Add(this.grpConditionInfo);
            this.pnlConditionInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConditionInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlConditionInfo.Name = "pnlConditionInfo";
            this.pnlConditionInfo.Size = new System.Drawing.Size(722, 62);
            this.pnlConditionInfo.TabIndex = 0;
            // 
            // grpConditionInfo
            // 
            this.grpConditionInfo.Controls.Add(this.cdvFlow);
            this.grpConditionInfo.Controls.Add(this.cdvMaterial);
            this.grpConditionInfo.Controls.Add(this.cdvOperation);
            this.grpConditionInfo.Controls.Add(this.lblOperation);
            this.grpConditionInfo.Controls.Add(this.panel11);
            this.grpConditionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConditionInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpConditionInfo.Location = new System.Drawing.Point(0, 0);
            this.grpConditionInfo.Name = "grpConditionInfo";
            this.grpConditionInfo.Size = new System.Drawing.Size(722, 62);
            this.grpConditionInfo.TabIndex = 0;
            this.grpConditionInfo.TabStop = false;
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = true;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 90;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(342, 37);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(270, 21);
            this.cdvFlow.TabIndex = 14;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 21;
            this.cdvFlow.WidthFlowAndSequence = 180;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = true;
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
            this.cdvMaterial.Location = new System.Drawing.Point(12, 37);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(270, 21);
            this.cdvMaterial.TabIndex = 13;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDefaultFilter = true;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 21;
            this.cdvMaterial.WidthLabel = 90;
            this.cdvMaterial.WidthMaterialAndVersion = 180;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.VersionChanged += new System.EventHandler(this.cdvMaterial_VersionChanged_1);
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
            this.cdvOperation.Location = new System.Drawing.Point(102, 13);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(180, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 1;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 180;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOperation_SelectedItemChanged);
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(12, 15);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(62, 13);
            this.lblOperation.TabIndex = 0;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.Controls.Add(this.pnlTranTime);
            this.panel11.Location = new System.Drawing.Point(677, 11);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(24, 23);
            this.panel11.TabIndex = 12;
            this.panel11.Visible = false;
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranTime);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranDate);
            this.pnlTranTime.Location = new System.Drawing.Point(11, 3);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(10, 32);
            this.pnlTranTime.TabIndex = 5;
            this.pnlTranTime.Visible = false;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.Location = new System.Drawing.Point(139, 0);
            this.txtTranDateTime.MaxLength = 30;
            this.txtTranDateTime.Name = "txtTranDateTime";
            this.txtTranDateTime.ReadOnly = true;
            this.txtTranDateTime.Size = new System.Drawing.Size(157, 20);
            this.txtTranDateTime.TabIndex = 1;
            this.txtTranDateTime.TabStop = false;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranTime.Checked = false;
            this.dtpTranTime.CustomFormat = "HH:mm:ss";
            this.dtpTranTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranTime.Location = new System.Drawing.Point(-61, 0);
            this.dtpTranTime.Name = "dtpTranTime";
            this.dtpTranTime.ShowUpDown = true;
            this.dtpTranTime.Size = new System.Drawing.Size(71, 20);
            this.dtpTranTime.TabIndex = 2;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTranDateTime.Location = new System.Drawing.Point(3, 1);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            this.chkTranDateTime.TabIndex = 0;
            this.chkTranDateTime.Text = "Transaction Time";
            this.chkTranDateTime.CheckedChanged += new System.EventHandler(this.chkTranDateTime_CheckedChanged);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranDate.Checked = false;
            this.dtpTranDate.CustomFormat = "";
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTranDate.Location = new System.Drawing.Point(-147, 0);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(86, 20);
            this.dtpTranDate.TabIndex = 2;
            // 
            // pnlCheck
            // 
            this.pnlCheck.Controls.Add(this.grpCheck);
            this.pnlCheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCheck.Location = new System.Drawing.Point(3, 65);
            this.pnlCheck.Name = "pnlCheck";
            this.pnlCheck.Padding = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.pnlCheck.Size = new System.Drawing.Size(90, 164);
            this.pnlCheck.TabIndex = 1;
            // 
            // grpCheck
            // 
            this.grpCheck.Controls.Add(this.btnUncheckAll);
            this.grpCheck.Controls.Add(this.btnCheckAll);
            this.grpCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCheck.Location = new System.Drawing.Point(0, 4);
            this.grpCheck.Name = "grpCheck";
            this.grpCheck.Size = new System.Drawing.Size(86, 160);
            this.grpCheck.TabIndex = 0;
            this.grpCheck.TabStop = false;
            this.grpCheck.Text = "Check Method";
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUncheckAll.Location = new System.Drawing.Point(8, 44);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(70, 26);
            this.btnUncheckAll.TabIndex = 1;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCheckAll.Location = new System.Drawing.Point(8, 16);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(70, 26);
            this.btnCheckAll.TabIndex = 0;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // pnlLotList
            // 
            this.pnlLotList.Controls.Add(this.grpLotList);
            this.pnlLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotList.Location = new System.Drawing.Point(93, 65);
            this.pnlLotList.Name = "pnlLotList";
            this.pnlLotList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlLotList.Size = new System.Drawing.Size(632, 164);
            this.pnlLotList.TabIndex = 1;
            // 
            // grpLotList
            // 
            this.grpLotList.Controls.Add(this.lisLotList);
            this.grpLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotList.Location = new System.Drawing.Point(0, 4);
            this.grpLotList.Name = "grpLotList";
            this.grpLotList.Size = new System.Drawing.Size(632, 160);
            this.grpLotList.TabIndex = 2;
            this.grpLotList.TabStop = false;
            this.grpLotList.Text = "Lot List";
            // 
            // lisLotList
            // 
            this.lisLotList.AllowColumnReorder = true;
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colLotID,
            this.colMaterial,
            this.colMatVersion,
            this.colFlow,
            this.colFlowSeq,
            this.colOperation,
            this.colQty1,
            this.colQty2,
            this.colQty3,
            this.colLotType,
            this.colOwnerCode,
            this.colCreateCode,
            this.colPriority,
            this.colLotStatus,
            this.colHoldFlag,
            this.colHoldCode,
            this.colCreateQty1,
            this.colCreateQty2,
            this.colCreateQty3,
            this.colOperInQty1,
            this.colOperInQty2,
            this.colOperInQty3,
            this.colInvFlag,
            this.colTransitFlag,
            this.colUnitExistFlag,
            this.colInvUnit,
            this.colRwkFlag,
            this.colRwkCode,
            this.colRwkCount,
            this.colRwkRetFlow,
            this.colRwkRetOper,
            this.colRwkEndFlow,
            this.colRwkEndOper,
            this.colRwkRetClearFlag,
            this.colRwkTime,
            this.colNstdFlag,
            this.colNstdRetFlow,
            this.colNstdRetOper,
            this.colNstdTime,
            this.colRepFlag,
            this.colRepOper,
            this.colStrRetFlow,
            this.colStrRetFlowSeq,
            this.colStrRetOper,
            this.colStartFlag,
            this.colStartTime,
            this.colStartResID,
            this.colEndFlag,
            this.colEndTime,
            this.colEndResID,
            this.colSampleFlag,
            this.colSampleWaitFlag,
            this.colSampleResult,
            this.colSplitFromLotID,
            this.colShipCode,
            this.colShipTime,
            this.colOrgDueTime,
            this.colSchDueTime,
            this.colCreateTime,
            this.colFactoryInTime,
            this.colFlowInTime,
            this.colOperInTime,
            this.colResvResID,
            this.colBatchID,
            this.colBatchSeq,
            this.colOrderID,
            this.colAddOrder1,
            this.colAddOrder2,
            this.colAddOrder3,
            this.colLocation,
            this.colLotCmf1,
            this.colLotCmf2,
            this.colLotCmf3,
            this.colLotCmf4,
            this.colLotCmf5,
            this.colLotCmf6,
            this.colLotCmf7,
            this.colLotCmf8,
            this.colLotCmf9,
            this.colLotCmf10,
            this.colLotCmf11,
            this.colLotCmf12,
            this.colLotCmf13,
            this.colLotCmf14,
            this.colLotCmf15,
            this.colLotCmf16,
            this.colLotCmf17,
            this.colLotCmf18,
            this.colLotCmf19,
            this.colLotCmf20,
            this.colBomSetID,
            this.colBomSetVersion,
            this.colBomActiveSeq,
            this.colBomHistSeq,
            this.colLotDelFlag,
            this.colLotDelTime,
            this.colLotDelReason,
            this.colLastTranCode,
            this.colLastTranTime,
            this.colLastComment,
            this.colLastActiveHistSeq,
            this.colLastHistSeq});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.EnableSort = true;
            this.lisLotList.EnableSortIcon = true;
            this.lisLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotList.FullRowSelect = true;
            this.lisLotList.Location = new System.Drawing.Point(3, 16);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(626, 141);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 80;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 120;
            // 
            // colMaterial
            // 
            this.colMaterial.Text = "Material";
            this.colMaterial.Width = 100;
            // 
            // colMatVersion
            // 
            this.colMatVersion.Text = "Mat Ver";
            // 
            // colFlow
            // 
            this.colFlow.Text = "Flow";
            this.colFlow.Width = 90;
            // 
            // colFlowSeq
            // 
            this.colFlowSeq.Text = "Flow Seq";
            // 
            // colOperation
            // 
            this.colOperation.Text = "Operation";
            this.colOperation.Width = 80;
            // 
            // colQty1
            // 
            this.colQty1.Text = "Qty 1";
            this.colQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colQty2
            // 
            this.colQty2.Text = "Qty 2";
            this.colQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colQty3
            // 
            this.colQty3.Text = "Qty3";
            this.colQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colLotType
            // 
            this.colLotType.Text = "Lot Type";
            this.colLotType.Width = 70;
            // 
            // colOwnerCode
            // 
            this.colOwnerCode.Text = "Owner Code";
            this.colOwnerCode.Width = 90;
            // 
            // colCreateCode
            // 
            this.colCreateCode.Text = "Create Code";
            this.colCreateCode.Width = 90;
            // 
            // colPriority
            // 
            this.colPriority.Text = "Priority";
            // 
            // colLotStatus
            // 
            this.colLotStatus.Text = "Lot Status";
            this.colLotStatus.Width = 80;
            // 
            // colHoldFlag
            // 
            this.colHoldFlag.Text = "Hold Flag";
            this.colHoldFlag.Width = 80;
            // 
            // colHoldCode
            // 
            this.colHoldCode.Text = "Hold Code";
            this.colHoldCode.Width = 80;
            // 
            // colCreateQty1
            // 
            this.colCreateQty1.Text = "Create Qty 1";
            this.colCreateQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCreateQty1.Width = 100;
            // 
            // colCreateQty2
            // 
            this.colCreateQty2.Text = "Create Qty 2";
            this.colCreateQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCreateQty2.Width = 100;
            // 
            // colCreateQty3
            // 
            this.colCreateQty3.Text = "Create Qty 3";
            this.colCreateQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCreateQty3.Width = 100;
            // 
            // colOperInQty1
            // 
            this.colOperInQty1.Text = "Oper In Qty 1";
            this.colOperInQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOperInQty1.Width = 100;
            // 
            // colOperInQty2
            // 
            this.colOperInQty2.Text = "Oper In Qty 2";
            this.colOperInQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOperInQty2.Width = 100;
            // 
            // colOperInQty3
            // 
            this.colOperInQty3.Text = "Oper In Qty 3";
            this.colOperInQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOperInQty3.Width = 100;
            // 
            // colInvFlag
            // 
            this.colInvFlag.Text = "Inventory Flag";
            this.colInvFlag.Width = 100;
            // 
            // colTransitFlag
            // 
            this.colTransitFlag.Text = "Transit Flag";
            this.colTransitFlag.Width = 100;
            // 
            // colUnitExistFlag
            // 
            this.colUnitExistFlag.Text = "Unit Exist Flag";
            this.colUnitExistFlag.Width = 100;
            // 
            // colInvUnit
            // 
            this.colInvUnit.Text = "Inv Unit";
            // 
            // colRwkFlag
            // 
            this.colRwkFlag.Text = "Rework Flag";
            this.colRwkFlag.Width = 120;
            // 
            // colRwkCode
            // 
            this.colRwkCode.Text = "Rework Code";
            this.colRwkCode.Width = 120;
            // 
            // colRwkCount
            // 
            this.colRwkCount.Text = "Rework Count";
            this.colRwkCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRwkCount.Width = 120;
            // 
            // colRwkRetFlow
            // 
            this.colRwkRetFlow.Text = "Rework Ret Flow";
            this.colRwkRetFlow.Width = 120;
            // 
            // colRwkRetOper
            // 
            this.colRwkRetOper.Text = "Rework Ret Oper";
            this.colRwkRetOper.Width = 120;
            // 
            // colRwkEndFlow
            // 
            this.colRwkEndFlow.Text = "Rework End Flow";
            this.colRwkEndFlow.Width = 120;
            // 
            // colRwkEndOper
            // 
            this.colRwkEndOper.Text = "Rework End Oper";
            this.colRwkEndOper.Width = 120;
            // 
            // colRwkRetClearFlag
            // 
            this.colRwkRetClearFlag.Text = "Rework Ret Clear Flag";
            this.colRwkRetClearFlag.Width = 155;
            // 
            // colRwkTime
            // 
            this.colRwkTime.Text = "Rework Time";
            this.colRwkTime.Width = 120;
            // 
            // colNstdFlag
            // 
            this.colNstdFlag.Text = "NSTD Flag";
            this.colNstdFlag.Width = 120;
            // 
            // colNstdRetFlow
            // 
            this.colNstdRetFlow.Text = "NSTD Ret Flow";
            this.colNstdRetFlow.Width = 120;
            // 
            // colNstdRetOper
            // 
            this.colNstdRetOper.Text = "NSTD Ret Oper";
            this.colNstdRetOper.Width = 120;
            // 
            // colNstdTime
            // 
            this.colNstdTime.Text = "NSTD Time";
            this.colNstdTime.Width = 120;
            // 
            // colRepFlag
            // 
            this.colRepFlag.Text = "Repair Flag";
            this.colRepFlag.Width = 100;
            // 
            // colRepOper
            // 
            this.colRepOper.Text = "Repair Return Oper";
            this.colRepOper.Width = 120;
            // 
            // colStrRetFlow
            // 
            this.colStrRetFlow.Text = "Store Return Flow";
            this.colStrRetFlow.Width = 120;
            // 
            // colStrRetFlowSeq
            // 
            this.colStrRetFlowSeq.Text = "Store Return Flow Seq";
            this.colStrRetFlowSeq.Width = 120;
            // 
            // colStrRetOper
            // 
            this.colStrRetOper.Text = "Store Return Oper";
            this.colStrRetOper.Width = 120;
            // 
            // colStartFlag
            // 
            this.colStartFlag.Text = "Start Flag";
            this.colStartFlag.Width = 70;
            // 
            // colStartTime
            // 
            this.colStartTime.Text = "Start Time";
            this.colStartTime.Width = 120;
            // 
            // colStartResID
            // 
            this.colStartResID.Text = "Start Res ID";
            this.colStartResID.Width = 80;
            // 
            // colEndFlag
            // 
            this.colEndFlag.Text = "End Flag";
            this.colEndFlag.Width = 70;
            // 
            // colEndTime
            // 
            this.colEndTime.Text = "End Time";
            this.colEndTime.Width = 120;
            // 
            // colEndResID
            // 
            this.colEndResID.Text = "End Res ID";
            this.colEndResID.Width = 80;
            // 
            // colSampleFlag
            // 
            this.colSampleFlag.Text = "Sample Flag";
            this.colSampleFlag.Width = 100;
            // 
            // colSampleWaitFlag
            // 
            this.colSampleWaitFlag.Text = "Sample Wait Flag";
            this.colSampleWaitFlag.Width = 110;
            // 
            // colSampleResult
            // 
            this.colSampleResult.Text = "Sample Result";
            this.colSampleResult.Width = 100;
            // 
            // colSplitFromLotID
            // 
            this.colSplitFromLotID.Text = "From To Lot ID";
            this.colSplitFromLotID.Width = 120;
            // 
            // colShipCode
            // 
            this.colShipCode.Text = "Ship Code";
            this.colShipCode.Width = 80;
            // 
            // colShipTime
            // 
            this.colShipTime.Text = "Ship Time";
            this.colShipTime.Width = 120;
            // 
            // colOrgDueTime
            // 
            this.colOrgDueTime.Text = "Original Due Time";
            this.colOrgDueTime.Width = 120;
            // 
            // colSchDueTime
            // 
            this.colSchDueTime.Text = "Scheduled Due Time";
            this.colSchDueTime.Width = 145;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Text = "Create Time";
            this.colCreateTime.Width = 120;
            // 
            // colFactoryInTime
            // 
            this.colFactoryInTime.Text = "Factory In Time";
            this.colFactoryInTime.Width = 120;
            // 
            // colFlowInTime
            // 
            this.colFlowInTime.Text = "Flow In Time";
            this.colFlowInTime.Width = 120;
            // 
            // colOperInTime
            // 
            this.colOperInTime.Text = "Oper In Time";
            this.colOperInTime.Width = 120;
            // 
            // colResvResID
            // 
            this.colResvResID.Text = "Reserve Res ID";
            this.colResvResID.Width = 120;
            // 
            // colBatchID
            // 
            this.colBatchID.Text = "Batch ID";
            // 
            // colBatchSeq
            // 
            this.colBatchSeq.Text = "Batch Seq";
            this.colBatchSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBatchSeq.Width = 70;
            // 
            // colOrderID
            // 
            this.colOrderID.Text = "Order ID";
            this.colOrderID.Width = 100;
            // 
            // colAddOrder1
            // 
            this.colAddOrder1.Text = "Add Order ID 1";
            this.colAddOrder1.Width = 100;
            // 
            // colAddOrder2
            // 
            this.colAddOrder2.Text = "Add Order ID 2";
            this.colAddOrder2.Width = 100;
            // 
            // colAddOrder3
            // 
            this.colAddOrder3.Text = "Add Order ID 3";
            this.colAddOrder3.Width = 100;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 80;
            // 
            // colLotCmf1
            // 
            this.colLotCmf1.Text = "Lot Cmf 1";
            this.colLotCmf1.Width = 100;
            // 
            // colLotCmf2
            // 
            this.colLotCmf2.Text = "Lot Cmf 2";
            this.colLotCmf2.Width = 100;
            // 
            // colLotCmf3
            // 
            this.colLotCmf3.Text = "Lot Cmf 3";
            this.colLotCmf3.Width = 100;
            // 
            // colLotCmf4
            // 
            this.colLotCmf4.Text = "Lot Cmf 4";
            this.colLotCmf4.Width = 100;
            // 
            // colLotCmf5
            // 
            this.colLotCmf5.Text = "Lot Cmf 5";
            this.colLotCmf5.Width = 100;
            // 
            // colLotCmf6
            // 
            this.colLotCmf6.Text = "Lot Cmf 6";
            this.colLotCmf6.Width = 100;
            // 
            // colLotCmf7
            // 
            this.colLotCmf7.Text = "Lot Cmf 7";
            this.colLotCmf7.Width = 100;
            // 
            // colLotCmf8
            // 
            this.colLotCmf8.Text = "Lot Cmf 8";
            this.colLotCmf8.Width = 100;
            // 
            // colLotCmf9
            // 
            this.colLotCmf9.Text = "Lot Cmf 9";
            this.colLotCmf9.Width = 100;
            // 
            // colLotCmf10
            // 
            this.colLotCmf10.Text = "Lot Cmf 10";
            this.colLotCmf10.Width = 100;
            // 
            // colLotCmf11
            // 
            this.colLotCmf11.Text = "Lot Cmf 11";
            this.colLotCmf11.Width = 100;
            // 
            // colLotCmf12
            // 
            this.colLotCmf12.Text = "Lot Cmf 12";
            this.colLotCmf12.Width = 100;
            // 
            // colLotCmf13
            // 
            this.colLotCmf13.Text = "Lot Cmf 13";
            this.colLotCmf13.Width = 100;
            // 
            // colLotCmf14
            // 
            this.colLotCmf14.Text = "Lot Cmf 14";
            this.colLotCmf14.Width = 100;
            // 
            // colLotCmf15
            // 
            this.colLotCmf15.Text = "Lot Cmf 15";
            this.colLotCmf15.Width = 100;
            // 
            // colLotCmf16
            // 
            this.colLotCmf16.Text = "Lot Cmf 16";
            this.colLotCmf16.Width = 100;
            // 
            // colLotCmf17
            // 
            this.colLotCmf17.Text = "Lot Cmf 17";
            this.colLotCmf17.Width = 100;
            // 
            // colLotCmf18
            // 
            this.colLotCmf18.Text = "Lot Cmf 18";
            this.colLotCmf18.Width = 100;
            // 
            // colLotCmf19
            // 
            this.colLotCmf19.Text = "Lot Cmf 19";
            this.colLotCmf19.Width = 100;
            // 
            // colLotCmf20
            // 
            this.colLotCmf20.Text = "Lot Cmf 20";
            this.colLotCmf20.Width = 100;
            // 
            // colBomSetID
            // 
            this.colBomSetID.Text = "BOM Set ID";
            this.colBomSetID.Width = 100;
            // 
            // colBomSetVersion
            // 
            this.colBomSetVersion.Text = "BOM Set Version";
            this.colBomSetVersion.Width = 120;
            // 
            // colBomActiveSeq
            // 
            this.colBomActiveSeq.Text = "BOM Act Hist Seq";
            this.colBomActiveSeq.Width = 120;
            // 
            // colBomHistSeq
            // 
            this.colBomHistSeq.Text = "BOM Hist Seq";
            this.colBomHistSeq.Width = 100;
            // 
            // colLotDelFlag
            // 
            this.colLotDelFlag.Text = "Lot Delete Flag";
            this.colLotDelFlag.Width = 100;
            // 
            // colLotDelTime
            // 
            this.colLotDelTime.Text = "Lot Delete Time";
            this.colLotDelTime.Width = 120;
            // 
            // colLotDelReason
            // 
            this.colLotDelReason.Text = "Lot Delete Reason";
            this.colLotDelReason.Width = 150;
            // 
            // colLastTranCode
            // 
            this.colLastTranCode.Text = "Last Trans Code";
            this.colLastTranCode.Width = 120;
            // 
            // colLastTranTime
            // 
            this.colLastTranTime.Text = "Last Trans Time";
            this.colLastTranTime.Width = 120;
            // 
            // colLastComment
            // 
            this.colLastComment.Text = "Last Comment";
            this.colLastComment.Width = 200;
            // 
            // colLastActiveHistSeq
            // 
            this.colLastActiveHistSeq.Text = "Last Active Hist Seq";
            this.colLastActiveHistSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colLastActiveHistSeq.Width = 140;
            // 
            // colLastHistSeq
            // 
            this.colLastHistSeq.Text = "Last Hist Seq";
            this.colLastHistSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colLastHistSeq.Width = 120;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.Location = new System.Drawing.Point(464, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // grpLoss
            // 
            this.grpLoss.Controls.Add(this.txtActionDesc);
            this.grpLoss.Controls.Add(this.txtPassFail);
            this.grpLoss.Controls.Add(this.lblResultType);
            this.grpLoss.Controls.Add(this.chkSMPUnit2Flag);
            this.grpLoss.Controls.Add(this.chkSMPUnit1Flag);
            this.grpLoss.Controls.Add(this.grpSMPUnit2);
            this.grpLoss.Controls.Add(this.grpSMPUnit1);
            this.grpLoss.Controls.Add(this.txtSMPDesc);
            this.grpLoss.Controls.Add(this.txtSMPRule);
            this.grpLoss.Controls.Add(this.lblSMPRule);
            this.grpLoss.Controls.Add(this.txtQAOper);
            this.grpLoss.Controls.Add(this.lblQAGateOper);
            this.grpLoss.Controls.Add(this.txtSMPType);
            this.grpLoss.Controls.Add(this.lblSMPType);
            this.grpLoss.Controls.Add(this.txtTestCount);
            this.grpLoss.Controls.Add(this.lblTestCount);
            this.grpLoss.Controls.Add(this.txtIRRMRR);
            this.grpLoss.Controls.Add(this.txtInspector);
            this.grpLoss.Controls.Add(this.lblInspector);
            this.grpLoss.Controls.Add(this.cdvShift);
            this.grpLoss.Controls.Add(this.cdvAction);
            this.grpLoss.Controls.Add(this.lblIRRMRR);
            this.grpLoss.Controls.Add(this.lblShift);
            this.grpLoss.Controls.Add(this.lblPassFlag);
            this.grpLoss.Controls.Add(this.txtSMPSize2);
            this.grpLoss.Controls.Add(this.txtSMPSize1);
            this.grpLoss.Controls.Add(this.lblSMPSize1);
            this.grpLoss.Controls.Add(this.lblSMPSize2);
            this.grpLoss.Controls.Add(this.cdvResID);
            this.grpLoss.Controls.Add(this.lblResID);
            this.grpLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLoss.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLoss.Location = new System.Drawing.Point(3, 0);
            this.grpLoss.Name = "grpLoss";
            this.grpLoss.Size = new System.Drawing.Size(722, 231);
            this.grpLoss.TabIndex = 3;
            this.grpLoss.TabStop = false;
            // 
            // txtActionDesc
            // 
            this.txtActionDesc.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtActionDesc.Enabled = false;
            this.txtActionDesc.Location = new System.Drawing.Point(308, 123);
            this.txtActionDesc.MaxLength = 50;
            this.txtActionDesc.Name = "txtActionDesc";
            this.txtActionDesc.Size = new System.Drawing.Size(402, 20);
            this.txtActionDesc.TabIndex = 15;
            // 
            // txtPassFail
            // 
            this.txtPassFail.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtPassFail.Enabled = false;
            this.txtPassFail.Location = new System.Drawing.Point(118, 150);
            this.txtPassFail.MaxLength = 6;
            this.txtPassFail.Name = "txtPassFail";
            this.txtPassFail.Size = new System.Drawing.Size(183, 20);
            this.txtPassFail.TabIndex = 17;
            // 
            // lblResultType
            // 
            this.lblResultType.AutoSize = true;
            this.lblResultType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResultType.Location = new System.Drawing.Point(12, 154);
            this.lblResultType.Name = "lblResultType";
            this.lblResultType.Size = new System.Drawing.Size(51, 13);
            this.lblResultType.TabIndex = 16;
            this.lblResultType.Text = "Pass/Fail";
            this.lblResultType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // chkSMPUnit2Flag
            // 
            this.chkSMPUnit2Flag.AutoSize = true;
            this.chkSMPUnit2Flag.Enabled = false;
            this.chkSMPUnit2Flag.Location = new System.Drawing.Point(72, 104);
            this.chkSMPUnit2Flag.Name = "chkSMPUnit2Flag";
            this.chkSMPUnit2Flag.Size = new System.Drawing.Size(51, 17);
            this.chkSMPUnit2Flag.TabIndex = 10;
            this.chkSMPUnit2Flag.Text = "Unit2";
            this.chkSMPUnit2Flag.UseVisualStyleBackColor = true;
            // 
            // chkSMPUnit1Flag
            // 
            this.chkSMPUnit1Flag.AutoSize = true;
            this.chkSMPUnit1Flag.Enabled = false;
            this.chkSMPUnit1Flag.Location = new System.Drawing.Point(15, 104);
            this.chkSMPUnit1Flag.Name = "chkSMPUnit1Flag";
            this.chkSMPUnit1Flag.Size = new System.Drawing.Size(51, 17);
            this.chkSMPUnit1Flag.TabIndex = 9;
            this.chkSMPUnit1Flag.Text = "Unit1";
            this.chkSMPUnit1Flag.UseVisualStyleBackColor = true;
            // 
            // grpSMPUnit2
            // 
            this.grpSMPUnit2.Controls.Add(this.txtUnit2SMPSelType);
            this.grpSMPUnit2.Controls.Add(this.lblUnit2SMPSelType);
            this.grpSMPUnit2.Controls.Add(this.txtUnit2SMPSize);
            this.grpSMPUnit2.Controls.Add(this.lblUnit2SMPSize);
            this.grpSMPUnit2.Controls.Add(this.txtUnit2SMPSizeType);
            this.grpSMPUnit2.Controls.Add(this.lblUnit2SMPSizeType);
            this.grpSMPUnit2.Location = new System.Drawing.Point(509, 30);
            this.grpSMPUnit2.Name = "grpSMPUnit2";
            this.grpSMPUnit2.Size = new System.Drawing.Size(199, 91);
            this.grpSMPUnit2.TabIndex = 12;
            this.grpSMPUnit2.TabStop = false;
            this.grpSMPUnit2.Text = "Unit2";
            // 
            // txtUnit2SMPSelType
            // 
            this.txtUnit2SMPSelType.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtUnit2SMPSelType.Enabled = false;
            this.txtUnit2SMPSelType.Location = new System.Drawing.Point(113, 63);
            this.txtUnit2SMPSelType.MaxLength = 10;
            this.txtUnit2SMPSelType.Name = "txtUnit2SMPSelType";
            this.txtUnit2SMPSelType.Size = new System.Drawing.Size(79, 20);
            this.txtUnit2SMPSelType.TabIndex = 47;
            // 
            // lblUnit2SMPSelType
            // 
            this.lblUnit2SMPSelType.AutoSize = true;
            this.lblUnit2SMPSelType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit2SMPSelType.Location = new System.Drawing.Point(11, 67);
            this.lblUnit2SMPSelType.Name = "lblUnit2SMPSelType";
            this.lblUnit2SMPSelType.Size = new System.Drawing.Size(102, 13);
            this.lblUnit2SMPSelType.TabIndex = 46;
            this.lblUnit2SMPSelType.Text = "Sample Select Type";
            this.lblUnit2SMPSelType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtUnit2SMPSize
            // 
            this.txtUnit2SMPSize.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtUnit2SMPSize.Enabled = false;
            this.txtUnit2SMPSize.Location = new System.Drawing.Point(113, 40);
            this.txtUnit2SMPSize.MaxLength = 11;
            this.txtUnit2SMPSize.Name = "txtUnit2SMPSize";
            this.txtUnit2SMPSize.Size = new System.Drawing.Size(79, 20);
            this.txtUnit2SMPSize.TabIndex = 45;
            // 
            // lblUnit2SMPSize
            // 
            this.lblUnit2SMPSize.AutoSize = true;
            this.lblUnit2SMPSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit2SMPSize.Location = new System.Drawing.Point(11, 44);
            this.lblUnit2SMPSize.Name = "lblUnit2SMPSize";
            this.lblUnit2SMPSize.Size = new System.Drawing.Size(65, 13);
            this.lblUnit2SMPSize.TabIndex = 44;
            this.lblUnit2SMPSize.Text = "Sample Size";
            this.lblUnit2SMPSize.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtUnit2SMPSizeType
            // 
            this.txtUnit2SMPSizeType.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtUnit2SMPSizeType.Enabled = false;
            this.txtUnit2SMPSizeType.Location = new System.Drawing.Point(113, 17);
            this.txtUnit2SMPSizeType.MaxLength = 10;
            this.txtUnit2SMPSizeType.Name = "txtUnit2SMPSizeType";
            this.txtUnit2SMPSizeType.Size = new System.Drawing.Size(79, 20);
            this.txtUnit2SMPSizeType.TabIndex = 43;
            // 
            // lblUnit2SMPSizeType
            // 
            this.lblUnit2SMPSizeType.AutoSize = true;
            this.lblUnit2SMPSizeType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit2SMPSizeType.Location = new System.Drawing.Point(11, 21);
            this.lblUnit2SMPSizeType.Name = "lblUnit2SMPSizeType";
            this.lblUnit2SMPSizeType.Size = new System.Drawing.Size(92, 13);
            this.lblUnit2SMPSizeType.TabIndex = 42;
            this.lblUnit2SMPSizeType.Text = "Sample Size Type";
            this.lblUnit2SMPSizeType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // grpSMPUnit1
            // 
            this.grpSMPUnit1.Controls.Add(this.txtUnit1SMPSelType);
            this.grpSMPUnit1.Controls.Add(this.lblUnit1SMPSelType);
            this.grpSMPUnit1.Controls.Add(this.txtUnit1SMPSize);
            this.grpSMPUnit1.Controls.Add(this.lblUnit1SMPSize);
            this.grpSMPUnit1.Controls.Add(this.txtUnit1SMPSizeType);
            this.grpSMPUnit1.Controls.Add(this.lblUnit1SMPSizeType);
            this.grpSMPUnit1.Location = new System.Drawing.Point(312, 30);
            this.grpSMPUnit1.Name = "grpSMPUnit1";
            this.grpSMPUnit1.Size = new System.Drawing.Size(197, 91);
            this.grpSMPUnit1.TabIndex = 11;
            this.grpSMPUnit1.TabStop = false;
            this.grpSMPUnit1.Text = "Unit1";
            // 
            // txtUnit1SMPSelType
            // 
            this.txtUnit1SMPSelType.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtUnit1SMPSelType.Enabled = false;
            this.txtUnit1SMPSelType.Location = new System.Drawing.Point(112, 62);
            this.txtUnit1SMPSelType.MaxLength = 10;
            this.txtUnit1SMPSelType.Name = "txtUnit1SMPSelType";
            this.txtUnit1SMPSelType.Size = new System.Drawing.Size(79, 20);
            this.txtUnit1SMPSelType.TabIndex = 45;
            // 
            // lblUnit1SMPSelType
            // 
            this.lblUnit1SMPSelType.AutoSize = true;
            this.lblUnit1SMPSelType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1SMPSelType.Location = new System.Drawing.Point(10, 66);
            this.lblUnit1SMPSelType.Name = "lblUnit1SMPSelType";
            this.lblUnit1SMPSelType.Size = new System.Drawing.Size(102, 13);
            this.lblUnit1SMPSelType.TabIndex = 44;
            this.lblUnit1SMPSelType.Text = "Sample Select Type";
            this.lblUnit1SMPSelType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtUnit1SMPSize
            // 
            this.txtUnit1SMPSize.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtUnit1SMPSize.Enabled = false;
            this.txtUnit1SMPSize.Location = new System.Drawing.Point(112, 39);
            this.txtUnit1SMPSize.MaxLength = 11;
            this.txtUnit1SMPSize.Name = "txtUnit1SMPSize";
            this.txtUnit1SMPSize.Size = new System.Drawing.Size(79, 20);
            this.txtUnit1SMPSize.TabIndex = 43;
            // 
            // lblUnit1SMPSize
            // 
            this.lblUnit1SMPSize.AutoSize = true;
            this.lblUnit1SMPSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1SMPSize.Location = new System.Drawing.Point(10, 43);
            this.lblUnit1SMPSize.Name = "lblUnit1SMPSize";
            this.lblUnit1SMPSize.Size = new System.Drawing.Size(65, 13);
            this.lblUnit1SMPSize.TabIndex = 42;
            this.lblUnit1SMPSize.Text = "Sample Size";
            this.lblUnit1SMPSize.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtUnit1SMPSizeType
            // 
            this.txtUnit1SMPSizeType.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtUnit1SMPSizeType.Enabled = false;
            this.txtUnit1SMPSizeType.Location = new System.Drawing.Point(112, 16);
            this.txtUnit1SMPSizeType.MaxLength = 10;
            this.txtUnit1SMPSizeType.Name = "txtUnit1SMPSizeType";
            this.txtUnit1SMPSizeType.Size = new System.Drawing.Size(79, 20);
            this.txtUnit1SMPSizeType.TabIndex = 41;
            // 
            // lblUnit1SMPSizeType
            // 
            this.lblUnit1SMPSizeType.AutoSize = true;
            this.lblUnit1SMPSizeType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1SMPSizeType.Location = new System.Drawing.Point(10, 20);
            this.lblUnit1SMPSizeType.Name = "lblUnit1SMPSizeType";
            this.lblUnit1SMPSizeType.Size = new System.Drawing.Size(92, 13);
            this.lblUnit1SMPSizeType.TabIndex = 40;
            this.lblUnit1SMPSizeType.Text = "Sample Size Type";
            this.lblUnit1SMPSizeType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtSMPDesc
            // 
            this.txtSMPDesc.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSMPDesc.Enabled = false;
            this.txtSMPDesc.Location = new System.Drawing.Point(307, 8);
            this.txtSMPDesc.MaxLength = 50;
            this.txtSMPDesc.Name = "txtSMPDesc";
            this.txtSMPDesc.Size = new System.Drawing.Size(401, 20);
            this.txtSMPDesc.TabIndex = 2;
            // 
            // txtSMPRule
            // 
            this.txtSMPRule.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSMPRule.Enabled = false;
            this.txtSMPRule.Location = new System.Drawing.Point(118, 8);
            this.txtSMPRule.MaxLength = 20;
            this.txtSMPRule.Name = "txtSMPRule";
            this.txtSMPRule.Size = new System.Drawing.Size(182, 20);
            this.txtSMPRule.TabIndex = 1;
            // 
            // lblSMPRule
            // 
            this.lblSMPRule.AutoSize = true;
            this.lblSMPRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSMPRule.Location = new System.Drawing.Point(12, 12);
            this.lblSMPRule.Name = "lblSMPRule";
            this.lblSMPRule.Size = new System.Drawing.Size(67, 13);
            this.lblSMPRule.TabIndex = 0;
            this.lblSMPRule.Text = "Sample Rule";
            this.lblSMPRule.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtQAOper
            // 
            this.txtQAOper.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtQAOper.Enabled = false;
            this.txtQAOper.Location = new System.Drawing.Point(118, 31);
            this.txtQAOper.MaxLength = 10;
            this.txtQAOper.Name = "txtQAOper";
            this.txtQAOper.Size = new System.Drawing.Size(182, 20);
            this.txtQAOper.TabIndex = 4;
            // 
            // lblQAGateOper
            // 
            this.lblQAGateOper.AutoSize = true;
            this.lblQAGateOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQAGateOper.Location = new System.Drawing.Point(12, 35);
            this.lblQAGateOper.Name = "lblQAGateOper";
            this.lblQAGateOper.Size = new System.Drawing.Size(97, 13);
            this.lblQAGateOper.TabIndex = 3;
            this.lblQAGateOper.Text = "QA Gate Operation";
            this.lblQAGateOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtSMPType
            // 
            this.txtSMPType.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSMPType.Enabled = false;
            this.txtSMPType.Location = new System.Drawing.Point(118, 54);
            this.txtSMPType.MaxLength = 10;
            this.txtSMPType.Name = "txtSMPType";
            this.txtSMPType.Size = new System.Drawing.Size(182, 20);
            this.txtSMPType.TabIndex = 6;
            // 
            // lblSMPType
            // 
            this.lblSMPType.AutoSize = true;
            this.lblSMPType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSMPType.Location = new System.Drawing.Point(12, 56);
            this.lblSMPType.Name = "lblSMPType";
            this.lblSMPType.Size = new System.Drawing.Size(69, 13);
            this.lblSMPType.TabIndex = 5;
            this.lblSMPType.Text = "Sample Type";
            this.lblSMPType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtTestCount
            // 
            this.txtTestCount.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTestCount.Enabled = false;
            this.txtTestCount.Location = new System.Drawing.Point(120, 80);
            this.txtTestCount.MaxLength = 6;
            this.txtTestCount.Name = "txtTestCount";
            this.txtTestCount.Size = new System.Drawing.Size(182, 20);
            this.txtTestCount.TabIndex = 8;
            this.txtTestCount.Visible = false;
            // 
            // lblTestCount
            // 
            this.lblTestCount.AutoSize = true;
            this.lblTestCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTestCount.Location = new System.Drawing.Point(12, 80);
            this.lblTestCount.Name = "lblTestCount";
            this.lblTestCount.Size = new System.Drawing.Size(59, 13);
            this.lblTestCount.TabIndex = 7;
            this.lblTestCount.Text = "Test Count";
            this.lblTestCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblTestCount.Visible = false;
            // 
            // txtIRRMRR
            // 
            this.txtIRRMRR.Location = new System.Drawing.Point(488, 214);
            this.txtIRRMRR.MaxLength = 30;
            this.txtIRRMRR.Name = "txtIRRMRR";
            this.txtIRRMRR.Size = new System.Drawing.Size(184, 20);
            this.txtIRRMRR.TabIndex = 29;
            // 
            // txtInspector
            // 
            this.txtInspector.Location = new System.Drawing.Point(488, 168);
            this.txtInspector.MaxLength = 20;
            this.txtInspector.Name = "txtInspector";
            this.txtInspector.Size = new System.Drawing.Size(184, 20);
            this.txtInspector.TabIndex = 25;
            // 
            // lblInspector
            // 
            this.lblInspector.AutoSize = true;
            this.lblInspector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspector.Location = new System.Drawing.Point(382, 171);
            this.lblInspector.Name = "lblInspector";
            this.lblInspector.Size = new System.Drawing.Size(51, 13);
            this.lblInspector.TabIndex = 24;
            this.lblInspector.Text = "Inspector";
            this.lblInspector.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvShift
            // 
            this.cdvShift.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShift.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShift.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShift.BtnToolTipText = "";
            this.cdvShift.DescText = "";
            this.cdvShift.DisplaySubItemIndex = -1;
            this.cdvShift.DisplayText = "";
            this.cdvShift.Focusing = null;
            this.cdvShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvShift.Index = 0;
            this.cdvShift.IsViewBtnImage = false;
            this.cdvShift.Location = new System.Drawing.Point(488, 191);
            this.cdvShift.MaxLength = 10;
            this.cdvShift.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShift.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShift.Name = "cdvShift";
            this.cdvShift.ReadOnly = false;
            this.cdvShift.SearchSubItemIndex = 0;
            this.cdvShift.SelectedDescIndex = -1;
            this.cdvShift.SelectedSubItemIndex = -1;
            this.cdvShift.SelectionStart = 0;
            this.cdvShift.Size = new System.Drawing.Size(184, 20);
            this.cdvShift.SmallImageList = null;
            this.cdvShift.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShift.TabIndex = 27;
            this.cdvShift.TextBoxToolTipText = "";
            this.cdvShift.TextBoxWidth = 131;
            this.cdvShift.VisibleButton = true;
            this.cdvShift.VisibleColumnHeader = false;
            this.cdvShift.VisibleDescription = false;
            this.cdvShift.ButtonPress += new System.EventHandler(this.cdvShift_ButtonPress);
            // 
            // cdvAction
            // 
            this.cdvAction.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAction.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAction.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAction.BtnToolTipText = "";
            this.cdvAction.DescText = "";
            this.cdvAction.DisplaySubItemIndex = -1;
            this.cdvAction.DisplayText = "";
            this.cdvAction.Focusing = null;
            this.cdvAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAction.Index = 0;
            this.cdvAction.IsViewBtnImage = false;
            this.cdvAction.Location = new System.Drawing.Point(118, 127);
            this.cdvAction.MaxLength = 20;
            this.cdvAction.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAction.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAction.Name = "cdvAction";
            this.cdvAction.ReadOnly = false;
            this.cdvAction.SearchSubItemIndex = 0;
            this.cdvAction.SelectedDescIndex = -1;
            this.cdvAction.SelectedSubItemIndex = -1;
            this.cdvAction.SelectionStart = 0;
            this.cdvAction.Size = new System.Drawing.Size(184, 20);
            this.cdvAction.SmallImageList = null;
            this.cdvAction.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAction.TabIndex = 14;
            this.cdvAction.TextBoxToolTipText = "";
            this.cdvAction.TextBoxWidth = 131;
            this.cdvAction.VisibleButton = true;
            this.cdvAction.VisibleColumnHeader = false;
            this.cdvAction.VisibleDescription = false;
            this.cdvAction.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAction_SelectedItemChanged);
            this.cdvAction.ButtonPress += new System.EventHandler(this.cdvAction_ButtonPress);
            // 
            // lblIRRMRR
            // 
            this.lblIRRMRR.AutoSize = true;
            this.lblIRRMRR.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblIRRMRR.Location = new System.Drawing.Point(382, 218);
            this.lblIRRMRR.Name = "lblIRRMRR";
            this.lblIRRMRR.Size = new System.Drawing.Size(56, 13);
            this.lblIRRMRR.TabIndex = 28;
            this.lblIRRMRR.Text = "IRR/MRR";
            this.lblIRRMRR.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift.Location = new System.Drawing.Point(382, 194);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(28, 13);
            this.lblShift.TabIndex = 26;
            this.lblShift.Text = "Shift";
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblPassFlag
            // 
            this.lblPassFlag.AutoSize = true;
            this.lblPassFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPassFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassFlag.Location = new System.Drawing.Point(12, 130);
            this.lblPassFlag.Name = "lblPassFlag";
            this.lblPassFlag.Size = new System.Drawing.Size(83, 13);
            this.lblPassFlag.TabIndex = 13;
            this.lblPassFlag.Text = "Result Action";
            this.lblPassFlag.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtSMPSize2
            // 
            this.txtSMPSize2.Location = new System.Drawing.Point(118, 197);
            this.txtSMPSize2.MaxLength = 11;
            this.txtSMPSize2.Name = "txtSMPSize2";
            this.txtSMPSize2.Size = new System.Drawing.Size(184, 20);
            this.txtSMPSize2.TabIndex = 21;
            // 
            // txtSMPSize1
            // 
            this.txtSMPSize1.Location = new System.Drawing.Point(118, 174);
            this.txtSMPSize1.MaxLength = 11;
            this.txtSMPSize1.Name = "txtSMPSize1";
            this.txtSMPSize1.Size = new System.Drawing.Size(184, 20);
            this.txtSMPSize1.TabIndex = 19;
            // 
            // lblSMPSize1
            // 
            this.lblSMPSize1.AutoSize = true;
            this.lblSMPSize1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSMPSize1.Location = new System.Drawing.Point(12, 176);
            this.lblSMPSize1.Name = "lblSMPSize1";
            this.lblSMPSize1.Size = new System.Drawing.Size(71, 13);
            this.lblSMPSize1.TabIndex = 18;
            this.lblSMPSize1.Text = "Sample Size1";
            this.lblSMPSize1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblSMPSize2
            // 
            this.lblSMPSize2.AutoSize = true;
            this.lblSMPSize2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSMPSize2.Location = new System.Drawing.Point(12, 199);
            this.lblSMPSize2.Name = "lblSMPSize2";
            this.lblSMPSize2.Size = new System.Drawing.Size(71, 13);
            this.lblSMPSize2.TabIndex = 20;
            this.lblSMPSize2.Text = "Sample Size2";
            this.lblSMPSize2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(488, 145);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(184, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 23;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 131;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Location = new System.Drawing.Point(382, 148);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 22;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(3, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(722, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // frmWIPTranMultiQaGate
            // 
            this.ClientSize = new System.Drawing.Size(742, 558);
            this.Name = "frmWIPTranMultiQaGate";
            this.Text = "Multi Qa Gate";
            this.Activated += new System.EventHandler(this.frmWIPTranMultiQaGate_Activated);
            this.Load += new System.EventHandler(this.frmWIPTranMultiQaGate_Load);
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
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
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlConditionInfo.ResumeLayout(false);
            this.grpConditionInfo.ResumeLayout(false);
            this.grpConditionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            this.panel11.ResumeLayout(false);
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.pnlCheck.ResumeLayout(false);
            this.grpCheck.ResumeLayout(false);
            this.pnlLotList.ResumeLayout(false);
            this.grpLotList.ResumeLayout(false);
            this.grpLoss.ResumeLayout(false);
            this.grpLoss.PerformLayout();
            this.grpSMPUnit2.ResumeLayout(false);
            this.grpSMPUnit2.PerformLayout();
            this.grpSMPUnit1.ResumeLayout(false);
            this.grpSMPUnit1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConditionInfo;
        private System.Windows.Forms.GroupBox grpConditionInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Panel pnlCheck;
        private System.Windows.Forms.GroupBox grpCheck;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Panel pnlLotList;
        private System.Windows.Forms.GroupBox grpLotList;
        private System.Windows.Forms.Button btnView;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colMaterial;
        private System.Windows.Forms.ColumnHeader colMatVersion;
        private System.Windows.Forms.ColumnHeader colFlow;
        private System.Windows.Forms.ColumnHeader colFlowSeq;
        private System.Windows.Forms.ColumnHeader colOperation;
        private System.Windows.Forms.ColumnHeader colQty1;
        private System.Windows.Forms.ColumnHeader colQty2;
        private System.Windows.Forms.ColumnHeader colQty3;
        private System.Windows.Forms.ColumnHeader colLotType;
        private System.Windows.Forms.ColumnHeader colOwnerCode;
        private System.Windows.Forms.ColumnHeader colCreateCode;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.ColumnHeader colLotStatus;
        private System.Windows.Forms.ColumnHeader colHoldFlag;
        private System.Windows.Forms.ColumnHeader colHoldCode;
        private System.Windows.Forms.ColumnHeader colCreateQty1;
        private System.Windows.Forms.ColumnHeader colCreateQty2;
        private System.Windows.Forms.ColumnHeader colCreateQty3;
        private System.Windows.Forms.ColumnHeader colOperInQty1;
        private System.Windows.Forms.ColumnHeader colOperInQty2;
        private System.Windows.Forms.ColumnHeader colOperInQty3;
        private System.Windows.Forms.ColumnHeader colInvFlag;
        private System.Windows.Forms.ColumnHeader colTransitFlag;
        private System.Windows.Forms.ColumnHeader colUnitExistFlag;
        private System.Windows.Forms.ColumnHeader colInvUnit;
        private System.Windows.Forms.ColumnHeader colRwkFlag;
        private System.Windows.Forms.ColumnHeader colRwkCode;
        private System.Windows.Forms.ColumnHeader colRwkCount;
        private System.Windows.Forms.ColumnHeader colRwkRetFlow;
        private System.Windows.Forms.ColumnHeader colRwkRetOper;
        private System.Windows.Forms.ColumnHeader colRwkEndFlow;
        private System.Windows.Forms.ColumnHeader colRwkEndOper;
        private System.Windows.Forms.ColumnHeader colRwkRetClearFlag;
        private System.Windows.Forms.ColumnHeader colRwkTime;
        private System.Windows.Forms.ColumnHeader colNstdFlag;
        private System.Windows.Forms.ColumnHeader colNstdRetFlow;
        private System.Windows.Forms.ColumnHeader colNstdRetOper;
        private System.Windows.Forms.ColumnHeader colNstdTime;
        private System.Windows.Forms.ColumnHeader colRepFlag;
        private System.Windows.Forms.ColumnHeader colRepOper;
        private System.Windows.Forms.ColumnHeader colStrRetFlow;
        private System.Windows.Forms.ColumnHeader colStrRetFlowSeq;
        private System.Windows.Forms.ColumnHeader colStrRetOper;
        private System.Windows.Forms.ColumnHeader colStartFlag;
        private System.Windows.Forms.ColumnHeader colStartTime;
        private System.Windows.Forms.ColumnHeader colStartResID;
        private System.Windows.Forms.ColumnHeader colEndFlag;
        private System.Windows.Forms.ColumnHeader colEndTime;
        private System.Windows.Forms.ColumnHeader colEndResID;
        private System.Windows.Forms.ColumnHeader colSampleFlag;
        private System.Windows.Forms.ColumnHeader colSampleWaitFlag;
        private System.Windows.Forms.ColumnHeader colSampleResult;
        private System.Windows.Forms.ColumnHeader colSplitFromLotID;
        private System.Windows.Forms.ColumnHeader colShipCode;
        private System.Windows.Forms.ColumnHeader colShipTime;
        private System.Windows.Forms.ColumnHeader colOrgDueTime;
        private System.Windows.Forms.ColumnHeader colSchDueTime;
        private System.Windows.Forms.ColumnHeader colCreateTime;
        private System.Windows.Forms.ColumnHeader colFactoryInTime;
        private System.Windows.Forms.ColumnHeader colFlowInTime;
        private System.Windows.Forms.ColumnHeader colOperInTime;
        private System.Windows.Forms.ColumnHeader colResvResID;
        private System.Windows.Forms.ColumnHeader colBatchID;
        private System.Windows.Forms.ColumnHeader colBatchSeq;
        private System.Windows.Forms.ColumnHeader colOrderID;
        private System.Windows.Forms.ColumnHeader colAddOrder1;
        private System.Windows.Forms.ColumnHeader colAddOrder2;
        private System.Windows.Forms.ColumnHeader colAddOrder3;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ColumnHeader colLotCmf1;
        private System.Windows.Forms.ColumnHeader colLotCmf2;
        private System.Windows.Forms.ColumnHeader colLotCmf3;
        private System.Windows.Forms.ColumnHeader colLotCmf4;
        private System.Windows.Forms.ColumnHeader colLotCmf5;
        private System.Windows.Forms.ColumnHeader colLotCmf6;
        private System.Windows.Forms.ColumnHeader colLotCmf7;
        private System.Windows.Forms.ColumnHeader colLotCmf8;
        private System.Windows.Forms.ColumnHeader colLotCmf9;
        private System.Windows.Forms.ColumnHeader colLotCmf10;
        private System.Windows.Forms.ColumnHeader colLotCmf11;
        private System.Windows.Forms.ColumnHeader colLotCmf12;
        private System.Windows.Forms.ColumnHeader colLotCmf13;
        private System.Windows.Forms.ColumnHeader colLotCmf14;
        private System.Windows.Forms.ColumnHeader colLotCmf15;
        private System.Windows.Forms.ColumnHeader colLotCmf16;
        private System.Windows.Forms.ColumnHeader colLotCmf17;
        private System.Windows.Forms.ColumnHeader colLotCmf18;
        private System.Windows.Forms.ColumnHeader colLotCmf19;
        private System.Windows.Forms.ColumnHeader colLotCmf20;
        private System.Windows.Forms.ColumnHeader colBomSetID;
        private System.Windows.Forms.ColumnHeader colBomSetVersion;
        private System.Windows.Forms.ColumnHeader colBomActiveSeq;
        private System.Windows.Forms.ColumnHeader colBomHistSeq;
        private System.Windows.Forms.ColumnHeader colLotDelFlag;
        private System.Windows.Forms.ColumnHeader colLotDelTime;
        private System.Windows.Forms.ColumnHeader colLotDelReason;
        private System.Windows.Forms.ColumnHeader colLastTranCode;
        private System.Windows.Forms.ColumnHeader colLastTranTime;
        private System.Windows.Forms.ColumnHeader colLastComment;
        private System.Windows.Forms.ColumnHeader colLastActiveHistSeq;
        private System.Windows.Forms.ColumnHeader colLastHistSeq;
        private System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.GroupBox grpLoss;
        private System.Windows.Forms.TextBox txtActionDesc;
        private System.Windows.Forms.TextBox txtPassFail;
        private System.Windows.Forms.Label lblResultType;
        private System.Windows.Forms.CheckBox chkSMPUnit2Flag;
        private System.Windows.Forms.CheckBox chkSMPUnit1Flag;
        private System.Windows.Forms.GroupBox grpSMPUnit2;
        private System.Windows.Forms.TextBox txtUnit2SMPSelType;
        private System.Windows.Forms.Label lblUnit2SMPSelType;
        private System.Windows.Forms.TextBox txtUnit2SMPSize;
        private System.Windows.Forms.Label lblUnit2SMPSize;
        private System.Windows.Forms.TextBox txtUnit2SMPSizeType;
        private System.Windows.Forms.Label lblUnit2SMPSizeType;
        private System.Windows.Forms.GroupBox grpSMPUnit1;
        private System.Windows.Forms.TextBox txtUnit1SMPSelType;
        private System.Windows.Forms.Label lblUnit1SMPSelType;
        private System.Windows.Forms.TextBox txtUnit1SMPSize;
        private System.Windows.Forms.Label lblUnit1SMPSize;
        private System.Windows.Forms.TextBox txtUnit1SMPSizeType;
        private System.Windows.Forms.Label lblUnit1SMPSizeType;
        private System.Windows.Forms.TextBox txtSMPDesc;
        private System.Windows.Forms.TextBox txtSMPRule;
        private System.Windows.Forms.Label lblSMPRule;
        private System.Windows.Forms.TextBox txtQAOper;
        private System.Windows.Forms.Label lblQAGateOper;
        private System.Windows.Forms.TextBox txtSMPType;
        private System.Windows.Forms.Label lblSMPType;
        private System.Windows.Forms.TextBox txtTestCount;
        private System.Windows.Forms.Label lblTestCount;
        private System.Windows.Forms.TextBox txtIRRMRR;
        private System.Windows.Forms.TextBox txtInspector;
        private System.Windows.Forms.Label lblInspector;
        private UI.Controls.MCCodeView.MCCodeView cdvShift;
        private UI.Controls.MCCodeView.MCCodeView cdvAction;
        private System.Windows.Forms.Label lblIRRMRR;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblPassFlag;
        private System.Windows.Forms.TextBox txtSMPSize2;
        private System.Windows.Forms.TextBox txtSMPSize1;
        private System.Windows.Forms.Label lblSMPSize1;
        private System.Windows.Forms.Label lblSMPSize2;
        private UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private MESCore.Controls.udcFlowAndSeq cdvFlow;
        private MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Splitter splitter1;
    }
}
