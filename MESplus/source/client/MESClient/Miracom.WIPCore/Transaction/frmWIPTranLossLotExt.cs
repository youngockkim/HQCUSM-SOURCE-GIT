
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranLossLotExt.vb
//   Description : Loss Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - View_Operation() : View Operation Information
//       - Loss_Lot() : Loss Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-05-11 : Created by CM Koo
//       - 2008-01-21 : Added by W.Y Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI;
using Infragistics.Win.UltraWinEditors;
using Miracom.TRSCore;


namespace Miracom.WIPCore
{
    public class frmWIPTranLossLotExt : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranLossLotExt()
        {
            InitializeComponent();
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        
        private System.ComponentModel.Container components = null;
        



        private System.Windows.Forms.TextBox txtChkUser3;
        private System.Windows.Forms.TextBox txtChkUser2;
        private System.Windows.Forms.TextBox txtChkUser1;
        private System.Windows.Forms.Label lblUser3;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.Label lblUser2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseFlow;
        private System.Windows.Forms.Label lblCauseRes;
        private System.Windows.Forms.Label lblCauseOper;
        private System.Windows.Forms.Label lblCauseFlow;
        private System.Windows.Forms.GroupBox grpLoss;
        private System.Windows.Forms.TextBox txtLossComment;
        private System.Windows.Forms.Label lblLossComment;
        private System.Windows.Forms.Panel pnlUnitTop;
        private System.Windows.Forms.GroupBox grpQty;
        private System.Windows.Forms.TextBox txtOutQty2;
        private System.Windows.Forms.TextBox txtOutQty1;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
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
        private System.Windows.Forms.GroupBox grpUnit1;
        private FarPoint.Win.Spread.FpSpread spdSublotLoss;
        private FarPoint.Win.Spread.SheetView spdSublotLoss_Sheet1;
        private System.Windows.Forms.TabPage tbpInfo;
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
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvLossCode;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvGrade;
        private System.Windows.Forms.TextBox txtLossQty2;
        private System.Windows.Forms.TextBox txtLossQty1;
        private System.Windows.Forms.Label lblLossQty2;
        private System.Windows.Forms.Label lblLossQty1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private CheckBox chkNoAutoTermLot;
        private TabControl tabCode;
        private TabPage tbpUnit2;
        private TabPage tbpLossReason;
        private GroupBox grpCodeInfo;
        private FarPoint.Win.Spread.FpSpread spdCodeList;
        private FarPoint.Win.Spread.SheetView spdCodeList_Sheet1;
        private Splitter splUnit;
        private Panel pnlOption;
        private Button btnApply;
        private TextBox txtQty3;
        private Label lblQty3;
        private TextBox txtLossQty3;
        private Label lblLossQty3;
        private TextBox txtOutQty3;
        private Label lblOutQty3;
        private TabPage tbpUnit3;
        private GroupBox grpUnit3;
        private UltraNumericEditor txtUnit3Qty10;
        private UltraNumericEditor txtUnit3Qty9;
        private UltraNumericEditor txtUnit3Qty8;
        private UltraNumericEditor txtUnit3Qty7;
        private UltraNumericEditor txtUnit3Qty6;
        private UltraNumericEditor txtUnit3Qty5;
        private UltraNumericEditor txtUnit3Qty4;
        private UltraNumericEditor txtUnit3Qty3;
        private UltraNumericEditor txtUnit3Qty2;
        private UltraNumericEditor txtUnit3Qty1;
        private Label lblUnit3Qty;
        private Label lblUnit3Code;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3Code1;
        private Label lblUnit3Qty10;
        private Label lblUnit3Qty9;
        private Label lblUnit3Qty8;
        private Label lblUnit3Qty7;
        private Label lblUnit3Qty6;
        private Label lblUnit3Qty5;
        private Label lblUnit3Qty4;
        private Label lblUnit3Qty3;
        private Label lblUnit3Qty2;
        private Label lblUnit3Qty1;
        private System.Windows.Forms.Label lblCrrID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.grpLoss = new System.Windows.Forms.GroupBox();
            this.chkNoAutoTermLot = new System.Windows.Forms.CheckBox();
            this.cdvCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.cdvCauseRes = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCauseOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCauseFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseRes = new System.Windows.Forms.Label();
            this.lblCauseOper = new System.Windows.Forms.Label();
            this.lblCauseFlow = new System.Windows.Forms.Label();
            this.txtChkUser3 = new System.Windows.Forms.TextBox();
            this.txtChkUser2 = new System.Windows.Forms.TextBox();
            this.txtChkUser1 = new System.Windows.Forms.TextBox();
            this.lblUser3 = new System.Windows.Forms.Label();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.txtLossComment = new System.Windows.Forms.TextBox();
            this.lblLossComment = new System.Windows.Forms.Label();
            this.tbpInfo = new System.Windows.Forms.TabPage();
            this.pnlUnitMid = new System.Windows.Forms.Panel();
            this.grpUnit1 = new System.Windows.Forms.GroupBox();
            this.spdSublotLoss = new FarPoint.Win.Spread.FpSpread();
            this.spdSublotLoss_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splUnit = new System.Windows.Forms.Splitter();
            this.tabCode = new System.Windows.Forms.TabControl();
            this.tbpUnit2 = new System.Windows.Forms.TabPage();
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
            this.tbpUnit3 = new System.Windows.Forms.TabPage();
            this.grpUnit3 = new System.Windows.Forms.GroupBox();
            this.txtUnit3Qty10 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit3Qty9 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit3Qty8 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit3Qty7 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit3Qty6 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit3Qty5 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit3Qty4 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit3Qty3 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit3Qty2 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtUnit3Qty1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblUnit3Qty = new System.Windows.Forms.Label();
            this.lblUnit3Code = new System.Windows.Forms.Label();
            this.cdvUnit3Code10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3Code9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3Code8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3Code7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3Code6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3Code5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3Code4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3Code3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3Code2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3Code1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUnit3Qty10 = new System.Windows.Forms.Label();
            this.lblUnit3Qty9 = new System.Windows.Forms.Label();
            this.lblUnit3Qty8 = new System.Windows.Forms.Label();
            this.lblUnit3Qty7 = new System.Windows.Forms.Label();
            this.lblUnit3Qty6 = new System.Windows.Forms.Label();
            this.lblUnit3Qty5 = new System.Windows.Forms.Label();
            this.lblUnit3Qty4 = new System.Windows.Forms.Label();
            this.lblUnit3Qty3 = new System.Windows.Forms.Label();
            this.lblUnit3Qty2 = new System.Windows.Forms.Label();
            this.lblUnit3Qty1 = new System.Windows.Forms.Label();
            this.tbpLossReason = new System.Windows.Forms.TabPage();
            this.grpCodeInfo = new System.Windows.Forms.GroupBox();
            this.spdCodeList = new FarPoint.Win.Spread.FpSpread();
            this.spdCodeList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlOption = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.pnlUnitTop = new System.Windows.Forms.Panel();
            this.grpQty = new System.Windows.Forms.GroupBox();
            this.txtLossQty3 = new System.Windows.Forms.TextBox();
            this.lblLossQty3 = new System.Windows.Forms.Label();
            this.txtOutQty3 = new System.Windows.Forms.TextBox();
            this.lblOutQty3 = new System.Windows.Forms.Label();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.txtLossQty2 = new System.Windows.Forms.TextBox();
            this.txtLossQty1 = new System.Windows.Forms.TextBox();
            this.lblLossQty2 = new System.Windows.Forms.Label();
            this.lblLossQty1 = new System.Windows.Forms.Label();
            this.txtOutQty2 = new System.Windows.Forms.TextBox();
            this.txtOutQty1 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblOutQty2 = new System.Windows.Forms.Label();
            this.lblOutQty1 = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.cdvLossCode = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvGrade = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.tbpInfo.SuspendLayout();
            this.pnlUnitMid.SuspendLayout();
            this.grpUnit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdSublotLoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSublotLoss_Sheet1)).BeginInit();
            this.tabCode.SuspendLayout();
            this.tbpUnit2.SuspendLayout();
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
            this.tbpUnit3.SuspendLayout();
            this.grpUnit3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code1)).BeginInit();
            this.tbpLossReason.SuspendLayout();
            this.grpCodeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCodeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCodeList_Sheet1)).BeginInit();
            this.pnlOption.SuspendLayout();
            this.pnlUnitTop.SuspendLayout();
            this.grpQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLossCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpLoss);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 203);
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
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(722, 344);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 347);
            this.pnlComment.Size = new System.Drawing.Size(722, 75);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtLossComment);
            this.grpComment.Controls.Add(this.lblLossComment);
            this.grpComment.Size = new System.Drawing.Size(722, 75);
            this.grpComment.Controls.SetChildIndex(this.lblComment, 0);
            this.grpComment.Controls.SetChildIndex(this.txtComment, 0);
            this.grpComment.Controls.SetChildIndex(this.lblLossComment, 0);
            this.grpComment.Controls.SetChildIndex(this.txtLossComment, 0);
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
            this.tabTran.Controls.Add(this.tbpInfo);
            this.tabTran.Controls.SetChildIndex(this.tbpCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpInfo, 0);
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
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Loss Lot";
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
            // 
            // grpLoss
            // 
            this.grpLoss.Controls.Add(this.chkNoAutoTermLot);
            this.grpLoss.Controls.Add(this.cdvCrrID);
            this.grpLoss.Controls.Add(this.lblCrrID);
            this.grpLoss.Controls.Add(this.cdvCauseRes);
            this.grpLoss.Controls.Add(this.cdvCauseOper);
            this.grpLoss.Controls.Add(this.cdvCauseFlow);
            this.grpLoss.Controls.Add(this.lblCauseRes);
            this.grpLoss.Controls.Add(this.lblCauseOper);
            this.grpLoss.Controls.Add(this.lblCauseFlow);
            this.grpLoss.Controls.Add(this.txtChkUser3);
            this.grpLoss.Controls.Add(this.txtChkUser2);
            this.grpLoss.Controls.Add(this.txtChkUser1);
            this.grpLoss.Controls.Add(this.lblUser3);
            this.grpLoss.Controls.Add(this.lblUser1);
            this.grpLoss.Controls.Add(this.lblUser2);
            this.grpLoss.Controls.Add(this.cdvResID);
            this.grpLoss.Controls.Add(this.lblResID);
            this.grpLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLoss.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLoss.Location = new System.Drawing.Point(0, 0);
            this.grpLoss.Name = "grpLoss";
            this.grpLoss.Size = new System.Drawing.Size(722, 203);
            this.grpLoss.TabIndex = 0;
            this.grpLoss.TabStop = false;
            // 
            // chkNoAutoTermLot
            // 
            this.chkNoAutoTermLot.AutoSize = true;
            this.chkNoAutoTermLot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoAutoTermLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNoAutoTermLot.Location = new System.Drawing.Point(12, 111);
            this.chkNoAutoTermLot.Name = "chkNoAutoTermLot";
            this.chkNoAutoTermLot.Size = new System.Drawing.Size(164, 18);
            this.chkNoAutoTermLot.TabIndex = 8;
            this.chkNoAutoTermLot.Text = "No Automatic Terminate Lot";
            // 
            // cdvCrrID
            // 
            this.cdvCrrID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrID.BtnToolTipText = "";
            this.cdvCrrID.DescText = "";
            this.cdvCrrID.DisplaySubItemIndex = -1;
            this.cdvCrrID.DisplayText = "";
            this.cdvCrrID.Focusing = null;
            this.cdvCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrID.Index = 0;
            this.cdvCrrID.IsViewBtnImage = false;
            this.cdvCrrID.Location = new System.Drawing.Point(458, 88);
            this.cdvCrrID.MaxLength = 20;
            this.cdvCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.Name = "cdvCrrID";
            this.cdvCrrID.ReadOnly = false;
            this.cdvCrrID.SearchSubItemIndex = 0;
            this.cdvCrrID.SelectedDescIndex = -1;
            this.cdvCrrID.SelectedSubItemIndex = -1;
            this.cdvCrrID.SelectionStart = 0;
            this.cdvCrrID.Size = new System.Drawing.Size(200, 20);
            this.cdvCrrID.SmallImageList = null;
            this.cdvCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrID.TabIndex = 16;
            this.cdvCrrID.TextBoxToolTipText = "";
            this.cdvCrrID.TextBoxWidth = 200;
            this.cdvCrrID.Visible = false;
            this.cdvCrrID.VisibleButton = true;
            this.cdvCrrID.VisibleColumnHeader = false;
            this.cdvCrrID.VisibleDescription = false;
            this.cdvCrrID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrID_SelectedItemChanged);
            this.cdvCrrID.TextBoxTextChanged += new System.EventHandler(this.cdvCrrID_TextBoxTextChanged);
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Location = new System.Drawing.Point(352, 91);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(51, 13);
            this.lblCrrID.TabIndex = 15;
            this.lblCrrID.Text = "Carrier ID";
            this.lblCrrID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCrrID.Visible = false;
            // 
            // cdvCauseRes
            // 
            this.cdvCauseRes.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseRes.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseRes.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseRes.BtnToolTipText = "";
            this.cdvCauseRes.DescText = "";
            this.cdvCauseRes.DisplaySubItemIndex = -1;
            this.cdvCauseRes.DisplayText = "";
            this.cdvCauseRes.Focusing = null;
            this.cdvCauseRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseRes.Index = 0;
            this.cdvCauseRes.IsViewBtnImage = false;
            this.cdvCauseRes.Location = new System.Drawing.Point(458, 64);
            this.cdvCauseRes.MaxLength = 20;
            this.cdvCauseRes.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseRes.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseRes.Name = "cdvCauseRes";
            this.cdvCauseRes.ReadOnly = false;
            this.cdvCauseRes.SearchSubItemIndex = 0;
            this.cdvCauseRes.SelectedDescIndex = -1;
            this.cdvCauseRes.SelectedSubItemIndex = -1;
            this.cdvCauseRes.SelectionStart = 0;
            this.cdvCauseRes.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseRes.SmallImageList = null;
            this.cdvCauseRes.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseRes.TabIndex = 14;
            this.cdvCauseRes.TextBoxToolTipText = "";
            this.cdvCauseRes.TextBoxWidth = 200;
            this.cdvCauseRes.VisibleButton = true;
            this.cdvCauseRes.VisibleColumnHeader = false;
            this.cdvCauseRes.VisibleDescription = false;
            this.cdvCauseRes.ButtonPress += new System.EventHandler(this.cdvCauseRes_ButtonPress);
            // 
            // cdvCauseOper
            // 
            this.cdvCauseOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseOper.BtnToolTipText = "";
            this.cdvCauseOper.DescText = "";
            this.cdvCauseOper.DisplaySubItemIndex = -1;
            this.cdvCauseOper.DisplayText = "";
            this.cdvCauseOper.Focusing = null;
            this.cdvCauseOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseOper.Index = 0;
            this.cdvCauseOper.IsViewBtnImage = false;
            this.cdvCauseOper.Location = new System.Drawing.Point(458, 40);
            this.cdvCauseOper.MaxLength = 10;
            this.cdvCauseOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseOper.Name = "cdvCauseOper";
            this.cdvCauseOper.ReadOnly = false;
            this.cdvCauseOper.SearchSubItemIndex = 0;
            this.cdvCauseOper.SelectedDescIndex = -1;
            this.cdvCauseOper.SelectedSubItemIndex = -1;
            this.cdvCauseOper.SelectionStart = 0;
            this.cdvCauseOper.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseOper.SmallImageList = null;
            this.cdvCauseOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseOper.TabIndex = 12;
            this.cdvCauseOper.TextBoxToolTipText = "";
            this.cdvCauseOper.TextBoxWidth = 200;
            this.cdvCauseOper.VisibleButton = true;
            this.cdvCauseOper.VisibleColumnHeader = false;
            this.cdvCauseOper.VisibleDescription = false;
            this.cdvCauseOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCauseOper_SelectedItemChanged);
            this.cdvCauseOper.ButtonPress += new System.EventHandler(this.cdvCauseOper_ButtonPress);
            // 
            // cdvCauseFlow
            // 
            this.cdvCauseFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseFlow.BtnToolTipText = "";
            this.cdvCauseFlow.DescText = "";
            this.cdvCauseFlow.DisplaySubItemIndex = -1;
            this.cdvCauseFlow.DisplayText = "";
            this.cdvCauseFlow.Focusing = null;
            this.cdvCauseFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseFlow.Index = 0;
            this.cdvCauseFlow.IsViewBtnImage = false;
            this.cdvCauseFlow.Location = new System.Drawing.Point(458, 16);
            this.cdvCauseFlow.MaxLength = 20;
            this.cdvCauseFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseFlow.Name = "cdvCauseFlow";
            this.cdvCauseFlow.ReadOnly = false;
            this.cdvCauseFlow.SearchSubItemIndex = 0;
            this.cdvCauseFlow.SelectedDescIndex = -1;
            this.cdvCauseFlow.SelectedSubItemIndex = -1;
            this.cdvCauseFlow.SelectionStart = 0;
            this.cdvCauseFlow.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseFlow.SmallImageList = null;
            this.cdvCauseFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseFlow.TabIndex = 10;
            this.cdvCauseFlow.TextBoxToolTipText = "";
            this.cdvCauseFlow.TextBoxWidth = 200;
            this.cdvCauseFlow.VisibleButton = true;
            this.cdvCauseFlow.VisibleColumnHeader = false;
            this.cdvCauseFlow.VisibleDescription = false;
            this.cdvCauseFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCauseFlow_SelectedItemChanged);
            this.cdvCauseFlow.ButtonPress += new System.EventHandler(this.cdvCauseFlow_ButtonPress);
            // 
            // lblCauseRes
            // 
            this.lblCauseRes.AutoSize = true;
            this.lblCauseRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseRes.Location = new System.Drawing.Point(352, 67);
            this.lblCauseRes.Name = "lblCauseRes";
            this.lblCauseRes.Size = new System.Drawing.Size(86, 13);
            this.lblCauseRes.TabIndex = 13;
            this.lblCauseRes.Text = "Cause Resource";
            this.lblCauseRes.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCauseOper
            // 
            this.lblCauseOper.AutoSize = true;
            this.lblCauseOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseOper.Location = new System.Drawing.Point(352, 43);
            this.lblCauseOper.Name = "lblCauseOper";
            this.lblCauseOper.Size = new System.Drawing.Size(86, 13);
            this.lblCauseOper.TabIndex = 11;
            this.lblCauseOper.Text = "Cause Operation";
            this.lblCauseOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCauseFlow
            // 
            this.lblCauseFlow.AutoSize = true;
            this.lblCauseFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseFlow.Location = new System.Drawing.Point(352, 19);
            this.lblCauseFlow.Name = "lblCauseFlow";
            this.lblCauseFlow.Size = new System.Drawing.Size(62, 13);
            this.lblCauseFlow.TabIndex = 9;
            this.lblCauseFlow.Text = "Cause Flow";
            this.lblCauseFlow.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtChkUser3
            // 
            this.txtChkUser3.Location = new System.Drawing.Point(118, 88);
            this.txtChkUser3.MaxLength = 20;
            this.txtChkUser3.Name = "txtChkUser3";
            this.txtChkUser3.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser3.TabIndex = 7;
            // 
            // txtChkUser2
            // 
            this.txtChkUser2.Location = new System.Drawing.Point(118, 64);
            this.txtChkUser2.MaxLength = 20;
            this.txtChkUser2.Name = "txtChkUser2";
            this.txtChkUser2.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser2.TabIndex = 5;
            // 
            // txtChkUser1
            // 
            this.txtChkUser1.Location = new System.Drawing.Point(118, 40);
            this.txtChkUser1.MaxLength = 20;
            this.txtChkUser1.Name = "txtChkUser1";
            this.txtChkUser1.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser1.TabIndex = 3;
            // 
            // lblUser3
            // 
            this.lblUser3.AutoSize = true;
            this.lblUser3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser3.Location = new System.Drawing.Point(12, 90);
            this.lblUser3.Name = "lblUser3";
            this.lblUser3.Size = new System.Drawing.Size(86, 13);
            this.lblUser3.TabIndex = 6;
            this.lblUser3.Text = "Check User ID 3";
            this.lblUser3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser1.Location = new System.Drawing.Point(12, 42);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(86, 13);
            this.lblUser1.TabIndex = 2;
            this.lblUser1.Text = "Check User ID 1";
            this.lblUser1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser2.Location = new System.Drawing.Point(12, 66);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(86, 13);
            this.lblUser2.TabIndex = 4;
            this.lblUser2.Text = "Check User ID 2";
            this.lblUser2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(118, 16);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Location = new System.Drawing.Point(12, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtLossComment
            // 
            this.txtLossComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLossComment.Location = new System.Drawing.Point(120, 36);
            this.txtLossComment.MaxLength = 400;
            this.txtLossComment.Multiline = true;
            this.txtLossComment.Name = "txtLossComment";
            this.txtLossComment.Size = new System.Drawing.Size(590, 34);
            this.txtLossComment.TabIndex = 3;
            // 
            // lblLossComment
            // 
            this.lblLossComment.AutoSize = true;
            this.lblLossComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLossComment.Location = new System.Drawing.Point(15, 38);
            this.lblLossComment.Name = "lblLossComment";
            this.lblLossComment.Size = new System.Drawing.Size(76, 13);
            this.lblLossComment.TabIndex = 2;
            this.lblLossComment.Text = "Loss Comment";
            this.lblLossComment.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbpInfo
            // 
            this.tbpInfo.Controls.Add(this.pnlUnitMid);
            this.tbpInfo.Controls.Add(this.pnlUnitTop);
            this.tbpInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpInfo.Name = "tbpInfo";
            this.tbpInfo.Size = new System.Drawing.Size(728, 422);
            this.tbpInfo.TabIndex = 2;
            this.tbpInfo.Text = "Loss Information";
            // 
            // pnlUnitMid
            // 
            this.pnlUnitMid.Controls.Add(this.grpUnit1);
            this.pnlUnitMid.Controls.Add(this.splUnit);
            this.pnlUnitMid.Controls.Add(this.tabCode);
            this.pnlUnitMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnitMid.Location = new System.Drawing.Point(0, 94);
            this.pnlUnitMid.Name = "pnlUnitMid";
            this.pnlUnitMid.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlUnitMid.Size = new System.Drawing.Size(728, 328);
            this.pnlUnitMid.TabIndex = 2;
            // 
            // grpUnit1
            // 
            this.grpUnit1.Controls.Add(this.spdSublotLoss);
            this.grpUnit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUnit1.Location = new System.Drawing.Point(3, 5);
            this.grpUnit1.Name = "grpUnit1";
            this.grpUnit1.Size = new System.Drawing.Size(471, 320);
            this.grpUnit1.TabIndex = 0;
            this.grpUnit1.TabStop = false;
            this.grpUnit1.Text = "Unit1";
            // 
            // spdSublotLoss
            // 
            this.spdSublotLoss.AccessibleDescription = "spdSublotLoss, Sheet1, Row 0, Column 0, ";
            this.spdSublotLoss.AllowEditOverflow = true;
            this.spdSublotLoss.BackColor = System.Drawing.SystemColors.Control;
            this.spdSublotLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSublotLoss.EditModeReplace = true;
            this.spdSublotLoss.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSublotLoss.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSublotLoss.HorizontalScrollBar.Name = "";
            this.spdSublotLoss.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdSublotLoss.HorizontalScrollBar.TabIndex = 6;
            this.spdSublotLoss.Location = new System.Drawing.Point(3, 16);
            this.spdSublotLoss.Name = "spdSublotLoss";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer2;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer2;
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
            this.spdSublotLoss.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdSublotLoss.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdSublotLoss.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdSublotLoss.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdSublotLoss.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSublotLoss_Sheet1});
            this.spdSublotLoss.Size = new System.Drawing.Size(465, 301);
            this.spdSublotLoss.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSublotLoss.TabIndex = 0;
            this.spdSublotLoss.TabStop = false;
            this.spdSublotLoss.TextTipDelay = 200;
            this.spdSublotLoss.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdSublotLoss.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSublotLoss.VerticalScrollBar.Name = "";
            this.spdSublotLoss.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdSublotLoss.VerticalScrollBar.TabIndex = 7;
            this.spdSublotLoss.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdSublotLoss_SelectionChanged);
            this.spdSublotLoss.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdSublotLoss_EnterCell);
            this.spdSublotLoss.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdSublotLoss_ButtonClicked);
            // 
            // spdSublotLoss_Sheet1
            // 
            this.spdSublotLoss_Sheet1.Reset();
            spdSublotLoss_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSublotLoss_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSublotLoss_Sheet1.ColumnCount = 9;
            spdSublotLoss_Sheet1.RowCount = 3;
            spdSublotLoss_Sheet1.RowHeader.ColumnCount = 0;
            this.spdSublotLoss_Sheet1.ColumnFooter.Columns.Default.MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdSublotLoss_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotLoss_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSublotLoss_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotLoss_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSublotLoss_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Slot";
            this.spdSublotLoss_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sub Lot ID";
            this.spdSublotLoss_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdSublotLoss_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Grade";
            this.spdSublotLoss_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdSublotLoss_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Loss Code";
            this.spdSublotLoss_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Cell Grade";
            this.spdSublotLoss_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Qty2";
            this.spdSublotLoss_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Cell Judge";
            this.spdSublotLoss_Sheet1.ColumnHeader.Columns.Default.MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdSublotLoss_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotLoss_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSublotLoss_Sheet1.Columns.Default.MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdSublotLoss_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSublotLoss_Sheet1.Columns.Get(0).Label = "Slot";
            this.spdSublotLoss_Sheet1.Columns.Get(0).Locked = true;
            this.spdSublotLoss_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotLoss_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotLoss_Sheet1.Columns.Get(0).Width = 40F;
            this.spdSublotLoss_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotLoss_Sheet1.Columns.Get(1).Label = "Sub Lot ID";
            this.spdSublotLoss_Sheet1.Columns.Get(1).Locked = true;
            this.spdSublotLoss_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotLoss_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotLoss_Sheet1.Columns.Get(1).Width = 120F;
            textCellType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            textCellType1.MaxLength = 1;
            this.spdSublotLoss_Sheet1.Columns.Get(2).CellType = textCellType1;
            this.spdSublotLoss_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdSublotLoss_Sheet1.Columns.Get(2).Label = "Grade";
            this.spdSublotLoss_Sheet1.Columns.Get(2).Locked = false;
            this.spdSublotLoss_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotLoss_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotLoss_Sheet1.Columns.Get(2).Width = 35F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdSublotLoss_Sheet1.Columns.Get(3).CellType = buttonCellType1;
            this.spdSublotLoss_Sheet1.Columns.Get(3).Width = 20F;
            this.spdSublotLoss_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotLoss_Sheet1.Columns.Get(4).Label = "Loss Code";
            this.spdSublotLoss_Sheet1.Columns.Get(4).Locked = true;
            this.spdSublotLoss_Sheet1.Columns.Get(4).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotLoss_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotLoss_Sheet1.Columns.Get(4).Width = 75F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdSublotLoss_Sheet1.Columns.Get(5).CellType = buttonCellType2;
            this.spdSublotLoss_Sheet1.Columns.Get(5).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotLoss_Sheet1.Columns.Get(5).Width = 20F;
            this.spdSublotLoss_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("DotumChe", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdSublotLoss_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotLoss_Sheet1.Columns.Get(6).Label = "Cell Grade";
            this.spdSublotLoss_Sheet1.Columns.Get(6).Locked = false;
            this.spdSublotLoss_Sheet1.Columns.Get(6).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotLoss_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotLoss_Sheet1.Columns.Get(6).Width = 84F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999D;
            numberCellType1.MinimumValue = 0D;
            this.spdSublotLoss_Sheet1.Columns.Get(7).CellType = numberCellType1;
            this.spdSublotLoss_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdSublotLoss_Sheet1.Columns.Get(7).Label = "Qty2";
            this.spdSublotLoss_Sheet1.Columns.Get(7).Locked = false;
            this.spdSublotLoss_Sheet1.Columns.Get(7).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotLoss_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotLoss_Sheet1.Columns.Get(7).Width = 50F;
            this.spdSublotLoss_Sheet1.Columns.Get(8).Font = new System.Drawing.Font("DotumChe", 9F);
            this.spdSublotLoss_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSublotLoss_Sheet1.Columns.Get(8).Label = "Cell Judge";
            this.spdSublotLoss_Sheet1.Columns.Get(8).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            this.spdSublotLoss_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSublotLoss_Sheet1.Columns.Get(8).Width = 74F;
            this.spdSublotLoss_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdSublotLoss_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSublotLoss_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotLoss_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSublotLoss_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSublotLoss_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSublotLoss_Sheet1.CellChanged += new FarPoint.Win.Spread.SheetViewEventHandler(this.spdSublotLoss_Sheet1_CellChanged);
            this.spdSublotLoss_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splUnit
            // 
            this.splUnit.Dock = System.Windows.Forms.DockStyle.Right;
            this.splUnit.Location = new System.Drawing.Point(474, 5);
            this.splUnit.Name = "splUnit";
            this.splUnit.Size = new System.Drawing.Size(5, 320);
            this.splUnit.TabIndex = 4;
            this.splUnit.TabStop = false;
            // 
            // tabCode
            // 
            this.tabCode.Controls.Add(this.tbpUnit2);
            this.tabCode.Controls.Add(this.tbpUnit3);
            this.tabCode.Controls.Add(this.tbpLossReason);
            this.tabCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabCode.Location = new System.Drawing.Point(479, 5);
            this.tabCode.Name = "tabCode";
            this.tabCode.SelectedIndex = 0;
            this.tabCode.Size = new System.Drawing.Size(246, 320);
            this.tabCode.TabIndex = 3;
            // 
            // tbpUnit2
            // 
            this.tbpUnit2.BackColor = System.Drawing.Color.Transparent;
            this.tbpUnit2.Controls.Add(this.grpUnit2);
            this.tbpUnit2.Location = new System.Drawing.Point(4, 22);
            this.tbpUnit2.Name = "tbpUnit2";
            this.tbpUnit2.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUnit2.Size = new System.Drawing.Size(238, 294);
            this.tbpUnit2.TabIndex = 0;
            this.tbpUnit2.Text = "Unit 2";
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
            this.grpUnit2.Location = new System.Drawing.Point(3, 3);
            this.grpUnit2.Name = "grpUnit2";
            this.grpUnit2.Size = new System.Drawing.Size(232, 288);
            this.grpUnit2.TabIndex = 1;
            this.grpUnit2.TabStop = false;
            // 
            // txtUnit2Qty10
            // 
            this.txtUnit2Qty10.Location = new System.Drawing.Point(146, 253);
            this.txtUnit2Qty10.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty10.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty10.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty10.Name = "txtUnit2Qty10";
            this.txtUnit2Qty10.Nullable = true;
            this.txtUnit2Qty10.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty10.PromptChar = ' ';
            this.txtUnit2Qty10.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty10.TabIndex = 31;
            this.txtUnit2Qty10.Value = null;
            this.txtUnit2Qty10.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // txtUnit2Qty9
            // 
            this.txtUnit2Qty9.Location = new System.Drawing.Point(146, 229);
            this.txtUnit2Qty9.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty9.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty9.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty9.Name = "txtUnit2Qty9";
            this.txtUnit2Qty9.Nullable = true;
            this.txtUnit2Qty9.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty9.PromptChar = ' ';
            this.txtUnit2Qty9.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty9.TabIndex = 28;
            this.txtUnit2Qty9.Value = null;
            this.txtUnit2Qty9.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // txtUnit2Qty8
            // 
            this.txtUnit2Qty8.Location = new System.Drawing.Point(146, 205);
            this.txtUnit2Qty8.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty8.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty8.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty8.Name = "txtUnit2Qty8";
            this.txtUnit2Qty8.Nullable = true;
            this.txtUnit2Qty8.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty8.PromptChar = ' ';
            this.txtUnit2Qty8.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty8.TabIndex = 25;
            this.txtUnit2Qty8.Value = null;
            this.txtUnit2Qty8.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // txtUnit2Qty7
            // 
            this.txtUnit2Qty7.Location = new System.Drawing.Point(146, 181);
            this.txtUnit2Qty7.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty7.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty7.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty7.Name = "txtUnit2Qty7";
            this.txtUnit2Qty7.Nullable = true;
            this.txtUnit2Qty7.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty7.PromptChar = ' ';
            this.txtUnit2Qty7.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty7.TabIndex = 22;
            this.txtUnit2Qty7.Value = null;
            this.txtUnit2Qty7.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // txtUnit2Qty6
            // 
            this.txtUnit2Qty6.Location = new System.Drawing.Point(146, 157);
            this.txtUnit2Qty6.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty6.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty6.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty6.Name = "txtUnit2Qty6";
            this.txtUnit2Qty6.Nullable = true;
            this.txtUnit2Qty6.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty6.PromptChar = ' ';
            this.txtUnit2Qty6.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty6.TabIndex = 19;
            this.txtUnit2Qty6.Value = null;
            this.txtUnit2Qty6.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // txtUnit2Qty5
            // 
            this.txtUnit2Qty5.Location = new System.Drawing.Point(146, 133);
            this.txtUnit2Qty5.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty5.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty5.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty5.Name = "txtUnit2Qty5";
            this.txtUnit2Qty5.Nullable = true;
            this.txtUnit2Qty5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty5.PromptChar = ' ';
            this.txtUnit2Qty5.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty5.TabIndex = 16;
            this.txtUnit2Qty5.Value = null;
            this.txtUnit2Qty5.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // txtUnit2Qty4
            // 
            this.txtUnit2Qty4.Location = new System.Drawing.Point(146, 109);
            this.txtUnit2Qty4.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty4.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty4.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty4.Name = "txtUnit2Qty4";
            this.txtUnit2Qty4.Nullable = true;
            this.txtUnit2Qty4.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty4.PromptChar = ' ';
            this.txtUnit2Qty4.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty4.TabIndex = 13;
            this.txtUnit2Qty4.Value = null;
            this.txtUnit2Qty4.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // txtUnit2Qty3
            // 
            this.txtUnit2Qty3.Location = new System.Drawing.Point(146, 85);
            this.txtUnit2Qty3.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty3.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty3.Name = "txtUnit2Qty3";
            this.txtUnit2Qty3.Nullable = true;
            this.txtUnit2Qty3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty3.PromptChar = ' ';
            this.txtUnit2Qty3.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty3.TabIndex = 10;
            this.txtUnit2Qty3.Value = null;
            this.txtUnit2Qty3.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // txtUnit2Qty2
            // 
            this.txtUnit2Qty2.Location = new System.Drawing.Point(146, 61);
            this.txtUnit2Qty2.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty2.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty2.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty2.Name = "txtUnit2Qty2";
            this.txtUnit2Qty2.Nullable = true;
            this.txtUnit2Qty2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty2.PromptChar = ' ';
            this.txtUnit2Qty2.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty2.TabIndex = 7;
            this.txtUnit2Qty2.Value = null;
            this.txtUnit2Qty2.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // txtUnit2Qty1
            // 
            this.txtUnit2Qty1.Location = new System.Drawing.Point(146, 37);
            this.txtUnit2Qty1.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty1.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit2Qty1.MaskInput = "+nnnnnnn";
            this.txtUnit2Qty1.Name = "txtUnit2Qty1";
            this.txtUnit2Qty1.Nullable = true;
            this.txtUnit2Qty1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit2Qty1.PromptChar = ' ';
            this.txtUnit2Qty1.Size = new System.Drawing.Size(77, 20);
            this.txtUnit2Qty1.TabIndex = 4;
            this.txtUnit2Qty1.Value = null;
            this.txtUnit2Qty1.AfterExitEditMode += new System.EventHandler(this.txtUnit2Qty_AfterExitEditMode);
            // 
            // lblUnit2Qty
            // 
            this.lblUnit2Qty.AutoSize = true;
            this.lblUnit2Qty.Location = new System.Drawing.Point(148, 17);
            this.lblUnit2Qty.Name = "lblUnit2Qty";
            this.lblUnit2Qty.Size = new System.Drawing.Size(23, 13);
            this.lblUnit2Qty.TabIndex = 1;
            this.lblUnit2Qty.Text = "Qty";
            // 
            // lblUnit2Code
            // 
            this.lblUnit2Code.AutoSize = true;
            this.lblUnit2Code.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit2Code.Location = new System.Drawing.Point(38, 17);
            this.lblUnit2Code.Name = "lblUnit2Code";
            this.lblUnit2Code.Size = new System.Drawing.Size(72, 13);
            this.lblUnit2Code.TabIndex = 0;
            this.lblUnit2Code.Text = "Reason Code";
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
            this.cdvUnit2Code10.Location = new System.Drawing.Point(36, 253);
            this.cdvUnit2Code10.MaxLength = 10;
            this.cdvUnit2Code10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code10.Name = "cdvUnit2Code10";
            this.cdvUnit2Code10.ReadOnly = false;
            this.cdvUnit2Code10.SearchSubItemIndex = 0;
            this.cdvUnit2Code10.SelectedDescIndex = -1;
            this.cdvUnit2Code10.SelectedSubItemIndex = -1;
            this.cdvUnit2Code10.SelectionStart = 0;
            this.cdvUnit2Code10.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code10.SmallImageList = null;
            this.cdvUnit2Code10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code10.TabIndex = 30;
            this.cdvUnit2Code10.TextBoxToolTipText = "";
            this.cdvUnit2Code10.TextBoxWidth = 100;
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
            this.cdvUnit2Code9.Location = new System.Drawing.Point(36, 229);
            this.cdvUnit2Code9.MaxLength = 10;
            this.cdvUnit2Code9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code9.Name = "cdvUnit2Code9";
            this.cdvUnit2Code9.ReadOnly = false;
            this.cdvUnit2Code9.SearchSubItemIndex = 0;
            this.cdvUnit2Code9.SelectedDescIndex = -1;
            this.cdvUnit2Code9.SelectedSubItemIndex = -1;
            this.cdvUnit2Code9.SelectionStart = 0;
            this.cdvUnit2Code9.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code9.SmallImageList = null;
            this.cdvUnit2Code9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code9.TabIndex = 27;
            this.cdvUnit2Code9.TextBoxToolTipText = "";
            this.cdvUnit2Code9.TextBoxWidth = 100;
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
            this.cdvUnit2Code8.Location = new System.Drawing.Point(36, 205);
            this.cdvUnit2Code8.MaxLength = 10;
            this.cdvUnit2Code8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code8.Name = "cdvUnit2Code8";
            this.cdvUnit2Code8.ReadOnly = false;
            this.cdvUnit2Code8.SearchSubItemIndex = 0;
            this.cdvUnit2Code8.SelectedDescIndex = -1;
            this.cdvUnit2Code8.SelectedSubItemIndex = -1;
            this.cdvUnit2Code8.SelectionStart = 0;
            this.cdvUnit2Code8.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code8.SmallImageList = null;
            this.cdvUnit2Code8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code8.TabIndex = 24;
            this.cdvUnit2Code8.TextBoxToolTipText = "";
            this.cdvUnit2Code8.TextBoxWidth = 100;
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
            this.cdvUnit2Code7.Location = new System.Drawing.Point(36, 181);
            this.cdvUnit2Code7.MaxLength = 10;
            this.cdvUnit2Code7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code7.Name = "cdvUnit2Code7";
            this.cdvUnit2Code7.ReadOnly = false;
            this.cdvUnit2Code7.SearchSubItemIndex = 0;
            this.cdvUnit2Code7.SelectedDescIndex = -1;
            this.cdvUnit2Code7.SelectedSubItemIndex = -1;
            this.cdvUnit2Code7.SelectionStart = 0;
            this.cdvUnit2Code7.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code7.SmallImageList = null;
            this.cdvUnit2Code7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code7.TabIndex = 21;
            this.cdvUnit2Code7.TextBoxToolTipText = "";
            this.cdvUnit2Code7.TextBoxWidth = 100;
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
            this.cdvUnit2Code6.Location = new System.Drawing.Point(36, 157);
            this.cdvUnit2Code6.MaxLength = 10;
            this.cdvUnit2Code6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code6.Name = "cdvUnit2Code6";
            this.cdvUnit2Code6.ReadOnly = false;
            this.cdvUnit2Code6.SearchSubItemIndex = 0;
            this.cdvUnit2Code6.SelectedDescIndex = -1;
            this.cdvUnit2Code6.SelectedSubItemIndex = -1;
            this.cdvUnit2Code6.SelectionStart = 0;
            this.cdvUnit2Code6.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code6.SmallImageList = null;
            this.cdvUnit2Code6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code6.TabIndex = 18;
            this.cdvUnit2Code6.TextBoxToolTipText = "";
            this.cdvUnit2Code6.TextBoxWidth = 100;
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
            this.cdvUnit2Code5.Location = new System.Drawing.Point(36, 133);
            this.cdvUnit2Code5.MaxLength = 10;
            this.cdvUnit2Code5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code5.Name = "cdvUnit2Code5";
            this.cdvUnit2Code5.ReadOnly = false;
            this.cdvUnit2Code5.SearchSubItemIndex = 0;
            this.cdvUnit2Code5.SelectedDescIndex = -1;
            this.cdvUnit2Code5.SelectedSubItemIndex = -1;
            this.cdvUnit2Code5.SelectionStart = 0;
            this.cdvUnit2Code5.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code5.SmallImageList = null;
            this.cdvUnit2Code5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code5.TabIndex = 15;
            this.cdvUnit2Code5.TextBoxToolTipText = "";
            this.cdvUnit2Code5.TextBoxWidth = 100;
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
            this.cdvUnit2Code4.Location = new System.Drawing.Point(36, 109);
            this.cdvUnit2Code4.MaxLength = 10;
            this.cdvUnit2Code4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code4.Name = "cdvUnit2Code4";
            this.cdvUnit2Code4.ReadOnly = false;
            this.cdvUnit2Code4.SearchSubItemIndex = 0;
            this.cdvUnit2Code4.SelectedDescIndex = -1;
            this.cdvUnit2Code4.SelectedSubItemIndex = -1;
            this.cdvUnit2Code4.SelectionStart = 0;
            this.cdvUnit2Code4.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code4.SmallImageList = null;
            this.cdvUnit2Code4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code4.TabIndex = 12;
            this.cdvUnit2Code4.TextBoxToolTipText = "";
            this.cdvUnit2Code4.TextBoxWidth = 100;
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
            this.cdvUnit2Code3.Location = new System.Drawing.Point(36, 85);
            this.cdvUnit2Code3.MaxLength = 10;
            this.cdvUnit2Code3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code3.Name = "cdvUnit2Code3";
            this.cdvUnit2Code3.ReadOnly = false;
            this.cdvUnit2Code3.SearchSubItemIndex = 0;
            this.cdvUnit2Code3.SelectedDescIndex = -1;
            this.cdvUnit2Code3.SelectedSubItemIndex = -1;
            this.cdvUnit2Code3.SelectionStart = 0;
            this.cdvUnit2Code3.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code3.SmallImageList = null;
            this.cdvUnit2Code3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code3.TabIndex = 9;
            this.cdvUnit2Code3.TextBoxToolTipText = "";
            this.cdvUnit2Code3.TextBoxWidth = 100;
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
            this.cdvUnit2Code2.Location = new System.Drawing.Point(36, 61);
            this.cdvUnit2Code2.MaxLength = 10;
            this.cdvUnit2Code2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code2.Name = "cdvUnit2Code2";
            this.cdvUnit2Code2.ReadOnly = false;
            this.cdvUnit2Code2.SearchSubItemIndex = 0;
            this.cdvUnit2Code2.SelectedDescIndex = -1;
            this.cdvUnit2Code2.SelectedSubItemIndex = -1;
            this.cdvUnit2Code2.SelectionStart = 0;
            this.cdvUnit2Code2.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code2.SmallImageList = null;
            this.cdvUnit2Code2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code2.TabIndex = 6;
            this.cdvUnit2Code2.TextBoxToolTipText = "";
            this.cdvUnit2Code2.TextBoxWidth = 100;
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
            this.cdvUnit2Code1.Location = new System.Drawing.Point(36, 37);
            this.cdvUnit2Code1.MaxLength = 10;
            this.cdvUnit2Code1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2Code1.Name = "cdvUnit2Code1";
            this.cdvUnit2Code1.ReadOnly = false;
            this.cdvUnit2Code1.SearchSubItemIndex = 0;
            this.cdvUnit2Code1.SelectedDescIndex = -1;
            this.cdvUnit2Code1.SelectedSubItemIndex = -1;
            this.cdvUnit2Code1.SelectionStart = 0;
            this.cdvUnit2Code1.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit2Code1.SmallImageList = null;
            this.cdvUnit2Code1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2Code1.TabIndex = 3;
            this.cdvUnit2Code1.TextBoxToolTipText = "";
            this.cdvUnit2Code1.TextBoxWidth = 100;
            this.cdvUnit2Code1.VisibleButton = true;
            this.cdvUnit2Code1.VisibleColumnHeader = false;
            this.cdvUnit2Code1.VisibleDescription = false;
            this.cdvUnit2Code1.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // lblB30
            // 
            this.lblB30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB30.Location = new System.Drawing.Point(12, 256);
            this.lblB30.Name = "lblB30";
            this.lblB30.Size = new System.Drawing.Size(17, 14);
            this.lblB30.TabIndex = 29;
            this.lblB30.Text = "10";
            // 
            // lblB29
            // 
            this.lblB29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB29.Location = new System.Drawing.Point(12, 232);
            this.lblB29.Name = "lblB29";
            this.lblB29.Size = new System.Drawing.Size(17, 14);
            this.lblB29.TabIndex = 26;
            this.lblB29.Text = "9";
            // 
            // lblB28
            // 
            this.lblB28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB28.Location = new System.Drawing.Point(12, 208);
            this.lblB28.Name = "lblB28";
            this.lblB28.Size = new System.Drawing.Size(17, 14);
            this.lblB28.TabIndex = 23;
            this.lblB28.Text = "8";
            // 
            // lblB27
            // 
            this.lblB27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB27.Location = new System.Drawing.Point(12, 184);
            this.lblB27.Name = "lblB27";
            this.lblB27.Size = new System.Drawing.Size(17, 14);
            this.lblB27.TabIndex = 20;
            this.lblB27.Text = "7";
            // 
            // lblB26
            // 
            this.lblB26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB26.Location = new System.Drawing.Point(12, 160);
            this.lblB26.Name = "lblB26";
            this.lblB26.Size = new System.Drawing.Size(17, 14);
            this.lblB26.TabIndex = 17;
            this.lblB26.Text = "6";
            // 
            // lblB25
            // 
            this.lblB25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB25.Location = new System.Drawing.Point(12, 136);
            this.lblB25.Name = "lblB25";
            this.lblB25.Size = new System.Drawing.Size(17, 14);
            this.lblB25.TabIndex = 14;
            this.lblB25.Text = "5";
            // 
            // lblB24
            // 
            this.lblB24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB24.Location = new System.Drawing.Point(12, 112);
            this.lblB24.Name = "lblB24";
            this.lblB24.Size = new System.Drawing.Size(17, 14);
            this.lblB24.TabIndex = 11;
            this.lblB24.Text = "4";
            // 
            // lblB23
            // 
            this.lblB23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB23.Location = new System.Drawing.Point(12, 88);
            this.lblB23.Name = "lblB23";
            this.lblB23.Size = new System.Drawing.Size(17, 14);
            this.lblB23.TabIndex = 8;
            this.lblB23.Text = "3";
            // 
            // lblB22
            // 
            this.lblB22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB22.Location = new System.Drawing.Point(12, 64);
            this.lblB22.Name = "lblB22";
            this.lblB22.Size = new System.Drawing.Size(17, 14);
            this.lblB22.TabIndex = 5;
            this.lblB22.Text = "2";
            // 
            // lblB21
            // 
            this.lblB21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblB21.Location = new System.Drawing.Point(12, 40);
            this.lblB21.Name = "lblB21";
            this.lblB21.Size = new System.Drawing.Size(17, 14);
            this.lblB21.TabIndex = 2;
            this.lblB21.Text = "1";
            // 
            // tbpUnit3
            // 
            this.tbpUnit3.Controls.Add(this.grpUnit3);
            this.tbpUnit3.Location = new System.Drawing.Point(4, 22);
            this.tbpUnit3.Name = "tbpUnit3";
            this.tbpUnit3.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUnit3.Size = new System.Drawing.Size(238, 294);
            this.tbpUnit3.TabIndex = 2;
            this.tbpUnit3.Text = "Unit 3";
            // 
            // grpUnit3
            // 
            this.grpUnit3.Controls.Add(this.txtUnit3Qty10);
            this.grpUnit3.Controls.Add(this.txtUnit3Qty9);
            this.grpUnit3.Controls.Add(this.txtUnit3Qty8);
            this.grpUnit3.Controls.Add(this.txtUnit3Qty7);
            this.grpUnit3.Controls.Add(this.txtUnit3Qty6);
            this.grpUnit3.Controls.Add(this.txtUnit3Qty5);
            this.grpUnit3.Controls.Add(this.txtUnit3Qty4);
            this.grpUnit3.Controls.Add(this.txtUnit3Qty3);
            this.grpUnit3.Controls.Add(this.txtUnit3Qty2);
            this.grpUnit3.Controls.Add(this.txtUnit3Qty1);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty);
            this.grpUnit3.Controls.Add(this.lblUnit3Code);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code10);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code9);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code8);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code7);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code6);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code5);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code4);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code3);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code2);
            this.grpUnit3.Controls.Add(this.cdvUnit3Code1);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty10);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty9);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty8);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty7);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty6);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty5);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty4);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty3);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty2);
            this.grpUnit3.Controls.Add(this.lblUnit3Qty1);
            this.grpUnit3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnit3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUnit3.Location = new System.Drawing.Point(3, 3);
            this.grpUnit3.Name = "grpUnit3";
            this.grpUnit3.Size = new System.Drawing.Size(232, 288);
            this.grpUnit3.TabIndex = 2;
            this.grpUnit3.TabStop = false;
            // 
            // txtUnit3Qty10
            // 
            this.txtUnit3Qty10.Location = new System.Drawing.Point(146, 253);
            this.txtUnit3Qty10.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty10.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty10.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty10.Name = "txtUnit3Qty10";
            this.txtUnit3Qty10.Nullable = true;
            this.txtUnit3Qty10.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty10.PromptChar = ' ';
            this.txtUnit3Qty10.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty10.TabIndex = 31;
            this.txtUnit3Qty10.Value = null;
            this.txtUnit3Qty10.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // txtUnit3Qty9
            // 
            this.txtUnit3Qty9.Location = new System.Drawing.Point(146, 229);
            this.txtUnit3Qty9.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty9.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty9.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty9.Name = "txtUnit3Qty9";
            this.txtUnit3Qty9.Nullable = true;
            this.txtUnit3Qty9.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty9.PromptChar = ' ';
            this.txtUnit3Qty9.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty9.TabIndex = 28;
            this.txtUnit3Qty9.Value = null;
            this.txtUnit3Qty9.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // txtUnit3Qty8
            // 
            this.txtUnit3Qty8.Location = new System.Drawing.Point(146, 205);
            this.txtUnit3Qty8.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty8.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty8.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty8.Name = "txtUnit3Qty8";
            this.txtUnit3Qty8.Nullable = true;
            this.txtUnit3Qty8.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty8.PromptChar = ' ';
            this.txtUnit3Qty8.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty8.TabIndex = 25;
            this.txtUnit3Qty8.Value = null;
            this.txtUnit3Qty8.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // txtUnit3Qty7
            // 
            this.txtUnit3Qty7.Location = new System.Drawing.Point(146, 181);
            this.txtUnit3Qty7.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty7.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty7.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty7.Name = "txtUnit3Qty7";
            this.txtUnit3Qty7.Nullable = true;
            this.txtUnit3Qty7.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty7.PromptChar = ' ';
            this.txtUnit3Qty7.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty7.TabIndex = 22;
            this.txtUnit3Qty7.Value = null;
            this.txtUnit3Qty7.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // txtUnit3Qty6
            // 
            this.txtUnit3Qty6.Location = new System.Drawing.Point(146, 157);
            this.txtUnit3Qty6.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty6.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty6.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty6.Name = "txtUnit3Qty6";
            this.txtUnit3Qty6.Nullable = true;
            this.txtUnit3Qty6.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty6.PromptChar = ' ';
            this.txtUnit3Qty6.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty6.TabIndex = 19;
            this.txtUnit3Qty6.Value = null;
            this.txtUnit3Qty6.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // txtUnit3Qty5
            // 
            this.txtUnit3Qty5.Location = new System.Drawing.Point(146, 133);
            this.txtUnit3Qty5.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty5.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty5.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty5.Name = "txtUnit3Qty5";
            this.txtUnit3Qty5.Nullable = true;
            this.txtUnit3Qty5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty5.PromptChar = ' ';
            this.txtUnit3Qty5.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty5.TabIndex = 16;
            this.txtUnit3Qty5.Value = null;
            this.txtUnit3Qty5.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // txtUnit3Qty4
            // 
            this.txtUnit3Qty4.Location = new System.Drawing.Point(146, 109);
            this.txtUnit3Qty4.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty4.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty4.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty4.Name = "txtUnit3Qty4";
            this.txtUnit3Qty4.Nullable = true;
            this.txtUnit3Qty4.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty4.PromptChar = ' ';
            this.txtUnit3Qty4.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty4.TabIndex = 13;
            this.txtUnit3Qty4.Value = null;
            this.txtUnit3Qty4.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // txtUnit3Qty3
            // 
            this.txtUnit3Qty3.Location = new System.Drawing.Point(146, 85);
            this.txtUnit3Qty3.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty3.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty3.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty3.Name = "txtUnit3Qty3";
            this.txtUnit3Qty3.Nullable = true;
            this.txtUnit3Qty3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty3.PromptChar = ' ';
            this.txtUnit3Qty3.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty3.TabIndex = 10;
            this.txtUnit3Qty3.Value = null;
            this.txtUnit3Qty3.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // txtUnit3Qty2
            // 
            this.txtUnit3Qty2.Location = new System.Drawing.Point(146, 61);
            this.txtUnit3Qty2.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty2.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty2.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty2.Name = "txtUnit3Qty2";
            this.txtUnit3Qty2.Nullable = true;
            this.txtUnit3Qty2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty2.PromptChar = ' ';
            this.txtUnit3Qty2.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty2.TabIndex = 7;
            this.txtUnit3Qty2.Value = null;
            this.txtUnit3Qty2.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // txtUnit3Qty1
            // 
            this.txtUnit3Qty1.Location = new System.Drawing.Point(146, 37);
            this.txtUnit3Qty1.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty1.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtUnit3Qty1.MaskInput = "+nnnnnnn";
            this.txtUnit3Qty1.Name = "txtUnit3Qty1";
            this.txtUnit3Qty1.Nullable = true;
            this.txtUnit3Qty1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtUnit3Qty1.PromptChar = ' ';
            this.txtUnit3Qty1.Size = new System.Drawing.Size(77, 20);
            this.txtUnit3Qty1.TabIndex = 4;
            this.txtUnit3Qty1.Value = null;
            this.txtUnit3Qty1.AfterExitEditMode += new System.EventHandler(this.txtUnit3Qty_AfterExitEditMode);
            // 
            // lblUnit3Qty
            // 
            this.lblUnit3Qty.AutoSize = true;
            this.lblUnit3Qty.Location = new System.Drawing.Point(148, 17);
            this.lblUnit3Qty.Name = "lblUnit3Qty";
            this.lblUnit3Qty.Size = new System.Drawing.Size(23, 13);
            this.lblUnit3Qty.TabIndex = 1;
            this.lblUnit3Qty.Text = "Qty";
            // 
            // lblUnit3Code
            // 
            this.lblUnit3Code.AutoSize = true;
            this.lblUnit3Code.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Code.Location = new System.Drawing.Point(38, 17);
            this.lblUnit3Code.Name = "lblUnit3Code";
            this.lblUnit3Code.Size = new System.Drawing.Size(72, 13);
            this.lblUnit3Code.TabIndex = 0;
            this.lblUnit3Code.Text = "Reason Code";
            // 
            // cdvUnit3Code10
            // 
            this.cdvUnit3Code10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code10.BtnToolTipText = "";
            this.cdvUnit3Code10.DescText = "";
            this.cdvUnit3Code10.DisplaySubItemIndex = -1;
            this.cdvUnit3Code10.DisplayText = "";
            this.cdvUnit3Code10.Focusing = null;
            this.cdvUnit3Code10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code10.Index = 0;
            this.cdvUnit3Code10.IsViewBtnImage = false;
            this.cdvUnit3Code10.Location = new System.Drawing.Point(36, 253);
            this.cdvUnit3Code10.MaxLength = 10;
            this.cdvUnit3Code10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code10.Name = "cdvUnit3Code10";
            this.cdvUnit3Code10.ReadOnly = false;
            this.cdvUnit3Code10.SearchSubItemIndex = 0;
            this.cdvUnit3Code10.SelectedDescIndex = -1;
            this.cdvUnit3Code10.SelectedSubItemIndex = -1;
            this.cdvUnit3Code10.SelectionStart = 0;
            this.cdvUnit3Code10.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code10.SmallImageList = null;
            this.cdvUnit3Code10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code10.TabIndex = 30;
            this.cdvUnit3Code10.TextBoxToolTipText = "";
            this.cdvUnit3Code10.TextBoxWidth = 100;
            this.cdvUnit3Code10.VisibleButton = true;
            this.cdvUnit3Code10.VisibleColumnHeader = false;
            this.cdvUnit3Code10.VisibleDescription = false;
            this.cdvUnit3Code10.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit3Code9
            // 
            this.cdvUnit3Code9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code9.BtnToolTipText = "";
            this.cdvUnit3Code9.DescText = "";
            this.cdvUnit3Code9.DisplaySubItemIndex = -1;
            this.cdvUnit3Code9.DisplayText = "";
            this.cdvUnit3Code9.Focusing = null;
            this.cdvUnit3Code9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code9.Index = 0;
            this.cdvUnit3Code9.IsViewBtnImage = false;
            this.cdvUnit3Code9.Location = new System.Drawing.Point(36, 229);
            this.cdvUnit3Code9.MaxLength = 10;
            this.cdvUnit3Code9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code9.Name = "cdvUnit3Code9";
            this.cdvUnit3Code9.ReadOnly = false;
            this.cdvUnit3Code9.SearchSubItemIndex = 0;
            this.cdvUnit3Code9.SelectedDescIndex = -1;
            this.cdvUnit3Code9.SelectedSubItemIndex = -1;
            this.cdvUnit3Code9.SelectionStart = 0;
            this.cdvUnit3Code9.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code9.SmallImageList = null;
            this.cdvUnit3Code9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code9.TabIndex = 27;
            this.cdvUnit3Code9.TextBoxToolTipText = "";
            this.cdvUnit3Code9.TextBoxWidth = 100;
            this.cdvUnit3Code9.VisibleButton = true;
            this.cdvUnit3Code9.VisibleColumnHeader = false;
            this.cdvUnit3Code9.VisibleDescription = false;
            this.cdvUnit3Code9.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit3Code8
            // 
            this.cdvUnit3Code8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code8.BtnToolTipText = "";
            this.cdvUnit3Code8.DescText = "";
            this.cdvUnit3Code8.DisplaySubItemIndex = -1;
            this.cdvUnit3Code8.DisplayText = "";
            this.cdvUnit3Code8.Focusing = null;
            this.cdvUnit3Code8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code8.Index = 0;
            this.cdvUnit3Code8.IsViewBtnImage = false;
            this.cdvUnit3Code8.Location = new System.Drawing.Point(36, 205);
            this.cdvUnit3Code8.MaxLength = 10;
            this.cdvUnit3Code8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code8.Name = "cdvUnit3Code8";
            this.cdvUnit3Code8.ReadOnly = false;
            this.cdvUnit3Code8.SearchSubItemIndex = 0;
            this.cdvUnit3Code8.SelectedDescIndex = -1;
            this.cdvUnit3Code8.SelectedSubItemIndex = -1;
            this.cdvUnit3Code8.SelectionStart = 0;
            this.cdvUnit3Code8.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code8.SmallImageList = null;
            this.cdvUnit3Code8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code8.TabIndex = 24;
            this.cdvUnit3Code8.TextBoxToolTipText = "";
            this.cdvUnit3Code8.TextBoxWidth = 100;
            this.cdvUnit3Code8.VisibleButton = true;
            this.cdvUnit3Code8.VisibleColumnHeader = false;
            this.cdvUnit3Code8.VisibleDescription = false;
            this.cdvUnit3Code8.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit3Code7
            // 
            this.cdvUnit3Code7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code7.BtnToolTipText = "";
            this.cdvUnit3Code7.DescText = "";
            this.cdvUnit3Code7.DisplaySubItemIndex = -1;
            this.cdvUnit3Code7.DisplayText = "";
            this.cdvUnit3Code7.Focusing = null;
            this.cdvUnit3Code7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code7.Index = 0;
            this.cdvUnit3Code7.IsViewBtnImage = false;
            this.cdvUnit3Code7.Location = new System.Drawing.Point(36, 181);
            this.cdvUnit3Code7.MaxLength = 10;
            this.cdvUnit3Code7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code7.Name = "cdvUnit3Code7";
            this.cdvUnit3Code7.ReadOnly = false;
            this.cdvUnit3Code7.SearchSubItemIndex = 0;
            this.cdvUnit3Code7.SelectedDescIndex = -1;
            this.cdvUnit3Code7.SelectedSubItemIndex = -1;
            this.cdvUnit3Code7.SelectionStart = 0;
            this.cdvUnit3Code7.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code7.SmallImageList = null;
            this.cdvUnit3Code7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code7.TabIndex = 21;
            this.cdvUnit3Code7.TextBoxToolTipText = "";
            this.cdvUnit3Code7.TextBoxWidth = 100;
            this.cdvUnit3Code7.VisibleButton = true;
            this.cdvUnit3Code7.VisibleColumnHeader = false;
            this.cdvUnit3Code7.VisibleDescription = false;
            this.cdvUnit3Code7.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit3Code6
            // 
            this.cdvUnit3Code6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code6.BtnToolTipText = "";
            this.cdvUnit3Code6.DescText = "";
            this.cdvUnit3Code6.DisplaySubItemIndex = -1;
            this.cdvUnit3Code6.DisplayText = "";
            this.cdvUnit3Code6.Focusing = null;
            this.cdvUnit3Code6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code6.Index = 0;
            this.cdvUnit3Code6.IsViewBtnImage = false;
            this.cdvUnit3Code6.Location = new System.Drawing.Point(36, 157);
            this.cdvUnit3Code6.MaxLength = 10;
            this.cdvUnit3Code6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code6.Name = "cdvUnit3Code6";
            this.cdvUnit3Code6.ReadOnly = false;
            this.cdvUnit3Code6.SearchSubItemIndex = 0;
            this.cdvUnit3Code6.SelectedDescIndex = -1;
            this.cdvUnit3Code6.SelectedSubItemIndex = -1;
            this.cdvUnit3Code6.SelectionStart = 0;
            this.cdvUnit3Code6.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code6.SmallImageList = null;
            this.cdvUnit3Code6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code6.TabIndex = 18;
            this.cdvUnit3Code6.TextBoxToolTipText = "";
            this.cdvUnit3Code6.TextBoxWidth = 100;
            this.cdvUnit3Code6.VisibleButton = true;
            this.cdvUnit3Code6.VisibleColumnHeader = false;
            this.cdvUnit3Code6.VisibleDescription = false;
            this.cdvUnit3Code6.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit3Code5
            // 
            this.cdvUnit3Code5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code5.BtnToolTipText = "";
            this.cdvUnit3Code5.DescText = "";
            this.cdvUnit3Code5.DisplaySubItemIndex = -1;
            this.cdvUnit3Code5.DisplayText = "";
            this.cdvUnit3Code5.Focusing = null;
            this.cdvUnit3Code5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code5.Index = 0;
            this.cdvUnit3Code5.IsViewBtnImage = false;
            this.cdvUnit3Code5.Location = new System.Drawing.Point(36, 133);
            this.cdvUnit3Code5.MaxLength = 10;
            this.cdvUnit3Code5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code5.Name = "cdvUnit3Code5";
            this.cdvUnit3Code5.ReadOnly = false;
            this.cdvUnit3Code5.SearchSubItemIndex = 0;
            this.cdvUnit3Code5.SelectedDescIndex = -1;
            this.cdvUnit3Code5.SelectedSubItemIndex = -1;
            this.cdvUnit3Code5.SelectionStart = 0;
            this.cdvUnit3Code5.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code5.SmallImageList = null;
            this.cdvUnit3Code5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code5.TabIndex = 15;
            this.cdvUnit3Code5.TextBoxToolTipText = "";
            this.cdvUnit3Code5.TextBoxWidth = 100;
            this.cdvUnit3Code5.VisibleButton = true;
            this.cdvUnit3Code5.VisibleColumnHeader = false;
            this.cdvUnit3Code5.VisibleDescription = false;
            this.cdvUnit3Code5.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit3Code4
            // 
            this.cdvUnit3Code4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code4.BtnToolTipText = "";
            this.cdvUnit3Code4.DescText = "";
            this.cdvUnit3Code4.DisplaySubItemIndex = -1;
            this.cdvUnit3Code4.DisplayText = "";
            this.cdvUnit3Code4.Focusing = null;
            this.cdvUnit3Code4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code4.Index = 0;
            this.cdvUnit3Code4.IsViewBtnImage = false;
            this.cdvUnit3Code4.Location = new System.Drawing.Point(36, 109);
            this.cdvUnit3Code4.MaxLength = 10;
            this.cdvUnit3Code4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code4.Name = "cdvUnit3Code4";
            this.cdvUnit3Code4.ReadOnly = false;
            this.cdvUnit3Code4.SearchSubItemIndex = 0;
            this.cdvUnit3Code4.SelectedDescIndex = -1;
            this.cdvUnit3Code4.SelectedSubItemIndex = -1;
            this.cdvUnit3Code4.SelectionStart = 0;
            this.cdvUnit3Code4.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code4.SmallImageList = null;
            this.cdvUnit3Code4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code4.TabIndex = 12;
            this.cdvUnit3Code4.TextBoxToolTipText = "";
            this.cdvUnit3Code4.TextBoxWidth = 100;
            this.cdvUnit3Code4.VisibleButton = true;
            this.cdvUnit3Code4.VisibleColumnHeader = false;
            this.cdvUnit3Code4.VisibleDescription = false;
            this.cdvUnit3Code4.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit3Code3
            // 
            this.cdvUnit3Code3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code3.BtnToolTipText = "";
            this.cdvUnit3Code3.DescText = "";
            this.cdvUnit3Code3.DisplaySubItemIndex = -1;
            this.cdvUnit3Code3.DisplayText = "";
            this.cdvUnit3Code3.Focusing = null;
            this.cdvUnit3Code3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code3.Index = 0;
            this.cdvUnit3Code3.IsViewBtnImage = false;
            this.cdvUnit3Code3.Location = new System.Drawing.Point(36, 85);
            this.cdvUnit3Code3.MaxLength = 10;
            this.cdvUnit3Code3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code3.Name = "cdvUnit3Code3";
            this.cdvUnit3Code3.ReadOnly = false;
            this.cdvUnit3Code3.SearchSubItemIndex = 0;
            this.cdvUnit3Code3.SelectedDescIndex = -1;
            this.cdvUnit3Code3.SelectedSubItemIndex = -1;
            this.cdvUnit3Code3.SelectionStart = 0;
            this.cdvUnit3Code3.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code3.SmallImageList = null;
            this.cdvUnit3Code3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code3.TabIndex = 9;
            this.cdvUnit3Code3.TextBoxToolTipText = "";
            this.cdvUnit3Code3.TextBoxWidth = 100;
            this.cdvUnit3Code3.VisibleButton = true;
            this.cdvUnit3Code3.VisibleColumnHeader = false;
            this.cdvUnit3Code3.VisibleDescription = false;
            this.cdvUnit3Code3.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit3Code2
            // 
            this.cdvUnit3Code2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code2.BtnToolTipText = "";
            this.cdvUnit3Code2.DescText = "";
            this.cdvUnit3Code2.DisplaySubItemIndex = -1;
            this.cdvUnit3Code2.DisplayText = "";
            this.cdvUnit3Code2.Focusing = null;
            this.cdvUnit3Code2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code2.Index = 0;
            this.cdvUnit3Code2.IsViewBtnImage = false;
            this.cdvUnit3Code2.Location = new System.Drawing.Point(36, 61);
            this.cdvUnit3Code2.MaxLength = 10;
            this.cdvUnit3Code2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code2.Name = "cdvUnit3Code2";
            this.cdvUnit3Code2.ReadOnly = false;
            this.cdvUnit3Code2.SearchSubItemIndex = 0;
            this.cdvUnit3Code2.SelectedDescIndex = -1;
            this.cdvUnit3Code2.SelectedSubItemIndex = -1;
            this.cdvUnit3Code2.SelectionStart = 0;
            this.cdvUnit3Code2.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code2.SmallImageList = null;
            this.cdvUnit3Code2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code2.TabIndex = 6;
            this.cdvUnit3Code2.TextBoxToolTipText = "";
            this.cdvUnit3Code2.TextBoxWidth = 100;
            this.cdvUnit3Code2.VisibleButton = true;
            this.cdvUnit3Code2.VisibleColumnHeader = false;
            this.cdvUnit3Code2.VisibleDescription = false;
            this.cdvUnit3Code2.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // cdvUnit3Code1
            // 
            this.cdvUnit3Code1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3Code1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3Code1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3Code1.BtnToolTipText = "";
            this.cdvUnit3Code1.DescText = "";
            this.cdvUnit3Code1.DisplaySubItemIndex = -1;
            this.cdvUnit3Code1.DisplayText = "";
            this.cdvUnit3Code1.Focusing = null;
            this.cdvUnit3Code1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3Code1.Index = 0;
            this.cdvUnit3Code1.IsViewBtnImage = false;
            this.cdvUnit3Code1.Location = new System.Drawing.Point(36, 37);
            this.cdvUnit3Code1.MaxLength = 10;
            this.cdvUnit3Code1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3Code1.Name = "cdvUnit3Code1";
            this.cdvUnit3Code1.ReadOnly = false;
            this.cdvUnit3Code1.SearchSubItemIndex = 0;
            this.cdvUnit3Code1.SelectedDescIndex = -1;
            this.cdvUnit3Code1.SelectedSubItemIndex = -1;
            this.cdvUnit3Code1.SelectionStart = 0;
            this.cdvUnit3Code1.Size = new System.Drawing.Size(100, 20);
            this.cdvUnit3Code1.SmallImageList = null;
            this.cdvUnit3Code1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3Code1.TabIndex = 3;
            this.cdvUnit3Code1.TextBoxToolTipText = "";
            this.cdvUnit3Code1.TextBoxWidth = 100;
            this.cdvUnit3Code1.VisibleButton = true;
            this.cdvUnit3Code1.VisibleColumnHeader = false;
            this.cdvUnit3Code1.VisibleDescription = false;
            this.cdvUnit3Code1.ButtonPress += new System.EventHandler(this.cdvUnitCode_ButtonPress);
            // 
            // lblUnit3Qty10
            // 
            this.lblUnit3Qty10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty10.Location = new System.Drawing.Point(12, 256);
            this.lblUnit3Qty10.Name = "lblUnit3Qty10";
            this.lblUnit3Qty10.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty10.TabIndex = 29;
            this.lblUnit3Qty10.Text = "10";
            // 
            // lblUnit3Qty9
            // 
            this.lblUnit3Qty9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty9.Location = new System.Drawing.Point(12, 232);
            this.lblUnit3Qty9.Name = "lblUnit3Qty9";
            this.lblUnit3Qty9.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty9.TabIndex = 26;
            this.lblUnit3Qty9.Text = "9";
            // 
            // lblUnit3Qty8
            // 
            this.lblUnit3Qty8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty8.Location = new System.Drawing.Point(12, 208);
            this.lblUnit3Qty8.Name = "lblUnit3Qty8";
            this.lblUnit3Qty8.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty8.TabIndex = 23;
            this.lblUnit3Qty8.Text = "8";
            // 
            // lblUnit3Qty7
            // 
            this.lblUnit3Qty7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty7.Location = new System.Drawing.Point(12, 184);
            this.lblUnit3Qty7.Name = "lblUnit3Qty7";
            this.lblUnit3Qty7.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty7.TabIndex = 20;
            this.lblUnit3Qty7.Text = "7";
            // 
            // lblUnit3Qty6
            // 
            this.lblUnit3Qty6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty6.Location = new System.Drawing.Point(12, 160);
            this.lblUnit3Qty6.Name = "lblUnit3Qty6";
            this.lblUnit3Qty6.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty6.TabIndex = 17;
            this.lblUnit3Qty6.Text = "6";
            // 
            // lblUnit3Qty5
            // 
            this.lblUnit3Qty5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty5.Location = new System.Drawing.Point(12, 136);
            this.lblUnit3Qty5.Name = "lblUnit3Qty5";
            this.lblUnit3Qty5.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty5.TabIndex = 14;
            this.lblUnit3Qty5.Text = "5";
            // 
            // lblUnit3Qty4
            // 
            this.lblUnit3Qty4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty4.Location = new System.Drawing.Point(12, 112);
            this.lblUnit3Qty4.Name = "lblUnit3Qty4";
            this.lblUnit3Qty4.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty4.TabIndex = 11;
            this.lblUnit3Qty4.Text = "4";
            // 
            // lblUnit3Qty3
            // 
            this.lblUnit3Qty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty3.Location = new System.Drawing.Point(12, 88);
            this.lblUnit3Qty3.Name = "lblUnit3Qty3";
            this.lblUnit3Qty3.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty3.TabIndex = 8;
            this.lblUnit3Qty3.Text = "3";
            // 
            // lblUnit3Qty2
            // 
            this.lblUnit3Qty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty2.Location = new System.Drawing.Point(12, 64);
            this.lblUnit3Qty2.Name = "lblUnit3Qty2";
            this.lblUnit3Qty2.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty2.TabIndex = 5;
            this.lblUnit3Qty2.Text = "2";
            // 
            // lblUnit3Qty1
            // 
            this.lblUnit3Qty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3Qty1.Location = new System.Drawing.Point(12, 40);
            this.lblUnit3Qty1.Name = "lblUnit3Qty1";
            this.lblUnit3Qty1.Size = new System.Drawing.Size(17, 14);
            this.lblUnit3Qty1.TabIndex = 2;
            this.lblUnit3Qty1.Text = "1";
            // 
            // tbpLossReason
            // 
            this.tbpLossReason.BackColor = System.Drawing.Color.Transparent;
            this.tbpLossReason.Controls.Add(this.grpCodeInfo);
            this.tbpLossReason.Controls.Add(this.pnlOption);
            this.tbpLossReason.Location = new System.Drawing.Point(4, 22);
            this.tbpLossReason.Name = "tbpLossReason";
            this.tbpLossReason.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLossReason.Size = new System.Drawing.Size(238, 294);
            this.tbpLossReason.TabIndex = 1;
            this.tbpLossReason.Text = "Multi Reason";
            // 
            // grpCodeInfo
            // 
            this.grpCodeInfo.Controls.Add(this.spdCodeList);
            this.grpCodeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCodeInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCodeInfo.Location = new System.Drawing.Point(3, 27);
            this.grpCodeInfo.Name = "grpCodeInfo";
            this.grpCodeInfo.Size = new System.Drawing.Size(232, 264);
            this.grpCodeInfo.TabIndex = 2;
            this.grpCodeInfo.TabStop = false;
            // 
            // spdCodeList
            // 
            this.spdCodeList.AccessibleDescription = "spdCodeList, Sheet1, Row 0, Column 0, ";
            this.spdCodeList.BackColor = System.Drawing.SystemColors.Control;
            this.spdCodeList.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdCodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCodeList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCodeList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCodeList.HorizontalScrollBar.Name = "";
            this.spdCodeList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdCodeList.HorizontalScrollBar.TabIndex = 2;
            this.spdCodeList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCodeList.Location = new System.Drawing.Point(3, 16);
            this.spdCodeList.Name = "spdCodeList";
            this.spdCodeList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCodeList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCodeList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCodeList_Sheet1});
            this.spdCodeList.Size = new System.Drawing.Size(226, 245);
            this.spdCodeList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCodeList.TabIndex = 3;
            this.spdCodeList.TabStop = false;
            this.spdCodeList.TextTipDelay = 200;
            this.spdCodeList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCodeList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCodeList.VerticalScrollBar.Name = "";
            this.spdCodeList.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdCodeList.VerticalScrollBar.TabIndex = 3;
            this.spdCodeList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCodeList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCodeList_ButtonClicked);
            // 
            // spdCodeList_Sheet1
            // 
            this.spdCodeList_Sheet1.Reset();
            spdCodeList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCodeList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCodeList_Sheet1.ColumnCount = 2;
            spdCodeList_Sheet1.RowCount = 5;
            this.spdCodeList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCodeList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCodeList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCodeList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCodeList_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdCodeList_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCodeList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Reason Code";
            this.spdCodeList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCodeList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCodeList_Sheet1.ColumnHeader.Rows.Get(0).Height = 25F;
            this.spdCodeList_Sheet1.Columns.Get(0).CellType = textCellType2;
            this.spdCodeList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCodeList_Sheet1.Columns.Get(0).Label = "Reason Code";
            this.spdCodeList_Sheet1.Columns.Get(0).Locked = true;
            this.spdCodeList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCodeList_Sheet1.Columns.Get(0).Width = 150F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdCodeList_Sheet1.Columns.Get(1).CellType = buttonCellType3;
            this.spdCodeList_Sheet1.Columns.Get(1).Width = 21F;
            this.spdCodeList_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdCodeList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCodeList_Sheet1.RowHeader.Columns.Get(0).Width = 30F;
            this.spdCodeList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCodeList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCodeList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCodeList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCodeList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlOption
            // 
            this.pnlOption.Controls.Add(this.btnApply);
            this.pnlOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOption.Location = new System.Drawing.Point(3, 3);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Size = new System.Drawing.Size(232, 24);
            this.pnlOption.TabIndex = 3;
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApply.Location = new System.Drawing.Point(3, 1);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(225, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply reason code to all sublot";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pnlUnitTop
            // 
            this.pnlUnitTop.Controls.Add(this.grpQty);
            this.pnlUnitTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUnitTop.Location = new System.Drawing.Point(0, 0);
            this.pnlUnitTop.Name = "pnlUnitTop";
            this.pnlUnitTop.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlUnitTop.Size = new System.Drawing.Size(728, 94);
            this.pnlUnitTop.TabIndex = 1;
            // 
            // grpQty
            // 
            this.grpQty.Controls.Add(this.txtLossQty3);
            this.grpQty.Controls.Add(this.lblLossQty3);
            this.grpQty.Controls.Add(this.txtOutQty3);
            this.grpQty.Controls.Add(this.lblOutQty3);
            this.grpQty.Controls.Add(this.txtQty3);
            this.grpQty.Controls.Add(this.lblQty3);
            this.grpQty.Controls.Add(this.txtLossQty2);
            this.grpQty.Controls.Add(this.txtLossQty1);
            this.grpQty.Controls.Add(this.lblLossQty2);
            this.grpQty.Controls.Add(this.lblLossQty1);
            this.grpQty.Controls.Add(this.txtOutQty2);
            this.grpQty.Controls.Add(this.txtOutQty1);
            this.grpQty.Controls.Add(this.txtQty2);
            this.grpQty.Controls.Add(this.txtQty1);
            this.grpQty.Controls.Add(this.lblOutQty2);
            this.grpQty.Controls.Add(this.lblOutQty1);
            this.grpQty.Controls.Add(this.lblQty2);
            this.grpQty.Controls.Add(this.lblQty1);
            this.grpQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpQty.Location = new System.Drawing.Point(3, 3);
            this.grpQty.Name = "grpQty";
            this.grpQty.Size = new System.Drawing.Size(722, 91);
            this.grpQty.TabIndex = 0;
            this.grpQty.TabStop = false;
            // 
            // txtLossQty3
            // 
            this.txtLossQty3.Location = new System.Drawing.Point(591, 64);
            this.txtLossQty3.MaxLength = 11;
            this.txtLossQty3.Name = "txtLossQty3";
            this.txtLossQty3.ReadOnly = true;
            this.txtLossQty3.Size = new System.Drawing.Size(115, 20);
            this.txtLossQty3.TabIndex = 21;
            this.txtLossQty3.TabStop = false;
            // 
            // lblLossQty3
            // 
            this.lblLossQty3.AutoSize = true;
            this.lblLossQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLossQty3.Location = new System.Drawing.Point(483, 67);
            this.lblLossQty3.Name = "lblLossQty3";
            this.lblLossQty3.Size = new System.Drawing.Size(80, 13);
            this.lblLossQty3.TabIndex = 20;
            this.lblLossQty3.Text = "Changing Qty 3";
            // 
            // txtOutQty3
            // 
            this.txtOutQty3.Location = new System.Drawing.Point(330, 64);
            this.txtOutQty3.MaxLength = 11;
            this.txtOutQty3.Name = "txtOutQty3";
            this.txtOutQty3.ReadOnly = true;
            this.txtOutQty3.Size = new System.Drawing.Size(115, 20);
            this.txtOutQty3.TabIndex = 19;
            this.txtOutQty3.TabStop = false;
            this.txtOutQty3.TextChanged += new System.EventHandler(this.txtOutQty3_TextChanged);
            // 
            // lblOutQty3
            // 
            this.lblOutQty3.AutoSize = true;
            this.lblOutQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty3.Location = new System.Drawing.Point(266, 67);
            this.lblOutQty3.Name = "lblOutQty3";
            this.lblOutQty3.Size = new System.Drawing.Size(52, 13);
            this.lblOutQty3.TabIndex = 18;
            this.lblOutQty3.Text = "Out Qty 3";
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(100, 64);
            this.txtQty3.MaxLength = 11;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(115, 20);
            this.txtQty3.TabIndex = 17;
            this.txtQty3.TabStop = false;
            // 
            // lblQty3
            // 
            this.lblQty3.AutoSize = true;
            this.lblQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty3.Location = new System.Drawing.Point(37, 67);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(32, 13);
            this.lblQty3.TabIndex = 16;
            this.lblQty3.Text = "Qty 3";
            // 
            // txtLossQty2
            // 
            this.txtLossQty2.Location = new System.Drawing.Point(591, 40);
            this.txtLossQty2.MaxLength = 11;
            this.txtLossQty2.Name = "txtLossQty2";
            this.txtLossQty2.ReadOnly = true;
            this.txtLossQty2.Size = new System.Drawing.Size(115, 20);
            this.txtLossQty2.TabIndex = 15;
            this.txtLossQty2.TabStop = false;
            // 
            // txtLossQty1
            // 
            this.txtLossQty1.Location = new System.Drawing.Point(591, 16);
            this.txtLossQty1.MaxLength = 11;
            this.txtLossQty1.Name = "txtLossQty1";
            this.txtLossQty1.ReadOnly = true;
            this.txtLossQty1.Size = new System.Drawing.Size(115, 20);
            this.txtLossQty1.TabIndex = 13;
            this.txtLossQty1.TabStop = false;
            // 
            // lblLossQty2
            // 
            this.lblLossQty2.AutoSize = true;
            this.lblLossQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLossQty2.Location = new System.Drawing.Point(483, 42);
            this.lblLossQty2.Name = "lblLossQty2";
            this.lblLossQty2.Size = new System.Drawing.Size(80, 13);
            this.lblLossQty2.TabIndex = 14;
            this.lblLossQty2.Text = "Changing Qty 2";
            // 
            // lblLossQty1
            // 
            this.lblLossQty1.AutoSize = true;
            this.lblLossQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLossQty1.Location = new System.Drawing.Point(483, 18);
            this.lblLossQty1.Name = "lblLossQty1";
            this.lblLossQty1.Size = new System.Drawing.Size(80, 13);
            this.lblLossQty1.TabIndex = 12;
            this.lblLossQty1.Text = "Changing Qty 1";
            // 
            // txtOutQty2
            // 
            this.txtOutQty2.Location = new System.Drawing.Point(330, 40);
            this.txtOutQty2.MaxLength = 11;
            this.txtOutQty2.Name = "txtOutQty2";
            this.txtOutQty2.ReadOnly = true;
            this.txtOutQty2.Size = new System.Drawing.Size(115, 20);
            this.txtOutQty2.TabIndex = 9;
            this.txtOutQty2.TabStop = false;
            this.txtOutQty2.TextChanged += new System.EventHandler(this.txtOutQty2_TextChanged);
            // 
            // txtOutQty1
            // 
            this.txtOutQty1.Location = new System.Drawing.Point(330, 16);
            this.txtOutQty1.MaxLength = 11;
            this.txtOutQty1.Name = "txtOutQty1";
            this.txtOutQty1.ReadOnly = true;
            this.txtOutQty1.Size = new System.Drawing.Size(115, 20);
            this.txtOutQty1.TabIndex = 7;
            this.txtOutQty1.TabStop = false;
            this.txtOutQty1.TextChanged += new System.EventHandler(this.txtOutQty1_TextChanged);
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(100, 40);
            this.txtQty2.MaxLength = 11;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(115, 20);
            this.txtQty2.TabIndex = 3;
            this.txtQty2.TabStop = false;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(100, 16);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(115, 20);
            this.txtQty1.TabIndex = 1;
            this.txtQty1.TabStop = false;
            // 
            // lblOutQty2
            // 
            this.lblOutQty2.AutoSize = true;
            this.lblOutQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty2.Location = new System.Drawing.Point(266, 43);
            this.lblOutQty2.Name = "lblOutQty2";
            this.lblOutQty2.Size = new System.Drawing.Size(52, 13);
            this.lblOutQty2.TabIndex = 8;
            this.lblOutQty2.Text = "Out Qty 2";
            // 
            // lblOutQty1
            // 
            this.lblOutQty1.AutoSize = true;
            this.lblOutQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty1.Location = new System.Drawing.Point(266, 19);
            this.lblOutQty1.Name = "lblOutQty1";
            this.lblOutQty1.Size = new System.Drawing.Size(52, 13);
            this.lblOutQty1.TabIndex = 6;
            this.lblOutQty1.Text = "Out Qty 1";
            // 
            // lblQty2
            // 
            this.lblQty2.AutoSize = true;
            this.lblQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty2.Location = new System.Drawing.Point(37, 43);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(32, 13);
            this.lblQty2.TabIndex = 2;
            this.lblQty2.Text = "Qty 2";
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Location = new System.Drawing.Point(37, 19);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(32, 13);
            this.lblQty1.TabIndex = 0;
            this.lblQty1.Text = "Qty 1";
            // 
            // cdvLossCode
            // 
            this.cdvLossCode.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvLossCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLossCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLossCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvLossCode.Location = new System.Drawing.Point(190, 17);
            this.cdvLossCode.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLossCode.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLossCode.Name = "MCSSCodeView";
            this.cdvLossCode.Size = new System.Drawing.Size(20, 20);
            this.cdvLossCode.SmallImageList = null;
            this.cdvLossCode.TabIndex = 0;
            this.cdvLossCode.TabStop = false;
            this.cdvLossCode.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvLossCode.Visible = false;
            this.cdvLossCode.VisibleColumnHeader = false;
            this.cdvLossCode.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvLossCode_SelectedItemChanged);
            // 
            // cdvGrade
            // 
            this.cdvGrade.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvGrade.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrade.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvGrade.Location = new System.Drawing.Point(312, 17);
            this.cdvGrade.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrade.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrade.Name = "cdvGrade";
            this.cdvGrade.Size = new System.Drawing.Size(20, 20);
            this.cdvGrade.SmallImageList = null;
            this.cdvGrade.TabIndex = 0;
            this.cdvGrade.TabStop = false;
            this.cdvGrade.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvGrade.Visible = false;
            this.cdvGrade.VisibleColumnHeader = false;
            this.cdvGrade.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvGrade_SelectedItemChanged);
            // 
            // frmWIPTranLossLotExt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranLossLotExt";
            this.Text = "Loss Extension";
            this.Activated += new System.EventHandler(this.frmWIPTranLossLot_Activated);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.tbpInfo.ResumeLayout(false);
            this.pnlUnitMid.ResumeLayout(false);
            this.grpUnit1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdSublotLoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSublotLoss_Sheet1)).EndInit();
            this.tabCode.ResumeLayout(false);
            this.tbpUnit2.ResumeLayout(false);
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
            this.tbpUnit3.ResumeLayout(false);
            this.grpUnit3.ResumeLayout(false);
            this.grpUnit3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit3Qty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3Code1)).EndInit();
            this.tbpLossReason.ResumeLayout(false);
            this.grpCodeInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCodeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCodeList_Sheet1)).EndInit();
            this.pnlOption.ResumeLayout(false);
            this.pnlUnitTop.ResumeLayout(false);
            this.grpQty.ResumeLayout(false);
            this.grpQty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLossCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrade)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private bool b_load_sublot_list_flag;
        private string s_loss_table = "";
        private FarPoint.Win.Spread.FpSpread lspd_table;

        private struct LossList
        {
            public string loss_code;
            public int qty;
        }

        private int i_loss_code_count = 0;
        private LossList[] t_loss_unit1 = new LossList[11];

        private struct CodeListBySublot
        {
            public string sublot_id;
            public ArrayList codes;
        }
        private ArrayList t_code_list_by_sublot;
        private bool b_exist_sublot_unit2;
        private bool b_exist_sublot_unit3;

        #endregion
        
        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            int i;

            MPCF.FieldClear(this, txtLotID);
            for (i = 0; i < t_code_list_by_sublot.Count; i++)
            {
                ((CodeListBySublot)t_code_list_by_sublot[i]).codes.Clear();
            }
            t_code_list_by_sublot.Clear();

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (MPGO.ProcessZeroQtyLot() == true)
                chkNoAutoTermLot.Checked = true;

            s_loss_table = "";
            if (View_Operation() == false) return false;
            BASLIST.ViewGCMDataList(cdvLossCode.GetListView, '1', s_loss_table);
            cdvLossCode.InsertEmptyRow(0, 1);

#if _CRR
            cdvCrrID.Init();
            cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            if (RASLIST.ViewCarrierList(cdvCrrID.GetListView, txtLotID.Text) == false) return false;
#endif

            if (cdvCrrID.Items.Count < 1)
            {
                if (SetSublotList() == false) return false;
            }
            else if (cdvCrrID.Items.Count == 1)
            {
                cdvCrrID.Text = cdvCrrID.Items[0].Text;
                cdvCrrID_SelectedItemChanged(null, null);
            }
            else
            {
                MPCF.ClearList(spdSublotLoss, true);
            }


            cdvResID.Text = LOT.GetString("START_RES_ID");
            
            txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
            txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
            
            txtOutQty1.Text = txtQty1.Text;
            txtOutQty2.Text = txtQty2.Text;
            txtOutQty3.Text = txtQty3.Text;
            
            return true;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                switch (ProcStep)
                {
                    case "1":
                        
                        //Initialize
                        MPCF.FieldClear(this);
                        txtLossQty1.Text = "";
                        txtLossQty2.Text = "";
                        
                        ClearLotSpread();
                        MPCF.ClearList(spdSublotLoss, true);
                        MPCF.ClearList(spdCodeList, true);
                        spdCodeList.ActiveSheet.RowCount = 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition()
        {

            int i = 0;
            int j = 0;

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                txtLotID.Focus();
                return false;
            }
            //if (MPCF.Trim(LOT.GetString("FLOW")) == "")
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
            //    txtLotID.Focus();
            //    return false;
            //}
            if (MPCF.Trim(LOT.GetString("OPER")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                txtLotID.Focus();
                return false;
            }
            if (cdvCauseFlow.Text == "" && cdvCauseOper.Text != "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                tabTran.SelectedTab = tbpGeneral;
                cdvCauseFlow.Focus();
                return false;
            }
            if (cdvCauseFlow.Text != "" && cdvCauseOper.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                tabTran.SelectedTab = tbpGeneral;
                cdvCauseOper.Focus();
                return false;
            }

#if _CRR
            if (cdvCrrID.Items.Count > 0)
            {
                if (cdvCrrID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    tabTran.SelectedTab = tbpGeneral;
                    cdvCrrID.Focus();
                    return false;
                }
            }
#endif


            i_loss_code_count = 0;
            for (j = 0; j < 10; j++)
            {
                t_loss_unit1[j].loss_code = "";
                t_loss_unit1[j].qty = 0;
            }

            for (i = 0; i < spdSublotLoss.ActiveSheet.RowCount; i++)
            {

                if ((MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 2].Tag) != MPGC.MP_SUBLOT_GOOD_GRADE ||
                     MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 2].Value) != MPGC.MP_SUBLOT_GOOD_GRADE) && MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 4].Value) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(237));
                    tabTran.SelectedTab = tbpInfo;
                    spdSublotLoss.ActiveSheet.SetActiveCell(i, 4);
                    return false;
                }
                if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 4].Value) != "" && MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 2].Value) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(240));
                    tabTran.SelectedTab = tbpInfo;
                    spdSublotLoss.ActiveSheet.SetActiveCell(i, 2);
                    return false;
                }
                if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 6].Value) != "")
                {
                    if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 6].Value).Length != MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 6].Tag).Length)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(238));
                        tabTran.SelectedTab = tbpInfo;
                        spdSublotLoss.ActiveSheet.SetActiveCell(i, 6);
                        return false;
                    }
                }

                if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 2].Value) != "" && MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 4].Value) != "")
                {

                    for (j = 0; j < 10; j++)
                    {
                        if (t_loss_unit1[j].loss_code == MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 4].Value))
                        {
                            if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 2].Value) == MPGC.MP_SUBLOT_SCRAP_GRADE)
                            {
                                t_loss_unit1[j].qty = t_loss_unit1[j].qty + 1;
                            }
                            break;
                        }
                    }
                    if (j > 9)
                    {
                        if (MPCF.Trim(t_loss_unit1[i_loss_code_count].loss_code) == "")
                        {
                            t_loss_unit1[i_loss_code_count].loss_code = MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 4].Value);

                            if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 2].Value) == MPGC.MP_SUBLOT_SCRAP_GRADE)
                            {
                                t_loss_unit1[i_loss_code_count].qty = t_loss_unit1[i_loss_code_count].qty + 1;
                            }

                            i_loss_code_count++;
                        }
                    }
                }
            }


            ArrayList controlUnit2Qty = null;
            ArrayList controlUnit2Code = null;
            int i_scrap_qty_2 = 0;

            controlUnit2Qty = MPCF.GetIndexedControl("txtUnit2Qty", grpUnit2);
            controlUnit2Code = MPCF.GetIndexedControl("cdvUnit2Code", grpUnit2);
            for (i = 0; i < 10; i++)
            {
                if (MPCF.Trim(((UltraNumericEditor)controlUnit2Qty[i]).Text) != "")
                {
                    if (MPCF.ToDbl(((UltraNumericEditor)controlUnit2Qty[i]).Text) != 0 && MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[i]).Text) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpInfo;
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[i]).Focus();
                        return false;
                    }
                }
                if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[i]).Text) != "")
                {
                    if (MPCF.ToDbl(((UltraNumericEditor)controlUnit2Qty[i]).Text) == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpInfo;
                        ((UltraNumericEditor)controlUnit2Qty[i]).Focus();
                        return false;
                    }
                }
            }
            for (i = 0; i < controlUnit2Code.Count - 1; i++)
            {
                if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[i]).Text) != "")
                {
                    for (j = i + 1; j < controlUnit2Code.Count; j++)
                    {
                        if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[i]).Text) ==
                            MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[j]).Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(111));
                            tabTran.SelectedTab = tbpInfo;
                            ((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[i]).Focus();
                            return false;
                        }
                    }
                }
            }
            
            for (i = 0; i < controlUnit2Qty.Count; i++)
            {
                if (MPCF.ToDbl(((UltraNumericEditor)controlUnit2Qty[i]).Text) != 0)
                {
                    i_scrap_qty_2 += MPCF.ToInt(MPCF.Trim(((UltraNumericEditor)controlUnit2Qty[i]).Text));
                }
            }

            if (MPCF.ToDbl(txtQty2.Text) + i_scrap_qty_2 != MPCF.ToDbl(txtOutQty2.Text))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(239));
                tabTran.SelectedTab = tbpInfo;
                cdvUnit2Code1.Focus();
                return false;
            }
        
            ArrayList controlUnit3Qty = null;
            ArrayList controlUnit3Code = null;
            int i_scrap_qty_3 = 0;

            controlUnit3Qty = MPCF.GetIndexedControl("txtUnit3Qty", grpUnit3);
            controlUnit3Code = MPCF.GetIndexedControl("cdvUnit3Code", grpUnit3);
            for (i = 0; i < 10; i++)
            {
                if (MPCF.Trim(((UltraNumericEditor)controlUnit3Qty[i]).Text) != "")
                {
                    if (MPCF.ToDbl(((UltraNumericEditor)controlUnit3Qty[i]).Text) != 0 && MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit3Code[i]).Text) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpInfo;
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit3Code[i]).Focus();
                        return false;
                    }
                }
                if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit3Code[i]).Text) != "")
                {
                    if (MPCF.ToDbl(((UltraNumericEditor)controlUnit3Qty[i]).Text) == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpInfo;
                        ((UltraNumericEditor)controlUnit3Qty[i]).Focus();
                        return false;
                    }
                }
            }
            for (i = 0; i < controlUnit3Code.Count - 1; i++)
            {
                if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit3Code[i]).Text) != "")
                {
                    for (j = i + 1; j < controlUnit3Code.Count; j++)
                    {
                        if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit3Code[i]).Text) ==
                            MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit3Code[j]).Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(111));
                            tabTran.SelectedTab = tbpInfo;
                            ((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit3Code[i]).Focus();
                            return false;
                        }
                    }
                }
            }
            for (i = 0; i < controlUnit3Qty.Count; i++)
            {
                if (MPCF.ToDbl(((UltraNumericEditor)controlUnit3Qty[i]).Text) != 0)
                {
                    i_scrap_qty_3 += MPCF.ToInt(MPCF.Trim(((UltraNumericEditor)controlUnit3Qty[i]).Text));
                }
            }

            if (MPCF.ToDbl(txtQty3.Text) + i_scrap_qty_3 != MPCF.ToDbl(txtOutQty3.Text))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(308));
                tabTran.SelectedTab = tbpInfo;
                return false;
            }

            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }

            return true;
        }
        
        //
        // SetSublotList()
        //       -  Set Sublot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool SetSublotList()
        {
            int i;
            int i_row;
            CodeListBySublot t_sublot;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");

            MPCF.ClearList(spdSublotLoss, true);
            MPCF.ClearList(spdCodeList, true);

            spdCodeList.ActiveSheet.RowCount = 1;

            b_load_sublot_list_flag = false;
            b_exist_sublot_unit2 = false;
            b_exist_sublot_unit3 = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            i_row = 0;
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdSublotLoss.ActiveSheet.RowCount += out_node.GetList(0).Count;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    // Add For V42 //////////////////////////////
                    t_sublot = new CodeListBySublot();
                    t_sublot.sublot_id = out_node.GetList(0)[i].GetString("SUBLOT_ID");
                    t_sublot.codes = new ArrayList();
                    t_code_list_by_sublot.Add(t_sublot);
                    //////////////////////////////////////////////

                    spdSublotLoss.ActiveSheet.Cells[i_row, 0].Value = out_node.GetList(0)[i].GetInt("SLOT_NO");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 1].Value = out_node.GetList(0)[i].GetString("SUBLOT_ID");

                    spdSublotLoss.ActiveSheet.Cells[i_row, 2].Value = out_node.GetList(0)[i].GetChar("GRADE");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 2].Tag = out_node.GetList(0)[i].GetChar("GRADE");

                    spdSublotLoss.ActiveSheet.Cells[i_row, 4].Value = out_node.GetList(0)[i].GetString("GRADE_CODE");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 4].Tag = out_node.GetList(0)[i].GetString("GRADE_CODE");

                    spdSublotLoss.ActiveSheet.Cells[i_row, 6].Value = out_node.GetList(0)[i].GetString("CELL_GRADE");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 6].Tag = out_node.GetList(0)[i].GetString("CELL_GRADE");

                    spdSublotLoss.ActiveSheet.Cells[i_row, 7].Value = out_node.GetList(0)[i].GetDouble("QTY_2");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 7].Tag = out_node.GetList(0)[i].GetDouble("QTY_2");

                    //Add by J.S. 2009.02.18 for Add CELL_JUDGE
                    spdSublotLoss.ActiveSheet.Cells[i_row, 8].Value = out_node.GetList(0)[i].GetString("CELL_JUDGE");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 8].Tag = out_node.GetList(0)[i].GetString("CELL_JUDGE");

                    if (out_node.GetList(0)[i].GetString("CELL_GRADE") == "")
                    {
                        spdSublotLoss.ActiveSheet.Cells[i_row, 6].Locked = true;
                        spdSublotLoss.ActiveSheet.Cells[i_row, 7].Locked = true;
                        spdSublotLoss.ActiveSheet.Cells[i_row, 8].Locked = true;
                    }
                    else
                    {
                        FarPoint.Win.Spread.CellType.MaskCellType MaskCellType = new FarPoint.Win.Spread.CellType.MaskCellType();
                        int ii;
                        int i_cell_grade_count;
                        string s_mask;

                        i_cell_grade_count = out_node.GetList(0)[i].GetString("CELL_GRADE").Length;

                        s_mask = "";
                        for (ii = 1; ii <= i_cell_grade_count; ii++)
                        {
                            s_mask = s_mask + "W";

                            if (ii < i_cell_grade_count && (ii % 10) == 0)
                            {
                                s_mask = s_mask + " ";
                            }
                        }

                        MaskCellType.Mask = s_mask;
                        MaskCellType.MaskChar = '_';

                        spdSublotLoss.ActiveSheet.Cells[i_row, 6].CellType = MaskCellType;

                        spdSublotLoss.ActiveSheet.Cells[i_row, 7].Locked = true;

                        b_exist_sublot_unit2 = true;
                    }

                    //Add by J.S. 2009.02.18 for Add CELL_JUDGE
                    if (out_node.GetList(0)[i].GetString("CELL_JUDGE") == "")
                    {
                    }
                    else
                    {
                        FarPoint.Win.Spread.CellType.MaskCellType MaskCellType = new FarPoint.Win.Spread.CellType.MaskCellType();
                        int ii;
                        int i_cell_judge_count;
                        string s_mask;

                        i_cell_judge_count = out_node.GetList(0)[i].GetString("CELL_JUDGE").Length;

                        s_mask = "";
                        for (ii = 1; ii <= i_cell_judge_count; ii++)
                        {
                            s_mask = s_mask + "W";

                            if (ii < i_cell_judge_count && (ii % 10) == 0)
                            {
                                s_mask = s_mask + " ";
                            }
                        }

                        MaskCellType.Mask = s_mask;
                        MaskCellType.MaskChar = '_';

                        spdSublotLoss.ActiveSheet.Cells[i_row, 8].CellType = MaskCellType;
                    }

                    i_row++;
                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            b_load_sublot_list_flag = true;

            return true;
        }

#if _CRR
        //
        // SetCarrierSublotList()
        //       -  Set Sublot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool SetCarrierSublotList(string sCrrID)
        {
            int i;
            int i_row;
            CodeListBySublot t_sublot;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");

            MPCF.ClearList(spdSublotLoss, true);
            MPCF.ClearList(spdCodeList, true);

            spdCodeList.ActiveSheet.RowCount = 1;

            b_load_sublot_list_flag = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("CRR_ID", MPCF.Trim(sCrrID));

            i_row = 0;
            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Carrier_Sublot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdSublotLoss.ActiveSheet.RowCount += out_node.GetList(0).Count;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    // Add For V42 //////////////////////////////
                    t_sublot = new CodeListBySublot();
                    t_sublot.sublot_id = out_node.GetList(0)[i].GetString("SUBLOT_ID");
                    t_sublot.codes = new ArrayList();
                    t_code_list_by_sublot.Add(t_sublot);
                    //////////////////////////////////////////////

                    spdSublotLoss.ActiveSheet.Cells[i_row, 0].Value = out_node.GetList(0)[i].GetInt("SLOT_NO");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 1].Value = out_node.GetList(0)[i].GetString("SUBLOT_ID");

                    spdSublotLoss.ActiveSheet.Cells[i_row, 2].Value = out_node.GetList(0)[i].GetChar("GRADE");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 2].Tag = out_node.GetList(0)[i].GetChar("GRADE");

                    spdSublotLoss.ActiveSheet.Cells[i_row, 4].Value = out_node.GetList(0)[i].GetString("GRADE_CODE");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 4].Tag = out_node.GetList(0)[i].GetString("GRADE_CODE");

                    spdSublotLoss.ActiveSheet.Cells[i_row, 6].Value = out_node.GetList(0)[i].GetString("CELL_GRADE");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 6].Tag = out_node.GetList(0)[i].GetString("CELL_GRADE");

                    spdSublotLoss.ActiveSheet.Cells[i_row, 7].Value = out_node.GetList(0)[i].GetDouble("QTY_2");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 7].Tag = out_node.GetList(0)[i].GetDouble("QTY_2");

                    //Add by J.S. 2009.02.18 for Add CELL_JUDGE
                    spdSublotLoss.ActiveSheet.Cells[i_row, 8].Value = out_node.GetList(0)[i].GetString("CELL_JUDGE");
                    spdSublotLoss.ActiveSheet.Cells[i_row, 8].Tag = out_node.GetList(0)[i].GetString("CELL_JUDGE");


                    if (out_node.GetList(0)[i].GetString("CELL_GRADE") == "")
                    {
                        spdSublotLoss.ActiveSheet.Cells[i_row, 6].Locked = true;
                    }
                    else
                    {
                        FarPoint.Win.Spread.CellType.MaskCellType MaskCellType = new FarPoint.Win.Spread.CellType.MaskCellType();
                        int ii;
                        int i_cell_grade_count;
                        string s_mask;

                        i_cell_grade_count = out_node.GetList(0)[i].GetString("CELL_GRADE").Length;

                        s_mask = "";
                        for (ii = 1; ii <= i_cell_grade_count; ii++)
                        {
                            s_mask = s_mask + "W";

                            if (ii < i_cell_grade_count && (ii % 10) == 0)
                            {
                                s_mask = s_mask + " ";
                            }
                        }

                        MaskCellType.Mask = s_mask;
                        MaskCellType.MaskChar = '_';

                        spdSublotLoss.ActiveSheet.Cells[i_row, 6].CellType = MaskCellType;

                        spdSublotLoss.ActiveSheet.Cells[i_row, 7].Locked = true;
                    }

                    //Add by J.S. 2009.02.18 for Add CELL_JUDGE
                    if (out_node.GetList(0)[i].GetString("CELL_JUDGE") == "")
                    {
                    }
                    else
                    {
                        FarPoint.Win.Spread.CellType.MaskCellType MaskCellType = new FarPoint.Win.Spread.CellType.MaskCellType();
                        int ii;
                        int i_cell_judge_count;
                        string s_mask;

                        i_cell_judge_count = out_node.GetList(0)[i].GetString("CELL_JUDGE").Length;

                        s_mask = "";
                        for (ii = 1; ii <= i_cell_judge_count; ii++)
                        {
                            s_mask = s_mask + "W";

                            if (ii < i_cell_judge_count && (ii % 10) == 0)
                            {
                                s_mask = s_mask + " ";
                            }
                        }

                        MaskCellType.Mask = s_mask;
                        MaskCellType.MaskChar = '_';

                        spdSublotLoss.ActiveSheet.Cells[i_row, 8].CellType = MaskCellType;
                    }

                    i_row++;

                }

                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));

            } while (in_node.GetInt("NEXT_SLOT_NO") > 0);

            b_load_sublot_list_flag = true;

            return true;
        }
#endif

        private int GetIndexSublotList(string s_sublot)
        {
            int i;
            CodeListBySublot t_sublot;

            for (i = 0; i < t_code_list_by_sublot.Count; i++)
            {
                t_sublot = (CodeListBySublot)t_code_list_by_sublot[i];
                if (s_sublot == t_sublot.sublot_id)
                    return i;
            }
            return -1;
        }

        //
        // SaveSublotListByLossReason()
        //       - Save Sublot loss reason code
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool SaveSublotListByLossReason(int i_row_index, string s_sublot)
        {
            int i;
            string s_reason_code;
            string s_major_code;
            CodeListBySublot t_sublot;

            try
            {
                i = GetIndexSublotList(s_sublot);
                if (i < 0) return false;

                t_sublot = (CodeListBySublot)t_code_list_by_sublot[i];
                t_sublot.codes.Clear();

                s_major_code = MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(i_row_index, 4));

                for (i = 0; i < spdCodeList.ActiveSheet.RowCount - 1; i++)
                {
                    s_reason_code = MPCF.Trim(spdCodeList.ActiveSheet.GetValue(i, 0));
                    if (s_reason_code != "" && s_major_code != s_reason_code)
                    {
                        if (t_sublot.codes.Contains(s_reason_code) == false)
                        {
                            t_sublot.codes.Add(s_reason_code);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // LoadSublotListByLossReason()
        //       - Load Sublot loss reason code
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool LoadSublotListByLossReason(int i_row_index, string s_sublot)
        {
            int i;
            CodeListBySublot t_sublot;

            try
            {
                i = GetIndexSublotList(s_sublot);
                if (i < 0) return false;

                t_sublot = (CodeListBySublot)t_code_list_by_sublot[i];

                spdCodeList.ActiveSheet.RowCount = 0;
                spdCodeList.ActiveSheet.RowCount = t_sublot.codes.Count + 1;
                for (i = 0; i < t_sublot.codes.Count; i++)
                {
                    spdCodeList.ActiveSheet.SetValue(i, 0, t_sublot.codes[i]);
                    spdCodeList.ActiveSheet.Cells[i, 0].BackColor = System.Drawing.Color.WhiteSmoke;
                }
                spdCodeList.ActiveSheet.SetActiveCell(0, 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        
        //
        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation()
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT_1") != "")
            {
                MPCF.FieldVisible(grpUnit1, true);
            }
            else
            {
                MPCF.FieldVisible(grpUnit1, false);
                txtOutQty1.Text = "0";

            }
            if (out_node.GetString("UNIT_2") != "")
            {
                MPCF.FieldVisible(grpUnit2, true);
            }
            else
            {
                MPCF.FieldVisible(grpUnit2, false);
                txtOutQty2.Text = "0";
            }

            if (out_node.GetString("UNIT_3") != "")
            {
                MPCF.FieldVisible(grpUnit3, true);
            }
            else
            {
                MPCF.FieldVisible(grpUnit3, false);
                txtOutQty3.Text = "0";
            }

            s_loss_table = "";
            s_loss_table = MPCR.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOSS_TBL_DEF);
            if (s_loss_table == "")
            {
                s_loss_table = out_node.GetString("LOSS_TBL");
            }
            if (s_loss_table == "")
            {
                MPCF.FieldVisible(pnlUnitMid, false);
                MPCF.ShowMsgBox(MPCF.GetMessage(247));
            }

            return true;

        }

        //
        // Loss_Lot()
        //       - Loss Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Loss_Lot()
        {

            int i = 0;
            int j = 0;
            string s_sublot_id;
            CodeListBySublot t_sublot;

            TRSNode in_node = new TRSNode("LOSS_LOT_EXT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;
            TRSNode code_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));
                in_node.AddString("CAUSE_FLOW", MPCF.Trim(cdvCauseFlow.Text));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(cdvCauseOper.Text));
                in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));
                in_node.AddString("CHECK_USER_1", MPCF.Trim(txtChkUser1.Text), true);
                in_node.AddString("CHECK_USER_2", MPCF.Trim(txtChkUser2.Text), true);
                in_node.AddString("CHECK_USER_3", MPCF.Trim(txtChkUser3.Text), true);

                if (MPCF.CheckNumeric(txtOutQty1.Text) == true)
                {
                    in_node.AddDouble("OUT_QTY_1", MPCF.ToDbl(txtOutQty1.Text));
                }
                else
                {
                    in_node.AddDouble("OUT_QTY_1", 0);
                }
                if (MPCF.CheckNumeric(txtOutQty2.Text) == true)
                {
                    in_node.AddDouble("OUT_QTY_2", MPCF.ToDbl(txtOutQty2.Text));
                }
                else
                {
                    in_node.AddDouble("OUT_QTY_2", 0);
                }
                if (MPCF.CheckNumeric(txtOutQty3.Text) == true)
                {
                    in_node.AddDouble("OUT_QTY_3", MPCF.ToDbl(txtOutQty3.Text));
                }
                else
                {
                    in_node.AddDouble("OUT_QTY_3", 0);
                }



                if (t_loss_unit1[0].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_1", t_loss_unit1[0].loss_code);
                    in_node.AddDouble("UNIT1_QTY_1", t_loss_unit1[0].qty);
                }
                if (t_loss_unit1[1].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_2", t_loss_unit1[1].loss_code);
                    in_node.AddDouble("UNIT1_QTY_2", t_loss_unit1[1].qty);
                }
                if (t_loss_unit1[2].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_3", t_loss_unit1[2].loss_code);
                    in_node.AddDouble("UNIT1_QTY_3", t_loss_unit1[2].qty);
                }
                if (t_loss_unit1[3].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_4", t_loss_unit1[3].loss_code);
                    in_node.AddDouble("UNIT1_QTY_4", t_loss_unit1[3].qty);
                }
                if (t_loss_unit1[4].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_5", t_loss_unit1[4].loss_code);
                    in_node.AddDouble("UNIT1_QTY_5", t_loss_unit1[4].qty);
                }
                if (t_loss_unit1[5].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_6", t_loss_unit1[5].loss_code);
                    in_node.AddDouble("UNIT1_QTY_6", t_loss_unit1[5].qty);
                }
                if (t_loss_unit1[6].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_7", t_loss_unit1[6].loss_code);
                    in_node.AddDouble("UNIT1_QTY_7", t_loss_unit1[6].qty);
                }
                if (t_loss_unit1[7].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_8", t_loss_unit1[7].loss_code);
                    in_node.AddDouble("UNIT1_QTY_8", t_loss_unit1[7].qty);
                }
                if (t_loss_unit1[8].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_9", t_loss_unit1[8].loss_code);
                    in_node.AddDouble("UNIT1_QTY_9", t_loss_unit1[8].qty);
                }
                if (t_loss_unit1[9].loss_code != "")
                {
                    in_node.AddString("UNIT1_CODE_10", t_loss_unit1[9].loss_code);
                    in_node.AddDouble("UNIT1_QTY_10", t_loss_unit1[9].qty);
                }

                in_node.AddString("UNIT2_CODE_1", MPCF.Trim(cdvUnit2Code1.Text));
                in_node.AddString("UNIT2_CODE_2", MPCF.Trim(cdvUnit2Code2.Text));
                in_node.AddString("UNIT2_CODE_3", MPCF.Trim(cdvUnit2Code3.Text));
                in_node.AddString("UNIT2_CODE_4", MPCF.Trim(cdvUnit2Code4.Text));
                in_node.AddString("UNIT2_CODE_5", MPCF.Trim(cdvUnit2Code5.Text));
                in_node.AddString("UNIT2_CODE_6", MPCF.Trim(cdvUnit2Code6.Text));
                in_node.AddString("UNIT2_CODE_7", MPCF.Trim(cdvUnit2Code7.Text));
                in_node.AddString("UNIT2_CODE_8", MPCF.Trim(cdvUnit2Code8.Text));
                in_node.AddString("UNIT2_CODE_9", MPCF.Trim(cdvUnit2Code9.Text));
                in_node.AddString("UNIT2_CODE_10", MPCF.Trim(cdvUnit2Code10.Text));
                if (MPCF.CheckNumeric(txtUnit2Qty1.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_1", MPCF.ToDbl(txtUnit2Qty1.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_1", 0);
                }
                if (MPCF.CheckNumeric(txtUnit2Qty2.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_2", MPCF.ToDbl(txtUnit2Qty2.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_2", 0);
                }
                if (MPCF.CheckNumeric(txtUnit2Qty3.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_3", MPCF.ToDbl(txtUnit2Qty3.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_3", 0);
                }
                if (MPCF.CheckNumeric(txtUnit2Qty4.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_4", MPCF.ToDbl(txtUnit2Qty4.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_4", 0);
                }
                if (MPCF.CheckNumeric(txtUnit2Qty5.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_5", MPCF.ToDbl(txtUnit2Qty5.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_5", 0);
                }
                if (MPCF.CheckNumeric(txtUnit2Qty6.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_6", MPCF.ToDbl(txtUnit2Qty6.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_6", 0);
                }
                if (MPCF.CheckNumeric(txtUnit2Qty7.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_7", MPCF.ToDbl(txtUnit2Qty7.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_7", 0);
                }
                if (MPCF.CheckNumeric(txtUnit2Qty8.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_8", MPCF.ToDbl(txtUnit2Qty8.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_8", 0);
                }
                if (MPCF.CheckNumeric(txtUnit2Qty9.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_9", MPCF.ToDbl(txtUnit2Qty9.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_9", 0);
                }
                if (MPCF.CheckNumeric(txtUnit2Qty10.Text) == true)
                {
                    in_node.AddDouble("UNIT2_QTY_10", MPCF.ToDbl(txtUnit2Qty10.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT2_QTY_10", 0);
                }

                if (MPCF.CheckNumeric(txtUnit3Qty1.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_1", MPCF.ToDbl(txtUnit3Qty1.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_1", 0);
                }
                if (MPCF.CheckNumeric(txtUnit3Qty2.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_2", MPCF.ToDbl(txtUnit3Qty2.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_2", 0);
                }
                if (MPCF.CheckNumeric(txtUnit3Qty3.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_3", MPCF.ToDbl(txtUnit3Qty3.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_3", 0);
                }
                if (MPCF.CheckNumeric(txtUnit3Qty4.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_4", MPCF.ToDbl(txtUnit3Qty4.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_4", 0);
                }
                if (MPCF.CheckNumeric(txtUnit3Qty5.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_5", MPCF.ToDbl(txtUnit3Qty5.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_5", 0);
                }
                if (MPCF.CheckNumeric(txtUnit3Qty6.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_6", MPCF.ToDbl(txtUnit3Qty6.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_6", 0);
                }
                if (MPCF.CheckNumeric(txtUnit3Qty7.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_7", MPCF.ToDbl(txtUnit3Qty7.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_7", 0);
                }
                if (MPCF.CheckNumeric(txtUnit3Qty8.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_8", MPCF.ToDbl(txtUnit3Qty8.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_8", 0);
                }
                if (MPCF.CheckNumeric(txtUnit3Qty9.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_9", MPCF.ToDbl(txtUnit3Qty9.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_9", 0);
                }
                if (MPCF.CheckNumeric(txtUnit3Qty10.Text) == true)
                {
                    in_node.AddDouble("UNIT3_QTY_10", MPCF.ToDbl(txtUnit3Qty10.Text) * -1);
                }
                else
                {
                    in_node.AddDouble("UNIT3_QTY_10", 0);
                }

                in_node.AddString("UNIT3_CODE_1", MPCF.Trim(cdvUnit3Code1.Text));
                in_node.AddString("UNIT3_CODE_2", MPCF.Trim(cdvUnit3Code2.Text));
                in_node.AddString("UNIT3_CODE_3", MPCF.Trim(cdvUnit3Code3.Text));
                in_node.AddString("UNIT3_CODE_4", MPCF.Trim(cdvUnit3Code4.Text));
                in_node.AddString("UNIT3_CODE_5", MPCF.Trim(cdvUnit3Code5.Text));
                in_node.AddString("UNIT3_CODE_6", MPCF.Trim(cdvUnit3Code6.Text));
                in_node.AddString("UNIT3_CODE_7", MPCF.Trim(cdvUnit3Code7.Text));
                in_node.AddString("UNIT3_CODE_8", MPCF.Trim(cdvUnit3Code8.Text));
                in_node.AddString("UNIT3_CODE_9", MPCF.Trim(cdvUnit3Code9.Text));
                in_node.AddString("UNIT3_CODE_10", MPCF.Trim(cdvUnit3Code10.Text));
                for (i = 0; i < spdSublotLoss.ActiveSheet.RowCount; i++)
                {
                    s_sublot_id = MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 1].Value);
                    if (s_sublot_id != "")
                    {
                        j = GetIndexSublotList(s_sublot_id);

                        s_sublot_id = "";
                        if (j >= 0)
                        {
                            t_sublot = (CodeListBySublot)t_code_list_by_sublot[j];
                            if (t_sublot.codes.Count > 0)
                            {
                                s_sublot_id = "REASON";
                            }
                        }

                        if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 2].Value) != MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 2].Tag) || 
                            MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 4].Value) != MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 4].Tag) ||
                            MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 6].Value) != MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 6].Tag) ||
                            MPCF.ToDbl(spdSublotLoss.ActiveSheet.Cells[i, 7].Value) != MPCF.ToDbl(spdSublotLoss.ActiveSheet.Cells[i, 7].Tag) ||
                            MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 8].Value) != MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 8].Tag) ||
                            s_sublot_id != "")
                        {
                            list_item = in_node.AddNode("SUBLOT");

                            list_item.AddInt("SLOT_NO", MPCF.ToInt(spdSublotLoss.ActiveSheet.Cells[i, 0].Value));
                            list_item.AddString("SUBLOT_ID", MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 1].Value));
                            list_item.AddChar("GRADE", MPCF.ToChar(spdSublotLoss.ActiveSheet.Cells[i, 2].Value));
                            list_item.AddString("LOSS_CODE", MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 4].Value));
                            list_item.AddString("CELL_GRADE", MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 6].Value));                            
                            list_item.AddDouble("OUT_QTY_2", MPCF.ToDbl(spdSublotLoss.ActiveSheet.Cells[i, 7].Value));
                            //Add by J.S. 2009.02.18 for ADD CELL_JUDGE
                            list_item.AddString("CELL_JUDGE", MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 8].Value));

                            j = GetIndexSublotList(list_item.GetString("SUBLOT_ID"));
                            if(j >= 0)
                            {
                                t_sublot = (CodeListBySublot)t_code_list_by_sublot[j];

                                if (t_sublot.codes.Count > 0)
                                {
                                    for (j = 0; j < t_sublot.codes.Count; j++)
                                    {
                                        code_item = list_item.AddNode("REASON");
                                        code_item.AddString("REASON_CODE", MPCF.Trim(t_sublot.codes[j]));
                                    }
                                }
                            }
                        }
                    }
                }

                in_node.AddString("LOT_TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("LOT_TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("LOT_TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("LOT_TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("LOT_TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("LOT_TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("LOT_TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("LOT_TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("LOT_TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("LOT_TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("LOT_TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("LOT_TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("LOT_TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("LOT_TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("LOT_TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("LOT_TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("LOT_TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("LOT_TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("LOT_TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("LOT_TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddString("LOSS_COMMENT", MPCF.Trim(txtLossComment.Text));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_Loss_Lot_Ext", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
        
        #endregion

        private void frmWIPTranLossLot_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    this.tabTran.TabPages.Remove(this.tbpCMF);
                    this.tabTran.Controls.Add(this.tbpCMF);

                    b_load_sublot_list_flag = false;

                    t_code_list_by_sublot = new ArrayList();
                    
                    #if _CRR
                    lblCrrID.Visible = true;
                    cdvCrrID.Visible = true;
                    #endif

                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_LOSS);
                    
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvUnitCode_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            try
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
                
                cdvTemp.Init();
                cdvTemp.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTemp.SelectedSubItemIndex = 0;

                if (BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', s_loss_table) == false)
                {
                    return;
                }
                cdvTemp.InsertEmptyRow(0, 1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }
        
        private void cdvCauseRes_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (txtLotID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLotID.Focus();
                    return;
                }
                if (cdvCauseOper.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvCauseOper.Focus();
                    return;
                }
                
                cdvCauseRes.Init();
                cdvCauseRes.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvCauseRes.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseRes.SelectedSubItemIndex = 0;
                #if _RAS
                if (RASLIST.ViewResourceList(cdvCauseRes.GetListView, "%", 0, cdvCauseFlow.Text, cdvCauseOper.Text, false) == false)
                {
                    return;
                }
                #endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (txtLotID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLotID.Focus();
                    return;
                }
                if (MPCF.Trim(LOT.GetString("OPER")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                    return;
                }
                
                cdvResID.Init();
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
                #if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
                {
                    return;
                }
                #endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }
        
        private void cdvCauseFlow_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                    return;
                }
                
                cdvCauseFlow.Init();
                cdvCauseFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvCauseFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseFlow.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewFlowList(cdvCauseFlow.GetListView, '1', "",0, "", null, "") == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }
        
        private void cdvCauseFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                cdvCauseOper.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }
        
        private void cdvCauseOper_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                    return;
                }
                if (cdvCauseFlow.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvCauseFlow.Focus();
                    return;
                }
                
                cdvCauseOper.Init();
                cdvCauseOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvCauseOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseOper.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvCauseOper.GetListView, '2', "", 0,cdvCauseFlow.Text, "", null, "") == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }
        
        private void cdvCauseOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                cdvCauseRes.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == false) return;

                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_LOSS, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'B') == false) return;
                if (Loss_Lot() == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_LOSS, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'A') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string s_sublot;
            int i_row;
            int i;

            if (spdSublotLoss.ActiveSheet.RowCount < 1) return;
            if (spdSublotLoss.ActiveSheet.ActiveRowIndex < 0) return;

            i_row = spdSublotLoss.ActiveSheet.ActiveRowIndex;
            s_sublot = MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(i_row, 1));

            for (i = 0; i < spdSublotLoss.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(i, 4)) != "")
                {
                    SaveSublotListByLossReason(i, MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(i, 1)));
                }
            }

            LoadSublotListByLossReason(i_row, s_sublot);
        }

        private void spdSublotLoss_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            string s_sublot;
            int i_row;

            if (spdSublotLoss.ActiveSheet.RowCount < 1) return;
            if (spdSublotLoss.ActiveSheet.ColumnCount < 1) return;

            i_row = spdSublotLoss.ActiveSheet.ActiveRowIndex;
            s_sublot = spdSublotLoss.ActiveSheet.GetText(i_row, 1);
            LoadSublotListByLossReason(i_row, s_sublot);
        }

        private void spdSublotLoss_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_sublot;
            s_sublot = MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(e.Row, 1));
            LoadSublotListByLossReason(e.Row, s_sublot);

            if (e.Column == 3)
            {
                cdvGrade.Init();
                cdvGrade.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvGrade.GetListView);
                cdvGrade.Columns.Add("Grade", 50, HorizontalAlignment.Left);
                cdvGrade.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                BASLIST.ViewGCMDataList(cdvGrade.GetListView, '1', MPGC.MP_WIP_SUBLOT_GRADE);
                
                if (cdvGrade.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            else if (e.Column == 5)
            {
                cdvLossCode.Init();
                cdvLossCode.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvLossCode.GetListView);
                cdvLossCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvLossCode.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                cdvLossCode.Columns.Add("Reusable", 50, HorizontalAlignment.Left);

                if (s_loss_table != "")
                {
                    BASLIST.ViewGCMDataList(cdvLossCode.GetListView, '1', s_loss_table);
                    cdvLossCode.InsertEmptyRow(0, 1);
                }

                if (cdvLossCode.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }

                lspd_table = spdSublotLoss;
            }
            
        }

        private void spdCodeList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            int i;
            int i_index;

            if (spdSublotLoss.ActiveSheet.RowCount < 1) return;
            if (spdSublotLoss.ActiveSheet.ColumnCount < 1) return;

            cdvLossCode.Init();
            cdvLossCode.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvLossCode.GetListView);
            cdvLossCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvLossCode.Columns.Add("Desc", 50, HorizontalAlignment.Left);

            if (s_loss_table == "") 
            {
                return;
            }
            if (MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(spdSublotLoss.ActiveSheet.ActiveRowIndex, 4)) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                spdSublotLoss.Focus();
                return;
            }

            BASLIST.ViewGCMDataList(cdvLossCode.GetListView, '1', s_loss_table);

            i_index = MPCF.FindListItemIndex(cdvLossCode.GetListView, MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(spdSublotLoss.ActiveSheet.ActiveRowIndex, 4)), false);
            if (i_index > -1)
            {
                cdvLossCode.Items.RemoveAt(i_index);
            }

            for (i = 0; i < spdCodeList.ActiveSheet.RowCount; i++)
            {
                i_index = MPCF.FindListItemIndex(cdvLossCode.GetListView, MPCF.Trim(spdCodeList.ActiveSheet.GetValue(i, 0)), false);
                if (i_index > -1)
                {
                    cdvLossCode.Items.RemoveAt(i_index);
                }
            }

            cdvLossCode.InsertEmptyRow(0, 1);

            if (cdvLossCode.ShowPopupList(e.Row, e.Column) == false)
            {
                return;
            }

            lspd_table = spdCodeList;
        }

        private void cdvLossCode_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            string s_sublot;
            int i;
            
            lspd_table.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;

            if (lspd_table.Name == "spdSublotLoss")
            {
                if (MPCF.Trim(e.SelectedItem.Text) == "")
                {
                    if (MPCF.Trim(spdCodeList.ActiveSheet.GetValue(0, 0)) != "")
                    {
                        spdSublotLoss.ActiveSheet.Cells[e.Row, e.Col - 1].Value = MPCF.Trim(spdCodeList.ActiveSheet.GetValue(0, 0));
                    }

                    return;
                }

                for (i = 0; i < spdCodeList.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdCodeList.ActiveSheet.GetValue(i, 0)) == e.SelectedItem.Text)
                    {
                        spdCodeList.ActiveSheet.RemoveRows(i, 1);
                        break;
                    }
                }
                    
                s_sublot = MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(e.Row, 1));
                SaveSublotListByLossReason(e.Row, s_sublot);
            }
            else if (lspd_table.Name == "spdCodeList")
            {
                if (e.Row == spdCodeList.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdCodeList.ActiveSheet.GetValue(e.Row, 0)) != "")
                    {
                        spdCodeList.ActiveSheet.Cells[spdCodeList.ActiveSheet.RowCount - 1, 0].BackColor = System.Drawing.Color.WhiteSmoke;
                        spdCodeList.ActiveSheet.RowCount++;
                    }
                }

                i = spdSublotLoss.ActiveSheet.ActiveRowIndex;
                s_sublot = MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(i, 1));

                SaveSublotListByLossReason(i, s_sublot);
            }

        }
        
        private void cdvGrade_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            spdSublotLoss.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;
            
        }
        
        private void spdSublotLoss_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {

            string s_cell_grade = string.Empty;
            if (b_load_sublot_list_flag == false)
            {
                return;
            }
            
            switch (e.Column)
            {
                case 2: //GRADE
                    
                    int i;
                    int i_scrap_count;
                    
                    if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 2].Value) == MPGC.MP_SUBLOT_SCRAP_GRADE)
                    {
                        int i_cell_count;
                        
                        s_cell_grade = MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Value);
                        i_cell_count = s_cell_grade.Length;
                        
                        s_cell_grade = "";
                        for (i = 0; i < i_cell_count; i++)
                        {
                            s_cell_grade = s_cell_grade + MPGC.MP_SUBLOT_SCRAP_GRADE;
                        }
                        
                        spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Value = s_cell_grade;
                        spdSublotLoss.ActiveSheet.Cells[e.Row, 7].Value = 0;
                        
                        b_load_sublot_list_flag = false;
                        
                        spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Locked = true;
                        spdSublotLoss.ActiveSheet.Cells[e.Row, 7].Locked = true;
                    }
                    else
                    {
                        b_load_sublot_list_flag = false;
                        
                        if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Value) == "")
                        {
                            spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Locked = true;
                            spdSublotLoss.ActiveSheet.Cells[e.Row, 7].Locked = false;
                        }
                        else
                        {
                            spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Locked = false;
                            spdSublotLoss.ActiveSheet.Cells[e.Row, 7].Locked = true;
                        }
                        
                        if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 2].Value) == MPGC.MP_SUBLOT_GOOD_GRADE)
                        {
                            /* Good Grade 로 변경되는 경우 Loss Code를 입력하도록 변경 */
                            /* 원래 Good 이었는데 다시 Good 으로 변경되는 경우도 Loss Code를 입력받고 */
                            /* Good 이 아니었는데 Good 으로 변경되는 경우 Loss Code를 지우지 않는다. */
                            //if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 2].Tag) == MPGC.MP_SUBLOT_GOOD_GRADE)
                            //{
                            //    spdSublotLoss.ActiveSheet.Cells[e.Row, 4].Value = "";
                            //}

                            if (spdCodeList.ActiveSheet.RowCount > 1)
                            {
                                spdCodeList.ActiveSheet.RemoveRows(0, spdCodeList.ActiveSheet.RowCount - 1);
                                SaveSublotListByLossReason(e.Row, MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(e.Row, 1)));
                                LoadSublotListByLossReason(e.Row, MPCF.Trim(spdSublotLoss.ActiveSheet.GetValue(e.Row, 1)));
                            }
                        }
                    }
                    
                    i_scrap_count = 0;
                    for (i = 0; i < spdSublotLoss.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[i, 2].Value) == MPGC.MP_SUBLOT_SCRAP_GRADE)
                        {
                            i_scrap_count++;
                        }
                    }
                    
                    txtOutQty1.Text = Convert.ToString(MPCF.ToDbl(txtQty1.Text) - i_scrap_count);
                    
                    b_load_sublot_list_flag = true;
                    break;
                    
                    
                case 4: //LOSS CODE
                    
                    if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 4].Value) == "")
                    {
                        if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 2].Tag) == MPGC.MP_SUBLOT_GOOD_GRADE)
                        {
                            spdSublotLoss.ActiveSheet.Cells[e.Row, 2].Value = MPGC.MP_SUBLOT_GOOD_GRADE;
                        }
                        else
                        {
                            spdSublotLoss.ActiveSheet.Cells[e.Row, 2].Value = "";
                        }
                    }
                    //else
                    //{
                    //    if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 2].Value) == MPGC.MP_SUBLOT_GOOD_GRADE)
                    //    {
                    //        if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 2].Tag) == MPGC.MP_SUBLOT_GOOD_GRADE)
                    //        {
                    //            spdSublotLoss.ActiveSheet.Cells[e.Row, 2].Value = "";
                    //        }
                    //    }
                    //}
                    break;
                    
                case 6: //CELL GRADE
                    
                    int i_not_scrap_count;
                    
                    s_cell_grade = MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Value);
                    i_not_scrap_count = 0;
                    for (i = 0; i < s_cell_grade.Length; i++)
                    {
                        if (s_cell_grade[i].ToString() != MPGC.MP_SUBLOT_SCRAP_GRADE)
                        {
                            i_not_scrap_count++;
                        }
                    }
                    
                    spdSublotLoss.ActiveSheet.Cells[e.Row, 7].Value = i_not_scrap_count;
                    break;
                    
                case 7: //QTY_2
                    
                    int i_qty_2;

                    i_qty_2 = MPCF.ToInt(spdSublotLoss.ActiveSheet.Cells[e.Row, 7].Tag);
                    
                    if (i_qty_2 < MPCF.ToDbl(spdSublotLoss.ActiveSheet.Cells[e.Row, 7].Value))
                    {
                        if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Value) == "")
                        {
                            spdSublotLoss.ActiveSheet.Cells[e.Row, 7].Value = spdSublotLoss.ActiveSheet.Cells[e.Row, 7].Tag;
                            return;
                        }
                        else
                        {
                            spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Value = spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Tag;
                            return;
                        }
                    }

                    if (MPCF.Trim(spdSublotLoss.ActiveSheet.Cells[e.Row, 6].Value) != "")
                    {
                        i_qty_2 = 0;
                        for (i = 0; i < spdSublotLoss.ActiveSheet.RowCount; i++)
                        {
                            i_qty_2 += MPCF.ToInt(spdSublotLoss.ActiveSheet.Cells[i, 7].Value);
                        }
                        txtOutQty2.Text = i_qty_2.ToString();
                    }
                    
                    break;
                    
            }
            
        }
        
        private void spdSublotLoss_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            if (e.Column == 6)
            {
                spdSublotLoss.EditModeReplace = false;
            }
            else
            {
                spdSublotLoss.EditModeReplace = true;
            }
        }
        
        private void txtOutQty1_TextChanged(System.Object sender, System.EventArgs e)
        {
            txtLossQty1.Text = Convert.ToString((MPCF.ToDbl(txtQty1.Text) - MPCF.ToDbl(txtOutQty1.Text)) * -1);
        }
        
        private void txtOutQty2_TextChanged(System.Object sender, System.EventArgs e)
        {
            txtLossQty2.Text = Convert.ToString((MPCF.ToDbl(txtQty2.Text) - MPCF.ToDbl(txtOutQty2.Text)) * -1);
        }

        private void txtOutQty3_TextChanged(System.Object sender, System.EventArgs e)
        {
            txtLossQty3.Text = Convert.ToString((MPCF.ToDbl(txtQty3.Text) - MPCF.ToDbl(txtOutQty3.Text)) * -1);
        }

        private void cdvCrrID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text != "")
            {
                SetCarrierSublotList(cdvCrrID.Text);
            }
#endif
        }
        
        private void cdvCrrID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text == "")
            {
                MPCF.ClearList(spdSublotLoss, true);
            }
#endif
        }

        private void txtUnit2Qty_AfterExitEditMode(object sender, EventArgs e)
        {
            if (b_exist_sublot_unit2 == true)
                return;

            UltraNumericEditor txtUnit2Qty = (UltraNumericEditor)sender;
            //if (MPCF.Trim(txtUnit2Qty.Value) == "" || MPCF.ToInt(txtUnit2Qty.Value) == 0)
            //    return;

            ArrayList controlUnit2Qty = null;
            ArrayList controlUnit2Code = null;
            int i;
            double d_unit2_loss;

            controlUnit2Qty = MPCF.GetIndexedControl("txtUnit2Qty", grpUnit2);
            controlUnit2Code = MPCF.GetIndexedControl("cdvUnit2Code", grpUnit2);

            d_unit2_loss = 0;
            for (i = 0; i < 10; i++)
            {
                if (((UltraNumericEditor)controlUnit2Qty[i]).Name == txtUnit2Qty.Name)
                {
                    if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit2Code[i]).Text) == "")
                    {
                        ((UltraNumericEditor)controlUnit2Qty[i]).Value = "";
                    }
                }

                d_unit2_loss += MPCF.ToDbl(((UltraNumericEditor)controlUnit2Qty[i]).Value);
            }

            txtOutQty2.Text = MPCF.ToInt(MPCF.ToDbl(txtQty2.Text) + d_unit2_loss).ToString();
        }

        private void txtUnit3Qty_AfterExitEditMode(object sender, EventArgs e)
        {
            if (b_exist_sublot_unit3 == true)
                return;

            UltraNumericEditor txtUnit3Qty = (UltraNumericEditor)sender;
            //if (MPCF.Trim(txtUnit3Qty.Value) == "" || MPCF.ToInt(txtUnit3Qty.Value) == 0)
            //    return;

            ArrayList controlUnit3Qty = null;
            ArrayList controlUnit3Code = null;
            int i;
            double d_unit3_loss;

            controlUnit3Qty = MPCF.GetIndexedControl("txtUnit3Qty", grpUnit3);
            controlUnit3Code = MPCF.GetIndexedControl("cdvUnit3Code", grpUnit3);

            d_unit3_loss = 0;
            for (i = 0; i < 10; i++)
            {
                if (((UltraNumericEditor)controlUnit3Qty[i]).Name == txtUnit3Qty.Name)
                {
                    if (MPCF.Trim(((Miracom.UI.Controls.MCCodeView.MCCodeView)controlUnit3Code[i]).Text) == "")
                    {
                        ((UltraNumericEditor)controlUnit3Qty[i]).Value = "";
                    }
                }

                d_unit3_loss += MPCF.ToDbl(((UltraNumericEditor)controlUnit3Qty[i]).Value);
            }

            txtOutQty3.Text = MPCF.ToInt(MPCF.ToDbl(txtQty3.Text) + d_unit3_loss).ToString();
        }

    }
    
}
