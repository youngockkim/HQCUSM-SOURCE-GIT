
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranMultiEndLotByResource.vb
//   Description : Multi End Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - End_Lot() : Start Lot transaction
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
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;


namespace Miracom.WIPCore
{
    public class frmWIPTranMultiEndLotByResource : Miracom.MESCore.TranForm08
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranMultiEndLotByResource()
        {
            
            
            InitializeComponent();
            
            
            this.spdResInfo.Tag = "Change Cell";
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
        



        private System.Windows.Forms.Panel pnlResInfo;
        private System.Windows.Forms.GroupBox grpResInfo;
        private System.Windows.Forms.Panel pnlResInfoMain;
        protected FarPoint.Win.Spread.FpSpread spdResInfo;
        private System.Windows.Forms.Panel pnlResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        protected FarPoint.Win.Spread.SheetView spdResInfo_LotInfo;
        private System.Windows.Forms.Panel pnlLotList;
        private System.Windows.Forms.GroupBox grpLotList;
        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
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
        private Miracom.UI.Controls.MCListView.MCListView lisLotListTemp;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.ColumnHeader ColumnHeader16;
        private System.Windows.Forms.ColumnHeader ColumnHeader17;
        private System.Windows.Forms.ColumnHeader ColumnHeader18;
        private System.Windows.Forms.ColumnHeader ColumnHeader19;
        private System.Windows.Forms.ColumnHeader ColumnHeader20;
        private System.Windows.Forms.ColumnHeader ColumnHeader21;
        private System.Windows.Forms.ColumnHeader ColumnHeader22;
        private System.Windows.Forms.ColumnHeader ColumnHeader23;
        private System.Windows.Forms.ColumnHeader ColumnHeader24;
        private System.Windows.Forms.ColumnHeader ColumnHeader25;
        private System.Windows.Forms.ColumnHeader ColumnHeader26;
        private System.Windows.Forms.ColumnHeader ColumnHeader27;
        private System.Windows.Forms.ColumnHeader ColumnHeader28;
        private System.Windows.Forms.ColumnHeader ColumnHeader29;
        private System.Windows.Forms.ColumnHeader ColumnHeader30;
        private System.Windows.Forms.ColumnHeader ColumnHeader31;
        private System.Windows.Forms.ColumnHeader ColumnHeader32;
        private System.Windows.Forms.ColumnHeader ColumnHeader33;
        private System.Windows.Forms.ColumnHeader ColumnHeader34;
        private System.Windows.Forms.ColumnHeader ColumnHeader35;
        private System.Windows.Forms.ColumnHeader ColumnHeader36;
        private System.Windows.Forms.ColumnHeader ColumnHeader37;
        private System.Windows.Forms.ColumnHeader ColumnHeader38;
        private System.Windows.Forms.ColumnHeader ColumnHeader39;
        private System.Windows.Forms.ColumnHeader ColumnHeader40;
        private System.Windows.Forms.ColumnHeader ColumnHeader41;
        private System.Windows.Forms.ColumnHeader ColumnHeader42;
        private System.Windows.Forms.ColumnHeader ColumnHeader43;
        private System.Windows.Forms.ColumnHeader ColumnHeader44;
        private System.Windows.Forms.ColumnHeader ColumnHeader45;
        private System.Windows.Forms.ColumnHeader ColumnHeader46;
        private System.Windows.Forms.ColumnHeader ColumnHeader47;
        private System.Windows.Forms.ColumnHeader ColumnHeader48;
        private System.Windows.Forms.ColumnHeader ColumnHeader49;
        private System.Windows.Forms.ColumnHeader ColumnHeader50;
        private System.Windows.Forms.ColumnHeader ColumnHeader51;
        private System.Windows.Forms.ColumnHeader ColumnHeader52;
        private System.Windows.Forms.ColumnHeader ColumnHeader53;
        private System.Windows.Forms.ColumnHeader ColumnHeader54;
        private System.Windows.Forms.ColumnHeader ColumnHeader55;
        private System.Windows.Forms.ColumnHeader ColumnHeader56;
        private System.Windows.Forms.ColumnHeader ColumnHeader57;
        private System.Windows.Forms.ColumnHeader ColumnHeader58;
        private System.Windows.Forms.ColumnHeader ColumnHeader59;
        private System.Windows.Forms.ColumnHeader ColumnHeader60;
        private System.Windows.Forms.ColumnHeader ColumnHeader61;
        private System.Windows.Forms.ColumnHeader ColumnHeader62;
        private System.Windows.Forms.ColumnHeader ColumnHeader63;
        private System.Windows.Forms.ColumnHeader ColumnHeader64;
        private System.Windows.Forms.ColumnHeader ColumnHeader65;
        private System.Windows.Forms.ColumnHeader ColumnHeader66;
        private System.Windows.Forms.ColumnHeader ColumnHeader67;
        private System.Windows.Forms.ColumnHeader ColumnHeader68;
        private System.Windows.Forms.ColumnHeader ColumnHeader69;
        private System.Windows.Forms.ColumnHeader ColumnHeader70;
        private System.Windows.Forms.ColumnHeader ColumnHeader71;
        private System.Windows.Forms.ColumnHeader ColumnHeader72;
        private System.Windows.Forms.ColumnHeader ColumnHeader73;
        private System.Windows.Forms.ColumnHeader ColumnHeader74;
        private System.Windows.Forms.ColumnHeader ColumnHeader75;
        private System.Windows.Forms.ColumnHeader ColumnHeader76;
        private System.Windows.Forms.ColumnHeader ColumnHeader77;
        private System.Windows.Forms.ColumnHeader ColumnHeader78;
        private System.Windows.Forms.ColumnHeader ColumnHeader79;
        private System.Windows.Forms.ColumnHeader ColumnHeader80;
        private System.Windows.Forms.ColumnHeader ColumnHeader81;
        private System.Windows.Forms.ColumnHeader ColumnHeader82;
        private System.Windows.Forms.ColumnHeader ColumnHeader83;
        private System.Windows.Forms.ColumnHeader ColumnHeader84;
        private System.Windows.Forms.ColumnHeader ColumnHeader85;
        private System.Windows.Forms.ColumnHeader ColumnHeader86;
        private System.Windows.Forms.ColumnHeader ColumnHeader87;
        private System.Windows.Forms.ColumnHeader ColumnHeader88;
        private System.Windows.Forms.ColumnHeader ColumnHeader89;
        private System.Windows.Forms.ColumnHeader ColumnHeader90;
        private System.Windows.Forms.ColumnHeader ColumnHeader91;
        private System.Windows.Forms.ColumnHeader ColumnHeader92;
        private System.Windows.Forms.ColumnHeader ColumnHeader93;
        private System.Windows.Forms.ColumnHeader ColumnHeader94;
        private System.Windows.Forms.ColumnHeader ColumnHeader95;
        private ColumnHeader columnHeader97;
        private ColumnHeader columnHeader98;
        private ColumnHeader colMatVer;
        private ColumnHeader colFlowSeq;
        private CheckBox chkBindSameTr;
        private System.Windows.Forms.ColumnHeader ColumnHeader96;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder3, bevelBorder4);
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlResInfo = new System.Windows.Forms.Panel();
            this.grpResInfo = new System.Windows.Forms.GroupBox();
            this.pnlResInfoMain = new System.Windows.Forms.Panel();
            this.spdResInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdResInfo_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.pnlResID = new System.Windows.Forms.Panel();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranDateTime = new System.Windows.Forms.CheckBox();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlLotList = new System.Windows.Forms.Panel();
            this.grpLotList = new System.Windows.Forms.GroupBox();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.lisLotListTemp = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader57 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader58 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader59 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader60 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader61 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader63 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader64 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader65 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader66 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader67 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader68 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader69 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader70 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader71 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader72 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader73 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader74 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader75 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader76 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader77 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader78 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader79 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader80 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader81 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader82 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader83 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader84 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader85 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader86 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader87 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader88 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader89 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader90 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader91 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader92 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader93 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader94 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader95 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader96 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader97 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader98 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkBindSameTr = new System.Windows.Forms.CheckBox();
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
            this.pnlResInfo.SuspendLayout();
            this.grpResInfo.SuspendLayout();
            this.pnlResInfoMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).BeginInit();
            this.pnlResID.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlLotList.SuspendLayout();
            this.grpLotList.SuspendLayout();
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
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.pnlLotList);
            this.pnlTranInfo.Controls.Add(this.pnlResInfo);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 443);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(0, 443);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 484);
            // 
            // grpCMF
            // 
            this.grpCMF.Size = new System.Drawing.Size(722, 478);
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
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.chkBindSameTr);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkBindSameTr, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Multi End Lot";
            // 
            // pnlResInfo
            // 
            this.pnlResInfo.Controls.Add(this.grpResInfo);
            this.pnlResInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlResInfo.Name = "pnlResInfo";
            this.pnlResInfo.Size = new System.Drawing.Size(722, 153);
            this.pnlResInfo.TabIndex = 0;
            // 
            // grpResInfo
            // 
            this.grpResInfo.Controls.Add(this.pnlResInfoMain);
            this.grpResInfo.Controls.Add(this.pnlResID);
            this.grpResInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResInfo.Location = new System.Drawing.Point(0, 0);
            this.grpResInfo.Name = "grpResInfo";
            this.grpResInfo.Size = new System.Drawing.Size(722, 153);
            this.grpResInfo.TabIndex = 0;
            this.grpResInfo.TabStop = false;
            this.grpResInfo.Text = "Resource Information";
            // 
            // pnlResInfoMain
            // 
            this.pnlResInfoMain.Controls.Add(this.spdResInfo);
            this.pnlResInfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResInfoMain.Location = new System.Drawing.Point(3, 45);
            this.pnlResInfoMain.Name = "pnlResInfoMain";
            this.pnlResInfoMain.Size = new System.Drawing.Size(716, 105);
            this.pnlResInfoMain.TabIndex = 1;
            // 
            // spdResInfo
            // 
            this.spdResInfo.AccessibleDescription = "";
            this.spdResInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdResInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdResInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResInfo.HorizontalScrollBar.Name = "";
            this.spdResInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdResInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdResInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdResInfo.Location = new System.Drawing.Point(0, 0);
            this.spdResInfo.MoveActiveOnFocus = false;
            this.spdResInfo.Name = "spdResInfo";
            this.spdResInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdResInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdResInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResInfo_LotInfo});
            this.spdResInfo.Size = new System.Drawing.Size(716, 105);
            this.spdResInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResInfo.TabIndex = 0;
            this.spdResInfo.TabStop = false;
            this.spdResInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdResInfo.TextTipDelay = 200;
            this.spdResInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdResInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResInfo.VerticalScrollBar.Name = "";
            this.spdResInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdResInfo.VerticalScrollBar.TabIndex = 3;
            this.spdResInfo.Resize += new System.EventHandler(this.spdResInfo_Resize);
            // 
            // spdResInfo_LotInfo
            // 
            this.spdResInfo_LotInfo.Reset();
            spdResInfo_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdResInfo_LotInfo.ColumnCount = 4;
            spdResInfo_LotInfo.RowCount = 6;
            this.spdResInfo_LotInfo.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 0).ParseFormatString = "G";
            this.spdResInfo_LotInfo.Cells.Get(0, 0).Value = "Up/Down Flag";
            this.spdResInfo_LotInfo.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 2).ParseFormatString = "G";
            this.spdResInfo_LotInfo.Cells.Get(0, 2).Value = "Primary Status";
            this.spdResInfo_LotInfo.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdResInfo_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdResInfo_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResInfo_LotInfo.ColumnHeader.Visible = false;
            this.spdResInfo_LotInfo.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdResInfo_LotInfo.Columns.Get(0).Border = compoundBorder1;
            this.spdResInfo_LotInfo.Columns.Get(0).CellType = textCellType1;
            this.spdResInfo_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(0).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(0).Width = 150F;
            this.spdResInfo_LotInfo.Columns.Get(1).CellType = textCellType2;
            this.spdResInfo_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(1).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(1).Width = 197F;
            this.spdResInfo_LotInfo.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdResInfo_LotInfo.Columns.Get(2).Border = compoundBorder2;
            this.spdResInfo_LotInfo.Columns.Get(2).CellType = textCellType3;
            this.spdResInfo_LotInfo.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Width = 150F;
            this.spdResInfo_LotInfo.Columns.Get(3).CellType = textCellType4;
            this.spdResInfo_LotInfo.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(3).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(3).Width = 197F;
            this.spdResInfo_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdResInfo_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdResInfo_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResInfo_LotInfo.RowHeader.Visible = false;
            this.spdResInfo_LotInfo.Rows.Get(0).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(1).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(2).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(3).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(4).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(5).Height = 17F;
            this.spdResInfo_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlResID
            // 
            this.pnlResID.Controls.Add(this.pnlTranTime);
            this.pnlResID.Controls.Add(this.cdvResID);
            this.pnlResID.Controls.Add(this.lblResID);
            this.pnlResID.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResID.Location = new System.Drawing.Point(3, 16);
            this.pnlResID.Name = "pnlResID";
            this.pnlResID.Size = new System.Drawing.Size(716, 29);
            this.pnlResID.TabIndex = 0;
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranTime);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranDate);
            this.pnlTranTime.Location = new System.Drawing.Point(408, -1);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 23);
            this.pnlTranTime.TabIndex = 2;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.Location = new System.Drawing.Point(139, 1);
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
            this.dtpTranTime.Location = new System.Drawing.Point(225, 1);
            this.dtpTranTime.Name = "dtpTranTime";
            this.dtpTranTime.ShowUpDown = true;
            this.dtpTranTime.Size = new System.Drawing.Size(71, 20);
            this.dtpTranTime.TabIndex = 2;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 2);
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
            this.dtpTranDate.Location = new System.Drawing.Point(139, 1);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(86, 20);
            this.dtpTranDate.TabIndex = 9;
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
            this.cdvResID.Location = new System.Drawing.Point(118, 0);
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
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(12, 3);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLotList
            // 
            this.pnlLotList.Controls.Add(this.grpLotList);
            this.pnlLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotList.Location = new System.Drawing.Point(3, 156);
            this.pnlLotList.Name = "pnlLotList";
            this.pnlLotList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlLotList.Size = new System.Drawing.Size(722, 287);
            this.pnlLotList.TabIndex = 1;
            // 
            // grpLotList
            // 
            this.grpLotList.Controls.Add(this.lisLotList);
            this.grpLotList.Controls.Add(this.lisLotListTemp);
            this.grpLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotList.Location = new System.Drawing.Point(0, 4);
            this.grpLotList.Name = "grpLotList";
            this.grpLotList.Size = new System.Drawing.Size(722, 283);
            this.grpLotList.TabIndex = 0;
            this.grpLotList.TabStop = false;
            this.grpLotList.Text = "Lot List";
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colLotID,
            this.colMaterial,
            this.colMatVer,
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
            this.lisLotList.MultiSelect = false;
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(716, 264);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
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
            // lisLotListTemp
            // 
            this.lisLotListTemp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader9,
            this.ColumnHeader10,
            this.ColumnHeader11,
            this.ColumnHeader12,
            this.ColumnHeader13,
            this.ColumnHeader14,
            this.ColumnHeader15,
            this.ColumnHeader16,
            this.ColumnHeader17,
            this.ColumnHeader18,
            this.ColumnHeader19,
            this.ColumnHeader20,
            this.ColumnHeader21,
            this.ColumnHeader22,
            this.ColumnHeader23,
            this.ColumnHeader24,
            this.ColumnHeader25,
            this.ColumnHeader26,
            this.ColumnHeader27,
            this.ColumnHeader28,
            this.ColumnHeader29,
            this.ColumnHeader30,
            this.ColumnHeader31,
            this.ColumnHeader32,
            this.ColumnHeader33,
            this.ColumnHeader34,
            this.ColumnHeader35,
            this.ColumnHeader36,
            this.ColumnHeader37,
            this.ColumnHeader38,
            this.ColumnHeader39,
            this.ColumnHeader40,
            this.ColumnHeader41,
            this.ColumnHeader42,
            this.ColumnHeader43,
            this.ColumnHeader44,
            this.ColumnHeader45,
            this.ColumnHeader46,
            this.ColumnHeader47,
            this.ColumnHeader48,
            this.ColumnHeader49,
            this.ColumnHeader50,
            this.ColumnHeader51,
            this.ColumnHeader52,
            this.ColumnHeader53,
            this.ColumnHeader54,
            this.ColumnHeader55,
            this.ColumnHeader56,
            this.ColumnHeader57,
            this.ColumnHeader58,
            this.ColumnHeader59,
            this.ColumnHeader60,
            this.ColumnHeader61,
            this.ColumnHeader62,
            this.ColumnHeader63,
            this.ColumnHeader64,
            this.ColumnHeader65,
            this.ColumnHeader66,
            this.ColumnHeader67,
            this.ColumnHeader68,
            this.ColumnHeader69,
            this.ColumnHeader70,
            this.ColumnHeader71,
            this.ColumnHeader72,
            this.ColumnHeader73,
            this.ColumnHeader74,
            this.ColumnHeader75,
            this.ColumnHeader76,
            this.ColumnHeader77,
            this.ColumnHeader78,
            this.ColumnHeader79,
            this.ColumnHeader80,
            this.ColumnHeader81,
            this.ColumnHeader82,
            this.ColumnHeader83,
            this.ColumnHeader84,
            this.ColumnHeader85,
            this.ColumnHeader86,
            this.ColumnHeader87,
            this.ColumnHeader88,
            this.ColumnHeader89,
            this.ColumnHeader90,
            this.ColumnHeader91,
            this.ColumnHeader92,
            this.ColumnHeader93,
            this.ColumnHeader94,
            this.ColumnHeader95,
            this.ColumnHeader96,
            this.columnHeader97,
            this.columnHeader98});
            this.lisLotListTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotListTemp.EnableSort = true;
            this.lisLotListTemp.EnableSortIcon = true;
            this.lisLotListTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotListTemp.FullRowSelect = true;
            this.lisLotListTemp.Location = new System.Drawing.Point(3, 16);
            this.lisLotListTemp.MultiSelect = false;
            this.lisLotListTemp.Name = "lisLotListTemp";
            this.lisLotListTemp.Size = new System.Drawing.Size(716, 264);
            this.lisLotListTemp.TabIndex = 1;
            this.lisLotListTemp.UseCompatibleStateImageBehavior = false;
            this.lisLotListTemp.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Seq";
            this.ColumnHeader1.Width = 40;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Lot ID";
            this.ColumnHeader2.Width = 120;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Material";
            this.ColumnHeader3.Width = 100;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.DisplayIndex = 4;
            this.ColumnHeader4.Text = "Flow";
            this.ColumnHeader4.Width = 90;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.DisplayIndex = 6;
            this.ColumnHeader5.Text = "Operation";
            this.ColumnHeader5.Width = 80;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.DisplayIndex = 7;
            this.ColumnHeader6.Text = "Qty 1";
            this.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.DisplayIndex = 8;
            this.ColumnHeader7.Text = "Qty 2";
            this.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.DisplayIndex = 9;
            this.ColumnHeader8.Text = "Qty3";
            this.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.DisplayIndex = 10;
            this.ColumnHeader9.Text = "Lot Type";
            this.ColumnHeader9.Width = 70;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.DisplayIndex = 11;
            this.ColumnHeader10.Text = "Owner Code";
            this.ColumnHeader10.Width = 90;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.DisplayIndex = 12;
            this.ColumnHeader11.Text = "Create Code";
            this.ColumnHeader11.Width = 90;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.DisplayIndex = 13;
            this.ColumnHeader12.Text = "Priority";
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.DisplayIndex = 14;
            this.ColumnHeader13.Text = "Lot Status";
            this.ColumnHeader13.Width = 80;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.DisplayIndex = 15;
            this.ColumnHeader14.Text = "Hold Flag";
            this.ColumnHeader14.Width = 80;
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.DisplayIndex = 16;
            this.ColumnHeader15.Text = "Hold Code";
            this.ColumnHeader15.Width = 80;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.DisplayIndex = 17;
            this.ColumnHeader16.Text = "Create Qty 1";
            this.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader16.Width = 100;
            // 
            // ColumnHeader17
            // 
            this.ColumnHeader17.DisplayIndex = 18;
            this.ColumnHeader17.Text = "Create Qty 2";
            this.ColumnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader17.Width = 100;
            // 
            // ColumnHeader18
            // 
            this.ColumnHeader18.DisplayIndex = 19;
            this.ColumnHeader18.Text = "Create Qty 3";
            this.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader18.Width = 100;
            // 
            // ColumnHeader19
            // 
            this.ColumnHeader19.DisplayIndex = 20;
            this.ColumnHeader19.Text = "Oper In Qty 1";
            this.ColumnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader19.Width = 100;
            // 
            // ColumnHeader20
            // 
            this.ColumnHeader20.DisplayIndex = 21;
            this.ColumnHeader20.Text = "Oper In Qty 2";
            this.ColumnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader20.Width = 100;
            // 
            // ColumnHeader21
            // 
            this.ColumnHeader21.DisplayIndex = 22;
            this.ColumnHeader21.Text = "Oper In Qty 3";
            this.ColumnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader21.Width = 100;
            // 
            // ColumnHeader22
            // 
            this.ColumnHeader22.DisplayIndex = 23;
            this.ColumnHeader22.Text = "Inventory Flag";
            this.ColumnHeader22.Width = 100;
            // 
            // ColumnHeader23
            // 
            this.ColumnHeader23.DisplayIndex = 24;
            this.ColumnHeader23.Text = "Transit Flag";
            this.ColumnHeader23.Width = 100;
            // 
            // ColumnHeader24
            // 
            this.ColumnHeader24.DisplayIndex = 25;
            this.ColumnHeader24.Text = "Unit Exist Flag";
            this.ColumnHeader24.Width = 100;
            // 
            // ColumnHeader25
            // 
            this.ColumnHeader25.DisplayIndex = 26;
            this.ColumnHeader25.Text = "Inv Unit";
            // 
            // ColumnHeader26
            // 
            this.ColumnHeader26.DisplayIndex = 27;
            this.ColumnHeader26.Text = "Rework Flag";
            this.ColumnHeader26.Width = 120;
            // 
            // ColumnHeader27
            // 
            this.ColumnHeader27.DisplayIndex = 28;
            this.ColumnHeader27.Text = "Rework Code";
            this.ColumnHeader27.Width = 120;
            // 
            // ColumnHeader28
            // 
            this.ColumnHeader28.DisplayIndex = 29;
            this.ColumnHeader28.Text = "Rework Count";
            this.ColumnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader28.Width = 120;
            // 
            // ColumnHeader29
            // 
            this.ColumnHeader29.DisplayIndex = 30;
            this.ColumnHeader29.Text = "Rework Ret Flow";
            this.ColumnHeader29.Width = 120;
            // 
            // ColumnHeader30
            // 
            this.ColumnHeader30.DisplayIndex = 31;
            this.ColumnHeader30.Text = "Rework Ret Oper";
            this.ColumnHeader30.Width = 120;
            // 
            // ColumnHeader31
            // 
            this.ColumnHeader31.DisplayIndex = 32;
            this.ColumnHeader31.Text = "Rework End Flow";
            this.ColumnHeader31.Width = 120;
            // 
            // ColumnHeader32
            // 
            this.ColumnHeader32.DisplayIndex = 33;
            this.ColumnHeader32.Text = "Rework End Oper";
            this.ColumnHeader32.Width = 120;
            // 
            // ColumnHeader33
            // 
            this.ColumnHeader33.DisplayIndex = 34;
            this.ColumnHeader33.Text = "Rework Ret Clear Flag";
            this.ColumnHeader33.Width = 155;
            // 
            // ColumnHeader34
            // 
            this.ColumnHeader34.DisplayIndex = 35;
            this.ColumnHeader34.Text = "Rework Time";
            this.ColumnHeader34.Width = 120;
            // 
            // ColumnHeader35
            // 
            this.ColumnHeader35.DisplayIndex = 36;
            this.ColumnHeader35.Text = "NSTD Flag";
            this.ColumnHeader35.Width = 120;
            // 
            // ColumnHeader36
            // 
            this.ColumnHeader36.DisplayIndex = 37;
            this.ColumnHeader36.Text = "NSTD Ret Flow";
            this.ColumnHeader36.Width = 120;
            // 
            // ColumnHeader37
            // 
            this.ColumnHeader37.DisplayIndex = 38;
            this.ColumnHeader37.Text = "NSTD Ret Oper";
            this.ColumnHeader37.Width = 120;
            // 
            // ColumnHeader38
            // 
            this.ColumnHeader38.DisplayIndex = 39;
            this.ColumnHeader38.Text = "NSTD Time";
            this.ColumnHeader38.Width = 120;
            // 
            // ColumnHeader39
            // 
            this.ColumnHeader39.DisplayIndex = 40;
            this.ColumnHeader39.Text = "Start Flag";
            this.ColumnHeader39.Width = 70;
            // 
            // ColumnHeader40
            // 
            this.ColumnHeader40.DisplayIndex = 41;
            this.ColumnHeader40.Text = "Start Time";
            this.ColumnHeader40.Width = 120;
            // 
            // ColumnHeader41
            // 
            this.ColumnHeader41.DisplayIndex = 42;
            this.ColumnHeader41.Text = "Start Res ID";
            this.ColumnHeader41.Width = 80;
            // 
            // ColumnHeader42
            // 
            this.ColumnHeader42.DisplayIndex = 43;
            this.ColumnHeader42.Text = "End Flag";
            this.ColumnHeader42.Width = 70;
            // 
            // ColumnHeader43
            // 
            this.ColumnHeader43.DisplayIndex = 44;
            this.ColumnHeader43.Text = "End Time";
            this.ColumnHeader43.Width = 120;
            // 
            // ColumnHeader44
            // 
            this.ColumnHeader44.DisplayIndex = 45;
            this.ColumnHeader44.Text = "End Res ID";
            this.ColumnHeader44.Width = 80;
            // 
            // ColumnHeader45
            // 
            this.ColumnHeader45.DisplayIndex = 46;
            this.ColumnHeader45.Text = "Sample Flag";
            this.ColumnHeader45.Width = 100;
            // 
            // ColumnHeader46
            // 
            this.ColumnHeader46.DisplayIndex = 47;
            this.ColumnHeader46.Text = "Sample Wait Flag";
            this.ColumnHeader46.Width = 110;
            // 
            // ColumnHeader47
            // 
            this.ColumnHeader47.DisplayIndex = 48;
            this.ColumnHeader47.Text = "Sample Result";
            this.ColumnHeader47.Width = 100;
            // 
            // ColumnHeader48
            // 
            this.ColumnHeader48.DisplayIndex = 49;
            this.ColumnHeader48.Text = "From To Lot ID";
            this.ColumnHeader48.Width = 120;
            // 
            // ColumnHeader49
            // 
            this.ColumnHeader49.DisplayIndex = 50;
            this.ColumnHeader49.Text = "Ship Code";
            this.ColumnHeader49.Width = 80;
            // 
            // ColumnHeader50
            // 
            this.ColumnHeader50.DisplayIndex = 51;
            this.ColumnHeader50.Text = "Ship Time";
            this.ColumnHeader50.Width = 120;
            // 
            // ColumnHeader51
            // 
            this.ColumnHeader51.DisplayIndex = 52;
            this.ColumnHeader51.Text = "Original Due Time";
            this.ColumnHeader51.Width = 120;
            // 
            // ColumnHeader52
            // 
            this.ColumnHeader52.DisplayIndex = 53;
            this.ColumnHeader52.Text = "Scheduled Due Time";
            this.ColumnHeader52.Width = 145;
            // 
            // ColumnHeader53
            // 
            this.ColumnHeader53.DisplayIndex = 54;
            this.ColumnHeader53.Text = "Create Time";
            this.ColumnHeader53.Width = 120;
            // 
            // ColumnHeader54
            // 
            this.ColumnHeader54.DisplayIndex = 55;
            this.ColumnHeader54.Text = "Factory In Time";
            this.ColumnHeader54.Width = 120;
            // 
            // ColumnHeader55
            // 
            this.ColumnHeader55.DisplayIndex = 56;
            this.ColumnHeader55.Text = "Flow In Time";
            this.ColumnHeader55.Width = 120;
            // 
            // ColumnHeader56
            // 
            this.ColumnHeader56.DisplayIndex = 57;
            this.ColumnHeader56.Text = "Oper In Time";
            this.ColumnHeader56.Width = 120;
            // 
            // ColumnHeader57
            // 
            this.ColumnHeader57.DisplayIndex = 58;
            this.ColumnHeader57.Text = "Reserve Res ID";
            this.ColumnHeader57.Width = 120;
            // 
            // ColumnHeader58
            // 
            this.ColumnHeader58.DisplayIndex = 59;
            this.ColumnHeader58.Text = "Batch ID";
            // 
            // ColumnHeader59
            // 
            this.ColumnHeader59.DisplayIndex = 60;
            this.ColumnHeader59.Text = "Batch Seq";
            this.ColumnHeader59.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader59.Width = 70;
            // 
            // ColumnHeader60
            // 
            this.ColumnHeader60.DisplayIndex = 61;
            this.ColumnHeader60.Text = "Order ID";
            this.ColumnHeader60.Width = 100;
            // 
            // ColumnHeader61
            // 
            this.ColumnHeader61.DisplayIndex = 62;
            this.ColumnHeader61.Text = "Add Order ID 1";
            this.ColumnHeader61.Width = 100;
            // 
            // ColumnHeader62
            // 
            this.ColumnHeader62.DisplayIndex = 63;
            this.ColumnHeader62.Text = "Add Order ID 2";
            this.ColumnHeader62.Width = 100;
            // 
            // ColumnHeader63
            // 
            this.ColumnHeader63.DisplayIndex = 64;
            this.ColumnHeader63.Text = "Add Order ID 3";
            this.ColumnHeader63.Width = 100;
            // 
            // ColumnHeader64
            // 
            this.ColumnHeader64.DisplayIndex = 65;
            this.ColumnHeader64.Text = "Location";
            this.ColumnHeader64.Width = 80;
            // 
            // ColumnHeader65
            // 
            this.ColumnHeader65.DisplayIndex = 66;
            this.ColumnHeader65.Text = "Lot Cmf 1";
            this.ColumnHeader65.Width = 100;
            // 
            // ColumnHeader66
            // 
            this.ColumnHeader66.DisplayIndex = 67;
            this.ColumnHeader66.Text = "Lot Cmf 2";
            this.ColumnHeader66.Width = 100;
            // 
            // ColumnHeader67
            // 
            this.ColumnHeader67.DisplayIndex = 68;
            this.ColumnHeader67.Text = "Lot Cmf 3";
            this.ColumnHeader67.Width = 100;
            // 
            // ColumnHeader68
            // 
            this.ColumnHeader68.DisplayIndex = 69;
            this.ColumnHeader68.Text = "Lot Cmf 4";
            this.ColumnHeader68.Width = 100;
            // 
            // ColumnHeader69
            // 
            this.ColumnHeader69.DisplayIndex = 70;
            this.ColumnHeader69.Text = "Lot Cmf 5";
            this.ColumnHeader69.Width = 100;
            // 
            // ColumnHeader70
            // 
            this.ColumnHeader70.DisplayIndex = 71;
            this.ColumnHeader70.Text = "Lot Cmf 6";
            this.ColumnHeader70.Width = 100;
            // 
            // ColumnHeader71
            // 
            this.ColumnHeader71.DisplayIndex = 72;
            this.ColumnHeader71.Text = "Lot Cmf 7";
            this.ColumnHeader71.Width = 100;
            // 
            // ColumnHeader72
            // 
            this.ColumnHeader72.DisplayIndex = 73;
            this.ColumnHeader72.Text = "Lot Cmf 8";
            this.ColumnHeader72.Width = 100;
            // 
            // ColumnHeader73
            // 
            this.ColumnHeader73.DisplayIndex = 74;
            this.ColumnHeader73.Text = "Lot Cmf 9";
            this.ColumnHeader73.Width = 100;
            // 
            // ColumnHeader74
            // 
            this.ColumnHeader74.DisplayIndex = 75;
            this.ColumnHeader74.Text = "Lot Cmf 10";
            this.ColumnHeader74.Width = 100;
            // 
            // ColumnHeader75
            // 
            this.ColumnHeader75.DisplayIndex = 76;
            this.ColumnHeader75.Text = "Lot Cmf 11";
            this.ColumnHeader75.Width = 100;
            // 
            // ColumnHeader76
            // 
            this.ColumnHeader76.DisplayIndex = 77;
            this.ColumnHeader76.Text = "Lot Cmf 12";
            this.ColumnHeader76.Width = 100;
            // 
            // ColumnHeader77
            // 
            this.ColumnHeader77.DisplayIndex = 78;
            this.ColumnHeader77.Text = "Lot Cmf 13";
            this.ColumnHeader77.Width = 100;
            // 
            // ColumnHeader78
            // 
            this.ColumnHeader78.DisplayIndex = 79;
            this.ColumnHeader78.Text = "Lot Cmf 14";
            this.ColumnHeader78.Width = 100;
            // 
            // ColumnHeader79
            // 
            this.ColumnHeader79.DisplayIndex = 80;
            this.ColumnHeader79.Text = "Lot Cmf 15";
            this.ColumnHeader79.Width = 100;
            // 
            // ColumnHeader80
            // 
            this.ColumnHeader80.DisplayIndex = 81;
            this.ColumnHeader80.Text = "Lot Cmf 16";
            this.ColumnHeader80.Width = 100;
            // 
            // ColumnHeader81
            // 
            this.ColumnHeader81.DisplayIndex = 82;
            this.ColumnHeader81.Text = "Lot Cmf 17";
            this.ColumnHeader81.Width = 100;
            // 
            // ColumnHeader82
            // 
            this.ColumnHeader82.DisplayIndex = 83;
            this.ColumnHeader82.Text = "Lot Cmf 18";
            this.ColumnHeader82.Width = 100;
            // 
            // ColumnHeader83
            // 
            this.ColumnHeader83.DisplayIndex = 84;
            this.ColumnHeader83.Text = "Lot Cmf 19";
            this.ColumnHeader83.Width = 100;
            // 
            // ColumnHeader84
            // 
            this.ColumnHeader84.DisplayIndex = 85;
            this.ColumnHeader84.Text = "Lot Cmf 20";
            this.ColumnHeader84.Width = 100;
            // 
            // ColumnHeader85
            // 
            this.ColumnHeader85.DisplayIndex = 86;
            this.ColumnHeader85.Text = "BOM Set ID";
            this.ColumnHeader85.Width = 100;
            // 
            // ColumnHeader86
            // 
            this.ColumnHeader86.DisplayIndex = 87;
            this.ColumnHeader86.Text = "BOM Set Version";
            this.ColumnHeader86.Width = 120;
            // 
            // ColumnHeader87
            // 
            this.ColumnHeader87.DisplayIndex = 88;
            this.ColumnHeader87.Text = "BOM Act Hist Seq";
            this.ColumnHeader87.Width = 120;
            // 
            // ColumnHeader88
            // 
            this.ColumnHeader88.DisplayIndex = 89;
            this.ColumnHeader88.Text = "BOM Hist Seq";
            this.ColumnHeader88.Width = 100;
            // 
            // ColumnHeader89
            // 
            this.ColumnHeader89.DisplayIndex = 90;
            this.ColumnHeader89.Text = "Lot Delete Flag";
            this.ColumnHeader89.Width = 100;
            // 
            // ColumnHeader90
            // 
            this.ColumnHeader90.DisplayIndex = 91;
            this.ColumnHeader90.Text = "Lot Delete Time";
            this.ColumnHeader90.Width = 120;
            // 
            // ColumnHeader91
            // 
            this.ColumnHeader91.DisplayIndex = 92;
            this.ColumnHeader91.Text = "Lot Delete Reason";
            this.ColumnHeader91.Width = 150;
            // 
            // ColumnHeader92
            // 
            this.ColumnHeader92.DisplayIndex = 93;
            this.ColumnHeader92.Text = "Last Trans Code";
            this.ColumnHeader92.Width = 120;
            // 
            // ColumnHeader93
            // 
            this.ColumnHeader93.DisplayIndex = 94;
            this.ColumnHeader93.Text = "Last Trans Time";
            this.ColumnHeader93.Width = 120;
            // 
            // ColumnHeader94
            // 
            this.ColumnHeader94.DisplayIndex = 95;
            this.ColumnHeader94.Text = "Last Comment";
            this.ColumnHeader94.Width = 200;
            // 
            // ColumnHeader95
            // 
            this.ColumnHeader95.DisplayIndex = 96;
            this.ColumnHeader95.Text = "Last Active Hist Seq";
            this.ColumnHeader95.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader95.Width = 140;
            // 
            // ColumnHeader96
            // 
            this.ColumnHeader96.DisplayIndex = 97;
            this.ColumnHeader96.Text = "Last Hist Seq";
            this.ColumnHeader96.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader96.Width = 120;
            // 
            // columnHeader97
            // 
            this.columnHeader97.DisplayIndex = 3;
            this.columnHeader97.Text = "Mat Ver";
            this.columnHeader97.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader98
            // 
            this.columnHeader98.DisplayIndex = 5;
            this.columnHeader98.Text = "Flow Seq";
            this.columnHeader98.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkBindSameTr
            // 
            this.chkBindSameTr.AutoSize = true;
            this.chkBindSameTr.Location = new System.Drawing.Point(12, 11);
            this.chkBindSameTr.Name = "chkBindSameTr";
            this.chkBindSameTr.Size = new System.Drawing.Size(158, 17);
            this.chkBindSameTr.TabIndex = 2;
            this.chkBindSameTr.Text = "Bind with Same Transaction";
            this.chkBindSameTr.UseVisualStyleBackColor = true;
            // 
            // frmWIPTranMultiEndLotByResource
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranMultiEndLotByResource";
            this.Text = "Multi End Lot by Resource";
            this.Activated += new System.EventHandler(this.frmWIPTranMultiEndLotByResource_Activated);
            this.Load += new System.EventHandler(this.frmWIPTranMultiEndLotByResource_Load);
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
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlResInfo.ResumeLayout(false);
            this.grpResInfo.ResumeLayout(false);
            this.pnlResInfoMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).EndInit();
            this.pnlResID.ResumeLayout(false);
            this.pnlResID.PerformLayout();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlLotList.ResumeLayout(false);
            this.grpLotList.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int LOT_ID = 1;
        private const int MAT_ID = 2;
        private const int MAT_VER = 3;
        private const int FLOW = 4;
        private const int FLOW_SEQ = 5;
        private const int OPER = 6;
        private const int QTY_1 = 7;
        private const int QTY_2 = 8;
        private const int QTY_3 = 9;
        private const int COL_LAST_HIST_SEQ = 97;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
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

            switch (MPCF.Trim(FuncName))
            {
                case "END_LOT":
                    
                    if (cdvResID.Items.Count > 0)
                    {
                        if (MPCF.CheckValue(cdvResID, 1) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            cdvResID.Focus();
                            return false;
                        }
                    }
                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
            }
            
            return true;
            
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
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
                #if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, false) == false)
                {
                    return false;
                }
                #endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        //
        // View_Resource()
        //       - Get ResourceID Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewResource()
        {

#if _RAS
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

            try
            {
                //Initilize spdResInfo
                spdResInfo.Sheets[0].Cells[0, 1].Text = "";
                spdResInfo.Sheets[0].Cells[0, 3].Text = "";
                spdResInfo.Sheets[0].Cells[1, 0].Text = "";
                spdResInfo.Sheets[0].Cells[1, 1].Text = "";
                spdResInfo.Sheets[0].Cells[1, 2].Text = "";
                spdResInfo.Sheets[0].Cells[1, 3].Text = "";
                spdResInfo.Sheets[0].Cells[2, 0].Text = "";
                spdResInfo.Sheets[0].Cells[2, 1].Text = "";
                spdResInfo.Sheets[0].Cells[2, 2].Text = "";
                spdResInfo.Sheets[0].Cells[2, 3].Text = "";
                spdResInfo.Sheets[0].Cells[3, 0].Text = "";
                spdResInfo.Sheets[0].Cells[3, 1].Text = "";
                spdResInfo.Sheets[0].Cells[3, 2].Text = "";
                spdResInfo.Sheets[0].Cells[3, 3].Text = "";
                spdResInfo.Sheets[0].Cells[4, 0].Text = "";
                spdResInfo.Sheets[0].Cells[4, 1].Text = "";
                spdResInfo.Sheets[0].Cells[4, 2].Text = "";
                spdResInfo.Sheets[0].Cells[4, 3].Text = "";
                spdResInfo.Sheets[0].Cells[5, 0].Text = "";
                spdResInfo.Sheets[0].Cells[5, 1].Text = "";
                spdResInfo.Sheets[0].Cells[5, 2].Text = "";
                spdResInfo.Sheets[0].Cells[5, 3].Text = "";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'U')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "UP";
                }
                else if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'D')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "DOWN";
                }
                spdResInfo.Sheets[0].Cells[0, 3].Text = MPCF.Trim(out_node.GetString("RES_PRI_STS"));

                spdResInfo.Sheets[0].Cells[1, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                spdResInfo.Sheets[0].Cells[1, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                spdResInfo.Sheets[0].Cells[2, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                spdResInfo.Sheets[0].Cells[2, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                spdResInfo.Sheets[0].Cells[3, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                spdResInfo.Sheets[0].Cells[3, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                spdResInfo.Sheets[0].Cells[4, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                spdResInfo.Sheets[0].Cells[4, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                spdResInfo.Sheets[0].Cells[5, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                spdResInfo.Sheets[0].Cells[5, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_10"));

                if (out_node.GetChar("USE_FAC_PRT_FLAG") == 'Y')
                {
                    ViewFactoryResStatus();
                }
                else
                {
                    spdResInfo.Sheets[0].Cells[1, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_1"));
                    spdResInfo.Sheets[0].Cells[1, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_2"));
                    spdResInfo.Sheets[0].Cells[2, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_3"));
                    spdResInfo.Sheets[0].Cells[2, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_4"));
                    spdResInfo.Sheets[0].Cells[3, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_5"));
                    spdResInfo.Sheets[0].Cells[3, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_6"));
                    spdResInfo.Sheets[0].Cells[4, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_7"));
                    spdResInfo.Sheets[0].Cells[4, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_8"));
                    spdResInfo.Sheets[0].Cells[5, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_9"));
                    spdResInfo.Sheets[0].Cells[5, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_10"));
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif
            return true;

        }

        //
        // View_Factory_ResStatus()
        //       - Get Resource Status Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewFactoryResStatus()
        {

            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCR.CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdResInfo.Sheets[0].Cells[1, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                spdResInfo.Sheets[0].Cells[1, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                spdResInfo.Sheets[0].Cells[2, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                spdResInfo.Sheets[0].Cells[2, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                spdResInfo.Sheets[0].Cells[3, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                spdResInfo.Sheets[0].Cells[3, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                spdResInfo.Sheets[0].Cells[4, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                spdResInfo.Sheets[0].Cells[4, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                spdResInfo.Sheets[0].Cells[5, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                spdResInfo.Sheets[0].Cells[5, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_10"));

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        //
        // GetLastHistSeq()
        //       - Get Last Hist Seq by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetLastHistSeq(int iRow)
        {
            
            string sActiveLastHistSeq = "";
            try
            {
                sActiveLastHistSeq = lisLotList.Items[iRow].SubItems[COL_LAST_HIST_SEQ].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sActiveLastHistSeq;
            
        }
        
        //
        // GetLotID()
        //       - Get LotID by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetLotID(int iRow)
        {
            
            string sLotID = "";
            try
            {
                sLotID = lisLotList.Items[iRow].SubItems[LOT_ID].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sLotID;
            
        }
        
        //
        // GetMaterial()
        //       - Get Material by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetMaterial(int iRow)
        {
            
            string sMaterial = "";
            try
            {
                sMaterial = lisLotList.Items[iRow].SubItems[MAT_ID].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sMaterial;
            
        }

        private int GetMaterialVer(int iRow)
        {

            int iMatVer = 0;
            try
            {
                iMatVer = System.Convert.ToInt32(lisLotList.Items[iRow].SubItems[MAT_VER].Text);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return iMatVer;

        }
        
        //
        // GetFlow()
        //       - Get Flow by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetFlow(int iRow)
        {
            
            string sFlow = "";
            try
            {
                sFlow = lisLotList.Items[iRow].SubItems[FLOW].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sFlow;
            
        }

        private int GetFlowSeq(int iRow)
        {

            int iFlowSeq = 0;
            try
            {
                iFlowSeq = System.Convert.ToInt32( lisLotList.Items[iRow].SubItems[FLOW_SEQ].Text);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return iFlowSeq;

        }

        //
        // GetOperation()
        //       - Get Operation by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetOperation(int iRow)
        {
            
            string sOperation = "";
            try
            {
                sOperation = lisLotList.Items[iRow].SubItems[OPER].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sOperation;
            
        }
        
        //
        // GetQty()
        //       - Get Qty by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetQty(int iRow, int iQtyType)
        {
            
            string sQty = "";
            try
            {
                switch (iQtyType)
                {
                    case 1:
                        
                        sQty = lisLotList.Items[iRow].SubItems[QTY_1].Text;
                        break;
                    case 2:
                        
                        sQty = lisLotList.Items[iRow].SubItems[QTY_2].Text;
                        break;
                    case 3:
                        
                        sQty = lisLotList.Items[iRow].SubItems[QTY_3].Text;
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sQty;
            
        }
        
        // View_Lot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewLotList()
        {
            //Modify by J.S. 2012.06.22 바깥에서 선택된 리스트를 가지고 오게 수정, 기존에 동작하지 않음.
            int i;
            string[] lot_list;

            lot_list = new string[MPGV.gaSelectLot_ID.Count - 1 + 1];

            for (i = 0; i <= MPGV.gaSelectLot_ID.Count - 1; i++)
            {
                lot_list[i] = MPGV.gaSelectLot_ID[i].ToString();
            }

            if (WIPLIST.ViewLotListDetail(lisLotList, '1', lot_list, "", "", "", "", "", "", "", "", "", "", "", "", ' ', ' ') == false)
            {
                return false;
            }

            return true;

            
            /*cdvResID_ButtonPress(null, null);
            if (WIPLIST.ViewLotListDetail(lisLotList, '2', null, "", "", "", cdvResID.Text, "", "", "", "", "", "", "", "", ' ', ' ') == false)
            {
                return false;
            }
            
            return true;
             */
            
        }
        
        //
        // Multi_End_Lot()
        //       - Batch Start Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool MultiEndLot(char ProcStep)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("MULTI_END_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode lot_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

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

                in_node.AddChar("BIND_SAME_TR_FLAG", chkBindSameTr.Checked == true ? 'Y' : ' ');

                for (i = 0; i < lisLotList.Items.Count; i++)
                {
                    lot_item = in_node.AddNode("LOT_LIST");

                    lot_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(GetLastHistSeq(i)));
                    lot_item.AddString("LOT_ID", MPCF.Trim(GetLotID(i)));
                    lot_item.AddString("MAT_ID", GetMaterial(i));
                    lot_item.AddInt("MAT_VER", GetMaterialVer(i));
                    lot_item.AddString("FLOW", GetFlow(i));
                    lot_item.AddInt("FLOW_SEQ_NUM", GetFlowSeq(i));
                    lot_item.AddString("OPER", GetOperation(i));
                    lot_item.AddDouble("QTY_1", MPCF.ToDbl(GetQty(i, 1)));
                    lot_item.AddDouble("QTY_2", MPCF.ToDbl(GetQty(i, 2)));
                    lot_item.AddDouble("QTY_3", MPCF.ToDbl(GetQty(i, 3)));
                }

                if (MPCR.CallService("WIP", "WIP_Multi_End_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        
        public override Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.tabTran;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPTranMultiEndLotByResource_Load(object sender, System.EventArgs e)
        {
            
            pnlTranTime.Visible = MPGO.UseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
            lisLotListTemp.Visible = false;
            
        }
        
        private void frmWIPTranMultiEndLotByResource_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    MPCF.InitListView(lisLotList);
                    SetCMFItem(MPGC.MP_CMF_TRN_END);
                    if (MPGV.gaSelectLot_ID.Count > 0)
                    {
                        ViewLotList();
                    }
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("END_LOT") == false) return;
                if (MultiEndLot('1') == false) return;

                if (ViewLotList() == false) return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
            
            if (ViewResource() == false)
            {
                return;
            }
            if (ViewLotList() == false)
            {
                return;
            }
            
        }
        
        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            txtTranDateTime.Visible = ! chkTranDateTime.Checked;
            
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
        }
        
        private void spdResInfo_Resize(object sender, System.EventArgs e)
        {
            
            int iDiffSize;
            
            try
            {
                iDiffSize = (spdResInfo.Width - 716) / 2;
                if (iDiffSize >= 0)
                {
                    spdResInfo.Sheets[0].Columns[1].Width = 197 + iDiffSize;
                    spdResInfo.Sheets[0].Columns[3].Width = 197 + iDiffSize;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
    }
    
}
