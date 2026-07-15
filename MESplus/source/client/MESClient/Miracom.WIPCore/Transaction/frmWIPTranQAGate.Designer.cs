
namespace Miracom.WIPCore
{
	partial class frmWIPTranQAGate
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
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
            this.tbpDefect1 = new System.Windows.Forms.TabPage();
            this.pnlUnitMid = new System.Windows.Forms.Panel();
            this.grpUnit2 = new System.Windows.Forms.GroupBox();
            this.txtUnit2Qty10 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit2Qty9 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit2Qty8 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit2Qty7 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit2Qty6 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit2Qty5 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit2Qty4 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit2Qty3 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit2Qty2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit2Qty1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblUnit2Qty = new System.Windows.Forms.Label();
            this.lblUnit2Code = new System.Windows.Forms.Label();
            this.cdvUnit2Code10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2Code9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2Code8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2Code7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2Code6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2Code5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2Code4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2Code3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2Code2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2Code1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblB30 = new System.Windows.Forms.Label();
            this.lblB29 = new System.Windows.Forms.Label();
            this.lblB28 = new System.Windows.Forms.Label();
            this.lblB27 = new System.Windows.Forms.Label();
            this.lblB26 = new System.Windows.Forms.Label();
            this.lblB25 = new System.Windows.Forms.Label();
            this.lblB24 = new System.Windows.Forms.Label();
            this.lblB23 = new System.Windows.Forms.Label();
            this.lblB22 = new System.Windows.Forms.Label();
            this.lblB21 = new System.Windows.Forms.Label();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.grpUnit1 = new System.Windows.Forms.GroupBox();
            this.txtUnit1Qty10 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit1Qty9 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit1Qty8 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit1Qty7 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit1Qty6 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit1Qty5 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit1Qty4 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit1Qty3 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit1Qty2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit1Qty1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblUnit1Qty = new System.Windows.Forms.Label();
            this.lblUnit1Code = new System.Windows.Forms.Label();
            this.cdvUnit1Code10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1Code9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1Code8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1Code7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1Code6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1Code5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1Code4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1Code3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1Code2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1Code1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblB20 = new System.Windows.Forms.Label();
            this.lblB19 = new System.Windows.Forms.Label();
            this.lblB18 = new System.Windows.Forms.Label();
            this.lblB17 = new System.Windows.Forms.Label();
            this.lblB16 = new System.Windows.Forms.Label();
            this.lblB15 = new System.Windows.Forms.Label();
            this.lblB14 = new System.Windows.Forms.Label();
            this.lblB13 = new System.Windows.Forms.Label();
            this.lblB12 = new System.Windows.Forms.Label();
            this.lblB11 = new System.Windows.Forms.Label();
            this.pnlUnitTop = new System.Windows.Forms.Panel();
            this.grpQty = new System.Windows.Forms.GroupBox();
            this.txtDefQty2 = new System.Windows.Forms.TextBox();
            this.txtDefQty1 = new System.Windows.Forms.TextBox();
            this.lblDefQty2 = new System.Windows.Forms.Label();
            this.lblDefQty1 = new System.Windows.Forms.Label();
            this.txtLotQty2 = new System.Windows.Forms.TextBox();
            this.txtLotQty1 = new System.Windows.Forms.TextBox();
            this.lblLotQyt2 = new System.Windows.Forms.Label();
            this.lblLotQty1 = new System.Windows.Forms.Label();
            this.txtOutQty2 = new System.Windows.Forms.TextBox();
            this.txtOutQty1 = new System.Windows.Forms.TextBox();
            this.txtLotSMPQty2 = new System.Windows.Forms.TextBox();
            this.txtLotSMPQty1 = new System.Windows.Forms.TextBox();
            this.lblOutQty2 = new System.Windows.Forms.Label();
            this.lblOutQty1 = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.tbpDefect2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.spdDefectData = new FarPoint.Win.Spread.FpSpread();
            this.spdDefectData_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.pnlWafer = new System.Windows.Forms.Panel();
            this.chkWaferSelect = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lisSubLot = new System.Windows.Forms.ListView();
            this.colSlotNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubLot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDefectQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOutQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYield = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSMPQty_2 = new System.Windows.Forms.TextBox();
            this.txtSMPQty_1 = new System.Windows.Forms.TextBox();
            this.lblSMPQty_2 = new System.Windows.Forms.Label();
            this.lblSMPQty_1 = new System.Windows.Forms.Label();
            this.txtLotQty_2 = new System.Windows.Forms.TextBox();
            this.txtLotQty_1 = new System.Windows.Forms.TextBox();
            this.lblLotQty_2 = new System.Windows.Forms.Label();
            this.lblLotQty_1 = new System.Windows.Forms.Label();
            this.txtTotlYield = new System.Windows.Forms.TextBox();
            this.txtDefectCount = new System.Windows.Forms.TextBox();
            this.txtTotDefQty = new System.Windows.Forms.TextBox();
            this.txtDefSubLotCnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalDefectCount = new System.Windows.Forms.Label();
            this.lblTotalDefectQty = new System.Windows.Forms.Label();
            this.lblDefectSubLotCount = new System.Windows.Forms.Label();
            this.cdvSublotID = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvDefect = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.pnlTranInfo.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            this.grpLotInfo.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTran.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.grpCMF.SuspendLayout();
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
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpLoss.SuspendLayout();
            this.grpSMPUnit2.SuspendLayout();
            this.grpSMPUnit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.tbpDefect1.SuspendLayout();
            this.pnlUnitMid.SuspendLayout();
            this.grpUnit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code1)).BeginInit();
            this.grpUnit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code1)).BeginInit();
            this.pnlUnitTop.SuspendLayout();
            this.grpQty.SuspendLayout();
            this.tbpDefect2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).BeginInit();
            this.pnlWafer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSublotID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefect)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTranInfo.Controls.Add(this.grpLoss);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 271);
            this.pnlTranInfo.TabIndex = 1;
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 454);
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(722, 412);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 415);
            this.pnlComment.Size = new System.Drawing.Size(722, 39);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            this.tbpCMF.UseVisualStyleBackColor = true;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.btnFile);
            this.grpComment.Controls.Add(this.txtFile);
            this.grpComment.Controls.Add(this.lblFile);
            this.grpComment.Size = new System.Drawing.Size(722, 39);
            this.grpComment.Controls.SetChildIndex(this.lblComment, 0);
            this.grpComment.Controls.SetChildIndex(this.txtComment, 0);
            this.grpComment.Controls.SetChildIndex(this.lblFile, 0);
            this.grpComment.Controls.SetChildIndex(this.txtFile, 0);
            this.grpComment.Controls.SetChildIndex(this.btnFile, 0);
            // 
            // txtComment
            // 
            this.txtComment.Size = new System.Drawing.Size(588, 20);
            this.txtComment.TabIndex = 9;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF9.TextBoxWidth = 129;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF8.TextBoxWidth = 129;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF7.TextBoxWidth = 129;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF6.TextBoxWidth = 129;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF5.TextBoxWidth = 129;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF4.TextBoxWidth = 129;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF3.TextBoxWidth = 129;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF2.TextBoxWidth = 129;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF10.TextBoxWidth = 129;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF1.TextBoxWidth = 129;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF19.TextBoxWidth = 129;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF18.TextBoxWidth = 129;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF17.TextBoxWidth = 129;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF16.TextBoxWidth = 129;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF15.TextBoxWidth = 129;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF14.TextBoxWidth = 129;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF13.TextBoxWidth = 129;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF12.TextBoxWidth = 129;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF20.TextBoxWidth = 129;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.Size = new System.Drawing.Size(181, 20);
            this.cdvCMF11.TextBoxWidth = 129;
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.TabIndex = 5;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.MaxLength = 30;
            this.txtTranDateTime.TabStop = true;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.TabStop = false;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 1);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.TabStop = false;
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpDefect1);
            this.tabTran.Controls.Add(this.tbpDefect2);
            this.tabTran.Size = new System.Drawing.Size(736, 480);
            this.tabTran.Controls.SetChildIndex(this.tbpDefect2, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpDefect1, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpGeneral, 0);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            // 
            // txtLotID
            // 
            this.txtLotID.Size = new System.Drawing.Size(133, 20);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Size = new System.Drawing.Size(1095, 20);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 483);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(545, 9);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(639, 9);
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 545);
            this.pnlBottom.Size = new System.Drawing.Size(742, 44);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 545);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Loss Lot";
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
            this.grpLoss.Location = new System.Drawing.Point(0, 0);
            this.grpLoss.Name = "grpLoss";
            this.grpLoss.Size = new System.Drawing.Size(722, 271);
            this.grpLoss.TabIndex = 0;
            this.grpLoss.TabStop = false;
            // 
            // txtActionDesc
            // 
            this.txtActionDesc.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtActionDesc.Enabled = false;
            this.txtActionDesc.Location = new System.Drawing.Point(308, 145);
            this.txtActionDesc.MaxLength = 50;
            this.txtActionDesc.Name = "txtActionDesc";
            this.txtActionDesc.Size = new System.Drawing.Size(402, 20);
            this.txtActionDesc.TabIndex = 15;
            // 
            // txtPassFail
            // 
            this.txtPassFail.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtPassFail.Enabled = false;
            this.txtPassFail.Location = new System.Drawing.Point(118, 172);
            this.txtPassFail.MaxLength = 6;
            this.txtPassFail.Name = "txtPassFail";
            this.txtPassFail.Size = new System.Drawing.Size(183, 20);
            this.txtPassFail.TabIndex = 17;
            // 
            // lblResultType
            // 
            this.lblResultType.AutoSize = true;
            this.lblResultType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResultType.Location = new System.Drawing.Point(12, 176);
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
            this.chkSMPUnit2Flag.Location = new System.Drawing.Point(72, 112);
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
            this.chkSMPUnit1Flag.Location = new System.Drawing.Point(15, 112);
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
            this.grpSMPUnit2.Location = new System.Drawing.Point(509, 38);
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
            this.grpSMPUnit1.Location = new System.Drawing.Point(312, 38);
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
            this.txtSMPDesc.Location = new System.Drawing.Point(307, 16);
            this.txtSMPDesc.MaxLength = 50;
            this.txtSMPDesc.Name = "txtSMPDesc";
            this.txtSMPDesc.Size = new System.Drawing.Size(401, 20);
            this.txtSMPDesc.TabIndex = 2;
            // 
            // txtSMPRule
            // 
            this.txtSMPRule.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSMPRule.Enabled = false;
            this.txtSMPRule.Location = new System.Drawing.Point(118, 16);
            this.txtSMPRule.MaxLength = 20;
            this.txtSMPRule.Name = "txtSMPRule";
            this.txtSMPRule.Size = new System.Drawing.Size(182, 20);
            this.txtSMPRule.TabIndex = 1;
            // 
            // lblSMPRule
            // 
            this.lblSMPRule.AutoSize = true;
            this.lblSMPRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSMPRule.Location = new System.Drawing.Point(12, 20);
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
            this.txtQAOper.Location = new System.Drawing.Point(118, 39);
            this.txtQAOper.MaxLength = 10;
            this.txtQAOper.Name = "txtQAOper";
            this.txtQAOper.Size = new System.Drawing.Size(182, 20);
            this.txtQAOper.TabIndex = 4;
            // 
            // lblQAGateOper
            // 
            this.lblQAGateOper.AutoSize = true;
            this.lblQAGateOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQAGateOper.Location = new System.Drawing.Point(12, 43);
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
            this.txtSMPType.Location = new System.Drawing.Point(118, 62);
            this.txtSMPType.MaxLength = 10;
            this.txtSMPType.Name = "txtSMPType";
            this.txtSMPType.Size = new System.Drawing.Size(182, 20);
            this.txtSMPType.TabIndex = 6;
            // 
            // lblSMPType
            // 
            this.lblSMPType.AutoSize = true;
            this.lblSMPType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSMPType.Location = new System.Drawing.Point(12, 64);
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
            this.txtTestCount.Location = new System.Drawing.Point(120, 88);
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
            this.lblTestCount.Location = new System.Drawing.Point(12, 88);
            this.lblTestCount.Name = "lblTestCount";
            this.lblTestCount.Size = new System.Drawing.Size(59, 13);
            this.lblTestCount.TabIndex = 7;
            this.lblTestCount.Text = "Test Count";
            this.lblTestCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblTestCount.Visible = false;
            // 
            // txtIRRMRR
            // 
            this.txtIRRMRR.Location = new System.Drawing.Point(488, 241);
            this.txtIRRMRR.MaxLength = 30;
            this.txtIRRMRR.Name = "txtIRRMRR";
            this.txtIRRMRR.Size = new System.Drawing.Size(184, 20);
            this.txtIRRMRR.TabIndex = 29;
            // 
            // txtInspector
            // 
            this.txtInspector.Location = new System.Drawing.Point(488, 195);
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
            this.lblInspector.Location = new System.Drawing.Point(382, 198);
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
            this.cdvShift.Location = new System.Drawing.Point(488, 218);
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
            this.cdvAction.Location = new System.Drawing.Point(118, 149);
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
            this.lblIRRMRR.Location = new System.Drawing.Point(382, 245);
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
            this.lblShift.Location = new System.Drawing.Point(382, 221);
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
            this.lblPassFlag.Location = new System.Drawing.Point(12, 152);
            this.lblPassFlag.Name = "lblPassFlag";
            this.lblPassFlag.Size = new System.Drawing.Size(83, 13);
            this.lblPassFlag.TabIndex = 13;
            this.lblPassFlag.Text = "Result Action";
            this.lblPassFlag.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtSMPSize2
            // 
            this.txtSMPSize2.Location = new System.Drawing.Point(118, 219);
            this.txtSMPSize2.MaxLength = 11;
            this.txtSMPSize2.Name = "txtSMPSize2";
            this.txtSMPSize2.Size = new System.Drawing.Size(184, 20);
            this.txtSMPSize2.TabIndex = 21;
            // 
            // txtSMPSize1
            // 
            this.txtSMPSize1.Location = new System.Drawing.Point(118, 196);
            this.txtSMPSize1.MaxLength = 11;
            this.txtSMPSize1.Name = "txtSMPSize1";
            this.txtSMPSize1.Size = new System.Drawing.Size(184, 20);
            this.txtSMPSize1.TabIndex = 19;
            this.txtSMPSize1.TextChanged += new System.EventHandler(this.txtSMPSize1_TextChanged);
            // 
            // lblSMPSize1
            // 
            this.lblSMPSize1.AutoSize = true;
            this.lblSMPSize1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSMPSize1.Location = new System.Drawing.Point(12, 198);
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
            this.lblSMPSize2.Location = new System.Drawing.Point(12, 221);
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
            this.cdvResID.Location = new System.Drawing.Point(488, 172);
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
            this.lblResID.Location = new System.Drawing.Point(382, 175);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 22;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbpDefect1
            // 
            this.tbpDefect1.Controls.Add(this.pnlUnitMid);
            this.tbpDefect1.Controls.Add(this.pnlUnitTop);
            this.tbpDefect1.Location = new System.Drawing.Point(4, 22);
            this.tbpDefect1.Name = "tbpDefect1";
            this.tbpDefect1.Size = new System.Drawing.Size(728, 422);
            this.tbpDefect1.TabIndex = 2;
            this.tbpDefect1.Text = "Defect Information1";
            this.tbpDefect1.UseVisualStyleBackColor = true;
            // 
            // pnlUnitMid
            // 
            this.pnlUnitMid.Controls.Add(this.grpUnit2);
            this.pnlUnitMid.Controls.Add(this.pnlSeperator);
            this.pnlUnitMid.Controls.Add(this.grpUnit1);
            this.pnlUnitMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnitMid.Location = new System.Drawing.Point(0, 78);
            this.pnlUnitMid.Name = "pnlUnitMid";
            this.pnlUnitMid.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlUnitMid.Size = new System.Drawing.Size(728, 344);
            this.pnlUnitMid.TabIndex = 2;
            // 
            // grpUnit2
            // 
            this.grpUnit2.Controls.Add(this.txtUnit2Qty10);
            this.grpUnit2.Controls.Add(this.txtUnit2Qty9);
            this.grpUnit2.Controls.Add(this.txtUnit2Qty8);
            this.grpUnit2.Controls.Add(this.txtUnit2Qty7);
            this.grpUnit2.Controls.Add(this.txtUnit2Qty6);
            this.grpUnit2.Controls.Add(this.txtUnit2Qty5);
            this.grpUnit2.Controls.Add(this.txtUnit2Qty4);
            this.grpUnit2.Controls.Add(this.txtUnit2Qty3);
            this.grpUnit2.Controls.Add(this.txtUnit2Qty2);
            this.grpUnit2.Controls.Add(this.txtUnit2Qty1);
            this.grpUnit2.Controls.Add(this.lblUnit2Qty);
            this.grpUnit2.Controls.Add(this.lblUnit2Code);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code10);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code9);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code8);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code7);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code6);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code5);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code4);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code3);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code2);
            this.grpUnit2.Controls.Add(this.cdvUnit2Code1);
            this.grpUnit2.Controls.Add(this.lblB30);
            this.grpUnit2.Controls.Add(this.lblB29);
            this.grpUnit2.Controls.Add(this.lblB28);
            this.grpUnit2.Controls.Add(this.lblB27);
            this.grpUnit2.Controls.Add(this.lblB26);
            this.grpUnit2.Controls.Add(this.lblB25);
            this.grpUnit2.Controls.Add(this.lblB24);
            this.grpUnit2.Controls.Add(this.lblB23);
            this.grpUnit2.Controls.Add(this.lblB22);
            this.grpUnit2.Controls.Add(this.lblB21);
            this.grpUnit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnit2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUnit2.Location = new System.Drawing.Point(366, 5);
            this.grpUnit2.Name = "grpUnit2";
            this.grpUnit2.Size = new System.Drawing.Size(359, 336);
            this.grpUnit2.TabIndex = 3;
            this.grpUnit2.TabStop = false;
            this.grpUnit2.Text = "Unit2";
            // 
            // txtUnit2Qty10
            // 
            this.txtUnit2Qty10.Location = new System.Drawing.Point(199, 247);
            this.txtUnit2Qty10.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty10.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty10.MaskInput = "nnnnnnn";
            this.txtUnit2Qty10.Name = "txtUnit2Qty10";
            this.txtUnit2Qty10.Nullable = true;
            this.txtUnit2Qty10.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty10.PromptChar = ' ';
            this.txtUnit2Qty10.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty10.TabIndex = 31;
            this.txtUnit2Qty10.Value = null;
            this.txtUnit2Qty10.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // txtUnit2Qty9
            // 
            this.txtUnit2Qty9.Location = new System.Drawing.Point(199, 223);
            this.txtUnit2Qty9.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty9.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty9.MaskInput = "nnnnnnn";
            this.txtUnit2Qty9.Name = "txtUnit2Qty9";
            this.txtUnit2Qty9.Nullable = true;
            this.txtUnit2Qty9.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty9.PromptChar = ' ';
            this.txtUnit2Qty9.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty9.TabIndex = 28;
            this.txtUnit2Qty9.Value = null;
            this.txtUnit2Qty9.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // txtUnit2Qty8
            // 
            this.txtUnit2Qty8.Location = new System.Drawing.Point(199, 199);
            this.txtUnit2Qty8.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty8.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty8.MaskInput = "nnnnnnn";
            this.txtUnit2Qty8.Name = "txtUnit2Qty8";
            this.txtUnit2Qty8.Nullable = true;
            this.txtUnit2Qty8.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty8.PromptChar = ' ';
            this.txtUnit2Qty8.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty8.TabIndex = 25;
            this.txtUnit2Qty8.Value = null;
            this.txtUnit2Qty8.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // txtUnit2Qty7
            // 
            this.txtUnit2Qty7.Location = new System.Drawing.Point(199, 175);
            this.txtUnit2Qty7.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty7.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty7.MaskInput = "nnnnnnn";
            this.txtUnit2Qty7.Name = "txtUnit2Qty7";
            this.txtUnit2Qty7.Nullable = true;
            this.txtUnit2Qty7.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty7.PromptChar = ' ';
            this.txtUnit2Qty7.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty7.TabIndex = 22;
            this.txtUnit2Qty7.Value = null;
            this.txtUnit2Qty7.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // txtUnit2Qty6
            // 
            this.txtUnit2Qty6.Location = new System.Drawing.Point(199, 151);
            this.txtUnit2Qty6.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty6.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty6.MaskInput = "nnnnnnn";
            this.txtUnit2Qty6.Name = "txtUnit2Qty6";
            this.txtUnit2Qty6.Nullable = true;
            this.txtUnit2Qty6.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty6.PromptChar = ' ';
            this.txtUnit2Qty6.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty6.TabIndex = 19;
            this.txtUnit2Qty6.Value = null;
            this.txtUnit2Qty6.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // txtUnit2Qty5
            // 
            this.txtUnit2Qty5.Location = new System.Drawing.Point(199, 127);
            this.txtUnit2Qty5.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty5.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty5.MaskInput = "nnnnnnn";
            this.txtUnit2Qty5.Name = "txtUnit2Qty5";
            this.txtUnit2Qty5.Nullable = true;
            this.txtUnit2Qty5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty5.PromptChar = ' ';
            this.txtUnit2Qty5.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty5.TabIndex = 16;
            this.txtUnit2Qty5.Value = null;
            this.txtUnit2Qty5.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // txtUnit2Qty4
            // 
            this.txtUnit2Qty4.Location = new System.Drawing.Point(199, 103);
            this.txtUnit2Qty4.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty4.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty4.MaskInput = "nnnnnnn";
            this.txtUnit2Qty4.Name = "txtUnit2Qty4";
            this.txtUnit2Qty4.Nullable = true;
            this.txtUnit2Qty4.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty4.PromptChar = ' ';
            this.txtUnit2Qty4.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty4.TabIndex = 13;
            this.txtUnit2Qty4.Value = null;
            this.txtUnit2Qty4.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // txtUnit2Qty3
            // 
            this.txtUnit2Qty3.Location = new System.Drawing.Point(199, 79);
            this.txtUnit2Qty3.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty3.MaskInput = "nnnnnnn";
            this.txtUnit2Qty3.Name = "txtUnit2Qty3";
            this.txtUnit2Qty3.Nullable = true;
            this.txtUnit2Qty3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty3.PromptChar = ' ';
            this.txtUnit2Qty3.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty3.TabIndex = 10;
            this.txtUnit2Qty3.Value = null;
            this.txtUnit2Qty3.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // txtUnit2Qty2
            // 
            this.txtUnit2Qty2.Location = new System.Drawing.Point(199, 55);
            this.txtUnit2Qty2.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty2.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty2.MaskInput = "nnnnnnn";
            this.txtUnit2Qty2.Name = "txtUnit2Qty2";
            this.txtUnit2Qty2.Nullable = true;
            this.txtUnit2Qty2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty2.PromptChar = ' ';
            this.txtUnit2Qty2.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty2.TabIndex = 7;
            this.txtUnit2Qty2.Value = null;
            this.txtUnit2Qty2.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // txtUnit2Qty1
            // 
            this.txtUnit2Qty1.Location = new System.Drawing.Point(199, 31);
            this.txtUnit2Qty1.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty1.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty1.MaskInput = "nnnnnnn";
            this.txtUnit2Qty1.Name = "txtUnit2Qty1";
            this.txtUnit2Qty1.Nullable = true;
            this.txtUnit2Qty1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty1.PromptChar = ' ';
            this.txtUnit2Qty1.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty1.TabIndex = 4;
            this.txtUnit2Qty1.Value = null;
            this.txtUnit2Qty1.ValueChanged += new System.EventHandler(this.txtUnit2Qty_ValueChanged);
            // 
            // lblUnit2Qty
            // 
            this.lblUnit2Qty.Location = new System.Drawing.Point(201, 17);
            this.lblUnit2Qty.Name = "lblUnit2Qty";
            this.lblUnit2Qty.Size = new System.Drawing.Size(31, 13);
            this.lblUnit2Qty.TabIndex = 1;
            this.lblUnit2Qty.Text = "Qty";
            // 
            // lblUnit2Code
            // 
            this.lblUnit2Code.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit2Code.Location = new System.Drawing.Point(54, 17);
            this.lblUnit2Code.Name = "lblUnit2Code";
            this.lblUnit2Code.Size = new System.Drawing.Size(63, 14);
            this.lblUnit2Code.TabIndex = 0;
            this.lblUnit2Code.Text = "Loss Code";
            // 
            // cdvUnit2Code10
            // 
            this.cdvUnit2Code10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code10.BtnToolTipText = "";
            this.cdvUnit2Code10.DescText = "";
            this.cdvUnit2Code10.DisplaySubItemIndex = -1;
            this.cdvUnit2Code10.DisplayText = "";
            this.cdvUnit2Code10.Focusing = null;
            this.cdvUnit2Code10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code10.Index = 0;
            this.cdvUnit2Code10.IsViewBtnImage = false;
            this.cdvUnit2Code10.Location = new System.Drawing.Point(52, 247);
            this.cdvUnit2Code10.MaxLength = 10;
            this.cdvUnit2Code10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code10.Name = "cdvUnit2Code10";
            this.cdvUnit2Code10.ReadOnly = false;
            this.cdvUnit2Code10.SearchSubItemIndex = 0;
            this.cdvUnit2Code10.SelectedDescIndex = -1;
            this.cdvUnit2Code10.SelectedSubItemIndex = -1;
            this.cdvUnit2Code10.SelectionStart = 0;
            this.cdvUnit2Code10.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code10.SmallImageList = null;
            this.cdvUnit2Code10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code10.TabIndex = 30;
            this.cdvUnit2Code10.TextBoxToolTipText = "";
            this.cdvUnit2Code10.TextBoxWidth = 102;
            this.cdvUnit2Code10.VisibleButton = true;
            this.cdvUnit2Code10.VisibleColumnHeader = false;
            this.cdvUnit2Code10.VisibleDescription = false;
            this.cdvUnit2Code10.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit2Code9
            // 
            this.cdvUnit2Code9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code9.BtnToolTipText = "";
            this.cdvUnit2Code9.DescText = "";
            this.cdvUnit2Code9.DisplaySubItemIndex = -1;
            this.cdvUnit2Code9.DisplayText = "";
            this.cdvUnit2Code9.Focusing = null;
            this.cdvUnit2Code9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code9.Index = 0;
            this.cdvUnit2Code9.IsViewBtnImage = false;
            this.cdvUnit2Code9.Location = new System.Drawing.Point(52, 223);
            this.cdvUnit2Code9.MaxLength = 10;
            this.cdvUnit2Code9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code9.Name = "cdvUnit2Code9";
            this.cdvUnit2Code9.ReadOnly = false;
            this.cdvUnit2Code9.SearchSubItemIndex = 0;
            this.cdvUnit2Code9.SelectedDescIndex = -1;
            this.cdvUnit2Code9.SelectedSubItemIndex = -1;
            this.cdvUnit2Code9.SelectionStart = 0;
            this.cdvUnit2Code9.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code9.SmallImageList = null;
            this.cdvUnit2Code9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code9.TabIndex = 27;
            this.cdvUnit2Code9.TextBoxToolTipText = "";
            this.cdvUnit2Code9.TextBoxWidth = 102;
            this.cdvUnit2Code9.VisibleButton = true;
            this.cdvUnit2Code9.VisibleColumnHeader = false;
            this.cdvUnit2Code9.VisibleDescription = false;
            this.cdvUnit2Code9.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit2Code8
            // 
            this.cdvUnit2Code8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code8.BtnToolTipText = "";
            this.cdvUnit2Code8.DescText = "";
            this.cdvUnit2Code8.DisplaySubItemIndex = -1;
            this.cdvUnit2Code8.DisplayText = "";
            this.cdvUnit2Code8.Focusing = null;
            this.cdvUnit2Code8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code8.Index = 0;
            this.cdvUnit2Code8.IsViewBtnImage = false;
            this.cdvUnit2Code8.Location = new System.Drawing.Point(52, 199);
            this.cdvUnit2Code8.MaxLength = 10;
            this.cdvUnit2Code8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code8.Name = "cdvUnit2Code8";
            this.cdvUnit2Code8.ReadOnly = false;
            this.cdvUnit2Code8.SearchSubItemIndex = 0;
            this.cdvUnit2Code8.SelectedDescIndex = -1;
            this.cdvUnit2Code8.SelectedSubItemIndex = -1;
            this.cdvUnit2Code8.SelectionStart = 0;
            this.cdvUnit2Code8.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code8.SmallImageList = null;
            this.cdvUnit2Code8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code8.TabIndex = 24;
            this.cdvUnit2Code8.TextBoxToolTipText = "";
            this.cdvUnit2Code8.TextBoxWidth = 102;
            this.cdvUnit2Code8.VisibleButton = true;
            this.cdvUnit2Code8.VisibleColumnHeader = false;
            this.cdvUnit2Code8.VisibleDescription = false;
            this.cdvUnit2Code8.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit2Code7
            // 
            this.cdvUnit2Code7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code7.BtnToolTipText = "";
            this.cdvUnit2Code7.DescText = "";
            this.cdvUnit2Code7.DisplaySubItemIndex = -1;
            this.cdvUnit2Code7.DisplayText = "";
            this.cdvUnit2Code7.Focusing = null;
            this.cdvUnit2Code7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code7.Index = 0;
            this.cdvUnit2Code7.IsViewBtnImage = false;
            this.cdvUnit2Code7.Location = new System.Drawing.Point(52, 175);
            this.cdvUnit2Code7.MaxLength = 10;
            this.cdvUnit2Code7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code7.Name = "cdvUnit2Code7";
            this.cdvUnit2Code7.ReadOnly = false;
            this.cdvUnit2Code7.SearchSubItemIndex = 0;
            this.cdvUnit2Code7.SelectedDescIndex = -1;
            this.cdvUnit2Code7.SelectedSubItemIndex = -1;
            this.cdvUnit2Code7.SelectionStart = 0;
            this.cdvUnit2Code7.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code7.SmallImageList = null;
            this.cdvUnit2Code7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code7.TabIndex = 21;
            this.cdvUnit2Code7.TextBoxToolTipText = "";
            this.cdvUnit2Code7.TextBoxWidth = 102;
            this.cdvUnit2Code7.VisibleButton = true;
            this.cdvUnit2Code7.VisibleColumnHeader = false;
            this.cdvUnit2Code7.VisibleDescription = false;
            this.cdvUnit2Code7.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit2Code6
            // 
            this.cdvUnit2Code6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code6.BtnToolTipText = "";
            this.cdvUnit2Code6.DescText = "";
            this.cdvUnit2Code6.DisplaySubItemIndex = -1;
            this.cdvUnit2Code6.DisplayText = "";
            this.cdvUnit2Code6.Focusing = null;
            this.cdvUnit2Code6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code6.Index = 0;
            this.cdvUnit2Code6.IsViewBtnImage = false;
            this.cdvUnit2Code6.Location = new System.Drawing.Point(52, 151);
            this.cdvUnit2Code6.MaxLength = 10;
            this.cdvUnit2Code6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code6.Name = "cdvUnit2Code6";
            this.cdvUnit2Code6.ReadOnly = false;
            this.cdvUnit2Code6.SearchSubItemIndex = 0;
            this.cdvUnit2Code6.SelectedDescIndex = -1;
            this.cdvUnit2Code6.SelectedSubItemIndex = -1;
            this.cdvUnit2Code6.SelectionStart = 0;
            this.cdvUnit2Code6.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code6.SmallImageList = null;
            this.cdvUnit2Code6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code6.TabIndex = 18;
            this.cdvUnit2Code6.TextBoxToolTipText = "";
            this.cdvUnit2Code6.TextBoxWidth = 102;
            this.cdvUnit2Code6.VisibleButton = true;
            this.cdvUnit2Code6.VisibleColumnHeader = false;
            this.cdvUnit2Code6.VisibleDescription = false;
            this.cdvUnit2Code6.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit2Code5
            // 
            this.cdvUnit2Code5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code5.BtnToolTipText = "";
            this.cdvUnit2Code5.DescText = "";
            this.cdvUnit2Code5.DisplaySubItemIndex = -1;
            this.cdvUnit2Code5.DisplayText = "";
            this.cdvUnit2Code5.Focusing = null;
            this.cdvUnit2Code5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code5.Index = 0;
            this.cdvUnit2Code5.IsViewBtnImage = false;
            this.cdvUnit2Code5.Location = new System.Drawing.Point(52, 127);
            this.cdvUnit2Code5.MaxLength = 10;
            this.cdvUnit2Code5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code5.Name = "cdvUnit2Code5";
            this.cdvUnit2Code5.ReadOnly = false;
            this.cdvUnit2Code5.SearchSubItemIndex = 0;
            this.cdvUnit2Code5.SelectedDescIndex = -1;
            this.cdvUnit2Code5.SelectedSubItemIndex = -1;
            this.cdvUnit2Code5.SelectionStart = 0;
            this.cdvUnit2Code5.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code5.SmallImageList = null;
            this.cdvUnit2Code5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code5.TabIndex = 15;
            this.cdvUnit2Code5.TextBoxToolTipText = "";
            this.cdvUnit2Code5.TextBoxWidth = 102;
            this.cdvUnit2Code5.VisibleButton = true;
            this.cdvUnit2Code5.VisibleColumnHeader = false;
            this.cdvUnit2Code5.VisibleDescription = false;
            this.cdvUnit2Code5.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit2Code4
            // 
            this.cdvUnit2Code4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code4.BtnToolTipText = "";
            this.cdvUnit2Code4.DescText = "";
            this.cdvUnit2Code4.DisplaySubItemIndex = -1;
            this.cdvUnit2Code4.DisplayText = "";
            this.cdvUnit2Code4.Focusing = null;
            this.cdvUnit2Code4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code4.Index = 0;
            this.cdvUnit2Code4.IsViewBtnImage = false;
            this.cdvUnit2Code4.Location = new System.Drawing.Point(52, 103);
            this.cdvUnit2Code4.MaxLength = 10;
            this.cdvUnit2Code4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code4.Name = "cdvUnit2Code4";
            this.cdvUnit2Code4.ReadOnly = false;
            this.cdvUnit2Code4.SearchSubItemIndex = 0;
            this.cdvUnit2Code4.SelectedDescIndex = -1;
            this.cdvUnit2Code4.SelectedSubItemIndex = -1;
            this.cdvUnit2Code4.SelectionStart = 0;
            this.cdvUnit2Code4.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code4.SmallImageList = null;
            this.cdvUnit2Code4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code4.TabIndex = 12;
            this.cdvUnit2Code4.TextBoxToolTipText = "";
            this.cdvUnit2Code4.TextBoxWidth = 102;
            this.cdvUnit2Code4.VisibleButton = true;
            this.cdvUnit2Code4.VisibleColumnHeader = false;
            this.cdvUnit2Code4.VisibleDescription = false;
            this.cdvUnit2Code4.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit2Code3
            // 
            this.cdvUnit2Code3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code3.BtnToolTipText = "";
            this.cdvUnit2Code3.DescText = "";
            this.cdvUnit2Code3.DisplaySubItemIndex = -1;
            this.cdvUnit2Code3.DisplayText = "";
            this.cdvUnit2Code3.Focusing = null;
            this.cdvUnit2Code3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code3.Index = 0;
            this.cdvUnit2Code3.IsViewBtnImage = false;
            this.cdvUnit2Code3.Location = new System.Drawing.Point(52, 79);
            this.cdvUnit2Code3.MaxLength = 10;
            this.cdvUnit2Code3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code3.Name = "cdvUnit2Code3";
            this.cdvUnit2Code3.ReadOnly = false;
            this.cdvUnit2Code3.SearchSubItemIndex = 0;
            this.cdvUnit2Code3.SelectedDescIndex = -1;
            this.cdvUnit2Code3.SelectedSubItemIndex = -1;
            this.cdvUnit2Code3.SelectionStart = 0;
            this.cdvUnit2Code3.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code3.SmallImageList = null;
            this.cdvUnit2Code3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code3.TabIndex = 9;
            this.cdvUnit2Code3.TextBoxToolTipText = "";
            this.cdvUnit2Code3.TextBoxWidth = 102;
            this.cdvUnit2Code3.VisibleButton = true;
            this.cdvUnit2Code3.VisibleColumnHeader = false;
            this.cdvUnit2Code3.VisibleDescription = false;
            this.cdvUnit2Code3.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit2Code2
            // 
            this.cdvUnit2Code2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code2.BtnToolTipText = "";
            this.cdvUnit2Code2.DescText = "";
            this.cdvUnit2Code2.DisplaySubItemIndex = -1;
            this.cdvUnit2Code2.DisplayText = "";
            this.cdvUnit2Code2.Focusing = null;
            this.cdvUnit2Code2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code2.Index = 0;
            this.cdvUnit2Code2.IsViewBtnImage = false;
            this.cdvUnit2Code2.Location = new System.Drawing.Point(52, 55);
            this.cdvUnit2Code2.MaxLength = 10;
            this.cdvUnit2Code2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code2.Name = "cdvUnit2Code2";
            this.cdvUnit2Code2.ReadOnly = false;
            this.cdvUnit2Code2.SearchSubItemIndex = 0;
            this.cdvUnit2Code2.SelectedDescIndex = -1;
            this.cdvUnit2Code2.SelectedSubItemIndex = -1;
            this.cdvUnit2Code2.SelectionStart = 0;
            this.cdvUnit2Code2.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code2.SmallImageList = null;
            this.cdvUnit2Code2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code2.TabIndex = 6;
            this.cdvUnit2Code2.TextBoxToolTipText = "";
            this.cdvUnit2Code2.TextBoxWidth = 102;
            this.cdvUnit2Code2.VisibleButton = true;
            this.cdvUnit2Code2.VisibleColumnHeader = false;
            this.cdvUnit2Code2.VisibleDescription = false;
            this.cdvUnit2Code2.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit2Code1
            // 
            this.cdvUnit2Code1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2Code1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2Code1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2Code1.BtnToolTipText = "";
            this.cdvUnit2Code1.DescText = "";
            this.cdvUnit2Code1.DisplaySubItemIndex = -1;
            this.cdvUnit2Code1.DisplayText = "";
            this.cdvUnit2Code1.Focusing = null;
            this.cdvUnit2Code1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2Code1.Index = 0;
            this.cdvUnit2Code1.IsViewBtnImage = false;
            this.cdvUnit2Code1.Location = new System.Drawing.Point(52, 31);
            this.cdvUnit2Code1.MaxLength = 10;
            this.cdvUnit2Code1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code1.Name = "cdvUnit2Code1";
            this.cdvUnit2Code1.ReadOnly = false;
            this.cdvUnit2Code1.SearchSubItemIndex = 0;
            this.cdvUnit2Code1.SelectedDescIndex = -1;
            this.cdvUnit2Code1.SelectedSubItemIndex = -1;
            this.cdvUnit2Code1.SelectionStart = 0;
            this.cdvUnit2Code1.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit2Code1.SmallImageList = null;
            this.cdvUnit2Code1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code1.TabIndex = 3;
            this.cdvUnit2Code1.TextBoxToolTipText = "";
            this.cdvUnit2Code1.TextBoxWidth = 102;
            this.cdvUnit2Code1.VisibleButton = true;
            this.cdvUnit2Code1.VisibleColumnHeader = false;
            this.cdvUnit2Code1.VisibleDescription = false;
            this.cdvUnit2Code1.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // lblB30
            // 
            this.lblB30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB30.Location = new System.Drawing.Point(22, 250);
            this.lblB30.Name = "lblB30";
            this.lblB30.Size = new System.Drawing.Size(17, 14);
            this.lblB30.TabIndex = 29;
            this.lblB30.Text = "10";
            // 
            // lblB29
            // 
            this.lblB29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB29.Location = new System.Drawing.Point(22, 226);
            this.lblB29.Name = "lblB29";
            this.lblB29.Size = new System.Drawing.Size(17, 14);
            this.lblB29.TabIndex = 26;
            this.lblB29.Text = "9";
            // 
            // lblB28
            // 
            this.lblB28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB28.Location = new System.Drawing.Point(22, 202);
            this.lblB28.Name = "lblB28";
            this.lblB28.Size = new System.Drawing.Size(17, 14);
            this.lblB28.TabIndex = 23;
            this.lblB28.Text = "8";
            // 
            // lblB27
            // 
            this.lblB27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB27.Location = new System.Drawing.Point(22, 178);
            this.lblB27.Name = "lblB27";
            this.lblB27.Size = new System.Drawing.Size(17, 14);
            this.lblB27.TabIndex = 20;
            this.lblB27.Text = "7";
            // 
            // lblB26
            // 
            this.lblB26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB26.Location = new System.Drawing.Point(22, 154);
            this.lblB26.Name = "lblB26";
            this.lblB26.Size = new System.Drawing.Size(17, 14);
            this.lblB26.TabIndex = 17;
            this.lblB26.Text = "6";
            // 
            // lblB25
            // 
            this.lblB25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB25.Location = new System.Drawing.Point(22, 130);
            this.lblB25.Name = "lblB25";
            this.lblB25.Size = new System.Drawing.Size(17, 14);
            this.lblB25.TabIndex = 14;
            this.lblB25.Text = "5";
            // 
            // lblB24
            // 
            this.lblB24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB24.Location = new System.Drawing.Point(22, 106);
            this.lblB24.Name = "lblB24";
            this.lblB24.Size = new System.Drawing.Size(17, 14);
            this.lblB24.TabIndex = 11;
            this.lblB24.Text = "4";
            // 
            // lblB23
            // 
            this.lblB23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB23.Location = new System.Drawing.Point(22, 82);
            this.lblB23.Name = "lblB23";
            this.lblB23.Size = new System.Drawing.Size(17, 14);
            this.lblB23.TabIndex = 8;
            this.lblB23.Text = "3";
            // 
            // lblB22
            // 
            this.lblB22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB22.Location = new System.Drawing.Point(22, 58);
            this.lblB22.Name = "lblB22";
            this.lblB22.Size = new System.Drawing.Size(17, 14);
            this.lblB22.TabIndex = 5;
            this.lblB22.Text = "2";
            // 
            // lblB21
            // 
            this.lblB21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB21.Location = new System.Drawing.Point(22, 34);
            this.lblB21.Name = "lblB21";
            this.lblB21.Size = new System.Drawing.Size(17, 14);
            this.lblB21.TabIndex = 2;
            this.lblB21.Text = "1";
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSeperator.Location = new System.Drawing.Point(362, 5);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(4, 336);
            this.pnlSeperator.TabIndex = 2;
            // 
            // grpUnit1
            // 
            this.grpUnit1.Controls.Add(this.txtUnit1Qty10);
            this.grpUnit1.Controls.Add(this.txtUnit1Qty9);
            this.grpUnit1.Controls.Add(this.txtUnit1Qty8);
            this.grpUnit1.Controls.Add(this.txtUnit1Qty7);
            this.grpUnit1.Controls.Add(this.txtUnit1Qty6);
            this.grpUnit1.Controls.Add(this.txtUnit1Qty5);
            this.grpUnit1.Controls.Add(this.txtUnit1Qty4);
            this.grpUnit1.Controls.Add(this.txtUnit1Qty3);
            this.grpUnit1.Controls.Add(this.txtUnit1Qty2);
            this.grpUnit1.Controls.Add(this.txtUnit1Qty1);
            this.grpUnit1.Controls.Add(this.lblUnit1Qty);
            this.grpUnit1.Controls.Add(this.lblUnit1Code);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code10);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code9);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code8);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code7);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code6);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code5);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code4);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code3);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code2);
            this.grpUnit1.Controls.Add(this.cdvUnit1Code1);
            this.grpUnit1.Controls.Add(this.lblB20);
            this.grpUnit1.Controls.Add(this.lblB19);
            this.grpUnit1.Controls.Add(this.lblB18);
            this.grpUnit1.Controls.Add(this.lblB17);
            this.grpUnit1.Controls.Add(this.lblB16);
            this.grpUnit1.Controls.Add(this.lblB15);
            this.grpUnit1.Controls.Add(this.lblB14);
            this.grpUnit1.Controls.Add(this.lblB13);
            this.grpUnit1.Controls.Add(this.lblB12);
            this.grpUnit1.Controls.Add(this.lblB11);
            this.grpUnit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUnit1.Location = new System.Drawing.Point(3, 5);
            this.grpUnit1.Name = "grpUnit1";
            this.grpUnit1.Size = new System.Drawing.Size(359, 336);
            this.grpUnit1.TabIndex = 0;
            this.grpUnit1.TabStop = false;
            this.grpUnit1.Text = "Unit1";
            // 
            // txtUnit1Qty10
            // 
            this.txtUnit1Qty10.Location = new System.Drawing.Point(199, 247);
            this.txtUnit1Qty10.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty10.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty10.MaskInput = "nnnnnnn";
            this.txtUnit1Qty10.Name = "txtUnit1Qty10";
            this.txtUnit1Qty10.Nullable = true;
            this.txtUnit1Qty10.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty10.PromptChar = ' ';
            this.txtUnit1Qty10.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty10.TabIndex = 31;
            this.txtUnit1Qty10.Value = null;
            this.txtUnit1Qty10.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // txtUnit1Qty9
            // 
            this.txtUnit1Qty9.Location = new System.Drawing.Point(199, 223);
            this.txtUnit1Qty9.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty9.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty9.MaskInput = "nnnnnnn";
            this.txtUnit1Qty9.Name = "txtUnit1Qty9";
            this.txtUnit1Qty9.Nullable = true;
            this.txtUnit1Qty9.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty9.PromptChar = ' ';
            this.txtUnit1Qty9.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty9.TabIndex = 29;
            this.txtUnit1Qty9.Value = null;
            this.txtUnit1Qty9.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // txtUnit1Qty8
            // 
            this.txtUnit1Qty8.Location = new System.Drawing.Point(199, 199);
            this.txtUnit1Qty8.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty8.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty8.MaskInput = "nnnnnnn";
            this.txtUnit1Qty8.Name = "txtUnit1Qty8";
            this.txtUnit1Qty8.Nullable = true;
            this.txtUnit1Qty8.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty8.PromptChar = ' ';
            this.txtUnit1Qty8.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty8.TabIndex = 25;
            this.txtUnit1Qty8.Value = null;
            this.txtUnit1Qty8.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // txtUnit1Qty7
            // 
            this.txtUnit1Qty7.Location = new System.Drawing.Point(199, 175);
            this.txtUnit1Qty7.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty7.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty7.MaskInput = "nnnnnnn";
            this.txtUnit1Qty7.Name = "txtUnit1Qty7";
            this.txtUnit1Qty7.Nullable = true;
            this.txtUnit1Qty7.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty7.PromptChar = ' ';
            this.txtUnit1Qty7.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty7.TabIndex = 22;
            this.txtUnit1Qty7.Value = null;
            this.txtUnit1Qty7.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // txtUnit1Qty6
            // 
            this.txtUnit1Qty6.Location = new System.Drawing.Point(199, 151);
            this.txtUnit1Qty6.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty6.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty6.MaskInput = "nnnnnnn";
            this.txtUnit1Qty6.Name = "txtUnit1Qty6";
            this.txtUnit1Qty6.Nullable = true;
            this.txtUnit1Qty6.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty6.PromptChar = ' ';
            this.txtUnit1Qty6.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty6.TabIndex = 19;
            this.txtUnit1Qty6.Value = null;
            this.txtUnit1Qty6.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // txtUnit1Qty5
            // 
            this.txtUnit1Qty5.Location = new System.Drawing.Point(199, 127);
            this.txtUnit1Qty5.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty5.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty5.MaskInput = "nnnnnnn";
            this.txtUnit1Qty5.Name = "txtUnit1Qty5";
            this.txtUnit1Qty5.Nullable = true;
            this.txtUnit1Qty5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty5.PromptChar = ' ';
            this.txtUnit1Qty5.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty5.TabIndex = 16;
            this.txtUnit1Qty5.Value = null;
            this.txtUnit1Qty5.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // txtUnit1Qty4
            // 
            this.txtUnit1Qty4.Location = new System.Drawing.Point(199, 103);
            this.txtUnit1Qty4.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty4.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty4.MaskInput = "nnnnnnn";
            this.txtUnit1Qty4.Name = "txtUnit1Qty4";
            this.txtUnit1Qty4.Nullable = true;
            this.txtUnit1Qty4.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty4.PromptChar = ' ';
            this.txtUnit1Qty4.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty4.TabIndex = 13;
            this.txtUnit1Qty4.Value = null;
            this.txtUnit1Qty4.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // txtUnit1Qty3
            // 
            this.txtUnit1Qty3.Location = new System.Drawing.Point(199, 79);
            this.txtUnit1Qty3.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty3.MaskInput = "nnnnnnn";
            this.txtUnit1Qty3.Name = "txtUnit1Qty3";
            this.txtUnit1Qty3.Nullable = true;
            this.txtUnit1Qty3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty3.PromptChar = ' ';
            this.txtUnit1Qty3.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty3.TabIndex = 10;
            this.txtUnit1Qty3.Value = null;
            this.txtUnit1Qty3.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // txtUnit1Qty2
            // 
            this.txtUnit1Qty2.Location = new System.Drawing.Point(199, 55);
            this.txtUnit1Qty2.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty2.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty2.MaskInput = "nnnnnnn";
            this.txtUnit1Qty2.Name = "txtUnit1Qty2";
            this.txtUnit1Qty2.Nullable = true;
            this.txtUnit1Qty2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty2.PromptChar = ' ';
            this.txtUnit1Qty2.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty2.TabIndex = 7;
            this.txtUnit1Qty2.Value = null;
            this.txtUnit1Qty2.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // txtUnit1Qty1
            // 
            this.txtUnit1Qty1.Location = new System.Drawing.Point(199, 31);
            this.txtUnit1Qty1.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty1.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit1Qty1.MaskInput = "nnnnnnn";
            this.txtUnit1Qty1.Name = "txtUnit1Qty1";
            this.txtUnit1Qty1.Nullable = true;
            this.txtUnit1Qty1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit1Qty1.PromptChar = ' ';
            this.txtUnit1Qty1.Size = new System.Drawing.Size(77, 20);
            this.txtUnit1Qty1.TabIndex = 4;
            this.txtUnit1Qty1.Value = null;
            this.txtUnit1Qty1.ValueChanged += new System.EventHandler(this.txtUnit1Qty_ValueChanged);
            // 
            // lblUnit1Qty
            // 
            this.lblUnit1Qty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1Qty.Location = new System.Drawing.Point(201, 17);
            this.lblUnit1Qty.Name = "lblUnit1Qty";
            this.lblUnit1Qty.Size = new System.Drawing.Size(31, 14);
            this.lblUnit1Qty.TabIndex = 1;
            this.lblUnit1Qty.Text = "Qty";
            // 
            // lblUnit1Code
            // 
            this.lblUnit1Code.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1Code.Location = new System.Drawing.Point(54, 17);
            this.lblUnit1Code.Name = "lblUnit1Code";
            this.lblUnit1Code.Size = new System.Drawing.Size(63, 14);
            this.lblUnit1Code.TabIndex = 0;
            this.lblUnit1Code.Text = "Loss Code";
            // 
            // cdvUnit1Code10
            // 
            this.cdvUnit1Code10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code10.BtnToolTipText = "";
            this.cdvUnit1Code10.DescText = "";
            this.cdvUnit1Code10.DisplaySubItemIndex = -1;
            this.cdvUnit1Code10.DisplayText = "";
            this.cdvUnit1Code10.Focusing = null;
            this.cdvUnit1Code10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code10.Index = 0;
            this.cdvUnit1Code10.IsViewBtnImage = false;
            this.cdvUnit1Code10.Location = new System.Drawing.Point(52, 247);
            this.cdvUnit1Code10.MaxLength = 10;
            this.cdvUnit1Code10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code10.Name = "cdvUnit1Code10";
            this.cdvUnit1Code10.ReadOnly = false;
            this.cdvUnit1Code10.SearchSubItemIndex = 0;
            this.cdvUnit1Code10.SelectedDescIndex = -1;
            this.cdvUnit1Code10.SelectedSubItemIndex = -1;
            this.cdvUnit1Code10.SelectionStart = 0;
            this.cdvUnit1Code10.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code10.SmallImageList = null;
            this.cdvUnit1Code10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code10.TabIndex = 30;
            this.cdvUnit1Code10.TextBoxToolTipText = "";
            this.cdvUnit1Code10.TextBoxWidth = 102;
            this.cdvUnit1Code10.VisibleButton = true;
            this.cdvUnit1Code10.VisibleColumnHeader = false;
            this.cdvUnit1Code10.VisibleDescription = false;
            this.cdvUnit1Code10.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit1Code9
            // 
            this.cdvUnit1Code9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code9.BtnToolTipText = "";
            this.cdvUnit1Code9.DescText = "";
            this.cdvUnit1Code9.DisplaySubItemIndex = -1;
            this.cdvUnit1Code9.DisplayText = "";
            this.cdvUnit1Code9.Focusing = null;
            this.cdvUnit1Code9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code9.Index = 0;
            this.cdvUnit1Code9.IsViewBtnImage = false;
            this.cdvUnit1Code9.Location = new System.Drawing.Point(52, 223);
            this.cdvUnit1Code9.MaxLength = 10;
            this.cdvUnit1Code9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code9.Name = "cdvUnit1Code9";
            this.cdvUnit1Code9.ReadOnly = false;
            this.cdvUnit1Code9.SearchSubItemIndex = 0;
            this.cdvUnit1Code9.SelectedDescIndex = -1;
            this.cdvUnit1Code9.SelectedSubItemIndex = -1;
            this.cdvUnit1Code9.SelectionStart = 0;
            this.cdvUnit1Code9.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code9.SmallImageList = null;
            this.cdvUnit1Code9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code9.TabIndex = 27;
            this.cdvUnit1Code9.TextBoxToolTipText = "";
            this.cdvUnit1Code9.TextBoxWidth = 102;
            this.cdvUnit1Code9.VisibleButton = true;
            this.cdvUnit1Code9.VisibleColumnHeader = false;
            this.cdvUnit1Code9.VisibleDescription = false;
            this.cdvUnit1Code9.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit1Code8
            // 
            this.cdvUnit1Code8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code8.BtnToolTipText = "";
            this.cdvUnit1Code8.DescText = "";
            this.cdvUnit1Code8.DisplaySubItemIndex = -1;
            this.cdvUnit1Code8.DisplayText = "";
            this.cdvUnit1Code8.Focusing = null;
            this.cdvUnit1Code8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code8.Index = 0;
            this.cdvUnit1Code8.IsViewBtnImage = false;
            this.cdvUnit1Code8.Location = new System.Drawing.Point(52, 199);
            this.cdvUnit1Code8.MaxLength = 10;
            this.cdvUnit1Code8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code8.Name = "cdvUnit1Code8";
            this.cdvUnit1Code8.ReadOnly = false;
            this.cdvUnit1Code8.SearchSubItemIndex = 0;
            this.cdvUnit1Code8.SelectedDescIndex = -1;
            this.cdvUnit1Code8.SelectedSubItemIndex = -1;
            this.cdvUnit1Code8.SelectionStart = 0;
            this.cdvUnit1Code8.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code8.SmallImageList = null;
            this.cdvUnit1Code8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code8.TabIndex = 24;
            this.cdvUnit1Code8.TextBoxToolTipText = "";
            this.cdvUnit1Code8.TextBoxWidth = 102;
            this.cdvUnit1Code8.VisibleButton = true;
            this.cdvUnit1Code8.VisibleColumnHeader = false;
            this.cdvUnit1Code8.VisibleDescription = false;
            this.cdvUnit1Code8.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit1Code7
            // 
            this.cdvUnit1Code7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code7.BtnToolTipText = "";
            this.cdvUnit1Code7.DescText = "";
            this.cdvUnit1Code7.DisplaySubItemIndex = -1;
            this.cdvUnit1Code7.DisplayText = "";
            this.cdvUnit1Code7.Focusing = null;
            this.cdvUnit1Code7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code7.Index = 0;
            this.cdvUnit1Code7.IsViewBtnImage = false;
            this.cdvUnit1Code7.Location = new System.Drawing.Point(52, 175);
            this.cdvUnit1Code7.MaxLength = 10;
            this.cdvUnit1Code7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code7.Name = "cdvUnit1Code7";
            this.cdvUnit1Code7.ReadOnly = false;
            this.cdvUnit1Code7.SearchSubItemIndex = 0;
            this.cdvUnit1Code7.SelectedDescIndex = -1;
            this.cdvUnit1Code7.SelectedSubItemIndex = -1;
            this.cdvUnit1Code7.SelectionStart = 0;
            this.cdvUnit1Code7.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code7.SmallImageList = null;
            this.cdvUnit1Code7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code7.TabIndex = 21;
            this.cdvUnit1Code7.TextBoxToolTipText = "";
            this.cdvUnit1Code7.TextBoxWidth = 102;
            this.cdvUnit1Code7.VisibleButton = true;
            this.cdvUnit1Code7.VisibleColumnHeader = false;
            this.cdvUnit1Code7.VisibleDescription = false;
            this.cdvUnit1Code7.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit1Code6
            // 
            this.cdvUnit1Code6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code6.BtnToolTipText = "";
            this.cdvUnit1Code6.DescText = "";
            this.cdvUnit1Code6.DisplaySubItemIndex = -1;
            this.cdvUnit1Code6.DisplayText = "";
            this.cdvUnit1Code6.Focusing = null;
            this.cdvUnit1Code6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code6.Index = 0;
            this.cdvUnit1Code6.IsViewBtnImage = false;
            this.cdvUnit1Code6.Location = new System.Drawing.Point(52, 151);
            this.cdvUnit1Code6.MaxLength = 10;
            this.cdvUnit1Code6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code6.Name = "cdvUnit1Code6";
            this.cdvUnit1Code6.ReadOnly = false;
            this.cdvUnit1Code6.SearchSubItemIndex = 0;
            this.cdvUnit1Code6.SelectedDescIndex = -1;
            this.cdvUnit1Code6.SelectedSubItemIndex = -1;
            this.cdvUnit1Code6.SelectionStart = 0;
            this.cdvUnit1Code6.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code6.SmallImageList = null;
            this.cdvUnit1Code6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code6.TabIndex = 18;
            this.cdvUnit1Code6.TextBoxToolTipText = "";
            this.cdvUnit1Code6.TextBoxWidth = 102;
            this.cdvUnit1Code6.VisibleButton = true;
            this.cdvUnit1Code6.VisibleColumnHeader = false;
            this.cdvUnit1Code6.VisibleDescription = false;
            this.cdvUnit1Code6.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit1Code5
            // 
            this.cdvUnit1Code5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code5.BtnToolTipText = "";
            this.cdvUnit1Code5.DescText = "";
            this.cdvUnit1Code5.DisplaySubItemIndex = -1;
            this.cdvUnit1Code5.DisplayText = "";
            this.cdvUnit1Code5.Focusing = null;
            this.cdvUnit1Code5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code5.Index = 0;
            this.cdvUnit1Code5.IsViewBtnImage = false;
            this.cdvUnit1Code5.Location = new System.Drawing.Point(52, 127);
            this.cdvUnit1Code5.MaxLength = 10;
            this.cdvUnit1Code5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code5.Name = "cdvUnit1Code5";
            this.cdvUnit1Code5.ReadOnly = false;
            this.cdvUnit1Code5.SearchSubItemIndex = 0;
            this.cdvUnit1Code5.SelectedDescIndex = -1;
            this.cdvUnit1Code5.SelectedSubItemIndex = -1;
            this.cdvUnit1Code5.SelectionStart = 0;
            this.cdvUnit1Code5.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code5.SmallImageList = null;
            this.cdvUnit1Code5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code5.TabIndex = 15;
            this.cdvUnit1Code5.TextBoxToolTipText = "";
            this.cdvUnit1Code5.TextBoxWidth = 102;
            this.cdvUnit1Code5.VisibleButton = true;
            this.cdvUnit1Code5.VisibleColumnHeader = false;
            this.cdvUnit1Code5.VisibleDescription = false;
            this.cdvUnit1Code5.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit1Code4
            // 
            this.cdvUnit1Code4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code4.BtnToolTipText = "";
            this.cdvUnit1Code4.DescText = "";
            this.cdvUnit1Code4.DisplaySubItemIndex = -1;
            this.cdvUnit1Code4.DisplayText = "";
            this.cdvUnit1Code4.Focusing = null;
            this.cdvUnit1Code4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code4.Index = 0;
            this.cdvUnit1Code4.IsViewBtnImage = false;
            this.cdvUnit1Code4.Location = new System.Drawing.Point(52, 103);
            this.cdvUnit1Code4.MaxLength = 10;
            this.cdvUnit1Code4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code4.Name = "cdvUnit1Code4";
            this.cdvUnit1Code4.ReadOnly = false;
            this.cdvUnit1Code4.SearchSubItemIndex = 0;
            this.cdvUnit1Code4.SelectedDescIndex = -1;
            this.cdvUnit1Code4.SelectedSubItemIndex = -1;
            this.cdvUnit1Code4.SelectionStart = 0;
            this.cdvUnit1Code4.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code4.SmallImageList = null;
            this.cdvUnit1Code4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code4.TabIndex = 12;
            this.cdvUnit1Code4.TextBoxToolTipText = "";
            this.cdvUnit1Code4.TextBoxWidth = 102;
            this.cdvUnit1Code4.VisibleButton = true;
            this.cdvUnit1Code4.VisibleColumnHeader = false;
            this.cdvUnit1Code4.VisibleDescription = false;
            this.cdvUnit1Code4.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit1Code3
            // 
            this.cdvUnit1Code3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code3.BtnToolTipText = "";
            this.cdvUnit1Code3.DescText = "";
            this.cdvUnit1Code3.DisplaySubItemIndex = -1;
            this.cdvUnit1Code3.DisplayText = "";
            this.cdvUnit1Code3.Focusing = null;
            this.cdvUnit1Code3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code3.Index = 0;
            this.cdvUnit1Code3.IsViewBtnImage = false;
            this.cdvUnit1Code3.Location = new System.Drawing.Point(52, 79);
            this.cdvUnit1Code3.MaxLength = 10;
            this.cdvUnit1Code3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code3.Name = "cdvUnit1Code3";
            this.cdvUnit1Code3.ReadOnly = false;
            this.cdvUnit1Code3.SearchSubItemIndex = 0;
            this.cdvUnit1Code3.SelectedDescIndex = -1;
            this.cdvUnit1Code3.SelectedSubItemIndex = -1;
            this.cdvUnit1Code3.SelectionStart = 0;
            this.cdvUnit1Code3.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code3.SmallImageList = null;
            this.cdvUnit1Code3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code3.TabIndex = 9;
            this.cdvUnit1Code3.TextBoxToolTipText = "";
            this.cdvUnit1Code3.TextBoxWidth = 102;
            this.cdvUnit1Code3.VisibleButton = true;
            this.cdvUnit1Code3.VisibleColumnHeader = false;
            this.cdvUnit1Code3.VisibleDescription = false;
            this.cdvUnit1Code3.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit1Code2
            // 
            this.cdvUnit1Code2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code2.BtnToolTipText = "";
            this.cdvUnit1Code2.DescText = "";
            this.cdvUnit1Code2.DisplaySubItemIndex = -1;
            this.cdvUnit1Code2.DisplayText = "";
            this.cdvUnit1Code2.Focusing = null;
            this.cdvUnit1Code2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code2.Index = 0;
            this.cdvUnit1Code2.IsViewBtnImage = false;
            this.cdvUnit1Code2.Location = new System.Drawing.Point(52, 55);
            this.cdvUnit1Code2.MaxLength = 10;
            this.cdvUnit1Code2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code2.Name = "cdvUnit1Code2";
            this.cdvUnit1Code2.ReadOnly = false;
            this.cdvUnit1Code2.SearchSubItemIndex = 0;
            this.cdvUnit1Code2.SelectedDescIndex = -1;
            this.cdvUnit1Code2.SelectedSubItemIndex = -1;
            this.cdvUnit1Code2.SelectionStart = 0;
            this.cdvUnit1Code2.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code2.SmallImageList = null;
            this.cdvUnit1Code2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code2.TabIndex = 6;
            this.cdvUnit1Code2.TextBoxToolTipText = "";
            this.cdvUnit1Code2.TextBoxWidth = 102;
            this.cdvUnit1Code2.VisibleButton = true;
            this.cdvUnit1Code2.VisibleColumnHeader = false;
            this.cdvUnit1Code2.VisibleDescription = false;
            this.cdvUnit1Code2.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit1Code1
            // 
            this.cdvUnit1Code1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1Code1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1Code1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1Code1.BtnToolTipText = "";
            this.cdvUnit1Code1.DescText = "";
            this.cdvUnit1Code1.DisplaySubItemIndex = -1;
            this.cdvUnit1Code1.DisplayText = "";
            this.cdvUnit1Code1.Focusing = null;
            this.cdvUnit1Code1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1Code1.Index = 0;
            this.cdvUnit1Code1.IsViewBtnImage = false;
            this.cdvUnit1Code1.Location = new System.Drawing.Point(52, 31);
            this.cdvUnit1Code1.MaxLength = 10;
            this.cdvUnit1Code1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1Code1.Name = "cdvUnit1Code1";
            this.cdvUnit1Code1.ReadOnly = false;
            this.cdvUnit1Code1.SearchSubItemIndex = 0;
            this.cdvUnit1Code1.SelectedDescIndex = -1;
            this.cdvUnit1Code1.SelectedSubItemIndex = -1;
            this.cdvUnit1Code1.SelectionStart = 0;
            this.cdvUnit1Code1.Size = new System.Drawing.Size(143, 20);
            this.cdvUnit1Code1.SmallImageList = null;
            this.cdvUnit1Code1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1Code1.TabIndex = 3;
            this.cdvUnit1Code1.TextBoxToolTipText = "";
            this.cdvUnit1Code1.TextBoxWidth = 102;
            this.cdvUnit1Code1.VisibleButton = true;
            this.cdvUnit1Code1.VisibleColumnHeader = false;
            this.cdvUnit1Code1.VisibleDescription = false;
            this.cdvUnit1Code1.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // lblB20
            // 
            this.lblB20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB20.Location = new System.Drawing.Point(22, 250);
            this.lblB20.Name = "lblB20";
            this.lblB20.Size = new System.Drawing.Size(17, 14);
            this.lblB20.TabIndex = 29;
            this.lblB20.Text = "10";
            // 
            // lblB19
            // 
            this.lblB19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB19.Location = new System.Drawing.Point(22, 226);
            this.lblB19.Name = "lblB19";
            this.lblB19.Size = new System.Drawing.Size(17, 14);
            this.lblB19.TabIndex = 26;
            this.lblB19.Text = "9";
            // 
            // lblB18
            // 
            this.lblB18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB18.Location = new System.Drawing.Point(22, 202);
            this.lblB18.Name = "lblB18";
            this.lblB18.Size = new System.Drawing.Size(17, 14);
            this.lblB18.TabIndex = 23;
            this.lblB18.Text = "8";
            // 
            // lblB17
            // 
            this.lblB17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB17.Location = new System.Drawing.Point(22, 178);
            this.lblB17.Name = "lblB17";
            this.lblB17.Size = new System.Drawing.Size(17, 14);
            this.lblB17.TabIndex = 20;
            this.lblB17.Text = "7";
            // 
            // lblB16
            // 
            this.lblB16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB16.Location = new System.Drawing.Point(22, 154);
            this.lblB16.Name = "lblB16";
            this.lblB16.Size = new System.Drawing.Size(17, 14);
            this.lblB16.TabIndex = 17;
            this.lblB16.Text = "6";
            // 
            // lblB15
            // 
            this.lblB15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB15.Location = new System.Drawing.Point(22, 130);
            this.lblB15.Name = "lblB15";
            this.lblB15.Size = new System.Drawing.Size(17, 14);
            this.lblB15.TabIndex = 14;
            this.lblB15.Text = "5";
            // 
            // lblB14
            // 
            this.lblB14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB14.Location = new System.Drawing.Point(22, 106);
            this.lblB14.Name = "lblB14";
            this.lblB14.Size = new System.Drawing.Size(17, 14);
            this.lblB14.TabIndex = 11;
            this.lblB14.Text = "4";
            // 
            // lblB13
            // 
            this.lblB13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB13.Location = new System.Drawing.Point(22, 82);
            this.lblB13.Name = "lblB13";
            this.lblB13.Size = new System.Drawing.Size(17, 14);
            this.lblB13.TabIndex = 8;
            this.lblB13.Text = "3";
            // 
            // lblB12
            // 
            this.lblB12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB12.Location = new System.Drawing.Point(22, 58);
            this.lblB12.Name = "lblB12";
            this.lblB12.Size = new System.Drawing.Size(17, 14);
            this.lblB12.TabIndex = 5;
            this.lblB12.Text = "2";
            // 
            // lblB11
            // 
            this.lblB11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB11.Location = new System.Drawing.Point(22, 34);
            this.lblB11.Name = "lblB11";
            this.lblB11.Size = new System.Drawing.Size(17, 14);
            this.lblB11.TabIndex = 2;
            this.lblB11.Text = "1";
            // 
            // pnlUnitTop
            // 
            this.pnlUnitTop.Controls.Add(this.grpQty);
            this.pnlUnitTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUnitTop.Location = new System.Drawing.Point(0, 0);
            this.pnlUnitTop.Name = "pnlUnitTop";
            this.pnlUnitTop.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlUnitTop.Size = new System.Drawing.Size(728, 78);
            this.pnlUnitTop.TabIndex = 1;
            // 
            // grpQty
            // 
            this.grpQty.Controls.Add(this.txtDefQty2);
            this.grpQty.Controls.Add(this.txtDefQty1);
            this.grpQty.Controls.Add(this.lblDefQty2);
            this.grpQty.Controls.Add(this.lblDefQty1);
            this.grpQty.Controls.Add(this.txtLotQty2);
            this.grpQty.Controls.Add(this.txtLotQty1);
            this.grpQty.Controls.Add(this.lblLotQyt2);
            this.grpQty.Controls.Add(this.lblLotQty1);
            this.grpQty.Controls.Add(this.txtOutQty2);
            this.grpQty.Controls.Add(this.txtOutQty1);
            this.grpQty.Controls.Add(this.txtLotSMPQty2);
            this.grpQty.Controls.Add(this.txtLotSMPQty1);
            this.grpQty.Controls.Add(this.lblOutQty2);
            this.grpQty.Controls.Add(this.lblOutQty1);
            this.grpQty.Controls.Add(this.lblQty2);
            this.grpQty.Controls.Add(this.lblQty1);
            this.grpQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpQty.Location = new System.Drawing.Point(3, 3);
            this.grpQty.Name = "grpQty";
            this.grpQty.Size = new System.Drawing.Size(722, 75);
            this.grpQty.TabIndex = 0;
            this.grpQty.TabStop = false;
            // 
            // txtDefQty2
            // 
            this.txtDefQty2.Location = new System.Drawing.Point(450, 43);
            this.txtDefQty2.MaxLength = 11;
            this.txtDefQty2.Name = "txtDefQty2";
            this.txtDefQty2.ReadOnly = true;
            this.txtDefQty2.Size = new System.Drawing.Size(83, 20);
            this.txtDefQty2.TabIndex = 11;
            this.txtDefQty2.TabStop = false;
            // 
            // txtDefQty1
            // 
            this.txtDefQty1.Location = new System.Drawing.Point(450, 19);
            this.txtDefQty1.MaxLength = 11;
            this.txtDefQty1.Name = "txtDefQty1";
            this.txtDefQty1.ReadOnly = true;
            this.txtDefQty1.Size = new System.Drawing.Size(83, 20);
            this.txtDefQty1.TabIndex = 9;
            this.txtDefQty1.TabStop = false;
            // 
            // lblDefQty2
            // 
            this.lblDefQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefQty2.Location = new System.Drawing.Point(370, 46);
            this.lblDefQty2.Name = "lblDefQty2";
            this.lblDefQty2.Size = new System.Drawing.Size(67, 14);
            this.lblDefQty2.TabIndex = 10;
            this.lblDefQty2.Text = "Defect Qty 2";
            // 
            // lblDefQty1
            // 
            this.lblDefQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefQty1.Location = new System.Drawing.Point(370, 22);
            this.lblDefQty1.Name = "lblDefQty1";
            this.lblDefQty1.Size = new System.Drawing.Size(68, 14);
            this.lblDefQty1.TabIndex = 8;
            this.lblDefQty1.Text = "Defect Qty 1";
            // 
            // txtLotQty2
            // 
            this.txtLotQty2.Location = new System.Drawing.Point(82, 43);
            this.txtLotQty2.MaxLength = 11;
            this.txtLotQty2.Name = "txtLotQty2";
            this.txtLotQty2.ReadOnly = true;
            this.txtLotQty2.Size = new System.Drawing.Size(83, 20);
            this.txtLotQty2.TabIndex = 3;
            this.txtLotQty2.TabStop = false;
            // 
            // txtLotQty1
            // 
            this.txtLotQty1.Location = new System.Drawing.Point(82, 19);
            this.txtLotQty1.MaxLength = 11;
            this.txtLotQty1.Name = "txtLotQty1";
            this.txtLotQty1.ReadOnly = true;
            this.txtLotQty1.Size = new System.Drawing.Size(83, 20);
            this.txtLotQty1.TabIndex = 1;
            this.txtLotQty1.TabStop = false;
            // 
            // lblLotQyt2
            // 
            this.lblLotQyt2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotQyt2.Location = new System.Drawing.Point(21, 46);
            this.lblLotQyt2.Name = "lblLotQyt2";
            this.lblLotQyt2.Size = new System.Drawing.Size(79, 14);
            this.lblLotQyt2.TabIndex = 2;
            this.lblLotQyt2.Text = "Lot Qty 2";
            // 
            // lblLotQty1
            // 
            this.lblLotQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotQty1.Location = new System.Drawing.Point(21, 22);
            this.lblLotQty1.Name = "lblLotQty1";
            this.lblLotQty1.Size = new System.Drawing.Size(79, 14);
            this.lblLotQty1.TabIndex = 0;
            this.lblLotQty1.Text = "Lot Qty 1";
            // 
            // txtOutQty2
            // 
            this.txtOutQty2.Location = new System.Drawing.Point(615, 43);
            this.txtOutQty2.MaxLength = 11;
            this.txtOutQty2.Name = "txtOutQty2";
            this.txtOutQty2.ReadOnly = true;
            this.txtOutQty2.Size = new System.Drawing.Size(83, 20);
            this.txtOutQty2.TabIndex = 15;
            this.txtOutQty2.TabStop = false;
            // 
            // txtOutQty1
            // 
            this.txtOutQty1.Location = new System.Drawing.Point(615, 19);
            this.txtOutQty1.MaxLength = 11;
            this.txtOutQty1.Name = "txtOutQty1";
            this.txtOutQty1.ReadOnly = true;
            this.txtOutQty1.Size = new System.Drawing.Size(83, 20);
            this.txtOutQty1.TabIndex = 13;
            this.txtOutQty1.TabStop = false;
            // 
            // txtLotSMPQty2
            // 
            this.txtLotSMPQty2.Location = new System.Drawing.Point(263, 43);
            this.txtLotSMPQty2.MaxLength = 11;
            this.txtLotSMPQty2.Name = "txtLotSMPQty2";
            this.txtLotSMPQty2.ReadOnly = true;
            this.txtLotSMPQty2.Size = new System.Drawing.Size(83, 20);
            this.txtLotSMPQty2.TabIndex = 7;
            this.txtLotSMPQty2.TabStop = false;
            // 
            // txtLotSMPQty1
            // 
            this.txtLotSMPQty1.Location = new System.Drawing.Point(263, 19);
            this.txtLotSMPQty1.MaxLength = 11;
            this.txtLotSMPQty1.Name = "txtLotSMPQty1";
            this.txtLotSMPQty1.ReadOnly = true;
            this.txtLotSMPQty1.Size = new System.Drawing.Size(83, 20);
            this.txtLotSMPQty1.TabIndex = 5;
            this.txtLotSMPQty1.TabStop = false;
            // 
            // lblOutQty2
            // 
            this.lblOutQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty2.Location = new System.Drawing.Point(559, 46);
            this.lblOutQty2.Name = "lblOutQty2";
            this.lblOutQty2.Size = new System.Drawing.Size(57, 14);
            this.lblOutQty2.TabIndex = 14;
            this.lblOutQty2.Text = "Out Qty 2";
            // 
            // lblOutQty1
            // 
            this.lblOutQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty1.Location = new System.Drawing.Point(559, 22);
            this.lblOutQty1.Name = "lblOutQty1";
            this.lblOutQty1.Size = new System.Drawing.Size(57, 14);
            this.lblOutQty1.TabIndex = 12;
            this.lblOutQty1.Text = "Out Qty 1";
            // 
            // lblQty2
            // 
            this.lblQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty2.Location = new System.Drawing.Point(191, 46);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(79, 14);
            this.lblQty2.TabIndex = 6;
            this.lblQty2.Text = "Sample Qty 2";
            // 
            // lblQty1
            // 
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Location = new System.Drawing.Point(191, 22);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(79, 14);
            this.lblQty1.TabIndex = 4;
            this.lblQty1.Text = "Sample Qty 1";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFile.Location = new System.Drawing.Point(15, 41);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(51, 13);
            this.lblFile.TabIndex = 18;
            this.lblFile.Text = "Save File";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblFile.Visible = false;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(121, 38);
            this.txtFile.MaxLength = 100;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(562, 20);
            this.txtFile.TabIndex = 19;
            this.txtFile.Visible = false;
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(685, 37);
            this.btnFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(24, 21);
            this.btnFile.TabIndex = 20;
            this.btnFile.Text = "...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // tbpDefect2
            // 
            this.tbpDefect2.Controls.Add(this.splitContainer1);
            this.tbpDefect2.Controls.Add(this.panel1);
            this.tbpDefect2.Location = new System.Drawing.Point(4, 22);
            this.tbpDefect2.Name = "tbpDefect2";
            this.tbpDefect2.Size = new System.Drawing.Size(728, 422);
            this.tbpDefect2.TabIndex = 3;
            this.tbpDefect2.Text = "Defect Information2";
            this.tbpDefect2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 57);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.spdDefectData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlWafer);
            this.splitContainer1.Panel2.Controls.Add(this.lisSubLot);
            this.splitContainer1.Size = new System.Drawing.Size(728, 365);
            this.splitContainer1.SplitterDistance = 502;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 4;
            // 
            // spdDefectData
            // 
            this.spdDefectData.AccessibleDescription = "spdDefectData, LotInfo, Row 0, Column 0, ";
            this.spdDefectData.BackColor = System.Drawing.Color.Transparent;
            this.spdDefectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDefectData.Location = new System.Drawing.Point(0, 0);
            this.spdDefectData.MoveActiveOnFocus = false;
            this.spdDefectData.Name = "spdDefectData";
            this.spdDefectData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdDefectData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdDefectData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDefectData_LotInfo});
            this.spdDefectData.Size = new System.Drawing.Size(502, 365);
            this.spdDefectData.TabIndex = 4;
            this.spdDefectData.TabStop = false;
            this.spdDefectData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdDefectData.TextTipAppearance = tipAppearance1;
            this.spdDefectData.TextTipDelay = 200;
            this.spdDefectData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDefectData.EditModeOff += new System.EventHandler(this.spdDefectData_EditModeOff);
            this.spdDefectData.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdDefectData_SelectionChanged);
            this.spdDefectData.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdDefectData_ButtonClicked);
            this.spdDefectData.TextChanged += new System.EventHandler(this.spdDefectData_TextChanged);
            this.spdDefectData.Leave += new System.EventHandler(this.spdDefectData_Leave);
            // 
            // spdDefectData_LotInfo
            // 
            this.spdDefectData_LotInfo.Reset();
            spdDefectData_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDefectData_LotInfo.ColumnCount = 14;
            spdDefectData_LotInfo.RowCount = 1000;
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 0).Value = "Defect Code";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 1).Value = "...";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 2).Value = "Sub Lot ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 4).Value = "In Qty";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 5).Value = "Defect";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 6).Value = "Good Qty";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 7).Value = "Yield";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 8).Value = "Loc X";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 9).Value = "Loc Y";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 10).Value = "Loc Z";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 11).Value = "Cell X";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 12).Value = "Cell Y";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 13).Value = "Cell Z";
            this.spdDefectData_LotInfo.Columns.Get(0).BackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.Columns.Get(0).CellType = textCellType1;
            this.spdDefectData_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefectData_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDefectData_LotInfo.Columns.Get(0).Label = "Defect Code";
            this.spdDefectData_LotInfo.Columns.Get(0).Locked = false;
            this.spdDefectData_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefectData_LotInfo.Columns.Get(0).Width = 82F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdDefectData_LotInfo.Columns.Get(1).CellType = buttonCellType1;
            this.spdDefectData_LotInfo.Columns.Get(1).Label = "...";
            this.spdDefectData_LotInfo.Columns.Get(1).Locked = false;
            this.spdDefectData_LotInfo.Columns.Get(1).Resizable = false;
            this.spdDefectData_LotInfo.Columns.Get(1).Width = 25F;
            this.spdDefectData_LotInfo.Columns.Get(2).CellType = textCellType2;
            this.spdDefectData_LotInfo.Columns.Get(2).Label = "Sub Lot ID";
            this.spdDefectData_LotInfo.Columns.Get(2).Width = 108F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdDefectData_LotInfo.Columns.Get(3).CellType = buttonCellType2;
            this.spdDefectData_LotInfo.Columns.Get(3).Width = 22F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999D;
            numberCellType1.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(4).CellType = numberCellType1;
            this.spdDefectData_LotInfo.Columns.Get(4).Label = "In Qty";
            this.spdDefectData_LotInfo.Columns.Get(4).Width = 52F;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.MaximumValue = 9999999D;
            numberCellType2.MinimumValue = -9999999D;
            this.spdDefectData_LotInfo.Columns.Get(5).CellType = numberCellType2;
            this.spdDefectData_LotInfo.Columns.Get(5).Label = "Defect";
            this.spdDefectData_LotInfo.Columns.Get(5).Width = 54F;
            this.spdDefectData_LotInfo.Columns.Get(6).CellType = numberCellType3;
            this.spdDefectData_LotInfo.Columns.Get(6).Label = "Good Qty";
            this.spdDefectData_LotInfo.Columns.Get(6).Width = 66F;
            this.spdDefectData_LotInfo.Columns.Get(7).CellType = numberCellType4;
            this.spdDefectData_LotInfo.Columns.Get(7).Label = "Yield";
            this.spdDefectData_LotInfo.Columns.Get(7).Width = 52F;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.MaximumValue = 9999999D;
            numberCellType5.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(11).CellType = numberCellType5;
            this.spdDefectData_LotInfo.Columns.Get(11).Label = "Cell X";
            this.spdDefectData_LotInfo.Columns.Get(11).Width = 56F;
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.MaximumValue = 9999999D;
            numberCellType6.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(12).CellType = numberCellType6;
            this.spdDefectData_LotInfo.Columns.Get(12).Label = "Cell Y";
            this.spdDefectData_LotInfo.Columns.Get(12).Width = 55F;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.MaximumValue = 9999999D;
            numberCellType7.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(13).CellType = numberCellType7;
            this.spdDefectData_LotInfo.Columns.Get(13).Label = "Cell Z";
            this.spdDefectData_LotInfo.Columns.Get(13).Width = 52F;
            this.spdDefectData_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdDefectData_LotInfo.RowHeader.Columns.Get(0).Width = 26F;
            this.spdDefectData_LotInfo.RowHeader.Visible = false;
            this.spdDefectData_LotInfo.Rows.Default.Height = 17F;
            this.spdDefectData_LotInfo.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlWafer
            // 
            this.pnlWafer.Controls.Add(this.chkWaferSelect);
            this.pnlWafer.Controls.Add(this.btnClear);
            this.pnlWafer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlWafer.Location = new System.Drawing.Point(0, 333);
            this.pnlWafer.Name = "pnlWafer";
            this.pnlWafer.Size = new System.Drawing.Size(218, 32);
            this.pnlWafer.TabIndex = 1;
            // 
            // chkWaferSelect
            // 
            this.chkWaferSelect.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkWaferSelect.AutoSize = true;
            this.chkWaferSelect.Location = new System.Drawing.Point(6, 5);
            this.chkWaferSelect.Name = "chkWaferSelect";
            this.chkWaferSelect.Size = new System.Drawing.Size(65, 23);
            this.chkWaferSelect.TabIndex = 0;
            this.chkWaferSelect.Text = "  Seleted  ";
            this.chkWaferSelect.UseVisualStyleBackColor = true;
            this.chkWaferSelect.CheckedChanged += new System.EventHandler(this.chkWaferSelect_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(146, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lisSubLot
            // 
            this.lisSubLot.CheckBoxes = true;
            this.lisSubLot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlotNo,
            this.colSubLot,
            this.colInQty,
            this.colDefectQty,
            this.colOutQty,
            this.colYield});
            this.lisSubLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSubLot.Location = new System.Drawing.Point(0, 0);
            this.lisSubLot.Name = "lisSubLot";
            this.lisSubLot.Size = new System.Drawing.Size(218, 365);
            this.lisSubLot.TabIndex = 0;
            this.lisSubLot.UseCompatibleStateImageBehavior = false;
            this.lisSubLot.View = System.Windows.Forms.View.Details;
            // 
            // colSlotNo
            // 
            this.colSlotNo.DisplayIndex = 1;
            this.colSlotNo.Text = "Sub Lot";
            this.colSlotNo.Width = 120;
            // 
            // colSubLot
            // 
            this.colSubLot.DisplayIndex = 0;
            this.colSubLot.Text = "No";
            this.colSubLot.Width = 30;
            // 
            // colInQty
            // 
            this.colInQty.Text = "In Qty";
            // 
            // colDefectQty
            // 
            this.colDefectQty.Text = "Defect Qty";
            // 
            // colOutQty
            // 
            this.colOutQty.Text = "Out Qty";
            // 
            // colYield
            // 
            this.colYield.Text = "Yield";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Controls.Add(this.txtSMPQty_2);
            this.panel1.Controls.Add(this.txtSMPQty_1);
            this.panel1.Controls.Add(this.lblSMPQty_2);
            this.panel1.Controls.Add(this.lblSMPQty_1);
            this.panel1.Controls.Add(this.txtLotQty_2);
            this.panel1.Controls.Add(this.txtLotQty_1);
            this.panel1.Controls.Add(this.lblLotQty_2);
            this.panel1.Controls.Add(this.lblLotQty_1);
            this.panel1.Controls.Add(this.txtTotlYield);
            this.panel1.Controls.Add(this.txtDefectCount);
            this.panel1.Controls.Add(this.txtTotDefQty);
            this.panel1.Controls.Add(this.txtDefSubLotCnt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTotalDefectCount);
            this.panel1.Controls.Add(this.lblTotalDefectQty);
            this.panel1.Controls.Add(this.lblDefectSubLotCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 57);
            this.panel1.TabIndex = 3;
            // 
            // txtSMPQty_2
            // 
            this.txtSMPQty_2.Enabled = false;
            this.txtSMPQty_2.Location = new System.Drawing.Point(248, 30);
            this.txtSMPQty_2.MaxLength = 11;
            this.txtSMPQty_2.Name = "txtSMPQty_2";
            this.txtSMPQty_2.ReadOnly = true;
            this.txtSMPQty_2.Size = new System.Drawing.Size(73, 20);
            this.txtSMPQty_2.TabIndex = 7;
            this.txtSMPQty_2.TabStop = false;
            // 
            // txtSMPQty_1
            // 
            this.txtSMPQty_1.Enabled = false;
            this.txtSMPQty_1.Location = new System.Drawing.Point(248, 6);
            this.txtSMPQty_1.MaxLength = 11;
            this.txtSMPQty_1.Name = "txtSMPQty_1";
            this.txtSMPQty_1.ReadOnly = true;
            this.txtSMPQty_1.Size = new System.Drawing.Size(73, 20);
            this.txtSMPQty_1.TabIndex = 5;
            this.txtSMPQty_1.TabStop = false;
            // 
            // lblSMPQty_2
            // 
            this.lblSMPQty_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSMPQty_2.Location = new System.Drawing.Point(179, 33);
            this.lblSMPQty_2.Name = "lblSMPQty_2";
            this.lblSMPQty_2.Size = new System.Drawing.Size(79, 14);
            this.lblSMPQty_2.TabIndex = 6;
            this.lblSMPQty_2.Text = "Sample Qty 2";
            // 
            // lblSMPQty_1
            // 
            this.lblSMPQty_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSMPQty_1.Location = new System.Drawing.Point(179, 9);
            this.lblSMPQty_1.Name = "lblSMPQty_1";
            this.lblSMPQty_1.Size = new System.Drawing.Size(79, 14);
            this.lblSMPQty_1.TabIndex = 4;
            this.lblSMPQty_1.Text = "Sample Qty 1";
            // 
            // txtLotQty_2
            // 
            this.txtLotQty_2.Enabled = false;
            this.txtLotQty_2.Location = new System.Drawing.Point(76, 29);
            this.txtLotQty_2.MaxLength = 11;
            this.txtLotQty_2.Name = "txtLotQty_2";
            this.txtLotQty_2.ReadOnly = true;
            this.txtLotQty_2.Size = new System.Drawing.Size(73, 20);
            this.txtLotQty_2.TabIndex = 3;
            this.txtLotQty_2.TabStop = false;
            // 
            // txtLotQty_1
            // 
            this.txtLotQty_1.Enabled = false;
            this.txtLotQty_1.Location = new System.Drawing.Point(76, 5);
            this.txtLotQty_1.MaxLength = 11;
            this.txtLotQty_1.Name = "txtLotQty_1";
            this.txtLotQty_1.ReadOnly = true;
            this.txtLotQty_1.Size = new System.Drawing.Size(73, 20);
            this.txtLotQty_1.TabIndex = 1;
            this.txtLotQty_1.TabStop = false;
            // 
            // lblLotQty_2
            // 
            this.lblLotQty_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotQty_2.Location = new System.Drawing.Point(22, 32);
            this.lblLotQty_2.Name = "lblLotQty_2";
            this.lblLotQty_2.Size = new System.Drawing.Size(79, 14);
            this.lblLotQty_2.TabIndex = 2;
            this.lblLotQty_2.Text = "Lot Qty 2";
            // 
            // lblLotQty_1
            // 
            this.lblLotQty_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotQty_1.Location = new System.Drawing.Point(22, 8);
            this.lblLotQty_1.Name = "lblLotQty_1";
            this.lblLotQty_1.Size = new System.Drawing.Size(79, 14);
            this.lblLotQty_1.TabIndex = 0;
            this.lblLotQty_1.Text = "Lot Qty 1";
            // 
            // txtTotlYield
            // 
            this.txtTotlYield.Enabled = false;
            this.txtTotlYield.Location = new System.Drawing.Point(638, 29);
            this.txtTotlYield.MaxLength = 21;
            this.txtTotlYield.Name = "txtTotlYield";
            this.txtTotlYield.ReadOnly = true;
            this.txtTotlYield.Size = new System.Drawing.Size(73, 20);
            this.txtTotlYield.TabIndex = 15;
            this.txtTotlYield.TabStop = false;
            // 
            // txtDefectCount
            // 
            this.txtDefectCount.Enabled = false;
            this.txtDefectCount.Location = new System.Drawing.Point(461, 29);
            this.txtDefectCount.MaxLength = 10;
            this.txtDefectCount.Name = "txtDefectCount";
            this.txtDefectCount.ReadOnly = true;
            this.txtDefectCount.Size = new System.Drawing.Size(73, 20);
            this.txtDefectCount.TabIndex = 11;
            this.txtDefectCount.TabStop = false;
            // 
            // txtTotDefQty
            // 
            this.txtTotDefQty.Enabled = false;
            this.txtTotDefQty.Location = new System.Drawing.Point(638, 5);
            this.txtTotDefQty.MaxLength = 11;
            this.txtTotDefQty.Name = "txtTotDefQty";
            this.txtTotDefQty.ReadOnly = true;
            this.txtTotDefQty.Size = new System.Drawing.Size(73, 20);
            this.txtTotDefQty.TabIndex = 13;
            this.txtTotDefQty.TabStop = false;
            // 
            // txtDefSubLotCnt
            // 
            this.txtDefSubLotCnt.Enabled = false;
            this.txtDefSubLotCnt.Location = new System.Drawing.Point(461, 5);
            this.txtDefSubLotCnt.MaxLength = 10;
            this.txtDefSubLotCnt.Name = "txtDefSubLotCnt";
            this.txtDefSubLotCnt.ReadOnly = true;
            this.txtDefSubLotCnt.Size = new System.Drawing.Size(73, 20);
            this.txtDefSubLotCnt.TabIndex = 9;
            this.txtDefSubLotCnt.TabStop = false;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(551, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Total Yield";
            // 
            // lblTotalDefectCount
            // 
            this.lblTotalDefectCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTotalDefectCount.Location = new System.Drawing.Point(350, 32);
            this.lblTotalDefectCount.Name = "lblTotalDefectCount";
            this.lblTotalDefectCount.Size = new System.Drawing.Size(100, 14);
            this.lblTotalDefectCount.TabIndex = 10;
            this.lblTotalDefectCount.Text = "Total Defect Count";
            // 
            // lblTotalDefectQty
            // 
            this.lblTotalDefectQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTotalDefectQty.Location = new System.Drawing.Point(551, 8);
            this.lblTotalDefectQty.Name = "lblTotalDefectQty";
            this.lblTotalDefectQty.Size = new System.Drawing.Size(80, 14);
            this.lblTotalDefectQty.TabIndex = 12;
            this.lblTotalDefectQty.Text = "Total Defect Qty";
            // 
            // lblDefectSubLotCount
            // 
            this.lblDefectSubLotCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefectSubLotCount.Location = new System.Drawing.Point(350, 8);
            this.lblDefectSubLotCount.Name = "lblDefectSubLotCount";
            this.lblDefectSubLotCount.Size = new System.Drawing.Size(109, 14);
            this.lblDefectSubLotCount.TabIndex = 8;
            this.lblDefectSubLotCount.Text = "Defect Sub Lot Count";
            // 
            // cdvSublotID
            // 
            this.cdvSublotID.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvSublotID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSublotID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSublotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvSublotID.Location = new System.Drawing.Point(299, 17);
            this.cdvSublotID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSublotID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSublotID.Name = "cdvSublotID";
            this.cdvSublotID.Size = new System.Drawing.Size(20, 20);
            this.cdvSublotID.SmallImageList = null;
            this.cdvSublotID.TabIndex = 0;
            this.cdvSublotID.TabStop = false;
            this.cdvSublotID.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvSublotID.Visible = false;
            this.cdvSublotID.VisibleColumnHeader = false;
            this.cdvSublotID.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvSublotID_SelectedItemChanged);
            // 
            // cdvDefect
            // 
            this.cdvDefect.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvDefect.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefect.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvDefect.Location = new System.Drawing.Point(194, 17);
            this.cdvDefect.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefect.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefect.Name = "cdvDefect";
            this.cdvDefect.Size = new System.Drawing.Size(20, 20);
            this.cdvDefect.SmallImageList = null;
            this.cdvDefect.TabIndex = 0;
            this.cdvDefect.TabStop = false;
            this.cdvDefect.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDefect.Visible = false;
            this.cdvDefect.VisibleColumnHeader = false;
            this.cdvDefect.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvDefect_SelectedItemChanged);
            // 
            // ofdFile
            // 
            this.ofdFile.DefaultExt = "xls,xlsx";
            this.ofdFile.FileName = "*";
            this.ofdFile.Filter = "*.xls|*.xlsx";
            this.ofdFile.Title = "Select File";
            // 
            // frmWIPTranQAGate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 589);
            this.Name = "frmWIPTranQAGate";
            this.Text = "QA Gate";
            this.Activated += new System.EventHandler(this.frmWIPTranQAGate_Activated);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlGeneralTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            this.grpLotInfo.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTran.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.grpCMF.ResumeLayout(false);
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
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpLoss.ResumeLayout(false);
            this.grpLoss.PerformLayout();
            this.grpSMPUnit2.ResumeLayout(false);
            this.grpSMPUnit2.PerformLayout();
            this.grpSMPUnit1.ResumeLayout(false);
            this.grpSMPUnit1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.tbpDefect1.ResumeLayout(false);
            this.pnlUnitMid.ResumeLayout(false);
            this.grpUnit2.ResumeLayout(false);
            this.grpUnit2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit2Qty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2Code1)).EndInit();
            this.grpUnit1.ResumeLayout(false);
            this.grpUnit1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit1Qty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1Code1)).EndInit();
            this.pnlUnitTop.ResumeLayout(false);
            this.grpQty.ResumeLayout(false);
            this.grpQty.PerformLayout();
            this.tbpDefect2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).EndInit();
            this.pnlWafer.ResumeLayout(false);
            this.pnlWafer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSublotID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefect)).EndInit();
            this.ResumeLayout(false);

		}
		
		#endregion

		private System.Windows.Forms.TextBox txtSMPSize2;
        private System.Windows.Forms.TextBox txtSMPSize1;
		private System.Windows.Forms.Label lblSMPSize1;
		private System.Windows.Forms.Label lblSMPSize2;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvShift;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAction;
		private System.Windows.Forms.Label lblIRRMRR;
		private System.Windows.Forms.Label lblShift;
		private System.Windows.Forms.Label lblPassFlag;
        private System.Windows.Forms.GroupBox grpLoss;
		private System.Windows.Forms.Panel pnlUnitTop;
        private System.Windows.Forms.GroupBox grpQty;
		private System.Windows.Forms.TextBox txtOutQty2;
		private System.Windows.Forms.TextBox txtOutQty1;
		private System.Windows.Forms.TextBox txtLotSMPQty2;
        private System.Windows.Forms.TextBox txtLotSMPQty1;
		private System.Windows.Forms.Label lblOutQty2;
        private System.Windows.Forms.Label lblOutQty1;
		private System.Windows.Forms.Label lblQty2;
        private System.Windows.Forms.Label lblQty1;
		private System.Windows.Forms.Panel pnlUnitMid;
		private System.Windows.Forms.GroupBox grpUnit2;
		private System.Windows.Forms.Label lblUnit2Qty;
		private System.Windows.Forms.Label lblUnit2Code;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code10;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code9;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code8;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code7;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code6;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code5;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code4;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code3;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code2;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2Code1;
		private System.Windows.Forms.Label lblB30;
		private System.Windows.Forms.Label lblB29;
		private System.Windows.Forms.Label lblB28;
		private System.Windows.Forms.Label lblB27;
		private System.Windows.Forms.Label lblB26;
		private System.Windows.Forms.Label lblB25;
		private System.Windows.Forms.Label lblB24;
		private System.Windows.Forms.Label lblB23;
		private System.Windows.Forms.Label lblB22;
		private System.Windows.Forms.Label lblB21;
		private System.Windows.Forms.Panel pnlSeperator;
		private System.Windows.Forms.GroupBox grpUnit1;
		private System.Windows.Forms.Label lblUnit1Qty;
		private System.Windows.Forms.Label lblUnit1Code;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code10;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code9;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code8;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code7;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code6;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code5;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code4;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code3;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code2;
		private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1Code1;
		private System.Windows.Forms.Label lblB20;
		private System.Windows.Forms.Label lblB19;
		private System.Windows.Forms.Label lblB18;
		private System.Windows.Forms.Label lblB17;
		private System.Windows.Forms.Label lblB16;
		private System.Windows.Forms.Label lblB15;
		private System.Windows.Forms.Label lblB14;
		private System.Windows.Forms.Label lblB13;
		private System.Windows.Forms.Label lblB12;
		private System.Windows.Forms.Label lblB11;
		private System.Windows.Forms.TabPage tbpDefect1;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty10;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty9;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty8;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty7;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty6;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty5;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty4;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty3;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty2;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit1Qty1;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty10;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty9;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty8;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty7;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty6;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty5;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty4;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty3;
		private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty2;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtUnit2Qty1;
        private System.Windows.Forms.TextBox txtInspector;
        private System.Windows.Forms.Label lblInspector;
        private System.Windows.Forms.TextBox txtTestCount;
        private System.Windows.Forms.Label lblTestCount;
        private System.Windows.Forms.TextBox txtSMPType;
        private System.Windows.Forms.Label lblSMPType;
        private System.Windows.Forms.TextBox txtQAOper;
        private System.Windows.Forms.Label lblQAGateOper;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TabPage tbpDefect2;
        private System.Windows.Forms.TextBox txtLotQty2;
        private System.Windows.Forms.TextBox txtLotQty1;
        private System.Windows.Forms.Label lblLotQyt2;
        private System.Windows.Forms.Label lblLotQty1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLotQty_2;
        private System.Windows.Forms.TextBox txtLotQty_1;
        private System.Windows.Forms.Label lblLotQty_2;
        private System.Windows.Forms.Label lblLotQty_1;
        private System.Windows.Forms.TextBox txtTotlYield;
        private System.Windows.Forms.TextBox txtDefectCount;
        private System.Windows.Forms.TextBox txtTotDefQty;
        private System.Windows.Forms.TextBox txtDefSubLotCnt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalDefectCount;
        private System.Windows.Forms.Label lblTotalDefectQty;
        private System.Windows.Forms.Label lblDefectSubLotCount;
        private System.Windows.Forms.SplitContainer splitContainer1;
        protected FarPoint.Win.Spread.FpSpread spdDefectData;
        protected FarPoint.Win.Spread.SheetView spdDefectData_LotInfo;
        private System.Windows.Forms.ListView lisSubLot;
        private System.Windows.Forms.ColumnHeader colSubLot;
        private System.Windows.Forms.ColumnHeader colSlotNo;
        private System.Windows.Forms.ColumnHeader colInQty;
        private System.Windows.Forms.ColumnHeader colDefectQty;
        private System.Windows.Forms.ColumnHeader colOutQty;
        private System.Windows.Forms.ColumnHeader colYield;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvSublotID;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDefect;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Panel pnlWafer;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkWaferSelect;
        private System.Windows.Forms.TextBox txtSMPDesc;
        private System.Windows.Forms.TextBox txtSMPRule;
        private System.Windows.Forms.Label lblSMPRule;
        private System.Windows.Forms.GroupBox grpSMPUnit1;
        private System.Windows.Forms.TextBox txtUnit1SMPSelType;
        private System.Windows.Forms.Label lblUnit1SMPSelType;
        private System.Windows.Forms.TextBox txtUnit1SMPSize;
        private System.Windows.Forms.Label lblUnit1SMPSize;
        private System.Windows.Forms.TextBox txtUnit1SMPSizeType;
        private System.Windows.Forms.Label lblUnit1SMPSizeType;
        private System.Windows.Forms.CheckBox chkSMPUnit2Flag;
        private System.Windows.Forms.CheckBox chkSMPUnit1Flag;
        private System.Windows.Forms.GroupBox grpSMPUnit2;
        private System.Windows.Forms.TextBox txtUnit2SMPSelType;
        private System.Windows.Forms.Label lblUnit2SMPSelType;
        private System.Windows.Forms.TextBox txtUnit2SMPSize;
        private System.Windows.Forms.Label lblUnit2SMPSize;
        private System.Windows.Forms.TextBox txtUnit2SMPSizeType;
        private System.Windows.Forms.Label lblUnit2SMPSizeType;
        private System.Windows.Forms.TextBox txtPassFail;
        private System.Windows.Forms.Label lblResultType;
        private System.Windows.Forms.TextBox txtActionDesc;
        private System.Windows.Forms.TextBox txtSMPQty_2;
        private System.Windows.Forms.TextBox txtSMPQty_1;
        private System.Windows.Forms.Label lblSMPQty_2;
        private System.Windows.Forms.Label lblSMPQty_1;
        private System.Windows.Forms.TextBox txtDefQty2;
        private System.Windows.Forms.TextBox txtDefQty1;
        private System.Windows.Forms.Label lblDefQty2;
        private System.Windows.Forms.Label lblDefQty1;
        private System.Windows.Forms.TextBox txtIRRMRR;
    }
}