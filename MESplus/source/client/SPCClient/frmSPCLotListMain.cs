#define _ORD
#define _POP
#define _SPC
#define _RMS
#define _CRR
#define _ALM
#define _INV
#define _TOOL
#define _BOM
#define _QCM
#define _UTL
#define _RTD
#define _RCP
#define _EDC
#define _RAS

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.UTLCore;
using Miracom.SPCCore;
using Miracom.TRSCore;


//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCLotListMain.vb
//   Description : View Lot List
//
//   SPC Version : 1.0.0
//
//   Function List
//       - View_Lot_List : View Lot List By Operation Condition
//       - SetOperation : Setting Operation at "frmMIDMain"
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCClient
{
    public class frmSPCLotListMain : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCLotListMain()
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

        
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnExcel;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnClose;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvMatId;
        internal System.Windows.Forms.Label lblTotQty;
        internal System.Windows.Forms.Label lblTotLot;
        internal System.Windows.Forms.Label lblFlow;
        internal System.Windows.Forms.Label lblMaterial;
        internal System.Windows.Forms.Panel pnlMid;
        internal System.Windows.Forms.ListView lisLotList;
        internal System.Windows.Forms.ColumnHeader colSeq;
        internal System.Windows.Forms.ColumnHeader colLotID;
        internal System.Windows.Forms.ColumnHeader colMaterial;
        internal System.Windows.Forms.ColumnHeader colFlow;
        internal System.Windows.Forms.ColumnHeader colOperation;
        internal System.Windows.Forms.ColumnHeader colQty1;
        internal System.Windows.Forms.ColumnHeader colQty2;
        internal System.Windows.Forms.ColumnHeader colQty3;
        internal System.Windows.Forms.ColumnHeader colLotType;
        internal System.Windows.Forms.ColumnHeader colOwnerCode;
        internal System.Windows.Forms.ColumnHeader colCreateCode;
        internal System.Windows.Forms.ColumnHeader colPriority;
        internal System.Windows.Forms.ColumnHeader colLotStatus;
        internal System.Windows.Forms.ColumnHeader colHoldFlag;
        internal System.Windows.Forms.ColumnHeader colHoldCode;
        internal System.Windows.Forms.ColumnHeader colCreateQty1;
        internal System.Windows.Forms.ColumnHeader colCreateQty2;
        internal System.Windows.Forms.ColumnHeader colCreateQty3;
        internal System.Windows.Forms.ColumnHeader colOperInQty1;
        internal System.Windows.Forms.ColumnHeader colOperInQty2;
        internal System.Windows.Forms.ColumnHeader colOperInQty3;
        internal System.Windows.Forms.ColumnHeader colInvFlag;
        internal System.Windows.Forms.ColumnHeader colTransitFlag;
        internal System.Windows.Forms.ColumnHeader colUnitExistFlag;
        internal System.Windows.Forms.ColumnHeader colInvUnit;
        internal System.Windows.Forms.ColumnHeader colRwkFlag;
        internal System.Windows.Forms.ColumnHeader colRwkCode;
        internal System.Windows.Forms.ColumnHeader colRwkCount;
        internal System.Windows.Forms.ColumnHeader colRwkRetFlow;
        internal System.Windows.Forms.ColumnHeader colRwkRetOper;
        internal System.Windows.Forms.ColumnHeader colRwkEndFlow;
        internal System.Windows.Forms.ColumnHeader colRwkEndOper;
        internal System.Windows.Forms.ColumnHeader colRwkRetClearFlag;
        internal System.Windows.Forms.ColumnHeader colRwkTime;
        internal System.Windows.Forms.ColumnHeader colNstdFlag;
        internal System.Windows.Forms.ColumnHeader colNstdRetFlow;
        internal System.Windows.Forms.ColumnHeader colNstdRetOper;
        internal System.Windows.Forms.ColumnHeader colNstdTime;
        internal System.Windows.Forms.ColumnHeader colStartFlag;
        internal System.Windows.Forms.ColumnHeader colStartTime;
        internal System.Windows.Forms.ColumnHeader colStartResID;
        internal System.Windows.Forms.ColumnHeader colEndFlag;
        internal System.Windows.Forms.ColumnHeader colEndTime;
        internal System.Windows.Forms.ColumnHeader colEndResID;
        internal System.Windows.Forms.ColumnHeader colSampleFlag;
        internal System.Windows.Forms.ColumnHeader colSampleWaitFlag;
        internal System.Windows.Forms.ColumnHeader colSampleResult;
        internal System.Windows.Forms.ColumnHeader colSplitFromLotID;
        internal System.Windows.Forms.ColumnHeader colShipCode;
        internal System.Windows.Forms.ColumnHeader colShipTime;
        internal System.Windows.Forms.ColumnHeader colOrgDueTime;
        internal System.Windows.Forms.ColumnHeader colSchDueTime;
        internal System.Windows.Forms.ColumnHeader colCreateTime;
        internal System.Windows.Forms.ColumnHeader colFactoryInTime;
        internal System.Windows.Forms.ColumnHeader colFlowInTime;
        internal System.Windows.Forms.ColumnHeader colOperInTime;
        internal System.Windows.Forms.ColumnHeader colResvResID;
        internal System.Windows.Forms.ColumnHeader colBatchID;
        internal System.Windows.Forms.ColumnHeader colBatchSeq;
        internal System.Windows.Forms.ColumnHeader colOrderID;
        internal System.Windows.Forms.ColumnHeader colAddOrder1;
        internal System.Windows.Forms.ColumnHeader colAddOrder2;
        internal System.Windows.Forms.ColumnHeader colAddOrder3;
        internal System.Windows.Forms.ColumnHeader colLocation;
        internal System.Windows.Forms.ColumnHeader colLotCmf1;
        internal System.Windows.Forms.ColumnHeader colLotCmf2;
        internal System.Windows.Forms.ColumnHeader colLotCmf3;
        internal System.Windows.Forms.ColumnHeader colLotCmf4;
        internal System.Windows.Forms.ColumnHeader colLotCmf5;
        internal System.Windows.Forms.ColumnHeader colLotCmf6;
        internal System.Windows.Forms.ColumnHeader colLotCmf7;
        internal System.Windows.Forms.ColumnHeader colLotCmf8;
        internal System.Windows.Forms.ColumnHeader colLotCmf9;
        internal System.Windows.Forms.ColumnHeader colLotCmf10;
        internal System.Windows.Forms.ColumnHeader colLotCmf11;
        internal System.Windows.Forms.ColumnHeader colLotCmf12;
        internal System.Windows.Forms.ColumnHeader colLotCmf13;
        internal System.Windows.Forms.ColumnHeader colLotCmf14;
        internal System.Windows.Forms.ColumnHeader colLotCmf15;
        internal System.Windows.Forms.ColumnHeader colLotCmf16;
        internal System.Windows.Forms.ColumnHeader colLotCmf17;
        internal System.Windows.Forms.ColumnHeader colLotCmf18;
        internal System.Windows.Forms.ColumnHeader colLotCmf19;
        internal System.Windows.Forms.ColumnHeader colLotCmf20;
        internal System.Windows.Forms.ColumnHeader colBomSetID;
        internal System.Windows.Forms.ColumnHeader colBomSetVersion;
        internal System.Windows.Forms.ColumnHeader colBomActiveSeq;
        internal System.Windows.Forms.ColumnHeader colBomHistSeq;
        internal System.Windows.Forms.ColumnHeader colLotDelFlag;
        internal System.Windows.Forms.ColumnHeader colLotDelTime;
        internal System.Windows.Forms.ColumnHeader colLotDelReason;
        internal System.Windows.Forms.ColumnHeader colLastTranCode;
        internal System.Windows.Forms.ColumnHeader colLastTranTime;
        internal System.Windows.Forms.ColumnHeader colLastComment;
        internal System.Windows.Forms.ColumnHeader colLastActiveHistSeq;
        internal System.Windows.Forms.ColumnHeader colLastHistSeq;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAutoRefresh;
        internal System.Windows.Forms.Timer tmrTimer;
        internal System.Windows.Forms.Label lblAutoRefresh;
        internal System.Windows.Forms.Label lblTotalQty;
        private ColumnHeader colMatVer;
        private ColumnHeader colFlowSeq;
        internal System.Windows.Forms.Label lblTotalLot;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCLotListMain));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblAutoRefresh = new System.Windows.Forms.Label();
            this.chkAutoRefresh = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.lblTotalLot = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvMatId = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTotQty = new System.Windows.Forms.Label();
            this.lblTotLot = new System.Windows.Forms.Label();
            this.lblFlow = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.lisLotList = new System.Windows.Forms.ListView();
            this.colSeq = new System.Windows.Forms.ColumnHeader();
            this.colLotID = new System.Windows.Forms.ColumnHeader();
            this.colMaterial = new System.Windows.Forms.ColumnHeader();
            this.colFlow = new System.Windows.Forms.ColumnHeader();
            this.colOperation = new System.Windows.Forms.ColumnHeader();
            this.colQty1 = new System.Windows.Forms.ColumnHeader();
            this.colQty2 = new System.Windows.Forms.ColumnHeader();
            this.colQty3 = new System.Windows.Forms.ColumnHeader();
            this.colLotType = new System.Windows.Forms.ColumnHeader();
            this.colOwnerCode = new System.Windows.Forms.ColumnHeader();
            this.colCreateCode = new System.Windows.Forms.ColumnHeader();
            this.colPriority = new System.Windows.Forms.ColumnHeader();
            this.colLotStatus = new System.Windows.Forms.ColumnHeader();
            this.colHoldFlag = new System.Windows.Forms.ColumnHeader();
            this.colHoldCode = new System.Windows.Forms.ColumnHeader();
            this.colCreateQty1 = new System.Windows.Forms.ColumnHeader();
            this.colCreateQty2 = new System.Windows.Forms.ColumnHeader();
            this.colCreateQty3 = new System.Windows.Forms.ColumnHeader();
            this.colOperInQty1 = new System.Windows.Forms.ColumnHeader();
            this.colOperInQty2 = new System.Windows.Forms.ColumnHeader();
            this.colOperInQty3 = new System.Windows.Forms.ColumnHeader();
            this.colInvFlag = new System.Windows.Forms.ColumnHeader();
            this.colTransitFlag = new System.Windows.Forms.ColumnHeader();
            this.colUnitExistFlag = new System.Windows.Forms.ColumnHeader();
            this.colInvUnit = new System.Windows.Forms.ColumnHeader();
            this.colRwkFlag = new System.Windows.Forms.ColumnHeader();
            this.colRwkCode = new System.Windows.Forms.ColumnHeader();
            this.colRwkCount = new System.Windows.Forms.ColumnHeader();
            this.colRwkRetFlow = new System.Windows.Forms.ColumnHeader();
            this.colRwkRetOper = new System.Windows.Forms.ColumnHeader();
            this.colRwkEndFlow = new System.Windows.Forms.ColumnHeader();
            this.colRwkEndOper = new System.Windows.Forms.ColumnHeader();
            this.colRwkRetClearFlag = new System.Windows.Forms.ColumnHeader();
            this.colRwkTime = new System.Windows.Forms.ColumnHeader();
            this.colNstdFlag = new System.Windows.Forms.ColumnHeader();
            this.colNstdRetFlow = new System.Windows.Forms.ColumnHeader();
            this.colNstdRetOper = new System.Windows.Forms.ColumnHeader();
            this.colNstdTime = new System.Windows.Forms.ColumnHeader();
            this.colStartFlag = new System.Windows.Forms.ColumnHeader();
            this.colStartTime = new System.Windows.Forms.ColumnHeader();
            this.colStartResID = new System.Windows.Forms.ColumnHeader();
            this.colEndFlag = new System.Windows.Forms.ColumnHeader();
            this.colEndTime = new System.Windows.Forms.ColumnHeader();
            this.colEndResID = new System.Windows.Forms.ColumnHeader();
            this.colSampleFlag = new System.Windows.Forms.ColumnHeader();
            this.colSampleWaitFlag = new System.Windows.Forms.ColumnHeader();
            this.colSampleResult = new System.Windows.Forms.ColumnHeader();
            this.colSplitFromLotID = new System.Windows.Forms.ColumnHeader();
            this.colShipCode = new System.Windows.Forms.ColumnHeader();
            this.colShipTime = new System.Windows.Forms.ColumnHeader();
            this.colOrgDueTime = new System.Windows.Forms.ColumnHeader();
            this.colSchDueTime = new System.Windows.Forms.ColumnHeader();
            this.colCreateTime = new System.Windows.Forms.ColumnHeader();
            this.colFactoryInTime = new System.Windows.Forms.ColumnHeader();
            this.colFlowInTime = new System.Windows.Forms.ColumnHeader();
            this.colOperInTime = new System.Windows.Forms.ColumnHeader();
            this.colResvResID = new System.Windows.Forms.ColumnHeader();
            this.colBatchID = new System.Windows.Forms.ColumnHeader();
            this.colBatchSeq = new System.Windows.Forms.ColumnHeader();
            this.colOrderID = new System.Windows.Forms.ColumnHeader();
            this.colAddOrder1 = new System.Windows.Forms.ColumnHeader();
            this.colAddOrder2 = new System.Windows.Forms.ColumnHeader();
            this.colAddOrder3 = new System.Windows.Forms.ColumnHeader();
            this.colLocation = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf1 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf2 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf3 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf4 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf5 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf6 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf7 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf8 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf9 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf10 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf11 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf12 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf13 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf14 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf15 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf16 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf17 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf18 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf19 = new System.Windows.Forms.ColumnHeader();
            this.colLotCmf20 = new System.Windows.Forms.ColumnHeader();
            this.colBomSetID = new System.Windows.Forms.ColumnHeader();
            this.colBomSetVersion = new System.Windows.Forms.ColumnHeader();
            this.colBomActiveSeq = new System.Windows.Forms.ColumnHeader();
            this.colBomHistSeq = new System.Windows.Forms.ColumnHeader();
            this.colLotDelFlag = new System.Windows.Forms.ColumnHeader();
            this.colLotDelTime = new System.Windows.Forms.ColumnHeader();
            this.colLotDelReason = new System.Windows.Forms.ColumnHeader();
            this.colLastTranCode = new System.Windows.Forms.ColumnHeader();
            this.colLastTranTime = new System.Windows.Forms.ColumnHeader();
            this.colLastComment = new System.Windows.Forms.ColumnHeader();
            this.colLastActiveHistSeq = new System.Windows.Forms.ColumnHeader();
            this.colLastHistSeq = new System.Windows.Forms.ColumnHeader();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.colMatVer = new System.Windows.Forms.ColumnHeader();
            this.colFlowSeq = new System.Windows.Forms.ColumnHeader();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatId)).BeginInit();
            this.pnlMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblAutoRefresh);
            this.pnlBottom.Controls.Add(this.chkAutoRefresh);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.lblTotalQty);
            this.pnlBottom.Controls.Add(this.lblTotalLot);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.cdvFlow);
            this.pnlBottom.Controls.Add(this.cdvMatId);
            this.pnlBottom.Controls.Add(this.lblTotQty);
            this.pnlBottom.Controls.Add(this.lblTotLot);
            this.pnlBottom.Controls.Add(this.lblFlow);
            this.pnlBottom.Controls.Add(this.lblMaterial);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 494);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 52);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblAutoRefresh
            // 
            this.lblAutoRefresh.Location = new System.Drawing.Point(276, 31);
            this.lblAutoRefresh.Name = "lblAutoRefresh";
            this.lblAutoRefresh.Size = new System.Drawing.Size(72, 14);
            this.lblAutoRefresh.TabIndex = 9;
            this.lblAutoRefresh.Text = "Auto Refresh";
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.Enabled = false;
            this.chkAutoRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoRefresh.Location = new System.Drawing.Point(256, 31);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(16, 14);
            this.chkAutoRefresh.TabIndex = 8;
            this.chkAutoRefresh.Text = "Auto Refresh";
            this.chkAutoRefresh.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(386, 24);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(356, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalQty.Location = new System.Drawing.Point(458, 7);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(96, 13);
            this.lblTotalQty.TabIndex = 5;
            this.lblTotalQty.Text = "Tot Qty";
            // 
            // lblTotalLot
            // 
            this.lblTotalLot.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalLot.Location = new System.Drawing.Point(310, 7);
            this.lblTotalLot.Name = "lblTotalLot";
            this.lblTotalLot.Size = new System.Drawing.Size(50, 13);
            this.lblTotalLot.TabIndex = 3;
            this.lblTotalLot.Text = "Tot Lot";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(648, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cdvFlow
            // 
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = -1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(96, 28);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(148, 21);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cdvFlow.TabIndex = 7;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 148;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            this.cdvFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            // 
            // cdvMatId
            // 
            this.cdvMatId.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMatId.BtnToolTipText = "";
            this.cdvMatId.DescText = "";
            this.cdvMatId.DisplaySubItemIndex = -1;
            this.cdvMatId.DisplayText = "";
            this.cdvMatId.Focusing = null;
            this.cdvMatId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatId.Index = 0;
            this.cdvMatId.IsViewBtnImage = false;
            this.cdvMatId.Location = new System.Drawing.Point(96, 4);
            this.cdvMatId.MaxLength = 30;
            this.cdvMatId.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatId.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMatId.Name = "cdvMatId";
            this.cdvMatId.ReadOnly = false;
            this.cdvMatId.SearchSubItemIndex = 0;
            this.cdvMatId.SelectedDescIndex = -1;
            this.cdvMatId.SelectedSubItemIndex = -1;
            this.cdvMatId.SelectionStart = 0;
            this.cdvMatId.Size = new System.Drawing.Size(148, 21);
            this.cdvMatId.SmallImageList = null;
            this.cdvMatId.StyleBorder = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cdvMatId.TabIndex = 1;
            this.cdvMatId.TextBoxToolTipText = "";
            this.cdvMatId.TextBoxWidth = 148;
            this.cdvMatId.VisibleButton = true;
            this.cdvMatId.VisibleColumnHeader = false;
            this.cdvMatId.VisibleDescription = false;
            this.cdvMatId.ButtonPress += new System.EventHandler(this.cdvMatID_ButtonPress);
            this.cdvMatId.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatId_SelectedItemChanged);
            // 
            // lblTotQty
            // 
            this.lblTotQty.AutoSize = true;
            this.lblTotQty.Location = new System.Drawing.Point(366, 6);
            this.lblTotQty.Name = "lblTotQty";
            this.lblTotQty.Size = new System.Drawing.Size(79, 13);
            this.lblTotQty.TabIndex = 4;
            this.lblTotQty.Text = "Tot Qty 1/2/3 :";
            this.lblTotQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotLot
            // 
            this.lblTotLot.AutoSize = true;
            this.lblTotLot.Location = new System.Drawing.Point(256, 6);
            this.lblTotLot.Name = "lblTotLot";
            this.lblTotLot.Size = new System.Drawing.Size(47, 13);
            this.lblTotLot.TabIndex = 2;
            this.lblTotLot.Text = "Tot Lot :";
            this.lblTotLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFlow
            // 
            this.lblFlow.Location = new System.Drawing.Point(8, 31);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(86, 14);
            this.lblFlow.TabIndex = 6;
            this.lblFlow.Text = "Flow";
            // 
            // lblMaterial
            // 
            this.lblMaterial.Location = new System.Drawing.Point(8, 7);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(86, 14);
            this.lblMaterial.TabIndex = 0;
            this.lblMaterial.Text = "Material";
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.lisLotList);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 0);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMid.Size = new System.Drawing.Size(742, 494);
            this.pnlMid.TabIndex = 0;
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colLotID,
            this.colMaterial,
            this.colFlow,
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
            this.colLastHistSeq,
            this.colMatVer,
            this.colFlowSeq});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.FullRowSelect = true;
            this.lisLotList.Location = new System.Drawing.Point(3, 3);
            this.lisLotList.MultiSelect = false;
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(736, 488);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            this.lisLotList.Click += new System.EventHandler(this.lisLotList_Click);
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
            // colFlow
            // 
            this.colFlow.DisplayIndex = 4;
            this.colFlow.Text = "Flow";
            this.colFlow.Width = 90;
            // 
            // colOperation
            // 
            this.colOperation.DisplayIndex = 6;
            this.colOperation.Text = "Operation";
            this.colOperation.Width = 80;
            // 
            // colQty1
            // 
            this.colQty1.DisplayIndex = 7;
            this.colQty1.Text = "Qty 1";
            this.colQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colQty2
            // 
            this.colQty2.DisplayIndex = 8;
            this.colQty2.Text = "Qty 2";
            this.colQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colQty3
            // 
            this.colQty3.DisplayIndex = 9;
            this.colQty3.Text = "Qty3";
            this.colQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colLotType
            // 
            this.colLotType.DisplayIndex = 10;
            this.colLotType.Text = "Lot Type";
            this.colLotType.Width = 70;
            // 
            // colOwnerCode
            // 
            this.colOwnerCode.DisplayIndex = 11;
            this.colOwnerCode.Text = "Owner Code";
            this.colOwnerCode.Width = 90;
            // 
            // colCreateCode
            // 
            this.colCreateCode.DisplayIndex = 12;
            this.colCreateCode.Text = "Create Code";
            this.colCreateCode.Width = 90;
            // 
            // colPriority
            // 
            this.colPriority.DisplayIndex = 13;
            this.colPriority.Text = "Priority";
            // 
            // colLotStatus
            // 
            this.colLotStatus.DisplayIndex = 14;
            this.colLotStatus.Text = "Lot Status";
            this.colLotStatus.Width = 80;
            // 
            // colHoldFlag
            // 
            this.colHoldFlag.DisplayIndex = 15;
            this.colHoldFlag.Text = "Hold Flag";
            this.colHoldFlag.Width = 80;
            // 
            // colHoldCode
            // 
            this.colHoldCode.DisplayIndex = 16;
            this.colHoldCode.Text = "Hold Code";
            this.colHoldCode.Width = 80;
            // 
            // colCreateQty1
            // 
            this.colCreateQty1.DisplayIndex = 17;
            this.colCreateQty1.Text = "Create Qty 1";
            this.colCreateQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCreateQty1.Width = 100;
            // 
            // colCreateQty2
            // 
            this.colCreateQty2.DisplayIndex = 18;
            this.colCreateQty2.Text = "Create Qty 2";
            this.colCreateQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCreateQty2.Width = 100;
            // 
            // colCreateQty3
            // 
            this.colCreateQty3.DisplayIndex = 19;
            this.colCreateQty3.Text = "Create Qty 3";
            this.colCreateQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCreateQty3.Width = 100;
            // 
            // colOperInQty1
            // 
            this.colOperInQty1.DisplayIndex = 20;
            this.colOperInQty1.Text = "Oper In Qty 1";
            this.colOperInQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOperInQty1.Width = 100;
            // 
            // colOperInQty2
            // 
            this.colOperInQty2.DisplayIndex = 21;
            this.colOperInQty2.Text = "Oper In Qty 2";
            this.colOperInQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOperInQty2.Width = 100;
            // 
            // colOperInQty3
            // 
            this.colOperInQty3.DisplayIndex = 22;
            this.colOperInQty3.Text = "Oper In Qty 3";
            this.colOperInQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colOperInQty3.Width = 100;
            // 
            // colInvFlag
            // 
            this.colInvFlag.DisplayIndex = 23;
            this.colInvFlag.Text = "Inventory Flag";
            this.colInvFlag.Width = 100;
            // 
            // colTransitFlag
            // 
            this.colTransitFlag.DisplayIndex = 24;
            this.colTransitFlag.Text = "Transit Flag";
            this.colTransitFlag.Width = 100;
            // 
            // colUnitExistFlag
            // 
            this.colUnitExistFlag.DisplayIndex = 25;
            this.colUnitExistFlag.Text = "Unit Exist Flag";
            this.colUnitExistFlag.Width = 100;
            // 
            // colInvUnit
            // 
            this.colInvUnit.DisplayIndex = 26;
            this.colInvUnit.Text = "Inv Unit";
            // 
            // colRwkFlag
            // 
            this.colRwkFlag.DisplayIndex = 27;
            this.colRwkFlag.Text = "Rework Flag";
            this.colRwkFlag.Width = 120;
            // 
            // colRwkCode
            // 
            this.colRwkCode.DisplayIndex = 28;
            this.colRwkCode.Text = "Rework Code";
            this.colRwkCode.Width = 120;
            // 
            // colRwkCount
            // 
            this.colRwkCount.DisplayIndex = 29;
            this.colRwkCount.Text = "Rework Count";
            this.colRwkCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRwkCount.Width = 120;
            // 
            // colRwkRetFlow
            // 
            this.colRwkRetFlow.DisplayIndex = 30;
            this.colRwkRetFlow.Text = "Rework Ret Flow";
            this.colRwkRetFlow.Width = 120;
            // 
            // colRwkRetOper
            // 
            this.colRwkRetOper.DisplayIndex = 31;
            this.colRwkRetOper.Text = "Rework Ret Oper";
            this.colRwkRetOper.Width = 120;
            // 
            // colRwkEndFlow
            // 
            this.colRwkEndFlow.DisplayIndex = 32;
            this.colRwkEndFlow.Text = "Rework End Flow";
            this.colRwkEndFlow.Width = 120;
            // 
            // colRwkEndOper
            // 
            this.colRwkEndOper.DisplayIndex = 33;
            this.colRwkEndOper.Text = "Rework End Oper";
            this.colRwkEndOper.Width = 120;
            // 
            // colRwkRetClearFlag
            // 
            this.colRwkRetClearFlag.DisplayIndex = 34;
            this.colRwkRetClearFlag.Text = "Rework Ret Clear Flag";
            this.colRwkRetClearFlag.Width = 155;
            // 
            // colRwkTime
            // 
            this.colRwkTime.DisplayIndex = 35;
            this.colRwkTime.Text = "Rework Time";
            this.colRwkTime.Width = 120;
            // 
            // colNstdFlag
            // 
            this.colNstdFlag.DisplayIndex = 36;
            this.colNstdFlag.Text = "NSTD Flag";
            this.colNstdFlag.Width = 120;
            // 
            // colNstdRetFlow
            // 
            this.colNstdRetFlow.DisplayIndex = 37;
            this.colNstdRetFlow.Text = "NSTD Ret Flow";
            this.colNstdRetFlow.Width = 120;
            // 
            // colNstdRetOper
            // 
            this.colNstdRetOper.DisplayIndex = 38;
            this.colNstdRetOper.Text = "NSTD Ret Oper";
            this.colNstdRetOper.Width = 120;
            // 
            // colNstdTime
            // 
            this.colNstdTime.DisplayIndex = 39;
            this.colNstdTime.Text = "NSTD Time";
            this.colNstdTime.Width = 120;
            // 
            // colStartFlag
            // 
            this.colStartFlag.DisplayIndex = 40;
            this.colStartFlag.Text = "Start Flag";
            this.colStartFlag.Width = 70;
            // 
            // colStartTime
            // 
            this.colStartTime.DisplayIndex = 41;
            this.colStartTime.Text = "Start Time";
            this.colStartTime.Width = 120;
            // 
            // colStartResID
            // 
            this.colStartResID.DisplayIndex = 42;
            this.colStartResID.Text = "Start Res ID";
            this.colStartResID.Width = 80;
            // 
            // colEndFlag
            // 
            this.colEndFlag.DisplayIndex = 43;
            this.colEndFlag.Text = "End Flag";
            this.colEndFlag.Width = 70;
            // 
            // colEndTime
            // 
            this.colEndTime.DisplayIndex = 44;
            this.colEndTime.Text = "End Time";
            this.colEndTime.Width = 120;
            // 
            // colEndResID
            // 
            this.colEndResID.DisplayIndex = 45;
            this.colEndResID.Text = "End Res ID";
            this.colEndResID.Width = 80;
            // 
            // colSampleFlag
            // 
            this.colSampleFlag.DisplayIndex = 46;
            this.colSampleFlag.Text = "Sample Flag";
            this.colSampleFlag.Width = 100;
            // 
            // colSampleWaitFlag
            // 
            this.colSampleWaitFlag.DisplayIndex = 47;
            this.colSampleWaitFlag.Text = "Sample Wait Flag";
            this.colSampleWaitFlag.Width = 110;
            // 
            // colSampleResult
            // 
            this.colSampleResult.DisplayIndex = 48;
            this.colSampleResult.Text = "Sample Result";
            this.colSampleResult.Width = 100;
            // 
            // colSplitFromLotID
            // 
            this.colSplitFromLotID.DisplayIndex = 49;
            this.colSplitFromLotID.Text = "Split From Lot ID";
            this.colSplitFromLotID.Width = 120;
            // 
            // colShipCode
            // 
            this.colShipCode.DisplayIndex = 50;
            this.colShipCode.Text = "Ship Code";
            this.colShipCode.Width = 80;
            // 
            // colShipTime
            // 
            this.colShipTime.DisplayIndex = 51;
            this.colShipTime.Text = "Ship Time";
            this.colShipTime.Width = 120;
            // 
            // colOrgDueTime
            // 
            this.colOrgDueTime.DisplayIndex = 52;
            this.colOrgDueTime.Text = "Original Due Time";
            this.colOrgDueTime.Width = 120;
            // 
            // colSchDueTime
            // 
            this.colSchDueTime.DisplayIndex = 53;
            this.colSchDueTime.Text = "Scheduled Due Time";
            this.colSchDueTime.Width = 145;
            // 
            // colCreateTime
            // 
            this.colCreateTime.DisplayIndex = 54;
            this.colCreateTime.Text = "Create Time";
            this.colCreateTime.Width = 120;
            // 
            // colFactoryInTime
            // 
            this.colFactoryInTime.DisplayIndex = 55;
            this.colFactoryInTime.Text = "Factory In Time";
            this.colFactoryInTime.Width = 120;
            // 
            // colFlowInTime
            // 
            this.colFlowInTime.DisplayIndex = 56;
            this.colFlowInTime.Text = "Flow In Time";
            this.colFlowInTime.Width = 120;
            // 
            // colOperInTime
            // 
            this.colOperInTime.DisplayIndex = 57;
            this.colOperInTime.Text = "Oper In Time";
            this.colOperInTime.Width = 120;
            // 
            // colResvResID
            // 
            this.colResvResID.DisplayIndex = 58;
            this.colResvResID.Text = "Reserve Res ID";
            this.colResvResID.Width = 120;
            // 
            // colBatchID
            // 
            this.colBatchID.DisplayIndex = 59;
            this.colBatchID.Text = "Batch ID";
            // 
            // colBatchSeq
            // 
            this.colBatchSeq.DisplayIndex = 60;
            this.colBatchSeq.Text = "Batch Seq";
            this.colBatchSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBatchSeq.Width = 70;
            // 
            // colOrderID
            // 
            this.colOrderID.DisplayIndex = 61;
            this.colOrderID.Text = "Order ID";
            this.colOrderID.Width = 100;
            // 
            // colAddOrder1
            // 
            this.colAddOrder1.DisplayIndex = 62;
            this.colAddOrder1.Text = "Add Order ID 1";
            this.colAddOrder1.Width = 100;
            // 
            // colAddOrder2
            // 
            this.colAddOrder2.DisplayIndex = 63;
            this.colAddOrder2.Text = "Add Order ID 2";
            this.colAddOrder2.Width = 100;
            // 
            // colAddOrder3
            // 
            this.colAddOrder3.DisplayIndex = 64;
            this.colAddOrder3.Text = "Add Order ID 3";
            this.colAddOrder3.Width = 100;
            // 
            // colLocation
            // 
            this.colLocation.DisplayIndex = 65;
            this.colLocation.Text = "Location";
            this.colLocation.Width = 80;
            // 
            // colLotCmf1
            // 
            this.colLotCmf1.DisplayIndex = 66;
            this.colLotCmf1.Text = "Lot Cmf 1";
            this.colLotCmf1.Width = 100;
            // 
            // colLotCmf2
            // 
            this.colLotCmf2.DisplayIndex = 67;
            this.colLotCmf2.Text = "Lot Cmf 2";
            this.colLotCmf2.Width = 100;
            // 
            // colLotCmf3
            // 
            this.colLotCmf3.DisplayIndex = 68;
            this.colLotCmf3.Text = "Lot Cmf 3";
            this.colLotCmf3.Width = 100;
            // 
            // colLotCmf4
            // 
            this.colLotCmf4.DisplayIndex = 69;
            this.colLotCmf4.Text = "Lot Cmf 4";
            this.colLotCmf4.Width = 100;
            // 
            // colLotCmf5
            // 
            this.colLotCmf5.DisplayIndex = 70;
            this.colLotCmf5.Text = "Lot Cmf 5";
            this.colLotCmf5.Width = 100;
            // 
            // colLotCmf6
            // 
            this.colLotCmf6.DisplayIndex = 71;
            this.colLotCmf6.Text = "Lot Cmf 6";
            this.colLotCmf6.Width = 100;
            // 
            // colLotCmf7
            // 
            this.colLotCmf7.DisplayIndex = 72;
            this.colLotCmf7.Text = "Lot Cmf 7";
            this.colLotCmf7.Width = 100;
            // 
            // colLotCmf8
            // 
            this.colLotCmf8.DisplayIndex = 73;
            this.colLotCmf8.Text = "Lot Cmf 8";
            this.colLotCmf8.Width = 100;
            // 
            // colLotCmf9
            // 
            this.colLotCmf9.DisplayIndex = 74;
            this.colLotCmf9.Text = "Lot Cmf 9";
            this.colLotCmf9.Width = 100;
            // 
            // colLotCmf10
            // 
            this.colLotCmf10.DisplayIndex = 75;
            this.colLotCmf10.Text = "Lot Cmf 10";
            this.colLotCmf10.Width = 100;
            // 
            // colLotCmf11
            // 
            this.colLotCmf11.DisplayIndex = 76;
            this.colLotCmf11.Text = "Lot Cmf 11";
            this.colLotCmf11.Width = 100;
            // 
            // colLotCmf12
            // 
            this.colLotCmf12.DisplayIndex = 77;
            this.colLotCmf12.Text = "Lot Cmf 12";
            this.colLotCmf12.Width = 100;
            // 
            // colLotCmf13
            // 
            this.colLotCmf13.DisplayIndex = 78;
            this.colLotCmf13.Text = "Lot Cmf 13";
            this.colLotCmf13.Width = 100;
            // 
            // colLotCmf14
            // 
            this.colLotCmf14.DisplayIndex = 79;
            this.colLotCmf14.Text = "Lot Cmf 14";
            this.colLotCmf14.Width = 100;
            // 
            // colLotCmf15
            // 
            this.colLotCmf15.DisplayIndex = 80;
            this.colLotCmf15.Text = "Lot Cmf 15";
            this.colLotCmf15.Width = 100;
            // 
            // colLotCmf16
            // 
            this.colLotCmf16.DisplayIndex = 81;
            this.colLotCmf16.Text = "Lot Cmf 16";
            this.colLotCmf16.Width = 100;
            // 
            // colLotCmf17
            // 
            this.colLotCmf17.DisplayIndex = 82;
            this.colLotCmf17.Text = "Lot Cmf 17";
            this.colLotCmf17.Width = 100;
            // 
            // colLotCmf18
            // 
            this.colLotCmf18.DisplayIndex = 83;
            this.colLotCmf18.Text = "Lot Cmf 18";
            this.colLotCmf18.Width = 100;
            // 
            // colLotCmf19
            // 
            this.colLotCmf19.DisplayIndex = 84;
            this.colLotCmf19.Text = "Lot Cmf 19";
            this.colLotCmf19.Width = 100;
            // 
            // colLotCmf20
            // 
            this.colLotCmf20.DisplayIndex = 85;
            this.colLotCmf20.Text = "Lot Cmf 20";
            this.colLotCmf20.Width = 100;
            // 
            // colBomSetID
            // 
            this.colBomSetID.DisplayIndex = 86;
            this.colBomSetID.Text = "BOM Set ID";
            this.colBomSetID.Width = 100;
            // 
            // colBomSetVersion
            // 
            this.colBomSetVersion.DisplayIndex = 87;
            this.colBomSetVersion.Text = "BOM Set Version";
            this.colBomSetVersion.Width = 120;
            // 
            // colBomActiveSeq
            // 
            this.colBomActiveSeq.DisplayIndex = 88;
            this.colBomActiveSeq.Text = "BOM Act Hist Seq";
            this.colBomActiveSeq.Width = 120;
            // 
            // colBomHistSeq
            // 
            this.colBomHistSeq.DisplayIndex = 89;
            this.colBomHistSeq.Text = "BOM Hist Seq";
            this.colBomHistSeq.Width = 100;
            // 
            // colLotDelFlag
            // 
            this.colLotDelFlag.DisplayIndex = 90;
            this.colLotDelFlag.Text = "Lot Delete Flag";
            this.colLotDelFlag.Width = 100;
            // 
            // colLotDelTime
            // 
            this.colLotDelTime.DisplayIndex = 91;
            this.colLotDelTime.Text = "Lot Delete Time";
            this.colLotDelTime.Width = 120;
            // 
            // colLotDelReason
            // 
            this.colLotDelReason.DisplayIndex = 92;
            this.colLotDelReason.Text = "Lot Delete Reason";
            this.colLotDelReason.Width = 150;
            // 
            // colLastTranCode
            // 
            this.colLastTranCode.DisplayIndex = 93;
            this.colLastTranCode.Text = "Last Trans Code";
            this.colLastTranCode.Width = 120;
            // 
            // colLastTranTime
            // 
            this.colLastTranTime.DisplayIndex = 94;
            this.colLastTranTime.Text = "Last Trans Time";
            this.colLastTranTime.Width = 120;
            // 
            // colLastComment
            // 
            this.colLastComment.DisplayIndex = 95;
            this.colLastComment.Text = "Last Comment";
            this.colLastComment.Width = 200;
            // 
            // colLastActiveHistSeq
            // 
            this.colLastActiveHistSeq.DisplayIndex = 96;
            this.colLastActiveHistSeq.Text = "Last Active Hist Seq";
            this.colLastActiveHistSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colLastActiveHistSeq.Width = 140;
            // 
            // colLastHistSeq
            // 
            this.colLastHistSeq.DisplayIndex = 97;
            this.colLastHistSeq.Text = "Last Hist Seq";
            this.colLastHistSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colLastHistSeq.Width = 120;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 60000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // colMatVer
            // 
            this.colMatVer.DisplayIndex = 3;
            this.colMatVer.Text = "Mat Ver";
            // 
            // colFlowSeq
            // 
            this.colFlowSeq.DisplayIndex = 5;
            this.colFlowSeq.Text = "Flow Seq";
            // 
            // frmSPCLotListMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSPCLotListMain";
            this.Text = "Lot List Main";
            this.Activated += new System.EventHandler(this.frmSPCLotListMain_Activated);
            this.Load += new System.EventHandler(this.frmSPCLotListMain_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatId)).EndInit();
            this.pnlMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private string sCurrentOper;
        
        #endregion
        
        #region " Funcion Implementations"
        
        // View_Lot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       - Boolean : True of False
        // Arguments
        //        -
        //
        private bool View_Lot_List()
        {
            TRSNode in_node = new TRSNode("View_Lot_List_In");
            TRSNode out_node;
            
            int i;
            ListViewItem itmX;
            int iTotLot;
            double dTotQty_1;
            double dTotQty_2;
            double dTotQty_3;
            try
            {
                MPCF.ClearList(lisLotList, true);
                //gaSelectLot_ID.Clear()
                MPGV.gsCurrentLot_ID = "";
                
                iTotLot = 0;
                dTotQty_1 = 0;
                dTotQty_2 = 0;
                dTotQty_3 = 0;

                MPCR.SetInMsg(in_node);

                in_node.AddString("MAT_ID", cdvMatId.Text);
                in_node.AddString("FLOW", cdvFlow.Text);
                in_node.AddString("OPER", sCurrentOper);
                in_node.AddString("GRP_1", "");
                in_node.AddString("TABLE_NAME_1", "");
                in_node.AddChar("ZERO_QTY_FLAG", ' ');
                in_node.AddChar("LOT_DEL_FLAG", ' ');

                
                do
                {
                    out_node = new TRSNode("View_Lot_List_Out");
                    if (MPCR.CallService("WIP", "WIP_View_Lot_List_By_Operation", in_node, ref out_node) == false)
                    {
                        //MPCF.ShowMsgBox(Miracom.H101Core.h101stub.StatusMessage);
                        return false;
                    }

                    if (out_node.StatusValue != MPGC.MP_SUCCESS_STATUS)
                    {
                        MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, out_node.FieldMsg));
                        return false;
                    }

                    
                    //for (i = 0; i <= View_Lot_List_Out.count - 1; i++)
                    //{
                    //    WIP_View_Lot_List_Detail_Out_Tag_lot_list with_1 = View_Lot_List_Out.lot_list[i];
                        
                    //    iTotLot++;
                        
                    //    WIPLIST.DisplayLotListDetail(lisLotList, View_Lot_List_Out.lot_list[i], 0);
                        
                    //    dTotQty_1 += with_1.qty_1;
                    //    dTotQty_2 += with_1.qty_2;
                    //    dTotQty_3 += with_1.qty_3;
                        
                    //}

                    in_node.AddString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));

                } while (in_node.GetString("NEXT_LOT_ID") != "");
                
                lblTotalLot.Text = iTotLot.ToString();
                lblTotalQty.Text = dTotQty_1.ToString() + " / " + dTotQty_2.ToString() + " / " + dTotQty_3.ToString();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.View_Lot_List()" + "\r\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetOperation()
        //       - Setting Operation at "frmMIDMain"
        // Return Value
        //       -
        // Arguments
        //        -
        public void SetOperation(string sOper)
        {
            
            try
            {
                sCurrentOper = sOper;
                cdvMatId.Text = "";
                cdvFlow.Text = "";
                
                if (b_load_flag == true)
                {
                    View_Lot_List();
                }
                else
                {
                    this.Top = 0;
                    this.Left = 0;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.SetOperation()" + "\r\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implementations"
        
        private void frmSPCLotListMain_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.InitListView(lisLotList);
                    View_Lot_List();
                    b_load_flag = true;
                }
                else
                {
                    if (chkAutoRefresh.Checked == true)
                    {
                        View_Lot_List();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.frmSPCLotListMain_Activated()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (sCurrentOper != "")
                {
                    View_Lot_List();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.btnRefresh_Click()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sCond;
                sCond = "";
                if (cdvMatId.Text != "")
                {
                    sCond = sCond + "Mat ID    : " + cdvMatId.Text + "\r";
                }
                if (cdvFlow.Text != "")
                {
                    sCond = sCond + "Flow      : " + cdvFlow.Text + "\r";
                }
                sCond = sCond + "Operation : " + sCurrentOper;

                if (MPCF.ExportToExcel(lisLotList, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.btnExcel_Click()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gsCurrentLot_ID = "";
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.btnClose_Click()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void cdvMatId_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (sCurrentOper != "")
                {
                    View_Lot_List();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.cdvMatId_SelectedItemChanged()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void cdvFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (sCurrentOper != "")
                {
                    View_Lot_List();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.cdvFlow_SelectedItemChanged()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void cdvMatID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvMatId.Init();
                MPCF.InitListView(cdvMatId.GetListView);
                cdvMatId.Columns.Add("Material", 50, HorizontalAlignment.Left);
                cdvMatId.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvMatId.SelectedSubItemIndex = 0;
                cdvMatId.SmallImageList = MPGV.gIMdiForm.GetSmallIconList();
                WIPLIST.ViewMaterialList(cdvMatId.GetListView, '1', "", ' ', ' ', "",false,null,"");
                cdvMatId.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.cdvMatID_ButtonPress()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvFlow.Init();
                MPCF.InitListView(cdvFlow.GetListView);
                cdvFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvFlow.SelectedSubItemIndex = 0;
                cdvFlow.SmallImageList = MPGV.gIMdiForm.GetSmallIconList();
                if (cdvMatId.Text == "")
                {
                    WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "",0, "", null, "");
                }
                else
                {
                    WIPLIST.ViewFlowList(cdvFlow.GetListView, '2', cdvMatId.Text,0, "", null, "");
                }
                cdvFlow.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.cdvFlow_ButtonPress()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void frmSPCLotListMain_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                MPCF.SetTextboxStyle(this.Controls);
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
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.frmSPCLotListMain_Load()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void tmrTimer_Tick(object sender, System.EventArgs e)
        {
            
            try
            {
                if (sCurrentOper != "")
                {
                    View_Lot_List();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.tmrTimer_Tick()" + "\r\n" + ex.Message);
            }
            
        }
        
        private void lisLotList_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gsCurrentLot_ID = lisLotList.FocusedItem.SubItems[1].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLotListMain.lisLotList_Click()" + "\r\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
}
