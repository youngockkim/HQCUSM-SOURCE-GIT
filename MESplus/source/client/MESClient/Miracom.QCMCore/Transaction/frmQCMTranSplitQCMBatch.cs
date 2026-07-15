
using Miracom.CliFrx;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.UI.Controls;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmQCMTranSplitQCMBatch.vb
//   Description : Split Batch Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - Split_Batch() : Split Batch transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2006-02-11 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _QCM = True Then

namespace Miracom.QCMCore
{
    public class frmQCMTranSplitQCMBatch : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMTranSplitQCMBatch()
        {
            
            //???¸ì¶œ?€ Windows Form ?”ìž?´ë„ˆ???„ìš”?©ë‹ˆ??
            InitializeComponent();
            
            //InitializeComponent()ë¥??¸ì¶œ???¤ìŒ??ì´ˆê¸°???‘ì—…??ì¶”ê??˜ì‹­?œì˜¤.
            
        }
        
        //Form?€ Disposeë¥??¬ì •?˜í•˜??êµ¬ì„± ?”ì†Œ ëª©ë¡???•ë¦¬?©ë‹ˆ??
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
        
        //Windows Form ?”ìž?´ë„ˆ???„ìš”?©ë‹ˆ??
        private System.ComponentModel.Container components = null;
        
        //ì°¸ê³ : ?¤ìŒ ?„ë¡œ?œì???Windows Form ?”ìž?´ë„ˆ???„ìš”?©ë‹ˆ??
        //Windows Form ?”ìž?´ë„ˆë¥??¬ìš©?˜ì—¬ ?˜ì •?????ˆìŠµ?ˆë‹¤.
        //ì½”ë“œ ?¸ì§‘ê¸°ë? ?¬ìš©?˜ì—¬ ?˜ì •?˜ì? ë§ˆì‹­?œì˜¤.
        private System.Windows.Forms.Panel pnlMainTop;
        private System.Windows.Forms.GroupBox grpBatchID;
        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        protected System.Windows.Forms.TextBox txtBatchID;
        protected System.Windows.Forms.Label lblBatchID;
        private System.Windows.Forms.Panel pnlMainMiddle;
        protected System.Windows.Forms.TabControl tabTran;
        protected System.Windows.Forms.TabPage tbpGeneral;
        protected System.Windows.Forms.Panel pnlGeneralMiddle;
        protected System.Windows.Forms.Panel pnlTranInfo;
        protected System.Windows.Forms.Panel pnlComment;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Panel pnlGeneralTop;
        private System.Windows.Forms.GroupBox grpBatInfo;
        private System.Windows.Forms.Panel pnlBatchInfoMain;
        private System.Windows.Forms.TabPage tbpItem;
        protected System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.Panel pnlCMF;
        protected System.Windows.Forms.GroupBox grpCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        protected System.Windows.Forms.Label lblCMF10;
        protected System.Windows.Forms.Label lblCMF9;
        protected System.Windows.Forms.Label lblCMF8;
        protected System.Windows.Forms.Label lblCMF7;
        protected System.Windows.Forms.Label lblCMF6;
        protected System.Windows.Forms.Label lblCMF5;
        protected System.Windows.Forms.Label lblCMF4;
        protected System.Windows.Forms.Label lblCMF3;
        protected System.Windows.Forms.Label lblCMF2;
        protected System.Windows.Forms.Label lblCMF1;
        private System.Windows.Forms.TabPage tbpCreateCMF;
        protected System.Windows.Forms.GroupBox grpCreateCMF;
        protected System.Windows.Forms.Label lblCreateCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF1;
        protected System.Windows.Forms.Label lblCreateCMF10;
        protected System.Windows.Forms.Label lblCreateCMF9;
        protected System.Windows.Forms.Label lblCreateCMF8;
        protected System.Windows.Forms.Label lblCreateCMF7;
        protected System.Windows.Forms.Label lblCreateCMF6;
        protected System.Windows.Forms.Label lblCreateCMF5;
        protected System.Windows.Forms.Label lblCreateCMF4;
        protected System.Windows.Forms.Label lblCreateCMF3;
        protected System.Windows.Forms.Label lblCreateCMF1;
        private System.Windows.Forms.GroupBox grpSublotInfo;
        private System.Windows.Forms.Panel pnlSplitSublot;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnUnSplit;
        private System.Windows.Forms.Panel pnlSubChild;
        private System.Windows.Forms.Panel pnlSubChildMid;
        private Miracom.UI.Controls.MCListView.MCListView lisChild;
        private System.Windows.Forms.Panel pnlSubChildTop;
        private System.Windows.Forms.TextBox txtMoveQty3;
        private System.Windows.Forms.TextBox txtMoveQty2;
        private System.Windows.Forms.TextBox txtMoveQty1;
        private System.Windows.Forms.Label lblMoveQty;
        private System.Windows.Forms.Panel pnlSubMother;
        private System.Windows.Forms.Panel pnlSubMotherMid;
        private Miracom.UI.Controls.MCListView.MCListView lisMother;
        private System.Windows.Forms.Panel pnlSubMotherTop;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.Label lblMotherQty;
        private System.Windows.Forms.GroupBox grpDefect;
        private System.Windows.Forms.Panel pnlDefect;
        private FarPoint.Win.Spread.FpSpread spdDefect;
        private FarPoint.Win.Spread.SheetView spdDefect_Sheet1;
        private System.Windows.Forms.Panel pnlDefectInspItem;
        private System.Windows.Forms.Button btnHideDefect;
        protected System.Windows.Forms.TextBox txtDefectInspItem;
        private System.Windows.Forms.Panel pnlChildBatchInfo;
        private System.Windows.Forms.Panel pnlChildBatchTop;
        private System.Windows.Forms.GroupBox grpChildBatch;
        private System.Windows.Forms.GroupBox grpMotherBatch;
        private System.Windows.Forms.ColumnHeader colChildSeq;
        private System.Windows.Forms.ColumnHeader colChildItemID;
        private System.Windows.Forms.ColumnHeader colChildQty;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colItemID;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.GroupBox grpChildBatchID;
        protected System.Windows.Forms.Label lblChildBatchID;
        private System.Windows.Forms.GroupBox grpChildBatchInfo;
        protected System.Windows.Forms.Label lblRetDlvID;
        private System.Windows.Forms.TextBox txtRetDlvId;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvOrderID;
        protected System.Windows.Forms.Label lblOrderID;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCustomer;
        protected System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtPOItem;
        protected System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtQty;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvVendor;
        protected System.Windows.Forms.Label lblVendor;
        protected System.Windows.Forms.Label lblBoxID;
        protected System.Windows.Forms.Label lblInvoice;
        protected System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.TextBox txtBOXID;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtPO;
        protected System.Windows.Forms.Label Label8;
        private System.Windows.Forms.TextBox txtMaxSetQty;
        private System.Windows.Forms.TextBox txtMaxBatchQty;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspSetID;
        protected System.Windows.Forms.Label lblInspSetID;
        private Miracom.QCMCore.udcQCMBatchInfo ctrlBatchInfo;
        protected System.Windows.Forms.TextBox txtChildBatchID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.pnlMainTop = new System.Windows.Forms.Panel();
            this.grpBatchID = new System.Windows.Forms.GroupBox();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranDateTime = new System.Windows.Forms.CheckBox();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.pnlMainMiddle = new System.Windows.Forms.Panel();
            this.tabTran = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlGeneralMiddle = new System.Windows.Forms.Panel();
            this.pnlTranInfo = new System.Windows.Forms.Panel();
            this.pnlChildBatchInfo = new System.Windows.Forms.Panel();
            this.grpChildBatchInfo = new System.Windows.Forms.GroupBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtMaxSetQty = new System.Windows.Forms.TextBox();
            this.txtMaxBatchQty = new System.Windows.Forms.TextBox();
            this.cdvInspSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInspSetID = new System.Windows.Forms.Label();
            this.lblRetDlvID = new System.Windows.Forms.Label();
            this.txtRetDlvId = new System.Windows.Forms.TextBox();
            this.cdvOrderID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.cdvCustomer = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtPOItem = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.cdvVendor = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblBoxID = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblPO = new System.Windows.Forms.Label();
            this.txtBOXID = new System.Windows.Forms.TextBox();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.pnlChildBatchTop = new System.Windows.Forms.Panel();
            this.grpChildBatchID = new System.Windows.Forms.GroupBox();
            this.txtChildBatchID = new System.Windows.Forms.TextBox();
            this.lblChildBatchID = new System.Windows.Forms.Label();
            this.grpDefect = new System.Windows.Forms.GroupBox();
            this.pnlDefect = new System.Windows.Forms.Panel();
            this.spdDefect = new FarPoint.Win.Spread.FpSpread();
            this.spdDefect_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlDefectInspItem = new System.Windows.Forms.Panel();
            this.btnHideDefect = new System.Windows.Forms.Button();
            this.txtDefectInspItem = new System.Windows.Forms.TextBox();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.pnlGeneralTop = new System.Windows.Forms.Panel();
            this.grpBatInfo = new System.Windows.Forms.GroupBox();
            this.pnlBatchInfoMain = new System.Windows.Forms.Panel();
            this.ctrlBatchInfo = new Miracom.QCMCore.udcQCMBatchInfo();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.pnlCMF = new System.Windows.Forms.Panel();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.tbpItem = new System.Windows.Forms.TabPage();
            this.grpSublotInfo = new System.Windows.Forms.GroupBox();
            this.pnlSplitSublot = new System.Windows.Forms.Panel();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnUnSplit = new System.Windows.Forms.Button();
            this.pnlSubChild = new System.Windows.Forms.Panel();
            this.grpChildBatch = new System.Windows.Forms.GroupBox();
            this.pnlSubChildMid = new System.Windows.Forms.Panel();
            this.lisChild = new Miracom.UI.Controls.MCListView.MCListView();
            this.colChildSeq = new System.Windows.Forms.ColumnHeader();
            this.colChildItemID = new System.Windows.Forms.ColumnHeader();
            this.colChildQty = new System.Windows.Forms.ColumnHeader();
            this.pnlSubChildTop = new System.Windows.Forms.Panel();
            this.txtMoveQty3 = new System.Windows.Forms.TextBox();
            this.txtMoveQty2 = new System.Windows.Forms.TextBox();
            this.txtMoveQty1 = new System.Windows.Forms.TextBox();
            this.lblMoveQty = new System.Windows.Forms.Label();
            this.pnlSubMother = new System.Windows.Forms.Panel();
            this.grpMotherBatch = new System.Windows.Forms.GroupBox();
            this.pnlSubMotherMid = new System.Windows.Forms.Panel();
            this.lisMother = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = new System.Windows.Forms.ColumnHeader();
            this.colItemID = new System.Windows.Forms.ColumnHeader();
            this.colQty = new System.Windows.Forms.ColumnHeader();
            this.pnlSubMotherTop = new System.Windows.Forms.Panel();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblMotherQty = new System.Windows.Forms.Label();
            this.tbpCreateCMF = new System.Windows.Forms.TabPage();
            this.grpCreateCMF = new System.Windows.Forms.GroupBox();
            this.lblCreateCMF2 = new System.Windows.Forms.Label();
            this.cdvCreateCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCreateCMF10 = new System.Windows.Forms.Label();
            this.lblCreateCMF9 = new System.Windows.Forms.Label();
            this.lblCreateCMF8 = new System.Windows.Forms.Label();
            this.lblCreateCMF7 = new System.Windows.Forms.Label();
            this.lblCreateCMF6 = new System.Windows.Forms.Label();
            this.lblCreateCMF5 = new System.Windows.Forms.Label();
            this.lblCreateCMF4 = new System.Windows.Forms.Label();
            this.lblCreateCMF3 = new System.Windows.Forms.Label();
            this.lblCreateCMF1 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMainTop.SuspendLayout();
            this.grpBatchID.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            this.pnlMainMiddle.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGeneralMiddle.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlChildBatchInfo.SuspendLayout();
            this.grpChildBatchInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvVendor)).BeginInit();
            this.pnlChildBatchTop.SuspendLayout();
            this.grpChildBatchID.SuspendLayout();
            this.grpDefect.SuspendLayout();
            this.pnlDefect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect_Sheet1)).BeginInit();
            this.pnlDefectInspItem.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            this.grpBatInfo.SuspendLayout();
            this.pnlBatchInfoMain.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.pnlCMF.SuspendLayout();
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
            this.tbpItem.SuspendLayout();
            this.grpSublotInfo.SuspendLayout();
            this.pnlSplitSublot.SuspendLayout();
            this.pnlSubChild.SuspendLayout();
            this.grpChildBatch.SuspendLayout();
            this.pnlSubChildMid.SuspendLayout();
            this.pnlSubChildTop.SuspendLayout();
            this.pnlSubMother.SuspendLayout();
            this.grpMotherBatch.SuspendLayout();
            this.pnlSubMotherMid.SuspendLayout();
            this.pnlSubMotherTop.SuspendLayout();
            this.tbpCreateCMF.SuspendLayout();
            this.grpCreateCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMainMiddle);
            this.pnlCenter.Controls.Add(this.pnlMainTop);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Split QCM Batch";
            // 
            // pnlMainTop
            // 
            this.pnlMainTop.Controls.Add(this.grpBatchID);
            this.pnlMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTop.Name = "pnlMainTop";
            this.pnlMainTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlMainTop.Size = new System.Drawing.Size(742, 44);
            this.pnlMainTop.TabIndex = 0;
            // 
            // grpBatchID
            // 
            this.grpBatchID.Controls.Add(this.pnlTranTime);
            this.grpBatchID.Controls.Add(this.txtBatchID);
            this.grpBatchID.Controls.Add(this.lblBatchID);
            this.grpBatchID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBatchID.Location = new System.Drawing.Point(3, 0);
            this.grpBatchID.Name = "grpBatchID";
            this.grpBatchID.Size = new System.Drawing.Size(736, 44);
            this.grpBatchID.TabIndex = 0;
            this.grpBatchID.TabStop = false;
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranTime);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranDate);
            this.pnlTranTime.Location = new System.Drawing.Point(426, 16);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 20);
            this.pnlTranTime.TabIndex = 2;
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
            this.chkTranDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTranDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTranDateTime.Location = new System.Drawing.Point(3, 3);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(124, 14);
            this.chkTranDateTime.TabIndex = 0;
            this.chkTranDateTime.Text = "Transaction Time";
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranDate.Checked = false;
            this.dtpTranDate.CustomFormat = "yyyy-MM-dd";
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranDate.Location = new System.Drawing.Point(139, 0);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(86, 20);
            this.dtpTranDate.TabIndex = 2;
            // 
            // txtBatchID
            // 
            this.txtBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBatchID.Location = new System.Drawing.Point(120, 16);
            this.txtBatchID.MaxLength = 30;
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.Size = new System.Drawing.Size(200, 20);
            this.txtBatchID.TabIndex = 1;
            this.txtBatchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchID_KeyPress);
            // 
            // lblBatchID
            // 
            this.lblBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchID.Location = new System.Drawing.Point(16, 18);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(100, 14);
            this.lblBatchID.TabIndex = 0;
            this.lblBatchID.Text = "Batch ID";
            this.lblBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMainMiddle
            // 
            this.pnlMainMiddle.Controls.Add(this.tabTran);
            this.pnlMainMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMiddle.Location = new System.Drawing.Point(0, 44);
            this.pnlMainMiddle.Name = "pnlMainMiddle";
            this.pnlMainMiddle.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlMainMiddle.Size = new System.Drawing.Size(742, 462);
            this.pnlMainMiddle.TabIndex = 1;
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpGeneral);
            this.tabTran.Controls.Add(this.tbpCMF);
            this.tabTran.Controls.Add(this.tbpItem);
            this.tabTran.Controls.Add(this.tbpCreateCMF);
            this.tabTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTran.ItemSize = new System.Drawing.Size(60, 18);
            this.tabTran.Location = new System.Drawing.Point(3, 5);
            this.tabTran.Name = "tabTran";
            this.tabTran.SelectedIndex = 0;
            this.tabTran.Size = new System.Drawing.Size(736, 454);
            this.tabTran.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGeneralMiddle);
            this.tbpGeneral.Controls.Add(this.pnlGeneralTop);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(728, 428);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlGeneralMiddle
            // 
            this.pnlGeneralMiddle.Controls.Add(this.pnlTranInfo);
            this.pnlGeneralMiddle.Controls.Add(this.pnlComment);
            this.pnlGeneralMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneralMiddle.Location = new System.Drawing.Point(0, 146);
            this.pnlGeneralMiddle.Name = "pnlGeneralMiddle";
            this.pnlGeneralMiddle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlGeneralMiddle.Size = new System.Drawing.Size(728, 282);
            this.pnlGeneralMiddle.TabIndex = 0;
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.pnlChildBatchInfo);
            this.pnlTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTranInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTranInfo.Name = "pnlTranInfo";
            this.pnlTranInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 242);
            this.pnlTranInfo.TabIndex = 0;
            // 
            // pnlChildBatchInfo
            // 
            this.pnlChildBatchInfo.Controls.Add(this.grpChildBatchInfo);
            this.pnlChildBatchInfo.Controls.Add(this.pnlChildBatchTop);
            this.pnlChildBatchInfo.Controls.Add(this.grpDefect);
            this.pnlChildBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildBatchInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlChildBatchInfo.Location = new System.Drawing.Point(3, 0);
            this.pnlChildBatchInfo.Name = "pnlChildBatchInfo";
            this.pnlChildBatchInfo.Size = new System.Drawing.Size(722, 242);
            this.pnlChildBatchInfo.TabIndex = 7;
            // 
            // grpChildBatchInfo
            // 
            this.grpChildBatchInfo.Controls.Add(this.Label8);
            this.grpChildBatchInfo.Controls.Add(this.txtMaxSetQty);
            this.grpChildBatchInfo.Controls.Add(this.txtMaxBatchQty);
            this.grpChildBatchInfo.Controls.Add(this.cdvInspSetID);
            this.grpChildBatchInfo.Controls.Add(this.lblInspSetID);
            this.grpChildBatchInfo.Controls.Add(this.lblRetDlvID);
            this.grpChildBatchInfo.Controls.Add(this.txtRetDlvId);
            this.grpChildBatchInfo.Controls.Add(this.cdvOrderID);
            this.grpChildBatchInfo.Controls.Add(this.lblOrderID);
            this.grpChildBatchInfo.Controls.Add(this.cdvCustomer);
            this.grpChildBatchInfo.Controls.Add(this.lblCustomer);
            this.grpChildBatchInfo.Controls.Add(this.txtPOItem);
            this.grpChildBatchInfo.Controls.Add(this.Label6);
            this.grpChildBatchInfo.Controls.Add(this.txtQty);
            this.grpChildBatchInfo.Controls.Add(this.cdvVendor);
            this.grpChildBatchInfo.Controls.Add(this.lblVendor);
            this.grpChildBatchInfo.Controls.Add(this.lblBoxID);
            this.grpChildBatchInfo.Controls.Add(this.lblInvoice);
            this.grpChildBatchInfo.Controls.Add(this.lblPO);
            this.grpChildBatchInfo.Controls.Add(this.txtBOXID);
            this.grpChildBatchInfo.Controls.Add(this.txtInvoice);
            this.grpChildBatchInfo.Controls.Add(this.txtPO);
            this.grpChildBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChildBatchInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChildBatchInfo.Location = new System.Drawing.Point(0, 44);
            this.grpChildBatchInfo.Name = "grpChildBatchInfo";
            this.grpChildBatchInfo.Size = new System.Drawing.Size(722, 198);
            this.grpChildBatchInfo.TabIndex = 0;
            this.grpChildBatchInfo.TabStop = false;
            this.grpChildBatchInfo.Text = "Child Batch Information";
            // 
            // Label8
            // 
            this.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label8.Location = new System.Drawing.Point(364, 21);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(170, 14);
            this.Label8.TabIndex = 11;
            this.Label8.Text = "Max Batch Qty / Max Insp. Set Qty";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaxSetQty
            // 
            this.txtMaxSetQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxSetQty.Location = new System.Drawing.Point(638, 17);
            this.txtMaxSetQty.MaxLength = 30;
            this.txtMaxSetQty.Name = "txtMaxSetQty";
            this.txtMaxSetQty.ReadOnly = true;
            this.txtMaxSetQty.Size = new System.Drawing.Size(76, 20);
            this.txtMaxSetQty.TabIndex = 13;
            this.txtMaxSetQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxBatchQty
            // 
            this.txtMaxBatchQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxBatchQty.Location = new System.Drawing.Point(556, 17);
            this.txtMaxBatchQty.MaxLength = 30;
            this.txtMaxBatchQty.Name = "txtMaxBatchQty";
            this.txtMaxBatchQty.ReadOnly = true;
            this.txtMaxBatchQty.Size = new System.Drawing.Size(76, 20);
            this.txtMaxBatchQty.TabIndex = 12;
            this.txtMaxBatchQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cdvInspSetID
            // 
            this.cdvInspSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspSetID.BtnToolTipText = "";
            this.cdvInspSetID.DescText = "";
            this.cdvInspSetID.DisplaySubItemIndex = -1;
            this.cdvInspSetID.DisplayText = "";
            this.cdvInspSetID.Focusing = null;
            this.cdvInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspSetID.Index = 0;
            this.cdvInspSetID.IsViewBtnImage = false;
            this.cdvInspSetID.Location = new System.Drawing.Point(136, 17);
            this.cdvInspSetID.MaxLength = 30;
            this.cdvInspSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspSetID.Name = "cdvInspSetID";
            this.cdvInspSetID.ReadOnly = false;
            this.cdvInspSetID.SearchSubItemIndex = 0;
            this.cdvInspSetID.SelectedDescIndex = -1;
            this.cdvInspSetID.SelectedSubItemIndex = -1;
            this.cdvInspSetID.SelectionStart = 0;
            this.cdvInspSetID.Size = new System.Drawing.Size(212, 20);
            this.cdvInspSetID.SmallImageList = null;
            this.cdvInspSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspSetID.TabIndex = 1;
            this.cdvInspSetID.TextBoxToolTipText = "";
            this.cdvInspSetID.TextBoxWidth = 212;
            this.cdvInspSetID.VisibleButton = true;
            this.cdvInspSetID.VisibleColumnHeader = false;
            this.cdvInspSetID.VisibleDescription = false;
            this.cdvInspSetID.TextBoxTextChanged += new System.EventHandler(this.cdvInspSetID_TextBoxTextChanged);
            this.cdvInspSetID.ButtonPress += new System.EventHandler(this.cdvInspSetID_ButtonPress);
            // 
            // lblInspSetID
            // 
            this.lblInspSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspSetID.Location = new System.Drawing.Point(13, 21);
            this.lblInspSetID.Name = "lblInspSetID";
            this.lblInspSetID.Size = new System.Drawing.Size(100, 14);
            this.lblInspSetID.TabIndex = 0;
            this.lblInspSetID.Text = "Inspection Set ID";
            this.lblInspSetID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRetDlvID
            // 
            this.lblRetDlvID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetDlvID.Location = new System.Drawing.Point(434, 117);
            this.lblRetDlvID.Name = "lblRetDlvID";
            this.lblRetDlvID.Size = new System.Drawing.Size(100, 14);
            this.lblRetDlvID.TabIndex = 20;
            this.lblRetDlvID.Text = "Ret Dlv. ID";
            this.lblRetDlvID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRetDlvId
            // 
            this.txtRetDlvId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetDlvId.Location = new System.Drawing.Point(556, 114);
            this.txtRetDlvId.MaxLength = 30;
            this.txtRetDlvId.Name = "txtRetDlvId";
            this.txtRetDlvId.Size = new System.Drawing.Size(157, 20);
            this.txtRetDlvId.TabIndex = 21;
            // 
            // cdvOrderID
            // 
            this.cdvOrderID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOrderID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOrderID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOrderID.BtnToolTipText = "";
            this.cdvOrderID.DescText = "";
            this.cdvOrderID.DisplaySubItemIndex = -1;
            this.cdvOrderID.DisplayText = "";
            this.cdvOrderID.Focusing = null;
            this.cdvOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOrderID.Index = 0;
            this.cdvOrderID.IsViewBtnImage = false;
            this.cdvOrderID.Location = new System.Drawing.Point(556, 89);
            this.cdvOrderID.MaxLength = 30;
            this.cdvOrderID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOrderID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOrderID.Name = "cdvOrderID";
            this.cdvOrderID.ReadOnly = false;
            this.cdvOrderID.SearchSubItemIndex = 0;
            this.cdvOrderID.SelectedDescIndex = -1;
            this.cdvOrderID.SelectedSubItemIndex = -1;
            this.cdvOrderID.SelectionStart = 0;
            this.cdvOrderID.Size = new System.Drawing.Size(157, 20);
            this.cdvOrderID.SmallImageList = null;
            this.cdvOrderID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOrderID.TabIndex = 19;
            this.cdvOrderID.TextBoxToolTipText = "";
            this.cdvOrderID.TextBoxWidth = 157;
            this.cdvOrderID.VisibleButton = true;
            this.cdvOrderID.VisibleColumnHeader = false;
            this.cdvOrderID.VisibleDescription = false;
            this.cdvOrderID.ButtonPress += new System.EventHandler(this.cdvOrderID_ButtonPress);
            // 
            // lblOrderID
            // 
            this.lblOrderID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderID.Location = new System.Drawing.Point(434, 92);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(100, 14);
            this.lblOrderID.TabIndex = 18;
            this.lblOrderID.Text = "Order ID";
            this.lblOrderID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCustomer
            // 
            this.cdvCustomer.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCustomer.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCustomer.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCustomer.BtnToolTipText = "";
            this.cdvCustomer.DescText = "";
            this.cdvCustomer.DisplaySubItemIndex = -1;
            this.cdvCustomer.DisplayText = "";
            this.cdvCustomer.Focusing = null;
            this.cdvCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCustomer.Index = 0;
            this.cdvCustomer.IsViewBtnImage = false;
            this.cdvCustomer.Location = new System.Drawing.Point(556, 65);
            this.cdvCustomer.MaxLength = 30;
            this.cdvCustomer.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCustomer.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCustomer.Name = "cdvCustomer";
            this.cdvCustomer.ReadOnly = false;
            this.cdvCustomer.SearchSubItemIndex = 0;
            this.cdvCustomer.SelectedDescIndex = -1;
            this.cdvCustomer.SelectedSubItemIndex = -1;
            this.cdvCustomer.SelectionStart = 0;
            this.cdvCustomer.Size = new System.Drawing.Size(157, 20);
            this.cdvCustomer.SmallImageList = null;
            this.cdvCustomer.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCustomer.TabIndex = 17;
            this.cdvCustomer.TextBoxToolTipText = "";
            this.cdvCustomer.TextBoxWidth = 157;
            this.cdvCustomer.VisibleButton = true;
            this.cdvCustomer.VisibleColumnHeader = false;
            this.cdvCustomer.VisibleDescription = false;
            this.cdvCustomer.ButtonPress += new System.EventHandler(this.cdvCustomer_ButtonPress);
            // 
            // lblCustomer
            // 
            this.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomer.Location = new System.Drawing.Point(434, 68);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(100, 14);
            this.lblCustomer.TabIndex = 16;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPOItem
            // 
            this.txtPOItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPOItem.Location = new System.Drawing.Point(300, 41);
            this.txtPOItem.MaxLength = 30;
            this.txtPOItem.Name = "txtPOItem";
            this.txtPOItem.Size = new System.Drawing.Size(48, 20);
            this.txtPOItem.TabIndex = 4;
            // 
            // Label6
            // 
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(434, 44);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(100, 14);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Qty";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(556, 41);
            this.txtQty.MaxLength = 30;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(157, 20);
            this.txtQty.TabIndex = 15;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cdvVendor
            // 
            this.cdvVendor.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvVendor.BorderHotColor = System.Drawing.Color.Black;
            this.cdvVendor.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvVendor.BtnToolTipText = "";
            this.cdvVendor.DescText = "";
            this.cdvVendor.DisplaySubItemIndex = -1;
            this.cdvVendor.DisplayText = "";
            this.cdvVendor.Focusing = null;
            this.cdvVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvVendor.Index = 0;
            this.cdvVendor.IsViewBtnImage = false;
            this.cdvVendor.Location = new System.Drawing.Point(136, 114);
            this.cdvVendor.MaxLength = 30;
            this.cdvVendor.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvVendor.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvVendor.Name = "cdvVendor";
            this.cdvVendor.ReadOnly = false;
            this.cdvVendor.SearchSubItemIndex = 0;
            this.cdvVendor.SelectedDescIndex = -1;
            this.cdvVendor.SelectedSubItemIndex = -1;
            this.cdvVendor.SelectionStart = 0;
            this.cdvVendor.Size = new System.Drawing.Size(157, 20);
            this.cdvVendor.SmallImageList = null;
            this.cdvVendor.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvVendor.TabIndex = 10;
            this.cdvVendor.TextBoxToolTipText = "";
            this.cdvVendor.TextBoxWidth = 157;
            this.cdvVendor.VisibleButton = true;
            this.cdvVendor.VisibleColumnHeader = false;
            this.cdvVendor.VisibleDescription = false;
            this.cdvVendor.ButtonPress += new System.EventHandler(this.cdvVendor_ButtonPress);
            // 
            // lblVendor
            // 
            this.lblVendor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVendor.Location = new System.Drawing.Point(14, 117);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(100, 14);
            this.lblVendor.TabIndex = 9;
            this.lblVendor.Text = "Vendor";
            this.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBoxID
            // 
            this.lblBoxID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBoxID.Location = new System.Drawing.Point(14, 92);
            this.lblBoxID.Name = "lblBoxID";
            this.lblBoxID.Size = new System.Drawing.Size(100, 14);
            this.lblBoxID.TabIndex = 7;
            this.lblBoxID.Text = "BOX ID";
            this.lblBoxID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInvoice
            // 
            this.lblInvoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInvoice.Location = new System.Drawing.Point(14, 68);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(100, 14);
            this.lblInvoice.TabIndex = 5;
            this.lblInvoice.Text = "Invoice";
            this.lblInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPO
            // 
            this.lblPO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPO.Location = new System.Drawing.Point(14, 44);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(100, 14);
            this.lblPO.TabIndex = 2;
            this.lblPO.Text = "Purchase Order";
            this.lblPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBOXID
            // 
            this.txtBOXID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBOXID.Location = new System.Drawing.Point(136, 89);
            this.txtBOXID.MaxLength = 30;
            this.txtBOXID.Name = "txtBOXID";
            this.txtBOXID.Size = new System.Drawing.Size(157, 20);
            this.txtBOXID.TabIndex = 8;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoice.Location = new System.Drawing.Point(136, 65);
            this.txtInvoice.MaxLength = 30;
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(157, 20);
            this.txtInvoice.TabIndex = 6;
            // 
            // txtPO
            // 
            this.txtPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPO.Location = new System.Drawing.Point(136, 41);
            this.txtPO.MaxLength = 30;
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(157, 20);
            this.txtPO.TabIndex = 3;
            // 
            // pnlChildBatchTop
            // 
            this.pnlChildBatchTop.Controls.Add(this.grpChildBatchID);
            this.pnlChildBatchTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChildBatchTop.Location = new System.Drawing.Point(0, 0);
            this.pnlChildBatchTop.Name = "pnlChildBatchTop";
            this.pnlChildBatchTop.Size = new System.Drawing.Size(722, 44);
            this.pnlChildBatchTop.TabIndex = 8;
            // 
            // grpChildBatchID
            // 
            this.grpChildBatchID.Controls.Add(this.txtChildBatchID);
            this.grpChildBatchID.Controls.Add(this.lblChildBatchID);
            this.grpChildBatchID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChildBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChildBatchID.Location = new System.Drawing.Point(0, 0);
            this.grpChildBatchID.Name = "grpChildBatchID";
            this.grpChildBatchID.Size = new System.Drawing.Size(722, 44);
            this.grpChildBatchID.TabIndex = 0;
            this.grpChildBatchID.TabStop = false;
            // 
            // txtChildBatchID
            // 
            this.txtChildBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtChildBatchID.Location = new System.Drawing.Point(120, 16);
            this.txtChildBatchID.MaxLength = 30;
            this.txtChildBatchID.Name = "txtChildBatchID";
            this.txtChildBatchID.Size = new System.Drawing.Size(200, 20);
            this.txtChildBatchID.TabIndex = 1;
            this.txtChildBatchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChildBatchID_KeyPress);
            // 
            // lblChildBatchID
            // 
            this.lblChildBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChildBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildBatchID.Location = new System.Drawing.Point(16, 18);
            this.lblChildBatchID.Name = "lblChildBatchID";
            this.lblChildBatchID.Size = new System.Drawing.Size(100, 14);
            this.lblChildBatchID.TabIndex = 0;
            this.lblChildBatchID.Text = "Child Batch ID";
            this.lblChildBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpDefect
            // 
            this.grpDefect.Controls.Add(this.pnlDefect);
            this.grpDefect.Controls.Add(this.pnlDefectInspItem);
            this.grpDefect.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpDefect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDefect.Location = new System.Drawing.Point(722, 0);
            this.grpDefect.Name = "grpDefect";
            this.grpDefect.Size = new System.Drawing.Size(0, 242);
            this.grpDefect.TabIndex = 7;
            this.grpDefect.TabStop = false;
            this.grpDefect.Text = "Defect";
            this.grpDefect.Visible = false;
            // 
            // pnlDefect
            // 
            this.pnlDefect.Controls.Add(this.spdDefect);
            this.pnlDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefect.Location = new System.Drawing.Point(3, 60);
            this.pnlDefect.Name = "pnlDefect";
            this.pnlDefect.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDefect.Size = new System.Drawing.Size(0, 179);
            this.pnlDefect.TabIndex = 1;
            // 
            // spdDefect
            // 
            this.spdDefect.AccessibleDescription = "";
            this.spdDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefect.Location = new System.Drawing.Point(3, 3);
            this.spdDefect.Name = "spdDefect";
            this.spdDefect.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdDefect.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdDefect.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDefect_Sheet1});
            this.spdDefect.Size = new System.Drawing.Size(0, 173);
            this.spdDefect.TabIndex = 7;
            this.spdDefect.TabStop = false;
            // 
            // spdDefect_Sheet1
            // 
            this.spdDefect_Sheet1.Reset();
            this.spdDefect_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdDefect_Sheet1.ColumnCount = 3;
            this.spdDefect_Sheet1.RowCount = 10;
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Defect Code";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Qty";
            this.spdDefect_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdDefect_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.White;
            this.spdDefect_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefect_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDefect_Sheet1.Columns.Get(0).Label = "Defect Code";
            this.spdDefect_Sheet1.Columns.Get(0).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(0).Width = 100F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdDefect_Sheet1.Columns.Get(1).CellType = buttonCellType2;
            this.spdDefect_Sheet1.Columns.Get(1).Resizable = false;
            this.spdDefect_Sheet1.Columns.Get(1).Width = 20F;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.MinimumValue = 0;
            this.spdDefect_Sheet1.Columns.Get(2).CellType = numberCellType2;
            this.spdDefect_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDefect_Sheet1.Columns.Get(2).Label = "Qty";
            this.spdDefect_Sheet1.Columns.Get(2).Locked = false;
            this.spdDefect_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(2).Width = 50F;
            this.spdDefect_Sheet1.FrozenColumnCount = 3;
            this.spdDefect_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDefect_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdDefect_Sheet1.Rows.Get(0).Height = 18F;
            this.spdDefect_Sheet1.Rows.Get(1).Height = 18F;
            this.spdDefect_Sheet1.Rows.Get(2).Height = 18F;
            this.spdDefect_Sheet1.Rows.Get(3).Height = 18F;
            this.spdDefect_Sheet1.Rows.Get(4).Height = 18F;
            this.spdDefect_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.spdDefect.SetViewportLeftColumn(0, 0, 3);
            this.spdDefect.SetActiveViewport(0, 0, -1);
            // 
            // pnlDefectInspItem
            // 
            this.pnlDefectInspItem.Controls.Add(this.btnHideDefect);
            this.pnlDefectInspItem.Controls.Add(this.txtDefectInspItem);
            this.pnlDefectInspItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDefectInspItem.Location = new System.Drawing.Point(3, 16);
            this.pnlDefectInspItem.Name = "pnlDefectInspItem";
            this.pnlDefectInspItem.Size = new System.Drawing.Size(0, 44);
            this.pnlDefectInspItem.TabIndex = 0;
            // 
            // btnHideDefect
            // 
            this.btnHideDefect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHideDefect.Location = new System.Drawing.Point(16, 10);
            this.btnHideDefect.Name = "btnHideDefect";
            this.btnHideDefect.Size = new System.Drawing.Size(22, 24);
            this.btnHideDefect.TabIndex = 32;
            this.btnHideDefect.Text = "?€";
            // 
            // txtDefectInspItem
            // 
            this.txtDefectInspItem.Location = new System.Drawing.Point(76, 12);
            this.txtDefectInspItem.MaxLength = 25;
            this.txtDefectInspItem.Name = "txtDefectInspItem";
            this.txtDefectInspItem.ReadOnly = true;
            this.txtDefectInspItem.Size = new System.Drawing.Size(157, 20);
            this.txtDefectInspItem.TabIndex = 2;
            this.txtDefectInspItem.TabStop = false;
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.grpComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(0, 242);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlComment.Size = new System.Drawing.Size(728, 37);
            this.pnlComment.TabIndex = 1;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(3, 0);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(722, 37);
            this.grpComment.TabIndex = 0;
            this.grpComment.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(120, 12);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(590, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 14);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(100, 14);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlGeneralTop
            // 
            this.pnlGeneralTop.Controls.Add(this.grpBatInfo);
            this.pnlGeneralTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGeneralTop.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneralTop.Name = "pnlGeneralTop";
            this.pnlGeneralTop.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlGeneralTop.Size = new System.Drawing.Size(728, 146);
            this.pnlGeneralTop.TabIndex = 0;
            // 
            // grpBatInfo
            // 
            this.grpBatInfo.Controls.Add(this.pnlBatchInfoMain);
            this.grpBatInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBatInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBatInfo.Location = new System.Drawing.Point(3, 3);
            this.grpBatInfo.Name = "grpBatInfo";
            this.grpBatInfo.Size = new System.Drawing.Size(722, 143);
            this.grpBatInfo.TabIndex = 0;
            this.grpBatInfo.TabStop = false;
            this.grpBatInfo.Text = "Batch Information";
            // 
            // pnlBatchInfoMain
            // 
            this.pnlBatchInfoMain.Controls.Add(this.ctrlBatchInfo);
            this.pnlBatchInfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBatchInfoMain.Location = new System.Drawing.Point(3, 16);
            this.pnlBatchInfoMain.Name = "pnlBatchInfoMain";
            this.pnlBatchInfoMain.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBatchInfoMain.Size = new System.Drawing.Size(716, 124);
            this.pnlBatchInfoMain.TabIndex = 0;
            // 
            // ctrlBatchInfo
            // 
            this.ctrlBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlBatchInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlBatchInfo.Location = new System.Drawing.Point(1, 1);
            this.ctrlBatchInfo.Name = "ctrlBatchInfo";
            this.ctrlBatchInfo.Size = new System.Drawing.Size(714, 122);
            this.ctrlBatchInfo.TabIndex = 0;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.pnlCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Size = new System.Drawing.Size(728, 428);
            this.tbpCMF.TabIndex = 1;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.Visible = false;
            // 
            // pnlCMF
            // 
            this.pnlCMF.Controls.Add(this.grpCMF);
            this.pnlCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCMF.Location = new System.Drawing.Point(0, 0);
            this.pnlCMF.Name = "pnlCMF";
            this.pnlCMF.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCMF.Size = new System.Drawing.Size(728, 428);
            this.pnlCMF.TabIndex = 0;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.Location = new System.Drawing.Point(3, 3);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(722, 422);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(170, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 180;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(170, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 180;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(170, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 180;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(170, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 180;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(170, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 180;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(170, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 180;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(170, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 180;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(170, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 180;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(170, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 180;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(170, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 180;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(24, 236);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(24, 212);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(24, 188);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(24, 164);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(24, 140);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(24, 116);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(24, 92);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(24, 68);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(24, 44);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(24, 20);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpItem
            // 
            this.tbpItem.Controls.Add(this.grpSublotInfo);
            this.tbpItem.Location = new System.Drawing.Point(4, 22);
            this.tbpItem.Name = "tbpItem";
            this.tbpItem.Padding = new System.Windows.Forms.Padding(3);
            this.tbpItem.Size = new System.Drawing.Size(728, 428);
            this.tbpItem.TabIndex = 2;
            this.tbpItem.Text = "Item Information";
            this.tbpItem.Visible = false;
            // 
            // grpSublotInfo
            // 
            this.grpSublotInfo.Controls.Add(this.pnlSplitSublot);
            this.grpSublotInfo.Controls.Add(this.pnlSubChild);
            this.grpSublotInfo.Controls.Add(this.pnlSubMother);
            this.grpSublotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSublotInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSublotInfo.Location = new System.Drawing.Point(3, 3);
            this.grpSublotInfo.Name = "grpSublotInfo";
            this.grpSublotInfo.Size = new System.Drawing.Size(722, 422);
            this.grpSublotInfo.TabIndex = 1;
            this.grpSublotInfo.TabStop = false;
            this.grpSublotInfo.Resize += new System.EventHandler(this.grpSublotInfo_Resize);
            // 
            // pnlSplitSublot
            // 
            this.pnlSplitSublot.Controls.Add(this.btnSplit);
            this.pnlSplitSublot.Controls.Add(this.btnUnSplit);
            this.pnlSplitSublot.Location = new System.Drawing.Point(338, 93);
            this.pnlSplitSublot.Name = "pnlSplitSublot";
            this.pnlSplitSublot.Size = new System.Drawing.Size(46, 230);
            this.pnlSplitSublot.TabIndex = 0;
            // 
            // btnSplit
            // 
            this.btnSplit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSplit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSplit.Location = new System.Drawing.Point(11, 89);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(24, 24);
            this.btnSplit.TabIndex = 0;
            this.btnSplit.Text = ">";
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnUnSplit
            // 
            this.btnUnSplit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUnSplit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUnSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnSplit.Location = new System.Drawing.Point(11, 118);
            this.btnUnSplit.Name = "btnUnSplit";
            this.btnUnSplit.Size = new System.Drawing.Size(24, 24);
            this.btnUnSplit.TabIndex = 1;
            this.btnUnSplit.Text = "<";
            this.btnUnSplit.Click += new System.EventHandler(this.btnUnSplit_Click);
            // 
            // pnlSubChild
            // 
            this.pnlSubChild.Controls.Add(this.grpChildBatch);
            this.pnlSubChild.Location = new System.Drawing.Point(390, 20);
            this.pnlSubChild.Name = "pnlSubChild";
            this.pnlSubChild.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubChild.Size = new System.Drawing.Size(328, 388);
            this.pnlSubChild.TabIndex = 1;
            // 
            // grpChildBatch
            // 
            this.grpChildBatch.Controls.Add(this.pnlSubChildMid);
            this.grpChildBatch.Controls.Add(this.pnlSubChildTop);
            this.grpChildBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChildBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChildBatch.Location = new System.Drawing.Point(3, 3);
            this.grpChildBatch.Name = "grpChildBatch";
            this.grpChildBatch.Size = new System.Drawing.Size(322, 382);
            this.grpChildBatch.TabIndex = 0;
            this.grpChildBatch.TabStop = false;
            this.grpChildBatch.Text = "Child Batch";
            // 
            // pnlSubChildMid
            // 
            this.pnlSubChildMid.Controls.Add(this.lisChild);
            this.pnlSubChildMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubChildMid.Location = new System.Drawing.Point(3, 46);
            this.pnlSubChildMid.Name = "pnlSubChildMid";
            this.pnlSubChildMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubChildMid.Size = new System.Drawing.Size(316, 333);
            this.pnlSubChildMid.TabIndex = 1;
            // 
            // lisChild
            // 
            this.lisChild.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChildSeq,
            this.colChildItemID,
            this.colChildQty});
            this.lisChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisChild.EnableSort = true;
            this.lisChild.EnableSortIcon = true;
            this.lisChild.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisChild.FullRowSelect = true;
            this.lisChild.Location = new System.Drawing.Point(3, 3);
            this.lisChild.Name = "lisChild";
            this.lisChild.Size = new System.Drawing.Size(310, 327);
            this.lisChild.TabIndex = 1;
            this.lisChild.UseCompatibleStateImageBehavior = false;
            this.lisChild.View = System.Windows.Forms.View.Details;
            // 
            // colChildSeq
            // 
            this.colChildSeq.Text = "Seq";
            this.colChildSeq.Width = 47;
            // 
            // colChildItemID
            // 
            this.colChildItemID.Text = "Item ID";
            this.colChildItemID.Width = 110;
            // 
            // colChildQty
            // 
            this.colChildQty.Text = "Qty1";
            this.colChildQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlSubChildTop
            // 
            this.pnlSubChildTop.Controls.Add(this.txtMoveQty3);
            this.pnlSubChildTop.Controls.Add(this.txtMoveQty2);
            this.pnlSubChildTop.Controls.Add(this.txtMoveQty1);
            this.pnlSubChildTop.Controls.Add(this.lblMoveQty);
            this.pnlSubChildTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubChildTop.Location = new System.Drawing.Point(3, 16);
            this.pnlSubChildTop.Name = "pnlSubChildTop";
            this.pnlSubChildTop.Size = new System.Drawing.Size(316, 30);
            this.pnlSubChildTop.TabIndex = 0;
            // 
            // txtMoveQty3
            // 
            this.txtMoveQty3.Location = new System.Drawing.Point(242, 2);
            this.txtMoveQty3.MaxLength = 20;
            this.txtMoveQty3.Name = "txtMoveQty3";
            this.txtMoveQty3.Size = new System.Drawing.Size(68, 20);
            this.txtMoveQty3.TabIndex = 3;
            // 
            // txtMoveQty2
            // 
            this.txtMoveQty2.Location = new System.Drawing.Point(172, 2);
            this.txtMoveQty2.MaxLength = 20;
            this.txtMoveQty2.Name = "txtMoveQty2";
            this.txtMoveQty2.Size = new System.Drawing.Size(68, 20);
            this.txtMoveQty2.TabIndex = 2;
            // 
            // txtMoveQty1
            // 
            this.txtMoveQty1.Location = new System.Drawing.Point(102, 2);
            this.txtMoveQty1.MaxLength = 20;
            this.txtMoveQty1.Name = "txtMoveQty1";
            this.txtMoveQty1.ReadOnly = true;
            this.txtMoveQty1.Size = new System.Drawing.Size(68, 20);
            this.txtMoveQty1.TabIndex = 1;
            this.txtMoveQty1.TabStop = false;
            // 
            // lblMoveQty
            // 
            this.lblMoveQty.Location = new System.Drawing.Point(6, 4);
            this.lblMoveQty.Name = "lblMoveQty";
            this.lblMoveQty.Size = new System.Drawing.Size(95, 16);
            this.lblMoveQty.TabIndex = 0;
            this.lblMoveQty.Text = "Move Qty 1/2/3";
            // 
            // pnlSubMother
            // 
            this.pnlSubMother.Controls.Add(this.grpMotherBatch);
            this.pnlSubMother.Location = new System.Drawing.Point(8, 20);
            this.pnlSubMother.Name = "pnlSubMother";
            this.pnlSubMother.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubMother.Size = new System.Drawing.Size(326, 388);
            this.pnlSubMother.TabIndex = 0;
            // 
            // grpMotherBatch
            // 
            this.grpMotherBatch.Controls.Add(this.pnlSubMotherMid);
            this.grpMotherBatch.Controls.Add(this.pnlSubMotherTop);
            this.grpMotherBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMotherBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMotherBatch.Location = new System.Drawing.Point(3, 3);
            this.grpMotherBatch.Name = "grpMotherBatch";
            this.grpMotherBatch.Size = new System.Drawing.Size(320, 382);
            this.grpMotherBatch.TabIndex = 0;
            this.grpMotherBatch.TabStop = false;
            this.grpMotherBatch.Text = "Mother Batch";
            // 
            // pnlSubMotherMid
            // 
            this.pnlSubMotherMid.Controls.Add(this.lisMother);
            this.pnlSubMotherMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubMotherMid.Location = new System.Drawing.Point(3, 46);
            this.pnlSubMotherMid.Name = "pnlSubMotherMid";
            this.pnlSubMotherMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubMotherMid.Size = new System.Drawing.Size(314, 333);
            this.pnlSubMotherMid.TabIndex = 1;
            // 
            // lisMother
            // 
            this.lisMother.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colItemID,
            this.colQty});
            this.lisMother.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMother.EnableSort = true;
            this.lisMother.EnableSortIcon = true;
            this.lisMother.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMother.FullRowSelect = true;
            this.lisMother.Location = new System.Drawing.Point(3, 3);
            this.lisMother.Name = "lisMother";
            this.lisMother.Size = new System.Drawing.Size(308, 327);
            this.lisMother.TabIndex = 1;
            this.lisMother.UseCompatibleStateImageBehavior = false;
            this.lisMother.View = System.Windows.Forms.View.Details;
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 47;
            // 
            // colItemID
            // 
            this.colItemID.Text = "Item ID";
            this.colItemID.Width = 110;
            // 
            // colQty
            // 
            this.colQty.Text = "Qty1";
            this.colQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlSubMotherTop
            // 
            this.pnlSubMotherTop.Controls.Add(this.txtQty3);
            this.pnlSubMotherTop.Controls.Add(this.txtQty2);
            this.pnlSubMotherTop.Controls.Add(this.txtQty1);
            this.pnlSubMotherTop.Controls.Add(this.lblMotherQty);
            this.pnlSubMotherTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMotherTop.Location = new System.Drawing.Point(3, 16);
            this.pnlSubMotherTop.Name = "pnlSubMotherTop";
            this.pnlSubMotherTop.Size = new System.Drawing.Size(314, 30);
            this.pnlSubMotherTop.TabIndex = 0;
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(240, 2);
            this.txtQty3.MaxLength = 20;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(68, 20);
            this.txtQty3.TabIndex = 3;
            this.txtQty3.TabStop = false;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(170, 2);
            this.txtQty2.MaxLength = 20;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(68, 20);
            this.txtQty2.TabIndex = 2;
            this.txtQty2.TabStop = false;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(100, 2);
            this.txtQty1.MaxLength = 20;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(68, 20);
            this.txtQty1.TabIndex = 1;
            this.txtQty1.TabStop = false;
            // 
            // lblMotherQty
            // 
            this.lblMotherQty.Location = new System.Drawing.Point(6, 4);
            this.lblMotherQty.Name = "lblMotherQty";
            this.lblMotherQty.Size = new System.Drawing.Size(95, 16);
            this.lblMotherQty.TabIndex = 0;
            this.lblMotherQty.Text = "Qty 1/2/3";
            // 
            // tbpCreateCMF
            // 
            this.tbpCreateCMF.Controls.Add(this.grpCreateCMF);
            this.tbpCreateCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCreateCMF.Name = "tbpCreateCMF";
            this.tbpCreateCMF.Size = new System.Drawing.Size(728, 428);
            this.tbpCreateCMF.TabIndex = 3;
            this.tbpCreateCMF.Text = "Create CMF Field";
            // 
            // grpCreateCMF
            // 
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF2);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF9);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF8);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF7);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF6);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF5);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF4);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF3);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF2);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF10);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF1);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF10);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF9);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF8);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF7);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF6);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF5);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF4);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF3);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF1);
            this.grpCreateCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreateCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateCMF.Location = new System.Drawing.Point(0, 0);
            this.grpCreateCMF.Name = "grpCreateCMF";
            this.grpCreateCMF.Size = new System.Drawing.Size(728, 428);
            this.grpCreateCMF.TabIndex = 1;
            this.grpCreateCMF.TabStop = false;
            // 
            // lblCreateCMF2
            // 
            this.lblCreateCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF2.Location = new System.Drawing.Point(23, 43);
            this.lblCreateCMF2.Name = "lblCreateCMF2";
            this.lblCreateCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF2.TabIndex = 2;
            this.lblCreateCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCreateCMF9
            // 
            this.cdvCreateCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF9.BtnToolTipText = "";
            this.cdvCreateCMF9.DescText = "";
            this.cdvCreateCMF9.DisplaySubItemIndex = -1;
            this.cdvCreateCMF9.DisplayText = "";
            this.cdvCreateCMF9.Focusing = null;
            this.cdvCreateCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF9.Index = 0;
            this.cdvCreateCMF9.IsViewBtnImage = false;
            this.cdvCreateCMF9.Location = new System.Drawing.Point(170, 208);
            this.cdvCreateCMF9.MaxLength = 30;
            this.cdvCreateCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF9.Name = "cdvCreateCMF9";
            this.cdvCreateCMF9.ReadOnly = false;
            this.cdvCreateCMF9.SearchSubItemIndex = 0;
            this.cdvCreateCMF9.SelectedDescIndex = -1;
            this.cdvCreateCMF9.SelectedSubItemIndex = -1;
            this.cdvCreateCMF9.SelectionStart = 0;
            this.cdvCreateCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF9.SmallImageList = null;
            this.cdvCreateCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF9.TabIndex = 17;
            this.cdvCreateCMF9.TextBoxToolTipText = "";
            this.cdvCreateCMF9.TextBoxWidth = 180;
            this.cdvCreateCMF9.VisibleButton = true;
            this.cdvCreateCMF9.VisibleColumnHeader = false;
            this.cdvCreateCMF9.VisibleDescription = false;
            this.cdvCreateCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF9.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // cdvCreateCMF8
            // 
            this.cdvCreateCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF8.BtnToolTipText = "";
            this.cdvCreateCMF8.DescText = "";
            this.cdvCreateCMF8.DisplaySubItemIndex = -1;
            this.cdvCreateCMF8.DisplayText = "";
            this.cdvCreateCMF8.Focusing = null;
            this.cdvCreateCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF8.Index = 0;
            this.cdvCreateCMF8.IsViewBtnImage = false;
            this.cdvCreateCMF8.Location = new System.Drawing.Point(170, 184);
            this.cdvCreateCMF8.MaxLength = 30;
            this.cdvCreateCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF8.Name = "cdvCreateCMF8";
            this.cdvCreateCMF8.ReadOnly = false;
            this.cdvCreateCMF8.SearchSubItemIndex = 0;
            this.cdvCreateCMF8.SelectedDescIndex = -1;
            this.cdvCreateCMF8.SelectedSubItemIndex = -1;
            this.cdvCreateCMF8.SelectionStart = 0;
            this.cdvCreateCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF8.SmallImageList = null;
            this.cdvCreateCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF8.TabIndex = 15;
            this.cdvCreateCMF8.TextBoxToolTipText = "";
            this.cdvCreateCMF8.TextBoxWidth = 180;
            this.cdvCreateCMF8.VisibleButton = true;
            this.cdvCreateCMF8.VisibleColumnHeader = false;
            this.cdvCreateCMF8.VisibleDescription = false;
            this.cdvCreateCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF8.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // cdvCreateCMF7
            // 
            this.cdvCreateCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF7.BtnToolTipText = "";
            this.cdvCreateCMF7.DescText = "";
            this.cdvCreateCMF7.DisplaySubItemIndex = -1;
            this.cdvCreateCMF7.DisplayText = "";
            this.cdvCreateCMF7.Focusing = null;
            this.cdvCreateCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF7.Index = 0;
            this.cdvCreateCMF7.IsViewBtnImage = false;
            this.cdvCreateCMF7.Location = new System.Drawing.Point(170, 160);
            this.cdvCreateCMF7.MaxLength = 30;
            this.cdvCreateCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF7.Name = "cdvCreateCMF7";
            this.cdvCreateCMF7.ReadOnly = false;
            this.cdvCreateCMF7.SearchSubItemIndex = 0;
            this.cdvCreateCMF7.SelectedDescIndex = -1;
            this.cdvCreateCMF7.SelectedSubItemIndex = -1;
            this.cdvCreateCMF7.SelectionStart = 0;
            this.cdvCreateCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF7.SmallImageList = null;
            this.cdvCreateCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF7.TabIndex = 13;
            this.cdvCreateCMF7.TextBoxToolTipText = "";
            this.cdvCreateCMF7.TextBoxWidth = 180;
            this.cdvCreateCMF7.VisibleButton = true;
            this.cdvCreateCMF7.VisibleColumnHeader = false;
            this.cdvCreateCMF7.VisibleDescription = false;
            this.cdvCreateCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF7.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // cdvCreateCMF6
            // 
            this.cdvCreateCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF6.BtnToolTipText = "";
            this.cdvCreateCMF6.DescText = "";
            this.cdvCreateCMF6.DisplaySubItemIndex = -1;
            this.cdvCreateCMF6.DisplayText = "";
            this.cdvCreateCMF6.Focusing = null;
            this.cdvCreateCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF6.Index = 0;
            this.cdvCreateCMF6.IsViewBtnImage = false;
            this.cdvCreateCMF6.Location = new System.Drawing.Point(170, 136);
            this.cdvCreateCMF6.MaxLength = 30;
            this.cdvCreateCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF6.Name = "cdvCreateCMF6";
            this.cdvCreateCMF6.ReadOnly = false;
            this.cdvCreateCMF6.SearchSubItemIndex = 0;
            this.cdvCreateCMF6.SelectedDescIndex = -1;
            this.cdvCreateCMF6.SelectedSubItemIndex = -1;
            this.cdvCreateCMF6.SelectionStart = 0;
            this.cdvCreateCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF6.SmallImageList = null;
            this.cdvCreateCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF6.TabIndex = 11;
            this.cdvCreateCMF6.TextBoxToolTipText = "";
            this.cdvCreateCMF6.TextBoxWidth = 180;
            this.cdvCreateCMF6.VisibleButton = true;
            this.cdvCreateCMF6.VisibleColumnHeader = false;
            this.cdvCreateCMF6.VisibleDescription = false;
            this.cdvCreateCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF6.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // cdvCreateCMF5
            // 
            this.cdvCreateCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF5.BtnToolTipText = "";
            this.cdvCreateCMF5.DescText = "";
            this.cdvCreateCMF5.DisplaySubItemIndex = -1;
            this.cdvCreateCMF5.DisplayText = "";
            this.cdvCreateCMF5.Focusing = null;
            this.cdvCreateCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF5.Index = 0;
            this.cdvCreateCMF5.IsViewBtnImage = false;
            this.cdvCreateCMF5.Location = new System.Drawing.Point(170, 112);
            this.cdvCreateCMF5.MaxLength = 30;
            this.cdvCreateCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF5.Name = "cdvCreateCMF5";
            this.cdvCreateCMF5.ReadOnly = false;
            this.cdvCreateCMF5.SearchSubItemIndex = 0;
            this.cdvCreateCMF5.SelectedDescIndex = -1;
            this.cdvCreateCMF5.SelectedSubItemIndex = -1;
            this.cdvCreateCMF5.SelectionStart = 0;
            this.cdvCreateCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF5.SmallImageList = null;
            this.cdvCreateCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF5.TabIndex = 9;
            this.cdvCreateCMF5.TextBoxToolTipText = "";
            this.cdvCreateCMF5.TextBoxWidth = 180;
            this.cdvCreateCMF5.VisibleButton = true;
            this.cdvCreateCMF5.VisibleColumnHeader = false;
            this.cdvCreateCMF5.VisibleDescription = false;
            this.cdvCreateCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF5.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // cdvCreateCMF4
            // 
            this.cdvCreateCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF4.BtnToolTipText = "";
            this.cdvCreateCMF4.DescText = "";
            this.cdvCreateCMF4.DisplaySubItemIndex = -1;
            this.cdvCreateCMF4.DisplayText = "";
            this.cdvCreateCMF4.Focusing = null;
            this.cdvCreateCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF4.Index = 0;
            this.cdvCreateCMF4.IsViewBtnImage = false;
            this.cdvCreateCMF4.Location = new System.Drawing.Point(170, 88);
            this.cdvCreateCMF4.MaxLength = 30;
            this.cdvCreateCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF4.Name = "cdvCreateCMF4";
            this.cdvCreateCMF4.ReadOnly = false;
            this.cdvCreateCMF4.SearchSubItemIndex = 0;
            this.cdvCreateCMF4.SelectedDescIndex = -1;
            this.cdvCreateCMF4.SelectedSubItemIndex = -1;
            this.cdvCreateCMF4.SelectionStart = 0;
            this.cdvCreateCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF4.SmallImageList = null;
            this.cdvCreateCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF4.TabIndex = 7;
            this.cdvCreateCMF4.TextBoxToolTipText = "";
            this.cdvCreateCMF4.TextBoxWidth = 180;
            this.cdvCreateCMF4.VisibleButton = true;
            this.cdvCreateCMF4.VisibleColumnHeader = false;
            this.cdvCreateCMF4.VisibleDescription = false;
            this.cdvCreateCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF4.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // cdvCreateCMF3
            // 
            this.cdvCreateCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF3.BtnToolTipText = "";
            this.cdvCreateCMF3.DescText = "";
            this.cdvCreateCMF3.DisplaySubItemIndex = -1;
            this.cdvCreateCMF3.DisplayText = "";
            this.cdvCreateCMF3.Focusing = null;
            this.cdvCreateCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF3.Index = 0;
            this.cdvCreateCMF3.IsViewBtnImage = false;
            this.cdvCreateCMF3.Location = new System.Drawing.Point(170, 64);
            this.cdvCreateCMF3.MaxLength = 30;
            this.cdvCreateCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF3.Name = "cdvCreateCMF3";
            this.cdvCreateCMF3.ReadOnly = false;
            this.cdvCreateCMF3.SearchSubItemIndex = 0;
            this.cdvCreateCMF3.SelectedDescIndex = -1;
            this.cdvCreateCMF3.SelectedSubItemIndex = -1;
            this.cdvCreateCMF3.SelectionStart = 0;
            this.cdvCreateCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF3.SmallImageList = null;
            this.cdvCreateCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF3.TabIndex = 5;
            this.cdvCreateCMF3.TextBoxToolTipText = "";
            this.cdvCreateCMF3.TextBoxWidth = 180;
            this.cdvCreateCMF3.VisibleButton = true;
            this.cdvCreateCMF3.VisibleColumnHeader = false;
            this.cdvCreateCMF3.VisibleDescription = false;
            this.cdvCreateCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF3.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // cdvCreateCMF2
            // 
            this.cdvCreateCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF2.BtnToolTipText = "";
            this.cdvCreateCMF2.DescText = "";
            this.cdvCreateCMF2.DisplaySubItemIndex = -1;
            this.cdvCreateCMF2.DisplayText = "";
            this.cdvCreateCMF2.Focusing = null;
            this.cdvCreateCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF2.Index = 0;
            this.cdvCreateCMF2.IsViewBtnImage = false;
            this.cdvCreateCMF2.Location = new System.Drawing.Point(170, 40);
            this.cdvCreateCMF2.MaxLength = 30;
            this.cdvCreateCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF2.Name = "cdvCreateCMF2";
            this.cdvCreateCMF2.ReadOnly = false;
            this.cdvCreateCMF2.SearchSubItemIndex = 0;
            this.cdvCreateCMF2.SelectedDescIndex = -1;
            this.cdvCreateCMF2.SelectedSubItemIndex = -1;
            this.cdvCreateCMF2.SelectionStart = 0;
            this.cdvCreateCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF2.SmallImageList = null;
            this.cdvCreateCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF2.TabIndex = 3;
            this.cdvCreateCMF2.TextBoxToolTipText = "";
            this.cdvCreateCMF2.TextBoxWidth = 180;
            this.cdvCreateCMF2.VisibleButton = true;
            this.cdvCreateCMF2.VisibleColumnHeader = false;
            this.cdvCreateCMF2.VisibleDescription = false;
            this.cdvCreateCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF2.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // cdvCreateCMF10
            // 
            this.cdvCreateCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF10.BtnToolTipText = "";
            this.cdvCreateCMF10.DescText = "";
            this.cdvCreateCMF10.DisplaySubItemIndex = -1;
            this.cdvCreateCMF10.DisplayText = "";
            this.cdvCreateCMF10.Focusing = null;
            this.cdvCreateCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF10.Index = 0;
            this.cdvCreateCMF10.IsViewBtnImage = false;
            this.cdvCreateCMF10.Location = new System.Drawing.Point(170, 232);
            this.cdvCreateCMF10.MaxLength = 30;
            this.cdvCreateCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF10.Name = "cdvCreateCMF10";
            this.cdvCreateCMF10.ReadOnly = false;
            this.cdvCreateCMF10.SearchSubItemIndex = 0;
            this.cdvCreateCMF10.SelectedDescIndex = -1;
            this.cdvCreateCMF10.SelectedSubItemIndex = -1;
            this.cdvCreateCMF10.SelectionStart = 0;
            this.cdvCreateCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF10.SmallImageList = null;
            this.cdvCreateCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF10.TabIndex = 19;
            this.cdvCreateCMF10.TextBoxToolTipText = "";
            this.cdvCreateCMF10.TextBoxWidth = 180;
            this.cdvCreateCMF10.VisibleButton = true;
            this.cdvCreateCMF10.VisibleColumnHeader = false;
            this.cdvCreateCMF10.VisibleDescription = false;
            this.cdvCreateCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF10.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // cdvCreateCMF1
            // 
            this.cdvCreateCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF1.BtnToolTipText = "";
            this.cdvCreateCMF1.DescText = "";
            this.cdvCreateCMF1.DisplaySubItemIndex = -1;
            this.cdvCreateCMF1.DisplayText = "";
            this.cdvCreateCMF1.Focusing = null;
            this.cdvCreateCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF1.Index = 0;
            this.cdvCreateCMF1.IsViewBtnImage = false;
            this.cdvCreateCMF1.Location = new System.Drawing.Point(170, 16);
            this.cdvCreateCMF1.MaxLength = 30;
            this.cdvCreateCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF1.Name = "cdvCreateCMF1";
            this.cdvCreateCMF1.ReadOnly = false;
            this.cdvCreateCMF1.SearchSubItemIndex = 0;
            this.cdvCreateCMF1.SelectedDescIndex = -1;
            this.cdvCreateCMF1.SelectedSubItemIndex = -1;
            this.cdvCreateCMF1.SelectionStart = 0;
            this.cdvCreateCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF1.SmallImageList = null;
            this.cdvCreateCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF1.TabIndex = 1;
            this.cdvCreateCMF1.TextBoxToolTipText = "";
            this.cdvCreateCMF1.TextBoxWidth = 180;
            this.cdvCreateCMF1.VisibleButton = true;
            this.cdvCreateCMF1.VisibleColumnHeader = false;
            this.cdvCreateCMF1.VisibleDescription = false;
            this.cdvCreateCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            this.cdvCreateCMF1.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            // 
            // lblCreateCMF10
            // 
            this.lblCreateCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF10.Location = new System.Drawing.Point(23, 235);
            this.lblCreateCMF10.Name = "lblCreateCMF10";
            this.lblCreateCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF10.TabIndex = 18;
            this.lblCreateCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF9
            // 
            this.lblCreateCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF9.Location = new System.Drawing.Point(23, 211);
            this.lblCreateCMF9.Name = "lblCreateCMF9";
            this.lblCreateCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF9.TabIndex = 16;
            this.lblCreateCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF8
            // 
            this.lblCreateCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF8.Location = new System.Drawing.Point(23, 187);
            this.lblCreateCMF8.Name = "lblCreateCMF8";
            this.lblCreateCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF8.TabIndex = 14;
            this.lblCreateCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF7
            // 
            this.lblCreateCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF7.Location = new System.Drawing.Point(23, 163);
            this.lblCreateCMF7.Name = "lblCreateCMF7";
            this.lblCreateCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF7.TabIndex = 12;
            this.lblCreateCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF6
            // 
            this.lblCreateCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF6.Location = new System.Drawing.Point(23, 139);
            this.lblCreateCMF6.Name = "lblCreateCMF6";
            this.lblCreateCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF6.TabIndex = 10;
            this.lblCreateCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF5
            // 
            this.lblCreateCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF5.Location = new System.Drawing.Point(23, 115);
            this.lblCreateCMF5.Name = "lblCreateCMF5";
            this.lblCreateCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF5.TabIndex = 8;
            this.lblCreateCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF4
            // 
            this.lblCreateCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF4.Location = new System.Drawing.Point(23, 91);
            this.lblCreateCMF4.Name = "lblCreateCMF4";
            this.lblCreateCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF4.TabIndex = 6;
            this.lblCreateCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF3
            // 
            this.lblCreateCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF3.Location = new System.Drawing.Point(23, 67);
            this.lblCreateCMF3.Name = "lblCreateCMF3";
            this.lblCreateCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF3.TabIndex = 4;
            this.lblCreateCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF1
            // 
            this.lblCreateCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF1.Location = new System.Drawing.Point(23, 20);
            this.lblCreateCMF1.Name = "lblCreateCMF1";
            this.lblCreateCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF1.TabIndex = 0;
            this.lblCreateCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmQCMTranSplitQCMBatch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmQCMTranSplitQCMBatch";
            this.Tag = "QCM2005";
            this.Text = "Split QCM Batch";
            this.Load += new System.EventHandler(this.frmQCMTranSplitQCMBatch_Load);
            this.Activated += new System.EventHandler(this.frmQCMTranSplitQCMBatch_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMainTop.ResumeLayout(false);
            this.grpBatchID.ResumeLayout(false);
            this.grpBatchID.PerformLayout();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.pnlMainMiddle.ResumeLayout(false);
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlGeneralMiddle.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlChildBatchInfo.ResumeLayout(false);
            this.grpChildBatchInfo.ResumeLayout(false);
            this.grpChildBatchInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvVendor)).EndInit();
            this.pnlChildBatchTop.ResumeLayout(false);
            this.grpChildBatchID.ResumeLayout(false);
            this.grpChildBatchID.PerformLayout();
            this.grpDefect.ResumeLayout(false);
            this.pnlDefect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect_Sheet1)).EndInit();
            this.pnlDefectInspItem.ResumeLayout(false);
            this.pnlDefectInspItem.PerformLayout();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.pnlGeneralTop.ResumeLayout(false);
            this.grpBatInfo.ResumeLayout(false);
            this.pnlBatchInfoMain.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.pnlCMF.ResumeLayout(false);
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
            this.tbpItem.ResumeLayout(false);
            this.grpSublotInfo.ResumeLayout(false);
            this.pnlSplitSublot.ResumeLayout(false);
            this.pnlSubChild.ResumeLayout(false);
            this.grpChildBatch.ResumeLayout(false);
            this.pnlSubChildMid.ResumeLayout(false);
            this.pnlSubChildTop.ResumeLayout(false);
            this.pnlSubChildTop.PerformLayout();
            this.pnlSubMother.ResumeLayout(false);
            this.grpMotherBatch.ResumeLayout(false);
            this.pnlSubMotherMid.ResumeLayout(false);
            this.pnlSubMotherTop.ResumeLayout(false);
            this.pnlSubMotherTop.PerformLayout();
            this.tbpCreateCMF.ResumeLayout(false);
            this.grpCreateCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool bLoadFlag;
        
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
                switch (ProcStep)
                {
                    case '1':
                        
                        //Initialize
                        MPCF.FieldClear(this);
                        ctrlBatchInfo.ClearBatchInfo();
                        
                        MPCF.InitListView(lisMother);
                        MPCF.InitListView(lisChild);
                        
                        txtQty1.Text = "0";
                        txtQty2.Text = "0";
                        txtQty3.Text = "0";
                        
                        txtMoveQty1.Text = "0";
                        txtMoveQty2.Text = "0";
                        txtMoveQty3.Text = "0";
                        break;
                        
                    case '2':
                        
                        //LotID ?…ë ¥ ?±ê³µ ??
                        MPCF.FieldClear(this, txtBatchID, null, null, null, null, false);
                        if (ctrlBatchInfo.ViewBatchInformation(txtBatchID.Text, "") == false)
                        {
                            txtBatchID.Focus();
                            return;
                        }
                        
                        if (Init_Tran_Control(ctrlBatchInfo.InspType) == false)
                        {
                            return;
                        }
                        
                        txtQty1.Text = ctrlBatchInfo.Qty1;
                        //txtQty2.Text = ctrlBatchInfo.Qty2;
                        //txtQty3.Text = ctrlBatchInfo.Qty3;
                        cdvInspSetID.Text = ctrlBatchInfo.InspSet;
                        txtPO.Text = ctrlBatchInfo.PO;
                        txtPOItem.Text = ctrlBatchInfo.POItem;
                        txtQty.Text = ctrlBatchInfo.Qty1;
                        txtInvoice.Text = ctrlBatchInfo.Invoice;
                        cdvCustomer.Text = ctrlBatchInfo.Customer;
                        txtBOXID.Text = ctrlBatchInfo.BoxID;
                        cdvVendor.Text = ctrlBatchInfo.Venodr;
                        txtRetDlvId.Text = ctrlBatchInfo.RetDlvID;
                        cdvOrderID.Text = ctrlBatchInfo.OrderID;
                        
                        lisChild.Items.Clear();
                        if (View_Batch_Item_List(lisMother, txtBatchID.Text, ctrlBatchInfo.InspSet, MPCF.ToInt(ctrlBatchInfo.InspSetVersion)) == false)
                        {
                            return;
                        }
                        break;
                        
                    case '3':
                        
                        //Split Batch ?±ê³µ??txtBatchID, ctrlBatchInfoë¥??œì™¸??Field Clear
                        MPCF.FieldClear(this, txtBatchID, null, null, null, null, false);
                        if (ctrlBatchInfo.ViewBatchInformation(txtBatchID.Text, "") == false)
                        {
                            txtBatchID.Focus();
                            return;
                        }
                        
                        if (Init_Tran_Control(ctrlBatchInfo.InspType) == false)
                        {
                            return;
                        }
                        
                        lisChild.Items.Clear();
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
                case "SPLIT_BATCH":

                    if (MPCF.CheckValue(txtBatchID, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.Trim(ctrlBatchInfo.InspType) == "")
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Inspection Type]");
                        txtBatchID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(ctrlBatchInfo.MatID) == "")
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                        txtBatchID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(ctrlBatchInfo.InspSet) == "")
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Inspection Set]");
                        txtBatchID.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(txtChildBatchID, 1, false, false, "", "", "") == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        txtChildBatchID.Focus();
                        return false;
                    }
                    if (txtQty1.ReadOnly == false)
                    {
                        if (txtQty1.Text == "")
                        {
                            txtQty1.Text = null;
                        }
                        if (MPCF.CheckValue(txtQty1, 2, false, false, "", "", "") == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty1.Focus();
                            return false;
                        }
                    }
                    if (txtQty2.ReadOnly == false)
                    {
                        if (txtQty2.Text == "")
                        {
                            txtQty2.Text = null;
                        }
                        if (MPCF.CheckValue(txtQty2, 2, false, false, "", "", "") == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty2.Focus();
                            return false;
                        }
                    }
                    if (txtQty3.ReadOnly == false)
                    {
                        if (txtQty3.Text == "")
                        {
                            txtQty3.Text = null;
                        }
                        if (MPCF.CheckValue(txtQty3, 2, false, false, "", "", "") == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty3.Focus();
                            return false;
                        }
                    }
                    if (txtQty1.Text != "" && txtQty1.Text != "0")
                    {
                        if (MPCF.ToDbl(MPCF.Trim(ctrlBatchInfo.Qty1)) < MPCF.ToDbl(txtQty1.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(135));
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty1.Text = "0";
                            txtQty1.Focus();
                            return false;
                        }
                    }
                    //if (txtQty2.Text != "" && txtQty2.Text != "0")
                    //{
                    //    if (MPCF.ToDbl(MPCF.Trim(ctrlBatchInfo.Qty2)) < MPCF.ToDbl(txtQty2.Text))
                    //    {
                    //        MPCF.ShowMsgBox(MPCF.GetMessage(135));
                    //        tabTran.SelectedTab = tbpGeneral;
                    //        txtQty2.Text = "0";
                    //        txtQty2.Focus();
                    //        return false;
                    //    }
                    //}
                    //if (txtQty3.Text != "" && txtQty3.Text != "0")
                    //{
                    //    if (MPCF.ToDbl(MPCF.Trim(ctrlBatchInfo.Qty3)) < MPCF.ToDbl(txtQty3.Text))
                    //    {
                    //        MPCF.ShowMsgBox(MPCF.GetMessage(135));
                    //        tabTran.SelectedTab = tbpGeneral;
                    //        txtQty3.Text = "0";
                    //        txtQty3.Focus();
                    //        return false;
                    //    }
                    //}
                    
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCreateCMF", "cdvCreateCMF", grpCreateCMF) == false)
                    {
                        tabTran.SelectedTab = tbpCreateCMF;
                        return false;
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        //
        // Split_Batch()
        //       - Split Batch
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Split_Batch(char ProcStep)
        {
            TRSNode in_node = new TRSNode("SPLIT_BATCH_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

        
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(ctrlBatchInfo.HistSeq));

                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));

                in_node.AddString("CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddString("BATCH_CMF_1", MPCF.Trim(cdvCreateCMF1.Text));
                in_node.AddString("BATCH_CMF_2", MPCF.Trim(cdvCreateCMF2.Text));
                in_node.AddString("BATCH_CMF_3", MPCF.Trim(cdvCreateCMF3.Text));
                in_node.AddString("BATCH_CMF_4", MPCF.Trim(cdvCreateCMF4.Text));
                in_node.AddString("BATCH_CMF_5", MPCF.Trim(cdvCreateCMF5.Text));
                in_node.AddString("BATCH_CMF_6", MPCF.Trim(cdvCreateCMF6.Text));
                in_node.AddString("BATCH_CMF_7", MPCF.Trim(cdvCreateCMF7.Text));
                in_node.AddString("BATCH_CMF_8", MPCF.Trim(cdvCreateCMF8.Text));
                in_node.AddString("BATCH_CMF_9", MPCF.Trim(cdvCreateCMF9.Text));
                in_node.AddString("BATCH_CMF_10", MPCF.Trim(cdvCreateCMF10.Text));

                in_node.AddString("CHILD_BATCH_ID", MPCF.Trim(txtChildBatchID.Text));
                in_node.AddString("CHILD_MAT_ID", ctrlBatchInfo.MatID);
                in_node.AddInt("CHILD_MAT_VER", ctrlBatchInfo.MatVer);
                in_node.AddString("CHILD_INSP_SET_ID", MPCF.Trim(cdvInspSetID.Text));
                in_node.AddString("CHILD_INSP_TYPE", ctrlBatchInfo.InspType);

                if (MPCF.Trim(ctrlBatchInfo.InspType) == MPGC.MP_QCM_INSP_TYPE_IQC)
                {
                    in_node.AddString("CHILD_PO", MPCF.Trim(txtPO.Text));
                    in_node.AddString("CHILD_PO_ITEM", MPCF.Trim(txtPOItem.Text));
                    in_node.AddString("CHILD_INVOICE", MPCF.Trim(txtInvoice.Text));
                    in_node.AddString("CHILD_BOX_ID", MPCF.Trim(txtBOXID.Text));
                    in_node.AddString("CHILD_VENDOR", MPCF.Trim(cdvVendor.Text));
                }
                else if (MPCF.Trim(ctrlBatchInfo.InspType) == MPGC.MP_QCM_INSP_TYPE_OQC)
                {
                    in_node.AddString("CHILD_CUSTOMER", MPCF.Trim(cdvCustomer.Text));
                    in_node.AddString("CHILD_ORDER_ID", MPCF.Trim(cdvOrderID.Text));
                }
                else if (MPCF.Trim(ctrlBatchInfo.InspType) == MPGC.MP_QCM_INSP_TYPE_PQC)
                {
                }
                else if (MPCF.Trim(ctrlBatchInfo.InspType) == MPGC.MP_QCM_INSP_TYPE_RMA)
                {
                    in_node.AddString("CHILD_CUSTOMER", MPCF.Trim(cdvCustomer.Text));
                    in_node.AddString("CHILD_RET_DLV_ID", MPCF.Trim(txtRetDlvId.Text));

                }
                
                SetSplitSublot(ref in_node);
                
                if (in_node.GetList(0).Count < 1)
                {
                    return false;
                }
                
                if (txtMoveQty1.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_1", MPCF.ToDbl(txtMoveQty1.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_1", 0);
                }
                if (txtMoveQty2.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_2", MPCF.ToDbl(txtMoveQty2.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_2", 0);
                }
                if (txtMoveQty3.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_3", MPCF.ToDbl(txtMoveQty3.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_3", 0);
                }
                
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("QCM", "QCM_Split_Batch", in_node, ref out_node) == false)
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
        private bool View_Batch_Item_List(ListView control, string sBatchID, string sInspSet, int sInspSetVersion)
        {
            TRSNode in_node = new TRSNode("VIEW_BATCH_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_ITEM_LIST_OUT");
            ListViewItem itmX;
            int i;
            
            try
            {
                
                MPCF.InitListView(control);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BATCH_ID", sBatchID);
                in_node.AddString("INSP_SET_ID", sInspSet);
                in_node.AddInt("INSP_SET_VERSION", sInspSetVersion);
                in_node.AddString("NEXT_ITEM_ID", "");
                
                do
                {

                    if (MPCR.CallService("QCM", "QCM_View_Batch_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(System.Convert.ToString (i + 1));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ITEM_ID"));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetDouble("ITEM_QTY_1").ToString());
                        //itmX.SubItems.Add(Trim(View_Batch_Item_List_Out.item_list[i].result_flag))
                        //itmX.SubItems.Add(Trim(View_Batch_Item_List_Out.item_list[i].defect_code))
                        //itmX.SubItems.Add(Trim(View_Batch_Item_List_Out.item_list[i].comment))
                        //itmX.SubItems.Add(Trim(View_Batch_Item_List_Out.item_list[i].item_status))
                        //itmX.SubItems.Add(MakeDateFormat(View_Batch_Item_List_Out.item_list[i].tran_time))
                        //itmX.SubItems.Add(Trim(View_Batch_Item_List_Out.item_list[i].user_id))
                        
                        control.Items.Add(itmX);
                    }
                    
                    in_node.SetString("NEXT_ITEM_ID", out_node.GetString("NEXT_ITEM_ID"));

                } while (in_node.GetString("NEXT_ITEM_ID") != "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }
        
        //
        // View_Inspection_Set()
        //       - View Inspection Set Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Inspection_Set(string sInspSetID)
        {
            TRSNode in_node = new TRSNode("VIEW_INSPECTION_SET_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_SET_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INSP_SET_ID", MPCF.Trim(sInspSetID));

                if (MPCR.CallService("QCM", "QCM_Split_Batch", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtMaxSetQty.Text = out_node.GetString("MAX_QTY");
            
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        private void SetSplitSublot(ref TRSNode in_node)
        {
            int i;
            int iCnt;
            
            iCnt = MPCF.ToInt(MPCF.ToDbl(txtMoveQty1.Text));
            if (iCnt < 1)
            {
                return;
            }

            //sp_in._C.item_tbl = new QCM_SPLIT_BATCH_IN_TAG_item_tbl[iCnt + 1];
            
            for (i = 0; i <= lisChild.Items.Count - 1; i++)
            {
                TRSNode node = in_node.AddNode("ITEM_TBL");
                node.AddString("item_id", lisChild.Items[i].SubItems[1].Text);
            }
            
        }
        
        private bool Init_Tran_Control(object sInspType)
        {
            
            if (MPCF.Trim(sInspType) == "")
            {
                return false;
            }
            
            cdvInspSetID.Init();
            MPCF.InitListView(cdvInspSetID.GetListView);
            cdvInspSetID.Columns.Add("Insp. Set", 100, HorizontalAlignment.Left);
            cdvInspSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvInspSetID.SelectedSubItemIndex = 0;
            QCMLIST.ViewInspectionSetList(cdvInspSetID.GetListView, '2', MPCF.Trim(sInspType), "", null, "");
            
            lblCustomer.Visible = false;
            cdvCustomer.Visible = false;
            lblOrderID.Visible = false;
            cdvOrderID.Visible = false;
            lblPO.Visible = false;
            txtPO.Visible = false;
            txtPOItem.Visible = false;
            lblInvoice.Visible = false;
            txtInvoice.Visible = false;
            lblBoxID.Visible = false;
            txtBOXID.Visible = false;
            lblVendor.Visible = false;
            cdvVendor.Visible = false;
            lblRetDlvID.Visible = false;
            txtRetDlvId.Visible = false;
            if (MPCF.Trim(sInspType) == MPGC.MP_QCM_INSP_TYPE_OQC)
            {
                lblCustomer.Visible = true;
                cdvCustomer.Visible = true;
                lblOrderID.Visible = true;
                cdvOrderID.Visible = true;
            }
            else if (MPCF.Trim(sInspType) == MPGC.MP_QCM_INSP_TYPE_IQC)
            {
                lblPO.Visible = true;
                txtPO.Visible = true;
                txtPOItem.Visible = true;
                lblInvoice.Visible = true;
                txtInvoice.Visible = true;
                lblBoxID.Visible = true;
                txtBOXID.Visible = true;
                lblVendor.Visible = true;
                cdvVendor.Visible = true;
            }
            else if (MPCF.Trim(sInspType) == MPGC.MP_QCM_INSP_TYPE_PQC)
            {
                
            }
            else if (MPCF.Trim(sInspType) == MPGC.MP_QCM_INSP_TYPE_RMA)
            {
                lblCustomer.Visible = true;
                cdvCustomer.Visible = true;
                lblRetDlvID.Visible = true;
                txtRetDlvId.Visible = true;
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
        
        private void frmQCMTranSplitQCMBatch_Load(object sender, System.EventArgs e)
        {
            
            pnlTranTime.Visible = MPGO.UseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
        }
        
        private void frmQCMTranSplitQCMBatch_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (bLoadFlag == false)
                {
                    
                    ClearData('1');
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_QCM_SPLIT, "lblCMF", "cdvCMF", grpCMF);
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_QCM_BATCH, "lblCreateCMF", "cdvCreateCMF", grpCreateCMF);
                    
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtBatchID.Text = MPGV.gsCurrentLot_ID;
                        ClearData('2');
                    }
                    
                    bLoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCMF_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }
        
        private void cdvCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }
        
        private void txtBatchID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13)
            {
                ClearData('2');
            }
            
        }
        
        private void txtChildBatchID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13)
            {
                lisChild.Items.Clear();
            }
            
        }
        
        private void cdvCreateCMF_ButtonPress(object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        
        private void cdvCreateCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            MPCR.CheckCMFKeyPress(sender, e);
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("SPLIT_BATCH") == true)
                {
                    if (Split_Batch('1') == false)
                    {
                        return;
                    }

                    ClearData('3');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnSplit_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            ListViewItem ItmX;
            
            if (lisMother.SelectedItems.Count < 1)
            {
                return;
            }
            
            for (i = 0; i <= lisMother.SelectedItems.Count - 1; i++)
            {
                if (lisMother.Items[i].Selected == true)
                {
                    
                    txtMoveQty1.Text =  MPCF.Trim(MPCF.ToDbl(txtMoveQty1.Text) + MPCF.ToDbl(lisMother.Items[i].SubItems[2].Text));
                    txtQty1.Text = MPCF.Trim(MPCF.ToDbl(txtQty1.Text) - MPCF.ToDbl(lisMother.Items[i].SubItems[2].Text));
                    //txtMoveQty2.Text = Val(txtMoveQty2.Text) + Val(lisMother.Items[i].SubItems(3).Text)
                    //txtQty2.Text = Val(txtQty2.Text) - Val(lisMother.Items[i].SubItems(3).Text)

                    ItmX = new ListViewItem(lisChild.Items.Count.ToString());
                    ItmX.SubItems[1].Text = lisMother.Items[i].SubItems[1].Text;
                    ItmX.SubItems[2].Text = lisMother.Items[i].SubItems[2].Text;
                    
                    lisChild.Items.Add(ItmX);
                    
                    lisMother.Items[i].Remove();
                    
                    i--;
                }
            }
            
        }
        
        private void btnUnSplit_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            ListViewItem ItmX;
            
            try
            {
                if (lisChild.SelectedItems.Count < 1)
                {
                    return;
                }
                
                for (i = 0; i <= lisChild.SelectedItems.Count - 1; i++)
                {
                    if (lisChild.Items[i].Selected == true)
                    {

                        txtMoveQty1.Text = MPCF.Trim(MPCF.ToDbl(txtMoveQty1.Text) - MPCF.ToDbl(lisChild.Items[i].SubItems[2].Text));
                        txtQty1.Text = MPCF.Trim(MPCF.ToDbl(txtQty1.Text) + MPCF.ToDbl(lisChild.Items[i].SubItems[2].Text));
                        //txtMoveQty2.Text = Val(txtMoveQty2.Text) - Val(lisChild.Items[i].SubItems(3).Text)
                        //txtQty2.Text = Val(txtQty2.Text) + Val(lisChild.Items[i].SubItems(3).Text)
                        
                        ItmX = new ListViewItem(lisMother.Items.Count.ToString());
                        ItmX.SubItems[1].Text = lisChild.Items[i].SubItems[1].Text;
                        ItmX.SubItems[2].Text = lisChild.Items[i].SubItems[2].Text;
                        
                        lisMother.Items.Add(ItmX);
                        
                        lisChild.Items[i].Remove();
                        
                        i--;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void grpSublotInfo_Resize(object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(grpSublotInfo, pnlSubMother, pnlSubChild, pnlSplitSublot, 40);
            
        }
        
        private void cdvVendor_ButtonPress(object sender, System.EventArgs e)
        {
            cdvVendor.Init();
            MPCF.InitListView(cdvVendor.GetListView);
            cdvVendor.Columns.Add("Vendor", 100, HorizontalAlignment.Left);
            cdvVendor.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvVendor.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvVendor.GetListView, '1', MPGC.MP_QCM_VENDOR);
        }
        
        private void cdvCustomer_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCustomer.Init();
            MPCF.InitListView(cdvCustomer.GetListView);
            cdvCustomer.Columns.Add("Customer", 100, HorizontalAlignment.Left);
            cdvCustomer.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCustomer.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCustomer.GetListView, '1', MPGC.MP_QCM_CUSTOMER);
        }
        
        private void cdvOrderID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOrderID.Init();
            MPCF.InitListView(cdvOrderID.GetListView);
            cdvOrderID.Columns.Add("Order", 100, HorizontalAlignment.Left);
            cdvOrderID.Columns.Add("Mat ID", 200, HorizontalAlignment.Left);
            cdvOrderID.Columns.Add("Mat Ver", 200, HorizontalAlignment.Left);
            cdvOrderID.Columns.Add("Order Qty", 200, HorizontalAlignment.Left);
            cdvOrderID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOrderID.SelectedSubItemIndex = 0;
            #if _ORD
            ORDLIST.ViewOrderList(cdvOrderID.GetListView, '1', "", null, "");
            #endif
        }
        
        private void cdvInspSetID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInspSetID.Init();
            MPCF.InitListView(cdvInspSetID.GetListView);
            cdvInspSetID.Columns.Add("Order", 100, HorizontalAlignment.Left);
            cdvInspSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvInspSetID.SelectedSubItemIndex = 0;
        }
        
        private void cdvInspSetID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            if (cdvInspSetID.Text == "")
            {
                return;
            }
            View_Inspection_Set(cdvInspSetID.Text);
        }
        
    }
    
    //#End If
    
}
