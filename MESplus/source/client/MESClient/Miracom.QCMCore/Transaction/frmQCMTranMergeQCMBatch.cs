
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
//   File Name   : frmQCMTranMergeQCMBatch.vb
//   Description : Merge Batch Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - Merge_Batch() : Merge Batch transaction
//
//   Detail Description
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
    public class frmQCMTranMergeQCMBatch : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMTranMergeQCMBatch()
        {
            
            //???∏Ï∂ú?Ä Windows Form ?îÏûê?¥ÎÑà???ÑÏöî?©Îãà??
            InitializeComponent();
            
            //InitializeComponent()Î•??∏Ï∂ú???§Ïùå??Ï¥àÍ∏∞???ëÏóÖ??Ï∂îÍ??òÏã≠?úÏò§.
            
        }
        
        //Form?Ä DisposeÎ•??¨Ï†ï?òÌïò??Íµ¨ÏÑ± ?îÏÜå Î™©Î°ù???ïÎ¶¨?©Îãà??
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
        
        //Windows Form ?îÏûê?¥ÎÑà???ÑÏöî?©Îãà??
        private System.ComponentModel.Container components = null;
        
        //Ï∞∏Í≥†: ?§Ïùå ?ÑÎ°ú?úÏ???Windows Form ?îÏûê?¥ÎÑà???ÑÏöî?©Îãà??
        //Windows Form ?îÏûê?¥ÎÑàÎ•??¨Ïö©?òÏó¨ ?òÏ†ï?????àÏäµ?àÎã§.
        //ÏΩîÎìú ?∏ÏßëÍ∏∞Î? ?¨Ïö©?òÏó¨ ?òÏ†ï?òÏ? ÎßàÏã≠?úÏò§.
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
        private System.Windows.Forms.Panel pnlTargetBatch;
        private System.Windows.Forms.GroupBox grpTargetBatch;
        protected System.Windows.Forms.Label lblTargetBatch;
        private System.Windows.Forms.GroupBox grpMoveQty;
        private System.Windows.Forms.Label lblQty3;
        private System.Windows.Forms.TextBox txtMoveQty3;
        private System.Windows.Forms.TextBox txtMoveQty2;
        private System.Windows.Forms.Label lblQty2;
        private System.Windows.Forms.TextBox txtMoveQty1;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.Panel pnlTargetBatchInfo;
        private System.Windows.Forms.GroupBox grpTargetBatchInfo;
        private System.Windows.Forms.Panel pnlTagetBatchnfoMain;
        private System.Windows.Forms.GroupBox grpSubBatchInfo;
        private System.Windows.Forms.Panel pnlSubMid;
        private System.Windows.Forms.Panel pnlSubChild;
        private System.Windows.Forms.GroupBox grpChildSubLot;
        private System.Windows.Forms.Panel pnlSubChildMid;
        private Miracom.UI.Controls.MCListView.MCListView lisTarget;
        private System.Windows.Forms.Panel pnlSubChildTop;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.TextBox TextBox3;
        private System.Windows.Forms.Label lblMoveQty;
        private System.Windows.Forms.Panel pnlSubMother;
        private System.Windows.Forms.GroupBox grpMotherSubBatch;
        private System.Windows.Forms.Panel pnlSubMotherMid;
        private Miracom.UI.Controls.MCListView.MCListView lisSource;
        private System.Windows.Forms.Panel pnlSubMotherTop;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.Label lblMotherQty;
        private System.Windows.Forms.ColumnHeader colTargetSeq;
        private System.Windows.Forms.ColumnHeader colTargetItemId;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colItemId;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.ColumnHeader colTargetQty;
        protected System.Windows.Forms.TextBox txtTargetBatchID;
        private Miracom.QCMCore.udcQCMBatchInfo ctrlBatchInfo;
        private Miracom.QCMCore.udcQCMBatchInfo ctrlTargetBatchInfo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
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
            this.pnlTargetBatchInfo = new System.Windows.Forms.Panel();
            this.grpTargetBatchInfo = new System.Windows.Forms.GroupBox();
            this.pnlTagetBatchnfoMain = new System.Windows.Forms.Panel();
            this.ctrlTargetBatchInfo = new Miracom.QCMCore.udcQCMBatchInfo();
            this.grpMoveQty = new System.Windows.Forms.GroupBox();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.txtMoveQty3 = new System.Windows.Forms.TextBox();
            this.txtMoveQty2 = new System.Windows.Forms.TextBox();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.txtMoveQty1 = new System.Windows.Forms.TextBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.pnlTargetBatch = new System.Windows.Forms.Panel();
            this.grpTargetBatch = new System.Windows.Forms.GroupBox();
            this.txtTargetBatchID = new System.Windows.Forms.TextBox();
            this.lblTargetBatch = new System.Windows.Forms.Label();
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
            this.grpSubBatchInfo = new System.Windows.Forms.GroupBox();
            this.pnlSubMid = new System.Windows.Forms.Panel();
            this.pnlSubChild = new System.Windows.Forms.Panel();
            this.grpChildSubLot = new System.Windows.Forms.GroupBox();
            this.pnlSubChildMid = new System.Windows.Forms.Panel();
            this.lisTarget = new Miracom.UI.Controls.MCListView.MCListView();
            this.colTargetSeq = new System.Windows.Forms.ColumnHeader();
            this.colTargetItemId = new System.Windows.Forms.ColumnHeader();
            this.colTargetQty = new System.Windows.Forms.ColumnHeader();
            this.pnlSubChildTop = new System.Windows.Forms.Panel();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.lblMoveQty = new System.Windows.Forms.Label();
            this.pnlSubMother = new System.Windows.Forms.Panel();
            this.grpMotherSubBatch = new System.Windows.Forms.GroupBox();
            this.pnlSubMotherMid = new System.Windows.Forms.Panel();
            this.lisSource = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = new System.Windows.Forms.ColumnHeader();
            this.colItemId = new System.Windows.Forms.ColumnHeader();
            this.colQty = new System.Windows.Forms.ColumnHeader();
            this.pnlSubMotherTop = new System.Windows.Forms.Panel();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblMotherQty = new System.Windows.Forms.Label();
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
            this.pnlTargetBatchInfo.SuspendLayout();
            this.grpTargetBatchInfo.SuspendLayout();
            this.pnlTagetBatchnfoMain.SuspendLayout();
            this.grpMoveQty.SuspendLayout();
            this.pnlTargetBatch.SuspendLayout();
            this.grpTargetBatch.SuspendLayout();
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
            this.grpSubBatchInfo.SuspendLayout();
            this.pnlSubChild.SuspendLayout();
            this.grpChildSubLot.SuspendLayout();
            this.pnlSubChildMid.SuspendLayout();
            this.pnlSubChildTop.SuspendLayout();
            this.pnlSubMother.SuspendLayout();
            this.grpMotherSubBatch.SuspendLayout();
            this.pnlSubMotherMid.SuspendLayout();
            this.pnlSubMotherTop.SuspendLayout();
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
            this.lblFormTitle.Text = "Merge QCM Batch";
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
            this.pnlTranInfo.Controls.Add(this.pnlTargetBatchInfo);
            this.pnlTranInfo.Controls.Add(this.grpMoveQty);
            this.pnlTranInfo.Controls.Add(this.pnlTargetBatch);
            this.pnlTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTranInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTranInfo.Name = "pnlTranInfo";
            this.pnlTranInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 242);
            this.pnlTranInfo.TabIndex = 0;
            // 
            // pnlTargetBatchInfo
            // 
            this.pnlTargetBatchInfo.Controls.Add(this.grpTargetBatchInfo);
            this.pnlTargetBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTargetBatchInfo.Location = new System.Drawing.Point(3, 44);
            this.pnlTargetBatchInfo.Name = "pnlTargetBatchInfo";
            this.pnlTargetBatchInfo.Size = new System.Drawing.Size(722, 154);
            this.pnlTargetBatchInfo.TabIndex = 6;
            // 
            // grpTargetBatchInfo
            // 
            this.grpTargetBatchInfo.Controls.Add(this.pnlTagetBatchnfoMain);
            this.grpTargetBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTargetBatchInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTargetBatchInfo.Location = new System.Drawing.Point(0, 0);
            this.grpTargetBatchInfo.Name = "grpTargetBatchInfo";
            this.grpTargetBatchInfo.Size = new System.Drawing.Size(722, 154);
            this.grpTargetBatchInfo.TabIndex = 0;
            this.grpTargetBatchInfo.TabStop = false;
            this.grpTargetBatchInfo.Text = "Target Batch Infomation";
            // 
            // pnlTagetBatchnfoMain
            // 
            this.pnlTagetBatchnfoMain.Controls.Add(this.ctrlTargetBatchInfo);
            this.pnlTagetBatchnfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTagetBatchnfoMain.Location = new System.Drawing.Point(3, 16);
            this.pnlTagetBatchnfoMain.Name = "pnlTagetBatchnfoMain";
            this.pnlTagetBatchnfoMain.Size = new System.Drawing.Size(716, 135);
            this.pnlTagetBatchnfoMain.TabIndex = 0;
            // 
            // ctrlTargetBatchInfo
            // 
            this.ctrlTargetBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTargetBatchInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlTargetBatchInfo.Location = new System.Drawing.Point(0, 0);
            this.ctrlTargetBatchInfo.Name = "ctrlTargetBatchInfo";
            this.ctrlTargetBatchInfo.Size = new System.Drawing.Size(716, 135);
            this.ctrlTargetBatchInfo.TabIndex = 0;
            // 
            // grpMoveQty
            // 
            this.grpMoveQty.Controls.Add(this.lblQty3);
            this.grpMoveQty.Controls.Add(this.txtMoveQty3);
            this.grpMoveQty.Controls.Add(this.txtMoveQty2);
            this.grpMoveQty.Controls.Add(this.lblQty2);
            this.grpMoveQty.Controls.Add(this.txtMoveQty1);
            this.grpMoveQty.Controls.Add(this.lblQty1);
            this.grpMoveQty.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMoveQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMoveQty.Location = new System.Drawing.Point(3, 198);
            this.grpMoveQty.Name = "grpMoveQty";
            this.grpMoveQty.Size = new System.Drawing.Size(722, 44);
            this.grpMoveQty.TabIndex = 1;
            this.grpMoveQty.TabStop = false;
            // 
            // lblQty3
            // 
            this.lblQty3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblQty3.Location = new System.Drawing.Point(439, 19);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(83, 13);
            this.lblQty3.TabIndex = 4;
            this.lblQty3.Text = "Move Qty 3";
            this.lblQty3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMoveQty3
            // 
            this.txtMoveQty3.Location = new System.Drawing.Point(527, 15);
            this.txtMoveQty3.MaxLength = 10;
            this.txtMoveQty3.Name = "txtMoveQty3";
            this.txtMoveQty3.ReadOnly = true;
            this.txtMoveQty3.Size = new System.Drawing.Size(96, 20);
            this.txtMoveQty3.TabIndex = 5;
            this.txtMoveQty3.TabStop = false;
            // 
            // txtMoveQty2
            // 
            this.txtMoveQty2.Location = new System.Drawing.Point(313, 15);
            this.txtMoveQty2.MaxLength = 10;
            this.txtMoveQty2.Name = "txtMoveQty2";
            this.txtMoveQty2.ReadOnly = true;
            this.txtMoveQty2.Size = new System.Drawing.Size(97, 20);
            this.txtMoveQty2.TabIndex = 3;
            this.txtMoveQty2.TabStop = false;
            // 
            // lblQty2
            // 
            this.lblQty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblQty2.Location = new System.Drawing.Point(226, 19);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(83, 13);
            this.lblQty2.TabIndex = 2;
            this.lblQty2.Text = "Move Qty 2";
            this.lblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMoveQty1
            // 
            this.txtMoveQty1.Location = new System.Drawing.Point(100, 15);
            this.txtMoveQty1.MaxLength = 10;
            this.txtMoveQty1.Name = "txtMoveQty1";
            this.txtMoveQty1.ReadOnly = true;
            this.txtMoveQty1.Size = new System.Drawing.Size(97, 20);
            this.txtMoveQty1.TabIndex = 1;
            this.txtMoveQty1.TabStop = false;
            // 
            // lblQty1
            // 
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblQty1.Location = new System.Drawing.Point(12, 19);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(84, 13);
            this.lblQty1.TabIndex = 0;
            this.lblQty1.Text = "Move Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTargetBatch
            // 
            this.pnlTargetBatch.Controls.Add(this.grpTargetBatch);
            this.pnlTargetBatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTargetBatch.Location = new System.Drawing.Point(3, 0);
            this.pnlTargetBatch.Name = "pnlTargetBatch";
            this.pnlTargetBatch.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTargetBatch.Size = new System.Drawing.Size(722, 44);
            this.pnlTargetBatch.TabIndex = 0;
            // 
            // grpTargetBatch
            // 
            this.grpTargetBatch.Controls.Add(this.txtTargetBatchID);
            this.grpTargetBatch.Controls.Add(this.lblTargetBatch);
            this.grpTargetBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTargetBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTargetBatch.Location = new System.Drawing.Point(3, 0);
            this.grpTargetBatch.Name = "grpTargetBatch";
            this.grpTargetBatch.Size = new System.Drawing.Size(716, 44);
            this.grpTargetBatch.TabIndex = 0;
            this.grpTargetBatch.TabStop = false;
            // 
            // txtTargetBatchID
            // 
            this.txtTargetBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTargetBatchID.Location = new System.Drawing.Point(120, 16);
            this.txtTargetBatchID.MaxLength = 30;
            this.txtTargetBatchID.Name = "txtTargetBatchID";
            this.txtTargetBatchID.Size = new System.Drawing.Size(200, 20);
            this.txtTargetBatchID.TabIndex = 1;
            this.txtTargetBatchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetBatchID_KeyPress);
            // 
            // lblTargetBatch
            // 
            this.lblTargetBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetBatch.Location = new System.Drawing.Point(16, 18);
            this.lblTargetBatch.Name = "lblTargetBatch";
            this.lblTargetBatch.Size = new System.Drawing.Size(100, 14);
            this.lblTargetBatch.TabIndex = 0;
            this.lblTargetBatch.Text = "Target Batch ID";
            this.lblTargetBatch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tbpItem.Controls.Add(this.grpSubBatchInfo);
            this.tbpItem.Location = new System.Drawing.Point(4, 22);
            this.tbpItem.Name = "tbpItem";
            this.tbpItem.Padding = new System.Windows.Forms.Padding(3);
            this.tbpItem.Size = new System.Drawing.Size(728, 428);
            this.tbpItem.TabIndex = 2;
            this.tbpItem.Text = "Item Information";
            this.tbpItem.Visible = false;
            // 
            // grpSubBatchInfo
            // 
            this.grpSubBatchInfo.Controls.Add(this.pnlSubMid);
            this.grpSubBatchInfo.Controls.Add(this.pnlSubChild);
            this.grpSubBatchInfo.Controls.Add(this.pnlSubMother);
            this.grpSubBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSubBatchInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSubBatchInfo.Location = new System.Drawing.Point(3, 3);
            this.grpSubBatchInfo.Name = "grpSubBatchInfo";
            this.grpSubBatchInfo.Size = new System.Drawing.Size(722, 422);
            this.grpSubBatchInfo.TabIndex = 3;
            this.grpSubBatchInfo.TabStop = false;
            // 
            // pnlSubMid
            // 
            this.pnlSubMid.Location = new System.Drawing.Point(354, 93);
            this.pnlSubMid.Name = "pnlSubMid";
            this.pnlSubMid.Size = new System.Drawing.Size(14, 230);
            this.pnlSubMid.TabIndex = 2;
            // 
            // pnlSubChild
            // 
            this.pnlSubChild.Controls.Add(this.grpChildSubLot);
            this.pnlSubChild.Location = new System.Drawing.Point(390, 20);
            this.pnlSubChild.Name = "pnlSubChild";
            this.pnlSubChild.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubChild.Size = new System.Drawing.Size(328, 388);
            this.pnlSubChild.TabIndex = 1;
            // 
            // grpChildSubLot
            // 
            this.grpChildSubLot.Controls.Add(this.pnlSubChildMid);
            this.grpChildSubLot.Controls.Add(this.pnlSubChildTop);
            this.grpChildSubLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChildSubLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChildSubLot.Location = new System.Drawing.Point(3, 3);
            this.grpChildSubLot.Name = "grpChildSubLot";
            this.grpChildSubLot.Size = new System.Drawing.Size(322, 382);
            this.grpChildSubLot.TabIndex = 0;
            this.grpChildSubLot.TabStop = false;
            this.grpChildSubLot.Text = "Target Lot";
            // 
            // pnlSubChildMid
            // 
            this.pnlSubChildMid.Controls.Add(this.lisTarget);
            this.pnlSubChildMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubChildMid.Location = new System.Drawing.Point(3, 46);
            this.pnlSubChildMid.Name = "pnlSubChildMid";
            this.pnlSubChildMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubChildMid.Size = new System.Drawing.Size(316, 333);
            this.pnlSubChildMid.TabIndex = 1;
            // 
            // lisTarget
            // 
            this.lisTarget.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTargetSeq,
            this.colTargetItemId,
            this.colTargetQty});
            this.lisTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisTarget.EnableSort = true;
            this.lisTarget.EnableSortIcon = true;
            this.lisTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisTarget.FullRowSelect = true;
            this.lisTarget.Location = new System.Drawing.Point(3, 3);
            this.lisTarget.Name = "lisTarget";
            this.lisTarget.Size = new System.Drawing.Size(310, 327);
            this.lisTarget.TabIndex = 0;
            this.lisTarget.UseCompatibleStateImageBehavior = false;
            this.lisTarget.View = System.Windows.Forms.View.Details;
            // 
            // colTargetSeq
            // 
            this.colTargetSeq.Text = "Seq.";
            this.colTargetSeq.Width = 80;
            // 
            // colTargetItemId
            // 
            this.colTargetItemId.Text = "Item ID";
            this.colTargetItemId.Width = 200;
            // 
            // colTargetQty
            // 
            this.colTargetQty.Text = "Qty";
            this.colTargetQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlSubChildTop
            // 
            this.pnlSubChildTop.Controls.Add(this.TextBox1);
            this.pnlSubChildTop.Controls.Add(this.TextBox2);
            this.pnlSubChildTop.Controls.Add(this.TextBox3);
            this.pnlSubChildTop.Controls.Add(this.lblMoveQty);
            this.pnlSubChildTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubChildTop.Location = new System.Drawing.Point(3, 16);
            this.pnlSubChildTop.Name = "pnlSubChildTop";
            this.pnlSubChildTop.Size = new System.Drawing.Size(316, 30);
            this.pnlSubChildTop.TabIndex = 0;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(242, 2);
            this.TextBox1.MaxLength = 20;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            this.TextBox1.Size = new System.Drawing.Size(68, 20);
            this.TextBox1.TabIndex = 3;
            this.TextBox1.TabStop = false;
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(172, 2);
            this.TextBox2.MaxLength = 20;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ReadOnly = true;
            this.TextBox2.Size = new System.Drawing.Size(68, 20);
            this.TextBox2.TabIndex = 2;
            this.TextBox2.TabStop = false;
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(102, 2);
            this.TextBox3.MaxLength = 20;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.ReadOnly = true;
            this.TextBox3.Size = new System.Drawing.Size(68, 20);
            this.TextBox3.TabIndex = 1;
            this.TextBox3.TabStop = false;
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
            this.pnlSubMother.Controls.Add(this.grpMotherSubBatch);
            this.pnlSubMother.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSubMother.Location = new System.Drawing.Point(3, 16);
            this.pnlSubMother.Name = "pnlSubMother";
            this.pnlSubMother.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubMother.Size = new System.Drawing.Size(327, 403);
            this.pnlSubMother.TabIndex = 0;
            // 
            // grpMotherSubBatch
            // 
            this.grpMotherSubBatch.Controls.Add(this.pnlSubMotherMid);
            this.grpMotherSubBatch.Controls.Add(this.pnlSubMotherTop);
            this.grpMotherSubBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMotherSubBatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMotherSubBatch.Location = new System.Drawing.Point(3, 3);
            this.grpMotherSubBatch.Name = "grpMotherSubBatch";
            this.grpMotherSubBatch.Size = new System.Drawing.Size(321, 397);
            this.grpMotherSubBatch.TabIndex = 0;
            this.grpMotherSubBatch.TabStop = false;
            this.grpMotherSubBatch.Text = "Source Lot";
            // 
            // pnlSubMotherMid
            // 
            this.pnlSubMotherMid.Controls.Add(this.lisSource);
            this.pnlSubMotherMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubMotherMid.Location = new System.Drawing.Point(3, 46);
            this.pnlSubMotherMid.Name = "pnlSubMotherMid";
            this.pnlSubMotherMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubMotherMid.Size = new System.Drawing.Size(315, 348);
            this.pnlSubMotherMid.TabIndex = 1;
            // 
            // lisSource
            // 
            this.lisSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colItemId,
            this.colQty});
            this.lisSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSource.EnableSort = true;
            this.lisSource.EnableSortIcon = true;
            this.lisSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSource.FullRowSelect = true;
            this.lisSource.Location = new System.Drawing.Point(3, 3);
            this.lisSource.Name = "lisSource";
            this.lisSource.Size = new System.Drawing.Size(309, 342);
            this.lisSource.TabIndex = 0;
            this.lisSource.UseCompatibleStateImageBehavior = false;
            this.lisSource.View = System.Windows.Forms.View.Details;
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq.";
            this.colSeq.Width = 80;
            // 
            // colItemId
            // 
            this.colItemId.Text = "Item ID";
            this.colItemId.Width = 200;
            // 
            // colQty
            // 
            this.colQty.Text = "Qty";
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
            this.pnlSubMotherTop.Size = new System.Drawing.Size(315, 30);
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
            // frmQCMTranMergeQCMBatch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmQCMTranMergeQCMBatch";
            this.Tag = "QCM2004";
            this.Text = "Merge QCM Batch";
            this.Load += new System.EventHandler(this.frmQCMTranMergeQCMBatch_Load);
            this.Activated += new System.EventHandler(this.frmQCMTranMergeQCMBatch_Activated);
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
            this.pnlTargetBatchInfo.ResumeLayout(false);
            this.grpTargetBatchInfo.ResumeLayout(false);
            this.pnlTagetBatchnfoMain.ResumeLayout(false);
            this.grpMoveQty.ResumeLayout(false);
            this.grpMoveQty.PerformLayout();
            this.pnlTargetBatch.ResumeLayout(false);
            this.grpTargetBatch.ResumeLayout(false);
            this.grpTargetBatch.PerformLayout();
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
            this.grpSubBatchInfo.ResumeLayout(false);
            this.pnlSubChild.ResumeLayout(false);
            this.grpChildSubLot.ResumeLayout(false);
            this.pnlSubChildMid.ResumeLayout(false);
            this.pnlSubChildTop.ResumeLayout(false);
            this.pnlSubChildTop.PerformLayout();
            this.pnlSubMother.ResumeLayout(false);
            this.grpMotherSubBatch.ResumeLayout(false);
            this.pnlSubMotherMid.ResumeLayout(false);
            this.pnlSubMotherTop.ResumeLayout(false);
            this.pnlSubMotherTop.PerformLayout();
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
        //       - Optional ByVal ProcStep As String ("1", "2", "3", "4")
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
                        ctrlTargetBatchInfo.ClearBatchInfo();
                        
                        MPCF.InitListView(lisSource);
                        MPCF.InitListView(lisTarget);
                        
                        txtQty1.Text = "0";
                        txtQty2.Text = "0";
                        txtQty3.Text = "0";
                        
                        txtMoveQty1.Text = "0";
                        txtMoveQty2.Text = "0";
                        txtMoveQty3.Text = "0";
                        break;
                        
                    case '2':
                        
                        //Lot ?ÖÎ†• ??Enter ??Lot ?ïÎ≥¥ Ï∂úÎ†•
                        MPCF.FieldClear(this, txtBatchID, null, null, null, null, false);
                        ctrlTargetBatchInfo.ClearBatchInfo();
                        if (ctrlBatchInfo.ViewBatchInformation(txtBatchID.Text, "") == false)
                        {
                            txtBatchID.Focus();
                            return;
                        }
                        
                        txtQty1.Text = ctrlBatchInfo.Qty1;
                        //txtQty2.Text = ctrlBatchInfo.Qty2;
                        //txtQty3.Text = ctrlBatchInfo.Qty3;
                        
                        if (View_Batch_Item_List(lisSource, txtBatchID.Text, ctrlBatchInfo.InspSet, MPCF.ToInt(ctrlBatchInfo.InspSetVersion)) == false)
                        {
                            return;
                        }
                        break;
                        
                    case '3':
                        
                        //Target Lot ?ÖÎ†• ??Enter ??Lot ?ïÎ≥¥ Ï∂úÎ†•
                        if (ctrlTargetBatchInfo.ViewBatchInformation(txtTargetBatchID.Text, "") == false)
                        {
                            txtTargetBatchID.Focus();
                            return;
                        }
                        
                        if (View_Batch_Item_List(lisTarget, txtTargetBatchID.Text, ctrlTargetBatchInfo.InspSet, MPCF.ToInt(ctrlTargetBatchInfo.InspSetVersion)) == false)
                        {
                            return;
                        }
                        break;
                        
                    case '4':
                        
                        //Merge ?±Í≥µ??Lot Info Reload
                        MPCF.FieldClear(this, txtBatchID, txtTargetBatchID, null, null, null, false);
                        if (ctrlTargetBatchInfo.ViewBatchInformation(txtTargetBatchID.Text, "") == false)
                        {
                            txtTargetBatchID.Focus();
                            return;
                        }
                        ctrlBatchInfo.ClearBatchInfo();
                        MPCF.InitListView(lisSource);
                        if (View_Batch_Item_List(lisTarget, txtTargetBatchID.Text, ctrlTargetBatchInfo.InspSet, MPCF.ToInt(ctrlTargetBatchInfo.InspSetVersion)) == false)
                        {
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //Private Sub MoveSublot()
        //    Dim i As Integer
        //    Dim iRow As Integer
        //    Dim iCnt As Integer
        //    Dim sSublotID As String
        
        //    If Val(txtQty1.Text) < 1 Then Exit Sub
        
        //    iCnt = 0
        //    For i = 0 To lisSource.Items.Count - 1
        //        If lisSource.Items[i].ImageIndex = SMALLICON_INDEX.IDX_SLOT_FULL Then
        //            sSublotID = lisSource.Items[i].SubItems(1).Text
        //            iRow = FindListItemIndex(lisTarget, sSublotID, 1)
        //            If iRow < 0 Then
        //                For iRow = 0 To lisTarget.Items.Count - 1
        //                    If lisTarget.Items(iRow).SubItems(1).Text.Trim = "" Then Exit For
        //                Next
        
        //                lisSource.Items[i].ImageIndex = SMALLICON_INDEX.IDX_SLOT_EMPTY
        //                lisTarget.Items(iRow).ImageIndex = SMALLICON_INDEX.IDX_SLOT_FULL_NEW
        //                lisTarget.Items(iRow).SubItems(1).Text = sSublotID
        //                lisTarget.Items(iRow).Tag = lisSource.Items[i].Tag
        //                txtMoveQty1.Text = CStr(Val(txtMoveQty1.Text) + 1)
        //                txtQty1.Text = CStr(Val(txtQty1.Text) - 1)
        //                txtMoveQty2.Text = CStr(Val(txtMoveQty2.Text) + lisSource.Items[i].Tag)
        //                txtQty2.Text = CStr(Val(txtQty2.Text) - lisSource.Items[i].Tag)
        
        //                iCnt += 1
        //            End If
        //        End If
        //    Next
        
        //    txtMoveQty3.Text = txtQty3.Text
        
        //End Sub
        
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
                case "MERGE_BATCH":

                    if (MPCF.CheckValue(txtBatchID, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtTargetBatchID, 1, false, false, "", "", "") == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        txtTargetBatchID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(txtBatchID.Text) == MPCF.Trim(txtTargetBatchID.Text))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(307));
                        tabTran.SelectedTab = tbpGeneral;
                        txtTargetBatchID.Focus();
                        return false;
                    }
                    //MoveQty Validation
                    if (MPCF.Trim(txtMoveQty1.Tag) != "")
                    {
                        if (MPCF.CheckValue(txtMoveQty1, 1, false, false, "", "", "") == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtMoveQty1.Focus();
                            return false;
                        }
                    }
                    if (MPCF.Trim(txtMoveQty2.Tag) != "")
                    {
                        if (MPCF.CheckValue(txtMoveQty2, 1, false, false, "", "", "") == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtMoveQty2.Focus();
                            return false;
                        }
                    }
                    if (MPCF.Trim(txtMoveQty3.Tag) != "")
                    {
                        if (MPCF.CheckValue(txtMoveQty3, 1, false, false, "", "", "") == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtMoveQty3.Focus();
                            return false;
                        }
                    }
                    if (txtMoveQty1.Text != "" && txtMoveQty1.Text != "0")
                    {
                        if (MPCF.ToDbl(MPCF.Trim(ctrlBatchInfo.Qty1)) < MPCF.ToDbl(txtMoveQty1.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(136));
                            tabTran.SelectedTab = tbpGeneral;
                            txtMoveQty1.Text = "0";
                            txtMoveQty1.Focus();
                            return false;
                        }
                    }
                    //if (txtMoveQty2.Text != "" && txtMoveQty2.Text != "0")
                    //{
                    //    if (MPCF.ToDbl(MPCF.Trim(ctrlBatchInfo.Qty2)) < MPCF.ToDbl(txtMoveQty2.Text))
                    //    {
                    //        MPCF.ShowMsgBox(MPCF.GetMessage(136));
                    //        tabTran.SelectedTab = tbpGeneral;
                    //        txtMoveQty2.Text = "0";
                    //        txtMoveQty2.Focus();
                    //        return false;
                    //    }
                    //}
                    //if (txtMoveQty3.Text != "" && txtMoveQty3.Text != "0")
                    //{
                    //    if (MPCF.ToDbl(MPCF.Trim(ctrlBatchInfo.Qty3)) < MPCF.ToDbl(txtMoveQty3.Text))
                    //    {
                    //        MPCF.ShowMsgBox(MPCF.GetMessage(136));
                    //        tabTran.SelectedTab = tbpGeneral;
                    //        txtMoveQty3.Text = "0";
                    //        txtMoveQty3.Focus();
                    //        return false;
                    //    }
                    //}
                    //CMF Validation
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
                default:
                    
                    break;
            }
            
            return true;
            
        }
        
        //
        // Merge_Batch()
        //       - Merge Batch
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Merge_Batch(char ProcStep)
        {
            TRSNode in_node = new TRSNode("MERGE_BATCH_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);                
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(ctrlBatchInfo.HistSeq));
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddString("INSP_TYPE", ctrlBatchInfo.InspType);
                in_node.AddString("INSP_SET_ID", ctrlBatchInfo.InspSet);
                in_node.AddString("MAT_ID", ctrlBatchInfo.MatID);
                in_node.AddInt("MAT_VER", ctrlBatchInfo.MatVer);

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

                in_node.AddString("TARGET_BATCH_ID", MPCF.Trim(txtTargetBatchID.Text));
                
                //SetMergeBatch(Merge_Batch_In)

                if (txtMoveQty1.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_1", MPCF.ToDbl(MPCF.Trim(txtMoveQty1.Text)));
                }
                if (txtMoveQty2.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_2", MPCF.ToDbl(MPCF.Trim(txtMoveQty2.Text)));
                }
                if (txtMoveQty3.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_3", MPCF.ToDbl(MPCF.Trim(txtMoveQty3.Text)));
                }
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("QCM", "QCM_Merge_Batch", in_node, ref out_node) == false)
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
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("VIEW_BATCH_ITEM_LIST_OUT"));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("VIEW_BATCH_ITEM_LIST_OUT"));
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
        
        private void frmQCMTranMergeQCMBatch_Load(object sender, System.EventArgs e)
        {
            this.tabTran.TabPages.Remove(this.tbpCMF);
            this.tabTran.Controls.Add(this.tbpCMF);
            
            pnlTranTime.Visible = MPGO.UseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
        }
        
        private void frmQCMTranMergeQCMBatch_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (bLoadFlag == false)
                {
                    
                    ClearData('1');
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_QCM_MERGE, "lblCMF", "cdvCMF", grpCMF);
                    
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
        
        private void txtTargetBatchID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13)
            {
                ClearData('3');
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("MERGE_BATCH") == true)
                {
                    if (Merge_Batch('1') == false)
                    {
                        return;
                    }

                    ClearData('4');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        //Private Sub lisTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lisTarget.Click
        
        //    Dim i As Integer
        //    Dim Index As Integer
        
        //    If Trim(txtBatchID.Text) = "" Then
        //        ShowMsgBox(GetMessage(173))
        //        txtBatchID.Focus()
        //        Exit Sub
        //    End If
        
        //    If Trim(txtTargetBatchID.Text) = "" Then
        //        ShowMsgBox(GetMessage(173))
        //        tabTran.TabIndex = 0
        //        txtTargetBatchID.Focus()
        //        Exit Sub
        //    End If
        
        //    If lisSource.SelectedItems.Count < 1 Then
        //        Exit Sub
        //    ElseIf lisTarget.SelectedItems.Count < 1 Then
        //        ShowMsgBox(GetMessage(176))
        //        Exit Sub
        //    ElseIf lisTarget.SelectedItems.Count = 0 Then
        //        ShowMsgBox(GetMessage(176))
        //        Exit Sub
        //    End If
        
        //    If IsNumeric(txtQty1.Text) = False Then
        //        txtQty1.Text = "0"
        //    End If
        //    If IsNumeric(txtMoveQty1.Text) = False Then
        //        txtMoveQty1.Text = "0"
        //    End If
        
        //    Index = lisTarget.SelectedItems(0).Index
        
        //    For i = 0 To lisSource.Items.Count - 1
        //        If lisSource.Items[i].Selected = True Then
        //            If lisTarget.Items(Index).ImageIndex <> SMALLICON_INDEX.IDX_SLOT_EMPTY Then
        //                Exit For
        //            Else
        //                If Val(txtQty1.Text) = 0 Then
        //                    Exit For
        //                Else
        //                    txtMoveQty1.Text = Val(txtMoveQty1.Text) + 1
        //                    txtQty1.Text = Val(txtQty1.Text) - 1
        //                    txtMoveQty2.Text = Val(txtMoveQty2.Text) + Val(lisSource.Items[i].Tag)
        //                    txtQty2.Text = Val(txtQty2.Text) - Val(lisSource.Items[i].Tag)
        //                End If
        //                lisTarget.Items(Index).Tag = lisSource.Items[i].Tag
        //                lisTarget.Items(Index).SubItems(1).Text = lisSource.Items[i].SubItems(1).Text
        //                lisTarget.Items(Index).ImageIndex = SMALLICON_INDEX.IDX_SLOT_FULL_NEW
        //                lisTarget.Items(Index).Selected = True
        //                lisTarget.Items(Index).EnsureVisible()
        //                lisSource.Items[i].ImageIndex = SMALLICON_INDEX.IDX_SLOT_EMPTY
        //                lisSource.Items[i].Selected = False
        //                Index = Index + 1
        //                'lisTarget.SelectedItem.Selected = False
        //                If Index <= lisTarget.Items.Count Then
        //                    '    lisTarget.ListItems(Index).Selected = True
        //                Else
        //                    Exit For
        //                End If
        //            End If
        //        End If
        //    Next i
        
        //    Exit Sub
        
        //End Sub
        
        //Private Sub lisTarget_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lisTarget.DoubleClick
        //    Dim i As Integer
        
        //    For i = 0 To lisSource.SelectedItems.Count - 1
        //        lisSource.SelectedItems[i].Selected = False
        //    Next
        //    If lisTarget.SelectedItems(0).ImageIndex <> SMALLICON_INDEX.IDX_SLOT_FULL_NEW Then
        //        Exit Sub
        //    End If
        
        //    If IsNumeric(txtQty1.Text) = False Then
        //        txtQty1.Text = "0"
        //    End If
        //    If IsNumeric(txtMoveQty1.Text) = False Then
        //        txtMoveQty1.Text = "0"
        //    End If
        
        //    If FindListItem(lisSource, lisTarget.SelectedItems(0).SubItems(1).Text, 1) = True Then
        //        If Val(txtMoveQty1.Text) <= 0 Then
        //            Exit Sub
        //        End If
        //        txtMoveQty1.Text = Val(txtMoveQty1.Text) - 1
        //        txtQty1.Text = Val(txtQty1.Text) + 1
        //        txtMoveQty2.Text = Val(txtMoveQty2.Text) - Val(lisTarget.Items[i].Tag)
        //        txtQty2.Text = Val(txtQty2.Text) + Val(lisTarget.Items[i].Tag)
        //        lisSource.SelectedItems(0).SubItems(1).Text = lisTarget.SelectedItems(0).SubItems(1).Text
        //        lisSource.SelectedItems(0).ImageIndex = SMALLICON_INDEX.IDX_SLOT_FULL
        //        lisTarget.SelectedItems(0).SubItems(1).Text = ""
        //        lisTarget.SelectedItems(0).ImageIndex = SMALLICON_INDEX.IDX_SLOT_EMPTY
        //    End If
        
        //End Sub
        
    }
    
    //#End If
    
}
