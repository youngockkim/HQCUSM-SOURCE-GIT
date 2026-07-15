
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;

using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmORDTranCreateLotOrder.vb
//   Description : Create Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - View_Lot() : View Lot Information
//       - Create_Lot() : Create Lot transaction
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
//#If _ORD = True Then

namespace Miracom.ORDCore
{
    public class frmORDTranCreateLotOrder : Miracom.MESCore.TranForm08
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDTranCreateLotOrder()
        {
            
            
            InitializeComponent();
            
            
            
            spdLotInfo.Tag = "Change Cell";
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
        



        private System.Windows.Forms.Panel pnlCreateLot;
        private System.Windows.Forms.GroupBox grpCreateLot;
        private System.Windows.Forms.Panel pnlOrderList;
        private System.Windows.Forms.Panel pnlWorkDate;
        private System.Windows.Forms.GroupBox grpWorkDate;
        private System.Windows.Forms.GroupBox grpOrderList;
        private Miracom.UI.Controls.MCListView.MCListView lisOrderList;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.Button btnViewOrderList;
        private System.Windows.Forms.ColumnHeader colOrderID;
        private System.Windows.Forms.ColumnHeader colMatID;
        private System.Windows.Forms.ColumnHeader colFlow;
        private System.Windows.Forms.ColumnHeader colResID;
        private System.Windows.Forms.ColumnHeader colBOMSetID;
        private System.Windows.Forms.ColumnHeader colBOMSetVersion;
        private System.Windows.Forms.ColumnHeader comCustomerID;
        private System.Windows.Forms.ColumnHeader colCustomerMatID;
        private System.Windows.Forms.ColumnHeader colPlanDueTime;
        private System.Windows.Forms.ColumnHeader colPlanStartTime;
        private System.Windows.Forms.ColumnHeader colPlanEndTime;
        private System.Windows.Forms.ColumnHeader colCMF1;
        private System.Windows.Forms.ColumnHeader colCMF2;
        private System.Windows.Forms.ColumnHeader colCMF3;
        private System.Windows.Forms.ColumnHeader colCMF4;
        private System.Windows.Forms.ColumnHeader colCMF5;
        private System.Windows.Forms.ColumnHeader colCMF6;
        private System.Windows.Forms.ColumnHeader colCMF7;
        private System.Windows.Forms.ColumnHeader colCMF8;
        private System.Windows.Forms.ColumnHeader colCMF9;
        private System.Windows.Forms.ColumnHeader colCMF10;
        private System.Windows.Forms.ColumnHeader colLotType;
        private System.Windows.Forms.ColumnHeader colOwnerCode;
        private System.Windows.Forms.ColumnHeader colCreateCode;
        private System.Windows.Forms.ColumnHeader colLotPriority;
        private System.Windows.Forms.ColumnHeader colOrgDueTime;
        private System.Windows.Forms.ColumnHeader colStatusFlag;
        private System.Windows.Forms.ColumnHeader colShipFlag;
        private System.Windows.Forms.ColumnHeader colStartTime;
        private System.Windows.Forms.ColumnHeader colEndTime;
        private System.Windows.Forms.ColumnHeader colCreateUserID;
        private System.Windows.Forms.ColumnHeader colCreateTime;
        private System.Windows.Forms.ColumnHeader colUpdateUserID;
        private System.Windows.Forms.ColumnHeader colUpdateTime;
        private System.Windows.Forms.Panel pnlLotID;
        protected System.Windows.Forms.TextBox txtLotDesc;
        protected System.Windows.Forms.Label lblLotDesc;
        protected System.Windows.Forms.TextBox txtLotID;
        protected System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Panel pnlLotInfo;
        protected FarPoint.Win.Spread.SheetView spdLotInfo_Sheet1;
        protected FarPoint.Win.Spread.FpSpread spdLotInfo;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colOrderQty;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.ColumnHeader colInQty;
        private System.Windows.Forms.ColumnHeader colOutQty;
        private System.Windows.Forms.ColumnHeader colLossQty;
        private System.Windows.Forms.ColumnHeader colRwkQty;
        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        private System.Windows.Forms.TabPage tbpCreateCMF;
        private System.Windows.Forms.GroupBox grpCrtCmf;
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
        private ColumnHeader colMatVer;
        private ColumnHeader colFlowSeqNum;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private ColumnHeader colOrderDesc;
        protected System.Windows.Forms.Label lblCrtCmf1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder3, bevelBorder4);
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder3 = new FarPoint.Win.CompoundBorder(bevelBorder5, bevelBorder6);
            this.pnlCreateLot = new System.Windows.Forms.Panel();
            this.grpCreateLot = new System.Windows.Forms.GroupBox();
            this.pnlLotInfo = new System.Windows.Forms.Panel();
            this.spdLotInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdLotInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlLotID = new System.Windows.Forms.Panel();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranDateTime = new System.Windows.Forms.CheckBox();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.txtLotDesc = new System.Windows.Forms.TextBox();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlOrderList = new System.Windows.Forms.Panel();
            this.grpOrderList = new System.Windows.Forms.GroupBox();
            this.lisOrderList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowSeqNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBOMSetID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBOMSetVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comCustomerID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerMatID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlanDueTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlanStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlanEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMF10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOwnerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrgDueTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatusFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShipFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOutQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLossQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRwkQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlWorkDate = new System.Windows.Forms.Panel();
            this.grpWorkDate = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.btnViewOrderList = new System.Windows.Forms.Button();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.tbpCreateCMF = new System.Windows.Forms.TabPage();
            this.grpCrtCmf = new System.Windows.Forms.GroupBox();
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
            this.lblCrtCmf8 = new System.Windows.Forms.Label();
            this.lblCrtCmf7 = new System.Windows.Forms.Label();
            this.lblCrtCmf6 = new System.Windows.Forms.Label();
            this.lblCrtCmf5 = new System.Windows.Forms.Label();
            this.lblCrtCmf4 = new System.Windows.Forms.Label();
            this.lblCrtCmf3 = new System.Windows.Forms.Label();
            this.lblCrtCmf2 = new System.Windows.Forms.Label();
            this.lblCrtCmf1 = new System.Windows.Forms.Label();
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
            this.pnlCreateLot.SuspendLayout();
            this.grpCreateLot.SuspendLayout();
            this.pnlLotInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo_Sheet1)).BeginInit();
            this.pnlLotID.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            this.pnlOrderList.SuspendLayout();
            this.grpOrderList.SuspendLayout();
            this.pnlWorkDate.SuspendLayout();
            this.grpWorkDate.SuspendLayout();
            this.tbpCreateCMF.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpCreateCMF);
            this.tabTran.Size = new System.Drawing.Size(736, 510);
            this.tabTran.Controls.SetChildIndex(this.tbpCreateCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpGeneral, 0);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 484);
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.pnlOrderList);
            this.pnlTranInfo.Controls.Add(this.pnlCreateLot);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 443);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(0, 443);
            this.pnlComment.TabIndex = 1;
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Create Lot Based On Order";
            // 
            // pnlCreateLot
            // 
            this.pnlCreateLot.Controls.Add(this.grpCreateLot);
            this.pnlCreateLot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCreateLot.Location = new System.Drawing.Point(3, 315);
            this.pnlCreateLot.Name = "pnlCreateLot";
            this.pnlCreateLot.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlCreateLot.Size = new System.Drawing.Size(722, 128);
            this.pnlCreateLot.TabIndex = 0;
            // 
            // grpCreateLot
            // 
            this.grpCreateLot.Controls.Add(this.pnlLotInfo);
            this.grpCreateLot.Controls.Add(this.pnlLotID);
            this.grpCreateLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreateLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateLot.Location = new System.Drawing.Point(0, 3);
            this.grpCreateLot.Name = "grpCreateLot";
            this.grpCreateLot.Size = new System.Drawing.Size(722, 125);
            this.grpCreateLot.TabIndex = 0;
            this.grpCreateLot.TabStop = false;
            this.grpCreateLot.Text = "Create Lot Information";
            // 
            // pnlLotInfo
            // 
            this.pnlLotInfo.Controls.Add(this.spdLotInfo);
            this.pnlLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotInfo.Location = new System.Drawing.Point(3, 68);
            this.pnlLotInfo.Name = "pnlLotInfo";
            this.pnlLotInfo.Size = new System.Drawing.Size(716, 54);
            this.pnlLotInfo.TabIndex = 1;
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.AccessibleDescription = "spdLotInfo, LotInfo, Row 0, Column 0, Material(Ver)";
            this.spdLotInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdLotInfo.Location = new System.Drawing.Point(0, 0);
            this.spdLotInfo.MoveActiveOnFocus = false;
            this.spdLotInfo.Name = "spdLotInfo";
            this.spdLotInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdLotInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdLotInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotInfo_Sheet1});
            this.spdLotInfo.Size = new System.Drawing.Size(716, 54);
            this.spdLotInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLotInfo.TabIndex = 0;
            this.spdLotInfo.TabStop = false;
            this.spdLotInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdLotInfo.TextTipDelay = 200;
            this.spdLotInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            this.spdLotInfo.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            // 
            // spdLotInfo_Sheet1
            // 
            this.spdLotInfo_Sheet1.Reset();
            spdLotInfo_Sheet1.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotInfo_Sheet1.ColumnCount = 6;
            spdLotInfo_Sheet1.RowCount = 3;
            this.spdLotInfo_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Cells.Get(0, 0).Value = "Material(Ver)";
            this.spdLotInfo_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 2).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Cells.Get(0, 2).Value = "Flow(SeqNum)";
            this.spdLotInfo_Sheet1.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Cells.Get(0, 4).Value = "Operation";
            this.spdLotInfo_Sheet1.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Cells.Get(1, 0).Value = "Qty 1/2/3";
            this.spdLotInfo_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 2).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Cells.Get(1, 2).Value = "Create Code";
            this.spdLotInfo_Sheet1.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Cells.Get(1, 4).Value = "Owner Code";
            this.spdLotInfo_Sheet1.Cells.Get(1, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Cells.Get(2, 0).Value = "Lot Type";
            this.spdLotInfo_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Cells.Get(2, 2).Value = "Priority";
            this.spdLotInfo_Sheet1.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Cells.Get(2, 4).Value = "Due Date";
            this.spdLotInfo_Sheet1.Cells.Get(2, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.ColumnHeader.Visible = false;
            this.spdLotInfo_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Columns.Get(0).Border = compoundBorder1;
            this.spdLotInfo_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdLotInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(0).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(0).Width = 102F;
            this.spdLotInfo_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdLotInfo_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(1).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(1).Width = 135F;
            this.spdLotInfo_Sheet1.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Columns.Get(2).Border = compoundBorder2;
            this.spdLotInfo_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdLotInfo_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(2).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(2).Width = 102F;
            this.spdLotInfo_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdLotInfo_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(3).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(3).Width = 135F;
            this.spdLotInfo_Sheet1.Columns.Get(4).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Columns.Get(4).Border = compoundBorder3;
            this.spdLotInfo_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdLotInfo_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(4).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(4).Width = 102F;
            this.spdLotInfo_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdLotInfo_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(5).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(5).Width = 135F;
            this.spdLotInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLotInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLotInfo_Sheet1.RowHeader.Visible = false;
            this.spdLotInfo_Sheet1.Rows.Get(0).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(1).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(2).Height = 17F;
            this.spdLotInfo_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLotInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlLotID
            // 
            this.pnlLotID.Controls.Add(this.pnlTranTime);
            this.pnlLotID.Controls.Add(this.txtLotDesc);
            this.pnlLotID.Controls.Add(this.lblLotDesc);
            this.pnlLotID.Controls.Add(this.txtLotID);
            this.pnlLotID.Controls.Add(this.lblLotID);
            this.pnlLotID.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLotID.Location = new System.Drawing.Point(3, 16);
            this.pnlLotID.Name = "pnlLotID";
            this.pnlLotID.Size = new System.Drawing.Size(716, 52);
            this.pnlLotID.TabIndex = 0;
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranTime);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranDate);
            this.pnlTranTime.Location = new System.Drawing.Point(410, 0);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 20);
            this.pnlTranTime.TabIndex = 4;
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
            this.chkTranDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
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
            this.dtpTranDate.TabIndex = 9;
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotDesc.Location = new System.Drawing.Point(120, 24);
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Name = "txtLotDesc";
            this.txtLotDesc.Size = new System.Drawing.Size(586, 20);
            this.txtLotDesc.TabIndex = 3;
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDesc.Location = new System.Drawing.Point(15, 27);
            this.lblLotDesc.Name = "lblLotDesc";
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            this.lblLotDesc.TabIndex = 2;
            this.lblLotDesc.Text = "Description";
            this.lblLotDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 0);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 3);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOrderList
            // 
            this.pnlOrderList.Controls.Add(this.grpOrderList);
            this.pnlOrderList.Controls.Add(this.pnlWorkDate);
            this.pnlOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderList.Location = new System.Drawing.Point(3, 3);
            this.pnlOrderList.Name = "pnlOrderList";
            this.pnlOrderList.Size = new System.Drawing.Size(722, 312);
            this.pnlOrderList.TabIndex = 0;
            // 
            // grpOrderList
            // 
            this.grpOrderList.Controls.Add(this.lisOrderList);
            this.grpOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOrderList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOrderList.Location = new System.Drawing.Point(0, 52);
            this.grpOrderList.Name = "grpOrderList";
            this.grpOrderList.Size = new System.Drawing.Size(722, 260);
            this.grpOrderList.TabIndex = 0;
            this.grpOrderList.TabStop = false;
            this.grpOrderList.Text = "Order List";
            // 
            // lisOrderList
            // 
            this.lisOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colOrderID,
            this.colOrderDesc,
            this.colMatID,
            this.colMatVer,
            this.colFlow,
            this.colFlowSeqNum,
            this.colOrderQty,
            this.colResID,
            this.colBOMSetID,
            this.colBOMSetVersion,
            this.comCustomerID,
            this.colCustomerMatID,
            this.colPlanDueTime,
            this.colPlanStartTime,
            this.colPlanEndTime,
            this.colCMF1,
            this.colCMF2,
            this.colCMF3,
            this.colCMF4,
            this.colCMF5,
            this.colCMF6,
            this.colCMF7,
            this.colCMF8,
            this.colCMF9,
            this.colCMF10,
            this.colQty,
            this.colLotType,
            this.colOwnerCode,
            this.colCreateCode,
            this.colLotPriority,
            this.colOrgDueTime,
            this.colStatusFlag,
            this.colShipFlag,
            this.colStartTime,
            this.colEndTime,
            this.colInQty,
            this.colOutQty,
            this.colLossQty,
            this.colRwkQty,
            this.colCreateUserID,
            this.colCreateTime,
            this.colUpdateUserID,
            this.colUpdateTime});
            this.lisOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisOrderList.EnableSort = true;
            this.lisOrderList.EnableSortIcon = true;
            this.lisOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisOrderList.FullRowSelect = true;
            this.lisOrderList.HideSelection = false;
            this.lisOrderList.Location = new System.Drawing.Point(3, 16);
            this.lisOrderList.MultiSelect = false;
            this.lisOrderList.Name = "lisOrderList";
            this.lisOrderList.Size = new System.Drawing.Size(716, 241);
            this.lisOrderList.TabIndex = 0;
            this.lisOrderList.UseCompatibleStateImageBehavior = false;
            this.lisOrderList.View = System.Windows.Forms.View.Details;
            this.lisOrderList.Click += new System.EventHandler(this.lisOrderList_Click);
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 49;
            // 
            // colOrderID
            // 
            this.colOrderID.Text = "Order ID";
            this.colOrderID.Width = 123;
            // 
            // colOrderDesc
            // 
            this.colOrderDesc.Text = "Order Desc";
            this.colOrderDesc.Width = 100;
            // 
            // colMatID
            // 
            this.colMatID.Text = "Material";
            this.colMatID.Width = 120;
            // 
            // colMatVer
            // 
            this.colMatVer.Text = "Mat Ver";
            // 
            // colFlow
            // 
            this.colFlow.Text = "Flow";
            this.colFlow.Width = 110;
            // 
            // colFlowSeqNum
            // 
            this.colFlowSeqNum.Text = "Flow Seq Num";
            this.colFlowSeqNum.Width = 100;
            // 
            // colOrderQty
            // 
            this.colOrderQty.Text = "Order Qty";
            this.colOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOrderQty.Width = 80;
            // 
            // colResID
            // 
            this.colResID.Text = "Resource ID";
            this.colResID.Width = 125;
            // 
            // colBOMSetID
            // 
            this.colBOMSetID.Text = "BOM Set ID";
            this.colBOMSetID.Width = 104;
            // 
            // colBOMSetVersion
            // 
            this.colBOMSetVersion.Text = "BOM Set Version";
            this.colBOMSetVersion.Width = 111;
            // 
            // comCustomerID
            // 
            this.comCustomerID.Text = "Customer ID";
            this.comCustomerID.Width = 102;
            // 
            // colCustomerMatID
            // 
            this.colCustomerMatID.Text = "Customer Mat ID";
            this.colCustomerMatID.Width = 111;
            // 
            // colPlanDueTime
            // 
            this.colPlanDueTime.Text = "Plan Due Time";
            this.colPlanDueTime.Width = 120;
            // 
            // colPlanStartTime
            // 
            this.colPlanStartTime.Text = "Plan Start Time";
            this.colPlanStartTime.Width = 120;
            // 
            // colPlanEndTime
            // 
            this.colPlanEndTime.Text = "Plan End Time";
            this.colPlanEndTime.Width = 120;
            // 
            // colCMF1
            // 
            this.colCMF1.Text = "CMF 1";
            this.colCMF1.Width = 80;
            // 
            // colCMF2
            // 
            this.colCMF2.Text = "CMF 2";
            this.colCMF2.Width = 80;
            // 
            // colCMF3
            // 
            this.colCMF3.Text = "CMF 3";
            this.colCMF3.Width = 80;
            // 
            // colCMF4
            // 
            this.colCMF4.Text = "CMF 4";
            this.colCMF4.Width = 80;
            // 
            // colCMF5
            // 
            this.colCMF5.Text = "CMF 5";
            this.colCMF5.Width = 80;
            // 
            // colCMF6
            // 
            this.colCMF6.Text = "CMF 6";
            this.colCMF6.Width = 80;
            // 
            // colCMF7
            // 
            this.colCMF7.Text = "CMF 7";
            this.colCMF7.Width = 80;
            // 
            // colCMF8
            // 
            this.colCMF8.Text = "CMF 8";
            this.colCMF8.Width = 80;
            // 
            // colCMF9
            // 
            this.colCMF9.Text = "CMF 9";
            this.colCMF9.Width = 80;
            // 
            // colCMF10
            // 
            this.colCMF10.Text = "CMF 10";
            this.colCMF10.Width = 80;
            // 
            // colQty
            // 
            this.colQty.Text = "Qty";
            this.colQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colQty.Width = 70;
            // 
            // colLotType
            // 
            this.colLotType.Text = "Lot Type";
            this.colLotType.Width = 66;
            // 
            // colOwnerCode
            // 
            this.colOwnerCode.Text = "Owner Code";
            this.colOwnerCode.Width = 87;
            // 
            // colCreateCode
            // 
            this.colCreateCode.Text = "Create Code";
            this.colCreateCode.Width = 87;
            // 
            // colLotPriority
            // 
            this.colLotPriority.Text = "Priority";
            // 
            // colOrgDueTime
            // 
            this.colOrgDueTime.Text = "Due Date";
            this.colOrgDueTime.Width = 80;
            // 
            // colStatusFlag
            // 
            this.colStatusFlag.Text = "Status";
            this.colStatusFlag.Width = 50;
            // 
            // colShipFlag
            // 
            this.colShipFlag.Text = "Ship Flag";
            this.colShipFlag.Width = 66;
            // 
            // colStartTime
            // 
            this.colStartTime.Text = "StartTime";
            this.colStartTime.Width = 120;
            // 
            // colEndTime
            // 
            this.colEndTime.Text = "End Time";
            this.colEndTime.Width = 120;
            // 
            // colInQty
            // 
            this.colInQty.Text = "In Qty";
            this.colInQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInQty.Width = 70;
            // 
            // colOutQty
            // 
            this.colOutQty.Text = "Out Qty";
            this.colOutQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOutQty.Width = 75;
            // 
            // colLossQty
            // 
            this.colLossQty.Text = "Loss Qty";
            this.colLossQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colLossQty.Width = 75;
            // 
            // colRwkQty
            // 
            this.colRwkQty.Text = "Rework Qty";
            this.colRwkQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRwkQty.Width = 90;
            // 
            // colCreateUserID
            // 
            this.colCreateUserID.Text = "Create User ID";
            this.colCreateUserID.Width = 98;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Text = "Create Time";
            this.colCreateTime.Width = 120;
            // 
            // colUpdateUserID
            // 
            this.colUpdateUserID.Text = "Update User ID";
            this.colUpdateUserID.Width = 98;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.Text = "Update Time";
            this.colUpdateTime.Width = 120;
            // 
            // pnlWorkDate
            // 
            this.pnlWorkDate.Controls.Add(this.grpWorkDate);
            this.pnlWorkDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWorkDate.Location = new System.Drawing.Point(0, 0);
            this.pnlWorkDate.Name = "pnlWorkDate";
            this.pnlWorkDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlWorkDate.Size = new System.Drawing.Size(722, 52);
            this.pnlWorkDate.TabIndex = 0;
            // 
            // grpWorkDate
            // 
            this.grpWorkDate.Controls.Add(this.cdvMaterial);
            this.grpWorkDate.Controls.Add(this.btnViewOrderList);
            this.grpWorkDate.Controls.Add(this.dtpWorkDate);
            this.grpWorkDate.Controls.Add(this.lblWorkDate);
            this.grpWorkDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpWorkDate.Location = new System.Drawing.Point(0, 0);
            this.grpWorkDate.Name = "grpWorkDate";
            this.grpWorkDate.Size = new System.Drawing.Size(722, 47);
            this.grpWorkDate.TabIndex = 0;
            this.grpWorkDate.TabStop = false;
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
            this.cdvMaterial.Location = new System.Drawing.Point(224, 16);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(252, 20);
            this.cdvMaterial.TabIndex = 2;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 108;
            this.cdvMaterial.WidthMaterialAndVersion = 144;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // btnViewOrderList
            // 
            this.btnViewOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewOrderList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnViewOrderList.Location = new System.Drawing.Point(596, 16);
            this.btnViewOrderList.Name = "btnViewOrderList";
            this.btnViewOrderList.Size = new System.Drawing.Size(118, 21);
            this.btnViewOrderList.TabIndex = 3;
            this.btnViewOrderList.Text = "View Order List";
            this.btnViewOrderList.Click += new System.EventHandler(this.btnViewOrderList_Click);
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(115, 15);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(90, 20);
            this.dtpWorkDate.TabIndex = 1;
            this.dtpWorkDate.CloseUp += new System.EventHandler(this.dtpWorkDate_CloseUp);
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkDate.Location = new System.Drawing.Point(15, 18);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(59, 13);
            this.lblWorkDate.TabIndex = 0;
            this.lblWorkDate.Text = "Work Date";
            // 
            // tbpCreateCMF
            // 
            this.tbpCreateCMF.Controls.Add(this.grpCrtCmf);
            this.tbpCreateCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCreateCMF.Name = "tbpCreateCMF";
            this.tbpCreateCMF.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCreateCMF.Size = new System.Drawing.Size(728, 484);
            this.tbpCreateCMF.TabIndex = 2;
            this.tbpCreateCMF.Text = "Create Customized Field";
            // 
            // grpCrtCmf
            // 
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
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf8);
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
            this.grpCrtCmf.Size = new System.Drawing.Size(722, 478);
            this.grpCrtCmf.TabIndex = 2;
            this.grpCrtCmf.TabStop = false;
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
            // lblCrtCmf8
            // 
            this.lblCrtCmf8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf8.Location = new System.Drawing.Point(23, 187);
            this.lblCrtCmf8.Name = "lblCrtCmf8";
            this.lblCrtCmf8.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf8.TabIndex = 14;
            this.lblCrtCmf8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // frmORDTranCreateLotOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmORDTranCreateLotOrder";
            this.Text = "Create Lot Based On Order";
            this.Activated += new System.EventHandler(this.frmORDTranCreateLotOrder_Activated);
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
            this.pnlCreateLot.ResumeLayout(false);
            this.grpCreateLot.ResumeLayout(false);
            this.pnlLotInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo_Sheet1)).EndInit();
            this.pnlLotID.ResumeLayout(false);
            this.pnlLotID.PerformLayout();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.pnlOrderList.ResumeLayout(false);
            this.grpOrderList.ResumeLayout(false);
            this.pnlWorkDate.ResumeLayout(false);
            this.grpWorkDate.ResumeLayout(false);
            this.grpWorkDate.PerformLayout();
            this.tbpCreateCMF.ResumeLayout(false);
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
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int ORDER_ID          = 1;
        private const int ORDER_DESC        = 2;
        private const int MAT_ID            = 3;
        private const int MAT_VER           = 4;
        private const int FLOW              = 5;
        private const int FLOW_SEQ_NUM      = 6;
        private const int ORD_QTY           = 7;
        private const int RES_ID            = 8;
        private const int BOM_SET_ID        = 9;
        private const int BOM_SET_VERSION   = 10;
        private const int CUSTOMER_ID       = 11;
        private const int CUSTOMER_MAT_ID   = 12;
        private const int PLAN_DUE_TIME     = 13;
        private const int PLAN_START_TIME   = 14;
        private const int PLAN_END_TIME     = 15;
        private const int ORD_CMF_1         = 16;
        private const int ORD_CMF_2         = 17;
        private const int ORD_CMF_3         = 18;
        private const int ORD_CMF_4         = 19;
        private const int ORD_CMF_5         = 20;
        private const int ORD_CMF_6         = 21;
        private const int ORD_CMF_7         = 22;
        private const int ORD_CMF_8         = 23;
        private const int ORD_CMF_9         = 24;
        private const int ORD_CMF_10        = 25;
        private const int QTY               = 26;
        private const int LOT_TYPE          = 27;
        private const int OWNER_CODE        = 28;
        private const int CREATE_CODE       = 29;
        private const int LOT_PRIORITY      = 30;
        private const int ORG_DUE_TIME      = 31;
        private const int ORD_STATUS_FLAG   = 32;
        private const int ORD_SHIP_FLAG     = 33;
        private const int ORD_START_TIME    = 34;
        private const int ORD_END_TIME      = 35;
        private const int ORD_IN_QTY        = 36;
        private const int ORD_OUT_QTY       = 37;
        private const int ORD_LOSS_QTY      = 38;
        private const int ORD_RWK_QTY       = 39;
        private const int CREATE_USER_ID    = 40;
        private const int CREATE_TIME       = 41;
        private const int UPDATE_USER_ID    = 42;
        private const int UPDATE_TIME       = 43;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag = false;
        private string sOrderID = "";
        private string sWorkDate = "";
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(char ProcStep)
        {
            
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this);
                    InitLotInfo();
                }
                else if (ProcStep == '2')
                {
                    //View Order List Button Click ??Field Clear
                    MPCF.FieldClear(this, cdvMaterial, null, null, null, null, false);
                    InitLotInfo();
                }
                else if (ProcStep == '3')
                {
                    //Create Lot ?±ê³µ ??Field Clear
                    MPCF.FieldClear(this, cdvMaterial, null, null, null, null, false);
                    InitLotInfo();
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
                case "CREATE_LOT":
                    
                    tabTran.SelectedTab = tbpGeneral;
                    if (MPCF.CheckValue(txtLotID, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (GetMaterial() == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (GetFlow() == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                        dtpWorkDate.Focus();
                        return false;
                    }
                    if (GetOperation() == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        dtpWorkDate.Focus();
                        return false;
                    }
                    if (GetQty1() == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Qty1]");
                        dtpWorkDate.Focus();
                        return false;
                    }
                    if (GetCreateCode() == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [CreateCode]");
                        dtpWorkDate.Focus();
                        return false;
                    }
                    if (GetOwnerCode() == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [OwnerCode]");
                        dtpWorkDate.Focus();
                        return false;
                    }
                    if (GetLotType() == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [LotType]");
                        dtpWorkDate.Focus();
                        return false;
                    }
                    if (GetPriority() == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Proirity]");
                        dtpWorkDate.Focus();
                        return false;
                    }
                    if (GetDueDate() == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [DueDate]");
                        dtpWorkDate.Focus();
                        return false;
                    }
                    
                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCrtCMF", "cdvCrtCMF", grpCrtCmf) == false)
                    {
                        tabTran.SelectedTab = tbpCreateCMF;
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }
        
        private void InitLotInfo()
        {
            
            spdLotInfo.Sheets[0].Cells[0, 1].Text = "";
            spdLotInfo.Sheets[0].Cells[0, 3].Text = "";
            spdLotInfo.Sheets[0].Cells[0, 5].Text = "";
            spdLotInfo.Sheets[0].Cells[1, 1].Text = "";
            spdLotInfo.Sheets[0].Cells[1, 3].Text = "";
            spdLotInfo.Sheets[0].Cells[1, 5].Text = "";
            spdLotInfo.Sheets[0].Cells[2, 1].Text = "";
            spdLotInfo.Sheets[0].Cells[2, 3].Text = "";
            spdLotInfo.Sheets[0].Cells[2, 5].Text = "";
            
        }
        
        private string GetMaterial()
        {
            
            string sMaterial = "";
            int iMatVer = 0;
            
            try
            {
                /* 2013.06.12. Aiden. Material ID ¿¡ (,) °¡ Æ÷ÇÔµÈ °æ¿ì ParsingÀÌ Á¦´ë·Î ¾ÈµÇ´Â ¹®Á¦ ÇØ°á */
                MPCR.ParseSequenceInfo(spdLotInfo.Sheets[0].Cells[0, 1].Text, ref sMaterial, ref iMatVer);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
            return sMaterial;
            
        }

        private int GetMatVer()
        {
            string sMaterial = "";
            int iMaterialVer = 0;

            try
            {
                /* 2013.06.12. Aiden. Material ID ¿¡ (,) °¡ Æ÷ÇÔµÈ °æ¿ì ParsingÀÌ Á¦´ë·Î ¾ÈµÇ´Â ¹®Á¦ ÇØ°á */
                MPCR.ParseSequenceInfo(spdLotInfo.Sheets[0].Cells[0, 1].Text, ref sMaterial, ref iMaterialVer);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return 0;
            }

            return iMaterialVer;
        }
        
        private string GetFlow()
        {
            
            string sFlow = "";
            int iFlowSeq = 0;
            
            try
            {
                /* 2013.06.12. Aiden. Material ID ¿¡ (,) °¡ Æ÷ÇÔµÈ °æ¿ì ParsingÀÌ Á¦´ë·Î ¾ÈµÇ´Â ¹®Á¦ ÇØ°á */
                MPCR.ParseSequenceInfo(spdLotInfo.Sheets[0].Cells[0, 3].Text, ref sFlow, ref iFlowSeq);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
            return sFlow;
            
        }

        private int GetFlowSeqNum()
        {

            string sFlowSeqNum = "";
            int iFlowSeq = 0;

            try
            {
                /* 2013.06.12. Aiden. Material ID ¿¡ (,) °¡ Æ÷ÇÔµÈ °æ¿ì ParsingÀÌ Á¦´ë·Î ¾ÈµÇ´Â ¹®Á¦ ÇØ°á */
                MPCR.ParseSequenceInfo(spdLotInfo.Sheets[0].Cells[0, 3].Text, ref sFlowSeqNum, ref iFlowSeq);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return 0;
            }

            return iFlowSeq;

        }
        
        private string GetOperation()
        {
            
            string sOperation = "";
            
            try
            {
                sOperation = MPCF.Trim(spdLotInfo.Sheets[0].Cells[0, 5].Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
            return sOperation;
            
        }
        
        private string GetQty1()
        {
            
            string sQty1 = "";
            
            try
            {
                sQty1 = MPCF.Trim(spdLotInfo.Sheets[0].Cells[1, 1].Text);
                if (sQty1 != "")
                {
                    if (sQty1.IndexOf("/") > 0)
                    {
                        sQty1 = sQty1.Substring(0, sQty1.IndexOf("/"));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
            return sQty1;
            
        }
        
        private string GetQty2()
        {
            
            string sQty2 = "";
            
            try
            {
                sQty2 = MPCF.Trim(spdLotInfo.Sheets[0].Cells[1, 1].Text);
                if (sQty2.IndexOf("1") <= 0)
                {
                    return "";
                }
                if (sQty2 != "")
                {
                    sQty2 = sQty2.Substring(sQty2.IndexOf("/") + 1, sQty2.LastIndexOf("/") - sQty2.IndexOf("/") - 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sQty2;
            
        }
        
        private string GetQty3()
        {
            
            string sQty3 = "";
            
            try
            {
                sQty3 = MPCF.Trim(spdLotInfo.Sheets[0].Cells[1, 1].Text);
                if (sQty3.IndexOf("1") <= 0)
                {
                    return "";
                }
                if (sQty3 != "")
                {
                    sQty3 = sQty3.Substring(sQty3.LastIndexOf("/") + 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sQty3;
            
        }
        
        private string GetCreateCode()
        {
            
            string sCreateCode = "";
            
            try
            {
                sCreateCode = MPCF.Trim(spdLotInfo.Sheets[0].Cells[1, 3].Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
            return sCreateCode;
            
        }
        
        private string GetOwnerCode()
        {
            
            string sOwnerCode = "";
            
            try
            {
                sOwnerCode = MPCF.Trim(spdLotInfo.Sheets[0].Cells[1, 5].Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
            return sOwnerCode;
            
        }
        
        private string GetLotType()
        {
            
            string sLotType = "";
            
            try
            {
                sLotType = MPCF.Trim(spdLotInfo.Sheets[0].Cells[2, 1].Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
            return sLotType;
            
        }
        
        private string GetPriority()
        {
            
            string sPriority = "";
            
            try
            {
                sPriority = MPCF.Trim(spdLotInfo.Sheets[0].Cells[2, 3].Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
            return sPriority;
            
        }
        
        private string GetDueDate()
        {
            
            string sDueDate = "";
            
            try
            {
                sDueDate = MPCF.Trim(spdLotInfo.Sheets[0].Cells[2, 5].Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
            return sDueDate;
            
        }
        
        
        //
        // GetFirstOperByFlow()
        //       - Get First Operation By Flow
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private string GetFirstOperByFlow(string sFlow)
        {
            TRSNode in_node = new TRSNode("View_Flow_In");
            TRSNode out_node = new TRSNode("View_Flow_Out");


            string sOper = "";
            
            if (sFlow == "")
            {
                return sOper;
            }


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", sFlow);

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return sOper;
            }

            sOper = MPCF.Trim(out_node.GetString("FIRST_OPER"));
            
            return sOper;
            
        }
        
        
        // View_Order_List_Detail()
        //       - View all Flow List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : Listê°€ ?¤ì–´ê°?control
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterë¡??œìž‘?˜ëŠ” Flow
        //        - Optional ByVal sOper As String = ""        : sOperë¥?ê°€ì§?Flow
        //        - Optional ByVal sMaterial As String = ""    : sMaterialë¥?ê°€ì§?Flow
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?ì„œ ì¶”ê???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?„ìž¬ Factoryê°€ ?„ë‹Œê²½ìš°???€??Factory
        //
        private bool View_Order_List_Detail()
        {
            TRSNode in_node = new TRSNode("View_Order_List_Detail_In");
            TRSNode out_node = new TRSNode("View_Order_List_Detail_Out");
            TRSNode order_list;
            int i = 0;
            ListViewItem itmX;
            int iTotalCnt = 0;

            MPCF.ClearList(lisOrderList, true);
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FROM_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
            in_node.AddString("TO_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
            in_node.AddChar("ORD_STATUS_FLAG", ' ');
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            
            do
            {
                if (MPCR.CallService("ORD", "ORD_View_Order_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    order_list = out_node.GetList(0)[i];
                    if (MPCF.Trim(order_list.GetChar("ORD_STATUS_FLAG")) != "D")
                    {
                        
                        iTotalCnt++;

                        itmX = new ListViewItem(MPCF.Trim(iTotalCnt), (int)SMALLICON_INDEX.IDX_ORDER);

                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORDER_ID")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORDER_DESC")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("MAT_ID")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetInt("MAT_VER")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("FLOW")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetInt("FLOW_SEQ_NUM")));
                        itmX.SubItems.Add(MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_QTY")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("RES_ID")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("BOM_SET_ID")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetInt("BOM_SET_VERSION")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("CUSTOMER_ID")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("CUSTOMER_MAT_ID")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(order_list.GetString("PLAN_DUE_TIME")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(order_list.GetString("PLAN_START_TIME")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(order_list.GetString("PLAN_END_TIME")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_1")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_2")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_3")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_4")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_5")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_6")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_7")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_8")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_9")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("ORD_CMF_10")));
                        itmX.SubItems.Add(MPCF.Format("#####,##0.###", order_list.GetDouble("QTY")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetChar("LOT_TYPE")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("OWNER_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("CREATE_CODE")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetChar("LOT_PRIORITY")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(order_list.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetChar("ORD_STATUS_FLAG")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetChar("ORD_SHIP_FLAG")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(order_list.GetString("ORD_START_TIME")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(order_list.GetString("ORD_END_TIME")));
                        itmX.SubItems.Add(MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_IN_QTY")));
                        itmX.SubItems.Add(MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_OUT_QTY")));
                        itmX.SubItems.Add(MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_LOSS_QTY")));
                        itmX.SubItems.Add(MPCF.Format("#####,##0.###", order_list.GetDouble("ORD_RWK_QTY")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("CREATE_USER_ID")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(order_list.GetString("CREATE_TIME")));
                        itmX.SubItems.Add(MPCF.Trim(order_list.GetString("UPDATE_USER_ID")));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(order_list.GetString("UPDATE_TIME")));
                        
                        lisOrderList.Items.Add(itmX);
                        
                    }
                    
                }
                in_node.SetString("NEXT_ORDER_ID", out_node.GetString("NEXT_ORDER_ID"));

            } while (in_node.GetString("NEXT_ORDER_ID") != "");
            
            return true;
            
        }
        
        //
        // Create_Lot()
        //       - Create New Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Create_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("Create_Lot_In");
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("LOT_DESC", MPCF.Trim(txtLotDesc.Text));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("MAT_ID", GetMaterial());
                in_node.AddInt("MAT_VER", GetMatVer());
                in_node.AddString("FLOW", GetFlow());
                in_node.AddInt("FLOW_SEQ_NUM", GetFlowSeqNum());
                in_node.AddString("OPER", GetOperation());
                in_node.AddChar("LOT_TYPE", MPCF.ToChar(GetLotType()));


                if (GetQty1() != "")
                {
                    in_node.AddDouble("QTY_1", MPCF.ToDbl(GetQty1()));
                }
                else
                {
                    in_node.AddDouble("QTY_1", 0);
                }
                if (GetQty2() != "")
                {
                    in_node.AddDouble("QTY_2", MPCF.ToDbl(GetQty2()));
                }
                else
                {
                    in_node.AddDouble("QTY_2", 0);
                }
                if (GetQty3() != "")
                {
                    in_node.AddDouble("QTY_3", MPCF.ToDbl(GetQty3()));
                }
                else
                {
                    in_node.AddDouble("QTY_3", 0);
                }
                
                in_node.AddString("CREATE_CODE", GetCreateCode());
                in_node.AddString("OWNER_CODE",GetOwnerCode());
                in_node.AddChar("LOT_PRIORITY",MPCF.ToChar(GetPriority()));
                in_node.AddString("DUE_TIME", MPCF.DestroyDateFormat(GetDueDate(), DATE_TIME_FORMAT.DATE));
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

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvCrtCmf1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvCrtCmf2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvCrtCmf3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvCrtCmf4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvCrtCmf5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvCrtCmf6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvCrtCmf7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvCrtCmf8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvCrtCmf9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvCrtCmf10.Text));
                in_node.AddString("LOT_CMF_11", MPCF.Trim(cdvCrtCmf11.Text));
                in_node.AddString("LOT_CMF_12", MPCF.Trim(cdvCrtCmf12.Text));
                in_node.AddString("LOT_CMF_13", MPCF.Trim(cdvCrtCmf13.Text));
                in_node.AddString("LOT_CMF_14", MPCF.Trim(cdvCrtCmf14.Text));
                in_node.AddString("LOT_CMF_15", MPCF.Trim(cdvCrtCmf15.Text));
                in_node.AddString("LOT_CMF_16", MPCF.Trim(cdvCrtCmf16.Text));
                in_node.AddString("LOT_CMF_17", MPCF.Trim(cdvCrtCmf17.Text));
                in_node.AddString("LOT_CMF_18", MPCF.Trim(cdvCrtCmf18.Text));
                in_node.AddString("LOT_CMF_19", MPCF.Trim(cdvCrtCmf19.Text));
                in_node.AddString("LOT_CMF_20", MPCF.Trim(cdvCrtCmf20.Text));


                in_node.AddChar("IN_CASE", '1');
                in_node.AddString("ORDER_ID", sOrderID);

                if (MPCR.CallService("ORD", "ORD_Create_Lot", in_node, ref out_node) == false)
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
        
        private void frmORDTranCreateLotOrder_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData('1');
                    MPCF.InitListView(lisOrderList);
                    SetCMFItem(MPGC.MP_CMF_TRN_CREATE);
                    MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblCrtCMF", "cdvCrtCMF", grpCrtCmf);
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("CREATE_LOT") == false) return;
                if (Create_Lot('1') == false) return;

                btnViewOrderList.PerformClick();
                ClearData('3');
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnViewOrderList_Click(System.Object sender, System.EventArgs e)
        {
            
            if (View_Order_List_Detail() == false)
            {
                return;
            }
            ClearData('2');
            
        }
        
        private void lisOrderList_Click(object sender, System.EventArgs e)
        {
            
            InitLotInfo();
            if (lisOrderList.SelectedItems.Count > 0)
            {
                
                sOrderID = MPCF.Trim(lisOrderList.SelectedItems[0].SubItems[ORDER_ID].Text);
                spdLotInfo.Sheets[0].Cells[0, 1].Value = MPCF.Trim(lisOrderList.SelectedItems[0].SubItems[MAT_ID].Text + "(" + lisOrderList.SelectedItems[0].SubItems[MAT_VER].Text + ")");
                spdLotInfo.Sheets[0].Cells[0, 3].Value = MPCF.Trim(lisOrderList.SelectedItems[0].SubItems[FLOW].Text + "(" + lisOrderList.SelectedItems[0].SubItems[FLOW_SEQ_NUM].Text + ")");
                spdLotInfo.Sheets[0].Cells[0, 5].Value = GetFirstOperByFlow(GetFlow());
                spdLotInfo.Sheets[0].Cells[1, 1].Value = MPCF.Trim(lisOrderList.SelectedItems[0].SubItems[QTY].Text);
                spdLotInfo.Sheets[0].Cells[1, 3].Value = MPCF.Trim(lisOrderList.SelectedItems[0].SubItems[CREATE_CODE].Text);
                spdLotInfo.Sheets[0].Cells[1, 5].Value = MPCF.Trim(lisOrderList.SelectedItems[0].SubItems[OWNER_CODE].Text);
                spdLotInfo.Sheets[0].Cells[2, 1].Value = MPCF.Trim(lisOrderList.SelectedItems[0].SubItems[LOT_TYPE].Text);
                spdLotInfo.Sheets[0].Cells[2, 3].Value = MPCF.Trim(lisOrderList.SelectedItems[0].SubItems[LOT_PRIORITY].Text);
                spdLotInfo.Sheets[0].Cells[2, 5].Value = MPCF.Trim(lisOrderList.SelectedItems[0].SubItems[ORG_DUE_TIME].Text);
                
            }
            
        }
        
        private void dtpWorkDate_CloseUp(object sender, System.EventArgs e)
        {

            sWorkDate = MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT);
            btnViewOrderList.PerformClick();
            
        }
        
        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            txtTranDateTime.Visible = ! chkTranDateTime.Checked;
            
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
        }
        
        protected override void OnActivated(System.EventArgs e)
        {
            
            pnlTranTime.Visible = MPGO.UseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
            base.OnActivated(e);
            
        }
        
        private void cdvMaterial_ButtonPress(object sender, System.EventArgs e)
        {
            cdvMaterial.Init();
            MPCF.InitListView(cdvMaterial.MaterialGetListView);
            cdvMaterial.MaterialColumns.Add("Material", 50, HorizontalAlignment.Left);
            cdvMaterial.MaterialColumns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvMaterial.SelectedSubItemIndex = 0;
            WIPLIST.ViewMaterialList(cdvMaterial.MaterialGetListView, '1');
        }
    }
    //#End If
}
