
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmResourceListMain.vb
//   Description : MES Cient Form View Resource List Main
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-12 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _RAS = True Then

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.MESCore
{
    public class frmResourceListMain : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmResourceListMain()
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

        private System.ComponentModel.IContainer components;

        
        



        private System.Windows.Forms.Panel pnlBottom;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTotRes;
        private System.Windows.Forms.Label lblTotRes;
        private System.Windows.Forms.ContextMenu ctxMenu;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlMid;
        private Miracom.UI.Controls.MCListView.MCListView lisResourceList;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colRes;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colUpDown;
        private System.Windows.Forms.ColumnHeader colPriSts;
        private System.Windows.Forms.ColumnHeader colPrt1;
        private System.Windows.Forms.ColumnHeader colPrt2;
        private System.Windows.Forms.ColumnHeader colPrt3;
        private System.Windows.Forms.ColumnHeader colPrt4;
        private System.Windows.Forms.ColumnHeader colPrt5;
        private System.Windows.Forms.ColumnHeader colPrt6;
        private System.Windows.Forms.ColumnHeader colPrt7;
        private System.Windows.Forms.ColumnHeader colPrt8;
        private System.Windows.Forms.ColumnHeader colPrt9;
        private System.Windows.Forms.ColumnHeader colPrt10;
        private System.Windows.Forms.ColumnHeader colSts1;
        private System.Windows.Forms.ColumnHeader colSts2;
        private System.Windows.Forms.ColumnHeader colSts3;
        private System.Windows.Forms.ColumnHeader colSts4;
        private System.Windows.Forms.ColumnHeader colSts5;
        private System.Windows.Forms.ColumnHeader colSts6;
        private System.Windows.Forms.ColumnHeader colSts7;
        private System.Windows.Forms.ColumnHeader colSts8;
        private System.Windows.Forms.ColumnHeader colSts9;
        private System.Windows.Forms.ColumnHeader colSts10;
        private System.Windows.Forms.ColumnHeader colUseFac;
        private System.Windows.Forms.ColumnHeader colLastEvent;
        private System.Windows.Forms.ColumnHeader colLastEventTime;
        private System.Windows.Forms.ColumnHeader colLastStartTime;
        private System.Windows.Forms.ColumnHeader colLastEndTime;
        private System.Windows.Forms.ColumnHeader colProcCount;
        private System.Windows.Forms.ColumnHeader colMaxProcCount;
        private System.Windows.Forms.ColumnHeader colLastActiveHistSeq;
        private System.Windows.Forms.ColumnHeader colLastHistSeq;
        private System.Windows.Forms.ColumnHeader colCreateUser;
        private System.Windows.Forms.ColumnHeader colCreateTime;
        private System.Windows.Forms.ColumnHeader colUpdateUser;
        private System.Windows.Forms.ColumnHeader colUpdateTime;
        private System.Windows.Forms.Splitter Splitter1;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colMaterial;
        private System.Windows.Forms.ColumnHeader colFlow;
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
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
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
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private ColumnHeader colMatVer;
        private ColumnHeader colFlowSeqNum;
        private Button btnMessage;
        private Timer tmrGotMessage;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResourceListMain));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnMessage = new System.Windows.Forms.Button();
            this.txtTotRes = new System.Windows.Forms.TextBox();
            this.lblTotRes = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.ctxMenu = new System.Windows.Forms.ContextMenu();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowSeqNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Splitter1 = new System.Windows.Forms.Splitter();
            this.lisResourceList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriSts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrt10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSts10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUseFac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEventTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProcCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaxProcCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastActiveHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastHistSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrGotMessage = new System.Windows.Forms.Timer(this.components);
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnMessage);
            this.pnlBottom.Controls.Add(this.txtTotRes);
            this.pnlBottom.Controls.Add(this.lblTotRes);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.chkAutoRefresh);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.cdvType);
            this.pnlBottom.Controls.Add(this.lblType);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 360);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(660, 33);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnMessage
            // 
            this.btnMessage.BackColor = System.Drawing.SystemColors.Control;
            this.btnMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMessage.Location = new System.Drawing.Point(424, 4);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(70, 24);
            this.btnMessage.TabIndex = 10;
            this.btnMessage.Text = "Message";
            this.btnMessage.UseVisualStyleBackColor = false;
            this.btnMessage.Visible = false;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // txtTotRes
            // 
            this.txtTotRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotRes.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotRes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotRes.Location = new System.Drawing.Point(520, 9);
            this.txtTotRes.MaxLength = 10;
            this.txtTotRes.Name = "txtTotRes";
            this.txtTotRes.ReadOnly = true;
            this.txtTotRes.Size = new System.Drawing.Size(44, 13);
            this.txtTotRes.TabIndex = 6;
            this.txtTotRes.Text = "Tot Res";
            // 
            // lblTotRes
            // 
            this.lblTotRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotRes.AutoSize = true;
            this.lblTotRes.Location = new System.Drawing.Point(460, 8);
            this.lblTotRes.Name = "lblTotRes";
            this.lblTotRes.Size = new System.Drawing.Size(51, 13);
            this.lblTotRes.TabIndex = 5;
            this.lblTotRes.Text = "Tot Res :";
            this.lblTotRes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(568, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.Enabled = false;
            this.chkAutoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoRefresh.Location = new System.Drawing.Point(262, 7);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(98, 18);
            this.chkAutoRefresh.TabIndex = 2;
            this.chkAutoRefresh.Text = "Auto Refresh";
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(394, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(364, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(116, 6);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = false;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(138, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 138;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvType_SelectedItemChanged);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(8, 9);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(102, 14);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Resource Type";
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 60000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblFormTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(660, 22);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.Visible = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFormTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFormTitle.Location = new System.Drawing.Point(2, 2);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(656, 18);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Resource List Main";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFormTitle.DoubleClick += new System.EventHandler(this.lblFormTitle_DoubleClick);
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.lisLotList);
            this.pnlMid.Controls.Add(this.Splitter1);
            this.pnlMid.Controls.Add(this.lisResourceList);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 22);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(660, 338);
            this.pnlMid.TabIndex = 2;
            // 
            // lisLotList
            // 
            this.lisLotList.AllowColumnReorder = true;
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.colLotID,
            this.colMaterial,
            this.colMatVer,
            this.colFlow,
            this.colFlowSeqNum,
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
            this.ColumnHeader2,
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
            this.ColumnHeader3,
            this.ColumnHeader4});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.EnableSort = true;
            this.lisLotList.EnableSortIcon = true;
            this.lisLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotList.FullRowSelect = true;
            this.lisLotList.Location = new System.Drawing.Point(0, 197);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(660, 141);
            this.lisLotList.TabIndex = 6;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            this.lisLotList.Click += new System.EventHandler(this.lisLotList_Click);
            this.lisLotList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lisLotList_KeyDown);
            this.lisLotList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisLotList_MouseDown);
            this.lisLotList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lisLotList_MouseUp);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Seq";
            this.ColumnHeader1.Width = 40;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 120;
            // 
            // colMaterial
            // 
            this.colMaterial.Text = "Material";
            this.colMaterial.Width = 128;
            // 
            // colMatVer
            // 
            this.colMatVer.DisplayIndex = 96;
            this.colMatVer.Text = "Mat Ver";
            this.colMatVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMatVer.Width = 3;
            // 
            // colFlow
            // 
            this.colFlow.DisplayIndex = 3;
            this.colFlow.Text = "Flow";
            this.colFlow.Width = 67;
            // 
            // colFlowSeqNum
            // 
            this.colFlowSeqNum.DisplayIndex = 97;
            this.colFlowSeqNum.Text = "Flow Seq Num";
            this.colFlowSeqNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFlowSeqNum.Width = 5;
            // 
            // colOperation
            // 
            this.colOperation.DisplayIndex = 4;
            this.colOperation.Text = "Operation";
            this.colOperation.Width = 65;
            // 
            // colQty1
            // 
            this.colQty1.DisplayIndex = 5;
            this.colQty1.Text = "Qty 1";
            this.colQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colQty1.Width = 51;
            // 
            // colQty2
            // 
            this.colQty2.DisplayIndex = 6;
            this.colQty2.Text = "Qty 2";
            this.colQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colQty2.Width = 53;
            // 
            // colQty3
            // 
            this.colQty3.DisplayIndex = 7;
            this.colQty3.Text = "Qty3";
            this.colQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colQty3.Width = 51;
            // 
            // colLotType
            // 
            this.colLotType.DisplayIndex = 8;
            this.colLotType.Text = "Lot Type";
            this.colLotType.Width = 70;
            // 
            // colOwnerCode
            // 
            this.colOwnerCode.DisplayIndex = 9;
            this.colOwnerCode.Text = "Owner Code";
            this.colOwnerCode.Width = 90;
            // 
            // colCreateCode
            // 
            this.colCreateCode.DisplayIndex = 10;
            this.colCreateCode.Text = "Create Code";
            this.colCreateCode.Width = 90;
            // 
            // colPriority
            // 
            this.colPriority.DisplayIndex = 11;
            this.colPriority.Text = "Priority";
            // 
            // colLotStatus
            // 
            this.colLotStatus.DisplayIndex = 12;
            this.colLotStatus.Text = "Lot Status";
            this.colLotStatus.Width = 80;
            // 
            // colHoldFlag
            // 
            this.colHoldFlag.DisplayIndex = 13;
            this.colHoldFlag.Text = "Hold Flag";
            this.colHoldFlag.Width = 80;
            // 
            // colHoldCode
            // 
            this.colHoldCode.DisplayIndex = 14;
            this.colHoldCode.Text = "Hold Code";
            this.colHoldCode.Width = 80;
            // 
            // colCreateQty1
            // 
            this.colCreateQty1.DisplayIndex = 15;
            this.colCreateQty1.Text = "Create Qty 1";
            this.colCreateQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCreateQty1.Width = 100;
            // 
            // colCreateQty2
            // 
            this.colCreateQty2.DisplayIndex = 16;
            this.colCreateQty2.Text = "Create Qty 2";
            this.colCreateQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCreateQty2.Width = 100;
            // 
            // colCreateQty3
            // 
            this.colCreateQty3.DisplayIndex = 17;
            this.colCreateQty3.Text = "Create Qty 3";
            this.colCreateQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCreateQty3.Width = 100;
            // 
            // colOperInQty1
            // 
            this.colOperInQty1.DisplayIndex = 18;
            this.colOperInQty1.Text = "Oper In Qty 1";
            this.colOperInQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOperInQty1.Width = 100;
            // 
            // colOperInQty2
            // 
            this.colOperInQty2.DisplayIndex = 19;
            this.colOperInQty2.Text = "Oper In Qty 2";
            this.colOperInQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOperInQty2.Width = 100;
            // 
            // colOperInQty3
            // 
            this.colOperInQty3.DisplayIndex = 20;
            this.colOperInQty3.Text = "Oper In Qty 3";
            this.colOperInQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOperInQty3.Width = 100;
            // 
            // colInvFlag
            // 
            this.colInvFlag.DisplayIndex = 21;
            this.colInvFlag.Text = "Inventory Flag";
            this.colInvFlag.Width = 100;
            // 
            // colTransitFlag
            // 
            this.colTransitFlag.DisplayIndex = 22;
            this.colTransitFlag.Text = "Transit Flag";
            this.colTransitFlag.Width = 100;
            // 
            // colUnitExistFlag
            // 
            this.colUnitExistFlag.DisplayIndex = 23;
            this.colUnitExistFlag.Text = "Unit Exist Flag";
            this.colUnitExistFlag.Width = 100;
            // 
            // colInvUnit
            // 
            this.colInvUnit.DisplayIndex = 24;
            this.colInvUnit.Text = "Inv Unit";
            // 
            // colRwkFlag
            // 
            this.colRwkFlag.DisplayIndex = 25;
            this.colRwkFlag.Text = "Rework Flag";
            this.colRwkFlag.Width = 120;
            // 
            // colRwkCode
            // 
            this.colRwkCode.DisplayIndex = 26;
            this.colRwkCode.Text = "Rework Code";
            this.colRwkCode.Width = 120;
            // 
            // colRwkCount
            // 
            this.colRwkCount.DisplayIndex = 27;
            this.colRwkCount.Text = "Rework Count";
            this.colRwkCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRwkCount.Width = 120;
            // 
            // colRwkRetFlow
            // 
            this.colRwkRetFlow.DisplayIndex = 28;
            this.colRwkRetFlow.Text = "Rework Ret Flow";
            this.colRwkRetFlow.Width = 120;
            // 
            // colRwkRetOper
            // 
            this.colRwkRetOper.DisplayIndex = 29;
            this.colRwkRetOper.Text = "Rework Ret Oper";
            this.colRwkRetOper.Width = 120;
            // 
            // colRwkEndFlow
            // 
            this.colRwkEndFlow.DisplayIndex = 30;
            this.colRwkEndFlow.Text = "Rework End Flow";
            this.colRwkEndFlow.Width = 120;
            // 
            // colRwkEndOper
            // 
            this.colRwkEndOper.DisplayIndex = 31;
            this.colRwkEndOper.Text = "Rework End Oper";
            this.colRwkEndOper.Width = 120;
            // 
            // colRwkRetClearFlag
            // 
            this.colRwkRetClearFlag.DisplayIndex = 32;
            this.colRwkRetClearFlag.Text = "Rework Ret Clear Flag";
            this.colRwkRetClearFlag.Width = 155;
            // 
            // colRwkTime
            // 
            this.colRwkTime.DisplayIndex = 33;
            this.colRwkTime.Text = "Rework Time";
            this.colRwkTime.Width = 120;
            // 
            // colNstdFlag
            // 
            this.colNstdFlag.DisplayIndex = 34;
            this.colNstdFlag.Text = "NSTD Flag";
            this.colNstdFlag.Width = 120;
            // 
            // colNstdRetFlow
            // 
            this.colNstdRetFlow.DisplayIndex = 35;
            this.colNstdRetFlow.Text = "NSTD Ret Flow";
            this.colNstdRetFlow.Width = 120;
            // 
            // colNstdRetOper
            // 
            this.colNstdRetOper.DisplayIndex = 36;
            this.colNstdRetOper.Text = "NSTD Ret Oper";
            this.colNstdRetOper.Width = 120;
            // 
            // colNstdTime
            // 
            this.colNstdTime.DisplayIndex = 37;
            this.colNstdTime.Text = "NSTD Time";
            this.colNstdTime.Width = 120;
            // 
            // colStartFlag
            // 
            this.colStartFlag.DisplayIndex = 38;
            this.colStartFlag.Text = "Start Flag";
            this.colStartFlag.Width = 70;
            // 
            // colStartTime
            // 
            this.colStartTime.DisplayIndex = 39;
            this.colStartTime.Text = "Start Time";
            this.colStartTime.Width = 120;
            // 
            // colStartResID
            // 
            this.colStartResID.DisplayIndex = 40;
            this.colStartResID.Text = "Start Res ID";
            this.colStartResID.Width = 80;
            // 
            // colEndFlag
            // 
            this.colEndFlag.DisplayIndex = 41;
            this.colEndFlag.Text = "End Flag";
            this.colEndFlag.Width = 70;
            // 
            // colEndTime
            // 
            this.colEndTime.DisplayIndex = 42;
            this.colEndTime.Text = "End Time";
            this.colEndTime.Width = 120;
            // 
            // colEndResID
            // 
            this.colEndResID.DisplayIndex = 43;
            this.colEndResID.Text = "End Res ID";
            this.colEndResID.Width = 80;
            // 
            // colSampleFlag
            // 
            this.colSampleFlag.DisplayIndex = 44;
            this.colSampleFlag.Text = "Sample Flag";
            this.colSampleFlag.Width = 100;
            // 
            // colSampleWaitFlag
            // 
            this.colSampleWaitFlag.DisplayIndex = 45;
            this.colSampleWaitFlag.Text = "Sample Wait Flag";
            this.colSampleWaitFlag.Width = 110;
            // 
            // colSampleResult
            // 
            this.colSampleResult.DisplayIndex = 46;
            this.colSampleResult.Text = "Sample Result";
            this.colSampleResult.Width = 100;
            // 
            // colSplitFromLotID
            // 
            this.colSplitFromLotID.DisplayIndex = 47;
            this.colSplitFromLotID.Text = "From To Lot ID";
            this.colSplitFromLotID.Width = 120;
            // 
            // colShipCode
            // 
            this.colShipCode.DisplayIndex = 48;
            this.colShipCode.Text = "Ship Code";
            this.colShipCode.Width = 80;
            // 
            // colShipTime
            // 
            this.colShipTime.DisplayIndex = 49;
            this.colShipTime.Text = "Ship Time";
            this.colShipTime.Width = 120;
            // 
            // colOrgDueTime
            // 
            this.colOrgDueTime.DisplayIndex = 50;
            this.colOrgDueTime.Text = "Original Due Time";
            this.colOrgDueTime.Width = 120;
            // 
            // colSchDueTime
            // 
            this.colSchDueTime.DisplayIndex = 51;
            this.colSchDueTime.Text = "Scheduled Due Time";
            this.colSchDueTime.Width = 145;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.DisplayIndex = 52;
            this.ColumnHeader2.Text = "Create Time";
            this.ColumnHeader2.Width = 120;
            // 
            // colFactoryInTime
            // 
            this.colFactoryInTime.DisplayIndex = 53;
            this.colFactoryInTime.Text = "Factory In Time";
            this.colFactoryInTime.Width = 120;
            // 
            // colFlowInTime
            // 
            this.colFlowInTime.DisplayIndex = 54;
            this.colFlowInTime.Text = "Flow In Time";
            this.colFlowInTime.Width = 120;
            // 
            // colOperInTime
            // 
            this.colOperInTime.DisplayIndex = 55;
            this.colOperInTime.Text = "Oper In Time";
            this.colOperInTime.Width = 120;
            // 
            // colResvResID
            // 
            this.colResvResID.DisplayIndex = 56;
            this.colResvResID.Text = "Reserve Res ID";
            this.colResvResID.Width = 120;
            // 
            // colBatchID
            // 
            this.colBatchID.DisplayIndex = 57;
            this.colBatchID.Text = "Batch ID";
            // 
            // colBatchSeq
            // 
            this.colBatchSeq.DisplayIndex = 58;
            this.colBatchSeq.Text = "Batch Seq";
            this.colBatchSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBatchSeq.Width = 70;
            // 
            // colOrderID
            // 
            this.colOrderID.DisplayIndex = 59;
            this.colOrderID.Text = "Order ID";
            this.colOrderID.Width = 100;
            // 
            // colAddOrder1
            // 
            this.colAddOrder1.DisplayIndex = 60;
            this.colAddOrder1.Text = "Add Order ID 1";
            this.colAddOrder1.Width = 100;
            // 
            // colAddOrder2
            // 
            this.colAddOrder2.DisplayIndex = 61;
            this.colAddOrder2.Text = "Add Order ID 2";
            this.colAddOrder2.Width = 100;
            // 
            // colAddOrder3
            // 
            this.colAddOrder3.DisplayIndex = 62;
            this.colAddOrder3.Text = "Add Order ID 3";
            this.colAddOrder3.Width = 100;
            // 
            // colLocation
            // 
            this.colLocation.DisplayIndex = 63;
            this.colLocation.Text = "Location";
            this.colLocation.Width = 80;
            // 
            // colLotCmf1
            // 
            this.colLotCmf1.DisplayIndex = 64;
            this.colLotCmf1.Text = "Lot Cmf 1";
            this.colLotCmf1.Width = 100;
            // 
            // colLotCmf2
            // 
            this.colLotCmf2.DisplayIndex = 65;
            this.colLotCmf2.Text = "Lot Cmf 2";
            this.colLotCmf2.Width = 100;
            // 
            // colLotCmf3
            // 
            this.colLotCmf3.DisplayIndex = 66;
            this.colLotCmf3.Text = "Lot Cmf 3";
            this.colLotCmf3.Width = 100;
            // 
            // colLotCmf4
            // 
            this.colLotCmf4.DisplayIndex = 67;
            this.colLotCmf4.Text = "Lot Cmf 4";
            this.colLotCmf4.Width = 100;
            // 
            // colLotCmf5
            // 
            this.colLotCmf5.DisplayIndex = 68;
            this.colLotCmf5.Text = "Lot Cmf 5";
            this.colLotCmf5.Width = 100;
            // 
            // colLotCmf6
            // 
            this.colLotCmf6.DisplayIndex = 69;
            this.colLotCmf6.Text = "Lot Cmf 6";
            this.colLotCmf6.Width = 100;
            // 
            // colLotCmf7
            // 
            this.colLotCmf7.DisplayIndex = 70;
            this.colLotCmf7.Text = "Lot Cmf 7";
            this.colLotCmf7.Width = 100;
            // 
            // colLotCmf8
            // 
            this.colLotCmf8.DisplayIndex = 71;
            this.colLotCmf8.Text = "Lot Cmf 8";
            this.colLotCmf8.Width = 100;
            // 
            // colLotCmf9
            // 
            this.colLotCmf9.DisplayIndex = 72;
            this.colLotCmf9.Text = "Lot Cmf 9";
            this.colLotCmf9.Width = 100;
            // 
            // colLotCmf10
            // 
            this.colLotCmf10.DisplayIndex = 73;
            this.colLotCmf10.Text = "Lot Cmf 10";
            this.colLotCmf10.Width = 100;
            // 
            // colLotCmf11
            // 
            this.colLotCmf11.DisplayIndex = 74;
            this.colLotCmf11.Text = "Lot Cmf 11";
            this.colLotCmf11.Width = 100;
            // 
            // colLotCmf12
            // 
            this.colLotCmf12.DisplayIndex = 75;
            this.colLotCmf12.Text = "Lot Cmf 12";
            this.colLotCmf12.Width = 100;
            // 
            // colLotCmf13
            // 
            this.colLotCmf13.DisplayIndex = 76;
            this.colLotCmf13.Text = "Lot Cmf 13";
            this.colLotCmf13.Width = 100;
            // 
            // colLotCmf14
            // 
            this.colLotCmf14.DisplayIndex = 77;
            this.colLotCmf14.Text = "Lot Cmf 14";
            this.colLotCmf14.Width = 100;
            // 
            // colLotCmf15
            // 
            this.colLotCmf15.DisplayIndex = 78;
            this.colLotCmf15.Text = "Lot Cmf 15";
            this.colLotCmf15.Width = 100;
            // 
            // colLotCmf16
            // 
            this.colLotCmf16.DisplayIndex = 79;
            this.colLotCmf16.Text = "Lot Cmf 16";
            this.colLotCmf16.Width = 100;
            // 
            // colLotCmf17
            // 
            this.colLotCmf17.DisplayIndex = 80;
            this.colLotCmf17.Text = "Lot Cmf 17";
            this.colLotCmf17.Width = 100;
            // 
            // colLotCmf18
            // 
            this.colLotCmf18.DisplayIndex = 81;
            this.colLotCmf18.Text = "Lot Cmf 18";
            this.colLotCmf18.Width = 100;
            // 
            // colLotCmf19
            // 
            this.colLotCmf19.DisplayIndex = 82;
            this.colLotCmf19.Text = "Lot Cmf 19";
            this.colLotCmf19.Width = 100;
            // 
            // colLotCmf20
            // 
            this.colLotCmf20.DisplayIndex = 83;
            this.colLotCmf20.Text = "Lot Cmf 20";
            this.colLotCmf20.Width = 100;
            // 
            // colBomSetID
            // 
            this.colBomSetID.DisplayIndex = 84;
            this.colBomSetID.Text = "BOM Set ID";
            this.colBomSetID.Width = 100;
            // 
            // colBomSetVersion
            // 
            this.colBomSetVersion.DisplayIndex = 85;
            this.colBomSetVersion.Text = "BOM Set Version";
            this.colBomSetVersion.Width = 120;
            // 
            // colBomActiveSeq
            // 
            this.colBomActiveSeq.DisplayIndex = 86;
            this.colBomActiveSeq.Text = "BOM Act Hist Seq";
            this.colBomActiveSeq.Width = 120;
            // 
            // colBomHistSeq
            // 
            this.colBomHistSeq.DisplayIndex = 87;
            this.colBomHistSeq.Text = "BOM Hist Seq";
            this.colBomHistSeq.Width = 100;
            // 
            // colLotDelFlag
            // 
            this.colLotDelFlag.DisplayIndex = 88;
            this.colLotDelFlag.Text = "Lot Delete Flag";
            this.colLotDelFlag.Width = 100;
            // 
            // colLotDelTime
            // 
            this.colLotDelTime.DisplayIndex = 89;
            this.colLotDelTime.Text = "Lot Delete Time";
            this.colLotDelTime.Width = 120;
            // 
            // colLotDelReason
            // 
            this.colLotDelReason.DisplayIndex = 90;
            this.colLotDelReason.Text = "Lot Delete Reason";
            this.colLotDelReason.Width = 150;
            // 
            // colLastTranCode
            // 
            this.colLastTranCode.DisplayIndex = 91;
            this.colLastTranCode.Text = "Last Trans Code";
            this.colLastTranCode.Width = 120;
            // 
            // colLastTranTime
            // 
            this.colLastTranTime.DisplayIndex = 92;
            this.colLastTranTime.Text = "Last Trans Time";
            this.colLastTranTime.Width = 120;
            // 
            // colLastComment
            // 
            this.colLastComment.DisplayIndex = 93;
            this.colLastComment.Text = "Last Comment";
            this.colLastComment.Width = 200;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.DisplayIndex = 94;
            this.ColumnHeader3.Text = "Last Active Hist Seq";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader3.Width = 140;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.DisplayIndex = 95;
            this.ColumnHeader4.Text = "Last Hist Seq";
            this.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader4.Width = 120;
            // 
            // Splitter1
            // 
            this.Splitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Splitter1.Location = new System.Drawing.Point(0, 194);
            this.Splitter1.Name = "Splitter1";
            this.Splitter1.Size = new System.Drawing.Size(660, 3);
            this.Splitter1.TabIndex = 5;
            this.Splitter1.TabStop = false;
            // 
            // lisResourceList
            // 
            this.lisResourceList.AllowColumnReorder = true;
            this.lisResourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colRes,
            this.colDesc,
            this.colType,
            this.colUpDown,
            this.colPriSts,
            this.colPrt1,
            this.colPrt2,
            this.colPrt3,
            this.colPrt4,
            this.colPrt5,
            this.colPrt6,
            this.colPrt7,
            this.colPrt8,
            this.colPrt9,
            this.colPrt10,
            this.colSts1,
            this.colSts2,
            this.colSts3,
            this.colSts4,
            this.colSts5,
            this.colSts6,
            this.colSts7,
            this.colSts8,
            this.colSts9,
            this.colSts10,
            this.colUseFac,
            this.colLastEvent,
            this.colLastEventTime,
            this.colLastStartTime,
            this.colLastEndTime,
            this.colProcCount,
            this.colMaxProcCount,
            this.colLastActiveHistSeq,
            this.colLastHistSeq,
            this.colCreateUser,
            this.colCreateTime,
            this.colUpdateUser,
            this.colUpdateTime});
            this.lisResourceList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lisResourceList.EnableSort = true;
            this.lisResourceList.EnableSortIcon = true;
            this.lisResourceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResourceList.FullRowSelect = true;
            this.lisResourceList.Location = new System.Drawing.Point(0, 0);
            this.lisResourceList.MultiSelect = false;
            this.lisResourceList.Name = "lisResourceList";
            this.lisResourceList.Size = new System.Drawing.Size(660, 194);
            this.lisResourceList.TabIndex = 4;
            this.lisResourceList.UseCompatibleStateImageBehavior = false;
            this.lisResourceList.View = System.Windows.Forms.View.Details;
            this.lisResourceList.Click += new System.EventHandler(this.lisResourceList_Click);
            this.lisResourceList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lisResourceList_KeyDown);
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 44;
            // 
            // colRes
            // 
            this.colRes.Text = "Resource ID";
            this.colRes.Width = 89;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Res Desc";
            this.colDesc.Width = 119;
            // 
            // colType
            // 
            this.colType.Text = "Res Type";
            this.colType.Width = 98;
            // 
            // colUpDown
            // 
            this.colUpDown.Text = "Up/Down";
            this.colUpDown.Width = 59;
            // 
            // colPriSts
            // 
            this.colPriSts.Text = "Primary Status";
            this.colPriSts.Width = 88;
            // 
            // colPrt1
            // 
            this.colPrt1.Text = "Status Prompt 1";
            this.colPrt1.Width = 120;
            // 
            // colPrt2
            // 
            this.colPrt2.Text = "Status Prompt 2";
            this.colPrt2.Width = 120;
            // 
            // colPrt3
            // 
            this.colPrt3.Text = "Status Prompt 3";
            this.colPrt3.Width = 120;
            // 
            // colPrt4
            // 
            this.colPrt4.Text = "Status Prompt 4";
            this.colPrt4.Width = 120;
            // 
            // colPrt5
            // 
            this.colPrt5.Text = "Status Prompt 5";
            this.colPrt5.Width = 120;
            // 
            // colPrt6
            // 
            this.colPrt6.Text = "Status Prompt 6";
            this.colPrt6.Width = 120;
            // 
            // colPrt7
            // 
            this.colPrt7.Text = "Status Prompt 7";
            this.colPrt7.Width = 120;
            // 
            // colPrt8
            // 
            this.colPrt8.Text = "Status Prompt 8";
            this.colPrt8.Width = 120;
            // 
            // colPrt9
            // 
            this.colPrt9.Text = "Status Prompt 9";
            this.colPrt9.Width = 120;
            // 
            // colPrt10
            // 
            this.colPrt10.Text = "Status Prompt 10";
            this.colPrt10.Width = 120;
            // 
            // colSts1
            // 
            this.colSts1.Text = "Status 1";
            this.colSts1.Width = 120;
            // 
            // colSts2
            // 
            this.colSts2.Text = "Status 2";
            this.colSts2.Width = 120;
            // 
            // colSts3
            // 
            this.colSts3.Text = "Status 3";
            this.colSts3.Width = 120;
            // 
            // colSts4
            // 
            this.colSts4.Text = "Status 4";
            this.colSts4.Width = 120;
            // 
            // colSts5
            // 
            this.colSts5.Text = "Status 5";
            this.colSts5.Width = 120;
            // 
            // colSts6
            // 
            this.colSts6.Text = "Status 6";
            this.colSts6.Width = 120;
            // 
            // colSts7
            // 
            this.colSts7.Text = "Status 7";
            this.colSts7.Width = 120;
            // 
            // colSts8
            // 
            this.colSts8.Text = "Status 8";
            this.colSts8.Width = 120;
            // 
            // colSts9
            // 
            this.colSts9.Text = "Status 9";
            this.colSts9.Width = 120;
            // 
            // colSts10
            // 
            this.colSts10.Text = "Status 10";
            this.colSts10.Width = 120;
            // 
            // colUseFac
            // 
            this.colUseFac.Text = "Use Fac Prt Flag";
            this.colUseFac.Width = 100;
            // 
            // colLastEvent
            // 
            this.colLastEvent.Text = "Last Event";
            this.colLastEvent.Width = 100;
            // 
            // colLastEventTime
            // 
            this.colLastEventTime.Text = "Last Event Time";
            this.colLastEventTime.Width = 120;
            // 
            // colLastStartTime
            // 
            this.colLastStartTime.Text = "Last Start Time";
            this.colLastStartTime.Width = 120;
            // 
            // colLastEndTime
            // 
            this.colLastEndTime.Text = "Last End Time";
            this.colLastEndTime.Width = 120;
            // 
            // colProcCount
            // 
            this.colProcCount.Text = "Proc Lot Count";
            this.colProcCount.Width = 100;
            // 
            // colMaxProcCount
            // 
            this.colMaxProcCount.Text = "Max Proc Count";
            this.colMaxProcCount.Width = 100;
            // 
            // colLastActiveHistSeq
            // 
            this.colLastActiveHistSeq.Text = "Last Active Hist Seq";
            this.colLastActiveHistSeq.Width = 120;
            // 
            // colLastHistSeq
            // 
            this.colLastHistSeq.Text = "Last Hist Seq";
            this.colLastHistSeq.Width = 100;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 110;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Text = "Create Time";
            this.colCreateTime.Width = 120;
            // 
            // colUpdateUser
            // 
            this.colUpdateUser.Text = "Update User";
            this.colUpdateUser.Width = 110;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.Text = "Update Time";
            this.colUpdateTime.Width = 120;
            // 
            // tmrGotMessage
            // 
            this.tmrGotMessage.Interval = 1000;
            this.tmrGotMessage.Tick += new System.EventHandler(this.tmrGotMessage_Tick);
            // 
            // frmResourceListMain
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(660, 393);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmResourceListMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Resource List Main";
            this.Activated += new System.EventHandler(this.frmResourceListMain_Activated);
            this.Closed += new System.EventHandler(this.frmResourceListMain_Closed);
            this.Load += new System.EventHandler(this.frmResourceListMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmResourceListMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmResourceListMain_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmResourceListMain_KeyUp);
            this.Resize += new System.EventHandler(this.frmResourceListMain_Resize);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private string s_current_area;
        private string s_current_sub_area;
        private bool b_got_favorite;
        private bool b_got_msg_flag;
        
        
        #endregion
        
        #region " Function Definition "
        
        // initCodeView()
        //       - initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //        -
        private void initCodeView()
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvType.GetListView, '1', MPGC.MP_RAS_RES_TYPE, - 1, null, "", false, - 1, - 1, null);
            cdvType.InsertEmptyRow(0, 1);
            
        }
        
        // GetSubMenu()
        //       - initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //        -
        private bool GetSubMenu()
        {
            int i;
            ListView lisTmp;
            MenuItem mnuTmp;

            try
            {
                ctxMenu.MenuItems.Clear();
                lisTmp = new ListView();
                lisTmp.View = View.Details;

                lisTmp.Columns.Add(new ColumnHeader());
                lisTmp.Columns.Add(new ColumnHeader());
                SECLIST.ViewFavoritesList(lisTmp, '1', MPGV.gsProgramID, null, "");

                if (lisTmp.Items.Count < 1)
                {
                    b_got_favorite = false;
                    mnuTmp = new MenuItem("View Resource Status", new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "RAS3001"; ctxMenu.MenuItems.Add(mnuTmp);
                    mnuTmp = new MenuItem("View Resource History", new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "RAS3002"; ctxMenu.MenuItems.Add(mnuTmp);
                }
                else
                {
                    b_got_favorite = true;
                    for (i = 0; i < lisTmp.Items.Count; i++)
                    {
                        mnuTmp = new MenuItem(lisTmp.Items[i].SubItems[1].Text, new EventHandler(subMenu_Click));
                        mnuTmp.Tag = lisTmp.Items[i].Tag;
                        ctxMenu.MenuItems.Add(mnuTmp);
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        // View_Resource_List()
        //       - View Resource List
        // Return Value
        //       -
        // Arguments
        //        -
        private bool View_Resource_List()
        {
            if (s_current_area != "" || s_current_sub_area != "")
            {
                
                MPGV.gaSelectRes_ID.Clear();
                MPGV.gsCurrentRes_ID = "";
                
                MPCF.ClearList(lisLotList, true);
                
                RASLIST.ViewResourceListDetail(lisResourceList, cdvType.Text, "", s_current_area, s_current_sub_area, "", false, true, "", false);
                txtTotRes.Text = lisResourceList.Items.Count.ToString();
                
            }
            return true;
            
        }
        
        
        // View_Lot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_Lot_List(string sResID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_BY_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_BY_RESOURCE_OUT");

            int i;
            int iTotLot;
            double dTotQty_1;
            double dTotQty_2;
            double dTotQty_3;

            MPCF.InitListView(lisLotList);
            MPGV.gaSelectLot_ID.Clear();
            MPGV.gsCurrentLot_ID = "";

            iTotLot = 0;
            dTotQty_1 = 0;
            dTotQty_2 = 0;
            dTotQty_3 = 0;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("RES_ID", sResID);
            in_node.AddString("MAT_ID", "");
            in_node.AddInt("MAT_VER", 0);
            in_node.AddString("FLOW", "");
            in_node.AddString("OPER", "");

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_List_By_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iTotLot++;

                    DisplayLotListDetail(lisLotList, out_node.GetList(0)[i], 0);

                    dTotQty_1 += out_node.GetList(0)[i].GetDouble("QTY_1");
                    dTotQty_2 += out_node.GetList(0)[i].GetDouble("QTY_2");
                    dTotQty_3 += out_node.GetList(0)[i].GetDouble("QTY_3");

                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            return true;
        }


        private void DisplayLotListDetail(Control control, TRSNode lot_out, int proc_step)
        {
            int iRow;
            ListViewItem itmX;
            
            if (control is ListView)
            {
                
                iRow = ((ListView) control).Items.Count + 1;
                
                itmX = new ListViewItem(iRow.ToString());
                
                if (proc_step == 1)
                {
                    itmX.SubItems.Add(lot_out.GetString("FACTORY"));
                }
                itmX.SubItems.Add(lot_out.GetString("LOT_ID"));
                itmX.SubItems.Add(lot_out.GetString("MAT_ID"));
                itmX.SubItems.Add(lot_out.GetInt("MAT_VER").ToString());
                itmX.SubItems.Add(lot_out.GetString("FLOW"));
                itmX.SubItems.Add(lot_out.GetInt("FLOW_SEQ_NUM").ToString());
                itmX.SubItems.Add(lot_out.GetString("OPER"));

                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_out.GetDouble("QTY_1")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_out.GetDouble("QTY_2")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_out.GetDouble("QTY_3")));

                itmX.SubItems.Add(lot_out.GetChar("LOT_TYPE").ToString());
                itmX.SubItems.Add(lot_out.GetString("OWNER_CODE"));
                itmX.SubItems.Add(lot_out.GetString("CREATE_CODE"));
                itmX.SubItems.Add(lot_out.GetChar("LOT_PRIORITY").ToString());
                itmX.SubItems.Add(lot_out.GetString("LOT_STATUS"));
                itmX.SubItems.Add(lot_out.GetChar("HOLD_FLAG").ToString());
                itmX.SubItems.Add(lot_out.GetString("HOLD_CODE"));

                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_out.GetDouble("CREATE_QTY_1")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_out.GetDouble("CREATE_QTY_2")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_out.GetDouble("CREATE_QTY_3")));

                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_out.GetDouble("OPER_IN_QTY_1")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_out.GetDouble("OPER_IN_QTY_2")));
                itmX.SubItems.Add(MPCF.Format("########,##0.###", lot_out.GetDouble("OPER_IN_QTY_3")));

                itmX.SubItems.Add(lot_out.GetChar("INV_FLAG").ToString());
                itmX.SubItems.Add(lot_out.GetChar("TRANSIT_FLAG").ToString());
                itmX.SubItems.Add(lot_out.GetChar("UNIT_EXIST_FLAG").ToString());
                itmX.SubItems.Add(lot_out.GetString("INV_UNIT"));

                itmX.SubItems.Add(lot_out.GetChar("RWK_FLAG").ToString());
                itmX.SubItems.Add(lot_out.GetString("RWK_CODE"));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_out.GetInt("RWK_COUNT")));
                itmX.SubItems.Add(lot_out.GetString("RWK_RET_FLOW"));
                itmX.SubItems.Add(lot_out.GetString("RWK_RET_OPER"));
                itmX.SubItems.Add(lot_out.GetString("RWK_END_FLOW"));
                itmX.SubItems.Add(lot_out.GetString("RWK_END_OPER"));
                itmX.SubItems.Add(lot_out.GetChar("RWK_RET_CLEAR_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("RWK_TIME")));

                itmX.SubItems.Add(lot_out.GetChar("NSTD_FLAG").ToString());
                itmX.SubItems.Add(lot_out.GetString("NSTD_RET_FLOW"));
                itmX.SubItems.Add(lot_out.GetString("NSTD_RET_OPER"));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("NSTD_TIME")));

                itmX.SubItems.Add(lot_out.GetChar("START_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("START_TIME")));
                itmX.SubItems.Add(lot_out.GetString("START_RES_ID"));
                itmX.SubItems.Add(lot_out.GetChar("END_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("END_TIME")));
                itmX.SubItems.Add(lot_out.GetString("END_RES_ID"));

                itmX.SubItems.Add(lot_out.GetChar("SAMPLE_FLAG").ToString());
                itmX.SubItems.Add(lot_out.GetChar("SAMPLE_WAIT_FLAG").ToString());

                switch (lot_out.GetChar("SAMPLE_RESULT"))
                {
                    case 'Y':

                        itmX.SubItems.Add("Good");
                        break;
                    case 'N':

                        itmX.SubItems.Add("No Good");
                        break;
                    default:

                        itmX.SubItems.Add("");
                        break;
                }
                itmX.SubItems.Add(lot_out.GetString("FROM_TO_LOT_ID"));
                itmX.SubItems.Add(lot_out.GetString("SHIP_CODE"));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("SHIP_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("CREATE_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("FAC_IN_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("FLOW_IN_TIME")));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("OPER_IN_TIME")));
                itmX.SubItems.Add(lot_out.GetString("RESERVE_RES_ID"));
                itmX.SubItems.Add(lot_out.GetString("BATCH_ID"));
                itmX.SubItems.Add(MPCF.Format("#######,##0", lot_out.GetInt("BATCH_SEQ")));
                itmX.SubItems.Add(lot_out.GetString("ORDER_ID"));
                itmX.SubItems.Add(lot_out.GetString("ADD_ORDER_ID_1"));
                itmX.SubItems.Add(lot_out.GetString("ADD_ORDER_ID_2"));
                itmX.SubItems.Add(lot_out.GetString("ADD_ORDER_ID_3"));
                itmX.SubItems.Add(lot_out.GetString("LOT_LOCATION"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_1"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_2"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_3"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_4"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_5"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_6"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_7"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_8"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_9"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_10"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_11"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_12"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_13"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_14"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_15"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_16"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_17"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_18"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_19"));
                itmX.SubItems.Add(lot_out.GetString("LOT_CMF_20"));
                itmX.SubItems.Add(lot_out.GetString("BOM_SET_ID"));
                itmX.SubItems.Add(lot_out.GetInt("BOM_SET_VERSION").ToString());
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_out.GetInt("BOM_ACTIVE_HIST_SEQ")));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_out.GetInt("BOM_HIST_SEQ")));

                itmX.SubItems.Add(lot_out.GetChar("LOT_DEL_FLAG").ToString());
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("LOT_DEL_TIME")));
                itmX.SubItems.Add(lot_out.GetString("LOT_DEL_CODE"));

                itmX.SubItems.Add(lot_out.GetString("LAST_TRAN_CODE"));
                itmX.SubItems.Add(MPCF.MakeDateFormat(lot_out.GetString("LAST_TRAN_TIME")));
                itmX.SubItems.Add(lot_out.GetString("LAST_COMMENT"));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_out.GetInt("LAST_ACTIVE_HIST_SEQ")));
                itmX.SubItems.Add(MPCF.Format("########,##0", lot_out.GetInt("LAST_HIST_SEQ")));

                if (lot_out.GetChar("HOLD_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                }
                else if (lot_out.GetChar("START_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_START;
                }
                else if (lot_out.GetChar("RWK_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                }
                else if (lot_out.GetChar("NSTD_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                }
                else if (lot_out.GetString("LAST_TRAN_CODE") == MPGC.MP_TRAN_CODE_RELEASE)
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                }
                else if (lot_out.GetChar("REP_FLAG") == 'Y')
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                }
                else
                {
                    itmX.ImageIndex =  (int)SMALLICON_INDEX.IDX_LOT;
                }

                ((ListView) control).Items.Add(itmX);


            }
            
        }
        
        // SetArea()
        //       - Setting Area at "frmMIDMain"
        // Return Value
        //       -
        // Arguments
        //        -
        public void SetArea(string sArea, string sSubArea, int iWidth, int iHeight)
        {
            s_current_area = sArea;
            s_current_sub_area = sSubArea;
            cdvType.Text = "";
            
            if (this.Width + 4 > iWidth)
            {
                this.Left = 0;
                this.Width = iWidth - 4;
            }
            if (this.Height + 4 > iHeight)
            {
                this.Top = 0;
                this.Height = iHeight - 4;
            }
            
            if (b_load_flag == true)
            {
                View_Resource_List();
            }
            else
            {
                this.Top = 0;
                this.Left = 0;
                this.Width = iWidth - 4;
                this.Height = iHeight - 4;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisResourceList;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }

        private bool GetPopupMessageForRes()
        {
            TRSNode out_node = new TRSNode("VIEW_BBS_MSG_LIST_OUT");
            int i_msg_cnt = 0;

            b_got_msg_flag = false;
            tmrGotMessage.Stop();
            tmrGotMessage.Enabled = false;
            btnMessage.Visible = false;
            btnMessage.Tag = null;

            try
            {
                if (BASLIST.ViewBBSMsgListForRes(out_node, MPGV.gsCurrentRes_ID) == false)
                {
                    return false;
                }

                i_msg_cnt = out_node.GetList("MSG_LIST").Count;
                if (i_msg_cnt > 0)
                {
                    out_node.AddBoolean("__FOR_RES", true);
                    b_got_msg_flag = true;
                    btnMessage.Tag = out_node;
                    tmrGotMessage.Enabled = true;
                    tmrGotMessage.Start();
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool GetPopupMessageForLot()
        {
            TRSNode out_node = new TRSNode("VIEW_BBS_MSG_LIST_OUT");
            int i_msg_cnt = 0;

            b_got_msg_flag = false;
            tmrGotMessage.Stop();
            tmrGotMessage.Enabled = false;
            btnMessage.Visible = false;
            btnMessage.Tag = null;

            try
            {
                if (BASLIST.ViewBBSMsgList(out_node, MPGV.gsCurrentLot_ID, "", "", "", "", MPGV.gsCurrentRes_ID, "", "", true) == false)
                {
                    return false;
                }

                i_msg_cnt = out_node.GetList("MSG_LIST").Count;
                if (i_msg_cnt > 0)
                {
                    out_node.AddBoolean("__FOR_LOT", true);
                    b_got_msg_flag = true;
                    btnMessage.Tag = out_node;
                    tmrGotMessage.Enabled = true;
                    tmrGotMessage.Start();
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion
        
        private void frmResourceListMain_Load(object sender, System.EventArgs e)
        {
            this.lblFormTitle.Text = this.Text;
            
            MPGV.gIBaseFormEvent.Form_Load(this, e);
            
            chkAutoRefresh.Checked = false;
            if (MPGV.giAutoRefreshTime > 0)
            {
                chkAutoRefresh.Checked = MPGV.gbAutoRefresh;
                tmrTimer.Interval = MPGV.giAutoRefreshTime * 1000;
            }
            
            if (chkAutoRefresh.Checked == true)
            {
                tmrTimer.Start();
            }
            else
            {
                tmrTimer.Stop();
            }
        }
        
        private void frmResourceListMain_Closed(object sender, System.EventArgs e)
        {
            try
            {
                MPGV.gaSelectRes_ID.Clear();
                MPGV.gsCurrentRes_ID = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmResourceListMain_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                MPCF.InitListView(lisResourceList);
                MPCF.InitListView(lisLotList);
                initCodeView();
                MPGV.gbFavoriteChangeForResourceListMain = false;
                GetSubMenu();
                View_Resource_List();
                
                b_load_flag = true;
            }
            else
            {
                if (chkAutoRefresh.Checked == true)
                {
                    View_Resource_List();
                }

                //Add by J.S. 2009.02.13  favorites 수정 했을시 Refresh되게 하기 위해서....
                if (MPGV.gbFavoriteChangeForResourceListMain == true)
                {
                    MPGV.gbFavoriteChangeForResourceListMain = false;
                    GetSubMenu();
                }
            }
        }
        
        private void frmResourceListMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is ListView)
                {
                    ListView lisList;
                    if (e.Control == true && e.KeyCode == Keys.C)
                    {
                        lisList = (ListView) this.ActiveControl;
                        if (lisList.SelectedItems.Count == 0)
                        {
                            Clipboard.SetDataObject("", true);
                        }
                        else
                        {
                            Clipboard.SetDataObject(lisList.SelectedItems[0].SubItems[1].Text, true);
                        }
                    }
                }
            }
        }
        
        private void frmResourceListMain_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is TextBox)
                {
                    if (e.KeyValue != 13 && e.KeyValue != 8 || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                    {
                        if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        
        private void frmResourceListMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    if (e.KeyChar == (char)58)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        
        private void frmResourceListMain_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                if (this.MdiParent != null)
                {
                    pnlTop.Visible = true;
                }
                else
                {
                    pnlTop.Visible = false;
                }
            }
            else
            {
                pnlTop.Visible = false;
            }
        }
        
        private void lblFormTitle_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            string sResID;
            
            sResID = MPGV.gsCurrentRes_ID;
            View_Resource_List();
            
            if (sResID != "")
            {
                MPGV.gsCurrentRes_ID = sResID;
                MPCF.FindListItem(lisResourceList, MPGV.gsCurrentRes_ID, 1, false);
                if (lisResourceList.SelectedItems.Count < 1)
                {
                    return;
                }
                View_Lot_List(MPGV.gsCurrentRes_ID);
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "";
            if (cdvType.Text != "")
            {
                sCond = sCond + "Res Type : " + cdvType.Text + "\r";
            }
            sCond = sCond + "Area     : " + s_current_area + "\r";
            sCond = sCond + "Sub Area : " + s_current_sub_area;

            if (MPCF.ExportToExcel(lisResourceList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }
        
        
        private void tmrTimer_Tick(object sender, System.EventArgs e)
        {
            string sResID;

            /* 2013.06.12. Aiden. Middleware 가 사용가능한지 확인 */
            if (MPIF.gInit.IsAvailableSendMessage == true)
            {
                sResID = MPGV.gsCurrentRes_ID;
                View_Resource_List();
                
                if (sResID != "")
                {
                    MPGV.gsCurrentRes_ID = sResID;
                    MPCF.FindListItem(lisResourceList, MPGV.gsCurrentRes_ID, 1, false);
                    if (lisResourceList.SelectedItems.Count < 1)
                    {
                        return;
                    }

                    GetPopupMessageForRes();

                    View_Lot_List(MPGV.gsCurrentRes_ID);
                }
            }
        }
        
        private void subMenu_Click(System.Object sender, System.EventArgs e)
        {
            if (((MenuItem)sender).Tag == null) return;

            if (b_got_favorite == false)
            {
                string s_func_name = MPCF.Trim(((MenuItem)sender).Tag);
                MPGV.gIMdiForm.ActiveMenu(s_func_name);
            }
            else
            {
                MenuInfoTag m_menu = (MenuInfoTag)(((MenuItem)sender).Tag);
                MPGV.gIMdiForm.ActiveMenu(m_menu);
            }
        }
        
        private void cdvType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            View_Resource_List();
        }
        
        
        private void lisResourceList_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sResID;
                
                
                if (lisResourceList.SelectedItems.Count < 1)
                {
                    return;
                }
                sResID = lisResourceList.SelectedItems[0].SubItems[1].Text;
                
                MPGV.gaSelectRes_ID.Clear();
                MPGV.gsCurrentRes_ID = "";
                MPGV.gaSelectRes_ID.Add(lisResourceList.SelectedItems[0].SubItems[1].Text);
                MPGV.gsCurrentRes_ID = lisResourceList.SelectedItems[0].SubItems[1].Text;

                GetPopupMessageForRes();

                View_Lot_List(MPGV.gsCurrentRes_ID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisResourceList_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                ListView lisList;
                lisList = (ListView) sender;
                if (lisList.SelectedItems.Count == 0)
                {
                    Clipboard.SetDataObject("", true);
                }
                else
                {
                    Clipboard.SetDataObject(lisList.SelectedItems[0].SubItems[1].Text, true);
                }
            }
        }
        
        
        private void lisLotList_Click(object sender, System.EventArgs e)
        {
            int i;
            
            if (lisLotList.SelectedItems.Count > 0)
            {
                MPGV.gaSelectLot_ID.Clear();
                MPGV.gsCurrentLot_ID = "";
                
                for (i = 0; i <= lisLotList.SelectedItems.Count - 1; i++)
                {
                    MPGV.gaSelectLot_ID.Add(lisLotList.SelectedItems[i].SubItems[1].Text);
                }
                
                MPGV.gsCurrentLot_ID = lisLotList.FocusedItem.SubItems[1].Text;

                GetPopupMessageForLot();
            }
        }
        
        private void lisLotList_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                ListView lisList;
                lisList = (ListView) sender;
                if (lisList.SelectedItems.Count == 0)
                {
                    Clipboard.SetDataObject("", true);
                }
                else
                {
                    Clipboard.SetDataObject(lisList.SelectedItems[0].SubItems[1].Text, true);
                }
            }
        }
        
        
        private void lisLotList_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ctxMenu.Show(lisLotList, new Point(e.X, e.Y));
            }
        }
        
        private void lisLotList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MPGV.gaSelectLot_ID.Clear();
            MPGV.gsCurrentLot_ID = "";
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            TRSNode out_node;
            try
            {
                out_node = (TRSNode)btnMessage.Tag;
                if (out_node != null)
                {
                    if (out_node.GetBoolean("__FOR_RES") == true)
                    {
                        MPCR.PopupInformNote(out_node, "", "", "", "", "", MPGV.gsCurrentRes_ID);
                    }
                    else if (out_node.GetBoolean("__FOR_LOT") == true)
                    {
                        MPCR.PopupInformNote(out_node, "", MPGV.gsCurrentLot_ID, "", "", "", MPGV.gsCurrentRes_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tmrGotMessage_Tick(object sender, EventArgs e)
        {
            if (b_got_msg_flag == true)
            {
                btnMessage.Visible = true;
                if (btnMessage.BackColor.Equals(Color.LemonChiffon) == true)
                {
                    btnMessage.BackColor = Color.Salmon;
                }
                else
                {
                    btnMessage.BackColor = Color.LemonChiffon;
                }
            }
            else
            {
                btnMessage.Visible = false;
            }
        }
        
    }
    //#End If
}
