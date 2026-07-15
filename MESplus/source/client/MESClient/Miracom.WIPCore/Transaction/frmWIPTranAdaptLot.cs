
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranAdaptLot.vb
//   Description : Adapt Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - View_Operation() : View Operation Information
//       - View_Lot() : View Lot Information
//       - Adapt_Lot() : Adapt Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-23 : Created by CM Koo
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
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPTranAdaptLot : Miracom.MESCore.TranForm05
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranAdaptLot()
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
        



        private System.Windows.Forms.GroupBox grpAdapt;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label lblOrderID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvShipCode;
        private System.Windows.Forms.Label lblShipCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotType;
        private System.Windows.Forms.Label lblLotType;
        private System.Windows.Forms.Label lblQty23;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Label lblCreateCode;
        private System.Windows.Forms.DateTimePicker dtpDueTime;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        private System.Windows.Forms.Label lblDueTime;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblOwnerCode;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToOper;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.Label lblToOper;
        private System.Windows.Forms.TabPage tbpRework;
        private System.Windows.Forms.TabPage tbpCrtCmf;
        private System.Windows.Forms.Panel pnlReworkLeft;
        private System.Windows.Forms.Panel pnlReworkLeftMid;
        private System.Windows.Forms.Panel pnlReworkLeftTop;
        private System.Windows.Forms.GroupBox grpRework;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRwkEndOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRwkRetOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRwkCode;
        private System.Windows.Forms.TextBox txtRwkCnt;
        private System.Windows.Forms.Label lblReworkEndOper;
        private System.Windows.Forms.Label lblReworkReturnOper;
        private System.Windows.Forms.Label lblReworkCnt;
        private System.Windows.Forms.Label lblReworkCode;
        private System.Windows.Forms.CheckBox chkRework;
        private System.Windows.Forms.Panel pnlReworkMid;
        private System.Windows.Forms.GroupBox grpRes;
        private System.Windows.Forms.GroupBox grpCrtCmf;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf1;
        protected System.Windows.Forms.Label lblCrtCmf10;
        protected System.Windows.Forms.Label lblCrtCmf9;
        protected System.Windows.Forms.Label lblCrtCmf8;
        protected System.Windows.Forms.Label lblCrtCmf7;
        protected System.Windows.Forms.Label lblCrtCmf6;
        protected System.Windows.Forms.Label lblCrtCmf5;
        protected System.Windows.Forms.Label lblCrtCmf4;
        protected System.Windows.Forms.Label lblCrtCmf3;
        protected System.Windows.Forms.Label lblCrtCmf2;
        protected System.Windows.Forms.Label lblCrtCmf1;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.Label lblOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvStartResID;
        private System.Windows.Forms.Label lblStartResource;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndResID;
        private System.Windows.Forms.Label lblEndResource;
        private System.Windows.Forms.Label lblResvRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResvResID;
        private System.Windows.Forms.TextBox txtOperDesc;
        private System.Windows.Forms.Label lblReworkTime;
        private System.Windows.Forms.GroupBox grpNstd;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvNstdRetOper;
        private System.Windows.Forms.Label lblNstdTime;
        private System.Windows.Forms.Label lblNstdReturnOper;
        private System.Windows.Forms.CheckBox chkNstd;
        private System.Windows.Forms.DateTimePicker dtpNstdTime;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf20;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf11;
        protected System.Windows.Forms.Label lblCrtCmf20;
        protected System.Windows.Forms.Label lblCrtCmf19;
        protected System.Windows.Forms.Label lblCrtCmf18;
        protected System.Windows.Forms.Label lblCrtCmf17;
        protected System.Windows.Forms.Label lblCrtCmf16;
        protected System.Windows.Forms.Label lblCrtCmf15;
        protected System.Windows.Forms.Label lblCrtCmf14;
        protected System.Windows.Forms.Label lblCrtCmf13;
        protected System.Windows.Forms.Label lblCrtCmf12;
        protected System.Windows.Forms.Label lblCrtCmf11;
        private System.Windows.Forms.DateTimePicker dtpRwkTime;
        private System.Windows.Forms.TextBox txtRwkTime;
        private System.Windows.Forms.TextBox txtNstdTime;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCarrier;
        private Miracom.MESCore.Controls.udcMaterial cdvToMatID;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvToFlow;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvRwkRetFlow;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvNstdRetFlow;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvRwkEndFlow;
        private CheckBox chkNoAutoTermLot;
        private TabPage tbpExtra;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLocation3;
        private Label lblLotLocation3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLocation2;
        private Label lblLotLocation2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLocation1;
        private Label lblLotLocation1;
        private GroupBox grpExtra;
        private TextBox txtAddOrder3;
        private Label lblAddOrder3;
        private TextBox txtAddOrder2;
        private Label lblAddOrder2;
        private TextBox txtAddOrder1;
        private Label lblAddOrder1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSampleResult;
        private CheckBox chkSampleWait;
        private CheckBox chkSample;
        private Label lblSampleResult;
        private TextBox txtInvUnit;
        private Label lblInvUnit;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvStrRetFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvStrRetOper;
        private Label lblStrRetOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPort;
        private Label lblPortID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToCarrier;
        private Label lblToCarrier;
        private Label lblYield1;
        private TextBox txtYield1;
        private TextBox txtYield3;
        private Label lblYield3;
        private TextBox txtYield2;
        private Label lblYield2;
        private ComboBox cboReturnOption;
        private CheckBox chkLocalRwkFlag;
        private TextBox txtRwkDepth;
        private Label lblRwkDepth;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRwkStopOper;
        private Label lblRwkStopOper;
        private System.Windows.Forms.Label lblCarrier;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpAdapt = new System.Windows.Forms.GroupBox();
            this.cdvToCarrier = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToCarrier = new System.Windows.Forms.Label();
            this.chkNoAutoTermLot = new System.Windows.Forms.CheckBox();
            this.cdvToFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvToMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvCarrier = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.txtOperDesc = new System.Windows.Forms.TextBox();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.lblOper = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.cdvShipCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblShipCode = new System.Windows.Forms.Label();
            this.cdvLotType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLotType = new System.Windows.Forms.Label();
            this.lblQty23 = new System.Windows.Forms.Label();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.dtpDueTime = new System.Windows.Forms.DateTimePicker();
            this.cdvOwnerCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDueTime = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.cdvToOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lblToOper = new System.Windows.Forms.Label();
            this.tbpRework = new System.Windows.Forms.TabPage();
            this.pnlReworkMid = new System.Windows.Forms.Panel();
            this.grpRes = new System.Windows.Forms.GroupBox();
            this.cdvPort = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPortID = new System.Windows.Forms.Label();
            this.cdvLocation3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLotLocation3 = new System.Windows.Forms.Label();
            this.cdvLocation2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLotLocation2 = new System.Windows.Forms.Label();
            this.cdvLocation1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResvRes = new System.Windows.Forms.Label();
            this.cdvEndResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEndResource = new System.Windows.Forms.Label();
            this.cdvStartResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLotLocation1 = new System.Windows.Forms.Label();
            this.lblStartResource = new System.Windows.Forms.Label();
            this.pnlReworkLeft = new System.Windows.Forms.Panel();
            this.pnlReworkLeftMid = new System.Windows.Forms.Panel();
            this.grpNstd = new System.Windows.Forms.GroupBox();
            this.cdvNstdRetFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.txtNstdTime = new System.Windows.Forms.TextBox();
            this.dtpNstdTime = new System.Windows.Forms.DateTimePicker();
            this.cdvNstdRetOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblNstdTime = new System.Windows.Forms.Label();
            this.lblNstdReturnOper = new System.Windows.Forms.Label();
            this.chkNstd = new System.Windows.Forms.CheckBox();
            this.pnlReworkLeftTop = new System.Windows.Forms.Panel();
            this.grpRework = new System.Windows.Forms.GroupBox();
            this.chkLocalRwkFlag = new System.Windows.Forms.CheckBox();
            this.txtRwkDepth = new System.Windows.Forms.TextBox();
            this.lblRwkDepth = new System.Windows.Forms.Label();
            this.cdvRwkStopOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRwkStopOper = new System.Windows.Forms.Label();
            this.cboReturnOption = new System.Windows.Forms.ComboBox();
            this.cdvRwkEndFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvRwkRetFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.txtRwkTime = new System.Windows.Forms.TextBox();
            this.dtpRwkTime = new System.Windows.Forms.DateTimePicker();
            this.lblReworkTime = new System.Windows.Forms.Label();
            this.cdvRwkEndOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvRwkRetOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvRwkCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtRwkCnt = new System.Windows.Forms.TextBox();
            this.lblReworkEndOper = new System.Windows.Forms.Label();
            this.lblReworkReturnOper = new System.Windows.Forms.Label();
            this.lblReworkCnt = new System.Windows.Forms.Label();
            this.lblReworkCode = new System.Windows.Forms.Label();
            this.chkRework = new System.Windows.Forms.CheckBox();
            this.tbpCrtCmf = new System.Windows.Forms.TabPage();
            this.grpCrtCmf = new System.Windows.Forms.GroupBox();
            this.lblCrtCmf8 = new System.Windows.Forms.Label();
            this.cdvCrtCmf19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrtCmf20 = new System.Windows.Forms.Label();
            this.lblCrtCmf19 = new System.Windows.Forms.Label();
            this.lblCrtCmf18 = new System.Windows.Forms.Label();
            this.lblCrtCmf17 = new System.Windows.Forms.Label();
            this.lblCrtCmf16 = new System.Windows.Forms.Label();
            this.lblCrtCmf15 = new System.Windows.Forms.Label();
            this.lblCrtCmf14 = new System.Windows.Forms.Label();
            this.lblCrtCmf13 = new System.Windows.Forms.Label();
            this.lblCrtCmf12 = new System.Windows.Forms.Label();
            this.lblCrtCmf11 = new System.Windows.Forms.Label();
            this.cdvCrtCmf9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrtCmf10 = new System.Windows.Forms.Label();
            this.lblCrtCmf9 = new System.Windows.Forms.Label();
            this.lblCrtCmf7 = new System.Windows.Forms.Label();
            this.lblCrtCmf6 = new System.Windows.Forms.Label();
            this.lblCrtCmf5 = new System.Windows.Forms.Label();
            this.lblCrtCmf4 = new System.Windows.Forms.Label();
            this.lblCrtCmf3 = new System.Windows.Forms.Label();
            this.lblCrtCmf2 = new System.Windows.Forms.Label();
            this.lblCrtCmf1 = new System.Windows.Forms.Label();
            this.tbpExtra = new System.Windows.Forms.TabPage();
            this.grpExtra = new System.Windows.Forms.GroupBox();
            this.txtYield3 = new System.Windows.Forms.TextBox();
            this.lblYield3 = new System.Windows.Forms.Label();
            this.txtYield2 = new System.Windows.Forms.TextBox();
            this.lblYield2 = new System.Windows.Forms.Label();
            this.txtYield1 = new System.Windows.Forms.TextBox();
            this.lblYield1 = new System.Windows.Forms.Label();
            this.cdvStrRetFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvStrRetOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblStrRetOper = new System.Windows.Forms.Label();
            this.txtAddOrder3 = new System.Windows.Forms.TextBox();
            this.lblAddOrder3 = new System.Windows.Forms.Label();
            this.txtAddOrder2 = new System.Windows.Forms.TextBox();
            this.lblAddOrder2 = new System.Windows.Forms.Label();
            this.txtAddOrder1 = new System.Windows.Forms.TextBox();
            this.lblAddOrder1 = new System.Windows.Forms.Label();
            this.cdvSampleResult = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkSampleWait = new System.Windows.Forms.CheckBox();
            this.chkSample = new System.Windows.Forms.CheckBox();
            this.lblSampleResult = new System.Windows.Forms.Label();
            this.txtInvUnit = new System.Windows.Forms.TextBox();
            this.lblInvUnit = new System.Windows.Forms.Label();
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
            this.grpAdapt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOper)).BeginInit();
            this.tbpRework.SuspendLayout();
            this.pnlReworkMid.SuspendLayout();
            this.grpRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLocation3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLocation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLocation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvStartResID)).BeginInit();
            this.pnlReworkLeft.SuspendLayout();
            this.pnlReworkLeftMid.SuspendLayout();
            this.grpNstd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNstdRetOper)).BeginInit();
            this.pnlReworkLeftTop.SuspendLayout();
            this.grpRework.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkStopOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkEndOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkRetOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkCode)).BeginInit();
            this.tbpCrtCmf.SuspendLayout();
            this.grpCrtCmf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf1)).BeginInit();
            this.tbpExtra.SuspendLayout();
            this.grpExtra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvStrRetOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSampleResult)).BeginInit();
            this.SuspendLayout();
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 422);
            // 
            // pnlTran
            // 
            this.pnlTran.Controls.Add(this.grpAdapt);
            this.pnlTran.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlTran.Size = new System.Drawing.Size(722, 383);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 386);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // txtComment
            // 
            this.txtComment.Size = new System.Drawing.Size(597, 20);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // grpCMF
            // 
            this.grpCMF.Size = new System.Drawing.Size(722, 419);
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
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpRework);
            this.tabTran.Controls.Add(this.tbpExtra);
            this.tabTran.Controls.Add(this.tbpCrtCmf);
            this.tabTran.Size = new System.Drawing.Size(736, 448);
            this.tabTran.Controls.SetChildIndex(this.tbpCrtCmf, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpExtra, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpRework, 0);
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
            this.txtLotID.Location = new System.Drawing.Point(125, 12);
            this.txtLotID.Size = new System.Drawing.Size(195, 20);
            this.txtLotID.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Location = new System.Drawing.Point(125, 36);
            this.txtLotDesc.ReadOnly = false;
            this.txtLotDesc.Size = new System.Drawing.Size(599, 20);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 451);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Adapt Lot";
            // 
            // grpAdapt
            // 
            this.grpAdapt.Controls.Add(this.cdvToCarrier);
            this.grpAdapt.Controls.Add(this.lblToCarrier);
            this.grpAdapt.Controls.Add(this.chkNoAutoTermLot);
            this.grpAdapt.Controls.Add(this.cdvToFlow);
            this.grpAdapt.Controls.Add(this.cdvToMatID);
            this.grpAdapt.Controls.Add(this.cdvFlow);
            this.grpAdapt.Controls.Add(this.cdvMaterial);
            this.grpAdapt.Controls.Add(this.cdvCarrier);
            this.grpAdapt.Controls.Add(this.lblCarrier);
            this.grpAdapt.Controls.Add(this.txtOperDesc);
            this.grpAdapt.Controls.Add(this.txtOper);
            this.grpAdapt.Controls.Add(this.lblOper);
            this.grpAdapt.Controls.Add(this.txtOrderID);
            this.grpAdapt.Controls.Add(this.lblOrderID);
            this.grpAdapt.Controls.Add(this.cdvShipCode);
            this.grpAdapt.Controls.Add(this.lblShipCode);
            this.grpAdapt.Controls.Add(this.cdvLotType);
            this.grpAdapt.Controls.Add(this.lblLotType);
            this.grpAdapt.Controls.Add(this.lblQty23);
            this.grpAdapt.Controls.Add(this.txtPriority);
            this.grpAdapt.Controls.Add(this.lblCreateCode);
            this.grpAdapt.Controls.Add(this.dtpDueTime);
            this.grpAdapt.Controls.Add(this.cdvOwnerCode);
            this.grpAdapt.Controls.Add(this.cdvCreateCode);
            this.grpAdapt.Controls.Add(this.lblDueTime);
            this.grpAdapt.Controls.Add(this.lblPriority);
            this.grpAdapt.Controls.Add(this.lblOwnerCode);
            this.grpAdapt.Controls.Add(this.txtQty3);
            this.grpAdapt.Controls.Add(this.txtQty2);
            this.grpAdapt.Controls.Add(this.txtQty1);
            this.grpAdapt.Controls.Add(this.cdvToOper);
            this.grpAdapt.Controls.Add(this.lblQty1);
            this.grpAdapt.Controls.Add(this.lblToOper);
            this.grpAdapt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAdapt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAdapt.Location = new System.Drawing.Point(3, 3);
            this.grpAdapt.Name = "grpAdapt";
            this.grpAdapt.Size = new System.Drawing.Size(716, 380);
            this.grpAdapt.TabIndex = 0;
            this.grpAdapt.TabStop = false;
            // 
            // cdvToCarrier
            // 
            this.cdvToCarrier.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToCarrier.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToCarrier.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToCarrier.BtnToolTipText = "";
            this.cdvToCarrier.DescText = "";
            this.cdvToCarrier.DisplaySubItemIndex = -1;
            this.cdvToCarrier.DisplayText = "";
            this.cdvToCarrier.Focusing = null;
            this.cdvToCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToCarrier.Index = 0;
            this.cdvToCarrier.IsViewBtnImage = false;
            this.cdvToCarrier.Location = new System.Drawing.Point(115, 234);
            this.cdvToCarrier.MaxLength = 20;
            this.cdvToCarrier.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToCarrier.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToCarrier.Name = "cdvToCarrier";
            this.cdvToCarrier.ReadOnly = false;
            this.cdvToCarrier.SearchSubItemIndex = 0;
            this.cdvToCarrier.SelectedDescIndex = -1;
            this.cdvToCarrier.SelectedSubItemIndex = -1;
            this.cdvToCarrier.SelectionStart = 0;
            this.cdvToCarrier.Size = new System.Drawing.Size(168, 20);
            this.cdvToCarrier.SmallImageList = null;
            this.cdvToCarrier.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToCarrier.TabIndex = 19;
            this.cdvToCarrier.TextBoxToolTipText = "";
            this.cdvToCarrier.TextBoxWidth = 168;
            this.cdvToCarrier.Visible = false;
            this.cdvToCarrier.VisibleButton = true;
            this.cdvToCarrier.VisibleColumnHeader = false;
            this.cdvToCarrier.VisibleDescription = false;
            this.cdvToCarrier.ButtonPress += new System.EventHandler(this.cdvToCarrier_ButtonPress);
            // 
            // lblToCarrier
            // 
            this.lblToCarrier.AutoSize = true;
            this.lblToCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToCarrier.Location = new System.Drawing.Point(12, 237);
            this.lblToCarrier.Name = "lblToCarrier";
            this.lblToCarrier.Size = new System.Drawing.Size(67, 13);
            this.lblToCarrier.TabIndex = 18;
            this.lblToCarrier.Text = "To Carrier ID";
            this.lblToCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblToCarrier.Visible = false;
            // 
            // chkNoAutoTermLot
            // 
            this.chkNoAutoTermLot.AutoSize = true;
            this.chkNoAutoTermLot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoAutoTermLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNoAutoTermLot.Location = new System.Drawing.Point(317, 235);
            this.chkNoAutoTermLot.Name = "chkNoAutoTermLot";
            this.chkNoAutoTermLot.Size = new System.Drawing.Size(164, 18);
            this.chkNoAutoTermLot.TabIndex = 32;
            this.chkNoAutoTermLot.Text = "No Automatic Terminate Lot";
            // 
            // cdvToFlow
            // 
            this.cdvToFlow.AddEmptyRowToLast = false;
            this.cdvToFlow.AddEmptyRowToTop = false;
            this.cdvToFlow.DisplaySubItemIndex = 0;
            this.cdvToFlow.FlowReadOnly = false;
            this.cdvToFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelText = "To Flow";
            this.cdvToFlow.LabelWidth = 103;
            this.cdvToFlow.ListCond_ExtFactory = "";
            this.cdvToFlow.ListCond_Step = '2';
            this.cdvToFlow.Location = new System.Drawing.Point(12, 114);
            this.cdvToFlow.Name = "cdvToFlow";
            this.cdvToFlow.SearchSubItemIndex = 0;
            this.cdvToFlow.SelectedDescIndex = -1;
            this.cdvToFlow.SelectedSubItemIndex = 0;
            this.cdvToFlow.SequenceReadOnly = false;
            this.cdvToFlow.Size = new System.Drawing.Size(271, 20);
            this.cdvToFlow.TabIndex = 6;
            this.cdvToFlow.VisibleColumnHeader = false;
            this.cdvToFlow.VisibleDescription = false;
            this.cdvToFlow.VisibleFlowButton = true;
            this.cdvToFlow.VisibleSequenceButton = true;
            this.cdvToFlow.WidthButton = 20;
            this.cdvToFlow.WidthFlowAndSequence = 168;
            this.cdvToFlow.WidthSequence = 50;
            this.cdvToFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToFlow_SelectedItemChanged);
            this.cdvToFlow.FlowButtonPress += new System.EventHandler(this.cdvToFlow_ButtonPress);
            // 
            // cdvToMatID
            // 
            this.cdvToMatID.AddEmptyRowToLast = false;
            this.cdvToMatID.AddEmptyRowToTop = false;
            this.cdvToMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvToMatID.DisplaySubItemIndex = 0;
            this.cdvToMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvToMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMatID.LabelText = "To Material";
            this.cdvToMatID.ListCond_ExtFactory = "";
            this.cdvToMatID.ListCond_StepMaterial = '1';
            this.cdvToMatID.ListCond_StepVersion = '1';
            this.cdvToMatID.Location = new System.Drawing.Point(12, 89);
            this.cdvToMatID.MaterialEnabled = true;
            this.cdvToMatID.MaterialReadOnly = false;
            this.cdvToMatID.Name = "cdvToMatID";
            this.cdvToMatID.SearchSubItemIndex = 0;
            this.cdvToMatID.SelectedDescIndex = -1;
            this.cdvToMatID.SelectedSubItemIndex = 0;
            this.cdvToMatID.Size = new System.Drawing.Size(271, 20);
            this.cdvToMatID.TabIndex = 5;
            this.cdvToMatID.VersionEnabled = true;
            this.cdvToMatID.VersionReadOnly = false;
            this.cdvToMatID.VisibleColumnHeader = false;
            this.cdvToMatID.VisibleDescription = false;
            this.cdvToMatID.VisibleMaterialButton = true;
            this.cdvToMatID.VisibleVersionButton = true;
            this.cdvToMatID.WidthButton = 20;
            this.cdvToMatID.WidthLabel = 103;
            this.cdvToMatID.WidthMaterialAndVersion = 168;
            this.cdvToMatID.WidthVersion = 50;
            this.cdvToMatID.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToMaterial_SelectedItemChanged);
            this.cdvToMatID.MaterialButtonPress += new System.EventHandler(this.cdvToMaterial_ButtonPress);
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = true;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 103;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(12, 38);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = true;
            this.cdvFlow.Size = new System.Drawing.Size(698, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = true;
            this.cdvFlow.VisibleFlowButton = false;
            this.cdvFlow.VisibleSequenceButton = false;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 216;
            this.cdvFlow.WidthSequence = 50;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 12);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = true;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(698, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = false;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 103;
            this.cdvMaterial.WidthMaterialAndVersion = 216;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // cdvCarrier
            // 
            this.cdvCarrier.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCarrier.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCarrier.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCarrier.BtnToolTipText = "";
            this.cdvCarrier.DescText = "";
            this.cdvCarrier.DisplaySubItemIndex = -1;
            this.cdvCarrier.DisplayText = "";
            this.cdvCarrier.Focusing = null;
            this.cdvCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCarrier.Index = 0;
            this.cdvCarrier.IsViewBtnImage = false;
            this.cdvCarrier.Location = new System.Drawing.Point(115, 210);
            this.cdvCarrier.MaxLength = 20;
            this.cdvCarrier.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCarrier.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCarrier.Name = "cdvCarrier";
            this.cdvCarrier.ReadOnly = false;
            this.cdvCarrier.SearchSubItemIndex = 0;
            this.cdvCarrier.SelectedDescIndex = -1;
            this.cdvCarrier.SelectedSubItemIndex = -1;
            this.cdvCarrier.SelectionStart = 0;
            this.cdvCarrier.Size = new System.Drawing.Size(168, 20);
            this.cdvCarrier.SmallImageList = null;
            this.cdvCarrier.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCarrier.TabIndex = 17;
            this.cdvCarrier.TextBoxToolTipText = "";
            this.cdvCarrier.TextBoxWidth = 168;
            this.cdvCarrier.Visible = false;
            this.cdvCarrier.VisibleButton = true;
            this.cdvCarrier.VisibleColumnHeader = false;
            this.cdvCarrier.VisibleDescription = false;
            // 
            // lblCarrier
            // 
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrier.Location = new System.Drawing.Point(12, 213);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(51, 13);
            this.lblCarrier.TabIndex = 16;
            this.lblCarrier.Text = "Carrier ID";
            this.lblCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCarrier.Visible = false;
            // 
            // txtOperDesc
            // 
            this.txtOperDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperDesc.Location = new System.Drawing.Point(283, 64);
            this.txtOperDesc.MaxLength = 200;
            this.txtOperDesc.Name = "txtOperDesc";
            this.txtOperDesc.ReadOnly = true;
            this.txtOperDesc.Size = new System.Drawing.Size(427, 20);
            this.txtOperDesc.TabIndex = 4;
            this.txtOperDesc.TabStop = false;
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(115, 64);
            this.txtOper.MaxLength = 10;
            this.txtOper.Name = "txtOper";
            this.txtOper.ReadOnly = true;
            this.txtOper.Size = new System.Drawing.Size(166, 20);
            this.txtOper.TabIndex = 3;
            this.txtOper.TabStop = false;
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Location = new System.Drawing.Point(12, 67);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 2;
            this.lblOper.Text = "Operation";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(430, 162);
            this.txtOrderID.MaxLength = 25;
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(167, 20);
            this.txtOrderID.TabIndex = 27;
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.Location = new System.Drawing.Point(317, 165);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(47, 13);
            this.lblOrderID.TabIndex = 26;
            this.lblOrderID.Text = "Order ID";
            // 
            // cdvShipCode
            // 
            this.cdvShipCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShipCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShipCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShipCode.BtnToolTipText = "";
            this.cdvShipCode.DescText = "";
            this.cdvShipCode.DisplaySubItemIndex = -1;
            this.cdvShipCode.DisplayText = "";
            this.cdvShipCode.Focusing = null;
            this.cdvShipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvShipCode.Index = 0;
            this.cdvShipCode.IsViewBtnImage = false;
            this.cdvShipCode.Location = new System.Drawing.Point(430, 138);
            this.cdvShipCode.MaxLength = 10;
            this.cdvShipCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShipCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShipCode.Name = "cdvShipCode";
            this.cdvShipCode.ReadOnly = false;
            this.cdvShipCode.SearchSubItemIndex = 0;
            this.cdvShipCode.SelectedDescIndex = -1;
            this.cdvShipCode.SelectedSubItemIndex = -1;
            this.cdvShipCode.SelectionStart = 0;
            this.cdvShipCode.Size = new System.Drawing.Size(167, 20);
            this.cdvShipCode.SmallImageList = null;
            this.cdvShipCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShipCode.TabIndex = 25;
            this.cdvShipCode.TextBoxToolTipText = "";
            this.cdvShipCode.TextBoxWidth = 167;
            this.cdvShipCode.VisibleButton = true;
            this.cdvShipCode.VisibleColumnHeader = false;
            this.cdvShipCode.VisibleDescription = false;
            this.cdvShipCode.ButtonPress += new System.EventHandler(this.cdvShipCode_ButtonPress);
            // 
            // lblShipCode
            // 
            this.lblShipCode.AutoSize = true;
            this.lblShipCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipCode.Location = new System.Drawing.Point(317, 141);
            this.lblShipCode.Name = "lblShipCode";
            this.lblShipCode.Size = new System.Drawing.Size(56, 13);
            this.lblShipCode.TabIndex = 24;
            this.lblShipCode.Text = "Ship Code";
            // 
            // cdvLotType
            // 
            this.cdvLotType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLotType.BtnToolTipText = "";
            this.cdvLotType.DescText = "";
            this.cdvLotType.DisplaySubItemIndex = -1;
            this.cdvLotType.DisplayText = "";
            this.cdvLotType.Focusing = null;
            this.cdvLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLotType.Index = 0;
            this.cdvLotType.IsViewBtnImage = false;
            this.cdvLotType.Location = new System.Drawing.Point(115, 186);
            this.cdvLotType.MaxLength = 1;
            this.cdvLotType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.Name = "cdvLotType";
            this.cdvLotType.ReadOnly = false;
            this.cdvLotType.SearchSubItemIndex = 0;
            this.cdvLotType.SelectedDescIndex = -1;
            this.cdvLotType.SelectedSubItemIndex = -1;
            this.cdvLotType.SelectionStart = 0;
            this.cdvLotType.Size = new System.Drawing.Size(168, 20);
            this.cdvLotType.SmallImageList = null;
            this.cdvLotType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotType.TabIndex = 15;
            this.cdvLotType.TextBoxToolTipText = "";
            this.cdvLotType.TextBoxWidth = 168;
            this.cdvLotType.VisibleButton = true;
            this.cdvLotType.VisibleColumnHeader = false;
            this.cdvLotType.VisibleDescription = false;
            this.cdvLotType.ButtonPress += new System.EventHandler(this.cdvLotType_ButtonPress);
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(12, 189);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(49, 13);
            this.lblLotType.TabIndex = 14;
            this.lblLotType.Text = "Lot Type";
            this.lblLotType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty23
            // 
            this.lblQty23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty23.Location = new System.Drawing.Point(45, 165);
            this.lblQty23.Name = "lblQty23";
            this.lblQty23.Size = new System.Drawing.Size(45, 14);
            this.lblQty23.TabIndex = 10;
            this.lblQty23.Text = "/ 2 / 3";
            this.lblQty23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(430, 210);
            this.txtPriority.MaxLength = 1;
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(167, 20);
            this.txtPriority.TabIndex = 31;
            this.txtPriority.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPriority_KeyPress);
            // 
            // lblCreateCode
            // 
            this.lblCreateCode.AutoSize = true;
            this.lblCreateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCode.Location = new System.Drawing.Point(317, 92);
            this.lblCreateCode.Name = "lblCreateCode";
            this.lblCreateCode.Size = new System.Drawing.Size(66, 13);
            this.lblCreateCode.TabIndex = 20;
            this.lblCreateCode.Text = "Create Code";
            this.lblCreateCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDueTime
            // 
            this.dtpDueTime.CustomFormat = "";
            this.dtpDueTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueTime.Location = new System.Drawing.Point(430, 186);
            this.dtpDueTime.Name = "dtpDueTime";
            this.dtpDueTime.Size = new System.Drawing.Size(167, 20);
            this.dtpDueTime.TabIndex = 29;
            // 
            // cdvOwnerCode
            // 
            this.cdvOwnerCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOwnerCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOwnerCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOwnerCode.BtnToolTipText = "";
            this.cdvOwnerCode.DescText = "";
            this.cdvOwnerCode.DisplaySubItemIndex = -1;
            this.cdvOwnerCode.DisplayText = "";
            this.cdvOwnerCode.Focusing = null;
            this.cdvOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOwnerCode.Index = 0;
            this.cdvOwnerCode.IsViewBtnImage = false;
            this.cdvOwnerCode.Location = new System.Drawing.Point(430, 114);
            this.cdvOwnerCode.MaxLength = 10;
            this.cdvOwnerCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.Name = "cdvOwnerCode";
            this.cdvOwnerCode.ReadOnly = false;
            this.cdvOwnerCode.SearchSubItemIndex = 0;
            this.cdvOwnerCode.SelectedDescIndex = -1;
            this.cdvOwnerCode.SelectedSubItemIndex = -1;
            this.cdvOwnerCode.SelectionStart = 0;
            this.cdvOwnerCode.Size = new System.Drawing.Size(167, 20);
            this.cdvOwnerCode.SmallImageList = null;
            this.cdvOwnerCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOwnerCode.TabIndex = 23;
            this.cdvOwnerCode.TextBoxToolTipText = "";
            this.cdvOwnerCode.TextBoxWidth = 167;
            this.cdvOwnerCode.VisibleButton = true;
            this.cdvOwnerCode.VisibleColumnHeader = false;
            this.cdvOwnerCode.VisibleDescription = false;
            this.cdvOwnerCode.ButtonPress += new System.EventHandler(this.cdvOwnerCode_ButtonPress);
            // 
            // cdvCreateCode
            // 
            this.cdvCreateCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCode.BtnToolTipText = "";
            this.cdvCreateCode.DescText = "";
            this.cdvCreateCode.DisplaySubItemIndex = -1;
            this.cdvCreateCode.DisplayText = "";
            this.cdvCreateCode.Focusing = null;
            this.cdvCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCode.Index = 0;
            this.cdvCreateCode.IsViewBtnImage = false;
            this.cdvCreateCode.Location = new System.Drawing.Point(430, 89);
            this.cdvCreateCode.MaxLength = 10;
            this.cdvCreateCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.Name = "cdvCreateCode";
            this.cdvCreateCode.ReadOnly = false;
            this.cdvCreateCode.SearchSubItemIndex = 0;
            this.cdvCreateCode.SelectedDescIndex = -1;
            this.cdvCreateCode.SelectedSubItemIndex = -1;
            this.cdvCreateCode.SelectionStart = 0;
            this.cdvCreateCode.Size = new System.Drawing.Size(167, 20);
            this.cdvCreateCode.SmallImageList = null;
            this.cdvCreateCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCode.TabIndex = 21;
            this.cdvCreateCode.TextBoxToolTipText = "";
            this.cdvCreateCode.TextBoxWidth = 167;
            this.cdvCreateCode.VisibleButton = true;
            this.cdvCreateCode.VisibleColumnHeader = false;
            this.cdvCreateCode.VisibleDescription = false;
            this.cdvCreateCode.ButtonPress += new System.EventHandler(this.cdvCreateCode_ButtonPress);
            // 
            // lblDueTime
            // 
            this.lblDueTime.AutoSize = true;
            this.lblDueTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDueTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueTime.Location = new System.Drawing.Point(317, 189);
            this.lblDueTime.Name = "lblDueTime";
            this.lblDueTime.Size = new System.Drawing.Size(53, 13);
            this.lblDueTime.TabIndex = 28;
            this.lblDueTime.Text = "Due Date";
            this.lblDueTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(317, 213);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(38, 13);
            this.lblPriority.TabIndex = 30;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerCode.Location = new System.Drawing.Point(317, 117);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(66, 13);
            this.lblOwnerCode.TabIndex = 22;
            this.lblOwnerCode.Text = "Owner Code";
            this.lblOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(227, 162);
            this.txtQty3.MaxLength = 11;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.Size = new System.Drawing.Size(56, 20);
            this.txtQty3.TabIndex = 13;
            this.txtQty3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(171, 162);
            this.txtQty2.MaxLength = 11;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.Size = new System.Drawing.Size(54, 20);
            this.txtQty2.TabIndex = 12;
            this.txtQty2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(115, 162);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.Size = new System.Drawing.Size(54, 20);
            this.txtQty1.TabIndex = 11;
            this.txtQty1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // cdvToOper
            // 
            this.cdvToOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToOper.BtnToolTipText = "";
            this.cdvToOper.DescText = "";
            this.cdvToOper.DisplaySubItemIndex = -1;
            this.cdvToOper.DisplayText = "";
            this.cdvToOper.Focusing = null;
            this.cdvToOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOper.Index = 0;
            this.cdvToOper.IsViewBtnImage = false;
            this.cdvToOper.Location = new System.Drawing.Point(115, 138);
            this.cdvToOper.MaxLength = 10;
            this.cdvToOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToOper.Name = "cdvToOper";
            this.cdvToOper.ReadOnly = false;
            this.cdvToOper.SearchSubItemIndex = 0;
            this.cdvToOper.SelectedDescIndex = -1;
            this.cdvToOper.SelectedSubItemIndex = -1;
            this.cdvToOper.SelectionStart = 0;
            this.cdvToOper.Size = new System.Drawing.Size(168, 20);
            this.cdvToOper.SmallImageList = null;
            this.cdvToOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToOper.TabIndex = 8;
            this.cdvToOper.TextBoxToolTipText = "";
            this.cdvToOper.TextBoxWidth = 168;
            this.cdvToOper.VisibleButton = true;
            this.cdvToOper.VisibleColumnHeader = false;
            this.cdvToOper.VisibleDescription = false;
            this.cdvToOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToOper_SelectedItemChanged);
            this.cdvToOper.ButtonPress += new System.EventHandler(this.cdvToOper_ButtonPress);
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(12, 165);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(37, 13);
            this.lblQty1.TabIndex = 9;
            this.lblQty1.Text = "Qty 1&";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToOper
            // 
            this.lblToOper.AutoSize = true;
            this.lblToOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToOper.Location = new System.Drawing.Point(12, 141);
            this.lblToOper.Name = "lblToOper";
            this.lblToOper.Size = new System.Drawing.Size(69, 13);
            this.lblToOper.TabIndex = 7;
            this.lblToOper.Text = "To Operation";
            this.lblToOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpRework
            // 
            this.tbpRework.Controls.Add(this.pnlReworkMid);
            this.tbpRework.Controls.Add(this.pnlReworkLeft);
            this.tbpRework.Location = new System.Drawing.Point(4, 22);
            this.tbpRework.Name = "tbpRework";
            this.tbpRework.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRework.Size = new System.Drawing.Size(728, 415);
            this.tbpRework.TabIndex = 2;
            this.tbpRework.Text = "Rework and Resource Information";
            // 
            // pnlReworkMid
            // 
            this.pnlReworkMid.Controls.Add(this.grpRes);
            this.pnlReworkMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReworkMid.Location = new System.Drawing.Point(397, 3);
            this.pnlReworkMid.Name = "pnlReworkMid";
            this.pnlReworkMid.Size = new System.Drawing.Size(328, 409);
            this.pnlReworkMid.TabIndex = 1;
            // 
            // grpRes
            // 
            this.grpRes.Controls.Add(this.cdvPort);
            this.grpRes.Controls.Add(this.lblPortID);
            this.grpRes.Controls.Add(this.cdvLocation3);
            this.grpRes.Controls.Add(this.lblLotLocation3);
            this.grpRes.Controls.Add(this.cdvLocation2);
            this.grpRes.Controls.Add(this.lblLotLocation2);
            this.grpRes.Controls.Add(this.cdvLocation1);
            this.grpRes.Controls.Add(this.cdvResvResID);
            this.grpRes.Controls.Add(this.lblResvRes);
            this.grpRes.Controls.Add(this.cdvEndResID);
            this.grpRes.Controls.Add(this.lblEndResource);
            this.grpRes.Controls.Add(this.cdvStartResID);
            this.grpRes.Controls.Add(this.lblLotLocation1);
            this.grpRes.Controls.Add(this.lblStartResource);
            this.grpRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRes.Location = new System.Drawing.Point(0, 0);
            this.grpRes.Name = "grpRes";
            this.grpRes.Size = new System.Drawing.Size(328, 409);
            this.grpRes.TabIndex = 0;
            this.grpRes.TabStop = false;
            this.grpRes.Text = "Resource Information";
            // 
            // cdvPort
            // 
            this.cdvPort.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPort.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPort.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPort.BtnToolTipText = "";
            this.cdvPort.DescText = "";
            this.cdvPort.DisplaySubItemIndex = -1;
            this.cdvPort.DisplayText = "";
            this.cdvPort.Focusing = null;
            this.cdvPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPort.Index = 0;
            this.cdvPort.IsViewBtnImage = false;
            this.cdvPort.Location = new System.Drawing.Point(144, 107);
            this.cdvPort.MaxLength = 10;
            this.cdvPort.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPort.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPort.Name = "cdvPort";
            this.cdvPort.ReadOnly = false;
            this.cdvPort.SearchSubItemIndex = 0;
            this.cdvPort.SelectedDescIndex = -1;
            this.cdvPort.SelectedSubItemIndex = -1;
            this.cdvPort.SelectionStart = 0;
            this.cdvPort.Size = new System.Drawing.Size(166, 20);
            this.cdvPort.SmallImageList = null;
            this.cdvPort.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPort.TabIndex = 7;
            this.cdvPort.TextBoxToolTipText = "";
            this.cdvPort.TextBoxWidth = 166;
            this.cdvPort.VisibleButton = true;
            this.cdvPort.VisibleColumnHeader = false;
            this.cdvPort.VisibleDescription = false;
            this.cdvPort.ButtonPress += new System.EventHandler(this.cdvPort_ButtonPress);
            // 
            // lblPortID
            // 
            this.lblPortID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPortID.Location = new System.Drawing.Point(13, 110);
            this.lblPortID.Name = "lblPortID";
            this.lblPortID.Size = new System.Drawing.Size(115, 14);
            this.lblPortID.TabIndex = 6;
            this.lblPortID.Text = "Port ID";
            // 
            // cdvLocation3
            // 
            this.cdvLocation3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLocation3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLocation3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLocation3.BtnToolTipText = "";
            this.cdvLocation3.DescText = "";
            this.cdvLocation3.DisplaySubItemIndex = -1;
            this.cdvLocation3.DisplayText = "";
            this.cdvLocation3.Focusing = null;
            this.cdvLocation3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLocation3.Index = 0;
            this.cdvLocation3.IsViewBtnImage = false;
            this.cdvLocation3.Location = new System.Drawing.Point(144, 190);
            this.cdvLocation3.MaxLength = 20;
            this.cdvLocation3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLocation3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLocation3.Name = "cdvLocation3";
            this.cdvLocation3.ReadOnly = false;
            this.cdvLocation3.SearchSubItemIndex = 0;
            this.cdvLocation3.SelectedDescIndex = -1;
            this.cdvLocation3.SelectedSubItemIndex = -1;
            this.cdvLocation3.SelectionStart = 0;
            this.cdvLocation3.Size = new System.Drawing.Size(166, 20);
            this.cdvLocation3.SmallImageList = null;
            this.cdvLocation3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLocation3.TabIndex = 13;
            this.cdvLocation3.TextBoxToolTipText = "";
            this.cdvLocation3.TextBoxWidth = 166;
            this.cdvLocation3.VisibleButton = false;
            this.cdvLocation3.VisibleColumnHeader = false;
            this.cdvLocation3.VisibleDescription = false;
            // 
            // lblLotLocation3
            // 
            this.lblLotLocation3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotLocation3.Location = new System.Drawing.Point(13, 193);
            this.lblLotLocation3.Name = "lblLotLocation3";
            this.lblLotLocation3.Size = new System.Drawing.Size(115, 14);
            this.lblLotLocation3.TabIndex = 12;
            this.lblLotLocation3.Text = "Lot Location 3";
            // 
            // cdvLocation2
            // 
            this.cdvLocation2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLocation2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLocation2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLocation2.BtnToolTipText = "";
            this.cdvLocation2.DescText = "";
            this.cdvLocation2.DisplaySubItemIndex = -1;
            this.cdvLocation2.DisplayText = "";
            this.cdvLocation2.Focusing = null;
            this.cdvLocation2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLocation2.Index = 0;
            this.cdvLocation2.IsViewBtnImage = false;
            this.cdvLocation2.Location = new System.Drawing.Point(144, 166);
            this.cdvLocation2.MaxLength = 20;
            this.cdvLocation2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLocation2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLocation2.Name = "cdvLocation2";
            this.cdvLocation2.ReadOnly = false;
            this.cdvLocation2.SearchSubItemIndex = 0;
            this.cdvLocation2.SelectedDescIndex = -1;
            this.cdvLocation2.SelectedSubItemIndex = -1;
            this.cdvLocation2.SelectionStart = 0;
            this.cdvLocation2.Size = new System.Drawing.Size(166, 20);
            this.cdvLocation2.SmallImageList = null;
            this.cdvLocation2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLocation2.TabIndex = 11;
            this.cdvLocation2.TextBoxToolTipText = "";
            this.cdvLocation2.TextBoxWidth = 166;
            this.cdvLocation2.VisibleButton = false;
            this.cdvLocation2.VisibleColumnHeader = false;
            this.cdvLocation2.VisibleDescription = false;
            // 
            // lblLotLocation2
            // 
            this.lblLotLocation2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotLocation2.Location = new System.Drawing.Point(13, 169);
            this.lblLotLocation2.Name = "lblLotLocation2";
            this.lblLotLocation2.Size = new System.Drawing.Size(115, 14);
            this.lblLotLocation2.TabIndex = 10;
            this.lblLotLocation2.Text = "Lot Location 2";
            // 
            // cdvLocation1
            // 
            this.cdvLocation1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLocation1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLocation1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLocation1.BtnToolTipText = "";
            this.cdvLocation1.DescText = "";
            this.cdvLocation1.DisplaySubItemIndex = -1;
            this.cdvLocation1.DisplayText = "";
            this.cdvLocation1.Focusing = null;
            this.cdvLocation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLocation1.Index = 0;
            this.cdvLocation1.IsViewBtnImage = false;
            this.cdvLocation1.Location = new System.Drawing.Point(144, 142);
            this.cdvLocation1.MaxLength = 10;
            this.cdvLocation1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLocation1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLocation1.Name = "cdvLocation1";
            this.cdvLocation1.ReadOnly = false;
            this.cdvLocation1.SearchSubItemIndex = 0;
            this.cdvLocation1.SelectedDescIndex = -1;
            this.cdvLocation1.SelectedSubItemIndex = -1;
            this.cdvLocation1.SelectionStart = 0;
            this.cdvLocation1.Size = new System.Drawing.Size(166, 20);
            this.cdvLocation1.SmallImageList = null;
            this.cdvLocation1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLocation1.TabIndex = 9;
            this.cdvLocation1.TextBoxToolTipText = "";
            this.cdvLocation1.TextBoxWidth = 166;
            this.cdvLocation1.VisibleButton = false;
            this.cdvLocation1.VisibleColumnHeader = false;
            this.cdvLocation1.VisibleDescription = false;
            // 
            // cdvResvResID
            // 
            this.cdvResvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResvResID.BtnToolTipText = "";
            this.cdvResvResID.DescText = "";
            this.cdvResvResID.DisplaySubItemIndex = -1;
            this.cdvResvResID.DisplayText = "";
            this.cdvResvResID.Focusing = null;
            this.cdvResvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResvResID.Index = 0;
            this.cdvResvResID.IsViewBtnImage = false;
            this.cdvResvResID.Location = new System.Drawing.Point(144, 70);
            this.cdvResvResID.MaxLength = 20;
            this.cdvResvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResvResID.Name = "cdvResvResID";
            this.cdvResvResID.ReadOnly = false;
            this.cdvResvResID.SearchSubItemIndex = 0;
            this.cdvResvResID.SelectedDescIndex = -1;
            this.cdvResvResID.SelectedSubItemIndex = -1;
            this.cdvResvResID.SelectionStart = 0;
            this.cdvResvResID.Size = new System.Drawing.Size(166, 20);
            this.cdvResvResID.SmallImageList = null;
            this.cdvResvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResvResID.TabIndex = 5;
            this.cdvResvResID.TextBoxToolTipText = "";
            this.cdvResvResID.TextBoxWidth = 166;
            this.cdvResvResID.VisibleButton = true;
            this.cdvResvResID.VisibleColumnHeader = false;
            this.cdvResvResID.VisibleDescription = false;
            this.cdvResvResID.ButtonPress += new System.EventHandler(this.cdvResvResID_ButtonPress);
            // 
            // lblResvRes
            // 
            this.lblResvRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResvRes.Location = new System.Drawing.Point(13, 73);
            this.lblResvRes.Name = "lblResvRes";
            this.lblResvRes.Size = new System.Drawing.Size(115, 14);
            this.lblResvRes.TabIndex = 4;
            this.lblResvRes.Text = "Reserve Resource ID";
            // 
            // cdvEndResID
            // 
            this.cdvEndResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndResID.BtnToolTipText = "";
            this.cdvEndResID.DescText = "";
            this.cdvEndResID.DisplaySubItemIndex = -1;
            this.cdvEndResID.DisplayText = "";
            this.cdvEndResID.Focusing = null;
            this.cdvEndResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndResID.Index = 0;
            this.cdvEndResID.IsViewBtnImage = false;
            this.cdvEndResID.Location = new System.Drawing.Point(144, 46);
            this.cdvEndResID.MaxLength = 20;
            this.cdvEndResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndResID.Name = "cdvEndResID";
            this.cdvEndResID.ReadOnly = false;
            this.cdvEndResID.SearchSubItemIndex = 0;
            this.cdvEndResID.SelectedDescIndex = -1;
            this.cdvEndResID.SelectedSubItemIndex = -1;
            this.cdvEndResID.SelectionStart = 0;
            this.cdvEndResID.Size = new System.Drawing.Size(166, 20);
            this.cdvEndResID.SmallImageList = null;
            this.cdvEndResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndResID.TabIndex = 3;
            this.cdvEndResID.TextBoxToolTipText = "";
            this.cdvEndResID.TextBoxWidth = 166;
            this.cdvEndResID.VisibleButton = true;
            this.cdvEndResID.VisibleColumnHeader = false;
            this.cdvEndResID.VisibleDescription = false;
            this.cdvEndResID.ButtonPress += new System.EventHandler(this.cdvEndResID_ButtonPress);
            // 
            // lblEndResource
            // 
            this.lblEndResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndResource.Location = new System.Drawing.Point(13, 49);
            this.lblEndResource.Name = "lblEndResource";
            this.lblEndResource.Size = new System.Drawing.Size(115, 14);
            this.lblEndResource.TabIndex = 2;
            this.lblEndResource.Text = "End Resource ID";
            // 
            // cdvStartResID
            // 
            this.cdvStartResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvStartResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvStartResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvStartResID.BtnToolTipText = "";
            this.cdvStartResID.DescText = "";
            this.cdvStartResID.DisplaySubItemIndex = -1;
            this.cdvStartResID.DisplayText = "";
            this.cdvStartResID.Focusing = null;
            this.cdvStartResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvStartResID.Index = 0;
            this.cdvStartResID.IsViewBtnImage = false;
            this.cdvStartResID.Location = new System.Drawing.Point(144, 22);
            this.cdvStartResID.MaxLength = 20;
            this.cdvStartResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvStartResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvStartResID.Name = "cdvStartResID";
            this.cdvStartResID.ReadOnly = false;
            this.cdvStartResID.SearchSubItemIndex = 0;
            this.cdvStartResID.SelectedDescIndex = -1;
            this.cdvStartResID.SelectedSubItemIndex = -1;
            this.cdvStartResID.SelectionStart = 0;
            this.cdvStartResID.Size = new System.Drawing.Size(166, 20);
            this.cdvStartResID.SmallImageList = null;
            this.cdvStartResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvStartResID.TabIndex = 1;
            this.cdvStartResID.TextBoxToolTipText = "";
            this.cdvStartResID.TextBoxWidth = 166;
            this.cdvStartResID.VisibleButton = true;
            this.cdvStartResID.VisibleColumnHeader = false;
            this.cdvStartResID.VisibleDescription = false;
            this.cdvStartResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvStartResID_SelectedItemChanged);
            this.cdvStartResID.ButtonPress += new System.EventHandler(this.cdvStartResID_ButtonPress);
            // 
            // lblLotLocation1
            // 
            this.lblLotLocation1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotLocation1.Location = new System.Drawing.Point(13, 145);
            this.lblLotLocation1.Name = "lblLotLocation1";
            this.lblLotLocation1.Size = new System.Drawing.Size(115, 14);
            this.lblLotLocation1.TabIndex = 8;
            this.lblLotLocation1.Text = "Lot Location 1";
            // 
            // lblStartResource
            // 
            this.lblStartResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartResource.Location = new System.Drawing.Point(13, 26);
            this.lblStartResource.Name = "lblStartResource";
            this.lblStartResource.Size = new System.Drawing.Size(115, 14);
            this.lblStartResource.TabIndex = 0;
            this.lblStartResource.Text = "Start Resource ID";
            // 
            // pnlReworkLeft
            // 
            this.pnlReworkLeft.Controls.Add(this.pnlReworkLeftMid);
            this.pnlReworkLeft.Controls.Add(this.pnlReworkLeftTop);
            this.pnlReworkLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlReworkLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlReworkLeft.Name = "pnlReworkLeft";
            this.pnlReworkLeft.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlReworkLeft.Size = new System.Drawing.Size(394, 409);
            this.pnlReworkLeft.TabIndex = 0;
            // 
            // pnlReworkLeftMid
            // 
            this.pnlReworkLeftMid.Controls.Add(this.grpNstd);
            this.pnlReworkLeftMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReworkLeftMid.Location = new System.Drawing.Point(0, 284);
            this.pnlReworkLeftMid.Name = "pnlReworkLeftMid";
            this.pnlReworkLeftMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlReworkLeftMid.Size = new System.Drawing.Size(391, 125);
            this.pnlReworkLeftMid.TabIndex = 1;
            // 
            // grpNstd
            // 
            this.grpNstd.Controls.Add(this.cdvNstdRetFlow);
            this.grpNstd.Controls.Add(this.txtNstdTime);
            this.grpNstd.Controls.Add(this.dtpNstdTime);
            this.grpNstd.Controls.Add(this.cdvNstdRetOper);
            this.grpNstd.Controls.Add(this.lblNstdTime);
            this.grpNstd.Controls.Add(this.lblNstdReturnOper);
            this.grpNstd.Controls.Add(this.chkNstd);
            this.grpNstd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNstd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpNstd.Location = new System.Drawing.Point(0, 5);
            this.grpNstd.Name = "grpNstd";
            this.grpNstd.Size = new System.Drawing.Size(391, 120);
            this.grpNstd.TabIndex = 0;
            this.grpNstd.TabStop = false;
            this.grpNstd.Text = "Non Standard Information";
            // 
            // cdvNstdRetFlow
            // 
            this.cdvNstdRetFlow.AddEmptyRowToLast = false;
            this.cdvNstdRetFlow.AddEmptyRowToTop = false;
            this.cdvNstdRetFlow.DisplaySubItemIndex = 0;
            this.cdvNstdRetFlow.FlowReadOnly = false;
            this.cdvNstdRetFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvNstdRetFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvNstdRetFlow.LabelText = "NSTD Return Flow";
            this.cdvNstdRetFlow.LabelWidth = 133;
            this.cdvNstdRetFlow.ListCond_ExtFactory = "";
            this.cdvNstdRetFlow.ListCond_Step = '1';
            this.cdvNstdRetFlow.Location = new System.Drawing.Point(12, 44);
            this.cdvNstdRetFlow.Name = "cdvNstdRetFlow";
            this.cdvNstdRetFlow.SearchSubItemIndex = 0;
            this.cdvNstdRetFlow.SelectedDescIndex = -1;
            this.cdvNstdRetFlow.SelectedSubItemIndex = 0;
            this.cdvNstdRetFlow.SequenceReadOnly = false;
            this.cdvNstdRetFlow.Size = new System.Drawing.Size(299, 20);
            this.cdvNstdRetFlow.TabIndex = 1;
            this.cdvNstdRetFlow.VisibleColumnHeader = false;
            this.cdvNstdRetFlow.VisibleDescription = false;
            this.cdvNstdRetFlow.VisibleFlowButton = true;
            this.cdvNstdRetFlow.VisibleSequenceButton = true;
            this.cdvNstdRetFlow.WidthButton = 20;
            this.cdvNstdRetFlow.WidthFlowAndSequence = 166;
            this.cdvNstdRetFlow.WidthSequence = 50;
            this.cdvNstdRetFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvNstdRetFlow_SelectedItemChanged);
            // 
            // txtNstdTime
            // 
            this.txtNstdTime.Enabled = false;
            this.txtNstdTime.Location = new System.Drawing.Point(145, 94);
            this.txtNstdTime.MaxLength = 30;
            this.txtNstdTime.Name = "txtNstdTime";
            this.txtNstdTime.Size = new System.Drawing.Size(167, 20);
            this.txtNstdTime.TabIndex = 5;
            // 
            // dtpNstdTime
            // 
            this.dtpNstdTime.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.dtpNstdTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNstdTime.Location = new System.Drawing.Point(145, 94);
            this.dtpNstdTime.Name = "dtpNstdTime";
            this.dtpNstdTime.Size = new System.Drawing.Size(166, 20);
            this.dtpNstdTime.TabIndex = 5;
            // 
            // cdvNstdRetOper
            // 
            this.cdvNstdRetOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvNstdRetOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvNstdRetOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvNstdRetOper.BtnToolTipText = "";
            this.cdvNstdRetOper.DescText = "";
            this.cdvNstdRetOper.DisplaySubItemIndex = -1;
            this.cdvNstdRetOper.DisplayText = "";
            this.cdvNstdRetOper.Focusing = null;
            this.cdvNstdRetOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvNstdRetOper.Index = 0;
            this.cdvNstdRetOper.IsViewBtnImage = false;
            this.cdvNstdRetOper.Location = new System.Drawing.Point(145, 70);
            this.cdvNstdRetOper.MaxLength = 10;
            this.cdvNstdRetOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvNstdRetOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvNstdRetOper.Name = "cdvNstdRetOper";
            this.cdvNstdRetOper.ReadOnly = false;
            this.cdvNstdRetOper.SearchSubItemIndex = 0;
            this.cdvNstdRetOper.SelectedDescIndex = -1;
            this.cdvNstdRetOper.SelectedSubItemIndex = -1;
            this.cdvNstdRetOper.SelectionStart = 0;
            this.cdvNstdRetOper.Size = new System.Drawing.Size(166, 20);
            this.cdvNstdRetOper.SmallImageList = null;
            this.cdvNstdRetOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvNstdRetOper.TabIndex = 3;
            this.cdvNstdRetOper.TextBoxToolTipText = "";
            this.cdvNstdRetOper.TextBoxWidth = 166;
            this.cdvNstdRetOper.VisibleButton = true;
            this.cdvNstdRetOper.VisibleColumnHeader = false;
            this.cdvNstdRetOper.VisibleDescription = false;
            this.cdvNstdRetOper.ButtonPress += new System.EventHandler(this.cdvNstdRetOper_ButtonPress);
            // 
            // lblNstdTime
            // 
            this.lblNstdTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNstdTime.Location = new System.Drawing.Point(12, 97);
            this.lblNstdTime.Name = "lblNstdTime";
            this.lblNstdTime.Size = new System.Drawing.Size(115, 14);
            this.lblNstdTime.TabIndex = 4;
            this.lblNstdTime.Text = "NSTD Time";
            // 
            // lblNstdReturnOper
            // 
            this.lblNstdReturnOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNstdReturnOper.Location = new System.Drawing.Point(12, 73);
            this.lblNstdReturnOper.Name = "lblNstdReturnOper";
            this.lblNstdReturnOper.Size = new System.Drawing.Size(115, 14);
            this.lblNstdReturnOper.TabIndex = 2;
            this.lblNstdReturnOper.Text = "NSTD Return Oper";
            // 
            // chkNstd
            // 
            this.chkNstd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNstd.Location = new System.Drawing.Point(12, 22);
            this.chkNstd.Name = "chkNstd";
            this.chkNstd.Size = new System.Drawing.Size(115, 14);
            this.chkNstd.TabIndex = 0;
            this.chkNstd.Text = "Non Standard Flag";
            this.chkNstd.CheckedChanged += new System.EventHandler(this.chkNstd_CheckedChanged);
            // 
            // pnlReworkLeftTop
            // 
            this.pnlReworkLeftTop.Controls.Add(this.grpRework);
            this.pnlReworkLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReworkLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlReworkLeftTop.Name = "pnlReworkLeftTop";
            this.pnlReworkLeftTop.Size = new System.Drawing.Size(391, 284);
            this.pnlReworkLeftTop.TabIndex = 0;
            // 
            // grpRework
            // 
            this.grpRework.Controls.Add(this.chkLocalRwkFlag);
            this.grpRework.Controls.Add(this.txtRwkDepth);
            this.grpRework.Controls.Add(this.lblRwkDepth);
            this.grpRework.Controls.Add(this.cdvRwkStopOper);
            this.grpRework.Controls.Add(this.lblRwkStopOper);
            this.grpRework.Controls.Add(this.cboReturnOption);
            this.grpRework.Controls.Add(this.cdvRwkEndFlow);
            this.grpRework.Controls.Add(this.cdvRwkRetFlow);
            this.grpRework.Controls.Add(this.txtRwkTime);
            this.grpRework.Controls.Add(this.dtpRwkTime);
            this.grpRework.Controls.Add(this.lblReworkTime);
            this.grpRework.Controls.Add(this.cdvRwkEndOper);
            this.grpRework.Controls.Add(this.cdvRwkRetOper);
            this.grpRework.Controls.Add(this.cdvRwkCode);
            this.grpRework.Controls.Add(this.txtRwkCnt);
            this.grpRework.Controls.Add(this.lblReworkEndOper);
            this.grpRework.Controls.Add(this.lblReworkReturnOper);
            this.grpRework.Controls.Add(this.lblReworkCnt);
            this.grpRework.Controls.Add(this.lblReworkCode);
            this.grpRework.Controls.Add(this.chkRework);
            this.grpRework.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRework.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRework.Location = new System.Drawing.Point(0, 0);
            this.grpRework.Name = "grpRework";
            this.grpRework.Size = new System.Drawing.Size(391, 284);
            this.grpRework.TabIndex = 0;
            this.grpRework.TabStop = false;
            this.grpRework.Text = "Rework Information";
            // 
            // chkLocalRwkFlag
            // 
            this.chkLocalRwkFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkLocalRwkFlag.Location = new System.Drawing.Point(145, 263);
            this.chkLocalRwkFlag.Name = "chkLocalRwkFlag";
            this.chkLocalRwkFlag.Size = new System.Drawing.Size(115, 14);
            this.chkLocalRwkFlag.TabIndex = 18;
            this.chkLocalRwkFlag.Text = "Local Rework Flag";
            // 
            // txtRwkDepth
            // 
            this.txtRwkDepth.Enabled = false;
            this.txtRwkDepth.Location = new System.Drawing.Point(145, 238);
            this.txtRwkDepth.MaxLength = 6;
            this.txtRwkDepth.Name = "txtRwkDepth";
            this.txtRwkDepth.Size = new System.Drawing.Size(166, 20);
            this.txtRwkDepth.TabIndex = 17;
            // 
            // lblRwkDepth
            // 
            this.lblRwkDepth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRwkDepth.Location = new System.Drawing.Point(12, 241);
            this.lblRwkDepth.Name = "lblRwkDepth";
            this.lblRwkDepth.Size = new System.Drawing.Size(115, 14);
            this.lblRwkDepth.TabIndex = 16;
            this.lblRwkDepth.Text = "Rework Depth";
            // 
            // cdvRwkStopOper
            // 
            this.cdvRwkStopOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRwkStopOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRwkStopOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRwkStopOper.BtnToolTipText = "";
            this.cdvRwkStopOper.DescText = "";
            this.cdvRwkStopOper.DisplaySubItemIndex = -1;
            this.cdvRwkStopOper.DisplayText = "";
            this.cdvRwkStopOper.Focusing = null;
            this.cdvRwkStopOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkStopOper.Index = 0;
            this.cdvRwkStopOper.IsViewBtnImage = false;
            this.cdvRwkStopOper.Location = new System.Drawing.Point(145, 70);
            this.cdvRwkStopOper.MaxLength = 10;
            this.cdvRwkStopOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRwkStopOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRwkStopOper.Name = "cdvRwkStopOper";
            this.cdvRwkStopOper.ReadOnly = false;
            this.cdvRwkStopOper.SearchSubItemIndex = 0;
            this.cdvRwkStopOper.SelectedDescIndex = -1;
            this.cdvRwkStopOper.SelectedSubItemIndex = -1;
            this.cdvRwkStopOper.SelectionStart = 0;
            this.cdvRwkStopOper.Size = new System.Drawing.Size(166, 20);
            this.cdvRwkStopOper.SmallImageList = null;
            this.cdvRwkStopOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRwkStopOper.TabIndex = 5;
            this.cdvRwkStopOper.TextBoxToolTipText = "";
            this.cdvRwkStopOper.TextBoxWidth = 166;
            this.cdvRwkStopOper.VisibleButton = true;
            this.cdvRwkStopOper.VisibleColumnHeader = false;
            this.cdvRwkStopOper.VisibleDescription = false;
            this.cdvRwkStopOper.ButtonPress += new System.EventHandler(this.cdvRwkStopOper_ButtonPress);
            // 
            // lblRwkStopOper
            // 
            this.lblRwkStopOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRwkStopOper.Location = new System.Drawing.Point(12, 73);
            this.lblRwkStopOper.Name = "lblRwkStopOper";
            this.lblRwkStopOper.Size = new System.Drawing.Size(115, 14);
            this.lblRwkStopOper.TabIndex = 4;
            this.lblRwkStopOper.Text = "Rework Stop Oper";
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
            this.cboReturnOption.Location = new System.Drawing.Point(145, 21);
            this.cboReturnOption.Name = "cboReturnOption";
            this.cboReturnOption.Size = new System.Drawing.Size(240, 21);
            this.cboReturnOption.TabIndex = 1;
            // 
            // cdvRwkEndFlow
            // 
            this.cdvRwkEndFlow.AddEmptyRowToLast = false;
            this.cdvRwkEndFlow.AddEmptyRowToTop = false;
            this.cdvRwkEndFlow.DisplaySubItemIndex = 0;
            this.cdvRwkEndFlow.FlowReadOnly = false;
            this.cdvRwkEndFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkEndFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkEndFlow.LabelText = "Rework End Flow";
            this.cdvRwkEndFlow.LabelWidth = 133;
            this.cdvRwkEndFlow.ListCond_ExtFactory = "";
            this.cdvRwkEndFlow.ListCond_Step = '1';
            this.cdvRwkEndFlow.Location = new System.Drawing.Point(12, 142);
            this.cdvRwkEndFlow.Name = "cdvRwkEndFlow";
            this.cdvRwkEndFlow.SearchSubItemIndex = 0;
            this.cdvRwkEndFlow.SelectedDescIndex = -1;
            this.cdvRwkEndFlow.SelectedSubItemIndex = 0;
            this.cdvRwkEndFlow.SequenceReadOnly = false;
            this.cdvRwkEndFlow.Size = new System.Drawing.Size(299, 20);
            this.cdvRwkEndFlow.TabIndex = 9;
            this.cdvRwkEndFlow.VisibleColumnHeader = false;
            this.cdvRwkEndFlow.VisibleDescription = false;
            this.cdvRwkEndFlow.VisibleFlowButton = true;
            this.cdvRwkEndFlow.VisibleSequenceButton = true;
            this.cdvRwkEndFlow.WidthButton = 20;
            this.cdvRwkEndFlow.WidthFlowAndSequence = 166;
            this.cdvRwkEndFlow.WidthSequence = 50;
            this.cdvRwkEndFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkEndFlow_FlowSelectedItemChanged);
            this.cdvRwkEndFlow.FlowButtonPress += new System.EventHandler(this.cdvRwkEndFlow_FlowButtonPress);
            // 
            // cdvRwkRetFlow
            // 
            this.cdvRwkRetFlow.AddEmptyRowToLast = false;
            this.cdvRwkRetFlow.AddEmptyRowToTop = false;
            this.cdvRwkRetFlow.DisplaySubItemIndex = 0;
            this.cdvRwkRetFlow.FlowReadOnly = false;
            this.cdvRwkRetFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkRetFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkRetFlow.LabelText = "Rework Return Flow";
            this.cdvRwkRetFlow.LabelWidth = 133;
            this.cdvRwkRetFlow.ListCond_ExtFactory = "";
            this.cdvRwkRetFlow.ListCond_Step = '1';
            this.cdvRwkRetFlow.Location = new System.Drawing.Point(12, 94);
            this.cdvRwkRetFlow.Name = "cdvRwkRetFlow";
            this.cdvRwkRetFlow.SearchSubItemIndex = 0;
            this.cdvRwkRetFlow.SelectedDescIndex = -1;
            this.cdvRwkRetFlow.SelectedSubItemIndex = 0;
            this.cdvRwkRetFlow.SequenceReadOnly = false;
            this.cdvRwkRetFlow.Size = new System.Drawing.Size(299, 20);
            this.cdvRwkRetFlow.TabIndex = 6;
            this.cdvRwkRetFlow.VisibleColumnHeader = false;
            this.cdvRwkRetFlow.VisibleDescription = false;
            this.cdvRwkRetFlow.VisibleFlowButton = true;
            this.cdvRwkRetFlow.VisibleSequenceButton = true;
            this.cdvRwkRetFlow.WidthButton = 20;
            this.cdvRwkRetFlow.WidthFlowAndSequence = 166;
            this.cdvRwkRetFlow.WidthSequence = 50;
            this.cdvRwkRetFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRwkRetFlow_FlowSelectedItemChanged);
            this.cdvRwkRetFlow.FlowButtonPress += new System.EventHandler(this.cdvRwkRetFlow_FlowButtonPress);
            // 
            // txtRwkTime
            // 
            this.txtRwkTime.Location = new System.Drawing.Point(145, 214);
            this.txtRwkTime.MaxLength = 30;
            this.txtRwkTime.Name = "txtRwkTime";
            this.txtRwkTime.Size = new System.Drawing.Size(166, 20);
            this.txtRwkTime.TabIndex = 15;
            // 
            // dtpRwkTime
            // 
            this.dtpRwkTime.CustomFormat = "yyyy-MM-dd  HH:mm:ss";
            this.dtpRwkTime.Enabled = false;
            this.dtpRwkTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRwkTime.Location = new System.Drawing.Point(145, 214);
            this.dtpRwkTime.Name = "dtpRwkTime";
            this.dtpRwkTime.Size = new System.Drawing.Size(166, 20);
            this.dtpRwkTime.TabIndex = 15;
            // 
            // lblReworkTime
            // 
            this.lblReworkTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkTime.Location = new System.Drawing.Point(12, 217);
            this.lblReworkTime.Name = "lblReworkTime";
            this.lblReworkTime.Size = new System.Drawing.Size(115, 14);
            this.lblReworkTime.TabIndex = 14;
            this.lblReworkTime.Text = "Rework Time";
            // 
            // cdvRwkEndOper
            // 
            this.cdvRwkEndOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRwkEndOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRwkEndOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRwkEndOper.BtnToolTipText = "";
            this.cdvRwkEndOper.DescText = "";
            this.cdvRwkEndOper.DisplaySubItemIndex = -1;
            this.cdvRwkEndOper.DisplayText = "";
            this.cdvRwkEndOper.Focusing = null;
            this.cdvRwkEndOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkEndOper.Index = 0;
            this.cdvRwkEndOper.IsViewBtnImage = false;
            this.cdvRwkEndOper.Location = new System.Drawing.Point(145, 166);
            this.cdvRwkEndOper.MaxLength = 10;
            this.cdvRwkEndOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRwkEndOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRwkEndOper.Name = "cdvRwkEndOper";
            this.cdvRwkEndOper.ReadOnly = false;
            this.cdvRwkEndOper.SearchSubItemIndex = 0;
            this.cdvRwkEndOper.SelectedDescIndex = -1;
            this.cdvRwkEndOper.SelectedSubItemIndex = -1;
            this.cdvRwkEndOper.SelectionStart = 0;
            this.cdvRwkEndOper.Size = new System.Drawing.Size(166, 20);
            this.cdvRwkEndOper.SmallImageList = null;
            this.cdvRwkEndOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRwkEndOper.TabIndex = 11;
            this.cdvRwkEndOper.TextBoxToolTipText = "";
            this.cdvRwkEndOper.TextBoxWidth = 166;
            this.cdvRwkEndOper.VisibleButton = true;
            this.cdvRwkEndOper.VisibleColumnHeader = false;
            this.cdvRwkEndOper.VisibleDescription = false;
            this.cdvRwkEndOper.ButtonPress += new System.EventHandler(this.cdvRwkEndOper_ButtonPress);
            // 
            // cdvRwkRetOper
            // 
            this.cdvRwkRetOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRwkRetOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRwkRetOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRwkRetOper.BtnToolTipText = "";
            this.cdvRwkRetOper.DescText = "";
            this.cdvRwkRetOper.DisplaySubItemIndex = -1;
            this.cdvRwkRetOper.DisplayText = "";
            this.cdvRwkRetOper.Focusing = null;
            this.cdvRwkRetOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkRetOper.Index = 0;
            this.cdvRwkRetOper.IsViewBtnImage = false;
            this.cdvRwkRetOper.Location = new System.Drawing.Point(145, 118);
            this.cdvRwkRetOper.MaxLength = 10;
            this.cdvRwkRetOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRwkRetOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRwkRetOper.Name = "cdvRwkRetOper";
            this.cdvRwkRetOper.ReadOnly = false;
            this.cdvRwkRetOper.SearchSubItemIndex = 0;
            this.cdvRwkRetOper.SelectedDescIndex = -1;
            this.cdvRwkRetOper.SelectedSubItemIndex = -1;
            this.cdvRwkRetOper.SelectionStart = 0;
            this.cdvRwkRetOper.Size = new System.Drawing.Size(166, 20);
            this.cdvRwkRetOper.SmallImageList = null;
            this.cdvRwkRetOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRwkRetOper.TabIndex = 8;
            this.cdvRwkRetOper.TextBoxToolTipText = "";
            this.cdvRwkRetOper.TextBoxWidth = 166;
            this.cdvRwkRetOper.VisibleButton = true;
            this.cdvRwkRetOper.VisibleColumnHeader = false;
            this.cdvRwkRetOper.VisibleDescription = false;
            this.cdvRwkRetOper.ButtonPress += new System.EventHandler(this.cdvRwkRetOper_ButtonPress);
            // 
            // cdvRwkCode
            // 
            this.cdvRwkCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRwkCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRwkCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRwkCode.BtnToolTipText = "";
            this.cdvRwkCode.DescText = "";
            this.cdvRwkCode.DisplaySubItemIndex = -1;
            this.cdvRwkCode.DisplayText = "";
            this.cdvRwkCode.Focusing = null;
            this.cdvRwkCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRwkCode.Index = 0;
            this.cdvRwkCode.IsViewBtnImage = false;
            this.cdvRwkCode.Location = new System.Drawing.Point(145, 46);
            this.cdvRwkCode.MaxLength = 10;
            this.cdvRwkCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRwkCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRwkCode.Name = "cdvRwkCode";
            this.cdvRwkCode.ReadOnly = false;
            this.cdvRwkCode.SearchSubItemIndex = 0;
            this.cdvRwkCode.SelectedDescIndex = -1;
            this.cdvRwkCode.SelectedSubItemIndex = -1;
            this.cdvRwkCode.SelectionStart = 0;
            this.cdvRwkCode.Size = new System.Drawing.Size(166, 20);
            this.cdvRwkCode.SmallImageList = null;
            this.cdvRwkCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRwkCode.TabIndex = 3;
            this.cdvRwkCode.TextBoxToolTipText = "";
            this.cdvRwkCode.TextBoxWidth = 166;
            this.cdvRwkCode.VisibleButton = true;
            this.cdvRwkCode.VisibleColumnHeader = false;
            this.cdvRwkCode.VisibleDescription = false;
            this.cdvRwkCode.ButtonPress += new System.EventHandler(this.cdvRwkCode_ButtonPress);
            // 
            // txtRwkCnt
            // 
            this.txtRwkCnt.Location = new System.Drawing.Point(145, 190);
            this.txtRwkCnt.MaxLength = 6;
            this.txtRwkCnt.Name = "txtRwkCnt";
            this.txtRwkCnt.Size = new System.Drawing.Size(166, 20);
            this.txtRwkCnt.TabIndex = 13;
            // 
            // lblReworkEndOper
            // 
            this.lblReworkEndOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkEndOper.Location = new System.Drawing.Point(12, 169);
            this.lblReworkEndOper.Name = "lblReworkEndOper";
            this.lblReworkEndOper.Size = new System.Drawing.Size(115, 14);
            this.lblReworkEndOper.TabIndex = 10;
            this.lblReworkEndOper.Text = "Rework End Oper";
            // 
            // lblReworkReturnOper
            // 
            this.lblReworkReturnOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkReturnOper.Location = new System.Drawing.Point(12, 121);
            this.lblReworkReturnOper.Name = "lblReworkReturnOper";
            this.lblReworkReturnOper.Size = new System.Drawing.Size(115, 14);
            this.lblReworkReturnOper.TabIndex = 7;
            this.lblReworkReturnOper.Text = "Rework Return Oper";
            // 
            // lblReworkCnt
            // 
            this.lblReworkCnt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkCnt.Location = new System.Drawing.Point(12, 193);
            this.lblReworkCnt.Name = "lblReworkCnt";
            this.lblReworkCnt.Size = new System.Drawing.Size(115, 14);
            this.lblReworkCnt.TabIndex = 12;
            this.lblReworkCnt.Text = "Rework Count";
            // 
            // lblReworkCode
            // 
            this.lblReworkCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkCode.Location = new System.Drawing.Point(12, 49);
            this.lblReworkCode.Name = "lblReworkCode";
            this.lblReworkCode.Size = new System.Drawing.Size(115, 14);
            this.lblReworkCode.TabIndex = 2;
            this.lblReworkCode.Text = "Rework Code";
            // 
            // chkRework
            // 
            this.chkRework.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRework.Location = new System.Drawing.Point(12, 22);
            this.chkRework.Name = "chkRework";
            this.chkRework.Size = new System.Drawing.Size(115, 14);
            this.chkRework.TabIndex = 0;
            this.chkRework.Text = "Rework Flag";
            this.chkRework.CheckedChanged += new System.EventHandler(this.chkRework_CheckedChanged);
            // 
            // tbpCrtCmf
            // 
            this.tbpCrtCmf.Controls.Add(this.grpCrtCmf);
            this.tbpCrtCmf.Location = new System.Drawing.Point(4, 22);
            this.tbpCrtCmf.Name = "tbpCrtCmf";
            this.tbpCrtCmf.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCrtCmf.Size = new System.Drawing.Size(728, 415);
            this.tbpCrtCmf.TabIndex = 3;
            this.tbpCrtCmf.Text = "Create Customized Field";
            // 
            // grpCrtCmf
            // 
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf8);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf19);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf18);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf17);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf16);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf15);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf14);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf13);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf12);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf20);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf11);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf20);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf19);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf18);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf17);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf16);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf15);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf14);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf13);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf12);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf11);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf9);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf8);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf7);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf6);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf5);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf4);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf3);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf2);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf10);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf1);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf10);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf9);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf7);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf6);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf5);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf4);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf3);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf2);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf1);
            this.grpCrtCmf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCrtCmf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCrtCmf.Location = new System.Drawing.Point(3, 3);
            this.grpCrtCmf.Name = "grpCrtCmf";
            this.grpCrtCmf.Size = new System.Drawing.Size(722, 409);
            this.grpCrtCmf.TabIndex = 0;
            this.grpCrtCmf.TabStop = false;
            // 
            // lblCrtCmf8
            // 
            this.lblCrtCmf8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf8.Location = new System.Drawing.Point(23, 187);
            this.lblCrtCmf8.Name = "lblCrtCmf8";
            this.lblCrtCmf8.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf8.TabIndex = 40;
            this.lblCrtCmf8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCrtCmf19
            // 
            this.cdvCrtCmf19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf19.BtnToolTipText = "";
            this.cdvCrtCmf19.DescText = "";
            this.cdvCrtCmf19.DisplaySubItemIndex = -1;
            this.cdvCrtCmf19.DisplayText = "";
            this.cdvCrtCmf19.Focusing = null;
            this.cdvCrtCmf19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf19.Index = 0;
            this.cdvCrtCmf19.IsViewBtnImage = false;
            this.cdvCrtCmf19.Location = new System.Drawing.Point(519, 208);
            this.cdvCrtCmf19.MaxLength = 30;
            this.cdvCrtCmf19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf19.Name = "cdvCrtCmf19";
            this.cdvCrtCmf19.ReadOnly = false;
            this.cdvCrtCmf19.SearchSubItemIndex = 0;
            this.cdvCrtCmf19.SelectedDescIndex = -1;
            this.cdvCrtCmf19.SelectedSubItemIndex = -1;
            this.cdvCrtCmf19.SelectionStart = 0;
            this.cdvCrtCmf19.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf19.SmallImageList = null;
            this.cdvCrtCmf19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf19.TabIndex = 37;
            this.cdvCrtCmf19.TextBoxToolTipText = "";
            this.cdvCrtCmf19.TextBoxWidth = 180;
            this.cdvCrtCmf19.VisibleButton = true;
            this.cdvCrtCmf19.VisibleColumnHeader = false;
            this.cdvCrtCmf19.VisibleDescription = false;
            this.cdvCrtCmf19.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf18
            // 
            this.cdvCrtCmf18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf18.BtnToolTipText = "";
            this.cdvCrtCmf18.DescText = "";
            this.cdvCrtCmf18.DisplaySubItemIndex = -1;
            this.cdvCrtCmf18.DisplayText = "";
            this.cdvCrtCmf18.Focusing = null;
            this.cdvCrtCmf18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf18.Index = 0;
            this.cdvCrtCmf18.IsViewBtnImage = false;
            this.cdvCrtCmf18.Location = new System.Drawing.Point(519, 184);
            this.cdvCrtCmf18.MaxLength = 30;
            this.cdvCrtCmf18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf18.Name = "cdvCrtCmf18";
            this.cdvCrtCmf18.ReadOnly = false;
            this.cdvCrtCmf18.SearchSubItemIndex = 0;
            this.cdvCrtCmf18.SelectedDescIndex = -1;
            this.cdvCrtCmf18.SelectedSubItemIndex = -1;
            this.cdvCrtCmf18.SelectionStart = 0;
            this.cdvCrtCmf18.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf18.SmallImageList = null;
            this.cdvCrtCmf18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf18.TabIndex = 35;
            this.cdvCrtCmf18.TextBoxToolTipText = "";
            this.cdvCrtCmf18.TextBoxWidth = 180;
            this.cdvCrtCmf18.VisibleButton = true;
            this.cdvCrtCmf18.VisibleColumnHeader = false;
            this.cdvCrtCmf18.VisibleDescription = false;
            this.cdvCrtCmf18.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf17
            // 
            this.cdvCrtCmf17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf17.BtnToolTipText = "";
            this.cdvCrtCmf17.DescText = "";
            this.cdvCrtCmf17.DisplaySubItemIndex = -1;
            this.cdvCrtCmf17.DisplayText = "";
            this.cdvCrtCmf17.Focusing = null;
            this.cdvCrtCmf17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf17.Index = 0;
            this.cdvCrtCmf17.IsViewBtnImage = false;
            this.cdvCrtCmf17.Location = new System.Drawing.Point(519, 160);
            this.cdvCrtCmf17.MaxLength = 30;
            this.cdvCrtCmf17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf17.Name = "cdvCrtCmf17";
            this.cdvCrtCmf17.ReadOnly = false;
            this.cdvCrtCmf17.SearchSubItemIndex = 0;
            this.cdvCrtCmf17.SelectedDescIndex = -1;
            this.cdvCrtCmf17.SelectedSubItemIndex = -1;
            this.cdvCrtCmf17.SelectionStart = 0;
            this.cdvCrtCmf17.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf17.SmallImageList = null;
            this.cdvCrtCmf17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf17.TabIndex = 33;
            this.cdvCrtCmf17.TextBoxToolTipText = "";
            this.cdvCrtCmf17.TextBoxWidth = 180;
            this.cdvCrtCmf17.VisibleButton = true;
            this.cdvCrtCmf17.VisibleColumnHeader = false;
            this.cdvCrtCmf17.VisibleDescription = false;
            this.cdvCrtCmf17.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf16
            // 
            this.cdvCrtCmf16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf16.BtnToolTipText = "";
            this.cdvCrtCmf16.DescText = "";
            this.cdvCrtCmf16.DisplaySubItemIndex = -1;
            this.cdvCrtCmf16.DisplayText = "";
            this.cdvCrtCmf16.Focusing = null;
            this.cdvCrtCmf16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf16.Index = 0;
            this.cdvCrtCmf16.IsViewBtnImage = false;
            this.cdvCrtCmf16.Location = new System.Drawing.Point(519, 136);
            this.cdvCrtCmf16.MaxLength = 30;
            this.cdvCrtCmf16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf16.Name = "cdvCrtCmf16";
            this.cdvCrtCmf16.ReadOnly = false;
            this.cdvCrtCmf16.SearchSubItemIndex = 0;
            this.cdvCrtCmf16.SelectedDescIndex = -1;
            this.cdvCrtCmf16.SelectedSubItemIndex = -1;
            this.cdvCrtCmf16.SelectionStart = 0;
            this.cdvCrtCmf16.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf16.SmallImageList = null;
            this.cdvCrtCmf16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf16.TabIndex = 31;
            this.cdvCrtCmf16.TextBoxToolTipText = "";
            this.cdvCrtCmf16.TextBoxWidth = 180;
            this.cdvCrtCmf16.VisibleButton = true;
            this.cdvCrtCmf16.VisibleColumnHeader = false;
            this.cdvCrtCmf16.VisibleDescription = false;
            this.cdvCrtCmf16.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf15
            // 
            this.cdvCrtCmf15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf15.BtnToolTipText = "";
            this.cdvCrtCmf15.DescText = "";
            this.cdvCrtCmf15.DisplaySubItemIndex = -1;
            this.cdvCrtCmf15.DisplayText = "";
            this.cdvCrtCmf15.Focusing = null;
            this.cdvCrtCmf15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf15.Index = 0;
            this.cdvCrtCmf15.IsViewBtnImage = false;
            this.cdvCrtCmf15.Location = new System.Drawing.Point(519, 112);
            this.cdvCrtCmf15.MaxLength = 30;
            this.cdvCrtCmf15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf15.Name = "cdvCrtCmf15";
            this.cdvCrtCmf15.ReadOnly = false;
            this.cdvCrtCmf15.SearchSubItemIndex = 0;
            this.cdvCrtCmf15.SelectedDescIndex = -1;
            this.cdvCrtCmf15.SelectedSubItemIndex = -1;
            this.cdvCrtCmf15.SelectionStart = 0;
            this.cdvCrtCmf15.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf15.SmallImageList = null;
            this.cdvCrtCmf15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf15.TabIndex = 29;
            this.cdvCrtCmf15.TextBoxToolTipText = "";
            this.cdvCrtCmf15.TextBoxWidth = 180;
            this.cdvCrtCmf15.VisibleButton = true;
            this.cdvCrtCmf15.VisibleColumnHeader = false;
            this.cdvCrtCmf15.VisibleDescription = false;
            this.cdvCrtCmf15.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf14
            // 
            this.cdvCrtCmf14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf14.BtnToolTipText = "";
            this.cdvCrtCmf14.DescText = "";
            this.cdvCrtCmf14.DisplaySubItemIndex = -1;
            this.cdvCrtCmf14.DisplayText = "";
            this.cdvCrtCmf14.Focusing = null;
            this.cdvCrtCmf14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf14.Index = 0;
            this.cdvCrtCmf14.IsViewBtnImage = false;
            this.cdvCrtCmf14.Location = new System.Drawing.Point(519, 88);
            this.cdvCrtCmf14.MaxLength = 30;
            this.cdvCrtCmf14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf14.Name = "cdvCrtCmf14";
            this.cdvCrtCmf14.ReadOnly = false;
            this.cdvCrtCmf14.SearchSubItemIndex = 0;
            this.cdvCrtCmf14.SelectedDescIndex = -1;
            this.cdvCrtCmf14.SelectedSubItemIndex = -1;
            this.cdvCrtCmf14.SelectionStart = 0;
            this.cdvCrtCmf14.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf14.SmallImageList = null;
            this.cdvCrtCmf14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf14.TabIndex = 27;
            this.cdvCrtCmf14.TextBoxToolTipText = "";
            this.cdvCrtCmf14.TextBoxWidth = 180;
            this.cdvCrtCmf14.VisibleButton = true;
            this.cdvCrtCmf14.VisibleColumnHeader = false;
            this.cdvCrtCmf14.VisibleDescription = false;
            this.cdvCrtCmf14.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf13
            // 
            this.cdvCrtCmf13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf13.BtnToolTipText = "";
            this.cdvCrtCmf13.DescText = "";
            this.cdvCrtCmf13.DisplaySubItemIndex = -1;
            this.cdvCrtCmf13.DisplayText = "";
            this.cdvCrtCmf13.Focusing = null;
            this.cdvCrtCmf13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf13.Index = 0;
            this.cdvCrtCmf13.IsViewBtnImage = false;
            this.cdvCrtCmf13.Location = new System.Drawing.Point(519, 64);
            this.cdvCrtCmf13.MaxLength = 30;
            this.cdvCrtCmf13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf13.Name = "cdvCrtCmf13";
            this.cdvCrtCmf13.ReadOnly = false;
            this.cdvCrtCmf13.SearchSubItemIndex = 0;
            this.cdvCrtCmf13.SelectedDescIndex = -1;
            this.cdvCrtCmf13.SelectedSubItemIndex = -1;
            this.cdvCrtCmf13.SelectionStart = 0;
            this.cdvCrtCmf13.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf13.SmallImageList = null;
            this.cdvCrtCmf13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf13.TabIndex = 25;
            this.cdvCrtCmf13.TextBoxToolTipText = "";
            this.cdvCrtCmf13.TextBoxWidth = 180;
            this.cdvCrtCmf13.VisibleButton = true;
            this.cdvCrtCmf13.VisibleColumnHeader = false;
            this.cdvCrtCmf13.VisibleDescription = false;
            this.cdvCrtCmf13.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf12
            // 
            this.cdvCrtCmf12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf12.BtnToolTipText = "";
            this.cdvCrtCmf12.DescText = "";
            this.cdvCrtCmf12.DisplaySubItemIndex = -1;
            this.cdvCrtCmf12.DisplayText = "";
            this.cdvCrtCmf12.Focusing = null;
            this.cdvCrtCmf12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf12.Index = 0;
            this.cdvCrtCmf12.IsViewBtnImage = false;
            this.cdvCrtCmf12.Location = new System.Drawing.Point(519, 40);
            this.cdvCrtCmf12.MaxLength = 30;
            this.cdvCrtCmf12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf12.Name = "cdvCrtCmf12";
            this.cdvCrtCmf12.ReadOnly = false;
            this.cdvCrtCmf12.SearchSubItemIndex = 0;
            this.cdvCrtCmf12.SelectedDescIndex = -1;
            this.cdvCrtCmf12.SelectedSubItemIndex = -1;
            this.cdvCrtCmf12.SelectionStart = 0;
            this.cdvCrtCmf12.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf12.SmallImageList = null;
            this.cdvCrtCmf12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf12.TabIndex = 23;
            this.cdvCrtCmf12.TextBoxToolTipText = "";
            this.cdvCrtCmf12.TextBoxWidth = 180;
            this.cdvCrtCmf12.VisibleButton = true;
            this.cdvCrtCmf12.VisibleColumnHeader = false;
            this.cdvCrtCmf12.VisibleDescription = false;
            this.cdvCrtCmf12.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf20
            // 
            this.cdvCrtCmf20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf20.BtnToolTipText = "";
            this.cdvCrtCmf20.DescText = "";
            this.cdvCrtCmf20.DisplaySubItemIndex = -1;
            this.cdvCrtCmf20.DisplayText = "";
            this.cdvCrtCmf20.Focusing = null;
            this.cdvCrtCmf20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf20.Index = 0;
            this.cdvCrtCmf20.IsViewBtnImage = false;
            this.cdvCrtCmf20.Location = new System.Drawing.Point(519, 232);
            this.cdvCrtCmf20.MaxLength = 30;
            this.cdvCrtCmf20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf20.Name = "cdvCrtCmf20";
            this.cdvCrtCmf20.ReadOnly = false;
            this.cdvCrtCmf20.SearchSubItemIndex = 0;
            this.cdvCrtCmf20.SelectedDescIndex = -1;
            this.cdvCrtCmf20.SelectedSubItemIndex = -1;
            this.cdvCrtCmf20.SelectionStart = 0;
            this.cdvCrtCmf20.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf20.SmallImageList = null;
            this.cdvCrtCmf20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf20.TabIndex = 39;
            this.cdvCrtCmf20.TextBoxToolTipText = "";
            this.cdvCrtCmf20.TextBoxWidth = 180;
            this.cdvCrtCmf20.VisibleButton = true;
            this.cdvCrtCmf20.VisibleColumnHeader = false;
            this.cdvCrtCmf20.VisibleDescription = false;
            this.cdvCrtCmf20.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf11
            // 
            this.cdvCrtCmf11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf11.BtnToolTipText = "";
            this.cdvCrtCmf11.DescText = "";
            this.cdvCrtCmf11.DisplaySubItemIndex = -1;
            this.cdvCrtCmf11.DisplayText = "";
            this.cdvCrtCmf11.Focusing = null;
            this.cdvCrtCmf11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf11.Index = 0;
            this.cdvCrtCmf11.IsViewBtnImage = false;
            this.cdvCrtCmf11.Location = new System.Drawing.Point(519, 16);
            this.cdvCrtCmf11.MaxLength = 30;
            this.cdvCrtCmf11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf11.Name = "cdvCrtCmf11";
            this.cdvCrtCmf11.ReadOnly = false;
            this.cdvCrtCmf11.SearchSubItemIndex = 0;
            this.cdvCrtCmf11.SelectedDescIndex = -1;
            this.cdvCrtCmf11.SelectedSubItemIndex = -1;
            this.cdvCrtCmf11.SelectionStart = 0;
            this.cdvCrtCmf11.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf11.SmallImageList = null;
            this.cdvCrtCmf11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf11.TabIndex = 21;
            this.cdvCrtCmf11.TextBoxToolTipText = "";
            this.cdvCrtCmf11.TextBoxWidth = 180;
            this.cdvCrtCmf11.VisibleButton = true;
            this.cdvCrtCmf11.VisibleColumnHeader = false;
            this.cdvCrtCmf11.VisibleDescription = false;
            this.cdvCrtCmf11.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // lblCrtCmf20
            // 
            this.lblCrtCmf20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf20.Location = new System.Drawing.Point(373, 236);
            this.lblCrtCmf20.Name = "lblCrtCmf20";
            this.lblCrtCmf20.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf20.TabIndex = 38;
            this.lblCrtCmf20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf19
            // 
            this.lblCrtCmf19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf19.Location = new System.Drawing.Point(373, 212);
            this.lblCrtCmf19.Name = "lblCrtCmf19";
            this.lblCrtCmf19.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf19.TabIndex = 36;
            this.lblCrtCmf19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf18
            // 
            this.lblCrtCmf18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf18.Location = new System.Drawing.Point(373, 188);
            this.lblCrtCmf18.Name = "lblCrtCmf18";
            this.lblCrtCmf18.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf18.TabIndex = 34;
            this.lblCrtCmf18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf17
            // 
            this.lblCrtCmf17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf17.Location = new System.Drawing.Point(373, 164);
            this.lblCrtCmf17.Name = "lblCrtCmf17";
            this.lblCrtCmf17.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf17.TabIndex = 32;
            this.lblCrtCmf17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf16
            // 
            this.lblCrtCmf16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf16.Location = new System.Drawing.Point(373, 140);
            this.lblCrtCmf16.Name = "lblCrtCmf16";
            this.lblCrtCmf16.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf16.TabIndex = 30;
            this.lblCrtCmf16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf15
            // 
            this.lblCrtCmf15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf15.Location = new System.Drawing.Point(373, 116);
            this.lblCrtCmf15.Name = "lblCrtCmf15";
            this.lblCrtCmf15.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf15.TabIndex = 28;
            this.lblCrtCmf15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf14
            // 
            this.lblCrtCmf14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf14.Location = new System.Drawing.Point(373, 92);
            this.lblCrtCmf14.Name = "lblCrtCmf14";
            this.lblCrtCmf14.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf14.TabIndex = 26;
            this.lblCrtCmf14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf13
            // 
            this.lblCrtCmf13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf13.Location = new System.Drawing.Point(373, 68);
            this.lblCrtCmf13.Name = "lblCrtCmf13";
            this.lblCrtCmf13.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf13.TabIndex = 24;
            this.lblCrtCmf13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf12
            // 
            this.lblCrtCmf12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf12.Location = new System.Drawing.Point(373, 44);
            this.lblCrtCmf12.Name = "lblCrtCmf12";
            this.lblCrtCmf12.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf12.TabIndex = 22;
            this.lblCrtCmf12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf11
            // 
            this.lblCrtCmf11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf11.Location = new System.Drawing.Point(373, 20);
            this.lblCrtCmf11.Name = "lblCrtCmf11";
            this.lblCrtCmf11.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf11.TabIndex = 20;
            this.lblCrtCmf11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCrtCmf9
            // 
            this.cdvCrtCmf9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf9.BtnToolTipText = "";
            this.cdvCrtCmf9.DescText = "";
            this.cdvCrtCmf9.DisplaySubItemIndex = -1;
            this.cdvCrtCmf9.DisplayText = "";
            this.cdvCrtCmf9.Focusing = null;
            this.cdvCrtCmf9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf9.Index = 0;
            this.cdvCrtCmf9.IsViewBtnImage = false;
            this.cdvCrtCmf9.Location = new System.Drawing.Point(169, 208);
            this.cdvCrtCmf9.MaxLength = 30;
            this.cdvCrtCmf9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf9.Name = "cdvCrtCmf9";
            this.cdvCrtCmf9.ReadOnly = false;
            this.cdvCrtCmf9.SearchSubItemIndex = 0;
            this.cdvCrtCmf9.SelectedDescIndex = -1;
            this.cdvCrtCmf9.SelectedSubItemIndex = -1;
            this.cdvCrtCmf9.SelectionStart = 0;
            this.cdvCrtCmf9.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf9.SmallImageList = null;
            this.cdvCrtCmf9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf9.TabIndex = 17;
            this.cdvCrtCmf9.TextBoxToolTipText = "";
            this.cdvCrtCmf9.TextBoxWidth = 180;
            this.cdvCrtCmf9.VisibleButton = true;
            this.cdvCrtCmf9.VisibleColumnHeader = false;
            this.cdvCrtCmf9.VisibleDescription = false;
            this.cdvCrtCmf9.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf8
            // 
            this.cdvCrtCmf8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf8.BtnToolTipText = "";
            this.cdvCrtCmf8.DescText = "";
            this.cdvCrtCmf8.DisplaySubItemIndex = -1;
            this.cdvCrtCmf8.DisplayText = "";
            this.cdvCrtCmf8.Focusing = null;
            this.cdvCrtCmf8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf8.Index = 0;
            this.cdvCrtCmf8.IsViewBtnImage = false;
            this.cdvCrtCmf8.Location = new System.Drawing.Point(169, 184);
            this.cdvCrtCmf8.MaxLength = 30;
            this.cdvCrtCmf8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf8.Name = "cdvCrtCmf8";
            this.cdvCrtCmf8.ReadOnly = false;
            this.cdvCrtCmf8.SearchSubItemIndex = 0;
            this.cdvCrtCmf8.SelectedDescIndex = -1;
            this.cdvCrtCmf8.SelectedSubItemIndex = -1;
            this.cdvCrtCmf8.SelectionStart = 0;
            this.cdvCrtCmf8.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf8.SmallImageList = null;
            this.cdvCrtCmf8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf8.TabIndex = 15;
            this.cdvCrtCmf8.TextBoxToolTipText = "";
            this.cdvCrtCmf8.TextBoxWidth = 180;
            this.cdvCrtCmf8.VisibleButton = true;
            this.cdvCrtCmf8.VisibleColumnHeader = false;
            this.cdvCrtCmf8.VisibleDescription = false;
            this.cdvCrtCmf8.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf7
            // 
            this.cdvCrtCmf7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf7.BtnToolTipText = "";
            this.cdvCrtCmf7.DescText = "";
            this.cdvCrtCmf7.DisplaySubItemIndex = -1;
            this.cdvCrtCmf7.DisplayText = "";
            this.cdvCrtCmf7.Focusing = null;
            this.cdvCrtCmf7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf7.Index = 0;
            this.cdvCrtCmf7.IsViewBtnImage = false;
            this.cdvCrtCmf7.Location = new System.Drawing.Point(169, 160);
            this.cdvCrtCmf7.MaxLength = 30;
            this.cdvCrtCmf7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf7.Name = "cdvCrtCmf7";
            this.cdvCrtCmf7.ReadOnly = false;
            this.cdvCrtCmf7.SearchSubItemIndex = 0;
            this.cdvCrtCmf7.SelectedDescIndex = -1;
            this.cdvCrtCmf7.SelectedSubItemIndex = -1;
            this.cdvCrtCmf7.SelectionStart = 0;
            this.cdvCrtCmf7.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf7.SmallImageList = null;
            this.cdvCrtCmf7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf7.TabIndex = 13;
            this.cdvCrtCmf7.TextBoxToolTipText = "";
            this.cdvCrtCmf7.TextBoxWidth = 180;
            this.cdvCrtCmf7.VisibleButton = true;
            this.cdvCrtCmf7.VisibleColumnHeader = false;
            this.cdvCrtCmf7.VisibleDescription = false;
            this.cdvCrtCmf7.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf6
            // 
            this.cdvCrtCmf6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf6.BtnToolTipText = "";
            this.cdvCrtCmf6.DescText = "";
            this.cdvCrtCmf6.DisplaySubItemIndex = -1;
            this.cdvCrtCmf6.DisplayText = "";
            this.cdvCrtCmf6.Focusing = null;
            this.cdvCrtCmf6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf6.Index = 0;
            this.cdvCrtCmf6.IsViewBtnImage = false;
            this.cdvCrtCmf6.Location = new System.Drawing.Point(169, 136);
            this.cdvCrtCmf6.MaxLength = 30;
            this.cdvCrtCmf6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf6.Name = "cdvCrtCmf6";
            this.cdvCrtCmf6.ReadOnly = false;
            this.cdvCrtCmf6.SearchSubItemIndex = 0;
            this.cdvCrtCmf6.SelectedDescIndex = -1;
            this.cdvCrtCmf6.SelectedSubItemIndex = -1;
            this.cdvCrtCmf6.SelectionStart = 0;
            this.cdvCrtCmf6.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf6.SmallImageList = null;
            this.cdvCrtCmf6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf6.TabIndex = 11;
            this.cdvCrtCmf6.TextBoxToolTipText = "";
            this.cdvCrtCmf6.TextBoxWidth = 180;
            this.cdvCrtCmf6.VisibleButton = true;
            this.cdvCrtCmf6.VisibleColumnHeader = false;
            this.cdvCrtCmf6.VisibleDescription = false;
            this.cdvCrtCmf6.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf5
            // 
            this.cdvCrtCmf5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf5.BtnToolTipText = "";
            this.cdvCrtCmf5.DescText = "";
            this.cdvCrtCmf5.DisplaySubItemIndex = -1;
            this.cdvCrtCmf5.DisplayText = "";
            this.cdvCrtCmf5.Focusing = null;
            this.cdvCrtCmf5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf5.Index = 0;
            this.cdvCrtCmf5.IsViewBtnImage = false;
            this.cdvCrtCmf5.Location = new System.Drawing.Point(169, 112);
            this.cdvCrtCmf5.MaxLength = 30;
            this.cdvCrtCmf5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf5.Name = "cdvCrtCmf5";
            this.cdvCrtCmf5.ReadOnly = false;
            this.cdvCrtCmf5.SearchSubItemIndex = 0;
            this.cdvCrtCmf5.SelectedDescIndex = -1;
            this.cdvCrtCmf5.SelectedSubItemIndex = -1;
            this.cdvCrtCmf5.SelectionStart = 0;
            this.cdvCrtCmf5.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf5.SmallImageList = null;
            this.cdvCrtCmf5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf5.TabIndex = 9;
            this.cdvCrtCmf5.TextBoxToolTipText = "";
            this.cdvCrtCmf5.TextBoxWidth = 180;
            this.cdvCrtCmf5.VisibleButton = true;
            this.cdvCrtCmf5.VisibleColumnHeader = false;
            this.cdvCrtCmf5.VisibleDescription = false;
            this.cdvCrtCmf5.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf4
            // 
            this.cdvCrtCmf4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf4.BtnToolTipText = "";
            this.cdvCrtCmf4.DescText = "";
            this.cdvCrtCmf4.DisplaySubItemIndex = -1;
            this.cdvCrtCmf4.DisplayText = "";
            this.cdvCrtCmf4.Focusing = null;
            this.cdvCrtCmf4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf4.Index = 0;
            this.cdvCrtCmf4.IsViewBtnImage = false;
            this.cdvCrtCmf4.Location = new System.Drawing.Point(169, 88);
            this.cdvCrtCmf4.MaxLength = 30;
            this.cdvCrtCmf4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf4.Name = "cdvCrtCmf4";
            this.cdvCrtCmf4.ReadOnly = false;
            this.cdvCrtCmf4.SearchSubItemIndex = 0;
            this.cdvCrtCmf4.SelectedDescIndex = -1;
            this.cdvCrtCmf4.SelectedSubItemIndex = -1;
            this.cdvCrtCmf4.SelectionStart = 0;
            this.cdvCrtCmf4.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf4.SmallImageList = null;
            this.cdvCrtCmf4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf4.TabIndex = 7;
            this.cdvCrtCmf4.TextBoxToolTipText = "";
            this.cdvCrtCmf4.TextBoxWidth = 180;
            this.cdvCrtCmf4.VisibleButton = true;
            this.cdvCrtCmf4.VisibleColumnHeader = false;
            this.cdvCrtCmf4.VisibleDescription = false;
            this.cdvCrtCmf4.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf3
            // 
            this.cdvCrtCmf3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf3.BtnToolTipText = "";
            this.cdvCrtCmf3.DescText = "";
            this.cdvCrtCmf3.DisplaySubItemIndex = -1;
            this.cdvCrtCmf3.DisplayText = "";
            this.cdvCrtCmf3.Focusing = null;
            this.cdvCrtCmf3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf3.Index = 0;
            this.cdvCrtCmf3.IsViewBtnImage = false;
            this.cdvCrtCmf3.Location = new System.Drawing.Point(169, 64);
            this.cdvCrtCmf3.MaxLength = 30;
            this.cdvCrtCmf3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf3.Name = "cdvCrtCmf3";
            this.cdvCrtCmf3.ReadOnly = false;
            this.cdvCrtCmf3.SearchSubItemIndex = 0;
            this.cdvCrtCmf3.SelectedDescIndex = -1;
            this.cdvCrtCmf3.SelectedSubItemIndex = -1;
            this.cdvCrtCmf3.SelectionStart = 0;
            this.cdvCrtCmf3.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf3.SmallImageList = null;
            this.cdvCrtCmf3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf3.TabIndex = 5;
            this.cdvCrtCmf3.TextBoxToolTipText = "";
            this.cdvCrtCmf3.TextBoxWidth = 180;
            this.cdvCrtCmf3.VisibleButton = true;
            this.cdvCrtCmf3.VisibleColumnHeader = false;
            this.cdvCrtCmf3.VisibleDescription = false;
            this.cdvCrtCmf3.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf2
            // 
            this.cdvCrtCmf2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf2.BtnToolTipText = "";
            this.cdvCrtCmf2.DescText = "";
            this.cdvCrtCmf2.DisplaySubItemIndex = -1;
            this.cdvCrtCmf2.DisplayText = "";
            this.cdvCrtCmf2.Focusing = null;
            this.cdvCrtCmf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf2.Index = 0;
            this.cdvCrtCmf2.IsViewBtnImage = false;
            this.cdvCrtCmf2.Location = new System.Drawing.Point(169, 40);
            this.cdvCrtCmf2.MaxLength = 30;
            this.cdvCrtCmf2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf2.Name = "cdvCrtCmf2";
            this.cdvCrtCmf2.ReadOnly = false;
            this.cdvCrtCmf2.SearchSubItemIndex = 0;
            this.cdvCrtCmf2.SelectedDescIndex = -1;
            this.cdvCrtCmf2.SelectedSubItemIndex = -1;
            this.cdvCrtCmf2.SelectionStart = 0;
            this.cdvCrtCmf2.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf2.SmallImageList = null;
            this.cdvCrtCmf2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf2.TabIndex = 3;
            this.cdvCrtCmf2.TextBoxToolTipText = "";
            this.cdvCrtCmf2.TextBoxWidth = 180;
            this.cdvCrtCmf2.VisibleButton = true;
            this.cdvCrtCmf2.VisibleColumnHeader = false;
            this.cdvCrtCmf2.VisibleDescription = false;
            this.cdvCrtCmf2.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf10
            // 
            this.cdvCrtCmf10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf10.BtnToolTipText = "";
            this.cdvCrtCmf10.DescText = "";
            this.cdvCrtCmf10.DisplaySubItemIndex = -1;
            this.cdvCrtCmf10.DisplayText = "";
            this.cdvCrtCmf10.Focusing = null;
            this.cdvCrtCmf10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf10.Index = 0;
            this.cdvCrtCmf10.IsViewBtnImage = false;
            this.cdvCrtCmf10.Location = new System.Drawing.Point(169, 232);
            this.cdvCrtCmf10.MaxLength = 30;
            this.cdvCrtCmf10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf10.Name = "cdvCrtCmf10";
            this.cdvCrtCmf10.ReadOnly = false;
            this.cdvCrtCmf10.SearchSubItemIndex = 0;
            this.cdvCrtCmf10.SelectedDescIndex = -1;
            this.cdvCrtCmf10.SelectedSubItemIndex = -1;
            this.cdvCrtCmf10.SelectionStart = 0;
            this.cdvCrtCmf10.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf10.SmallImageList = null;
            this.cdvCrtCmf10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf10.TabIndex = 19;
            this.cdvCrtCmf10.TextBoxToolTipText = "";
            this.cdvCrtCmf10.TextBoxWidth = 180;
            this.cdvCrtCmf10.VisibleButton = true;
            this.cdvCrtCmf10.VisibleColumnHeader = false;
            this.cdvCrtCmf10.VisibleDescription = false;
            this.cdvCrtCmf10.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf1
            // 
            this.cdvCrtCmf1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf1.BtnToolTipText = "";
            this.cdvCrtCmf1.DescText = "";
            this.cdvCrtCmf1.DisplaySubItemIndex = -1;
            this.cdvCrtCmf1.DisplayText = "";
            this.cdvCrtCmf1.Focusing = null;
            this.cdvCrtCmf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf1.Index = 0;
            this.cdvCrtCmf1.IsViewBtnImage = false;
            this.cdvCrtCmf1.Location = new System.Drawing.Point(169, 16);
            this.cdvCrtCmf1.MaxLength = 30;
            this.cdvCrtCmf1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf1.Name = "cdvCrtCmf1";
            this.cdvCrtCmf1.ReadOnly = false;
            this.cdvCrtCmf1.SearchSubItemIndex = 0;
            this.cdvCrtCmf1.SelectedDescIndex = -1;
            this.cdvCrtCmf1.SelectedSubItemIndex = -1;
            this.cdvCrtCmf1.SelectionStart = 0;
            this.cdvCrtCmf1.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf1.SmallImageList = null;
            this.cdvCrtCmf1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf1.TabIndex = 1;
            this.cdvCrtCmf1.TextBoxToolTipText = "";
            this.cdvCrtCmf1.TextBoxWidth = 180;
            this.cdvCrtCmf1.VisibleButton = true;
            this.cdvCrtCmf1.VisibleColumnHeader = false;
            this.cdvCrtCmf1.VisibleDescription = false;
            this.cdvCrtCmf1.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // lblCrtCmf10
            // 
            this.lblCrtCmf10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf10.Location = new System.Drawing.Point(23, 235);
            this.lblCrtCmf10.Name = "lblCrtCmf10";
            this.lblCrtCmf10.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf10.TabIndex = 18;
            this.lblCrtCmf10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf9
            // 
            this.lblCrtCmf9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf9.Location = new System.Drawing.Point(23, 211);
            this.lblCrtCmf9.Name = "lblCrtCmf9";
            this.lblCrtCmf9.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf9.TabIndex = 16;
            this.lblCrtCmf9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf7
            // 
            this.lblCrtCmf7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf7.Location = new System.Drawing.Point(23, 163);
            this.lblCrtCmf7.Name = "lblCrtCmf7";
            this.lblCrtCmf7.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf7.TabIndex = 12;
            this.lblCrtCmf7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf6
            // 
            this.lblCrtCmf6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf6.Location = new System.Drawing.Point(23, 139);
            this.lblCrtCmf6.Name = "lblCrtCmf6";
            this.lblCrtCmf6.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf6.TabIndex = 10;
            this.lblCrtCmf6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf5
            // 
            this.lblCrtCmf5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf5.Location = new System.Drawing.Point(23, 115);
            this.lblCrtCmf5.Name = "lblCrtCmf5";
            this.lblCrtCmf5.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf5.TabIndex = 8;
            this.lblCrtCmf5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf4
            // 
            this.lblCrtCmf4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf4.Location = new System.Drawing.Point(23, 91);
            this.lblCrtCmf4.Name = "lblCrtCmf4";
            this.lblCrtCmf4.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf4.TabIndex = 6;
            this.lblCrtCmf4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf3
            // 
            this.lblCrtCmf3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf3.Location = new System.Drawing.Point(23, 67);
            this.lblCrtCmf3.Name = "lblCrtCmf3";
            this.lblCrtCmf3.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf3.TabIndex = 4;
            this.lblCrtCmf3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf2
            // 
            this.lblCrtCmf2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf2.Location = new System.Drawing.Point(23, 43);
            this.lblCrtCmf2.Name = "lblCrtCmf2";
            this.lblCrtCmf2.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf2.TabIndex = 2;
            this.lblCrtCmf2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf1
            // 
            this.lblCrtCmf1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf1.Location = new System.Drawing.Point(23, 20);
            this.lblCrtCmf1.Name = "lblCrtCmf1";
            this.lblCrtCmf1.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf1.TabIndex = 0;
            this.lblCrtCmf1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpExtra
            // 
            this.tbpExtra.Controls.Add(this.grpExtra);
            this.tbpExtra.Location = new System.Drawing.Point(4, 22);
            this.tbpExtra.Name = "tbpExtra";
            this.tbpExtra.Padding = new System.Windows.Forms.Padding(3);
            this.tbpExtra.Size = new System.Drawing.Size(728, 415);
            this.tbpExtra.TabIndex = 4;
            this.tbpExtra.Text = "Extra Information";
            // 
            // grpExtra
            // 
            this.grpExtra.Controls.Add(this.txtYield3);
            this.grpExtra.Controls.Add(this.lblYield3);
            this.grpExtra.Controls.Add(this.txtYield2);
            this.grpExtra.Controls.Add(this.lblYield2);
            this.grpExtra.Controls.Add(this.txtYield1);
            this.grpExtra.Controls.Add(this.lblYield1);
            this.grpExtra.Controls.Add(this.cdvStrRetFlow);
            this.grpExtra.Controls.Add(this.cdvStrRetOper);
            this.grpExtra.Controls.Add(this.lblStrRetOper);
            this.grpExtra.Controls.Add(this.txtAddOrder3);
            this.grpExtra.Controls.Add(this.lblAddOrder3);
            this.grpExtra.Controls.Add(this.txtAddOrder2);
            this.grpExtra.Controls.Add(this.lblAddOrder2);
            this.grpExtra.Controls.Add(this.txtAddOrder1);
            this.grpExtra.Controls.Add(this.lblAddOrder1);
            this.grpExtra.Controls.Add(this.cdvSampleResult);
            this.grpExtra.Controls.Add(this.chkSampleWait);
            this.grpExtra.Controls.Add(this.chkSample);
            this.grpExtra.Controls.Add(this.lblSampleResult);
            this.grpExtra.Controls.Add(this.txtInvUnit);
            this.grpExtra.Controls.Add(this.lblInvUnit);
            this.grpExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExtra.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpExtra.Location = new System.Drawing.Point(3, 3);
            this.grpExtra.Name = "grpExtra";
            this.grpExtra.Size = new System.Drawing.Size(722, 409);
            this.grpExtra.TabIndex = 0;
            this.grpExtra.TabStop = false;
            this.grpExtra.Text = "Extra Information";
            // 
            // txtYield3
            // 
            this.txtYield3.Location = new System.Drawing.Point(144, 325);
            this.txtYield3.MaxLength = 21;
            this.txtYield3.Name = "txtYield3";
            this.txtYield3.Size = new System.Drawing.Size(166, 20);
            this.txtYield3.TabIndex = 24;
            // 
            // lblYield3
            // 
            this.lblYield3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblYield3.Location = new System.Drawing.Point(13, 328);
            this.lblYield3.Name = "lblYield3";
            this.lblYield3.Size = new System.Drawing.Size(115, 14);
            this.lblYield3.TabIndex = 23;
            this.lblYield3.Text = "Yield 3";
            // 
            // txtYield2
            // 
            this.txtYield2.Location = new System.Drawing.Point(144, 301);
            this.txtYield2.MaxLength = 21;
            this.txtYield2.Name = "txtYield2";
            this.txtYield2.Size = new System.Drawing.Size(166, 20);
            this.txtYield2.TabIndex = 22;
            // 
            // lblYield2
            // 
            this.lblYield2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblYield2.Location = new System.Drawing.Point(13, 304);
            this.lblYield2.Name = "lblYield2";
            this.lblYield2.Size = new System.Drawing.Size(115, 14);
            this.lblYield2.TabIndex = 21;
            this.lblYield2.Text = "Yield 2";
            // 
            // txtYield1
            // 
            this.txtYield1.Location = new System.Drawing.Point(144, 277);
            this.txtYield1.MaxLength = 21;
            this.txtYield1.Name = "txtYield1";
            this.txtYield1.Size = new System.Drawing.Size(166, 20);
            this.txtYield1.TabIndex = 20;
            // 
            // lblYield1
            // 
            this.lblYield1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblYield1.Location = new System.Drawing.Point(13, 280);
            this.lblYield1.Name = "lblYield1";
            this.lblYield1.Size = new System.Drawing.Size(115, 14);
            this.lblYield1.TabIndex = 19;
            this.lblYield1.Text = "Yield 1";
            // 
            // cdvStrRetFlow
            // 
            this.cdvStrRetFlow.AddEmptyRowToLast = false;
            this.cdvStrRetFlow.AddEmptyRowToTop = false;
            this.cdvStrRetFlow.DisplaySubItemIndex = 0;
            this.cdvStrRetFlow.FlowReadOnly = false;
            this.cdvStrRetFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvStrRetFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvStrRetFlow.LabelText = "Store Return Flow";
            this.cdvStrRetFlow.LabelWidth = 133;
            this.cdvStrRetFlow.ListCond_ExtFactory = "";
            this.cdvStrRetFlow.ListCond_Step = '1';
            this.cdvStrRetFlow.Location = new System.Drawing.Point(11, 19);
            this.cdvStrRetFlow.Name = "cdvStrRetFlow";
            this.cdvStrRetFlow.SearchSubItemIndex = 0;
            this.cdvStrRetFlow.SelectedDescIndex = -1;
            this.cdvStrRetFlow.SelectedSubItemIndex = 0;
            this.cdvStrRetFlow.SequenceReadOnly = false;
            this.cdvStrRetFlow.Size = new System.Drawing.Size(299, 20);
            this.cdvStrRetFlow.TabIndex = 0;
            this.cdvStrRetFlow.VisibleColumnHeader = false;
            this.cdvStrRetFlow.VisibleDescription = false;
            this.cdvStrRetFlow.VisibleFlowButton = true;
            this.cdvStrRetFlow.VisibleSequenceButton = true;
            this.cdvStrRetFlow.WidthButton = 20;
            this.cdvStrRetFlow.WidthFlowAndSequence = 166;
            this.cdvStrRetFlow.WidthSequence = 50;
            this.cdvStrRetFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvStrRetFlow_SelectedItemChanged);
            // 
            // cdvStrRetOper
            // 
            this.cdvStrRetOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvStrRetOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvStrRetOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvStrRetOper.BtnToolTipText = "";
            this.cdvStrRetOper.DescText = "";
            this.cdvStrRetOper.DisplaySubItemIndex = -1;
            this.cdvStrRetOper.DisplayText = "";
            this.cdvStrRetOper.Focusing = null;
            this.cdvStrRetOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvStrRetOper.Index = 0;
            this.cdvStrRetOper.IsViewBtnImage = false;
            this.cdvStrRetOper.Location = new System.Drawing.Point(144, 43);
            this.cdvStrRetOper.MaxLength = 10;
            this.cdvStrRetOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvStrRetOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvStrRetOper.Name = "cdvStrRetOper";
            this.cdvStrRetOper.ReadOnly = false;
            this.cdvStrRetOper.SearchSubItemIndex = 0;
            this.cdvStrRetOper.SelectedDescIndex = -1;
            this.cdvStrRetOper.SelectedSubItemIndex = -1;
            this.cdvStrRetOper.SelectionStart = 0;
            this.cdvStrRetOper.Size = new System.Drawing.Size(166, 20);
            this.cdvStrRetOper.SmallImageList = null;
            this.cdvStrRetOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvStrRetOper.TabIndex = 2;
            this.cdvStrRetOper.TextBoxToolTipText = "";
            this.cdvStrRetOper.TextBoxWidth = 166;
            this.cdvStrRetOper.VisibleButton = true;
            this.cdvStrRetOper.VisibleColumnHeader = false;
            this.cdvStrRetOper.VisibleDescription = false;
            this.cdvStrRetOper.ButtonPress += new System.EventHandler(this.cdvStrRetOper_ButtonPress);
            // 
            // lblStrRetOper
            // 
            this.lblStrRetOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStrRetOper.Location = new System.Drawing.Point(11, 46);
            this.lblStrRetOper.Name = "lblStrRetOper";
            this.lblStrRetOper.Size = new System.Drawing.Size(115, 14);
            this.lblStrRetOper.TabIndex = 1;
            this.lblStrRetOper.Text = "Store Return Oper";
            // 
            // txtAddOrder3
            // 
            this.txtAddOrder3.Location = new System.Drawing.Point(144, 159);
            this.txtAddOrder3.MaxLength = 25;
            this.txtAddOrder3.Name = "txtAddOrder3";
            this.txtAddOrder3.Size = new System.Drawing.Size(166, 20);
            this.txtAddOrder3.TabIndex = 14;
            // 
            // lblAddOrder3
            // 
            this.lblAddOrder3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddOrder3.Location = new System.Drawing.Point(14, 161);
            this.lblAddOrder3.Name = "lblAddOrder3";
            this.lblAddOrder3.Size = new System.Drawing.Size(115, 14);
            this.lblAddOrder3.TabIndex = 13;
            this.lblAddOrder3.Text = "Add Order ID 3";
            // 
            // txtAddOrder2
            // 
            this.txtAddOrder2.Location = new System.Drawing.Point(144, 135);
            this.txtAddOrder2.MaxLength = 25;
            this.txtAddOrder2.Name = "txtAddOrder2";
            this.txtAddOrder2.Size = new System.Drawing.Size(166, 20);
            this.txtAddOrder2.TabIndex = 12;
            // 
            // lblAddOrder2
            // 
            this.lblAddOrder2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddOrder2.Location = new System.Drawing.Point(14, 137);
            this.lblAddOrder2.Name = "lblAddOrder2";
            this.lblAddOrder2.Size = new System.Drawing.Size(115, 14);
            this.lblAddOrder2.TabIndex = 11;
            this.lblAddOrder2.Text = "Add Order ID 2";
            // 
            // txtAddOrder1
            // 
            this.txtAddOrder1.Location = new System.Drawing.Point(144, 111);
            this.txtAddOrder1.MaxLength = 25;
            this.txtAddOrder1.Name = "txtAddOrder1";
            this.txtAddOrder1.Size = new System.Drawing.Size(166, 20);
            this.txtAddOrder1.TabIndex = 10;
            // 
            // lblAddOrder1
            // 
            this.lblAddOrder1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddOrder1.Location = new System.Drawing.Point(14, 113);
            this.lblAddOrder1.Name = "lblAddOrder1";
            this.lblAddOrder1.Size = new System.Drawing.Size(115, 14);
            this.lblAddOrder1.TabIndex = 9;
            this.lblAddOrder1.Text = "Add Order ID 1";
            // 
            // cdvSampleResult
            // 
            this.cdvSampleResult.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSampleResult.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSampleResult.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSampleResult.BtnToolTipText = "";
            this.cdvSampleResult.DescText = "";
            this.cdvSampleResult.DisplaySubItemIndex = -1;
            this.cdvSampleResult.DisplayText = "";
            this.cdvSampleResult.Focusing = null;
            this.cdvSampleResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSampleResult.Index = 0;
            this.cdvSampleResult.IsViewBtnImage = false;
            this.cdvSampleResult.Location = new System.Drawing.Point(144, 243);
            this.cdvSampleResult.MaxLength = 1;
            this.cdvSampleResult.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSampleResult.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSampleResult.Name = "cdvSampleResult";
            this.cdvSampleResult.ReadOnly = false;
            this.cdvSampleResult.SearchSubItemIndex = 0;
            this.cdvSampleResult.SelectedDescIndex = -1;
            this.cdvSampleResult.SelectedSubItemIndex = -1;
            this.cdvSampleResult.SelectionStart = 0;
            this.cdvSampleResult.Size = new System.Drawing.Size(166, 20);
            this.cdvSampleResult.SmallImageList = null;
            this.cdvSampleResult.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSampleResult.TabIndex = 18;
            this.cdvSampleResult.TextBoxToolTipText = "";
            this.cdvSampleResult.TextBoxWidth = 166;
            this.cdvSampleResult.VisibleButton = true;
            this.cdvSampleResult.VisibleColumnHeader = false;
            this.cdvSampleResult.VisibleDescription = false;
            // 
            // chkSampleWait
            // 
            this.chkSampleWait.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSampleWait.Location = new System.Drawing.Point(13, 221);
            this.chkSampleWait.Name = "chkSampleWait";
            this.chkSampleWait.Size = new System.Drawing.Size(115, 14);
            this.chkSampleWait.TabIndex = 16;
            this.chkSampleWait.Text = "Sample Wait Flag";
            // 
            // chkSample
            // 
            this.chkSample.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSample.Location = new System.Drawing.Point(13, 197);
            this.chkSample.Name = "chkSample";
            this.chkSample.Size = new System.Drawing.Size(115, 14);
            this.chkSample.TabIndex = 15;
            this.chkSample.Text = "Sample Flag";
            // 
            // lblSampleResult
            // 
            this.lblSampleResult.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSampleResult.Location = new System.Drawing.Point(13, 245);
            this.lblSampleResult.Name = "lblSampleResult";
            this.lblSampleResult.Size = new System.Drawing.Size(115, 14);
            this.lblSampleResult.TabIndex = 17;
            this.lblSampleResult.Text = "Sample Result";
            // 
            // txtInvUnit
            // 
            this.txtInvUnit.Location = new System.Drawing.Point(144, 77);
            this.txtInvUnit.MaxLength = 10;
            this.txtInvUnit.Name = "txtInvUnit";
            this.txtInvUnit.Size = new System.Drawing.Size(166, 20);
            this.txtInvUnit.TabIndex = 8;
            // 
            // lblInvUnit
            // 
            this.lblInvUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInvUnit.Location = new System.Drawing.Point(13, 79);
            this.lblInvUnit.Name = "lblInvUnit";
            this.lblInvUnit.Size = new System.Drawing.Size(115, 14);
            this.lblInvUnit.TabIndex = 7;
            this.lblInvUnit.Text = "Inventory Unit";
            // 
            // frmWIPTranAdaptLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranAdaptLot";
            this.Text = "Adapt";
            this.Activated += new System.EventHandler(this.frmWIPTranAdaptLot_Activated);
            this.Load += new System.EventHandler(this.frmWIPTranAdaptLot_Load);
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
            this.grpAdapt.ResumeLayout(false);
            this.grpAdapt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOper)).EndInit();
            this.tbpRework.ResumeLayout(false);
            this.pnlReworkMid.ResumeLayout(false);
            this.grpRes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLocation3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLocation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLocation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvStartResID)).EndInit();
            this.pnlReworkLeft.ResumeLayout(false);
            this.pnlReworkLeftMid.ResumeLayout(false);
            this.grpNstd.ResumeLayout(false);
            this.grpNstd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNstdRetOper)).EndInit();
            this.pnlReworkLeftTop.ResumeLayout(false);
            this.grpRework.ResumeLayout(false);
            this.grpRework.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkStopOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkEndOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkRetOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRwkCode)).EndInit();
            this.tbpCrtCmf.ResumeLayout(false);
            this.grpCrtCmf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf1)).EndInit();
            this.tbpExtra.ResumeLayout(false);
            this.grpExtra.ResumeLayout(false);
            this.grpExtra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvStrRetOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSampleResult)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private string sReworkTable;
        private TRSNode LOT = new TRSNode("View_Lot_Out");
        
        #endregion
        
        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected bool ViewLotInfo(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("View_Lot_In");

            MPCR.SetInMsg(in_node);

            in_node.ProcStep = '3';
            in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
            {
                return false;
            }

            txtLotDesc.Text = LOT.GetString("LOT_DESC");
            cdvMaterial.Text = LOT.GetString("MAT_ID");
            cdvMaterial.Version = LOT.GetInt("MAT_VER");
            cdvMaterial.DescText = LOT.GetString("MAT_DESC");
            cdvToMatID.Text = LOT.GetString("MAT_ID");
            cdvToMatID.Version = LOT.GetInt("MAT_VER");
            cdvFlow.Text = LOT.GetString("FLOW");
            cdvFlow.Sequence = LOT.GetInt("FLOW_SEQ_NUM");
            cdvFlow.DescText = LOT.GetString("FLOW_DESC");
            cdvToFlow.Text = LOT.GetString("FLOW");
            cdvToFlow.Sequence = LOT.GetInt("FLOW_SEQ_NUM");
            txtOper.Text = LOT.GetString("OPER");
            cdvToOper.Text = LOT.GetString("OPER");
            txtOperDesc.Text = LOT.GetString("OPER_DESC");

            View_Operation();

            txtQty1.Text = LOT.GetDouble("QTY_1").ToString("########,##0.###");
            txtQty2.Text = LOT.GetDouble("QTY_2").ToString("########,##0.###");
            txtQty3.Text = LOT.GetDouble("QTY_3").ToString("########,##0.###");

            cdvLotType.Text = LOT.GetChar("LOT_TYPE").ToString();
            txtPriority.Text = LOT.GetChar("LOT_PRIORITY").ToString();

            cdvOwnerCode.Text = LOT.GetString("OWNER_CODE");
            cdvCreateCode.Text = LOT.GetString("CREATE_CODE");
            cdvShipCode.Text = LOT.GetString("SHIP_CODE");
            txtOrderID.Text = LOT.GetString("ORDER_ID");

            if (LOT.GetString("SCH_DUE_TIME") != "")
            {
                if (LOT.GetString("SCH_DUE_TIME").Length > 8)
                {
                    LOT.SetString("SCH_DUE_TIME", LOT.GetString("SCH_DUE_TIME").Substring(0, 8));
                }
                dtpDueTime.Value = MPCF.ToDate(LOT.GetString("SCH_DUE_TIME"));
            }

#if _CRR
            ViewLotCarrierList(LOT.GetString("LOT_ID"));
#endif

            chkRework.Checked = (LOT.GetChar("RWK_FLAG") == 'Y') ? true : false;

            if (LOT.GetChar("RWK_FLAG") == 'Y')
            {
                //Add by J.S. 2011.05.19 rwk_from_oper 가있을 경우 가장 우선,multi depth인경우 "RET_OPER"기준으로 가지고 온다
                if (LOT.GetString("RWK_FROM_OPER") != "")
                {
                    View_End_Operation(LOT.GetString("RWK_FROM_OPER"));
                }
                else
                {
                    if (LOT.GetInt("RWK_DEPTH") > 1)
                    {
                        if (LOT.GetString("RWK_RET_OPER") != "")
                        {
                            View_End_Operation(LOT.GetString("RWK_RET_OPER"));
                        }
                        else
                        {
                            View_End_Operation(LOT.GetString("RWK_END_OPER"));
                        }
                    }
                    else
                    {
                        View_End_Operation(LOT.GetString("RWK_END_OPER"));
                    }
                }
            }
            else
            {
                View_End_Operation(cdvToOper.Text);
            }

            //Add by J.S. 2011.05.19
            if (LOT.GetChar("RWK_FLAG") != 'Y')
            {
                cdvRwkCode.Text = "";
                cdvRwkCode.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkCode.Enabled = false;

                cdvRwkStopOper.Text = "";
                cdvRwkStopOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkStopOper.Enabled = false;

                cdvRwkRetFlow.Text = "";
                cdvRwkRetFlow.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkRetFlow.Enabled = false;

                cdvRwkRetOper.Text = "";
                cdvRwkRetOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkRetOper.Enabled = false;

                cdvRwkEndFlow.Text = "";
                cdvRwkEndFlow.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkEndFlow.Enabled = false;

                cdvRwkEndOper.Text = "";
                cdvRwkEndOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkEndOper.Enabled = false;

                //txtRwkCnt.Text = "0";
                txtRwkCnt.BackColor = MPGV.gcolorReadOnlyBackColor;
                txtRwkCnt.Enabled = false;

                dtpRwkTime.Visible = false;
                txtRwkTime.Visible = true;

                cboReturnOption.Enabled = false;

                chkLocalRwkFlag.Checked = false;
                chkLocalRwkFlag.Enabled = false;

                lblReworkCode.Enabled = false;
                lblRwkStopOper.Enabled = false;
                lblReworkReturnOper.Enabled = false;
                lblReworkEndOper.Enabled = false;
                lblReworkCnt.Enabled = false;
                lblReworkTime.Enabled = false;
                lblRwkDepth.Enabled = false;
            }
            //End Add

            cdvRwkCode.Text = LOT.GetString("RWK_CODE");
            txtRwkCnt.Text = LOT.GetInt("RWK_COUNT").ToString();
            cdvRwkRetFlow.Text = LOT.GetString("RWK_RET_FLOW");
            cdvRwkRetFlow.Sequence = LOT.GetInt("RWK_RET_FLOW_SEQ_NUM");
            cdvRwkRetOper.Text = LOT.GetString("RWK_RET_OPER");
            cdvRwkEndFlow.Text = LOT.GetString("RWK_END_FLOW");
            cdvRwkEndFlow.Sequence = LOT.GetInt("RWK_END_FLOW_SEQ_NUM");
            cdvRwkEndOper.Text = LOT.GetString("RWK_END_OPER");
            if (chkRework.Checked == true)
            {
                switch (LOT.GetChar("RWK_RET_CLEAR_FLAG"))
                {
                    case 'Y': // Clear Rework
                        cboReturnOption.SelectedIndex = 1;
                        break;
                    case 'A': // Clear Rework and Move to Next Oper
                        cboReturnOption.SelectedIndex = 2;
                        break;
                    case 'B': // Keep Rework and Move to Next Oper
                        cboReturnOption.SelectedIndex = 3;
                        break;
                    default: // keep Rework
                        cboReturnOption.SelectedIndex = 0;
                        break;
                }
            }
            else
            {
                cboReturnOption.SelectedIndex = -1;
                cboReturnOption.Text = "";
            }

            if (LOT.GetString("RWK_TIME") == "")
            {
                txtRwkTime.Visible = true;
                dtpRwkTime.Visible = false;
            }
            else
            {
                txtRwkTime.Visible = false;
                dtpRwkTime.Visible = true;
                dtpRwkTime.Value = MPCF.ToDate(LOT.GetString("RWK_TIME"));
            }
            txtRwkDepth.Text = LOT.GetInt("RWK_DEPTH").ToString();
            cdvRwkStopOper.Text = LOT.GetString("RWK_STOP_OPER");
            chkLocalRwkFlag.Checked = (LOT.GetChar("LOCAL_REWORK_FLAG") == 'Y') ? true : false;

            chkNstd.Checked = (LOT.GetChar("NSTD_FLAG") == 'Y') ? true : false;
            cdvNstdRetFlow.Text = LOT.GetString("NSTD_RET_FLOW");
            cdvNstdRetFlow.Sequence = LOT.GetInt("NSTD_RET_FLOW_SEQ_NUM");

            cdvNstdRetFlow.ListCond_Step = '2';
            cdvNstdRetFlow.ListCond_MatID = LOT.GetString("MAT_ID");
            cdvNstdRetFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");

            cdvNstdRetOper.Text = LOT.GetString("NSTD_RET_OPER");
            if (LOT.GetString("NSTD_TIME") == "")
            {
                txtNstdTime.Visible = true;
                dtpNstdTime.Visible = false;
            }
            else
            {
                txtNstdTime.Visible = false;
                dtpNstdTime.Visible = true;
                dtpNstdTime.Value = MPCF.ToDate(LOT.GetString("NSTD_TIME"));
            }

            cdvStartResID.Text = LOT.GetString("START_RES_ID");
            cdvEndResID.Text = LOT.GetString("END_RES_ID");
            cdvResvResID.Text = LOT.GetString("RESERVE_RES_ID");
            cdvPort.Text = LOT.GetString("PORT_ID");

            txtInvUnit.Text = LOT.GetString("INV_UNIT");
            cdvLocation1.Text = LOT.GetString("LOT_LOCATION_1");
            cdvLocation2.Text = LOT.GetString("LOT_LOCATION_2");
            cdvLocation3.Text = LOT.GetString("LOT_LOCATION_3");

            txtAddOrder1.Text = LOT.GetString("ADD_ORDER_ID_1");
            txtAddOrder2.Text = LOT.GetString("ADD_ORDER_ID_2");
            txtAddOrder3.Text = LOT.GetString("ADD_ORDER_ID_3");

            chkSample.Checked = (LOT.GetChar("SAMPLE_FLAG") == 'Y') ? true : false;
            chkSampleWait.Checked = (LOT.GetChar("SAMPLE_WAIT_FLAG") == 'Y') ? true : false;
            cdvSampleResult.Text = LOT.GetChar("SAMPLE_RESULT").ToString();

            cdvStrRetFlow.Text = LOT.GetString("STR_RET_FLOW");
            cdvStrRetFlow.Sequence = LOT.GetInt("STR_RET_FLOW_SEQ_NUM");

            cdvStrRetFlow.ListCond_Step = '2';
            cdvStrRetFlow.ListCond_MatID = LOT.GetString("MAT_ID");
            cdvStrRetFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");
            cdvStrRetOper.Text = LOT.GetString("STR_RET_OPER");

            txtYield1.Text = LOT.GetDouble("YIELD_1").ToString();
            txtYield2.Text = LOT.GetDouble("YIELD_2").ToString();
            txtYield3.Text = LOT.GetDouble("YIELD_3").ToString();

            cdvCrtCmf1.Text = LOT.GetString("LOT_CMF_1");
            cdvCrtCmf2.Text = LOT.GetString("LOT_CMF_2");
            cdvCrtCmf3.Text = LOT.GetString("LOT_CMF_3");
            cdvCrtCmf4.Text = LOT.GetString("LOT_CMF_4");
            cdvCrtCmf5.Text = LOT.GetString("LOT_CMF_5");
            cdvCrtCmf6.Text = LOT.GetString("LOT_CMF_6");
            cdvCrtCmf7.Text = LOT.GetString("LOT_CMF_7");
            cdvCrtCmf8.Text = LOT.GetString("LOT_CMF_8");
            cdvCrtCmf9.Text = LOT.GetString("LOT_CMF_9");
            cdvCrtCmf10.Text = LOT.GetString("LOT_CMF_10");
            cdvCrtCmf11.Text = LOT.GetString("LOT_CMF_11");
            cdvCrtCmf12.Text = LOT.GetString("LOT_CMF_12");
            cdvCrtCmf13.Text = LOT.GetString("LOT_CMF_13");
            cdvCrtCmf14.Text = LOT.GetString("LOT_CMF_14");
            cdvCrtCmf15.Text = LOT.GetString("LOT_CMF_15");
            cdvCrtCmf16.Text = LOT.GetString("LOT_CMF_16");
            cdvCrtCmf17.Text = LOT.GetString("LOT_CMF_17");
            cdvCrtCmf18.Text = LOT.GetString("LOT_CMF_18");
            cdvCrtCmf19.Text = LOT.GetString("LOT_CMF_19");
            cdvCrtCmf20.Text = LOT.GetString("LOT_CMF_20");

            if (MPGO.ProcessZeroQtyLot() == true)
                chkNoAutoTermLot.Checked = true;

            txtLotID.Focus();

            return true;
        }
        
        private void ViewLotCarrierList(string s_lot_id)
        {
#if _CRR
            cdvCarrier.Init();
            MPCF.InitListView(cdvCarrier.GetListView);
            cdvCarrier.Columns.Add("Carrier", 50, HorizontalAlignment.Left);
            cdvCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCarrier.SelectedSubItemIndex = 0;

            if (RASLIST.ViewCarrierList(cdvCarrier.GetListView, s_lot_id) == false)
            {
                return ;
            }

            cdvCarrier.Text = "";
            cdvToCarrier.Text = "";

            if (cdvCarrier.Items.Count > 0)
            {
                cdvCarrier.Text = cdvCarrier.Items[0].Text;
                cdvToCarrier.Text = cdvCarrier.Text;
            }
#endif
        }
        
        // ClearData()
        //       -   Clear Form Control Data
        // Return Value
        //       -
        // Arguments
        //       -
        private void ClearData(int iStep)
        {
            
            cdvToFlow.FlowItems.Clear();
            cdvToFlow.SeqItems.Clear();
            cdvToOper.Items.Clear();
            
            cdvRwkCode.Items.Clear();
            cdvRwkRetOper.Items.Clear();
            cdvRwkEndOper.Items.Clear();
            
            cdvStartResID.Items.Clear();
            cdvEndResID.Items.Clear();
            cdvResvResID.Items.Clear();
            
            txtQty1.Enabled = false;
            txtQty2.Enabled = false;
            txtQty3.Enabled = false;
            
            chkRework.Checked = false;
            chkNstd.Checked = false;
            
            cdvRwkCode.Text = "";
            txtRwkCnt.Text = "0";
            txtRwkDepth.Text = "0";
            cdvRwkStopOper.Text = "";
            cdvRwkRetFlow.Text = "";
            cdvRwkRetOper.Text = "";
            cdvRwkEndFlow.Text = "";
            cdvRwkEndOper.Text = "";
            cdvNstdRetFlow.Text = "";
            cdvNstdRetOper.Text = "";
            cboReturnOption.Text = "";
            chkLocalRwkFlag.Checked = false;
            dtpRwkTime.Value = DateTime.Now;
            dtpRwkTime.Visible = false;
            txtRwkTime.Visible = true;

            chkNstd_CheckedChanged(null, null);
            dtpNstdTime.Value = DateTime.Now;
            dtpNstdTime.Visible = false;
            txtNstdTime.Visible = true;
            
            sReworkTable = "";
            
            switch (iStep)
            {
                case 0:

                    MPCF.FieldClear(this);
                    break;
            }
            
        }
        
        // initCodeView()
        //       -   initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //       -
        private void initCodeView()
        {
            
            
            cdvSampleResult.Init();
            MPCF.InitListView(cdvSampleResult.GetListView);
            cdvSampleResult.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvSampleResult.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvSampleResult.SelectedSubItemIndex = 0;
            cdvSampleResult.ReadOnly = true;
            
            ListViewItem itmX;
            itmX = new ListViewItem("Y", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itmX.SubItems.Add("Good");
            cdvSampleResult.GetListView.Items.Add(itmX);
            itmX = new ListViewItem("N", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itmX.SubItems.Add("No Good");
            cdvSampleResult.GetListView.Items.Add(itmX);
        }
        
        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition()
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return false;
            }
            if (cdvToMatID.CheckValue() == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvToOper, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvToOper.Focus();
                return false;
            }
            if (MPCF.CheckValue(cdvCreateCode, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvCreateCode.Focus();
                return false;
            }
            if (MPCF.CheckValue(cdvOwnerCode, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvOwnerCode.Focus();
                return false;
            }
            if (MPCF.CheckValue(cdvLotType, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvLotType.Focus();
                return false;
            }
            if (txtQty1.Text == "" && txtQty1.Enabled == true)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                tabTran.SelectedTab = tbpGeneral;
                txtQty1.Focus();
                return false;
            }
            if (txtQty2.Text == "" && txtQty2.Enabled == true)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                tabTran.SelectedTab = tbpGeneral;
                txtQty2.Focus();
                return false;
            }
            if (txtQty3.Text == "" && txtQty3.Enabled == true)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                tabTran.SelectedTab = tbpGeneral;
                txtQty3.Focus();
                return false;
            }
            if (txtPriority.Text == "")
            {
                txtPriority.Text = "5";
            }
            
            //Add by J.S. 2011.05.19
            if (chkRework.Checked == true)
            {
                if (MPCF.CheckValue(cdvRwkCode, 1) == false)
                {
                    tabTran.SelectedTab = tbpRework;
                    cdvRwkCode.Focus();
                    return false;
                }

                //if (MPCF.CheckValue(cdvRwkRetFlow, 1) == false)
                //{
                //    tabTran.SelectedTab = tbpRework;
                //    cdvRwkRetFlow.Focus();
                //    return false;
                //}
                //if (MPCF.CheckValue(cdvRwkRetOper, 1) == false)
                //{
                //    tabTran.SelectedTab = tbpRework;
                //    cdvRwkRetOper.Focus();
                //    return false;
                //}
                if (MPCF.CheckValue(cdvRwkEndFlow, 1) == false)
                {
                    tabTran.SelectedTab = tbpRework;
                    cdvRwkEndFlow.Focus();
                    return false;
                }
                if (MPCF.CheckValue(cdvRwkEndOper, 1) == false)
                {
                    tabTran.SelectedTab = tbpRework;
                    cdvRwkEndOper.Focus();
                    return false;
                }

                if (MPCF.CheckValue(txtRwkCnt,2) == false)
                {
                    tabTran.SelectedTab = tbpRework;
                    txtRwkCnt.Focus();
                    return false;
                }

            }
            //End Add


            if (chkNstd.Checked == true)
            {
                if (MPCF.CheckValue(cdvNstdRetFlow, 1) == false)
                {
                    tabTran.SelectedTab = tbpRework;
                    cdvNstdRetFlow.Focus();
                    return false;
                }
                if (MPCF.CheckValue(cdvNstdRetOper, 1) == false)
                {
                    tabTran.SelectedTab = tbpRework;
                    cdvNstdRetOper.Focus();
                    return false;
                }
            }
            
            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }
            if (MPCR.CheckGRPCMFValue("lblCrtCmf", "cdvCrtCmf", grpCrtCmf) == false)
            {
                tabTran.SelectedTab = tbpCrtCmf;
                return false;
            }

            if (MPCF.Trim(txtYield1.Text) != "")
            {
                if (MPCF.CheckNumeric(txtYield1.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    tabTran.SelectedTab = tbpExtra;
                    txtYield1.Focus();
                    return false;
                }
            }
            if (MPCF.Trim(txtYield2.Text) != "")
            {
                if (MPCF.CheckNumeric(txtYield2.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    tabTran.SelectedTab = tbpExtra;
                    txtYield2.Focus();
                    return false;
                }
            }
            if (MPCF.Trim(txtYield3.Text) != "")
            {
                if (MPCF.CheckNumeric(txtYield3.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    tabTran.SelectedTab = tbpExtra;
                    txtYield3.Focus();
                    return false;
                }
            }
            
            return true;
        }
        
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
            in_node.AddString("OPER", MPCF.Trim(cdvToOper.Text));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }
            
            if (out_node.GetString("UNIT_1") != "")
            {
                txtQty1.Enabled = true;
            }
            else
            {
                txtQty1.Enabled = false;
            }
            if (out_node.GetString("UNIT_2") != "")
            {
                txtQty2.Enabled = true;
            }
            else
            {
                txtQty2.Enabled = false;
            }

            if (out_node.GetString("UNIT_3") != "")
            {
                txtQty3.Enabled = true;
            }
            else
            {
                txtQty3.Enabled = false;
            }
            
            return true;
            
        }
        
        // View_End_Operation()
        //       -  View End Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_End_Operation(string sOper)
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", MPCF.Trim(sOper));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }
            sReworkTable = out_node.GetString("REWORK_TBL");
            
            return true;
            
        }

        //Add by J.S. 2011.05.19 for rework
        // GetReturnOperationList()
        //       - Get rework return Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetReturnOperationList(string sFlow)
        {

            try
            {
                cdvRwkRetOper.Init();
                MPCF.InitListView(cdvRwkRetOper.GetListView);
                cdvRwkRetOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvRwkRetOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRwkRetOper.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvRwkRetOper.GetListView, '2', "", 0, sFlow, "", null, "") == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        // GetReturnOperationList()
        //       - Get rework End Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetEndOperationList(string sFlow)
        {

            try
            {
                cdvRwkEndOper.Init();
                MPCF.InitListView(cdvRwkEndOper.GetListView);
                cdvRwkEndOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvRwkEndOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRwkEndOper.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvRwkEndOper.GetListView, '2', "", 0, sFlow, "", null, "") == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        //End Add

        // Adapt_Lot()
        //       -   Adapt Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Adapt_Lot()
        {
            TRSNode in_node = new TRSNode("ADAPT_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                //Modify by J.S. 2008.12.18 for clear field
                // MPCF.Trim -> MPCF.RTrimSpace
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.RTrimSpace(txtLotID.Text));
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));

                in_node.AddString("LOT_DESC", MPCF.RTrimSpace(txtLotDesc.Text));
                in_node.AddString("MAT_ID", MPCF.RTrimSpace(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.RTrimSpace(cdvFlow.Text));
                in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("OPER", MPCF.RTrimSpace(txtOper.Text));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("TO_MAT_ID", MPCF.RTrimSpace(cdvToMatID.Text));
                in_node.AddInt("TO_MAT_VER", cdvToMatID.Version);
                in_node.AddString("TO_FLOW", MPCF.RTrimSpace(cdvToFlow.Text));
                in_node.AddInt("TO_FLOW_SEQ_NUM", cdvToFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.RTrimSpace(cdvToOper.Text));
                in_node.AddChar("LOT_TYPE", MPCF.ToChar(cdvLotType.Text));
                in_node.AddChar("LOT_PRIORITY", (txtPriority.Text == "") ? '5' : MPCF.ToChar(txtPriority.Text));

                if (txtQty1.Text == "")
                {
                    in_node.AddDouble("QTY_1", 0);
                }
                else
                {
                    in_node.AddDouble("QTY_1", MPCF.ToDbl(txtQty1.Text));
                }
                if (txtQty2.Text == "")
                {
                    in_node.AddDouble("QTY_2", 0);
                }
                else
                {
                    in_node.AddDouble("QTY_2", MPCF.ToDbl(txtQty2.Text));
                }
                if (txtQty3.Text == "")
                {
                    in_node.AddDouble("QTY_3", 0);
                }
                else
                {
                    //Modify by J.S. 2008.12.23 Bug Fix txtQty2.Text -> txtQty3.Text
                    in_node.AddDouble("QTY_3", MPCF.ToDbl(txtQty3.Text));
                }

                in_node.AddString("CREATE_CODE", MPCF.RTrimSpace(cdvCreateCode.Text));
                in_node.AddString("OWNER_CODE", MPCF.RTrimSpace(cdvOwnerCode.Text));
                in_node.AddString("SHIP_CODE", MPCF.RTrimSpace(cdvShipCode.Text));
                in_node.AddString("ORDER_ID", MPCF.RTrimSpace(txtOrderID.Text));
                in_node.AddString("DUE_TIME", MPCF.ToStandardTime(dtpDueTime.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                
                #if _CRR
                in_node.AddString("CRR_ID", MPCF.RTrimSpace(cdvCarrier.Text));
                in_node.AddString("TO_CRR_ID", MPCF.RTrimSpace(cdvToCarrier.Text));
                #endif //_CRR
                
                in_node.AddChar("RWK_FLAG", chkRework.Checked == true ? 'Y' : ' ');
                //Add by J.S. 2011.05.19 rework관련 항목 추가
                if (chkRework.Checked == true)
                {
                    switch (cboReturnOption.SelectedIndex)
                    {
                        case 0: // Keep Rework
                            in_node.AddChar("RWK_RET_CLEAR_FLAG", ' ');
                            break;
                        case 1: // Clear Rework
                            in_node.AddChar("RWK_RET_CLEAR_FLAG", 'Y');
                            break;
                        case 2: // Clear Rework and Move to Next Oper
                            in_node.AddChar("RWK_RET_CLEAR_FLAG", 'A');
                            break;
                        case 3: // Keep Rework and Move to Next Oper
                            in_node.AddChar("RWK_RET_CLEAR_FLAG", 'B');
                            break;
                    }
                    in_node.AddChar("LOCAL_REWORK_FLAG", chkLocalRwkFlag.Checked == true ? 'Y' : ' ');
                    if (txtRwkCnt.Text == "")
                    {
                        in_node.AddInt("RWK_COUNT", 0);
                    }
                    else
                    {
                        in_node.AddInt("RWK_COUNT", MPCF.ToInt(txtRwkCnt.Text));
                    }
                    in_node.AddString("RWK_CODE", MPCF.RTrimSpace(cdvRwkCode.Text));
                    in_node.AddString("RWK_STOP_OPER", MPCF.RTrimSpace(cdvRwkStopOper.Text));
                    in_node.AddString("RWK_RET_FLOW", MPCF.RTrimSpace(cdvRwkRetFlow.Text));
                    in_node.AddInt("RWK_RET_FLOW_SEQ_NUM", cdvRwkRetFlow.Sequence);
                    in_node.AddString("RWK_RET_OPER", MPCF.RTrimSpace(cdvRwkRetOper.Text));
                    in_node.AddString("RWK_END_FLOW", MPCF.RTrimSpace(cdvRwkEndFlow.Text));
                    in_node.AddInt("RWK_END_FLOW_SEQ_NUM", cdvRwkEndFlow.Sequence);
                    in_node.AddString("RWK_END_OPER", MPCF.RTrimSpace(cdvRwkEndOper.Text));

                    in_node.AddString("RWK_TIME", MPCF.ToStandardTime(dtpRwkTime.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
                }
                //End Add

                in_node.AddChar("NSTD_FLAG", chkNstd.Checked == true ? 'Y' : ' ');
                in_node.AddString("NSTD_RET_FLOW", MPCF.RTrimSpace(cdvNstdRetFlow.Text));
                in_node.AddInt("NSTD_RET_FLOW_SEQ_NUM", cdvNstdRetFlow.Sequence);
                in_node.AddString("NSTD_RET_OPER", MPCF.RTrimSpace(cdvNstdRetOper.Text));

                if (chkNstd.Checked == true)
                {
                    in_node.AddString("NSTD_TIME", MPCF.ToStandardTime(dtpNstdTime.Value, MPGC.MP_CONVERT_DATETIME_FORMAT));
                }

                in_node.AddString("START_RES_ID", MPCF.RTrimSpace(cdvStartResID.Text));
                in_node.AddString("END_RES_ID", MPCF.Trim(cdvEndResID.Text));
                in_node.AddString("RESERVE_RES_ID", MPCF.RTrimSpace(cdvResvResID.Text));
                in_node.AddString("PORT_ID", MPCF.RTrimSpace(cdvPort.Text));

                in_node.AddString("LOCATION_1", MPCF.Trim(cdvLocation1.Text));
                in_node.AddString("LOCATION_2", MPCF.Trim(cdvLocation2.Text));
                in_node.AddString("LOCATION_3", MPCF.Trim(cdvLocation3.Text));

                in_node.AddString("INV_UNIT", MPCF.Trim(txtInvUnit.Text));

                in_node.AddString("ADD_ORDER_ID_1", MPCF.RTrimSpace(txtAddOrder1.Text));
                in_node.AddString("ADD_ORDER_ID_2", MPCF.RTrimSpace(txtAddOrder2.Text));
                in_node.AddString("ADD_ORDER_ID_3", MPCF.RTrimSpace(txtAddOrder3.Text));

                in_node.AddChar("SAMPLE_FLAG", chkSample.Checked == true ? 'Y' : ' ');
                in_node.AddChar("SAMPLE_WAIT_FLAG", chkSampleWait.Checked == true ? 'Y' : ' ');
                in_node.AddChar("SAMPLE_RESULT", MPCF.ToChar(cdvSampleResult.Text));

                in_node.AddString("TRAN_CMF_1", MPCF.RTrimSpace(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.RTrimSpace(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.RTrimSpace(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.RTrimSpace(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.RTrimSpace(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.RTrimSpace(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.RTrimSpace(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.RTrimSpace(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.RTrimSpace(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.RTrimSpace(cdvCMF10.Text));
                in_node.AddString("TRAN_CMF_11", MPCF.RTrimSpace(cdvCMF11.Text));
                in_node.AddString("TRAN_CMF_12", MPCF.RTrimSpace(cdvCMF12.Text));
                in_node.AddString("TRAN_CMF_13", MPCF.RTrimSpace(cdvCMF13.Text));
                in_node.AddString("TRAN_CMF_14", MPCF.RTrimSpace(cdvCMF14.Text));
                in_node.AddString("TRAN_CMF_15", MPCF.RTrimSpace(cdvCMF15.Text));
                in_node.AddString("TRAN_CMF_16", MPCF.RTrimSpace(cdvCMF16.Text));
                in_node.AddString("TRAN_CMF_17", MPCF.RTrimSpace(cdvCMF17.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.RTrimSpace(cdvCMF18.Text));
                in_node.AddString("TRAN_CMF_19", MPCF.RTrimSpace(cdvCMF19.Text));
                in_node.AddString("TRAN_CMF_20", MPCF.RTrimSpace(cdvCMF20.Text));

                in_node.AddString("LOT_CMF_1", MPCF.RTrimSpace(cdvCrtCmf1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.RTrimSpace(cdvCrtCmf2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.RTrimSpace(cdvCrtCmf3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.RTrimSpace(cdvCrtCmf4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.RTrimSpace(cdvCrtCmf5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.RTrimSpace(cdvCrtCmf6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.RTrimSpace(cdvCrtCmf7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.RTrimSpace(cdvCrtCmf8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.RTrimSpace(cdvCrtCmf9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.RTrimSpace(cdvCrtCmf10.Text));
                in_node.AddString("LOT_CMF_11", MPCF.RTrimSpace(cdvCrtCmf11.Text));
                in_node.AddString("LOT_CMF_12", MPCF.RTrimSpace(cdvCrtCmf12.Text));
                in_node.AddString("LOT_CMF_13", MPCF.RTrimSpace(cdvCrtCmf13.Text));
                in_node.AddString("LOT_CMF_14", MPCF.RTrimSpace(cdvCrtCmf14.Text));
                in_node.AddString("LOT_CMF_15", MPCF.RTrimSpace(cdvCrtCmf15.Text));
                in_node.AddString("LOT_CMF_16", MPCF.RTrimSpace(cdvCrtCmf16.Text));
                in_node.AddString("LOT_CMF_17", MPCF.RTrimSpace(cdvCrtCmf17.Text));
                in_node.AddString("LOT_CMF_18", MPCF.RTrimSpace(cdvCrtCmf18.Text));
                in_node.AddString("LOT_CMF_19", MPCF.RTrimSpace(cdvCrtCmf19.Text));
                in_node.AddString("LOT_CMF_20", MPCF.RTrimSpace(cdvCrtCmf20.Text));

                in_node.AddString("COMMENT", MPCF.RTrimSpace(txtComment.Text));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');


                //Add by J.S. 2008.12.18 for store return flow, oper
                in_node.AddString("STR_RET_FLOW", MPCF.RTrimSpace(cdvStrRetFlow.Text));
                in_node.AddInt("STR_RET_FLOW_SEQ_NUM", cdvStrRetFlow.Sequence);
                in_node.AddString("STR_RET_OPER", MPCF.RTrimSpace(cdvStrRetOper.Text));

                if (MPCF.Trim(txtYield1.Text) == "")
                {
                    in_node.AddDouble("YIELD_1", 0);
                }
                else
                {
                    in_node.AddDouble("YIELD_1", MPCF.ToDbl(txtYield1.Text));
                }

                if (MPCF.Trim(txtYield2.Text) == "")
                {
                    in_node.AddDouble("YIELD_2", 0);
                }
                else
                {
                    in_node.AddDouble("YIELD_2", MPCF.ToDbl(txtYield2.Text));
                }

                if (MPCF.Trim(txtYield3.Text) == "")
                {
                    in_node.AddDouble("YIELD_3", 0);
                }
                else
                {
                    in_node.AddDouble("YIELD_3", MPCF.ToDbl(txtYield3.Text));
                }

                if (MPCR.CallService("WIP", "WIP_Adapt_Lot", in_node, ref out_node) == false)
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
        
        private void frmWIPTranAdaptLot_Load(object sender, System.EventArgs e)
        {
            txtRwkTime.BackColor = MPGV.gcolorReadOnlyBackColor;
            txtNstdTime.BackColor = MPGV.gcolorReadOnlyBackColor;

            cdvMaterial.BackColor = SystemColors.Control;
            cdvFlow.BackColor = SystemColors.Control;
            
            #if _CRR
            lblCarrier.Visible = true;
            cdvCarrier.Visible = true;
            lblToCarrier.Visible = true;
            cdvToCarrier.Visible = true;
#endif //_CRR
            
        }
        
        private void frmWIPTranAdaptLot_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                
                initCodeView();
                ClearData(0);
                
                SetCMFItem(MPGC.MP_CMF_TRN_ADAPT);
                MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblCrtCmf", "cdvCrtCmf", grpCrtCmf);
                
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                }
                
                b_load_flag = true;
            }
            
            
        }
        
        private void cdvCrtCmf_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }
        
        private void cdvCrtCmf_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && MPCF.Trim(txtLotID.Text) != "")
            {
                ViewLotInfo(txtLotID.Text);
            }
        }
        
        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                ClearData(0);
            }
        }
        
        private void cdvToMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvToFlow.Text = "";
            cdvToOper.Text = "";
            
        }
        
        private void cdvToFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvToOper.Text = "";

            if (MPCF.Trim(cdvToFlow.Text) != "")
            {
                cdvToFlow.ListCond_Step = '2';
                cdvToFlow.ListCond_MatID = cdvToMatID.Text;
                cdvToFlow.ListCond_MatVersion = cdvToMatID.Version;
            }
        }

        private void cdvToFlow_ButtonPress(object sender, System.EventArgs e)
        {
            /* 2013.06.12. Aiden. Material ID 가 없는 경우 전체 Flow 를 표시하도록 변경 */
            if (MPCF.Trim(cdvToMatID.Text) == "")
            {
                cdvToFlow.ListCond_Step = '1';
                cdvToFlow.ListCond_MatID = "";
                cdvToFlow.ListCond_MatVersion = 0;
            }
            else
            {
                cdvToFlow.ListCond_Step = '2';
                cdvToFlow.ListCond_MatID = cdvToMatID.Text;
                cdvToFlow.ListCond_MatVersion = cdvToMatID.Version;
            }
        }
        
        private void cdvToOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (View_Operation() == false)
            {
                return;
            }
        }
                
        private void cdvToOper_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvToMatID.CheckValue() == false) return;
            if (cdvToFlow.CheckValue() == false) return;
            
            cdvToOper.Init();
            MPCF.InitListView(cdvToOper.GetListView);
            cdvToOper.Columns.Add("Oper", 150, HorizontalAlignment.Left);
            cdvToOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvToOper.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvToOper.GetListView, '2', "", 0,cdvToFlow.Text, "", null, "");
            
        }
        
        private void cdvNstdRetFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvNstdRetOper.Text = "";
            if (MPCF.Trim(cdvNstdRetFlow.Text) != "")
            {
                cdvNstdRetFlow.ListCond_Step = '2';
                cdvNstdRetFlow.ListCond_MatID =  cdvMaterial.Text;
                cdvNstdRetFlow.ListCond_MatVersion = cdvMaterial.Version;
            }
        }
        
        private void cdvNstdRetOper_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            if (cdvNstdRetFlow.Text == "")
            {
                cdvNstdRetFlow.Focus();
                return;
            }
            cdvNstdRetOper.Init();
            MPCF.InitListView(cdvNstdRetOper.GetListView);
            cdvNstdRetOper.Columns.Add("Oper", 150, HorizontalAlignment.Left);
            cdvNstdRetOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvNstdRetOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvNstdRetOper.GetListView, '2', "", 0,cdvNstdRetFlow.Text, "", null, "");
            
        }
        
        private void chkNstd_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkNstd.Checked == false)
            {
                cdvNstdRetFlow.Text = "";
                cdvNstdRetFlow.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvNstdRetFlow.Enabled = false;
                
                cdvNstdRetOper.Text = "";
                cdvNstdRetOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvNstdRetOper.Enabled = false;

                dtpNstdTime.Visible = false;
                txtNstdTime.Visible = true;

                lblNstdReturnOper.Enabled = false;
                lblNstdTime.Enabled = false;
            }
            else
            {
                cdvNstdRetFlow.BackColor = Color.White;
                cdvNstdRetFlow.Enabled = true;
                
                cdvNstdRetOper.BackColor = Color.White;
                cdvNstdRetOper.Enabled = true;
                
                dtpNstdTime.Value = DateTime.Now;
                dtpNstdTime.Visible = true;
                txtNstdTime.Visible = false;

                lblNstdReturnOper.Enabled = true;
                lblNstdTime.Enabled = true;
            }
        }
        
        private void cdvStartResID_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return;
            }
            
            if (cdvToOper.Text == "")
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvToOper.Focus();
                return;
            }
            #if _RAS
            cdvStartResID.Init();
            MPCF.InitListView(cdvStartResID.GetListView);
            cdvStartResID.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvStartResID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvStartResID.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvStartResID.GetListView, cdvToMatID.Text, cdvToMatID.Version, cdvToFlow.Text, cdvToOper.Text, false);
            #endif
            
        }

        private void cdvStartResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvPort.Text) != "" && MPCF.Trim(cdvStartResID.Text) != "")
            {
                cdvPort.Text = "";
            }
        }
        
        private void cdvEndResID_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return;
            }
            
            if (cdvToOper.Text == "")
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvToOper.Focus();
                return;
            }
            #if _RAS
            cdvEndResID.Init();
            MPCF.InitListView(cdvEndResID.GetListView);
            cdvEndResID.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvEndResID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvEndResID.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvEndResID.GetListView, cdvToMatID.Text, cdvToMatID.Version, cdvToFlow.Text, cdvToOper.Text, false);
            #endif
        }
        
        private void cdvResvResID_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return;
            }
            
            if (cdvToOper.Text == "")
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvToOper.Focus();
                return;
            }
            #if _RAS
            cdvResvResID.Init();
            MPCF.InitListView(cdvResvResID.GetListView);
            cdvResvResID.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvResvResID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvResvResID.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResvResID.GetListView, cdvToMatID.Text, cdvToMatID.Version, cdvToFlow.Text, cdvToOper.Text, false);
            #endif
        }
        
        private void txtPriority_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
        }
        
        private void txtQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    if (e.KeyChar != (char)46)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition() == false) return;

            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_ADAPT, LOT.GetString("LOT_ID"), "", "", 'B') == false) return;
            if (Adapt_Lot() == false) return;
            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_ADAPT, LOT.GetString("LOT_ID"), "", "", 'A') == false) return;

            ViewLotInfo(txtLotID.Text);
        }
        
        private void cdvToCarrier_ButtonPress(object sender, System.EventArgs e)
        {
#if _CRR
            cdvToCarrier.Init();
            MPCF.InitListView(cdvToCarrier.GetListView);
            cdvToCarrier.Columns.Add("Carrier", 50, HorizontalAlignment.Left);
            cdvToCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToCarrier.SelectedSubItemIndex = 0;

            if (RASLIST.ViewCarrierList(cdvToCarrier.GetListView, '2', ' ', cdvToMatID.Text, cdvToMatID.Version, cdvToFlow.Text, cdvToOper.Text, cdvStartResID.Text, cdvPort.Text) == false)
            {
                return;
            }
#endif                    
        }
    
        private void cdvToMaterial_ButtonPress(object sender, System.EventArgs e)
        {
            cdvToMatID.ListCond_StepMaterial = '1';
        }
        
        private void cdvCreateCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCreateCode.Init();
            MPCF.InitListView(cdvCreateCode.GetListView);
            cdvCreateCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvCreateCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCreateCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCreateCode.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);
            
        }
        
        private void cdvOwnerCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOwnerCode.Init();
            MPCF.InitListView(cdvOwnerCode.GetListView);
            cdvOwnerCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvOwnerCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOwnerCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvOwnerCode.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);
        }
        
        private void cdvShipCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvShipCode.Init();
            MPCF.InitListView(cdvShipCode.GetListView);
            cdvShipCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvShipCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvShipCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvShipCode.GetListView, '1', MPGC.MP_WIP_SHIP_CODE);
        }
        
        private void cdvLotType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvLotType.Init();
            MPCF.InitListView(cdvLotType.GetListView);
            cdvLotType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvLotType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvLotType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvLotType.GetListView, '1', MPGC.MP_WIP_LOT_TYPE);
        }

        private void cdvPort_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvStartResID.Text) != "")
            {
                cdvPort.Init();
                MPCF.InitListView(cdvPort.GetListView);
                cdvPort.Columns.Add("Location", 50, HorizontalAlignment.Left);
                cdvPort.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvPort.SelectedSubItemIndex = 0;
                RASLIST.ViewPortList(cdvPort.GetListView, '1', cdvStartResID.Text, "");
            }
        }

        private void cdvStrRetFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvStrRetOper.Text = "";
            if (MPCF.Trim(cdvStrRetFlow.Text) != "")
            {
                cdvStrRetFlow.ListCond_Step = '2';
                cdvStrRetFlow.ListCond_MatID = cdvMaterial.Text;
                cdvStrRetFlow.ListCond_MatVersion = cdvMaterial.Version;
            }
        }

        private void cdvStrRetOper_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvStrRetFlow.Text == "")
            {
                cdvStrRetFlow.Focus();
                return;
            }

            cdvStrRetOper.Init();
            MPCF.InitListView(cdvStrRetOper.GetListView);
            cdvStrRetOper.Columns.Add("Oper", 150, HorizontalAlignment.Left);
            cdvStrRetOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvStrRetOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvStrRetOper.GetListView, '2', "", 0, cdvStrRetFlow.Text, "", null, "");

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ViewLotInfo(txtLotID.Text) == false)
            {
                txtLotID.Focus();
                return;
            }
        }

        //Add by J.S. 2011.05.19 for rework
        private void chkRework_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRework.Checked == false)
            {
                cdvRwkCode.Text = "";
                cdvRwkCode.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkCode.Enabled = false;

                cdvRwkStopOper.Text = "";
                cdvRwkStopOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkStopOper.Enabled = false;

                cdvRwkRetFlow.Text = "";
                cdvRwkRetFlow.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkRetFlow.Enabled = false;

                cdvRwkRetOper.Text = "";
                cdvRwkRetOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkRetOper.Enabled = false;

                cdvRwkEndFlow.Text = "";
                cdvRwkEndFlow.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkEndFlow.Enabled = false;

                cdvRwkEndOper.Text = "";
                cdvRwkEndOper.BackColor = MPGV.gcolorReadOnlyBackColor;
                cdvRwkEndOper.Enabled = false;

                //txtRwkCnt.Text = "0";
                txtRwkCnt.BackColor = MPGV.gcolorReadOnlyBackColor;
                txtRwkCnt.Enabled = false;

                dtpRwkTime.Visible = false;
                txtRwkTime.Visible = true;

                cboReturnOption.Enabled = false;

                chkLocalRwkFlag.Checked = false;
                chkLocalRwkFlag.Enabled = false;

                lblReworkCode.Enabled = false;
                lblRwkStopOper.Enabled = false;
                lblReworkReturnOper.Enabled = false;
                lblReworkEndOper.Enabled = false;
                lblReworkCnt.Enabled = false;
                lblReworkTime.Enabled = false;
                lblRwkDepth.Enabled = false;
            }
            else
            {
                cdvRwkCode.BackColor = Color.White;
                cdvRwkCode.Enabled = true;

                cdvRwkStopOper.BackColor = Color.White;
                cdvRwkStopOper.Enabled = true;

                cdvRwkRetFlow.BackColor = Color.White;
                cdvRwkRetFlow.Enabled = true;
             

                cdvRwkRetOper.BackColor = Color.White;
                cdvRwkRetOper.Enabled = true;

                cdvRwkEndFlow.BackColor = Color.White;
                cdvRwkEndFlow.Enabled = true;

                cdvRwkEndOper.BackColor = Color.White;
                cdvRwkEndOper.Enabled = true;

                txtRwkCnt.BackColor = Color.White;
                txtRwkCnt.Enabled = true;

                dtpRwkTime.Value = DateTime.Now;
                dtpRwkTime.Visible = true;
                dtpRwkTime.Enabled = true;
                txtRwkTime.Visible = false;

                cboReturnOption.Enabled = true;

                chkLocalRwkFlag.Enabled = true;

                lblReworkCode.Enabled = true;
                lblRwkStopOper.Enabled = true;
                lblReworkReturnOper.Enabled = true;
                lblReworkEndOper.Enabled = true;
                lblReworkCnt.Enabled = true;
                lblReworkTime.Enabled = true;
                lblRwkDepth.Enabled = false;
            }
        }


        private void cdvRwkCode_ButtonPress(object sender, EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return;
            }
            if (chkRework.Checked == false)
            {
                chkRework.Focus();
                return;
            }

            if (sReworkTable != "")
            {
                cdvRwkCode.Init();
                MPCF.InitListView(cdvRwkCode.GetListView);
                cdvRwkCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvRwkCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvRwkCode.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvRwkCode.GetListView, '1', sReworkTable);
            }
        }

        private void cdvRwkStopOper_ButtonPress(object sender, EventArgs e)
        {
            cdvRwkStopOper.Init();
            MPCF.InitListView(cdvRwkStopOper.GetListView);
            cdvRwkStopOper.Columns.Add("Oper", 150, HorizontalAlignment.Left);
            cdvRwkStopOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvRwkStopOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvRwkStopOper.GetListView, '1', "", 0, "", "", null, "");
        }

        private void cdvRwkRetFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvRwkRetFlow.ListCond_Step = '1';
            cdvRwkRetFlow.ListCond_MatID = "";
            cdvRwkRetFlow.ListCond_MatVersion = 0;
        }

        private void cdvRwkRetFlow_FlowSelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRwkRetOper.Text = "";
            if (MPCF.Trim(cdvRwkRetFlow.Text) != "")
            {
                cdvRwkRetFlow.ListCond_Step = '2';
                cdvRwkRetFlow.ListCond_MatID = cdvToMatID.Text;
                cdvRwkRetFlow.ListCond_MatVersion = cdvToMatID.Version;
            }
        }

        private void cdvRwkRetOper_ButtonPress(object sender, EventArgs e)
        {
            if (cdvRwkRetFlow.Text.Trim() == "")
            {
                cdvRwkRetOper.Init();
                cdvRwkRetOper.Text = "";
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvRwkRetFlow.Focus();
                return;
            }

            if (GetReturnOperationList(cdvRwkRetFlow.Text) == false)
            {
                return;
            }
        }

        private void cdvRwkEndFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvRwkEndFlow.ListCond_Step = '1';
            cdvRwkEndFlow.ListCond_MatID = "";
            cdvRwkEndFlow.ListCond_MatVersion = 0;
        }

        private void cdvRwkEndFlow_FlowSelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRwkEndOper.Text = "";
            if (MPCF.Trim(cdvRwkEndFlow.Text) != "")
            {
                cdvRwkEndFlow.ListCond_Step = '2';
                cdvRwkEndFlow.ListCond_MatID = cdvToMatID.Text;
                cdvRwkEndFlow.ListCond_MatVersion = cdvToMatID.Version;
            }
        }

        private void cdvRwkEndOper_ButtonPress(object sender, EventArgs e)
        {
            if (cdvRwkEndFlow.Text.Trim() == "")
            {
                cdvRwkEndOper.Init();
                cdvRwkEndOper.Text = "";
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvRwkEndFlow.Focus();
                return;
            }

            if (GetEndOperationList(cdvRwkEndFlow.Text) == false)
            {
                return;
            }
        }
        //End Add
    }
}
