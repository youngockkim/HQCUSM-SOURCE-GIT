
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranMakeBatcht.vb
//   Description : Make Batch
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - Start_Lot() : Start Lot transaction
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

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI;
using Miracom.TRSCore;


namespace Miracom.WIPCore
{
    public class frmWIPTranMakeBatch : Miracom.CliFrx.BaseForm03
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranMakeBatch()
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
        private System.Windows.Forms.GroupBox grpLotList;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private System.Windows.Forms.ColumnHeader colSeq;
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
        private ColumnHeader colMatVer;
        private ColumnHeader colFlowSeq;
        private Button btnClose;
        private Button btnMake;
        private Button btnInquiryBatch;
        private TextBox txtBatchID;
        private Label lblBatchID;
        private GroupBox grpRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private Label lblResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private Label lblOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private Label lblFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Button btnDel;
        private Button btnAdd;
        private ColumnHeader colRemainQtime;
        private Splitter sptTop;
        private Button btnCancel;
        private CheckBox chkReserveBatch;
        private TextBox txtBatchComment;
        private Button btnConfirm;
        private CheckBox chkConfirm;
        private Button btnSeq;
        private Label lblBatchComment;
        private GroupBox grpLowerBatch;
        private GroupBox grpBatchLotList;
        private Miracom.UI.Controls.MCListView.MCListView lisAddLot;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader101;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        private ColumnHeader columnHeader25;
        private ColumnHeader columnHeader26;
        private ColumnHeader columnHeader27;
        private ColumnHeader columnHeader28;
        private ColumnHeader columnHeader29;
        private ColumnHeader columnHeader30;
        private ColumnHeader columnHeader31;
        private ColumnHeader columnHeader32;
        private ColumnHeader columnHeader33;
        private ColumnHeader columnHeader34;
        private ColumnHeader columnHeader35;
        private ColumnHeader columnHeader36;
        private ColumnHeader columnHeader37;
        private ColumnHeader columnHeader38;
        private ColumnHeader columnHeader39;
        private ColumnHeader columnHeader40;
        private ColumnHeader columnHeader41;
        private ColumnHeader columnHeader42;
        private ColumnHeader columnHeader43;
        private ColumnHeader columnHeader44;
        private ColumnHeader columnHeader45;
        private ColumnHeader columnHeader46;
        private ColumnHeader columnHeader47;
        private ColumnHeader columnHeader48;
        private ColumnHeader columnHeader49;
        private ColumnHeader columnHeader50;
        private ColumnHeader columnHeader51;
        private ColumnHeader columnHeader52;
        private ColumnHeader columnHeader53;
        private ColumnHeader columnHeader54;
        private ColumnHeader columnHeader55;
        private ColumnHeader columnHeader56;
        private ColumnHeader columnHeader57;
        private ColumnHeader columnHeader58;
        private ColumnHeader columnHeader59;
        private ColumnHeader columnHeader60;
        private ColumnHeader columnHeader61;
        private ColumnHeader columnHeader62;
        private ColumnHeader columnHeader64;
        private ColumnHeader columnHeader65;
        private ColumnHeader columnHeader66;
        private ColumnHeader columnHeader67;
        private ColumnHeader columnHeader68;
        private ColumnHeader columnHeader69;
        private ColumnHeader columnHeader70;
        private ColumnHeader columnHeader71;
        private ColumnHeader columnHeader72;
        private ColumnHeader columnHeader73;
        private ColumnHeader columnHeader74;
        private ColumnHeader columnHeader75;
        private ColumnHeader columnHeader76;
        private ColumnHeader columnHeader77;
        private ColumnHeader columnHeader78;
        private ColumnHeader columnHeader79;
        private ColumnHeader columnHeader80;
        private ColumnHeader columnHeader81;
        private ColumnHeader columnHeader82;
        private ColumnHeader columnHeader83;
        private ColumnHeader columnHeader84;
        private ColumnHeader columnHeader85;
        private ColumnHeader columnHeader86;
        private ColumnHeader columnHeader87;
        private ColumnHeader columnHeader88;
        private ColumnHeader columnHeader89;
        private ColumnHeader columnHeader90;
        private ColumnHeader columnHeader91;
        private ColumnHeader columnHeader92;
        private ColumnHeader columnHeader93;
        private ColumnHeader columnHeader94;
        private ColumnHeader columnHeader95;
        private ColumnHeader columnHeader96;
        private ColumnHeader columnHeader97;
        private ColumnHeader columnHeader98;
        private ColumnHeader columnHeader99;
        private ColumnHeader columnHeader100;
        private Panel pnlUpDown;
        private Button btnUp;
        private Button btnDown;
        private Label lblReserveBatchID;
        private TextBox txtLotBatchID;
        private Label lblLotBatchID;
        private Button btnApplyBatch;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvReserveBatchID;
        private ColumnHeader colReserveBatchID;
        private Button btnInquiryLotList;
        private ColumnHeader columnHeader1;
        private Button btnNPWAdd;
        private TextBox txtNPWID;
        private Label lblNPW;
        private CheckBox chkOverriable;
        private CheckBox chkManual;
        private System.Windows.Forms.GroupBox grpBatch;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPTranMakeBatch));
            this.grpBatch = new System.Windows.Forms.GroupBox();
            this.btnInquiryLotList = new System.Windows.Forms.Button();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOper = new System.Windows.Forms.Label();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFlow = new System.Windows.Forms.Label();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.grpLotList = new System.Windows.Forms.GroupBox();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBatchID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBatchSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReserveBatchID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMake = new System.Windows.Forms.Button();
            this.btnInquiryBatch = new System.Windows.Forms.Button();
            this.grpRes = new System.Windows.Forms.GroupBox();
            this.btnNPWAdd = new System.Windows.Forms.Button();
            this.txtNPWID = new System.Windows.Forms.TextBox();
            this.lblNPW = new System.Windows.Forms.Label();
            this.btnApplyBatch = new System.Windows.Forms.Button();
            this.cdvReserveBatchID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblReserveBatchID = new System.Windows.Forms.Label();
            this.txtLotBatchID = new System.Windows.Forms.TextBox();
            this.lblLotBatchID = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.sptTop = new System.Windows.Forms.Splitter();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkReserveBatch = new System.Windows.Forms.CheckBox();
            this.txtBatchComment = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.chkConfirm = new System.Windows.Forms.CheckBox();
            this.btnSeq = new System.Windows.Forms.Button();
            this.lblBatchComment = new System.Windows.Forms.Label();
            this.grpLowerBatch = new System.Windows.Forms.GroupBox();
            this.chkManual = new System.Windows.Forms.CheckBox();
            this.chkOverriable = new System.Windows.Forms.CheckBox();
            this.grpBatchLotList = new System.Windows.Forms.GroupBox();
            this.lisAddLot = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.pnlUpDown = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpBatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            this.grpLotList.SuspendLayout();
            this.grpRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReserveBatchID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.grpLowerBatch.SuspendLayout();
            this.grpBatchLotList.SuspendLayout();
            this.pnlUpDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grpLowerBatch);
            this.pnlBottom.Controls.Add(this.btnSeq);
            this.pnlBottom.Controls.Add(this.btnInquiryBatch);
            this.pnlBottom.Controls.Add(this.btnMake);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnConfirm);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 447);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlBottom.Size = new System.Drawing.Size(742, 99);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpBatchLotList);
            this.pnlCenter.Controls.Add(this.grpRes);
            this.pnlCenter.Controls.Add(this.sptTop);
            this.pnlCenter.Controls.Add(this.grpLotList);
            this.pnlCenter.Controls.Add(this.grpBatch);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 447);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Make Batch";
            // 
            // grpBatch
            // 
            this.grpBatch.Controls.Add(this.btnInquiryLotList);
            this.grpBatch.Controls.Add(this.cdvOper);
            this.grpBatch.Controls.Add(this.lblOper);
            this.grpBatch.Controls.Add(this.cdvFlow);
            this.grpBatch.Controls.Add(this.lblFlow);
            this.grpBatch.Controls.Add(this.cdvMaterial);
            this.grpBatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
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
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
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
            this.cdvMaterial.Location = new System.Drawing.Point(12, 13);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(223, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 80;
            this.cdvMaterial.WidthMaterialAndVersion = 143;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_MaterialSelectedItemChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_VersionSelectedItemChanged);
            // 
            // grpLotList
            // 
            this.grpLotList.Controls.Add(this.lisLotList);
            this.grpLotList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotList.Location = new System.Drawing.Point(3, 40);
            this.grpLotList.Name = "grpLotList";
            this.grpLotList.Size = new System.Drawing.Size(736, 160);
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
            this.colReserveBatchID,
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
            this.lisLotList.Size = new System.Drawing.Size(730, 141);
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
            // colReserveBatchID
            // 
            this.colReserveBatchID.Text = "Reserve Batch ID";
            this.colReserveBatchID.Width = 100;
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
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(649, 67);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMake
            // 
            this.btnMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMake.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMake.Location = new System.Drawing.Point(558, 67);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(88, 26);
            this.btnMake.TabIndex = 4;
            this.btnMake.Text = "Make Batch";
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // btnInquiryBatch
            // 
            this.btnInquiryBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInquiryBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInquiryBatch.Location = new System.Drawing.Point(467, 67);
            this.btnInquiryBatch.Name = "btnInquiryBatch";
            this.btnInquiryBatch.Size = new System.Drawing.Size(88, 26);
            this.btnInquiryBatch.TabIndex = 3;
            this.btnInquiryBatch.Text = "Inquiry Batch";
            this.btnInquiryBatch.Click += new System.EventHandler(this.btnInquiryBatch_Click);
            // 
            // grpRes
            // 
            this.grpRes.Controls.Add(this.btnNPWAdd);
            this.grpRes.Controls.Add(this.txtNPWID);
            this.grpRes.Controls.Add(this.lblNPW);
            this.grpRes.Controls.Add(this.btnApplyBatch);
            this.grpRes.Controls.Add(this.cdvReserveBatchID);
            this.grpRes.Controls.Add(this.lblReserveBatchID);
            this.grpRes.Controls.Add(this.txtLotBatchID);
            this.grpRes.Controls.Add(this.lblLotBatchID);
            this.grpRes.Controls.Add(this.btnDel);
            this.grpRes.Controls.Add(this.btnAdd);
            this.grpRes.Controls.Add(this.cdvResID);
            this.grpRes.Controls.Add(this.lblResID);
            this.grpRes.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRes.Location = new System.Drawing.Point(3, 203);
            this.grpRes.Name = "grpRes";
            this.grpRes.Size = new System.Drawing.Size(736, 66);
            this.grpRes.TabIndex = 2;
            this.grpRes.TabStop = false;
            // 
            // btnNPWAdd
            // 
            this.btnNPWAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnNPWAdd.Image")));
            this.btnNPWAdd.Location = new System.Drawing.Point(702, 39);
            this.btnNPWAdd.Name = "btnNPWAdd";
            this.btnNPWAdd.Size = new System.Drawing.Size(21, 21);
            this.btnNPWAdd.TabIndex = 11;
            this.btnNPWAdd.Click += new System.EventHandler(this.btnNPWAdd_Click);
            // 
            // txtNPWID
            // 
            this.txtNPWID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtNPWID.Location = new System.Drawing.Point(565, 39);
            this.txtNPWID.MaxLength = 25;
            this.txtNPWID.Name = "txtNPWID";
            this.txtNPWID.Size = new System.Drawing.Size(136, 20);
            this.txtNPWID.TabIndex = 10;
            this.txtNPWID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNPWID_KeyPress);
            // 
            // lblNPW
            // 
            this.lblNPW.AutoSize = true;
            this.lblNPW.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPW.Location = new System.Drawing.Point(468, 43);
            this.lblNPW.Name = "lblNPW";
            this.lblNPW.Size = new System.Drawing.Size(47, 13);
            this.lblNPW.TabIndex = 9;
            this.lblNPW.Text = "NPW ID";
            this.lblNPW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnApplyBatch
            // 
            this.btnApplyBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApplyBatch.Location = new System.Drawing.Point(312, 37);
            this.btnApplyBatch.Name = "btnApplyBatch";
            this.btnApplyBatch.Size = new System.Drawing.Size(136, 24);
            this.btnApplyBatch.TabIndex = 6;
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
            this.cdvReserveBatchID.Location = new System.Drawing.Point(565, 13);
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
            this.cdvReserveBatchID.TabIndex = 8;
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
            this.lblReserveBatchID.Location = new System.Drawing.Point(468, 16);
            this.lblReserveBatchID.Name = "lblReserveBatchID";
            this.lblReserveBatchID.Size = new System.Drawing.Size(92, 13);
            this.lblReserveBatchID.TabIndex = 7;
            this.lblReserveBatchID.Text = "Reserve Batch ID";
            this.lblReserveBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotBatchID
            // 
            this.txtLotBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotBatchID.Location = new System.Drawing.Point(312, 13);
            this.txtLotBatchID.MaxLength = 30;
            this.txtLotBatchID.Name = "txtLotBatchID";
            this.txtLotBatchID.ReadOnly = true;
            this.txtLotBatchID.Size = new System.Drawing.Size(136, 20);
            this.txtLotBatchID.TabIndex = 3;
            // 
            // lblLotBatchID
            // 
            this.lblLotBatchID.AutoSize = true;
            this.lblLotBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotBatchID.Location = new System.Drawing.Point(253, 16);
            this.lblLotBatchID.Name = "lblLotBatchID";
            this.lblLotBatchID.Size = new System.Drawing.Size(49, 13);
            this.lblLotBatchID.TabIndex = 2;
            this.lblLotBatchID.Text = "Batch ID";
            this.lblLotBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(278, 37);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 5;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(251, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.cdvResID.Location = new System.Drawing.Point(91, 13);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(144, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 144;
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
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(9, 16);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBatchID
            // 
            this.txtBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBatchID.Location = new System.Drawing.Point(103, 11);
            this.txtBatchID.MaxLength = 30;
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.Size = new System.Drawing.Size(183, 20);
            this.txtBatchID.TabIndex = 1;
            this.txtBatchID.TextChanged += new System.EventHandler(this.txtBatchID_TextChanged);
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchID.Location = new System.Drawing.Point(9, 13);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(57, 13);
            this.lblBatchID.TabIndex = 0;
            this.lblBatchID.Text = "Batch ID";
            this.lblBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sptTop
            // 
            this.sptTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.sptTop.Location = new System.Drawing.Point(3, 200);
            this.sptTop.Name = "sptTop";
            this.sptTop.Size = new System.Drawing.Size(736, 3);
            this.sptTop.TabIndex = 0;
            this.sptTop.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(3, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chkReserveBatch
            // 
            this.chkReserveBatch.AutoSize = true;
            this.chkReserveBatch.Enabled = false;
            this.chkReserveBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkReserveBatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkReserveBatch.Location = new System.Drawing.Point(386, 12);
            this.chkReserveBatch.Name = "chkReserveBatch";
            this.chkReserveBatch.Size = new System.Drawing.Size(102, 18);
            this.chkReserveBatch.TabIndex = 3;
            this.chkReserveBatch.Text = "Reserve batch";
            // 
            // txtBatchComment
            // 
            this.txtBatchComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchComment.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBatchComment.Location = new System.Drawing.Point(103, 35);
            this.txtBatchComment.MaxLength = 200;
            this.txtBatchComment.Name = "txtBatchComment";
            this.txtBatchComment.Size = new System.Drawing.Size(628, 20);
            this.txtBatchComment.TabIndex = 7;
            // 
            // btnConfirm
            // 
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConfirm.Location = new System.Drawing.Point(3, 67);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(88, 26);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // chkConfirm
            // 
            this.chkConfirm.AutoSize = true;
            this.chkConfirm.Enabled = false;
            this.chkConfirm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkConfirm.Location = new System.Drawing.Point(653, 12);
            this.chkConfirm.Name = "chkConfirm";
            this.chkConfirm.Size = new System.Drawing.Size(67, 18);
            this.chkConfirm.TabIndex = 5;
            this.chkConfirm.Text = "Confirm";
            this.chkConfirm.UseVisualStyleBackColor = true;
            // 
            // btnSeq
            // 
            this.btnSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSeq.Location = new System.Drawing.Point(94, 67);
            this.btnSeq.Name = "btnSeq";
            this.btnSeq.Size = new System.Drawing.Size(88, 26);
            this.btnSeq.TabIndex = 2;
            this.btnSeq.Text = "Change Seq.";
            this.btnSeq.Visible = false;
            this.btnSeq.Click += new System.EventHandler(this.btnSeq_Click);
            // 
            // lblBatchComment
            // 
            this.lblBatchComment.AutoSize = true;
            this.lblBatchComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchComment.Location = new System.Drawing.Point(9, 37);
            this.lblBatchComment.Name = "lblBatchComment";
            this.lblBatchComment.Size = new System.Drawing.Size(82, 13);
            this.lblBatchComment.TabIndex = 6;
            this.lblBatchComment.Text = "Batch Comment";
            this.lblBatchComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpLowerBatch
            // 
            this.grpLowerBatch.Controls.Add(this.chkManual);
            this.grpLowerBatch.Controls.Add(this.chkOverriable);
            this.grpLowerBatch.Controls.Add(this.lblBatchComment);
            this.grpLowerBatch.Controls.Add(this.lblBatchID);
            this.grpLowerBatch.Controls.Add(this.txtBatchID);
            this.grpLowerBatch.Controls.Add(this.chkConfirm);
            this.grpLowerBatch.Controls.Add(this.chkReserveBatch);
            this.grpLowerBatch.Controls.Add(this.txtBatchComment);
            this.grpLowerBatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLowerBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLowerBatch.Location = new System.Drawing.Point(3, 0);
            this.grpLowerBatch.Name = "grpLowerBatch";
            this.grpLowerBatch.Size = new System.Drawing.Size(736, 61);
            this.grpLowerBatch.TabIndex = 0;
            this.grpLowerBatch.TabStop = false;
            // 
            // chkManual
            // 
            this.chkManual.AutoSize = true;
            this.chkManual.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkManual.Location = new System.Drawing.Point(292, 12);
            this.chkManual.Name = "chkManual";
            this.chkManual.Size = new System.Drawing.Size(67, 18);
            this.chkManual.TabIndex = 2;
            this.chkManual.Text = "Manual";
            this.chkManual.UseVisualStyleBackColor = true;
            // 
            // chkOverriable
            // 
            this.chkOverriable.AutoSize = true;
            this.chkOverriable.Enabled = false;
            this.chkOverriable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOverriable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkOverriable.Location = new System.Drawing.Point(501, 12);
            this.chkOverriable.Name = "chkOverriable";
            this.chkOverriable.Size = new System.Drawing.Size(139, 18);
            this.chkOverriable.TabIndex = 4;
            this.chkOverriable.Text = "Allow override batch id";
            // 
            // grpBatchLotList
            // 
            this.grpBatchLotList.Controls.Add(this.lisAddLot);
            this.grpBatchLotList.Controls.Add(this.pnlUpDown);
            this.grpBatchLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBatchLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBatchLotList.Location = new System.Drawing.Point(3, 269);
            this.grpBatchLotList.Name = "grpBatchLotList";
            this.grpBatchLotList.Size = new System.Drawing.Size(736, 178);
            this.grpBatchLotList.TabIndex = 3;
            this.grpBatchLotList.TabStop = false;
            this.grpBatchLotList.Text = "Batch Lot List";
            // 
            // lisAddLot
            // 
            this.lisAddLot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader62,
            this.columnHeader1,
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
            this.lisAddLot.Location = new System.Drawing.Point(3, 16);
            this.lisAddLot.Name = "lisAddLot";
            this.lisAddLot.Size = new System.Drawing.Size(696, 159);
            this.lisAddLot.TabIndex = 0;
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
            this.columnHeader62.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Reserve Batch ID";
            this.columnHeader1.Width = 100;
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
            // pnlUpDown
            // 
            this.pnlUpDown.Controls.Add(this.btnUp);
            this.pnlUpDown.Controls.Add(this.btnDown);
            this.pnlUpDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUpDown.Location = new System.Drawing.Point(699, 16);
            this.pnlUpDown.Name = "pnlUpDown";
            this.pnlUpDown.Size = new System.Drawing.Size(34, 159);
            this.pnlUpDown.TabIndex = 1;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(5, 57);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 0;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(5, 84);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 1;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // frmWIPTranMakeBatch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranMakeBatch";
            this.Text = "Make Batch";
            this.Activated += new System.EventHandler(this.frmWIPTranMakeBatch_Activated);
            this.pnlBottom.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.grpLowerBatch.ResumeLayout(false);
            this.grpLowerBatch.PerformLayout();
            this.grpBatchLotList.ResumeLayout(false);
            this.pnlUpDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private const int COL_LOT_ID = 1;
        private const int COL_MAT_ID = 4;
        private const int COL_MAT_VER = 5;
        private const int COL_FLOW = 6;
        private const int COL_FLOW_SEQ = 7;
        private const int COL_OPER = 8;
        private string s_crt_rule = "";
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case "1":

                        MPCF.FieldClear(this);
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
        private bool CheckCondition(string FuncName)
        {

            int i;
            switch (MPCF.Trim(FuncName))
            {
                case "MAKE_BATCH":
                    
                    
                    if (lisAddLot.Items.Count == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(199));
                        return false;
                    }

                    if (MPCF.CheckValue(cdvResID, 1) == false)
                    {
                        cdvResID.Focus();
                        return false;
                    }
                    break;

                case "VIEW":

                    if (MPCF.CheckValue(txtBatchID, 1) == false)
                    {
                        txtBatchID.Focus();
                        return false;
                    }
                    break;

                case "ATTACH_LOT":

                    for (i = 0; i < lisLotList.SelectedItems.Count; i++)
                    {
                        if (MPCF.Trim(lisLotList.SelectedItems[i].SubItems[2].Text) != "")  // Batch ID
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(285));
                            return false;
                        }
                        if (MPCF.Trim(lisLotList.SelectedItems[i].SubItems[19].Text) == "Y") //Hold Flag
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(282));
                            return false;
                        }
                        if (MPCF.Trim(lisLotList.SelectedItems[i].SubItems[44].Text) == "Y") // Start Flag
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(283));
                            return false;
                        }
                        if (MPCF.Trim(lisLotList.SelectedItems[i].SubItems[28].Text) == "Y") // Transit Flag
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(284));
                            return false;
                        }
                    }
                    break;

                case "CANCEL":

                    if (MPCF.CheckValue(txtBatchID, 1) == false)
                    {
                        txtBatchID.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(txtBatchComment, 1) == false)
                    {
                        txtBatchComment.Focus();
                        return false;
                    }

                    if (MPCF.ShowMsgBox(MPCF.GetMessage(297), MessageBoxButtons.YesNo, 1) == DialogResult.No)
                    {
                        return false;
                    }

                    break;

                case "CONFIRM":

                    if (MPCF.CheckValue(txtBatchID, 1) == false)
                    {
                        txtBatchID.Focus();
                        return false;
                    }

                    break;
            }
            
            return true;
            
        }

          
        //
        // GetLotID()
        //       - Get Operation Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetLotID(int iRow)
        {
            
            string sLotID = "";
            
            if (lisLotList.Items.Count < 1)
            {
                return sLotID;
            }
            
            try
            {
                sLotID = lisAddLot.Items[iRow].SubItems[COL_LOT_ID].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sLotID;
            
        }

        private string GetMatID()
        {

            string s_temp = "";
            int i;

            if (lisAddLot.Items.Count < 1)
            {
                return s_temp;
            }

            try
            {
                s_temp = lisAddLot.Items[0].SubItems[COL_MAT_ID].Text;
                for (i = 0; i < lisAddLot.Items.Count; i++)
                {
                    if (MPCF.Trim(s_temp) != MPCF.Trim(lisAddLot.Items[i].SubItems[COL_MAT_ID].Text))
                    {
                        return "";
                    }
                }
 
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return s_temp;

        }

        private int GetMatVer()
        {

            string s_temp = "";
            int i;

            if (lisAddLot.Items.Count < 1)
            {
                return 0;
            }

            try
            {
                s_temp = lisAddLot.Items[0].SubItems[COL_MAT_VER].Text;
                for (i = 0; i < lisAddLot.Items.Count; i++)
                {
                    if (MPCF.Trim(s_temp) != MPCF.Trim(lisAddLot.Items[i].SubItems[COL_MAT_VER].Text))
                    {
                        return 0;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return MPCF.ToInt(s_temp);

        }

        private string GetFlow()
        {

            string s_temp = "";
            int i;

            if (lisAddLot.Items.Count < 1)
            {
                return s_temp;
            }

            try
            {
                s_temp = lisAddLot.Items[0].SubItems[COL_FLOW].Text;
                for (i = 0; i < lisAddLot.Items.Count; i++)
                {
                    if (MPCF.Trim(s_temp) != MPCF.Trim(lisAddLot.Items[i].SubItems[COL_FLOW].Text))
                    {
                        return "";
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return s_temp;

        }

        private string GetOper()
        {

            string s_temp = "";
            int i;

            if (lisAddLot.Items.Count < 1)
            {
                return s_temp;
            }

            try
            {
                s_temp = lisAddLot.Items[0].SubItems[COL_OPER].Text;
                for (i = 0; i < lisAddLot.Items.Count; i++)
                {
                    if (MPCF.Trim(s_temp) != MPCF.Trim(lisAddLot.Items[i].SubItems[COL_OPER].Text))
                    {
                        return "";
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return s_temp;

        }
        
        //
        // GetResourceIDList()
        //       - Get ResourceID List by Operation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetResourceIDList()
        {
            
            try
            {
                if (chkReserveBatch.Checked == true && MPCF.Trim(txtBatchID.Text) != "")
                {
                    ViewReserveBatch();
                }
                else
                { 
                    cdvResID.Init();
                    MPCF.InitListView(cdvResID.GetListView);
                    cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                    cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                    cdvResID.SelectedSubItemIndex = 0;
                    #if _RAS
                    if (RASLIST.ViewResourceList(cdvResID.GetListView, cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOper.Text, false) == false)
                    {
                        return false;
                    }
                    #endif
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        // ViewLotList()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewLotList()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
            int i;
            ListViewItem itmX;
            int j;
            string s_rsv_batch_list;
            List<TRSNode> rsv_batch_list;

            MPCF.InitListView(lisLotList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
            in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_List_By_Operation", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    itmX = new ListViewItem(MPCF.Trim(lisLotList.Items.Count + 1), (int)SMALLICON_INDEX.IDX_LOT);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("BATCH_ID"));
                    itmX.SubItems.Add(MPCF.Format("#######,##0", out_node.GetList(0)[i].GetInt("BATCH_SEQ")));

                    s_rsv_batch_list = "";
                    rsv_batch_list = out_node.GetList(0)[i].GetList("RESERVE_BATCH_LIST");
                    for (j = 0; j < rsv_batch_list.Count; j++)
                    {
                        s_rsv_batch_list += rsv_batch_list[j].GetString("RSV_BATCH_ID");
                        if (j < rsv_batch_list.Count - 1)
                        {
                            s_rsv_batch_list += ", ";
                        }
                    }
                    itmX.SubItems.Add(s_rsv_batch_list);

                    if (j == 1 && out_node.GetList(0)[i].GetInt("BATCH_SEQ") < 1)
                    {
                        itmX.SubItems[3].Text = MPCF.Format("#######,##0", rsv_batch_list[0].GetInt("RSV_BATCH_SEQ"));
                    }

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER"));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("REMAIN_QTIME").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_TYPE").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OWNER_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CREATE_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_PRIORITY").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_STATUS"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("HOLD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("HOLD_CODE"));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3")));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_3")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("INV_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("TRANSIT_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("UNIT_EXIST_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("INV_UNIT"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RWK_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_CODE"));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("RWK_COUNT")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_RET_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_RET_OPER"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_END_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_END_OPER"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RWK_RET_CLEAR_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RWK_TIME")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("NSTD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("NSTD_RET_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("NSTD_RET_OPER"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("NSTD_TIME")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("START_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("START_RES_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("END_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("END_RES_ID"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SAMPLE_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SAMPLE_WAIT_FLAG").ToString());

                    switch (out_node.GetList(0)[i].GetChar("SAMPLE_RESULT"))
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
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FROM_TO_LOT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SHIP_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SHIP_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FAC_IN_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FLOW_IN_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("OPER_IN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESERVE_RES_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ORDER_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_1"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_2"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_3"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_LOCATION"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_1"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_2"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_3"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_4"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_5"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_6"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_7"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_8"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_9"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_10"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_11"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_12"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_13"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_14"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_15"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_16"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_17"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_18"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_19"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_20"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("BOM_SET_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("BOM_SET_VERSION").ToString());
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_ACTIVE_HIST_SEQ")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_HIST_SEQ")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOT_DEL_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_DEL_CODE"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_TRAN_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_COMMENT"));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ")));

                    if (out_node.GetList(0)[i].GetChar("HOLD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                    }
                    else if (out_node.GetList(0)[i].GetChar("START_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_START;
                    }
                    else if (out_node.GetList(0)[i].GetChar("RWK_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                    }
                    else if (out_node.GetList(0)[i].GetChar("NSTD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                    }
                    else if (out_node.GetList(0)[i].GetString("LAST_TRAN_CODE") == MPGC.MP_TRAN_CODE_RELEASE)
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                    }
                    else if (out_node.GetList(0)[i].GetChar("REP_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                    }
                    else
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                    }
                    itmX.Tag = "L"; // Lot batch item type


                    if (out_node.GetList(0)[i].GetString("BATCH_ID") != "")
                    {
                        itmX.BackColor = Color.Thistle;
                    }
                    else if (out_node.GetList(0)[i].GetList("RESERVE_BATCH_LIST").Count > 0)
                    {
                        itmX.BackColor = Color.LightYellow;
                    }
                    
                    lisLotList.Items.Add(itmX);
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            MPCF.FitColumnHeader(lisLotList);
            return true;
        }
        
        private bool ViewAddLotInfo(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
            ListViewItem itmX;
            string sBatchId = "";
            string sReservedBatchId = "";

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("SUBLOT_ID", s_lot_id);

            if (MPCR.CallService("WIP", "WIP_View_Sublot", in_node, ref out_node) == false)
            {
                return false;
            }

            foreach (ListViewItem lvItem in lisAddLot.Items)
            {
                if (lvItem.SubItems[2].Text != "" && sBatchId == "")
                    sBatchId = lvItem.SubItems[2].Text;
                else if (lvItem.SubItems[3].Text != "" && sReservedBatchId == "")
                    sReservedBatchId = lvItem.SubItems[3].Text;
            }

            itmX = new ListViewItem(((int)(lisAddLot.Items.Count + 1)).ToString(), (int)SMALLICON_INDEX.IDX_SUB_LOT);
            itmX.SubItems.Add(s_lot_id);
            itmX.SubItems.Add(sBatchId); // batch id
            itmX.SubItems.Add(sReservedBatchId); // reserve batch id
            itmX.SubItems.Add(out_node.GetString("MAT_ID"));
            itmX.SubItems.Add(out_node.GetInt("MAT_VER").ToString());
            itmX.SubItems.Add(out_node.GetString("FLOW"));
            itmX.SubItems.Add(out_node.GetInt("FLOW_SEQ_NUM").ToString());
            itmX.SubItems.Add(out_node.GetString("OPER"));

            itmX.SubItems.Add("0.000");
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("QTY_2")));
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("QTY_3")));

            itmX.SubItems.Add("");

            itmX.SubItems.Add(MPCF.Trim(out_node.GetChar("SUBLOT_TYPE")));
            itmX.SubItems.Add(out_node.GetString("OWNER_CODE"));
            itmX.SubItems.Add(out_node.GetString("CREATE_CODE"));
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add(out_node.GetChar("HOLD_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("HOLD_CODE"));

            itmX.SubItems.Add("0.000");
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("CREATE_QTY_2")));
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("CREATE_QTY_3")));

            itmX.SubItems.Add("0.000");
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("OPER_IN_QTY_2")));
            itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetDouble("OPER_IN_QTY_3")));

            itmX.SubItems.Add(out_node.GetChar("INV_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetChar("TRANSIT_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetChar("UNIT_EXIST_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("INV_UNIT"));

            itmX.SubItems.Add(out_node.GetChar("RWK_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("RWK_CODE"));
            itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetInt("RWK_COUNT")));
            itmX.SubItems.Add(out_node.GetString("RWK_RET_FLOW"));
            itmX.SubItems.Add(out_node.GetString("RWK_RET_OPER"));
            itmX.SubItems.Add(out_node.GetString("RWK_END_FLOW"));
            itmX.SubItems.Add(out_node.GetString("RWK_END_OPER"));
            itmX.SubItems.Add(out_node.GetChar("RWK_RET_CLEAR_FLAG").ToString());
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("RWK_TIME")));

            itmX.SubItems.Add(out_node.GetChar("NSTD_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("NSTD_RET_FLOW"));
            itmX.SubItems.Add(out_node.GetString("NSTD_RET_OPER"));
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("NSTD_TIME")));

            itmX.SubItems.Add(out_node.GetChar("START_FLAG").ToString());
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("START_TIME")));
            itmX.SubItems.Add(out_node.GetString("START_RES_ID"));
            itmX.SubItems.Add(out_node.GetChar("END_FLAG").ToString());
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("END_TIME")));
            itmX.SubItems.Add(out_node.GetString("END_RES_ID"));

            itmX.SubItems.Add(out_node.GetChar("SAMPLE_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetChar("SAMPLE_WAIT_FLAG").ToString());

            switch (out_node.GetChar("SAMPLE_RESULT"))
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
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add(out_node.GetString("RESERVE_RES_ID"));
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_1"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_2"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_3"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_4"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_5"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_6"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_7"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_8"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_9"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_10"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_11"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_12"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_13"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_14"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_15"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_16"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_17"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_18"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_19"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_CMF_20"));
            itmX.SubItems.Add("");
            itmX.SubItems.Add("0");
            itmX.SubItems.Add("0");
            itmX.SubItems.Add("0");

            itmX.SubItems.Add(out_node.GetChar("SUBLOT_DEL_FLAG").ToString());
            itmX.SubItems.Add(out_node.GetString("SUBLOT_DEL_TIME"));
            itmX.SubItems.Add(out_node.GetString("SUBLOT_DEL_CODE"));

            itmX.SubItems.Add(out_node.GetString("LAST_TRAN_CODE"));
            itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME")));
            itmX.SubItems.Add(out_node.GetString("LAST_COMMENT"));
            itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetInt("LAST_ACTIVE_HIST_SEQ")));
            itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetInt("LAST_HIST_SEQ")));

            itmX.Tag = "N";
            itmX.Selected = true;
            lisAddLot.Items.Add(itmX);

            return true;
        }

        private bool ViewBatchRelation()
        {

            TRSNode in_node = new TRSNode("VIEW_BATCH_RELATION_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_RELATION_OUT");

            chkOverriable.Checked = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
            
            if (MPCR.CallService("WIP", "WIP_View_Batch_Relation", in_node, ref out_node) == false)
            {
                return false;
            }

            chkManual.Checked = false;

            if (out_node.GetChar("OVERRIDE_FLAG") == 'Y')
            {
                chkOverriable.Checked = true;
                chkManual.Enabled = true;
            }
            else
            {
                chkOverriable.Checked = false;
                chkManual.Enabled = false;
            }

            return true;

        }

        private bool ViewReserveBatch()
        {

            TRSNode in_node = new TRSNode("VIEW_RESERVE_BATCH_IN");
            TRSNode out_node = new TRSNode("VIEW_RESERVE_BATCH_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RSV_BATCH_ID", txtBatchID.Text);

            if (MPCR.CallService("WIP", "WIP_View_Reserve_Batch", in_node, ref out_node) == false)
            {
                return false;
            }

            if (MPCF.Trim(out_node.GetString("RES_ID")) != "")
            {
                cdvResID.Text = MPCF.Trim(out_node.GetString("RES_ID"));
            }
            else
            {
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;

                if (RASLIST.ViewResourceList(cdvResID.GetListView, out_node.GetString("RESG_ID"), out_node.GetString("RES_TYPE"), false) == false)
                {
                    return false;
                }
            }
            s_crt_rule = out_node.GetString("CRT_RULE_ID");
            return true;

        }

        private bool ViewReserveBatchIdList(string s_res_id, string s_lot_id)
        {

            TRSNode in_node = new TRSNode("VIEW_RESERVE_BATCH_ID_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RESERVE_BATCH_ID_LIST_OUT");
            ListViewItem itm;
            int i;

            cdvReserveBatchID.Text = "";

            cdvReserveBatchID.Init();
            MPCF.InitListView(cdvReserveBatchID.GetListView);
            cdvReserveBatchID.Columns.Add("Reserve Batch ID", 50, HorizontalAlignment.Left);
            cdvReserveBatchID.SelectedSubItemIndex = 0;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RES_ID", s_res_id);
            in_node.AddString("ITEM_ID", s_lot_id);
            in_node.AddChar("ITEM_TYPE", 'L');

            if (MPCR.CallService("WIP", "WIP_View_Reserve_Batch_Id_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList("RSV_BATCH_ID_LIST").Count; i++)
            {
                itm = new ListViewItem(out_node.GetList("RSV_BATCH_ID_LIST")[i].GetString("RSV_BATCH_ID"));
                cdvReserveBatchID.Items.Add(itm);
            }

            if (cdvReserveBatchID.Items.Count > 1)
            {
                cdvReserveBatchID.VisibleButton = true;
                cdvReserveBatchID.BackColor = SystemColors.Window;
            }
            else if (cdvReserveBatchID.Items.Count > 0)
            {
                cdvReserveBatchID.VisibleButton = false;
                cdvReserveBatchID.Text = cdvReserveBatchID.Items[0].Text;
                cdvReserveBatchID.BackColor = SystemColors.Control;
            }
            else
            {
                cdvReserveBatchID.VisibleButton = false;
                cdvReserveBatchID.BackColor = SystemColors.Control;
            }

            return true;

        }

        // ViewBatchLotList()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewBatchLotList(string s_batch_id)
        {

            int i;
            ListViewItem itmX;

            int j;
            string s_rsv_batch_list;
            List<TRSNode> rsv_batch_list;

            TRSNode in_node = new TRSNode("VIEW_BATCH_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_LOT_LIST_OUT");

            try
            {
                MPCF.InitListView(lisAddLot);
                chkReserveBatch.Checked = false;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BATCH_ID", MPCF.Trim(s_batch_id));

                if (MPCR.CallService("WIP", "WIP_View_Batch_Item_List", in_node, ref out_node, true) == false)
                {
                    in_node.Init();

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("RSV_BATCH_ID", MPCF.Trim(s_batch_id));

                    if (MPCR.CallService("WIP", "WIP_View_Reserve_Batch_Item_List", in_node, ref out_node, false) == false)
                    {
                        return false;
                    }

                    if (out_node.GetList(0).Count > 0)
                    {
                        chkReserveBatch.Checked = true;

                        ViewReserveBatch();

                        if (cdvResID.Text != "")
                        {
                            ViewBatchRelation();
                        }
                    }
                }

                if (out_node.GetList(0).Count < 1)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("SEQ_NUM").ToString());

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ITEM_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("BATCH_ID"));

                    s_rsv_batch_list = "";
                    rsv_batch_list = out_node.GetList(0)[i].GetList("RESERVE_BATCH_LIST");
                    for (j = 0; j < rsv_batch_list.Count; j++)
                    {
                        s_rsv_batch_list += rsv_batch_list[j].GetString("RSV_BATCH_ID");
                        if (j < rsv_batch_list.Count - 1)
                        {
                            s_rsv_batch_list += ", ";
                        }
                    }
                    itmX.SubItems.Add(s_rsv_batch_list);

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OPER"));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("REMAIN_QTIME").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_TYPE").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("OWNER_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CREATE_CODE"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_PRIORITY").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_STATUS"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("HOLD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("HOLD_CODE"));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3")));

                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_1")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_2")));
                    itmX.SubItems.Add(MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_3")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("INV_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("TRANSIT_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("UNIT_EXIST_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("INV_UNIT"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RWK_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_CODE"));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("RWK_COUNT")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_RET_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_RET_OPER"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_END_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_END_OPER"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RWK_RET_CLEAR_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RWK_TIME")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("NSTD_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("NSTD_RET_FLOW"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("NSTD_RET_OPER"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("NSTD_TIME")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("START_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("START_RES_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("END_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("END_RES_ID"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SAMPLE_FLAG").ToString());
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("SAMPLE_WAIT_FLAG").ToString());

                    switch (out_node.GetList(0)[i].GetChar("SAMPLE_RESULT"))
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
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FROM_TO_LOT_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SHIP_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SHIP_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FAC_IN_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FLOW_IN_TIME")));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("OPER_IN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESERVE_RES_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ORDER_ID"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_1"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_2"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ADD_ORDER_ID_3"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_LOCATION"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_1"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_2"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_3"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_4"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_5"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_6"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_7"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_8"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_9"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_10"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_11"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_12"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_13"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_14"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_15"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_16"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_17"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_18"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_19"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_20"));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("BOM_SET_ID"));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetInt("BOM_SET_VERSION")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_ACTIVE_HIST_SEQ")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_HIST_SEQ")));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG").ToString());
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOT_DEL_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_DEL_CODE"));

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_TRAN_CODE"));
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME")));
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("LAST_COMMENT"));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ")));
                    itmX.SubItems.Add(MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ")));

                    itmX.Tag = out_node.GetList(0)[i].GetChar("ITEM_TYPE");
                    if (out_node.GetList(0)[i].GetChar("HOLD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                    }
                    else if (out_node.GetList(0)[i].GetChar("START_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_START;
                    }
                    else if (out_node.GetList(0)[i].GetChar("RWK_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                    }
                    else if (out_node.GetList(0)[i].GetChar("NSTD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                    }
                    else if (out_node.GetList(0)[i].GetString("LAST_TRAN_CODE") == MPGC.MP_TRAN_CODE_RELEASE)
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                    }
                    else if (out_node.GetList(0)[i].GetChar("REP_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                    }
                    else
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                    }

                    lisAddLot.Items.Add(itmX);

                    if(out_node.GetList(0)[i].GetChar("CONFIRM_FLAG")  == 'C')
                    {
                        chkConfirm.Checked = true;
                        btnConfirm.Visible = false;
                        btnCancel.Visible = true;
                        btnSeq.Visible = false;
                    }
                    else
                    {
                        chkConfirm.Checked = false;
                        btnConfirm.Visible = true;
                        btnCancel.Visible = false;
                        btnSeq.Visible = false;
                    }
                }

                MPCF.FitColumnHeader(lisAddLot);
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // Make Batch()
        //       - Make Batch
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool MakeBatch(char ProcStep)
        {

            int i = 0;

            TRSNode in_node = new TRSNode("MAKE_BATCH_IN");
            TRSNode out_node = new TRSNode("MAKE_BATCH_OUT");
            TRSNode list_item;

            try
            {
                MPCR.SetInMsg(in_node);

                /* 
                 * '1': Make New Batch and Confirm
                 * '2': Added Item to existed batch
                 * '3': Remove item from exist batch
                 * '4': Change sequence of item in batch
                 * '5' : Confirm the batch
                 * '6' : Cancel of confirmation) 
                 */

                in_node.ProcStep = ProcStep;
                in_node.AddString("MAT_ID", GetMatID());
                if (MPCF.Trim(GetMatID()) != "")
                {
                    in_node.AddInt("MAT_VER", GetMatVer());
                }
                in_node.AddString("FLOW", GetFlow());
                in_node.AddString("OPER", GetOper());
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddString("BATCH_COMMENT", txtBatchComment.Text);

                if (ProcStep != '2' && ProcStep != '3')
                {
                    for (i = 0; i < lisAddLot.Items.Count; i++)
                    {
                        list_item = in_node.AddNode("ITEM_LIST");

                        list_item.AddInt("SEQ_NUM", MPCF.ToInt(lisAddLot.Items[i].Text));
                        list_item.AddString("ITEM_ID", MPCF.Trim(lisAddLot.Items[i].SubItems[COL_LOT_ID].Text));
                        list_item.AddChar("ITEM_TYPE", MPCF.ToChar(lisAddLot.Items[i].Tag));
                    }
                }
                else if(ProcStep == '2')
                {
                    for (i = 0; i < lisLotList.SelectedItems.Count; i++)
                    {
                        list_item = in_node.AddNode("ITEM_LIST");

                        list_item.AddInt("SEQ_NUM", MPCF.ToInt(lisLotList.SelectedItems[i].Text));
                        list_item.AddString("ITEM_ID", MPCF.Trim(lisLotList.SelectedItems[i].SubItems[COL_LOT_ID].Text));
                        list_item.AddChar("ITEM_TYPE", MPCF.ToChar(lisLotList.SelectedItems[i].Tag));
                        
                    }
                }
                else
                {
                    for (i = 0; i < lisAddLot.SelectedItems.Count; i++)
                    {
                        list_item = in_node.AddNode("ITEM_LIST");

                        list_item.AddInt("SEQ_NUM", MPCF.ToInt(lisAddLot.SelectedItems[i].Text));
                        list_item.AddString("ITEM_ID", MPCF.Trim(lisAddLot.SelectedItems[i].SubItems[COL_LOT_ID].Text));
                        list_item.AddChar("ITEM_TYPE", MPCF.ToChar(lisAddLot.SelectedItems[i].Tag));
                        
                    }
                }

                if (ProcStep == '1')
                {
                    if (chkReserveBatch.Checked == true)
                    {
                        in_node.AddChar("RESERVE_FLAG", 'Y');
                    }
                }

                if ((ProcStep == '2' || ProcStep == '3' || ProcStep == '4') && chkReserveBatch.Checked == true)
                {
                    in_node.AddString("CRT_RULE_ID", s_crt_rule);
                    
                    if (MPCR.CallService("WIP", "WIP_Make_Reserve_Batch", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (MPCR.CallService("WIP", "WIP_Make_Batch", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }
                
                txtBatchID.Text = out_node.GetString("BATCH_ID");

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtBatchID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion

        private void frmWIPTranMakeBatch_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    MPCF.InitListView(lisLotList);
                    MPCF.InitListView(lisAddLot);

                    b_load_flag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInquiryBatch_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == true)
            {
                ViewBatchLotList(txtBatchID.Text);
            }
        }

        private void btnMake_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("MAKE_BATCH") == true)
                {
                    if (MakeBatch('1') == false)
                    {
                        return;
                    }

                    if (ViewBatchLotList(txtBatchID.Text) == false)
                    {
                        return;
                    }
                    if (ViewLotList() == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("CANCEL") == true)
            {
                if (MakeBatch('6') == false)
                {
                    return;
                }
                if (ViewBatchLotList(txtBatchID.Text) == false)
                {
                    return;
                }
            }
        }


        private void cdvMaterial_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.InitListView(lisLotList);
            cdvFlow.Text = "";
            cdvOper.Text = "";
        }

        private void cdvMaterial_VersionSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.InitListView(lisLotList);
            cdvFlow.Text = "";
            cdvOper.Text = "";
        }
        
        private void cdvFlow_ButtonPress(object sender, EventArgs e)
        {
            cdvFlow.Init();
            MPCF.InitListView(cdvFlow.GetListView);
            cdvFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            if (MPCF.Trim(cdvMaterial.Text) == "")
            {
                if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "") == false)
                {
                    return;
                }
            }
            else
            {
                if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '2', cdvMaterial.Text, cdvMaterial.Version, "", null, "") == false)
                {
                    return;
                }
            }

            cdvFlow.AddEmptyRow(1);

        }

        private void cdvFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.InitListView(lisLotList);
            cdvOper.Text = "";
        }

        private void cdvOper_ButtonPress(object sender, EventArgs e)
        {
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            if (cdvMaterial.Text != "" && cdvFlow.Text != "")
            {
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
            }
            else if (cdvMaterial.Text == "" && cdvFlow.Text != "")
            {
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '2', "", 0, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
            }
            else if (cdvMaterial.Text != "" && cdvFlow.Text == "")
            {
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, "", "", null, "") == false)
                {
                    return;
                }
            }
            else if (cdvMaterial.Text == "" && cdvFlow.Text == "")
            {
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '1', "", 0, "", "", null, "") == false)
                {
                    return;
                }
            }
            cdvOper.AddEmptyRow(1);
        }

        private void cdvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnInquiryLotList.PerformClick();
        }

        private void cdvOper_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnInquiryLotList.PerformClick();
            }

        }

        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (GetResourceIDList() == false)
            {
                return;
            }
        }

        private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvResID.Text) != "")
            {
                ViewBatchRelation();
                
                if (lisLotList.SelectedItems.Count > 0)
                {
                    ViewReserveBatchIdList(cdvResID.Text, lisLotList.SelectedItems[0].SubItems[1].Text);
                }
            }
            else
            {
                MPCF.InitListView(lisAddLot);
                txtBatchID.Text = "";
            }
        }

        private void btnInquiryLotList_Click(object sender, EventArgs e)
        {
            ViewLotList();
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i, j;
            ListViewItem itmx;
            try
            {
                if (lisLotList.SelectedItems.Count < 1) return;
                if (CheckCondition("ATTACH_LOT") == false) return;

                if (txtBatchID.Text != "")
                {
                    if (MakeBatch('2') == false)
                    {
                        return;
                    }
                }

                for (i = 0; i < lisLotList.SelectedItems.Count; i++)
                {
                    if (MPCF.FindListItem(lisAddLot, lisLotList.SelectedItems[i].SubItems[COL_LOT_ID].Text, COL_LOT_ID, false) == false)
                    {
                        itmx = new ListViewItem(MPCF.Trim(lisAddLot.Items.Count + 1), (int)SMALLICON_INDEX.IDX_LOT);

                        itmx.SubItems.Add(lisLotList.SelectedItems[i].SubItems[1].Text); // lot_id

                        if (chkReserveBatch.Checked == true)
                        {
                            itmx.SubItems.Add(lisLotList.SelectedItems[i].SubItems[2].Text); // batch id
                            itmx.SubItems.Add(txtBatchID.Text); // reserve batch id
                        }
                        else
                        {
                            itmx.SubItems.Add(txtBatchID.Text); // batch id
                            itmx.SubItems.Add(lisLotList.SelectedItems[i].SubItems[4].Text); // reserve batch id
                        }

                        for (j = 5; j < lisLotList.SelectedItems[i].SubItems.Count; j++)
                        {
                            itmx.SubItems.Add(lisLotList.SelectedItems[i].SubItems[j].Text);
                        }
                        itmx.Tag = "L";
                        lisAddLot.Items.Add(itmx);
                    }
                }

                if (ViewLotList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int i;

            if (lisAddLot.SelectedItems.Count < 1) return;

            if (txtBatchID.Text != "")
            {
                if (MakeBatch('3') == false)
                {
                    return;
                }
            }

            while (true)
            {
                if (lisAddLot.SelectedItems.Count < 1) break;
                lisAddLot.Items[lisAddLot.SelectedItems[0].Index].Remove();
            }

            for (i = 1; i <= lisAddLot.Items.Count; i++)
            {
                lisAddLot.Items[i - 1].Text = i.ToString();
            }

            if (ViewLotList() == false)
            {
                return;
            }
        }

        private void txtNPWID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnNPWAdd.PerformClick();
            }
        }

        private void btnNPWAdd_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(this.txtNPWID, 1) == true)
            {
                ViewAddLotInfo(txtNPWID.Text);
            }
            else
            {
                txtNPWID.Focus();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int i_idx, i;
            ListViewItem itmx;
            try
            {
                if (lisAddLot.SelectedItems.Count < 1) return;
                if (lisAddLot.SelectedItems[0].Index == 0) return;

                i_idx = lisAddLot.SelectedItems[0].Index;
                itmx = new ListViewItem(MPCF.Trim(i_idx - 1), lisAddLot.SelectedItems[0].ImageIndex);
                for (i = 1; i < lisAddLot.Items[i_idx].SubItems.Count; i++)
                {
                    itmx.SubItems.Add(lisAddLot.Items[i_idx].SubItems[i].Text);
                }
                itmx.Tag = lisAddLot.SelectedItems[0].Tag;
                lisAddLot.Items.Insert(i_idx - 1, itmx);
                lisAddLot.Items.RemoveAt(i_idx + 1);
                for (i = 1; i <= lisAddLot.Items.Count; i++)
                {
                    lisAddLot.Items[i - 1].Text = i.ToString();
                }
                lisAddLot.Items[i_idx - 1].Selected = true;
                if(btnConfirm.Visible == true)
                {
                    btnSeq.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int i_idx, i;
            ListViewItem itmx;
            if (lisAddLot.SelectedItems.Count < 1) return;
            if (lisAddLot.SelectedItems[0].Index == lisAddLot.Items.Count -1) return;
            i_idx = lisAddLot.SelectedItems[0].Index;
            itmx = new ListViewItem(MPCF.Trim(i_idx + 2), lisAddLot.SelectedItems[0].ImageIndex);
            for (i = 1; i < lisAddLot.Items[i_idx].SubItems.Count; i++)
            {
                itmx.SubItems.Add(lisAddLot.Items[i_idx].SubItems[i].Text);
            }
            itmx.Tag = lisAddLot.SelectedItems[0].Tag;
            lisAddLot.Items.RemoveAt(i_idx);
            lisAddLot.Items.Insert(i_idx + 1, itmx);

            for (i = 1; i <= lisAddLot.Items.Count; i++)
            {
                lisAddLot.Items[i - 1].Text = i.ToString();
            }
            lisAddLot.Items[i_idx + 1].Selected = true;
            if (btnConfirm.Visible == true)
            {
                btnSeq.Visible = true;
            }
        }

                      
        private void lisLotList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisLotList.SelectedItems.Count > 0)
            {
                txtLotBatchID.Text = lisLotList.SelectedItems[0].SubItems[2].Text;

                if (lisLotList.SelectedItems[0].SubItems[4].Text != "")
                {
                    cdvResID.Text = "";
                    ViewReserveBatchIdList(cdvResID.Text, lisLotList.SelectedItems[0].SubItems[1].Text);
                }
                else
                {
                    cdvReserveBatchID.Text = "";
                    cdvReserveBatchID.BackColor = SystemColors.Control;
                    cdvReserveBatchID.VisibleButton = false;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CheckCondition("CONFIRM") == true)
            {
                if (MakeBatch('5') == false)
                {
                    return;
                }
                if (ViewBatchLotList(txtBatchID.Text) == false)
                {
                    return;
                }
            }

        }

        private void btnSeq_Click(object sender, EventArgs e)
        {
            if(txtBatchID.Text != "")
            {
                if (MakeBatch('4') == false)
                {
                    return;
                }

                btnSeq.Visible = false;
            }
        }

        private void btnApplyBatch_Click(object sender, EventArgs e)
        {
            if (txtLotBatchID.Text == "")
            {
                txtBatchID.Text = cdvReserveBatchID.Text;
            }
            else
            {
                txtBatchID.Text = txtLotBatchID.Text;
            }

            btnInquiryBatch.PerformClick();
        }

        private void txtBatchID_TextChanged(object sender, EventArgs e)
        {
            if (chkManual.Checked == false)
            {
                MPCF.InitListView(lisAddLot);
            }
        }


    }
    
}
