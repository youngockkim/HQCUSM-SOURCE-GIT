
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCViewLotListbyOperation.vb
//   Description :
//
//   SPC Version : 1.0.0
//
//   Function List
//       - SetTableName() : Set Operation Group Table Name
//       - SetOperGroupPrompt() : Set Group Property to control
//       - View_Lot_List() : View Lot List By Operation Condition
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-05-10 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCViewLotListbyOperation : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCViewLotListbyOperation()
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
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.Panel pnlMid;
        internal System.Windows.Forms.GroupBox grpTop;
        internal System.Windows.Forms.Label lblOperGroup;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup1;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroupType1;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        internal System.Windows.Forms.Label lblOperation;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkTerminatedLot;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkZeroQtyLot;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private ColumnHeader colSeq;
        private ColumnHeader colLotID;
        private ColumnHeader colMaterial;
        private ColumnHeader colMatVersion;
        private ColumnHeader colFlow;
        private ColumnHeader colFlowSeq;
        private ColumnHeader colOperation;
        private ColumnHeader colQty1;
        private ColumnHeader colQty2;
        private ColumnHeader colQty3;
        private ColumnHeader colLotType;
        private ColumnHeader colOwnerCode;
        private ColumnHeader colCreateCode;
        private ColumnHeader colPriority;
        private ColumnHeader colLotStatus;
        private ColumnHeader colHoldFlag;
        private ColumnHeader colHoldCode;
        private ColumnHeader colCreateQty1;
        private ColumnHeader colCreateQty2;
        private ColumnHeader colCreateQty3;
        private ColumnHeader colOperInQty1;
        private ColumnHeader colOperInQty2;
        private ColumnHeader colOperInQty3;
        private ColumnHeader colInvFlag;
        private ColumnHeader colTransitFlag;
        private ColumnHeader colUnitExistFlag;
        private ColumnHeader colInvUnit;
        private ColumnHeader colRwkFlag;
        private ColumnHeader colRwkCode;
        private ColumnHeader colRwkCount;
        private ColumnHeader colRwkRetFlow;
        private ColumnHeader colRwkRetOper;
        private ColumnHeader colRwkEndFlow;
        private ColumnHeader colRwkEndOper;
        private ColumnHeader colRwkRetClearFlag;
        private ColumnHeader colRwkTime;
        private ColumnHeader colNstdFlag;
        private ColumnHeader colNstdRetFlow;
        private ColumnHeader colNstdRetOper;
        private ColumnHeader colNstdTime;
        private ColumnHeader colRepFlag;
        private ColumnHeader colRepOper;
        private ColumnHeader colStrRetFlow;
        private ColumnHeader colStrRetFlowSeq;
        private ColumnHeader colStrRetOper;
        private ColumnHeader colStartFlag;
        private ColumnHeader colStartTime;
        private ColumnHeader colStartResID;
        private ColumnHeader colEndFlag;
        private ColumnHeader colEndTime;
        private ColumnHeader colEndResID;
        private ColumnHeader colSampleFlag;
        private ColumnHeader colSampleWaitFlag;
        private ColumnHeader colSampleResult;
        private ColumnHeader colSplitFromLotID;
        private ColumnHeader colShipCode;
        private ColumnHeader colShipTime;
        private ColumnHeader colOrgDueTime;
        private ColumnHeader colSchDueTime;
        private ColumnHeader colCreateTime;
        private ColumnHeader colFactoryInTime;
        private ColumnHeader colFlowInTime;
        private ColumnHeader colOperInTime;
        private ColumnHeader colResvResID;
        private ColumnHeader colBatchID;
        private ColumnHeader colBatchSeq;
        private ColumnHeader colOrderID;
        private ColumnHeader colAddOrder1;
        private ColumnHeader colAddOrder2;
        private ColumnHeader colAddOrder3;
        private ColumnHeader colLocation;
        private ColumnHeader colLotCmf1;
        private ColumnHeader colLotCmf2;
        private ColumnHeader colLotCmf3;
        private ColumnHeader colLotCmf4;
        private ColumnHeader colLotCmf5;
        private ColumnHeader colLotCmf6;
        private ColumnHeader colLotCmf7;
        private ColumnHeader colLotCmf8;
        private ColumnHeader colLotCmf9;
        private ColumnHeader colLotCmf10;
        private ColumnHeader colLotCmf11;
        private ColumnHeader colLotCmf12;
        private ColumnHeader colLotCmf13;
        private ColumnHeader colLotCmf14;
        private ColumnHeader colLotCmf15;
        private ColumnHeader colLotCmf16;
        private ColumnHeader colLotCmf17;
        private ColumnHeader colLotCmf18;
        private ColumnHeader colLotCmf19;
        private ColumnHeader colLotCmf20;
        private ColumnHeader colBomSetID;
        private ColumnHeader colBomSetVersion;
        private ColumnHeader colBomActiveSeq;
        private ColumnHeader colBomHistSeq;
        private ColumnHeader colLotDelFlag;
        private ColumnHeader colLotDelTime;
        private ColumnHeader colLotDelReason;
        private ColumnHeader colLastTranCode;
        private ColumnHeader colLastTranTime;
        private ColumnHeader colLastComment;
        private ColumnHeader colLastActiveHistSeq;
        private ColumnHeader colLastHistSeq;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        public System.Windows.Forms.Button btnExcel;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCViewLotListbyOperation));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.chkTerminatedLot = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkZeroQtyLot = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblOperGroup = new System.Windows.Forms.Label();
            this.cdvGroup1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroupType1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
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
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTerminatedLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeroQtyLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroupType1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            this.pnlMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(8, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(558, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(650, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpTop);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTop.Size = new System.Drawing.Size(742, 95);
            this.pnlTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.cdvFlow);
            this.grpTop.Controls.Add(this.cdvMaterial);
            this.grpTop.Controls.Add(this.chkTerminatedLot);
            this.grpTop.Controls.Add(this.chkZeroQtyLot);
            this.grpTop.Controls.Add(this.lblOperGroup);
            this.grpTop.Controls.Add(this.cdvGroup1);
            this.grpTop.Controls.Add(this.cdvGroupType1);
            this.grpTop.Controls.Add(this.cdvOperation);
            this.grpTop.Controls.Add(this.lblOperation);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(736, 95);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // chkTerminatedLot
            // 
            this.chkTerminatedLot.AutoSize = true;
            this.chkTerminatedLot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTerminatedLot.Location = new System.Drawing.Point(564, 64);
            this.chkTerminatedLot.Name = "chkTerminatedLot";
            this.chkTerminatedLot.Size = new System.Drawing.Size(154, 17);
            this.chkTerminatedLot.TabIndex = 8;
            this.chkTerminatedLot.Text = "Include Terminated Lot";
            this.chkTerminatedLot.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkZeroQtyLot
            // 
            this.chkZeroQtyLot.AutoSize = true;
            this.chkZeroQtyLot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkZeroQtyLot.Location = new System.Drawing.Point(564, 40);
            this.chkZeroQtyLot.Name = "chkZeroQtyLot";
            this.chkZeroQtyLot.Size = new System.Drawing.Size(122, 17);
            this.chkZeroQtyLot.TabIndex = 7;
            this.chkZeroQtyLot.Text = "Zero Quantity Lot";
            this.chkZeroQtyLot.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblOperGroup
            // 
            this.lblOperGroup.AutoSize = true;
            this.lblOperGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperGroup.Location = new System.Drawing.Point(340, 16);
            this.lblOperGroup.Name = "lblOperGroup";
            this.lblOperGroup.Size = new System.Drawing.Size(85, 13);
            this.lblOperGroup.TabIndex = 4;
            this.lblOperGroup.Text = "Operation Group";
            this.lblOperGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvGroup1
            // 
            this.cdvGroup1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup1.BtnToolTipText = "";
            this.cdvGroup1.DescText = "";
            this.cdvGroup1.DisplaySubItemIndex = -1;
            this.cdvGroup1.DisplayText = "";
            this.cdvGroup1.Focusing = null;
            this.cdvGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup1.Index = 0;
            this.cdvGroup1.IsViewBtnImage = false;
            this.cdvGroup1.Location = new System.Drawing.Point(340, 61);
            this.cdvGroup1.MaxLength = 30;
            this.cdvGroup1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = true;
            this.cdvGroup1.SearchSubItemIndex = 0;
            this.cdvGroup1.SelectedDescIndex = -1;
            this.cdvGroup1.SelectedSubItemIndex = -1;
            this.cdvGroup1.SelectionStart = 0;
            this.cdvGroup1.Size = new System.Drawing.Size(192, 20);
            this.cdvGroup1.SmallImageList = null;
            this.cdvGroup1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup1.TabIndex = 6;
            this.cdvGroup1.TextBoxToolTipText = "";
            this.cdvGroup1.TextBoxWidth = 192;
            this.cdvGroup1.VisibleButton = true;
            this.cdvGroup1.VisibleColumnHeader = false;
            this.cdvGroup1.VisibleDescription = false;
            this.cdvGroup1.ButtonPress += new System.EventHandler(this.cdvGroup1_ButtonPress);
            // 
            // cdvGroupType1
            // 
            this.cdvGroupType1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroupType1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroupType1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroupType1.BtnToolTipText = "";
            this.cdvGroupType1.DescText = "";
            this.cdvGroupType1.DisplaySubItemIndex = -1;
            this.cdvGroupType1.DisplayText = "";
            this.cdvGroupType1.Focusing = null;
            this.cdvGroupType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroupType1.Index = 0;
            this.cdvGroupType1.IsViewBtnImage = false;
            this.cdvGroupType1.Location = new System.Drawing.Point(340, 37);
            this.cdvGroupType1.MaxLength = 20;
            this.cdvGroupType1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroupType1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroupType1.Name = "cdvGroupType1";
            this.cdvGroupType1.ReadOnly = true;
            this.cdvGroupType1.SearchSubItemIndex = 0;
            this.cdvGroupType1.SelectedDescIndex = -1;
            this.cdvGroupType1.SelectedSubItemIndex = -1;
            this.cdvGroupType1.SelectionStart = 0;
            this.cdvGroupType1.Size = new System.Drawing.Size(192, 20);
            this.cdvGroupType1.SmallImageList = null;
            this.cdvGroupType1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroupType1.TabIndex = 5;
            this.cdvGroupType1.TextBoxToolTipText = "";
            this.cdvGroupType1.TextBoxWidth = 192;
            this.cdvGroupType1.VisibleButton = true;
            this.cdvGroupType1.VisibleColumnHeader = false;
            this.cdvGroupType1.VisibleDescription = false;
            this.cdvGroupType1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGroupType1_SelectedItemChanged);
            this.cdvGroupType1.ButtonPress += new System.EventHandler(this.cdvGroupType_ButtonPress);
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
            this.cdvOperation.Location = new System.Drawing.Point(117, 61);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(192, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 3;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 192;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(9, 64);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(100, 14);
            this.lblOperation.TabIndex = 2;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.lisLotList);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 95);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlMid.Size = new System.Drawing.Size(742, 418);
            this.pnlMid.TabIndex = 1;
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
            this.lisLotList.Location = new System.Drawing.Point(3, 3);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(736, 415);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 50;
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
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 108;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(9, 37);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(299, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 191;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            this.cdvFlow.FlowTextChanged += new System.EventHandler(this.cdvFlow_TextBoxTextChanged);
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
            this.cdvMaterial.Location = new System.Drawing.Point(9, 13);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(299, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 108;
            this.cdvMaterial.WidthMaterialAndVersion = 191;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_MaterialSelectedItemChanged);
            this.cdvMaterial.MaterialTextChanged += new System.EventHandler(this.cdvMaterial_MaterialTextBoxTextChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_VersionSelectedItemChanged);
            this.cdvMaterial.VersionChanged += new System.EventHandler(this.cdvMaterial_VersionTextBoxTextChanged);
            // 
            // frmSPCViewLotListbyOperation
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCViewLotListbyOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "View Lot List by Operation";
            this.Activated += new System.EventHandler(this.frmSPCViewLotListbyOperation_Activated);
            this.Closed += new System.EventHandler(this.frmSPCViewLotListbyOperation_Closed);
            this.Load += new System.EventHandler(this.frmSPCViewLotListbyOperation_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTerminatedLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZeroQtyLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroupType1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            this.pnlMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        private string[] sGroupTableName = new string[10];
        
        #endregion
        
        #region " Function Definition "
        
        // SetTableName()
        //       - Set Operation Group Table Name
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetTableName()
        {
            
            try
            {
                sGroupTableName[0] = MPGC.MP_GCM_OPER_GRP_1;
                sGroupTableName[1] = MPGC.MP_GCM_OPER_GRP_2;
                sGroupTableName[2] = MPGC.MP_GCM_OPER_GRP_3;
                sGroupTableName[3] = MPGC.MP_GCM_OPER_GRP_4;
                sGroupTableName[4] = MPGC.MP_GCM_OPER_GRP_5;
                sGroupTableName[5] = MPGC.MP_GCM_OPER_GRP_6;
                sGroupTableName[6] = MPGC.MP_GCM_OPER_GRP_7;
                sGroupTableName[7] = MPGC.MP_GCM_OPER_GRP_8;
                sGroupTableName[8] = MPGC.MP_GCM_OPER_GRP_9;
                sGroupTableName[9] = MPGC.MP_GCM_OPER_GRP_10;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.SetTableName()\n" + ex.Message);
            }
            
        }
        
        // SetOperGroupPrompt()
        //       - Set Group Property to control
        // Return Value
        //       -
        // Arguments
        //        - ByVal cdvList As Miracom.UI.Controls.MCCodeView.MCCodeView
        //
        private bool SetOperGroupPrompt(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ListViewItem itmx = null;
            int i;

            try
            {
                cdvList.Items.Clear();

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_OPERATION, ref out_node, "", true) == false)
                {
                    return false;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")), (int)SMALLICON_INDEX.IDX_CODE_DATA);

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")) == "")
                        {
                            itmx.SubItems.Add(sGroupTableName[i]);
                        }
                        else
                        {
                            itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                        }
                        cdvList.Items.Add(itmx);
                    }
                }
                cdvList.AddEmptyRow(1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.SetOperGroupPrompt()\n" + ex.Message);
                return false;
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
        private bool View_Lot_List()
        {
            TRSNode in_node = new TRSNode("View_Lot_List_In");
            TRSNode out_node;
            ArrayList a_list = new ArrayList();
            int i;

            MPCF.ClearList(lisLotList, true);
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
                in_node.AddString("GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("TABLE_NAME_1", MPCF.Trim(cdvGroupType1.Text));
                in_node.AddChar("ZERO_QTY_FLAG", (chkZeroQtyLot.Checked == true ? 'Y' : ' '));
                in_node.AddChar("LOT_DEL_FLAG", (chkTerminatedLot.Checked == true ? 'Y' : ' '));
                
        
                do
                {
                    out_node = new TRSNode("View_Lot_List_Out");
                    if (MPCR.CallService("WIP", "WIP_View_Lot_List_By_Operation", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        WIPLIST.DisplayLotListDetail(lisLotList, out_node.GetList(0)[i], 0);
                    }

                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));

                } while (in_node.GetString("NEXT_LOT_ID") != "");
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.View_Lot_List()\n" + ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvMaterial;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCViewLotListbyOperation_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.FieldClear(this);
                    MPCF.InitListView(lisLotList);
                    SetTableName();
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.frmSPCViewLotListbyOperation_Activated()\n" + ex.Message);
            }
            
        }
        
        private void cdvGroupType_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvGroupType1.Init();
                MPCF.InitListView(cdvGroupType1.GetListView);
                cdvGroupType1.Columns.Add("Group", 50, HorizontalAlignment.Left);
                cdvGroupType1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvGroupType1.SelectedSubItemIndex = 1;
                cdvGroupType1.DisplaySubItemIndex = 0;
                cdvGroupType1.ReadOnly = true;
                SetOperGroupPrompt((Miracom.UI.Controls.MCCodeView.MCCodeView)sender);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvGroupType_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvGroup1_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvGroupType1.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvGroupType1.Focus();
                    cdvGroup1.IsPopup = false;
                    return;
                }
                
                cdvGroup1.Init();
                MPCF.InitListView(cdvGroup1.GetListView);
                cdvGroup1.Columns.Add("Group", 50, HorizontalAlignment.Left);
                cdvGroup1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvGroup1.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvGroup1.GetListView, '1', cdvGroupType1.Text) == false)
                {
                    return;
                }
                cdvGroup1.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvGroup1_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                cdvOperation.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvFlow_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvMaterial.Text == "")
                {
                    cdvFlow.ListCond_Step = '1';
                }
                else
                {
                    cdvFlow.ListCond_Step = '2';
                    cdvFlow.ListCond_MatID = cdvMaterial.Text;
                    cdvFlow.ListCond_MatVersion = cdvMaterial.Version;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvFlow_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvOperation.Init();
                MPCF.InitListView(cdvOperation.GetListView);
                cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOperation.SelectedSubItemIndex = 0;
                if (cdvMaterial.Text != "" && cdvFlow.Text != "")
                {
                    WIPLIST.ViewOperationList(cdvOperation.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "");
                }
                else
                {
                    if (cdvFlow.Text == "")
                    {
                        if (cdvMaterial.Text == "")
                        {
                            WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0,"", "", null, "");
                        }
                        else
                        {
                            WIPLIST.ViewOperationList(cdvOperation.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, "", "", null, "");
                        }
                    }
                    else
                    {
                        WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0,cdvFlow.Text, "", null, "");
                    }
                }
                cdvOperation.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvOperation_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvOperation.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvOperation.Focus();
                    return;
                }
                View_Lot_List();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCViewLotListbyOperation_Closed(object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.frmSPCViewLotListbyOperation_Closed()\n" + ex.Message);
            }
            
        }
        
        
        private void cdvFlow_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvOperation.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvFlow_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCViewLotListbyOperation_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.frmSPCViewLotListbyOperation_Load()\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sCond;

                sCond = "Operation : " + MPCF.Trim(cdvOperation.DisplayText);

                if (MPCF.ExportToExcel(lisLotList, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.btnExcel_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvGroupType1_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvGroup1.DisplayText = "";
            cdvGroup1.Text = "";
        }
        
        #endregion

        private void cdvMaterial_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                cdvFlow.Text = "";
                cdvOperation.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvMaterial_MaterialSelectedItemChanged()\n" + ex.Message);
            }
        }

        private void cdvMaterial_MaterialTextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                cdvFlow.Text = "";
                cdvOperation.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvMaterial_TextBoxTextChanged()\n" + ex.Message);
            }
        }

        private void cdvMaterial_VersionSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                cdvFlow.Text = "";
                cdvOperation.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvMaterial_VersionSelectedItemChanged()\n" + ex.Message);
            }
        }

        private void cdvMaterial_VersionTextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                cdvFlow.Text = "";
                cdvOperation.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewLotListbyOperation.cdvMaterial_VersionTextBoxTextChanged()\n" + ex.Message);
            }
        }
        
    }
    
    
    //#End If
    
}
