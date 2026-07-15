namespace Miracom.WIPCore
{
    partial class frmWIPTranMultiTerminateLot
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.pnlConditionInfo = new System.Windows.Forms.Panel();
            this.grpConditionInfo = new System.Windows.Forms.GroupBox();
            this.cdvAttributeValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttributeValue = new System.Windows.Forms.Label();
            this.chkZeroQuantityLot = new System.Windows.Forms.CheckBox();
            this.cdvAttributeName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttributeName = new System.Windows.Forms.Label();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.udcCondition = new Miracom.MESCore.Controls.udcFlexibleConditionForLot();
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
            this.cdvspdTerminateCode = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlLotInfo = new System.Windows.Forms.Panel();
            this.grpSelLotList = new System.Windows.Forms.GroupBox();
            this.spdSelLotList = new FarPoint.Win.Spread.FpSpread();
            this.spdSelLotList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlSummaryInfo = new System.Windows.Forms.Panel();
            this.lblTotQty3 = new System.Windows.Forms.Label();
            this.lblTotQty2 = new System.Windows.Forms.Label();
            this.lblTotQty1 = new System.Windows.Forms.Label();
            this.lblTotCnt = new System.Windows.Forms.Label();
            this.pnlLotCondition = new System.Windows.Forms.Panel();
            this.grpTerminateInfo = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.cdvTerminateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTerminateCode = new System.Windows.Forms.Label();
            this.chkBindSameTr = new System.Windows.Forms.CheckBox();
            this.chkCommitCond = new System.Windows.Forms.CheckBox();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranDateTime = new System.Windows.Forms.CheckBox();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
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
            this.pnlTranInfo.SuspendLayout();
            this.tbpLotInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlConditionInfo.SuspendLayout();
            this.grpConditionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttributeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttributeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            this.pnlCheck.SuspendLayout();
            this.grpCheck.SuspendLayout();
            this.pnlLotList.SuspendLayout();
            this.grpLotList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvspdTerminateCode)).BeginInit();
            this.pnlLotInfo.SuspendLayout();
            this.grpSelLotList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdSelLotList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSelLotList_Sheet1)).BeginInit();
            this.pnlSummaryInfo.SuspendLayout();
            this.pnlLotCondition.SuspendLayout();
            this.grpTerminateInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTerminateCode)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTran
            // 
            this.tabTran.Size = new System.Drawing.Size(736, 510);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 484);
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
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.pnlLotList);
            this.pnlTranInfo.Controls.Add(this.pnlCheck);
            this.pnlTranInfo.Controls.Add(this.pnlConditionInfo);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 481);
            // 
            // tbpLotInfo
            // 
            this.tbpLotInfo.Controls.Add(this.pnlLotInfo);
            this.tbpLotInfo.Size = new System.Drawing.Size(728, 484);
            this.tbpLotInfo.Controls.SetChildIndex(this.pnlComment, 0);
            this.tbpLotInfo.Controls.SetChildIndex(this.pnlLotInfo, 0);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(0, 441);
            this.pnlComment.Size = new System.Drawing.Size(728, 40);
            this.pnlComment.TabIndex = 3;
            // 
            // grpComment
            // 
            this.grpComment.Size = new System.Drawing.Size(722, 40);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(15, 15);
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(120, 13);
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Multi Terminate Lot";
            // 
            // pnlConditionInfo
            // 
            this.pnlConditionInfo.Controls.Add(this.grpConditionInfo);
            this.pnlConditionInfo.Controls.Add(this.udcCondition);
            this.pnlConditionInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConditionInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlConditionInfo.Name = "pnlConditionInfo";
            this.pnlConditionInfo.Size = new System.Drawing.Size(722, 177);
            this.pnlConditionInfo.TabIndex = 0;
            // 
            // grpConditionInfo
            // 
            this.grpConditionInfo.Controls.Add(this.cdvAttributeValue);
            this.grpConditionInfo.Controls.Add(this.lblAttributeValue);
            this.grpConditionInfo.Controls.Add(this.chkZeroQuantityLot);
            this.grpConditionInfo.Controls.Add(this.cdvAttributeName);
            this.grpConditionInfo.Controls.Add(this.lblAttributeName);
            this.grpConditionInfo.Controls.Add(this.cdvFlow);
            this.grpConditionInfo.Controls.Add(this.cdvMaterial);
            this.grpConditionInfo.Controls.Add(this.cdvOperation);
            this.grpConditionInfo.Controls.Add(this.lblOperation);
            this.grpConditionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConditionInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpConditionInfo.Location = new System.Drawing.Point(0, 0);
            this.grpConditionInfo.Name = "grpConditionInfo";
            this.grpConditionInfo.Size = new System.Drawing.Size(722, 91);
            this.grpConditionInfo.TabIndex = 0;
            this.grpConditionInfo.TabStop = false;
            // 
            // cdvAttributeValue
            // 
            this.cdvAttributeValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttributeValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttributeValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttributeValue.BtnToolTipText = "";
            this.cdvAttributeValue.DescText = "";
            this.cdvAttributeValue.DisplaySubItemIndex = -1;
            this.cdvAttributeValue.DisplayText = "";
            this.cdvAttributeValue.Focusing = null;
            this.cdvAttributeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttributeValue.Index = 0;
            this.cdvAttributeValue.IsViewBtnImage = false;
            this.cdvAttributeValue.Location = new System.Drawing.Point(396, 39);
            this.cdvAttributeValue.MaxLength = 1000;
            this.cdvAttributeValue.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttributeValue.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttributeValue.Name = "cdvAttributeValue";
            this.cdvAttributeValue.ReadOnly = false;
            this.cdvAttributeValue.SearchSubItemIndex = 0;
            this.cdvAttributeValue.SelectedDescIndex = -1;
            this.cdvAttributeValue.SelectedSubItemIndex = -1;
            this.cdvAttributeValue.SelectionStart = 0;
            this.cdvAttributeValue.Size = new System.Drawing.Size(180, 20);
            this.cdvAttributeValue.SmallImageList = null;
            this.cdvAttributeValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttributeValue.TabIndex = 7;
            this.cdvAttributeValue.TextBoxToolTipText = "";
            this.cdvAttributeValue.TextBoxWidth = 180;
            this.cdvAttributeValue.VisibleButton = true;
            this.cdvAttributeValue.VisibleColumnHeader = false;
            this.cdvAttributeValue.VisibleDescription = false;
            this.cdvAttributeValue.ButtonPress += new System.EventHandler(this.cdvAttributeValue_ButtonPress);
            // 
            // lblAttributeValue
            // 
            this.lblAttributeValue.AutoSize = true;
            this.lblAttributeValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttributeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttributeValue.Location = new System.Drawing.Point(309, 42);
            this.lblAttributeValue.Name = "lblAttributeValue";
            this.lblAttributeValue.Size = new System.Drawing.Size(76, 13);
            this.lblAttributeValue.TabIndex = 6;
            this.lblAttributeValue.Text = "Attribute Value";
            this.lblAttributeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkZeroQuantityLot
            // 
            this.chkZeroQuantityLot.AutoSize = true;
            this.chkZeroQuantityLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkZeroQuantityLot.Location = new System.Drawing.Point(596, 15);
            this.chkZeroQuantityLot.Name = "chkZeroQuantityLot";
            this.chkZeroQuantityLot.Size = new System.Drawing.Size(114, 18);
            this.chkZeroQuantityLot.TabIndex = 8;
            this.chkZeroQuantityLot.Text = "Zero Quantity Lot";
            // 
            // cdvAttributeName
            // 
            this.cdvAttributeName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttributeName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttributeName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttributeName.BtnToolTipText = "";
            this.cdvAttributeName.DescText = "";
            this.cdvAttributeName.DisplaySubItemIndex = -1;
            this.cdvAttributeName.DisplayText = "";
            this.cdvAttributeName.Focusing = null;
            this.cdvAttributeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttributeName.Index = 0;
            this.cdvAttributeName.IsViewBtnImage = false;
            this.cdvAttributeName.Location = new System.Drawing.Point(396, 14);
            this.cdvAttributeName.MaxLength = 100;
            this.cdvAttributeName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttributeName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttributeName.Name = "cdvAttributeName";
            this.cdvAttributeName.ReadOnly = false;
            this.cdvAttributeName.SearchSubItemIndex = 0;
            this.cdvAttributeName.SelectedDescIndex = -1;
            this.cdvAttributeName.SelectedSubItemIndex = -1;
            this.cdvAttributeName.SelectionStart = 0;
            this.cdvAttributeName.Size = new System.Drawing.Size(180, 20);
            this.cdvAttributeName.SmallImageList = null;
            this.cdvAttributeName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttributeName.TabIndex = 5;
            this.cdvAttributeName.TextBoxToolTipText = "";
            this.cdvAttributeName.TextBoxWidth = 180;
            this.cdvAttributeName.VisibleButton = true;
            this.cdvAttributeName.VisibleColumnHeader = false;
            this.cdvAttributeName.VisibleDescription = false;
            this.cdvAttributeName.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttributeName_SelectedItemChanged);
            this.cdvAttributeName.ButtonPress += new System.EventHandler(this.cdvAttributeName_ButtonPress);
            // 
            // lblAttributeName
            // 
            this.lblAttributeName.AutoSize = true;
            this.lblAttributeName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttributeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttributeName.Location = new System.Drawing.Point(309, 17);
            this.lblAttributeName.Name = "lblAttributeName";
            this.lblAttributeName.Size = new System.Drawing.Size(77, 13);
            this.lblAttributeName.TabIndex = 4;
            this.lblAttributeName.Text = "Attribute Name";
            this.lblAttributeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvFlow.Location = new System.Drawing.Point(12, 63);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(270, 20);
            this.cdvFlow.TabIndex = 3;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 180;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
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
            this.cdvMaterial.Location = new System.Drawing.Point(12, 39);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(270, 20);
            this.cdvMaterial.TabIndex = 2;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 90;
            this.cdvMaterial.WidthMaterialAndVersion = 180;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.VersionChanged += new System.EventHandler(this.cdvMaterial_VersionChanged);
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
            this.cdvOperation.Location = new System.Drawing.Point(102, 15);
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
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(12, 17);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(62, 13);
            this.lblOperation.TabIndex = 0;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcCondition
            // 
            this.udcCondition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.udcCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcCondition.Location = new System.Drawing.Point(0, 91);
            this.udcCondition.Name = "udcCondition";
            this.udcCondition.Size = new System.Drawing.Size(722, 86);
            this.udcCondition.TabIndex = 1;
            // 
            // pnlCheck
            // 
            this.pnlCheck.Controls.Add(this.grpCheck);
            this.pnlCheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCheck.Location = new System.Drawing.Point(3, 180);
            this.pnlCheck.Name = "pnlCheck";
            this.pnlCheck.Padding = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.pnlCheck.Size = new System.Drawing.Size(90, 301);
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
            this.grpCheck.Size = new System.Drawing.Size(86, 297);
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
            this.pnlLotList.Location = new System.Drawing.Point(93, 180);
            this.pnlLotList.Name = "pnlLotList";
            this.pnlLotList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlLotList.Size = new System.Drawing.Size(632, 301);
            this.pnlLotList.TabIndex = 2;
            // 
            // grpLotList
            // 
            this.grpLotList.Controls.Add(this.lisLotList);
            this.grpLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotList.Location = new System.Drawing.Point(0, 4);
            this.grpLotList.Name = "grpLotList";
            this.grpLotList.Size = new System.Drawing.Size(632, 297);
            this.grpLotList.TabIndex = 0;
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
            this.lisLotList.Size = new System.Drawing.Size(626, 278);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            this.lisLotList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lisLotList_ItemChecked);
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
            this.btnView.Location = new System.Drawing.Point(374, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cdvspdTerminateCode
            // 
            this.cdvspdTerminateCode.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvspdTerminateCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvspdTerminateCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvspdTerminateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvspdTerminateCode.Location = new System.Drawing.Point(273, 17);
            this.cdvspdTerminateCode.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvspdTerminateCode.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvspdTerminateCode.Name = "cdvRotate";
            this.cdvspdTerminateCode.Size = new System.Drawing.Size(20, 20);
            this.cdvspdTerminateCode.SmallImageList = null;
            this.cdvspdTerminateCode.TabIndex = 0;
            this.cdvspdTerminateCode.TabStop = false;
            this.cdvspdTerminateCode.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvspdTerminateCode.Visible = false;
            this.cdvspdTerminateCode.VisibleColumnHeader = false;
            this.cdvspdTerminateCode.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvspdTerminateCode_SelectedItemChanged);
            // 
            // pnlLotInfo
            // 
            this.pnlLotInfo.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLotInfo.Controls.Add(this.grpSelLotList);
            this.pnlLotInfo.Controls.Add(this.pnlLotCondition);
            this.pnlLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlLotInfo.Name = "pnlLotInfo";
            this.pnlLotInfo.Size = new System.Drawing.Size(728, 441);
            this.pnlLotInfo.TabIndex = 3;
            // 
            // grpSelLotList
            // 
            this.grpSelLotList.Controls.Add(this.spdSelLotList);
            this.grpSelLotList.Controls.Add(this.pnlSummaryInfo);
            this.grpSelLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSelLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSelLotList.Location = new System.Drawing.Point(0, 65);
            this.grpSelLotList.Name = "grpSelLotList";
            this.grpSelLotList.Size = new System.Drawing.Size(728, 376);
            this.grpSelLotList.TabIndex = 0;
            this.grpSelLotList.TabStop = false;
            this.grpSelLotList.Text = "Lot List";
            // 
            // spdSelLotList
            // 
            this.spdSelLotList.AccessibleDescription = "spdSelLotList, Sheet1, Row 0, Column 0, ";
            this.spdSelLotList.BackColor = System.Drawing.SystemColors.Control;
            this.spdSelLotList.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdSelLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSelLotList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSelLotList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSelLotList.HorizontalScrollBar.Name = "";
            this.spdSelLotList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdSelLotList.HorizontalScrollBar.TabIndex = 42;
            this.spdSelLotList.Location = new System.Drawing.Point(3, 16);
            this.spdSelLotList.Name = "spdSelLotList";
            this.spdSelLotList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdSelLotList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdSelLotList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSelLotList_Sheet1});
            this.spdSelLotList.Size = new System.Drawing.Size(722, 337);
            this.spdSelLotList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSelLotList.TabIndex = 0;
            this.spdSelLotList.TabStop = false;
            this.spdSelLotList.TextTipDelay = 200;
            this.spdSelLotList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdSelLotList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSelLotList.VerticalScrollBar.Name = "";
            this.spdSelLotList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdSelLotList.VerticalScrollBar.TabIndex = 43;
            this.spdSelLotList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdSelLotList_ButtonClicked);
            // 
            // spdSelLotList_Sheet1
            // 
            this.spdSelLotList_Sheet1.Reset();
            spdSelLotList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSelLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSelLotList_Sheet1.ColumnCount = 7;
            spdSelLotList_Sheet1.RowCount = 2;
            this.spdSelLotList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSelLotList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSelLotList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSelLotList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Lot ID";
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Terminate Code";
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Material";
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Qty 1";
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Qty 2";
            this.spdSelLotList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Qty 3";
            this.spdSelLotList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSelLotList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSelLotList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            textCellType1.MaxLength = 25;
            this.spdSelLotList_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdSelLotList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSelLotList_Sheet1.Columns.Get(0).Label = "Lot ID";
            this.spdSelLotList_Sheet1.Columns.Get(0).Locked = true;
            this.spdSelLotList_Sheet1.Columns.Get(0).ShowSortIndicator = false;
            this.spdSelLotList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSelLotList_Sheet1.Columns.Get(0).Width = 110F;
            textCellType2.MaxLength = 10;
            this.spdSelLotList_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.spdSelLotList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSelLotList_Sheet1.Columns.Get(1).Label = "Terminate Code";
            this.spdSelLotList_Sheet1.Columns.Get(1).Locked = false;
            this.spdSelLotList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSelLotList_Sheet1.Columns.Get(1).Width = 98F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdSelLotList_Sheet1.Columns.Get(2).CellType = buttonCellType1;
            this.spdSelLotList_Sheet1.Columns.Get(2).Width = 24F;
            this.spdSelLotList_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdSelLotList_Sheet1.Columns.Get(3).Label = "Material";
            this.spdSelLotList_Sheet1.Columns.Get(3).Locked = true;
            this.spdSelLotList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSelLotList_Sheet1.Columns.Get(3).Width = 149F;
            this.spdSelLotList_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdSelLotList_Sheet1.Columns.Get(4).Label = "Qty 1";
            this.spdSelLotList_Sheet1.Columns.Get(4).Locked = true;
            this.spdSelLotList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSelLotList_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdSelLotList_Sheet1.Columns.Get(5).Label = "Qty 2";
            this.spdSelLotList_Sheet1.Columns.Get(5).Locked = true;
            this.spdSelLotList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSelLotList_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdSelLotList_Sheet1.Columns.Get(6).Label = "Qty 3";
            this.spdSelLotList_Sheet1.Columns.Get(6).Locked = true;
            this.spdSelLotList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSelLotList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdSelLotList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSelLotList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSelLotList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSelLotList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSelLotList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSelLotList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlSummaryInfo
            // 
            this.pnlSummaryInfo.Controls.Add(this.lblTotQty3);
            this.pnlSummaryInfo.Controls.Add(this.lblTotQty2);
            this.pnlSummaryInfo.Controls.Add(this.lblTotQty1);
            this.pnlSummaryInfo.Controls.Add(this.lblTotCnt);
            this.pnlSummaryInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummaryInfo.Location = new System.Drawing.Point(3, 353);
            this.pnlSummaryInfo.Name = "pnlSummaryInfo";
            this.pnlSummaryInfo.Size = new System.Drawing.Size(722, 20);
            this.pnlSummaryInfo.TabIndex = 0;
            // 
            // lblTotQty3
            // 
            this.lblTotQty3.AutoSize = true;
            this.lblTotQty3.Location = new System.Drawing.Point(461, 4);
            this.lblTotQty3.Name = "lblTotQty3";
            this.lblTotQty3.Size = new System.Drawing.Size(38, 13);
            this.lblTotQty3.TabIndex = 3;
            this.lblTotQty3.Text = "Qty3 : ";
            // 
            // lblTotQty2
            // 
            this.lblTotQty2.AutoSize = true;
            this.lblTotQty2.Location = new System.Drawing.Point(324, 4);
            this.lblTotQty2.Name = "lblTotQty2";
            this.lblTotQty2.Size = new System.Drawing.Size(38, 13);
            this.lblTotQty2.TabIndex = 2;
            this.lblTotQty2.Text = "Qty2 : ";
            // 
            // lblTotQty1
            // 
            this.lblTotQty1.AutoSize = true;
            this.lblTotQty1.Location = new System.Drawing.Point(187, 4);
            this.lblTotQty1.Name = "lblTotQty1";
            this.lblTotQty1.Size = new System.Drawing.Size(38, 13);
            this.lblTotQty1.TabIndex = 1;
            this.lblTotQty1.Text = "Qty1 : ";
            // 
            // lblTotCnt
            // 
            this.lblTotCnt.AutoSize = true;
            this.lblTotCnt.Location = new System.Drawing.Point(17, 3);
            this.lblTotCnt.Name = "lblTotCnt";
            this.lblTotCnt.Size = new System.Drawing.Size(71, 13);
            this.lblTotCnt.TabIndex = 0;
            this.lblTotCnt.Text = "Total Count : ";
            // 
            // pnlLotCondition
            // 
            this.pnlLotCondition.Controls.Add(this.grpTerminateInfo);
            this.pnlLotCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLotCondition.Location = new System.Drawing.Point(0, 0);
            this.pnlLotCondition.Name = "pnlLotCondition";
            this.pnlLotCondition.Size = new System.Drawing.Size(728, 65);
            this.pnlLotCondition.TabIndex = 0;
            // 
            // grpTerminateInfo
            // 
            this.grpTerminateInfo.Controls.Add(this.btnApply);
            this.grpTerminateInfo.Controls.Add(this.cdvTerminateCode);
            this.grpTerminateInfo.Controls.Add(this.lblTerminateCode);
            this.grpTerminateInfo.Controls.Add(this.chkBindSameTr);
            this.grpTerminateInfo.Controls.Add(this.chkCommitCond);
            this.grpTerminateInfo.Controls.Add(this.pnlTranTime);
            this.grpTerminateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTerminateInfo.Location = new System.Drawing.Point(0, 0);
            this.grpTerminateInfo.Name = "grpTerminateInfo";
            this.grpTerminateInfo.Size = new System.Drawing.Size(728, 65);
            this.grpTerminateInfo.TabIndex = 0;
            this.grpTerminateInfo.TabStop = false;
            this.grpTerminateInfo.Text = "Terminate Information";
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApply.Location = new System.Drawing.Point(323, 14);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(74, 22);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cdvTerminateCode
            // 
            this.cdvTerminateCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTerminateCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTerminateCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTerminateCode.BtnToolTipText = "";
            this.cdvTerminateCode.DescText = "";
            this.cdvTerminateCode.DisplaySubItemIndex = -1;
            this.cdvTerminateCode.DisplayText = "";
            this.cdvTerminateCode.Focusing = null;
            this.cdvTerminateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTerminateCode.Index = 0;
            this.cdvTerminateCode.IsViewBtnImage = false;
            this.cdvTerminateCode.Location = new System.Drawing.Point(117, 16);
            this.cdvTerminateCode.MaxLength = 12;
            this.cdvTerminateCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTerminateCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTerminateCode.Name = "cdvTerminateCode";
            this.cdvTerminateCode.ReadOnly = false;
            this.cdvTerminateCode.SearchSubItemIndex = 0;
            this.cdvTerminateCode.SelectedDescIndex = -1;
            this.cdvTerminateCode.SelectedSubItemIndex = -1;
            this.cdvTerminateCode.SelectionStart = 0;
            this.cdvTerminateCode.Size = new System.Drawing.Size(200, 20);
            this.cdvTerminateCode.SmallImageList = null;
            this.cdvTerminateCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTerminateCode.TabIndex = 1;
            this.cdvTerminateCode.TextBoxToolTipText = "";
            this.cdvTerminateCode.TextBoxWidth = 200;
            this.cdvTerminateCode.VisibleButton = true;
            this.cdvTerminateCode.VisibleColumnHeader = false;
            this.cdvTerminateCode.VisibleDescription = false;
            this.cdvTerminateCode.ButtonPress += new System.EventHandler(this.cdvTerminateCode_ButtonPress);
            // 
            // lblTerminateCode
            // 
            this.lblTerminateCode.AutoSize = true;
            this.lblTerminateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTerminateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminateCode.Location = new System.Drawing.Point(11, 19);
            this.lblTerminateCode.Name = "lblTerminateCode";
            this.lblTerminateCode.Size = new System.Drawing.Size(96, 13);
            this.lblTerminateCode.TabIndex = 0;
            this.lblTerminateCode.Text = "Terminate Code";
            // 
            // chkBindSameTr
            // 
            this.chkBindSameTr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBindSameTr.AutoSize = true;
            this.chkBindSameTr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkBindSameTr.Location = new System.Drawing.Point(536, 41);
            this.chkBindSameTr.Name = "chkBindSameTr";
            this.chkBindSameTr.Size = new System.Drawing.Size(164, 18);
            this.chkBindSameTr.TabIndex = 4;
            this.chkBindSameTr.Text = "Bind with Same Transaction";
            this.chkBindSameTr.UseVisualStyleBackColor = true;
            // 
            // chkCommitCond
            // 
            this.chkCommitCond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCommitCond.AutoSize = true;
            this.chkCommitCond.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkCommitCond.Location = new System.Drawing.Point(428, 41);
            this.chkCommitCond.Name = "chkCommitCond";
            this.chkCommitCond.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCommitCond.Size = new System.Drawing.Size(94, 18);
            this.chkCommitCond.TabIndex = 3;
            this.chkCommitCond.Text = "Each Commit";
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranTime);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranDate);
            this.pnlTranTime.Location = new System.Drawing.Point(424, 16);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 20);
            this.pnlTranTime.TabIndex = 7;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.Location = new System.Drawing.Point(139, 0);
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
            this.dtpTranTime.Location = new System.Drawing.Point(225, 0);
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
            this.dtpTranDate.Location = new System.Drawing.Point(139, 0);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(86, 20);
            this.dtpTranDate.TabIndex = 2;
            // 
            // frmWIPTranMultiTerminateLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranMultiTerminateLot";
            this.Text = "Multi Terminate Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranMultiTerminateLot_Activated);
            this.Load += new System.EventHandler(this.frmWIPTranMultiTerminateLot_Load);
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
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
            this.pnlTranInfo.ResumeLayout(false);
            this.tbpLotInfo.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlConditionInfo.ResumeLayout(false);
            this.grpConditionInfo.ResumeLayout(false);
            this.grpConditionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttributeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttributeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            this.pnlCheck.ResumeLayout(false);
            this.grpCheck.ResumeLayout(false);
            this.pnlLotList.ResumeLayout(false);
            this.grpLotList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvspdTerminateCode)).EndInit();
            this.pnlLotInfo.ResumeLayout(false);
            this.grpSelLotList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdSelLotList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSelLotList_Sheet1)).EndInit();
            this.pnlSummaryInfo.ResumeLayout(false);
            this.pnlSummaryInfo.PerformLayout();
            this.pnlLotCondition.ResumeLayout(false);
            this.grpTerminateInfo.ResumeLayout(false);
            this.grpTerminateInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTerminateCode)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConditionInfo;
        private System.Windows.Forms.GroupBox grpConditionInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttributeValue;
        private System.Windows.Forms.Label lblAttributeValue;
        private System.Windows.Forms.CheckBox chkZeroQuantityLot;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttributeName;
        private System.Windows.Forms.Label lblAttributeName;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label lblOperation;
        private Miracom.MESCore.Controls.udcFlexibleConditionForLot udcCondition;
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
        private UI.Controls.MCCodeView.MCSPCodeView cdvspdTerminateCode;
        private System.Windows.Forms.Panel pnlLotInfo;
        private System.Windows.Forms.Panel pnlLotCondition;
        private System.Windows.Forms.GroupBox grpTerminateInfo;
        private System.Windows.Forms.Button btnApply;
        private UI.Controls.MCCodeView.MCCodeView cdvTerminateCode;
        private System.Windows.Forms.Label lblTerminateCode;
        private System.Windows.Forms.CheckBox chkBindSameTr;
        private System.Windows.Forms.CheckBox chkCommitCond;
        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        private System.Windows.Forms.GroupBox grpSelLotList;
        private FarPoint.Win.Spread.FpSpread spdSelLotList;
        private FarPoint.Win.Spread.SheetView spdSelLotList_Sheet1;
        private System.Windows.Forms.Panel pnlSummaryInfo;
        private System.Windows.Forms.Label lblTotQty3;
        private System.Windows.Forms.Label lblTotQty2;
        private System.Windows.Forms.Label lblTotQty1;
        private System.Windows.Forms.Label lblTotCnt;
    }
}
