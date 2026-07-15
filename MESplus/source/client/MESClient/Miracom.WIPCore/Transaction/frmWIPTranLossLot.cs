
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranLossLot.vb
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
//       - 2004-06-23 : Created by WKIM
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
    public class frmWIPTranLossLot : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranLossLot()
        {
            
            
            InitializeComponent();

            this.tabTran.TabPages.Remove(this.tbpCMF);
            this.tabTran.Controls.Add(this.tbpCMF);
            
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
        private System.Windows.Forms.TextBox txtOutQty3;
        private System.Windows.Forms.TextBox txtOutQty2;
        private System.Windows.Forms.TextBox txtOutQty1;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.Label lblOutQty3;
        private System.Windows.Forms.Label lblOutQty2;
        private System.Windows.Forms.Label lblOutQty1;
        private System.Windows.Forms.Label lblQty3;
        private System.Windows.Forms.Label lblQty2;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.Panel pnlUnitMid;
        private System.Windows.Forms.TabPage tbpInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private CheckBox chkNoAutoTermLot;
        private Panel pnlUnit1;
        private FarPoint.Win.Spread.FpSpread spdUnit1;
        private FarPoint.Win.Spread.SheetView spdUnit1_Sheet1;
        private Panel pnlUnit2;
        private FarPoint.Win.Spread.FpSpread spdUnit2;
        private FarPoint.Win.Spread.SheetView spdUnit2_Sheet1;
        private Panel pnlUnit3;
        private FarPoint.Win.Spread.FpSpread spdUnit3;
        private FarPoint.Win.Spread.SheetView spdUnit3_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvCode;
        private TextBox txtLossQty3;
        private TextBox txtLossQty2;
        private TextBox txtLossQty1;
        private Label lblLossQty3;
        private Label lblLossQty2;
        private Label lblLossQty1;
        private System.Windows.Forms.Label lblCrrID;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer5 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer5 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer6 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer6 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer7 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle9 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle10 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle11 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer3 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle12 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType3 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer8 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
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
            this.pnlUnit3 = new System.Windows.Forms.Panel();
            this.spdUnit3 = new FarPoint.Win.Spread.FpSpread();
            this.spdUnit3_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlUnit2 = new System.Windows.Forms.Panel();
            this.spdUnit2 = new FarPoint.Win.Spread.FpSpread();
            this.spdUnit2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlUnit1 = new System.Windows.Forms.Panel();
            this.spdUnit1 = new FarPoint.Win.Spread.FpSpread();
            this.spdUnit1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlUnitTop = new System.Windows.Forms.Panel();
            this.grpQty = new System.Windows.Forms.GroupBox();
            this.txtLossQty3 = new System.Windows.Forms.TextBox();
            this.txtLossQty2 = new System.Windows.Forms.TextBox();
            this.txtLossQty1 = new System.Windows.Forms.TextBox();
            this.lblLossQty3 = new System.Windows.Forms.Label();
            this.lblLossQty2 = new System.Windows.Forms.Label();
            this.lblLossQty1 = new System.Windows.Forms.Label();
            this.txtOutQty3 = new System.Windows.Forms.TextBox();
            this.txtOutQty2 = new System.Windows.Forms.TextBox();
            this.txtOutQty1 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblOutQty3 = new System.Windows.Forms.Label();
            this.lblOutQty2 = new System.Windows.Forms.Label();
            this.lblOutQty1 = new System.Windows.Forms.Label();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.cdvCode = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
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
            this.pnlUnit3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit3_Sheet1)).BeginInit();
            this.pnlUnit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit2_Sheet1)).BeginInit();
            this.pnlUnit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit1_Sheet1)).BeginInit();
            this.pnlUnitTop.SuspendLayout();
            this.grpQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCode)).BeginInit();
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
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
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
            this.pnlBottom.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Loss Lot";
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
            columnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer5.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer5.Name = "columnHeaderRenderer5";
            columnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer5.TextRotationAngle = 0D;
            rowHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer5.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer5.Name = "rowHeaderRenderer5";
            rowHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer5.TextRotationAngle = 0D;
            columnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer6.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer6.Name = "columnHeaderRenderer6";
            columnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer6.TextRotationAngle = 0D;
            rowHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer6.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer6.Name = "rowHeaderRenderer6";
            rowHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer6.TextRotationAngle = 0D;
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
            this.pnlUnitMid.Controls.Add(this.pnlUnit3);
            this.pnlUnitMid.Controls.Add(this.pnlUnit2);
            this.pnlUnitMid.Controls.Add(this.pnlUnit1);
            this.pnlUnitMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnitMid.Location = new System.Drawing.Point(0, 100);
            this.pnlUnitMid.Name = "pnlUnitMid";
            this.pnlUnitMid.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlUnitMid.Size = new System.Drawing.Size(728, 322);
            this.pnlUnitMid.TabIndex = 2;
            // 
            // pnlUnit3
            // 
            this.pnlUnit3.Controls.Add(this.spdUnit3);
            this.pnlUnit3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUnit3.Location = new System.Drawing.Point(485, 5);
            this.pnlUnit3.Name = "pnlUnit3";
            this.pnlUnit3.Padding = new System.Windows.Forms.Padding(3);
            this.pnlUnit3.Size = new System.Drawing.Size(240, 314);
            this.pnlUnit3.TabIndex = 5;
            // 
            // spdUnit3
            // 
            this.spdUnit3.AccessibleDescription = "spdUnit3, Sheet1, Row 0, Column 0, ";
            this.spdUnit3.BackColor = System.Drawing.SystemColors.Control;
            this.spdUnit3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdUnit3.EditModePermanent = true;
            this.spdUnit3.EditModeReplace = true;
            this.spdUnit3.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdUnit3.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit3.HorizontalScrollBar.Name = "";
            this.spdUnit3.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdUnit3.HorizontalScrollBar.TabIndex = 22;
            this.spdUnit3.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUnit3.Location = new System.Drawing.Point(3, 3);
            this.spdUnit3.Name = "spdUnit3";
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
            this.spdUnit3.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdUnit3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdUnit3.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdUnit3_Sheet1});
            this.spdUnit3.Size = new System.Drawing.Size(234, 308);
            this.spdUnit3.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdUnit3.TabIndex = 0;
            this.spdUnit3.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit3.VerticalScrollBar.Name = "";
            this.spdUnit3.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdUnit3.VerticalScrollBar.TabIndex = 23;
            this.spdUnit3.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUnit3.EditModeOff += new System.EventHandler(this.spdUnit_EditModeOff);
            this.spdUnit3.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdUnit1_ButtonClicked);
            // 
            // spdUnit3_Sheet1
            // 
            this.spdUnit3_Sheet1.Reset();
            spdUnit3_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdUnit3_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdUnit3_Sheet1.ColumnCount = 4;
            spdUnit3_Sheet1.RowCount = 1;
            this.spdUnit3_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit3_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit3_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit3_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit3_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdUnit3_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Unit 3 Code";
            this.spdUnit3_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Qty";
            this.spdUnit3_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "No Scrap";
            this.spdUnit3_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit3_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit3_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.spdUnit3_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdUnit3_Sheet1.Columns.Get(0).Label = "Unit 3 Code";
            this.spdUnit3_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit3_Sheet1.Columns.Get(0).Width = 80F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdUnit3_Sheet1.Columns.Get(1).CellType = buttonCellType1;
            this.spdUnit3_Sheet1.Columns.Get(1).Width = 24F;
            numberCellType1.DecimalPlaces = 3;
            numberCellType1.MaximumValue = 9999999.999D;
            numberCellType1.MinimumValue = -9999999.999D;
            this.spdUnit3_Sheet1.Columns.Get(2).CellType = numberCellType1;
            this.spdUnit3_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdUnit3_Sheet1.Columns.Get(2).Label = "Qty";
            this.spdUnit3_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit3_Sheet1.Columns.Get(3).CellType = checkBoxCellType1;
            this.spdUnit3_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdUnit3_Sheet1.Columns.Get(3).Label = "No Scrap";
            this.spdUnit3_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit3_Sheet1.Columns.Get(3).Width = 35F;
            this.spdUnit3_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdUnit3_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdUnit3_Sheet1.RowHeader.Columns.Get(0).Width = 30F;
            this.spdUnit3_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit3_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdUnit3_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit3_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit3_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlUnit2
            // 
            this.pnlUnit2.Controls.Add(this.spdUnit2);
            this.pnlUnit2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUnit2.Location = new System.Drawing.Point(244, 5);
            this.pnlUnit2.Name = "pnlUnit2";
            this.pnlUnit2.Padding = new System.Windows.Forms.Padding(3);
            this.pnlUnit2.Size = new System.Drawing.Size(241, 314);
            this.pnlUnit2.TabIndex = 4;
            // 
            // spdUnit2
            // 
            this.spdUnit2.AccessibleDescription = "spdUnit2, Sheet1, Row 0, Column 0, ";
            this.spdUnit2.BackColor = System.Drawing.SystemColors.Control;
            this.spdUnit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdUnit2.EditModePermanent = true;
            this.spdUnit2.EditModeReplace = true;
            this.spdUnit2.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdUnit2.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit2.HorizontalScrollBar.Name = "";
            this.spdUnit2.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdUnit2.HorizontalScrollBar.TabIndex = 22;
            this.spdUnit2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUnit2.Location = new System.Drawing.Point(3, 3);
            this.spdUnit2.Name = "spdUnit2";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.Renderer = columnHeaderRenderer5;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = rowHeaderRenderer5;
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
            this.spdUnit2.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdUnit2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdUnit2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdUnit2_Sheet1});
            this.spdUnit2.Size = new System.Drawing.Size(235, 308);
            this.spdUnit2.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdUnit2.TabIndex = 0;
            this.spdUnit2.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit2.VerticalScrollBar.Name = "";
            this.spdUnit2.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdUnit2.VerticalScrollBar.TabIndex = 23;
            this.spdUnit2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUnit2.EditModeOff += new System.EventHandler(this.spdUnit_EditModeOff);
            this.spdUnit2.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdUnit1_ButtonClicked);
            // 
            // spdUnit2_Sheet1
            // 
            this.spdUnit2_Sheet1.Reset();
            spdUnit2_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdUnit2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdUnit2_Sheet1.ColumnCount = 4;
            spdUnit2_Sheet1.RowCount = 1;
            this.spdUnit2_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit2_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit2_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit2_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit2_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdUnit2_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Unit 2 Code";
            this.spdUnit2_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Qty";
            this.spdUnit2_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "No Scrap";
            this.spdUnit2_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit2_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit2_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.spdUnit2_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdUnit2_Sheet1.Columns.Get(0).Label = "Unit 2 Code";
            this.spdUnit2_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit2_Sheet1.Columns.Get(0).Width = 80F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdUnit2_Sheet1.Columns.Get(1).CellType = buttonCellType2;
            this.spdUnit2_Sheet1.Columns.Get(1).Width = 24F;
            numberCellType2.DecimalPlaces = 3;
            numberCellType2.MaximumValue = 9999999.999D;
            numberCellType2.MinimumValue = -9999999.999D;
            this.spdUnit2_Sheet1.Columns.Get(2).CellType = numberCellType2;
            this.spdUnit2_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdUnit2_Sheet1.Columns.Get(2).Label = "Qty";
            this.spdUnit2_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit2_Sheet1.Columns.Get(3).CellType = checkBoxCellType2;
            this.spdUnit2_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdUnit2_Sheet1.Columns.Get(3).Label = "No Scrap";
            this.spdUnit2_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit2_Sheet1.Columns.Get(3).Width = 35F;
            this.spdUnit2_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdUnit2_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdUnit2_Sheet1.RowHeader.Columns.Get(0).Width = 30F;
            this.spdUnit2_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit2_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdUnit2_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit2_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlUnit1
            // 
            this.pnlUnit1.Controls.Add(this.spdUnit1);
            this.pnlUnit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUnit1.Location = new System.Drawing.Point(3, 5);
            this.pnlUnit1.Name = "pnlUnit1";
            this.pnlUnit1.Padding = new System.Windows.Forms.Padding(3);
            this.pnlUnit1.Size = new System.Drawing.Size(241, 314);
            this.pnlUnit1.TabIndex = 3;
            // 
            // spdUnit1
            // 
            this.spdUnit1.AccessibleDescription = "spdUnit1, Sheet1, Row 0, Column 0, ";
            this.spdUnit1.BackColor = System.Drawing.SystemColors.Control;
            this.spdUnit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdUnit1.EditModePermanent = true;
            this.spdUnit1.EditModeReplace = true;
            this.spdUnit1.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdUnit1.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit1.HorizontalScrollBar.Name = "";
            this.spdUnit1.HorizontalScrollBar.Renderer = defaultScrollBarRenderer7;
            this.spdUnit1.HorizontalScrollBar.TabIndex = 28;
            this.spdUnit1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUnit1.Location = new System.Drawing.Point(3, 3);
            this.spdUnit1.Name = "spdUnit1";
            namedStyle9.BackColor = System.Drawing.SystemColors.Control;
            namedStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle9.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle9.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle9.Renderer = columnHeaderRenderer6;
            namedStyle9.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle10.BackColor = System.Drawing.SystemColors.Control;
            namedStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle10.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle10.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle10.Renderer = rowHeaderRenderer6;
            namedStyle10.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle11.BackColor = System.Drawing.SystemColors.Control;
            namedStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle11.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle11.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle11.Renderer = cornerRenderer3;
            namedStyle11.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle12.BackColor = System.Drawing.SystemColors.Window;
            namedStyle12.CellType = generalCellType3;
            namedStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle12.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle12.Renderer = generalCellType3;
            this.spdUnit1.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle9,
            namedStyle10,
            namedStyle11,
            namedStyle12});
            this.spdUnit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdUnit1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdUnit1_Sheet1});
            this.spdUnit1.Size = new System.Drawing.Size(235, 308);
            this.spdUnit1.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdUnit1.TabIndex = 0;
            this.spdUnit1.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit1.VerticalScrollBar.Name = "";
            this.spdUnit1.VerticalScrollBar.Renderer = defaultScrollBarRenderer8;
            this.spdUnit1.VerticalScrollBar.TabIndex = 29;
            this.spdUnit1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUnit1.EditModeOff += new System.EventHandler(this.spdUnit_EditModeOff);
            this.spdUnit1.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdUnit1_ButtonClicked);
            // 
            // spdUnit1_Sheet1
            // 
            this.spdUnit1_Sheet1.Reset();
            spdUnit1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdUnit1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdUnit1_Sheet1.ColumnCount = 4;
            spdUnit1_Sheet1.RowCount = 1;
            this.spdUnit1_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit1_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit1_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit1_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit1_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdUnit1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Unit 1 Code";
            this.spdUnit1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Qty";
            this.spdUnit1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "No Scrap";
            this.spdUnit1_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit1_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.spdUnit1_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdUnit1_Sheet1.Columns.Get(0).Label = "Unit 1 Code";
            this.spdUnit1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit1_Sheet1.Columns.Get(0).Width = 80F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdUnit1_Sheet1.Columns.Get(1).CellType = buttonCellType3;
            this.spdUnit1_Sheet1.Columns.Get(1).Width = 24F;
            numberCellType3.DecimalPlaces = 3;
            numberCellType3.MaximumValue = 9999999.999D;
            numberCellType3.MinimumValue = -9999999.999D;
            this.spdUnit1_Sheet1.Columns.Get(2).CellType = numberCellType3;
            this.spdUnit1_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdUnit1_Sheet1.Columns.Get(2).Label = "Qty";
            this.spdUnit1_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit1_Sheet1.Columns.Get(3).CellType = checkBoxCellType3;
            this.spdUnit1_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdUnit1_Sheet1.Columns.Get(3).Label = "No Scrap";
            this.spdUnit1_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit1_Sheet1.Columns.Get(3).Width = 35F;
            this.spdUnit1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdUnit1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdUnit1_Sheet1.RowHeader.Columns.Get(0).Width = 30F;
            this.spdUnit1_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdUnit1_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit1_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlUnitTop
            // 
            this.pnlUnitTop.Controls.Add(this.grpQty);
            this.pnlUnitTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUnitTop.Location = new System.Drawing.Point(0, 0);
            this.pnlUnitTop.Name = "pnlUnitTop";
            this.pnlUnitTop.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlUnitTop.Size = new System.Drawing.Size(728, 100);
            this.pnlUnitTop.TabIndex = 1;
            // 
            // grpQty
            // 
            this.grpQty.Controls.Add(this.txtLossQty3);
            this.grpQty.Controls.Add(this.txtLossQty2);
            this.grpQty.Controls.Add(this.txtLossQty1);
            this.grpQty.Controls.Add(this.lblLossQty3);
            this.grpQty.Controls.Add(this.lblLossQty2);
            this.grpQty.Controls.Add(this.lblLossQty1);
            this.grpQty.Controls.Add(this.txtOutQty3);
            this.grpQty.Controls.Add(this.txtOutQty2);
            this.grpQty.Controls.Add(this.txtOutQty1);
            this.grpQty.Controls.Add(this.txtQty2);
            this.grpQty.Controls.Add(this.txtQty1);
            this.grpQty.Controls.Add(this.lblOutQty3);
            this.grpQty.Controls.Add(this.lblOutQty2);
            this.grpQty.Controls.Add(this.lblOutQty1);
            this.grpQty.Controls.Add(this.lblQty3);
            this.grpQty.Controls.Add(this.lblQty2);
            this.grpQty.Controls.Add(this.lblQty1);
            this.grpQty.Controls.Add(this.txtQty3);
            this.grpQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpQty.Location = new System.Drawing.Point(3, 3);
            this.grpQty.Name = "grpQty";
            this.grpQty.Size = new System.Drawing.Size(722, 97);
            this.grpQty.TabIndex = 0;
            this.grpQty.TabStop = false;
            // 
            // txtLossQty3
            // 
            this.txtLossQty3.Location = new System.Drawing.Point(334, 64);
            this.txtLossQty3.MaxLength = 11;
            this.txtLossQty3.Name = "txtLossQty3";
            this.txtLossQty3.ReadOnly = true;
            this.txtLossQty3.Size = new System.Drawing.Size(117, 20);
            this.txtLossQty3.TabIndex = 11;
            this.txtLossQty3.TabStop = false;
            // 
            // txtLossQty2
            // 
            this.txtLossQty2.Location = new System.Drawing.Point(334, 40);
            this.txtLossQty2.MaxLength = 11;
            this.txtLossQty2.Name = "txtLossQty2";
            this.txtLossQty2.ReadOnly = true;
            this.txtLossQty2.Size = new System.Drawing.Size(117, 20);
            this.txtLossQty2.TabIndex = 9;
            this.txtLossQty2.TabStop = false;
            // 
            // txtLossQty1
            // 
            this.txtLossQty1.Location = new System.Drawing.Point(334, 16);
            this.txtLossQty1.MaxLength = 11;
            this.txtLossQty1.Name = "txtLossQty1";
            this.txtLossQty1.ReadOnly = true;
            this.txtLossQty1.Size = new System.Drawing.Size(117, 20);
            this.txtLossQty1.TabIndex = 7;
            this.txtLossQty1.TabStop = false;
            // 
            // lblLossQty3
            // 
            this.lblLossQty3.AutoSize = true;
            this.lblLossQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLossQty3.Location = new System.Drawing.Point(271, 67);
            this.lblLossQty3.Name = "lblLossQty3";
            this.lblLossQty3.Size = new System.Drawing.Size(57, 13);
            this.lblLossQty3.TabIndex = 10;
            this.lblLossQty3.Text = "Loss Qty 3";
            // 
            // lblLossQty2
            // 
            this.lblLossQty2.AutoSize = true;
            this.lblLossQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLossQty2.Location = new System.Drawing.Point(271, 43);
            this.lblLossQty2.Name = "lblLossQty2";
            this.lblLossQty2.Size = new System.Drawing.Size(57, 13);
            this.lblLossQty2.TabIndex = 8;
            this.lblLossQty2.Text = "Loss Qty 2";
            // 
            // lblLossQty1
            // 
            this.lblLossQty1.AutoSize = true;
            this.lblLossQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLossQty1.Location = new System.Drawing.Point(271, 19);
            this.lblLossQty1.Name = "lblLossQty1";
            this.lblLossQty1.Size = new System.Drawing.Size(57, 13);
            this.lblLossQty1.TabIndex = 6;
            this.lblLossQty1.Text = "Loss Qty 1";
            // 
            // txtOutQty3
            // 
            this.txtOutQty3.Location = new System.Drawing.Point(569, 64);
            this.txtOutQty3.MaxLength = 11;
            this.txtOutQty3.Name = "txtOutQty3";
            this.txtOutQty3.ReadOnly = true;
            this.txtOutQty3.Size = new System.Drawing.Size(117, 20);
            this.txtOutQty3.TabIndex = 17;
            this.txtOutQty3.TabStop = false;
            // 
            // txtOutQty2
            // 
            this.txtOutQty2.Location = new System.Drawing.Point(569, 40);
            this.txtOutQty2.MaxLength = 11;
            this.txtOutQty2.Name = "txtOutQty2";
            this.txtOutQty2.ReadOnly = true;
            this.txtOutQty2.Size = new System.Drawing.Size(117, 20);
            this.txtOutQty2.TabIndex = 15;
            this.txtOutQty2.TabStop = false;
            // 
            // txtOutQty1
            // 
            this.txtOutQty1.Location = new System.Drawing.Point(569, 16);
            this.txtOutQty1.MaxLength = 11;
            this.txtOutQty1.Name = "txtOutQty1";
            this.txtOutQty1.ReadOnly = true;
            this.txtOutQty1.Size = new System.Drawing.Size(117, 20);
            this.txtOutQty1.TabIndex = 13;
            this.txtOutQty1.TabStop = false;
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
            // lblOutQty3
            // 
            this.lblOutQty3.AutoSize = true;
            this.lblOutQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty3.Location = new System.Drawing.Point(506, 67);
            this.lblOutQty3.Name = "lblOutQty3";
            this.lblOutQty3.Size = new System.Drawing.Size(52, 13);
            this.lblOutQty3.TabIndex = 16;
            this.lblOutQty3.Text = "Out Qty 3";
            // 
            // lblOutQty2
            // 
            this.lblOutQty2.AutoSize = true;
            this.lblOutQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty2.Location = new System.Drawing.Point(506, 43);
            this.lblOutQty2.Name = "lblOutQty2";
            this.lblOutQty2.Size = new System.Drawing.Size(52, 13);
            this.lblOutQty2.TabIndex = 14;
            this.lblOutQty2.Text = "Out Qty 2";
            // 
            // lblOutQty1
            // 
            this.lblOutQty1.AutoSize = true;
            this.lblOutQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty1.Location = new System.Drawing.Point(506, 19);
            this.lblOutQty1.Name = "lblOutQty1";
            this.lblOutQty1.Size = new System.Drawing.Size(52, 13);
            this.lblOutQty1.TabIndex = 12;
            this.lblOutQty1.Text = "Out Qty 1";
            // 
            // lblQty3
            // 
            this.lblQty3.AutoSize = true;
            this.lblQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty3.Location = new System.Drawing.Point(37, 67);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(32, 13);
            this.lblQty3.TabIndex = 4;
            this.lblQty3.Text = "Qty 3";
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
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(100, 64);
            this.txtQty3.MaxLength = 11;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(115, 20);
            this.txtQty3.TabIndex = 5;
            this.txtQty3.TabStop = false;
            // 
            // cdvCode
            // 
            this.cdvCode.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvCode.Location = new System.Drawing.Point(312, 17);
            this.cdvCode.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCode.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCode.Name = "cdvGrade";
            this.cdvCode.Size = new System.Drawing.Size(20, 20);
            this.cdvCode.SmallImageList = null;
            this.cdvCode.TabIndex = 0;
            this.cdvCode.TabStop = false;
            this.cdvCode.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvCode.Visible = false;
            this.cdvCode.VisibleColumnHeader = false;
            this.cdvCode.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvCode_SelectedItemChanged);
            // 
            // frmWIPTranLossLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranLossLot";
            this.Text = "Loss Lot";
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
            this.pnlUnit3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit3_Sheet1)).EndInit();
            this.pnlUnit2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit2_Sheet1)).EndInit();
            this.pnlUnit1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit1_Sheet1)).EndInit();
            this.pnlUnitTop.ResumeLayout(false);
            this.grpQty.ResumeLayout(false);
            this.grpQty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCode)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private string s_loss_table = "";
        
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
            MPCF.FieldClear(this, txtLotID);

            spdUnit1.ActiveSheet.RowCount = 0;
            spdUnit2.ActiveSheet.RowCount = 0;
            spdUnit3.ActiveSheet.RowCount = 0;

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (MPGO.ProcessZeroQtyLot() == true)
                chkNoAutoTermLot.Checked = true;

            if (View_Operation() == false) return false;

            cdvResID.Text = LOT.GetString("START_RES_ID");
            
            txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
            txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
            
            txtOutQty1.Text = txtQty1.Text;
            txtOutQty2.Text = txtQty2.Text;
            txtOutQty3.Text = txtQty3.Text;

#if _CRR
            cdvCrrID.Init();
            cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            if (RASLIST.ViewCarrierList(cdvCrrID.GetListView, txtLotID.Text) == false) return false;
#endif
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
                        ClearLotSpread();
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

            ////// Multi Carrier 를 지원하므로 Carrier 를 입력 안할수도 있다.
            ////#if _CRR
            ////if (cdvCrrID.GetListView.Items.Count > 0)
            ////{
            ////    if (cdvCrrID.Text == "")
            ////    {
            ////        MPCF.ShowMsgBox(MPCF.GetMessage(108));
            ////        tabTran.SelectedTab = tbpGeneral;
            ////        cdvCrrID.Focus();
            ////        return false;
            ////    }
            ////}
            ////#endif

            //if (MPCF.ToDbl(txtLossQty1.Text) <= 0 && MPCF.ToDbl(txtLossQty2.Text) <= 0 && MPCF.ToDbl(txtLossQty3.Text) <= 0)
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(107));
            //    tabTran.SelectedTab = tbpInfo;
            //    return false;
            //}
            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
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

            s_loss_table = "";
            s_loss_table = MPCR.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOSS_TBL_DEF);
            if (s_loss_table == "")
            {
                s_loss_table = out_node.GetString("LOSS_TBL");
            }

            if (s_loss_table == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(247));
                return false;
            }

            if (out_node.GetString("UNIT_1") != "")
            {
                spdUnit1.Visible = true;
                spdUnit1.ActiveSheet.RowCount = 1;
            }
            else
            {
                spdUnit1.Visible = false;
                txtOutQty1.Text = "0";
            }
            if (out_node.GetString("UNIT_2") != "")
            {
                spdUnit2.Visible = true;
                spdUnit2.ActiveSheet.RowCount = 1;
            }
            else
            {
                spdUnit2.Visible = false;
                txtOutQty2.Text = "0";
            }
            if (out_node.GetString("UNIT_3") != "")
            {
                spdUnit3.Visible = true;
                spdUnit3.ActiveSheet.RowCount = 1;
            }
            else
            {
                spdUnit3.Visible = false;
                txtOutQty3.Text = "0";
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
        private bool Loss_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("LOSS_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode loss_item;

            string s_code;
            double d_qty;
            bool b_no_scrap_flag;
            int i;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

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
                for (i = 0; i < spdUnit1.ActiveSheet.RowCount; i++)
                {
                    s_code = MPCF.Trim(spdUnit1.ActiveSheet.GetValue(i, 0));
                    d_qty = MPCF.ToDbl(spdUnit1.ActiveSheet.GetValue(i, 2));

                    b_no_scrap_flag = false;
                    if(spdUnit1.ActiveSheet.GetValue(i, 3) != null)
                    {
                        b_no_scrap_flag = Convert.ToBoolean(spdUnit1.ActiveSheet.GetValue(i, 3));
                    }

                    if (s_code != "" && d_qty != 0)
                    {
                        loss_item = in_node.AddNode("UNIT1");

                        loss_item.AddString("CODE", s_code);
                        loss_item.AddDouble("QTY", d_qty);
                        loss_item.AddChar("NO_SCRAP_FLAG", (b_no_scrap_flag == true ? 'Y' : ' '));
                    }
                }

                for (i = 0; i < spdUnit2.ActiveSheet.RowCount; i++)
                {
                    s_code = MPCF.Trim(spdUnit2.ActiveSheet.GetValue(i, 0));
                    d_qty = MPCF.ToDbl(spdUnit2.ActiveSheet.GetValue(i, 2));

                    b_no_scrap_flag = false;
                    if (spdUnit2.ActiveSheet.GetValue(i, 3) != null)
                    {
                        b_no_scrap_flag = Convert.ToBoolean(spdUnit2.ActiveSheet.GetValue(i, 3));
                    }

                    if (s_code != "" && d_qty != 0)
                    {
                        loss_item = in_node.AddNode("UNIT2");

                        loss_item.AddString("CODE", s_code);
                        loss_item.AddDouble("QTY", d_qty);
                        loss_item.AddChar("NO_SCRAP_FLAG", (b_no_scrap_flag == true ? 'Y' : ' '));
                    }
                }

                for (i = 0; i < spdUnit3.ActiveSheet.RowCount; i++)
                {
                    s_code = MPCF.Trim(spdUnit3.ActiveSheet.GetValue(i, 0));
                    d_qty = MPCF.ToDbl(spdUnit3.ActiveSheet.GetValue(i, 2));

                    b_no_scrap_flag = false;
                    if (spdUnit3.ActiveSheet.GetValue(i, 3) != null)
                    {
                        b_no_scrap_flag = Convert.ToBoolean(spdUnit3.ActiveSheet.GetValue(i, 3));
                    }

                    if (s_code != "" && d_qty != 0)
                    {
                        loss_item = in_node.AddNode("UNIT3");

                        loss_item.AddString("CODE", s_code);
                        loss_item.AddDouble("QTY", d_qty);
                        loss_item.AddChar("NO_SCRAP_FLAG", (b_no_scrap_flag == true ? 'Y' : ' '));
                    }
                }

                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddString("LOSS_COMMENT", MPCF.Trim(txtLossComment.Text));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_Loss_Lot", in_node, ref out_node) == false)
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
        
        private void cdvUnitCode_ButtonPress(object sender, System.EventArgs e)
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

                cdvCauseRes.Init();
                cdvCauseRes.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvCauseRes.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseRes.SelectedSubItemIndex = 0;

                if (cdvCauseOper.Text == "")
                {
                    if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (RASLIST.ViewResourceList(cdvCauseRes.GetListView, "%", 0, cdvCauseFlow.Text, cdvCauseOper.Text, false) == false)
                    {
                        return;
                    }
                }
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
                if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
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
                
                if (WIPLIST.ViewFlowList(cdvCauseFlow.GetListView, '1', "", 0, "", null, "") == false)
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
                
                cdvCauseOper.Init();
                cdvCauseOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvCauseOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseOper.SelectedSubItemIndex = 0;

                if (cdvCauseFlow.Text == "")
                {
                    if (WIPLIST.ViewOperationList(cdvCauseOper.GetListView, '1') == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (WIPLIST.ViewOperationList(cdvCauseOper.GetListView, '2', cdvCauseFlow.Text) == false)
                    {
                        return;
                    }
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
                if (Loss_Lot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_LOSS, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'A') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdUnit1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread spdUnit;
            string s_code;
            int i_code_index;
            int i;

            spdUnit = (FarPoint.Win.Spread.FpSpread)sender;

            if (e.Column == 1)
            {
                cdvCode.Tag = null;

                cdvCode.Init();
                cdvCode.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvCode.GetListView);
                cdvCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvCode.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                cdvCode.Columns.Add("Reusable", 50, HorizontalAlignment.Left);
                BASLIST.ViewGCMDataList(cdvCode.GetListView, '1', s_loss_table);

                if (cdvCode.Items.Count > 0)
                {
                    for (i = 0; i < spdUnit.ActiveSheet.RowCount; i++)
                    {
                        s_code = MPCF.Trim(spdUnit.ActiveSheet.GetValue(i, 0));
                        if (s_code != "")
                        {
                            i_code_index = MPCF.FindListItemIndex(cdvCode.GetListView, s_code, true);
                            if (i_code_index >= 0)
                            {
                                cdvCode.Items.RemoveAt(i_code_index);
                            }
                        }
                    }

                    if (cdvCode.Items.Count > 0)
                    {
                        if (cdvCode.ShowPopupList(e.Row, e.Column) == false)
                        {
                            return;
                        }

                        cdvCode.Tag = sender;
                    }
                }
            }
            else if (e.Column == 3)
            {
                if (spdUnit.ActiveSheet.Cells[e.Row, e.Column].Value != spdUnit.ActiveSheet.Cells[e.Row, e.Column].Tag)
                {
                    spdUnit_EditModeOff(sender, null);
                    spdUnit.ActiveSheet.Cells[e.Row, e.Column].Tag = spdUnit.ActiveSheet.Cells[e.Row, e.Column].Value;
                }
            }
        }

        private void cdvCode_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            if (cdvCode.Tag == null) return;

            FarPoint.Win.Spread.FpSpread spdUnit = (FarPoint.Win.Spread.FpSpread)cdvCode.Tag;

            spdUnit.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;
            spdUnit.ActiveSheet.Cells[e.Row, 3].Value = false;
            if (MPCF.Trim(e.SelectedItem.SubItems[2].Text) == "N")
            {
                spdUnit.ActiveSheet.Cells[e.Row, 3].Value = true;
            }
            spdUnit_EditModeOff(spdUnit, null);
        }

        private void spdUnit_EditModeOff(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.FpSpread spdUnit;
            double d_total_qty;
            int i;
            int i_row;

            spdUnit = (FarPoint.Win.Spread.FpSpread)sender;

            i_row = spdUnit.ActiveSheet.ActiveRowIndex;

            if (spdUnit.ActiveSheet.ActiveColumnIndex == 1 || spdUnit.ActiveSheet.ActiveColumnIndex == 2 || spdUnit.ActiveSheet.ActiveColumnIndex == 3)
            {
                if (MPCF.Trim(spdUnit.ActiveSheet.GetValue(i_row, 0)) == "")
                {
                    spdUnit.ActiveSheet.SetValue(i_row, 2, null);
                    return;
                }

                d_total_qty = 0;

                for (i = 0; i < spdUnit.ActiveSheet.RowCount; i++)
                {
                    if (spdUnit.ActiveSheet.Cells[i, 3].Value == null || Convert.ToBoolean(spdUnit.ActiveSheet.Cells[i, 3].Value) == false)
                    {
                        d_total_qty += MPCF.ToDbl(spdUnit.ActiveSheet.GetValue(i, 2));
                    }
                }

                if (spdUnit.Name == "spdUnit1")
                {
                    if (MPCF.ToDbl(txtQty1.Text) - d_total_qty < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(198));
                        spdUnit.ActiveSheet.SetValue(i_row, 2, null);
                        return;
                    }

                    txtLossQty1.Text = d_total_qty.ToString("######,##0.###");
                    txtOutQty1.Text = ((double)(MPCF.ToDbl(txtQty1.Text) - d_total_qty)).ToString("######,##0.###");
                }
                else if (spdUnit.Name == "spdUnit2")
                {
                    if (MPCF.ToDbl(txtQty2.Text)- d_total_qty < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(198));
                        spdUnit.ActiveSheet.SetValue(i_row, 2, null);
                        return;
                    }

                    txtLossQty2.Text = d_total_qty.ToString("######,##0.###");
                    txtOutQty2.Text = ((double)(MPCF.ToDbl(txtQty2.Text) - d_total_qty)).ToString("######,##0.###");
                }
                else if (spdUnit.Name == "spdUnit3")
                {
                    if (MPCF.ToDbl(txtQty3.Text) - d_total_qty < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(198));
                        spdUnit.ActiveSheet.SetValue(i_row, 2, null);
                        return;
                    }

                    txtLossQty3.Text = d_total_qty.ToString("######,##0.###");
                    txtOutQty3.Text = ((double)(MPCF.ToDbl(txtQty3.Text) - d_total_qty)).ToString("######,##0.###");
                }

                if (i_row == spdUnit.ActiveSheet.RowCount - 1)
                {
                    spdUnit.ActiveSheet.RowCount++;
                }
            }
        }
        
    }
    
}

