namespace Miracom.WIPCore
{
    partial class frmWIPTranReserveLotBatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPTranReserveLotBatch));
            this.grpBatch = new System.Windows.Forms.GroupBox();
            this.btnInquiryLotList = new System.Windows.Forms.Button();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOper = new System.Windows.Forms.Label();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFlow = new System.Windows.Forms.Label();
            this.cdvMat = new Miracom.MESCore.Controls.udcMaterial();
            this.grpLotList = new System.Windows.Forms.GroupBox();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBatchID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBatchSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReserveBatch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemainQtime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.grpRes = new System.Windows.Forms.GroupBox();
            this.btnApplyBatch = new System.Windows.Forms.Button();
            this.cdvReserveBatchID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblReserveBatchID = new System.Windows.Forms.Label();
            this.cdvRule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRule = new System.Windows.Forms.Label();
            this.cdvResGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResGroup = new System.Windows.Forms.Label();
            this.cdvResType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResType = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNPWAdd = new System.Windows.Forms.Button();
            this.txtNPWID = new System.Windows.Forms.TextBox();
            this.lblAddLot = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlUpDown = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.lisAddLot = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader63 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader101 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader57 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader58 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader59 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader60 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader61 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader64 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader65 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader66 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader67 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader68 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader69 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader70 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader71 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader72 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader73 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader74 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader75 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader76 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader77 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader78 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader79 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader80 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader81 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader82 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader83 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader84 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader85 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader86 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader87 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader88 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader89 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader90 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader91 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader92 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader93 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader94 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader95 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader96 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader97 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader98 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader99 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader100 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.btnInquiryBatch = new System.Windows.Forms.Button();
            this.btnMake = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBatchLotSeq = new System.Windows.Forms.Button();
            this.chkManual = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpBatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            this.grpLotList.SuspendLayout();
            this.grpRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReserveBatchID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlUpDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.chkManual);
            this.pnlBottom.Controls.Add(this.btnBatchLotSeq);
            this.pnlBottom.Controls.Add(this.txtBatchID);
            this.pnlBottom.Controls.Add(this.lblBatchID);
            this.pnlBottom.Controls.Add(this.btnInquiryBatch);
            this.pnlBottom.Controls.Add(this.btnMake);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Location = new System.Drawing.Point(0, 507);
            this.pnlBottom.Size = new System.Drawing.Size(742, 39);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.lisAddLot);
            this.pnlCenter.Controls.Add(this.pnlUpDown);
            this.pnlCenter.Controls.Add(this.grpRes);
            this.pnlCenter.Controls.Add(this.grpLotList);
            this.pnlCenter.Controls.Add(this.grpBatch);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 507);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "BaseForm03";
            // 
            // grpBatch
            // 
            this.grpBatch.Controls.Add(this.btnInquiryLotList);
            this.grpBatch.Controls.Add(this.cdvOper);
            this.grpBatch.Controls.Add(this.lblOper);
            this.grpBatch.Controls.Add(this.cdvFlow);
            this.grpBatch.Controls.Add(this.lblFlow);
            this.grpBatch.Controls.Add(this.cdvMat);
            this.grpBatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBatch.Location = new System.Drawing.Point(3, 0);
            this.grpBatch.Name = "grpBatch";
            this.grpBatch.Size = new System.Drawing.Size(736, 40);
            this.grpBatch.TabIndex = 0;
            this.grpBatch.TabStop = false;
            // 
            // btnInquiryLotList
            // 
            this.btnInquiryLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInquiryLotList.Location = new System.Drawing.Point(680, 13);
            this.btnInquiryLotList.Name = "btnInquiryLotList";
            this.btnInquiryLotList.Size = new System.Drawing.Size(42, 20);
            this.btnInquiryLotList.TabIndex = 5;
            this.btnInquiryLotList.Text = "View";
            this.btnInquiryLotList.Click += new System.EventHandler(this.btnInquiryLotList_Click);
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(557, 13);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(120, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 4;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 120;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvOper_TextBoxKeyPress);
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOper.Location = new System.Drawing.Point(470, 16);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(62, 13);
            this.lblOper.TabIndex = 3;
            this.lblOper.Text = "Operation";
            this.lblOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvFlow.Location = new System.Drawing.Point(312, 13);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(136, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 2;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 136;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlow.Location = new System.Drawing.Point(252, 16);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(29, 13);
            this.lblFlow.TabIndex = 1;
            this.lblFlow.Text = "Flow";
            this.lblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvMat
            // 
            this.cdvMat.AddEmptyRowToLast = false;
            this.cdvMat.AddEmptyRowToTop = false;
            this.cdvMat.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMat.DisplaySubItemIndex = 0;
            this.cdvMat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMat.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMat.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMat.LabelText = "Material";
            this.cdvMat.ListCond_ExtFactory = "";
            this.cdvMat.ListCond_StepMaterial = '1';
            this.cdvMat.ListCond_StepVersion = '1';
            this.cdvMat.Location = new System.Drawing.Point(12, 13);
            this.cdvMat.MaterialEnabled = true;
            this.cdvMat.MaterialReadOnly = false;
            this.cdvMat.Name = "cdvMat";
            this.cdvMat.SearchSubItemIndex = 0;
            this.cdvMat.SelectedDescIndex = -1;
            this.cdvMat.SelectedSubItemIndex = 0;
            this.cdvMat.Size = new System.Drawing.Size(223, 20);
            this.cdvMat.TabIndex = 0;
            this.cdvMat.VersionEnabled = true;
            this.cdvMat.VersionReadOnly = false;
            this.cdvMat.VisibleColumnHeader = false;
            this.cdvMat.VisibleDescription = false;
            this.cdvMat.VisibleMaterialButton = true;
            this.cdvMat.VisibleVersionButton = true;
            this.cdvMat.WidthButton = 20;
            this.cdvMat.WidthLabel = 80;
            this.cdvMat.WidthMaterialAndVersion = 143;
            this.cdvMat.WidthVersion = 50;
            this.cdvMat.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMat_MaterialSelectedItemChanged);
            this.cdvMat.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMat_VersionSelectedItemChanged);
            // 
            // grpLotList
            // 
            this.grpLotList.Controls.Add(this.lisLotList);
            this.grpLotList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotList.Location = new System.Drawing.Point(3, 40);
            this.grpLotList.Name = "grpLotList";
            this.grpLotList.Size = new System.Drawing.Size(736, 181);
            this.grpLotList.TabIndex = 1;
            this.grpLotList.TabStop = false;
            this.grpLotList.Text = "Lot List";
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colLotID,
            this.colBatchID,
            this.colBatchSeq,
            this.colReserveBatch,
            this.colMaterial,
            this.colMatVer,
            this.colFlow,
            this.colFlowSeq,
            this.colOperation,
            this.colQty1,
            this.colQty2,
            this.colQty3,
            this.colRemainQtime,
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
            this.lisLotList.Size = new System.Drawing.Size(730, 162);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            this.lisLotList.SelectedIndexChanged += new System.EventHandler(this.lisLotList_SelectedIndexChanged);
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 40;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 120;
            // 
            // colBatchID
            // 
            this.colBatchID.Text = "Batch ID";
            this.colBatchID.Width = 100;
            // 
            // colBatchSeq
            // 
            this.colBatchSeq.Text = "Batch Seq";
            this.colBatchSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colReserveBatch
            // 
            this.colReserveBatch.Text = "Reserve Batch";
            this.colReserveBatch.Width = 100;
            // 
            // colMaterial
            // 
            this.colMaterial.Text = "Material";
            this.colMaterial.Width = 100;
            // 
            // colMatVer
            // 
            this.colMatVer.Text = "Mat Ver";
            this.colMatVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colFlow
            // 
            this.colFlow.Text = "Flow";
            this.colFlow.Width = 90;
            // 
            // colFlowSeq
            // 
            this.colFlowSeq.Text = "Flow Seq";
            this.colFlowSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // colRemainQtime
            // 
            this.colRemainQtime.Text = "Remain Queue Time";
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
            // grpRes
            // 
            this.grpRes.Controls.Add(this.btnApplyBatch);
            this.grpRes.Controls.Add(this.cdvReserveBatchID);
            this.grpRes.Controls.Add(this.lblReserveBatchID);
            this.grpRes.Controls.Add(this.cdvRule);
            this.grpRes.Controls.Add(this.lblRule);
            this.grpRes.Controls.Add(this.cdvResGrp);
            this.grpRes.Controls.Add(this.lblResGroup);
            this.grpRes.Controls.Add(this.cdvResType);
            this.grpRes.Controls.Add(this.lblResType);
            this.grpRes.Controls.Add(this.btnDel);
            this.grpRes.Controls.Add(this.btnAdd);
            this.grpRes.Controls.Add(this.btnNPWAdd);
            this.grpRes.Controls.Add(this.txtNPWID);
            this.grpRes.Controls.Add(this.lblAddLot);
            this.grpRes.Controls.Add(this.cdvResID);
            this.grpRes.Controls.Add(this.lblResID);
            this.grpRes.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRes.Location = new System.Drawing.Point(3, 221);
            this.grpRes.Name = "grpRes";
            this.grpRes.Size = new System.Drawing.Size(736, 86);
            this.grpRes.TabIndex = 2;
            this.grpRes.TabStop = false;
            // 
            // btnApplyBatch
            // 
            this.btnApplyBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApplyBatch.Location = new System.Drawing.Point(591, 10);
            this.btnApplyBatch.Name = "btnApplyBatch";
            this.btnApplyBatch.Size = new System.Drawing.Size(130, 24);
            this.btnApplyBatch.TabIndex = 13;
            this.btnApplyBatch.Text = "Apply Batch ID";
            this.btnApplyBatch.Click += new System.EventHandler(this.btnApplyBatch_Click);
            // 
            // cdvReserveBatchID
            // 
            this.cdvReserveBatchID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReserveBatchID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReserveBatchID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvReserveBatchID.BtnToolTipText = "";
            this.cdvReserveBatchID.DescText = "";
            this.cdvReserveBatchID.DisplaySubItemIndex = -1;
            this.cdvReserveBatchID.DisplayText = "";
            this.cdvReserveBatchID.Focusing = null;
            this.cdvReserveBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReserveBatchID.Index = 0;
            this.cdvReserveBatchID.IsViewBtnImage = false;
            this.cdvReserveBatchID.Location = new System.Drawing.Point(391, 12);
            this.cdvReserveBatchID.MaxLength = 30;
            this.cdvReserveBatchID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvReserveBatchID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvReserveBatchID.Name = "cdvReserveBatchID";
            this.cdvReserveBatchID.ReadOnly = true;
            this.cdvReserveBatchID.SearchSubItemIndex = 0;
            this.cdvReserveBatchID.SelectedDescIndex = -1;
            this.cdvReserveBatchID.SelectedSubItemIndex = -1;
            this.cdvReserveBatchID.SelectionStart = 0;
            this.cdvReserveBatchID.Size = new System.Drawing.Size(158, 20);
            this.cdvReserveBatchID.SmallImageList = null;
            this.cdvReserveBatchID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvReserveBatchID.TabIndex = 7;
            this.cdvReserveBatchID.TextBoxToolTipText = "";
            this.cdvReserveBatchID.TextBoxWidth = 158;
            this.cdvReserveBatchID.VisibleButton = true;
            this.cdvReserveBatchID.VisibleColumnHeader = false;
            this.cdvReserveBatchID.VisibleDescription = false;
            // 
            // lblReserveBatchID
            // 
            this.lblReserveBatchID.AutoSize = true;
            this.lblReserveBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReserveBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReserveBatchID.Location = new System.Drawing.Point(289, 15);
            this.lblReserveBatchID.Name = "lblReserveBatchID";
            this.lblReserveBatchID.Size = new System.Drawing.Size(92, 13);
            this.lblReserveBatchID.TabIndex = 6;
            this.lblReserveBatchID.Text = "Reserve Batch ID";
            this.lblReserveBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvRule
            // 
            this.cdvRule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRule.BtnToolTipText = "";
            this.cdvRule.DescText = "";
            this.cdvRule.DisplaySubItemIndex = -1;
            this.cdvRule.DisplayText = "";
            this.cdvRule.Focusing = null;
            this.cdvRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRule.Index = 0;
            this.cdvRule.IsViewBtnImage = false;
            this.cdvRule.Location = new System.Drawing.Point(391, 36);
            this.cdvRule.MaxLength = 20;
            this.cdvRule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRule.Name = "cdvRule";
            this.cdvRule.ReadOnly = false;
            this.cdvRule.SearchSubItemIndex = 0;
            this.cdvRule.SelectedDescIndex = -1;
            this.cdvRule.SelectedSubItemIndex = -1;
            this.cdvRule.SelectionStart = 0;
            this.cdvRule.Size = new System.Drawing.Size(158, 20);
            this.cdvRule.SmallImageList = null;
            this.cdvRule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRule.TabIndex = 9;
            this.cdvRule.TextBoxToolTipText = "";
            this.cdvRule.TextBoxWidth = 158;
            this.cdvRule.VisibleButton = true;
            this.cdvRule.VisibleColumnHeader = false;
            this.cdvRule.VisibleDescription = false;
            this.cdvRule.ButtonPress += new System.EventHandler(this.cdvRule_ButtonPress);
            // 
            // lblRule
            // 
            this.lblRule.AutoSize = true;
            this.lblRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRule.Location = new System.Drawing.Point(289, 40);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new System.Drawing.Size(71, 13);
            this.lblRule.TabIndex = 8;
            this.lblRule.Text = "Creation Rule";
            this.lblRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvResGrp
            // 
            this.cdvResGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp.BtnToolTipText = "";
            this.cdvResGrp.DescText = "";
            this.cdvResGrp.DisplaySubItemIndex = -1;
            this.cdvResGrp.DisplayText = "";
            this.cdvResGrp.Focusing = null;
            this.cdvResGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp.Index = 0;
            this.cdvResGrp.IsViewBtnImage = false;
            this.cdvResGrp.Location = new System.Drawing.Point(111, 36);
            this.cdvResGrp.MaxLength = 20;
            this.cdvResGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp.Name = "cdvResGrp";
            this.cdvResGrp.ReadOnly = false;
            this.cdvResGrp.SearchSubItemIndex = 0;
            this.cdvResGrp.SelectedDescIndex = -1;
            this.cdvResGrp.SelectedSubItemIndex = -1;
            this.cdvResGrp.SelectionStart = 0;
            this.cdvResGrp.Size = new System.Drawing.Size(136, 20);
            this.cdvResGrp.SmallImageList = null;
            this.cdvResGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp.TabIndex = 3;
            this.cdvResGrp.TextBoxToolTipText = "";
            this.cdvResGrp.TextBoxWidth = 136;
            this.cdvResGrp.VisibleButton = true;
            this.cdvResGrp.VisibleColumnHeader = false;
            this.cdvResGrp.VisibleDescription = false;
            this.cdvResGrp.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResGrp_SelectedItemChanged);
            this.cdvResGrp.ButtonPress += new System.EventHandler(this.cdvResGrp_ButtonPress);
            this.cdvResGrp.TextBoxTextChanged += new System.EventHandler(this.cdvResGrp_TextBoxTextChanged);
            // 
            // lblResGroup
            // 
            this.lblResGroup.AutoSize = true;
            this.lblResGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResGroup.Location = new System.Drawing.Point(9, 40);
            this.lblResGroup.Name = "lblResGroup";
            this.lblResGroup.Size = new System.Drawing.Size(85, 13);
            this.lblResGroup.TabIndex = 2;
            this.lblResGroup.Text = "Resource Group";
            this.lblResGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvResType
            // 
            this.cdvResType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResType.BtnToolTipText = "";
            this.cdvResType.DescText = "";
            this.cdvResType.DisplaySubItemIndex = -1;
            this.cdvResType.DisplayText = "";
            this.cdvResType.Focusing = null;
            this.cdvResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResType.Index = 0;
            this.cdvResType.IsViewBtnImage = false;
            this.cdvResType.Location = new System.Drawing.Point(111, 60);
            this.cdvResType.MaxLength = 20;
            this.cdvResType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResType.Name = "cdvResType";
            this.cdvResType.ReadOnly = false;
            this.cdvResType.SearchSubItemIndex = 0;
            this.cdvResType.SelectedDescIndex = -1;
            this.cdvResType.SelectedSubItemIndex = -1;
            this.cdvResType.SelectionStart = 0;
            this.cdvResType.Size = new System.Drawing.Size(136, 20);
            this.cdvResType.SmallImageList = null;
            this.cdvResType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResType.TabIndex = 5;
            this.cdvResType.TextBoxToolTipText = "";
            this.cdvResType.TextBoxWidth = 136;
            this.cdvResType.VisibleButton = true;
            this.cdvResType.VisibleColumnHeader = false;
            this.cdvResType.VisibleDescription = false;
            this.cdvResType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResType_SelectedItemChanged);
            this.cdvResType.ButtonPress += new System.EventHandler(this.cdvResType_ButtonPress);
            this.cdvResType.TextBoxTextChanged += new System.EventHandler(this.cdvResType_TextBoxTextChanged);
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResType.Location = new System.Drawing.Point(9, 64);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(80, 13);
            this.lblResType.TabIndex = 4;
            this.lblResType.Text = "Resource Type";
            this.lblResType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(657, 46);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 15;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(630, 46);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNPWAdd
            // 
            this.btnNPWAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnNPWAdd.Image")));
            this.btnNPWAdd.Location = new System.Drawing.Point(528, 60);
            this.btnNPWAdd.Name = "btnNPWAdd";
            this.btnNPWAdd.Size = new System.Drawing.Size(21, 21);
            this.btnNPWAdd.TabIndex = 12;
            this.btnNPWAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNPWAdd.Click += new System.EventHandler(this.btnNPWAdd_Click);
            // 
            // txtNPWID
            // 
            this.txtNPWID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtNPWID.Location = new System.Drawing.Point(391, 60);
            this.txtNPWID.MaxLength = 25;
            this.txtNPWID.Name = "txtNPWID";
            this.txtNPWID.Size = new System.Drawing.Size(137, 20);
            this.txtNPWID.TabIndex = 11;
            this.txtNPWID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNPWID_KeyPress);
            // 
            // lblAddLot
            // 
            this.lblAddLot.AutoSize = true;
            this.lblAddLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddLot.Location = new System.Drawing.Point(289, 63);
            this.lblAddLot.Name = "lblAddLot";
            this.lblAddLot.Size = new System.Drawing.Size(47, 13);
            this.lblAddLot.TabIndex = 10;
            this.lblAddLot.Text = "NPW ID";
            this.lblAddLot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(111, 12);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(136, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 136;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(9, 16);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUpDown
            // 
            this.pnlUpDown.Controls.Add(this.btnUp);
            this.pnlUpDown.Controls.Add(this.btnDown);
            this.pnlUpDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUpDown.Location = new System.Drawing.Point(704, 307);
            this.pnlUpDown.Name = "pnlUpDown";
            this.pnlUpDown.Size = new System.Drawing.Size(35, 200);
            this.pnlUpDown.TabIndex = 4;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(5, 85);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 0;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(5, 109);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 1;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // lisAddLot
            // 
            this.lisAddLot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader62,
            this.columnHeader63,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader101,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader41,
            this.columnHeader42,
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48,
            this.columnHeader49,
            this.columnHeader50,
            this.columnHeader51,
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader54,
            this.columnHeader55,
            this.columnHeader56,
            this.columnHeader57,
            this.columnHeader58,
            this.columnHeader59,
            this.columnHeader60,
            this.columnHeader61,
            this.columnHeader64,
            this.columnHeader65,
            this.columnHeader66,
            this.columnHeader67,
            this.columnHeader68,
            this.columnHeader69,
            this.columnHeader70,
            this.columnHeader71,
            this.columnHeader72,
            this.columnHeader73,
            this.columnHeader74,
            this.columnHeader75,
            this.columnHeader76,
            this.columnHeader77,
            this.columnHeader78,
            this.columnHeader79,
            this.columnHeader80,
            this.columnHeader81,
            this.columnHeader82,
            this.columnHeader83,
            this.columnHeader84,
            this.columnHeader85,
            this.columnHeader86,
            this.columnHeader87,
            this.columnHeader88,
            this.columnHeader89,
            this.columnHeader90,
            this.columnHeader91,
            this.columnHeader92,
            this.columnHeader93,
            this.columnHeader94,
            this.columnHeader95,
            this.columnHeader96,
            this.columnHeader97,
            this.columnHeader98,
            this.columnHeader99,
            this.columnHeader100});
            this.lisAddLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAddLot.EnableSort = true;
            this.lisAddLot.EnableSortIcon = true;
            this.lisAddLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAddLot.FullRowSelect = true;
            this.lisAddLot.Location = new System.Drawing.Point(3, 307);
            this.lisAddLot.Name = "lisAddLot";
            this.lisAddLot.Size = new System.Drawing.Size(701, 200);
            this.lisAddLot.TabIndex = 3;
            this.lisAddLot.UseCompatibleStateImageBehavior = false;
            this.lisAddLot.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Seq";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lot ID";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader62
            // 
            this.columnHeader62.Text = "Batch ID";
            // 
            // columnHeader63
            // 
            this.columnHeader63.Text = "Reserve Batch";
            this.columnHeader63.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Material";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Mat Ver";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Flow";
            this.columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Flow Seq";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Operation";
            this.columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Qty 1";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Qty 2";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Qty3";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader101
            // 
            this.columnHeader101.Text = "Remain Queue Time";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Lot Type";
            this.columnHeader13.Width = 70;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Owner Code";
            this.columnHeader14.Width = 90;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Create Code";
            this.columnHeader15.Width = 90;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Priority";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Lot Status";
            this.columnHeader17.Width = 80;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Hold Flag";
            this.columnHeader18.Width = 80;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Hold Code";
            this.columnHeader19.Width = 80;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Create Qty 1";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader20.Width = 100;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Create Qty 2";
            this.columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader21.Width = 100;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Create Qty 3";
            this.columnHeader22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader22.Width = 100;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Oper In Qty 1";
            this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader23.Width = 100;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Oper In Qty 2";
            this.columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader24.Width = 100;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Oper In Qty 3";
            this.columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader25.Width = 100;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Inventory Flag";
            this.columnHeader26.Width = 100;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Transit Flag";
            this.columnHeader27.Width = 100;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Unit Exist Flag";
            this.columnHeader28.Width = 100;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Inv Unit";
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Rework Flag";
            this.columnHeader30.Width = 120;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Rework Code";
            this.columnHeader31.Width = 120;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Rework Count";
            this.columnHeader32.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader32.Width = 120;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "Rework Ret Flow";
            this.columnHeader33.Width = 120;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Rework Ret Oper";
            this.columnHeader34.Width = 120;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "Rework End Flow";
            this.columnHeader35.Width = 120;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "Rework End Oper";
            this.columnHeader36.Width = 120;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Rework Ret Clear Flag";
            this.columnHeader37.Width = 155;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Rework Time";
            this.columnHeader38.Width = 120;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "NSTD Flag";
            this.columnHeader39.Width = 120;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "NSTD Ret Flow";
            this.columnHeader40.Width = 120;
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "NSTD Ret Oper";
            this.columnHeader41.Width = 120;
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "NSTD Time";
            this.columnHeader42.Width = 120;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "Start Flag";
            this.columnHeader43.Width = 70;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "Start Time";
            this.columnHeader44.Width = 120;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "Start Res ID";
            this.columnHeader45.Width = 80;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "End Flag";
            this.columnHeader46.Width = 70;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "End Time";
            this.columnHeader47.Width = 120;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "End Res ID";
            this.columnHeader48.Width = 80;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "Sample Flag";
            this.columnHeader49.Width = 100;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "Sample Wait Flag";
            this.columnHeader50.Width = 110;
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "Sample Result";
            this.columnHeader51.Width = 100;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "From To Lot ID";
            this.columnHeader52.Width = 120;
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "Ship Code";
            this.columnHeader53.Width = 80;
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "Ship Time";
            this.columnHeader54.Width = 120;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "Original Due Time";
            this.columnHeader55.Width = 120;
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "Scheduled Due Time";
            this.columnHeader56.Width = 145;
            // 
            // columnHeader57
            // 
            this.columnHeader57.Text = "Create Time";
            this.columnHeader57.Width = 120;
            // 
            // columnHeader58
            // 
            this.columnHeader58.Text = "Factory In Time";
            this.columnHeader58.Width = 120;
            // 
            // columnHeader59
            // 
            this.columnHeader59.Text = "Flow In Time";
            this.columnHeader59.Width = 120;
            // 
            // columnHeader60
            // 
            this.columnHeader60.Text = "Oper In Time";
            this.columnHeader60.Width = 120;
            // 
            // columnHeader61
            // 
            this.columnHeader61.Text = "Reserve Res ID";
            this.columnHeader61.Width = 120;
            // 
            // columnHeader64
            // 
            this.columnHeader64.Text = "Order ID";
            this.columnHeader64.Width = 100;
            // 
            // columnHeader65
            // 
            this.columnHeader65.Text = "Add Order ID 1";
            this.columnHeader65.Width = 100;
            // 
            // columnHeader66
            // 
            this.columnHeader66.Text = "Add Order ID 2";
            this.columnHeader66.Width = 100;
            // 
            // columnHeader67
            // 
            this.columnHeader67.Text = "Add Order ID 3";
            this.columnHeader67.Width = 100;
            // 
            // columnHeader68
            // 
            this.columnHeader68.Text = "Location";
            this.columnHeader68.Width = 80;
            // 
            // columnHeader69
            // 
            this.columnHeader69.Text = "Lot Cmf 1";
            this.columnHeader69.Width = 100;
            // 
            // columnHeader70
            // 
            this.columnHeader70.Text = "Lot Cmf 2";
            this.columnHeader70.Width = 100;
            // 
            // columnHeader71
            // 
            this.columnHeader71.Text = "Lot Cmf 3";
            this.columnHeader71.Width = 100;
            // 
            // columnHeader72
            // 
            this.columnHeader72.Text = "Lot Cmf 4";
            this.columnHeader72.Width = 100;
            // 
            // columnHeader73
            // 
            this.columnHeader73.Text = "Lot Cmf 5";
            this.columnHeader73.Width = 100;
            // 
            // columnHeader74
            // 
            this.columnHeader74.Text = "Lot Cmf 6";
            this.columnHeader74.Width = 100;
            // 
            // columnHeader75
            // 
            this.columnHeader75.Text = "Lot Cmf 7";
            this.columnHeader75.Width = 100;
            // 
            // columnHeader76
            // 
            this.columnHeader76.Text = "Lot Cmf 8";
            this.columnHeader76.Width = 100;
            // 
            // columnHeader77
            // 
            this.columnHeader77.Text = "Lot Cmf 9";
            this.columnHeader77.Width = 100;
            // 
            // columnHeader78
            // 
            this.columnHeader78.Text = "Lot Cmf 10";
            this.columnHeader78.Width = 100;
            // 
            // columnHeader79
            // 
            this.columnHeader79.Text = "Lot Cmf 11";
            this.columnHeader79.Width = 100;
            // 
            // columnHeader80
            // 
            this.columnHeader80.Text = "Lot Cmf 12";
            this.columnHeader80.Width = 100;
            // 
            // columnHeader81
            // 
            this.columnHeader81.Text = "Lot Cmf 13";
            this.columnHeader81.Width = 100;
            // 
            // columnHeader82
            // 
            this.columnHeader82.Text = "Lot Cmf 14";
            this.columnHeader82.Width = 100;
            // 
            // columnHeader83
            // 
            this.columnHeader83.Text = "Lot Cmf 15";
            this.columnHeader83.Width = 100;
            // 
            // columnHeader84
            // 
            this.columnHeader84.Text = "Lot Cmf 16";
            this.columnHeader84.Width = 100;
            // 
            // columnHeader85
            // 
            this.columnHeader85.Text = "Lot Cmf 17";
            this.columnHeader85.Width = 100;
            // 
            // columnHeader86
            // 
            this.columnHeader86.Text = "Lot Cmf 18";
            this.columnHeader86.Width = 100;
            // 
            // columnHeader87
            // 
            this.columnHeader87.Text = "Lot Cmf 19";
            this.columnHeader87.Width = 100;
            // 
            // columnHeader88
            // 
            this.columnHeader88.Text = "Lot Cmf 20";
            this.columnHeader88.Width = 100;
            // 
            // columnHeader89
            // 
            this.columnHeader89.Text = "BOM Set ID";
            this.columnHeader89.Width = 100;
            // 
            // columnHeader90
            // 
            this.columnHeader90.Text = "BOM Set Version";
            this.columnHeader90.Width = 120;
            // 
            // columnHeader91
            // 
            this.columnHeader91.Text = "BOM Act Hist Seq";
            this.columnHeader91.Width = 120;
            // 
            // columnHeader92
            // 
            this.columnHeader92.Text = "BOM Hist Seq";
            this.columnHeader92.Width = 100;
            // 
            // columnHeader93
            // 
            this.columnHeader93.Text = "Lot Delete Flag";
            this.columnHeader93.Width = 100;
            // 
            // columnHeader94
            // 
            this.columnHeader94.Text = "Lot Delete Time";
            this.columnHeader94.Width = 120;
            // 
            // columnHeader95
            // 
            this.columnHeader95.Text = "Lot Delete Reason";
            this.columnHeader95.Width = 150;
            // 
            // columnHeader96
            // 
            this.columnHeader96.Text = "Last Trans Code";
            this.columnHeader96.Width = 120;
            // 
            // columnHeader97
            // 
            this.columnHeader97.Text = "Last Trans Time";
            this.columnHeader97.Width = 120;
            // 
            // columnHeader98
            // 
            this.columnHeader98.Text = "Last Comment";
            this.columnHeader98.Width = 200;
            // 
            // columnHeader99
            // 
            this.columnHeader99.Text = "Last Active Hist Seq";
            this.columnHeader99.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader99.Width = 140;
            // 
            // columnHeader100
            // 
            this.columnHeader100.Text = "Last Hist Seq";
            this.columnHeader100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader100.Width = 120;
            // 
            // txtBatchID
            // 
            this.txtBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBatchID.Location = new System.Drawing.Point(125, 9);
            this.txtBatchID.MaxLength = 25;
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.Size = new System.Drawing.Size(160, 20);
            this.txtBatchID.TabIndex = 1;
            this.txtBatchID.TextChanged += new System.EventHandler(this.txtBatchID_TextChanged);
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchID.Location = new System.Drawing.Point(9, 12);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(108, 13);
            this.lblBatchID.TabIndex = 0;
            this.lblBatchID.Text = "Reserve Batch ID";
            this.lblBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInquiryBatch
            // 
            this.btnInquiryBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInquiryBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInquiryBatch.Location = new System.Drawing.Point(376, 7);
            this.btnInquiryBatch.Name = "btnInquiryBatch";
            this.btnInquiryBatch.Size = new System.Drawing.Size(88, 26);
            this.btnInquiryBatch.TabIndex = 3;
            this.btnInquiryBatch.Text = "Inquiry Batch";
            this.btnInquiryBatch.Click += new System.EventHandler(this.btnInquiryBatch_Click);
            // 
            // btnMake
            // 
            this.btnMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMake.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMake.Location = new System.Drawing.Point(558, 7);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(88, 26);
            this.btnMake.TabIndex = 5;
            this.btnMake.Text = "Reserve Batch";
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(649, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBatchLotSeq
            // 
            this.btnBatchLotSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchLotSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBatchLotSeq.Location = new System.Drawing.Point(467, 7);
            this.btnBatchLotSeq.Name = "btnBatchLotSeq";
            this.btnBatchLotSeq.Size = new System.Drawing.Size(88, 26);
            this.btnBatchLotSeq.TabIndex = 4;
            this.btnBatchLotSeq.Text = "Change Seq.";
            this.btnBatchLotSeq.Click += new System.EventHandler(this.btnBatchLotSeq_Click);
            // 
            // chkManual
            // 
            this.chkManual.AutoSize = true;
            this.chkManual.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkManual.Location = new System.Drawing.Point(291, 11);
            this.chkManual.Name = "chkManual";
            this.chkManual.Size = new System.Drawing.Size(67, 18);
            this.chkManual.TabIndex = 2;
            this.chkManual.Text = "Manual";
            this.chkManual.UseVisualStyleBackColor = true;
            // 
            // frmWIPTranReserveLotBatch
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranReserveLotBatch";
            this.Text = "Reserve Lot Batch";
            this.Load += new System.EventHandler(this.frmWIPTranReserveLotBatch_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpBatch.ResumeLayout(false);
            this.grpBatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            this.grpLotList.ResumeLayout(false);
            this.grpRes.ResumeLayout(false);
            this.grpRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReserveBatchID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlUpDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBatch;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private System.Windows.Forms.Label lblOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMat;
        private System.Windows.Forms.GroupBox grpLotList;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colMaterial;
        private System.Windows.Forms.ColumnHeader colMatVer;
        private System.Windows.Forms.ColumnHeader colFlow;
        private System.Windows.Forms.ColumnHeader colFlowSeq;
        private System.Windows.Forms.ColumnHeader colOperation;
        private System.Windows.Forms.ColumnHeader colQty1;
        private System.Windows.Forms.ColumnHeader colQty2;
        private System.Windows.Forms.ColumnHeader colQty3;
        private System.Windows.Forms.ColumnHeader colRemainQtime;
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
        private System.Windows.Forms.GroupBox grpRes;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnNPWAdd;
        private System.Windows.Forms.TextBox txtNPWID;
        private System.Windows.Forms.Label lblAddLot;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Panel pnlUpDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private Miracom.UI.Controls.MCListView.MCListView lisAddLot;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader101;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.ColumnHeader columnHeader41;
        private System.Windows.Forms.ColumnHeader columnHeader42;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.ColumnHeader columnHeader47;
        private System.Windows.Forms.ColumnHeader columnHeader48;
        private System.Windows.Forms.ColumnHeader columnHeader49;
        private System.Windows.Forms.ColumnHeader columnHeader50;
        private System.Windows.Forms.ColumnHeader columnHeader51;
        private System.Windows.Forms.ColumnHeader columnHeader52;
        private System.Windows.Forms.ColumnHeader columnHeader53;
        private System.Windows.Forms.ColumnHeader columnHeader54;
        private System.Windows.Forms.ColumnHeader columnHeader55;
        private System.Windows.Forms.ColumnHeader columnHeader56;
        private System.Windows.Forms.ColumnHeader columnHeader57;
        private System.Windows.Forms.ColumnHeader columnHeader58;
        private System.Windows.Forms.ColumnHeader columnHeader59;
        private System.Windows.Forms.ColumnHeader columnHeader60;
        private System.Windows.Forms.ColumnHeader columnHeader61;
        private System.Windows.Forms.ColumnHeader columnHeader62;
        private System.Windows.Forms.ColumnHeader columnHeader63;
        private System.Windows.Forms.ColumnHeader columnHeader64;
        private System.Windows.Forms.ColumnHeader columnHeader65;
        private System.Windows.Forms.ColumnHeader columnHeader66;
        private System.Windows.Forms.ColumnHeader columnHeader67;
        private System.Windows.Forms.ColumnHeader columnHeader68;
        private System.Windows.Forms.ColumnHeader columnHeader69;
        private System.Windows.Forms.ColumnHeader columnHeader70;
        private System.Windows.Forms.ColumnHeader columnHeader71;
        private System.Windows.Forms.ColumnHeader columnHeader72;
        private System.Windows.Forms.ColumnHeader columnHeader73;
        private System.Windows.Forms.ColumnHeader columnHeader74;
        private System.Windows.Forms.ColumnHeader columnHeader75;
        private System.Windows.Forms.ColumnHeader columnHeader76;
        private System.Windows.Forms.ColumnHeader columnHeader77;
        private System.Windows.Forms.ColumnHeader columnHeader78;
        private System.Windows.Forms.ColumnHeader columnHeader79;
        private System.Windows.Forms.ColumnHeader columnHeader80;
        private System.Windows.Forms.ColumnHeader columnHeader81;
        private System.Windows.Forms.ColumnHeader columnHeader82;
        private System.Windows.Forms.ColumnHeader columnHeader83;
        private System.Windows.Forms.ColumnHeader columnHeader84;
        private System.Windows.Forms.ColumnHeader columnHeader85;
        private System.Windows.Forms.ColumnHeader columnHeader86;
        private System.Windows.Forms.ColumnHeader columnHeader87;
        private System.Windows.Forms.ColumnHeader columnHeader88;
        private System.Windows.Forms.ColumnHeader columnHeader89;
        private System.Windows.Forms.ColumnHeader columnHeader90;
        private System.Windows.Forms.ColumnHeader columnHeader91;
        private System.Windows.Forms.ColumnHeader columnHeader92;
        private System.Windows.Forms.ColumnHeader columnHeader93;
        private System.Windows.Forms.ColumnHeader columnHeader94;
        private System.Windows.Forms.ColumnHeader columnHeader95;
        private System.Windows.Forms.ColumnHeader columnHeader96;
        private System.Windows.Forms.ColumnHeader columnHeader97;
        private System.Windows.Forms.ColumnHeader columnHeader98;
        private System.Windows.Forms.ColumnHeader columnHeader99;
        private System.Windows.Forms.ColumnHeader columnHeader100;
        private System.Windows.Forms.TextBox txtBatchID;
        private System.Windows.Forms.Label lblBatchID;
        private System.Windows.Forms.Button btnInquiryBatch;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.Button btnClose;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRule;
        private System.Windows.Forms.Label lblRule;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp;
        private System.Windows.Forms.Label lblResGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResType;
        private System.Windows.Forms.Label lblResType;
        private System.Windows.Forms.Button btnBatchLotSeq;
        private System.Windows.Forms.ColumnHeader colReserveBatch;
        private System.Windows.Forms.Button btnInquiryLotList;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvReserveBatchID;
        private System.Windows.Forms.Label lblReserveBatchID;
        private System.Windows.Forms.Button btnApplyBatch;
        private System.Windows.Forms.CheckBox chkManual;
    }
}
